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
    public partial class CP_User : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpusername = new ToolTip();
        private ToolTip tploginid = new ToolTip();
        private ToolTip tppassword = new ToolTip();
        private ToolTip tpconfirmpassword = new ToolTip();
        private ToolTip tpUserRole  = new ToolTip();
        private ToolTip tpUserCatagory  = new ToolTip();
        private ToolTip tpPassKey  = new ToolTip();

        public string oldpassword,varpassword;
        public string varusercode="";
        public string varUserRoleCode = "";

        public CP_User()
        {
            InitializeComponent();
        }
        public void udfnLoadUserRole()
        {
            //try
            //{
            //    // Bind combobox
            //    DataBind objDataBind = new DataBind();
            //    objDataBind.BindComboBoxListSelected("View_UserRole", "rolecode<>0 and 1=1 Order by rolecode", "rolename,rolecode", cmbUserRole, "", "rolename", "rolecode");
            //    objDataBind = null;
            //    if (varUserRoleCode != "")
            //    {
            //        cmbUserRole.SelectedValue = varUserRoleCode;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
      

        private void txtUserName_Leave(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToString(txtUserName.Text).Trim() == "")
                {
                    epUser.SetError(txtUserName, "Please Enter User Name");
                    txtUserName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpusername.ShowAlways = true;
                    tpusername.Show("Please Enter User Name", txtUserName, 5000);

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
                    cmbUserCatagory.Focus();
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
                    epUser.SetError(txtLoginID, "Please Enter Login Id");
                    txtLoginID.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tploginid.ShowAlways = true;
                    tploginid.Show("Please Enter Login Id", txtLoginID, 5000);

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
                    epUser.SetError(txtPassword, "Please Enter Password");
                    txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tploginid.ShowAlways = true;
                    tploginid.Show("Please Enter Password", txtPassword, 5000);

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
                    epUser.SetError(txtCPassword, "Please Enter Confirm Password");
                    txtCPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpconfirmpassword.ShowAlways = true;
                    tpconfirmpassword.Show("Please Enter Confirm Password", txtCPassword, 5000);

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
                bool blnErrorFlag = false;

                if (Convert.ToString(txtUserName.Text).Trim() == "")
                {
                    epUser.SetError(txtUserName, "Please Enter User Name");
                    txtUserName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpusername.ShowAlways = true;
                    tpusername.Show("Please Enter User Name", txtUserName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtLoginID.Text).Trim() == "")
                {
                    epUser.SetError(txtLoginID, "Please Enter Login Id");
                    txtLoginID.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tploginid.ShowAlways = true;
                    tploginid.Show("Please Enter Login Id", txtLoginID, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbUserCatagory.SelectedValue) == "" || Convert.ToString(cmbUserCatagory.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbUserCatagory, "Please Select User Catagory");
                    cmbUserCatagory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUserCatagory.ShowAlways = true;
                    tpUserCatagory.Show("Please Select User Catagory", cmbUserCatagory, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbUserRole.SelectedValue) == "" || Convert.ToString(cmbUserRole.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbUserRole, "Please Select User Role");
                    cmbUserRole.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUserRole.ShowAlways = true;
                    tpUserRole.Show("Please Select User Role", cmbUserRole, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtPassword.Text).Trim() == "")
                {
                    epUser.SetError(txtPassword, "Please Enter Password");
                    txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppassword.ShowAlways = true;
                    tppassword.Show("Please Enter Password", txtPassword, 5000);
                    blnErrorFlag = true;

                }
                if (Convert.ToString(txtCPassword.Text).Trim() == "")
                {
                    epUser.SetError(txtCPassword, "Please Enter Confirm Password");
                    txtCPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpconfirmpassword.ShowAlways = true;
                    tpconfirmpassword.Show("Please Enter Confirm Password", txtCPassword, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbPasskey.SelectedValue) == "" || Convert.ToString(cmbPasskey.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbPasskey, "Please Select Pass Key");
                    cmbPasskey.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppassword.ShowAlways = true;
                    tpPassKey.Show("Please Select Pass Key", cmbPasskey, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    udfnSave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnClear()
        {
            txtUserName.Text = "";
            txtLoginID.Text = "";
            txtPassword.Text = "";
            txtCPassword.Text = "";
            rbActive.Checked = true;
            //cmbUserRole.SelectedValue = "-1";
            btnSave.Text = "Save";
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
                btnSave.BackColor = Color.White;
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
                btnClose.BackColor = Color.White;
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

                //this.ActiveControl = txtUserName;
                //udfnLoadUserRole();
                //udfnEdit();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                }
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

        private void CmbUserCatagory_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbUserCatagory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUserCatagory_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbUserCatagory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbUserCatagory_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbUserCatagory.SelectedValue) == "" || Convert.ToString(cmbUserCatagory.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbUserCatagory, "Please Select User Catagory");
                    cmbUserCatagory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUserCatagory.ShowAlways = true;
                    tpUserCatagory.Show("Please Select User Catagory", cmbUserCatagory, 5000);
                }
                else
                {
                    epUser.Clear();
                    cmbUserCatagory.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUserCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                BeginInvoke(new Action(() => cmbUserCatagory.Select(int.MaxValue, 0)));
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
                    epUser.SetError(cmbUserRole, "Please Select User Role");
                    cmbUserRole.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUserRole.ShowAlways = true;
                    tpUserRole.Show("Please Select User Role", cmbUserRole, 5000);
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
                    epUser.SetError(cmbPasskey, "Please Select Pass Key");
                    cmbPasskey.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppassword.ShowAlways = true;
                    tpPassKey.Show("Please Select Pass Key", cmbPasskey, 5000);
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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_UserCatagory = new CP_UserCatagory();
                MainForm.objCP_UserCatagory.ShowDialog();
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
                if (varusercode != "")
                {
                    pnlStatus.Enabled = true;
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS = new DataSet();
                  //  objDS = objspservice.udfnSPUserList("EditLoad", varusercode, MainForm.pbUserID, MainForm.pbIpAddress);
                    objspservice.CloseConnection();

                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtUserName.Text = objDS.Tables[0].Rows[0]["UserName"].ToString().Replace("''", "'");
                            txtLoginID.Text = objDS.Tables[0].Rows[0]["Userid"].ToString();
                            txtPassword.Text = objDS.Tables[0].Rows[0]["UserPassword"].ToString();
                            oldpassword = objDS.Tables[0].Rows[0]["UserPassword"].ToString();
                            txtCPassword.Text = objDS.Tables[0].Rows[0]["UserPassword"].ToString();
                          //  cmbUserRole.SelectedValue= objDS.Tables[0].Rows[0]["UserRoleCode"].ToString();

                            if (objDS.Tables[0].Rows[0]["Statuscode"].ToString() == "1")
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
