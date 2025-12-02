using ROMS.Model;
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
    //Created By:Sathish ; Created On:-26/11/2025
    public partial class CP_Customer : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpCustomer = new ToolTip();
        public int pbCustomerId = 0, PbStatus = 0, varUpdate = 0;
        public CP_Customer()
        {
            InitializeComponent();
        }
        public void udfnSave()
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0, varCustomerType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Customer Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Customer Updation";
                    varType = 1;
                }

                if (rbCash.Checked == true)
                {
                    varCustomerType = 326;  // Cash
                }
                if (rbCredit.Checked == true)
                {
                    varCustomerType = 327;  // Credit
                }
                MR_Sales obj = new MR_Sales();
                obj.paraViewType = varType; // 0 = Insert, 1 = Update, 2 = Delete
                obj.paraCustomerId = pbCustomerId; // set if updating or deleting
                obj.paraCUS_Name = txtCustomerName.Text.Trim();
                obj.paraCUS_ReferenceName = txtReferenceName.Text.Trim();
                obj.paraCUS_ContactNo = txtContactNo.Text.Trim();
                obj.paraCUS_WhatsappNo = txtWhatsappNo.Text.Trim();
                obj.paraCUS_TypeID = varCustomerType; 
                obj.paraCUS_CategoryTypeID = Convert.ToInt32(cmbCustomerType.SelectedValue); 
                obj.paraCUS_Credit_Limit = string.IsNullOrEmpty(txtCreditLimit.Text.Trim()) ? 0 : Convert.ToInt32(txtCreditLimit.Text.Trim());
                obj.paraCUS_CreditDays = string.IsNullOrEmpty(txtCreditDays.Text.Trim()) ? 0 : Convert.ToInt32(txtCreditDays.Text.Trim());
                obj.paraCUS_TotalInvoice = string.IsNullOrEmpty(txtTotalInvoice.Text.Trim()) ? 0 : Convert.ToInt32(txtTotalInvoice.Text.Trim());
                obj.paraCUS_OpeningBalance = string.IsNullOrEmpty(txtOBAmt.Text.Trim()) ? 0 : (float)Convert.ToDecimal(txtOBAmt.Text.Trim());
                obj.paraCUS_OpeningBalanceType = Convert.ToInt32(cmbOBType.SelectedValue);
                obj.paraCUS_GSTIN = txtGSTIN.Text.Trim();
                obj.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);

                // Billing Address
                obj.para_Billing_Address1 = txtaddress1.Text.Trim();
                obj.para_Billing_Address2 = txtaddress2.Text.Trim();
                obj.para_Billing_STID = Convert.ToInt32(cmbState.SelectedValue);
                obj.para_Billing_AID = Convert.ToInt32(lblAreaId.Text.Trim());
                obj.para_Billing_CTYID = Convert.ToInt32(lblCityId.Text.Trim());
                obj.para_Billing_Pincode = txtPincode.Text.Trim();
                obj.para_Billing_Landmark = txtLandmark.Text.Trim();

                // Shipping Address
                obj.para_Shipping_Address1 = txtShipaddress1.Text.Trim();
                obj.para_Shipping_Address2 = txtShipaddress2.Text.Trim();
                obj.para_Shipping_STID = Convert.ToInt32(cmbShipState.SelectedValue);
                obj.para_Shipping_AID = Convert.ToInt32(lblShipAreaId.Text.Trim());
                obj.para_Shipping_CTYID = Convert.ToInt32(lblShipCityId.Text.Trim());
                obj.para_Shipping_Pincode = txtShipPincode.Text.Trim();
                obj.para_Shipping_Landmark = txtShipLandmark.Text.Trim();

                // Common
                obj.paraOriginator = varoriginator;
                varResult = objspservice.udfnCustomer(obj);
                objspservice.CloseConnection();

                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Customerlist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        txtCustomerName.Text = "";
                        this.ActiveControl = txtCustomerName;
                    }
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
                    }
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
                }
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrFlag = false;
                if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
                {
                    epCustomer.SetError(txtCustomerName, "Please enter customer name.");
                    txtCustomerName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter customer name.", txtCustomerName, 5000);
                    blnErrFlag = true;
                }
                if (string.IsNullOrWhiteSpace(txtReferenceName.Text))
                {
                    epCustomer.SetError(txtReferenceName, "Please enter reference name.");
                    txtReferenceName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter reference name.", txtReferenceName, 5000);
                    blnErrFlag = true;
                }
                if (string.IsNullOrWhiteSpace(txtContactNo.Text))
                {
                    epCustomer.SetError(txtContactNo, "Please enter contact no.");
                    txtContactNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter contact no.", txtContactNo, 5000);
                    blnErrFlag = true;
                }
                else if (!long.TryParse(txtContactNo.Text.Trim(), out _) || txtContactNo.Text.Trim().Length != 15)
                {
                    epCustomer.SetError(txtContactNo, "Please enter valid contact no.");
                    txtContactNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter valid contact no.", txtContactNo, 5000);
                    blnErrFlag = true;
                }
                if (rbCredit.Checked == true)  // Credit
                {
                    if (!string.IsNullOrWhiteSpace(txtCreditLimit.Text))
                    {
                        if (!decimal.TryParse(txtCreditLimit.Text.Trim(), out _))
                        {
                            epCustomer.SetError(txtCreditLimit, "Please enter valid credit limit.");
                            txtCreditLimit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpCustomer.ShowAlways = true;
                            tpCustomer.Show("Please enter valid credit limit.", txtCreditLimit, 5000);
                            blnErrFlag = true;
                        }
                    }
                    else
                    {
                        epCustomer.SetError(txtCreditLimit, "Please enter credit limit.");
                        txtCreditLimit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCustomer.ShowAlways = true;
                        tpCustomer.Show("Please enter credit limit.", txtCreditLimit, 5000);
                        blnErrFlag = true;
                    }
                    if (!string.IsNullOrWhiteSpace(txtCreditDays.Text))
                    {
                        if (!int.TryParse(txtCreditDays.Text.Trim(), out _))
                        {
                            epCustomer.SetError(txtCreditDays, "Please enter valid credit days.");
                            txtCreditDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpCustomer.ShowAlways = true;
                            tpCustomer.Show("Please enter valid credit days.", txtCreditDays, 5000);
                            blnErrFlag = true;
                        }
                    }
                    else
                    {
                        epCustomer.SetError(txtCreditDays, "Please enter credit days.");
                        txtCreditDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCustomer.ShowAlways = true;
                        tpCustomer.Show("Please enter credit days.", txtCreditDays, 5000);
                        blnErrFlag = true;
                    }
                    if (!string.IsNullOrWhiteSpace(txtTotalInvoice.Text))
                    {
                        if (!decimal.TryParse(txtTotalInvoice.Text.Trim(), out _))
                        {
                            epCustomer.SetError(txtTotalInvoice, "Please enter valid total invoice.");
                            txtTotalInvoice.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpCustomer.ShowAlways = true;
                            tpCustomer.Show("Please enter valid total invoice.", txtTotalInvoice, 5000);
                            blnErrFlag = true;
                        }
                    }
                    else
                    {
                        epCustomer.SetError(txtTotalInvoice, "Please enter total invoice.");
                        txtTotalInvoice.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCustomer.ShowAlways = true;
                        tpCustomer.Show("Please enter total invoice.", txtTotalInvoice, 5000);
                        blnErrFlag = true;
                    }

                    if (!string.IsNullOrWhiteSpace(txtOBAmt.Text))
                    {
                        if (!decimal.TryParse(txtOBAmt.Text.Trim(), out _))
                        {
                            epCustomer.SetError(txtOBAmt, "Please enter valid opening balance.");
                            txtOBAmt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpCustomer.ShowAlways = true;
                            tpCustomer.Show("Please enter valid opening balance.", txtOBAmt, 5000);
                            blnErrFlag = true;
                        }
                    }
                    else
                    {
                        epCustomer.SetError(txtOBAmt, "Please enter opening balance.");
                        txtOBAmt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCustomer.ShowAlways = true;
                        tpCustomer.Show("Please enter opening balance.", txtOBAmt, 5000);
                        blnErrFlag = true;
                    }

                    if (string.IsNullOrWhiteSpace(txtGSTIN.Text))
                    {
                        epCustomer.SetError(txtGSTIN, "Please enter GSTIN.");
                        txtGSTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCustomer.ShowAlways = true;
                        tpCustomer.Show("Please enter GSTIN.", txtGSTIN, 5000);
                        blnErrFlag = true;
                    }
                }

                if (cmbStatus.SelectedValue == null || Convert.ToInt32(cmbStatus.SelectedValue) == -1)
                {
                    epCustomer.SetError(cmbStatus, "Please select the status.");
                    cmbStatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please select the status.", cmbStatus, 5000);
                    blnErrFlag = true;
                }
                // --- Billing Address Validations ---
                if (string.IsNullOrWhiteSpace(txtaddress1.Text))
                {
                    epCustomer.SetError(txtaddress1, "Please enter address line 1.");
                    txtaddress1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter address line 1.", txtaddress1, 5000);
                    blnErrFlag = true;
                }

                if (string.IsNullOrWhiteSpace(txtaddress2.Text))
                {
                    epCustomer.SetError(txtaddress2, "Please enter address line 2.");
                    txtaddress2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter address line 2.", txtaddress2, 5000);
                    blnErrFlag = true;
                }

                if (cmbState.SelectedValue == null || Convert.ToInt32(cmbState.SelectedValue) == -1)
                {
                    epCustomer.SetError(cmbState, "Please select state.");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please select state.", cmbState, 5000);
                    blnErrFlag = true;
                }
                if (string.IsNullOrWhiteSpace(txtArea.Text))
                {
                    epCustomer.SetError(txtArea, "Please enter area name.");
                    txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter area name.", txtArea, 5000);
                    blnErrFlag = true;
                }
                else if (string.IsNullOrWhiteSpace(lblAreaId.Text) || lblAreaId.Text.Trim() == "0")
                {
                    epCustomer.SetError(txtArea, "Please enter a valid area.");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter a valid area.", txtArea, 5000);
                    blnErrFlag = true;
                }

                if (string.IsNullOrWhiteSpace(txtPincode.Text))
                {
                    epCustomer.SetError(txtPincode, "Please enter pincode.");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter pincode.", txtPincode, 5000);
                    blnErrFlag = true;
                }

                if (string.IsNullOrWhiteSpace(txtLandmark.Text))
                {
                    epCustomer.SetError(txtLandmark, "Please enter landmark.");
                    txtLandmark.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomer.ShowAlways = true;
                    tpCustomer.Show("Please enter landmark.", txtLandmark, 5000);
                    blnErrFlag = true;
                }

                if (blnErrFlag == false)
                {
                    epCustomer.Clear();
                    btnSave.Enabled = false;
                    udfnSave();
                    btnSave.Enabled = true;
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

        private void CP_Customer_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Customerlist.picLoader.Visible = false;
                MainForm.objCP_Customerlist.picLoader.SendToBack();
                this.ActiveControl = txtCustomerName;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Customer_Type", "CusType_STSID=1 ORDER BY CusTypeID", "CusType_Name,CusTypeID", cmbCustomerType, "", "CusType_Name", "CusTypeID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STSID IN (1,2,29)", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>0 ORDER BY STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>0 ORDER BY STID", "ST_Name,STID", cmbShipState, "", "ST_Name", "STID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (29,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOBType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                if (pbCustomerId == 0)
                {

                }
                else
                {
                    udfnEdit();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCustomerName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCustomerName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCustomerName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtContactNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtContactNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
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

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtContactNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtWhatsappNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWhatsappNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtWhatsappNo_KeyDown(object sender, KeyEventArgs e)
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

        private void txtWhatsappNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtWhatsappNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtWhatsappNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCustomerType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbCustomerType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCustomerType_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbCustomerType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbCustomerType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbCustomerType.SelectedValue) != 2)
                {
                    txtGSTIN.Enabled = false;
                }
                else
                {
                    txtGSTIN.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtGSTIN_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGSTIN.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtGSTIN_KeyDown(object sender, KeyEventArgs e)
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

        private void txtGSTIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                objValidation.udfnGSTIN(e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtGSTIN_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGSTIN.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCreditLimit_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCreditLimit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCreditLimit_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCreditLimit_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCreditLimit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbState_Enter(object sender, EventArgs e)
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

        private void cmbState_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbState_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbState_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbState.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbState.Select(int.MaxValue, 0)));
                //txtCity.Text = "";
                //lblCityId.Text = "0";
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

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {

                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtCity.Text.Length > 0)
                {
                    objDs = objspdservice.udfnCitylist(1, txtCity.Text, Convert.ToInt32(cmbState.SelectedValue), 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString(), objDs.Tables[0].Rows[i]["ST_TIN"].ToString() };
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
        }

        private void txtPincode_Enter(object sender, EventArgs e)
        {
            try
            {
                lvCity.Visible = false;
                txtPincode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPincode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPincode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPincode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvCity_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnCityBind();
                txtPincode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnCityBind();
                    txtPincode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCityBind()
        {
            try
            {
                if (txtCity.Text != "")
                {
                    ListViewItem selectedItem = lvCity.SelectedItems[0];
                    txtCity.Text = selectedItem.SubItems[0].Text;
                    lblCityId.Text = selectedItem.SubItems[2].Text;
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
                lvCity.Visible = false;
            }
        }

        private void txtReferenceName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtReferenceName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtReferenceName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtReferenceName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtReferenceName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCreditDays_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCreditDays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCreditDays_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCreditDays_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCreditDays.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbOBType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbOBType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbOBType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtGSTIN.Enabled == true)
                    {
                        txtGSTIN.Focus();
                    }
                    else
                    {
                        cmbStatus.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbOBType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbOBType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOBType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtaddress1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtaddress1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtaddress1_KeyDown(object sender, KeyEventArgs e)
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

        private void txtaddress1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtaddress1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtaddress2_Enter(object sender, EventArgs e)
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

        private void txtaddress2_KeyDown(object sender, KeyEventArgs e)
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

        private void txtaddress2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtaddress2.BackColor = Color.White;
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

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvArea.Items.Count == 0 || txtArea.Text == "")
                    {
                        txtCity.Focus();
                        lvArea.Visible = false;
                    }
                    else
                    {
                        lvArea.Focus();
                    }
                    if (lvArea.Items.Count > 0)
                    {
                        lvArea.Items[0].Selected = true;
                    }
                }
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

        private void txtArea_Leave(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvArea.Items.Clear();
                if (txtArea.Text.Length > 0)
                {
                    lblAreaId.Text = "0";
                    lblCityId.Text = "0";
                    txtCity.Text = "";
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();

                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 2;
                    obj.paraMHEName = txtArea.Text.Trim();
                    objDs = objspservice.udfnMarriageHallList(obj);
                    objspservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["Area"].ToString(), objDs.Tables[0].Rows[i]["City"].ToString(), objDs.Tables[0].Rows[i]["State"].ToString(), objDs.Tables[0].Rows[i]["AID"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString(), objDs.Tables[0].Rows[i]["STID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    lvArea.Columns[3].Width = 0;
                                    lvArea.Columns[4].Width = 0;
                                    lvArea.Columns[5].Width = 0;
                                    lvArea.Items.Add(objList);
                                }
                                lvArea.Visible = true;
                            }
                            else
                            {
                                lvArea.Visible = false;
                            }
                        }
                        else
                        {
                            lvArea.Visible = false;
                        }
                    }
                    else
                    {
                        lvArea.Visible = false;
                    }
                }
                else
                {
                    lvArea.Visible = false;
                    lvArea.Items.Clear();
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

        private void txtLandmark_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLandmark.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLandmark_KeyDown(object sender, KeyEventArgs e)
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

        private void txtLandmark_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLandmark.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipaddress1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtShipaddress1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipaddress1_KeyDown(object sender, KeyEventArgs e)
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

        private void txtShipaddress1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtShipaddress1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipaddress2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtShipaddress2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipaddress2_KeyDown(object sender, KeyEventArgs e)
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

        private void txtShipaddress2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtShipaddress2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbShipState_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbShipState.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbShipState_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbShipState_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbShipState_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbShipState.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbShipState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbShipState.Select(int.MaxValue, 0)));
                //txtShipCity.Text = "";
                //lblShipCityId.Text = "0";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipArea_Enter(object sender, EventArgs e)
        {
            try
            {
                txtShipArea.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvShipArea.Items.Count == 0 || txtArea.Text == "")
                    {
                        txtShipCity.Focus();
                        lvShipArea.Visible = false;
                    }
                    else
                    {
                        lvShipArea.Focus();
                    }
                    if (lvShipArea.Items.Count > 0)
                    {
                        lvShipArea.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtShipCity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipArea_Leave(object sender, EventArgs e)
        {
            try
            {
                txtShipArea.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipArea_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvShipArea.Items.Clear();
                if (txtShipArea.Text.Length > 0)
                {
                    lblShipAreaId.Text = "0";
                    lblShipCityId.Text = "0";
                    txtShipCity.Text = "";
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();

                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 2;
                    obj.paraMHEName = txtShipArea.Text.Trim();
                    objDs = objspservice.udfnMarriageHallList(obj);
                    objspservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["Area"].ToString(), objDs.Tables[0].Rows[i]["City"].ToString(), objDs.Tables[0].Rows[i]["State"].ToString(), objDs.Tables[0].Rows[i]["AID"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString(), objDs.Tables[0].Rows[i]["STID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    lvShipArea.Columns[3].Width = 0;
                                    lvShipArea.Columns[4].Width = 0;
                                    lvShipArea.Columns[5].Width = 0;
                                    lvShipArea.Items.Add(objList);
                                }
                                lvShipArea.Visible = true;
                            }
                            else
                            {
                                lvShipArea.Visible = false;
                            }
                        }
                        else
                        {
                            lvShipArea.Visible = false;
                        }
                    }
                    else
                    {
                        lvShipArea.Visible = false;
                    }
                }
                else
                {
                    lvShipArea.Visible = false;
                    lvShipArea.Items.Clear();
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

        private void txtShipCity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtShipCity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvShipCity.Items.Count == 0 || txtShipCity.Text == "")
                    {
                        txtShipCity.Focus();
                        lvShipCity.Visible = false;
                    }
                    else
                    {
                        lvShipCity.Focus();
                    }
                    if (lvShipCity.Items.Count > 0)
                    {
                        lvShipCity.Items[0].Selected = true;
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

        private void txtShipCity_Leave(object sender, EventArgs e)
        {
            try
            {
                txtShipCity.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipCity_TextChanged(object sender, EventArgs e)
        {
            try
            {

                lvShipCity.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtShipCity.Text.Length > 0)
                {
                    objDs = objspdservice.udfnCitylist(1, txtShipCity.Text, Convert.ToInt32(cmbShipState.SelectedValue), 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString(), objDs.Tables[0].Rows[i]["ST_TIN"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvShipCity.Items.Add(objList);
                                }
                                lvShipCity.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvShipCity.Visible = false;
                    lvShipCity.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipPincode_Enter(object sender, EventArgs e)
        {
            try
            {
                lvShipCity.Visible = false;
                txtShipPincode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipPincode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtShipPincode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtShipPincode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtShipPincode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipLandmark_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLandmark.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShipLandmark_KeyDown(object sender, KeyEventArgs e)
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

        private void txtShipLandmark_Leave(object sender, EventArgs e)
        {
            try
            {
                txtShipLandmark.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvShipCity_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnShipCityBind();
                txtShipPincode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvShipCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnShipCityBind();
                    txtShipPincode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnShipCityBind()
        {
            try
            {
                if (txtShipCity.Text != "")
                {
                    ListViewItem selectedItem = lvShipCity.SelectedItems[0];
                    txtShipCity.Text = selectedItem.SubItems[0].Text;
                    lblShipCityId.Text = selectedItem.SubItems[2].Text;
                    lvShipCity.Visible = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvShipCity.Visible = false;
            }
        }

        private void chkSameasBilling_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                udfnShippingBind(chkSameasBilling.Checked);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnShippingBind(bool isSameAsBilling)
        {
            try
            {
                if (isSameAsBilling)
                {
                    // Copy billing values to shipping
                    txtShipaddress1.Text = txtaddress1.Text.Trim();
                    txtShipaddress2.Text = txtaddress2.Text.Trim();
                    cmbShipState.SelectedValue = cmbState.SelectedValue;
                    txtShipArea.Text = txtArea.Text.Trim();
                    txtShipCity.Text = txtCity.Text.Trim();
                    lblShipAreaId.Text = lblAreaId.Text.Trim();
                    lblShipCityId.Text = lblCityId.Text.Trim();
                    txtShipPincode.Text = txtPincode.Text.Trim();
                    txtShipLandmark.Text = txtLandmark.Text.Trim();
                    lvShipArea.Visible = false;
                    lvShipCity.Visible = false;
                }
                else
                {
                    // Clear shipping values
                    txtShipaddress1.Text = "";
                    txtShipaddress2.Text = "";
                    cmbShipState.SelectedValue = -1;
                    txtShipArea.Text = "";
                    txtShipCity.Text = "";
                    lblShipAreaId.Text = "0";
                    lblShipCityId.Text = "0";
                    txtShipPincode.Text = "";
                    txtShipLandmark.Text = "";
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

        private void CP_Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varUpdate == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void rbCash_Enter(object sender, EventArgs e)
        {
            try
            {
                rbCash.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOBAmt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbCash_Leave(object sender, EventArgs e)
        {
            try
            {
                rbCash.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbCredit_Enter(object sender, EventArgs e)
        {
            try
            {
                rbCredit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbCredit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCreditLimit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbCredit_Leave(object sender, EventArgs e)
        {
            try
            {
                rbCredit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOBAmt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOBAmt.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOBAmt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOBType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOBAmt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtOBAmt.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtCreditLimit.Text = "";
                txtCreditDays.Text = "";
                txtTotalInvoice.Text = "";
                txtOBAmt.Text = "";
                txtGSTIN.Text = "";

                txtCreditLimit.Enabled = false;
                txtCreditDays.Enabled = false;
                txtTotalInvoice.Enabled = false;
                txtOBAmt.Enabled = false;
                cmbOBType.Enabled = false;
                txtGSTIN.Enabled = false;

                txtCreditLimit.ReadOnly = true;
                txtCreditDays.ReadOnly = true;
                txtTotalInvoice.ReadOnly = true;
                txtOBAmt.ReadOnly = true;
                txtGSTIN.ReadOnly = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbCredit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtCreditLimit.Enabled = true;
                txtCreditDays.Enabled = true;
                txtTotalInvoice.Enabled = true;
                txtOBAmt.Enabled = true;
                cmbOBType.Enabled = true;
                txtGSTIN.Enabled = true;

                txtCreditLimit.ReadOnly = false;
                txtCreditDays.ReadOnly = false;
                txtTotalInvoice.ReadOnly = false;
                txtOBAmt.ReadOnly = false;
                txtGSTIN.ReadOnly = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTotalInvoice_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTotalInvoice.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTotalInvoice_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTotalInvoice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalInvoice_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTotalInvoice.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnAreaEvent();
                    txtPincode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvArea_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnAreaEvent();
                txtPincode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAreaEvent()
        {
            try
            {
                if (txtArea.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvArea.SelectedItems[0];
                    txtArea.Text = selectedItem.SubItems[0].Text;
                    txtCity.Text = selectedItem.SubItems[1].Text;
                    lblAreaId.Text = selectedItem.SubItems[3].Text;
                    lblCityId.Text = selectedItem.SubItems[4].Text;
                    cmbState.SelectedValue = Convert.ToInt32(selectedItem.SubItems[5].Text);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvArea.Visible = false;
            }
        }

        private void lvShipArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnShipAreaEvent();
                    txtShipPincode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvShipArea_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnShipAreaEvent();
                txtShipPincode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnShipAreaEvent()
        {
            try
            {
                if (txtShipArea.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvShipArea.SelectedItems[0];
                    txtShipArea.Text = selectedItem.SubItems[0].Text;
                    txtShipCity.Text = selectedItem.SubItems[1].Text;
                    lblShipAreaId.Text = selectedItem.SubItems[3].Text;
                    lblShipCityId.Text = selectedItem.SubItems[4].Text;
                    cmbShipState.SelectedValue= Convert.ToInt32(selectedItem.SubItems[5].Text);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvShipArea.Visible = false;
            }
        }
        private void btnSave_Leave(object sender, EventArgs e)
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
        public void udfnEdit()
        {
            try
            {
                if (pbCustomerId != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();
                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 1;
                    obj.paraCustomerId = pbCustomerId;
                    obj.paraStatusId = 0;
                    objDs = objspservice.udfnCustomerList(obj);
                    if (objDs != null)
                    {
                        if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = objDs.Tables[0].Rows[0];

                            txtCustomerName.Text = dr["CUS_Name"].ToString();
                            txtReferenceName.Text = dr["CUS_ReferenceName"].ToString();
                            txtContactNo.Text = dr["CUS_ContactNo"].ToString();
                            txtWhatsappNo.Text = dr["CUS_WhatsappNo"].ToString();
                            cmbCustomerType.SelectedValue = Convert.ToInt32(dr["CUS_CategoryTypeID"]);

                            int cusType = Convert.ToInt32(dr["CUS_CusTypeID"]);
                            if (cusType == 326)
                            {
                                rbCash.Checked = true;
                            }
                            else if (cusType == 327)
                            {
                                rbCredit.Checked = true;
                            }
                            if (cusType == 326)
                            {
                                txtCreditLimit.Text = dr["CUS_Credit_Limit"].ToString();
                                txtCreditDays.Text = dr["CUS_CreditDays"].ToString();
                                txtTotalInvoice.Text = dr["CUS_TotalInvoice"].ToString();
                                txtOBAmt.Text = dr["CUS_OpeningBalance"].ToString();
                                cmbOBType.SelectedValue = Convert.ToInt32(dr["CUS_OpeningBalanceType"]);
                                txtGSTIN.Text = dr["CUS_GSTIN"].ToString();
                            }
                            txtaddress1.Text = dr["CUS_Billing_Address1"].ToString();
                            txtaddress2.Text = dr["CUS_Billing_Address2"].ToString();
                            txtArea.Text = dr["BillArea"].ToString();
                            txtCity.Text = dr["BillCity"].ToString();
                            lblAreaId.Text = dr["CUS_Billing_AID"].ToString();
                            lblCityId.Text = dr["CUS_Billing_CTYID"].ToString();
                            cmbState.SelectedValue = Convert.ToInt32(dr["CUS_Billing_STID"]);
                            txtPincode.Text = dr["CUS_Billing_Pincode"].ToString();
                            txtLandmark.Text = dr["CUS_Billing_Landmark"].ToString();

                            txtShipaddress1.Text = dr["CUS_Shipping_Address1"].ToString();
                            txtShipaddress2.Text = dr["CUS_Shipping_Address2"].ToString();
                            txtShipArea.Text = dr["ShipArea"].ToString();
                            txtShipCity.Text = dr["ShipCity"].ToString();
                            lblShipAreaId.Text = dr["CUS_Shipping_AID"].ToString();
                            lblShipCityId.Text = dr["CUS_Shipping_CTYID"].ToString();
                            cmbShipState.SelectedValue = Convert.ToInt32(dr["CUS_Shipping_STID"]);
                            txtShipPincode.Text = dr["CUS_Shipping_Pincode"].ToString();
                            txtShipLandmark.Text = dr["CUS_Shipping_Landmark"].ToString();

                            lvArea.Visible = false;
                            lvShipArea.Visible = false;
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
    }
}
