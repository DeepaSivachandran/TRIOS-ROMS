using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_Company : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpCompanyName = new ToolTip();
        private ToolTip tpShortName = new ToolTip();
        private ToolTip tpAddressLine1 = new ToolTip();
        private ToolTip tpAddressLine2 = new ToolTip();
        private ToolTip tpState = new ToolTip();
        private ToolTip tpCity = new ToolTip();
        private ToolTip tpPincode = new ToolTip();
        private ToolTip tpPhoneNo = new ToolTip();
        private ToolTip tpMobileNo = new ToolTip();
        private ToolTip tpWhatsAppNo = new ToolTip();
        private ToolTip tpEmail = new ToolTip();
        private ToolTip tpWebsite = new ToolTip();
        private ToolTip tpGstin = new ToolTip();
        private ToolTip tpPan = new ToolTip();
        private ToolTip tpEsi = new ToolTip();
        private ToolTip tpEsf = new ToolTip();
        private ToolTip tpFssai = new ToolTip();
        private ToolTip tpPlNo = new ToolTip();
        private ToolTip tpName = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        private ToolTip tpMobileNumber = new ToolTip();
        private ToolTip tpOperator = new ToolTip();
        private ToolTip tpMobileBrand = new ToolTip();

        private ToolTip tpBankName = new ToolTip();
        private ToolTip tpBankShortName = new ToolTip();
        private ToolTip tpBranchName = new ToolTip();
        private ToolTip tpAccountNo = new ToolTip();
        private ToolTip tpIfsCode = new ToolTip();

        public CP_Company()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Company = new CP_Company();
                MainForm.objCP_Company.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
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
        private void CP_Company_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                
             
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void TxtBankname_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtBankname.Text).Trim() == "")
                {
                    epCompany.SetError(txtBankname, "Please enter bank name");
                    txtBankname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankName.ShowAlways = true;
                    tpBankName.Show("Please enter bank name", txtBankname, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtBankname.BackColor = Color.White;
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
                    txtBankShortName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBankShortName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBankShortName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBankShortName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtBankShortName.Text).Trim() == "")
                {
                    epCompany.SetError(txtBankShortName, "Please enter bank short name");
                    txtBankShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank short name", txtBankShortName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtBankShortName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBankShortName_KeyDown(object sender, KeyEventArgs e)
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
            try
            {
                if (Convert.ToString(txtbranchname.Text).Trim() == "")
                {
                    epCompany.SetError(txtbranchname, "Please enter branch name");
                    txtbranchname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBranchName.ShowAlways = true;
                    tpBranchName.Show("Please enter branch name", txtbranchname, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtbranchname.BackColor = Color.White;
                }
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
            try
            {
                if (Convert.ToString(txtAccno.Text).Trim() == "")
                {
                    epCompany.SetError(txtAccno, "Please enter account number");
                    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAccountNo.ShowAlways = true;
                    tpAccountNo.Show("Please enter account number", txtAccno, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtAccno.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void TxtIFScode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIFScode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIFScode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
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
            try
            {
                if (Convert.ToString(txtIFScode.Text).Trim() == "")
                {
                    epCompany.SetError(txtIFScode, "Please enter IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter IFS Code", txtIFScode, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtIFScode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtBankname.Text).Trim() == "")
                {
                    epCompany.SetError(txtBankname, "Please enter bank name");
                    txtBankname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankName.ShowAlways = true;
                    tpBankName.Show("Please enter bank name", txtBankname, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtBankShortName.Text).Trim() == "")
                {
                    epCompany.SetError(txtBankShortName, "Please enter bank short name");
                    txtBankShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank short name", txtBankShortName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtbranchname.Text).Trim() == "")
                {
                    epCompany.SetError(txtbranchname, "Please enter branch name");
                    txtbranchname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBranchName.ShowAlways = true;
                    tpBranchName.Show("Please enter branch name", txtbranchname, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtAccno.Text).Trim() == "")
                {
                    epCompany.SetError(txtAccno, "Please enter account number");
                    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAccountNo.ShowAlways = true;
                    tpAccountNo.Show("Please enter account number", txtAccno, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(txtIFScode.Text).Trim() == "")
                {
                    epCompany.SetError(txtIFScode, "Please enter IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter IFS Code", txtIFScode, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    grdBankDetails.Rows.Add(grdBankDetails.Rows.Count + 1, txtBankname.Text, txtBankShortName.Text, txtbranchname.Text, txtAccno.Text, txtIFScode.Text, "Active");
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtCompanyName_Enter(object sender, EventArgs e)
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

        private void TxtCompanyName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtCompanyName.Text).Trim() == "")
                {
                    epCompany.SetError(txtCompanyName, "Please enter company name");
                    txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCompanyName.ShowAlways = true;
                    tpCompanyName.Show("Please enter company name", txtCompanyName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtCompanyName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtCompanyName_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtShortName_Enter(object sender, EventArgs e)
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

        private void TxtShortName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epCompany.SetError(txtShortName, "Please enter short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpShortName.ShowAlways = true;
                    tpShortName.Show("Please enter short name", txtShortName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtShortName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtShortName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddressLine1.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAddressLine1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAddressLine1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAddressLine1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtAddressLine1.Text).Trim() == "")
                {
                    epCompany.SetError(txtAddressLine1, "Please enter address");
                    txtAddressLine1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAddressLine1.ShowAlways = true;
                    tpAddressLine1.Show("Please enter address", txtAddressLine1, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtAddressLine1.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAddressLine1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddressLine2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAddressLine2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAddressLine2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAddressLine2_Leave(object sender, EventArgs e)
        {
            try
            {
                  txtAddressLine2.BackColor = Color.White;
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAddressLine2_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbState_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbState.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                {
                    epCompany.SetError(cmbState, "Please select state");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please select state", cmbState, 5000);
                }
                else
                {
                    epCompany.Clear();
                    cmbState.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbState_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbState.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCity_Enter(object sender, EventArgs e)
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

        private void TxtCity_Leave(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToString(txtCity.Text).Trim() == "")
                {
                    epCompany.SetError(txtCity, "Please enter city");
                    txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCity.ShowAlways = true;
                    tpCity.Show("Please enter city", txtCity, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtCity.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCity_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtPhoneNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPhoneNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPhoneNo_Leave(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToString(txtPhoneNo.Text).Trim() == "")
                {
                    epCompany.SetError(txtPhoneNo, "Please enter phone number");
                    txtPhoneNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPhoneNo.ShowAlways = true;
                    tpPhoneNo.Show("Please enter phone number", txtPhoneNo, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtPhoneNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAlterPhoneno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterPhoneno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAlterPhoneno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterPhoneno_Leave(object sender, EventArgs e)
        {
            try
            { 
                txtAlterPhoneno.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterPhoneno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtmobileNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtmobileNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtmobileNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtmobileNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtmobileNo.Text).Trim() == "")
                {
                    epCompany.SetError(txtmobileNo, "Please enter mobile number");
                    txtmobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNo.ShowAlways = true;
                    tpMobileNo.Show("Please enter mobile number", txtmobileNo, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtmobileNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtmobileNo_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtPincode_Enter(object sender, EventArgs e)
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

        private void TxtPincode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtPincode.Text).Trim() == "")
                {
                    epCompany.SetError(txtPincode, "Please enter pincode");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPincode.ShowAlways = true;
                    tpPincode.Show("Please enter pincode", txtPincode, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtPincode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPincode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPhoneNo.Focus();
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
            try
            {
                txtAlterMobileno.BackColor = Color.White;
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
                    txtwhatsappNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtwhatsappNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtwhatsappNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtwhatsappNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtwhatsappNo.Text).Trim() == "")
                {
                    epCompany.SetError(txtwhatsappNo, "Please enter whatsapp number");
                    txtwhatsappNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWhatsAppNo.ShowAlways = true;
                    tpWhatsAppNo.Show("Please enter whatsapp number", txtwhatsappNo, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtwhatsappNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtwhatsappNo_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtEmail_Enter(object sender, EventArgs e)
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

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtEmail.Text).Trim() == "")
                {
                    epCompany.SetError(txtEmail, "Please enter email");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEmail.ShowAlways = true;
                    tpEmail.Show("Please enter email", txtEmail, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtEmail.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
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

        private void Txtwebsite_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtwebsite.Text).Trim() == "")
                {
                    epCompany.SetError(txtwebsite, "Please enter website");
                    txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWebsite.ShowAlways = true;
                    tpWebsite.Show("Please enter website", txtwebsite, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtwebsite.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void TxtGSTTIN_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtGSTTIN.Text).Trim() == "")
                {
                    epCompany.SetError(txtGSTTIN, "Please enter GSTTIN");
                    txtGSTTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGstin.ShowAlways = true;
                    tpGstin.Show("Please enter GSTTIN", txtGSTTIN, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtGSTTIN.BackColor = Color.White;
                }
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
                    txtPan.Focus();
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

        private void TxtPan_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtPan.Text).Trim() == "")
                {
                    epCompany.SetError(txtPan, "Please enter PAN");
                    txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPan.ShowAlways = true;
                    tpPan.Show("Please enter PAN", txtPan, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtPan.BackColor = Color.White;
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

        private void TxtESI_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtESI.Text).Trim() == "")
                {
                    epCompany.SetError(txtESI, "Please enter ESI");
                    txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsi.ShowAlways = true;
                    tpEsi.Show("Please enter ESI", txtESI, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtESI.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void TxtEPF_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtEPF.Text).Trim() == "")
                {
                    epCompany.SetError(txtEPF, "Please enter ESF");
                    txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsf.ShowAlways = true;
                    tpEsf.Show("Please enter ESF", txtEPF, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtEPF.BackColor = Color.White;
                }
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
                if (Convert.ToString(txtFSSAI.Text).Trim() == "")
                {
                    epCompany.SetError(txtFSSAI, "Please enter FSSAI");
                    txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpFssai.ShowAlways = true;
                    tpFssai.Show("Please enter FSSAI", txtFSSAI, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtFSSAI.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtFSSAI_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPlno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPlno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPlno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPlno_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtPlno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtPlno.Text).Trim() == "")
                {
                    epCompany.SetError(txtPlno, "Please enter PL number");
                    txtPlno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPlNo.ShowAlways = true;
                    tpPlNo.Show("Please enter PL number", txtPlno, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtPlno.BackColor = Color.White;
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

        }

        private void CP_Company_FormClosing(object sender, FormClosingEventArgs e)
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

        private void BtnClose_Click(object sender, EventArgs e)
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

        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
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

        private void RbActive_Leave(object sender, EventArgs e)
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

        private void RbInActive_Enter(object sender, EventArgs e)
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

        private void RbInActive_Leave(object sender, EventArgs e)
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

        private void BtnSave_Enter(object sender, EventArgs e)
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

        private void BtnSave_Leave(object sender, EventArgs e)
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

        private void BtnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClose_Enter(object sender, EventArgs e)
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

        private void BtnClose_Leave(object sender, EventArgs e)
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

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
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
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_KeyDown(object sender, KeyEventArgs e)
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtCompanyName.Text).Trim() == "")
                {
                    epCompany.SetError(txtCompanyName, "Please enter company name");
                    txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCompanyName.ShowAlways = true;
                    tpCompanyName.Show("Please enter company name", txtCompanyName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epCompany.SetError(txtShortName, "Please enter short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpShortName.ShowAlways = true;
                    tpShortName.Show("Please enter short name", txtShortName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtAddressLine1.Text).Trim() == "")
                {
                    epCompany.SetError(txtAddressLine1, "Please enter address");
                    txtAddressLine1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAddressLine1.ShowAlways = true;
                    tpAddressLine1.Show("Please enter address", txtAddressLine1, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                {
                    epCompany.SetError(cmbState, "Please select state");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please select state", cmbState, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtCity.Text).Trim() == "")
                {
                    epCompany.SetError(txtCity, "Please enter city");
                    txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCity.ShowAlways = true;
                    tpCity.Show("Please enter city", txtCity, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtPincode.Text).Trim() == "")
                {
                    epCompany.SetError(txtPincode, "Please enter pincode");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPincode.ShowAlways = true;
                    tpPincode.Show("Please enter pincode", txtPincode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtPhoneNo.Text).Trim() == "")
                {
                    epCompany.SetError(txtPhoneNo, "Please enter phone number");
                    txtPhoneNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPhoneNo.ShowAlways = true;
                    tpPhoneNo.Show("Please enter phone number", txtPhoneNo, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtmobileNo.Text).Trim() == "")
                {
                    epCompany.SetError(txtmobileNo, "Please enter mobile number");
                    txtmobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNo.ShowAlways = true;
                    tpMobileNo.Show("Please enter mobile number", txtmobileNo, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtwhatsappNo.Text).Trim() == "")
                {
                    epCompany.SetError(txtwhatsappNo, "Please enter whatsapp number");
                    txtwhatsappNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWhatsAppNo.ShowAlways = true;
                    tpWhatsAppNo.Show("Please enter whatsapp number", txtwhatsappNo, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtEmail.Text).Trim() == "")
                {
                    epCompany.SetError(txtEmail, "Please enter email");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEmail.ShowAlways = true;
                    tpEmail.Show("Please enter email", txtEmail, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtwebsite.Text).Trim() == "")
                {
                    epCompany.SetError(txtwebsite, "Please enter website");
                    txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWebsite.ShowAlways = true;
                    tpWebsite.Show("Please enter website", txtwebsite, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtGSTTIN.Text).Trim() == "")
                {
                    epCompany.SetError(txtGSTTIN, "Please enter GSTTIN");
                    txtGSTTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGstin.ShowAlways = true;
                    tpGstin.Show("Please enter GSTTIN", txtGSTTIN, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtPan.Text).Trim() == "")
                {
                    epCompany.SetError(txtPan, "Please enter PAN");
                    txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPan.ShowAlways = true;
                    tpPan.Show("Please enter PAN", txtPan, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtESI.Text).Trim() == "")
                {
                    epCompany.SetError(txtESI, "Please enter ESI");
                    txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsi.ShowAlways = true;
                    tpEsi.Show("Please enter ESI", txtESI, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtEPF.Text).Trim() == "")
                {
                    epCompany.SetError(txtEPF, "Please enter ESF");
                    txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsf.ShowAlways = true;
                    tpEsf.Show("Please enter ESF", txtEPF, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtFSSAI.Text).Trim() == "")
                {
                    epCompany.SetError(txtFSSAI, "Please enter FSSAI");
                    txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpFssai.ShowAlways = true;
                    tpFssai.Show("Please enter FSSAI", txtFSSAI, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtPlno.Text).Trim() == "")
                {
                    epCompany.SetError(txtPlno, "Please enter PL number");
                    txtPlno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPlNo.ShowAlways = true;
                    tpPlNo.Show("Please enter PL number", txtPlno, 5000);
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

        private void TxtName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtName.Text).Trim() == "")
                {
                    epCompany.SetError(txtName, "Please enter name");
                    txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpName.ShowAlways = true;
                    tpName.Show("Please enter name", txtName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbTransactionType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTransactionType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobilenumber_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMobilenumber.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtOperator_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOperator.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobileBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMobileBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epCompany.SetError(cmbTransactionType, "Please select transaction type");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
                }
                else
                {
                    epCompany.Clear();
                    cmbTransactionType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMobilenumber.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbTransactionType.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobilenumber_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtMobilenumber.Text).Trim() == "")
                {
                    epCompany.SetError(txtMobilenumber, "Please enter broker name");
                    txtMobilenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNumber.ShowAlways = true;
                    tpMobileNumber.Show("Please enter broker name", txtMobilenumber, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtMobilenumber.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobilenumber_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOperator.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOperator_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtOperator.Text).Trim() == "")
                {
                    epCompany.SetError(txtOperator, "Please enter opertaor");
                    txtOperator.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOperator.ShowAlways = true;
                    tpOperator.Show("Please enter operator", txtOperator, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtOperator.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOperator_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMobileBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobileBrand_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtMobileBrand.Text).Trim() == "")
                {
                    epCompany.SetError(txtMobileBrand, "Please enter mobile brand");
                    txtMobileBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileBrand.ShowAlways = true;
                    tpMobileBrand.Show("Please enter mobile brand", txtMobileBrand, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtMobileBrand.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobileBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAddContact_Enter(object sender, EventArgs e)
        {

        }


        private void TabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void BtnAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtName.Text).Trim() == "")
                {
                    epCompany.SetError(txtName, "Please enter name");
                    txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpName.ShowAlways = true;
                    tpName.Show("Please enter name", txtName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epCompany.SetError(cmbTransactionType, "Please select transaction type");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(txtMobilenumber.Text).Trim() == "")
                {
                    epCompany.SetError(txtMobilenumber, "Please enter broker name");
                    txtMobilenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNumber.ShowAlways = true;
                    tpMobileNumber.Show("Please enter broker name", txtMobilenumber, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtOperator.Text).Trim() == "")
                {
                    epCompany.SetError(txtOperator, "Please enter opertaor");
                    txtOperator.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOperator.ShowAlways = true;
                    tpOperator.Show("Please enter operator", txtOperator, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(txtMobileBrand.Text).Trim() == "")
                {
                    epCompany.SetError(txtMobileBrand, "Please enter mobile brand");
                    txtMobileBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileBrand.ShowAlways = true;
                    tpMobileBrand.Show("Please enter mobile brand", txtMobileBrand, 5000);
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

        private void BtnSaveContact_Click(object sender, EventArgs e)
        {

        }
    }
}
