namespace ROMS
{
    partial class ProductDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductDetails));
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.grbTools = new System.Windows.Forms.GroupBox();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnClkRotate = new System.Windows.Forms.Button();
            this.btnAnticlkRotation = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.pnlImageContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.grbSpecification = new System.Windows.Forms.GroupBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblSubgroup = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTechnicalName = new System.Windows.Forms.Label();
            this.lblTamilName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdSpecification = new System.Windows.Forms.DataGridView();
            this.clmAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMeasurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNext = new System.Windows.Forms.Button();
            this.errWeight = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.grbForm.SuspendLayout();
            this.grbTools.SuspendLayout();
            this.pnlImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbSpecification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.grbTools);
            this.grbForm.Controls.Add(this.pnlImageContainer);
            this.grbForm.Controls.Add(this.lblCount);
            this.grbForm.Controls.Add(this.btnPrev);
            this.grbForm.Controls.Add(this.grbSpecification);
            this.grbForm.Controls.Add(this.btnNext);
            this.grbForm.Location = new System.Drawing.Point(17, 10);
            this.grbForm.Name = "grbForm";
            this.grbForm.Size = new System.Drawing.Size(448, 451);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // grbTools
            // 
            this.grbTools.Controls.Add(this.btnPlus);
            this.grbTools.Controls.Add(this.btnClkRotate);
            this.grbTools.Controls.Add(this.btnAnticlkRotation);
            this.grbTools.Controls.Add(this.btnMinus);
            this.grbTools.Location = new System.Drawing.Point(42, 14);
            this.grbTools.Name = "grbTools";
            this.grbTools.Size = new System.Drawing.Size(354, 45);
            this.grbTools.TabIndex = 1111262;
            this.grbTools.TabStop = false;
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnPlus.Image = global::ROMS.Properties.Resources.zoom_in;
            this.btnPlus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlus.Location = new System.Drawing.Point(109, 12);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(25, 27);
            this.btnPlus.TabIndex = 6;
            this.btnPlus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.BtnPlus_Click);
            // 
            // btnClkRotate
            // 
            this.btnClkRotate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClkRotate.Image = global::ROMS.Properties.Resources.right_rotate;
            this.btnClkRotate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClkRotate.Location = new System.Drawing.Point(202, 12);
            this.btnClkRotate.Name = "btnClkRotate";
            this.btnClkRotate.Size = new System.Drawing.Size(25, 27);
            this.btnClkRotate.TabIndex = 4;
            this.btnClkRotate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClkRotate.UseVisualStyleBackColor = true;
            this.btnClkRotate.Click += new System.EventHandler(this.BtnClkRotate_Click);
            // 
            // btnAnticlkRotation
            // 
            this.btnAnticlkRotation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnAnticlkRotation.Image = global::ROMS.Properties.Resources.left_rotate;
            this.btnAnticlkRotation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnticlkRotation.Location = new System.Drawing.Point(171, 12);
            this.btnAnticlkRotation.Name = "btnAnticlkRotation";
            this.btnAnticlkRotation.Size = new System.Drawing.Size(25, 27);
            this.btnAnticlkRotation.TabIndex = 5;
            this.btnAnticlkRotation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnticlkRotation.UseVisualStyleBackColor = true;
            this.btnAnticlkRotation.Click += new System.EventHandler(this.BtnAnticlkRotation_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnMinus.Image = global::ROMS.Properties.Resources.zoom_out;
            this.btnMinus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinus.Location = new System.Drawing.Point(140, 12);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(25, 27);
            this.btnMinus.TabIndex = 7;
            this.btnMinus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.BtnMinus_Click);
            // 
            // pnlImageContainer
            // 
            this.pnlImageContainer.Controls.Add(this.pictureBox1);
            this.pnlImageContainer.Location = new System.Drawing.Point(42, 61);
            this.pnlImageContainer.Name = "pnlImageContainer";
            this.pnlImageContainer.Size = new System.Drawing.Size(354, 384);
            this.pnlImageContainer.TabIndex = 1111261;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 378);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(145, 36);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(124, 20);
            this.lblCount.TabIndex = 1111260;
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnPrev.Image = global::ROMS.Properties.Resources.add___left;
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(6, 222);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(30, 27);
            this.btnPrev.TabIndex = 1111259;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // grbSpecification
            // 
            this.grbSpecification.Controls.Add(this.lblUnit);
            this.grbSpecification.Controls.Add(this.label7);
            this.grbSpecification.Controls.Add(this.lblGroup);
            this.grbSpecification.Controls.Add(this.lblSubgroup);
            this.grbSpecification.Controls.Add(this.lblBrand);
            this.grbSpecification.Controls.Add(this.label5);
            this.grbSpecification.Controls.Add(this.label4);
            this.grbSpecification.Controls.Add(this.label3);
            this.grbSpecification.Controls.Add(this.lblTechnicalName);
            this.grbSpecification.Controls.Add(this.lblTamilName);
            this.grbSpecification.Controls.Add(this.label2);
            this.grbSpecification.Controls.Add(this.label1);
            this.grbSpecification.Controls.Add(this.grdSpecification);
            this.grbSpecification.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.grbSpecification.Location = new System.Drawing.Point(454, 52);
            this.grbSpecification.Name = "grbSpecification";
            this.grbSpecification.Size = new System.Drawing.Size(357, 393);
            this.grbSpecification.TabIndex = 1111258;
            this.grbSpecification.TabStop = false;
            this.grbSpecification.Text = "Specifications";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(110, 88);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(0, 20);
            this.lblUnit.TabIndex = 1111203;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 1111202;
            this.label7.Text = "Unit                      :";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(110, 140);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(0, 20);
            this.lblGroup.TabIndex = 1111201;
            // 
            // lblSubgroup
            // 
            this.lblSubgroup.AutoSize = true;
            this.lblSubgroup.Location = new System.Drawing.Point(110, 169);
            this.lblSubgroup.Name = "lblSubgroup";
            this.lblSubgroup.Size = new System.Drawing.Size(0, 20);
            this.lblSubgroup.TabIndex = 1111200;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(110, 115);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(0, 20);
            this.lblBrand.TabIndex = 1111199;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 1111198;
            this.label5.Text = "SubGroup            :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 1111197;
            this.label4.Text = "Group                   :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 1111195;
            this.label3.Text = "Brand                   :";
            // 
            // lblTechnicalName
            // 
            this.lblTechnicalName.AutoSize = true;
            this.lblTechnicalName.Location = new System.Drawing.Point(110, 61);
            this.lblTechnicalName.Name = "lblTechnicalName";
            this.lblTechnicalName.Size = new System.Drawing.Size(0, 20);
            this.lblTechnicalName.TabIndex = 1111194;
            // 
            // lblTamilName
            // 
            this.lblTamilName.AutoSize = true;
            this.lblTamilName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamilName.Location = new System.Drawing.Point(110, 32);
            this.lblTamilName.Name = "lblTamilName";
            this.lblTamilName.Size = new System.Drawing.Size(0, 20);
            this.lblTamilName.TabIndex = 1111191;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 1111193;
            this.label2.Text = "English Name     :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1111192;
            this.label1.Text = "Tamil Name         :";
            // 
            // grdSpecification
            // 
            this.grdSpecification.AllowUserToAddRows = false;
            this.grdSpecification.AllowUserToDeleteRows = false;
            this.grdSpecification.AllowUserToResizeColumns = false;
            this.grdSpecification.AllowUserToResizeRows = false;
            this.grdSpecification.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.grdSpecification.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSpecification.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSpecification.ColumnHeadersHeight = 30;
            this.grdSpecification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSpecification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAttribute,
            this.clmValue,
            this.clmMeasurement});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSpecification.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSpecification.EnableHeadersVisualStyles = false;
            this.grdSpecification.GridColor = System.Drawing.Color.White;
            this.grdSpecification.Location = new System.Drawing.Point(13, 203);
            this.grdSpecification.Name = "grdSpecification";
            this.grdSpecification.ReadOnly = true;
            this.grdSpecification.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdSpecification.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSpecification.RowTemplate.Height = 25;
            this.grdSpecification.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSpecification.Size = new System.Drawing.Size(325, 184);
            this.grdSpecification.TabIndex = 69;
            // 
            // clmAttribute
            // 
            this.clmAttribute.HeaderText = "Attribute";
            this.clmAttribute.Name = "clmAttribute";
            this.clmAttribute.ReadOnly = true;
            // 
            // clmValue
            // 
            this.clmValue.HeaderText = "Value";
            this.clmValue.Name = "clmValue";
            this.clmValue.ReadOnly = true;
            this.clmValue.Width = 80;
            // 
            // clmMeasurement
            // 
            this.clmMeasurement.HeaderText = "Unit";
            this.clmMeasurement.Name = "clmMeasurement";
            this.clmMeasurement.ReadOnly = true;
            this.clmMeasurement.Width = 110;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnNext.Image = global::ROMS.Properties.Resources.add;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(402, 222);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 27);
            this.btnNext.TabIndex = 1111257;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // errWeight
            // 
            this.errWeight.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(390, 467);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // ProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(477, 508);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Image Details";
            this.Load += new System.EventHandler(this.PM_ProductDetails_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PM_ProductDetails_KeyDown);
            this.grbForm.ResumeLayout(false);
            this.grbTools.ResumeLayout(false);
            this.pnlImageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbSpecification.ResumeLayout(false);
            this.grbSpecification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        private System.Windows.Forms.ErrorProvider errWeight;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox grbSpecification;
        public System.Windows.Forms.DataGridView grdSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMeasurement;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel pnlImageContainer;
        private System.Windows.Forms.GroupBox grbTools;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnClkRotate;
        private System.Windows.Forms.Button btnAnticlkRotation;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTechnicalName;
        private System.Windows.Forms.Label lblTamilName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblSubgroup;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label label7;
    }
}