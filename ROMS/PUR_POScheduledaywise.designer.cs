namespace ROMS
{
    partial class PUR_POScheduledaywise
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PUR_POScheduledaywise));
            this.errUnit = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpPOScheduledaywise = new System.Windows.Forms.GroupBox();
            this.btnPrintdaywise = new System.Windows.Forms.Button();
            this.grdHeaderview = new System.Windows.Forms.DataGridView();
            this.grdPOSchedule = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).BeginInit();
            this.grpPOScheduledaywise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHeaderview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPOSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // errUnit
            // 
            this.errUnit.ContainerControl = this;
            // 
            // grpPOScheduledaywise
            // 
            this.grpPOScheduledaywise.Controls.Add(this.btnPrintdaywise);
            this.grpPOScheduledaywise.Controls.Add(this.grdHeaderview);
            this.grpPOScheduledaywise.Controls.Add(this.grdPOSchedule);
            this.grpPOScheduledaywise.Location = new System.Drawing.Point(2, -4);
            this.grpPOScheduledaywise.Name = "grpPOScheduledaywise";
            this.grpPOScheduledaywise.Size = new System.Drawing.Size(1176, 354);
            this.grpPOScheduledaywise.TabIndex = 0;
            this.grpPOScheduledaywise.TabStop = false;
            // 
            // btnPrintdaywise
            // 
            this.btnPrintdaywise.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintdaywise.Image = global::ROMS.Properties.Resources.print;
            this.btnPrintdaywise.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintdaywise.Location = new System.Drawing.Point(1101, 29);
            this.btnPrintdaywise.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPrintdaywise.Name = "btnPrintdaywise";
            this.btnPrintdaywise.Size = new System.Drawing.Size(67, 33);
            this.btnPrintdaywise.TabIndex = 1111180;
            this.btnPrintdaywise.Text = "Print";
            this.btnPrintdaywise.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintdaywise.UseVisualStyleBackColor = true;
            this.btnPrintdaywise.Click += new System.EventHandler(this.BtnPrintdaywise_Click);
            this.btnPrintdaywise.Enter += new System.EventHandler(this.BtnPrintdaywise_Enter);
            this.btnPrintdaywise.Leave += new System.EventHandler(this.BtnPrintdaywise_Leave);
            // 
            // grdHeaderview
            // 
            this.grdHeaderview.AllowUserToAddRows = false;
            this.grdHeaderview.AllowUserToDeleteRows = false;
            this.grdHeaderview.AllowUserToResizeColumns = false;
            this.grdHeaderview.AllowUserToResizeRows = false;
            this.grdHeaderview.BackgroundColor = System.Drawing.Color.White;
            this.grdHeaderview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdHeaderview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdHeaderview.ColumnHeadersHeight = 30;
            this.grdHeaderview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdHeaderview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdHeaderview.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdHeaderview.EnableHeadersVisualStyles = false;
            this.grdHeaderview.GridColor = System.Drawing.Color.White;
            this.grdHeaderview.Location = new System.Drawing.Point(10, 69);
            this.grdHeaderview.Name = "grdHeaderview";
            this.grdHeaderview.ReadOnly = true;
            this.grdHeaderview.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdHeaderview.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdHeaderview.RowTemplate.Height = 25;
            this.grdHeaderview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdHeaderview.Size = new System.Drawing.Size(1158, 29);
            this.grdHeaderview.TabIndex = 1111179;
            // 
            // grdPOSchedule
            // 
            this.grdPOSchedule.AllowUserToAddRows = false;
            this.grdPOSchedule.AllowUserToDeleteRows = false;
            this.grdPOSchedule.AllowUserToResizeColumns = false;
            this.grdPOSchedule.AllowUserToResizeRows = false;
            this.grdPOSchedule.BackgroundColor = System.Drawing.Color.White;
            this.grdPOSchedule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPOSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdPOSchedule.ColumnHeadersHeight = 30;
            this.grdPOSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPOSchedule.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdPOSchedule.EnableHeadersVisualStyles = false;
            this.grdPOSchedule.GridColor = System.Drawing.Color.White;
            this.grdPOSchedule.Location = new System.Drawing.Point(10, 95);
            this.grdPOSchedule.Name = "grdPOSchedule";
            this.grdPOSchedule.ReadOnly = true;
            this.grdPOSchedule.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdPOSchedule.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdPOSchedule.RowTemplate.Height = 25;
            this.grdPOSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPOSchedule.Size = new System.Drawing.Size(1158, 251);
            this.grdPOSchedule.TabIndex = 1111178;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Order Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PUR_POScheduledaywise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1184, 352);
            this.Controls.Add(this.grpPOScheduledaywise);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PUR_POScheduledaywise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Day Wise Suppliers in PO Schedule";
            this.Load += new System.EventHandler(this.PUR_POScheduledaywise_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PUR_POScheduledaywise_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errUnit)).EndInit();
            this.grpPOScheduledaywise.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHeaderview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPOSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errUnit;
        private System.Windows.Forms.GroupBox grpPOScheduledaywise;
        private System.Windows.Forms.Button btnPrintdaywise;
        public System.Windows.Forms.DataGridView grdHeaderview;
        public System.Windows.Forms.DataGridView grdPOSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}