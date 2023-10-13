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
{  //Created By:-Sathish
    //Created On:-22/08/2023
    public partial class CP_User : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpusername = new ToolTip();
        private ToolTip tploginid = new ToolTip();
        private ToolTip tppassword = new ToolTip();
        private ToolTip tpconfirmpassword = new ToolTip();
        private ToolTip tpUserRole  = new ToolTip();
        private ToolTip tpUserCategory  = new ToolTip();
        private ToolTip tpPassKey  = new ToolTip();
        public string oldpassword,varpassword;
        public string PbDefault;
        public int varstatus;
        public string varUserID ="";
        public string varusercode="";
        public string varUserRoleCode = "";
        public string PbNameoftheUser = "";
        public string PbLoginid = "";
        public string PbUserCategory = "";
        public string PbUserRole = "";
        public string PbPasskey = "";
        public int PbUserCategoryID = 0;
        public int PbUserRoleID = 0;
        public int PbPasskeyID = 0;
        public int PbStatus=0;
        public int varUpdate = 0;
        public int varCategoryCode;

        public CP_User()
        {
            InitializeComponent();
        }
        private void CP_User_Leave(object sender, EventArgs e)
        {
            try
            {
                tploginid.Active = false;
                tpusername.Active = false;
                tppassword.Active = false;
                tpconfirmpassword.Active = false;
                tpUserRole.Active = false;
                tpUserCategory.Active = false;
                tpPassKey.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtUserName.Text).Trim() == "")
                {
                    epUser.SetError(txtUserName, "Please enter user name");
                    txtUserName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpusername.ShowAlways = true;
                    tpusername.Show("Please enter user name", txtUserName, 5000);

                }
                else
                {
                    epUser.Clear();
                    txtUserName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtLoginID_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLoginID.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtLoginID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbUserRole.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtLoginID_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtLoginID.Text).Trim() == "")
                {
                    epUser.SetError(txtLoginID, "Please enter login id");
                    txtLoginID.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tploginid.ShowAlways = true;
                    tploginid.Show("Please enter login id", txtLoginID, 5000);

                }
                else
                {
                    epUser.Clear();
                    txtLoginID.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
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
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtPassword.Text).Trim() == "")
                {
                    epUser.SetError(txtPassword, "Please enter password");
                    txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tploginid.ShowAlways = true;
                    tploginid.Show("Please enter password", txtPassword, 5000);

                }
                else
                {
                    epUser.Clear();
                    txtPassword.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtCPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCPassword.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtCPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPasskey.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtCPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtCPassword.Text).Trim() == "")
                {
                    epUser.SetError(txtCPassword, "Please enter confirm password");
                    txtCPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpconfirmpassword.ShowAlways = true;
                    tpconfirmpassword.Show("Please enter confirm password", txtCPassword, 5000);

                }
                else
                {
                    epUser.Clear();
                    txtCPassword.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void rbActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void rbActive_KeyDown(object sender, KeyEventArgs e)
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
        private void rbActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void rbInactive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void rbInactive_KeyDown(object sender, KeyEventArgs e)
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
        private void rbInactive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.White;
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                if (rbActive.Checked == true) { varstatus = 1; }
                else { varstatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "User Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "User Updation";
                    varType = 1;
                }
                if(varUserID=="")
                {
                    varUserID = "0";
                }
                varResult = objspservice.udfnUser(varType,Convert.ToInt32( varUserID), (txtUserName.Text).Trim(), (txtLoginID.Text).Trim(), 0, Convert.ToInt16(cmbUserRole.SelectedValue), varpassword, Convert.ToInt16(cmbPasskey.SelectedValue), varstatus, varoriginator);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Userlist.udfnList();
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
                    }
                    udfnClear();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Focus();
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtUserName.Text).Trim() == "")
                {
                    epUser.SetError(txtUserName, "Please enter user name");
                    txtUserName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpusername.ShowAlways = true;
                    tpusername.Show("Please enter user name", txtUserName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtLoginID.Text).Trim() == "")
                {
                    epUser.SetError(txtLoginID, "Please enter login id");
                    txtLoginID.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tploginid.ShowAlways = true;
                    tploginid.Show("Please enter login id", txtLoginID, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbUserRole.SelectedValue) == "" || Convert.ToString(cmbUserRole.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbUserRole, "Please select user role");
                    cmbUserRole.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUserRole.ShowAlways = true;
                    tpUserRole.Show("Please select user role", cmbUserRole, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtPassword.Text).Trim() == "")
                {
                    epUser.SetError(txtPassword, "Please enter password");
                    txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tploginid.ShowAlways = true;
                    tploginid.Show("Please enter password", txtPassword, 5000);
                    blnErrorFlag = true;

                }
                if (Convert.ToString(txtCPassword.Text).Trim() == "")
                {
                    epUser.SetError(txtCPassword, "Please enter confirm password");
                    txtCPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpconfirmpassword.ShowAlways = true;
                    tpconfirmpassword.Show("Please enter confirm password", txtCPassword, 5000);
                    blnErrorFlag = true;
                }
                if (txtPassword.Text.Trim() != txtCPassword.Text.Trim())
                {
                    epUser.SetError(txtCPassword, "Password not match.");
                    txtCPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpconfirmpassword.ShowAlways = true;
                    tpconfirmpassword.Show("Password not match.", txtCPassword, 5000);
                    txtCPassword.Text = "";
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbPasskey.SelectedValue) == "" || Convert.ToString(cmbPasskey.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbPasskey, "Please select pass key");
                    cmbPasskey.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppassword.ShowAlways = true;
                    tpPassKey.Show("Please select pass key", cmbPasskey, 5000);
                    blnErrorFlag = true;
                }

                if (oldpassword != null && oldpassword != "")
                {
                    if (oldpassword.Trim() == txtPassword.Text.Trim())
                    {
                        varpassword = txtPassword.Text;
                    }
                    else
                    {
                        varpassword = GenerateMD5(txtPassword.Text);
                    }
                }
                else
                {
                    varpassword = GenerateMD5(txtPassword.Text);
                }

                if (blnErrorFlag == false)
                {
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void udfnClear()
        {
            txtUserName.Text = "";
            txtLoginID.Text = "";
            txtPassword.Text = "";
            txtCPassword.Text = "";
            cmbUserRole.SelectedIndex = 0;
            cmbPasskey.SelectedIndex = 0;
            rbActive.Checked = true;
            btnSave.Text = "Save";
            txtUserName.Focus();
            this.ActiveControl = txtUserName;
        }
        private void btnSave_Enter(object sender, EventArgs e)
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
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
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
        private void btnSave_Leave(object sender, EventArgs e)
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
        public void udfnclose()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
             //   MainForm.objCP_UserList.udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnClose_KeyDown(object sender, KeyEventArgs e)
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
        private void btnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_User_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Focus();
                this.ActiveControl = txtUserName;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_UserRole", "UR_STSID=1 and URID !=0 Order by URID", "UR_Name,URID", cmbUserRole, "", "UR_Name", "URID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", " MST_TransactionID in (0,7) and MSTID !=0 Order by MSTID", "MST_DisplayText,MSTID", cmbPasskey, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                udfnEdit();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    if (btnSave.Visible)
                    {
                        pnlStatus.Enabled = true;
                    }
                    udfnLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {

                MainForm.objCP_Userlist.picLoader.Visible = false;
                MainForm.objCP_Userlist.picLoader.SendToBack();
            }
        }
        private void udfnLoad()
        {
            try
            {   
                txtUserName.Text = PbNameoftheUser;
                txtLoginID.Text = PbLoginid;
                cmbUserRole.SelectedValue = PbUserRoleID;
                cmbPasskey.SelectedValue = PbPasskeyID;
                if (PbStatus == 1) { rbActive.Checked = true; } else { rbInactive.Checked = true; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_User_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtUserName_Enter(object sender, EventArgs e)
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
        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLoginID.Focus();   
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserRole_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbUserRole.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserRole_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbUserRole.SelectedValue) == "" || Convert.ToString(cmbUserRole.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbUserRole, "Please select user role");
                    cmbUserRole.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUserRole.ShowAlways = true;
                    tpUserRole.Show("Please select user role", cmbUserRole, 5000);
                }
                else
                {
                    epUser.Clear();
                    cmbUserRole.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbUserRole.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserRole_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbUserRole_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPasskey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled)
                    {
                        rbActive.Focus();
                    }
                    else { btnSave.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPasskey_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPasskey_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbPasskey.SelectedValue) == "" || Convert.ToString(cmbPasskey.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbPasskey, "Please select pass key");
                    cmbPasskey.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppassword.ShowAlways = true;
                    tpPassKey.Show("Please select pass key", cmbPasskey, 5000);
                }
                else
                {
                    epUser.Clear();
                    cmbPasskey.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPasskey_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPasskey.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPasskey_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPasskey.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varUpdate == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnEdit()
        {
            try
            {
                if (varUserID != "")
                {
                    pnlStatus.Enabled = true;
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnUserList(3,"", "", "",Convert.ToInt32(varUserID),0);
                    objspdservice.CloseConnection();

                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            txtUserName.Text = objDs.Tables[0].Rows[0]["U_Name"].ToString().Replace("''", "'");
                            txtLoginID.Text = objDs.Tables[0].Rows[0]["U_LoginID"].ToString();
                            txtPassword.Text = objDs.Tables[0].Rows[0]["U_Password"].ToString();
                            oldpassword = objDs.Tables[0].Rows[0]["U_Password"].ToString();
                            txtCPassword.Text = objDs.Tables[0].Rows[0]["U_Password"].ToString();
                          //  cmbUserRole.SelectedValue= objDS.Tables[0].Rows[0]["UserRoleCode"].ToString();
                            if (objDs.Tables[0].Rows[0]["U_STSID"].ToString() == "1")
                            {
                                rbActive.Checked = true;
                            }
                            else
                            {
                                rbInactive.Checked = true;
                            }
                            btnSave.Text = "Update";
                        }
                    }
                }
                else { pnlStatus.Enabled = false; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {

            }
        }
    }
}
