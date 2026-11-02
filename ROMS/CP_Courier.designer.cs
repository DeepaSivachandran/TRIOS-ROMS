namespace ROMS
{
    partial class CP_Courier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Courier));
            this.epCourier = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdCourier = new System.Windows.Forms.GroupBox();
            this.txtCourierNameEnglish = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.txtLandmark = new System.Windows.Forms.TextBox();
            this.txtCityName = new System.Windows.Forms.TextBox();
            this.txtPincode = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCourierNameTamil = new System.Windows.Forms.TextBox();
            this.txtDUserName = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbAddress = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.epCourier)).BeginInit();
            this.grdCourier.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.grbAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // epCourier
            // 
            this.epCourier.ContainerControl = this;
            // 
            // grdCourier
            // 
            this.grdCourier.Controls.Add(this.grbAddress);
            this.grdCourier.Controls.Add(this.txtShortName);
            this.grdCourier.Controls.Add(this.textBox9);
            this.grdCourier.Controls.Add(this.txtStatus);
            this.grdCourier.Controls.Add(this.pnlStatus);
            this.grdCourier.Controls.Add(this.txtCourierNameEnglish);
            this.grdCourier.Controls.Add(this.textBox10);
            this.grdCourier.Controls.Add(this.btnClose);
            this.grdCourier.Controls.Add(this.btnSave);
            this.grdCourier.Controls.Add(this.txtCourierNameTamil);
            this.grdCourier.Controls.Add(this.txtDUserName);
            this.grdCourier.Location = new System.Drawing.Point(12, 2);
            this.grdCourier.Name = "grdCourier";
            this.grdCourier.Size = new System.Drawing.Size(848, 295);
            this.grdCourier.TabIndex = 12;
            this.grdCourier.TabStop = false;
            // 
            // txtCourierNameEnglish
            // 
            this.txtCourierNameEnglish.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourierNameEnglish.Location = new System.Drawing.Point(142, 27);
            this.txtCourierNameEnglish.MaxLength = 100;
            this.txtCourierNameEnglish.Name = "txtCourierNameEnglish";
            this.txtCourierNameEnglish.Size = new System.Drawing.Size(279, 27);
            this.txtCourierNameEnglish.TabIndex = 32;
            this.txtCourierNameEnglish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCourierNameEnglish_KeyDown);
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Control;
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(12, 27);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(130, 27);
            this.textBox10.TabIndex = 31;
            this.textBox10.Text = "Courier Name in English";
            // 
            // cmbState
            // 
            this.cmbState.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(136, 50);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(112, 28);
            this.cmbState.TabIndex = 28;
            this.cmbState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbState_KeyDown);
            this.cmbState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbState_KeyPress);
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(303, 50);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(112, 28);
            this.cmbDistrict.TabIndex = 27;
            this.cmbDistrict.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDistrict_KeyDown);
            this.cmbDistrict.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDistrict_KeyPress);
            // 
            // txtLandmark
            // 
            this.txtLandmark.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLandmark.Location = new System.Drawing.Point(541, 78);
            this.txtLandmark.MaxLength = 6;
            this.txtLandmark.Multiline = true;
            this.txtLandmark.Name = "txtLandmark";
            this.txtLandmark.Size = new System.Drawing.Size(279, 69);
            this.txtLandmark.TabIndex = 26;
            this.txtLandmark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLandmark_KeyDown);
            // 
            // txtCityName
            // 
            this.txtCityName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCityName.Location = new System.Drawing.Point(541, 51);
            this.txtCityName.MaxLength = 100;
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(168, 27);
            this.txtCityName.TabIndex = 25;
            this.txtCityName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCityName_KeyDown);
            // 
            // txtPincode
            // 
            this.txtPincode.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPincode.Location = new System.Drawing.Point(760, 51);
            this.txtPincode.MaxLength = 6;
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.Size = new System.Drawing.Size(60, 27);
            this.txtPincode.TabIndex = 24;
            this.txtPincode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPincode_KeyDown);
            this.txtPincode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPincode_KeyPress);
            // 
            // txtArea
            // 
            this.txtArea.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.Location = new System.Drawing.Point(136, 78);
            this.txtArea.MaxLength = 100;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(279, 27);
            this.txtArea.TabIndex = 23;
            this.txtArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArea_KeyDown);
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress2.Location = new System.Drawing.Point(541, 24);
            this.txtAddress2.MaxLength = 100;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(279, 27);
            this.txtAddress2.TabIndex = 22;
            this.txtAddress2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress2_KeyDown);
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress1.Location = new System.Drawing.Point(136, 24);
            this.txtAddress1.MaxLength = 100;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(279, 27);
            this.txtAddress1.TabIndex = 21;
            this.txtAddress1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress1_KeyDown);
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(415, 78);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(126, 27);
            this.textBox8.TabIndex = 20;
            this.textBox8.Text = "Landmark";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(709, 51);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(51, 27);
            this.textBox7.TabIndex = 19;
            this.textBox7.Text = "Pincode";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(6, 51);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(130, 27);
            this.textBox6.TabIndex = 18;
            this.textBox6.Text = "State";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(6, 78);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(130, 27);
            this.textBox5.TabIndex = 17;
            this.textBox5.Text = "Area";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(415, 51);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(126, 27);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "City";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(248, 51);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(56, 27);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "District";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(415, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(126, 27);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "Address 2";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(130, 27);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Address 1";
            // 
            // txtCourierNameTamil
            // 
            this.txtCourierNameTamil.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F);
            this.txtCourierNameTamil.Location = new System.Drawing.Point(547, 27);
            this.txtCourierNameTamil.MaxLength = 100;
            this.txtCourierNameTamil.Name = "txtCourierNameTamil";
            this.txtCourierNameTamil.Size = new System.Drawing.Size(279, 27);
            this.txtCourierNameTamil.TabIndex = 12;
            this.txtCourierNameTamil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCourierNameTamil_KeyDown);
            // 
            // txtDUserName
            // 
            this.txtDUserName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDUserName.Enabled = false;
            this.txtDUserName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUserName.Location = new System.Drawing.Point(421, 27);
            this.txtDUserName.Name = "txtDUserName";
            this.txtDUserName.ReadOnly = true;
            this.txtDUserName.Size = new System.Drawing.Size(130, 27);
            this.txtDUserName.TabIndex = 11;
            this.txtDUserName.Text = "Courier Name in Tamil";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtStatus.Location = new System.Drawing.Point(12, 248);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(130, 27);
            this.txtStatus.TabIndex = 34;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.pnlStatus.Location = new System.Drawing.Point(142, 248);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(279, 27);
            this.pnlStatus.TabIndex = 33;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(57, 1);
            this.rbActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(60, 24);
            this.rbActive.TabIndex = 6;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbActive_KeyDown);
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInActive.Location = new System.Drawing.Point(125, 1);
            this.rbInActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 6;
            this.rbInActive.Text = "Inactive";
            this.rbInActive.UseVisualStyleBackColor = true;
            this.rbInActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbInActive_KeyDown);
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(12, 54);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(130, 27);
            this.textBox9.TabIndex = 35;
            this.textBox9.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F);
            this.txtShortName.Location = new System.Drawing.Point(142, 54);
            this.txtShortName.MaxLength = 20;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(112, 27);
            this.txtShortName.TabIndex = 36;
            this.txtShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortName_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(746, 245);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 33);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(660, 245);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // grbAddress
            // 
            this.grbAddress.Controls.Add(this.textBox1);
            this.grbAddress.Controls.Add(this.txtAddress1);
            this.grbAddress.Controls.Add(this.textBox2);
            this.grbAddress.Controls.Add(this.txtAddress2);
            this.grbAddress.Controls.Add(this.cmbState);
            this.grbAddress.Controls.Add(this.textBox6);
            this.grbAddress.Controls.Add(this.cmbDistrict);
            this.grbAddress.Controls.Add(this.textBox3);
            this.grbAddress.Controls.Add(this.textBox4);
            this.grbAddress.Controls.Add(this.txtLandmark);
            this.grbAddress.Controls.Add(this.txtCityName);
            this.grbAddress.Controls.Add(this.textBox8);
            this.grbAddress.Controls.Add(this.txtPincode);
            this.grbAddress.Controls.Add(this.textBox5);
            this.grbAddress.Controls.Add(this.txtArea);
            this.grbAddress.Controls.Add(this.textBox7);
            this.grbAddress.Location = new System.Drawing.Point(6, 83);
            this.grbAddress.Name = "grbAddress";
            this.grbAddress.Size = new System.Drawing.Size(830, 158);
            this.grbAddress.TabIndex = 37;
            this.grbAddress.TabStop = false;
            this.grbAddress.Text = "Address Details";
            // 
            // CP_Courier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(870, 308);
            this.Controls.Add(this.grdCourier);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Courier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Courier Details";
            this.Load += new System.EventHandler(this.CP_Courier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCourier)).EndInit();
            this.grdCourier.ResumeLayout(false);
            this.grdCourier.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grbAddress.ResumeLayout(false);
            this.grbAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epCourier;
        private System.Windows.Forms.GroupBox grdCourier;
        private System.Windows.Forms.TextBox txtDUserName;
        public System.Windows.Forms.TextBox txtCourierNameTamil;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.TextBox txtAddress1;
        public System.Windows.Forms.TextBox txtAddress2;
        public System.Windows.Forms.TextBox txtArea;
        public System.Windows.Forms.TextBox txtPincode;
        private System.Windows.Forms.TextBox txtCityName;
        public System.Windows.Forms.TextBox txtLandmark;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtCourierNameEnglish;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.TextBox textBox9;
        public System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.GroupBox grbAddress;
    }
}