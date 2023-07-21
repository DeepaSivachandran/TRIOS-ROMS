namespace ROMS
{
    partial class CP_Supplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Supplier));
            this.txtDCompanyName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDArea = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtDCity = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtDAContactNumber = new System.Windows.Forms.TextBox();
            this.txtAContactNumber = new System.Windows.Forms.TextBox();
            this.txtDEmail = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.lvCity = new System.Windows.Forms.ListView();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtwhatsapp = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtaddress2 = new System.Windows.Forms.TextBox();
            this.txtDPincode = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.txtPincode = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDContactNumber = new System.Windows.Forms.TextBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.errCompany = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtrupee = new System.Windows.Forms.TextBox();
            this.cmbfinance = new System.Windows.Forms.ComboBox();
            this.txtopening = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.txtcreditlimit = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.cmbSupplierType = new System.Windows.Forms.ComboBox();
            this.txtDSupplierType = new System.Windows.Forms.TextBox();
            this.cmbPaymentTerm = new System.Windows.Forms.ComboBox();
            this.txtDPaymentTerm = new System.Windows.Forms.TextBox();
            this.txtgstin = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.txtcontactName = new System.Windows.Forms.TextBox();
            this.txtDShortName = new System.Windows.Forms.TextBox();
            this.cmbDesignation = new System.Windows.Forms.ComboBox();
            this.txtDDesignation = new System.Windows.Forms.TextBox();
            this.grbEnvelopeDetails = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errCompany)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.grbEnvelopeDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDCompanyName
            // 
            this.txtDCompanyName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDCompanyName.Enabled = false;
            this.txtDCompanyName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDCompanyName.Location = new System.Drawing.Point(10, 23);
            this.txtDCompanyName.Name = "txtDCompanyName";
            this.txtDCompanyName.ReadOnly = true;
            this.txtDCompanyName.Size = new System.Drawing.Size(111, 27);
            this.txtDCompanyName.TabIndex = 14;
            this.txtDCompanyName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtName.Location = new System.Drawing.Point(121, 23);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(397, 27);
            this.txtName.TabIndex = 0;
            this.txtName.Enter += new System.EventHandler(this.txtCompanyName_Enter);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyName_KeyDown);
            this.txtName.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // txtDArea
            // 
            this.txtDArea.BackColor = System.Drawing.SystemColors.Control;
            this.txtDArea.Enabled = false;
            this.txtDArea.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDArea.Location = new System.Drawing.Point(10, 50);
            this.txtDArea.Name = "txtDArea";
            this.txtDArea.ReadOnly = true;
            this.txtDArea.Size = new System.Drawing.Size(111, 27);
            this.txtDArea.TabIndex = 16;
            this.txtDArea.Text = "Address 1";
            // 
            // txtArea
            // 
            this.txtArea.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtArea.Location = new System.Drawing.Point(121, 50);
            this.txtArea.MaxLength = 250;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(397, 27);
            this.txtArea.TabIndex = 2;
            this.txtArea.Enter += new System.EventHandler(this.txtArea_Enter_1);
            this.txtArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArea_KeyDown);
            this.txtArea.Leave += new System.EventHandler(this.txtArea_Leave);
            // 
            // txtDCity
            // 
            this.txtDCity.BackColor = System.Drawing.SystemColors.Control;
            this.txtDCity.Enabled = false;
            this.txtDCity.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDCity.Location = new System.Drawing.Point(10, 131);
            this.txtDCity.Name = "txtDCity";
            this.txtDCity.ReadOnly = true;
            this.txtDCity.Size = new System.Drawing.Size(111, 27);
            this.txtDCity.TabIndex = 17;
            this.txtDCity.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCity.Location = new System.Drawing.Point(121, 131);
            this.txtCity.MaxLength = 100;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(186, 27);
            this.txtCity.TabIndex = 5;
            this.txtCity.Enter += new System.EventHandler(this.txtCity_Enter);
            this.txtCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCity_KeyDown);
            this.txtCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCity_KeyPress);
            this.txtCity.Leave += new System.EventHandler(this.txtCity_Leave);
            // 
            // txtDAContactNumber
            // 
            this.txtDAContactNumber.BackColor = System.Drawing.SystemColors.Control;
            this.txtDAContactNumber.Enabled = false;
            this.txtDAContactNumber.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDAContactNumber.Location = new System.Drawing.Point(10, 185);
            this.txtDAContactNumber.Name = "txtDAContactNumber";
            this.txtDAContactNumber.ReadOnly = true;
            this.txtDAContactNumber.Size = new System.Drawing.Size(111, 27);
            this.txtDAContactNumber.TabIndex = 19;
            this.txtDAContactNumber.Text = "Mobile No.";
            // 
            // txtAContactNumber
            // 
            this.txtAContactNumber.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtAContactNumber.Location = new System.Drawing.Point(121, 185);
            this.txtAContactNumber.MaxLength = 10;
            this.txtAContactNumber.Name = "txtAContactNumber";
            this.txtAContactNumber.Size = new System.Drawing.Size(186, 27);
            this.txtAContactNumber.TabIndex = 9;
            this.txtAContactNumber.Enter += new System.EventHandler(this.txtAContactNumber_Enter);
            this.txtAContactNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAContactNumber_KeyDown_1);
            this.txtAContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAContactNumber_KeyPress);
            this.txtAContactNumber.Leave += new System.EventHandler(this.txtAContactNumber_Leave);
            // 
            // txtDEmail
            // 
            this.txtDEmail.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEmail.Enabled = false;
            this.txtDEmail.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDEmail.Location = new System.Drawing.Point(10, 236);
            this.txtDEmail.Name = "txtDEmail";
            this.txtDEmail.ReadOnly = true;
            this.txtDEmail.Size = new System.Drawing.Size(111, 27);
            this.txtDEmail.TabIndex = 20;
            this.txtDEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtEmail.Location = new System.Drawing.Point(121, 236);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(397, 27);
            this.txtEmail.TabIndex = 12;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // grbform
            // 
            this.grbform.Controls.Add(this.lvCity);
            this.grbform.Controls.Add(this.textBox6);
            this.grbform.Controls.Add(this.txtwhatsapp);
            this.grbform.Controls.Add(this.textBox3);
            this.grbform.Controls.Add(this.txtaddress2);
            this.grbform.Controls.Add(this.txtDPincode);
            this.grbform.Controls.Add(this.cmbState);
            this.grbform.Controls.Add(this.txtPincode);
            this.grbform.Controls.Add(this.textBox1);
            this.grbform.Controls.Add(this.txtDEmail);
            this.grbform.Controls.Add(this.txtDCompanyName);
            this.grbform.Controls.Add(this.txtEmail);
            this.grbform.Controls.Add(this.txtName);
            this.grbform.Controls.Add(this.txtDAContactNumber);
            this.grbform.Controls.Add(this.txtAContactNumber);
            this.grbform.Controls.Add(this.txtDContactNumber);
            this.grbform.Controls.Add(this.txtArea);
            this.grbform.Controls.Add(this.txtContactNumber);
            this.grbform.Controls.Add(this.txtDArea);
            this.grbform.Controls.Add(this.txtDCity);
            this.grbform.Controls.Add(this.txtCity);
            this.grbform.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbform.Location = new System.Drawing.Point(12, 3);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(530, 276);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            this.grbform.Text = "Concern Contact Details";
            // 
            // lvCity
            // 
            this.lvCity.HideSelection = false;
            this.lvCity.Location = new System.Drawing.Point(121, 157);
            this.lvCity.Name = "lvCity";
            this.lvCity.Size = new System.Drawing.Size(186, 65);
            this.lvCity.TabIndex = 62;
            this.lvCity.UseCompatibleStateImageBehavior = false;
            this.lvCity.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox6.Location = new System.Drawing.Point(10, 209);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(111, 27);
            this.textBox6.TabIndex = 61;
            this.textBox6.Text = "WhatsApp No.";
            // 
            // txtwhatsapp
            // 
            this.txtwhatsapp.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtwhatsapp.Location = new System.Drawing.Point(121, 209);
            this.txtwhatsapp.MaxLength = 10;
            this.txtwhatsapp.Name = "txtwhatsapp";
            this.txtwhatsapp.Size = new System.Drawing.Size(186, 27);
            this.txtwhatsapp.TabIndex = 11;
            this.txtwhatsapp.Enter += new System.EventHandler(this.Txtwhatsapp_Enter);
            this.txtwhatsapp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtwhatsapp_KeyDown);
            this.txtwhatsapp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtwhatsapp_KeyPress);
            this.txtwhatsapp.Leave += new System.EventHandler(this.Txtwhatsapp_Leave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox3.Location = new System.Drawing.Point(10, 77);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(111, 27);
            this.textBox3.TabIndex = 48;
            this.textBox3.Text = "Address 2";
            // 
            // txtaddress2
            // 
            this.txtaddress2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtaddress2.Location = new System.Drawing.Point(121, 77);
            this.txtaddress2.MaxLength = 250;
            this.txtaddress2.Name = "txtaddress2";
            this.txtaddress2.Size = new System.Drawing.Size(397, 27);
            this.txtaddress2.TabIndex = 3;
            this.txtaddress2.Enter += new System.EventHandler(this.Txtaddress2_Enter);
            this.txtaddress2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtaddress2_KeyDown);
            this.txtaddress2.Leave += new System.EventHandler(this.Txtaddress2_Leave);
            // 
            // txtDPincode
            // 
            this.txtDPincode.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPincode.Enabled = false;
            this.txtDPincode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDPincode.Location = new System.Drawing.Point(307, 131);
            this.txtDPincode.Name = "txtDPincode";
            this.txtDPincode.ReadOnly = true;
            this.txtDPincode.Size = new System.Drawing.Size(53, 27);
            this.txtDPincode.TabIndex = 46;
            this.txtDPincode.Text = "Pincode";
            this.txtDPincode.TextChanged += new System.EventHandler(this.TxtDPincode_TextChanged);
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(121, 104);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(186, 27);
            this.cmbState.TabIndex = 4;
            this.cmbState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbState_KeyDown);
            // 
            // txtPincode
            // 
            this.txtPincode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtPincode.Location = new System.Drawing.Point(360, 131);
            this.txtPincode.MaxLength = 6;
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.Size = new System.Drawing.Size(158, 27);
            this.txtPincode.TabIndex = 6;
            this.txtPincode.Enter += new System.EventHandler(this.txtPincode_Enter);
            this.txtPincode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPincode_KeyDown_1);
            this.txtPincode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPincode_KeyPress);
            this.txtPincode.Leave += new System.EventHandler(this.txtPincode_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox1.Location = new System.Drawing.Point(10, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(111, 27);
            this.textBox1.TabIndex = 45;
            this.textBox1.Text = "State";
            // 
            // txtDContactNumber
            // 
            this.txtDContactNumber.BackColor = System.Drawing.SystemColors.Control;
            this.txtDContactNumber.Enabled = false;
            this.txtDContactNumber.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDContactNumber.Location = new System.Drawing.Point(10, 158);
            this.txtDContactNumber.Name = "txtDContactNumber";
            this.txtDContactNumber.ReadOnly = true;
            this.txtDContactNumber.Size = new System.Drawing.Size(111, 27);
            this.txtDContactNumber.TabIndex = 18;
            this.txtDContactNumber.Text = "Phone No.";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtContactNumber.Location = new System.Drawing.Point(121, 158);
            this.txtContactNumber.MaxLength = 10;
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(186, 27);
            this.txtContactNumber.TabIndex = 7;
            this.txtContactNumber.Enter += new System.EventHandler(this.txtContactNumber_Enter);
            this.txtContactNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactNumber_KeyDown);
            this.txtContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContactNumber_KeyPress);
            this.txtContactNumber.Leave += new System.EventHandler(this.txtContactNumber_Leave);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(826, 210);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(111, 27);
            this.textBox4.TabIndex = 56;
            this.textBox4.Text = "Status";
            // 
            // errCompany
            // 
            this.errCompany.ContainerControl = this;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbPaymentTerm);
            this.groupBox4.Controls.Add(this.cmbSupplierType);
            this.groupBox4.Controls.Add(this.txtDPaymentTerm);
            this.groupBox4.Controls.Add(this.txtrupee);
            this.groupBox4.Controls.Add(this.txtgstin);
            this.groupBox4.Controls.Add(this.txtDSupplierType);
            this.groupBox4.Controls.Add(this.textBox32);
            this.groupBox4.Controls.Add(this.cmbfinance);
            this.groupBox4.Controls.Add(this.txtopening);
            this.groupBox4.Controls.Add(this.textBox22);
            this.groupBox4.Controls.Add(this.txtcreditlimit);
            this.groupBox4.Controls.Add(this.textBox28);
            this.groupBox4.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(552, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(534, 134);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Accounts  Details";
            // 
            // txtrupee
            // 
            this.txtrupee.BackColor = System.Drawing.SystemColors.Control;
            this.txtrupee.Enabled = false;
            this.txtrupee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.txtrupee.Location = new System.Drawing.Point(102, 44);
            this.txtrupee.Name = "txtrupee";
            this.txtrupee.ReadOnly = true;
            this.txtrupee.Size = new System.Drawing.Size(21, 27);
            this.txtrupee.TabIndex = 62;
            this.txtrupee.Text = "₹";
            // 
            // cmbfinance
            // 
            this.cmbfinance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfinance.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbfinance.FormattingEnabled = true;
            this.cmbfinance.Items.AddRange(new object[] {
            "CR",
            "DR"});
            this.cmbfinance.Location = new System.Drawing.Point(230, 70);
            this.cmbfinance.Name = "cmbfinance";
            this.cmbfinance.Size = new System.Drawing.Size(42, 27);
            this.cmbfinance.TabIndex = 28;
            this.cmbfinance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmbfinance_KeyDown);
            // 
            // txtopening
            // 
            this.txtopening.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtopening.Location = new System.Drawing.Point(123, 70);
            this.txtopening.MaxLength = 50;
            this.txtopening.Name = "txtopening";
            this.txtopening.Size = new System.Drawing.Size(107, 27);
            this.txtopening.TabIndex = 14;
            this.txtopening.Enter += new System.EventHandler(this.Txtopening_Enter);
            this.txtopening.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtopening_KeyDown);
            this.txtopening.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtcreditlimit_KeyPress);
            this.txtopening.Leave += new System.EventHandler(this.Txtopening_Leave);
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.SystemColors.Control;
            this.textBox22.Enabled = false;
            this.textBox22.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox22.Location = new System.Drawing.Point(12, 70);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(111, 27);
            this.textBox22.TabIndex = 26;
            this.textBox22.Text = "Opening Balance";
            // 
            // txtcreditlimit
            // 
            this.txtcreditlimit.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtcreditlimit.Location = new System.Drawing.Point(123, 44);
            this.txtcreditlimit.MaxLength = 50;
            this.txtcreditlimit.Name = "txtcreditlimit";
            this.txtcreditlimit.Size = new System.Drawing.Size(149, 27);
            this.txtcreditlimit.TabIndex = 13;
            this.txtcreditlimit.Enter += new System.EventHandler(this.Txtcreditlimit_Enter);
            this.txtcreditlimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtcreditlimit_KeyDown);
            this.txtcreditlimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtcreditlimit_KeyPress);
            this.txtcreditlimit.Leave += new System.EventHandler(this.Txtcreditlimit_Leave);
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.SystemColors.Control;
            this.textBox28.Enabled = false;
            this.textBox28.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox28.Location = new System.Drawing.Point(12, 44);
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(90, 27);
            this.textBox28.TabIndex = 16;
            this.textBox28.Text = "Credit Limit ";
            // 
            // cmbSupplierType
            // 
            this.cmbSupplierType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplierType.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplierType.FormattingEnabled = true;
            this.cmbSupplierType.Items.AddRange(new object[] {
            "Registered",
            "Composite",
            "URD"});
            this.cmbSupplierType.Location = new System.Drawing.Point(383, 44);
            this.cmbSupplierType.Name = "cmbSupplierType";
            this.cmbSupplierType.Size = new System.Drawing.Size(149, 27);
            this.cmbSupplierType.TabIndex = 67;
            this.cmbSupplierType.SelectedIndexChanged += new System.EventHandler(this.CmbESupplierType_SelectedIndexChanged);
            this.cmbSupplierType.Leave += new System.EventHandler(this.CmbESupplierType_Leave);
            // 
            // txtDSupplierType
            // 
            this.txtDSupplierType.BackColor = System.Drawing.SystemColors.Control;
            this.txtDSupplierType.Enabled = false;
            this.txtDSupplierType.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDSupplierType.Location = new System.Drawing.Point(272, 44);
            this.txtDSupplierType.Name = "txtDSupplierType";
            this.txtDSupplierType.ReadOnly = true;
            this.txtDSupplierType.Size = new System.Drawing.Size(111, 27);
            this.txtDSupplierType.TabIndex = 66;
            this.txtDSupplierType.Text = "Supplier Type";
            // 
            // cmbPaymentTerm
            // 
            this.cmbPaymentTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentTerm.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentTerm.FormattingEnabled = true;
            this.cmbPaymentTerm.Items.AddRange(new object[] {
            "Nett Amount",
            "Taxable Amount"});
            this.cmbPaymentTerm.Location = new System.Drawing.Point(123, 97);
            this.cmbPaymentTerm.Name = "cmbPaymentTerm";
            this.cmbPaymentTerm.Size = new System.Drawing.Size(149, 27);
            this.cmbPaymentTerm.TabIndex = 25;
            this.cmbPaymentTerm.SelectedIndexChanged += new System.EventHandler(this.CmbPaymentTerm_SelectedIndexChanged);
            // 
            // txtDPaymentTerm
            // 
            this.txtDPaymentTerm.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPaymentTerm.Enabled = false;
            this.txtDPaymentTerm.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDPaymentTerm.Location = new System.Drawing.Point(12, 97);
            this.txtDPaymentTerm.Name = "txtDPaymentTerm";
            this.txtDPaymentTerm.ReadOnly = true;
            this.txtDPaymentTerm.Size = new System.Drawing.Size(111, 27);
            this.txtDPaymentTerm.TabIndex = 24;
            this.txtDPaymentTerm.Text = "Payment Term";
            this.txtDPaymentTerm.TextChanged += new System.EventHandler(this.TxtDPaymentTerm_TextChanged);
            // 
            // txtgstin
            // 
            this.txtgstin.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtgstin.Location = new System.Drawing.Point(383, 70);
            this.txtgstin.MaxLength = 100;
            this.txtgstin.Name = "txtgstin";
            this.txtgstin.Size = new System.Drawing.Size(149, 27);
            this.txtgstin.TabIndex = 23;
            this.txtgstin.Enter += new System.EventHandler(this.Txtgstin_Enter);
            this.txtgstin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtgstin_KeyDown);
            this.txtgstin.Leave += new System.EventHandler(this.Txtgstin_Leave);
            // 
            // textBox32
            // 
            this.textBox32.BackColor = System.Drawing.SystemColors.Control;
            this.textBox32.Enabled = false;
            this.textBox32.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox32.Location = new System.Drawing.Point(272, 70);
            this.textBox32.Name = "textBox32";
            this.textBox32.ReadOnly = true;
            this.textBox32.Size = new System.Drawing.Size(111, 27);
            this.textBox32.TabIndex = 16;
            this.textBox32.Text = "GSTIN";
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.rbInactive);
            this.panelStatus.Controls.Add(this.rbActive);
            this.panelStatus.Enabled = false;
            this.panelStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelStatus.Location = new System.Drawing.Point(937, 210);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(149, 27);
            this.panelStatus.TabIndex = 60;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(79, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 33;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(2, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 31;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbActive_KeyDown);
            // 
            // txtcontactName
            // 
            this.txtcontactName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtcontactName.Location = new System.Drawing.Point(370, 23);
            this.txtcontactName.MaxLength = 10;
            this.txtcontactName.Name = "txtcontactName";
            this.txtcontactName.Size = new System.Drawing.Size(151, 27);
            this.txtcontactName.TabIndex = 63;
            // 
            // txtDShortName
            // 
            this.txtDShortName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDShortName.Enabled = false;
            this.txtDShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDShortName.Location = new System.Drawing.Point(272, 23);
            this.txtDShortName.Name = "txtDShortName";
            this.txtDShortName.ReadOnly = true;
            this.txtDShortName.Size = new System.Drawing.Size(100, 27);
            this.txtDShortName.TabIndex = 64;
            this.txtDShortName.Text = "Contact Person";
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesignation.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesignation.FormattingEnabled = true;
            this.cmbDesignation.Items.AddRange(new object[] {
            "The Proprietor",
            "The Manager"});
            this.cmbDesignation.Location = new System.Drawing.Point(123, 23);
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.Size = new System.Drawing.Size(149, 27);
            this.cmbDesignation.TabIndex = 69;
            // 
            // txtDDesignation
            // 
            this.txtDDesignation.BackColor = System.Drawing.SystemColors.Control;
            this.txtDDesignation.Enabled = false;
            this.txtDDesignation.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDDesignation.Location = new System.Drawing.Point(12, 23);
            this.txtDDesignation.Name = "txtDDesignation";
            this.txtDDesignation.ReadOnly = true;
            this.txtDDesignation.Size = new System.Drawing.Size(111, 27);
            this.txtDDesignation.TabIndex = 70;
            this.txtDDesignation.Text = "Designation";
            // 
            // grbEnvelopeDetails
            // 
            this.grbEnvelopeDetails.Controls.Add(this.cmbDesignation);
            this.grbEnvelopeDetails.Controls.Add(this.txtDShortName);
            this.grbEnvelopeDetails.Controls.Add(this.txtcontactName);
            this.grbEnvelopeDetails.Controls.Add(this.txtDDesignation);
            this.grbEnvelopeDetails.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbEnvelopeDetails.Location = new System.Drawing.Point(552, 3);
            this.grbEnvelopeDetails.Name = "grbEnvelopeDetails";
            this.grbEnvelopeDetails.Size = new System.Drawing.Size(534, 61);
            this.grbEnvelopeDetails.TabIndex = 63;
            this.grbEnvelopeDetails.TabStop = false;
            this.grbEnvelopeDetails.Text = "Envelope  Details";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(924, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1011, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // CP_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1098, 291);
            this.Controls.Add(this.grbEnvelopeDetails);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.grbform);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Details";
            this.Load += new System.EventHandler(this.CP_Supplier_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Supplier_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Supplier_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errCompany)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.grbEnvelopeDetails.ResumeLayout(false);
            this.grbEnvelopeDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDCompanyName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDArea;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtDCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtDAContactNumber;
        private System.Windows.Forms.TextBox txtAContactNumber;
        private System.Windows.Forms.TextBox txtDEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbform;
        private System.Windows.Forms.ErrorProvider errCompany;
        private System.Windows.Forms.TextBox txtDPincode;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.TextBox txtPincode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtaddress2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtwhatsapp;
        private System.Windows.Forms.ListView lvCity;
        private System.Windows.Forms.TextBox txtDContactNumber;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtcreditlimit;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.ComboBox cmbfinance;
        private System.Windows.Forms.TextBox txtopening;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox txtgstin;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.ComboBox cmbPaymentTerm;
        private System.Windows.Forms.TextBox txtDPaymentTerm;
        private System.Windows.Forms.TextBox txtrupee;
        private System.Windows.Forms.ComboBox cmbDesignation;
        private System.Windows.Forms.TextBox txtDDesignation;
        private System.Windows.Forms.TextBox txtcontactName;
        private System.Windows.Forms.TextBox txtDShortName;
        private System.Windows.Forms.GroupBox grbEnvelopeDetails;
        private System.Windows.Forms.ComboBox cmbSupplierType;
        private System.Windows.Forms.TextBox txtDSupplierType;
    }
}