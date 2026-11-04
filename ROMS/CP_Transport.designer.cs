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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.DGV_FilterArea = new System.Windows.Forms.DataGridView();
            this.DGV_FilterCity = new System.Windows.Forms.DataGridView();
            this.lblCityId = new System.Windows.Forms.Label();
            this.lblAreaId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epTransport)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.grbForm.SuspendLayout();
            this.grbAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterCity)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTransportEName
            // 
            this.txtTransportEName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtTransportEName.Location = new System.Drawing.Point(152, 22);
            this.txtTransportEName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTransportEName.MaxLength = 30;
            this.txtTransportEName.Name = "txtTransportEName";
            this.txtTransportEName.Size = new System.Drawing.Size(263, 27);
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
            this.txtStatus.Location = new System.Drawing.Point(6, 273);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(130, 27);
            this.txtStatus.TabIndex = 11;
            this.txtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.rbActive);
            this.pnlStatus.Controls.Add(this.rbInActive);
            this.pnlStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.pnlStatus.Location = new System.Drawing.Point(136, 273);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(279, 27);
            this.pnlStatus.TabIndex = 14;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.Location = new System.Drawing.Point(69, 1);
            this.rbActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(60, 24);
            this.rbActive.TabIndex = 14;
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
            this.rbInActive.Location = new System.Drawing.Point(137, 1);
            this.rbInActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 15;
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
            this.textBox1.Size = new System.Drawing.Size(145, 27);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Transport Name in English";
            // 
            // grbForm
            // 
            this.grbForm.Controls.Add(this.DGV_FilterCity);
            this.grbForm.Controls.Add(this.DGV_FilterArea);
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
            this.grbForm.Location = new System.Drawing.Point(12, 2);
            this.grbForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Name = "grbForm";
            this.grbForm.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbForm.Size = new System.Drawing.Size(850, 325);
            this.grbForm.TabIndex = 0;
            this.grbForm.TabStop = false;
            // 
            // grbAddress
            // 
            this.grbAddress.Controls.Add(this.lblAreaId);
            this.grbAddress.Controls.Add(this.lblCityId);
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
            this.grbAddress.Location = new System.Drawing.Point(0, 109);
            this.grbAddress.Name = "grbAddress";
            this.grbAddress.Size = new System.Drawing.Size(836, 158);
            this.grbAddress.TabIndex = 6;
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
            this.textBox6.Size = new System.Drawing.Size(130, 27);
            this.textBox6.TabIndex = 13;
            this.textBox6.Text = "Address 1";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress1.Location = new System.Drawing.Point(136, 24);
            this.txtAddress1.MaxLength = 100;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(279, 27);
            this.txtAddress1.TabIndex = 6;
            this.txtAddress1.Enter += new System.EventHandler(this.txtAddress1_Enter);
            this.txtAddress1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress1_KeyDown);
            this.txtAddress1.Leave += new System.EventHandler(this.txtAddress1_Leave);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(415, 24);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(132, 27);
            this.textBox7.TabIndex = 14;
            this.textBox7.Text = "Address 2";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress2.Location = new System.Drawing.Point(547, 24);
            this.txtAddress2.MaxLength = 100;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(279, 27);
            this.txtAddress2.TabIndex = 7;
            this.txtAddress2.Enter += new System.EventHandler(this.txtAddress2_Enter);
            this.txtAddress2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress2_KeyDown);
            this.txtAddress2.Leave += new System.EventHandler(this.txtAddress2_Leave);
            // 
            // cmbState
            // 
            this.cmbState.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(136, 50);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(112, 28);
            this.cmbState.TabIndex = 8;
            this.cmbState.Enter += new System.EventHandler(this.cmbState_Enter);
            this.cmbState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbState_KeyDown);
            this.cmbState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbState_KeyPress);
            this.cmbState.Leave += new System.EventHandler(this.cmbState_Leave);
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(6, 51);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(130, 27);
            this.textBox8.TabIndex = 18;
            this.textBox8.Text = "State";
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(303, 50);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(112, 28);
            this.cmbDistrict.TabIndex = 9;
            this.cmbDistrict.Enter += new System.EventHandler(this.cmbDistrict_Enter);
            this.cmbDistrict.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDistrict_KeyDown);
            this.cmbDistrict.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDistrict_KeyPress);
            this.cmbDistrict.Leave += new System.EventHandler(this.cmbDistrict_Leave);
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(248, 51);
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
            this.textBox10.Location = new System.Drawing.Point(415, 51);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(132, 27);
            this.textBox10.TabIndex = 16;
            this.textBox10.Text = "City";
            // 
            // txtLandmark
            // 
            this.txtLandmark.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLandmark.Location = new System.Drawing.Point(547, 78);
            this.txtLandmark.MaxLength = 200;
            this.txtLandmark.Multiline = true;
            this.txtLandmark.Name = "txtLandmark";
            this.txtLandmark.Size = new System.Drawing.Size(279, 69);
            this.txtLandmark.TabIndex = 13;
            this.txtLandmark.Enter += new System.EventHandler(this.txtLandmark_Enter);
            this.txtLandmark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLandmark_KeyDown);
            this.txtLandmark.Leave += new System.EventHandler(this.txtLandmark_Leave);
            // 
            // txtCityName
            // 
            this.txtCityName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtCityName.Location = new System.Drawing.Point(547, 51);
            this.txtCityName.MaxLength = 100;
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(168, 27);
            this.txtCityName.TabIndex = 10;
            this.txtCityName.TextChanged += new System.EventHandler(this.txtCityName_TextChanged);
            this.txtCityName.Enter += new System.EventHandler(this.txtCityName_Enter);
            this.txtCityName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCityName_KeyDown);
            this.txtCityName.Leave += new System.EventHandler(this.txtCityName_Leave);
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Control;
            this.textBox11.Enabled = false;
            this.textBox11.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(415, 78);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(132, 27);
            this.textBox11.TabIndex = 20;
            this.textBox11.Text = "Landmark";
            // 
            // txtPincode
            // 
            this.txtPincode.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPincode.Location = new System.Drawing.Point(766, 51);
            this.txtPincode.MaxLength = 6;
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.Size = new System.Drawing.Size(60, 27);
            this.txtPincode.TabIndex = 11;
            this.txtPincode.Enter += new System.EventHandler(this.txtPincode_Enter);
            this.txtPincode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPincode_KeyDown);
            this.txtPincode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPincode_KeyPress);
            this.txtPincode.Leave += new System.EventHandler(this.txtPincode_Leave);
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.Control;
            this.textBox12.Enabled = false;
            this.textBox12.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(6, 78);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(130, 27);
            this.textBox12.TabIndex = 17;
            this.textBox12.Text = "Area";
            // 
            // txtArea
            // 
            this.txtArea.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.Location = new System.Drawing.Point(136, 78);
            this.txtArea.MaxLength = 100;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(279, 27);
            this.txtArea.TabIndex = 12;
            this.txtArea.TextChanged += new System.EventHandler(this.txtArea_TextChanged);
            this.txtArea.Enter += new System.EventHandler(this.txtArea_Enter);
            this.txtArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArea_KeyDown);
            this.txtArea.Leave += new System.EventHandler(this.txtArea_Leave);
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.Control;
            this.textBox13.Enabled = false;
            this.textBox13.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(713, 51);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(51, 27);
            this.textBox13.TabIndex = 19;
            this.textBox13.Text = "Pincode";
            // 
            // txtLandline
            // 
            this.txtLandline.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtLandline.Location = new System.Drawing.Point(547, 78);
            this.txtLandline.MaxLength = 15;
            this.txtLandline.Name = "txtLandline";
            this.txtLandline.Size = new System.Drawing.Size(279, 27);
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
            this.txtLandlineNo.Location = new System.Drawing.Point(415, 78);
            this.txtLandlineNo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtLandlineNo.Name = "txtLandlineNo";
            this.txtLandlineNo.ReadOnly = true;
            this.txtLandlineNo.Size = new System.Drawing.Size(132, 27);
            this.txtLandlineNo.TabIndex = 21;
            this.txtLandlineNo.Text = "Landline Number";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtMobileNo.Location = new System.Drawing.Point(152, 78);
            this.txtMobileNo.MaxLength = 15;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(263, 27);
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
            this.textBox5.Location = new System.Drawing.Point(6, 78);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(145, 27);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "Mobile Number";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.textBox4.Location = new System.Drawing.Point(415, 49);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(132, 27);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Contact Person Name";
            // 
            // txtContactPersonName
            // 
            this.txtContactPersonName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtContactPersonName.Location = new System.Drawing.Point(547, 49);
            this.txtContactPersonName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContactPersonName.MaxLength = 50;
            this.txtContactPersonName.Name = "txtContactPersonName";
            this.txtContactPersonName.Size = new System.Drawing.Size(279, 27);
            this.txtContactPersonName.TabIndex = 3;
            this.txtContactPersonName.Enter += new System.EventHandler(this.txtContactPersonName_Enter);
            this.txtContactPersonName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactPersonName_KeyDown);
            this.txtContactPersonName.Leave += new System.EventHandler(this.txtContactPersonName_Leave);
            // 
            // txtShortName
            // 
            this.txtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.txtShortName.Location = new System.Drawing.Point(152, 49);
            this.txtShortName.MaxLength = 10;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(263, 27);
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
            this.textBox3.Location = new System.Drawing.Point(6, 51);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(145, 27);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "Short Name";
            // 
            // txtTransportTName
            // 
            this.txtTransportTName.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransportTName.Location = new System.Drawing.Point(547, 22);
            this.txtTransportTName.MaxLength = 100;
            this.txtTransportTName.Name = "txtTransportTName";
            this.txtTransportTName.Size = new System.Drawing.Size(279, 27);
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
            this.textBox2.Location = new System.Drawing.Point(415, 22);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(132, 27);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Transport Name in Tamil";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(752, 275);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 34);
            this.btnClose.TabIndex = 17;
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
            this.btnSave.Location = new System.Drawing.Point(664, 275);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 34);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // DGV_FilterArea
            // 
            this.DGV_FilterArea.AllowUserToAddRows = false;
            this.DGV_FilterArea.AllowUserToDeleteRows = false;
            this.DGV_FilterArea.AllowUserToResizeColumns = false;
            this.DGV_FilterArea.AllowUserToResizeRows = false;
            this.DGV_FilterArea.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterArea.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_FilterArea.ColumnHeadersHeight = 30;
            this.DGV_FilterArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterArea.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_FilterArea.EnableHeadersVisualStyles = false;
            this.DGV_FilterArea.GridColor = System.Drawing.Color.White;
            this.DGV_FilterArea.Location = new System.Drawing.Point(136, 214);
            this.DGV_FilterArea.Name = "DGV_FilterArea";
            this.DGV_FilterArea.ReadOnly = true;
            this.DGV_FilterArea.RowHeadersVisible = false;
            this.DGV_FilterArea.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterArea.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_FilterArea.RowTemplate.Height = 25;
            this.DGV_FilterArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterArea.Size = new System.Drawing.Size(279, 107);
            this.DGV_FilterArea.TabIndex = 111111228;
            this.DGV_FilterArea.Visible = false;
            this.DGV_FilterArea.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterArea_CellDoubleClick);
            this.DGV_FilterArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterArea_KeyDown);
            // 
            // DGV_FilterCity
            // 
            this.DGV_FilterCity.AllowUserToAddRows = false;
            this.DGV_FilterCity.AllowUserToDeleteRows = false;
            this.DGV_FilterCity.AllowUserToResizeColumns = false;
            this.DGV_FilterCity.AllowUserToResizeRows = false;
            this.DGV_FilterCity.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FilterCity.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FilterCity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FilterCity.ColumnHeadersHeight = 30;
            this.DGV_FilterCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Oswald Regular", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FilterCity.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_FilterCity.EnableHeadersVisualStyles = false;
            this.DGV_FilterCity.GridColor = System.Drawing.Color.White;
            this.DGV_FilterCity.Location = new System.Drawing.Point(547, 187);
            this.DGV_FilterCity.Name = "DGV_FilterCity";
            this.DGV_FilterCity.ReadOnly = true;
            this.DGV_FilterCity.RowHeadersVisible = false;
            this.DGV_FilterCity.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGV_FilterCity.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FilterCity.RowTemplate.Height = 25;
            this.DGV_FilterCity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FilterCity.Size = new System.Drawing.Size(279, 133);
            this.DGV_FilterCity.TabIndex = 111111168;
            this.DGV_FilterCity.Visible = false;
            this.DGV_FilterCity.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FilterCity_CellDoubleClick);
            this.DGV_FilterCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FilterCity_KeyDown);
            // 
            // lblCityId
            // 
            this.lblCityId.AutoSize = true;
            this.lblCityId.Location = new System.Drawing.Point(691, 54);
            this.lblCityId.Name = "lblCityId";
            this.lblCityId.Size = new System.Drawing.Size(16, 20);
            this.lblCityId.TabIndex = 1111251;
            this.lblCityId.Text = "0";
            this.lblCityId.Visible = false;
            // 
            // lblAreaId
            // 
            this.lblAreaId.AutoSize = true;
            this.lblAreaId.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaId.Location = new System.Drawing.Point(393, 81);
            this.lblAreaId.Name = "lblAreaId";
            this.lblAreaId.Size = new System.Drawing.Size(16, 20);
            this.lblAreaId.TabIndex = 111111230;
            this.lblAreaId.Text = "0";
            this.lblAreaId.Visible = false;
            // 
            // CP_Transport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(874, 336);
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
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FilterCity)).EndInit();
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
        public System.Windows.Forms.DataGridView DGV_FilterArea;
        public System.Windows.Forms.DataGridView DGV_FilterCity;
        private System.Windows.Forms.Label lblCityId;
        private System.Windows.Forms.Label lblAreaId;
    }
}