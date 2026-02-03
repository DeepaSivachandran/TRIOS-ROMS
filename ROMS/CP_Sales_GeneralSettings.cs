using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ROMS.Model;

namespace ROMS
{
    public partial class CP_Sales_GeneralSettings : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpConsiderProducts = new ToolTip();


        DataSet objDs = new DataSet();
        public int varSettingID = 0;
        public int varBillAmnt = 0;

        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public CP_Sales_GeneralSettings()
        {
            InitializeComponent();
            windowControl.Initialize(tsSalesGeneralSettings, this);
        }
     

        

        public void udfnClose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    windowControl?.TriggerClose();
                }
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        public void udfnList()
        {
            try
            {

                SPDataService objderv = new SPDataService();     /* create objects for spdataservices*/
                objDs = objderv.udfnSalesGeneralSettingList(0);   /*fetches data from db using prameter*/
                objderv.CloseConnection();

                if (objDs != null)   /*checkes the dataset*/
                {
                    if (objDs.Tables.Count != 0)   /*checkes if 1 table exists*/
                    {
                        if (objDs.Tables[0].Rows.Count != 0) /*checkes if 1 row exists*/
                        {
                            varSettingID = Convert.ToInt32(objDs.Tables[0].Rows[0]["ID"]);   /*Reads the id*/

                            txtConsiderProducts.Text = objDs.Tables[0].Rows[0]["NEW DAYS"].ToString();  /*Reads the data stored in the table*/

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

        


        public void udfnUpdate()
        {

            try
            {

                epSalesGeneralSettings.Clear();

                string varResult = "";       /*to passes result messgages as string from db*/

                SPDataService objDser = new SPDataService();  /*create object for spdataservice*/

                varResult = objDser.udfnSalesGeneralSettings(0, varSettingID, Convert.ToInt32(txtConsiderProducts.Text));   /*call action using parameter*/
                objDser.CloseConnection();             /*close the database connection after exection*/

                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (varResult.Split('~')[0] == "4")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnUpdate.Focus();
                }

                btnUpdate.Enabled = true;

                udfnList();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void CP_Sales_GeneralSettings_Load(object sender, EventArgs e)
        {
            try
            {

                MenuCode = 606;
                DataBind objDataBind = new DataBind();               

                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }

                string flag = "1";

                if (Convert.ToInt32(flag) == 0 || Convert.ToInt32(flag) <= 2)
                {
                    udfnList();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(MenuCode);
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions;
                btnUpdate.Visible = privilege.Contains("3");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        //clear
        public void udfnClear()
        {
            try
            {
                txtConsiderProducts.BackColor = Color.White;
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        //update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrFlag = false;

                if (txtConsiderProducts.Text == "" || Convert.ToInt32(txtConsiderProducts.Text) == 0)
                {
                    epSalesGeneralSettings.SetError(txtConsiderProducts, "Please enter valid Days.");
                    txtConsiderProducts.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConsiderProducts.ShowAlways = true;
                    tpConsiderProducts.Show("Please enter valid Days.", txtConsiderProducts, 5000);
                    blnErrFlag = true;
                }

                if (blnErrFlag == false)
                {
                    epSalesGeneralSettings.Clear();
                    udfnClear();
                    udfnUpdate();
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
                udfnClose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        //events
        private void txtConsiderProducts_Enter(object sender, EventArgs e)
        {
            try
            {
                txtConsiderProducts.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtConsiderProducts_KeyDown(object sender, KeyEventArgs e)
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

        private void txtConsiderProducts_Leave(object sender, EventArgs e)
        {
            try
            {
                txtConsiderProducts.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtConsiderProducts_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnUpdate_Enter(object sender, EventArgs e)
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

        private void btnUpdate_Leave(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.White;
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

        private void CP_Sales_GeneralSettings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnClose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnUpdate.Focus();
                    btnUpdate_Click(sender, e);
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



