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
namespace ROMS
{
    //Sivabharathi  Created on:9/10/2023
    public partial class CP_ChangePasswordConfirmation : Form
    {
        private SecurityController _security;
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int flag = 0;
        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public string varPassword = "";
        public string varPasskey = "";
        public CP_ChangePasswordConfirmation()
        {
            InitializeComponent();
            _security = new SecurityController();
        }
        public string GenerateMD5(string HashString)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(HashString)).Select(s => s.ToString("x2")));
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDPasskey.Text == "Password")
                { udfnPasswordVerification(); }
                else
                {
                    udfnPassKeyVerification();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPasswordVerification()
        {
            try
            {
                if (txtPassKey.Text != "")
                {
                    DataSet objDs = new DataSet();
                    if (txtPassKey.TextLength != 0)
                    {
                        varPassword =_security.Encrypt (MainForm.pbLoginId.ToLower(),(txtPassKey.Text).Trim());
                        SPDataService objDser = new SPDataService();
                        int count = 0;
                        objDs = objDser.udfnUserList(0, "", MainForm.pbUserName, varPassword, 0,"");
                        objDser.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                count = Convert.ToInt32(objDs.Tables[0].Rows[0]["countvalue"]);
                                if (count != 0)
                                {
                                    //flag = 1;
                                    MainForm.objCP_ChangePassword.varPasskeyFlag = 0;
                                    this.Close();
                                }
                                else if (count == 0)
                                {
                                    //DialogResult response = MessageBox.Show(Convert.ToString(objDs.Tables[1].Rows[0]["MessageText"]), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                    SPDataService objDServ = new SPDataService();
                                    string varMessage = objDServ.udfnGetMessages(62);
                                    objDServ.CloseConnection();
                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtPassKey.Text = "";
                                    txtPassKey.Focus();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPassKeyVerification()
        {
            try
            {
                DataSet objDs = new DataSet();
                if (txtPassKey.TextLength != 0)
                {
                    SPDataService objDser = new SPDataService();
                    int count = 0;
                    varPasskey = _security.Encrypt("passkey", (txtPassKey.Text).Trim());
                    objDs = objDser.udfnUserList(10, "", MainForm.pbUserName,"", 0, varPasskey);
                    objDser.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            count = Convert.ToInt32(objDs.Tables[0].Rows[0]["countvalue"]);
                            if (count != 0)
                            {
                                //flag = 1;
                                MainForm.objCP_ChangePassword.varPasswordFlag = 0;
                                this.Close();
                            }
                            else if (count == 0)
                            {
                                //DialogResult response = MessageBox.Show(Convert.ToString(objDs.Tables[1].Rows[0]["MessageText"]), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                SPDataService objDServ = new SPDataService();
                                string varMessage = objDServ.udfnGetMessages(66);
                                objDServ.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassKey.Text = "";
                                txtPassKey.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_ChangePasswordConfirmation_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtPassKey;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPassKey_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPassKey.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPassKey_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPassKey.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPassKey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnConfirm.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnConfirm_Enter(object sender, EventArgs e)
        {
            try
            {
                btnConfirm.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnConfirm_Leave(object sender, EventArgs e)
        {
            try
            {
                btnConfirm.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnConfirm_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
