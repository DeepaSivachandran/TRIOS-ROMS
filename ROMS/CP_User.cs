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
        private ToolTip tpuserid = new ToolTip();
        private ToolTip tppassword = new ToolTip();
        private ToolTip tpconfirmpassword = new ToolTip();
        private ToolTip tpUserRole  = new ToolTip();
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
        private void txtUserName_Enter(object sender, EventArgs e)
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

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtUserName_Leave(object sender, EventArgs e)
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
                    txtPassword.Focus();
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
                txtLoginID.BackColor = Color.White;
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
                txtPassword.BackColor = Color.White;
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
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        cmbUserRole.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtCPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCPassword.BackColor = Color.White;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errUser.Clear();

                if (txtUserName.Text.Trim() == "")
                {
                    errUser.SetError(txtUserName, "Please enter name of the user.");
                    txtUserName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpusername.ShowAlways = true;
                    tpusername.Show("Please enter name of the user.", txtUserName, 5000);
                    txtUserName.Text = "";
                }
                if (txtLoginID.Text.Trim() == "")
                {
                    errUser.SetError(txtLoginID, "Please enter Login Id.");
                    txtLoginID.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpuserid.ShowAlways = true;
                    tpuserid.Show("Please enter Login Id.", txtLoginID, 5000);
                    txtLoginID.Text = "";
                }

                if (txtPassword.Text.Trim() == "")
                {
                    errUser.SetError(txtPassword, "Please enter Password.");
                    txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tppassword.ShowAlways = true;
                    tppassword.Show("Please enter Password.", txtPassword, 5000);
                    txtPassword.Text = "";
                }

                if (txtCPassword.Text.Trim() == "")
                {
                    errUser.SetError(txtCPassword, "Please enter confirm Password.");
                    txtCPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpconfirmpassword.ShowAlways = true;
                    tpconfirmpassword.Show("Please enter confirm Password.", txtCPassword, 5000);
                    txtCPassword.Text = "";
                }


                if (txtPassword.Text.Trim() != txtCPassword.Text.Trim())
                {
                    errUser.SetError(txtCPassword, "Password not match.");
                    txtCPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpconfirmpassword.ShowAlways = true;
                    tpconfirmpassword.Show("Password not match.", txtCPassword, 5000);
                    txtCPassword.Text = "";
                }

                //if (cmbUserRole.Text.Trim() == "" || cmbUserRole.SelectedValue.ToString() == "-1")
                //{
                //    errUser.SetError(cmbUserRole, "Please select User Role");
                //    cmbUserRole.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                //    tpUserRole.ShowAlways = true;
                //    tpUserRole.Show("Please select User Role", cmbUserRole, 5000);
                //    cmbUserRole.Text = "";

                //}


                if (txtUserName.Text.Trim() == "")
                {
                    txtUserName.Focus();
                    return;
                }

                if (txtLoginID.Text.Trim() == "")
                {
                    txtLoginID.Focus();
                    return;
                }


                if (txtPassword.Text.Trim() == "")
                {
                    txtPassword.Focus();
                    return;
                }


                if (txtCPassword.Text.Trim() == "")
                {
                    txtCPassword.Focus();
                    return;

                }

                //if (cmbUserRole.Text.Trim() == "" || cmbUserRole.SelectedValue.ToString() == "-1")
                //{
                //    cmbUserRole.Focus();
                //    return;

                //}

                if (txtPassword.Text.Trim() != txtCPassword.Text.Trim())
                {

                    txtCPassword.Focus();
                    return;
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


                string varstatus;
                if (rbActive.Checked == true)
                {
                    varstatus = "1";
                }
                else
                {
                    varstatus = "2";
                }


                SPDataService objspdservice = new SPDataService();

                string result = "";

                if (btnSave.Text == "Save")
                {
                   // result = objspdservice.udfnSPUserMaster("Create", "0",txtLoginID.Text,txtUserName.Text,cmbUserRole.SelectedValue.ToString(),varpassword,varstatus ,MainForm.pbUserID, MainForm.pbIpAddress, "User Create");

                }

                else
                {
                  //  result = objspdservice.udfnSPUserMaster("Update", varusercode, txtLoginID.Text, txtUserName.Text, cmbUserRole.SelectedValue.ToString(), varpassword, varstatus, MainForm.pbUserID, MainForm.pbIpAddress, "User Update");
                }


                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (btnSave.Text == "Update")
                    {
                        this.Close();
                    }
                    else
                    {
                        udfnClear();
                    }

                    MainForm.objCP_Userlist.udfnList();



                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                objspdservice.CloseConnection();


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

        private void CP_User_Leave(object sender, EventArgs e)
        {
            try
            {
                tpusername.Active = false;
                tpuserid.Active = false;
                tppassword.Active = false;
                tpconfirmpassword.Active = false;
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
                this.ActiveControl = txtUserName;
                udfnLoadUserRole();
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbUserRole_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (panelStatus.Enabled) { rbActive.Focus(); } else { btnSave.Focus(); }
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
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //MainForm.objCP_UserRole = new CP_UserRole();
                //MainForm.objCP_UserRole.pbFormStatus = "User";
                //MainForm.objCP_UserRole.ShowDialog();
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
                    panelStatus.Enabled = true;
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
                else { panelStatus.Enabled = false; }

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
