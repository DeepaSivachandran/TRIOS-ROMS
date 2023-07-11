namespace ROMS
{
    partial class CP_Location
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Location));
            this.txtDLocationName = new System.Windows.Forms.TextBox();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbLocation = new System.Windows.Forms.GroupBox();
            this.txtDlocationtype = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rboutside = new System.Windows.Forms.RadioButton();
            this.rbInside = new System.Windows.Forms.RadioButton();
            this.txtDStatus = new System.Windows.Forms.TextBox();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.errLocation = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbrack = new System.Windows.Forms.RadioButton();
            this.rbLocation = new System.Windows.Forms.RadioButton();
            this.grbrack = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtRankShortName = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbrackinactive = new System.Windows.Forms.RadioButton();
            this.rbrackactive = new System.Windows.Forms.RadioButton();
            this.txtDEGroupName = new System.Windows.Forms.TextBox();
            this.btnRackClose = new System.Windows.Forms.Button();
            this.btnRacksave = new System.Windows.Forms.Button();
            this.txtRankName = new System.Windows.Forms.TextBox();
            this.cmbmasterselect = new System.Windows.Forms.ComboBox();
            this.txtdmasterselect = new System.Windows.Forms.TextBox();
            this.grbLocation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.grbrack.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDLocationName
            // 
            this.txtDLocationName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDLocationName.Enabled = false;
            this.txtDLocationName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDLocationName.Location = new System.Drawing.Point(14, 21);
            this.txtDLocationName.Name = "txtDLocationName";
            this.txtDLocationName.ReadOnly = true;
            this.txtDLocationName.Size = new System.Drawing.Size(181, 27);
            this.txtDLocationName.TabIndex = 6;
            this.txtDLocationName.Text = "Godown Name";
            // 
            // txtLocationName
            // 
            this.txtLocationName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationName.Location = new System.Drawing.Point(195, 21);
            this.txtLocationName.MaxLength = 50;
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(288, 27);
            this.txtLocationName.TabIndex = 1;
            this.txtLocationName.Enter += new System.EventHandler(this.txtLocationName_Enter);
            this.txtLocationName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationName_KeyDown);
            this.txtLocationName.Leave += new System.EventHandler(this.txtLocationName_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(320, 117);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 6;
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
            this.btnClose.Location = new System.Drawing.Point(408, 117);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // grbLocation
            // 
            this.grbLocation.Controls.Add(this.txtDLocationName);
            this.grbLocation.Controls.Add(this.txtLocationName);
            this.grbLocation.Controls.Add(this.txtDlocationtype);
            this.grbLocation.Controls.Add(this.panel1);
            this.grbLocation.Controls.Add(this.btnClose);
            this.grbLocation.Controls.Add(this.txtDStatus);
            this.grbLocation.Controls.Add(this.btnSave);
            this.grbLocation.Controls.Add(this.panelStatus);
            this.grbLocation.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLocation.Location = new System.Drawing.Point(24, 38);
            this.grbLocation.Name = "grbLocation";
            this.grbLocation.Size = new System.Drawing.Size(552, 159);
            this.grbLocation.TabIndex = 1;
            this.grbLocation.TabStop = false;
            // 
            // txtDlocationtype
            // 
            this.txtDlocationtype.BackColor = System.Drawing.SystemColors.Control;
            this.txtDlocationtype.Enabled = false;
            this.txtDlocationtype.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDlocationtype.Location = new System.Drawing.Point(14, 48);
            this.txtDlocationtype.Name = "txtDlocationtype";
            this.txtDlocationtype.ReadOnly = true;
            this.txtDlocationtype.Size = new System.Drawing.Size(181, 27);
            this.txtDlocationtype.TabIndex = 21;
            this.txtDlocationtype.Text = "Godown Type";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rboutside);
            this.panel1.Controls.Add(this.rbInside);
            this.panel1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(195, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 27);
            this.panel1.TabIndex = 1;
            // 
            // rboutside
            // 
            this.rboutside.AutoSize = true;
            this.rboutside.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rboutside.Location = new System.Drawing.Point(146, 1);
            this.rboutside.Name = "rboutside";
            this.rboutside.Size = new System.Drawing.Size(62, 21);
            this.rboutside.TabIndex = 3;
            this.rboutside.Text = "Outside";
            this.rboutside.UseVisualStyleBackColor = true;
            this.rboutside.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rboutside_KeyDown);
            // 
            // rbInside
            // 
            this.rbInside.AutoSize = true;
            this.rbInside.Checked = true;
            this.rbInside.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInside.Location = new System.Drawing.Point(29, 1);
            this.rbInside.Name = "rbInside";
            this.rbInside.Size = new System.Drawing.Size(54, 21);
            this.rbInside.TabIndex = 2;
            this.rbInside.TabStop = true;
            this.rbInside.Text = "Inside";
            this.rbInside.UseVisualStyleBackColor = true;
            // 
            // txtDStatus
            // 
            this.txtDStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtDStatus.Enabled = false;
            this.txtDStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStatus.Location = new System.Drawing.Point(14, 75);
            this.txtDStatus.Name = "txtDStatus";
            this.txtDStatus.ReadOnly = true;
            this.txtDStatus.Size = new System.Drawing.Size(181, 27);
            this.txtDStatus.TabIndex = 19;
            this.txtDStatus.Text = "Status";
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.rbInactive);
            this.panelStatus.Controls.Add(this.rbActive);
            this.panelStatus.Enabled = false;
            this.panelStatus.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelStatus.Location = new System.Drawing.Point(195, 75);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(288, 27);
            this.panelStatus.TabIndex = 3;
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbInactive.Location = new System.Drawing.Point(146, 1);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(63, 21);
            this.rbInactive.TabIndex = 5;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbInactive_KeyDown);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbActive.Location = new System.Drawing.Point(29, 1);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(54, 21);
            this.rbActive.TabIndex = 4;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RbActive_KeyDown);
            // 
            // errLocation
            // 
            this.errLocation.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbrack);
            this.panel2.Controls.Add(this.rbLocation);
            this.panel2.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(473, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(83, 27);
            this.panel2.TabIndex = 21;
            this.panel2.Visible = false;
            // 
            // rbrack
            // 
            this.rbrack.AutoSize = true;
            this.rbrack.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbrack.Location = new System.Drawing.Point(132, 2);
            this.rbrack.Name = "rbrack";
            this.rbrack.Size = new System.Drawing.Size(50, 21);
            this.rbrack.TabIndex = 7;
            this.rbrack.Text = "Rack";
            this.rbrack.UseVisualStyleBackColor = true;
            this.rbrack.CheckedChanged += new System.EventHandler(this.Rbrack_CheckedChanged);
            // 
            // rbLocation
            // 
            this.rbLocation.AutoSize = true;
            this.rbLocation.Checked = true;
            this.rbLocation.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbLocation.Location = new System.Drawing.Point(12, 1);
            this.rbLocation.Name = "rbLocation";
            this.rbLocation.Size = new System.Drawing.Size(67, 21);
            this.rbLocation.TabIndex = 6;
            this.rbLocation.TabStop = true;
            this.rbLocation.Text = "Location";
            this.rbLocation.UseVisualStyleBackColor = true;
            this.rbLocation.CheckedChanged += new System.EventHandler(this.RbLocation_CheckedChanged);
            // 
            // grbrack
            // 
            this.grbrack.Controls.Add(this.textBox1);
            this.grbrack.Controls.Add(this.txtRankShortName);
            this.grbrack.Controls.Add(this.textBox3);
            this.grbrack.Controls.Add(this.panel3);
            this.grbrack.Controls.Add(this.txtDEGroupName);
            this.grbrack.Controls.Add(this.btnRackClose);
            this.grbrack.Controls.Add(this.btnRacksave);
            this.grbrack.Controls.Add(this.txtRankName);
            this.grbrack.Location = new System.Drawing.Point(24, 38);
            this.grbrack.Name = "grbrack";
            this.grbrack.Size = new System.Drawing.Size(552, 161);
            this.grbrack.TabIndex = 22;
            this.grbrack.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(14, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(181, 27);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "Short Name";
            // 
            // txtRankShortName
            // 
            this.txtRankShortName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRankShortName.Location = new System.Drawing.Point(195, 48);
            this.txtRankShortName.MaxLength = 50;
            this.txtRankShortName.Name = "txtRankShortName";
            this.txtRankShortName.Size = new System.Drawing.Size(288, 27);
            this.txtRankShortName.TabIndex = 2;
            this.txtRankShortName.Enter += new System.EventHandler(this.TxtRankShortName_Enter);
            this.txtRankShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRankShortName_KeyDown);
            this.txtRankShortName.Leave += new System.EventHandler(this.TxtRankShortName_Leave);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(14, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(181, 27);
            this.textBox3.TabIndex = 17;
            this.textBox3.Text = "Status";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rbrackinactive);
            this.panel3.Controls.Add(this.rbrackactive);
            this.panel3.Enabled = false;
            this.panel3.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(195, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(288, 27);
            this.panel3.TabIndex = 3;
            // 
            // rbrackinactive
            // 
            this.rbrackinactive.AutoSize = true;
            this.rbrackinactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbrackinactive.Location = new System.Drawing.Point(146, 1);
            this.rbrackinactive.Name = "rbrackinactive";
            this.rbrackinactive.Size = new System.Drawing.Size(63, 21);
            this.rbrackinactive.TabIndex = 4;
            this.rbrackinactive.Text = "Inactive";
            this.rbrackinactive.UseVisualStyleBackColor = true;
            this.rbrackinactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rbrackinactive_KeyDown);
            // 
            // rbrackactive
            // 
            this.rbrackactive.AutoSize = true;
            this.rbrackactive.Checked = true;
            this.rbrackactive.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.rbrackactive.Location = new System.Drawing.Point(29, 1);
            this.rbrackactive.Name = "rbrackactive";
            this.rbrackactive.Size = new System.Drawing.Size(54, 21);
            this.rbrackactive.TabIndex = 3;
            this.rbrackactive.TabStop = true;
            this.rbrackactive.Text = "Active";
            this.rbrackactive.UseVisualStyleBackColor = true;
            // 
            // txtDEGroupName
            // 
            this.txtDEGroupName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDEGroupName.Enabled = false;
            this.txtDEGroupName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEGroupName.Location = new System.Drawing.Point(14, 21);
            this.txtDEGroupName.Name = "txtDEGroupName";
            this.txtDEGroupName.ReadOnly = true;
            this.txtDEGroupName.Size = new System.Drawing.Size(181, 27);
            this.txtDEGroupName.TabIndex = 11;
            this.txtDEGroupName.Text = "Rack Name";
            // 
            // btnRackClose
            // 
            this.btnRackClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnRackClose.Image = global::ROMS.Properties.Resources.close;
            this.btnRackClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRackClose.Location = new System.Drawing.Point(408, 117);
            this.btnRackClose.Name = "btnRackClose";
            this.btnRackClose.Size = new System.Drawing.Size(75, 29);
            this.btnRackClose.TabIndex = 6;
            this.btnRackClose.Text = "Close";
            this.btnRackClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRackClose.UseVisualStyleBackColor = true;
            // 
            // btnRacksave
            // 
            this.btnRacksave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnRacksave.Image = global::ROMS.Properties.Resources.save;
            this.btnRacksave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRacksave.Location = new System.Drawing.Point(320, 117);
            this.btnRacksave.Name = "btnRacksave";
            this.btnRacksave.Size = new System.Drawing.Size(84, 29);
            this.btnRacksave.TabIndex = 5;
            this.btnRacksave.Text = "Save";
            this.btnRacksave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRacksave.UseVisualStyleBackColor = true;
            // 
            // txtRankName
            // 
            this.txtRankName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRankName.Location = new System.Drawing.Point(195, 21);
            this.txtRankName.MaxLength = 50;
            this.txtRankName.Name = "txtRankName";
            this.txtRankName.Size = new System.Drawing.Size(288, 27);
            this.txtRankName.TabIndex = 1;
            this.txtRankName.Enter += new System.EventHandler(this.TxtRankName_Enter);
            this.txtRankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRankName_KeyDown);
            this.txtRankName.Leave += new System.EventHandler(this.TxtRankName_Leave);
            // 
            // cmbmasterselect
            // 
            this.cmbmasterselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmasterselect.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbmasterselect.FormattingEnabled = true;
            this.cmbmasterselect.Location = new System.Drawing.Point(99, 9);
            this.cmbmasterselect.Name = "cmbmasterselect";
            this.cmbmasterselect.Size = new System.Drawing.Size(120, 27);
            this.cmbmasterselect.TabIndex = 0;
            // 
            // txtdmasterselect
            // 
            this.txtdmasterselect.BackColor = System.Drawing.SystemColors.Control;
            this.txtdmasterselect.Enabled = false;
            this.txtdmasterselect.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdmasterselect.Location = new System.Drawing.Point(24, 9);
            this.txtdmasterselect.Name = "txtdmasterselect";
            this.txtdmasterselect.ReadOnly = true;
            this.txtdmasterselect.Size = new System.Drawing.Size(75, 27);
            this.txtdmasterselect.TabIndex = 64;
            this.txtdmasterselect.Text = "Location Type";
            // 
            // CP_Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(601, 214);
            this.Controls.Add(this.txtdmasterselect);
            this.Controls.Add(this.cmbmasterselect);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grbLocation);
            this.Controls.Add(this.grbrack);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_Location";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CP_Location_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Location_KeyDown);
            this.grbLocation.ResumeLayout(false);
            this.grbLocation.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbrack.ResumeLayout(false);
            this.grbrack.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDLocationName;
        private System.Windows.Forms.TextBox txtLocationName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbLocation;
        private System.Windows.Forms.ErrorProvider errLocation;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtDStatus;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.TextBox txtDlocationtype;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rboutside;
        private System.Windows.Forms.RadioButton rbInside;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbrack;
        private System.Windows.Forms.RadioButton rbLocation;
        private System.Windows.Forms.GroupBox grbrack;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtRankShortName;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbrackinactive;
        private System.Windows.Forms.RadioButton rbrackactive;
        private System.Windows.Forms.TextBox txtDEGroupName;
        private System.Windows.Forms.Button btnRackClose;
        private System.Windows.Forms.Button btnRacksave;
        private System.Windows.Forms.TextBox txtRankName;
        private System.Windows.Forms.ComboBox cmbmasterselect;
        private System.Windows.Forms.TextBox txtdmasterselect;
    }
}