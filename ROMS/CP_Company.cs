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
        public string varupdate = "0";
        public string varcompanyid="0",varstatusid ="0", varcontactcompanyid = "0";
        public CP_Company()
        {
            InitializeComponent();
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
                if (e.KeyCode == Keys.F5)
                {
                    if(tcCompanyDetails.SelectedIndex == 1)
                    {
                        BtnSaveContact_Click(sender, e);
                    }
                    else
                    { 
                        BtnSave_Click(sender, e);
                    }
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
                int varflag = 0;

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
                    foreach (DataGridViewRow row in grdBankDetails.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                        {
                            string gridValue1 = row.Cells[1].Value.ToString();
                            string gridValue2 = row.Cells[3].Value.ToString();

                            if (gridValue1 == txtBankname.Text && gridValue2 == txtbranchname.Text)
                            {
                                varflag = 1;
                            }
                        } 
                    }

                    if (varflag == 0)
                    {

                        grdBankDetails.Rows.Add(grdBankDetails.Rows.Count + 1, txtBankname.Text, txtBankShortName.Text, txtbranchname.Text, txtAccno.Text, txtIFScode.Text, varstatusid);
                        udfnBankclear();
                        txtBankname.Focus();
                        grdBankDetails.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Bank details already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                     
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

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvCity.Items.Count == 0 || txtCity.Text == "")
                    {
                        txtCity.Focus();
                        lvCity.Visible = false;
                    }
                    else
                    {
                        lvCity.Focus();
                    }
                    if (lvCity.Items.Count > 0)
                    {
                        lvCity.Items[0].Selected = true;
                    }
                }
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
                else if (txtPhoneNo.TextLength != 10)
                {
                    epCompany.SetError(txtPhoneNo, "Please enter valid phone number");
                    txtPhoneNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPhoneNo.ShowAlways = true;
                    tpPhoneNo.Show("Please enter valid phone number", txtPhoneNo, 5000);
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
                if (txtAlterPhoneno.Text !="" )
                {
                    epCompany.SetError(txtAlterPhoneno, "please enter alter Phone no.");
                    txtAlterPhoneno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPhoneNo.ShowAlways = true;
                    tpPhoneNo.Show("please enter  alter mobile no.", txtAlterPhoneno, 5000);
                }
                else if (txtAlterPhoneno.Text.Length != 10)
                {
                    epCompany.SetError(txtAlterPhoneno, "please enter valid alter Phone no.");
                    txtAlterPhoneno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPhoneNo.ShowAlways = true;
                    tpPhoneNo.Show("please enter valid alter mobile no.", txtAlterPhoneno, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtAlterPhoneno.BackColor = Color.White;
                }
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

                else if (txtmobileNo.Text.Length != 10)
                {
                    epCompany.SetError(txtmobileNo, "Please enter valid mobile number");
                    txtmobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNo.ShowAlways = true;
                    tpMobileNo.Show("Please enter valid mobile number", txtmobileNo, 5000);
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
                else if( txtPincode.TextLength != 6)
                {
                    epCompany.SetError(txtPincode, "Please enter valid pincode");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPincode.ShowAlways = true;
                    tpPincode.Show("Please enter valid pincode", txtPincode, 5000);
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

                if (txtAlterMobileno.Text != "")
                {
                    epCompany.SetError(txtAlterMobileno, "please enter alter mobile no.");
                    txtAlterMobileno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPhoneNo.ShowAlways = true;
                    tpPhoneNo.Show("please enter alter mobile no.", txtAlterMobileno, 5000);
                }
                else if (txtAlterMobileno.Text.Length != 10)
                {
                    epCompany.SetError(txtAlterMobileno, "please enter valid alter mobile no.");
                    txtAlterMobileno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPhoneNo.ShowAlways = true;
                    tpPhoneNo.Show("please enter valid alter mobile no.", txtAlterMobileno, 5000);
                }
                
                else
                {
                    epCompany.Clear();
                    txtAlterMobileno.BackColor = Color.White;
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
                if (Convert.ToString(txtwhatsappNo.Text).Trim() == "" )
                {
                    epCompany.SetError(txtwhatsappNo, "Please enter whatsapp number");
                    txtwhatsappNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWhatsAppNo.ShowAlways = true;
                    tpWhatsAppNo.Show("Please enter whatsapp number", txtwhatsappNo, 5000);
                }
               else if (txtwhatsappNo.TextLength != 10)
                {
                    epCompany.SetError(txtwhatsappNo, "Please enter valid whatsapp number");
                    txtwhatsappNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWhatsAppNo.ShowAlways = true;
                    tpWhatsAppNo.Show("Please enter valid whatsapp number", txtwhatsappNo, 5000);
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
                else if (objValidation.FormatEMail(txtEmail.Text) == false)
                {
                    epCompany.SetError(txtEmail, "Please enter valid email");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEmail.ShowAlways = true;
                    tpEmail.Show("Please enter valid email", txtEmail, 5000); 
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
                if (Convert.ToString(txtwebsite.Text).Trim() == "" )
                {
                    epCompany.SetError(txtwebsite, "Please enter website");
                    txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWebsite.ShowAlways = true;
                    tpWebsite.Show("Please enter website", txtwebsite, 5000);
                }
                else if (!objValidation.IsValidUrl(txtwebsite.Text))
                {
                    epCompany.SetError(txtwebsite, "Please enter valid website");
                    txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWebsite.ShowAlways = true;
                    tpWebsite.Show("Please enter valid website", txtwebsite, 5000);
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
               else if (txtGSTTIN.Text.Length != 15)
                {
                    epCompany.SetError(txtGSTTIN, "Please enter valid GSTTIN");
                    txtGSTTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGstin.ShowAlways = true;
                    tpGstin.Show("Please enter valid GSTTIN", txtGSTTIN, 5000);
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
                if (Convert.ToString(txtPan.Text).Trim() == "" )
                {
                    epCompany.SetError(txtPan, "Please enter PAN");
                    txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPan.ShowAlways = true;
                    tpPan.Show("Please enter PAN", txtPan, 5000);
                }
                else if (txtPan.Text.Length != 10)
                {
                    epCompany.SetError(txtPan, "Please enter valid PAN");
                    txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPan.ShowAlways = true;
                    tpPan.Show("Please enter valid PAN", txtPan, 5000);
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
                if (Convert.ToString(txtESI.Text).Trim() == "" )
                {
                    epCompany.SetError(txtESI, "Please enter ESI");
                    txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsi.ShowAlways = true;
                    tpEsi.Show("Please enter ESI", txtESI, 5000);
                }
               else if (txtESI.Text.Length != 17)
                {
                    epCompany.SetError(txtESI, "Please enter valid ESI");
                    txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsi.ShowAlways = true;
                    tpEsi.Show("Please enter valid ESI", txtESI, 5000);
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
                if (Convert.ToString(txtEPF.Text).Trim() == "" )
                {
                    epCompany.SetError(txtEPF, "Please enter EPF");
                    txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsf.ShowAlways = true;
                    tpEsf.Show("Please enter EPF", txtEPF, 5000);
                }
               else if (txtEPF.Text.Length != 22)
                {
                    epCompany.SetError(txtEPF, "Please enter valid EPF");
                    txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsf.ShowAlways = true;
                    tpEsf.Show("Please enter valid EPF", txtEPF, 5000);
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
                else if (txtFSSAI.Text.Length != 14)
                {
                    epCompany.SetError(txtFSSAI, "Please enter valid FSSAI");
                    txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpFssai.ShowAlways = true;
                    tpFssai.Show("Please enter valid FSSAI", txtFSSAI, 5000);
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

     
        private void CP_Company_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varupdate == "0")
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
                btnSave.BackColor = Color.Transparent;
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
                btnClose.BackColor = Color.Transparent;
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
                SPDataService objspdservice = new SPDataService();
                string result = "";
                string varStatus = "1";
                epCompany.Clear();
                udfntextboxcolor();
                if (Convert.ToString(txtShortName.Text).Trim() != "" && Convert.ToString(txtCompanyName.Text).Trim() != "")
                {
                    if (rbActive.Checked == true)
                    {
                        varStatus = "1";
                    }
                    else
                    {
                        varStatus = "2";

                    }
                     
                    DataTable objBankTable = new DataTable();
                    

                    DataTable objContactTable = new DataTable();

                    objContactTable.TableName = "MR_Company_Contact";
                    objContactTable.Columns.Add("CMCON_Name", typeof(string));
                    objContactTable.Columns.Add("CMCON_TransactionType", typeof(int));
                    objContactTable.Columns.Add("CMCON_MobileNo", typeof(string));
                    objContactTable.Columns.Add("CMCON_Operator", typeof(string));
                    objContactTable.Columns.Add("CMCON_MobileBrand", typeof(string));
                    objContactTable.Columns.Add("CMCON_Primary", typeof(int));
                    objContactTable.Columns.Add("CMCON_WhatsAppEnabled", typeof(int));

                    int cityid = 0;string varpincode="";
                    if (lblcityid.Text=="")
                    {
                        cityid = 0;
                    }
                    else
                    {
                        cityid = Convert.ToInt32(lblcityid.Text);
                    }
                    if (txtPincode.Text == "")
                    {
                        varpincode = "";
                    }
                    else
                    {
                        varpincode = txtPincode.Text;
                    }

                    objBankTable = udfnBankSave();
                    int companyupdate = 0;
                    if (Convert.ToInt32(varcontactcompanyid) != 0)
                    {
                        companyupdate = Convert.ToInt32(varcontactcompanyid);
                    }
                    else
                    {
                        companyupdate = Convert.ToInt32(varcompanyid);
                    }

                    if (btnSave.Text == "Save")
                    {
                    result = objspdservice.udfnCompanyMaster(0, 0, txtCompanyName.Text, txtShortName.Text, txtAddressLine1.Text, txtAddressLine2.Text, cityid
                    , varpincode, txtPhoneNo.Text, txtAlterPhoneno.Text, txtwhatsappNo.Text, txtmobileNo.Text, txtAlterMobileno.Text, txtEmail.Text, txtwebsite.Text
                    , txtGSTTIN.Text, txtPan.Text, txtESI.Text, txtEPF.Text, txtFSSAI.Text, txtPlno.Text, Convert.ToString(cmbState.SelectedValue), "1",
                    MainForm.pbUserID, MainForm.pbIpAddress, "Company Create",objBankTable, objContactTable);  
                    }
                    else
                    {
                    result = objspdservice.udfnCompanyMaster(1, Convert.ToInt32(companyupdate), txtCompanyName.Text, txtShortName.Text, txtAddressLine1.Text, txtAddressLine2.Text, cityid
                    , varpincode, txtPhoneNo.Text, txtAlterPhoneno.Text, txtwhatsappNo.Text, txtmobileNo.Text, txtAlterMobileno.Text, txtEmail.Text, txtwebsite.Text
                    , txtGSTTIN.Text, txtPan.Text, txtESI.Text, txtEPF.Text, txtFSSAI.Text, txtPlno.Text, Convert.ToString(cmbState.SelectedValue), varStatus,
                    MainForm.pbUserID, MainForm.pbIpAddress, "Company Update", objBankTable, objContactTable);
                       
                    }
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = tcCompanyDetails; 
                        tcCompanyDetails.SelectedIndex = 1;
                        MainForm.objCP_Companylist.udfnList();

                        varcontactcompanyid = varvalue[2];
                        txtCompanyName.Focus();
                        if (btnSave.Text == "Update")
                        {
                            varupdate = "1";
                            udfnclose();
                            udfnClear();
                        }

                        if (tcCompanyDetails.SelectedIndex == 1)
                        { 
                            btnSaveContact.Text = "Update";
                            btnSave.Text = "Update";
                        }
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (Convert.ToString(txtCompanyName.Text).Trim() == "")
                    {
                        epCompany.SetError(txtCompanyName, "Please enter company name");
                        txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCompanyName.ShowAlways = true;
                        tpCompanyName.Show("Please enter company name", txtCompanyName, 5000);
                        
                    }

                    if (Convert.ToString(txtShortName.Text).Trim() == "")
                    {
                        epCompany.SetError(txtShortName, "Please enter short name");
                        txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpShortName.ShowAlways = true;
                        tpShortName.Show("Please enter short name", txtShortName, 5000);
                        
                    }
                }
                
                objspdservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public DataTable udfnBankSave()
        {

            DataTable objBankTable = new DataTable();
            try
            { 
                objBankTable.TableName = "MR_Bank";
                objBankTable.Columns.Add("CMBNK_Name", typeof(string));
                objBankTable.Columns.Add("CMBNK_ShortName", typeof(string));
                objBankTable.Columns.Add("CMBNK_BranchName", typeof(string));
                objBankTable.Columns.Add("CMBNK_AccNo", typeof(string));
                objBankTable.Columns.Add("CMBNK_IFSC", typeof(string));
                objBankTable.Columns.Add("CMBNK_STSID", typeof(string));
                for (int i = 0; i < grdBankDetails.Rows.Count; i++)
                {
                    string varStatus = "1";
                    if (Convert.ToString(grdBankDetails.Rows[i].Cells["clmStatus"].Value) == "ACTIVE")
                    {
                        varStatus = "1";
                    }
                    else
                    {
                        varStatus = "2";
                    }
                    objBankTable.Rows.Add(Convert.ToString(grdBankDetails.Rows[i].Cells["clmbankname"].Value), Convert.ToString(grdBankDetails.Rows[i].Cells["clmBankShortName"].Value),
                    Convert.ToString(grdBankDetails.Rows[i].Cells["clmbranch"].Value), Convert.ToString(grdBankDetails.Rows[i].Cells["clmaccno"].Value),
                    Convert.ToString(grdBankDetails.Rows[i].Cells["clmifscode"].Value), varStatus); 
                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return objBankTable;
        }
        public void udfntextboxcolor()
        {
            try
            {
                txtCompanyName.BackColor = Color.White;
                txtShortName.BackColor = Color.White;
                txtAddressLine1.BackColor = Color.White;
                txtAddressLine2.BackColor = Color.White;
                txtCompanyName.BackColor = Color.White;
                cmbState.BackColor = Color.White;
                txtCity.BackColor = Color.White;
                txtPincode.BackColor = Color.White;
                txtPhoneNo.BackColor = Color.White;
                txtAlterPhoneno.BackColor = Color.White;
                txtmobileNo.BackColor = Color.White;
                txtAlterMobileno.BackColor = Color.White;
                txtwhatsappNo.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                txtwebsite.BackColor = Color.White;
                txtGSTTIN.BackColor = Color.White;
                txtPan.BackColor = Color.White;
                txtFSSAI.BackColor = Color.White;
                txtESI.BackColor = Color.White;
                txtEPF.BackColor = Color.White;
                txtPlno.BackColor = Color.White;
                txtBankname.BackColor = Color.White;
                txtBankShortName.BackColor = Color.White;
                txtbranchname.BackColor = Color.White;
                txtAccno.BackColor = Color.White;
                txtIFScode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        {
            try
            {
                txtCompanyName.Text = "";
                txtShortName.Text = "";
                txtAddressLine1.Text = "";
                txtAddressLine2.Text = "";
                txtCompanyName.Text = "";
                cmbState.Text = "";
                txtCity.Text = "";
                txtPincode.Text = "";
                txtPhoneNo.Text = "";
                txtAlterPhoneno.Text = "";
                txtmobileNo.Text = "";
                txtAlterMobileno.Text = "";
                txtwhatsappNo.Text = "";
                txtEmail.Text = "";
                txtwebsite.Text = "";
                txtGSTTIN.Text = "";
                txtPan.Text = "";
                txtFSSAI.Text = "";
                txtESI.Text = "";
                txtEPF.Text = "";
                txtPlno.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBankclear()
        {

            txtBankname.Text = "";
            txtBankShortName.Text = "";
            txtbranchname.Text = "";
            txtAccno.Text = "";
            txtIFScode.Text = "";

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
               // if (Convert.ToString(txtAddressLine1.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtAddressLine1, "Please enter address");
               //     txtAddressLine1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpAddressLine1.ShowAlways = true;
               //     tpAddressLine1.Show("Please enter address", txtAddressLine1, 5000);
               //   //  blnErrorFlag = true;
               // }
               // if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
               // {
               //     epCompany.SetError(cmbState, "Please select state");
               //     cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpState.ShowAlways = true;
               //     tpState.Show("Please select state", cmbState, 5000);
               //    // blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtCity.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtCity, "Please enter city");
               //     txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpCity.ShowAlways = true;
               //     tpCity.Show("Please enter city", txtCity, 5000);
               // //    blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtPincode.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtPincode, "Please enter pincode");
               //     txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpPincode.ShowAlways = true;
               //     tpPincode.Show("Please enter pincode", txtPincode, 5000);
               ////     blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtPhoneNo.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtPhoneNo, "Please enter phone number");
               //     txtPhoneNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpPhoneNo.ShowAlways = true;
               //     tpPhoneNo.Show("Please enter phone number", txtPhoneNo, 5000);
               ////     blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtmobileNo.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtmobileNo, "Please enter mobile number");
               //     txtmobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpMobileNo.ShowAlways = true;
               //     tpMobileNo.Show("Please enter mobile number", txtmobileNo, 5000);
               // //    blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtwhatsappNo.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtwhatsappNo, "Please enter whatsapp number");
               //     txtwhatsappNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpWhatsAppNo.ShowAlways = true;
               //     tpWhatsAppNo.Show("Please enter whatsapp number", txtwhatsappNo, 5000);
               // //    blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtEmail.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtEmail, "Please enter email");
               //     txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpEmail.ShowAlways = true;
               //     tpEmail.Show("Please enter email", txtEmail, 5000);
               ////     blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtwebsite.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtwebsite, "Please enter website");
               //     txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpWebsite.ShowAlways = true;
               //     tpWebsite.Show("Please enter website", txtwebsite, 5000);
               //   //  blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtGSTTIN.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtGSTTIN, "Please enter GSTTIN");
               //     txtGSTTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpGstin.ShowAlways = true;
               //     tpGstin.Show("Please enter GSTTIN", txtGSTTIN, 5000);
               // //    blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtPan.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtPan, "Please enter PAN");
               //     txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpPan.ShowAlways = true;
               //     tpPan.Show("Please enter PAN", txtPan, 5000);
               // //    blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtESI.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtESI, "Please enter ESI");
               //     txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpEsi.ShowAlways = true;
               //     tpEsi.Show("Please enter ESI", txtESI, 5000);
               //  //   blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtEPF.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtEPF, "Please enter ESF");
               //     txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpEsf.ShowAlways = true;
               //     tpEsf.Show("Please enter ESF", txtEPF, 5000);
               // //    blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtFSSAI.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtFSSAI, "Please enter FSSAI");
               //     txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpFssai.ShowAlways = true;
               //     tpFssai.Show("Please enter FSSAI", txtFSSAI, 5000);
               // //    blnErrorFlag = true;
               // }
               // if (Convert.ToString(txtPlno.Text).Trim() == "")
               // {
               //     epCompany.SetError(txtPlno, "Please enter PL number");
               //     txtPlno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpPlNo.ShowAlways = true;
               //     tpPlNo.Show("Please enter PL number", txtPlno, 5000);
               // //    blnErrorFlag = true;
               // }
                if (blnErrorFlag == false)
                {
                    udfnSave(sender, e);
                    udfnBankclear(); 
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
                    cmbTransactionType.Focus();
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
                    cbWhatsApp.Focus();
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
                    btnAddContact.Focus();
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
                int varflag = 0, varflag1 = 0,varflag2=0;
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

                if (Convert.ToString(txtMobilenumber.Text).Trim() == "" && txtMobilenumber.Text.Length !=10)
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
                    var varcheckedvalue= "";  
                    var varwhatsapp = "";
                    if (cbPrimary.Checked == true)
                    {
                        varcheckedvalue ="Yes";
                    }
                    else
                    {
                        varcheckedvalue = "No"; 
                    }
                    if (cbWhatsApp.Checked == true)
                    {
                        varwhatsapp = "Yes";
                    }
                    else
                    {
                        varwhatsapp = "No";
                    }

                   
                   
                    foreach (DataGridViewRow row in grdContactManager.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                        {
                            string gridValue1 = row.Cells[8].Value.ToString();
                            string gridValue2 = row.Cells[5].Value.ToString(); 
                            string gridValue4 = row.Cells[3].Value.ToString();

                            if (gridValue1 == Convert.ToString(cmbTransactionType.SelectedValue) && gridValue4 == txtMobilenumber.Text)
                            {
                                varflag1 = 1;
                            }
                            if (gridValue1 == Convert.ToString(cmbTransactionType.SelectedValue) && gridValue2 == varcheckedvalue)
                            { 
                                varflag = 1;
                                if (varflag == 1 && cbPrimary.Checked==true)
                                {
                                    varflag2 = 1;
                                }
                            }
                        }
                    }
                    DataService objDser = new DataService();
                    string varvalue = "";
                    varvalue = objDser.displaydata("SELECT MST_DisplayText FROM  DEF_Master where MSTID = '"+ Convert.ToString(cmbTransactionType.SelectedValue) + "'");


                    if (varflag1==0 && varflag2 ==0)
                    { 
                        grdContactManager.Rows.Add(grdContactManager.Rows.Count + 1, txtName.Text, varvalue, txtMobilenumber.Text, varwhatsapp, varcheckedvalue, txtOperator.Text, txtMobileBrand.Text, Convert.ToString(cmbTransactionType.SelectedValue));
                        udfnContactClear();
                        txtName.Focus();
                        grdContactManager.ClearSelection();
                    }
                    else
                    {
                        if (varflag1 != 0)
                        {
                            MessageBox.Show("Mobile Number already exists for this transaction!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (varflag2 != 0)
                        {
                            MessageBox.Show("Primary already exists for this transaction type!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void udfnContactClear()
        {
            try
            {
                txtName.Text = "";
                cmbTransactionType.SelectedValue = -1;
                txtMobilenumber.Text = "";
                txtOperator.Text = "";
                txtMobileBrand.Text = "";
                cbWhatsApp.Checked = false;
                cbPrimary.Checked = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

       

        private void BtnSaveContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdContactManager.Rows.Count > 0)
                {
                    udfnContactSave();
                    udfnContactClear();
                    //grdContactManager.Rows.Clear();
                }
                else
                { 
                    MessageBox.Show("Please enter atleast one Transaction", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnContactSave()
        {
            string result = "";
            int contactupdate = 0;
            SPDataService objspdservice = new SPDataService();
            DataTable objContactTable = new DataTable();
            try
            {
                objContactTable.TableName = "MR_Company_Contact";
                objContactTable.Columns.Add("CMCON_Name", typeof(string));
                objContactTable.Columns.Add("CMCON_TransactionType", typeof(int));
                objContactTable.Columns.Add("CMCON_MobileNo", typeof(string));
                objContactTable.Columns.Add("CMCON_Operator", typeof(string));
                objContactTable.Columns.Add("CMCON_MobileBrand", typeof(string));
                objContactTable.Columns.Add("CMCON_Primary", typeof(int));
                objContactTable.Columns.Add("CMCON_WhatsAppEnabled", typeof(int));


                DataTable objBankTable = new DataTable();
                objBankTable.TableName = "MR_Bank";
                objBankTable.Columns.Add("CMBNK_Name", typeof(string));
                objBankTable.Columns.Add("CMBNK_ShortName", typeof(string));
                objBankTable.Columns.Add("CMBNK_BranchName", typeof(string));
                objBankTable.Columns.Add("CMBNK_AccNo", typeof(string));
                objBankTable.Columns.Add("CMBNK_IFSC", typeof(string));
                objBankTable.Columns.Add("CMBNK_STSID", typeof(string));

                for (int i = 0; i < grdContactManager.Rows.Count; i++)
                {
                    int varprimary = 0;
                    int varwhatsapp = 0;
                    if (Convert.ToString(grdContactManager.Rows[i].Cells["clmPrimary"].Value) == "Yes")
                    {
                        varprimary = 1;
                    }
                    else
                    {
                        varprimary = 0;
                    }
                    if (Convert.ToString(grdContactManager.Rows[i].Cells["clmWhatsAppNo"].Value) =="Yes")
                    {
                        varwhatsapp = 1;
                    }
                    else
                    {
                        varwhatsapp = 0;
                    }

                    objContactTable.Rows.Add(Convert.ToString(grdContactManager.Rows[i].Cells["clmName"].Value), Convert.ToInt32(grdContactManager.Rows[i].Cells["clmid"].Value),
                    Convert.ToString(grdContactManager.Rows[i].Cells["clmmobile"].Value), Convert.ToString(grdContactManager.Rows[i].Cells["clmOperator"].Value),
                    Convert.ToString(grdContactManager.Rows[i].Cells["clmMobileBrand"].Value), varprimary,varwhatsapp);
                }
                if (Convert.ToInt32(varcontactcompanyid) != 0)
                {
                    contactupdate = Convert.ToInt32(varcontactcompanyid);
                }
                else
                { 
                    contactupdate = Convert.ToInt32(varcompanyid);
                }

                if (btnSave.Text == "Save")
                {
                    result = objspdservice.udfnCompanyMaster(3, Convert.ToInt32(varcontactcompanyid), "", "", "", "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", MainForm.pbUserID, MainForm.pbIpAddress, "contact manager Create", objBankTable, objContactTable);
                }
                else
                {
                    result = objspdservice.udfnCompanyMaster(4, Convert.ToInt32(contactupdate), "", "", "", "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", MainForm.pbUserID, MainForm.pbIpAddress, "contact manager Update", objBankTable, objContactTable);
                    varupdate = "1"; 
                }
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    udfnClear();
                    MainForm.objCP_Companylist.udfnList();
                    if (btnSave.Text == "Update")
                    {
                        udfnclose();
                    }
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
        private void BtnAddContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAddContact_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSaveContact_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSaveContact.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSaveContact_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSaveContact.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSaveContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSaveContact_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnCloseContact_Click(object sender, EventArgs e)
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

        private void BtnCloseContact_Enter(object sender, EventArgs e)
        {
            try
            {
                btnCloseContact.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnCloseContact_Leave(object sender, EventArgs e)
        {
            try
            {
                btnCloseContact.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnCloseContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPincode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAlterPhoneno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtmobileNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAlterMobileno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtwhatsappNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CP_Company_Load(object sender, EventArgs e)
        {
            try
            { 
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>0 ORDER BY STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,1) AND MSTID !=0 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
                objDataBind = null; 
                DataService objdservice = new DataService();  
                varstatusid = objdservice.displaydata("select STS_Name as name from DEF_Status where STS_ModuleID=1 AND STSID=1"); 
                grdContactManager.Rows.Clear();
                grdBankDetails.Rows.Clear();
                udfnEdit();
                this.ActiveControl = txtCompanyName;
                objdservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdContactManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.RowIndex != -1)
                {
                    switch (grdContactManager.Columns[e.ColumnIndex].Name)
                    {

                        case "clmRemove":

                            grdContactManager.Rows.RemoveAt(this.grdContactManager.SelectedRows[0].Index);
                            for (int i = 0; i < grdContactManager.RowCount; i++)
                            { 
                                grdContactManager.Rows[i].Cells["clmContsno"].Value = i + 1;
                            }
                            break; 
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBankDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 

                if (e.RowIndex != -1)
                {
                    switch (grdBankDetails.Columns[e.ColumnIndex].Name)
                    {

                        case "clmremovebank":

                            grdBankDetails.Rows.RemoveAt(this.grdBankDetails.SelectedRows[0].Index);
                            for (int i = 0; i < grdBankDetails.RowCount; i++)
                            {
                                grdBankDetails.Rows[i].Cells["clmsno"].Value = i + 1; 
                            }
                            break;

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
                if (varcompanyid != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objspservice.udfnCompanyList(1, Convert.ToInt32(varcompanyid), MainForm.pbUserID, MainForm.pbIpAddress);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtCompanyName.Text = objDS.Tables[0].Rows[0]["Name"].ToString().Replace("''", "'");
                            txtShortName.Text = objDS.Tables[0].Rows[0]["Shortname"].ToString().Replace("''", "'");
                            txtCity.Text = objDS.Tables[0].Rows[0]["city"].ToString().Replace("''", "'");
                            txtPhoneNo.Text = objDS.Tables[0].Rows[0]["Phone"].ToString().Replace("''", "'");
                            txtwhatsappNo.Text = objDS.Tables[0].Rows[0]["Whatsapp"].ToString().Replace("''", "'");
                            txtGSTTIN.Text = objDS.Tables[0].Rows[0]["GSTIN"].ToString().Replace("''", "'");
                            txtPan.Text = objDS.Tables[0].Rows[0]["Pan"].ToString().Replace("''", "'");
                            txtAddressLine1.Text = objDS.Tables[0].Rows[0]["Address1"].ToString().Replace("''", "'");
                            txtAddressLine2.Text = objDS.Tables[0].Rows[0]["Address2"].ToString().Replace("''", "'");
                            cmbState.Text = objDS.Tables[0].Rows[0]["State"].ToString();
                            txtPincode.Text = objDS.Tables[0].Rows[0]["Pincode"].ToString();
                            txtmobileNo.Text = objDS.Tables[0].Rows[0]["Mobile"].ToString();
                            txtEmail.Text = objDS.Tables[0].Rows[0]["Email"].ToString().Replace("''", "'");
                            txtwebsite.Text = objDS.Tables[0].Rows[0]["Web"].ToString().Replace("''", "'");
                            txtESI.Text = objDS.Tables[0].Rows[0]["ESI"].ToString().Replace("''", "'");
                            txtEPF.Text = objDS.Tables[0].Rows[0]["EPF"].ToString().Replace("''", "'");
                            txtFSSAI.Text = objDS.Tables[0].Rows[0]["FSSAI"].ToString().Replace("''", "'");
                            txtPlno.Text = objDS.Tables[0].Rows[0]["PLNO"].ToString().Replace("''", "'");
                            txtAlterMobileno.Text = objDS.Tables[0].Rows[0]["MobileAlt"].ToString();
                            txtAlterPhoneno.Text = objDS.Tables[0].Rows[0]["PhoneAlt"].ToString(); 
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "1") { rbActive.Checked = true; } else { rbInactive.Checked = true; }

                            btnSave.Text = "Update";
                            btnSaveContact.Text = "Update"; ;
                            pnlStatus.Enabled = true;
                        }
                        if (objDS.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                            {
                                grdContactManager.Rows.Add(Convert.ToString(objDS.Tables[1].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[1].Rows[i]["NAME"]), Convert.ToString(objDS.Tables[1].Rows[i]["TRANSACTIONNAME"]),
                                Convert.ToString(objDS.Tables[1].Rows[i]["MOBILE"]), Convert.ToString(objDS.Tables[1].Rows[i]["WHATSAPP"]), Convert.ToString(objDS.Tables[1].Rows[i]["PRIMAY"])
                                , Convert.ToString(objDS.Tables[1].Rows[i]["OPERATOR"]), Convert.ToString(objDS.Tables[1].Rows[i]["BRAND"]), Convert.ToString(objDS.Tables[1].Rows[i]["id"]));
                                
                            }

                        }
                        if (objDS.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                            {
                                grdBankDetails.Rows.Add(Convert.ToString(objDS.Tables[2].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[2].Rows[i]["NAME"]), Convert.ToString(objDS.Tables[2].Rows[i]["SHORTNAME"]),
                                Convert.ToString(objDS.Tables[2].Rows[i]["BRANCH"]), Convert.ToString(objDS.Tables[2].Rows[i]["ACCOUNT"]), Convert.ToString(objDS.Tables[2].Rows[i]["IFSC"])
                                , Convert.ToString(objDS.Tables[2].Rows[i]["STATUS"]),  Convert.ToString(objDS.Tables[2].Rows[i]["sts"]));
                                
                            }

                            btnSave.Text = "Update";
                            btnSaveContact.Text = "Update"; ;

                        }

                    }
                    lvCity.Visible = false;
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

        private void TxtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {

                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService(); 
                DataSet objDs = new DataSet();
                if (txtCity.Text.Length > 2)
                {
                    objDs = objspdservice.udfncitylist(1, txtCity.Text, MainForm.pbUserID, MainForm.pbIpAddress,Convert.ToString(cmbState.SelectedValue));
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString() };
                                  //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvCity.Items.Add(objList);
                                }
                                lvCity.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvCity.Visible = false;
                    lvCity.Items.Clear();
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

        private void LvCity_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               
                    udfnGrdevent();
                    txtPincode.Focus();
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGrdevent();
                    txtPincode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public void udfnGrdevent()
        {
            try
            {
                    if (txtCity.Text != "")
                    {
                        txtCity.Text = lvCity.SelectedItems[0].SubItems[0].Text;
                        lvCity.Visible = false;
                        DataService objDataService = new DataService();
                        lblcityid.Text = lvCity.SelectedItems[0].SubItems[2].Text;
                        objDataService.CloseConnection();
                    }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobilenumber_KeyPress(object sender, KeyPressEventArgs e)
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
        public AutoCompleteStringCollection AutoCompleteLoad()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();
             
            objds = objdservice.GetDataset("select STSID as id,STS_Name as Name from DEF_Status where STS_ModuleID=1 ");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("Name") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            } 
            return varstr;
        }

        private void CbWhatsApp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbPrimary.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbPrimary_KeyDown(object sender, KeyEventArgs e)
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

        private void CbWhatsApp_Enter(object sender, EventArgs e)
        {
            try
            {
                cbWhatsApp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbWhatsApp_Leave(object sender, EventArgs e)
        {
            try
            {
                cbWhatsApp.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbPrimary_Enter(object sender, EventArgs e)
        {
            try
            {
                cbPrimary.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBankDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        { try
            {

                grdBankDetails.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdContactManager_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                grdContactManager.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbPrimary_Leave(object sender, EventArgs e)
        {
            try
            {
                cbPrimary.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBankDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdBankDetails.CurrentCell.OwningColumn.Name == "clmStatus")
                {
                    TextBox RefCode = e.Control as TextBox;
                    if (RefCode != null)
                    {
                        RefCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        RefCode.AutoCompleteCustomSource = AutoCompleteLoad();
                        RefCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else
                {
                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.None;
                    }
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
