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
    public partial class CP_Product : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;


        public string varcompanycode;
        public string pbFormStatus;
        public string varstatecode = "";

        //tool tip
        private ToolTip tpContactNo = new ToolTip();
        private ToolTip tpAltContactNo = new ToolTip();
        private ToolTip tpemail = new ToolTip();
        private ToolTip tpgstin = new ToolTip();
        private ToolTip tpfssai = new ToolTip();
        private ToolTip tpplno = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpshortname = new ToolTip();
        private ToolTip tppincode = new ToolTip();
        private ToolTip tpcity = new ToolTip();
        private ToolTip tparea = new ToolTip();
        private ToolTip tpstate = new ToolTip();
        public CP_Product()
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
               // MainForm.objCP_CompanyList.udfnList();
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

        private void CP_Company_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    this.ActiveControl = txtName;
            //    udfnLoadState();
            //    udfnEdit();
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
                    txtItemNameEnglish.Focus();
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
                    txtItemNameTamil.Focus();
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
                    rbYes.Focus();
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
                    rbNo.Focus();
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
                    cmbHSNGroup.Focus();
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
                    txtCommodityCode.Focus();
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
                    cmbGroup.Focus();
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
                    cmbSubGroup.Focus();
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
                    cmbBrand.Focus();
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
                    cmbUnit.Focus();
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
                    cmbPosition.Focus();
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
                    cmbSalesCounter.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSalesCounter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSalesType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbTCSApplicable.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTCSApplicable_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbNatureOfGoods.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbNatureOfGoods_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRetailRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRetailRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWSaleRate.Focus();
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
                    txtWeight.Focus();
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
                if (e.KeyCode == Keys.Enter)
                {
                    cbStockable.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbStockable_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPurchaseRate.Focus();
                }
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
                    txtMRPRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMRPRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMaxStock.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMaxStock_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMinStock.Focus();
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOpeningStock.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOpeningStock_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWMinSaleQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWMinSaleQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRMinSaleQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRMinSaleQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBarcode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbExpiry.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDay.Focus();
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
                    txtMonth.Focus();
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
                    txtYear.Focus();
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
                    cbPriorityProduct.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbPriorityProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbBlockWRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbBlockWRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbSpecialProduct.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbSpecialProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbFocusProduct.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbFocusProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbEstimateOnly.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbEstimateOnly_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGST.Focus();
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
                    txtCGST.Focus();
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
                    txtSGST.Focus();
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
                    txtIGST.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIGST_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReOrderQty.Focus();
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
                    cbGStockable.Focus();
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
                    cbBatch.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbBatch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbActive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbInActive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInActive_KeyDown(object sender, KeyEventArgs e)
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

            //////////////////////////////////////////////////////
            



        }

        private void TxtPICode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPICode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                txtItemNameEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtItemNameTamil.BackColor = Color.LemonChiffon;
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
               txtCommodityCode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesType_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRetailRate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRetailRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWSaleRate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWSaleRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWeight_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWeight.BackColor = Color.LemonChiffon;
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
                txtPurchaseRate.BackColor = Color.LemonChiffon;
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
                txtMRPRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMaxStock_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMaxStock.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMinStock_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMinStock.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOpeningStock_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOpeningStock.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWMinSaleQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWMinSaleQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRMinSaleQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRMinSaleQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBarcode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBarcode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonth_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMonth.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtYear_Enter(object sender, EventArgs e)
        {
            try
            {
                txtYear.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGST_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGST.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCGST_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCGST.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSGST_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSGST.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIGST_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIGST.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtReOrderQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtReOrderQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }



        ////////////////////////////////////////////////////


        private void TxtPICode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPICode.Text == "")
                {
                    txtPICode.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtPICode, "Please Enter PI Code");
                }
                else
                {
                    txtPICode.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtItemNameEnglish.Text == "")
                {
                    txtItemNameEnglish.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtItemNameEnglish, "Please Enter Item Name In English");
                }
                else
                {
                    txtItemNameEnglish.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtItemNameTamil.Text == "")
                {
                    txtItemNameTamil.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtItemNameTamil, "Please Enter Item Name In Tamil");
                }
                else
                {
                    txtItemNameTamil.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCommodityCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCommodityCode.Text == "")
                {
                    txtCommodityCode.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtCommodityCode, "Please Enter Commodity Code");
                }
                else
                {
                    txtCommodityCode.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesType.Text == "")
                {
                    txtSalesType.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtSalesType, "Please Enter Sales Type");
                }
                else
                {
                    txtSalesType.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRetailRate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRetailRate.Text == "")
                {
                    txtRetailRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtRetailRate, "Please Enter Retail Rate");
                }
                else
                {
                    txtRetailRate.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWSaleRate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtWSaleRate.Text == "")
                {
                    txtWSaleRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtWSaleRate, "Please Enter W Sale Rate");
                }
                else
                {
                    txtWSaleRate.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtWeight.Text == "")
                {
                    txtWeight.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtWeight, "Please Enter Weight");
                }
                else
                {
                    txtWeight.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurchaseRate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPurchaseRate.Text == "")
                {
                    txtPurchaseRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtPurchaseRate, "Please Enter Purchase Rate");
                }
                else
                {
                    txtPurchaseRate.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMRPRate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMRPRate.Text == "")
                {
                    txtMRPRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtMRPRate, "Please Enter MRP Rate");
                }
                else
                {
                    txtMRPRate.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMaxStock_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMaxStock.Text == "")
                {
                    txtMaxStock.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtMaxStock, "Please Enter Max Stock");
                }
                else
                {
                    txtMaxStock.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMinStock_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMinStock.Text == "")
                {
                    txtMinStock.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtMinStock, "Please Enter Min Stock");
                }
                else
                {
                    txtMinStock.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOpeningStock_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtOpeningStock.Text == "")
                {
                    txtOpeningStock.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtOpeningStock, "Please Enter Openning Stock");
                }
                else
                {
                    txtOpeningStock.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWMinSaleQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtWMinSaleQty.Text == "")
                {
                    txtWMinSaleQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtWMinSaleQty, "Please Enter Min Sale Qty");
                }
                else
                {
                    txtWMinSaleQty.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRMinSaleQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRMinSaleQty.Text == "")
                {
                    txtRMinSaleQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtRMinSaleQty, "Please Enter R Min Sale Qty");
                }
                else
                {
                    txtRMinSaleQty.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBarcode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBarcode.Text == "")
                {
                    txtBarcode.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtBarcode, "Please Enter BarCode");
                }
                else
                {
                    txtBarcode.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDay.Text == "")
                {
                    txtDay.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtDay, "Please Enter Day");
                }
                else
                {
                    txtDay.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMonth.Text == "")
                {
                    txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtMonth, "Please Enter Month");
                }
                else
                {
                    txtMonth.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text == "")
                {
                    txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtYear, "Please Enter Year");
                }
                else
                {
                    txtYear.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGST_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtGST.Text == "")
                {
                    txtGST.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtGST, "Please Enter GST");
                }
                else
                {
                    txtGST.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCGST_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCGST.Text == "")
                {
                    txtCGST.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtCGST, "Please Enter CGST");
                }
                else
                {
                    txtCGST.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSGST_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSGST.Text == "")
                {
                    txtSGST.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtSGST, "Please Enter SGST");
                }
                else
                {
                    txtSGST.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIGST_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtIGST.Text == "")
                {
                    txtIGST.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtIGST, "Please Enter IGST");
                }
                else
                {
                    txtIGST.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtReOrderQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtReOrderQty.Text == "")
                {
                    txtReOrderQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtReOrderQty, "Please Enter ReOrder Qty");
                }
                else
                {
                    txtReOrderQty.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

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
                bool varResult = objvalidation.CheckNumeric(e);
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
                bool varResult = objvalidation.CheckNumeric(e);
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
                bool varResult = objvalidation.CheckNumeric(e);
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
                bool varResult = objvalidation.CheckNumeric(e);
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

        private void TxtCGST_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtSGST_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtIGST_KeyPress(object sender, KeyPressEventArgs e)
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


    