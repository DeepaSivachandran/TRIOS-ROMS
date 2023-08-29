using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_ProductDetails : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;


        public string varcompanycode;
        public string pbFormStatus;
        public string varstatecode = "";
        public int varRackId = 0;
        public string varDescription = "";
        public string varRackName = "";

        public void udfnList()
        {
            try
            {
                
                Application.DoEvents();
               
                grdProductDetails.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnProductDetailsList(0, varRackId);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            txtRackName.Text = varRackName;
                            txtDescription.Text = varDescription;
                            grdProductDetails.DataSource = objDs.Tables[0];
                            
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

        public CP_ProductDetails()
        {
            InitializeComponent();
        }

        private void txtCompanyName_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtName.BackColor = Color.LemonChiffon; 
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtcontactName.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtName.BackColor = Color.White;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtShortName_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtcontactName.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtShortName_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtArea.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtShortName_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtcontactName.BackColor = Color.White;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtArea_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtArea.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

      

       

        private void txtCity_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtCity.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        cmbState.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtCity.BackColor = Color.White;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtContactNumber_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtContactNumber.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtContactNumber_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtAContactNumber.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtContactNumber_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtContactNumber.BackColor = Color.White;
            //    try
            //    {
            //        if (txtContactNumber.Text.Trim() != "")
            //        {
            //            if (objvalidation.FormatNumeric(txtContactNumber.Text) == false || txtContactNumber.Text.Length < 10)
            //            {
            //                errCompany.SetError(txtContactNumber, "Please enter valid contact No.");
            //                txtContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //                tpContactNo.ShowAlways = true;
            //                tpContactNo.Show("Please enter valid contact No.", txtContactNumber, 5000);
            //                txtContactNumber.Focus();
            //            }

            //            else
            //            {
            //                errCompany.Clear();
            //                txtContactNumber.BackColor = Color.White;
            //                tpContactNo.Hide(txtContactNumber);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        objError = new DataError();
            //        objError.WriteFile(ex);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtAContactNumber_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtAContactNumber.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtAContactNumber_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAContactNumber_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtAContactNumber.BackColor = Color.White;
            //    if (txtAContactNumber.Text.Trim() != "")
            //    {
            //        if (objvalidation.FormatNumeric(txtAContactNumber.Text) == false || txtAContactNumber.Text.Length < 10)
            //        {
            //            errCompany.SetError(txtAContactNumber, "Please enter valid contact No.");
            //            txtAContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //            tpAltContactNo.ShowAlways = true;
            //            tpAltContactNo.Show("Please enter valid contact No.", txtAContactNumber, 5000);
            //            txtAContactNumber.Focus();
            //        }

            //        else
            //        {
            //            errCompany.Clear();
            //            txtAContactNumber.BackColor = Color.White;
            //            tpAltContactNo.Hide(txtAContactNumber);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtEmail.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtEmail.BackColor = Color.White;
            //    if (txtEmail.Text.Trim() != "" && objvalidation.FormatEMail(txtEmail.Text) == false)
            //    {
            //        errCompany.SetError(txtEmail, "Please enter valid EmailID");
            //        txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //        tpemail.ShowAlways = true;
            //        tpemail.Show("Please enter valid EmailID", txtEmail, 5000);

            //        //txtEmail.Text = "";
            //        txtEmail.Focus();
            //    }
            //    else
            //    {
            //        errCompany.Clear();
            //        txtEmail.BackColor = Color.White;
            //        tpemail.Hide(txtEmail);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
 
        private void btnSave_Click(object sender, EventArgs e)
        { 
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                //btnSave.BackColor = Color.LemonChiffon;
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

        private void udfnclear()
        {
            //try
            //{
            //    txtName.Text = "";
            //    txtcontactName.Text = "";
            //    txtArea.Text = "";
            //    txtCity.Text = "";
            //    txtContactNumber.Text = "";
            //    txtAContactNumber.Text = "";
            //    txtEmail.Text = "";  
            //    txtPincode.Text = "";
            //    btnSave.Text = "Save";
            //    txtName.Focus();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

   
     

        private void CP_Company_Load(object sender, EventArgs e)
        {
            try
            {
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            
            


        }


        private void udfnEdit()
        {
            //try
            //{

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

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
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

        private void txtAContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void CP_Company_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    tpContactNo.Active = false;
            //    tpAltContactNo.Active = false;
            //    tpemail.Active = false;
            //    tpgstin.Active = false;
            //    tpfssai.Active = false;
            //    tpplno.Active = false;
            //    tpcompanyname.Active = false;
            //    tpshortname.Active = false;


               
                  
            // }
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void CP_Company_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Escape)
            //    {
            //        udfnclose();
            //    }
            //    if (e.KeyCode == Keys.F5)
            //    {
            //        btnSave_Click(sender, e);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.FormatAlphabeticWithSpaceOnly(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtArea_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtArea.BackColor = Color.White;
            //    try
            //    {
            //        if (txtArea.Text.Trim() == "")
            //        {
                       
            //                errCompany.SetError(txtArea, "Please enter area");
            //                txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //                tparea.ShowAlways = true;
            //                tparea.Show("Please enter area.", txtArea, 5000);
            //                txtArea.Focus();
                       
            //        }
            //        else
            //        {
            //            errCompany.Clear();
            //            txtArea.BackColor = Color.White;
            //            tparea.Hide(txtArea);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        objError = new DataError();
            //        objError.WriteFile(ex);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
           
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtCity.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
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

        private void txtPincode_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtPincode.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtPincode_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtPincode.BackColor = Color.White;
            //    try
            //    {
            //        if (txtPincode.Text.Trim() != "")
            //        {
            //            if (objvalidation.FormatNumeric(txtPincode.Text) == false || txtPincode.Text.Length < 6)
            //            {
            //                errCompany.SetError(txtPincode, "Please enter valid pincode");
            //                txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //                tppincode.ShowAlways = true;
            //                tppincode.Show("Please enter valid pincode.", txtPincode, 5000);
            //                txtPincode.Focus();
            //            }

            //            else
            //            {
            //                errCompany.Clear();
            //                txtPincode.BackColor = Color.White;
            //                tppincode.Hide(txtPincode);
            //            }
            //        }
            //        else if(txtPincode.Text.Trim() == "")
            //        {
            //            errCompany.SetError(txtPincode, "Please enter pincode");
            //            txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //            tppincode.ShowAlways = true;
            //            tppincode.Show("Please enter pincode.", txtPincode, 5000);
            //            txtPincode.Focus();
            //        }
            //        else
            //        {
            //            errCompany.Clear();
            //            txtPincode.BackColor = Color.White;
            //            tppincode.Hide(txtPincode);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        objError = new DataError();
            //        objError.WriteFile(ex);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
           
        }

        private void txtPincode_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtContactNumber.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtArea_Enter_1(object sender, EventArgs e)
        {
            //try
            //{
            //    txtArea.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtState_Leave(object sender, EventArgs e)
        {

        }
        public void udfnLoadState()
        {
            //try
            //{
            //    DataBind objDataBind = new DataBind();
            //    objDataBind.BindComboBoxListSelected("DEF_STATE", "Status=1 and 1=1 Order by State", "State,StateCode", cmbState, "", "State", "StateCode");
            //    objDataBind = null;
            //    if (varstatecode != "") { cmbState.SelectedValue = varstatecode; }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtPincode_KeyDown_1(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtContactNumber.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void cmbState_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtPincode.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtFSSAI_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
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

        private void TxtDPincode_TextChanged(object sender, EventArgs e)
        {

        }
         

        private void TxtAlterPhno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
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

        private void TxtAlterMobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
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

        private void Txtwhatsapp_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
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

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Rbactive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RbInactive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Txtopening_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtcreditlimit_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void CbPriorityProduct_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CbSpecialProduct_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CbFocusProduct_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CbEstimateOnlly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void RbInActive_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void TxtPICode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtItemNameEnglish.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter )
                {
                    //txtItemNameTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbYes_KeyDown(object sender, KeyEventArgs e)
        {
            //rbYes.TabIndex = 3;
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbNo_KeyDown(object sender, KeyEventArgs e)
        {
            //rbNo.TabIndex = 4;
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    //cmbHSNName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPICode_TextChanged(object sender, EventArgs e)
        {
            //txtPICode.TabIndex = 1;
        }

        private void RbNo_CheckedChanged(object sender, EventArgs e)
        {
            //rbNo.TabIndex = 4;
        }

        private void RbYes_CheckedChanged(object sender, EventArgs e)
        {
            //rbYes.TabIndex = 3;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //rbNo.TabIndex = 4;
        }

        private void CmbHSNGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCommodityCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbUnit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbPosition.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPosition_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtWSaleRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtWeight.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWeight_KeyDown(object sender, KeyEventArgs e)
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

       

        private void TxtPurchaseRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   // txtMRPRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

       

        private void TxtMinStock_KeyDown(object sender, KeyEventArgs e)
        {
        }

        

        private void CbExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                 //   txtDay.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                  //  txtMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonth_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                 //   txtYear.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtYear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void TxtGST_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCGST_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSGST_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

       

        private void TxtReOrderQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbGStockable_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCommodityCode_Enter(object sender, EventArgs e)
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
         

     
        private void TxtPurchaseRate_Enter(object sender, EventArgs e)
        {
            try
            {
              //  txtPurchaseRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMRPRate_Enter(object sender, EventArgs e)
        {
            try
            {
              //  txtMRPRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }



        ////////////////////////////////////////////////////


   

        private void TxtPICode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
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

        private void TxtCommodityCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
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

        private void TxtRetailRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtWSaleRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtPurchaseRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtMRPRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtMaxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtMinStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtOpeningStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtWMinSaleQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtRMinSaleQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.FormatNumericOnly(e);
                if (varResult == true)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
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

        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.FormatNumericOnly(e);
                if (varResult == true)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
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

        private void TxtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.FormatNumericOnly(e);
                if (varResult == true)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
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

        private void TxtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.FormatNumericOnly(e);
                if (varResult == true)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
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

        private void TxtGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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

        private void TxtReOrderQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }
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


    