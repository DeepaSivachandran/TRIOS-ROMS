using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    //  Created By Sathish 
    //  Created ON 14-10-2025
    public partial class CP_User_ResetPassword : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpNewPassword = new ToolTip();
        private ToolTip tpConfirmPassword = new ToolTip();
        public string pbvarUserLoginID = "0";
        public int pbvarUserID = 0;
        private SecurityController _security;
        public CP_User_ResetPassword()
        {
            InitializeComponent();
            _security = new SecurityController();
        }
        private void BtnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                epPassword.Clear();
                bool blnErrorFlag = false;
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
                if (blnErrorFlag == false)
                {
                    udfnUpdatePassword();
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
                if (pbvarUserLoginID != "0")
                {
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varOriginator = "Password Updation", varPassword = "";
                    varPassword = _security.Encrypt(pbvarUserLoginID.ToLower(), txtNewPassword.Text.Trim());
                    varResult = objspservice.udfnUser(3, Convert.ToInt32(MainForm.pbUserID), "", "", 0, 0, varPassword, 0, 0, "", varOriginator, Convert.ToString(pbvarUserID), 0, null, 0);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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

        private void CP_User_ResetPassword_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtNewPassword;
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

        private void txtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
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

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
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
    }
}
