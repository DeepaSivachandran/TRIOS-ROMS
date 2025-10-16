using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;

namespace ROMS
{
    public partial class CP_ChangePassword : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        // Author : DEEPA
        //Sivabharathi on 10-10-2023

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private SecurityController _security = new SecurityController();
        public int varPassKeyId=0;
        public int varUserId = 0;
        public int varPasswordFlag = 0;
        public int varPasskeyFlag = 0,flag=0;
        public string varPassword = "",varPasskeyValue="";
        private ToolTip tpOldPassword = new ToolTip();
        private ToolTip tpNewPassword = new ToolTip();
        private ToolTip tpConfirmPassword = new ToolTip();
        public CP_ChangePassword()
        {
            InitializeComponent();
            objValidation.resolutionsettingsForm(this);
            windowControl.Initialize(tsProfile, this);
        }
        public void udfnLoad()
        {
            try
            {
                lblUserName.Text = MainForm.pbUserName;
                lblUserRole.Text = MainForm.pbUserRoleName;
                DataSet objDsUser = new DataSet();
                SPDataService objDser = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objDser.udfnUserList(10, "", MainForm.pbLoginId, "", 0, 0, "");
                objDser.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            varPassKeyId = Convert.ToInt32(objDs.Tables[1].Rows[0]["PassKeyID"]);
                            varPassword=Convert.ToString(objDs.Tables[1].Rows[0]["Password"]);
                            varPasskeyValue= _security.Decrypt("passkey", objDs.Tables[1].Rows[0]["PasskeyValue"].ToString());
                        }
                    }
                }
                if (varPassKeyId == 20)
                {
                    gpChangePassKey.Visible = true;
                    txtGenratePasskey.Text = varPasskeyValue;
                }
                else
                {
                    gpChangePassKey.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                throw ex;
            }
        }
        public void udfnPasswordVerification()
        {
            try
            {
                DataSet objDs = new DataSet();
                 // varPassword = (txtPassKey.Text).Trim();
                SPDataService objDser = new SPDataService();
                int count = 0;
                //objDs = objDser.udfnUserList(0, "", MainForm.pbUserName,, 0, "");
                objDser.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        count = Convert.ToInt32(objDs.Tables[0].Rows[0]["countvalue"]);
                        if (count != 0)
                        {
                            flag = 1;
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                throw ex;
            }
        }
        private void CP_ChangePassword_Load(object sender, EventArgs e)
        {
           try
           {
                this.ActiveControl = txtOldPassword;
                udfnLoad();
           }
           catch (Exception ex)
           {
                objError = new DataError();
                objError.WriteFile(ex);
                throw ex;
           }
        }

        private void txtOldPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOldPassword.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOldPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtOldPassword.Text).Trim() == "")
                {
                    epPassword.SetError(txtOldPassword, "Please enter password");
                    txtOldPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOldPassword.ShowAlways = true;
                    tpOldPassword.Show("Please enter password", txtOldPassword, 5000);
                }
                else
                {
                    epPassword.Clear();
                    txtOldPassword.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOldPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNewPassword.Focus();
                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtNewPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                txtNewPassword.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtNewPassword.Text).Trim() == "")
                {
                    epPassword.SetError(txtNewPassword, "Please enter new password");
                    txtNewPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpNewPassword.ShowAlways = true;
                    tpNewPassword.Show("Please enter new password", txtNewPassword, 5000);

                }
                else
                {
                    epPassword.Clear();
                    txtNewPassword.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtConfirmPassword.Focus();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                txtConfirmPassword.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (Convert.ToString(txtConfirmPassword.Text).Trim() == "")
            {
                epPassword.SetError(txtConfirmPassword, "Please enter confirm password");
                txtConfirmPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpConfirmPassword.ShowAlways = true;
                tpConfirmPassword.Show("Please enter confirm password", txtConfirmPassword, 5000);

            }
            else
            {
                epPassword.Clear();
                txtConfirmPassword.BackColor = Color.White;
            }
        }
        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnUpdate.Focus();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnclear()
        {
            try
            {
                txtOldPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtOldPassword.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public string GenerateMD5(string HashString)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(HashString)).Select(s => s.ToString("x2")));
        }

        private void CP_ChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_ChangePassword_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConfirmPassword.Active = false;
                tpNewPassword.Active = false;
                tpOldPassword.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                epPassword.Clear(); bool blnErrorFlag = false;
                if (txtOldPassword.Text.Trim() == "")
                {
                    epPassword.SetError(txtOldPassword, "Please enter old password.");
                    txtOldPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOldPassword.ShowAlways = true;
                    tpOldPassword.Show("Please enter old password.", txtOldPassword, 5000);
                    txtOldPassword.Text = "";
                    blnErrorFlag = true;
                }
                if (txtNewPassword.Text.Trim() == "")
                {
                    epPassword.SetError(txtNewPassword, "Please enter new password.");
                    txtNewPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpNewPassword.ShowAlways = true;
                    tpNewPassword.Show("Please enter new password.", txtNewPassword, 5000);
                    txtNewPassword.Text = "";
                    blnErrorFlag = true;
                }
                if (txtConfirmPassword.Text.Trim() == "")
                {
                    epPassword.SetError(txtConfirmPassword, "Please enter confirm password.");
                    txtConfirmPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConfirmPassword.ShowAlways = true;
                    tpConfirmPassword.Show("Please enter confirm password.", txtConfirmPassword, 5000);
                    txtConfirmPassword.Text = "";
                    blnErrorFlag = true;
                }
                if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    epPassword.SetError(txtConfirmPassword, "Password not match.");
                    txtConfirmPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConfirmPassword.ShowAlways = true;
                    tpConfirmPassword.Show("Password not match.", txtConfirmPassword, 5000);
                    txtConfirmPassword.Text = "";
                    blnErrorFlag = true;
                }
                //if (txtNewPassword.Text.Trim() == txtOldPassword.Text.Trim() || flag==1)
                //{
                //    epPassword.SetError(txtNewPassword, "Old and new password are same.");
                //    txtNewPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpNewPassword.ShowAlways = true;
                //    tpNewPassword.Show("Old and new password are same.", txtNewPassword, 5000);
                //    txtNewPassword.Text = "";
                //    txtConfirmPassword.Text = "";
                //    blnErrorFlag = true;
                //}
                if(blnErrorFlag==false)
                {
                    udfnUpdate();
                }
                //if (txtOldPassword.Text.Trim() == "")
                //{
                //    txtOldPassword.Focus();
                //    return;
                //}
                //if (txtNewPassword.Text.Trim() == "")
                //{
                //    txtNewPassword.Focus();
                //    return;
                //}
                //if (txtConfirmPassword.Text.Trim() == "")
                //{
                //    txtConfirmPassword.Focus();
                //    return;
                //}
                //if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                //{
                //    txtConfirmPassword.Focus();
                //    return;
                //}

                //string result;
                //SPDataService objspservice = new SPDataService();
                ////  result = objspservice.udfnSPChangePwd(MainForm.pbUserID,GenerateMD5(txtOldPassword.Text), GenerateMD5(txtNewPassword.Text), MainForm.pbIpAddress, "Change Pwd");
                //result = "";
                //objspservice.CloseConnection();

                //string[] varvalue = result.Split('~');
                //if (varvalue[0] == "3")
                //{
                //    MessageBox.Show(varvalue[1] + " You are now signed out !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    ProcessStartInfo Info = new ProcessStartInfo();
                //    Info.Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
                //    Info.WindowStyle = ProcessWindowStyle.Hidden;
                //    Info.CreateNoWindow = true;
                //    Info.FileName = "cmd.exe";
                //    MainForm.pbCloseForm = 1;
                //    Process.Start(Info);
                //    Application.Exit();
                //}
                //else
                //{
                //    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //udfnclear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUpdate()
        {
            try
            {
                string varPassword = _security.Encrypt(MainForm.pbLoginId.Trim().ToLower(), txtOldPassword.Text.Trim());
                if ((_security.Encrypt(MainForm.pbLoginId.Trim().ToLower(), txtOldPassword.Text.Trim())!=varPassword))
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(68);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOldPassword.Text = "";
                    txtOldPassword.Focus();
                }
                else
                {
                    int varCountValue = 0;
                    SPDataService objDServ1 = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objDServ1.udfnUserList(11,"",MainForm.pbLoginId,varPassword,0,0,"");
                    if (objDs != null) {
                        if (objDs.Tables.Count > 0) {
                            if (objDs.Tables[0].Rows.Count > 0) {
                                varCountValue = Convert.ToInt32(objDs.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varCountValue == 0)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(68);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNewPassword.Text = "";
                        txtConfirmPassword.Text = "";
                        txtOldPassword.Text = "";
                        txtOldPassword.Focus();
                        return;
                    }
                    if (txtOldPassword.Text.Trim() == txtNewPassword.Text.Trim())
                    {
                        flag = 1;
                    }
                    else
                    {
                        if (varPassKeyId == 20)
                        {
                            varPasswordFlag = 1;
                            MainForm.objCP_ChangePasswordConfirmation = new CP_ChangePasswordConfirmation();
                            MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.Text = "Passkey";
                            MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.MaxLength = 6;
                            MainForm.objCP_ChangePasswordConfirmation.ShowDialog();
                        }
                        flag = 0;
                    }
                    if (flag == 1)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(69);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNewPassword.Text = "";
                        txtConfirmPassword.Text = "";
                        txtNewPassword.Focus();
                    }
                    else
                    {
                        epPassword.Clear();
                        udfnUpdatePassword();
                    }
                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUpdatePassword()
        {
            try
            {
                if (varPasswordFlag == 0)
                {
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varOriginator = "Password Updation", varPassword = "";
                    varPassword = _security.Encrypt(MainForm.pbLoginId.Trim().ToLower(), txtNewPassword.Text.Trim());
                    varResult = objspservice.udfnUser(3, Convert.ToInt32(MainForm.pbUserID), "", "", 0, 0, varPassword, 0, 0, "", varOriginator, MainForm.pbUserID, 0, null, 0);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnLoad();
                    }
                    else
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    udfnclear();
                    txtOldPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGenratePasskey_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOldPassword.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGenratePasskey_Leave(object sender, EventArgs e)
        {
            try
            {
                txtOldPassword.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGenratePasskey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGenratePasskey.PasswordChar == '\0')
                {
                    txtGenratePasskey.PasswordChar = '*';
                    this.btnView.Image = global::ROMS.Properties.Resources.close_eye;
                    this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                }
                else
                {
                    txtGenratePasskey.PasswordChar = '\0';
                    this.btnView.Image = global::ROMS.Properties.Resources.view_eye;
                    this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGeneratePassKey()
        {
            try
            {
                if (varPasskeyFlag == 0)
                {
                    string varResult = ""; string varpasskey = "", varOriginator = "Passkey Updation";
                    DataService objdservice = new DataService();
                    DataSet objDT = new DataSet();
                    SPDataService objDser = new SPDataService();
                    objDT = objDser.udfnUserList(9, "", "", "", 0,0, "");
                    objDser.CloseConnection();
                    objdservice.CloseConnection();
                    if (objDT != null)
                    {
                        if (objDT.Tables.Count != 0)
                        {
                            if (objDT.Tables[0].Rows.Count != 0)
                            {
                                varpasskey = Convert.ToString(objDT.Tables[0].Rows[0]["PasskeyValue"]);
                            }
                        }
                    }
                    varResult = objDser.udfnUser(4, Convert.ToInt32(MainForm.pbUserID), "", "", 0, 0, "", 0, 0, _security.Encrypt("passkey", varpasskey), varOriginator, MainForm.pbUserID, 0, null, 0);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGenratePasskey.Text = varpasskey;
                         udfnLoad();
                    }
                    else
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUpdate_Enter(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GroupBox2_Leave(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Leave(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnUpdate_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                varPasskeyFlag = 1;
                MainForm.objCP_ChangePasswordConfirmation = new CP_ChangePasswordConfirmation();
                MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.Text = "Password";
                MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.MaxLength = 50;
                MainForm.objCP_ChangePasswordConfirmation.ShowDialog();
                udfnGeneratePassKey();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
