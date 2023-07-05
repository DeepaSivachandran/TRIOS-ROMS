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
    public partial class CP_Company : Form
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
        public CP_Company()
        {
            InitializeComponent();
        }

        private void txtCompanyName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCompanyName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtShortName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCompanyName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShortName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtShortName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShortName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtArea.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShortName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtShortName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_Enter(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

      

       

        private void txtCity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbState.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCity.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtContactNumber_Enter(object sender, EventArgs e)
        {
            try
            {
                txtContactNumber.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtContactNumber_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAContactNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtContactNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                txtContactNumber.BackColor = Color.White;
                try
                {
                    if (txtContactNumber.Text.Trim() != "")
                    {
                        if (objvalidation.FormatNumeric(txtContactNumber.Text) == false || txtContactNumber.Text.Length < 10)
                        {
                            errCompany.SetError(txtContactNumber, "Please enter valid contact No.");
                            txtContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpContactNo.ShowAlways = true;
                            tpContactNo.Show("Please enter valid contact No.", txtContactNumber, 5000);
                            txtContactNumber.Focus();
                        }

                        else
                        {
                            errCompany.Clear();
                            txtContactNumber.BackColor = Color.White;
                            tpContactNo.Hide(txtContactNumber);
                        }
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAContactNumber_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAContactNumber.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAContactNumber_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAContactNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAContactNumber.BackColor = Color.White;
                if (txtAContactNumber.Text.Trim() != "")
                {
                    if (objvalidation.FormatNumeric(txtAContactNumber.Text) == false || txtAContactNumber.Text.Length < 10)
                    {
                        errCompany.SetError(txtAContactNumber, "Please enter valid contact No.");
                        txtAContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpAltContactNo.ShowAlways = true;
                        tpAltContactNo.Show("Please enter valid contact No.", txtAContactNumber, 5000);
                        txtAContactNumber.Focus();
                    }

                    else
                    {
                        errCompany.Clear();
                        txtAContactNumber.BackColor = Color.White;
                        tpAltContactNo.Hide(txtAContactNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEmail.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
            try
            {
                txtEmail.BackColor = Color.White;
                if (txtEmail.Text.Trim() != "" && objvalidation.FormatEMail(txtEmail.Text) == false)
                {
                    errCompany.SetError(txtEmail, "Please enter valid EmailID");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpemail.ShowAlways = true;
                    tpemail.Show("Please enter valid EmailID", txtEmail, 5000);

                    //txtEmail.Text = "";
                    txtEmail.Focus();
                }
                else
                {
                    errCompany.Clear();
                    txtEmail.BackColor = Color.White;
                    tpemail.Hide(txtEmail);
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
            try
            {
                txtCompanyName.Text = "";
                txtShortName.Text = "";
                txtArea.Text = "";
                txtCity.Text = "";
                txtContactNumber.Text = "";
                txtAContactNumber.Text = "";
                txtEmail.Text = ""; 
                txtFSSAI.Text = ""; 
                txtPincode.Text = "";
                btnSave.Text = "Save";
                txtCompanyName.Focus();
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
            try
            {
                this.ActiveControl = txtCompanyName;
                udfnLoadState();
                udfnEdit();
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


        private void udfnEdit()
        {
            try
            {

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

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAContactNumber_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void CP_Company_Leave(object sender, EventArgs e)
        {
            try
            {
                tpContactNo.Active = false;
                tpAltContactNo.Active = false;
                tpemail.Active = false;
                tpgstin.Active = false;
                tpfssai.Active = false;
                tpplno.Active = false;
                tpcompanyname.Active = false;
                tpshortname.Active = false;


               
                  
             }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Company_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.FormatAlphabeticWithSpaceOnly(e);
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
        }

        private void txtArea_Leave(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.White;
                try
                {
                    if (txtArea.Text.Trim() == "")
                    {
                       
                            errCompany.SetError(txtArea, "Please enter area");
                            txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tparea.ShowAlways = true;
                            tparea.Show("Please enter area.", txtArea, 5000);
                            txtArea.Focus();
                       
                    }
                    else
                    {
                        errCompany.Clear();
                        txtArea.BackColor = Color.White;
                        tparea.Hide(txtArea);
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
           
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPincode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPincode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPincode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPincode.BackColor = Color.White;
                try
                {
                    if (txtPincode.Text.Trim() != "")
                    {
                        if (objvalidation.FormatNumeric(txtPincode.Text) == false || txtPincode.Text.Length < 6)
                        {
                            errCompany.SetError(txtPincode, "Please enter valid pincode");
                            txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tppincode.ShowAlways = true;
                            tppincode.Show("Please enter valid pincode.", txtPincode, 5000);
                            txtPincode.Focus();
                        }

                        else
                        {
                            errCompany.Clear();
                            txtPincode.BackColor = Color.White;
                            tppincode.Hide(txtPincode);
                        }
                    }
                    else if(txtPincode.Text.Trim() == "")
                    {
                        errCompany.SetError(txtPincode, "Please enter pincode");
                        txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppincode.ShowAlways = true;
                        tppincode.Show("Please enter pincode.", txtPincode, 5000);
                        txtPincode.Focus();
                    }
                    else
                    {
                        errCompany.Clear();
                        txtPincode.BackColor = Color.White;
                        tppincode.Hide(txtPincode);
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
           
        }

        private void txtPincode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtContactNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_Enter_1(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtState_Leave(object sender, EventArgs e)
        {

        }
        public void udfnLoadState()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_STATE", "Status=1 and 1=1 Order by State", "State,StateCode", cmbState, "", "State", "StateCode");
                objDataBind = null;
                if (varstatecode != "") { cmbState.SelectedValue = varstatecode; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPincode_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtContactNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbState_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPincode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtFSSAI_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtDPincode_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPan_Leave(object sender, EventArgs e)
        {

            string panNumber = txtPan.Text.Trim();
            string pattern = @"^[A-Z]{5}\d{4}[A-Z]$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            bool isValid = regex.IsMatch(panNumber);
            if (isValid==false)
            {
                errCompany.SetError(txtPan, "Please enter valid pan number.");
                txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tppincode.ShowAlways = true;
                tppincode.Show("Please enter valid pan number.", txtPan, 5000);
                txtPan.Focus();
            }
            else
            {
                errCompany.Clear();
                txtPan.BackColor = Color.White;
                tppincode.Hide(txtArea);
            }
        }

        private void TxtAlterPhno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAlterMobileno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txtwhatsapp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtGSTTIN_Leave(object sender, EventArgs e)
        {
            string gstin = txtGSTTIN.Text.Trim();
            string pattern = @"^\d{2}[A-Z]{5}\d{4}[A-Z]{1}[A-Z\d]{1}[Z]{1}[A-Z\d]{1}$"; 
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);  
            bool isValid = regex.IsMatch(gstin);
            if (isValid == false)
            {
                errCompany.SetError(txtGSTTIN, "Please enter valid GSTIN number.");
                txtGSTTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tppincode.ShowAlways = true;
                tppincode.Show("Please enter valid GSTIN number.", txtGSTTIN, 5000);
                txtGSTTIN.Focus();
            }
            else
            {
                errCompany.Clear();
                txtGSTTIN.BackColor = Color.White;
                tppincode.Hide(txtArea);
            }
        }

        private void TxtFSSAI_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtFSSAI.Text.Trim() == ""||(objvalidation.FormatAlphbeticAndNumeric(txtFSSAI.Text) == false || txtFSSAI.Text.Length != 14))
            {
                errCompany.SetError(txtFSSAI, "Please enter valid FSSAI"); txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpfssai.ShowAlways = true; tpfssai.Show("Please enter valid FSSAI", txtFSSAI, 5000);
                txtFSSAI.Focus();
            }
            else
            {
                errCompany.Clear();
                txtFSSAI.BackColor = Color.White;
                tpfssai.Hide(txtArea);
            }
        }

    }
}


    