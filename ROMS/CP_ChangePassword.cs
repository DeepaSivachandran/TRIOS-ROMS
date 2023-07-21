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


        private ToolTip tpoldpwd = new ToolTip();
        private ToolTip tpnewpwd = new ToolTip();
        private ToolTip tpconfirmpwd = new ToolTip();
        public CP_ChangePassword()
        {
            InitializeComponent();
            objValidation.resolutionsettingsForm(this);
        }


        private void CP_ChangePassword_Load(object sender, EventArgs e)
        {
           try
            {
                this.ActiveControl = txtOldPassword;
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
                txtOldPassword.BackColor = Color.White;
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
                txtNewPassword.BackColor = Color.White;
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
            try
            {
                txtConfirmPassword.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errChangePwd.Clear();

                if (txtOldPassword.Text.Trim() == "")
                {
                    errChangePwd.SetError(txtOldPassword, "Please enter old password.");
                    txtOldPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpoldpwd.ShowAlways = true;
                    tpoldpwd.Show("Please enter old password.", txtOldPassword, 5000);
                    txtOldPassword.Text = "";
                }


                if (txtNewPassword.Text.Trim() == "")
                {
                    errChangePwd.SetError(txtNewPassword, "Please enter new password.");
                    txtNewPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpnewpwd.ShowAlways = true;
                    tpnewpwd.Show("Please enter new password.", txtNewPassword, 5000);
                    txtNewPassword.Text = "";
                }

                if (txtConfirmPassword.Text.Trim() == "")
                {
                    errChangePwd.SetError(txtConfirmPassword, "Please enter confirm password.");
                    txtConfirmPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpconfirmpwd.ShowAlways = true;
                    tpconfirmpwd.Show("Please enter confirm password.", txtConfirmPassword, 5000);
                    txtConfirmPassword.Text = "";
                }


                if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    errChangePwd.SetError(txtConfirmPassword, "Password not match.");
                    txtConfirmPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpconfirmpwd.ShowAlways = true;
                    tpconfirmpwd.Show("Password not match.", txtConfirmPassword, 5000);
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

                if (txtConfirmPassword.Text.Trim()== "")
                {
                    txtConfirmPassword.Focus();
                    return;
                }

                if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    txtConfirmPassword.Focus();
                    return;
                }



                string result;
                SPDataService objspservice = new SPDataService();
                //  result = objspservice.udfnSPChangePwd(MainForm.pbUserID,GenerateMD5(txtOldPassword.Text), GenerateMD5(txtNewPassword.Text), MainForm.pbIpAddress, "Change Pwd");
                result = "";
                objspservice.CloseConnection();

                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1]+" You are now signed out !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProcessStartInfo Info = new ProcessStartInfo();
                    Info.Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
                    Info.WindowStyle = ProcessWindowStyle.Hidden;
                    Info.CreateNoWindow = true;
                    Info.FileName = "cmd.exe";
                    MainForm.pbCloseForm = 1;
                    Process.Start(Info);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                udfnclear();
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
                tpoldpwd.Active = false;
                tpnewpwd.Active = false;
                tpconfirmpwd.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_ChangePasswordConfirmation = new CP_ChangePasswordConfirmation();
                MainForm.objCP_ChangePasswordConfirmation.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUpdatePasskey_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_ChangePasswordConfirmation = new CP_ChangePasswordConfirmation();
                MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.Text = "Passward";
                MainForm.objCP_ChangePasswordConfirmation.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
