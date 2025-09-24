namespace ROMS
{
    partial class INV_StockHold_Supplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV_StockHold_Supplier));
            this.errSupplier = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDPasskey = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.LV_Supplier = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblschedule = new System.Windows.Forms.Label();
            this.grbSupplierDetails = new System.Windows.Forms.GroupBox();
            this.lblReturn = new System.Windows.Forms.Label();
            this.lblSupplierOrderpolicy = new System.Windows.Forms.Label();
            this.lblsupplierpayment = new System.Windows.Forms.Label();
            this.lblsupplierScheduletype = new System.Windows.Forms.Label();
            this.lblsupplierGST = new System.Windows.Forms.Label();
            this.lblSupplierCity = new System.Windows.Forms.Label();
            this.lblSuppliername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errSupplier)).BeginInit();
            this.grbSupplierDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // errSupplier
            // 
            this.errSupplier.ContainerControl = this;
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
            this.txtDPasskey.Size = new System.Drawing.Size(62, 33);
            this.txtDPasskey.TabIndex = 11;
            this.txtDPasskey.Text = "Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(74, 15);
            this.txtSupplier.MaxLength = 50;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(250, 32);
            this.txtSupplier.TabIndex = 0;
            this.txtSupplier.TextChanged += new System.EventHandler(this.TxtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.TxtSupplier_Enter);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.TxtSupplier_Leave);
            // 
            // LV_Supplier
            // 
            this.LV_Supplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9});
            this.LV_Supplier.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Supplier.HideSelection = false;
            this.LV_Supplier.Location = new System.Drawing.Point(74, 42);
            this.LV_Supplier.Name = "LV_Supplier";
            this.LV_Supplier.Size = new System.Drawing.Size(250, 79);
            this.LV_Supplier.TabIndex = 1111250;
            this.LV_Supplier.UseCompatibleStateImageBehavior = false;
            this.LV_Supplier.View = System.Windows.Forms.View.Details;
            this.LV_Supplier.Visible = false;
            this.LV_Supplier.DoubleClick += new System.EventHandler(this.LV_Supplier_DoubleClick);
            this.LV_Supplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_Supplier_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 50;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 0;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(243, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Submit";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.BtnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.BtnSave_Leave);
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(283, 121);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(21, 26);
            this.lblSupplierCode.TabIndex = 1111252;
            this.lblSupplierCode.Text = "0";
            this.lblSupplierCode.Visible = false;
            // 
            // lblschedule
            // 
            this.lblschedule.AutoSize = true;
            this.lblschedule.Location = new System.Drawing.Point(305, 121);
            this.lblschedule.Name = "lblschedule";
            this.lblschedule.Size = new System.Drawing.Size(21, 26);
            this.lblschedule.TabIndex = 1111253;
            this.lblschedule.Text = "0";
            this.lblschedule.Visible = false;
            // 
            // grbSupplierDetails
            // 
            this.grbSupplierDetails.Controls.Add(this.lblReturn);
            this.grbSupplierDetails.Controls.Add(this.lblSupplierOrderpolicy);
            this.grbSupplierDetails.Controls.Add(this.lblsupplierpayment);
            this.grbSupplierDetails.Controls.Add(this.lblsupplierScheduletype);
            this.grbSupplierDetails.Controls.Add(this.lblsupplierGST);
            this.grbSupplierDetails.Controls.Add(this.lblSupplierCity);
            this.grbSupplierDetails.Controls.Add(this.lblSuppliername);
            this.grbSupplierDetails.Font = new System.Drawing.Font("Oswald Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSupplierDetails.Location = new System.Drawing.Point(12, 50);
            this.grbSupplierDetails.Name = "grbSupplierDetails";
            this.grbSupplierDetails.Size = new System.Drawing.Size(209, 123);
            this.grbSupplierDetails.TabIndex = 1111254;
            this.grbSupplierDetails.TabStop = false;
            this.grbSupplierDetails.Text = "Supplier Details";
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.BackColor = System.Drawing.Color.White;
            this.lblReturn.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturn.Location = new System.Drawing.Point(166, 88);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(47, 20);
            this.lblReturn.TabIndex = 1111207;
            this.lblReturn.Text = "Retrun";
            this.lblReturn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblReturn.Visible = false;
            // 
            // lblSupplierOrderpolicy
            // 
            this.lblSupplierOrderpolicy.AutoSize = true;
            this.lblSupplierOrderpolicy.BackColor = System.Drawing.Color.White;
            this.lblSupplierOrderpolicy.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierOrderpolicy.Location = new System.Drawing.Point(6, 98);
            this.lblSupplierOrderpolicy.Name = "lblSupplierOrderpolicy";
            this.lblSupplierOrderpolicy.Size = new System.Drawing.Size(74, 20);
            this.lblSupplierOrderpolicy.TabIndex = 1111206;
            this.lblSupplierOrderpolicy.Text = "Order policy";
            this.lblSupplierOrderpolicy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsupplierpayment
            // 
            this.lblsupplierpayment.AutoSize = true;
            this.lblsupplierpayment.BackColor = System.Drawing.Color.White;
            this.lblsupplierpayment.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsupplierpayment.Location = new System.Drawing.Point(6, 81);
            this.lblsupplierpayment.Name = "lblsupplierpayment";
            this.lblsupplierpayment.Size = new System.Drawing.Size(56, 20);
            this.lblsupplierpayment.TabIndex = 1111205;
            this.lblsupplierpayment.Text = "Payment";
            this.lblsupplierpayment.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsupplierScheduletype
            // 
            this.lblsupplierScheduletype.AutoSize = true;
            this.lblsupplierScheduletype.BackColor = System.Drawing.Color.White;
            this.lblsupplierScheduletype.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsupplierScheduletype.Location = new System.Drawing.Point(6, 65);
            this.lblsupplierScheduletype.Name = "lblsupplierScheduletype";
            this.lblsupplierScheduletype.Size = new System.Drawing.Size(86, 20);
            this.lblsupplierScheduletype.TabIndex = 1111204;
            this.lblsupplierScheduletype.Text = "Schedule Type";
            this.lblsupplierScheduletype.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsupplierGST
            // 
            this.lblsupplierGST.AutoSize = true;
            this.lblsupplierGST.BackColor = System.Drawing.Color.White;
            this.lblsupplierGST.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsupplierGST.Location = new System.Drawing.Point(6, 46);
            this.lblsupplierGST.Name = "lblsupplierGST";
            this.lblsupplierGST.Size = new System.Drawing.Size(27, 20);
            this.lblsupplierGST.TabIndex = 1111203;
            this.lblsupplierGST.Text = "gst";
            this.lblsupplierGST.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSupplierCity
            // 
            this.lblSupplierCity.AutoSize = true;
            this.lblSupplierCity.BackColor = System.Drawing.Color.White;
            this.lblSupplierCity.Font = new System.Drawing.Font("Oswald Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierCity.Location = new System.Drawing.Point(6, 30);
            this.lblSupplierCity.Name = "lblSupplierCity";
            this.lblSupplierCity.Size = new System.Drawing.Size(29, 20);
            this.lblSupplierCity.TabIndex = 1111202;
            this.lblSupplierCity.Text = "city";
            this.lblSupplierCity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSuppliername
            // 
            this.lblSuppliername.AutoSize = true;
            this.lblSuppliername.BackColor = System.Drawing.Color.White;
            this.lblSuppliername.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuppliername.Location = new System.Drawing.Point(6, 13);
            this.lblSuppliername.Name = "lblSuppliername";
            this.lblSuppliername.Size = new System.Drawing.Size(59, 24);
            this.lblSuppliername.TabIndex = 1111201;
            this.lblSuppliername.Text = "supplier";
            this.lblSuppliername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // INV_StockHold_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(337, 186);
            this.Controls.Add(this.LV_Supplier);
            this.Controls.Add(this.grbSupplierDetails);
            this.Controls.Add(this.lblschedule);
            this.Controls.Add(this.lblSupplierCode);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.txtDPasskey);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "INV_StockHold_Supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.INV_StockHold_Supplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errSupplier)).EndInit();
            this.grbSupplierDetails.ResumeLayout(false);
            this.grbSupplierDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errSupplier;
        private System.Windows.Forms.TextBox txtDPasskey;
        public System.Windows.Forms.ListView LV_Supplier;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label lblSupplierCode;
        public System.Windows.Forms.Label lblschedule;
        public System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.GroupBox grbSupplierDetails;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label lblSupplierOrderpolicy;
        private System.Windows.Forms.Label lblsupplierpayment;
        private System.Windows.Forms.Label lblsupplierScheduletype;
        private System.Windows.Forms.Label lblsupplierGST;
        private System.Windows.Forms.Label lblSupplierCity;
        private System.Windows.Forms.Label lblSuppliername;
    }
}