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
                if (txtCompanyName.Text== "")
                {

                    errCompany.SetError(txtCompanyName, "Please enter company name.");
                    txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please enter company name.", txtCompanyName, 5000);
                }

                else
                {
                    errCompany.Clear();
                    txtCompanyName.BackColor = Color.White;
                    tpcompanyname.Hide(txtCompanyName);
                }
                
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
            if (txtShortName.Text== "")
            {

                errCompany.SetError(txtShortName, "Please enter short name.");
                txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpcompanyname.ShowAlways = true;
                tpcompanyname.Show("Please enter short name.", txtShortName, 5000);
            }

            else
            {
                errCompany.Clear();
                txtShortName.BackColor = Color.White;
                tpcompanyname.Hide(txtShortName);
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
                    txtPincode.Focus();
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
            if (txtCity.Text== "")
            {

                errCompany.SetError(txtCity, "Please enter city name.");
                txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpcity.ShowAlways = true;
                tpcity.Show("Please enter city name.", txtCity, 5000);
            }

            else
            {
                errCompany.Clear();
                txtCity.BackColor = Color.White;
                tpcity.Hide(txtCity);
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
                    txtAlterPhno.Focus();
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
                    if (txtContactNumber.Text == "")
                    {
                        if (objvalidation.FormatNumeric(txtContactNumber.Text) == false || txtContactNumber.Text.Length < 10)
                        {
                            errCompany.SetError(txtContactNumber, "Please enter valid phone No.");
                            txtContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpContactNo.ShowAlways = true;
                            tpContactNo.Show("Please enter valid phone No.", txtContactNumber, 5000); 
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
                txtmobileNumber.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void txtAContactNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                txtmobileNumber.BackColor = Color.White;
                if (txtmobileNumber.Text == "")
                {
                    if (objvalidation.FormatNumeric(txtmobileNumber.Text) == false || txtmobileNumber.Text.Length < 10)
                    {
                        errCompany.SetError(txtmobileNumber, "Please enter valid mobile No.");
                        txtmobileNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpAltContactNo.ShowAlways = true;
                        tpAltContactNo.Show("Please enter valid mobile No.", txtmobileNumber, 5000); 
                    }

                    else
                    {
                        errCompany.Clear();
                        txtmobileNumber.BackColor = Color.White;
                        tpAltContactNo.Hide(txtmobileNumber);
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
                    txtwebsite.Focus();
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
                if (txtEmail.Text == "" && objvalidation.FormatEMail(txtEmail.Text) == false)
                {
                    errCompany.SetError(txtEmail, "Please enter valid EmailID");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpemail.ShowAlways = true;
                    tpemail.Show("Please enter valid EmailID", txtEmail, 5000);

                    //txtEmail.Text = ""; 
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
                txtmobileNumber.Text = "";
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
                       
                            errCompany.SetError(txtArea, "Please enter address");
                            txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tparea.ShowAlways = true;
                            tparea.Show("Please enter address.", txtArea, 5000); 
                       
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
                    txtaddress2.Focus();
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
                    if (txtPincode.Text == "")
                    {
                        if (objvalidation.FormatNumeric(txtPincode.Text) == false || txtPincode.Text.Length < 6)
                        {
                            errCompany.SetError(txtPincode, "Please enter valid pincode");
                            txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tppincode.ShowAlways = true;
                            tppincode.Show("Please enter valid pincode.", txtPincode, 5000); 
                        }

                        else
                        {
                            errCompany.Clear();
                            txtPincode.BackColor = Color.White;
                            tppincode.Hide(txtPincode);
                        }
                    }
                    else if(txtPincode.Text == "")
                    {
                        errCompany.SetError(txtPincode, "Please enter pincode");
                        txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppincode.ShowAlways = true;
                        tppincode.Show("Please enter pincode.", txtPincode, 5000); 
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
                    txtCity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
            if (isValid == false)
            {
                errCompany.SetError(txtPan, "Please enter valid pan  No.");
                txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tppincode.ShowAlways = true;
                tppincode.Show("Please enter valid pan No.", txtPan, 5000);
            }
            else if (txtPan.Text == "") {

                errCompany.SetError(txtPan, "Please enter  pan No.");
                txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tppincode.ShowAlways = true;
                tppincode.Show("Please enter  pan No.", txtPan, 5000);
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBankname.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            
        }

        private void Txtaddress2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtaddress2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtaddress2_KeyDown(object sender, KeyEventArgs e)
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

        private void Txtaddress2_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (txtaddress2.Text.Trim() == "")
                    {

                        errCompany.SetError(txtaddress2, "Please enter address");
                        txtaddress2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tparea.ShowAlways = true;
                        tparea.Show("Please enter address.", txtaddress2, 5000);

                    }
                    else
                    {
                        errCompany.Clear();
                        txtaddress2.BackColor = Color.White;
                        tparea.Hide(txtaddress2);
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                }
            }
                catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterPhno_Enter(object sender, EventArgs e)
        {

            try
            {
                txtAlterPhno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterPhno_Leave(object sender, EventArgs e)
        {

            if (txtAlterPhno.Text.Trim() == "")
            {

                errCompany.SetError(txtAlterPhno, "Please enter alternative phone number");
                txtAlterPhno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter alternative phone number.", txtAlterPhno, 5000);

            }
            else
            {
                errCompany.Clear();
                txtAlterPhno.BackColor = Color.White;
                tparea.Hide(txtAlterPhno);
            }
        }

        private void TxtmobileNumber_KeyDown(object sender, KeyEventArgs e)
        {
            
                 try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAlterMobileno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterMobileno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtwhatsapp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterMobileno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAlterMobileno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterMobileno_Leave(object sender, EventArgs e)
        {
            if (txtAlterMobileno.Text.Trim() == "")
            {

                errCompany.SetError(txtAlterMobileno, "Please enter alternative mobile number");
                txtAlterMobileno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter  alternative mobile number.", txtAlterMobileno, 5000);

            }
            else
            {
                errCompany.Clear();
                txtAlterMobileno.BackColor = Color.White;
                tparea.Hide(txtAlterMobileno);
            }
        }

        private void Txtwhatsapp_Enter(object sender, EventArgs e)
        {
            try
            {
                txtwhatsapp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtwhatsapp_KeyDown(object sender, KeyEventArgs e)
        {
           
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEmail.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtwhatsapp_Leave(object sender, EventArgs e)
        {
            if (txtwhatsapp.Text.Trim() == "")
            {

                errCompany.SetError(txtwhatsapp, "Please enter whatapp number");
                txtwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter whatapp number.", txtwhatsapp, 5000);

            }
            else
            {
                errCompany.Clear();
                txtwhatsapp.BackColor = Color.White;
                tparea.Hide(txtwhatsapp);
            }
        }

        private void Txtwebsite_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGSTTIN.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtwebsite_Leave(object sender, EventArgs e)
        {
            if (txtwebsite.Text.Trim() == "")
            {

                errCompany.SetError(txtwebsite, "Please enter website");
                txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter website.", txtwebsite, 5000);

            }
            else
            {
                errCompany.Clear();
                txtwebsite.BackColor = Color.White;
                tparea.Hide(txtwebsite);
            }
        }

        private void Txtwebsite_Enter(object sender, EventArgs e)
        {
            try
            {
                txtwebsite.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGSTTIN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtCst.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGSTTIN_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGSTTIN.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCst_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPan.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

   

        private void TxtPan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtESI.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPan_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPan.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtESI_Leave(object sender, EventArgs e)
        {
            if (txtESI.Text.Trim() == "")
            {

                errCompany.SetError(txtESI, "Please enter ESI");
                txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter ESI.", txtESI, 5000);

            }
            else
            {
                errCompany.Clear();
                txtESI.BackColor = Color.White;
                tparea.Hide(txtESI);
            }
        }

        private void TxtESI_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEPF.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtESI_Enter(object sender, EventArgs e)
        {
            try
            {
                txtESI.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEPF_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtFSSAI.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEPF_Leave(object sender, EventArgs e)
        {
            if (txtEPF.Text.Trim() == "")
            {

                errCompany.SetError(txtEPF, "Please enter EPF");
                txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter EPF.", txtEPF, 5000);

            }
            else
            {
                errCompany.Clear();
                txtEPF.BackColor = Color.White;
                tparea.Hide(txtEPF);
            }
        }

        private void TxtEPF_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEPF.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtFSSAI_Enter(object sender, EventArgs e)
        {
            try
            {
                txtFSSAI.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtFSSAI_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtFSSAI.Text.Trim() == "" || (objvalidation.FormatAlphbeticAndNumeric(txtFSSAI.Text) == false || txtFSSAI.Text.Length != 14))
                {
                    errCompany.SetError(txtFSSAI, "Please enter valid FSSAI"); txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpfssai.ShowAlways = true; tpfssai.Show("Please enter valid FSSAI", txtFSSAI, 5000); 
                }
                else
                {
                    errCompany.Clear();
                    txtFSSAI.BackColor = Color.White;
                    tpfssai.Hide(txtFSSAI);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBankname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtbranchname.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBankname_Leave(object sender, EventArgs e)
        {
            if (txtBankname.Text.Trim() == "")
            {

                errCompany.SetError(txtBankname, "Please enter bank name");
                txtBankname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter bank name.", txtBankname, 5000);

            }
            else
            {
                errCompany.Clear();
                txtBankname.BackColor = Color.White;
                tparea.Hide(txtBankname);
            }
        }

        private void TxtBankname_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBankname.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtbranchname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAccno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtbranchname_Enter(object sender, EventArgs e)
        {
            try
            {
                txtbranchname.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtbranchname_Leave(object sender, EventArgs e)
        {
            if (txtbranchname.Text.Trim() == "")
            {

                errCompany.SetError(txtbranchname, "Please enter branch name");
                txtbranchname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter branch name.", txtbranchname, 5000);

            }
            else
            {
                errCompany.Clear();
                txtbranchname.BackColor = Color.White;
                tparea.Hide(txtbranchname);
            }
        }

        private void TxtAccno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtIFScode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAccno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAccno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAccno_Leave(object sender, EventArgs e)
        {
            if (txtAccno.Text.Trim() == "")
            {

                errCompany.SetError(txtAccno, "Please enter account number");
                txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter account number.", txtAccno, 5000);

            }
            else
            {
                errCompany.Clear();
                txtAccno.BackColor = Color.White;
                tparea.Hide(txtAccno);
            }
        }

        private void TxtIFScode_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtIFScode_Leave(object sender, EventArgs e)
        {
            if (txtIFScode.Text.Trim() == "")
            {

                errCompany.SetError(txtIFScode, "Please enter IFScode");
                txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter IFScode.", txtIFScode, 5000);

            }
            else
            {
                errCompany.Clear();
                txtIFScode.BackColor = Color.White;
                tparea.Hide(txtIFScode);
            }
        }

        private void TxtIFScode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIFScode.BackColor = Color.LemonChiffon ;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterPhno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtmobileNumber.Focus();
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


    