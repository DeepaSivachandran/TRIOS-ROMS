namespace ROMS
{
    partial class INV_StockHold_Location
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV_StockHold_Location));
            this.errLocation = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDPasskey = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtStockLocation = new System.Windows.Forms.TextBox();
            this.lblStockLocationCode = new System.Windows.Forms.Label();
            this.lvStockLocation = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnMove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // errLocation
            // 
            this.errLocation.ContainerControl = this;
            // 
            // txtDPasskey
            // 
            this.txtDPasskey.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPasskey.Enabled = false;
            this.txtDPasskey.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDPasskey.Location = new System.Drawing.Point(12, 14);
            this.txtDPasskey.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDPasskey.Name = "txtDPasskey";
            this.txtDPasskey.ReadOnly = true;
            this.txtDPasskey.Size = new System.Drawing.Size(62, 28);
            this.txtDPasskey.TabIndex = 11;
            this.txtDPasskey.Text = "Location";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(74, 42);
            this.txtQty.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtQty.MaxLength = 10;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(80, 28);
            this.txtQty.TabIndex = 1;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.Enter += new System.EventHandler(this.TxtQty_Enter);
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQty_KeyDown);
            this.txtQty.Leave += new System.EventHandler(this.TxtQty_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 42);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(62, 28);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Hold Qty";
            // 
            // txtStockLocation
            // 
            this.txtStockLocation.Location = new System.Drawing.Point(74, 14);
            this.txtStockLocation.MaxLength = 50;
            this.txtStockLocation.Name = "txtStockLocation";
            this.txtStockLocation.Size = new System.Drawing.Size(203, 28);
            this.txtStockLocation.TabIndex = 0;
            this.txtStockLocation.TextChanged += new System.EventHandler(this.TxtStockLocation_TextChanged);
            this.txtStockLocation.Enter += new System.EventHandler(this.TxtStockLocation_Enter);
            this.txtStockLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtStockLocation_KeyDown);
            this.txtStockLocation.Leave += new System.EventHandler(this.TxtStockLocation_Leave);
            // 
            // lblStockLocationCode
            // 
            this.lblStockLocationCode.AutoSize = true;
            this.lblStockLocationCode.Location = new System.Drawing.Point(232, 55);
            this.lblStockLocationCode.Name = "lblStockLocationCode";
            this.lblStockLocationCode.Size = new System.Drawing.Size(16, 20);
            this.lblStockLocationCode.TabIndex = 1111247;
            this.lblStockLocationCode.Text = "0";
            this.lblStockLocationCode.Visible = false;
            // 
            // lvStockLocation
            // 
            this.lvStockLocation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvStockLocation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvStockLocation.HideSelection = false;
            this.lvStockLocation.Location = new System.Drawing.Point(74, 42);
            this.lvStockLocation.Name = "lvStockLocation";
            this.lvStockLocation.Size = new System.Drawing.Size(203, 78);
            this.lvStockLocation.TabIndex = 1111248;
            this.lvStockLocation.UseCompatibleStateImageBehavior = false;
            this.lvStockLocation.View = System.Windows.Forms.View.Details;
            this.lvStockLocation.Visible = false;
            this.lvStockLocation.DoubleClick += new System.EventHandler(this.LvStockLocation_DoubleClick);
            this.lvStockLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvStockLocation_KeyDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 10;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 0;
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnMove.Image = global::ROMS.Properties.Resources.add;
            this.btnMove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMove.Location = new System.Drawing.Point(203, 78);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(74, 29);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "Move";
            this.btnMove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.BtnMove_Click);
            this.btnMove.Enter += new System.EventHandler(this.BtnMove_Enter);
            this.btnMove.Leave += new System.EventHandler(this.BtnMove_Leave);
            // 
            // INV_StockHold_Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(288, 121);
            this.Controls.Add(this.lvStockLocation);
            this.Controls.Add(this.lblStockLocationCode);
            this.Controls.Add(this.txtStockLocation);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtDPasskey);
            this.Controls.Add(this.btnMove);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "INV_StockHold_Location";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Destination";
            this.Load += new System.EventHandler(this.INV_StockHold_Location_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errLocation;
        private System.Windows.Forms.TextBox txtDPasskey;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtStockLocation;
        private System.Windows.Forms.Label lblStockLocationCode;
        public System.Windows.Forms.ListView lvStockLocation;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.Button btnMove;
    }
}