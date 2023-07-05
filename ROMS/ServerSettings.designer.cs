namespace ROMS
{
    partial class ServerSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerSettings));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDBUserName = new System.Windows.Forms.TextBox();
            this.lblDDBUserName = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.lblDDBName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblDServerName = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblDPassword = new System.Windows.Forms.Label();
            this.txtWebServiceName = new System.Windows.Forms.TextBox();
            this.lblDWcfUrl = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblformname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ROMS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(228, 178);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 34);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtDBUserName
            // 
            this.txtDBUserName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBUserName.Location = new System.Drawing.Point(132, 100);
            this.txtDBUserName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDBUserName.Name = "txtDBUserName";
            this.txtDBUserName.Size = new System.Drawing.Size(263, 27);
            this.txtDBUserName.TabIndex = 2;
            this.txtDBUserName.Enter += new System.EventHandler(this.txtusername_Enter);
            this.txtDBUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtusername_KeyDown);
            this.txtDBUserName.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // lblDDBUserName
            // 
            this.lblDDBUserName.AutoSize = true;
            this.lblDDBUserName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDDBUserName.Location = new System.Drawing.Point(35, 105);
            this.lblDDBUserName.Name = "lblDDBUserName";
            this.lblDDBUserName.Size = new System.Drawing.Size(86, 20);
            this.lblDDBUserName.TabIndex = 18;
            this.lblDDBUserName.Text = "DB User Name";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataBase.Location = new System.Drawing.Point(132, 62);
            this.txtDataBase.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(263, 27);
            this.txtDataBase.TabIndex = 1;
            this.txtDataBase.Enter += new System.EventHandler(this.txtdatabase_Enter);
            this.txtDataBase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdatabase_KeyDown);
            this.txtDataBase.Leave += new System.EventHandler(this.txtdatabase_Leave);
            // 
            // lblDDBName
            // 
            this.lblDDBName.AutoSize = true;
            this.lblDDBName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDDBName.Location = new System.Drawing.Point(28, 67);
            this.lblDDBName.Name = "lblDDBName";
            this.lblDDBName.Size = new System.Drawing.Size(92, 20);
            this.lblDDBName.TabIndex = 16;
            this.lblDDBName.Text = "Database Name";
            // 
            // txtServerName
            // 
            this.txtServerName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerName.Location = new System.Drawing.Point(132, 25);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(263, 27);
            this.txtServerName.TabIndex = 0;
            this.txtServerName.Enter += new System.EventHandler(this.txtservername_Enter);
            this.txtServerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtservername_KeyDown);
            this.txtServerName.Leave += new System.EventHandler(this.txtservername_Leave);
            // 
            // lblDServerName
            // 
            this.lblDServerName.AutoSize = true;
            this.lblDServerName.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDServerName.Location = new System.Drawing.Point(23, 30);
            this.lblDServerName.Name = "lblDServerName";
            this.lblDServerName.Size = new System.Drawing.Size(100, 20);
            this.lblDServerName.TabIndex = 14;
            this.lblDServerName.Text = "Server Name / IP";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.Location = new System.Drawing.Point(25, 178);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(113, 34);
            this.btnTestConnection.TabIndex = 5;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(132, 139);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(263, 27);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Enter += new System.EventHandler(this.txtpaswword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpaswword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtpaswword_Leave);
            // 
            // lblDPassword
            // 
            this.lblDPassword.AutoSize = true;
            this.lblDPassword.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDPassword.Location = new System.Drawing.Point(61, 144);
            this.lblDPassword.Name = "lblDPassword";
            this.lblDPassword.Size = new System.Drawing.Size(61, 20);
            this.lblDPassword.TabIndex = 29;
            this.lblDPassword.Text = "Password";
            // 
            // txtWebServiceName
            // 
            this.txtWebServiceName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWebServiceName.Location = new System.Drawing.Point(132, 178);
            this.txtWebServiceName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtWebServiceName.Name = "txtWebServiceName";
            this.txtWebServiceName.Size = new System.Drawing.Size(263, 23);
            this.txtWebServiceName.TabIndex = 4;
            this.txtWebServiceName.Text = "SSS";
            this.txtWebServiceName.Visible = false;
            this.txtWebServiceName.Enter += new System.EventHandler(this.txtwebservicename_Enter);
            this.txtWebServiceName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtwebservicename_KeyDown);
            this.txtWebServiceName.Leave += new System.EventHandler(this.txtwebservicename_Leave);
            // 
            // lblDWcfUrl
            // 
            this.lblDWcfUrl.AutoSize = true;
            this.lblDWcfUrl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDWcfUrl.Location = new System.Drawing.Point(23, 183);
            this.lblDWcfUrl.Name = "lblDWcfUrl";
            this.lblDWcfUrl.Size = new System.Drawing.Size(100, 15);
            this.lblDWcfUrl.TabIndex = 31;
            this.lblDWcfUrl.Text = "WCF URL : http://";
            this.lblDWcfUrl.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(325, 178);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 34);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblformname
            // 
            this.lblformname.AutoSize = true;
            this.lblformname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblformname.Location = new System.Drawing.Point(161, 296);
            this.lblformname.Name = "lblformname";
            this.lblformname.Size = new System.Drawing.Size(0, 15);
            this.lblformname.TabIndex = 33;
            this.lblformname.Visible = false;
            // 
            // ServerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 229);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblformname);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtWebServiceName);
            this.Controls.Add(this.lblDWcfUrl);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblDPassword);
            this.Controls.Add(this.txtDBUserName);
            this.Controls.Add(this.lblDDBUserName);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.lblDDBName);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblDServerName);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "ServerSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerSettings_KeyDown);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDBUserName;
        private System.Windows.Forms.Label lblDDBUserName;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Label lblDDBName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblDServerName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TextBox txtWebServiceName;
        private System.Windows.Forms.Label lblDWcfUrl;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblDPassword;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblformname;
    }
}