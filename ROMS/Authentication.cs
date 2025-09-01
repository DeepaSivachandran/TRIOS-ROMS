using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

//[assembly: XmlConfigurator(Watch = true)]
//[assembly: Repository()]
// Author : Deepa
namespace ROMS
{
    public partial class Authentication : Form
    {
        private SecurityController _security; 

        // ***** Object for data service classes declaration *****
        DataValidation objValidation = new DataValidation();
        DataError objError;

        // ***** Declaration Part *****
        public static string varUserID;
        public string varUserName = "";
        ToolTip tpUserName = new ToolTip();
        ToolTip tpPassword = new ToolTip();
        public Authentication()
        {
            InitializeComponent();
            _security = new SecurityController();
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUserName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            try
            {
                txtUserName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSignin.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPassword.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPassword.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet objDs = new DataSet();
                if (txtUserName.TextLength != 0 & txtPassword.TextLength != 0)
                {
                    SPDataService objDser = new SPDataService();
                    int count = 0;
                    // objDs = objDser.udfnUserList(0,varUserName ,txtUserName.Text.Trim(), GenerateMD5(txtPassword.Text),0,"");
                    objDs = objDser.udfnUserList(0, varUserName, txtUserName.Text.Trim(), _security.Encrypt(txtUserName.Text.Trim().ToLower(), txtPassword.Text), 0, 0, "");
                    objDser.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count > 0)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                count = Convert.ToInt32(objDs.Tables[0].Rows[0]["countvalue"]);
                                if (count != 0)
                                {
                                    MainForm.pbUserID = objDs.Tables[1].Rows[0]["Userid"].ToString();
                                    MainForm.pbUserRoleId = objDs.Tables[1].Rows[0]["UserRoleCode"].ToString();
                                    MainForm.pbUserName = objDs.Tables[1].Rows[0]["UserName"].ToString();
                                    MainForm.pbLoginId = objDs.Tables[1].Rows[0]["LoginId"].ToString();
                                    MainForm.pbUserRoleName = objDs.Tables[1].Rows[0]["RoleName"].ToString();
                                    MainForm.pbUserPassKey = objDs.Tables[1].Rows[0]["PassKey"].ToString();
                                    MainForm.pbUserPassKeyValue = _security.Decrypt("passkey", objDs.Tables[1].Rows[0]["PasskeyValue"].ToString());
                                    MainForm.pbVersion = lblDVersion.Text;
                                    MainForm.pbHostName = Dns.GetHostName();
                                    MainForm.pbSSSSoftwareName = udfnDBName();
                                    //MainForm.pbRomsSoftwareName = objDs.Tables[2].Rows[1]["TableName"].ToString();
                                    MainForm.pbReleaseDt = objDs.Tables[2].Rows[0]["ReleaseDate"].ToString();
                                    this.Hide();
                                    MainForm obj = new MainForm();
                                    obj.Show();
                                }
                                else if (count == 0)
                                {
                                    DialogResult response = MessageBox.Show(Convert.ToString(objDs.Tables[1].Rows[0]["MessageText"]), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                    txtUserName.Text = "";
                                    txtPassword.Text = "";
                                    txtUserName.Focus();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (txtUserName.Text == "")
                    {
                        txtUserName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpUserName.Show("User Name is required", txtUserName, 5000);
                    }
                    else
                    {
                        tpUserName.Hide(txtUserName);
                    }
                    if (txtPassword.Text == "")
                    {
                        txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPassword.Show("Password is required", txtPassword, 5000);
                    }
                    else
                    {
                        tpPassword.Hide(txtPassword);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public string udfnDBName()
        {
            string varDBName = "";
            try
            {
                string path = Application.StartupPath + "\\Server Settings\\serversettings.txt";
                if (File.Exists(path))
                {
                    string lines = File.ReadAllText(path);
                    if (lines != null & lines != "")
                    {
                        string[] words = lines.Split(',');
                        varDBName = words[1];
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            return varDBName;
        }
        public string GenerateMD5(string HashString)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(HashString)).Select(s => s.ToString("x2")));
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        // ***** Check newer version with server *****
        public void checknewversion()
        {
            this.Enabled = false;
            try
            {
                DataService objDserv = new DataService();
                string varNewVersion = objDserv.displaydata("SELECT COALESCE( (select top (1) VersionNumber from TRANS_Release order by VersionNumber desc),'')");
                objDserv.CloseConnection();
                if (varNewVersion != lblDVersion.Text && varNewVersion != null && varNewVersion != "")
                {
                    DialogResult objDialogueResult = MessageBox.Show("A newer version of this software is available on the server. You need to upgrade. Click OK to continue, CANCEL to exit.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (objDialogueResult == DialogResult.Cancel)
                    { this.Close(); }
                    else
                    {
                        string varPath = ""; string varSetupName = "";
                        DataSet objDs = new DataSet();
                        objDs = objDserv.GetDataset("select top 1 path,name from DEF_SharedFolderPath where pathcode=1 ");
                        objDserv.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count > 0)
                            {
                                if (objDs.Tables[0].Rows.Count > 0)
                                {
                                    varPath = Convert.ToString(objDs.Tables[0].Rows[0]["path"]);
                                    varSetupName = Convert.ToString(objDs.Tables[0].Rows[0]["name"]) + " " + varNewVersion;
                                    System.IO.DirectoryInfo objDir = new System.IO.DirectoryInfo(varPath);
                                    foreach (System.IO.FileInfo varFile in objDir.GetFiles("*.*"))
                                    {
                                        if (varFile.Exists)
                                        {
                                            try
                                            {
                                                // Run .exe from server
                                                Process varProcess = new Process();
                                                varProcess.StartInfo.FileName = "msiexec";
                                                varProcess.StartInfo.Arguments = "/i " + varFile.FullName + "";
                                                varProcess.Start();
                                                System.Environment.Exit(1);
                                                varProcess.WaitForExit();
                                            }
                                            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
                                            finally { this.Close(); }
                                        }
                                        else
                                        {
                                            DialogResult result = MessageBox.Show("File not uploaded in shared folder!", "Warning", MessageBoxButtons.OK);
                                            if (result == DialogResult.OK)
                                            {
                                                this.Close();
                                            }
                                            else { this.Close(); }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); this.Close(); }
            finally { this.Enabled = true; }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        public void Authentication_Load(object sender, EventArgs e)
        {
            string VersionName = "";
            //MR_Master objMR_Master = new MR_Master();
            //objMR_Master.ViewType = 20;
            //SPDataService objdserv = new SPDataService();
            //DataSet objDT = new DataSet();
            //objDT = objdserv.udfnMaster(objMR_Master);
            //objdserv.CloseConnection();
            //if (objDT != null)
            //{
            //    if (objDT.Tables.Count > 0)
            //    {
            //        if (objDT.Tables[0].Rows.Count > 0)
            //        {
            //            VersionName = objDT.Tables[0].Rows[0]["RLS_VersionNo"].ToString();
            //        }
            //    }
            //}
            VersionName = ConfigurationManager.AppSettings["versionno"];
            lblDVersion.Text = VersionName;
            lblDVersion.BringToFront();
            Authentication objAuthetication = new Authentication();
            objAuthetication.Name = " - " + lblDVersion.Text;
            //}
            //else { Application.Run(new ServerSettings()); }
        }
        // Author : Deepa
        // Created Date: 12-02-20202
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void Authentication_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Author : Deepa
        // Created Date: 12-02-2020
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Hide();
                ServerSettings obj = new ServerSettings();
                obj.lblformname.Text = "login";
                obj.Show();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabel1.Text);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
    }
}
