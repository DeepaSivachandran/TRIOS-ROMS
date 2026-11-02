namespace ROMS
{
    partial class CP_Transport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Transport));
            this.txtTransportEName = new System.Windows.Forms.TextBox();
            this.epTransport = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbForm = new System.Windows.Forms.GroupBox();
            this.grbAddress = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtLandmark = new System.Windows.Forms.TextBox();
            this.txtCityName = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.txtPincode = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.txtLandline = new System.Windows.Forms.TextBox();
            this.txtLandlineNo = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtContactPersonName = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtTransportTName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epTransport)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.grbForm.SuspendLayout();
            this.grbAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTransportEName
            // 
            this.txtTransportEName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtTransportEName.Location = new System.Drawing.Point(189, 22);
            this.txtTransportEName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTransportEName.MaxLength = 30;
            this.txtTransportEName.Name = "txtTransportEName";
            this.txtTransportEName.Size = new System.Drawing.Size(255, 27);
            this.txtTransportEName.TabIndex = 0;
            this.txtTransportEName.Enter += new System.EventHandler(this.txtTransportEName_Enter);
            this.txtTransportEName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransportEName_KeyDown);
            this.txtTransportEName.Leave += new System.EventHandler(this.txtTransportEName_Leave);
            // 
            // epTransport
            // 
            this.epTransport.ContainerControl = this;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtStatus.Location = new System.Drawing.Point(456, 264);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(91, 27);
            this.txtStatus.TabIndex = 11;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.pnlStatus.Location = new System.Drawing.Point(547, 264);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(317, 27);
            this.pnlStatus.TabIndex = 6;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(92, 1);
            this.rbActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(60, 24);
            this.rbActive.TabIndex = 6;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.Enter += new System.EventHandler(this.rbActive_Enter);
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbActive_KeyDown);
            this.rbActive.Leave += new System.EventHandler(this.rbActive_Leave);
            // 
            // rbInActive
            // 
            this.rbInActive.AutoSize = true;
            this.rbInActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInActive.Location = new System.Drawing.Point(160, 1);
            this.rbInActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 6;
            this.rbInActive.Text = "Inactive";
            this.rbInActive.UseVisualStyleBackColor = true;
            this.rbInActive.Enter += new System.EventHandler(this.rbInActive_Enter);
            this.rbInActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbInActive_KeyDown);
            this.rbInActive.Leave += new System.EventHandler(this.rbInActive_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(183, 27);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Transport Name in English";
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.grbAddress);
            this.grbForm.Controls.Add(this.txtLandline);
            this.grbForm.Controls.Add(this.txtLandlineNo);
            this.grbForm.Controls.Add(this.txtMobileNo);
            this.grbForm.Controls.Add(this.textBox5);
            this.grbForm.Controls.Add(this.textBox4);
            this.grbForm.Controls.Add(this.txtContactPersonName);
            this.grbForm.Controls.Add(this.txtShortName);
            this.grbForm.Controls.Add(this.textBox3);
            this.grbForm.Controls.Add(this.txtTransportTName);
            this.grbForm.Controls.Add(this.textBox2);
            this.grbForm.Controls.Add(this.textBox1);
            this.grbForm.Controls.Add(this.btnClose);
            this.grbForm.Controls.Add(this.txtTransportEName);
            this.grbForm.Controls.Add(this.btnSave);
            this.grbForm.Controls.Add(this.txtStatus);
            this.grbForm.Controls.Add(this.pnlStatus);
            this.grbForm.Location = new System.Drawing.Point(12, 13);
            this.grbForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Size = new System.Drawing.Size(887, 344);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // grbAddress
            // 
            this.grbAddress.Controls.Add(this.textBox6);
            this.grbAddress.Controls.Add(this.txtAddress1);
            this.grbAddress.Controls.Add(this.textBox7);
            this.grbAddress.Controls.Add(this.txtAddress2);
            this.grbAddress.Controls.Add(this.cmbState);
            this.grbAddress.Controls.Add(this.textBox8);
            this.grbAddress.Controls.Add(this.cmbDistrict);
            this.grbAddress.Controls.Add(this.textBox9);
            this.grbAddress.Controls.Add(this.textBox10);
            this.grbAddress.Controls.Add(this.txtLandmark);
            this.grbAddress.Controls.Add(this.txtCityName);
            this.grbAddress.Controls.Add(this.textBox11);
            this.grbAddress.Controls.Add(this.txtPincode);
            this.grbAddress.Controls.Add(this.textBox12);
            this.grbAddress.Controls.Add(this.txtArea);
            this.grbAddress.Controls.Add(this.textBox13);
            this.grbAddress.Location = new System.Drawing.Point(450, 13);
            this.grbAddress.Name = "grbAddress";
            this.grbAddress.Size = new System.Drawing.Size(426, 242);
            this.grbAddress.TabIndex = 38;
            this.grbAddress.TabStop = false;
            this.grbAddress.Text = "Address Details";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(6, 24);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(91, 27);
            this.textBox6.TabIndex = 13;
            this.textBox6.Text = "Address 1";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress1.Location = new System.Drawing.Point(97, 24);
            this.txtAddress1.MaxLength = 100;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(318, 27);
            this.txtAddress1.TabIndex = 21;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(6, 51);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(91, 27);
            this.textBox7.TabIndex = 14;
            this.textBox7.Text = "Address 2";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress2.Location = new System.Drawing.Point(97, 51);
            this.txtAddress2.MaxLength = 100;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(318, 27);
            this.txtAddress2.TabIndex = 22;
            // 
            // cmbState
            // 
            this.cmbState.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(97, 78);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(132, 28);
            this.cmbState.TabIndex = 28;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(6, 79);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(91, 27);
            this.textBox8.TabIndex = 18;
            this.textBox8.Text = "State";
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(287, 77);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(127, 28);
            this.cmbDistrict.TabIndex = 27;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(230, 79);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(56, 27);
            this.textBox9.TabIndex = 15;
            this.textBox9.Text = "District";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Control;
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(6, 107);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(91, 27);
            this.textBox10.TabIndex = 16;
            this.textBox10.Text = "City";
            // 
            // txtLandmark
            // 
            this.txtLandmark.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLandmark.Location = new System.Drawing.Point(97, 161);
            this.txtLandmark.MaxLength = 6;
            this.txtLandmark.Multiline = true;
            this.txtLandmark.Name = "txtLandmark";
            this.txtLandmark.Size = new System.Drawing.Size(317, 69);
            this.txtLandmark.TabIndex = 26;
            // 
            // txtCityName
            // 
            this.txtCityName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCityName.Location = new System.Drawing.Point(97, 107);
            this.txtCityName.MaxLength = 100;
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(189, 27);
            this.txtCityName.TabIndex = 25;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Control;
            this.textBox11.Enabled = false;
            this.textBox11.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(6, 161);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(91, 27);
            this.textBox11.TabIndex = 20;
            this.textBox11.Text = "Landmark";
            // 
            // txtPincode
            // 
            this.txtPincode.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPincode.Location = new System.Drawing.Point(337, 107);
            this.txtPincode.MaxLength = 6;
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.Size = new System.Drawing.Size(78, 27);
            this.txtPincode.TabIndex = 24;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.Control;
            this.textBox12.Enabled = false;
            this.textBox12.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(6, 134);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(91, 27);
            this.textBox12.TabIndex = 17;
            this.textBox12.Text = "Area";
            // 
            // txtArea
            // 
            this.txtArea.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.Location = new System.Drawing.Point(97, 134);
            this.txtArea.MaxLength = 100;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(318, 27);
            this.txtArea.TabIndex = 23;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.Control;
            this.textBox13.Enabled = false;
            this.textBox13.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(287, 107);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(51, 27);
            this.textBox13.TabIndex = 19;
            this.textBox13.Text = "Pincode";
            // 
            // txtLandline
            // 
            this.txtLandline.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtLandline.Location = new System.Drawing.Point(189, 161);
            this.txtLandline.MaxLength = 15;
            this.txtLandline.Name = "txtLandline";
            this.txtLandline.Size = new System.Drawing.Size(255, 27);
            this.txtLandline.TabIndex = 5;
            this.txtLandline.Enter += new System.EventHandler(this.txtLandline_Enter);
            this.txtLandline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLandline_KeyDown);
            this.txtLandline.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLandline_KeyPress);
            this.txtLandline.Leave += new System.EventHandler(this.txtLandline_Leave);
            // 
            // txtLandlineNo
            // 
            this.txtLandlineNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtLandlineNo.Enabled = false;
            this.txtLandlineNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtLandlineNo.Location = new System.Drawing.Point(6, 161);
            this.txtLandlineNo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtLandlineNo.Name = "txtLandlineNo";
            this.txtLandlineNo.ReadOnly = true;
            this.txtLandlineNo.Size = new System.Drawing.Size(183, 27);
            this.txtLandlineNo.TabIndex = 21;
            this.txtLandlineNo.Text = "Landline Number";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtMobileNo.Location = new System.Drawing.Point(189, 133);
            this.txtMobileNo.MaxLength = 15;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(255, 27);
            this.txtMobileNo.TabIndex = 4;
            this.txtMobileNo.Enter += new System.EventHandler(this.txtMobileNo_Enter);
            this.txtMobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNo_KeyDown);
            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNo_KeyPress);
            this.txtMobileNo.Leave += new System.EventHandler(this.txtMobileNo_Leave);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox5.Location = new System.Drawing.Point(6, 133);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(183, 27);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "Mobile Number";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(6, 105);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(183, 27);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Contact Person Name";
            // 
            // txtContactPersonName
            // 
            this.txtContactPersonName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtContactPersonName.Location = new System.Drawing.Point(189, 105);
            this.txtContactPersonName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContactPersonName.MaxLength = 50;
            this.txtContactPersonName.Name = "txtContactPersonName";
            this.txtContactPersonName.Size = new System.Drawing.Size(255, 27);
            this.txtContactPersonName.TabIndex = 3;
            this.txtContactPersonName.Enter += new System.EventHandler(this.txtContactPersonName_Enter);
            this.txtContactPersonName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactPersonName_KeyDown);
            this.txtContactPersonName.Leave += new System.EventHandler(this.txtContactPersonName_Leave);
            // 
            // txtShortName
            // 
            this.txtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtShortName.Location = new System.Drawing.Point(189, 77);
            this.txtShortName.MaxLength = 10;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(255, 27);
            this.txtShortName.TabIndex = 2;
            this.txtShortName.Enter += new System.EventHandler(this.txtShortName_Enter);
            this.txtShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortName_KeyDown);
            this.txtShortName.Leave += new System.EventHandler(this.txtShortName_Leave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox3.Location = new System.Drawing.Point(6, 77);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(183, 27);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "Short Name";
            // 
            // txtTransportTName
            // 
            this.txtTransportTName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransportTName.Location = new System.Drawing.Point(189, 49);
            this.txtTransportTName.MaxLength = 100;
            this.txtTransportTName.Name = "txtTransportTName";
            this.txtTransportTName.Size = new System.Drawing.Size(255, 27);
            this.txtTransportTName.TabIndex = 1;
            this.txtTransportTName.Enter += new System.EventHandler(this.txtTransportTName_Enter);
            this.txtTransportTName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransportTName_KeyDown);
            this.txtTransportTName.Leave += new System.EventHandler(this.txtTransportTName_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox2.Location = new System.Drawing.Point(6, 49);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(183, 27);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Transport Name in Tamil";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(802, 301);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 34);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(714, 301);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 34);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // CP_Transport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(909, 370);
            this.Controls.Add(this.grbForm);
            this.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Transport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transport Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CP_Transport_FormClosing);
            this.Load += new System.EventHandler(this.CP_Transport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Transport_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Transport_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.epTransport)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.grbForm.ResumeLayout(false);
            this.grbForm.PerformLayout();
            this.grbAddress.ResumeLayout(false);
            this.grbAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epTransport;
        public System.Windows.Forms.TextBox txtTransportEName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbForm;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtTransportTName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox txtContactPersonName;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtLandline;
        private System.Windows.Forms.TextBox txtLandlineNo;
        private System.Windows.Forms.GroupBox grbAddress;
        private System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        public System.Windows.Forms.TextBox txtLandmark;
        private System.Windows.Forms.TextBox txtCityName;
        private System.Windows.Forms.TextBox textBox11;
        public System.Windows.Forms.TextBox txtPincode;
        private System.Windows.Forms.TextBox textBox12;
        public System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox textBox13;
    }
}