using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_Supplier : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;
        DataTable dtSubGroup = new DataTable();
        DataTable dtPurProducts = new DataTable();
        DataTable dtPurMappedProducts = new DataTable();
        DataTable dtSubGroupMapping = new DataTable();
        DataTable dtPaymentMode = new DataTable();
        Boolean BlnSearchImageYN = false;

        public int SearchFlag = 0;
        public string varcompanycode;
        public int pbFormStatus = 0;
        public string varstatecode = "", varupdate = "0", vardays = "", varUserID = "", varCityname = "";
        public int varOrderid = 0, scheduleselectedIndex = -1;
        public int varBrandId = 0;
        public int varGroupId = 0;
        public int varSubGroupId = 0, varSLNO = 0;
        public int varPurGroupId = 0, varPurSubgroupId = 0, varPurBrandId = 0;
        public int varModifiedFlag = 0;
        public int PoScheduleFlag = 0;
        public int varSupplierStatusID = 0, varPurchaseSPID = 0, varDiscDays = 0, varDiscPer = 0;
        //tool tip
        private ToolTip tpContactNo = new ToolTip();
        private ToolTip tpAltContactNo = new ToolTip();
        private ToolTip tpemail = new ToolTip();
        private ToolTip tpgstin = new ToolTip();
        private ToolTip tpfssai = new ToolTip();
        private ToolTip tpplno = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpshortname = new ToolTip();
        private ToolTip tpDays = new ToolTip();
        private ToolTip tpDiscPer = new ToolTip();
        private ToolTip tpPaymentStaus = new ToolTip();
        private ToolTip tppincode = new ToolTip();
        private ToolTip tpcity = new ToolTip();
        private ToolTip tparea = new ToolTip();
        private ToolTip tpstate = new ToolTip();
        private ToolTip tpDrCompany = new ToolTip();
        private ToolTip tpCrCompany = new ToolTip();
        private ToolTip tpTaxableAmt = new ToolTip();
        private ToolTip tpTaxAmt = new ToolTip();

        private ToolTip tpcredit = new ToolTip();
        private ToolTip tpopening = new ToolTip();
        private ToolTip tpsalesman = new ToolTip();
        private ToolTip tpsalemanph = new ToolTip();
        private ToolTip tpgst = new ToolTip();
        private ToolTip tpname = new ToolTip();
        private ToolTip tpInvoiceNo = new ToolTip();
        private ToolTip tpInvoiceAmt = new ToolTip();
        private ToolTip tpTallyName = new ToolTip();
        private ToolTip tpschedule = new ToolTip();
        private ToolTip tpPayment = new ToolTip();

        private ToolTip tpBankName = new ToolTip();
        private ToolTip tpBankShortName = new ToolTip();
        private ToolTip tpBranchName = new ToolTip();
        private ToolTip tpAccountNo = new ToolTip();
        private ToolTip tpIfsCode = new ToolTip();
        public int SupplierUpdate = 0, vardayMonthID = 0, varWeekID = 0, vardayID = 0, varrecyclecode = 0, varMonthID = 0, varMasterid = 0, varProCount = 0,
            varMappedCount = 0, varScheduleStsCount = 0;
        public string pbSupplierid = "0", varstatusid = "0", varsupplierID = "0", varTINNo = "0";
        string varfirstValue = "", varsecValue = "";
        DataSet objDTBank = new DataSet();
        DataTable dtOpeningCRDetails = new DataTable();
        DataTable dtStatus = new DataTable();
        public CP_Supplier()
        {
            InitializeComponent();
        }

        private void txtcontactName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtcontactName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtcontactName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtcreditlimit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtcontactName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtcontactName.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


        }
        public void udfnLvHide()
        {
            try
            {
                lvMappingGroup.Visible = false;
                lvMappingSubGroup.Visible = false;
                lvBrand.Visible = false;
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
            if (txtCity.Text == "")
            {

                errCompany.SetError(txtCity, "Please enter city name");
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
                try
                {
                    //if (txtContactNumber.Text != "")
                    //{
                    //    if (txtContactNumber.Text.Length < 10)
                    //    {
                    //        errCompany.SetError(txtContactNumber, "Please enter valid phone No.");
                    //        txtContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //        tpContactNo.ShowAlways = true;
                    //        tpContactNo.Show("Please enter valid phone No.", txtContactNumber, 5000);
                    //    }
                    //    else
                    //    {
                    //        errCompany.Clear();
                    //        txtContactNumber.BackColor = Color.White;
                    //        tpContactNo.Hide(txtContactNumber);
                    //    }
                    //}
                    //else if (txtContactNumber.Text == "")
                    //{
                    txtContactNumber.BackColor = Color.White;
                    //}
                    //else if (txtContactNumber.Text == "")
                    //{
                    //    errCompany.SetError(txtContactNumber, "Please enter phone No.");
                    //    txtContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpContactNo.ShowAlways = true;
                    //    tpContactNo.Show("Please enter phone No.", txtContactNumber, 5000);
                    //}
                    //else
                    //{
                    //    errCompany.Clear();
                    //    txtContactNumber.BackColor = Color.White;
                    //    tpContactNo.Hide(txtContactNumber);
                    //}

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

        private void txtAContactNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtAContactNumber.Text != "")
                {
                    if (txtAContactNumber.Text.Length < 10)
                    {
                        errCompany.SetError(txtAContactNumber, "Please enter valid mobile No.");
                        txtAContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpAltContactNo.ShowAlways = true;
                        tpAltContactNo.Show("Please enter valid mobile No.", txtAContactNumber, 5000);
                    }

                    else
                    {
                        errCompany.Clear();
                        txtAContactNumber.BackColor = Color.White;
                        tpAltContactNo.Hide(txtAContactNumber);
                    }
                }
                else if (txtAContactNumber.Text == "")
                {
                    txtAContactNumber.BackColor = Color.White;
                }
                //else if (txtAContactNumber.Text == "")
                //{
                //    errCompany.SetError(txtAContactNumber, "Please enter mobile No.");
                //    txtAContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpAltContactNo.ShowAlways = true;
                //    tpAltContactNo.Show("Please enter mobile No.", txtAContactNumber, 5000);
                //}

                //else
                //{
                //    errCompany.Clear();
                //    txtAContactNumber.BackColor = Color.White;
                //    tpAltContactNo.Hide(txtAContactNumber);
                //}

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
                    cmbDesignation.Focus();
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


                if (Convert.ToString(txtEmail.Text).Trim() == "")
                {
                    txtEmail.BackColor = Color.White;
                    //errCompany.SetError(txtEmail, "Please enter email");
                    //txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //tpemail.ShowAlways = true;
                    //tpemail.Show("Please enter email", txtEmail, 5000);
                }
                else if (objvalidation.FormatEMail(txtEmail.Text) == false)
                {
                    errCompany.SetError(txtEmail, "Please enter valid email");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpemail.ShowAlways = true;
                    tpemail.Show("Please enter valid email", txtEmail, 5000);
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
            try
            {
                udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void udfnSave()
        {
            try
            {
                btnSave.Enabled = false;
                varfirstValue = "";
                varsecValue = "";   
                bool blnErrorFlag = false;
                if (txtContactNumber.Text.Trim() == "" && txtAContactNumber.Text.Trim() == "" && txtwhatsapp.Text.Trim() == "")
                {
                    errCompany.SetError(txtContactNumber, "Please enter phone No.");
                    txtContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpContactNo.ShowAlways = true;
                    tpContactNo.Show("Please enter phone No.", txtContactNumber, 5000);
                    blnErrorFlag = true;
                }
                if (txtName.Text.Trim() == "")
                {
                    errCompany.SetError(txtName, "Please enter the name");
                    txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpname.ShowAlways = true;
                    tpname.Show("Please enter the name.", txtName, 5000);
                    blnErrorFlag = true;
                }
                if (txtTalllyName.Text.Trim() == "")
                {
                    errCompany.SetError(txtTalllyName, "Please enter tally name");
                    txtTalllyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTallyName.ShowAlways = true;
                    tpTallyName.Show("Please enter tally name.", txtTalllyName, 5000);
                    blnErrorFlag = true;
                }
                if (txtSPShortName.Text.Trim() == "")
                {
                    errCompany.SetError(txtSPShortName, "Please enter the short name");
                    txtSPShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpshortname.ShowAlways = true;
                    tpshortname.Show("Please enter the short name.", txtSPShortName, 5000);
                    blnErrorFlag = true;
                }
                //if(Convert.ToInt32(cmbPaymentDisc.SelectedValue)==229)
                //{
                //    if(txtDays.Text=="")
                //    {
                //        errCompany.SetError(txtDays, "Please enter the days");
                //        txtDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpDays.ShowAlways = true;
                //        tpDays.Show("Please enter the days", txtDays, 5000);
                //        blnErrorFlag = true;
                //    }
                //    if (txtDiscountPer.Text=="")
                //    {
                //        errCompany.SetError(txtDiscountPer, "Please enter the discount percentage");
                //        txtDiscountPer.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpDiscPer.ShowAlways = true;
                //        tpDiscPer.Show("Please enter the discount percentage", txtDiscountPer, 5000);
                //        blnErrorFlag = true;
                //    }

                //}
                if (txtArea.Text.Trim() == "")
                {
                    errCompany.SetError(txtArea, "Please enter Address");
                    txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter Address.", txtArea, 5000);
                    blnErrorFlag = true;
                }
                if (txtCity.Text == "")
                {
                    errCompany.SetError(txtCity, "Please enter city name");
                    txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcity.ShowAlways = true;
                    tpcity.Show("Please enter city name.", txtCity, 5000);
                    blnErrorFlag = true;
                }
                if (txtDiscountPer.Text.Trim() != "")
                {
                    if (Convert.ToInt32(txtDiscountPer.Text) > 100)
                    {
                        errCompany.SetError(txtDiscountPer, "Please enter valid discount percentage");
                        txtDiscountPer.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpDiscPer.ShowAlways = true;
                        tpDiscPer.Show("Please enter valid discount percentage", txtDiscountPer, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtDays.Text.Trim() != "")
                {
                    if (Convert.ToInt32(txtDays.Text) > 10)
                    {
                        errCompany.SetError(txtDays, "Please enter valid days");
                        txtDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpDays.ShowAlways = true;
                        tpDays.Show("Please enter valid days", txtDays, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbState, "Please Select State Name");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please Select State Name", cmbState, 5000);
                    blnErrorFlag = true;
                }
                if (txtPincode.Text.Trim() == "")
                {
                    errCompany.SetError(txtPincode, "Please enter pincode");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppincode.ShowAlways = true;
                    tppincode.Show("Please enter pincode.", txtPincode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbSupplierType.SelectedValue) == "" || Convert.ToString(cmbSupplierType.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbSupplierType, "Please Select Supplier Type");
                    cmbSupplierType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please Select Payment Supplier Type", cmbSupplierType, 5000);
                    blnErrorFlag = true;
                }
                if (txtgstin.Text.Trim() == "" && txtgstin.Enabled == true)
                {
                    errCompany.SetError(txtgstin, "Please enter supplier GSTIN");
                    txtgstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpgst.ShowAlways = true;
                    tpgst.Show("Please enter supplier GSTIN.", txtgstin, 5000);
                    blnErrorFlag = true;
                }
                if (txtgstin.Text.Trim() != "")
                {
                    string varGSTIN = txtgstin.Text;
                    varfirstValue = Convert.ToString(varGSTIN[0]);
                    varsecValue = Convert.ToString(varGSTIN[1]);
                    if (varfirstValue != Convert.ToString(varTINNo[0]) || varsecValue != Convert.ToString(varTINNo[1]))
                    {
                        errCompany.SetError(txtgstin, "Invalid GSTIN");
                        txtgstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpgst.ShowAlways = true;
                        tpgst.Show("Invalid GSTIN", txtgstin, 5000);
                        blnErrorFlag = true;
                    }
                }
                //if (txtgstin.Text  && txtgstin.Enabled == true)
                //{
                //    errCompany.SetError(txtgstin, "Please enter supplier GSTIN");
                //    txtgstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpgst.ShowAlways = true;
                //    tpgst.Show("Please enter supplier GSTIN.", txtgstin, 5000);
                //    blnErrorFlag = true;
                //}
                //if (txtContactNumber.Text != "")
                //{
                //    if (txtContactNumber.Text.Length < 10)
                //    {
                //        errCompany.SetError(txtContactNumber, "Please enter valid phone No.");
                //        txtContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpContactNo.ShowAlways = true;
                //        tpContactNo.Show("Please enter valid phone No.", txtContactNumber, 5000);
                //        blnErrorFlag = true;
                //    }
                //}
                if (txtPincode.Text.Trim() != "")
                {
                    if (txtPincode.Text.Length < 6)
                    {
                        errCompany.SetError(txtPincode, "Please enter valid pincode");
                        txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppincode.ShowAlways = true;
                        tppincode.Show("Please enter valid pincode.", txtPincode, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtwhatsapp.Text.Trim() != "")
                {
                    if (txtwhatsapp.Text.Length < 10)
                    {

                        errCompany.SetError(txtwhatsapp, "Please enter valid whatsapp No.");
                        txtwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpContactNo.ShowAlways = true;
                        tpContactNo.Show("Please enter valid whatsapp No.", txtwhatsapp, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtAContactNumber.Text.Trim() != "")
                {
                    if (txtAContactNumber.Text.Length < 10)
                    {
                        errCompany.SetError(txtAContactNumber, "Please enter valid mobile No.");
                        txtAContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpAltContactNo.ShowAlways = true;
                        tpAltContactNo.Show("Please enter valid mobile No.", txtAContactNumber, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtgstin.Text.Trim() != "")
                {
                    if (txtgstin.Text.Length < 15)
                    {
                        errCompany.SetError(txtgstin, "Please enter valid supplier GSTIN");
                        txtgstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpgst.ShowAlways = true;
                        tpgst.Show("Please enter valid supplier GSTIN.", txtgstin, 5000);
                        blnErrorFlag = true;
                    }
                }
                //if(cmbPaymentDisc.Text=="")
                //{
                //    errCompany.SetError(txtgstin, "Please select payment discount");
                //    cmbPaymentDisc.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPayment.ShowAlways = true;
                //    tpPayment.Show("Please select payment discount", cmbPaymentDisc, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(txtCity.Text) != "")
                {
                    if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                    {
                        errCompany.SetError(cmbState, "Please Select State Name");
                        cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpstate.ShowAlways = true;
                        tpstate.Show("Please Select State Name", cmbState, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        errCompany.Clear();
                        cmbState.BackColor = Color.White;
                        string VarCity = "0";
                        //DataService objDserv = new DataService();
                        //VarCity = objDserv.displaydata("SELECT COUNT(*) FROM MR_CITY WHERE CTY_NAME='" + txtCity.Text + "'");
                        DataSet objDsCity = new DataSet();
                        SPDataService objDserv = new SPDataService();
                        objDsCity = objDserv.udfnCitylist(1, txtCity.Text.Trim(), Convert.ToInt32(cmbState.SelectedValue), 0);
                        objDserv.CloseConnection();
                        if (objDsCity != null)
                        {
                            if (objDsCity.Tables.Count > 0)
                            {
                                if (objDsCity.Tables[0].Rows.Count > 0)
                                {
                                    VarCity = Convert.ToString(objDsCity.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        if (VarCity == "0" || VarCity == "-1")
                        {
                            lblcityid.Text = "0";
                            errCompany.SetError(txtCity, "Invalid city");
                            txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpcity.ShowAlways = true;
                            tpcity.Show("Invalid city", txtCity, 5000);
                            blnErrorFlag = true;
                        }
                        else
                        {
                            lblcityid.Text = VarCity;
                        }
                    }

                }
                if (Convert.ToString(txtEmail.Text) != "")
                {
                    if (objvalidation.FormatEMail(txtEmail.Text) == false)
                    {
                        errCompany.SetError(txtEmail, "Please enter valid email");
                        txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpemail.ShowAlways = true;
                        tpemail.Show("Please enter valid email", txtEmail, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (blnErrorFlag == false)
                {
                    udfntphide();
                    SPDataService objspdservice = new SPDataService();
                    string result = "";
                    string varStatus = "1";
                    errCompany.Clear();
                    udfncolorchange();

                    int cityid = 0; string varpincode = "";
                    double creditlimit = 0, openingvalue = 0;
                    if (lblcityid.Text == "")
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

                    if (txtOpeningAmt.Text == "")
                    {
                        openingvalue = 0;
                    }
                    else
                    {
                        openingvalue = Convert.ToDouble(txtOpeningAmt.Text);
                    }

                    if (txtcreditlimit.Text == "")
                    {
                        creditlimit = 0;
                    }
                    else
                    {
                        creditlimit = Convert.ToDouble(txtcreditlimit.Text);
                    }

                    if (rbActive.Checked == true)
                    {
                        varStatus = "1";
                    }
                    else
                    {
                        varStatus = "2";
                    }
                    if (varSupplierStatusID == 98)
                    {
                        varStatus = "98";
                    }
                    SupplierUpdate = 0;
                    if (Convert.ToInt32(varsupplierID) != 0)
                    {
                        SupplierUpdate = Convert.ToInt32(varsupplierID);
                    }
                    else
                    {
                        SupplierUpdate = Convert.ToInt32(pbSupplierid);
                    }
                    string varorginator = "", varpaymentmethod = "";
                    int varviewtype = 0, varretuencycle = 0, varreturnapplicable = -1;
                    if (btnSave.Text == "Save")
                    {
                        varviewtype = 0;
                        varorginator = "Supplier Create";
                        //varretuencycle = 24;
                        //varreturnapplicable = 22;
                        varreturnapplicable = Convert.ToInt32(cmbReturnPolicy.SelectedValue);
                        varretuencycle = Convert.ToInt32(cmbReturnType.SelectedValue);
                    }
                    else
                    {
                        varviewtype = 1;
                        varorginator = "Supplier Update";
                    }

                    for (int i = 0; i < grdPaymentMode.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdPaymentMode.Rows[i].Cells[0].Value) == true)
                        {
                            if (varpaymentmethod == "")
                            {
                                varpaymentmethod = Convert.ToString(grdPaymentMode.Rows[i].Cells["MSTID"].Value);
                            }
                            else
                            {
                                varpaymentmethod = varpaymentmethod + ',' + Convert.ToString(grdPaymentMode.Rows[i].Cells["MSTID"].Value);
                            }

                        }
                    }
                    if (txtDays.Text == "")
                    {
                        varDiscDays = 0;
                    }
                    else
                    {
                        varDiscDays = Convert.ToInt32(txtDays.Text);
                    }
                    if (txtDiscountPer.Text == "")
                    {
                        varDiscPer = 0;
                    }
                    else
                    {
                        varDiscPer = Convert.ToInt32(txtDiscountPer.Text);
                    } 
                    result = objspdservice.udfnSupplierMaster(varviewtype, SupplierUpdate, txtName.Text, txtArea.Text, txtaddress2.Text, Convert.ToInt32(cityid)
                   , varpincode, txtContactNumber.Text, txtwhatsapp.Text, txtAContactNumber.Text, txtEmail.Text, txtgstin.Text,
                   Convert.ToInt32(cmbPaymentTerm.SelectedValue), varreturnapplicable, varretuencycle, Convert.ToInt32(cmbOpeningType.SelectedValue), openingvalue, Convert.ToInt32(cmbSupplierType.SelectedValue), Convert.ToInt32(cmbState.SelectedValue), varStatus,
                   MainForm.pbUserID, MainForm.pbIpAddress, varorginator, Convert.ToInt32(cmbDesignation.SelectedValue), txtcontactName.Text, creditlimit, -1, -1, -1, -1, "",
                   "", "", "", 0, "", 0, 0, "",  txtbranchname.Text, txtAccno.Text, txtIFScode.Text, txtAccName.Text, "", varpaymentmethod, 0, txtSPShortName.Text, 0, 0, 0, Convert.ToInt32(varDiscDays), Convert.ToInt32(varDiscPer), 0, 0, txtTalllyName.Text.Trim(),"",Convert.ToInt16(cmbBankName.SelectedValue),dtOpeningCRDetails,
                   Convert.ToInt16(cmbDrCompany.SelectedValue));

                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //picLoader.Visible = true;
                        //picLoader.BringToFront();
                        //Application.DoEvents();
                        //this.ActiveControl = tcSupplier;
                        //tcSupplier.SelectedIndex = 1;
                        //MainForm.objCP_Supplierlist.udfnList();
                        //udfnclear();
                        //txtName.Focus();
                        if (btnSave.Text == "Update")
                        {
                            varupdate = "1";
                            txtsuppliername.Text = txtName.Text;
                            txtSupplier.Text = txtName.Text;
                            txtMappedSupplierName.Text = txtName.Text;
                            txtPurSupplierName.Text = txtName.Text;
                            //MainForm.objCP_Supplierlist.udfnList();
                            //this.Close();
                            udfnclose();
                        }
                        else
                        {
                            udfnclear();
                            //MainForm.objCP_Supplierlist.udfnList();
                            btnSave.Text = "Save";
                            pbSupplierid = "0";
                        }
                        //else
                        //{
                        //    varsupplierID = varvalue[2];
                        //}
                        if (tcSupplier.SelectedIndex == 1)
                        {
                            btnSave.Text = "Update";
                            btnSaveOrderType.Text = "Update";
                            txtSupplier.Text = txtName.Text;
                            txtsuppliername.Text = txtName.Text;
                            txtMappedSupplierName.Text = txtName.Text;
                            txtPurSupplierName.Text = txtName.Text;
                        }

                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Focus();
            }
        }
        public void udfntphide()
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
                tppincode.Active = false;
                tparea.Active = false;
                tpstate.Active = false;
                tpBankName.Active = false;
                tpBankShortName.Active = false;
                tpBranchName.Active = false;
                tpAccountNo.Active = false;
                tpIfsCode.Active = false;
                tpcredit.Active = false;
                tpopening.Active = false;
                tpsalesman.Active = false;
                tpsalemanph.Active = false;
                tpgst.Active = false;
                tpname.Active = false;
                tpschedule.Active = false;
                tpInvoiceAmt.Active = false;
                tpInvoiceNo.Active = false;
                tpCrCompany.Active = false;
                tpDrCompany.Active = false;
                cmbTat.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfncolorchange()
        {
            try
            {
                txtName.BackColor = Color.White;
                txtArea.BackColor = Color.White;
                txtaddress2.BackColor = Color.White;
                cmbState.BackColor = Color.White;
                txtCity.BackColor = Color.White;
                txtPincode.BackColor = Color.White;
                txtAContactNumber.BackColor = Color.White;
                txtContactNumber.BackColor = Color.White;
                txtwhatsapp.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                cmbDesignation.BackColor = Color.White;
                cmbSupplierType.BackColor = Color.White;
                cmbPaymentTerm.BackColor = Color.White;
                txtgstin.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnScheduleClear()
        {
            try
            {
                txtsalesmanname.Text = "";
                txtsalesmanmobile.Text = "";
                txtsalesmanwhatsapp.Text = "";
                txtScheduleName.Text = "";
                cmbOrderType.SelectedValue = -1;
                foreach (DataGridViewRow row in grddays.Rows)
                {
                    row.Cells[0].Value = false;
                }
                errCompany.Clear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnSchedulecolorchange()
        {
            try
            {
                txtsalesmanname.BackColor = Color.White;
                txtsalesmanmobile.BackColor = Color.White;
                txtsalesmanwhatsapp.BackColor = Color.White;
                txtScheduleName.BackColor = Color.White;
                cmbOrderType.BackColor = Color.White;
                errCompany.Clear();
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
                txtName.Text = "";
                txtSPShortName.Text = "";
                txtArea.Text = "";
                txtaddress2.Text = "";
                cmbState.SelectedIndex = 27;
                txtCity.Text = "";
                txtPincode.Text = "";
                txtContactNumber.Text = "";
                txtAContactNumber.Text = "";
                txtwhatsapp.Text = "";
                txtEmail.Text = "";
                cmbDesignation.SelectedIndex = 0;
                txtcontactName.Text = "";
                txtcontactName.Text = "";
                txtopening.Text = "";
                cmbSupplierType.SelectedIndex = 0;
                txtcreditlimit.Text = "";
                cmbfinance.SelectedIndex = 0;
                txtgstin.Text = "";
                cmbPaymentTerm.SelectedIndex = 0;
                txtAccName.Text = "";
                txtAccno.Text = "";
                txtbranchname.Text = "";
                cmbBankName.SelectedValue = -1;
                txtBankShortName.Text = "";
                txtIFScode.Text = "";
                txtDays.Text = "";
                txtDiscountPer.Text = "";
                cmbPaymentDisc.SelectedValue = 228;
                BindDataGrid();
                txtName.Focus();
                for (int i = 0; i < grdPaymentMode.Rows.Count; i++)
                {
                    grdPaymentMode.Rows[i].Cells[0].Value = false;
                }
                txtInvoiceNo.Text = "";
                txtInvoiceAmt.Text = "";
                dpInvoiceDate.Text = Convert.ToString(MainForm.pbCurrentDate);
                udfnSumOpeningAmt();
                grdOpeningCrDetails.Rows.Clear();
                dtOpeningCRDetails.Rows.Clear();
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
                if (PoScheduleFlag == 1 || varModifiedFlag == 2)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objPUR_SupplierScheduleList.udfnList();
                    }
                    PoScheduleFlag = 0;
                    varModifiedFlag = 2;

                }
                if (varModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objCP_Supplierlist.Show();
                        MainForm.objCP_Supplierlist.udfnList();
                    }
                    else
                    { btnMappingsave.Focus(); }
                }
                else if (varModifiedFlag == 0)
                {
                    if (varupdate == "1")
                    {
                        this.Close();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    MainForm.objCP_Supplierlist.udfnList();
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

            finally
            {
                //if (varMasterid == 0)
                //{
                //    MainForm.objCP_Supplierlist.grdSupplierList.ClearSelection();
                //}
                //else
                //{
                //    MainForm.objPUR_SupplierScheduleList.dgvSupplierScheduleList.ClearSelection();
                //}
            }
        }


        private void CP_Supplier_Load(object sender, EventArgs e)
        {
            try
            {
                dtSubGroup = new DataTable();
                dtSubGroup.Columns.Add("", typeof(Boolean));
                dtSubGroup.Columns.Add("S.No.", typeof(string));
                dtSubGroup.Columns.Add("P.I Code", typeof(string));
                dtSubGroup.Columns.Add("Product Name in Tamil", typeof(string));
                dtSubGroup.Columns.Add("Unit", typeof(string));
                dtSubGroup.Columns.Add("Brand", typeof(string));
                dtSubGroup.Columns.Add("Product SubGroup", typeof(string));
                dtSubGroup.Columns.Add("Product Group", typeof(string));
                dtSubGroup.Columns.Add("GROUPID", typeof(int));
                dtSubGroup.Columns.Add("SUBGROUPID", typeof(int));
                dtSubGroup.Columns.Add("PRODUCTID", typeof(int));
                dtSubGroup.Columns.Add("Product Name in English", typeof(string));
                dtSubGroup.Columns.Add("MappedCount", typeof(int));


                dtPurProducts = new DataTable();
                dtPurProducts.Columns.Add("", typeof(Boolean));
                dtPurProducts.Columns.Add("S.No.", typeof(string));
                dtPurProducts.Columns.Add("P.I Code", typeof(string));
                dtPurProducts.Columns.Add("Product Name in Tamil", typeof(string));
                dtPurProducts.Columns.Add("Unit", typeof(string));
                dtPurProducts.Columns.Add("Brand", typeof(string));
                dtPurProducts.Columns.Add("Product SubGroup", typeof(string));
                dtPurProducts.Columns.Add("Product Group", typeof(string));
                dtPurProducts.Columns.Add("GROUPID", typeof(int));
                dtPurProducts.Columns.Add("SUBGROUPID", typeof(int));
                dtPurProducts.Columns.Add("PRODUCTID", typeof(int));
                dtPurProducts.Columns.Add("Product Name in English", typeof(string));
                dtPurProducts.Columns.Add("MappedCount", typeof(int));


                dtPaymentMode = new DataTable();
                dtPaymentMode.Columns.Add("", typeof(Boolean));
                dtPaymentMode.Columns.Add("DisplayText", typeof(string));
                dtPaymentMode.Columns.Add("MSTID", typeof(int));

                dtOpeningCRDetails = new DataTable();
                dtOpeningCRDetails.Columns.Add("SPOBID", typeof(int));
                dtOpeningCRDetails.Columns.Add("SPOB_InvoiceDate", typeof(string));
                dtOpeningCRDetails.Columns.Add("SPOB_InvoiceNo", typeof(string));
                dtOpeningCRDetails.Columns.Add("SPOB_InvoiceAmount", typeof(decimal));
                dtOpeningCRDetails.Columns.Add("SPOB_STSID", typeof(int));
                dtOpeningCRDetails.Columns.Add("SPOB_COMID", typeof(int));
                dtOpeningCRDetails.Columns.Add("SPOB_TaxableAmount", typeof(decimal));
                dtOpeningCRDetails.Columns.Add("SPOB_TaxAmount", typeof(decimal));
                dtOpeningCRDetails.Columns.Add("SPOB_Adjustments", typeof(decimal));

                udfnLoadState();
                udfnBankDropDownLoad();
                udfnCompanyDropDown();
                this.ActiveControl = txtName;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>0 ORDER BY STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (10,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbDesignation, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (11,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (12,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPaymentTerm, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (29,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbfinance, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (73,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPaymentDisc, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (29,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOpeningType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (29,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOBType, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (13,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbMappingordertype, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbMappingordeDay, "", "DY_Name", "DYID");
                cmbState.SelectedValue = 27;
                udfnEdit();
                BeginInvoke(new Action(() => cmbOrderschedule.Select(int.MaxValue, 0)));
                btnListPrint.Image = global::ROMS.Properties.Resources.print;
                if (pbSupplierid == "0")
                {
                    tcSupplier.TabPages[1].Enabled = false; // Second tab
                    tcSupplier.TabPages[2].Enabled = false; // Third tab
                    tcSupplier.TabPages[3].Enabled = false; // Fourth tab
                }
                //tcSupplier.TabPages[4].Enabled = false;
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
        public void udfnBankDropDownLoad()
        {
            try
            {
                objDTBank = null;
                SPDataService objDserv = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Bank objMR_Bank = new MR_Bank();
                objMR_Bank.paraViewType = 2;
                objDs = objDserv.udfnBanklist(objMR_Bank);
                objDserv.CloseConnection();
                cmbBankName.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbBankName.ValueMember = "BNKID";
                            cmbBankName.DisplayMember = "Bank";
                            cmbBankName.DataSource = objDs.Tables[0];
                            objDTBank = objDs;
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
        public void udfnCompanyDropDown()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                int varconcerntype = 3;
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(varconcerntype, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                cmbCrCompany.DataSource = null;
                cmbDrCompany.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbCrCompany.ValueMember = "COMID";
                            cmbCrCompany.DisplayMember = "COM_ShortName";
                            cmbCrCompany.DataSource = objDT.Tables[0];
                            cmbDrCompany.ValueMember = "COMID";
                            cmbDrCompany.DisplayMember = "COM_ShortName";
                            cmbDrCompany.DataSource = objDT.Tables[0];
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
        public void udfnSuppliertypeLoad()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                if (Convert.ToInt16(cmbState.SelectedValue) == 27)
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (11,0) AND MSTID NOT IN (0,151) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                }
                else
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (11,0) AND MSTID  IN (-1,151) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BindDataGrid()
        {
            try
            {
                DataBind objDataBind = new DataBind();

                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (13,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrderType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,47) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbStatus, "", "MST_DisplayText", "MSTID");
                cmborderday.DataSource = null;
                objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmborderday, "", "DY_Name", "DYID");
                objDataBind = null;
                cmbOrderType.SelectedIndex = 0;
                DataSet objDs = new DataSet();
                DataService objdserv = new DataService();
                objDs = objdserv.GetDataset("SELECT DYID,DY_Name from DEF_Days WHERE DYID NOT IN (0,-1)");
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grddays.DataSource = objDs.Tables[0];
                            grddays.Columns["DYID"].Visible = false;
                            grddays.Columns["DY_Name"].Width = 100;
                            grddays.Columns["DY_Name"].ReadOnly = true;
                        }
                    }
                }
                objDs = null;
                objDs = objdserv.GetDataset("SELECT CONCAT(DYID,' ',(SELECT MST_DisplayText FROM DEF_Master WHERE MSTID=17))AS TATNAME,DYID AS TATVALUE  FROM DEF_Days WHERE DYID NOT IN(0,-1)");
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbTat.ValueMember = "TATVALUE";
                            cmbTat.DisplayMember = "TATNAME";
                            cmbTat.DataSource = objDs.Tables[0];
                        }
                    }
                }
                if (btnSave.Text == "Save")
                {
                    cmbPaymentTerm.SelectedValue = 33;
                    cmbReturnPolicy.SelectedIndex = 0;
                    cmbReturnType.SelectedIndex = 0;
                    cmborderday.SelectedIndex = 0;
                    txtReturnText.Visible = false;
                    cmbPolicyContent.Visible = false;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
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
        private void udfnEdit()
        {
            try
            {
                string varReturnTypeID = "";
                int varReturPolicyId = 0;
                if (pbSupplierid != "0")
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (8,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnPolicy, "", "MST_DisplayText", "MSTID");
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (9,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                    //cmbReturnPolicy.SelectedValue = -1;
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 2;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(pbSupplierid);
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS = new DataSet(); ;
                    objDS = objspservice.udfnSupplierList(objMR_Supplier);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtName.Text = objDS.Tables[0].Rows[0]["NAME"].ToString().Replace("''", "'");
                            txtTalllyName.Text = objDS.Tables[0].Rows[0]["TallyName"].ToString().Replace("''", "'");
                            txtSPShortName.Text = objDS.Tables[0].Rows[0]["SP_ShortName"].ToString().Replace("''", "'");
                            txtsuppliername.Text = objDS.Tables[0].Rows[0]["NAME"].ToString().Replace("''", "'");
                            txtSupplier.Text = objDS.Tables[0].Rows[0]["NAME"].ToString().Replace("''", "'");
                            txtMappedSupplierName.Text = objDS.Tables[0].Rows[0]["NAME"].ToString().Replace("''", "'");
                            txtPurSupplierName.Text = objDS.Tables[0].Rows[0]["NAME"].ToString().Replace("''", "'");
                            txtArea.Text = objDS.Tables[0].Rows[0]["ADDRESS1"].ToString().Replace("''", "'");
                            txtaddress2.Text = objDS.Tables[0].Rows[0]["ADDRESS2"].ToString().Replace("''", "'");
                            cmbState.SelectedValue = objDS.Tables[0].Rows[0]["STATEID"].ToString();
                            txtCity.Text = objDS.Tables[0].Rows[0]["CTYID"].ToString().Replace("''", "'");
                            txtwhatsapp.Text = objDS.Tables[0].Rows[0]["Whatsapp"].ToString().Replace("''", "'");
                            txtPincode.Text = objDS.Tables[0].Rows[0]["PINCODE"].ToString().Replace("''", "'");
                            txtContactNumber.Text = objDS.Tables[0].Rows[0]["PHONE"].ToString().Replace("''", "'");
                            txtAContactNumber.Text = objDS.Tables[0].Rows[0]["MOBILE"].ToString().Replace("''", "'");
                            txtwhatsapp.Text = objDS.Tables[0].Rows[0]["WHATSAPP"].ToString().Replace("''", "'");
                            txtEmail.Text = objDS.Tables[0].Rows[0]["EMAIL"].ToString().Replace("''", "'");
                            cmbDesignation.SelectedValue = objDS.Tables[0].Rows[0]["DESIGNATION"].ToString();
                            txtcontactName.Text = objDS.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString().Replace("''", "'");
                            lblcity.Text = objDS.Tables[0].Rows[0]["CTY"].ToString().Replace("''", "'");
                            txtgstin.Text = objDS.Tables[0].Rows[0]["GSTIN"].ToString();
                            txtcreditlimit.Text = objDS.Tables[0].Rows[0]["CREDIT"].ToString().Replace("''", "'");
                            txtopening.Text = objDS.Tables[0].Rows[0]["OPBALANCE"].ToString().Replace("''", "'");
                            cmbBankName.SelectedValue = objDS.Tables[0].Rows[0]["SP_BNKID"].ToString().Replace("''", "'");
                            txtbranchname.Text = objDS.Tables[0].Rows[0]["SP_BranchName"].ToString().Replace("''", "'");
                            txtAccName.Text = objDS.Tables[0].Rows[0]["SP_AccountName"].ToString().Replace("''", "'");
                            txtAccno.Text = objDS.Tables[0].Rows[0]["SP_AccNo"].ToString().Replace("''", "'");
                            txtBankShortName.Text = objDS.Tables[0].Rows[0]["BankShortName"].ToString().Replace("''", "'");
                            txtIFScode.Text = objDS.Tables[0].Rows[0]["SP_IFSC"].ToString().Replace("''", "'");
                            txtOtherBrands.Text = objDS.Tables[0].Rows[0]["SP_Brand"].ToString().Replace("''", "'");
                            varTINNo = objDS.Tables[0].Rows[0]["ST_TIN"].ToString().Replace("''", "'");
                            cmbPaymentDisc.SelectedValue = objDS.Tables[0].Rows[0]["SP_DiscApplicable"].ToString().Replace("''", "'");
                            txtDays.Text = objDS.Tables[0].Rows[0]["SP_DiscDays"].ToString().Replace("''", "'");
                            txtDiscountPer.Text = objDS.Tables[0].Rows[0]["SP_DiscPer"].ToString().Replace("''", "'");
                            //cmbReturnPolicy.SelectedValue = objDS.Tables[0].Rows[0]["RETURN"].ToString();
                            varReturPolicyId = Convert.ToInt32(objDS.Tables[0].Rows[0]["RETURN"].ToString());
                            varReturnTypeID = objDS.Tables[0].Rows[0]["RETURNCYCLEID"].ToString();

                            cmbReturnPolicy.SelectedValue = Convert.ToInt64(varReturPolicyId);
                            cmbReturnType.SelectedValue = varReturnTypeID;
                            //cmbReturnType.SelectedValue = objDS.Tables[0].Rows[0]["RETURNCYCLEID"].ToString();

                            cmbSupplierType.SelectedValue = objDS.Tables[0].Rows[0]["SUPPLIERTYPE"].ToString();
                            cmbPaymentTerm.SelectedValue = objDS.Tables[0].Rows[0]["PAYMENT"].ToString();
                            cmbfinance.SelectedValue = objDS.Tables[0].Rows[0]["OPTYPE"].ToString();
                            cmbOpeningType.SelectedValue = objDS.Tables[0].Rows[0]["OPTYPE"].ToString();
                            cmbOBType.SelectedValue = objDS.Tables[0].Rows[0]["OPTYPE"].ToString();
                            varSupplierStatusID = Convert.ToInt32(objDS.Tables[0].Rows[0]["STS"]);
                            varPurchaseSPID = Convert.ToInt32(objDS.Tables[0].Rows[0]["PUR_SPID"]); 
                            txtOpeningAmt.Text = objDS.Tables[0].Rows[0]["OPBALANCE"].ToString().Replace("''", "'");
                            txtOBAmt.Text = objDS.Tables[0].Rows[0]["OPBALANCE"].ToString().Replace("''", "'");
                            //RETURN
                            //    DAYID
                            //    WEEKID
                            //    MONTHID
                            //    DAYOFMONTHID
                            //    RETURNCYCLEID

                            //if ((Convert.ToString(cmbReturnPolicy.SelectedValue) == "22"))
                            //{
                            //    cmbPolicyContent.SelectedValue = 0;
                            //    cmbSecondLevel.SelectedValue = 0;
                            //}
                            if (txtDays.Text == "0")
                            {
                                txtDays.Text = "";
                            }
                            if (txtDiscountPer.Text == "0")
                            {
                                txtDiscountPer.Text = "";
                            }
                            if (varPurchaseSPID != 0)
                            {
                                txtgstin.Enabled = false;
                                txtgstin.ReadOnly = true;
                                cmbSupplierType.Enabled = false;
                                cmbState.Enabled = false;
                            }
                            if ((Convert.ToString(cmbReturnType.SelectedValue) == "23"))
                            {
                                cmbPolicyContent.SelectedValue = 0;
                                cmbSecondLevel.SelectedValue = 0;
                            }
                            if ((Convert.ToString(cmbReturnType.SelectedValue) == "25"))
                            {
                                cmbPolicyContent.SelectedValue = objDS.Tables[0].Rows[0]["DAYID"].ToString();
                            }
                            if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                            {
                                cmbPolicyContent.SelectedValue = objDS.Tables[0].Rows[0]["WEEKID"].ToString();
                                cmbSecondLevel.SelectedValue = objDS.Tables[0].Rows[0]["DAYID"].ToString();
                            }
                            if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                            {
                                cmbPolicyContent.SelectedValue = objDS.Tables[0].Rows[0]["MONTHID"].ToString();
                                cmbSecondLevel.SelectedValue = objDS.Tables[0].Rows[0]["DAYOFMONTHID"].ToString();
                            }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "1")
                            {
                                rbActive.Checked = true;
                                varSupplierStatusID = 1;
                            }
                            else if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "2")
                            {
                                rbInactive.Checked = true;
                                varSupplierStatusID = 2;
                            }
                            else
                            {
                                rbInactive.Checked = true;
                                varSupplierStatusID = 98;
                            }

                            btnSave.Text = "Update";
                            panelStatus.Enabled = true;
                        }
                        if (objDS.Tables[1].Rows.Count > 0)
                        {
                            grdSupplierList.DataSource = null;
                            int varschedulenameflag = 0;
                            for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                            {
                                grdSupplierList.Rows.Add(Convert.ToString(objDS.Tables[1].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[1].Rows[i]["SCHEDULE"]), Convert.ToString(objDS.Tables[1].Rows[i]["SALEMAN"]),
                                Convert.ToString(objDS.Tables[1].Rows[i]["MOBILE"]), Convert.ToString(objDS.Tables[1].Rows[i]["WHATSAPP"]), Convert.ToString(objDS.Tables[1].Rows[i]["ORDERTYPE"]), varOrderid
                                , Convert.ToString(objDS.Tables[1].Rows[i]["ORDERDAYS"]), Convert.ToString(objDS.Tables[1].Rows[i]["TAT"]), Convert.ToString(objDS.Tables[1].Rows[i]["DAYID"]), Convert.ToString(objDS.Tables[1].Rows[i]["ID"]),
                                Convert.ToString(objDS.Tables[1].Rows[i]["Status"]), Convert.ToString(objDS.Tables[1].Rows[i]["StatusId"]));
                                if (Convert.ToString(objDS.Tables[1].Rows[i]["SCHEDULE"]) == "Regular")
                                {
                                    varschedulenameflag++;
                                }
                            }
                            if (varschedulenameflag != 0)
                            {
                                txtScheduleName.Text = "";
                            }
                            else { txtScheduleName.Text = "Regular"; }
                        }

                        if (objDS.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                            {
                                for (int j = 0; j < grdPaymentMode.Rows.Count; j++)
                                {
                                    if (Convert.ToInt32(objDS.Tables[2].Rows[i]["SPP_PaymentMode"].ToString()) == Convert.ToInt32(grdPaymentMode.Rows[j].Cells["MSTID"].Value))
                                    {
                                        grdPaymentMode.Rows[j].Cells[0].Value = true;
                                    }
                                }
                            }
                        }
                        if (objDS.Tables[3].Rows.Count > 0)
                        {
                            varScheduleStsCount = Convert.ToInt32(objDS.Tables[3].Rows[0]["ScheduleCount"]);
                            udfnThirdTabEnable();
                        }
                        if (objDS.Tables.Count > 3)
                        {
                            if (objDS.Tables[4].Rows.Count > 0)
                            {
                                for (int i = 0; i < objDS.Tables[4].Rows.Count; i++)
                                {
                                    if (Convert.ToString(objDS.Tables[0].Rows[0]["OPTYPE"]) == "84") //Cr
                                    {
                                        grdOpeningCrDetails.Rows.Add(Convert.ToString(objDS.Tables[4].Rows[i]["S.No"]), Convert.ToString(objDS.Tables[4].Rows[i]["Concern"]), Convert.ToString(objDS.Tables[4].Rows[i]["InvoiceNo"]), Convert.ToString(objDS.Tables[4].Rows[i]["InvoiceDate"]), Convert.ToString(objDS.Tables[4].Rows[i]["TaxableAmount"]), Convert.ToString(objDS.Tables[4].Rows[i]["TaxAmount"]), Convert.ToString(objDS.Tables[4].Rows[i]["Adjustments"]), Convert.ToString(objDS.Tables[4].Rows[i]["InvoiceAmount"]), Convert.ToString(objDS.Tables[4].Rows[i]["Status"]), Convert.ToString(objDS.Tables[4].Rows[i]["StatusID"]), Convert.ToString(objDS.Tables[4].Rows[i]["ConcernID"]), Convert.ToString(objDS.Tables[4].Rows[i]["ID"]));
                                        dtOpeningCRDetails.Rows.Add(Convert.ToInt16(objDS.Tables[4].Rows[i]["ID"]), Convert.ToString(objDS.Tables[4].Rows[i]["InvoiceDate"]), Convert.ToString(objDS.Tables[4].Rows[i]["InvoiceNo"]), Convert.ToDecimal(objDS.Tables[4].Rows[i]["InvoiceAmount"]), Convert.ToInt16(objDS.Tables[4].Rows[i]["StatusID"]), Convert.ToString(objDS.Tables[4].Rows[i]["ConcernID"]), Convert.ToDecimal(objDS.Tables[4].Rows[i]["TaxableAmount"]), Convert.ToDecimal(objDS.Tables[4].Rows[i]["TaxAmount"]), Convert.ToDecimal(objDS.Tables[4].Rows[i]["Adjustments"]));
                                         
                                        if (Convert.ToString(Convert.ToString(objDS.Tables[4].Rows[i]["RemoveFlag"])) == "1")
                                        {
                                            ((DataGridViewImageCell)grdOpeningCrDetails.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
                                            grdOpeningCrDetails.Rows[i].ReadOnly = true;
                                            grdOpeningCrDetails.Rows[i].Cells["clmRemove"].ReadOnly = true;
                                            grdOpeningCrDetails.Rows[i].Cells["clmRemove"].Value = null;
                                            grdOpeningCrDetails.Rows[i].Cells["clmRemove"] = new DataGridViewTextBoxCell();
                                            grdOpeningCrDetails.Rows[i].Cells["clmRemove"].Value = "";
                                            grdOpeningCrDetails.Rows[i].Cells["clmRemove"].ReadOnly = true; 
                                        }
                                    }
                                    else if (Convert.ToString(objDS.Tables[0].Rows[0]["OPTYPE"]) == "85") //Dr
                                    {
                                        cmbDrCompany.SelectedValue = Convert.ToInt16(objDS.Tables[4].Rows[0]["ConcernID"]); 
                                    }
                                }
                                grdOpeningCrDetails.ClearSelection();
                                udfnOpeningType();
                            }
                            
                        }
                    }
                }
                if (pbFormStatus == 2 || varSupplierStatusID == 2)
                {
                    udfnDisable();
                }
                if (varSupplierStatusID == 98)
                {
                    panelStatus.Enabled = false;
                    btnSave.Enabled = true;
                }
                if (varSupplierStatusID == 1)
                {
                    grbform.Enabled = true;
                    grbEnvelopeDetails.Enabled = true;
                    groupBox4.Enabled = true;
                    groupBox5.Enabled = true;
                }
                txtTotInvoice.Text = Convert.ToString(grdOpeningCrDetails.Rows.Count);
                txtOBTotInvoice.Text = Convert.ToString(grdOpeningCrDetails.Rows.Count);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvCity.Visible = false;
                // udfnLoadOrderSchedule();
            }
        }
        public void udfnDisable()
        {
            grbform.Enabled = false;
            grbEnvelopeDetails.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            txtScheduleName.Enabled = false;
            grpSalesmanDetails.Enabled = false;
            grpOrderDetails.Enabled = false;
            cmbTat.Enabled = false;
            groupBox3.Enabled = false;
            groupBox1.Enabled = false;
            grdSupplierList.ReadOnly = true;
            //grdSupplierList.Columns["clmedit"].Visible = false;
            //grdSupplierList.Columns["clmDelete"].Visible = false;
            grbSupplierMapping.Enabled = false;
            cmbMappingorderschedule.Enabled = false;
            btnSelectAll.Enabled = false;
            btnUnselectAll.Enabled = false;
            btnMappingSelectAll.Enabled = false;
            btnMappingUnselectAll.Enabled = false;
            btnMappingsave.Enabled = false;
            cmbOrderschedule.Enabled = false;
            txtSearchByProduct2.Enabled = false;
            btnListPrint.Enabled = false;
            grdViewSupplierMapping.Enabled = false;
        }
        public void udfnThirdTabEnable()
        {
            if (varScheduleStsCount == 1)
            {
                grbSupplierMapping.Enabled = true;
                cmbMappingorderschedule.Enabled = true;
                btnSelectAll.Enabled = true;
                btnUnselectAll.Enabled = true;
                btnMappingSelectAll.Enabled = true;
                btnMappingUnselectAll.Enabled = true;
                btnMappingsave.Enabled = true;
                cmbOrderschedule.Enabled = true;
                txtSearchByProduct2.Enabled = true;
                btnListPrint.Enabled = true;
                grdViewSupplierMapping.Enabled = true;
            }
            else
            {
                grbSupplierMapping.Enabled = false;
                cmbMappingorderschedule.Enabled = false;
                btnSelectAll.Enabled = false;
                btnUnselectAll.Enabled = false;
                btnMappingSelectAll.Enabled = false;
                btnMappingUnselectAll.Enabled = false;
                btnMappingsave.Enabled = false;
                cmbOrderschedule.Enabled = false;
                txtSearchByProduct2.Enabled = false;
                btnListPrint.Enabled = false;
                grdViewSupplierMapping.Enabled = false;
            }
        }
        private void CP_Supplier_Leave(object sender, EventArgs e)
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
                udfntphide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    if (tcSupplier.SelectedIndex == 0)
                    {
                        btnSave_Click(sender, e);
                    }
                    else if (tcSupplier.SelectedIndex == 2)
                    {
                        BtnMappingsave_Click(sender, e);
                    }
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
                if (txtArea.Text == "")
                {
                    errCompany.SetError(txtArea, "Please enter Address");
                    txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter Address.", txtArea, 5000);
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

        private void txtPincode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPincode.BackColor = Color.White;
                try
                {
                    if (txtPincode.Text != "")
                    {
                        if (txtPincode.Text.Length < 6)
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
                    else if (txtPincode.Text == "")
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

        public void udfnLoadState()
        {
            try
            {
                //DataBind objDataBind = new DataBind();
                //objDataBind.BindComboBoxListSelected("DEF_STATE", "Status=1 and 1=1 Order by State", "State,StateCode", cmbState, "", "State", "StateCode");
                //objDataBind = null;
                //if (varstatecode != "") { cmbState.SelectedValue = varstatecode; }

                DataSet objDs = new DataSet();
                DataSet objDsStatus = new DataSet();
                DataService objdserv = new DataService();
                objDs = null;
                objDs = objdserv.GetDataset("SELECT MSTID,MST_DisplayText FROM DEF_Master WHERE MST_TransactionID=31");
                objDsStatus = objdserv.GetDataset("SELECT STSID,STS_Name FROM DEF_Status WHERE STS_ModuleID=14");
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            dtPaymentMode.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                dtPaymentMode.Rows.Add(false, objDs.Tables[0].Rows[i]["MST_DisplayText"], objDs.Tables[0].Rows[i]["MSTID"]);
                            }
                            grdPaymentMode.DataSource = dtPaymentMode;
                            grdPaymentMode.Columns["MSTID"].Visible = false;
                            grdPaymentMode.Columns[0].Width = 30;
                            grdPaymentMode.Columns["DisplayText"].Width = 100;
                            grdPaymentMode.Columns["DisplayText"].ReadOnly = true;
                            grdPaymentMode.ClearSelection();
                        }
                    }
                }
                if (objDsStatus != null)
                {
                    if (objDsStatus.Tables.Count != 0)
                    {
                        if (objDsStatus.Tables[0].Rows.Count != 0)
                        {
                            dtStatus = objDsStatus.Tables[0];
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

        private void Txtaddress2_Leave(object sender, EventArgs e)
        {
            txtaddress2.BackColor = Color.White;
            //if (txtaddress2.Text  == "")
            //{

            //    errCompany.SetError(txtaddress2, "Please enter address");
            //    txtaddress2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //    tparea.ShowAlways = true;
            //    tparea.Show("Please enter address.", txtaddress2, 5000);

            //}
            //else
            //{
            //    errCompany.Clear();
            //    txtaddress2.BackColor = Color.White;
            //    tparea.Hide(txtaddress2);
            //}
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

        private void Txtwhatsapp_Leave(object sender, EventArgs e)
        {
            if (txtwhatsapp.Text == "")
            {
                txtwhatsapp.BackColor = Color.White;
                //errCompany.SetError(txtwhatsapp, "Please enter whatsapp No.");
                //txtwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //tpContactNo.ShowAlways = true;
                //tpContactNo.Show("Please enter whatsapp No.", txtwhatsapp, 5000);

            }
            else if (txtwhatsapp.Text != "")
            {

                if (txtwhatsapp.Text.Length < 10)
                {

                    errCompany.SetError(txtwhatsapp, "Please enter valid whatsapp No.");
                    txtwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpContactNo.ShowAlways = true;
                    tpContactNo.Show("Please enter valid whatsapp No.", txtwhatsapp, 5000);
                }
                else
                {
                    errCompany.Clear();
                    txtwhatsapp.BackColor = Color.White;
                    tpContactNo.Hide(txtwhatsapp);
                }
            }
            else
            {
                errCompany.Clear();
                txtwhatsapp.BackColor = Color.White;
                tpContactNo.Hide(txtwhatsapp);
            }
        }

        private void Txtcreditlimit_Enter(object sender, EventArgs e)
        {
            try
            {

                txtcreditlimit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtcreditlimit_Leave(object sender, EventArgs e)
        {
            txtcreditlimit.BackColor = Color.White;
            //if (txtcreditlimit.Text == "")
            //{

            //    errCompany.SetError(txtcreditlimit, "Please enter credit limit");
            //    txtcreditlimit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //    tpcredit.ShowAlways = true;
            //    tpcredit.Show("Please enter credit limit.", txtcreditlimit, 5000);

            //}
            //else
            //{
            //    errCompany.Clear();
            //    txtwhatsapp.BackColor = Color.White;
            //    tpcredit.Hide(txtcreditlimit);
            //}
        }

        private void Txtcreditlimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPaymentTerm.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtopening_Leave(object sender, EventArgs e)
        {
            try
            {
                txtopening.BackColor = Color.White;
                //if (txtopening.Text  == "")
                //{

                //    errCompany.SetError(txtopening, "Please enter opening ");
                //    txtopening.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpopening.ShowAlways = true;
                //    tpopening.Show("Please enter opening.", txtopening, 5000);

                //}
                //else
                //{
                //    errCompany.Clear();
                //    txtopening.BackColor = Color.White;
                //    tpopening.Hide(txtopening);
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtopening_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbfinance.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtopening_Enter(object sender, EventArgs e)
        {
            try
            {
                txtopening.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbfinance_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPaymentTerm.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }


        private void Txtsalesmanname_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtsalesmanname.Text == "")
                //{

                //    errCompany.SetError(txtsalesmanname, "Please enter salesman name");
                //    txtsalesmanname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpsalesman.ShowAlways = true;
                //    tpsalesman.Show("Please enter salesman name", txtsalesmanname, 5000);

                //}
                //else
                //{
                errCompany.Clear();
                txtsalesmanname.BackColor = Color.White;
                tpsalesman.Hide(txtsalesmanname);
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Txtsalesmanname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtsalesmanmobile.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsalesmanname_Enter(object sender, EventArgs e)
        {

            try
            {
                txtsalesmanname.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }



        private void Txtsalesmanmobile_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtsalesmanwhatsapp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsalesmanmobile_Leave(object sender, EventArgs e)
        {

            //if (txtsalesmanmobile.Text == "")
            //{

            //    errCompany.SetError(txtsalesmanmobile, "Please enter salesman mobile No.");
            //    txtsalesmanmobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //    tpsalemanph.ShowAlways = true;
            //    tpsalemanph.Show("Please enter salesman mobile No.", txtsalesmanmobile, 5000);
            //}
            // else 
            if (txtsalesmanmobile.Text != "" && txtsalesmanmobile.Text.Length != 10)
            {
                errCompany.SetError(txtsalesmanmobile, "Please enter valid mobile No.");
                txtsalesmanmobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpsalemanph.ShowAlways = true;
                tpsalemanph.Show("Please enter valid mobile No.", txtsalesmanmobile, 5000);
            }
            else
            {
                errCompany.Clear();
                txtsalesmanmobile.BackColor = Color.White;
                tpsalemanph.Hide(txtsalesmanmobile);
            }
        }

        private void Txtsalesmanmobile_Enter(object sender, EventArgs e)
        {
            try
            {
                txtsalesmanmobile.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsalesmanwhatsapp_Leave(object sender, EventArgs e)
        {
            if (txtsalesmanwhatsapp.Text == "")
            {
                txtsalesmanwhatsapp.BackColor = Color.White;
                //errCompany.SetError(txtsalesmanwhatsapp, "Please enter salesman whatsapp No.");
                //txtsalesmanwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //tpsalemanph.ShowAlways = true;
                //tpsalemanph.Show("Please enter salesman whatsapp No.", txtsalesmanwhatsapp, 5000);
            }
            else if (txtsalesmanwhatsapp.Text.Length != 10)
            {

                errCompany.SetError(txtsalesmanwhatsapp, "Please enter valid whatsapp No.");
                txtsalesmanwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpsalemanph.ShowAlways = true;
                tpsalemanph.Show("Please enter valid whatsapp No.", txtsalesmanwhatsapp, 5000);

            }
            else
            {
                errCompany.Clear();
                txtsalesmanwhatsapp.BackColor = Color.White;
                tpsalemanph.Hide(txtsalesmanwhatsapp);
            }
        }

        private void Txtsalesmanwhatsapp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlScheduleStatus.Enabled == true)
                    {
                        if (rbScheduleActive.Checked == true)
                        {
                            rbScheduleActive.Focus();
                        }
                        else
                        {
                            rbScheduleInactive.Focus();
                        }
                    }
                    else
                    {
                        cmbOrderType.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmbsuppliertype_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtgstin.Enabled == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtgstin.Focus();
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbPaymentDisc.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtgstin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPaymentDisc.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtgstin_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtgstin.Text  == "")
                //{

                //    errCompany.SetError(txtgstin, "Please enter GSTIN");
                //    txtgstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpgst.ShowAlways = true;
                //    tpgst.Show("Please enter supply GSTIN.", txtgstin, 5000);

                //}
                //else
                //{
                //    errCompany.Clear();
                //    txtgstin.BackColor = Color.White;
                //    tpgst.Hide(txtgstin);
                //}
                if (txtgstin.Text == "" && txtgstin.Enabled == true)
                {
                    errCompany.SetError(txtgstin, "Please enter GSTIN");
                    txtgstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpgst.ShowAlways = true;
                    tpgst.Show("Please enter supply GSTIN.", txtgstin, 5000);
                }
                else if (txtgstin.Text != "")
                {
                    if (txtgstin.Text.Length < 15)
                    {
                        errCompany.SetError(txtgstin, "Please enter valid supplier GSTIN");
                        txtgstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpgst.ShowAlways = true;
                        tpgst.Show("Please enter valid supplier GSTIN.", txtgstin, 5000);

                    }
                    else
                    {
                        if (txtgstin.Text.Length > 0)
                        {
                            //string[] varGSTIN = txtgstin.Text.Split(' ');
                            string varGSTIN = txtgstin.Text;
                            varfirstValue = Convert.ToString(varGSTIN[0]);
                            varsecValue = Convert.ToString(varGSTIN[1]);
                            if (varfirstValue != Convert.ToString(varTINNo[0]) || varsecValue != Convert.ToString(varTINNo[1]))
                            {
                                errCompany.SetError(txtgstin, "Invalid GSTIN");
                                txtgstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpgst.ShowAlways = true;
                                tpgst.Show("Invalid GSTIN", txtgstin, 5000);
                            }
                            else
                            {
                                errCompany.Clear();
                                tpgst.Hide(txtgstin);
                                txtgstin.BackColor = Color.White;
                            }
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

        private void Grddays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grddays.Columns[e.ColumnIndex].Name == "chkdays" && e.RowIndex >= 0)
                {
                    DataGridViewCheckBoxCell checkBoxCell = grddays.Rows[e.RowIndex].Cells["chkdays"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {
                        checkBoxCell.Value = !(bool)(checkBoxCell.Value ?? false);
                        grddays.EndEdit(); // Commit the change
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbDesignation.Select(int.MaxValue, 0)));
                if (Convert.ToString(cmbDesignation.SelectedValue) == "28")
                {
                    txtDShortName.Text = "Proprietor Name";
                }
                if (Convert.ToString(cmbDesignation.SelectedValue) == "29")
                {
                    txtDShortName.Text = "Manager Name";
                }
                if (Convert.ToString(cmbDesignation.SelectedValue) == "-1")
                {
                    txtDShortName.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void CmbReturnPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReturnPolicy.Text == "Yes")
                // if (Convert.ToString(cmbReturnType.SelectedValue) == "22")
                {
                    cmbReturnType.Visible = true;
                    txtDReturnCycle.Visible = true;
                }
                else
                {
                    cmbReturnType.Visible = false;
                    txtDReturnCycle.Visible = false;
                    cmbPolicyContent.Visible = false;
                    txtReturnText.Visible = false;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReturnPolicy.Text == "Yes")
                // if (Convert.ToString(cmbReturnType.SelectedValue) == "22")
                {
                    cmbPolicyContent.Visible = true;
                    cmbSecondLevel.Visible = true;
                    txtReturnText.Visible = true;
                    txtNextLevel.Visible = true;
                }
                else
                {
                    cmbPolicyContent.Visible = false;
                    cmbSecondLevel.Visible = false;
                    txtReturnText.Visible = false;
                    txtNextLevel.Visible = false;
                }
                BeginInvoke(new Action(() => cmbReturnType.Select(int.MaxValue, 0)));

                if (cmbReturnPolicy.Text == "Yes")
                {
                    if (Convert.ToString(cmbReturnType.SelectedValue) == "24")
                    {
                        vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                        cmbPolicyContent.DataSource = null;
                        txtReturnText.Visible = false;
                        cmbPolicyContent.Visible = false;
                        txtNextLevel.Visible = false;
                        cmbSecondLevel.Visible = false;
                        varrecyclecode = Convert.ToInt32(cmbReturnType.SelectedValue);
                    }
                    else if ((Convert.ToString(cmbReturnType.SelectedValue) == "25"))
                    {
                        txtReturnText.Text = "Day";
                        vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                        cmbPolicyContent.Enabled = true;
                        cmbPolicyContent.DataSource = null;
                        DataBind objDataBind = new DataBind();
                        objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbPolicyContent, "", "DY_Name", "DYID");
                        objDataBind = null;
                        cmbPolicyContent.SelectedIndex = 0;
                        txtReturnText.Visible = true;
                        cmbPolicyContent.Visible = true;
                        txtNextLevel.Visible = false;
                        cmbSecondLevel.Visible = false;
                        vardayID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                    }
                    else if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                    {
                        vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                        txtReturnText.Text = "Week No.";
                        txtReturnText.Visible = true;
                        cmbPolicyContent.DataSource = null;
                        cmbSecondLevel.DataSource = null;
                        cmbPolicyContent.Visible = true;
                        cmbPolicyContent.Enabled = true;
                        DataBind objDataBind = new DataBind();
                        objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (28,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPolicyContent, "", "MST_DisplayText", "MSTID");
                        objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbSecondLevel, "", "DY_Name", "DYID");
                        varWeekID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                        vardayID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                        cmbPolicyContent.SelectedIndex = 0;
                        cmbSecondLevel.SelectedIndex = 0;
                        txtNextLevel.Text = "Day";

                        objDataBind = null;
                        txtNextLevel.Visible = true;
                        cmbSecondLevel.Visible = true;
                    }
                    else if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                    {
                        txtReturnText.Text = "Month";
                        vardays = "";
                        vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                        txtReturnText.Visible = true;
                        cmbPolicyContent.Visible = true;
                        cmbPolicyContent.Enabled = true;
                        cmbPolicyContent.DataSource = null;
                        cmbSecondLevel.DataSource = null;
                        DataBind objDataBind = new DataBind();
                        objDataBind.BindComboBoxListSelected("DEF_Months", "MONID NOT IN (0,-1)", "MON_Name,MONID", cmbPolicyContent, "", "MON_Name", "MONID");
                        cmbPolicyContent.SelectedIndex = 0;
                        DataService objds = new DataService();
                        vardays = objds.displaydata("SELECT MON_DAY FROM DEF_Months WHERE MONID ='" + Convert.ToString(cmbPolicyContent.SelectedValue) + "'");
                        objds.CloseConnection();
                        txtNextLevel.Visible = true;
                        cmbSecondLevel.Visible = true;
                        txtNextLevel.Text = "Day of the month";
                        objDataBind.BindComboBoxListSelected("DEF_Month_Days", "MONDID <='" + vardays + "'", "MOND_Name,MONDID", cmbSecondLevel, "", "MOND_Name", "MONDID");
                        objDataBind = null;
                        cmbSecondLevel.SelectedIndex = 0;
                        varMonthID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                    }
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
                if (txtName.Text == "")
                {
                    errCompany.SetError(txtName, "Please enter the name");
                    txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpname.ShowAlways = true;
                    tpname.Show("Please enter the name.", txtName, 5000);
                }
                else
                {
                    errCompany.Clear();
                    txtName.BackColor = Color.White;
                    // tpname.Hide(txtName);
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
                    txtTalllyName.Focus();
                }
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
                    errCompany.SetError(cmbState, "Please Select State Name");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please Select State Name", cmbState, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbState.BackColor = Color.White;
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

        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbState.Select(int.MaxValue, 0)));
                txtCity.Text = "";
                udfnSuppliertypeLoad();
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

        private void CmbDesignation_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDesignation.BackColor = Color.White;
                //if (Convert.ToString(cmbDesignation.SelectedValue) == "" || Convert.ToString(cmbDesignation.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbDesignation, "Please Select Designation");
                //    cmbDesignation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please Select Designation", cmbDesignation, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbDesignation.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtcontactName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDesignation_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbDesignation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDesignation_KeyPress(object sender, KeyPressEventArgs e)
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



        private void Cmbfinance_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbfinance.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbfinance_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbfinance.BackColor = Color.White;
                //if (Convert.ToString(cmbfinance.SelectedValue) == "" || Convert.ToString(cmbfinance.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbfinance, "Please Select Finance");
                //    cmbfinance.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please Select Finance", cmbfinance, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbfinance.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbfinance_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmbfinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbfinance.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbPaymentTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPaymentTerm.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentTerm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSupplierType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentTerm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPaymentTerm_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPaymentTerm.BackColor = Color.White;
                //if (Convert.ToString(cmbPaymentTerm.SelectedValue) == "" || Convert.ToString(cmbPaymentTerm.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbPaymentTerm, "Please Select Payment Term");
                //    cmbPaymentTerm.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please Select Payment Term", cmbPaymentTerm, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbPaymentTerm.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentTerm_Enter(object sender, EventArgs e)
        {

            try
            {

                cmbPaymentTerm.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSupplierType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbSupplierType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSupplierType.BackColor = Color.White;
                if (Convert.ToString(cmbSupplierType.SelectedValue) == "" || Convert.ToString(cmbSupplierType.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbSupplierType, "Please select supplier type");
                    cmbSupplierType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please select supplier type", cmbSupplierType, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbSupplierType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSupplierType_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbSupplierType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSupplierType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSupplierType.Select(int.MaxValue, 0)));
                if (Convert.ToString(cmbSupplierType.SelectedValue) == "32" || Convert.ToString(cmbSupplierType.SelectedValue) == "-1")
                {
                    txtgstin.Text = "";
                    txtgstin.Enabled = false;
                }
                else
                {
                    txtgstin.Enabled = true;
                }
                if (Convert.ToInt32(cmbSupplierType.SelectedValue) != 30)
                {
                    cmbPaymentTerm.SelectedValue = 33;
                    cmbPaymentTerm.Enabled = false;
                }
                else
                {
                    cmbPaymentTerm.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtgstin_Enter(object sender, EventArgs e)
        {
            try
            {

                txtgstin.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbReturnType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReturnPolicy_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReturnPolicy.BackColor = Color.White;
                //if (Convert.ToString(cmbReturnPolicy.SelectedValue) == "" || Convert.ToString(cmbReturnPolicy.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbReturnPolicy, "Please select return policy");
                //    cmbReturnPolicy.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select return policy", cmbReturnPolicy, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbReturnPolicy.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbReturnPolicy.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbPolicyContent.Visible == true)
                    {
                        cmbPolicyContent.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReturnType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReturnType.BackColor = Color.White;
                //if (Convert.ToString(cmbReturnType.SelectedValue) == "" || Convert.ToString(cmbReturnType.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbReturnType, "Please select return type");
                //    cmbReturnType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select return type", cmbReturnType, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbReturnType.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbReturnType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPolicyContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPolicyContent.Select(int.MaxValue, 0)));
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                {
                    vardays = "";
                    vardayMonthID = 0;
                    cmbSecondLevel.DataSource = null;
                    DataBind objDataBind = new DataBind();
                    DataService objds = new DataService();
                    vardays = objds.displaydata("SELECT MON_DAY FROM DEF_Months WHERE MONID ='" + Convert.ToString(cmbPolicyContent.SelectedValue) + "'");
                    objds.CloseConnection();
                    objDataBind.BindComboBoxListSelected("DEF_Month_Days", "MONDID <='" + vardays + "'", "MOND_Name,MONDID", cmbSecondLevel, "", "MOND_Name", "MONDID");
                    objDataBind = null;
                    cmbSecondLevel.SelectedIndex = 0;
                    vardayMonthID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                }
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "25"))
                {
                    vardayID = 0;
                    vardayID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                }
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                {
                    vardays = "";
                    varWeekID = 0;
                    vardayID = 0;
                    cmbSecondLevel.DataSource = null;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbSecondLevel, "", "DY_Name", "DYID");
                    objDataBind = null;
                    varWeekID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                    vardayID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                }

            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPolicyContent_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPolicyContent.BackColor = Color.White;
                //if (Convert.ToString(cmbPolicyContent.SelectedValue) == "" || Convert.ToString(cmbPolicyContent.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbPolicyContent, "Please select policy content");
                //    cmbPolicyContent.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select policy content", cmbPolicyContent, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbPolicyContent.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbPolicyContent_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbSecondLevel.Visible == true)
                    {
                        cmbSecondLevel.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPolicyContent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPolicyContent_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPolicyContent.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSecondLevel.Select(int.MaxValue, 0)));
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                {
                    vardayMonthID = 0;
                    DataBind objDataBind = new DataBind();
                    DataService objds = new DataService();
                    vardayMonthID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                    varMonthID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                }

                if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                {
                    vardays = "";
                    varWeekID = 0;
                    vardayID = 0;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    varWeekID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                    vardayID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                }


            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSecondLevel.BackColor = Color.White;
                //if (Convert.ToString(cmbSecondLevel.SelectedValue) == "" || Convert.ToString(cmbSecondLevel.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbSecondLevel, "Please select");
                //    cmbSecondLevel.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select", cmbSecondLevel, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbSecondLevel.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbSecondLevel_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSecondLevel.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (panelStatus.Enabled == false)
                    {

                        btnSave.Focus();
                    }
                    else
                    {

                        rbActive.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtScheduleName_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtScheduleName.Text == "")
                {

                    errCompany.SetError(txtScheduleName, "Please enter the schedule");
                    txtScheduleName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpschedule.ShowAlways = true;
                    tpschedule.Show("Please enter the schedule", txtScheduleName, 5000);

                }
                else
                {
                    errCompany.Clear();
                    txtScheduleName.BackColor = Color.White;
                    tpschedule.Hide(txtScheduleName);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtScheduleName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    txtsalesmanname.Focus();

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtScheduleName_Enter(object sender, EventArgs e)
        {
            try
            {

                txtScheduleName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BeginInvoke(new Action(() => cmbOrderType.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    cmbTat.Focus();

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbOrderType_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbOrderType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrderType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderType.BackColor = Color.White;
                if (Convert.ToString(cmbOrderType.SelectedValue) == "" || Convert.ToString(cmbOrderType.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbOrderType, "Please select order type");
                    cmbOrderType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please select order type", cmbOrderType, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbOrderType.BackColor = Color.White;
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

        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {

                btnAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn_close_Leave(object sender, EventArgs e)
        {
            try
            {

                btn_close.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn_close_Enter(object sender, EventArgs e)
        {
            try
            {

                btn_close.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_Leave(object sender, EventArgs e)
        {
            try
            {

                txtSearchByProduct2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSearchByProduct2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    btn_Close2.Focus();

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct2.BackColor = Color.LemonChiffon;
                for (int i = 1; i < DGV_SearchGridPro.ColumnCount; i++)
                {
                    DGV_SearchGridPro.Rows[0].Cells[i].Value = "";
                }
                DGV_SearchGridPro_CurrentCellDirtyStateChanged(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //  SearchFlag = 0;
            }
        }

        private void Btn_Close2_Enter(object sender, EventArgs e)
        {
            try
            {

                btn_Close2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn_Close2_Leave(object sender, EventArgs e)
        {
            try
            {

                btn_Close2.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TbOrder_Enter(object sender, EventArgs e)
        {
            try
            {

                txtScheduleName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TcSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pbSupplierid != "0")
                {
                    errCompany.Clear();
                    udfntphide();
                    udfncolorchange();
                    udfnSchedulecolorchange();

                    if (tcSupplier.SelectedIndex == 1)
                    {
                        if (btnSave.Text == "Update")
                        {
                            if (varSupplierStatusID == 2)
                            {
                                gpSupplier.Enabled = false;
                                grdSupplierList.Columns["clmedit"].Visible = false;
                                grdSupplierList.Columns["clmDelete"].Visible = false;
                                grddays.Enabled = false;
                            }
                        }
                        txtScheduleName.Focus();

                        txtScheduleName.SelectionStart = txtScheduleName.Text.Length;
                        cmbOrderType.SelectedValue = 144;
                    }
                    if (tcSupplier.SelectedIndex == 0)
                    {
                        txtName.Focus();
                        txtName.SelectionStart = txtName.Text.Length;
                    }
                    if (tcSupplier.SelectedIndex == 3)
                    {

                        cmbOrderschedule.Focus();
                        BeginInvoke(new Action(() => cmborderday.Select(int.MaxValue, 0)));
                        cmborderday.SelectedIndex = 0;
                        cmbOrderschedule.SelectedIndex = 0;

                    }
                    if (tcSupplier.SelectedIndex == 2)
                    {
                        //picLoader.Visible = true;
                        //picLoader.BringToFront();
                        //Application.DoEvents();
                        txtSupplier.Focus();
                        //cmborderday.SelectedIndex = 0;
                        //cmbOrderschedule.SelectedIndex = 0;
                        this.ActiveControl = cmbMappingorderschedule;

                    }
                    if (tcSupplier.SelectedIndex == 4)
                    {
                        udfnLoadOrderSchedulePur();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadOrderSchedule()
        {
            try
            {
                if (Convert.ToInt32(varsupplierID) != 0)
                {
                    SupplierUpdate = Convert.ToInt32(varsupplierID);
                }
                else
                {
                    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                }
                cmbOrderschedule.DataSource = null; cmbOrderschedule.Text = "";
                cmbMappedorderrype.DataSource = null; cmbMappedorderrype.Text = "";
                grdViewSupplierMapping.DataSource = null;
                DGV_SearchGridPro.DataSource = null;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Supplier_Schedule", " SPSC_SPID='" + SupplierUpdate + "'AND SPSC_STSID NOT IN (2) oR  SPSC_SPID= 0  order by SPSCID, SPSC_Name", "SPSC_Name,SPSCID", cmbOrderschedule, "", "SPSC_Name", "SPSCID");
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (13,0) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbMappedorderrype, "", "MST_DisplayText", "MSTID");
                objDataBind = null;


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadOrderSchedulePur()
        {
            try
            {
                if (Convert.ToInt32(varsupplierID) != 0)
                {
                    SupplierUpdate = Convert.ToInt32(varsupplierID);
                }
                else
                {
                    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                }
                cmbPurOrderSchedule.DataSource = null; cmbPurOrderSchedule.Text = "";
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Supplier_Schedule", " SPSC_SPID='" + SupplierUpdate + "'AND SPSC_STSID NOT IN (2) oR  SPSC_SPID= 0  order by SPSCID, SPSC_Name", "SPSC_Name,SPSCID", cmbPurOrderSchedule, "", "SPSC_Name", "SPSCID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,47) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbPurStatus, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TcSupplier_Selected(object sender, TabControlEventArgs e)
        {
            if (pbSupplierid != "0")
            {

                if (e.TabPageIndex == 1)
                {
                    try
                    {
                        this.ActiveControl = txtScheduleName;
                        BindDataGrid();
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                }
                if (e.TabPageIndex == 3)
                {
                    try
                    {
                        this.ActiveControl = cmbOrderschedule;
                        udfnLoadOrderSchedule();
                        udfnThirdTabEnable();
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                }
                if (e.TabPageIndex == 2)
                {
                    try
                    {
                        BindDataGrid();
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        this.ActiveControl = cmbMappingorderschedule;
                        DataBind objDataBind = new DataBind();

                        cmbMappingorderschedule.DataSource = null; cmbMappingorderschedule.Text = "";
                        cmbOrderschedule.DataSource = null; cmbOrderschedule.Text = "";
                        grdViewSupplierMapping.DataSource = null;
                        DGV_SearchGridPro.DataSource = null;
                        if (Convert.ToInt32(varsupplierID) != 0)
                        {
                            SupplierUpdate = Convert.ToInt32(varsupplierID);
                        }
                        else
                        {
                            SupplierUpdate = Convert.ToInt32(pbSupplierid);
                        }
                        if (SupplierUpdate != 0)
                        {
                            objDataBind.BindComboBoxListSelected("MR_Supplier_Schedule", "SPSC_SPID = '" + SupplierUpdate + "'AND SPSC_STSID NOT IN (2) ", "SPSC_Name,SPSCID", cmbMappingorderschedule, "", "SPSC_Name", "SPSCID");
                        }
                        else
                        {
                            objDataBind.BindComboBoxListSelected("MR_Supplier_Schedule", "SPSC_STSID NOT IN (2) OR SPSCID=-1", "SPSC_Name,SPSCID", cmbMappingorderschedule, "", "SPSC_Name", "SPSCID");
                        }

                        //objDataBind.BindComboBoxListSelected("MR_Supplier_Schedule", "SPSC_SPID = '" + SupplierUpdate + "'AND SPSC_STSID NOT IN (2) OR SPSCID=0", "SPSC_Name,SPSCID", cmbOrderschedule, "", "SPSC_Name", "SPSCID");
                        objDataBind = null;
                        DataSet objDT = new DataSet();
                        SPDataService objdserv = new SPDataService();
                        int varViewType = 3;
                        objDT = objdserv.udfnGroupList(varViewType, 0, 0, "", 0);
                        objdserv.CloseConnection();
                        picLoader.Visible = false;
                        picLoader.SendToBack();
                        objdserv.CloseConnection();
                        udfnThirdTabEnable();
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                    finally
                    {
                        lblTotalProducts.Text = grdSupplierMappingLoad.Rows.Count.ToString();
                    }
                }
                grdSupplierList.ClearSelection();
            }
        }


        private void Cmborderday_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmborderday.DataSource == null) return;
                mappedproductsfilter();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //tab4
        public void mappedproductsfilter()
        {
            try
            {
                BeginInvoke(new Action(() => cmborderday.Select(int.MaxValue, 0)));
                grdViewSupplierMapping.DataSource = null;
                SPDataService objspservice = new SPDataService();
                DataSet objDs = new DataSet();
                SupplierUpdate = 0;
                lblMappedNoRecords.Visible = false;
                if (Convert.ToInt32(varsupplierID) != 0)
                {
                    SupplierUpdate = Convert.ToInt32(varsupplierID);
                }
                else
                {
                    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                }
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 5;
                objMR_Supplier.paraSupplierid = Convert.ToInt32(SupplierUpdate);
                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbOrderschedule.SelectedValue);
                objMR_Supplier.pardayid = Convert.ToInt32(cmborderday.SelectedValue);
                objMR_Supplier.paraordertype = Convert.ToInt32(cmbMappedorderrype.SelectedValue);
                objDs = objspservice.udfnSupplierList(objMR_Supplier);
                if (objDs.Tables[0].Rows.Count > 0)
                {
                    grdViewSupplierMapping.DataSource = objDs.Tables[0];
                    grdViewSupplierMapping.Columns["S.No."].Width = 50;
                    grdViewSupplierMapping.Columns["Product Name in Tamil"].Width = 250;
                    grdViewSupplierMapping.Columns["Product Name in English"].Width = 250;
                    grdViewSupplierMapping.Columns["Rep Name"].Width = 220;
                    grdViewSupplierMapping.Columns["Unit"].Width = 80;
                    grdViewSupplierMapping.Columns["R.Sales Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdViewSupplierMapping.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdViewSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                }
                else
                {
                    lblMappedNoRecords.Visible = true;
                    btnListPrint.Image = global::ROMS.Properties.Resources.view;
                }
                objspservice.CloseConnection();
                DGV_SearchGridPro.DataSource = null;
                udfnsearchgridHead_MappedProducts();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblMappedproductcountlist.Text = grdViewSupplierMapping.Rows.Count.ToString();
            }
        }

        private void Cmborderday_Leave(object sender, EventArgs e)
        {

            cmborderday.BackColor = Color.White;

        }

        private void Cmborderday_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmborderday_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    txtSearchByProduct2.Focus();

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Cmborderday_Enter(object sender, EventArgs e)
        {
            try
            {

                cmborderday.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderschedule_Leave(object sender, EventArgs e)
        {
            try
            {

                cmbOrderschedule.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrderschedule_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    cmbMappedorderrype.Focus();

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderschedule_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbOrderschedule.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbOrderschedule_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbOrderschedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnListPrint.Image = global::ROMS.Properties.Resources.print;
                BeginInvoke(new Action(() => cmbOrderschedule.Select(int.MaxValue, 0)));
                RPTViewer.Visible = false;
                udfnMappedDropDownLoad();
                mappedproductsfilter();
                btnListPrint.Visible = false;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 28;
                objMR_Supplier.paraSupplierid = Convert.ToInt32(pbSupplierid);
                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbOrderschedule.SelectedValue);
                if (Convert.ToInt32(cmbOrderschedule.SelectedValue) == 0)
                {
                    objDs = objspservice.udfnSupplierList(objMR_Supplier);
                }
                else
                {
                    objMR_Supplier.paraordertype = Convert.ToInt32(cmbMappedorderrype.SelectedValue);
                    objDs = objspservice.udfnSupplierList(objMR_Supplier);
                }
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            btnListPrint.Visible = true;
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
        //tab 4
        public void udfnMappedDropDownLoad()
        {
            try
            {
                txtMappedOrderDay.Text = "";
                cmbMappedorderrype.Text = "";
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 21;
                objMR_Supplier.paraSupplierid = SupplierUpdate;
                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbOrderschedule.SelectedValue);
                SPDataService objSPservice = new SPDataService();
                DataSet objDS = new DataSet();
                cmborderday.DataSource = null;
                objDS = objSPservice.udfnSupplierList(objMR_Supplier);
                objSPservice.CloseConnection();
                if (objDS != null)
                {
                    if (objDS.Tables.Count != 0)
                    {
                        if (objDS.Tables[0].Rows.Count != 0)
                        {
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["SPSC_OrderType"]) != "")
                            {
                                txtMappedOrderDay.Text = Convert.ToString(objDS.Tables[0].Rows[0]["DayNames"]);
                                cmbMappedorderrype.Text = Convert.ToString(objDS.Tables[0].Rows[0]["SPSC_OrderType"]);
                                //cmbMappedorderrype.SelectedValue = Convert.ToInt32(objDS.Tables[0].Rows[0]["OrderID"]);
                            }
                        }
                        else
                        {
                            cmbMappedorderrype.SelectedValue = 0;
                            txtMappedOrderDay.Text = "";
                        }
                        //if(objDS.Tables[1].Rows.Count !=0)
                        //{
                        //    cmbMappedorderrype.ValueMember = "OrderID";
                        //    cmbMappedorderrype.DisplayMember = "OrderType";
                        //    cmbMappedorderrype.DataSource = objDS.Tables[1];
                        //}
                    }
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
            finally
            {

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

        private void Txtsuppliername_Enter(object sender, EventArgs e)
        {
            try
            {

                txtsuppliername.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsuppliername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbMappingorderschedule.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsuppliername_Leave(object sender, EventArgs e)
        {
            try
            {

                txtsuppliername.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingorderschedule_Leave(object sender, EventArgs e)
        {
            try
            {

                cmbMappingorderschedule.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingorderschedule_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbMappingorderschedule_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMappingGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingorderschedule_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbMappingorderschedule.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnInitSubgroup()
        {
            try
            {
                dtSubGroup = new DataTable();
                dtSubGroup.Columns.Add("", typeof(Boolean));
                dtSubGroup.Columns.Add("S.No.", typeof(string));
                dtSubGroup.Columns.Add("P.I Code", typeof(string));
                dtSubGroup.Columns.Add("Product Name in Tamil", typeof(string));
                dtSubGroup.Columns.Add("Unit", typeof(string));
                dtSubGroup.Columns.Add("Brand", typeof(string));
                dtSubGroup.Columns.Add("Product SubGroup", typeof(string));
                dtSubGroup.Columns.Add("Product Group", typeof(string));
                dtSubGroup.Columns.Add("GROUPID", typeof(int));
                dtSubGroup.Columns.Add("SUBGROUPID", typeof(int));
                dtSubGroup.Columns.Add("PRODUCTID", typeof(int));
                dtSubGroup.Columns.Add("Product Name in English", typeof(string));
                dtSubGroup.Columns.Add("MappedCount", typeof(int));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbMappingorderschedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbMappingorderschedule.DataSource == null) return;
                dtSubGroupMapping = new DataTable();
                dtSubGroupMapping.Columns.Add("", typeof(Boolean));
                dtSubGroupMapping.Columns.Add("S.No.", typeof(string));
                dtSubGroupMapping.Columns.Add("P.I Code", typeof(string));
                dtSubGroupMapping.Columns.Add("Product Name in Tamil", typeof(string));
                dtSubGroupMapping.Columns.Add("Unit", typeof(string));
                dtSubGroupMapping.Columns.Add("Brand", typeof(string));
                dtSubGroupMapping.Columns.Add("Product SubGroup", typeof(string));
                dtSubGroupMapping.Columns.Add("Product Group", typeof(string));
                dtSubGroupMapping.Columns.Add("GROUPID", typeof(int));
                dtSubGroupMapping.Columns.Add("SUBGROUPID", typeof(int));
                dtSubGroupMapping.Columns.Add("PRODUCTID", typeof(int));
                dtSubGroupMapping.Columns.Add("Product Name in English", typeof(string));
                dtSubGroupMapping.Columns.Add("MappedCount", typeof(int));
                //udfnInitSubgroup();
                BeginInvoke(new Action(() => cmbMappingorderschedule.Select(int.MaxValue, 0)));
                udfnMappingGridsLoad();
                udfnMappingDropDownLoad();
                udfndataLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
                lblTotalProducts.Text = grdSupplierMappingLoad.Rows.Count.ToString();
            }
        }
        public void udfnMappingGridsLoad()
        {
            try
            {
                lblNoRecordsFound.Visible = false;
                grdSupplierMappingLoad.DataSource = null;
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 3;
                objMR_Product.paraGroup = varGroupId;
                objMR_Product.paraSubgroup = varSubGroupId;
                objMR_Product.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.paraBrandID = varBrandId;
                objMR_Product.ParaScheduleid = Convert.ToString(cmbMappingorderschedule.SelectedValue);
                objMR_Product.paraScheduleDay = Convert.ToString(cmbMappingordeDay.SelectedValue);
                DataSet objDs = new DataSet();
                dtSubGroup = null;
                udfnInitSubgroup();
                SPDataService objspservice = new SPDataService();
                //objDs = objspservice.udfnproductmasterlist(3, 0, 0,Convert.ToInt32(cmbMappingGroup.SelectedValue), Convert.ToInt32(cmbMappingSubGroup.SelectedValue),"", MainForm.pbUserID, MainForm.pbIpAddress, 0,0,0, Convert.ToInt32(cmbMappingorderschedule.SelectedValue), Convert.ToInt32(cmbMappingordeDay.SelectedValue));
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtSubGroup.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in Tamil"]
                            , objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["Brand"], objDs.Tables[0].Rows[i]["Product SubGroup"], objDs.Tables[0].Rows[i]["Product Group"], objDs.Tables[0].Rows[i]["GROUPID"], objDs.Tables[0].Rows[i]["SUBGROUPID"],
                            objDs.Tables[0].Rows[i]["PRODUCTID"], objDs.Tables[0].Rows[i]["Product Name in English"], objDs.Tables[0].Rows[i]["MappedCount"]);
                    }
                    grdSupplierMappingLoad.DataSource = dtSubGroup;
                    //  grdSupplierMappingLoad.Columns[0].Frozen = true;
                    grdSupplierMappingLoad.Columns[0].HeaderText = "";
                    grdSupplierMappingLoad.Columns[0].Width = 30;
                    grdSupplierMappingLoad.Columns["S.No."].Width = 50;
                    grdSupplierMappingLoad.Columns["P.I Code"].Width = 100;
                    grdSupplierMappingLoad.Columns["Product Name in Tamil"].Width = 220;
                    grdSupplierMappingLoad.Columns["Unit"].Width = 60;
                    grdSupplierMappingLoad.Columns["Product SubGroup"].Width = 170;
                    grdSupplierMappingLoad.Columns["GROUPID"].Visible = false;
                    grdSupplierMappingLoad.Columns["SUBGROUPID"].Visible = false;
                    grdSupplierMappingLoad.Columns["PRODUCTID"].Visible = false;
                    grdSupplierMappingLoad.Columns["MappedCount"].Visible = false;
                    grdSupplierMappingLoad.Columns["Product Name in English"].Visible = false;
                    grdSupplierMappingLoad.Columns["S.No."].Visible = false;

                    grdSupplierMappingLoad.Columns["S.No."].ReadOnly = true;
                    grdSupplierMappingLoad.Columns["P.I Code"].ReadOnly = true;
                    grdSupplierMappingLoad.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdSupplierMappingLoad.Columns["Unit"].ReadOnly = true;
                    grdSupplierMappingLoad.Columns["Product SubGroup"].ReadOnly = true;
                    grdSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    dtSubGroup.Rows.Clear();
                    //dtSubGroup.AcceptChanges();
                    grdSupplierMappingLoad.DataSource = null;
                }
                objspservice.CloseConnection();
                udfnSearchGridHead();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                SearchFlag = 0;
            }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdSupplierMappingLoad, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdSupplierMappingLoad.Columns)
                {
                    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_SearchGrid.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_SearchGrid.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_SearchGrid.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnsearchgridHead()
        {
            try
            {
                udfnGridSearchHeading(grdFinalSupplierMapping, DGV_SearchGrid1);
                DGV_SearchGrid1.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdFinalSupplierMapping.Columns)
                {
                    DGV_SearchGrid1.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_SearchGrid1.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_SearchGrid1.Rows.Clear();
                    DGV_SearchGrid1.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_SearchGrid1.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_SearchGrid1.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_SearchGrid1.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                //dgv2.DataSource = null;
                dgv2.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in dgv1.Columns)
                {
                    if (col.Visible)
                    {
                        dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                }
                int rowIndex = 0;
                int ColIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                BlnSearchImageYN = false;
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                    if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                    {
                        //dgv2.Rows[rowIndex].Visible = false;
                        BlnSearchImageYN = true;
                        ColIndex = i;
                        dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                        dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                        ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                    }
                    else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                    {
                        BlnSearchImageYN = true;
                        dgv2.Rows[rowIndex].Cells[i].Value = false;
                    }
                    else
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfngridsearchheading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                //dgv2.DataSource = null;
                dgv2.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in dgv1.Columns)
                {
                    if (col.Visible)
                    {
                        dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                }
                int rowIndex = 0;
                int ColIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                BlnSearchImageYN = false;
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                    if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                    {
                        //dgv2.Rows[rowIndex].Visible = false;
                        BlnSearchImageYN = true;
                        ColIndex = i;
                        dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                        dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                        ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                    }
                    else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                    {
                        BlnSearchImageYN = true;
                        dgv2.Rows[rowIndex].Cells[i].Value = false;
                    }
                    else
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        public void udfnMappingDropDownLoad()
        {
            try
            {
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 0;
                objMR_Supplier.paraSupplierid = SupplierUpdate;
                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbMappingorderschedule.SelectedValue);
                SPDataService objspservice = new SPDataService();
                DataSet objDs = new DataSet();
                cmbMappingordeDay.DataSource = null;
                objDs = objspservice.udfnSupplierList(objMR_Supplier);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            txtordertype.Text = objDs.Tables[0].Rows[0]["MST_DisplayText"].ToString().Replace("''", "'");
                            lblOrderTypeId.Text = objDs.Tables[0].Rows[0]["MSTID"].ToString().Replace("''", "'");
                        }
                        else
                        {
                            txtordertype.Text = "";
                        }
                    }
                    objspservice.CloseConnection();
                }
                MR_Supplier objMR_Supplier1 = new MR_Supplier();
                objMR_Supplier1.ViewType = 21;
                objMR_Supplier1.paraSupplierid = SupplierUpdate;
                objMR_Supplier1.paraSupplierScheduleid = Convert.ToInt32(cmbMappingorderschedule.SelectedValue);
                SPDataService objSPservice = new SPDataService();
                DataSet objDS = new DataSet();
                //cmborderday.DataSource = null;
                objDS = objSPservice.udfnSupplierList(objMR_Supplier1);
                objSPservice.CloseConnection();
                if (objDS != null)
                {
                    if (objDS.Tables.Count != 0)
                    {
                        if (objDS.Tables[0].Rows.Count != 0)
                        {
                            txtSupplierOrderDays.Text = objDS.Tables[0].Rows[0]["DayNames"].ToString().Replace("''", "'");
                        }
                        else
                        {
                            txtSupplierOrderDays.Text = "";
                        }
                    }
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

        private void CmbMappingordeDay_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbMappingordeDay.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbMappingordeDay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbMappingordeDay.SelectedValue) == "" || Convert.ToString(cmbMappingordeDay.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbMappingordeDay, "Please select order day");
                    cmbMappingordeDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please select order day", cmbMappingordeDay, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbMappingordeDay.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbMappingordeDay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMappingGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingordeDay_KeyPress(object sender, KeyPressEventArgs e)
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




        private void CmbMappingordeDay_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public void udfndataLoad()
        {
            try
            {
                lblNoRecordsFound.Visible = false;
                BeginInvoke(new Action(() => cmbMappingordeDay.Select(int.MaxValue, 0)));
                grdFinalSupplierMapping.DataSource = null;
                SPDataService objspservice = new SPDataService();
                DataSet objDs = new DataSet();
                //foreach (DataGridViewRow row in grdSupplierMappingLoad.Rows)
                //{
                //    row.Cells[0].Value = false;
                //} 
                SupplierUpdate = 0;
                if (Convert.ToInt32(varsupplierID) != 0)
                {
                    SupplierUpdate = Convert.ToInt32(varsupplierID);
                }
                else
                {
                    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                }
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 4;
                objMR_Supplier.paraSupplierid = Convert.ToInt32(SupplierUpdate);
                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbMappingorderschedule.SelectedValue);
                objDs = objspservice.udfnSupplierList(objMR_Supplier);
                dtSubGroupMapping = new DataTable();
                dtSubGroupMapping.Columns.Add("", typeof(Boolean));
                dtSubGroupMapping.Columns.Add("S.No.", typeof(string));
                dtSubGroupMapping.Columns.Add("P.I Code", typeof(string));
                dtSubGroupMapping.Columns.Add("Product Name in Tamil", typeof(string));
                dtSubGroupMapping.Columns.Add("Unit", typeof(string));
                dtSubGroupMapping.Columns.Add("Brand", typeof(string));
                dtSubGroupMapping.Columns.Add("Product SubGroup", typeof(string));
                dtSubGroupMapping.Columns.Add("Product Group", typeof(string));
                dtSubGroupMapping.Columns.Add("GROUPID", typeof(int));
                dtSubGroupMapping.Columns.Add("SUBGROUPID", typeof(int));
                dtSubGroupMapping.Columns.Add("PRODUCTID", typeof(int));
                dtSubGroupMapping.Columns.Add("Product Name in English", typeof(string));
                dtSubGroupMapping.Columns.Add("MappedCount", typeof(int));

                if (objDs.Tables[0].Rows.Count > 0)
                {
                    int varcount = 1;
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtSubGroupMapping.Rows.Add(false, Convert.ToInt32(dtSubGroupMapping.Rows.Count) + 1, objDs.Tables[0].Rows[i]["P.I Code"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Product Name in Tamil"].ToString().Replace("''", "'")
                        , objDs.Tables[0].Rows[i]["Unit"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Brand"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Product SubGroup"].ToString().Replace("''", "'"),
                       objDs.Tables[0].Rows[i]["Product Group"].ToString().Replace("''", "'"),
                        objDs.Tables[0].Rows[i]["GROUPID"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["SUBGROUPID"].ToString().Replace("''", "'"),
                        objDs.Tables[0].Rows[i]["PRODUCTID"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Product Name in English"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["MappedCount"].ToString());

                    }
                    grdFinalSupplierMapping.DataSource = dtSubGroupMapping;
                    //grdFinalSupplierMapping.Columns[0].Frozen = true;
                    grdFinalSupplierMapping.Columns[0].HeaderText = "";
                    grdFinalSupplierMapping.Columns[0].Width = 30;
                    grdFinalSupplierMapping.Columns["S.No."].Width = 50;
                    grdFinalSupplierMapping.Columns["P.I Code"].Width = 100;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].Width = 220;
                    grdFinalSupplierMapping.Columns["Unit"].Width = 100;
                    grdFinalSupplierMapping.Columns["Product SubGroup"].Width = 120;
                    grdFinalSupplierMapping.Columns["GROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["SUBGROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["PRODUCTID"].Visible = false;
                    grdFinalSupplierMapping.Columns["MappedCount"].Visible = false;
                    grdFinalSupplierMapping.Columns["Product Name in English"].Visible = false;

                    grdFinalSupplierMapping.Columns["S.No."].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Unit"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product SubGroup"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);

                    udfnGridRemove();
                    //for (int i = 0; i < grdSupplierMappingLoad.Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < grdFinalSupplierMapping.Rows.Count; j++)
                    //    {
                    //        if (Convert.ToInt32(grdFinalSupplierMapping.Rows[j].Cells["PRODUCTID"].Value) == Convert.ToInt32(grdSupplierMappingLoad.Rows[i].Cells["PRODUCTID"].Value))
                    //        {
                    //            grdSupplierMappingLoad.Rows[i].Cells[0].Value = true;
                    //        }
                    //    }
                    //}
                    btnMappingsave.Text = "Update";
                    //udfndataLoad();
                }
                else
                {
                    btnMappingsave.Text = "Save";
                }

                udfnsearchgridHead();
                objspservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
            }
        }

        private void CmbMappingGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMappingSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingGroup_KeyPress(object sender, KeyPressEventArgs e)
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



        private void CmbMappingGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    BeginInvoke(new Action(() => cmbMappingGroup.Select(int.MaxValue, 0))); 
            //    DataSet objDT = new DataSet();
            //    SPDataService objdserv = new SPDataService();
            //    int varViewType = 5;
            //    if (Convert.ToInt32(cmbMappingGroup.SelectedValue) == 0)
            //    {
            //        varViewType = 4;
            //    }
            //    objDT = objdserv.udfnSubGroupList(varViewType, 0,"", Convert.ToInt32(cmbMappingGroup.SelectedValue), 0,"");
            //    objdserv.CloseConnection();
            //    if (objDT != null)
            //    {
            //        if (objDT.Tables.Count > 0)
            //        {
            //            if (objDT.Tables[0].Rows.Count > 0)
            //            {
            //                cmbMappingSubGroup.ValueMember = "PRSGID";
            //                cmbMappingSubGroup.DisplayMember = "PRSG_EName";
            //                cmbMappingSubGroup.DataSource = objDT.Tables[0];
            //            }
            //        }
            //    }
            //    objdserv.CloseConnection();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void CmbMappingGroup_Leave(object sender, EventArgs e)
        {

            //try
            //{

            //    cmbMappingGroup.BackColor = Color.White;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}

        }

        private void CmbMappingSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnMappingView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingSubGroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbMappingSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {

                //cmbMappingSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingSubGroup_Enter(object sender, EventArgs e)
        {

            //try
            //{

            //    cmbMappingSubGroup.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void CmbMappingSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    BeginInvoke(new Action(() => cmbMappingSubGroup.Select(int.MaxValue, 0)));
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void BtnMappingView_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnLvHide();
                btnMappingView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnMappingView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSearchByProduct1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtmappingproductsearch2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct1_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnLvHide();
                txtSearchByProduct1.BackColor = Color.LemonChiffon;
                for (int i = 1; i < DGV_SearchGrid.ColumnCount; i++)
                {
                    DGV_SearchGrid.Rows[0].Cells[i].Value = "";
                }
                //udfnMappingGridsLoad();
                DGV_SearchGrid_CurrentCellDirtyStateChanged(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Txtmappingproductsearch2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtmappingproductsearch2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmappingproductsearch2_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnLvHide();
                txtmappingproductsearch2.BackColor = Color.LemonChiffon;
                for (int i = 1; i < DGV_SearchGrid1.ColumnCount; i++)
                {
                    DGV_SearchGrid1.Rows[0].Cells[i].Value = "";
                }
                DGV_SearchGrid1_CurrentCellDirtyStateChanged(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmappingproductsearch2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnMappingsave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingsave_Enter(object sender, EventArgs e)
        {

            try
            {
                btnMappingsave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingsave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnMappingsave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnMappingClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnMappingClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClear_Enter(object sender, EventArgs e)
        {

            try
            {
                btnClear.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClear_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClear.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string result = "";
                int sceduleidupdate = 0, varDeleteFlag = 0;
                //if (varOrderid == 0)
                //{
                //    sceduleidupdate = Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["ID"].Value.ToString());
                //}
                //else
                //{
                //    sceduleidupdate = varOrderid;
                //}
                sceduleidupdate = Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["ID"].Value.ToString());
                if (e.RowIndex != -1)
                {
                    switch (grdSupplierList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmDelete":

                            DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dialogResult == DialogResult.Yes)
                            {

                                SPDataService objspdservice = new SPDataService();
                                result = objspdservice.udfnSupplierMaster(5, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Delete Order Schedule", 0, "", 0, 0, 0, 0, 0, "", "", "", "", 0, "", sceduleidupdate, 0, "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, "","",0,null,0);
                                string[] varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    this.ActiveControl = txtScheduleName;
                                    varDeleteFlag = 1;
                                }
                                else
                                {
                                    DialogResult dialogResult1 = MessageBox.Show(varvalue[1] + " Are you sure want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult1 == DialogResult.Yes)
                                    {
                                        varDeleteFlag = 1;
                                    }
                                }
                                if (varDeleteFlag == 1)
                                {
                                    //SPDataService objspdservice1 = new SPDataService();
                                    //result = objspdservice1.udfnSupplierMaster(10, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Delete Order Schedule", 0, "", 0, 0, 0, 0, 0, "", "", "", "", 0, "", sceduleidupdate, 0, "", "", "", "", "", "", "", "", "", 0, "", 0);
                                    //objspdservice1.CloseConnection();
                                    //string[] varvalue1 = result.Split('~');
                                    //if (varvalue1[0] == "3")
                                    //{
                                    //    this.ActiveControl = txtScheduleName;
                                    //    grdSupplierList.Rows.RemoveAt(this.grdSupplierList.SelectedRows[0].Index);
                                    //    for (int i = 0; i < grdSupplierList.RowCount; i++)
                                    //    {
                                    //        grdSupplierList.Rows[i].Cells["clmsno"].Value = i + 1;
                                    //    }
                                    //    MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //    MainForm.objCP_Supplierlist.udfnList();
                                    //}
                                    //else
                                    //{
                                    //    MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //}
                                    SPDataService objspdservice1 = new SPDataService();
                                    result = objspdservice1.udfnSupplierMaster(10, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Delete Order Schedule", 0, "", 0, 0, 0, 0, 0, "", "", "", "", 0, "", sceduleidupdate, 0, "", "",   "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, "", "",0,null,0);
                                    objspdservice1.CloseConnection();
                                    string[] varvalue1 = result.Split('~');
                                    if (varvalue1[0] == "3")
                                    {
                                        if (result.Split('~')[1] == "1")
                                        {
                                            MainForm.objCP_Verify = new CP_Verify();
                                            MainForm.objCP_Verify.ShowDialog();
                                            varUserID = MainForm.objCP_Verify.varUserId;
                                            if (MainForm.objCP_Verify.flag == 1)
                                            {
                                                result = objspdservice1.udfnSupplierMaster(10, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Delete Order Schedule", 0, "", 0, 0, 0, 0, 0, "", "", "", "", 0, "", sceduleidupdate, 0, "", "", "", "", "",   "", "", 1, "", 0, 0, 0, 0, 0, 0, 0, "","",0,null,0);
                                                objspdservice1.CloseConnection();
                                                if (result.Split('~')[0] == "3")
                                                {
                                                    this.ActiveControl = txtScheduleName;
                                                    grdSupplierList.Rows.RemoveAt(this.grdSupplierList.SelectedRows[0].Index);
                                                    for (int i = 0; i < grdSupplierList.RowCount; i++)
                                                    {
                                                        grdSupplierList.Rows[i].Cells["clmsno"].Value = i + 1;
                                                    }
                                                    MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    MainForm.objCP_Supplierlist.udfnList();
                                                }
                                                else
                                                {
                                                    MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                        }
                                    }
                                    else if (result.Split('~')[0] == "4")
                                    {
                                        MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                udfnScheduleClear();
                                btnAdd.Text = "Save";
                                udfnSetRegularText();
                            }
                            break;


                        case "clmedit":
                            if (pbSupplierid != "")
                            {
                                btnSupplierdeal.Enabled = false;
                                btnSaveOrderType.Enabled = false;
                                tpschedule.Active = false;
                                errCompany.Clear();
                                txtScheduleName.BackColor = Color.White;
                                if (e.RowIndex >= 0)
                                {
                                    scheduleselectedIndex = e.RowIndex;
                                }
                                btnAdd.Text = "Update";
                                pnlScheduleStatus.Enabled = true;
                                SPDataService objspservice = new SPDataService();
                                foreach (DataGridViewRow row in grddays.Rows)
                                {
                                    row.Cells[0].Value = false;
                                }
                                DataSet objDS;
                                int varview = 3;

                                SupplierUpdate = 0;
                                if (Convert.ToInt32(varsupplierID) != 0)
                                {
                                    SupplierUpdate = Convert.ToInt32(varsupplierID);
                                }
                                else
                                {
                                    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                                }
                                varSLNO = Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["clmsno"].Value.ToString());
                                MR_Supplier objMR_Supplier = new MR_Supplier();
                                objMR_Supplier.ViewType = varview;
                                objMR_Supplier.paraSupplierid = Convert.ToInt32(SupplierUpdate);
                                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["ID"].Value.ToString());
                                objDS = objspservice.udfnSupplierList(objMR_Supplier);
                                objspservice.CloseConnection();
                                if (objDS != null)
                                {
                                    if (objDS.Tables[0].Rows.Count > 0)
                                    {
                                        txtScheduleName.Text = objDS.Tables[0].Rows[0]["SCHEDULE"].ToString().Replace("''", "'");
                                        txtsalesmanmobile.Text = objDS.Tables[0].Rows[0]["MOBILE"].ToString().Replace("''", "'");
                                        txtsalesmanname.Text = objDS.Tables[0].Rows[0]["NAME"].ToString().Replace("''", "'");
                                        txtsalesmanwhatsapp.Text = objDS.Tables[0].Rows[0]["WHATSAPP"].ToString().Replace("''", "'");
                                        cmbOrderType.SelectedValue = objDS.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                                        varOrderid = Convert.ToInt32(objDS.Tables[0].Rows[0]["SPSCID"].ToString());
                                        if (objDS.Tables[0].Rows[0]["StatusId"].ToString() == "1")
                                        { rbScheduleActive.Checked = true; }
                                        else if (objDS.Tables[0].Rows[0]["StatusId"].ToString() == "2")
                                        { rbScheduleInactive.Checked = true; }
                                        txtScheduleName.Focus();
                                        cmbTat.SelectedValue = objDS.Tables[0].Rows[0]["SPSC_TAT"].ToString();

                                    }
                                    if (objDS.Tables[1].Rows.Count > 0)
                                    {
                                        // objdatabrand = objDS.Tables[1];
                                        for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                                        {
                                            for (int j = 0; j < grddays.Rows.Count; j++)
                                            {
                                                if (Convert.ToInt32(objDS.Tables[1].Rows[i]["DAYID"].ToString().Replace("''", "'")) == Convert.ToInt32(grddays.Rows[j].Cells["DYID"].Value))
                                                {
                                                    grddays.Rows[j].Cells["clmcheck"].Value = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (objDS.Tables[0].Rows[0]["StatusId"].ToString() == "2")
                                {
                                    txtScheduleName.Enabled = false;
                                    grpSalesmanDetails.Enabled = false;
                                    if (Convert.ToInt32(cmbOrderType.SelectedValue) == 144)
                                    {
                                        grpOrderDetails.Enabled = false;
                                        grddays.Enabled = false;
                                    }
                                    else if (Convert.ToInt32(cmbOrderType.SelectedValue) == 35 || Convert.ToInt32(cmbOrderType.SelectedValue) == 36 || Convert.ToInt32(cmbOrderType.SelectedValue) == 37)
                                    {
                                        grpOrderDetails.Enabled = true;
                                        grddays.Enabled = true;
                                    }
                                }
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

        private void BtnSaveOrderType_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                btnSaveOrderType.Enabled = false;
                SPDataService objspdservice = new SPDataService();
                string result = "", varoriginator = "";
                int Vartype = 0;
                SupplierUpdate = 0;
                if (Convert.ToInt32(varsupplierID) != 0)
                {
                    SupplierUpdate = Convert.ToInt32(varsupplierID);
                }
                else
                {
                    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                }
                if (Convert.ToInt32(cmbReturnPolicy.SelectedValue) != -1 && Convert.ToInt32(cmbReturnPolicy.SelectedValue) != 23)
                {
                    if (cmbReturnType.SelectedValue == null)
                    {
                        errCompany.SetError(cmbReturnType, "Please select return cycle");
                        cmbReturnType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpstate.ShowAlways = true;
                        tpstate.Show("Please select return cycle", cmbReturnType, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        cmbReturnType.BackColor = Color.White;
                        errCompany.Clear();
                    }
                }
                else
                {
                    cmbReturnType.SelectedValue = -1;
                    ;
                }
                if (blnErrorFlag == false)
                {
                    if (btnSaveOrderType.Text == "Update")
                    {
                        result = objspdservice.udfnSupplierMaster(6, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, Convert.ToInt32(cmbReturnPolicy.SelectedValue), Convert.ToInt32(cmbReturnType.SelectedValue), 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Update supplier order type", 0, "", 0, vardayID, varMonthID, varWeekID, vardayMonthID, "", "", "", "", 0, "", 0, 0, "", "", "",   "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, "","",0,null,0);
                    }

                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm.objCP_Supplierlist.udfnList();
                        cmbReturnPolicy.Focus();
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnSaveOrderType.Enabled = true;
                btnSaveOrderType.Focus();
            }
        }
        private void Txtsalesmanmobile_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txtsalesmanwhatsapp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GrdSupplierMappingLoad_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdSupplierMappingLoad.IsCurrentCellDirty)
                {
                    grdSupplierMappingLoad.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSupplierMappingLoad.DataSource as BindingSource).Filter = "([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%'";
                // (grdSupplierMappingLoad.DataSource as BindingSource).Filter = "([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%'";
                //DataTable objdtnew = new DataTable();
                //objdtnew = dtSubGroup.Copy();
                //objdtnew.DefaultView.RowFilter = "([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%'";
                //grdSupplierMappingLoad.DataSource = objdtnew;
                ////  grdSupplierMappingLoad.Columns[0].Frozen = true;
                //grdSupplierMappingLoad.Columns[0].HeaderText = "";
                //grdSupplierMappingLoad.Columns[0].Width = 30;
                //grdSupplierMappingLoad.Columns["S.No."].Width = 50;
                //grdSupplierMappingLoad.Columns["P.I Code"].Width = 100;
                //grdSupplierMappingLoad.Columns["Product Name in Tamil"].Width = 220;
                //grdSupplierMappingLoad.Columns["Unit"].Width = 60;
                //grdSupplierMappingLoad.Columns["Product SubGroup"].Width = 170;
                //grdSupplierMappingLoad.Columns["GROUPID"].Visible = false;
                //grdSupplierMappingLoad.Columns["SUBGROUPID"].Visible = false;
                //grdSupplierMappingLoad.Columns["PRODUCTID"].Visible = false;
                //grdSupplierMappingLoad.Columns["MappedCount"].Visible = false;
                //grdSupplierMappingLoad.Columns["Product Name in English"].Visible = false;
                //grdSupplierMappingLoad.Columns["S.No."].Visible = false;

                //grdSupplierMappingLoad.Columns["S.No."].ReadOnly = true;
                //grdSupplierMappingLoad.Columns["P.I Code"].ReadOnly = true;
                //grdSupplierMappingLoad.Columns["Product Name in Tamil"].ReadOnly = true;
                //grdSupplierMappingLoad.Columns["Unit"].ReadOnly = true;
                //grdSupplierMappingLoad.Columns["Product SubGroup"].ReadOnly = true;
                //grdSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                //if (SearchFlag == 1)
                //{
                //    (grdSupplierMappingLoad.DataSource as BindingSource).Filter = "([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%'";
                //}
                //else
                //{
                //    (grdSupplierMappingLoad.DataSource as DataTable).DefaultView.RowFilter = "([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%'";
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalProducts.Text = grdSupplierMappingLoad.Rows.Count.ToString();
            }
        }
        private void Txtmappingproductsearch2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdFinalSupplierMapping.DataSource as BindingSource).Filter = "([P.I Code]) LIKE '%" + txtmappingproductsearch2.Text + "%'";
                //DataTable objdtnew = new DataTable();
                //objdtnew = dtSubGroupMapping.Copy();
                //objdtnew.DefaultView.RowFilter = "([P.I Code]) LIKE '%" + txtmappingproductsearch2.Text + "%'";
                //grdFinalSupplierMapping.DataSource = objdtnew;
                ////  grdFinalSupplierMapping.Columns[0].Frozen = true;
                //grdFinalSupplierMapping.Columns[0].HeaderText = "";
                //grdFinalSupplierMapping.Columns[0].Width = 30;
                //grdFinalSupplierMapping.Columns["S.No."].Width = 50;
                //grdFinalSupplierMapping.Columns["P.I Code"].Width = 100;
                //grdFinalSupplierMapping.Columns["Product Name in Tamil"].Width = 220;
                //grdFinalSupplierMapping.Columns["Unit"].Width = 60;
                //grdFinalSupplierMapping.Columns["Product SubGroup"].Width = 120;
                //grdFinalSupplierMapping.Columns["GROUPID"].Visible = false;
                //grdFinalSupplierMapping.Columns["SUBGROUPID"].Visible = false;
                //grdFinalSupplierMapping.Columns["PRODUCTID"].Visible = false;
                //grdFinalSupplierMapping.Columns["MappedCount"].Visible = false;
                //grdFinalSupplierMapping.Columns["Product Name in English"].Visible = false;
                //grdSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                //grdFinalSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                //grdFinalSupplierMapping.Columns["S.No."].ReadOnly = true;
                //grdFinalSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                //grdFinalSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                //grdFinalSupplierMapping.Columns["Unit"].ReadOnly = true;
                //grdFinalSupplierMapping.Columns["Product SubGroup"].ReadOnly = true;
                //if (SearchFlag == 0)
                //{
                //    (grdFinalSupplierMapping.DataSource as BindingSource).Filter = "([P.I Code]) LIKE '%" + txtmappingproductsearch2.Text + "%'";
                //}
                //else
                //{
                //    (grdFinalSupplierMapping.DataSource as DataTable).DefaultView.RowFilter = "([P.I Code]) LIKE '%" + txtmappingproductsearch2.Text + "%'";
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (Convert.ToInt32(cmbMappingorderschedule.SelectedValue) != -1)
                {
                    this.grdFinalSupplierMapping.Sort(this.grdFinalSupplierMapping.Columns[2], ListSortDirection.Ascending);
                    for (int i = 0; i < grdFinalSupplierMapping.RowCount; i++)
                    {
                        grdFinalSupplierMapping.Rows[i].Cells["S.No."].Value = i + 1;
                    }
                }
                grdFinalSupplierMapping.ClearSelection();
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
            }
        }
        private void BtnMappingView_Click(object sender, EventArgs e)
        {
            try
            {
                udfnMappingGridsLoad();
                udfnGridRemove();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalProducts.Text = grdSupplierMappingLoad.Rows.Count.ToString();
                txtSearchByProduct1.Text = "";
            }
        }

        private void BtnaddMove_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbMappingorderschedule.SelectedValue) != -1)
                {
                    udfnSubGroupAdd();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(65);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (Convert.ToInt32(cmbMappingorderschedule.SelectedValue) != -1)
                {
                    this.grdFinalSupplierMapping.Sort(this.grdFinalSupplierMapping.Columns[2], ListSortDirection.Ascending);
                    for (int i = 0; i < grdFinalSupplierMapping.RowCount; i++)
                    {
                        grdFinalSupplierMapping.Rows[i].Cells["S.No."].Value = i + 1;
                    }
                }
                grdFinalSupplierMapping.ClearSelection();
                lblTotalProducts.Text = grdSupplierMappingLoad.Rows.Count.ToString();
                txtmappingproductsearch2.Text = "";
                if (grdFinalSupplierMapping.Columns.Count != 0)
                {
                    grdFinalSupplierMapping.Columns[0].ReadOnly = false;
                    grdSupplierMappingLoad.Columns[0].ReadOnly = false;
                }
                //SearchFlag = 0;
            }
        }
        public void udfnSubGroupAdd()
        {
            try
            {
                string varRemoveProduct = "", varAddProduct = "", varGridRemove = "";
                //for (int i = 1; i < DGV_SearchGrid.ColumnCount; i++)
                //{
                //    DGV_SearchGrid.Rows[0].Cells[i].Value = "";
                //}
                //DGV_SearchGrid_CurrentCellDirtyStateChanged(sender, e);
                if (dtSubGroup.Rows.Count > 0)
                {
                    for (int i = 0; i < dtSubGroup.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dtSubGroup.Rows[i][0]) == true)
                        {
                            int varFlag = 0, varcount = 1;
                            for (int j = 0; j < dtSubGroupMapping.Rows.Count; j++)
                            {
                                varRemoveProduct = Convert.ToString(dtSubGroup.Rows[i]["PRODUCTID"]);
                                if (varRemoveProduct == Convert.ToString(dtSubGroupMapping.Rows[j]["PRODUCTID"]))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                dtSubGroupMapping.Rows.Add(false, Convert.ToInt32(dtSubGroupMapping.Rows.Count) + 1, dtSubGroup.Rows[i]["P.I Code"], dtSubGroup.Rows[i]["Product Name in Tamil"], dtSubGroup.Rows[i]["Unit"], dtSubGroup.Rows[i]["Brand"], dtSubGroup.Rows[i]["Product SubGroup"], dtSubGroup.Rows[i]["Product Group"],
                                dtSubGroup.Rows[i]["GROUPID"], dtSubGroup.Rows[i]["SUBGROUPID"], dtSubGroup.Rows[i]["PRODUCTID"], dtSubGroup.Rows[i]["Product Name in English"], dtSubGroup.Rows[i]["MappedCount"]);
                                varModifiedFlag = 1;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < dtSubGroupMapping.Rows.Count; j++)
                            {
                                varAddProduct = Convert.ToString(dtSubGroup.Rows[i]["PRODUCTID"]);
                                if (varAddProduct == Convert.ToString(dtSubGroupMapping.Rows[j]["PRODUCTID"]))
                                {
                                    dtSubGroupMapping.Rows[j].Delete();
                                    dtSubGroupMapping.AcceptChanges();
                                }
                            }
                        }
                    }
                    grdFinalSupplierMapping.DataSource = null;
                    grdFinalSupplierMapping.DataSource = dtSubGroupMapping;
                    //  grdFinalSupplierMapping.Columns[0].Frozen = true;
                    grdFinalSupplierMapping.Columns[0].HeaderText = "";
                    grdFinalSupplierMapping.Columns[0].Width = 30;
                    grdFinalSupplierMapping.Columns["S.No."].Width = 50;
                    grdFinalSupplierMapping.Columns["P.I Code"].Width = 100;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].Width = 220;
                    grdFinalSupplierMapping.Columns["Unit"].Width = 60;
                    grdFinalSupplierMapping.Columns["Product SubGroup"].Width = 120;
                    grdFinalSupplierMapping.Columns["GROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["SUBGROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["PRODUCTID"].Visible = false;
                    grdFinalSupplierMapping.Columns["MappedCount"].Visible = false;
                    grdFinalSupplierMapping.Columns["Product Name in English"].Visible = false;
                    grdSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                    grdFinalSupplierMapping.Columns["S.No."].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Unit"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product SubGroup"].ReadOnly = true;
                    udfnsearchgridHead();
                    udfnGridRemove();
                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
            }
        }
        public void udfnGridRemove()
        {
            try
            {
                //string varRemoveGroup = "";
                //for (int j = 0; j < dtSubGroupMapping.Rows.Count; j++)
                //{
                //    varRemoveGroup = Convert.ToString(grdFinalSupplierMapping.Rows[j].Cells["PRODUCTID"].Value);
                //    for (int i = 0; i < dtSubGroup.Rows.Count; i++)
                //    {
                //        if (varRemoveGroup == Convert.ToString(dtSubGroup.Rows[i]["PRODUCTID"]))
                //        {
                //            dtSubGroup.Rows[i].Delete();
                //            dtSubGroup.AcceptChanges();
                //        }
                //    }
                //}
                //grdSupplierMappingLoad.DataSource = dtSubGroup; 
                HashSet<string> productIdsToRemove = new HashSet<string>();
                foreach (DataGridViewRow row in grdFinalSupplierMapping.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the last row used for adding new entries 
                    string productId = row.Cells["PRODUCTID"].Value?.ToString(); 
                    if (!string.IsNullOrWhiteSpace(productId))
                    {
                        productIdsToRemove.Add(productId);
                    }
                } 
                for (int i =0;i< dtSubGroup.Rows.Count ;  i++)  
                {
                    string productId = Convert.ToString(dtSubGroup.Rows[i]["PRODUCTID"]);
                    if (productIdsToRemove.Contains(productId))
                    {
                        dtSubGroup.Rows[i].Delete(); // Mark row for deletion
                    }
                } 
                dtSubGroup.AcceptChanges();  
                grdSupplierMappingLoad.DataSource = dtSubGroup; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdFinalSupplierMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdFinalSupplierMapping.Columns[e.ColumnIndex].Name)
                    {
                        case "clmMappingRemove":

                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                dtSubGroup.Rows.Add(false, "0", grdFinalSupplierMapping.SelectedRows[0].Cells["P.I Code"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["Product Name in Tamil"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["Unit"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["Product SubGroup"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["GROUPID"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["SUBGROUPID"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["PRODUCTID"].Value, "0", grdFinalSupplierMapping.SelectedRows[0].Cells["MappedCount"].Value);
                                grdFinalSupplierMapping.Rows.RemoveAt(this.grdFinalSupplierMapping.SelectedRows[0].Index);
                                for (int i = 0; i < grdFinalSupplierMapping.RowCount; i++)
                                {
                                    grdFinalSupplierMapping.Rows[i].Cells["S.No."].Value = i + 1;
                                }
                                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
                                dtSubGroup.AcceptChanges();
                                grdSupplierMappingLoad.DataSource = dtSubGroup;
                                // grdSupplierMappingLoad.Columns[0].Frozen = true;
                                grdSupplierMappingLoad.Columns[0].HeaderText = "";
                                grdSupplierMappingLoad.Columns[0].Width = 30;
                                grdSupplierMappingLoad.Columns["S.No."].Width = 50;
                                grdSupplierMappingLoad.Columns["P.I Code"].Width = 100;
                                grdSupplierMappingLoad.Columns["Product Name in Tamil"].Width = 220;
                                grdSupplierMappingLoad.Columns["Unit"].Width = 100;
                                grdSupplierMappingLoad.Columns["Product SubGroup"].Width = 170;
                                grdSupplierMappingLoad.Columns["GROUPID"].Visible = false;
                                grdSupplierMappingLoad.Columns["SUBGROUPID"].Visible = false;
                                grdSupplierMappingLoad.Columns["PRODUCTID"].Visible = false;
                                grdSupplierMappingLoad.Columns["MappedCount"].Visible = false;
                                grdSupplierMappingLoad.Columns["Product Name in English"].Visible = false;
                                grdSupplierMappingLoad.Columns["S.No."].Visible = false;


                                grdSupplierMappingLoad.Columns["S.No."].ReadOnly = true;
                                grdSupplierMappingLoad.Columns["P.I Code"].ReadOnly = true;
                                grdSupplierMappingLoad.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdSupplierMappingLoad.Columns["Unit"].ReadOnly = true;
                                grdSupplierMappingLoad.Columns["Product SubGroup"].ReadOnly = true;
                                grdSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            }
                            break;
                    }
                }
                int vscroll = grdFinalSupplierMapping.FirstDisplayedScrollingRowIndex;
                int hscroll = grdFinalSupplierMapping.FirstDisplayedScrollingColumnIndex;
                int varPRID = Convert.ToInt16(grdFinalSupplierMapping.SelectedRows[0].Cells["PRODUCTID"].Value);
                udfnGetMappedProductCount(varPRID);
                grdFinalSupplierMapping.FirstDisplayedScrollingRowIndex = vscroll;
                grdFinalSupplierMapping.FirstDisplayedScrollingColumnIndex = hscroll;
                // udfnGetProductCount(0);       
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (grdSupplierMappingLoad.RowCount > 0)
                {
                    this.grdSupplierMappingLoad.Sort(this.grdSupplierMappingLoad.Columns[2], ListSortDirection.Ascending);
                }
                grdSupplierMappingLoad.ClearSelection();
            }
        }

        private void BtnMappingsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SupplierUpdate != 0 && SupplierUpdate != -1)
                {
                    if (cmbMappingorderschedule.Text != "")
                    {
                        btnMappingsave.Enabled = false;
                        txtmappingproductsearch2.Text = "";
                        for (int i = 1; i < DGV_SearchGrid1.ColumnCount; i++)
                        {
                            DGV_SearchGrid1.Rows[0].Cells[i].Value = "";
                        }
                        DGV_SearchGrid1_CurrentCellDirtyStateChanged(sender, e);
                        if (Convert.ToInt32(grdFinalSupplierMapping.Rows.Count) > 0)
                        {
                            string VarproductId = "", result = "", varoriginator = "";
                            int Vartype = 0;
                            SPDataService objspdservice = new SPDataService();
                            for (int i = 0; i < grdFinalSupplierMapping.Rows.Count; i++)
                            {
                                //if (Convert.ToBoolean(grdFinalSupplierMapping.Rows[i].Cells[0].Value) == true)
                                //{
                                if (VarproductId == "")
                                {
                                    VarproductId = Convert.ToString(grdFinalSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
                                }
                                else
                                {
                                    VarproductId = VarproductId + ',' + Convert.ToString(grdFinalSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
                                }
                                //  }
                            }

                            if (btnMappingsave.Text == "Save")
                            {
                                varoriginator = "Supplier mapping create";
                                Vartype = 7;

                            }
                            else
                            {
                                varoriginator = "Supplier mapping update";
                                Vartype = 8;
                            }
                            result = objspdservice.udfnSupplierMaster(Vartype, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0,
                                   0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, varoriginator, 0, "", 0, 0, 0, 0, 0, "", "", "", "", 0, "", Convert.ToInt32(cmbMappingorderschedule.SelectedValue), Convert.ToInt32(lblOrderTypeId.Text), VarproductId, "", "",   "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, "", "",0,null,0);
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "3")
                            {
                                MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                varModifiedFlag = 0;
                                if (MainForm.objCP_Supplierlist != null)
                                {
                                    MainForm.objCP_Supplierlist.udfnList();
                                }
                                cmbMappingorderschedule.Focus();
                                if (btnMappingsave.Text == "Update")
                                {
                                    varupdate = "1"; 
                                    //udfnclose();
                                }
                                txtMappingGroup.Text = "";
                                varGroupId = 0;
                                txtMappingSubGroup.Text = "";
                                varSubGroupId = 0;
                                txtBrand.Text = "";
                                varBrandId = 0;
                                cmbStatus.SelectedValue = 0;
                                txtSearchByProduct1.Text = "";
                                txtmappingproductsearch2.Text = "";
                                CmbMappingorderschedule_SelectedIndexChanged(sender, e);
                                //udfnMappingClear();
                            }
                            else
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            objspdservice.CloseConnection();
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(38);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        grdFinalSupplierMapping.DataSource = null;
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(65);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(85);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnMappingsave.Enabled = true;
                btnMappingsave.Focus();
            }
        }
        public void udfnMappingClear()
        {
            try
            {
                //cmbMappingorderschedule.SelectedValue = -1;
                //udfndataLoad();
                //cmbMappingSubGroup.SelectedValue = 0;
                //cmbMappingGroup.SelectedValue = 0;
                varGroupId = 0;
                varSubGroupId = 0;
                txtMappingGroup.Text = "";
                txtBrand.Text = "";
                varBrandId = 0;
                txtMappingSubGroup.Text = "";
                txtSearchByProduct1.Text = "";
                txtmappingproductsearch2.Text = "";
                foreach (DataGridViewRow row in grdSupplierMappingLoad.Rows)
                {
                    row.Cells[0].Value = false;
                }
                grdFinalSupplierMapping.DataSource = null;
                lblTotalMappingProduct.Text = "0";
                errCompany.Clear();
                udfnMappingGridsLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                grdFinalSupplierMapping.DataSource = null;
                lblTotalMappingProduct.Text = "0"; udfnMappingClear();
                txtordertype.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingClose_Click(object sender, EventArgs e)
        {
            try
            {
                //DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dialogResult == DialogResult.Yes)
                //{
                udfnclose();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Grddays_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grddays.IsCurrentCellDirty)
                {
                    grddays.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Supplier_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void TxtSearchByProduct2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdViewSupplierMapping.DataSource as BindingSource).Filter = "([Product Name in Tamil]) LIKE '%" + txtSearchByProduct2.Text + "%' OR ([P.I Code]) LIKE '%" + txtSearchByProduct2.Text + "%' OR ([Product Name in English]) LIKE '%" + txtSearchByProduct2.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            //try
            //{
            //    if (SearchFlag == 1)
            //    {
            //        (grdViewSupplierMapping.DataSource as BindingSource).Filter = "([Product Name in Tamil]) LIKE '%" + txtSearchByProduct2.Text + "%' OR ([P.I Code]) LIKE '%" + txtSearchByProduct2.Text + "%' OR ([Product Name in English]) LIKE '%" + txtSearchByProduct2.Text + "%' ";
            //    }
            //    else
            //    {
            //        (grdViewSupplierMapping.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in Tamil]) LIKE '%" + txtSearchByProduct2.Text + "%' OR ([P.I Code]) LIKE '%" + txtSearchByProduct2.Text + "%' OR ([Product Name in English]) LIKE '%" + txtSearchByProduct2.Text + "%' ";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            //finally
            //{
            //    lblMappedproductcountlist.Text = Convert.ToString(grdViewSupplierMapping.Rows.Count);
            //}
        }

        private void GrdSupplierList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdSupplierList.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {

                grdSupplierList.ClearSelection();
            }
        }

        private void GrdSupplierMappingLoad_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdSupplierMappingLoad.RowCount; i++)
                {
                    if (Convert.ToString(grdSupplierMappingLoad.Rows[i].Cells["MappedCount"].Value) != "0")
                    {
                        grdSupplierMappingLoad.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                grdSupplierMappingLoad.ClearSelection();
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

        private void GrdFinalSupplierMapping_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdFinalSupplierMapping.ClearSelection();
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

        private void GrdViewSupplierMapping_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdViewSupplierMapping.ClearSelection();
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

        private void TxtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAContactNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txtwhatsapp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txtsalesmanwhatsapp_Enter(object sender, EventArgs e)
        {

            try
            {
                txtsalesmanwhatsapp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierMappingLoad_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

        private void Grddays_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grddays.ClearSelection();
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

        private void BtnaddMove_Enter(object sender, EventArgs e)
        {
            try
            {
                BtnaddMove.BackColor = Color.LemonChiffon;
                udfnLvHide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnaddMove_Leave(object sender, EventArgs e)
        {
            try
            {
                BtnaddMove.BackColor = Color.Transparent;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int errorflag = 0; int count = 0;
                if (Convert.ToString(cmbOrderType.SelectedValue) == "" || Convert.ToString(cmbOrderType.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbOrderType, "Please select order type");
                    cmbOrderType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please select order type", cmbOrderType, 5000);
                    errorflag = 1;
                }
                if (txtsalesmanmobile.Text.Length != 10 && txtsalesmanmobile.Text != "")
                {
                    errCompany.SetError(txtsalesmanmobile, "Please enter valid salesman mobile No.");
                    txtsalesmanmobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpsalemanph.ShowAlways = true;
                    tpsalemanph.Show("Please enter valid salesman mobile No.", txtsalesmanmobile, 5000);
                    errorflag = 1;
                }
                if (txtsalesmanwhatsapp.Text.Trim() != "")
                {
                    if (txtsalesmanwhatsapp.Text.Length != 10)
                    {
                        errCompany.SetError(txtsalesmanwhatsapp, "Please enter valid salesman whatsapp No.");
                        txtsalesmanwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpsalemanph.ShowAlways = true;
                        tpsalemanph.Show("Please enter valid salesman whatsapp No.", txtsalesmanwhatsapp, 5000);
                        errorflag = 1;
                    }
                }
                if (txtScheduleName.Text.Trim() == "")
                {
                    errCompany.SetError(txtScheduleName, "Please enter the schedule.");
                    txtScheduleName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpschedule.ShowAlways = true;
                    tpschedule.Show("Please enter the schedule.", txtScheduleName, 5000);
                    errorflag = 1;
                }
                if (rbScheduleActive.Checked == true)
                {
                    if (Convert.ToInt32(cmbOrderType.SelectedValue) != 144)//|| Convert.ToInt32(cmbOrderType.SelectedValue) == 37)
                    {
                        for (int i = 0; i < grddays.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(grddays.Rows[i].Cells["clmcheck"].Value) == true)
                            {
                                count = count + 1;
                            }
                        }
                        if (count == 0)
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(56);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            errorflag = 1;
                        }
                    }
                }
                if (errorflag == 0)
                {
                    udfnSupplierOrderSave(sender, e);
                    udfntphide();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void udfnSupplierOrderSave(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                btnAdd.Enabled = false;
                int varflag = 0;
                errCompany.Clear();
                udfnSchedulecolorchange();
                if (blnErrorFlag == false)
                {
                    if (btnAdd.Text == "Save")
                    {
                        foreach (DataGridViewRow row in grdSupplierList.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                            {
                                // string gridValue1 = row.Cells[5].Value.ToString();
                                string gridValue2 = row.Cells[1].Value.ToString().Trim().ToUpper();

                                //if (gridValue1 == Convert.ToString(cmbOrderType.Text))
                                //{
                                //    varflag = 1;
                                //}
                                if (string.Equals(gridValue2, txtScheduleName.Text.Trim().ToUpper(), StringComparison.OrdinalIgnoreCase))
                                {
                                    varflag = 2;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in grdSupplierList.Rows)
                        {
                            //if (row.Cells[0].Value != null && Convert.ToString(row.Cells[0].Value) != Convert.ToString(grdSupplierList.SelectedRows[0].Cells["clmsno"].Value) && row.Cells[1].Value != null)

                            if (row.Cells[0].Value != null && Convert.ToString(row.Cells[0].Value) != Convert.ToString(varSLNO) && row.Cells[1].Value != null)
                            {
                                //string gridValue1 = row.Cells[5].Value.ToString();
                                string gridValue2 = row.Cells[1].Value.ToString().Trim().ToUpper();

                                //if (gridValue1 == Convert.ToString(cmbOrderType.Text))
                                //{
                                //    varflag = 1;
                                //}
                                if (string.Equals(gridValue2, txtScheduleName.Text.Trim().ToUpper(), StringComparison.OrdinalIgnoreCase))
                                {
                                    varflag = 2;
                                }
                            }
                        }
                    }
                    if (varflag == 0)
                    {
                        string VarTotalDays = "", VarDaysname = "";
                        for (int i = 0; i < grddays.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(grddays.Rows[i].Cells["clmcheck"].Value) == true)
                            {
                                if (VarTotalDays == "")
                                {
                                    VarTotalDays = Convert.ToString(grddays.Rows[i].Cells["DYID"].Value);
                                }
                                else
                                {
                                    VarTotalDays = VarTotalDays + ',' + Convert.ToString(grddays.Rows[i].Cells["DYID"].Value);
                                }

                                if (VarDaysname == "")
                                {
                                    VarDaysname = Convert.ToString(grddays.Rows[i].Cells["DY_Name"].Value);
                                }
                                else
                                {
                                    VarDaysname = VarDaysname + ',' + Convert.ToString(grddays.Rows[i].Cells["DY_Name"].Value);
                                }
                            }
                        }
                        if (VarTotalDays != "" || Convert.ToInt32(cmbOrderType.SelectedValue) == 144)
                        {
                            SupplierUpdate = 0;
                            if (Convert.ToInt32(varsupplierID) != 0)
                            {
                                SupplierUpdate = Convert.ToInt32(varsupplierID);
                            }
                            else
                            {
                                SupplierUpdate = Convert.ToInt32(pbSupplierid);
                            }

                            SPDataService objspdservice = new SPDataService();
                            string result = "", varoriginator = "";
                            int Vartype = 0, count = 0, varScheduleStatusid = 0;
                            if (rbScheduleActive.Checked == true)
                            { varScheduleStatusid = 1; }
                            else if (rbScheduleInactive.Checked == true)
                            { varScheduleStatusid = 2; }

                            if (btnAdd.Text == "Save")
                            {
                                count = grdSupplierList.Rows.Count + 1;
                            }
                            else
                            {
                                count = Convert.ToInt32(varSLNO);
                            }
                            int sceduleidupdate = 0;
                            if (btnAdd.Text == "Save")
                            {
                                varoriginator = "Supplier Order Create";
                                Vartype = 3;
                                sceduleidupdate = varOrderid;
                            }
                            else
                            {
                                if (varOrderid == 0)
                                {
                                    sceduleidupdate = Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["ID"].Value.ToString());
                                }
                                else
                                {
                                    sceduleidupdate = varOrderid;
                                }
                                varoriginator = "Supplier Order Update";
                                Vartype = 4;
                            }
                            result = objspdservice.udfnSupplierMaster(Vartype, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0,
                                Convert.ToInt32(cmbReturnPolicy.SelectedValue), varrecyclecode, 0, 0, 0, 0, Convert.ToString(varScheduleStatusid), MainForm.pbUserID, MainForm.pbIpAddress, varoriginator,
                                0, "", 0, vardayID, varMonthID, varWeekID, vardayMonthID, txtsalesmanname.Text, txtScheduleName.Text.Trim(), txtsalesmanmobile.Text,
                                txtsalesmanwhatsapp.Text, Convert.ToInt32(cmbOrderType.SelectedValue), VarTotalDays, sceduleidupdate, 0, "", "", "", "", "", "",   "", 0, "", Convert.ToInt32(cmbTat.SelectedValue), 0, 0, 0, 0, 0, 0, "","",0,null,0);
                            objspdservice.CloseConnection();
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "3")
                            {
                                MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grddays.ClearSelection();
                                if (PoScheduleFlag == 0)
                                {
                                    MainForm.objCP_Supplierlist.udfnList();
                                }
                                this.ActiveControl = txtScheduleName;
                                if (btnAdd.Text == "Update")
                                {
                                    varupdate = "1";
                                    //grdSupplierList.Rows.Clear ();
                                    //udfnEdit();
                                    if (scheduleselectedIndex >= 0 && scheduleselectedIndex < grdSupplierList.Rows.Count)
                                    {
                                        grdSupplierList.Rows.RemoveAt(scheduleselectedIndex);
                                        scheduleselectedIndex = -1;  // Reset the index after deletion.
                                        varScheduleStsCount = Convert.ToInt32(varvalue[2]);
                                    }
                                }
                                else
                                {
                                    varOrderid = Convert.ToInt32(varvalue[2]);
                                    varScheduleStsCount = Convert.ToInt32(varvalue[3]);
                                }
                                //grdSupplierList.Rows.Add(count, txtScheduleName.Text, txtsalesmanname.Text, txtsalesmanmobile.Text, txtsalesmanwhatsapp.Text, Convert.ToString(cmbOrderType.Text), varOrderid, VarDaysname, VarTotalDays, varOrderid);
                                udfnSaveGrdAdd();
                                udfnScheduleClear();
                                btnAdd.Text = "Save";
                                txtScheduleName.Enabled = true;
                                grpSalesmanDetails.Enabled = true;
                                grpOrderDetails.Enabled = true;
                                grddays.Enabled = true;
                                rbScheduleActive.Checked = true;
                                pnlScheduleStatus.Enabled = false;
                                cmbOrderType.SelectedValue = 144;
                                udfnSetRegularText();
                            }
                            else
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(56);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        //if (varflag == 1)
                        //{
                        //    SPDataService objDServ = new SPDataService();
                        //    string varMessage = objDServ.udfnGetMessages(40);
                        //    objDServ.CloseConnection();
                        //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        if (varflag == 2)
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(39);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    btnAdd.Enabled = true;
                    txtScheduleName.Focus();
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnAdd.Focus();
                    varOrderid = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                grdSupplierList.ClearSelection();
                btnAdd.Enabled = true;
                btnSupplierdeal.Enabled = true;
                btnSaveOrderType.Enabled = true;
            }
        }
        public void udfnSaveGrdAdd()
        {
            MR_Supplier objMR_Supplier = new MR_Supplier();
            objMR_Supplier.ViewType = 7;
            objMR_Supplier.paraSupplierid = Convert.ToInt32(SupplierUpdate);
            SPDataService objspservice = new SPDataService();
            DataSet objDS;
            objDS = objspservice.udfnSupplierList(objMR_Supplier);
            objspservice.CloseConnection();
            if (objDS.Tables[0].Rows.Count > 0)
            {
                grdSupplierList.Rows.Clear();
                for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                {
                    grdSupplierList.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[0].Rows[i]["SCHEDULE"]), Convert.ToString(objDS.Tables[0].Rows[i]["SALEMAN"]),
                    Convert.ToString(objDS.Tables[0].Rows[i]["MOBILE"]), Convert.ToString(objDS.Tables[0].Rows[i]["WHATSAPP"]), Convert.ToString(objDS.Tables[0].Rows[i]["ORDERTYPE"]), varOrderid
                    , Convert.ToString(objDS.Tables[0].Rows[i]["ORDERDAYS"]), Convert.ToString(objDS.Tables[0].Rows[i]["TAT"]), Convert.ToString(objDS.Tables[0].Rows[i]["DAYID"]), Convert.ToString(objDS.Tables[0].Rows[i]["ID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Status"]));

                }
                txtScheduleName.Text = "";
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

        public void udfnGrdevent()
        {
            try
            {
                if (txtCity.Text != "")
                {
                    ListViewItem selectedItem = lvCity.SelectedItems[0];
                    txtCity.Text = selectedItem.SubItems[0].Text;
                    varCityname = selectedItem.SubItems[0].Text;
                    lblcity.Text = selectedItem.SubItems[2].Text;
                    varTINNo = selectedItem.SubItems[3].Text;
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
                txtBankShortName.BackColor = Color.White;
                //if (Convert.ToString(txtBankShortName.Text).Trim() == "")
                //{
                //    errCompany.SetError(txtBankShortName, "Please enter bank short name");
                //    txtBankShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpBankShortName.ShowAlways = true;
                //    tpBankShortName.Show("Please enter bank short name", txtBankShortName, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    txtBankShortName.BackColor = Color.White;
                //}
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
                txtbranchname.BackColor = Color.White;
                //if (Convert.ToString(txtbranchname.Text).Trim() == "")
                //{
                //    errCompany.SetError(txtbranchname, "Please enter branch name");
                //    txtbranchname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpBranchName.ShowAlways = true;
                //    tpBranchName.Show("Please enter branch name", txtbranchname, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    txtbranchname.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAccno_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // This will prevent the character from being entered in the TextBox
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIFScode_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // This will prevent the character from being entered in the TextBox
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSupplierdeal_Click(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                string result = "", varoriginator = "";
                int Vartype = 0;
                SupplierUpdate = 0;
                if (Convert.ToInt32(varsupplierID) != 0)
                {
                    SupplierUpdate = Convert.ToInt32(varsupplierID);
                }
                else
                {
                    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                }
                if (btnSaveOrderType.Text == "Update")
                {
                    result = objspdservice.udfnSupplierMaster(9, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Update supplier dealt brand", 0, "", 0, 0, 0, 0, 0, "", "", "", "", 0, "", 0, 0, "", "", "",  "", "", txtOtherBrands.Text, "", 0, "", 0, 0, 0, 0, 0, 0, 0, "", "",0,null,0);
                }

                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Supplierlist.udfnList();
                    cmbReturnPolicy.Focus();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPaymentMode_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPaymentMode.IsCurrentCellDirty)
                {
                    grdPaymentMode.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void GrdPaymentMode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (grdPaymentMode.Columns[e.ColumnIndex].Name == "clmpaymentcheck" && e.RowIndex >= 0)
                {
                    DataGridViewCheckBoxCell checkBoxCell = grdPaymentMode.Rows[e.RowIndex].Cells["clmpaymentcheck"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {
                        checkBoxCell.Value = !(bool)(checkBoxCell.Value ?? false);
                        grdPaymentMode.EndEdit(); // Commit the change
                    }
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Grbform_Enter(object sender, EventArgs e)
        {

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

        private void TxtMappingGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvMappingSubGroup.Visible = false;
                lvBrand.Visible = false;
                txtMappingGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMappingGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMappingGroup.BackColor = Color.White;
                if (txtMappingGroup.Text.Trim() == "") { varGroupId = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMappingSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvMappingGroup.Visible = false;
                lvBrand.Visible = false;
                txtMappingSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMappingSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMappingSubGroup.BackColor = Color.White;
                if (txtMappingSubGroup.Text.Trim() == "") { varSubGroupId = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvGroup()
        {
            try
            {
                if (txtMappingGroup.Text != "")
                {
                    ListViewItem selectedItem = lvMappingGroup.SelectedItems[0];
                    txtMappingGroup.Text = selectedItem.SubItems[0].Text;
                    varGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvMappingGroup.Visible = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvSubGroup()
        {
            try
            {
                if (txtMappingSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvMappingSubGroup.SelectedItems[0];
                    txtMappingSubGroup.Text = selectedItem.SubItems[0].Text;
                    varSubGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvMappingSubGroup.Visible = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvMappingGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvGroup();
                    txtMappingSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMappingSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvMappingSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtMappingSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(10, 0, "", varGroupId, 0, txtMappingSubGroup.Text, 0, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {

                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvMappingSubGroup.Items.Add(objList);
                                }
                                lvMappingSubGroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvMappingSubGroup.Visible = false;
                    lvMappingSubGroup.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvMappingGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvGroup();
                txtMappingSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvMappingSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvSubGroup();
                    txtBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvMappingSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvSubGroup();
                txtBrand.Focus();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMappingGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvMappingGroup.Items.Count == 0 || txtMappingGroup.Text == "")
                    {
                        txtMappingGroup.Focus();
                        lvMappingGroup.Visible = false;
                    }
                    else
                    {
                        lvMappingGroup.Focus();
                    }
                    if (lvMappingGroup.Items.Count > 0)
                    {
                        lvMappingGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtMappingSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMappingSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvMappingSubGroup.Items.Count == 0 || txtMappingSubGroup.Text == "")
                    {
                        txtMappingSubGroup.Focus();
                        lvMappingSubGroup.Visible = false;
                    }
                    else
                    {
                        lvMappingSubGroup.Focus();
                    }
                    if (lvMappingSubGroup.Items.Count > 0)
                    {
                        lvMappingSubGroup.Items[0].Selected = true;
                    }
                }

                if (e.KeyCode == Keys.Enter)
                {
                    txtBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPaymentMode_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdPaymentMode.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMappingGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvMappingGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtMappingGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtMappingGroup.Text, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvMappingGroup.Items.Add(objList);
                                }
                                lvMappingGroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvMappingGroup.Visible = false;
                    lvMappingGroup.Items.Clear();
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

        private void Txtcreditlimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Reject the key
                }
                else if (e.KeyChar == '.' && txtcreditlimit.Text.IndexOf('.') > -1)
                {
                    e.Handled = true; // Reject the key
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtopening_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Reject the key
                }
                else if (e.KeyChar == '.' && txtopening.Text.IndexOf('.') > -1)
                {
                    e.Handled = true; // Reject the key
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappedorderrype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BeginInvoke(new Action(() => cmbMappedorderrype.Select(int.MaxValue, 0)));
                mappedproductsfilter();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappedorderrype_Leave(object sender, EventArgs e)
        {
            try
            {

                cmbMappedorderrype.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbMappedorderrype_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSearchByProduct2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappedorderrype_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbMappedorderrype.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtbrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtBrand.Text.Length > 0)
                {
                    objDs = objspdservice.udfnBrandList(7, "", varGroupId, varSubGroupId, 0, txtBrand.Text.Trim(), 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["BD_EName"].ToString(), objDs.Tables[0].Rows[i]["BD_TName"].ToString(), objDs.Tables[0].Rows[i]["BDID"].ToString(), };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvBrand.Items.Add(objList);
                                }
                                lvBrand.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvBrand.Visible = false;
                    lvBrand.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtbrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvBrand.Items.Count == 0 || txtBrand.Text == "")
                    {
                        txtBrand.Focus();
                        lvBrand.Visible = false;
                    }
                    else
                    {
                        lvBrand.Focus();
                    }
                    if (lvBrand.Items.Count > 0)
                    {
                        lvBrand.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtbrand_Leave(object sender, EventArgs e)
        {

            try
            {
                txtBrand.BackColor = Color.White;
                if (txtBrand.Text.Trim() == "")
                {
                    varBrandId = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtbrand_Enter(object sender, EventArgs e)
        {
            try
            {
                lvMappingSubGroup.Visible = false;
                lvMappingGroup.Visible = false;
                txtBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvBrand();
                    btnMappingView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvBrand_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvBrand();
                btnMappingView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvBrand()
        {
            try
            {
                if (txtBrand.Text != "")
                {
                    ListViewItem selectedItem = lvBrand.SelectedItems[0];
                    txtBrand.Text = selectedItem.SubItems[0].Text;
                    varBrandId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvBrand.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dialogResult == DialogResult.Yes)
                //{
                if (dtSubGroup == null)
                {
                    udfnInitSubgroup();
                }
                for (int k = 1; k < DGV_SearchGrid1.ColumnCount; k++)
                {
                    DGV_SearchGrid1.Rows[0].Cells[k].Value = "";
                }
                DGV_SearchGrid1_CurrentCellDirtyStateChanged(sender, e);
            L: for (int i = 0; i < dtSubGroupMapping.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtSubGroupMapping.Rows[i][0]) == true)
                    {
                        int varSlNo = 1;
                        if (dtSubGroup != null)
                        { varSlNo = dtSubGroup.Rows.Count + 1; }
                        varModifiedFlag = 1;
                        dtSubGroup.Rows.Add(false, varSlNo, dtSubGroupMapping.Rows[i]["P.I Code"],
                        dtSubGroupMapping.Rows[i]["Product Name in Tamil"],
                        dtSubGroupMapping.Rows[i]["Unit"],
                        dtSubGroupMapping.Rows[i]["Brand"],
                        dtSubGroupMapping.Rows[i]["Product SubGroup"],
                        dtSubGroupMapping.Rows[i]["Product Group"],
                        dtSubGroupMapping.Rows[i]["GROUPID"],
                        dtSubGroupMapping.Rows[i]["SUBGROUPID"],
                        dtSubGroupMapping.Rows[i]["PRODUCTID"], dtSubGroupMapping.Rows[i]["Product Name in English"],
                        dtSubGroupMapping.Rows[i]["MappedCount"]);
                        dtSubGroup.AcceptChanges();
                        //for (int j = 0; j < dtSubGroupMapping.Rows.Count; j++)
                        //{
                        //    if (Convert.ToString(grdFinalSupplierMapping.Rows[i].Cells["PRODUCTID"].Value) == Convert.ToString(dtSubGroupMapping.Rows[j]["PRODUCTID"]))
                        //    {
                        dtSubGroupMapping.Rows.RemoveAt(i);
                        dtSubGroupMapping.AcceptChanges();
                        goto L;
                        //  }
                        //  }
                    }
                }
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
                grdSupplierMappingLoad.DataSource = dtSubGroup;
                // grdSupplierMappingLoad.Columns[0].Frozen = true;
                grdSupplierMappingLoad.Columns[0].HeaderText = "";
                grdSupplierMappingLoad.Columns[0].Width = 30;
                grdSupplierMappingLoad.Columns["S.No."].Width = 50;
                grdSupplierMappingLoad.Columns["P.I Code"].Width = 100;
                grdSupplierMappingLoad.Columns["Product Name in Tamil"].Width = 220;
                grdSupplierMappingLoad.Columns["Unit"].Width = 60;
                grdSupplierMappingLoad.Columns["Product SubGroup"].Width = 170;
                grdSupplierMappingLoad.Columns["GROUPID"].Visible = false;
                grdSupplierMappingLoad.Columns["SUBGROUPID"].Visible = false;
                grdSupplierMappingLoad.Columns["MappedCount"].Visible = false;
                grdSupplierMappingLoad.Columns["PRODUCTID"].Visible = false;
                grdSupplierMappingLoad.Columns["Product Name in English"].Visible = false;
                grdSupplierMappingLoad.Columns["S.No."].Visible = false;
                grdSupplierMappingLoad.Columns["S.No."].ReadOnly = true;
                grdSupplierMappingLoad.Columns["P.I Code"].ReadOnly = true;
                grdSupplierMappingLoad.Columns["Product Name in Tamil"].ReadOnly = true;
                grdSupplierMappingLoad.Columns["Unit"].ReadOnly = true;
                grdSupplierMappingLoad.Columns["Product SubGroup"].ReadOnly = true;
                grdSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                udfnSearchGridHead();


                grdFinalSupplierMapping.DataSource = dtSubGroupMapping;
                // grdFinalSupplierMapping.Columns[0].Frozen = true;
                grdFinalSupplierMapping.Columns[0].HeaderText = "";
                grdFinalSupplierMapping.Columns[0].Width = 30;
                grdFinalSupplierMapping.Columns["S.No."].Width = 50;
                grdFinalSupplierMapping.Columns["P.I Code"].Width = 100;
                grdFinalSupplierMapping.Columns["Product Name in Tamil"].Width = 220;
                grdFinalSupplierMapping.Columns["Unit"].Width = 60;
                grdFinalSupplierMapping.Columns["Product SubGroup"].Width = 120;
                grdFinalSupplierMapping.Columns["GROUPID"].Visible = false;
                grdFinalSupplierMapping.Columns["SUBGROUPID"].Visible = false;
                grdFinalSupplierMapping.Columns["PRODUCTID"].Visible = false;
                grdFinalSupplierMapping.Columns["MappedCount"].Visible = false;
                grdFinalSupplierMapping.Columns["Product Name in English"].Visible = false;
                grdSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                grdFinalSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                grdFinalSupplierMapping.Columns["S.No."].ReadOnly = true;
                grdFinalSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                grdFinalSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                grdFinalSupplierMapping.Columns["Unit"].ReadOnly = true;
                grdFinalSupplierMapping.Columns["Product SubGroup"].ReadOnly = true;

                for (int j = 0; j < grdFinalSupplierMapping.RowCount; j++)
                {
                    grdFinalSupplierMapping.Rows[j].Cells["S.No."].Value = j + 1;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalProducts.Text = grdSupplierMappingLoad.Rows.Count.ToString();
                grdFinalSupplierMapping.Columns[0].ReadOnly = false;
                grdSupplierMappingLoad.Columns[0].ReadOnly = false;
            }
        }
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdSupplierMappingLoad.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSupplierMappingLoad);
                objDser.CloseConnection();
                grdSupplierMappingLoad.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            finally
            {
                SearchFlag = 1;
            }
        }

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                //if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                //    return;
                ////if (DGV_SearchGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Name == "Image")
                ////    return;
                //if ((e.ColumnIndex == 0))  //|| e.ColumnIndex == IntDispIndex /*If not our desired columns*/
                //    return;

                //if (e.Value != DBNull.Value && e.Value == "")  /*If value is null*/
                //{
                //    e.Paint(e.CellBounds, DataGridViewPaintParts.All
                //        & ~(DataGridViewPaintParts.ContentForeground));

                //    TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                //        e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                //    e.Handled = true;
                //}
                //DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdSupplierMappingLoad.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdSupplierMappingLoad.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdSupplierMappingLoad.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            // Sort a new column and remove the old SortGlyph.
                            direction = ListSortDirection.Ascending;
                            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                        }
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    grdSupplierMappingLoad.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdSupplierMappingLoad.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdSupplierMappingLoad.ColumnCount > 0)
                {
                    grdSupplierMappingLoad.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdSupplierMappingLoad.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdSupplierMappingLoad.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdSupplierMappingLoad.Width > grdSupplierMappingLoad.HorizontalScrollingOffset && grdSupplierMappingLoad.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierMappingLoad_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdSupplierMappingLoad.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdSupplierMappingLoad.Width > grdSupplierMappingLoad.HorizontalScrollingOffset && grdSupplierMappingLoad.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdSupplierMappingLoad);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdSupplierMappingLoad.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
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

        private void udfnScrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdFinalSupplierMapping.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGrid1.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid1.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGrid1.Rows[rowIndex].Cells[i].Value = "";
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
        private void udfntab4scrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdViewSupplierMapping.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGridPro.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGridPro.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGridPro.Rows[rowIndex].Cells[i].Value = "";
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
        private void DGV_SearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }


        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.Text = "";
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdSupplierMappingLoad.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSupplierMappingLoad);
                objDser.CloseConnection();
                grdSupplierMappingLoad.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                lblTotalProducts.Text = grdSupplierMappingLoad.Rows.Count.ToString();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdFinalSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid1, grdFinalSupplierMapping);
                objDser.CloseConnection();
                grdFinalSupplierMapping.HorizontalScrollingOffset = DGV_SearchGrid1.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            finally
            {
                //SearchFlag = 1; 
            }
        }

        private void DGV_SearchGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGrid1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }
        private void DGV_SearchGrid1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid1.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdFinalSupplierMapping.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdFinalSupplierMapping.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn
                            &&
                            grdFinalSupplierMapping.SortOrder == SortOrder.Ascending
                            )
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            // Sort a new column and remove the old SortGlyph.
                            direction = ListSortDirection.Ascending;
                            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                        }
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    grdFinalSupplierMapping.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGrid1.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGrid1.HorizontalScrollingOffset = grdFinalSupplierMapping.HorizontalScrollingOffset;
                    DGV_SearchGrid1.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdFinalSupplierMapping.ColumnCount > 0)
                {
                    grdFinalSupplierMapping.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid1.HorizontalScrollingOffset = grdFinalSupplierMapping.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                txtmappingproductsearch2.Text = "";
                if (DGV_SearchGrid1.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdFinalSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid1, grdFinalSupplierMapping);
                objDser.CloseConnection();
                grdFinalSupplierMapping.HorizontalScrollingOffset = DGV_SearchGrid1.HorizontalScrollingOffset;
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdFinalSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid1, grdFinalSupplierMapping);
                objDser.CloseConnection();
                grdFinalSupplierMapping.HorizontalScrollingOffset = DGV_SearchGrid1.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdFinalSupplierMapping.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid1.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdFinalSupplierMapping.Width > grdFinalSupplierMapping.HorizontalScrollingOffset && grdFinalSupplierMapping.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid1.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid1.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdFinalSupplierMapping_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdFinalSupplierMapping.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid1.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdFinalSupplierMapping.Width > grdFinalSupplierMapping.HorizontalScrollingOffset && grdFinalSupplierMapping.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid1.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid1.Invalidate();
                udfnScrollVisible(DGV_SearchGrid1, grdFinalSupplierMapping);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnLvHide();
                cmbStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnMappingView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_Leave(object sender, EventArgs e)
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

        private void CmbStatus_KeyPress(object sender, KeyPressEventArgs e)
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
        private void GrdSupplierMappingLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    int vscroll = grdSupplierMappingLoad.FirstDisplayedScrollingRowIndex;
                    int hscroll = grdSupplierMappingLoad.FirstDisplayedScrollingColumnIndex;
                    int varProId = Convert.ToInt16(grdSupplierMappingLoad.SelectedRows[0].Cells["PRODUCTID"].Value);
                    udfnGetProductCount(varProId);
                    grdSupplierMappingLoad.FirstDisplayedScrollingRowIndex = vscroll;
                    grdSupplierMappingLoad.FirstDisplayedScrollingColumnIndex = hscroll;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdViewSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridPro, grdViewSupplierMapping);
                objDser.CloseConnection();
                grdViewSupplierMapping.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridPro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdViewSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridPro, grdViewSupplierMapping);
                objDser.CloseConnection();
                grdViewSupplierMapping.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            finally
            {
                // SearchFlag = 1;
            }
        }

        private void DGV_SearchGridPro_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0)) /*If not our desired columns*/
                                           //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGridPro.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridPro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = grdViewSupplierMapping.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = grdViewSupplierMapping.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    grdViewSupplierMapping.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }
            grdViewSupplierMapping.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;

            DataGridViewColumn DGV = DGV_SearchGridPro.Columns[e.ColumnIndex];
            DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

            DGV_SearchGridPro.HorizontalScrollingOffset = grdViewSupplierMapping.HorizontalScrollingOffset;
            DGV_SearchGridPro.FirstDisplayedScrollingRowIndex = 0;
        }

        private void DGV_SearchGridPro_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdViewSupplierMapping.ColumnCount > 0)
                {
                    grdViewSupplierMapping.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGridPro.HorizontalScrollingOffset = grdViewSupplierMapping.HorizontalScrollingOffset;
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

        private void RbScheduleActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbScheduleActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbScheduleActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrderType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbScheduleActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbScheduleActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbScheduleInactive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbScheduleInactive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbScheduleInactive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrderType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbScheduleInactive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbScheduleInactive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbInactive_Enter(object sender, EventArgs e)
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
        private void RbInactive_Leave(object sender, EventArgs e)
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
        private void DGV_SearchGridPro_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGridPro.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGridPro.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdViewSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridPro, grdViewSupplierMapping);
                objDser.CloseConnection();
                grdViewSupplierMapping.HorizontalScrollingOffset = DGV_SearchGridPro.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGridPro_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdViewSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridPro, grdViewSupplierMapping);
                objDser.CloseConnection();
                grdViewSupplierMapping.HorizontalScrollingOffset = DGV_SearchGridPro.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGridPro_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdViewSupplierMapping.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridPro.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdViewSupplierMapping.Width > grdViewSupplierMapping.HorizontalScrollingOffset && grdViewSupplierMapping.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdViewSupplierMapping_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdViewSupplierMapping.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridPro.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdViewSupplierMapping.Width > grdViewSupplierMapping.HorizontalScrollingOffset && grdViewSupplierMapping.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridPro.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridPro.Invalidate();
                udfntab4scrollVisible(DGV_SearchGridPro, grdViewSupplierMapping);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnsearchgridHead_MappedProducts()
        {
            //try
            //{
            //    udfnGridSearchHeading(grdViewSupplierMapping, DGV_SearchGridPro);
            //    List<int> visibleColumns = new List<int>();
            //    DGV_SearchGridPro.Rows.Clear();
            //    DGV_SearchGridPro.Rows.Add();
            //    foreach (DataGridViewColumn col in grdViewSupplierMapping.Columns)
            //    {
            //        DGV_SearchGridPro.Columns.Add((DataGridViewColumn)col.Clone());
            //        visibleColumns.Add(col.Index);
            //    }

            //    if (DGV_SearchGridPro.ColumnCount > 1)
            //    {
            //        for (int i = 1; i < visibleColumns.Count; i++)
            //        {
            //            if (i == 0)
            //            { DGV_SearchGridPro.Rows[0].Cells[i].ReadOnly = true; }
            //            else
            //            { DGV_SearchGridPro.Rows[0].Cells[i].ReadOnly = false; }
            //        }
            //    }
            //}
            //catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            try
            {
                udfnGridSearchHeading(grdViewSupplierMapping, DGV_SearchGridPro);
                DGV_SearchGridPro.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdViewSupplierMapping.Columns)
                {
                    DGV_SearchGridPro.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                int rowIndex = 0;
                DGV_SearchGridPro.Rows.Clear();
                DGV_SearchGridPro.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    DGV_SearchGridPro.Rows[rowIndex].Cells[i].Value = "";
                }
                //   DGV_SearchGridPro.Columns["SI.No."].ReadOnly = true;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void TxtSPShortName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSPShortName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSPShortName_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtSPShortName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSPShortName.Text == "")
                {
                    errCompany.SetError(txtSPShortName, "Please enter the short name");
                    txtSPShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpshortname.ShowAlways = true;
                    tpshortname.Show("Please enter the short name.", txtSPShortName, 5000);
                }
                else
                {
                    errCompany.Clear();
                    txtSPShortName.BackColor = Color.White;
                    // tpname.Hide(txtName);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdSupplierMappingLoad.Rows.Count; i++)
                {
                    grdSupplierMappingLoad.Rows[i].Cells[0].Value = true;
                }
                btnRemove.Enabled = false;
                BtnaddMove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdSupplierMappingLoad.Rows.Count; i++)
                {
                    grdSupplierMappingLoad.Rows[i].Cells[0].Value = false;
                }
                btnRemove.Enabled = true;
                BtnaddMove.Enabled = false;
                //BtnaddMove.Enabled = true;
                //btnRemove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnMappingSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdFinalSupplierMapping.Rows.Count; i++)
                {
                    grdFinalSupplierMapping.Rows[i].Cells[0].Value = true;
                }
                BtnaddMove.Enabled = false;
                btnRemove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnMappingUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdFinalSupplierMapping.Rows.Count; i++)
                {
                    grdFinalSupplierMapping.Rows[i].Cells[0].Value = false;
                }
                btnRemove.Enabled = false;
                BtnaddMove.Enabled = true;
                //btnRemove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnListPrint_Click(object sender, EventArgs e)
        {
            if (!RPTViewer.Visible)
            {
                try
                {
                    btnListPrint.Image = global::ROMS.Properties.Resources.view;
                    btnListPrint.Enabled = false;
                    lblNoRecordsFound.Visible = false;
                    picLoader.Visible = true;
                    RPTViewer.Visible = true;
                    RPTViewer.ShowCloseButton = true;
                    RPTViewer.Enabled = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    int varPrint = 0;
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 22;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(pbSupplierid);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbOrderschedule.SelectedValue);
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();
                    objDs = objspservice.udfnSupplierList(objMR_Supplier);
                    objspservice.CloseConnection();
                    if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                    if (varPrint == 1)
                    {
                        RPTViewer.Visible = true;
                        RPTViewer.BringToFront();
                        RPTViewer.ReuseParameterValuesOnRefresh = true;
                        RPTViewer.RefreshReport();
                        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Supplier_Products.rpt");
                        objBillreport.SetParameterValue("@parascheduleid", Convert.ToInt32(cmbOrderschedule.SelectedValue));
                        objBillreport.SetParameterValue("@paraOrderID", Convert.ToInt32(cmbMappedorderrype.SelectedValue));
                        objBillreport.SetParameterValue("@parasupplierid", Convert.ToInt32(pbSupplierid));
                        objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                        objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        objvalidation.CrySqlConnection(objBillreport);
                        RPTViewer.ReportSource = objBillreport;
                        RPTViewer.Refresh();
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        btnListPrint.Image = global::ROMS.Properties.Resources.view;
                        RPTViewer.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
                finally
                {
                    picLoader.Visible = false;
                    picLoader.SendToBack();
                    btnListPrint.Enabled = true;
                    btnListPrint.Focus();
                    GC.Collect();
                }
            }
            else
            {
                CmbOrderschedule_SelectedIndexChanged(sender, e);
            }
        }
        private void GrdFinalSupplierMapping_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdFinalSupplierMapping.IsCurrentCellDirty)
                {
                    grdFinalSupplierMapping.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbMappedorderrype_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPaymentDisc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDays.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDays_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDiscountPer.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDiscountPer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBankName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentDisc_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPaymentDisc.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDays_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDiscountPer_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDiscountPer.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentDisc_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPaymentDisc.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDays_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtDays.Text) > 10)
                {
                    errCompany.SetError(txtDays, "Please enter valid days");
                    txtDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDays.ShowAlways = true;
                    tpDays.Show("Please enter valid days", txtDays, 5000);
                }
                else
                {
                    txtDays.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDiscountPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtDiscountPer.Text) > 100)
                {
                    errCompany.SetError(txtDiscountPer, "Please enter valid discount percentage");
                    txtDiscountPer.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDiscPer.ShowAlways = true;
                    tpDiscPer.Show("Please enter valid discount percentage", txtDiscountPer, 5000);
                }
                else
                {
                    txtDiscountPer.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentDisc_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtDays_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtTalllyName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTalllyName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTalllyName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSPShortName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTalllyName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTalllyName.Text.Trim() == "")
                {
                    errCompany.SetError(txtTalllyName, "Please enter tally name");
                    txtTalllyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTallyName.ShowAlways = true;
                    tpTallyName.Show("Please enter tally name.", txtTalllyName, 5000);
                }
                else
                {
                    errCompany.Clear();
                    txtTalllyName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBankName_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBankName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBankName_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbBankName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbBankName_Leave(object sender, EventArgs e)
        {
            try
            { 
                cmbBankName.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                result = objDTBank.Tables[0].AsEnumerable()
                           .Where(r => r.Field<int?>("BNKID") == Convert.ToInt16(cmbBankName.SelectedValue)) // handle nulls
                           .Select(r => r.Field<string>("ShortName"))
                           .FirstOrDefault() ?? string.Empty;

                // Assign to TextBox (result will be empty string if nothing found)
                txtBankShortName.Text = result ?? string.Empty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOpeningType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbOpeningType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOpeningType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOpeningType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOpeningType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToInt16(cmbOpeningType.SelectedValue) == 84)
                    {
                        txtInvoiceNo.Focus();
                    }
                    else
                    {
                        if (Convert.ToInt16(cmbOpeningType.SelectedValue) == 85)
                        {
                            txtOpeningAmt.Focus();
                        }
                    }
                    //else { if(clmInvoiceAmount.ena)}
                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOpeningType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbOpeningType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnOpeningType();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnOpeningType()
        {
            try
            {
                int varOpeningType = Convert.ToInt32(cmbOpeningType.SelectedValue); 
                cmbOBType.SelectedValue= Convert.ToInt32(cmbOpeningType.SelectedValue);
                if (varOpeningType==84) //Cr
                {
                    txtOpeningAmt.Visible = true;
                    txtInvoiceNo.Visible = true;
                    dpInvoiceDate.Visible = true;
                    txtTaxableAmt.Visible = true;
                    txtTaxAmt.Visible = true;
                    txtInvoiceAmt.Visible = true;
                    grdOpeningCrDetails.Visible = true;
                    btnOpeningAdd.Visible = true;
                    txtDInvoiceNo.Visible = true;
                    txtDInvoiceDate.Visible = true;
                    txtDETaxableAmt.Visible = true;
                    txtDETaxAmt.Visible = true;
                    txtDInvoiceAmt.Visible = true;
                    txtopening.Enabled = false;
                    txtopening.ReadOnly = true;
                    txtInvRupee.Visible = true;
                    txtOpeningAmt.Enabled = false;
                    txtOpeningAmt.ReadOnly = true;
                    txtDDrCompany.Visible = false;
                    cmbDrCompany.Visible = false;
                    txtDCrCompany.Visible = true;
                    cmbCrCompany.Visible = true;
                    txtDAdjustments.Visible = true;
                    txtAdjustments.Visible = true;
                    cmbCrCompany.SelectedValue = -1;
                    txtInvoiceNo.Text = "";
                    txtTaxableAmt.Text = "";
                    txtTaxAmt.Text = "";
                    txtInvoiceAmt.Text = "";
                    txtAdjustments.Text = "";
                }
                else if(varOpeningType==85) //Dr
                {
                    txtOpeningAmt.Visible = true;
                    txtInvoiceNo.Visible = false;
                    dpInvoiceDate.Visible = false;
                    txtTaxableAmt.Visible = false;
                    txtTaxAmt.Visible = false;
                    txtInvoiceAmt.Visible = false;
                    grdOpeningCrDetails.Visible = false;
                    btnOpeningAdd.Visible = false;
                    txtDInvoiceNo.Visible = false;
                    txtDInvoiceDate.Visible = false;
                    txtDETaxableAmt.Visible = false;
                    txtDETaxAmt.Visible = false;
                    txtDInvoiceAmt.Visible = false;
                    txtopening.Enabled = true;
                    txtopening.ReadOnly = false;
                    txtInvRupee.Visible = false;
                    txtOpeningAmt.Enabled = true;
                    txtOpeningAmt.ReadOnly = false;
                    txtDDrCompany.Visible = true;
                    cmbDrCompany.Visible = true;
                    txtDCrCompany.Visible = false;
                    cmbCrCompany.Visible = false;
                    txtDAdjustments.Visible = false;
                    txtAdjustments.Visible = false;
                }
                if (Convert.ToDecimal(txtOpeningAmt.Text) == 0)
                {
                    cmbOpeningType.Enabled = true;
                }
                else { cmbOpeningType.Enabled = false; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAdjuctmentsCalc()
        {
            try
            {
                decimal varTaxAmt = 0, varTaxableAmt = 0, varAdjustments = 0, varInvoiceAmt = 0;
                if (txtInvoiceAmt.Text.Trim() != "")
                { varInvoiceAmt = Convert.ToDecimal(txtInvoiceAmt.Text.Trim()); }
                if (txtTaxableAmt.Text.Trim() != "")
                { varTaxableAmt = Convert.ToDecimal(txtTaxableAmt.Text.Trim()); }
                if (txtTaxAmt.Text.Trim() != "")
                { varTaxAmt = Convert.ToDecimal(txtTaxAmt.Text.Trim()); }

                varAdjustments = varInvoiceAmt - (varTaxableAmt + varTaxAmt);
                txtAdjustments.Text = varAdjustments.ToString("###.00");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOpeningAmt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOpeningAmt.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOpeningAmt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtOpeningAmt.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceNo.Text.Trim() == "")
                {
                    errCompany.SetError(txtInvoiceNo, "Please enter the Invoice No.");
                    txtInvoiceNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoiceNo.ShowAlways = true;
                    tpInvoiceNo.Show("Please enter the Invoice No.", txtInvoiceNo, 5000);
                }
                else
                {
                    errCompany.Clear();
                    txtInvoiceNo.BackColor = Color.White;
                    // tpname.Hide(txtName);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceAmt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceAmt.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceAmt_Leave(object sender, EventArgs e)
        {
            try
            {
                if ( txtInvoiceAmt.Text.Trim() == "" || Convert.ToDecimal(txtInvoiceAmt.Text)==0)
                {
                    errCompany.SetError(txtInvoiceAmt, "Please enter the Invoice amt");
                    txtInvoiceAmt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoiceAmt.ShowAlways = true;
                    tpInvoiceAmt.Show("Please enter the Invoice amt", txtInvoiceAmt, 5000);
                }
                else
                {
                    errCompany.Clear();
                    txtInvoiceAmt.BackColor = Color.White;
                    // tpname.Hide(txtName);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnOpeningAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                btnOpeningAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnOpeningAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnOpeningAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOpeningAmt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbDrCompany.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpInvoiceDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTaxableAmt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnOpeningAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnOpeningAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOpeningAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Reject the key
                }
                else if (e.KeyChar == '.' && txtopening.Text.IndexOf('.') > -1)
                {
                    e.Handled = true; // Reject the key
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Reject the key
                }
                else if (e.KeyChar == '.' && txtopening.Text.IndexOf('.') > -1)
                {
                    e.Handled = true; // Reject the key
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpInvoiceDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpInvoiceDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpInvoiceDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpInvoiceDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceAmt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnOpeningAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnOpeningAdd_Click(object sender, EventArgs e)
        {
            try
            {
                udfnOpeningAdd();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnOpeningAdd()
        {
            try
            {
                errCompany.Clear();
                bool varFlag = false; string stsName = "";
                if (txtInvoiceNo.Text.Trim() == "")
                {
                    errCompany.SetError(txtInvoiceNo, "Please enter the Invoice No.");
                    txtInvoiceNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoiceNo.ShowAlways = true;
                    tpInvoiceNo.Show("Please enter the Invoice No.", txtInvoiceNo, 5000);
                    varFlag = true;
                }
                if (txtTaxableAmt.Text.Trim() == "" || Convert.ToDecimal(txtTaxableAmt.Text) == 0)
                {
                    errCompany.SetError(txtTaxableAmt, "Please enter the taxable amount");
                    txtTaxableAmt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTaxableAmt.ShowAlways = true;
                    tpTaxableAmt.Show("Please enter the taxable amount", txtTaxableAmt, 5000);
                    varFlag = true;
                }
                if (txtTaxAmt.Text.Trim() == "" || Convert.ToDecimal(txtTaxAmt.Text) == 0)
                {
                    errCompany.SetError(txtTaxAmt, "Please enter the tax amount");
                    txtTaxAmt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTaxAmt.ShowAlways = true;
                    tpTaxAmt.Show("Please enter the tax amount", txtTaxAmt, 5000);
                    varFlag = true;
                }
                //if (txtInvoiceAmt.Text.Trim() == "" || Convert.ToDecimal(txtInvoiceAmt.Text) == 0)
                //{
                //    errCompany.SetError(txtInvoiceAmt, "Please enter the Invoice amt");
                //    txtInvoiceAmt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpInvoiceAmt.ShowAlways = true;
                //    tpInvoiceAmt.Show("Please enter the Invoice amt", txtInvoiceAmt, 5000);
                //    varFlag = true;
                //}
                if (Convert.ToString(cmbCrCompany.SelectedValue) == "" || Convert.ToString(cmbCrCompany.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbCrCompany, "Please select concern.");
                    cmbCrCompany.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCrCompany.ShowAlways = true;
                    tpCrCompany.Show("Please select concern.", cmbCrCompany, 5000);
                    varFlag = true;
                }
                if (varFlag==false)
                {
                    var varStatus = dtStatus.AsEnumerable()
                                    .Where(r => r.Field<int>("STSID") == 63 
                                    )
                                    .Select(r=>r.Field<string>("STS_Name"))
                                    .ToList();
                    stsName = varStatus[0]; 
                    grdOpeningCrDetails.Rows.Add(grdOpeningCrDetails.RowCount+1, cmbCrCompany.Text,txtInvoiceNo.Text.Trim(), dpInvoiceDate.Text, Convert.ToString(txtTaxableAmt.Text.Trim()), Convert.ToString(txtTaxAmt.Text.Trim()), Convert.ToString(txtAdjustments.Text.Trim()), Convert.ToString(txtInvoiceAmt.Text.Trim()), stsName, 63,Convert.ToString(cmbCrCompany.SelectedValue), "0");
                    dtOpeningCRDetails.Rows.Add(0, Convert.ToString(dpInvoiceDate.Text), Convert.ToString(txtInvoiceNo.Text), Convert.ToDecimal(txtInvoiceAmt.Text), 63, Convert.ToInt16(cmbCrCompany.SelectedValue), Convert.ToDecimal(txtTaxableAmt.Text), Convert.ToDecimal(txtTaxAmt.Text), Convert.ToDecimal(txtAdjustments.Text.Trim()));
                    txtInvoiceNo.Text = "";
                    txtTaxableAmt.Text = "";
                    txtTaxAmt.Text = "";
                    txtInvoiceAmt.Text = "";
                    grdOpeningCrDetails.ClearSelection();
                    dpInvoiceDate.Text = Convert.ToString(MainForm.pbCurrentDate);

                    grdOpeningCrDetails.Columns["clmTaxableAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdOpeningCrDetails.Columns["clmTaxAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdOpeningCrDetails.Columns["clmInvoiceAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    txtInvoiceNo.Focus();
                    udfnSumOpeningAmt();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSumOpeningAmt()
        {
            try
            {
                decimal totalAmount = dtOpeningCRDetails.AsEnumerable()
                        .Sum(r => r.Field<decimal?>("SPOB_InvoiceAmount") ?? 0);
                txtOpeningAmt.Text = Convert.ToString(totalAmount.ToString("0.00"));
                txtOBAmt.Text = Convert.ToString(totalAmount.ToString("0.00"));
                if (totalAmount == 0)
                {
                    cmbOpeningType.Enabled = true; 
                }
                else { cmbOpeningType.Enabled = false;  }
                txtTotInvoice.Text = Convert.ToString(grdOpeningCrDetails.Rows.Count);
                txtOBTotInvoice.Text = Convert.ToString(grdOpeningCrDetails.Rows.Count);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDrCompany_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (panelStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInactive.Focus();
                        }
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDrCompany_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbDrCompany.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbCrCompany_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbCrCompany.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDrCompany_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDrCompany.BackColor = Color.White;
                if (Convert.ToString(cmbDrCompany.SelectedValue) == "" || Convert.ToString(cmbDrCompany.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbDrCompany, "Please select concern.");
                    cmbDrCompany.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDrCompany.ShowAlways = true;
                    tpDrCompany.Show("Please select concern.", cmbDrCompany, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbDrCompany.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbCrCompany_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbCrCompany.BackColor = Color.White;
                if (Convert.ToString(cmbCrCompany.SelectedValue) == "" || Convert.ToString(cmbCrCompany.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbCrCompany, "Please select concern.");
                    cmbCrCompany.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCrCompany.ShowAlways = true;
                    tpCrCompany.Show("Please select concern.", cmbCrCompany, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbCrCompany.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbCrCompany_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDrCompany_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbCrCompany_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GrdOpeningCrDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdOpeningCrDetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            { 
                                var spoid = Convert.ToInt32(grdOpeningCrDetails.CurrentRow.Cells["clmID"].Value);
                                var invNo = Convert.ToString(grdOpeningCrDetails.CurrentRow.Cells["clmInvoiceNo"].Value);
                                var invDate = Convert.ToString(grdOpeningCrDetails.CurrentRow.Cells["clmInvoiceDate"].Value);
                                var comid = Convert.ToInt16(grdOpeningCrDetails.CurrentRow.Cells["clmConcernId"].Value);

                                var rowsToDelete = dtOpeningCRDetails.AsEnumerable()
                                    .Where(r => r.Field<int>("SPOBID") == spoid
                                        && r.Field<string>("SPOB_InvoiceNo") == invNo
                                        && r.Field<string>("SPOB_InvoiceDate") == invDate
                                        && r.Field<int>("SPOB_COMID") == comid
                                    )
                                    .ToList(); 
                                foreach (var row in rowsToDelete)
                                {
                                    row.Delete();
                                }
                                dtOpeningCRDetails.AcceptChanges();
                                grdOpeningCrDetails.Rows.RemoveAt(this.grdOpeningCrDetails.Rows[e.RowIndex].Index);
                                udfnSumOpeningAmt();
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

        private void BtnOBClose_Click(object sender, EventArgs e)
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

        private void BtnOBClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnOBClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnOBClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnOBClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnOBSave_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnOBSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnOBSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnOBSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnOBSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTaxableAmt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTaxableAmt.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTaxableAmt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTaxAmt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTaxableAmt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTaxableAmt.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTaxAmt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTaxAmt.BackColor = Color.LemonChiffon;
                if (txtTaxableAmt.Text.Trim() == "")
                {
                    txtTaxAmt.Text = "";
                    errCompany.SetError(txtTaxableAmt, "Please enter the taxable amount.");
                    txtTaxableAmt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTaxableAmt.ShowAlways = true;
                    tpTaxableAmt.Show("Please enter the taxable amount.", txtTaxableAmt, 5000);
                    txtTaxableAmt.Focus();
                }
                else
                {
                    if (Convert.ToDecimal(txtTaxableAmt.Text) < 1)
                    {
                        txtTaxAmt.Text = "";
                        errCompany.SetError(txtTaxableAmt, "Please enter the valid taxable amount.");
                        txtTaxableAmt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpTaxableAmt.ShowAlways = true;
                        tpTaxableAmt.Show("Please enter the valid taxable amount.", txtTaxableAmt, 5000);
                        txtTaxableAmt.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTaxAmt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceAmt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTaxAmt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTaxAmt.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTaxableAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Reject the key
                }
                else if (e.KeyChar == '.' && txtopening.Text.IndexOf('.') > -1)
                {
                    e.Handled = true; // Reject the key
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTaxAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Reject the key
                }
                else if (e.KeyChar == '.' && txtopening.Text.IndexOf('.') > -1)
                {
                    e.Handled = true; // Reject the key
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTaxAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTaxableAmt.Text.Trim() != "")
                {
                    txtInvoiceAmt.Text = Convert.ToString(Convert.ToDecimal(txtTaxableAmt.Text) + Convert.ToDecimal(txtTaxAmt.Text));
                }
                udfnAdjuctmentsCalc();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurOrderSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnPurProductsGridLoad();
                udfnPurMappingDropDownLoad();
                udfnPurdataLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurdataLoad()
        {
            try
            {
                lblPurNoRecordsFound.Visible = false;
                grdPurMappedProducts.DataSource = null;
                SPDataService objspservice = new SPDataService();
                DataSet objDs = new DataSet();
                //foreach (DataGridViewRow row in grdPurSupplierMappingLoad.Rows)
                //{
                //    row.Cells[0].Value = false;
                //}
                SupplierUpdate = 0;
                if (Convert.ToInt32(varsupplierID) != 0)
                {
                    SupplierUpdate = Convert.ToInt32(varsupplierID);
                }
                else
                {
                    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                }
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 48;
                objMR_Supplier.paraSupplierid = Convert.ToInt32(SupplierUpdate);
                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbPurOrderSchedule.SelectedValue);
                objDs = objspservice.udfnSupplierList(objMR_Supplier);

                dtPurMappedProducts = new DataTable();
                dtPurMappedProducts.Columns.Add("", typeof(Boolean));
                dtPurMappedProducts.Columns.Add("S.No.", typeof(string));
                dtPurMappedProducts.Columns.Add("P.I Code", typeof(string));
                dtPurMappedProducts.Columns.Add("Product Name in Tamil", typeof(string));
                dtPurMappedProducts.Columns.Add("Unit", typeof(string));
                dtPurMappedProducts.Columns.Add("Brand", typeof(string));
                dtPurMappedProducts.Columns.Add("Product SubGroup", typeof(string));
                dtPurMappedProducts.Columns.Add("Product Group", typeof(string));
                dtPurMappedProducts.Columns.Add("GROUPID", typeof(int));
                dtPurMappedProducts.Columns.Add("SUBGROUPID", typeof(int));
                dtPurMappedProducts.Columns.Add("PRODUCTID", typeof(int));
                dtPurMappedProducts.Columns.Add("Product Name in English", typeof(string));
                dtPurMappedProducts.Columns.Add("MappedCount", typeof(int));

                if (objDs.Tables[0].Rows.Count > 0)
                {
                    int varcount = 1;
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtPurMappedProducts.Rows.Add(false, Convert.ToInt32(dtPurMappedProducts.Rows.Count) + 1, objDs.Tables[0].Rows[i]["P.I Code"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Product Name in Tamil"].ToString().Replace("''", "'")
                        , objDs.Tables[0].Rows[i]["Unit"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Brand"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Product SubGroup"].ToString().Replace("''", "'"),
                       objDs.Tables[0].Rows[i]["Product Group"].ToString().Replace("''", "'"),
                        objDs.Tables[0].Rows[i]["GROUPID"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["SUBGROUPID"].ToString().Replace("''", "'"),
                        objDs.Tables[0].Rows[i]["PRODUCTID"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Product Name in English"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["MappedCount"].ToString());

                    }
                    grdPurMappedProducts.DataSource = dtPurMappedProducts;
                    //grdPurMappedProducts.Columns[0].Frozen = true;
                    grdPurMappedProducts.Columns[0].HeaderText = "";
                    grdPurMappedProducts.Columns[0].Width = 30;
                    grdPurMappedProducts.Columns["S.No."].Width = 50;
                    grdPurMappedProducts.Columns["P.I Code"].Width = 100;
                    grdPurMappedProducts.Columns["Product Name in Tamil"].Width = 220;
                    grdPurMappedProducts.Columns["Unit"].Width = 100;
                    grdPurMappedProducts.Columns["Product SubGroup"].Width = 120;
                    grdPurMappedProducts.Columns["GROUPID"].Visible = false;
                    grdPurMappedProducts.Columns["SUBGROUPID"].Visible = false;
                    grdPurMappedProducts.Columns["PRODUCTID"].Visible = false;
                    grdPurMappedProducts.Columns["MappedCount"].Visible = false;
                    grdPurMappedProducts.Columns["Product Name in English"].Visible = false;

                    grdPurMappedProducts.Columns["S.No."].ReadOnly = true;
                    grdPurMappedProducts.Columns["P.I Code"].ReadOnly = true;
                    grdPurMappedProducts.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdPurMappedProducts.Columns["Unit"].ReadOnly = true;
                    grdPurMappedProducts.Columns["Product SubGroup"].ReadOnly = true;
                    grdPurMappedProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);

                    udfnPurGridRemove();
                    //for (int i = 0; i < grdPurSupplierMappingLoad.Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < grdPurMappedProducts.Rows.Count; j++)
                    //    {
                    //        if (Convert.ToInt32(grdPurMappedProducts.Rows[j].Cells["PRODUCTID"].Value) == Convert.ToInt32(grdPurSupplierMappingLoad.Rows[i].Cells["PRODUCTID"].Value))
                    //        {
                    //            grdPurSupplierMappingLoad.Rows[i].Cells[0].Value = true;
                    //        }
                    //    }
                    //}
                    //btnPurMappingsave.Text = "Update";
                    //udfndataLoad();
                }
                else
                {
                    //btnPurMappingsave.Text = "Save";
                    //Default Header
                    grdPurMappedProducts.DataSource = dtPurMappedProducts;
                    //grdPurMappedProducts.Columns[0].Frozen = true;
                    grdPurMappedProducts.Columns[0].HeaderText = "";
                    grdPurMappedProducts.Columns[0].Width = 30;
                    grdPurMappedProducts.Columns["S.No."].Width = 50;
                    grdPurMappedProducts.Columns["P.I Code"].Width = 100;
                    grdPurMappedProducts.Columns["Product Name in Tamil"].Width = 220;
                    grdPurMappedProducts.Columns["Unit"].Width = 100;
                    grdPurMappedProducts.Columns["Product SubGroup"].Width = 120;
                    grdPurMappedProducts.Columns["GROUPID"].Visible = false;
                    grdPurMappedProducts.Columns["SUBGROUPID"].Visible = false;
                    grdPurMappedProducts.Columns["PRODUCTID"].Visible = false;
                    grdPurMappedProducts.Columns["MappedCount"].Visible = false;
                    grdPurMappedProducts.Columns["Product Name in English"].Visible = false;
                }

                udfnPurMappedsearchgridHead();
                objspservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblPurMappedProducts.Text = grdPurMappedProducts.Rows.Count.ToString();
            }
        }
        public void udfnPurProductsGridLoad()
        {
            try
            {
                dtPurProducts = null;
                dtPurMappedProducts = null;
                grdPurSupplierMappingLoad.DataSource = null;
                grdPurMappedProducts.DataSource = null;
                if (txtPurGroup.Text.Trim() == "")
                { varPurGroupId = 0; }
                if (txtPurSubgroup.Text.Trim() == "")
                { varPurSubgroupId = 0; }
                if (txtPurBrand.Text.Trim() == "")
                { varPurBrandId = 0; }

                lblNoRecordsFound.Visible = false;
                BeginInvoke(new Action(() => cmbMappingordeDay.Select(int.MaxValue, 0)));
                grdPurSupplierMappingLoad.DataSource = null;
                SPDataService objspservice = new SPDataService();
                DataSet objDs = new DataSet();
                SupplierUpdate = 0;
                if (Convert.ToInt32(varsupplierID) != 0)
                {
                    SupplierUpdate = Convert.ToInt32(varsupplierID);
                }
                else
                {
                    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                }
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 47;
                objMR_Supplier.paraSupplierid = Convert.ToInt32(SupplierUpdate);
                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbPurOrderSchedule.SelectedValue);
                objMR_Supplier.paraGroupCode = varPurGroupId;
                objMR_Supplier.paraSubgroupCode = varPurSubgroupId;
                objMR_Supplier.paraBrandCode = varPurBrandId;
                objMR_Supplier.paraStatusId = Convert.ToInt32(cmbPurStatus.SelectedValue);
                objDs = objspservice.udfnSupplierList(objMR_Supplier);

                dtPurProducts = null;
                udfnInitPur();

                if (objDs.Tables[0].Rows.Count > 0)
                {
                    int varcount = 1;
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtPurProducts.Rows.Add(false, Convert.ToInt32(dtPurProducts.Rows.Count) + 1, objDs.Tables[0].Rows[i]["P.I Code"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Product Name in Tamil"].ToString().Replace("''", "'")
                        , objDs.Tables[0].Rows[i]["Unit"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Brand"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Product SubGroup"].ToString().Replace("''", "'"),
                       objDs.Tables[0].Rows[i]["Product Group"].ToString().Replace("''", "'"),
                        objDs.Tables[0].Rows[i]["GROUPID"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["SUBGROUPID"].ToString().Replace("''", "'"),
                        objDs.Tables[0].Rows[i]["PRODUCTID"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["Product Name in English"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["MappedCount"].ToString());

                    }
                    grdPurSupplierMappingLoad.DataSource = dtPurProducts;
                    //grdPurSupplierMappingLoad.Columns[0].Frozen = true;
                    grdPurSupplierMappingLoad.Columns[0].HeaderText = "";
                    grdPurSupplierMappingLoad.Columns[0].Width = 30;
                    grdPurSupplierMappingLoad.Columns["S.No."].Width = 50;
                    grdPurSupplierMappingLoad.Columns["P.I Code"].Width = 100;
                    grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].Width = 220;
                    grdPurSupplierMappingLoad.Columns["Unit"].Width = 100;
                    grdPurSupplierMappingLoad.Columns["Product SubGroup"].Width = 120;
                    grdPurSupplierMappingLoad.Columns["GROUPID"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["SUBGROUPID"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["PRODUCTID"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["MappedCount"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["Product Name in English"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["S.No."].Visible = false;

                    grdPurSupplierMappingLoad.Columns["S.No."].ReadOnly = true;
                    grdPurSupplierMappingLoad.Columns["P.I Code"].ReadOnly = true;
                    grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdPurSupplierMappingLoad.Columns["Unit"].ReadOnly = true;
                    grdPurSupplierMappingLoad.Columns["Product SubGroup"].ReadOnly = true;
                    grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);

                    udfnPurGridRemove();
                    //for (int i = 0; i < grdSupplierMappingLoad.Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < grdPurSupplierMappingLoad.Rows.Count; j++)
                    //    {
                    //        if (Convert.ToInt32(grdPurSupplierMappingLoad.Rows[j].Cells["PRODUCTID"].Value) == Convert.ToInt32(grdSupplierMappingLoad.Rows[i].Cells["PRODUCTID"].Value))
                    //        {
                    //            grdSupplierMappingLoad.Rows[i].Cells[0].Value = true;
                    //        }
                    //    }
                    //}
                    //btnPurMappingsave.Text = "Update";
                    //udfndataLoad();
                }
                else
                {
                    //btnPurMappingsave.Text = "Save";
                    //Default Header Load
                    grdPurSupplierMappingLoad.DataSource = dtPurProducts;
                    grdPurSupplierMappingLoad.Columns[0].HeaderText = "";
                    grdPurSupplierMappingLoad.Columns[0].Width = 30;
                    grdPurSupplierMappingLoad.Columns["S.No."].Width = 50;
                    grdPurSupplierMappingLoad.Columns["P.I Code"].Width = 100;
                    grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].Width = 220;
                    grdPurSupplierMappingLoad.Columns["Unit"].Width = 100;
                    grdPurSupplierMappingLoad.Columns["Product SubGroup"].Width = 120;
                    grdPurSupplierMappingLoad.Columns["GROUPID"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["SUBGROUPID"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["PRODUCTID"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["MappedCount"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["Product Name in English"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["S.No."].Visible = false;
                }

                udfnPursearchgridHead();
                objspservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblPurProducts.Text = grdPurSupplierMappingLoad.Rows.Count.ToString();
            }
        }
        private void udfnPursearchgridHead()
        {
            try
            {
                udfnGridSearchHeading(grdPurSupplierMappingLoad, DGV_PurSearchGrid);
                DGV_PurSearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdPurSupplierMappingLoad.Columns)
                {
                    DGV_PurSearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_PurSearchGrid.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_PurSearchGrid.Rows.Clear();
                    DGV_PurSearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_PurSearchGrid.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_PurSearchGrid.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_PurSearchGrid.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        public void udfnPurGridRemove()
        {
            try
            {
                //string varRemoveGroup = "";
                //for (int j = 0; j < dtSubGroupMapping.Rows.Count; j++)
                //{
                //    varRemoveGroup = Convert.ToString(grdFinalSupplierMapping.Rows[j].Cells["PRODUCTID"].Value);
                //    for (int i = 0; i < dtSubGroup.Rows.Count; i++)
                //    {
                //        if (varRemoveGroup == Convert.ToString(dtSubGroup.Rows[i]["PRODUCTID"]))
                //        {
                //            dtSubGroup.Rows[i].Delete();
                //            dtSubGroup.AcceptChanges();
                //        }
                //    }
                //}
                //grdSupplierMappingLoad.DataSource = dtSubGroup; 
                HashSet<string> productIdsToRemove = new HashSet<string>();
                foreach (DataGridViewRow row in grdPurMappedProducts.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the last row used for adding new entries 
                    string productId = row.Cells["PRODUCTID"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(productId))
                    {
                        productIdsToRemove.Add(productId);
                    }
                }
                for (int i = 0; i < dtPurProducts.Rows.Count; i++)
                {
                    string productId = Convert.ToString(dtPurProducts.Rows[i]["PRODUCTID"]);
                    if (productIdsToRemove.Contains(productId))
                    {
                        dtPurProducts.Rows[i].Delete(); // Mark row for deletion
                    }
                }
                dtPurProducts.AcceptChanges();
                grdPurSupplierMappingLoad.DataSource = dtPurProducts;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurMappingDropDownLoad()
        {
            try
            {
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 0;
                objMR_Supplier.paraSupplierid = SupplierUpdate;
                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbPurOrderSchedule.SelectedValue);
                SPDataService objspservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspservice.udfnSupplierList(objMR_Supplier);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            txtPurordertype.Text = objDs.Tables[0].Rows[0]["MST_DisplayText"].ToString().Replace("''", "'");
                            lblPurOrderTypeId.Text = objDs.Tables[0].Rows[0]["MSTID"].ToString().Replace("''", "'");
                        }
                        else
                        {
                            txtPurordertype.Text = "";
                        }
                    }
                    objspservice.CloseConnection();
                }
                MR_Supplier objMR_Supplier1 = new MR_Supplier();
                objMR_Supplier1.ViewType = 21;
                objMR_Supplier1.paraSupplierid = SupplierUpdate;
                objMR_Supplier1.paraSupplierScheduleid = Convert.ToInt32(cmbPurOrderSchedule.SelectedValue);
                SPDataService objSPservice = new SPDataService();
                DataSet objDS = new DataSet();
                //cmborderday.DataSource = null;
                objDS = objSPservice.udfnSupplierList(objMR_Supplier1);
                objSPservice.CloseConnection();
                if (objDS != null)
                {
                    if (objDS.Tables.Count != 0)
                    {
                        if (objDS.Tables[0].Rows.Count != 0)
                        {
                            txtPurOrderDays.Text = objDS.Tables[0].Rows[0]["DayNames"].ToString().Replace("''", "'");
                        }
                        else
                        {
                            txtPurOrderDays.Text = "";
                        }
                    }
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

        private void DGV_PurSearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdPurSupplierMappingLoad.DataSource = objDser.udfnGridSearchFilter(DGV_PurSearchGrid, grdPurSupplierMappingLoad);
                objDser.CloseConnection();
                grdPurSupplierMappingLoad.HorizontalScrollingOffset = DGV_PurSearchGrid.HorizontalScrollingOffset;
                //DGV_PurSearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_PurSearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_PurSearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }

        private void DGV_PurSearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        e.Handled = true;
                    }

                DGV_PurSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_PurSearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_PurSearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdPurSupplierMappingLoad.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdPurSupplierMappingLoad.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdPurSupplierMappingLoad.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            // Sort a new column and remove the old SortGlyph.
                            direction = ListSortDirection.Ascending;
                            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                        }
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    grdPurSupplierMappingLoad.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_PurSearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_PurSearchGrid.HorizontalScrollingOffset = grdPurSupplierMappingLoad.HorizontalScrollingOffset;
                    DGV_PurSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_PurSearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdPurSupplierMappingLoad.ColumnCount > 0)
                {
                    grdPurSupplierMappingLoad.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_PurSearchGrid.HorizontalScrollingOffset = grdPurSupplierMappingLoad.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_PurSearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.Text = "";
                if (DGV_PurSearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_PurSearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdPurSupplierMappingLoad.DataSource = objDser.udfnGridSearchFilter(DGV_PurSearchGrid, grdPurSupplierMappingLoad);
                objDser.CloseConnection();
                grdPurSupplierMappingLoad.HorizontalScrollingOffset = DGV_PurSearchGrid.HorizontalScrollingOffset;
                lblTotalProducts.Text = grdPurSupplierMappingLoad.Rows.Count.ToString();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_PurSearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdPurSupplierMappingLoad.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_PurSearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdPurSupplierMappingLoad.Width > grdPurSupplierMappingLoad.HorizontalScrollingOffset && grdPurSupplierMappingLoad.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_PurSearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_PurSearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurSupplierMappingLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    int vscroll = grdPurSupplierMappingLoad.FirstDisplayedScrollingRowIndex;
                    int hscroll = grdPurSupplierMappingLoad.FirstDisplayedScrollingColumnIndex;
                    int varProId = Convert.ToInt16(grdPurSupplierMappingLoad.SelectedRows[0].Cells["PRODUCTID"].Value);
                    udfnGetPurProductCount(varProId);
                    grdPurSupplierMappingLoad.FirstDisplayedScrollingRowIndex = vscroll;
                    grdPurSupplierMappingLoad.FirstDisplayedScrollingColumnIndex = hscroll;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGetPurProductCount(int varProId)
        {
            try
            {
                int varProductCount = 0; string varRemoveProduct = "";
                for (int i = 0; i < grdPurSupplierMappingLoad.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdPurSupplierMappingLoad.Rows[i].Cells[0].Value) == true)
                    {
                        varProductCount++;
                    }
                }
                if (Convert.ToBoolean(grdPurSupplierMappingLoad.SelectedRows[0].Cells[0].Value) == true)
                {
                    DataRow dr = dtPurProducts.Select("PRODUCTID=" + varProId).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = true;
                        dtPurProducts.AcceptChanges();
                    }
                }
                else
                {
                    DataRow dr = dtPurProducts.Select("PRODUCTID=" + varProId).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = false;
                        dtPurProducts.AcceptChanges();
                    }
                }
                if (varProductCount > 0)
                {
                    btnPurRemove.Enabled = false;
                    BtnPuraddMove.Enabled = true;
                    if (grdPurMappedProducts.RowCount > 0)
                    {
                        grdPurMappedProducts.Columns[0].ReadOnly = true;
                    }
                }
                else
                {
                    btnPurRemove.Enabled = true;
                    if (grdPurMappedProducts.RowCount > 0)
                    {
                        grdPurMappedProducts.Columns[0].ReadOnly = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurSupplierMappingLoad_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPurSupplierMappingLoad.IsCurrentCellDirty)
                {
                    grdPurSupplierMappingLoad.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurSupplierMappingLoad_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //for (int i = 0; i < grdPurSupplierMappingLoad.RowCount; i++)
                //{
                //    if (Convert.ToString(grdPurSupplierMappingLoad.Rows[i].Cells["MappedCount"].Value) != "0")
                //    {
                //        grdPurSupplierMappingLoad.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                //    }
                //}
                grdPurSupplierMappingLoad.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurSupplierMappingLoad_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdPurSupplierMappingLoad.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_PurSearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdPurSupplierMappingLoad.Width > grdPurSupplierMappingLoad.HorizontalScrollingOffset && grdPurSupplierMappingLoad.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_PurSearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_PurSearchGrid.Invalidate();
                udfnPurscrollVisible(DGV_PurSearchGrid, grdPurSupplierMappingLoad);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnPurscrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdPurSupplierMappingLoad.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_PurSearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_PurSearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_PurSearchGrid.Rows[rowIndex].Cells[i].Value = "";
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

        private void CmbPurOrderSchedule_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPurOrderSchedule.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurOrderSchedule_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPurGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurOrderSchedule_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPurOrderSchedule_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPurOrderSchedule.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByPurProducts_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPurSupplierMappingLoad.Rows.Count > 0)
                {
                    BindingSource bsPurProducts = new BindingSource();
                    bsPurProducts.DataSource = dtPurProducts;
                    grdPurSupplierMappingLoad.DataSource = bsPurProducts;
                    bsPurProducts.Filter = $"[P.I Code] LIKE '%{txtSearchByPurProducts.Text}%'";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblPurProducts.Text = grdPurSupplierMappingLoad.Rows.Count.ToString();
            }
        }

        private void TxtPurGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvPurSubgroup.Visible = false;
                lvPurBrand.Visible = false;
                txtPurGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvPurGroup.Items.Count == 0 || txtPurGroup.Text == "")
                    {
                        txtPurGroup.Focus();
                        lvPurGroup.Visible = false;
                    }
                    else
                    {
                        lvPurGroup.Focus();
                    }
                    if (lvPurGroup.Items.Count > 0)
                    {
                        lvPurGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtPurSubgroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvPurGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvPurGroup();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvPurGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvPurGroup();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvPurGroup()
        {
            try
            {
                if (txtPurGroup.Text != "")
                {
                    ListViewItem selectedItem = lvPurGroup.SelectedItems[0];
                    txtPurGroup.Text = selectedItem.SubItems[0].Text;
                    varPurGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvPurGroup.Visible = false;
                }
                txtPurSubgroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurSubgroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvPurGroup.Visible = false;
                lvPurBrand.Visible = false;
                txtPurSubgroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvPurSubgroup.Items.Count == 0 || txtPurSubgroup.Text == "")
                    {
                        txtPurSubgroup.Focus();
                        lvPurSubgroup.Visible = false;
                    }
                    else
                    {
                        lvPurSubgroup.Focus();
                    }
                    if (lvPurSubgroup.Items.Count > 0)
                    {
                        lvPurSubgroup.Items[0].Selected = true;
                    }
                }

                if (e.KeyCode == Keys.Enter)
                {
                    txtPurBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtPurSubgroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPurSubgroup.BackColor = Color.White;
                if (txtPurSubgroup.Text.Trim() == "") { varSubGroupId = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurSubgroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvPurSubgroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtPurSubgroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(10, 0, "", varPurGroupId, 0, txtPurSubgroup.Text, 0, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {

                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvPurSubgroup.Items.Add(objList);
                                }
                                lvPurSubgroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvPurSubgroup.Visible = false;
                    lvPurSubgroup.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void LvPurSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvPurSubGroup();
                    txtBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvPurSubgroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvPurSubGroup();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvPurSubGroup()
        {
            try
            {
                if (txtPurSubgroup.Text != "")
                {
                    ListViewItem selectedItem = lvPurSubgroup.SelectedItems[0];
                    txtPurSubgroup.Text = selectedItem.SubItems[0].Text;
                    varPurSubgroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvPurSubgroup.Visible = false;
                }
                txtPurBrand.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                lvPurSubgroup.Visible = false;
                lvPurGroup.Visible = false;
                txtPurBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvPurBrand.Items.Count == 0 || txtPurBrand.Text == "")
                    {
                        txtPurBrand.Focus();
                        lvPurBrand.Visible = false;
                    }
                    else
                    {
                        lvPurBrand.Focus();
                    }
                    if (lvPurBrand.Items.Count > 0)
                    {
                        lvPurBrand.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPurStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurBrand_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPurBrand.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvPurBrand.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtPurBrand.Text.Length > 0)
                {
                    objDs = objspdservice.udfnBrandList(7, "", varPurGroupId, varPurSubgroupId, 0, txtPurBrand.Text.Trim(), 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["BD_EName"].ToString(), objDs.Tables[0].Rows[i]["BD_TName"].ToString(), objDs.Tables[0].Rows[i]["BDID"].ToString(), };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvPurBrand.Items.Add(objList);
                                }
                                lvPurBrand.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvPurBrand.Visible = false;
                    lvPurBrand.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvPurBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvPurBrand();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvPurBrand_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvPurBrand();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvPurBrand()
        {
            try
            {
                if (txtPurBrand.Text != "")
                {
                    ListViewItem selectedItem = lvPurBrand.SelectedItems[0];
                    txtPurBrand.Text = selectedItem.SubItems[0].Text;
                    varPurBrandId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvPurBrand.Visible = false;
                }
                cmbPurStatus.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                lvPurGroup.Visible = false;
                lvPurSubgroup.Visible = false;
                lvPurBrand.Visible = false;
                cmbPurStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnPurView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurStatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPurStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPurStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPurView_Click(object sender, EventArgs e)
        {
            try
            {
                lvPurGroup.Visible = false;
                lvPurSubgroup.Visible = false;
                lvPurBrand.Visible = false;

                udfnPurProductsGridLoad();
                udfnPurGridRemove();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblPurProducts.Text = grdPurMappedProducts.Rows.Count.ToString();
                txtSearchByPurProducts.Text = "";
            }
        }
        public void udfnPurAdd()
        {
            try
            {
                string varRemoveProduct = "", varAddProduct = "", varGridRemove = "";
                if (dtPurProducts.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPurProducts.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dtPurProducts.Rows[i][0]) == true)
                        {
                            int varFlag = 0, varcount = 1;
                            for (int j = 0; j < dtPurMappedProducts.Rows.Count; j++)
                            {
                                varRemoveProduct = Convert.ToString(dtPurProducts.Rows[i]["PRODUCTID"]);
                                if (varRemoveProduct == Convert.ToString(dtPurMappedProducts.Rows[j]["PRODUCTID"]))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                dtPurMappedProducts.Rows.Add(false, Convert.ToInt32(dtPurMappedProducts.Rows.Count) + 1, dtPurProducts.Rows[i]["P.I Code"], dtPurProducts.Rows[i]["Product Name in Tamil"], dtPurProducts.Rows[i]["Unit"], dtPurProducts.Rows[i]["Brand"], dtPurProducts.Rows[i]["Product SubGroup"], dtPurProducts.Rows[i]["Product Group"],
                                dtPurProducts.Rows[i]["GROUPID"], dtPurProducts.Rows[i]["SUBGROUPID"], dtPurProducts.Rows[i]["PRODUCTID"], dtPurProducts.Rows[i]["Product Name in English"], dtPurProducts.Rows[i]["MappedCount"]);
                                varModifiedFlag = 1;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < dtPurMappedProducts.Rows.Count; j++)
                            {
                                varAddProduct = Convert.ToString(dtPurProducts.Rows[i]["PRODUCTID"]);
                                if (varAddProduct == Convert.ToString(dtPurMappedProducts.Rows[j]["PRODUCTID"]))
                                {
                                    dtPurMappedProducts.Rows[j].Delete();
                                    dtPurMappedProducts.AcceptChanges();
                                }
                            }
                        }
                    }
                    grdPurMappedProducts.DataSource = null;
                    grdPurMappedProducts.DataSource = dtPurMappedProducts;
                    //  grdPurMappedProducts.Columns[0].Frozen = true;
                    grdPurMappedProducts.Columns[0].HeaderText = "";
                    grdPurMappedProducts.Columns[0].Width = 30;
                    grdPurMappedProducts.Columns["S.No."].Width = 50;
                    grdPurMappedProducts.Columns["P.I Code"].Width = 100;
                    grdPurMappedProducts.Columns["Product Name in Tamil"].Width = 220;
                    grdPurMappedProducts.Columns["Unit"].Width = 60;
                    grdPurMappedProducts.Columns["Product SubGroup"].Width = 120;
                    grdPurMappedProducts.Columns["GROUPID"].Visible = false;
                    grdPurMappedProducts.Columns["SUBGROUPID"].Visible = false;
                    grdPurMappedProducts.Columns["PRODUCTID"].Visible = false;
                    grdPurMappedProducts.Columns["MappedCount"].Visible = false;
                    grdPurMappedProducts.Columns["Product Name in English"].Visible = false;
                    grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                    grdPurMappedProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                    grdPurMappedProducts.Columns["S.No."].ReadOnly = true;
                    grdPurMappedProducts.Columns["P.I Code"].ReadOnly = true;
                    grdPurMappedProducts.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdPurMappedProducts.Columns["Unit"].ReadOnly = true;
                    grdPurMappedProducts.Columns["Product SubGroup"].ReadOnly = true;
                    udfnPurMappedsearchgridHead();
                    udfnPurGridRemove();
                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblPurMappedProducts.Text = grdPurMappedProducts.Rows.Count.ToString();
            }
        }
        private void udfnPurMappedsearchgridHead()
        {
            try
            {
                udfnGridSearchHeading(grdPurMappedProducts, DGV_PurMappedSearchGrid);
                DGV_PurMappedSearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdPurMappedProducts.Columns)
                {
                    DGV_PurMappedSearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_PurMappedSearchGrid.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_PurMappedSearchGrid.Rows.Clear();
                    DGV_PurMappedSearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_PurMappedSearchGrid.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_PurMappedSearchGrid.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_PurMappedSearchGrid.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void BtnPuraddMove_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbPurOrderSchedule.SelectedValue) != -1)
                {
                    udfnPurAdd();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(65);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (Convert.ToInt32(cmbPurOrderSchedule.SelectedValue) != -1)
                {
                    this.grdPurMappedProducts.Sort(this.grdPurMappedProducts.Columns[2], ListSortDirection.Ascending);
                    for (int i = 0; i < grdPurMappedProducts.RowCount; i++)
                    {
                        grdPurMappedProducts.Rows[i].Cells["S.No."].Value = i + 1;
                    }
                }
                grdPurMappedProducts.ClearSelection();
                lblPurProducts.Text = grdPurSupplierMappingLoad.Rows.Count.ToString();
                txtSearchByPurMappedProducts.Text = "";
                if (grdPurMappedProducts.Columns.Count != 0)
                {
                    grdPurMappedProducts.Columns[0].ReadOnly = false;
                    grdPurSupplierMappingLoad.Columns[0].ReadOnly = false;
                }
                //SearchFlag = 0;
            }
        }

        private void BtnPurRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dialogResult == DialogResult.Yes)
                //{
                if (dtPurProducts == null)
                {
                    udfnInitPur();
                }
                for (int k = 1; k < DGV_SearchGrid1.ColumnCount; k++)
                {
                    DGV_SearchGrid1.Rows[0].Cells[k].Value = "";
                }
                DGV_PurMappedSearchGrid_CurrentCellDirtyStateChanged(sender, e);
            L: for (int i = 0; i < dtPurMappedProducts.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtPurMappedProducts.Rows[i][0]) == true)
                    {
                        int varSlNo = 1;
                        if (dtPurProducts != null)
                        { varSlNo = dtPurProducts.Rows.Count + 1; }
                        varModifiedFlag = 1;
                        dtPurProducts.Rows.Add(false, varSlNo, dtPurMappedProducts.Rows[i]["P.I Code"],
                        dtPurMappedProducts.Rows[i]["Product Name in Tamil"],
                        dtPurMappedProducts.Rows[i]["Unit"],
                        dtPurMappedProducts.Rows[i]["Brand"],
                        dtPurMappedProducts.Rows[i]["Product SubGroup"],
                        dtPurMappedProducts.Rows[i]["Product Group"],
                        dtPurMappedProducts.Rows[i]["GROUPID"],
                        dtPurMappedProducts.Rows[i]["SUBGROUPID"],
                        dtPurMappedProducts.Rows[i]["PRODUCTID"], dtPurMappedProducts.Rows[i]["Product Name in English"],
                        dtPurMappedProducts.Rows[i]["MappedCount"]);
                        dtPurProducts.AcceptChanges();
                        //for (int j = 0; j < dtPurMappedProducts.Rows.Count; j++)
                        //{
                        //    if (Convert.ToString(grdPurMappedProducts.Rows[i].Cells["PRODUCTID"].Value) == Convert.ToString(dtPurMappedProducts.Rows[j]["PRODUCTID"]))
                        //    {
                        dtPurMappedProducts.Rows.RemoveAt(i);
                        dtPurMappedProducts.AcceptChanges();
                        goto L;
                        //  }
                        //  }
                    }
                }
                lblTotalMappingProduct.Text = grdPurMappedProducts.Rows.Count.ToString();
                grdPurSupplierMappingLoad.DataSource = dtPurProducts;
                // grdPurSupplierMappingLoad.Columns[0].Frozen = true;
                grdPurSupplierMappingLoad.Columns[0].HeaderText = "";
                grdPurSupplierMappingLoad.Columns[0].Width = 30;
                grdPurSupplierMappingLoad.Columns["S.No."].Width = 50;
                grdPurSupplierMappingLoad.Columns["P.I Code"].Width = 100;
                grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].Width = 220;
                grdPurSupplierMappingLoad.Columns["Unit"].Width = 60;
                grdPurSupplierMappingLoad.Columns["Product SubGroup"].Width = 170;
                grdPurSupplierMappingLoad.Columns["GROUPID"].Visible = false;
                grdPurSupplierMappingLoad.Columns["SUBGROUPID"].Visible = false;
                grdPurSupplierMappingLoad.Columns["MappedCount"].Visible = false;
                grdPurSupplierMappingLoad.Columns["PRODUCTID"].Visible = false;
                grdPurSupplierMappingLoad.Columns["Product Name in English"].Visible = false;
                grdPurSupplierMappingLoad.Columns["S.No."].Visible = false;
                grdPurSupplierMappingLoad.Columns["S.No."].ReadOnly = true;
                grdPurSupplierMappingLoad.Columns["P.I Code"].ReadOnly = true;
                grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].ReadOnly = true;
                grdPurSupplierMappingLoad.Columns["Unit"].ReadOnly = true;
                grdPurSupplierMappingLoad.Columns["Product SubGroup"].ReadOnly = true;
                grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                udfnPursearchgridHead();


                grdPurMappedProducts.DataSource = dtPurMappedProducts;
                // grdPurMappedProducts.Columns[0].Frozen = true;
                grdPurMappedProducts.Columns[0].HeaderText = "";
                grdPurMappedProducts.Columns[0].Width = 30;
                grdPurMappedProducts.Columns["S.No."].Width = 50;
                grdPurMappedProducts.Columns["P.I Code"].Width = 100;
                grdPurMappedProducts.Columns["Product Name in Tamil"].Width = 220;
                grdPurMappedProducts.Columns["Unit"].Width = 60;
                grdPurMappedProducts.Columns["Product SubGroup"].Width = 120;
                grdPurMappedProducts.Columns["GROUPID"].Visible = false;
                grdPurMappedProducts.Columns["SUBGROUPID"].Visible = false;
                grdPurMappedProducts.Columns["PRODUCTID"].Visible = false;
                grdPurMappedProducts.Columns["MappedCount"].Visible = false;
                grdPurMappedProducts.Columns["Product Name in English"].Visible = false;
                grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                grdPurMappedProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                grdPurMappedProducts.Columns["S.No."].ReadOnly = true;
                grdPurMappedProducts.Columns["P.I Code"].ReadOnly = true;
                grdPurMappedProducts.Columns["Product Name in Tamil"].ReadOnly = true;
                grdPurMappedProducts.Columns["Unit"].ReadOnly = true;
                grdPurMappedProducts.Columns["Product SubGroup"].ReadOnly = true;

                for (int j = 0; j < grdPurMappedProducts.RowCount; j++)
                {
                    grdPurMappedProducts.Rows[j].Cells["S.No."].Value = j + 1;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblPurProducts.Text = grdPurSupplierMappingLoad.Rows.Count.ToString();
                grdPurMappedProducts.Columns[0].ReadOnly = false;
                grdPurSupplierMappingLoad.Columns[0].ReadOnly = false;
            }
        }
        public void udfnInitPur()
        {
            try
            {
                dtPurProducts = new DataTable();
                dtPurProducts.Columns.Add("", typeof(Boolean));
                dtPurProducts.Columns.Add("S.No.", typeof(string));
                dtPurProducts.Columns.Add("P.I Code", typeof(string));
                dtPurProducts.Columns.Add("Product Name in Tamil", typeof(string));
                dtPurProducts.Columns.Add("Unit", typeof(string));
                dtPurProducts.Columns.Add("Brand", typeof(string));
                dtPurProducts.Columns.Add("Product SubGroup", typeof(string));
                dtPurProducts.Columns.Add("Product Group", typeof(string));
                dtPurProducts.Columns.Add("GROUPID", typeof(int));
                dtPurProducts.Columns.Add("SUBGROUPID", typeof(int));
                dtPurProducts.Columns.Add("PRODUCTID", typeof(int));
                dtPurProducts.Columns.Add("Product Name in English", typeof(string));
                dtPurProducts.Columns.Add("MappedCount", typeof(int));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_PurMappedSearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdPurMappedProducts.DataSource = objDser.udfnGridSearchFilter(DGV_PurMappedSearchGrid, grdPurMappedProducts);
                objDser.CloseConnection();
                grdPurMappedProducts.HorizontalScrollingOffset = DGV_PurMappedSearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            finally
            {
                //SearchFlag = 1; 
            }
        }

        private void DGV_PurMappedSearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_PurMappedSearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }

        private void DGV_PurMappedSearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_PurMappedSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_PurMappedSearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }

        }

        private void DGV_PurMappedSearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdPurMappedProducts.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdPurMappedProducts.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn
                            &&
                            grdPurMappedProducts.SortOrder == SortOrder.Ascending
                            )
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            // Sort a new column and remove the old SortGlyph.
                            direction = ListSortDirection.Ascending;
                            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                        }
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    grdPurMappedProducts.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_PurMappedSearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_PurMappedSearchGrid.HorizontalScrollingOffset = grdPurMappedProducts.HorizontalScrollingOffset;
                    DGV_PurMappedSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void DGV_PurMappedSearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdPurMappedProducts.ColumnCount > 0)
                {
                    grdPurMappedProducts.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_PurMappedSearchGrid.HorizontalScrollingOffset = grdPurMappedProducts.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void DGV_PurMappedSearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchByPurMappedProducts.Text = "";
                if (DGV_PurMappedSearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_PurMappedSearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdPurMappedProducts.DataSource = objDser.udfnGridSearchFilter(DGV_PurMappedSearchGrid, grdPurMappedProducts);
                objDser.CloseConnection();
                grdPurMappedProducts.HorizontalScrollingOffset = DGV_PurMappedSearchGrid.HorizontalScrollingOffset;
                lblPurMappedProducts.Text = grdPurMappedProducts.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void DGV_PurMappedSearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdPurMappedProducts.DataSource = objDser.udfnGridSearchFilter(DGV_PurMappedSearchGrid, grdPurMappedProducts);
                objDser.CloseConnection();
                grdPurMappedProducts.HorizontalScrollingOffset = DGV_PurMappedSearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }

        }

        private void DGV_PurMappedSearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdPurMappedProducts.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_PurMappedSearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdPurMappedProducts.Width > grdPurMappedProducts.HorizontalScrollingOffset && grdPurMappedProducts.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_PurMappedSearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_PurMappedSearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurMappedProducts_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdPurMappedProducts.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_PurMappedSearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdPurMappedProducts.Width > grdPurMappedProducts.HorizontalScrollingOffset && grdPurMappedProducts.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_PurMappedSearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_PurMappedSearchGrid.Invalidate();
                udfnPurScrollVisible(DGV_PurMappedSearchGrid, grdPurMappedProducts);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnPurScrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdPurMappedProducts.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_PurMappedSearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_PurMappedSearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_PurMappedSearchGrid.Rows[rowIndex].Cells[i].Value = "";
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

        private void TxtSearchByPurMappedProducts_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPurMappedProducts.Rows.Count > 0)
                {
                    BindingSource bsPurMappedProducts = new BindingSource();
                    bsPurMappedProducts.DataSource = dtPurMappedProducts;
                    grdPurMappedProducts.DataSource = bsPurMappedProducts;
                    bsPurMappedProducts.Filter = $"[P.I Code] LIKE '%{txtSearchByPurMappedProducts.Text}%'";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (Convert.ToInt32(cmbPurOrderSchedule.SelectedValue) != -1)
                {
                    this.grdPurMappedProducts.Sort(this.grdPurMappedProducts.Columns[2], ListSortDirection.Ascending);
                    for (int i = 0; i < grdPurMappedProducts.RowCount; i++)
                    {
                        grdPurMappedProducts.Rows[i].Cells["S.No."].Value = i + 1;
                    }
                }
                grdPurMappedProducts.ClearSelection();
                lblPurMappedProducts.Text = grdPurMappedProducts.Rows.Count.ToString();
            }
        }

        private void GrdPurMappedProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPurMappedProducts.Columns[e.ColumnIndex].Name)
                    {
                        case "clmMappingRemove":

                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                dtPurProducts.Rows.Add(false, "0", grdPurMappedProducts.SelectedRows[0].Cells["P.I Code"].Value,
                                grdPurMappedProducts.SelectedRows[0].Cells["Product Name in Tamil"].Value,
                                grdPurMappedProducts.SelectedRows[0].Cells["Unit"].Value,
                                grdPurMappedProducts.SelectedRows[0].Cells["Product SubGroup"].Value,
                                grdPurMappedProducts.SelectedRows[0].Cells["GROUPID"].Value,
                                grdPurMappedProducts.SelectedRows[0].Cells["SUBGROUPID"].Value,
                                grdPurMappedProducts.SelectedRows[0].Cells["PRODUCTID"].Value, "0", grdPurMappedProducts.SelectedRows[0].Cells["MappedCount"].Value);
                                grdPurMappedProducts.Rows.RemoveAt(this.grdPurMappedProducts.SelectedRows[0].Index);
                                for (int i = 0; i < grdPurMappedProducts.RowCount; i++)
                                {
                                    grdPurMappedProducts.Rows[i].Cells["S.No."].Value = i + 1;
                                }
                                lblPurMappedProducts.Text = grdPurMappedProducts.Rows.Count.ToString();
                                dtPurProducts.AcceptChanges();
                                grdPurSupplierMappingLoad.DataSource = dtPurProducts;
                                // grdPurSupplierMappingLoad.Columns[0].Frozen = true;
                                grdPurSupplierMappingLoad.Columns[0].HeaderText = "";
                                grdPurSupplierMappingLoad.Columns[0].Width = 30;
                                grdPurSupplierMappingLoad.Columns["S.No."].Width = 50;
                                grdPurSupplierMappingLoad.Columns["P.I Code"].Width = 100;
                                grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].Width = 220;
                                grdPurSupplierMappingLoad.Columns["Unit"].Width = 100;
                                grdPurSupplierMappingLoad.Columns["Product SubGroup"].Width = 170;
                                grdPurSupplierMappingLoad.Columns["GROUPID"].Visible = false;
                                grdPurSupplierMappingLoad.Columns["SUBGROUPID"].Visible = false;
                                grdPurSupplierMappingLoad.Columns["PRODUCTID"].Visible = false;
                                grdPurSupplierMappingLoad.Columns["MappedCount"].Visible = false;
                                grdPurSupplierMappingLoad.Columns["Product Name in English"].Visible = false;
                                grdPurSupplierMappingLoad.Columns["S.No."].Visible = false;


                                grdPurSupplierMappingLoad.Columns["S.No."].ReadOnly = true;
                                grdPurSupplierMappingLoad.Columns["P.I Code"].ReadOnly = true;
                                grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdPurSupplierMappingLoad.Columns["Unit"].ReadOnly = true;
                                grdPurSupplierMappingLoad.Columns["Product SubGroup"].ReadOnly = true;
                                grdPurSupplierMappingLoad.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            }
                            break;
                    }
                }
                int vscroll = grdPurMappedProducts.FirstDisplayedScrollingRowIndex;
                int hscroll = grdPurMappedProducts.FirstDisplayedScrollingColumnIndex;
                int varPRID = Convert.ToInt16(grdPurMappedProducts.SelectedRows[0].Cells["PRODUCTID"].Value);
                udfnGetPurMappedProductCount(varPRID);
                grdPurMappedProducts.FirstDisplayedScrollingRowIndex = vscroll;
                grdPurMappedProducts.FirstDisplayedScrollingColumnIndex = hscroll;
                // udfnGetProductCount(0);       
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (grdPurSupplierMappingLoad.RowCount > 0)
                {
                    this.grdPurSupplierMappingLoad.Sort(this.grdPurSupplierMappingLoad.Columns[2], ListSortDirection.Ascending);
                }
                grdPurSupplierMappingLoad.ClearSelection();
            }
        }
        public void udfnGetPurMappedProductCount(int varPRID)
        {
            try
            {
                int varMappedProductCount = 0;
                for (int i = 0; i < grdPurMappedProducts.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdPurMappedProducts.Rows[i].Cells[0].Value) == true)
                    {
                        varMappedProductCount++;
                    }
                }
                if (Convert.ToBoolean(grdPurMappedProducts.SelectedRows[0].Cells[0].Value) == true)
                {
                    DataRow dr = dtPurMappedProducts.Select("PRODUCTID=" + varPRID).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = true;
                        dtPurMappedProducts.AcceptChanges();
                    }
                }
                else
                {
                    DataRow dr = dtPurMappedProducts.Select("PRODUCTID=" + varPRID).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = false;
                        dtPurMappedProducts.AcceptChanges();
                    }
                }
                if (varMappedProductCount > 0)
                {
                    BtnPuraddMove.Enabled = false;
                    btnPurRemove.Enabled = true;
                    grdPurSupplierMappingLoad.Columns[0].ReadOnly = true;
                }
                else
                {
                    btnPurRemove.Enabled = false;
                    grdPurSupplierMappingLoad.Columns[0].ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurMappedProducts_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPurMappedProducts.IsCurrentCellDirty)
                {
                    grdPurMappedProducts.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurMappedProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdPurMappedProducts.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPurProUnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdPurSupplierMappingLoad.Rows.Count; i++)
                {
                    grdPurSupplierMappingLoad.Rows[i].Cells[0].Value = false;
                }
                btnPurRemove.Enabled = true;
                BtnPuraddMove.Enabled = false;
                //BtnPuraddMove.Enabled = true;
                //btnPurRemove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPurProSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdPurSupplierMappingLoad.Rows.Count; i++)
                {
                    grdPurSupplierMappingLoad.Rows[i].Cells[0].Value = true;
                }
                btnPurRemove.Enabled = false;
                BtnPuraddMove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPurMappedProUnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdPurMappedProducts.Rows.Count; i++)
                {
                    grdPurMappedProducts.Rows[i].Cells[0].Value = false;
                }
                btnPurRemove.Enabled = false;
                BtnPuraddMove.Enabled = true;
                //btnPurRemove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPurMappedProSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdPurMappedProducts.Rows.Count; i++)
                {
                    grdPurMappedProducts.Rows[i].Cells[0].Value = true;
                }
                BtnPuraddMove.Enabled = false;
                btnPurRemove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPurMappingsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SupplierUpdate != 0 && SupplierUpdate != -1)
                {
                    if (cmbPurOrderSchedule.Text != "")
                    {
                        btnPurMappingsave.Enabled = false;
                        txtSearchByPurMappedProducts.Text = "";
                        for (int i = 1; i < DGV_PurMappedSearchGrid.ColumnCount; i++)
                        {
                            DGV_PurMappedSearchGrid.Rows[0].Cells[i].Value = "";
                        }
                        DGV_PurMappedSearchGrid_CurrentCellDirtyStateChanged(sender, e);
                        if (Convert.ToInt32(grdPurMappedProducts.Rows.Count) > 0)
                        {
                            string VarproductId = "", result = "";
                            SPDataService objspdservice = new SPDataService();
                            for (int i = 0; i < grdPurMappedProducts.Rows.Count; i++)
                            {
                                //if (Convert.ToBoolean(grdPurMappedProducts.Rows[i].Cells[0].Value) == true)
                                //{
                                if (VarproductId == "")
                                {
                                    VarproductId = Convert.ToString(grdPurMappedProducts.Rows[i].Cells["PRODUCTID"].Value);
                                }
                                else
                                {
                                    VarproductId = VarproductId + ',' + Convert.ToString(grdPurMappedProducts.Rows[i].Cells["PRODUCTID"].Value);
                                }
                                //  }
                            }
                            result = objspdservice.udfnSupplierMaster(15, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0,
                                   0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Purchase Variant Mapping Update", 0, "", 0, 0, 0, 0, 0, "", "", "", "", 0, "", Convert.ToInt32(cmbPurOrderSchedule.SelectedValue), Convert.ToInt32(lblPurOrderTypeId.Text), VarproductId, "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", 0, null, 0);
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "3")
                            {
                                MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                varModifiedFlag = 0;
                                if (MainForm.objCP_Supplierlist != null)
                                {
                                    MainForm.objCP_Supplierlist.udfnList();
                                }
                                cmbPurOrderSchedule.Focus();
                                if (btnPurMappingsave.Text == "Update")
                                {
                                    varupdate = "1";
                                    //udfnclose();
                                }
                                txtPurGroup.Text = "";
                                varPurGroupId = 0;
                                txtPurSubgroup.Text = "";
                                varPurSubgroupId = 0;
                                txtPurBrand.Text = "";
                                varPurBrandId = 0;
                                cmbPurStatus.SelectedValue = 0;
                                txtSearchByPurProducts.Text = "";
                                txtSearchByPurMappedProducts.Text = "";
                                CmbPurOrderSchedule_SelectedIndexChanged(sender, e);
                            }
                            else
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            objspdservice.CloseConnection();
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(38);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        grdPurMappedProducts.DataSource = null;
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(65);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(85);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnPurMappingsave.Enabled = true;
                btnPurMappingsave.Focus();
            }
        }

        private void BtnPurClose_Click(object sender, EventArgs e)
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

        private void TxtTaxableAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnAdjuctmentsCalc();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnAdjuctmentsCalc();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPurGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvPurGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtPurGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtPurGroup.Text, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvPurGroup.Items.Add(objList);
                                }
                                lvPurGroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvPurGroup.Visible = false;
                    lvPurGroup.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDiscountPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || (Convert.ToInt32(txtDiscountPer.Text) > 100))
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

        private void CmbPaymentDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbPaymentDisc.SelectedValue) == 229)
                {
                    txtDays.Enabled = true;
                    txtDiscountPer.Enabled = true;
                    txtDays.ReadOnly = false;
                    txtDiscountPer.ReadOnly = false;
                }
                else if (Convert.ToInt32(cmbPaymentDisc.SelectedValue) == 228)
                {
                    txtDays.Enabled = false;
                    txtDays.ReadOnly = true;
                    txtDiscountPer.Enabled = false;
                    txtDiscountPer.ReadOnly = true;
                    txtDays.Text = "";
                    txtDiscountPer.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRemove_Enter(object sender, EventArgs e)
        {
            try
            {
                btnRemove.BackColor = Color.LemonChiffon;
                udfnLvHide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbTat_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbTat_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbTat.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtgstin_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                objvalidation.udfnGSTIN(e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTat_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTat.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnRemove_Leave(object sender, EventArgs e)
        {
            try
            {
                btnRemove.BackColor = Color.Transparent;
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
                    txtAccName.Focus();
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
                txtAccno.BackColor = Color.White;
                //if (Convert.ToString(txtAccno.Text).Trim() == "")
                //{
                //    errCompany.SetError(txtAccno, "Please enter account number");
                //    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpAccountNo.ShowAlways = true;
                //    tpAccountNo.Show("Please enter account number", txtAccno, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    txtAccno.BackColor = Color.White;
                //}
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
                    if (panelStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInactive.Focus();
                        }
                    }
                    else
                    {
                        btnSave.Focus();
                    }
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
                //if(Convert.ToString(txtIFScode.Text).Trim() == "")
                //{
                //    errCompany.SetError(txtIFScode, "Please enter IFS Code");
                //    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpIfsCode.ShowAlways = true;
                //    tpIfsCode.Show("Please enter IFS Code", txtIFScode, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    txtIFScode.BackColor = Color.White;
                //}
                if (Convert.ToString(txtIFScode.Text).Trim() == "")
                {
                    txtIFScode.BackColor = Color.White;
                }
                else if (Convert.ToString(txtIFScode.Text).Trim() != "")
                {
                    if (txtIFScode.Text.Length < 11)
                    {
                        errCompany.SetError(txtIFScode, "Please enter valid IFS Code");
                        txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIfsCode.ShowAlways = true;
                        tpIfsCode.Show("Please enter IFS Code", txtIFScode, 5000);

                    }
                    else
                    {
                        errCompany.Clear();
                        txtIFScode.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAccName_Enter(object sender, EventArgs e)
        {

            try
            {
                txtAccName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAccName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAccName.BackColor = Color.White;
                //if (Convert.ToString(txtAccName.Text).Trim() == "")
                //{
                //    errCompany.SetError(txtAccName, "Please enter Acc name");
                //    txtAccName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpIfsCode.ShowAlways = true;
                //    tpIfsCode.Show("Please enter acc name", txtAccName, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    txtAccName.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAccName_KeyDown(object sender, KeyEventArgs e)
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
        public void udfnGetProductCount(int varProId)
        {
            try
            {
                int varProductCount = 0; string varRemoveProduct = "";
                for (int i = 0; i < grdSupplierMappingLoad.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSupplierMappingLoad.Rows[i].Cells[0].Value) == true)
                    {
                        varProductCount++;
                    }
                }
                if (Convert.ToBoolean(grdSupplierMappingLoad.SelectedRows[0].Cells[0].Value) == true)
                {
                    DataRow dr = dtSubGroup.Select("PRODUCTID=" + varProId).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = true;
                        dtSubGroup.AcceptChanges();
                    }
                }
                else
                {
                    DataRow dr = dtSubGroup.Select("PRODUCTID=" + varProId).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = false;
                        dtSubGroup.AcceptChanges();
                    }
                }
                if (varProductCount > 0)
                {
                    btnRemove.Enabled = false;
                    BtnaddMove.Enabled = true;
                    if (grdFinalSupplierMapping.RowCount > 0)
                    {
                        grdFinalSupplierMapping.Columns[0].ReadOnly = true;
                    }
                }
                else
                {
                    btnRemove.Enabled = true;
                    if (grdFinalSupplierMapping.RowCount > 0)
                    {
                        grdFinalSupplierMapping.Columns[0].ReadOnly = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGetMappedProductCount(int varPRID)
        {
            try
            {
                int varMappedProductCount = 0;
                for (int i = 0; i < grdFinalSupplierMapping.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdFinalSupplierMapping.Rows[i].Cells[0].Value) == true)
                    {
                        varMappedProductCount++;
                    }
                }
                if (Convert.ToBoolean(grdFinalSupplierMapping.SelectedRows[0].Cells[0].Value) == true)
                {
                    DataRow dr = dtSubGroupMapping.Select("PRODUCTID=" + varPRID).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = true;
                        dtSubGroupMapping.AcceptChanges();
                    }
                }
                else
                {
                    DataRow dr = dtSubGroupMapping.Select("PRODUCTID=" + varPRID).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = false;
                        dtSubGroupMapping.AcceptChanges();
                    }
                }
                if (varMappedProductCount > 0)
                {
                    BtnaddMove.Enabled = false;
                    btnRemove.Enabled = true;
                    grdSupplierMappingLoad.Columns[0].ReadOnly = true;
                }
                else
                {
                    btnRemove.Enabled = false;
                    grdSupplierMappingLoad.Columns[0].ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSetRegularText()
        {
            try
            {
                int varschedulenameflag = 0;
                for (int i = 0; i < grdSupplierList.RowCount; i++)
                {
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmsupname"].Value).ToUpper() == "REGULAR")
                    {
                        varschedulenameflag++;
                    }
                }
                if (varschedulenameflag != 0)
                {
                    txtScheduleName.Text = "";
                }
                else { txtScheduleName.Text = "Regular"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}