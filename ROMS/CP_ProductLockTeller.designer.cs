namespace ROMS
{
    partial class CP_ProductLockTeller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_ProductLockTeller));
            this.epTeller = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDTeller = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtTeller = new System.Windows.Forms.TextBox();
            this.lvVerified1 = new System.Windows.Forms.ListView();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.epTeller)).BeginInit();
            this.SuspendLayout();
            // 
            // epTeller
            // 
            this.epTeller.ContainerControl = this;
            // 
            // txtDTeller
            // 
            this.txtDTeller.BackColor = System.Drawing.SystemColors.Control;
            this.txtDTeller.Enabled = false;
            this.txtDTeller.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDTeller.Location = new System.Drawing.Point(12, 14);
            this.txtDTeller.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDTeller.Name = "txtDTeller";
            this.txtDTeller.ReadOnly = true;
            this.txtDTeller.Size = new System.Drawing.Size(62, 28);
            this.txtDTeller.TabIndex = 11;
            this.txtDTeller.Text = "Teller";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Image = global::ROMS.Properties.Resources.submit;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(211, 167);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(82, 33);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnSubmit.Enter += new System.EventHandler(this.btnSubmit_Enter);
            this.btnSubmit.Leave += new System.EventHandler(this.btnSubmit_Leave);
            // 
            // txtTeller
            // 
            this.txtTeller.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtTeller.Location = new System.Drawing.Point(74, 15);
            this.txtTeller.MaxLength = 50;
            this.txtTeller.Name = "txtTeller";
            this.txtTeller.Size = new System.Drawing.Size(219, 27);
            this.txtTeller.TabIndex = 0;
            this.txtTeller.TextChanged += new System.EventHandler(this.txtTeller_TextChanged);
            this.txtTeller.Enter += new System.EventHandler(this.txtTeller_Enter);
            this.txtTeller.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTeller_KeyDown);
            this.txtTeller.Leave += new System.EventHandler(this.txtTeller_Leave);
            // 
            // lvVerified1
            // 
            this.lvVerified1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24});
            this.lvVerified1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.lvVerified1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvVerified1.HideSelection = false;
            this.lvVerified1.Location = new System.Drawing.Point(74, 42);
            this.lvVerified1.Name = "lvVerified1";
            this.lvVerified1.Size = new System.Drawing.Size(219, 164);
            this.lvVerified1.TabIndex = 1110001027;
            this.lvVerified1.UseCompatibleStateImageBehavior = false;
            this.lvVerified1.View = System.Windows.Forms.View.Details;
            this.lvVerified1.Visible = false;
            this.lvVerified1.DoubleClick += new System.EventHandler(this.lvVerified1_DoubleClick);
            this.lvVerified1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvVerified1_KeyDown);
            // 
            // columnHeader23
            // 
            this.columnHeader23.Width = 120;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Width = 0;
            // 
            // CP_ProductLockTeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(306, 214);
            this.Controls.Add(this.lvVerified1);
            this.Controls.Add(this.txtTeller);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtDTeller);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_ProductLockTeller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unlock Teller";
            this.Load += new System.EventHandler(this.CP_ProductLockTeller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epTeller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epTeller;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtDTeller;
        private System.Windows.Forms.TextBox txtTeller;
        public System.Windows.Forms.ListView lvVerified1;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
    }
}