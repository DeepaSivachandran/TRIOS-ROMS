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
    public partial class CP_UserCategory : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpCatogaroryName = new ToolTip();
    


        public string oldpassword,varpassword;
        public string varusercode="";
        public string varUserRoleCode = "";

        public CP_UserCategory()
        {
            InitializeComponent();
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

                if (Convert.ToString(txtCategoryName.Text).Trim() == "")
                {
                    epUserCategory.SetError(txtCategoryName, "Please enter catogory name");
                    txtCategoryName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCatogaroryName.ShowAlways = true;
                    tpCatogaroryName.Show("Please enter catogory name", txtCategoryName, 5000);
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




        private void CP_UserCategory_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CP_UserCategory_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_UserCategory_Load(object sender, EventArgs e)
        {
            try
            {
             
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

        private void TxtCategoryName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCategoryName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCategoryName_Leave(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToString(txtCategoryName.Text).Trim() == "")
                {
                    epUserCategory.SetError(txtCategoryName, "Please enter catogory name");
                    txtCategoryName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCatogaroryName.ShowAlways = true;
                    tpCatogaroryName.Show("Please enter catogory name", txtCategoryName, 5000);

                }
                else
                {
                    epUserCategory.Clear();
                    txtCategoryName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_Enter(object sender, EventArgs e)
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

        private void TxtCategoryName_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_UserCategory_Leave(object sender, EventArgs e)
        {

        }

        private void udfnEdit()
        {
            //try
            //{
            //    if (varusercode != "")
            //    {
            //        pnlStatus.Enabled = true;
            //        SPDataService objspservice = new SPDataService();
            //        DataSet objDS = new DataSet();
            //      //  objDS = objspservice.udfnSPUserList("EditLoad", varusercode, MainForm.pbUserID, MainForm.pbIpAddress);
            //        objspservice.CloseConnection();

            //        if (objDS != null)
            //        {
            //            if (objDS.Tables[0].Rows.Count > 0)
            //            {
            //                txtUserName.Text = objDS.Tables[0].Rows[0]["UserName"].ToString().Replace("''", "'");
            //                txtLoginID.Text = objDS.Tables[0].Rows[0]["Userid"].ToString();
            //                txtPassword.Text = objDS.Tables[0].Rows[0]["UserPassword"].ToString();
            //                oldpassword = objDS.Tables[0].Rows[0]["UserPassword"].ToString();
            //                txtCPassword.Text = objDS.Tables[0].Rows[0]["UserPassword"].ToString();
            //              //  cmbUserRole.SelectedValue= objDS.Tables[0].Rows[0]["UserRoleCode"].ToString();

            //                if (objDS.Tables[0].Rows[0]["Statuscode"].ToString() == "1")
            //                {
            //                    rbActive.Checked = true;
            //                }
            //                else
            //                {
            //                    rbInactive.Checked = true;
            //                }
                           
            //                btnSave.Text = "Update";
            //            }
            //        }

            //    }
            //    else { pnlStatus.Enabled = false; }

            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            //finally
            //{

            //}
        }
    }
}
