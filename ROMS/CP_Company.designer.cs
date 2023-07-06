namespace ROMS
{
    partial class CP_Company
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Company));
            this.txtDCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtDShortName = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.txtDArea = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtDCity = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtDAContactNumber = new System.Windows.Forms.TextBox();
            this.txtAContactNumber = new System.Windows.Forms.TextBox();
            this.txtDEmail = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.grbform = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtwhatsapp = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtwebsite = new System.Windows.Forms.TextBox();
            this.txtAlterMobileno = new System.Windows.Forms.TextBox();
            this.txtAlterPhno = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtaddress2 = new System.Windows.Forms.TextBox();
            this.txtDPincode = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.txtPincode = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDGSTIN = new System.Windows.Forms.TextBox();
            this.txtDContactNumber = new System.Windows.Forms.TextBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.grpstatus = new System.Windows.Forms.GroupBox();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbactive = new System.Windows.Forms.RadioButton();
            this.errCompany = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtGSTTIN = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtCst = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtESI = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtEPF = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.txtPan = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.txtFSSAI = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBankname = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.txtAccno = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.txtIFScode = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdSupplierList = new System.Windows.Forms.DataGridView();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.txtbranchname = new System.Windows.Forms.TextBox();
            this.clmsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmbankname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmbranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmaccno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmifscode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Label();
            this.grbform.SuspendLayout();
            this.grpstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errCompany)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDCompanyName
            // 
            this.txtDCompanyName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDCompanyName.Enabled = false;
            this.txtDCompanyName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDCompanyName.Location = new System.Drawing.Point(23, 23);
            this.txtDCompanyName.Name = "txtDCompanyName";
            this.txtDCompanyName.ReadOnly = true;
            this.txtDCompanyName.Size = new System.Drawing.Size(111, 27);
            this.txtDCompanyName.TabIndex = 14;
            this.txtDCompanyName.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCompanyName.Location = new System.Drawing.Point(134, 23);
            this.txtCompanyName.MaxLength = 100;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(397, 27);
            this.txtCompanyName.TabIndex = 0;
            this.txtCompanyName.Enter += new System.EventHandler(this.txtCompanyName_Enter);
            this.txtCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyName_KeyDown);
            this.txtCompanyName.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // txtDShortName
            // 
            this.txtDShortName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDShortName.Enabled = false;
            this.txtDShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDShortName.Location = new System.Drawing.Point(23, 50);
            this.txtDShortName.Name = "txtDShortName";
            this.txtDShortName.ReadOnly = true;
            this.txtDShortName.Size = new System.Drawing.Size(111, 27);
            this.txtDShortName.TabIndex = 15;
            this.txtDShortName.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtShortName.Location = new System.Drawing.Point(134, 50);
            this.txtShortName.MaxLength = 10;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(397, 27);
            this.txtShortName.TabIndex = 1;
            this.txtShortName.Enter += new System.EventHandler(this.txtShortName_Enter);
            this.txtShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortName_KeyDown);
            this.txtShortName.Leave += new System.EventHandler(this.txtShortName_Leave);
            // 
            // txtDArea
            // 
            this.txtDArea.BackColor = System.Drawing.SystemColors.Control;
            this.txtDArea.Enabled = false;
            this.txtDArea.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDArea.Location = new System.Drawing.Point(23, 77);
            this.txtDArea.Name = "txtDArea";
            this.txtDArea.ReadOnly = true;
            this.txtDArea.Size = new System.Drawing.Size(111, 27);
            this.txtDArea.TabIndex = 16;
            this.txtDArea.Text = "Address 1";
            // 
            // txtArea
            // 
            this.txtArea.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtArea.Location = new System.Drawing.Point(134, 77);
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
            this.txtDCity.Location = new System.Drawing.Point(23, 131);
            this.txtDCity.Name = "txtDCity";
            this.txtDCity.ReadOnly = true;
            this.txtDCity.Size = new System.Drawing.Size(111, 27);
            this.txtDCity.TabIndex = 17;
            this.txtDCity.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCity.Location = new System.Drawing.Point(134, 131);
            this.txtCity.MaxLength = 100;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(186, 27);
            this.txtCity.TabIndex = 4;
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
            this.txtDAContactNumber.Location = new System.Drawing.Point(23, 212);
            this.txtDAContactNumber.Name = "txtDAContactNumber";
            this.txtDAContactNumber.ReadOnly = true;
            this.txtDAContactNumber.Size = new System.Drawing.Size(111, 27);
            this.txtDAContactNumber.TabIndex = 19;
            this.txtDAContactNumber.Text = "Mobile No.";
            // 
            // txtAContactNumber
            // 
            this.txtAContactNumber.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtAContactNumber.Location = new System.Drawing.Point(134, 212);
            this.txtAContactNumber.MaxLength = 10;
            this.txtAContactNumber.Name = "txtAContactNumber";
            this.txtAContactNumber.Size = new System.Drawing.Size(186, 27);
            this.txtAContactNumber.TabIndex = 9;
            this.txtAContactNumber.Enter += new System.EventHandler(this.txtAContactNumber_Enter);
            this.txtAContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAContactNumber_KeyPress);
            this.txtAContactNumber.Leave += new System.EventHandler(this.txtAContactNumber_Leave);
            // 
            // txtDEmail
            // 
            this.txtDEmail.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEmail.Enabled = false;
            this.txtDEmail.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDEmail.Location = new System.Drawing.Point(23, 263);
            this.txtDEmail.Name = "txtDEmail";
            this.txtDEmail.ReadOnly = true;
            this.txtDEmail.Size = new System.Drawing.Size(111, 27);
            this.txtDEmail.TabIndex = 20;
            this.txtDEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtEmail.Location = new System.Drawing.Point(134, 263);
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
            this.grbform.Controls.Add(this.textBox6);
            this.grbform.Controls.Add(this.txtwhatsapp);
            this.grbform.Controls.Add(this.textBox4);
            this.grbform.Controls.Add(this.btnSave);
            this.grbform.Controls.Add(this.btnClose);
            this.grbform.Controls.Add(this.groupBox2);
            this.grbform.Controls.Add(this.groupBox1);
            this.grbform.Controls.Add(this.txtwebsite);
            this.grbform.Controls.Add(this.txtAlterMobileno);
            this.grbform.Controls.Add(this.txtAlterPhno);
            this.grbform.Controls.Add(this.textBox3);
            this.grbform.Controls.Add(this.txtaddress2);
            this.grbform.Controls.Add(this.txtDPincode);
            this.grbform.Controls.Add(this.cmbState);
            this.grbform.Controls.Add(this.txtPincode);
            this.grbform.Controls.Add(this.textBox1);
            this.grbform.Controls.Add(this.txtDGSTIN);
            this.grbform.Controls.Add(this.txtDEmail);
            this.grbform.Controls.Add(this.txtDCompanyName);
            this.grbform.Controls.Add(this.txtEmail);
            this.grbform.Controls.Add(this.txtCompanyName);
            this.grbform.Controls.Add(this.txtDAContactNumber);
            this.grbform.Controls.Add(this.txtShortName);
            this.grbform.Controls.Add(this.txtAContactNumber);
            this.grbform.Controls.Add(this.txtDShortName);
            this.grbform.Controls.Add(this.txtDContactNumber);
            this.grbform.Controls.Add(this.txtArea);
            this.grbform.Controls.Add(this.txtContactNumber);
            this.grbform.Controls.Add(this.txtDArea);
            this.grbform.Controls.Add(this.txtDCity);
            this.grbform.Controls.Add(this.txtCity);
            this.grbform.Controls.Add(this.grpstatus);
            this.grbform.Location = new System.Drawing.Point(12, 12);
            this.grbform.Name = "grbform";
            this.grbform.Size = new System.Drawing.Size(887, 614);
            this.grbform.TabIndex = 0;
            this.grbform.TabStop = false;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox6.Location = new System.Drawing.Point(23, 236);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(111, 27);
            this.textBox6.TabIndex = 61;
            this.textBox6.Text = "Whatsapp No.";
            // 
            // txtwhatsapp
            // 
            this.txtwhatsapp.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtwhatsapp.Location = new System.Drawing.Point(134, 236);
            this.txtwhatsapp.MaxLength = 10;
            this.txtwhatsapp.Name = "txtwhatsapp";
            this.txtwhatsapp.Size = new System.Drawing.Size(186, 27);
            this.txtwhatsapp.TabIndex = 11;
            this.txtwhatsapp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtwhatsapp_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(23, 316);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(111, 27);
            this.textBox4.TabIndex = 56;
            this.textBox4.Text = "Status";
            // 
            // txtwebsite
            // 
            this.txtwebsite.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtwebsite.Location = new System.Drawing.Point(134, 290);
            this.txtwebsite.MaxLength = 10;
            this.txtwebsite.Name = "txtwebsite";
            this.txtwebsite.Size = new System.Drawing.Size(397, 27);
            this.txtwebsite.TabIndex = 13;
            // 
            // txtAlterMobileno
            // 
            this.txtAlterMobileno.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtAlterMobileno.Location = new System.Drawing.Point(345, 212);
            this.txtAlterMobileno.MaxLength = 10;
            this.txtAlterMobileno.Name = "txtAlterMobileno";
            this.txtAlterMobileno.Size = new System.Drawing.Size(186, 27);
            this.txtAlterMobileno.TabIndex = 10;
            this.txtAlterMobileno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAlterMobileno_KeyPress);
            // 
            // txtAlterPhno
            // 
            this.txtAlterPhno.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtAlterPhno.Location = new System.Drawing.Point(345, 185);
            this.txtAlterPhno.MaxLength = 10;
            this.txtAlterPhno.Name = "txtAlterPhno";
            this.txtAlterPhno.Size = new System.Drawing.Size(186, 27);
            this.txtAlterPhno.TabIndex = 8;
            this.txtAlterPhno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAlterPhno_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox3.Location = new System.Drawing.Point(23, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(111, 27);
            this.textBox3.TabIndex = 48;
            this.textBox3.Text = "Address 2";
            // 
            // txtaddress2
            // 
            this.txtaddress2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtaddress2.Location = new System.Drawing.Point(134, 104);
            this.txtaddress2.MaxLength = 250;
            this.txtaddress2.Name = "txtaddress2";
            this.txtaddress2.Size = new System.Drawing.Size(397, 27);
            this.txtaddress2.TabIndex = 3;
            // 
            // txtDPincode
            // 
            this.txtDPincode.BackColor = System.Drawing.SystemColors.Control;
            this.txtDPincode.Enabled = false;
            this.txtDPincode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDPincode.Location = new System.Drawing.Point(321, 131);
            this.txtDPincode.Name = "txtDPincode";
            this.txtDPincode.ReadOnly = true;
            this.txtDPincode.Size = new System.Drawing.Size(52, 27);
            this.txtDPincode.TabIndex = 46;
            this.txtDPincode.Text = "Pincode";
            this.txtDPincode.TextChanged += new System.EventHandler(this.TxtDPincode_TextChanged);
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(134, 158);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(186, 27);
            this.cmbState.TabIndex = 6;
            this.cmbState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbState_KeyDown);
            // 
            // txtPincode
            // 
            this.txtPincode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtPincode.Location = new System.Drawing.Point(374, 131);
            this.txtPincode.MaxLength = 6;
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.Size = new System.Drawing.Size(157, 27);
            this.txtPincode.TabIndex = 5;
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
            this.textBox1.Location = new System.Drawing.Point(23, 158);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(111, 27);
            this.textBox1.TabIndex = 45;
            this.textBox1.Text = "State";
            // 
            // txtDGSTIN
            // 
            this.txtDGSTIN.BackColor = System.Drawing.SystemColors.Control;
            this.txtDGSTIN.Enabled = false;
            this.txtDGSTIN.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDGSTIN.Location = new System.Drawing.Point(23, 290);
            this.txtDGSTIN.Name = "txtDGSTIN";
            this.txtDGSTIN.ReadOnly = true;
            this.txtDGSTIN.Size = new System.Drawing.Size(111, 27);
            this.txtDGSTIN.TabIndex = 21;
            this.txtDGSTIN.Text = "Website";
            // 
            // txtDContactNumber
            // 
            this.txtDContactNumber.BackColor = System.Drawing.SystemColors.Control;
            this.txtDContactNumber.Enabled = false;
            this.txtDContactNumber.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtDContactNumber.Location = new System.Drawing.Point(23, 185);
            this.txtDContactNumber.Name = "txtDContactNumber";
            this.txtDContactNumber.ReadOnly = true;
            this.txtDContactNumber.Size = new System.Drawing.Size(111, 27);
            this.txtDContactNumber.TabIndex = 18;
            this.txtDContactNumber.Text = "Phone No.";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtContactNumber.Location = new System.Drawing.Point(134, 185);
            this.txtContactNumber.MaxLength = 10;
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(186, 27);
            this.txtContactNumber.TabIndex = 7;
            this.txtContactNumber.Enter += new System.EventHandler(this.txtContactNumber_Enter);
            this.txtContactNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactNumber_KeyDown);
            this.txtContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContactNumber_KeyPress);
            this.txtContactNumber.Leave += new System.EventHandler(this.txtContactNumber_Leave);
            // 
            // grpstatus
            // 
            this.grpstatus.Controls.Add(this.rbInactive);
            this.grpstatus.Controls.Add(this.rbactive);
            this.grpstatus.Enabled = false;
            this.grpstatus.Location = new System.Drawing.Point(134, 309);
            this.grpstatus.Name = "grpstatus";
            this.grpstatus.Size = new System.Drawing.Size(397, 35);
            this.grpstatus.TabIndex = 59;
            this.grpstatus.TabStop = false;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInactive.Location = new System.Drawing.Point(101, 9);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(70, 24);
            this.rbInactive.TabIndex = 15;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            // 
            // rbactive
            // 
            this.rbactive.AutoSize = true;
            this.rbactive.Checked = true;
            this.rbactive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbactive.Location = new System.Drawing.Point(18, 9);
            this.rbactive.Name = "rbactive";
            this.rbactive.Size = new System.Drawing.Size(60, 24);
            this.rbactive.TabIndex = 14;
            this.rbactive.TabStop = true;
            this.rbactive.Text = "Active";
            this.rbactive.UseVisualStyleBackColor = true;
            // 
            // errCompany
            // 
            this.errCompany.ContainerControl = this;
            // 
            // txtGSTTIN
            // 
            this.txtGSTTIN.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtGSTTIN.Location = new System.Drawing.Point(60, 36);
            this.txtGSTTIN.MaxLength = 100;
            this.txtGSTTIN.Name = "txtGSTTIN";
            this.txtGSTTIN.Size = new System.Drawing.Size(204, 27);
            this.txtGSTTIN.TabIndex = 16;
            this.txtGSTTIN.Leave += new System.EventHandler(this.TxtGSTTIN_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox2.Location = new System.Drawing.Point(9, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(53, 27);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "GSTIN";
            // 
            // txtCst
            // 
            this.txtCst.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCst.Location = new System.Drawing.Point(60, 63);
            this.txtCst.MaxLength = 100;
            this.txtCst.Name = "txtCst";
            this.txtCst.Size = new System.Drawing.Size(204, 27);
            this.txtCst.TabIndex = 17;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox5.Location = new System.Drawing.Point(9, 63);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(53, 27);
            this.textBox5.TabIndex = 18;
            this.textBox5.Text = "CST";
            // 
            // txtESI
            // 
            this.txtESI.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtESI.Location = new System.Drawing.Point(60, 116);
            this.txtESI.MaxLength = 100;
            this.txtESI.Name = "txtESI";
            this.txtESI.Size = new System.Drawing.Size(204, 27);
            this.txtESI.TabIndex = 19;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox7.Location = new System.Drawing.Point(9, 116);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(53, 27);
            this.textBox7.TabIndex = 20;
            this.textBox7.Text = "ESI";
            // 
            // txtEPF
            // 
            this.txtEPF.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtEPF.Location = new System.Drawing.Point(60, 143);
            this.txtEPF.MaxLength = 100;
            this.txtEPF.Name = "txtEPF";
            this.txtEPF.Size = new System.Drawing.Size(204, 27);
            this.txtEPF.TabIndex = 20;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox9.Location = new System.Drawing.Point(9, 143);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(53, 27);
            this.textBox9.TabIndex = 22;
            this.textBox9.Text = "EPF";
            // 
            // txtPan
            // 
            this.txtPan.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtPan.Location = new System.Drawing.Point(60, 89);
            this.txtPan.MaxLength = 100;
            this.txtPan.Name = "txtPan";
            this.txtPan.Size = new System.Drawing.Size(204, 27);
            this.txtPan.TabIndex = 18;
            this.txtPan.Leave += new System.EventHandler(this.TxtPan_Leave);
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Control;
            this.textBox11.Enabled = false;
            this.textBox11.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox11.Location = new System.Drawing.Point(9, 89);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(53, 27);
            this.textBox11.TabIndex = 24;
            this.textBox11.Text = "PAN";
            // 
            // txtFSSAI
            // 
            this.txtFSSAI.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtFSSAI.Location = new System.Drawing.Point(60, 170);
            this.txtFSSAI.MaxLength = 100;
            this.txtFSSAI.Name = "txtFSSAI";
            this.txtFSSAI.Size = new System.Drawing.Size(204, 27);
            this.txtFSSAI.TabIndex = 21;
            this.txtFSSAI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFSSAI_KeyDown);
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.Control;
            this.textBox13.Enabled = false;
            this.textBox13.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox13.Location = new System.Drawing.Point(9, 170);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(53, 27);
            this.textBox13.TabIndex = 26;
            this.textBox13.Text = "FSSAI";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.txtFSSAI);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.txtPan);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.txtEPF);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.txtESI);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.txtCst);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.txtGSTTIN);
            this.groupBox1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(592, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 208);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registration Details";
            // 
            // txtBankname
            // 
            this.txtBankname.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtBankname.Location = new System.Drawing.Point(83, 27);
            this.txtBankname.MaxLength = 100;
            this.txtBankname.Name = "txtBankname";
            this.txtBankname.Size = new System.Drawing.Size(300, 27);
            this.txtBankname.TabIndex = 22;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.SystemColors.Control;
            this.textBox19.Enabled = false;
            this.textBox19.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox19.Location = new System.Drawing.Point(6, 27);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(77, 27);
            this.textBox19.TabIndex = 200000;
            this.textBox19.Text = "Bank Name";
            // 
            // txtAccno
            // 
            this.txtAccno.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtAccno.Location = new System.Drawing.Point(83, 54);
            this.txtAccno.MaxLength = 100;
            this.txtAccno.Name = "txtAccno";
            this.txtAccno.Size = new System.Drawing.Size(300, 27);
            this.txtAccno.TabIndex = 23;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.SystemColors.Control;
            this.textBox17.Enabled = false;
            this.textBox17.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox17.Location = new System.Drawing.Point(6, 54);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(77, 27);
            this.textBox17.TabIndex = 20000;
            this.textBox17.Text = "Acc No.";
            // 
            // txtIFScode
            // 
            this.txtIFScode.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtIFScode.Location = new System.Drawing.Point(516, 54);
            this.txtIFScode.MaxLength = 100;
            this.txtIFScode.Name = "txtIFScode";
            this.txtIFScode.Size = new System.Drawing.Size(300, 27);
            this.txtIFScode.TabIndex = 24;
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.SystemColors.Control;
            this.textBox15.Enabled = false;
            this.textBox15.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox15.Location = new System.Drawing.Point(439, 54);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(77, 27);
            this.textBox15.TabIndex = 200000;
            this.textBox15.Text = "IFS Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.txtbranchname);
            this.groupBox2.Controls.Add(this.grdSupplierList);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.textBox15);
            this.groupBox2.Controls.Add(this.txtIFScode);
            this.groupBox2.Controls.Add(this.textBox17);
            this.groupBox2.Controls.Add(this.txtAccno);
            this.groupBox2.Controls.Add(this.textBox19);
            this.groupBox2.Controls.Add(this.txtBankname);
            this.groupBox2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(23, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(847, 216);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bank Details";
            // 
            // grdSupplierList
            // 
            this.grdSupplierList.AllowUserToAddRows = false;
            this.grdSupplierList.AllowUserToDeleteRows = false;
            this.grdSupplierList.AllowUserToResizeColumns = false;
            this.grdSupplierList.AllowUserToResizeRows = false;
            this.grdSupplierList.BackgroundColor = System.Drawing.Color.White;
            this.grdSupplierList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSupplierList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSupplierList.ColumnHeadersHeight = 30;
            this.grdSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSupplierList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmsno,
            this.clmbankname,
            this.clmbranch,
            this.clmaccno,
            this.clmifscode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSupplierList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSupplierList.EnableHeadersVisualStyles = false;
            this.grdSupplierList.GridColor = System.Drawing.Color.White;
            this.grdSupplierList.Location = new System.Drawing.Point(6, 90);
            this.grdSupplierList.Name = "grdSupplierList";
            this.grdSupplierList.ReadOnly = true;
            this.grdSupplierList.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grdSupplierList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSupplierList.RowTemplate.Height = 25;
            this.grdSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSupplierList.Size = new System.Drawing.Size(810, 98);
            this.grdSupplierList.TabIndex = 1111136;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox8.Location = new System.Drawing.Point(439, 27);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(77, 27);
            this.textBox8.TabIndex = 1111138;
            this.textBox8.Text = "Branch Name";
            // 
            // txtbranchname
            // 
            this.txtbranchname.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtbranchname.Location = new System.Drawing.Point(516, 27);
            this.txtbranchname.MaxLength = 100;
            this.txtbranchname.Name = "txtbranchname";
            this.txtbranchname.Size = new System.Drawing.Size(300, 27);
            this.txtbranchname.TabIndex = 1111137;
            // 
            // clmsno
            // 
            this.clmsno.HeaderText = "S.No.";
            this.clmsno.Name = "clmsno";
            this.clmsno.ReadOnly = true;
            this.clmsno.Width = 50;
            // 
            // clmbankname
            // 
            this.clmbankname.HeaderText = "Bank Name";
            this.clmbankname.Name = "clmbankname";
            this.clmbankname.ReadOnly = true;
            this.clmbankname.Width = 200;
            // 
            // clmbranch
            // 
            this.clmbranch.HeaderText = "Branch Name";
            this.clmbranch.Name = "clmbranch";
            this.clmbranch.ReadOnly = true;
            this.clmbranch.Width = 175;
            // 
            // clmaccno
            // 
            this.clmaccno.HeaderText = "Account No.";
            this.clmaccno.Name = "clmaccno";
            this.clmaccno.ReadOnly = true;
            this.clmaccno.Width = 200;
            // 
            // clmifscode
            // 
            this.clmifscode.HeaderText = "IFS Code";
            this.clmifscode.Name = "clmifscode";
            this.clmifscode.ReadOnly = true;
            this.clmifscode.Width = 175;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(702, 567);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 25;
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
            this.btnClose.Location = new System.Drawing.Point(794, 567);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Image = global::ROMS.Properties.Resources.plus;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(821, 56);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 1111135;
            this.btnAdd.Text = "        ";
            // 
            // CP_Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(912, 642);
            this.Controls.Add(this.grbform);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Company";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Details";
            this.Load += new System.EventHandler(this.CP_Company_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Company_KeyDown);
            this.Leave += new System.EventHandler(this.CP_Company_Leave);
            this.grbform.ResumeLayout(false);
            this.grbform.PerformLayout();
            this.grpstatus.ResumeLayout(false);
            this.grpstatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errCompany)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupplierList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtDShortName;
        private System.Windows.Forms.TextBox txtShortName;
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
        private System.Windows.Forms.TextBox txtDContactNumber;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtaddress2;
        private System.Windows.Forms.TextBox txtAlterMobileno;
        private System.Windows.Forms.TextBox txtAlterPhno;
        private System.Windows.Forms.TextBox txtwebsite;
        private System.Windows.Forms.TextBox txtDGSTIN;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbactive;
        private System.Windows.Forms.GroupBox grpstatus;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtwhatsapp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox txtIFScode;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox txtAccno;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox txtBankname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox txtFSSAI;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox txtPan;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox txtEPF;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox txtESI;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtCst;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtGSTTIN;
        internal System.Windows.Forms.Label btnAdd;
        public System.Windows.Forms.DataGridView grdSupplierList;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox txtbranchname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmbankname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmbranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmaccno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmifscode;
    }
}