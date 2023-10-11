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
        // Author : DEEPA
        // Created Date: 12-02-2020

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public int varId=0;
        public int varUserId = 0;
        public int varPasswordFlag = 0;
        public int varPasskeyFlag = 0;
        private ToolTip tpOldPassword = new ToolTip();
        private ToolTip tpNewPassword = new ToolTip();
        private ToolTip tpConfirmPassword = new ToolTip();
        public CP_ChangePassword()
        {
            InitializeComponent();
            objValidation.resolutionsettingsForm(this);
        }
        public void udfnLoad()
        {
            try
            {
                lblUserName.Text = MainForm.pbUserName;
                lblUserRole.Text = MainForm.pbUserRoleName;
                varId = Convert.ToInt32(MainForm.pbUserPassKey);
                if (varId==20)
                {
                    gpChangePassKey.Visible = true;
                    txtGenratePasskey.Text = MainForm.pbUserPassKeyValue;
                }
                else
                { gpChangePassKey.Visible = false; }
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
                epPassword.Clear();
                if (txtOldPassword.Text.Trim() == "")
                {
                    epPassword.SetError(txtOldPassword, "Please enter old password.");
                    txtOldPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOldPassword.ShowAlways = true;
                    tpOldPassword.Show("Please enter old password.", txtOldPassword, 5000);
                    txtOldPassword.Text = "";
                }
                if (txtNewPassword.Text.Trim() == "")
                {
                    epPassword.SetError(txtNewPassword, "Please enter new password.");
                    txtNewPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpNewPassword.ShowAlways = true;
                    tpNewPassword.Show("Please enter new password.", txtNewPassword, 5000);
                    txtNewPassword.Text = "";
                }
                if (txtConfirmPassword.Text.Trim() == "")
                {
                    epPassword.SetError(txtConfirmPassword, "Please enter confirm password.");
                    txtConfirmPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConfirmPassword.ShowAlways = true;
                    tpConfirmPassword.Show("Please enter confirm password.", txtConfirmPassword, 5000);
                    txtConfirmPassword.Text = "";
                }
                if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    epPassword.SetError(txtConfirmPassword, "Password not match.");
                    txtConfirmPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConfirmPassword.ShowAlways = true;
                    tpConfirmPassword.Show("Password not match.", txtConfirmPassword, 5000);
                    txtConfirmPassword.Text = "";
                }
                if (txtOldPassword.Text.Trim() == "")
                {
                    txtOldPassword.Focus();
                    return;
                }
                if (txtNewPassword.Text.Trim() == "")
                {
                    txtNewPassword.Focus();
                    return;
                }
                if (txtConfirmPassword.Text.Trim() == "")
                {
                    txtConfirmPassword.Focus();
                    return;
                }
                if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    txtConfirmPassword.Focus();
                    return;
                }
                udfnUpdate();
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
                if (varId == 20)
                {
                    varPasswordFlag = 1;
                    MainForm.objCP_ChangePasswordConfirmation = new CP_ChangePasswordConfirmation();
                    MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.Text = "Passkey";
                    MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.MaxLength = 6;
                    MainForm.objCP_ChangePasswordConfirmation.ShowDialog();
                }
                udfnUpdatePassword();
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
                    varPassword = GenerateMD5(txtNewPassword.Text).Trim();
                    varResult = objspservice.udfnUser(3, Convert.ToInt32(MainForm.pbUserID), "", "", 0, 0, varPassword, 0, 0,"", varOriginator);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    udfnclear();
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
                    objDT = objDser.udfnUserList(9, "", "", "", Convert.ToInt32(MainForm.pbUserID), "");
                    objDser.CloseConnection();
                    objdservice.CloseConnection();
                    if (objDT != null)
                    {
                        if (objDT.Tables.Count != 0)
                        {
                            if (objDT.Tables[0].Rows.Count != 0)
                            {
                                varpasskey = Convert.ToString(objDT.Tables[0].Rows[0]["U_Passkeyvalue"]);
                            }
                        }
                    }
                    varResult = objDser.udfnUser(4, Convert.ToInt32(MainForm.pbUserID), "", "", 0, 0, "", 0, 0, GenerateMD5(varpasskey), varOriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGenratePasskey.Text = varpasskey;
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
