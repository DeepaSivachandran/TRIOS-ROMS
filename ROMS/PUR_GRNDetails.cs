using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 


namespace ROMS
{
    public partial class PUR_GRNDetails : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpProduct = new ToolTip();
        ToolTip tpconcern = new ToolTip();
        ToolTip tprate = new ToolTip();
        ToolTip tpbatchno = new ToolTip();
        ToolTip tpmonth = new ToolTip();
        ToolTip tpdate = new ToolTip();
        ToolTip tpyear = new ToolTip();
        ToolTip tpInvoiceQty = new ToolTip();
        ToolTip tpExcessQty = new ToolTip();
        ToolTip tpInvoiceNo = new ToolTip();
        ToolTip tpInvoiceAMT = new ToolTip();
        ToolTip tpReason = new ToolTip();
        DataSet objDs = new DataSet();
        public string GRNUpdateID = "";
        public DataTable dtPurchaseAutoComplete = new DataTable();
        public bool skipValidation = false;
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = ""
            , varorderSaleQty = "", varorderqty = "", addproductid = "", varunitid = "0", varDamage = "0", varReturnDC = "0", pbGRNId = "0", pbSupplierId = "0", dcid = "0",
            varenablefalg = "0", varUserID = "0", varflag = "0", varExpiryDate = "", varTName = "", varexp = "", pbScheduleId = "0", pbPOIdS = "0",
            varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0", varBatchNo = "0", varNewFlag = "0", varErrQty = "0", varTempExpiryDate = "0", varExpiryDateAdd = "", varInvoiceExpiryDate = "0", varInvExpiryDate="0";
        int grid_flag = 0;
        public int varGrnId = 0, varCloseflag = 0, pbDateflag = 0, varShelflife = 0, varMRPFlag = 0, varMRPEditflag = 0, expirydateFlag = 0, varErrorFormat = 0, varcount = 0, varErroronGrid = 0, varpono = 0, varModifiedFlag = 0, varUpDownKey = 0, varDecimal = 0, shelfLifeError = 0;
        public bool VarSearchFlag = true;
        public int PbVerified = 0, ParaSupplierAMT = 0, varSupplierType = 0, varGRNPrintFlag = 0;
        public string varGSTIN = "1";
        decimal varExcessQuantity = 0, varPendingQty = 0, varRMProductionFlag = 0, varDamageQty = 0 , varMismatchQty=0 ;
        public int varOrderType = 0;
        public double varDVA = 0, varCPA = 0;
        public string varProducts = "";
        public int varDateEnable = 0;
        List<int> varProductsIDs = new List<int>();
        public int varAutocompleteProduct = 0;
        public string varEditPRID = "0";
        public string pbStsID = "0";
        string varLocationID = "0", varRackID = "0" , varLocationName="" , varRack="", varPrid="" , varPoIDs="";
        public string varBlockedSupplier = "0", varBlockedReason = "0";
        public string pbConditionIDs = "0",pbCondition="";
        public int varLPFlag = 0,varNoDiffFlag=0,varExpDateValidFlag=0,varProValidation=0,varReasonFlag=0;
        public PUR_GRNDetails()
        {
            InitializeComponent();
        }
        private void PUR_GRNEntry_Load(object sender, EventArgs e)
        {
            try
            {
                lblDPercentage.Text = "< " + Convert.ToString(MainForm.pbShelflifeLevel1) + "%";
                lblPercentage.Text = "< " + Convert.ToString(MainForm.pbShelflifeLevel2) + "%";

                DataBind objDBind = new DataBind();
                objDBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (64) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPayment, "", "MST_DisplayText", "MSTID");
                objDBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (83) ORDER BY MST_OrderID", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
                objDBind = null; 
                this.ActiveControl = txtProductName;
                udfnDropdownLoad();
                udfnDtProductAutocomplte();
                udfnEditLoad();
                udfnDateSet();
                udfnPODropdownload();
                udfnGeneralSettingsList();
                if (chkCompleted.Checked == true && pbStsID!="17") //status not pending
                {
                    btnVerified.Enabled = false;
                }
                else
                {
                    btnVerified.Enabled = true;
                }
                if (Convert.ToInt32(cmbOrderType.SelectedValue) == 52)
                {
                    cmbProType.Enabled = false;
                }
                if (Convert.ToInt32(cmbProType.SelectedValue) == 214)
                {
                    tsbPO.Visible = false;
                    tsbAdded.Visible = false;
                    tsbProducts.Visible = false;
                    lbltotProduct.Visible = false;
                    lblAddProduct.Visible = false;
                    lblRemainProduct.Visible = false;
                    tss1.Visible = false;
                    tss2.Visible = false;
                }
                else
                {
                    tsbPO.Visible = true;
                    tsbAdded.Visible = true;
                    tsbProducts.Visible = true;
                    lbltotProduct.Visible = true;
                    lblAddProduct.Visible = true;
                    lblRemainProduct.Visible = true;
                    tss1.Visible = true;
                    tss2.Visible = true;
                } 
                udfnLoadConditions();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadConditions()
        { 
            MR_Master objMR_Master = new MR_Master();
            objMR_Master.ViewType = 25;
            SPDataService objspdservice = new SPDataService();
            DataSet objDs = new DataSet();
            objDs = objspdservice.udfnMaster(objMR_Master);
            objspdservice.CloseConnection();  
            if (objDs != null)
            {
                if (objDs.Tables.Count != 0)
                {
                    grdConditions.DataSource = objDs.Tables[0]; 
                }
                grdConditions.Columns["clmCheck"].Width = 40;
                grdConditions.Columns["Conditions"].Width = 130;
                grdConditions.Columns["ConditionID"].Visible = false;
                grdConditions.Columns["ConditionShortName"].Visible = false;
                grdConditions.Columns["Conditions"].ReadOnly = true;
                grdConditions.Columns["clmCheck"].HeaderText = "";
            }
        }
        public void udfnDtProductAutocomplte()
        {
            try
            {
                dtPurchaseAutoComplete = new DataTable();
                dtPurchaseAutoComplete.Columns.Add("Sno", typeof(int));
                dtPurchaseAutoComplete.Columns.Add("PRID", typeof(string));
                dtPurchaseAutoComplete.Columns.Add("MRP", typeof(decimal));
                dtPurchaseAutoComplete.Columns.Add("ExpiryDate", typeof(string));
                dtPurchaseAutoComplete.Columns.Add("BatchNo", typeof(string));
                dtPurchaseAutoComplete.Columns.Add("UTID", typeof(int));
                dtPurchaseAutoComplete.Columns.Add("SLID", typeof(int));
                dtPurchaseAutoComplete.Columns.Add("RKID", typeof(int));
                dtPurchaseAutoComplete.Columns.Add("ShelfLife_Flag", typeof(int));
                dtPurchaseAutoComplete.Columns.Add("Flag", typeof(int));
                dtPurchaseAutoComplete.Columns.Add("ID", typeof(int));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGeneralSettingsList()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGeneralSettingList(0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            varDVA = Convert.ToDouble(objDs.Tables[0].Rows[0]["GS_DVA"]);
                            varCPA = Convert.ToDouble(objDs.Tables[0].Rows[0]["GS_CPA"]);
                            varGRNPrintFlag = Convert.ToInt32(objDs.Tables[0].Rows[0]["GS_GRNPrint"]);
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
        public void udfnPODropdownload()
        {
            try
            {
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDT = null;
                objDT = objdserv.udfnPOEntry(10, 0, 0, 0, 0, 0, 0, 0, 0, "", "", 0, 0, "0", 0, 0, 0, 0, 0, Convert.ToInt32(pbGRNId),0);
                objdserv.CloseConnection();
                cmbProType.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbProType.ValueMember = "MSTID";
                            cmbProType.DisplayMember = "MST_DisplayText";
                            cmbProType.DataSource = objDT.Tables[0];
                        }
                        if (objDT.Tables[1].Rows.Count > 0)
                        {
                            if (Convert.ToInt32(objDT.Tables[1].Rows[0]["Count"]) > 0)
                            {
                                cmbProType.SelectedValue = 215;
                            }
                            else
                            {
                                cmbProType.SelectedValue = 214;
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

        public void udfnDateSet()
        {
            try
            {
                if (pbGRNId != "0")
                {
                    dpinvoicedate.MinDate = MainForm.pbFYStartDate;
                    dpinvoicedate.MaxDate = MainForm.pbCurrentDate;
                    //SPDataService objDServ = new SPDataService();
                    //DataSet objd = new DataSet();
                    //objd = objDServ.udfnMaster(4, 6, 0, "", "", 0, "", 0);
                    //if (objd.Tables[1].Rows.Count != 0)
                    //{
                    //    DateTime varmindate = DateTime.ParseExact(Convert.ToString(objd.Tables[1].Rows[0]["MinToday"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //    dpinvoicedate.MaxDate = varmindate;
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDropdownLoad()
        {
            SPDataService objdserv = new SPDataService();
            int varconcerntype = 3;
            DataSet objDT = new DataSet();
            objDT = objdserv.udfnCompanyList(varconcerntype, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
            objdserv.CloseConnection();
            cmbConcern.DataSource = null;
            if (objDT != null)
            {
                if (objDT.Tables.Count > 0)
                {
                    if (objDT.Tables[0].Rows.Count > 0)
                    {
                        cmbConcern.ValueMember = "COMID";
                        cmbConcern.DisplayMember = "COM_ShortName";
                        cmbConcern.DataSource = objDT.Tables[0];
                    }
                }
            }

            DataBind objDataBind = new DataBind();
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (16 ) OR MSTID  IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrderType, "", "MST_DisplayText", "MSTID");
            objDataBind = null;
        }

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errGRNDetails.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpconcern.ShowAlways = true;
                    tpconcern.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    errGRNDetails.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpGrnDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                {
                    string vardate = "", varResult = "";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    DataService objDservice = new DataService();
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,GETDATE(),103)");
                    varResult = objspdservice.udfngetVoucherNo("39", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                    objspdservice.CloseConnection();
                    if (varResult != "")
                    {
                        txtgrnno.Text = varResult;
                    }
                    else
                    {
                        txtgrnno.Text = "";
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
                skipValidation = true;
                udfnclose(sender, e);
                //MainForm.objPUR_GRNDetailsList.PUR_GRNDetailsList_Load(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclose(object sender, EventArgs e)
        {
            try
            {
                if (varModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();

                    }
                    else
                    { btnSave.Focus(); }
                }
                else
                {
                    if (varCloseflag == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            skipValidation = true;
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                    //MainForm.objPUR_GRNDetailsList.PUR_GRNDetailsList_Load(sender,e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnVerify1_Click(object sender, EventArgs e)
        {

            try
            {
                udfnverify(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnVerify2_Click(object sender, EventArgs e)
        {
            try
            {
                udfnverify(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnverify(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRNVerify = new PUR_GRNVerify();
                MainForm.objPUR_GRNVerify.pbGRNId = pbGRNId;
                if (btnVerify1.Enabled == true)
                {
                    MainForm.objPUR_GRNVerify.varVerifyType = 1;
                }
                else
                {
                    MainForm.objPUR_GRNVerify.varVerifyType = 2;
                }
                MainForm.objPUR_GRNVerify.ShowDialog();
                if (Convert.ToString(MainForm.objPUR_GRNVerify.varUserId) != "")
                {
                    if (varenablefalg == "1")
                    {
                        btnVerify1.Enabled = false;
                        btnVerify2.Enabled = true;
                        btnDC.Enabled = false;
                        gpAddrow.Enabled = false;
                    }
                    else if (varenablefalg == "2")
                    {
                        btnVerify1.Enabled = false;
                        btnVerify2.Enabled = false;
                    }
                    varCloseflag = 1;
                    udfnclose(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //SPDataService objdserv = new SPDataService();
                //DataSet objDs = new DataSet();
                //objDs = objdserv.udfnGrnListLoad(4, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0);
                //objdserv.CloseConnection();
                //if (objDs != null)
                //{
                //    if (objDs.Tables.Count != 0)
                //    {
                //        if (objDs.Tables[0].Rows.Count != 0)
                //        {
                //            lblVerified1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["VERIFIED1"]);
                //            lblVerifyDateTime.Text = Convert.ToString(objDs.Tables[0].Rows[0]["VERIFIEDON1"]);
                //        }
                //        if (objDs.Tables[1].Rows.Count != 0)
                //        {
                //            lblVerified2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["VERIFIED2"]);
                //            lblVerifyDateTime2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["VERIFIEDON2"]);
                //        }
                //    }
                //} 
            }
        }

        private void TxtInvoiceamt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceamt.BackColor = Color.White;
                if (Convert.ToDecimal(txtInvoiceamt.Text) >= 25000)
                {
                    if (chkCompleted.Enabled == false)
                    {
                        btnVerify1.Enabled = true;
                    }
                }
                else
                {
                    btnVerify1.Enabled = false;
                    btnVerify2.Enabled = false;
                }
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
                if (Convert.ToInt32(cmbOrderType.SelectedValue) == 52) { cmbProType.Enabled = false; txtProductName.Focus(); }
                else { cmbProType.Enabled = true; txtProductName.Focus(); }
                //if (Convert.ToInt32(cmbOrderType.SelectedValue) == 53)
                //{

                //    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                //    MainForm.objPUR_GRNOrderType.ShowDialog();
                //}
                //else
                //{
                //    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                //    MainForm.objPUR_GRNOrderType.Close();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                varNewFlag = "0";
                MainForm.objPUR_Product = new PUR_Product();
                MainForm.objPUR_Product.ShowDialog();
                txtProductName.Focus();
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
                int varErrEmp = 0;
                if (grdGrnlist.Rows.Count != 0) 
                {
                    string result = "", varPurchaseDC = "0", varSkip = "0", varDC = "0";
                    varflag = "0"; varUserID = "0";
                    int varTotalIssue = 0,varEditFlag=0;
                    DialogResult result1 = DialogResult.Yes;
                    SPDataService objDServ = new SPDataService();
                    DataSet objDs = new DataSet();
                    dcid = "0";
                    for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                    {
                        if (dcid == "0")
                        {
                            dcid = Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                        }
                        else
                        {
                            dcid = dcid + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                        }
                    } 
                    TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                    objTRN_PurchaseReturnDC.paraViewType = 6;
                    objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_PurchaseReturnDC.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text); 
                    objTRN_PurchaseReturnDC.ParaScheduleID = Convert.ToInt32(lblschedule.Text);
                    objTRN_PurchaseReturnDC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_PurchaseReturnDC.paraDCIDs = Convert.ToString(dcid);
                    objDs = objDServ.udfnReturnDC(objTRN_PurchaseReturnDC);
                    objDServ.CloseConnection();
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        varDC = Convert.ToString(objDs.Tables[0].Rows[0]["ID"]);
                    } 
                    if (varReturnDC != "0" && (chkCompleted.Enabled == true && chkCompleted.Checked == true))
                    {
                        if (varDC != "0")
                        {
                            string varMessage = objDServ.udfnGetMessages(102);
                            objDServ.CloseConnection();
                            varSkip = "1";
                            result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                    else
                    {
                        result1 = DialogResult.Yes;
                    }
                    if (varErrQty == "1")
                    {
                        SPDataService objDserv = new SPDataService();
                        string varMessage = objDserv.udfnGetMessages(89);
                        objDserv.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result1 = DialogResult.No;
                    }
                    else
                    {
                        result1 = DialogResult.Yes;
                    }   
                    if (txtInvoiceno.Text.Trim() == "")
                    {
                        errGRNDetails.SetError(txtInvoiceno, "Please enter invoiceno.");
                        txtInvoiceno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpInvoiceNo.ShowAlways = true;
                        tpInvoiceNo.Show("Please enter invoiceno.", txtInvoiceno, 5000);
                        result1 = DialogResult.No;
                        varErrorFormat = 1;
                    }
                    if (chkCompleted.Checked == true && lblVerifiedBy1.Text == "" && lblVerifiedBy2.Text == "" && Convert.ToDouble(txtInvoiceamt.Text) < varDVA)
                    {
                        string varMessage = objDServ.udfnGetMessages(119);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result1 = DialogResult.No;
                        varErrorFormat = 1;
                        varErrEmp = 1;
                    }
                    if (chkCompleted.Checked == true && (Convert.ToDouble(txtInvoiceamt.Text)) >= varDVA)
                    {
                        if (lblVerifiedBy1.Text == "" || lblVerifiedBy2.Text == "")
                        { 
                            string varMessage = objDServ.udfnGetMessages(120);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result1 = DialogResult.No;
                            varErrorFormat = 1;
                            varErrEmp = 1;
                        }
                    }
                    if (txtInvoiceamt.Text.Trim() == "")
                    {
                        errGRNDetails.SetError(txtInvoiceamt, "Please enter invoice amount.");
                        txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpInvoiceAMT.ShowAlways = true;
                        tpInvoiceAMT.Show("Please enter invoice amount.", txtInvoiceamt, 5000);
                        result1 = DialogResult.No;
                        varErrorFormat = 1;
                    }
                    if (varErrEmp == 0)
                    {
                        if (varBlockedSupplier == "98")
                        {
                            SPDataService objDS = new SPDataService();
                            string varMessage = objDS.udfnGetMessages(134);
                            objDS.CloseConnection();
                            DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.No)
                            {
                                result1 = DialogResult.No;
                            }
                        }
                    }
                    if (result1 == DialogResult.Yes)
                    {
                        errGRNDetails.Clear();
                        for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                        {
                            if (varPurchaseDC == "0")
                            {
                                varPurchaseDC = Convert.ToString(grdReurnDC.Rows[i].Cells["ID"].Value);
                            }
                            else
                            {
                                varPurchaseDC = varPurchaseDC + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["ID"].Value);
                            }
                        }
                        DataTable objGRNProd = new DataTable();
                        DataTable objGRNProdValidation = new DataTable();
                        (objGRNProd, objGRNProdValidation) = udfnobjGRNProd();
                        if (shelfLifeError != 0)
                        {
                            string varShelflifeMessage = "", varShelflifeLevel = "";
                            varShelflifeLevel = Convert.ToString(MainForm.pbShelflifeLevel2) + '%';
                            SPDataService objDServe1 = new SPDataService();
                            string varMessage = objDServe1.udfnGetMessages(110);
                            objDServe1.CloseConnection();
                            varShelflifeMessage = Convert.ToString(varMessage.Replace("50%", varShelflifeLevel));
                            DialogResult dialogResult1 = MessageBox.Show(varShelflifeMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult1 == DialogResult.Yes)
                            {
                                shelfLifeError = 0;
                            }
                        }
                        if (shelfLifeError == 0)
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet Result = new DataSet();
                            TRN_Validate_Products_By_Condition objTRN_Validate_Products_By_Condition = new TRN_Validate_Products_By_Condition();
                            objTRN_Validate_Products_By_Condition.ProductList = objGRNProdValidation;
                            objTRN_Validate_Products_By_Condition.ParaEntryDate = Convert.ToString(dpGrnDate.Text);
                            Result = objspdservice.udfnValidateProductsByCondition(objTRN_Validate_Products_By_Condition); 
                            if (Result.Tables[0].Rows.Count != 0)
                            {
                                varTotalIssue = Convert.ToInt32(Result.Tables[0].Rows[0]["Total_Issues"]);
                                if (varTotalIssue == 0)
                                {
                                    varEditFlag = 1;
                                }
                                else
                                {
                                    for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                                    {
                                        var gridRow = grdGrnlist.Rows[i];
                                        var varIssueow = Result.Tables[0].Rows[i];
                                        if (Convert.ToString(gridRow.Cells["clmsno"].Value) == Convert.ToString(varIssueow["GRNPR_SNO"]))
                                        {
                                            if (Convert.ToInt32(varIssueow["Expiry_Date_Issue"]) != 0 || Convert.ToInt32(varIssueow["Pro_Expiry_Date_Issue"]) != 0)
                                            {
                                                gridRow.Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                                gridRow.Cells["clmInvoiceExpiry"].Style.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                gridRow.Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                                gridRow.Cells["clmInvoiceExpiry"].Style.BackColor = Color.PaleGreen;
                                            }
                                            if (Convert.ToInt32(varIssueow["MRP_Valid_Issue"]) != 0 || Convert.ToInt32(varIssueow["Pro_MRP_Valid_Issue"]) != 0)
                                            {
                                                gridRow.Cells["clmmrp"].Style.BackColor = Color.LightPink;
                                                gridRow.Cells["clmInvoiceMRP"].Style.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                gridRow.Cells["clmmrp"].Style.BackColor = Color.PaleGreen;
                                                gridRow.Cells["clmInvoiceMRP"].Style.BackColor = Color.PaleGreen;
                                            }
                                            if (Convert.ToInt32(varIssueow["Pro_BatchNo_Issue"]) != 0 || Convert.ToInt32(varIssueow["Invoice_BatchNo_Issue"]) != 0)
                                            {
                                                gridRow.Cells["clmBatchno"].Style.BackColor = Color.LightPink;
                                                gridRow.Cells["clmInvoiceBatch"].Style.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                gridRow.Cells["clmBatchno"].Style.BackColor = Color.PaleGreen;
                                                gridRow.Cells["clmInvoiceBatch"].Style.BackColor = Color.PaleGreen;
                                            }
                                            if (Convert.ToInt32(varIssueow["Pro_BatchNo_Issue"]) != 0 || Convert.ToInt32(varIssueow["Invoice_BatchNo_Issue"]) != 0)
                                            {
                                                gridRow.Cells["clmBatchno"].Style.BackColor = Color.LightPink;
                                                gridRow.Cells["clmInvoiceBatch"].Style.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                gridRow.Cells["clmBatchno"].Style.BackColor = Color.PaleGreen;
                                                gridRow.Cells["clmInvoiceBatch"].Style.BackColor = Color.PaleGreen;
                                            }
                                            if (Convert.ToInt32(varIssueow["Location_Issue"]) != 0)
                                            {
                                                gridRow.Cells["clmLocation"].Style.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                gridRow.Cells["clmLocation"].Style.BackColor = Color.PaleGreen;
                                            }
                                            if (Convert.ToInt32(varIssueow["Rack_Issue"]) != 0)
                                            {
                                                gridRow.Cells["clmRack"].Style.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                gridRow.Cells["clmRack"].Style.BackColor = Color.PaleGreen;
                                            }
                                        }
                                    }
                                }
                            }
                            if (varTotalIssue == 0)
                            { 
                                grdGrnlist.ClearSelection();
                                //MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                                //MainForm.objPUR_GRNApprovalVerify.varTrnType = 1;
                                //MainForm.objPUR_GRNApprovalVerify.ShowDialog();
                                //varUserID = MainForm.objPUR_GRNApprovalVerify.varUserId;
                                //if (MainForm.objPUR_GRNApprovalVerify.flag == 1)
                                //{
                                varGrnId = Convert.ToInt32(pbGRNId);
                                varUserID = MainForm.pbUserID;
                                TRN_GRN objTRNS_GRN = new TRN_GRN();
                                objTRNS_GRN.ViewType = 3;
                                objTRNS_GRN.ParaEditFlag = 1;
                                objTRNS_GRN.ParaGRNID = varGrnId;
                                objTRNS_GRN.paraINVDate = dpinvoicedate.Text;
                                objTRNS_GRN.paraINVNo = txtInvoiceno.Text;
                                objTRNS_GRN.ParaInvAmt = Convert.ToDecimal(txtInvoiceamt.Text);
                                objTRNS_GRN.ParaPurchaseDC = varPurchaseDC;
                                objTRNS_GRN.paraUserID = Convert.ToInt32(varUserID);
                                objTRNS_GRN.paraRemarks = txtRemark.Text;
                                objTRNS_GRN.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                                objTRNS_GRN.paraScheduleID = Convert.ToInt32(lblschedule.Text);
                                objTRNS_GRN.paraID = ParaSupplierAMT;
                                objTRNS_GRN.paraPayment = Convert.ToInt32(cmbPayment.SelectedValue);
                                objTRNS_GRN.paraSkipped = varSkip;
                                objTRNS_GRN.paraGRNProd = objGRNProd;
                                objTRNS_GRN.paraGRNDate = dpGrnDate.Text;
                                if (chkCompleted.Enabled == true)
                                {
                                    objTRNS_GRN.paraflag = 1;
                                }
                                else
                                {
                                    objTRNS_GRN.paraflag = 0;
                                }
                                if (chkCompleted.Enabled == true)
                                {
                                    if (chkCompleted.Checked == true)
                                    {
                                        objTRNS_GRN.paraStatus = 23;
                                        if (varSkip == "1")
                                        {
                                            objTRNS_GRN.paraOriginator = "GRN DC Skipped";
                                        }
                                        else
                                        {
                                            objTRNS_GRN.paraOriginator = "GRN Detail Complete";
                                        }
                                    }
                                    else
                                    {
                                        objTRNS_GRN.paraStatus = 17;
                                        objTRNS_GRN.paraOriginator = "GRN Detail Update";
                                    }
                                }
                                else
                                {
                                    if (btnVerify2.Enabled == true)
                                    {
                                        //objTRNS_GRN.paraStatus = 24;
                                    }
                                    else
                                    {
                                        objTRNS_GRN.paraStatus = 23;
                                    }
                                }
                            K: objTRNS_GRN.paraSaveFlag = 0;
                                result = objspdservice.udfnGRNEntry(objTRNS_GRN);
                                objspdservice.CloseConnection();
                                string[] varvalue = result.Split('~');
                                if (result.Split('~')[1] == "1")
                                {
                                    if (chkCompleted.Checked == true)
                                    {
                                        Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                                        objMR_Supplier.ViewType = 33;
                                        objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                                        objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                                        DataSet objDserv = new DataSet();
                                        SPDataService objspdser = new SPDataService();
                                        objDserv = objspdser.udfnSupplierList(objMR_Supplier);
                                        objspdser.CloseConnection();
                                        if (objDserv != null)
                                        {
                                            string value = "";
                                            if (objDserv.Tables.Count != 0)
                                            {
                                                if (objDserv.Tables[0].Rows.Count != 0)
                                                {
                                                    value = Convert.ToString(objDserv.Tables[0].Rows[0]["Value"]);
                                                }
                                            }
                                            if (value == "1")
                                            {
                                                varGSTIN = "0";
                                                MainForm.objGRN_GSTIN = new GRN_GSTIN();
                                                MainForm.objGRN_GSTIN.pbvarSupplierCode = Convert.ToInt16(lblSupplierCode.Text);
                                                MainForm.objGRN_GSTIN.ShowDialog();
                                                varGSTIN = Convert.ToString(MainForm.objGRN_GSTIN.varGSTIN);
                                            }
                                            else
                                            {
                                                varGSTIN = "1";
                                            }
                                        }
                                    }
                                    if (chkCompleted.Checked == false)
                                    {
                                        varGSTIN = "1";
                                    }
                                    int passkeyflag = 0;
                                    if (chkCompleted.Checked == true && varGSTIN == "1")
                                    {
                                        MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                                        MainForm.objPUR_GRNApprovalVerify.varTrnType = 1;
                                        MainForm.objPUR_GRNApprovalVerify.ShowDialog();
                                        varUserID = MainForm.objPUR_GRNApprovalVerify.varUserId;
                                        passkeyflag = MainForm.objPUR_GRNApprovalVerify.flag;
                                    }
                                    else
                                    {
                                        if (varGSTIN == "1")
                                        {
                                            passkeyflag = 1;
                                        }
                                    }
                                    if (passkeyflag == 1)
                                    {
                                        objTRNS_GRN.paraSaveFlag = 1;
                                        objTRNS_GRN.paraUserID = Convert.ToInt32(varUserID);
                                        result = objspdservice.udfnGRNEntry(objTRNS_GRN);
                                        objspdservice.CloseConnection();
                                        varvalue = result.Split('~');
                                        if (varvalue[0] == "3")
                                        {
                                            varModifiedFlag = 0;
                                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            try
                                            {
                                                if (btnSave.Text == "Update" && varGRNPrintFlag == 1)
                                                {
                                                    if (varGrnId == 0)
                                                    {
                                                        GRNUpdateID = varvalue[2];
                                                    }
                                                    string ID = "0";
                                                    if (varGrnId == 0)
                                                    {
                                                        ID = varvalue[2];
                                                    }
                                                    else
                                                    {
                                                        ID = Convert.ToString(varGrnId);
                                                    }

                                                    SPDataService objDServs = new SPDataService();
                                                    string varMessage = objDServs.udfnGetMessages(87);
                                                    objDServs.CloseConnection();
                                                    result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                    if (result1 == DialogResult.Yes)
                                                    {
                                                        string varHeader = "";
                                                        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_PUR_GRNDetails.rpt");
                                                        varHeader = "Godown Wise GRN Transfer";

                                                        objBillreport.SetParameterValue("paraGRNID", Convert.ToInt32(ID));
                                                        objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(cmbConcern.SelectedValue));
                                                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                                                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                                                        objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                                                        objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                                                        objValidation.CrySqlConnection(objBillreport);

                                                        MainForm.objReportLoad = new ReportLoad();
                                                        MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                                        MainForm.objReportLoad.Text = varHeader;
                                                        MainForm.objReportLoad.ShowDialog();
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                objError = new DataError();
                                                objError.WriteFile(ex);
                                            }
                                            this.ActiveControl = txtSupplier;
                                            MainForm.objPUR_GRNDetailsList.udfnListLoad();
                                            varCloseflag = 1;
                                            udfnclose(sender, e);
                                        }
                                        else
                                        {
                                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                else
                                {
                                    if (varvalue[0] == "5")
                                    {
                                        DialogResult dialogResult = MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            ParaSupplierAMT = 1;
                                            objTRNS_GRN.paraSaveFlag = 1;
                                            objTRNS_GRN.paraID = ParaSupplierAMT;
                                            goto K;
                                        }
                                        else
                                        {
                                            txtInvoiceamt.Focus();
                                        }
                                    }
                                    else
                                    {
                                        if (varvalue[0] == "3")
                                        {
                                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            MainForm.objPUR_GRNDetailsList.udfnListLoad();
                                            varCloseflag = 1;
                                            varModifiedFlag = 0;
                                            udfnclose(sender, e);
                                        }
                                        else
                                        {
                                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (varErrorFormat == 0)
                        {
                            udfnDcAdd();
                        }
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
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
        }
        public (DataTable objGRNProd,DataTable objGRNProdValidation) udfnobjGRNProd()
        {
            varcount = 0; shelfLifeError = 0;
            DataTable objGRNProd = new DataTable();
            DataTable objGRNProdValidation = new DataTable();
            try
            {
                objGRNProd.TableName = "TRN_GRN_Products";
                objGRNProd.Columns.Add("GRNPR_SNO", typeof(int));
                objGRNProd.Columns.Add("GRNPR_GRNID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_PRID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_UTID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_QTY", typeof(float));
                objGRNProd.Columns.Add("GRNPR_ReturnType", typeof(int));
                objGRNProd.Columns.Add("GRNPR_Condition_Type", typeof(string)); 
                objGRNProd.Columns.Add("GRNPR_MRP", typeof(float));   
                objGRNProd.Columns.Add("GRNPR_BatchNo", typeof(string));
                objGRNProd.Columns.Add("GRNPR_ShelfLifeValue", typeof(int));
                objGRNProd.Columns.Add("GRNPR_ShelfLifeType", typeof(int)); 
                objGRNProd.Columns.Add("GRNPR_ShelfLife_Per", typeof(float));
                objGRNProd.Columns.Add("GRNPR_Expirydate", typeof(string));
                objGRNProd.Columns.Add("GRNPR_PRName", typeof(string));
                objGRNProd.Columns.Add("GRNPR_ShelfLifeStatus", typeof(int));
                objGRNProd.Columns.Add("GRNPR_BatchNoStatus", typeof(int));
                objGRNProd.Columns.Add("GRNPR_BatchNoGenration", typeof(int));
                objGRNProd.Columns.Add("GRNPR_PRFlag", typeof(int));
                objGRNProd.Columns.Add("GRNPR_ShelfLife_Flag", typeof(int)); 
                objGRNProd.Columns.Add("GRNPR_MRPFlag", typeof(int));
                objGRNProd.Columns.Add("GRNPR_SLID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_RKID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_RMProductionFlag", typeof(int));
                objGRNProd.Columns.Add("GRNPR_InvoiceMRP", typeof(decimal));
                objGRNProd.Columns.Add("GRNPR_InvoiceExpirydate", typeof(string));
                objGRNProd.Columns.Add("GRNPR_InvoiceBatchNo", typeof(string));
                objGRNProd.Columns.Add("GRNPR_POID", typeof(int));
                 
                objGRNProdValidation.TableName = "TRN_Products";
                objGRNProdValidation.Columns.Add("GRNPR_SNO", typeof(int));
                objGRNProdValidation.Columns.Add("GRNPR_PRID", typeof(int));
                objGRNProdValidation.Columns.Add("GRNPR_QTY", typeof(float));
                objGRNProdValidation.Columns.Add("GRNPR_Condition_Type", typeof(string));
                objGRNProdValidation.Columns.Add("GRNPR_MRP", typeof(float));
                objGRNProdValidation.Columns.Add("GRNPR_Expirydate", typeof(string));
                objGRNProdValidation.Columns.Add("GRNPR_SLID", typeof(int));
                objGRNProdValidation.Columns.Add("GRNPR_RKID", typeof(int));
                objGRNProdValidation.Columns.Add("GRNPR_InvoiceMRP", typeof(float));
                objGRNProdValidation.Columns.Add("GRNPR_InvoiceExpirydate", typeof(string));
                objGRNProdValidation.Columns.Add("GRNPR_Return_Type", typeof(int));
                objGRNProdValidation.Columns.Add("GRNPR_BatchNo", typeof(string));
                objGRNProdValidation.Columns.Add("GRNPR_InvoiceBatchNo", typeof(string)); 

                if (chkCompleted.Enabled == true)
                {
                    grdGrnlist.ClearSelection();
                    for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                    {
                        decimal varMRP = 0, varInvoiceMRP = 0; decimal varPendingQty = 0; string varProConditionType = "0"; decimal varMismatchqty = 0;
                        decimal varExcessQuantity = 0; decimal varExcessQty = 0; decimal varShelfPer = 0, varDamageQty = 0;
                        int Shelflifevalue = 0, ProShelflife = 0, ProFlag = 0, POID = 0; decimal PoQty = 0; varTempExpiryDate = ""; string varExpiryDate = "";
                        string varInvoiceExpiryDate = "", varInvoiceExpiry = "",varInvoiceBatchNo="",varProBatchNo="";
                        string varTempYear = "0", varInvoiceYear = "0"; int varSLID = 0, varRKID = 0,varPOID=0;
                        int sno = 0,varReasonType=0; 
                         
                        if(Convert.ToString(grdGrnlist.Rows[i].Cells["clmsno"].Value)!="")
                        {
                            sno = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmsno"].Value);
                        }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmPOID"].Value) == "")
                        {
                            POID = 0;
                        }
                        else { POID = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmPOID"].Value); } 
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmmrp"].Value) != "")
                        {
                            varMRP = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmmrp"].Value);
                        }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmInvoiceMRP"].Value) != "")
                        {
                            varInvoiceMRP = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmInvoiceMRP"].Value);
                        }  
                        if (Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmMismatchQty"].Value) != 0  )
                        {
                            varPendingQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmMismatchQty"].Value);
                        }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value) != "")
                        {
                            varProBatchNo = Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value);
                        }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmInvoiceBatch"].Value) != "")
                        {
                            varInvoiceBatchNo = Convert.ToString(grdGrnlist.Rows[i].Cells["clmInvoiceBatch"].Value);
                        } 
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmMismatchQty"].Value)!="")
                        { varMismatchqty= Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmMismatchQty"].Value); } 

                        string[] varShelflifevaluesplit = Convert.ToString(grdGrnlist.Rows[i].Cells["clmactuallife"].Value).Split(' ');
                        string[] varShelflifeper = Convert.ToString(grdGrnlist.Rows[i].Cells["clmshelfper"].Value).Split(' ');
                        string[] varProShelfLife = Convert.ToString(grdGrnlist.Rows[i].Cells["clmshelflife"].Value).Split(' ');
                        
                        if(Convert.ToString(varShelflifeper[0])!="" && Convert.ToDecimal(varShelflifeper[0]) < Convert.ToDecimal(MainForm.pbShelflifeLevel2))
                        {
                            shelfLifeError++;
                        }
                        if (Convert.ToString(varProShelfLife[0]) != "")
                        {
                            ProShelflife = Convert.ToInt32(varProShelfLife[0]);
                        }
                        else { ProShelflife = 0; }

                        if (Convert.ToString(varShelflifevaluesplit[0]) != "")
                        {
                            Shelflifevalue = Convert.ToInt32(varShelflifevaluesplit[0]);
                        }
                        else { Shelflifevalue = 0; }

                        if (Convert.ToString(varShelflifeper[0]) != "")
                        {
                            varShelfPer = Convert.ToDecimal(varShelflifeper[0]);
                        }
                        else { varShelfPer = 0; }    
                        object cellValue = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value);

                        varExpiryDate = cellValue.ToString();
                        string[] DMY = varExpiryDate.Split('/');
                        if (DMY.Count() == 3)
                        {
                            varTempYear = DMY[2];
                            if (varTempYear.Length == 2)
                            {
                                cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
                            }
                            else
                            {
                                cellValue = DMY[0] + "/" + DMY[1] + "/" + varTempYear;
                            }
                        }
                        object cellInvoiceExpiry = Convert.ToString(grdGrnlist.Rows[i].Cells["clmInvoiceExpiry"].Value); 
                        varInvoiceExpiryDate = cellInvoiceExpiry.ToString();
                        string[] DMY1 = varInvoiceExpiryDate.Split('/');
                        if (DMY1.Count() == 3)
                        {
                            varInvoiceYear = DMY1[2];
                            if (varInvoiceYear.Length == 2)
                            {
                                cellInvoiceExpiry = DMY1[0] + "/" + DMY1[1] + "/" + 20 + varInvoiceYear;
                            }
                            else
                            {
                                cellInvoiceExpiry = DMY1[0] + "/" + DMY1[1] + "/" + varInvoiceYear;
                            }
                        }  
                        varTempExpiryDate = cellValue.ToString();
                        varInvoiceExpiry = cellInvoiceExpiry.ToString();

                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmSLID"].Value) != "")
                        { varSLID = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmSLID"].Value); }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmRKID"].Value) != "")
                        { varRKID = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmRKID"].Value); }
                        
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConditionId"].Value) != "")
                        {
                            varProConditionType = Convert.ToString(grdGrnlist.Rows[i].Cells["clmConditionId"].Value);
                        }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmReasonID"].Value) != "")
                        {
                            varReasonType = Convert.ToInt16(grdGrnlist.Rows[i].Cells["clmReasonID"].Value);
                        } 
                        DataService objDser = new DataService();

                        objGRNProd.Rows.Add(sno, Convert.ToInt32(pbGRNId), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmProid"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmUtid"].Value), varMismatchqty, varReasonType, varProConditionType, varMRP, varProBatchNo,  ProShelflife, 0, varShelfPer, varTempExpiryDate, Convert.ToString(grdGrnlist.Rows[i].Cells["clmtam"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmShelflifeenable"].Value)  , Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmBatchenable"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmBatchgeneration"].Value), ProFlag, Shelflifevalue,  Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmMRPflag"].Value), varSLID, varRKID, Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmRMFlag"].Value), varInvoiceMRP, varInvoiceExpiry, varInvoiceBatchNo, POID);

                        objGRNProdValidation.Rows.Add(sno, Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmProid"].Value), varMismatchqty, varProConditionType, varMRP, varExpiryDate, varSLID, varRKID, varInvoiceMRP, varInvoiceExpiryDate, varReasonType, varProBatchNo, varInvoiceBatchNo);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return (objGRNProd, objGRNProdValidation); 
        }
        private void ChkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCompleted.Checked) { btnSave.Text = "Update"; } else { btnSave.Text = "Update as Draft"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void DpGrnDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpGrnDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void DpGrnDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpGrnDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void DpGrnDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupplier.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrderType.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (LV_Supplier.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        LV_Supplier.Visible = false;
                    }
                    else
                    {
                        LV_Supplier.Focus();
                    }
                    if (LV_Supplier.Items.Count > 0)
                    {
                        LV_Supplier.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSupplier_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 30;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.BringToFront();
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    LV_Supplier.Visible = false;
                    LV_Supplier.Items.Clear();
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

        private void LV_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        public void udfnListViewData()
        {
            try
            {
                if (txtSupplier.Text != "")
                {
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    udfnsupplierLoad();
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    cmbOrderType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                LV_Supplier.Visible = false;
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
                    dpinvoicedate.Focus();
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

        private void Txtmrprate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtDate.Enabled == true)
                    {
                        txtDate.Focus();
                    }
                    else
                    {
                        if (txtBatchno.Enabled == true)
                        {
                            txtBatchno.Focus();
                        }
                        else
                        {
                            btnAdd.Focus();
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

        private void Txtmrprate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtmrprate.Text.Trim() == "")
                {
                    txtmrprate.Text = "0";
                }
                txtmrprate.BackColor = Color.White;
                decimal varMRP = Math.Round(Convert.ToDecimal(txtmrprate.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                string mrp = string.Format("{0:0.00}", varMRP);
                string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                txtmrprate.Text = mrp;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmrprate_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtProductName.Text == "")
                {
                    lblProductcode.Text = "0";
                    txtmrprate.Text = "";
                    txtDate.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtBatchno.Text = "";
                }
                txtmrprate.BackColor = Color.LemonChiffon; 
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtDate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Month_KeyDown(object sender, KeyEventArgs e)
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

        private void Month_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Month_Enter(object sender, EventArgs e)
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

        private void Year_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Year_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Year_Enter(object sender, EventArgs e)
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

        private void TxtBatchno_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtBatchno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchno.Text.Trim() == "")
                    {
                        txtBatchno.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtBatchno, "Please enter BatchNo.");
                        tpbatchno.ShowAlways = true;
                        tpbatchno.Show("Please enter BatchNo.", txtBatchno, 5000);
                    }
                    else
                    {
                        txtBatchno.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
                else
                {
                    txtBatchno.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBatchno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchno.BackColor = Color.LemonChiffon;
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

        private void ChkCompleted_Leave(object sender, EventArgs e)
        {
            try
            {
                chkCompleted.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkCompleted_Enter(object sender, EventArgs e)
        {
            try
            {
                chkCompleted.BackColor = Color.White;
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

        private void BtnDC_Click(object sender, EventArgs e)
        {
            try
            {
                udfnDcAdd();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        public void udfnDcAdd()
        {
            try
            {
                dcid = "0";
                for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                {
                    if (dcid == "0")
                    {
                        dcid = Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                    }
                    else
                    {
                        dcid = dcid + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                    }
                }
                MainForm.objINV_GRNPODamaged = new INV_GRNPODamaged();
                MainForm.objINV_GRNPODamaged.varMasterType = "1";
                MainForm.objINV_GRNPODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void Txtmrprate_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void TxtDate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Month_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Year_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    int paraViewType = 0; string PRID = "0";
                    txtBatchno.BackColor = SystemColors.Control;
                    string varProductsCodes = "0";
                    //lvproduct.Items.Clear();
                    varNewFlag = "0";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    int GRNID = 0;
                    if (txtProductName.Text != "" || txtProductName.Text == "")
                    {
                        udfncleardata();
                        //txtStockLocation.Text = "";
                        //lblStockLocationCode.Text = "0";
                        //lvStockLocation.Visible = false;
                    }
                    if (txtProductName.Text.Length > 0)
                    {
                        if (Convert.ToInt32(cmbProType.SelectedValue) == 214)
                        {
                            GRNID = 0;
                            paraViewType = 29;
                        }
                        else
                        {
                            GRNID = Convert.ToInt32(pbGRNId);
                            paraViewType = 59;

                            if (varProducts != "")
                            {
                                var strings1 = varProductsIDs.Select(xx => xx);
                                PRID = (string.Join(",", strings1));
                            }
                        }

                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = paraViewType;
                        objMR_Product.ParaProductCode = 0;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.ParaScheduleid = Convert.ToString(lblschedule.Text);
                        objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                        objMR_Product.paraId = 0;
                        objMR_Product.ParaGRNID = GRNID;
                        objMR_Product.ParaProductsCode = PRID;
                        //ParaGRNID

                        if (VarSearchFlag == true)
                        {
                            objMR_Product.paraPicode = txtProductName.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraProductName = txtProductName.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        objspdservice.CloseConnection();

                        //lvproduct.BeginUpdate();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {   /*
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(),objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(),
                                        objDs.Tables[0].Rows[i]["PR_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PR_BatchNoGeneration"].ToString(),objDs.Tables[0].Rows[i]["PR_RMForProduction"].ToString(),objDs.Tables[0].Rows[i]["PR_PRCTID"].ToString(),objDs.Tables[0].Rows[i]["PR_ShelfLife"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvproduct.Items.Add(objList);
                                    }
                                    lvproduct.Visible = true;
                                    lvproduct.BringToFront();
                                    lvproduct.Columns[0].Width = 100;
                                    lvproduct.Columns[3].Width = 50;
                                    if (VarSearchFlag == true)
                                    {
                                        lvproduct.Columns[1].Width = 320;
                                        lvproduct.Columns[2].Width = 0;
                                    }
                                    else
                                    {
                                        lvproduct.Columns[1].Width = 0;
                                        lvproduct.Columns[2].Width = 320;
                                    }
                                    lvproduct.Columns[3].Width = 0;
                                    lvproduct.Columns[4].Width = 0;
                                    lvproduct.Columns[5].Width = 0;
                                    lvproduct.Columns[6].Width = 0;
                                    lvproduct.Columns[7].Width = 0;
                                    lvproduct.Columns[8].Width = 0;
                                    lvproduct.Columns[9].Width = 0;
                                    lvproduct.EndUpdate();
                                    */

                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.BringToFront();
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Visible = true;
                                    DGV_FilterProduct.Columns["PR_BatchNo"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_BatchNoGeneration"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_RMForProduction"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PRCTID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_ShelfLife"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["pr_retailrate"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_MRPflag"].Visible = false;
                                    DGV_FilterProduct.Columns["Product Shelf Life"].Width = 115;
                                    DGV_FilterProduct.Columns["PR_HSNID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 60;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                    if (VarSearchFlag == false)
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2;
                                    }
                                    else
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 2;
                                    }
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                    //lvProduct.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                                //lvProduct.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                            //lvProduct.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                        //lvProduct.Visible = false;
                        //lvProduct.Items.Clear();
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

        private void TxtInvoiceamt_KeyPress(object sender, KeyPressEventArgs e)
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
        }
        public void udfnProDetailsTolProCount()
        {
            try
            {
                int varFlag = 0; string varID = "0";

                //if (Convert.ToString(cmbEntryType.SelectedValue) == "55")//po
                //{
                //    varFlag = 0;
                //    varID = pbPONO;
                //}
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 15;
                objTRN_PurchaseEntry.paraType = varFlag;
                objTRN_PurchaseEntry.ParaIds = varID;
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                if (varFlag == 0)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lbltotProduct.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ProductCount"]);
                            lblRemainProduct.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ProductCount"]);
                        }
                    }
                }
                else
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            lbltotProduct.Text = Convert.ToString(objDs.Tables[1].Rows[0]["ProductCount"]);
                            lblRemainProduct.Text = Convert.ToString(objDs.Tables[1].Rows[0]["ProductCount"]);
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
        public void udfnProductCount()
        {
            try
            {
                varPrid = "";
                int varProductType = Convert.ToInt16(cmbProType.SelectedValue);
                if (varProductType == 215) //po
                {
                    var varProIds = from r in dtPurchaseAutoComplete.AsEnumerable()
                                    where (r.Field<int>("Flag").Equals(varProductType))
                                    group r by r.Field<string>("PRID") into g
                                    select g.Key;

                    if (varPrid == "")
                    {
                        varPrid = Convert.ToString(varProIds);
                    }
                    else
                    {
                        for (int i = 0; i < varProIds.Count(); i++)
                        {
                            varPrid = varPrid + ',' + varProIds.ToList()[i];
                        }
                    }
                    if (Convert.ToString(cmbProType.SelectedValue) == "215")
                    {
                        lblAddProduct.Text = Convert.ToString(varProIds.Count());
                        lblRemainProduct.Text = Convert.ToString(Convert.ToInt32(lbltotProduct.Text) - varProIds.Count());
                    }
                }
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
                pbDateflag = 0;
                udfnAddProductsgrid();
                txtTotalpro.Text = Convert.ToString(grdGrnlist.Rows.Count);
                udfnProductCount();
                ((DataGridViewTextBoxColumn)grdGrnlist.Columns["clmMismatchQty"]).MaxInputLength = 8; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefalutLocation()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    varLocationID = "0"; varRackID = "0"; varLocationName = ""; varRack = "";
                    if (lblProductcode.Text != "0" && lblProductcode.Text != "-1")
                    {
                        DataSet ObjsLocation = new DataSet();
                        SPDataService objDserv = new SPDataService();
                        ObjsLocation = objDserv.udfnStockLocationList(25, 0, 0, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0, 0, 0, "", "", 0);
                        objDserv.CloseConnection();
                        if (ObjsLocation != null)
                        {
                            if (ObjsLocation.Tables.Count > 0)
                            {
                                if (ObjsLocation.Tables[0].Rows.Count > 0)
                                {
                                    varLocationID = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SLID"]);
                                    varLocationName = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SL_EName"]);
                                    varRackID = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RKID"]);
                                    if (Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RK_ShortName"]) != "")
                                    {
                                        varRack = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RK_ShortName"]);
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(ObjsLocation.Tables[0].Rows[0]["RackCount"]) == 0)
                                        {
                                            varRack = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RKNAME"]);
                                            varRackID = "0";
                                            varRack = "None";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                varLocationID = "0"; varRackID = "0"; varLocationName = ""; varRack = "";
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
        private void GrdGrnlist_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {   /*
                varErrorFormat = 0;
                if (skipValidation == false)
                {
                    if (grdGrnlist.Columns[e.ColumnIndex].Name == "clmexpirydate")
                    {
                        if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmexpirydate"].Value) != "")
                        {
                            string dateString = varTempExpiryDate;
                            if (dateString.Length != 10 && dateString != "")
                            {
                                varErrorFormat = 1;
                                MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                e.Cancel = true;
                            }
                            else
                            {
                                if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmShelflifeenable"].Value) == "1" || dateString != "")
                                {
                                    varExpiryDate = "";
                                    DataSet objDS = new DataSet();
                                    SPDataService objDServ = new SPDataService();
                                    objDS = objDServ.udfnMaster(8, 0, 0, dateString, "", 0, "", 0);
                                    objDServ.CloseConnection();
                                    if (objDS.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(objDS.Tables[0].Rows[0]["DATE"]) == "0")
                                        {
                                            varErrorFormat = 1;
                                            MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            e.Cancel = true;
                                        }
                                        else
                                        {
                                            varExpiryDate = e.FormattedValue.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                */
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDate.Text.Length == 2)
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

        private void TxtMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMonth.Text.Length == 2)
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

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListviewProduct();
                btnConditions.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (-1))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewProduct();
                                    btnConditions.Focus();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnConditions.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMismatchQty.Text.Trim() == "")
                {
                    errGRNDetails.SetError(txtMismatchQty, "Please enter quantity");
                    txtMismatchQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoiceQty.ShowAlways = true;
                    tpInvoiceQty.Show("Please enter quantity", txtMismatchQty, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtMismatchQty.Text).Trim(), varDecimal);
                    //if (txtInvoiceQty.Text.Trim() == "0" || txtInvoiceQty.Text.Trim() == "00" || txtInvoiceQty.Text.Trim() == "000")
                    //{
                    //    txtInvoiceQty.Text = "0" + Qty;
                    //}
                    //else
                    //{
                    //    txtInvoiceQty.Text = Qty;
                    //}
                    txtMismatchQty.Text = Qty;
                    errGRNDetails.Clear();
                    txtMismatchQty.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdReurnDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Remaining = 0;
                if (e.RowIndex != -1)
                {
                    switch (grdReurnDC.Columns[e.ColumnIndex].Name)
                    {
                        case "clmDCRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdReurnDC.Rows.RemoveAt(this.grdReurnDC.SelectedCells[0].RowIndex);
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

        private void btnConditionClose_Click(object sender, EventArgs e)
        {
            try
            {
                pnlConditions.Visible = false;
                txtMismatchQty.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditions_Enter(object sender, EventArgs e)
        {
            try
            {
                btnConditions.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditions_Leave(object sender, EventArgs e)
        {
            try
            {
                btnConditions.BackColor = Color.Transparent; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPnlConditionVisible()
        {
            try
            {
                pnlConditions.Visible = true;
                grdConditions.Focus();
                grdConditions.CurrentCell = grdConditions.Rows[0].Cells[0];
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditions_Click(object sender, EventArgs e)
        {
            udfnPnlConditionVisible();
        }

        private void cmbReason_Enter(object sender, EventArgs e)
        {
            try
            {
                pnlConditions.Visible = false;
                cmbReason.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbReason_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                    if (txtmrprate.Enabled == true)
                    { txtmrprate.Focus();
                    }
                    else if (txtDate.Enabled == true)
                    {
                        txtDate.Focus();
                    }
                    else if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbReason_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbReason_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReason.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                udfnConditionApply();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdConditions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var gridRow = grdConditions.Rows[e.RowIndex];
                var dataTable = grdConditions.DataSource as DataTable;
                if (dataTable == null) return;
                bool isChecked = Convert.ToBoolean(gridRow.Cells["clmCheck"].Value);
                int conditionId = Convert.ToInt32(gridRow.Cells["ConditionID"].Value);
                if (conditionId == 275 || conditionId == 280 || conditionId == 281)
                {
                    if (isChecked)
                    { 
                        foreach (DataGridViewRow row in grdConditions.Rows)
                        {
                            bool isNoissue = Convert.ToString(row.Cells["ConditionID"].Value) == Convert.ToString(conditionId);
                            row.ReadOnly = !isNoissue;
                            if (!isNoissue)
                                row.Cells["clmCheck"].Value = false;
                        }
                        pbConditionIDs = Convert.ToString(conditionId);
                    } 
                    else
                    {
                        foreach (DataGridViewRow row in grdConditions.Rows)
                        {
                            row.ReadOnly = false;
                        }
                        pbConditionIDs = "";
                    }
                }
            
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void grdConditions_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdConditions.CurrentCell is DataGridViewCheckBoxCell)
                {
                    grdConditions.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditionClear_Click(object sender, EventArgs e)
        {
            try
            {
                udfnConditionClear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnConditionClear()
        {
            try
            {
                foreach (DataGridViewRow row in grdConditions.Rows)
                {
                    row.Cells["clmCheck"].Value = false;
                    row.Cells["clmCheck"].ReadOnly = false;
                }
                if (pnlConditions.Visible == true)
                {
                    grdConditions.CurrentCell = grdConditions.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnApply_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    udfnConditionApply();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdConditions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if we're at the last row 
                bool isLastRow = e.RowIndex == grdConditions.Rows.Count - 1;
                if (isLastRow)
                { 
                    btnApply.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnApply_Enter(object sender, EventArgs e)
        {
            try
            {
                btnApply.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnApply_Leave(object sender, EventArgs e)
        {
            try
            {
                btnApply.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditionClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnConditionClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditionClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnConditionClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditionClear_Enter(object sender, EventArgs e)
        {
            try
            {
                btnConditionClear.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditionClear_Leave(object sender, EventArgs e)
        {
            try
            {
                btnConditionClear.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditionClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    pnlConditions.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditionClear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnConditionClear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnConditionApply()
        {
            try
            {
                pbCondition = "";pbConditionIDs = ""; 
                var result = (grdConditions.DataSource as DataTable).AsEnumerable()
                          .Where(r => Convert.ToBoolean(r["clmCheck"]))  // Filter where clmCheck is true
                          .Select(r => new
                          {
                              ConditionId = r["ConditionID"],     
                              ConditionName = r["ConditionShortName"]   
                          })
                          .ToList();
                if (result.Count != 0)
                {
                    pbConditionIDs = string.Join(",", result.Select(r => r.ConditionId.ToString()));
                    pbCondition = string.Join(",", result.Select(r => r.ConditionName));
                    if (pbConditionIDs == "275" || pbConditionIDs == "280" || pbConditionIDs == "281")
                    {  
                        cmbReason.Enabled = false; cmbReason.SelectedValue = 286; 
                        txtInvoiceamt.Enabled = false; txtInvoiceamt.ReadOnly = true; 
                        txtMismatchQty.Enabled = false; txtMismatchQty.ReadOnly = true;
                    }
                    else
                    {   
                        cmbReason.Enabled = true; cmbReason.SelectedValue = 286;
                        txtInvoiceamt.Enabled = true; txtInvoiceamt.ReadOnly = false;
                        txtMismatchQty.Enabled = true; txtMismatchQty.ReadOnly = false;
                    }
                    pnlConditions.Visible = false;
                    txtMismatchQty.Focus();
                }
                else
                {
                    MessageBox.Show("Please select atleast one condition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditions_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPnlConditionVisible();
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void TxtInvoiceQty_Enter(object sender, EventArgs e)
        {
            try
            {
                pnlConditions.Visible = false;
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                txtMismatchQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnVerified_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRN_Level_Verified = new PUR_GRN_Level_Verified();
                MainForm.objPUR_GRN_Level_Verified.pbGRNId = pbGRNId;
                MainForm.objPUR_GRN_Level_Verified.pbGRNDate = dpGrnDate.Text;
                MainForm.objPUR_GRN_Level_Verified.ShowDialog();
                btnSave.Focus();
                if (PbVerified == 1)
                {
                    udfnVerifiedBy();
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbQtyType_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                btnConditions.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbQtyType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtMismatchQty.Enabled)
                    {
                        txtMismatchQty.Focus();
                    }
                    else if (txtmrprate.Enabled == true)
                    {
                        txtmrprate.Focus();
                    }
                    else if (txtDate.Enabled == true)
                    {
                        txtDate.Focus();
                    }
                    else if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbQtyType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbQtyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt32(cmbQtyType.SelectedValue) != 202) //no difference
                //{
                //        txtInvoiceQty.Enabled = true; txtInvoiceQty.ReadOnly = false; txtInvoiceQty.Text = "";
                //}
                //else
                //{
                //    txtInvoiceQty.Enabled = false; txtInvoiceQty.ReadOnly = true;
                //    txtInvoiceQty.Text = "";
                //}
                if ( Convert.ToString(cmbProType.SelectedValue) == "215")
                {
                    txtmrprate.Text = ""; //txtmrprate.Enabled = false; txtmrprate.ReadOnly = true;
                    txtBatchno.Text = ""; //txtBatchno.Enabled = false; txtBatchno.ReadOnly = true;
                    txtMonth.Text = ""; //txtMonth.Enabled = false; //txtMonth.ReadOnly = true;
                    txtDate.Text = ""; //txtDate.Enabled = false; txtDate.ReadOnly = true;
                    txtYear.Text = ""; //txtYear.Enabled = false; txtYear.ReadOnly = true;
                }
                else
                {
                    if (varShelflife == 1)
                    {
                        expirydateFlag = 1;
                        txtDate.ReadOnly = false;
                        txtMonth.ReadOnly = false;
                        txtYear.ReadOnly = false;
                        txtDate.Enabled = true;
                        txtMonth.Enabled = true;
                        txtYear.Enabled = true;
                    }
                    else
                    {
                        expirydateFlag = 0;
                        txtDate.ReadOnly = true;
                        txtMonth.ReadOnly = true;
                        txtYear.ReadOnly = true;
                        txtDate.Enabled = false;
                        txtMonth.Enabled = false;
                        txtYear.Enabled = false;
                        varDateEnable = 1;
                    }
                    if (varMRPFlag == 1)
                    {
                        varMRPEditflag = 1;
                        txtmrprate.ReadOnly = false;
                        txtmrprate.Enabled = true;
                    }
                    else
                    {
                        varMRPEditflag = 0;
                        txtmrprate.ReadOnly = true;
                        txtmrprate.Enabled = false;
                    }

                    if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                    {
                        txtBatchno.Text = "";
                        txtBatchno.Enabled = false;
                        //  txtBatchNo.ReadOnly = true;
                    }
                    else if (Convert.ToInt32(varBatchNo) == 72) //enabled
                    {
                        if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                        {
                            txtBatchno.Enabled = true;
                            txtBatchno.BackColor = Color.White;
                        }
                        else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                        {
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 14;
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(objMR_Master);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtBatchno.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                    txtBatchno.Enabled = false;
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(varPrcategory) == 16)
                    {
                        if (Convert.ToInt32(varRMProduction) == 1)
                        {
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 15;
                            objMR_Master.paraDate = dpGrnDate.Text;
                            objMR_Master.paraProductId = Convert.ToInt32(lblProductcode.Text.Trim());
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(objMR_Master);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtDate.Text = objDs.Tables[0].Rows[0][0].ToString();
                                    txtMonth.Text = objDs.Tables[0].Rows[1][0].ToString();
                                    txtYear.Text = objDs.Tables[0].Rows[2][0].ToString();
                                }
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

        private void CmbPayment_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPayment.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPayment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbProType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnlist_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceQty")
                //{
                //    if (Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmInvoiceQty"].Value) == 0)
                //    {
                //        grdGrnlist.CurrentRow.Cells["clmExcessQty"].ReadOnly = false;
                //        grdGrnlist.CurrentRow.Cells["clmExcessQty"].Style.BackColor = Color.PaleGreen;
                //    }
                //    else
                //    {
                //        grdGrnlist.CurrentRow.Cells["clmExcessQty"].ReadOnly = true;
                //        grdGrnlist.CurrentRow.Cells["clmExcessQty"].Style.BackColor = Color.LightGray;
                //    }
                //}
                //if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmExcessQty")
                //{
                //    if (Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmExcessQty"].Value) == 0)
                //    {
                //        grdGrnlist.CurrentRow.Cells["clmInvoiceQty"].ReadOnly = false;
                //        grdGrnlist.CurrentRow.Cells["clmInvoiceQty"].Style.BackColor = Color.PaleGreen;
                //    }
                //    else
                //    {
                //        grdGrnlist.CurrentRow.Cells["clmInvoiceQty"].ReadOnly = true;
                //        grdGrnlist.CurrentRow.Cells["clmInvoiceQty"].Style.BackColor = Color.LightGray;
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbPO_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(lblRemainProduct.Text) != "0")
                {
                    string PRID = "0";
                    var strings1 = varProductsIDs.Select(xx => xx);
                    PRID = (string.Join(",", strings1));
                    if (PRID == "")
                    {
                        PRID = "0";
                    }
                    MainForm.objPO_Details = new PO_Details();
                    MainForm.objPO_Details.PbvarGRNID = pbGRNId;
                    MainForm.objPO_Details.varProducts = PRID;
                    MainForm.objPO_Details.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnlist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.F10)
                //{
                //    if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmpicode" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmtam")
                //    {
                //        varEditPRID = Convert.ToString(grdGrnlist.CurrentRow.Cells["clmProid"].Value);
                //        varAutocompleteProduct = 2;
                //        udfnProDataChange();
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPayment_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPayment_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPayment.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnVerifiedBy()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objdserv.udfnGrnListLoad(8, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0, 0, "0", "","", 0, 0, 0, 0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            lblVerifiedBy1.Visible = true;
                            lblVerifiedDate1.Visible = true;
                            lblVerifiedBy1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["EMP_Name"]);
                            lblVerifiedDate1.Text = " @ " + Convert.ToString(objDs.Tables[0].Rows[0]["GRN_VerifiedOn1"]);
                        }
                    }
                    else
                    {
                        lblVerifiedBy1.Visible = true;
                        lblVerifiedDate1.Visible = true;
                        lblVerifiedBy1.Text = "";
                        lblVerifiedDate1.Text = "";
                    }
                    if (objDs.Tables[1].Rows.Count != 0)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            lblVerifiedBy2.Visible = true;
                            lblVerifiedDate2.Visible = true;
                            lblVerifiedBy2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["EMP_Name"]);
                            lblVerifiedDate2.Text = " @ " + Convert.ToString(objDs.Tables[1].Rows[0]["GRN_VerifiedOn2"]);
                        }
                    }
                    else
                    {
                        lblVerifiedBy2.Visible = true;
                        lblVerifiedDate2.Visible = true;
                        lblVerifiedBy2.Text = "";
                        lblVerifiedDate2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtInvoiceQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(cmbReason.Enabled==true)
                    {
                        cmbReason.Focus();
                    }
                    else if (txtmrprate.Enabled == true)
                    {
                        txtmrprate.Focus();
                    }
                    else if (txtDate.Enabled == true)
                    {
                        txtDate.Focus();
                    }
                    else if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtInvoiceQty_KeyPress(object sender, KeyPressEventArgs e)
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

                TextBox textBox = (TextBox)sender;
                if (varDecimal == 0)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                    {
                        e.Handled = true;
                    }
                }
                if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = false;
                }
                if (varDecimal == 0)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
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
        private void CmbPONo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbProType.SelectedValue) == 0)
                {
                    BtnNew.Enabled = true;
                }
                else
                {
                    BtnNew.Enabled = false;
                }
                if (Convert.ToInt32(cmbProType.SelectedValue) != varpono) //clear row details if the product typr changed 
                {
                    errGRNDetails.Clear();
                    cmbProType.BackColor = Color.White;
                    txtProductName.Text = "";
                    lblProductcode.Text = "0";
                    txtmrprate.Text = "";
                    txtDate.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtBatchno.Text = "";
                    txtProductName.BackColor = Color.White;
                    txtmrprate.BackColor = Color.White;
                    txtDate.BackColor = Color.White;
                    txtMonth.BackColor = Color.White;
                    txtYear.BackColor = Color.White;
                    txtBatchno.BackColor = Color.White;
                }
                varpono = Convert.ToInt32(cmbProType.SelectedValue); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdPODetails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPODetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmpono":
                            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                            {
                                string cellPOValue = Convert.ToString(grdPODetails.Rows[e.RowIndex].Cells["clmpendpoid"].Value);
                                MainForm.objPUR_POProducts = new PUR_POProducts();
                                MainForm.objPUR_POProducts.pbPoid = cellPOValue;
                                MainForm.objPUR_POProducts.pbSupplierCode = lblSupplierCode.Text;
                                MainForm.objPUR_POProducts.pbScheduleCode = lblschedule.Text;
                                MainForm.objPUR_POProducts.ShowDialog();
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
        private void GrdReurnDC_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdReurnDC.Columns[e.ColumnIndex].Name)
                    {
                        case "InvoiceNo":
                            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                            {
                                string cellPOValue = Convert.ToString(grdReurnDC.Rows[e.RowIndex].Cells["ID"].Value);
                                MainForm.objPUR_PurchaseOrderDamage = new PUR_PurchaseOrderDamage();
                                MainForm.objPUR_PurchaseOrderDamage.varMasterType = "3";
                                MainForm.objPUR_PurchaseOrderDamage.varDcCode = Convert.ToString(cellPOValue);
                                MainForm.objPUR_PurchaseOrderDamage.ShowDialog();
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
        private void GrdGrnlist_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmBatchno" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmmrp" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate" )
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmMismatchQty" ||  grdGrnlist.CurrentCell.OwningColumn.Name == "clmmrp" )
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmMismatchQty" ||  grdGrnlist.CurrentCell.OwningColumn.Name == "clmmrp"  )
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                    {
                        e.Handled = true;
                    }
                    //only allow one decimal point
                    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmmrp" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceMRP")
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
                    TextBox vartb = sender as TextBox;
                    //if (e.KeyChar == '.' && vartb.Text.Contains('.'))
                    //{
                    //    e.Handled = true;
                    //}
                    if (vartb.Text.Length >= 7 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmBatchno" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceBatch")
                {
                    TextBox vartb = sender as TextBox;
                    if (vartb.Text.Length >= 10 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceExpiry")
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
                    {
                        e.Handled = true;  // Disallow the character
                    }
                    TextBox vartb = sender as TextBox;
                    if (vartb.Text.Length >= 10 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmMismatchQty"   )
                { 
                    TextBox textBox = (TextBox)sender;
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                        {
                            e.Handled = true;
                        }
                    }
                    if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
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
        private void GrdGrnlist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                {
                    varLPFlag = 0;
                    var conditionSet = new HashSet<string>(pbConditionIDs.Split(','));
                    if (conditionSet.Contains("281") == true) //Line item pending
                    { varLPFlag = 1; }

                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchenable"].Value) == "72" && Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchgeneration"].Value) == "74")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                        DataGridView dataGridView1 = (DataGridView)sender;
                        DataGridViewCell cell1 = dataGridView.Rows[i].Cells["clmInvoiceBatch"];
                        cell1.Style.BackColor = Color.LightGray;
                        cell1.Style.ForeColor = Color.Black;
                        cell1.ReadOnly = true;
                        if (varLPFlag == 1)
                        {
                            cell.ReadOnly = false; cell1.ReadOnly = false;
                            cell.Style.BackColor = Color.LightGreen;
                            cell1.Style.BackColor = Color.PaleGreen;
                        }
                    }
                    else if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchenable"].Value) == "73")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                        DataGridView dataGridView1 = (DataGridView)sender;
                        DataGridViewCell cell1 = dataGridView.Rows[i].Cells["clmInvoiceBatch"];
                        cell1.Style.BackColor = Color.LightGray;
                        cell1.Style.ForeColor = Color.Black;
                        cell1.ReadOnly = true;
                    }
                    else
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.PaleGreen;
                        cell.Style.ForeColor = Color.Black;
                        DataGridView dataGridView1 = (DataGridView)sender;
                        DataGridViewCell cell1 = dataGridView.Rows[i].Cells["clmInvoiceBatch"];
                        cell1.Style.BackColor = Color.PaleGreen;
                        cell1.Style.ForeColor = Color.Black;
                        cell1.ReadOnly = true;
                    }
                    string[] varShelflifevalue = Convert.ToString(grdGrnlist.Rows[i].Cells["clmshelfper"].Value).Split(' ');
                    if (varShelflifevalue[0] != "")
                    {
                        //Shelflife Wise Color Set
                        if (Convert.ToDecimal(varShelflifevalue[0]) <= (MainForm.pbShelflifeLevel1))
                        {
                            DataGridView dataGridView = grdGrnlist;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.Red;
                            cell.Style.ForeColor = Color.White;
                        }
                        else if (Convert.ToDecimal(varShelflifevalue[0]) > (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifevalue[0]) < (MainForm.pbShelflifeLevel2))
                        {
                            DataGridView dataGridView = grdGrnlist;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.Orange;
                            cell.Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            DataGridView dataGridView = grdGrnlist;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.White;
                            cell.Style.ForeColor = Color.Black;
                        }
                    }
                    if (varLPFlag == 1 && Convert.ToString(grdGrnlist.Rows[i].Cells["clmPOID"].Value) == "215")
                    {
                        grdGrnlist.Rows[i].Cells["clmMismatchQty"].ReadOnly = true;
                        grdGrnlist.Rows[i].Cells["clmBatchno"].ReadOnly = true;
                        grdGrnlist.Rows[i].Cells["clmInvoiceBatch"].ReadOnly = true;
                        grdGrnlist.Rows[i].Cells["clmmrp"].ReadOnly = true;
                        grdGrnlist.Rows[i].Cells["clmInvoiceMRP"].ReadOnly = true;
                        grdGrnlist.Rows[i].Cells["clmexpirydate"].ReadOnly = true;
                        grdGrnlist.Rows[i].Cells["clmInvoiceExpiry"].ReadOnly = true;
                        grdGrnlist.Rows[i].Cells["clmexpirydate"].Value = "";
                        grdGrnlist.Rows[i].Cells["clmInvoiceExpiry"].Value = "";

                        grdGrnlist.Rows[i].Cells["clmMismatchQty"].Style.BackColor = Color.LightGray;
                        grdGrnlist.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                        grdGrnlist.Rows[i].Cells["clmInvoiceBatch"].Style.BackColor = Color.LightGray;
                        grdGrnlist.Rows[i].Cells["clmmrp"].Style.BackColor = Color.LightGray;
                        grdGrnlist.Rows[i].Cells["clmInvoiceMRP"].Style.BackColor = Color.LightGray;
                        grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                        grdGrnlist.Rows[i].Cells["clmInvoiceExpiry"].Style.BackColor = Color.LightGray;
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
                varLPFlag = 0; //For reset purpose
            }
        }
        private void TxtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text.Length == 2)
                {
                    if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtInvoiceno_Leave(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceno.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtInvoiceno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceamt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdGrnlist_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string varshelflife = "";
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                int varCellprodid = 0;
                if(grdGrnlist.Columns[e.ColumnIndex].Name == "clmexpirydate")
                {
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmexpirydate"].Value) != "")
                    {
                        varCellprodid = Convert.ToInt32(grdGrnlist.Rows[e.RowIndex].Cells["clmProid"].Value);
                        if (rowIndex >= 0 && columnIndex >= 0)
                        {
                            string varTempYear = "0", varTempMonth = "0", varTempDay = "0";
                            object cellValue = grdGrnlist.Rows[rowIndex].Cells[columnIndex].Value;
                            string varExpiryDate = "";
                            varExpiryDate = cellValue.ToString();
                            string[] DMY = varExpiryDate.Split('/');
                            if (DMY.Count() == 2 || DMY.Count() == 3 && DMY[0] == "")
                            {
                                string varDate = "";
                                if (DMY[0] == "")
                                {
                                    varDate = "01" + "/" + DMY[1] + "/" + "20" + DMY[2];
                                }
                                else
                                {
                                    varDate = "01" + "/" + DMY[0] + "/" + "20" + DMY[1];
                                }
                                DataSet objDSer = new DataSet();
                                MR_Master objMR_Master = new MR_Master();
                                objMR_Master.ViewType = 5;
                                objMR_Master.paraDate = varDate;
                                SPDataService objdServ = new SPDataService();
                                objDSer = objdServ.udfnMaster(objMR_Master);
                                objdServ.CloseConnection();
                                if (objDSer.Tables[0].Rows.Count > 0)
                                {
                                    varTempExpiryDate = objDSer.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();

                                    cellValue = varTempExpiryDate;
                                }
                            }
                            else if (DMY.Count() == 3)
                            {
                                varTempDay = DMY[0];
                                varTempMonth = DMY[1];
                                varTempYear = DMY[2];
                                if (varTempDay.Length == 1)
                                {
                                    varTempDay = "0" + DMY[0];
                                }
                                if (varTempMonth.Length == 1)
                                {
                                    varTempMonth = "0" + DMY[1];
                                }
                                if (varTempYear.Length == 2)
                                {
                                    varTempYear = "20" + DMY[2];
                                }
                                cellValue = varTempDay + "/" + varTempMonth + "/" + varTempYear;
                            }
                            varTempExpiryDate = cellValue.ToString();
                            if (cellValue != null && Convert.ToString(cellValue) != "")
                            {
                                varshelflife = cellValue.ToString();
                                if (varshelflife != "" || varshelflife != null)
                                   
                                    objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, dpGrnDate.Text, varCellprodid, 0, "0", "","", 0, 0, 0, 0);
                                objdserv.CloseConnection();
                                if (objDs != null)
                                {
                                    if (objDs.Tables[0].Rows.Count != 0)
                                    {
                                        if (objDs.Tables[0].Rows.Count > 0)
                                        {
                                            grdGrnlist.Rows[rowIndex].Cells["clmshelfper"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
                                        }
                                    }
                                    if (objDs.Tables[1].Rows.Count != 0)
                                    {
                                        if (objDs.Tables[1].Rows.Count > 0)
                                        {
                                            grdGrnlist.Rows[rowIndex].Cells["clmactuallife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
                                        }
                                    }
                                    string[] varShelflifevalue = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]).Split(' ');
                                    if (varShelflifevalue[0] != "")
                                    {
                                        //Shelflife Wise Color Set
                                        if (Convert.ToDecimal(varShelflifevalue[0]) <= (MainForm.pbShelflifeLevel1))
                                        {
                                            DataGridView dataGridView = grdGrnlist;
                                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                            cell.Style.BackColor = Color.Red;
                                            cell.Style.ForeColor = Color.White;
                                        }
                                        else if (Convert.ToDecimal(varShelflifevalue[0]) > (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifevalue[0]) < (MainForm.pbShelflifeLevel2))
                                        {
                                            DataGridView dataGridView = grdGrnlist;
                                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                            cell.Style.BackColor = Color.Orange;
                                            cell.Style.ForeColor = Color.Black;
                                        }
                                        else
                                        {
                                            DataGridView dataGridView = grdGrnlist;
                                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                            cell.Style.BackColor = Color.White;
                                            cell.Style.ForeColor = Color.Black;
                                        }
                                    }
                                }
                            }
                        }
                        grdGrnlist.Rows[e.RowIndex].Cells["clmexpirydate"].Value = varTempExpiryDate;
                        udfnGridaddvalue(sender, e);
                    }
                    else
                    {
                        grdGrnlist.Rows[rowIndex].Cells["clmactuallife"].Value = "";
                        DataGridView dataGridView = grdGrnlist;
                        DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                        cell.Style.BackColor = Color.White;
                        cell.Style.ForeColor = Color.Black;
                    }
                }
                if (grdGrnlist.Columns[e.ColumnIndex].Name == "clmInvoiceExpiry")
                {

                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmInvoiceExpiry"].Value) != "")
                    {
                        varCellprodid = Convert.ToInt32(grdGrnlist.Rows[e.RowIndex].Cells["clmProid"].Value);
                        if (rowIndex >= 0 && columnIndex >= 0)
                        {
                            string varInvoiceYear = "0", varInvoiceMonth = "0", varInvoiceDay = "0";
                            object cellInvoiceValue = grdGrnlist.Rows[rowIndex].Cells[columnIndex].Value;
                            string varInvoiceExp = "";
                            varInvoiceExp = cellInvoiceValue.ToString();
                            string[] DMY = varInvoiceExp.Split('/');
                            if (DMY.Count() == 2 || DMY.Count() == 3 && DMY[0] == "")
                            {
                                string varDate = "";
                                if (DMY[0] == "")
                                {
                                    varDate = "01" + "/" + DMY[1] + "/" + "20" + DMY[2];
                                }
                                else
                                {
                                    varDate = "01" + "/" + DMY[0] + "/" + "20" + DMY[1];
                                }
                                DataSet objDSer = new DataSet();
                                MR_Master objMR_Master = new MR_Master();
                                objMR_Master.ViewType = 5;
                                objMR_Master.paraDate = varDate;
                                SPDataService objdServ = new SPDataService();
                                objDSer = objdServ.udfnMaster(objMR_Master);
                                objdServ.CloseConnection();
                                if (objDSer.Tables[0].Rows.Count > 0)
                                {
                                    varInvoiceExpiryDate = objDSer.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();

                                    cellInvoiceValue = varInvoiceExpiryDate;
                                }
                            }
                            else if (DMY.Count() == 3)
                            {
                                varInvoiceDay = DMY[0];
                                varInvoiceMonth = DMY[1];
                                varInvoiceYear = DMY[2];
                                if (varInvoiceDay.Length == 1)
                                {
                                    varInvoiceDay = "0" + DMY[0];
                                }
                                if (varInvoiceMonth.Length == 1)
                                {
                                    varInvoiceMonth = "0" + DMY[1];
                                }
                                if (varInvoiceYear.Length == 2)
                                {
                                    varInvoiceYear = "20" + DMY[2];
                                }
                                cellInvoiceValue = varInvoiceDay + "/" + varInvoiceMonth + "/" + varInvoiceYear;
                            }
                            varInvoiceExpiryDate = cellInvoiceValue.ToString();
                        }
                        grdGrnlist.Rows[e.RowIndex].Cells["clmInvoiceExpiry"].Value = varInvoiceExpiryDate;
                        udfnGridaddvalue(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdGrnlist_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdGrnlist.IsCurrentCellDirty)
                {
                    grdGrnlist.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPONo_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPONo_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPONo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdGrnlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Remaining = 0;
                if (e.RowIndex != -1)
                {
                    switch (grdGrnlist.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                string varPRID = Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmProid"].Value);
                                string varSno = Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmsno"].Value);
                                varModifiedFlag = 1;

                                if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmPOID"].Value) == "215") //po
                                {
                                    int varProductType = Convert.ToInt16(grdGrnlist.Rows[e.RowIndex].Cells["clmPOID"].Value);

                                    var varRemoveProuct = from r in dtPurchaseAutoComplete.AsEnumerable()
                                                          where (r.Field<string>("PRID").Equals(varPRID) && r.Field<int>("Flag").Equals(varProductType))
                                                          group r by r.Field<int>("Sno") into g
                                                          select g.Key;
                                    if (varRemoveProuct.Count() == 1)
                                    {
                                        lblRemainProduct.Text = Convert.ToString((Convert.ToInt16(lblRemainProduct.Text) + 1));
                                        lblAddProduct.Text = Convert.ToString(Convert.ToInt16(lbltotProduct.Text) - Convert.ToInt16(lblRemainProduct.Text));
                                    }
                                }
                                for (int i = 0; i < varProductsIDs.Count; i++)
                                {
                                    if (varProductsIDs[i].Equals(Convert.ToInt16(varPRID)))
                                    { varProductsIDs.RemoveAt(i); goto L; }
                                }
                                 L: for (int i = 0; i < dtPurchaseAutoComplete.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dtPurchaseAutoComplete.Rows[i]["Sno"]) == Convert.ToString(varSno))
                                    {
                                        dtPurchaseAutoComplete.Rows[i].Delete();
                                        dtPurchaseAutoComplete.AcceptChanges();
                                    }
                                }
                                grdGrnlist.Rows.RemoveAt(this.grdGrnlist.SelectedCells[0].RowIndex);
                                txtTotalpro.Text = Convert.ToString(grdGrnlist.Rows.Count);
                                //for (int i = 0; i < varProductsIDs.Count; i++)
                                //{
                                //    if (varProductsIDs[i].Equals(varPRID)) { varProductsIDs.RemoveAt(i); goto L; }
                                //}
                                //L:
                                ////for (int i = 0; i < grdGrnlist.RowCount; i++)
                                ////{
                                ////    grdGrnlist.Rows[i].Cells["clmsno"].Value = i + 1;
                                ////} 
                                //lblAddProduct.Text = Convert.ToString(grdGrnlist.Rows.Count);
                                //Remaining = Convert.ToInt32(lbltotProduct.Text) - Convert.ToInt32(lblAddProduct.Text);
                                //lblRemainProduct.Text = Convert.ToString(Remaining);
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
            finally
            {
            }
        }
        private void GrdGrnlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (varErrorFormat == 0)
                {
                    //udfnGridaddvalue(sender, e);
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmmrp")
                {
                    decimal varMRP = Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmmrp"].Value);
                    string mrp = string.Format("{0:0.00}", varMRP);
                    string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                    grdGrnlist.Rows[e.RowIndex].Cells["clmmrp"].Value = mrp;
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceMRP")
                {
                    decimal varInvoiceMRP = Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmInvoiceMRP"].Value);
                    string mrp = string.Format("{0:0.00}", varInvoiceMRP);
                    string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                    grdGrnlist.Rows[e.RowIndex].Cells["clmInvoiceMRP"].Value = mrp;
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmMismatchQty")
                {
                    /*
                    decimal InvoiceQty = Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmInvoiceQty"].Value);
                    if (Convert.ToString(InvoiceQty) == "0" || Convert.ToString(InvoiceQty) == "")
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmInvoiceQty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrQty = "1";
                    }
                    else
                    {
                        grdGrnlist.CurrentRow.Cells["clmInvoiceQty"].Style.BackColor = Color.PaleGreen;
                        varErrQty = "0";
                    }
                    */
                    if (Convert.ToString(grdGrnlist.CurrentRow.Cells["clmMismatchQty"].Value) != "" && Convert.ToString(grdGrnlist.CurrentRow.Cells["clmMismatchQty"].Value) != "0")
                    {
                        int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);

                        string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmMismatchQty"].Value), varDecimal);
                        grdGrnlist.Rows[e.RowIndex].Cells["clmMismatchQty"].Value = Qty;
                    }
                    else
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmMismatchQty"].Value = "0";
                    }
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmExcessQty")
                {
                    if (Convert.ToString(grdGrnlist.CurrentRow.Cells["clmExcessQty"].Value) != "" && Convert.ToString(grdGrnlist.CurrentRow.Cells["clmExcessQty"].Value) != "0")
                    {
                        int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);

                        string ExcessQty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Value), varDecimal);
                        grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Value = ExcessQty;
                    }
                    else
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Value = "0";
                    }
                }
                    //udfnGridaddvalue( sender,value);
                
                /*
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmQtyType")
                {
                    decimal ExcessQty = Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmQtyType"].Value);
                    if (Convert.ToString(ExcessQty) == "0" || Convert.ToString(ExcessQty) == "")
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmQtyType"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrQty = "1";
                    }
                    else
                    {
                        grdGrnlist.CurrentRow.Cells["clmQtyType"].Style.BackColor = Color.PaleGreen;
                        varErrQty = "0";
                    }

                    int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmQtyType"].Value), varDecimal);
                    grdGrnlist.Rows[e.RowIndex].Cells["clmQtyType"].Value = Qty;
                    //udfnGridaddvalue( sender,value);
                }
                */
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate")
                {
                    int rowIndex = e.RowIndex, columnIndex = e.ColumnIndex, varProid = 0, PR_Shelflife = 0,Date=0;
                    
                    if(grdGrnlist.Rows.Count>0)
                    {
                        PR_Shelflife = Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmShelflifeenable"].Value);
                    }
                    if (PR_Shelflife == 1)
                    {
                        varTempExpiryDate = Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value);
                        if ((grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value != null && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value) != "0"))
                        {
                            DataSet objDSer = new DataSet();
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 8;
                            objMR_Master.paraDate = varTempExpiryDate;
                            SPDataService objdServ = new SPDataService();
                            objDSer = objdServ.udfnMaster(objMR_Master);
                            objdServ.CloseConnection();
                            if(objDSer != null)
                            {
                                if(objDSer.Tables[0].Rows.Count > 0)
                                {
                                    Date= Convert.ToInt32(objDSer.Tables[0].Rows[0]["Date"].ToString());
                                    if(Date == 0)
                                    {
                                        if (varTempExpiryDate!="" )
                                        {
                                            MessageBox.Show("Invalid date!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                        }
                                    }
                                    else
                                    {
                                        if (varErrorFormat != 5)
                                        {
                                            grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmQtyType"].Value) != "226")
                            {
                                MessageBox.Show("Please enter expirydate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                            }
                            else
                            {
                                if(varExpiryDate=="")
                                { grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen; }
                            }
                        }
                    }
                }

                string QtyType = Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmQtyType"].Value);
                if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmQtyType"].Value) == "")
                {
                    QtyType = "0";
                }
                if (varOrderType == 53 && QtyType == "0")
                {
                    if (Convert.ToDecimal(grdGrnlist.Rows[e.RowIndex].Cells["clmMismatchQty"].Value) == 0)
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].ReadOnly = false;
                        grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Style.BackColor = Color.PaleGreen;
                    }
                    else
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].ReadOnly = true;
                        grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Style.BackColor = Color.LightGray;
                    }


                    if (Convert.ToDecimal(grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Value) == 0)
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmMismatchQty"].ReadOnly = false;
                        grdGrnlist.Rows[e.RowIndex].Cells["clmMismatchQty"].Style.BackColor = Color.PaleGreen;
                    }
                    else
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmMismatchQty"].ReadOnly = true;
                        grdGrnlist.Rows[e.RowIndex].Cells["clmMismatchQty"].Style.BackColor = Color.LightGray;
                    }
                }
                if (Convert.ToDecimal(grdGrnlist.Rows[e.RowIndex].Cells["clmmrp"].Value) == 0 && Convert.ToInt32(grdGrnlist.Rows[e.RowIndex].Cells["clmMRPflag"].Value) == 1 && Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmQtyType"].Value) != "226")
                {
                    grdGrnlist.Rows[e.RowIndex].Cells["clmmrp"].Style.BackColor = Color.LightPink;
                }
                else if (Convert.ToDecimal(grdGrnlist.Rows[e.RowIndex].Cells["clmmrp"].Value) != 0 && Convert.ToInt32(grdGrnlist.Rows[e.RowIndex].Cells["clmMRPflag"].Value) == 1)
                {
                    grdGrnlist.Rows[e.RowIndex].Cells["clmmrp"].Style.BackColor = Color.PaleGreen;
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceMRP")
                {
                    decimal varInvoiceMRP = Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmInvoiceMRP"].Value);
                    string mrp = string.Format("{0:0.00}", varInvoiceMRP);
                    string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                    grdGrnlist.Rows[e.RowIndex].Cells["clmInvoiceMRP"].Value = mrp;
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceExpiry")
                {
                    int rowIndex = e.RowIndex, columnIndex = e.ColumnIndex, PR_Shelflife = 0, Date = 0;

                    if (grdGrnlist.Rows.Count > 0)
                    {
                        PR_Shelflife = Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmShelflifeenable"].Value);
                    }
                    if (PR_Shelflife == 1)
                    {
                        varInvoiceExpiryDate = Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Value);
                        if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmQtyType"].Value) != "226")
                        {
                            if (grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Value != null && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Value) != "0")
                            {
                                DataSet objDSer = new DataSet();
                                MR_Master objMR_Master = new MR_Master();
                                objMR_Master.ViewType = 8;
                                objMR_Master.paraDate = varInvoiceExpiryDate;
                                SPDataService objdServ = new SPDataService();
                                objDSer = objdServ.udfnMaster(objMR_Master);
                                objdServ.CloseConnection();
                                if (objDSer != null)
                                {
                                    if (objDSer.Tables[0].Rows.Count > 0)
                                    {
                                        Date = Convert.ToInt32(objDSer.Tables[0].Rows[0]["Date"].ToString());
                                        if (Date == 0)
                                        {
                                            MessageBox.Show("Invalid date!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Style.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            if (varErrorFormat != 5)
                                            {
                                                grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Style.BackColor = Color.PaleGreen;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter expirydate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Style.BackColor = Color.LightPink;
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
        public void udfnGridaddvalue(object sender, DataGridViewCellEventArgs value)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;
                varExpiryDate = "";
                varShelflife = 0;
                varErroronGrid = 0;
                int varExpiryDays = 0; int error = 0, rowIndex = value.RowIndex, columnIndex = value.ColumnIndex, varProid = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate")
                {
                    varExpiryDate = Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value);
                    string varTempYear = "0";
                    object cellValue = varExpiryDate;
                    string varExpDate = "";
                    varExpDate = cellValue.ToString();
                    string[] DMY = varExpDate.Split('/');
                    if (DMY.Count() == 3)
                    {
                        varTempYear = DMY[2];
                        if (varTempYear.Length == 2)
                        {
                            cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
                        }
                    }
                    //varTempDay = DMY[0];
                    //varTempMonth = DMY[1];
                    varTempExpiryDate = cellValue.ToString();
                }
                varProid = Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmProid"].Value);
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 10;
                objMR_Master.paraDate = dpGrnDate.Text.Trim();
                objMR_Master.ParaExpiryDate = varTempExpiryDate;
                objMR_Master.paraProductId = varProid;
                objDS = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                //for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                //{
                    varShelflife = Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmShelflifeenable"].Value);
                    pbDateflag = 0;
                    if (pbDateflag == 0)
                    {
                        if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate")
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                                {
                                    pbDateflag = 1; error = 1;
                                }
                                else
                                {
                                    if (objDS.Tables.Count != 0)
                                    {
                                        if (objDS.Tables[1].Rows.Count > 0)
                                        {
                                            varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                        }
                                    }
                                    if (varExpiryDays < 0)
                                    {
                                        pbDateflag = 1; error = 1;
                                    }
                                    else
                                    {
                                        if (varShelflife == 1)
                                        {
                                            if (objDS.Tables.Count > 1)
                                            {
                                                if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                                {
                                                    pbDateflag = 1;
                                                    if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                                                    {
                                                        varErrorFormat = 5;
                                                        grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                                        string varMessage = objDServ.udfnGetMessages(98);
                                                        objDServ.CloseConnection();
                                                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }
                                                }
                                                //else
                                                //{
                                                //    grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                                //}
                                            }
                                            else
                                            {
                                                pbDateflag = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (error == 1)
                        {   
                            if (varTempExpiryDate != "")
                            {
                                if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                                {
                                    varErroronGrid = 1;
                                    grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                    string varMessage = objDServ.udfnGetMessages(94);
                                    objDServ.CloseConnection();
                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            if (pbDateflag == 0)
                            {
                                //grdGrnlist.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmmrp"];
                                DataGridViewCell cell1 = dataGridView.Rows[rowIndex].Cells["clmexpirydate"];
                                DataGridViewCell cell2 = dataGridView.Rows[rowIndex].Cells["clmBatchno"];
                                DataGridViewCell cell3 = dataGridView.Rows[rowIndex].Cells["clmMismatchQty"];
                                DataGridViewCell cell4 = dataGridView.Rows[rowIndex].Cells["clmExcessQty"];
                                //cell.Style.BackColor = Color.PaleGreen;
                                //cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                //cell1.Style.BackColor = Color.PaleGreen;
                                //cell1.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                //cell2.Style.BackColor = Color.PaleGreen;
                                //cell2.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                //if (Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmQtyType"].Value) !=202)
                                //{
                                //    cell3.Style.BackColor = Color.PaleGreen;
                                //    cell3.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                //    cell4.Style.BackColor = Color.PaleGreen;
                                //    cell4.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                //}
                                if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmBatchenable"].Value) == "72" && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmBatchgeneration"].Value) == "74")
                                {
                                    cell2.Style.BackColor = Color.LightGray;
                                    cell2.Style.ForeColor = Color.Black;
                                    cell2.ReadOnly = true;
                                }
                                else if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmBatchenable"].Value) == "73")
                                {
                                    cell2.Style.BackColor = Color.LightGray;
                                    cell2.Style.ForeColor = Color.Black;
                                    cell2.ReadOnly = true;
                                }
                                //else
                                //{
                                //    cell2.Style.BackColor = Color.PaleGreen;
                                //    cell2.Style.ForeColor = Color.Black;
                                //}
                            }
                        }
                        if (pbDateflag == 0)
                        {
                            /*
                            //grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                            if (Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmsno"].Value) != Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmsno"].Value))
                            {
                                if (Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmProid"].Value) == Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmProid"].Value))
                                {
                                    string varMRP = Convert.ToString(grdGrnlist.Rows[i].Cells["clmmrp"].Value).Trim();
                                    string varNewExpiryDate = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value).Trim();
                                    string varBatch = Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value).Trim();
                                    string varPoid = Convert.ToString(grdGrnlist.Rows[i].Cells["clmPOid"].Value).Trim();
                                    if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value) == varNewExpiryDate && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmBatchno"].Value) == varBatch)
                                    {
                                        if (Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmPOid"].Value) == Convert.ToInt32(varPoid))
                                        {
                                            MessageBox.Show("Product already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            if (pbDateflag == 0)
                                            {
                                                grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                                DataGridViewCell cell = dataGridView.Rows[i].Cells["clmmrp"];
                                                DataGridViewCell cell1 = dataGridView.Rows[i].Cells["clmexpirydate"];
                                                DataGridViewCell cell2 = dataGridView.Rows[i].Cells["clmBatchno"];
                                                cell.Style.BackColor = Color.PaleGreen;
                                                cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                                cell1.Style.BackColor = Color.PaleGreen;
                                                cell1.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                                cell2.Style.BackColor = Color.PaleGreen;
                                                cell2.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                            }
                                        }
                                    }
                                }
                            }
                            */
                        }
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceExpiry")
                {
                    varInvExpiryDate = Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Value);
                    string varTempYear = "0";
                    object cellInvoiceValue = varInvExpiryDate;
                    string varExpDate = "";
                    varExpDate = cellInvoiceValue.ToString();
                    string[] DMY = varExpDate.Split('/');
                    if (DMY.Count() == 3)
                    {
                        varTempYear = DMY[2];
                        if (varTempYear.Length == 2)
                        {
                            cellInvoiceValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
                        }
                    }

                    varInvoiceExpiryDate = cellInvoiceValue.ToString();
                }
                objMR_Master.ViewType = 10;
                objMR_Master.paraDate = dpGrnDate.Text.Trim();
                objMR_Master.ParaExpiryDate = varInvoiceExpiryDate;
                objMR_Master.paraProductId = varProid;
                objDS = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                //for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                //{
                varShelflife = Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmShelflifeenable"].Value);
                pbDateflag = 0;
                if (pbDateflag == 0)
                {
                    if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceExpiry")
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                            {
                                pbDateflag = 1; error = 1;
                            }
                            else
                            {
                                if (objDS.Tables.Count != 0)
                                {
                                    if (objDS.Tables[1].Rows.Count > 0)
                                    {
                                        varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                    }
                                }
                                if (varExpiryDays < 0)
                                {
                                    pbDateflag = 1; error = 1;
                                }
                                else
                                {
                                    if (varShelflife == 1)
                                    {
                                        if (objDS.Tables.Count > 1)
                                        {
                                            if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                            {
                                                pbDateflag = 1;
                                                if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Value) == varInvoiceExpiryDate)
                                                {
                                                    varErrorFormat = 5;
                                                    grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Style.BackColor = Color.LightPink;
                                                    string varMessage = objDServ.udfnGetMessages(98);
                                                    objDServ.CloseConnection();
                                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                            //else
                                            //{
                                            //    grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Style.BackColor = Color.PaleGreen;
                                            //}
                                        }
                                        else
                                        {
                                            pbDateflag = 0;
                                        }
                                    }
                                }
                            }
                        }                   
                    if (error == 1)
                    {
                        if (varTempExpiryDate != "")
                        {
                            if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Value) == varInvoiceExpiryDate)
                            {
                                varErroronGrid = 1;
                                grdGrnlist.Rows[rowIndex].Cells["clmInvoiceExpiry"].Style.BackColor = Color.LightPink;
                                string varMessage = objDServ.udfnGetMessages(94);
                                objDServ.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        if (pbDateflag == 0)
                        {
                            //grdGrnlist.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmmrp"];
                            DataGridViewCell cell1 = dataGridView.Rows[rowIndex].Cells["clmInvoiceExpiry"];
                            DataGridViewCell cell2 = dataGridView.Rows[rowIndex].Cells["clmBatchno"];
                            DataGridViewCell cell3 = dataGridView.Rows[rowIndex].Cells["clmMismatchQty"];
                            DataGridViewCell cell4 = dataGridView.Rows[rowIndex].Cells["clmExcessQty"];
                            // Set the background color to the default background color
                            //cell1.Style.BackColor = Color.PaleGreen;
                            //cell1.Style.ForeColor = Color.Black;
                            if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmBatchenable"].Value) == "72" && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmBatchgeneration"].Value) == "74")
                            {
                                cell2.Style.BackColor = Color.LightGray;
                                cell2.Style.ForeColor = Color.Black;
                                cell2.ReadOnly = true;
                            }
                            else if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmBatchenable"].Value) == "73")
                            {
                                cell2.Style.BackColor = Color.LightGray;
                                cell2.Style.ForeColor = Color.Black;
                                cell2.ReadOnly = true;
                            }
                            //else
                            //{
                            //    cell2.Style.BackColor = Color.PaleGreen;
                            //    cell2.Style.ForeColor = Color.Black;
                            //}
                        }
                    }
                }
                    
                }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPONo_KeyPress(object sender, KeyPressEventArgs e)
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


        private void GrdPODetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdPODetails.Rows.Count; i++)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[i].Cells["clmpono"];
                    if (Convert.ToString(grdPODetails.Rows[i].Cells["clmsts"].Value) == "13")
                    {
                        cell.Style.BackColor = Color.RoyalBlue;
                        cell.Style.ForeColor = Color.White;
                    }
                    else
                    {
                        cell.Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        cell.Style.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPODetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PUR_GRNDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    BtnSave_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    if (pnlConditions.Visible == true)
                    { pnlConditions.Visible = false; }
                    else { udfnclose(sender, e); }
                }
                if (e.KeyCode == Keys.F1)
                {
                    if (pnlConditions.Visible == true)
                    {
                        btnApply_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnDamage_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamaged = new PUR_PODamaged();
                MainForm.objPUR_PODamaged.varMasterType = "3";
                MainForm.objPUR_PODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        public void udfnAddProductsgrid()
        {
            try
            {
                bool varErrorFlag = false; 
                varExpiryDate = ""; varExpiryDateAdd = ""; varPrid = "0";
                varExcessQuantity = 0; varMismatchQty = 0; varLPFlag = 0; varNoDiffFlag = 0;
                varPendingQty = 0;
                varDamageQty = 0; varExpDateValidFlag = 0; varProValidation=0; varReasonFlag = 0; 
                decimal varMRP = 0; string mrp = "", mrp1 = ""; var maxSno = 0; 
                var conditionSet = new HashSet<string>(pbConditionIDs.Split(',')); 
                if (conditionSet.Contains("281") == true) //Line item pending
                { varLPFlag = 1; }
                if (conditionSet.Contains("275") == true) //No difference
                { varNoDiffFlag = 1; }
                if(conditionSet.Contains("281") == true || conditionSet.Contains("280") == true || Convert.ToInt16(cmbReason.SelectedValue)==284)
                { varProValidation = 1; } //No need to validte product details
                if(expirydateFlag == 1 &&( txtDate.Text != "" || txtMonth.Text != "" || txtYear.Text != "") )  
                {  varExpDateValidFlag = 1; }
                if (conditionSet.Contains("281") == true || conditionSet.Contains("280") == true || conditionSet.Contains("275") == true)
                { varReasonFlag = 1; }  
                if (txtProductName.Text == "")
                {
                    errGRNDetails.SetError(txtProductName, "Please enter product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    varErrorFlag = true;
                } 
                if (varReasonFlag == 0)
                {
                    if(Convert.ToInt32(cmbReason.SelectedValue)== 286)
                    {
                        errGRNDetails.SetError(cmbReason, "Please select valid reason.");
                        cmbReason.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpReason.ShowAlways = true;
                        tpReason.Show("Please select valid reason.", txtProductName, 5000);
                        varErrorFlag = true;
                    }
                }
                if (varReasonFlag == 0 && txtMismatchQty.Text.Trim()=="")
                {
                    errGRNDetails.SetError(txtMismatchQty, "Please enter quantity");
                    txtMismatchQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoiceQty.ShowAlways = true;
                    tpInvoiceQty.Show("Please enter quantity", txtMismatchQty, 5000);
                    varErrorFlag = true;
                }
                if (varMRPFlag == 1 && (txtmrprate.Text == "" || Convert.ToDecimal(txtmrprate.Text) == 0) && varProValidation==0)
                {
                    errGRNDetails.SetError(txtmrprate, "Please enter MRP");
                    txtmrprate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tprate.ShowAlways = true;
                    tprate.Show("Please enter MRP.", txtmrprate, 5000);
                    varErrorFlag = true;
                }
                if (expirydateFlag == 1 &&  varProValidation==0)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtMonth, "Please enter month.");
                        varErrorFlag = true;
                    }
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtYear, "Please enter year.");
                        varErrorFlag = true;
                    }
                }
                if(varBatchNoGeneration == "75" && varProValidation == 0)
                {
                    if (txtBatchno.Text.Trim() == "")
                    {
                        txtBatchno.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtBatchno, "Please enter BatchNo.");
                        tpbatchno.ShowAlways = true;
                        tpbatchno.Show("Please enter Batch No.", txtBatchno, 5000);
                        varErrorFlag = true;
                    }
                }  
                if (varErrorFlag == false)
                {
                    int varflag = 0;
                    string varShelflifevalue = "", varAcutalshelflife = "";
                    lblNoRecordsFound.Visible = false; 
                    if(varExpDateValidFlag==1 && (txtDate.Text != "" || txtMonth.Text != "" || txtYear.Text != ""))
                    {
                        udfnDatevalidationset();
                    } 
                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    if (varExpiryDate != "" || varProValidation == 0)
                    {
                        MR_Master objMR_Master = new MR_Master();
                        objMR_Master.ViewType = 7;
                        objMR_Master.paraProductId = Convert.ToInt32(lblProductcode.Text);
                        objMR_Master.paraDate = dpGrnDate.Text;
                        objMR_Master.ParaExpiryDate = varExpiryDate;
                        objDS = objDServ.udfnMaster(objMR_Master);
                        objDServ.CloseConnection();
                        if (expirydateFlag == 1)
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(objDS.Tables[0].Rows[0]["DATEVALIDATE"]) == "0")
                                {
                                    errGRNDetails.SetError(txtDate, "Invalid expiry date");
                                    txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpProduct.ShowAlways = true;
                                    tpProduct.Show("Invalid expiry date", txtDate, 5000);
                                    varflag = 1;
                                }
                                else
                                {
                                    if (objDS.Tables[1].Rows.Count > 0)
                                    {
                                        varShelflifevalue = Convert.ToString(objDS.Tables[1].Rows[0]["SHELFLIFE"]);
                                    }
                                    if (objDS.Tables[2].Rows.Count > 0)
                                    {
                                        varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                                    }
                                }
                            }
                        } 
                    }
                    if(txtmrprate.Text.Trim()=="")
                    {
                        txtmrprate.Text = "0";
                    } 
                    if (Convert.ToInt32(lblSupplierCode.Text) != 0)
                    {
                        if (varflag == 0)
                        {
                            if (pbDateflag == 0)
                            {
                                errGRNDetails.Clear();
                                tpdate.Active = false;
                                txtDate.BackColor = Color.White;
                                txtMonth.BackColor = Color.White;
                                txtYear.BackColor = Color.White;
                                string[] varpono = cmbProType.Text.Split('~');
                                string productCode = "0";
                                if (Convert.ToString(varNewFlag) == "0")
                                {
                                    productCode = lblProductcode.Text;
                                }
                                else
                                {
                                    MR_Master objMR_Master = new MR_Master();
                                    objMR_Master.ViewType = 17;
                                    objDS = objDServ.udfnMaster(objMR_Master);
                                    objDServ.CloseConnection();
                                    if (objDS.Tables[0].Rows.Count > 0)
                                    {
                                        productCode = Convert.ToString(objDS.Tables[0].Rows[0]["Proid"]);
                                        varTName = txtProductName.Text;
                                        varPICode = "";
                                        var_Symbol = "";
                                        varexp = ""; 
                                        txtBatchno.Text = "";
                                        varunitid = "0";
                                        expirydateFlag = 0;
                                    }
                                } 
                                if (txtMismatchQty.Text != "")
                                {
                                    string[] Quantity = txtMismatchQty.Text.Split('.');
                                    string Qty = objValidation.udfnDecimal((txtMismatchQty.Text).Trim(), varDecimal);
                                    string QtyValue = Quantity[0];
                                    if (QtyValue == "0")
                                    {
                                        txtMismatchQty.Text = "0" + Qty; 
                                    }
                                    else
                                    {
                                        txtMismatchQty.Text = Qty; 
                                    }
                                } 
                                if (varReasonFlag==0) //No differece than validate 
                                {
                                    if (txtMismatchQty.Text.Trim() != "")
                                    { varMismatchQty = Convert.ToDecimal(txtMismatchQty.Text); }
                                }  
                                if (grdGrnlist.Rows.Count > 0)
                                {
                                    maxSno = (from row in grdGrnlist.Rows.Cast<DataGridViewRow>()
                                              let snoValue = string.IsNullOrEmpty(Convert.ToString(row.Cells["clmsno"].Value)) ? 0 : Convert.ToInt32(row.Cells["clmsno"].Value)
                                              select snoValue).Max();
                                } 
                                if (txtmrprate.Text.Trim() != "")
                                {
                                    varMRP = Math.Round(Convert.ToDecimal(txtmrprate.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                                    mrp = string.Format("{0:0.00}", varMRP);
                                    mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                                }
                                if (varLPFlag == 1)
                                {
                                    varLocationID = "0"; varRackID = "0"; varRack = "None"; varLocationName = "None";
                                }  
                                grdGrnlist.Columns["clmtam"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                 
                                grdGrnlist.Rows.Add(maxSno + 1,  (varpono[0]).Trim(), (varPICode).Trim(),  (varEName).Trim(),  (varTName).Trim(),    (var_Symbol).Trim(),
                                    pbCondition,   varMismatchQty,   Convert.ToString(cmbReason.Text),Convert.ToDecimal(mrp),
                                    Convert.ToDecimal(mrp), (varExpiryDate).Trim(), varExpiryDate.Trim() ,  (varexp).Trim(),varAcutalshelflife, 
                                    varShelflifevalue, (txtBatchno.Text).Trim(), (txtBatchno.Text).Trim(),  varLocationName, varRack, (productCode).Trim(), cmbProType.SelectedValue,
                                      (varunitid).Trim(),pbConditionIDs, cmbReason.SelectedValue, varMRPFlag, expirydateFlag, varBatchNo, varBatchNoGeneration, varLocationID,  
                                    varRackID, varDecimal, varRMProductionFlag);
                                
                                dtPurchaseAutoComplete.Rows.Add(maxSno + 1, productCode, mrp1, varExpiryDate, (txtBatchno.Text).Trim(), varunitid, varLocationID,
                                    (varRackID), expirydateFlag, Convert.ToInt16(cmbProType.SelectedValue), 0);
                                 
                                if (varDateEnable == 1)
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmexpirydate"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                    DataGridView dataGridView1 = grdGrnlist;
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmInvoiceExpiry"];
                                    cell1.Style.BackColor = Color.LightGray;
                                    cell1.Style.ForeColor = Color.Black;
                                    cell1.ReadOnly = true;
                                }
                                if (varMRPEditflag == 0)
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmmrp"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                    DataGridView dataGridView1 = grdGrnlist;
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmInvoiceMRP"];
                                    cell1.Style.BackColor = Color.LightGray;
                                    cell1.Style.ForeColor = Color.Black;
                                    cell1.ReadOnly = true;
                                }
                                if (varRMProductionFlag == 1)
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmexpirydate"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                    DataGridView dataGridView1 = grdGrnlist;
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmInvoiceExpiry"];
                                    cell1.Style.BackColor = Color.LightGray;
                                    cell1.Style.ForeColor = Color.Black;
                                    cell1.ReadOnly = true;
                                }
                                if (varProducts == "")
                                {
                                    varProducts = Convert.ToString(lblProductcode.Text);
                                }
                                else
                                {
                                    varProducts = varProducts + ',' + Convert.ToString(lblProductcode.Text);
                                }
                                varProductsIDs.Add(Convert.ToInt32(lblProductcode.Text)); 
                                varModifiedFlag = 1;  
                                this.ActiveControl = txtProductName;
                                string[] varShelflifeper = Convert.ToString(varShelflifevalue).Split(' '); 
                                if (varShelflifeper[0] != "")
                                {
                                    //Shelflife Wise Color Set
                                    if (Convert.ToDecimal(varShelflifeper[0]) <= (MainForm.pbShelflifeLevel1))
                                    {
                                        DataGridView dataGridView = grdGrnlist;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.Red;
                                        cell.Style.ForeColor = Color.White;
                                    }
                                    else if (Convert.ToDecimal(varShelflifeper[0]) > (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel2))
                                    {
                                        DataGridView dataGridView = grdGrnlist;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.Orange;
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                        DataGridView dataGridView = grdGrnlist;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.White;
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                }
                                if (varBatchNo == "72" && varBatchNoGeneration == "75")
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    cell.Style.BackColor = Color.PaleGreen;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = false;
                                    DataGridView dataGridView1 = grdGrnlist;
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmInvoiceBatch"];
                                    cell1.Style.BackColor = Color.PaleGreen;
                                    cell1.Style.ForeColor = Color.Black;
                                    cell1.ReadOnly = false;
                                }
                                if (varBatchNo == "72" && varBatchNoGeneration == "74")
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                    DataGridView dataGridView1 = grdGrnlist;
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmInvoiceBatch"];
                                    cell1.Style.BackColor = Color.LightGray;
                                    cell1.Style.ForeColor = Color.Black;
                                    cell1.ReadOnly = false;
                                    if(varLPFlag==1)
                                    {
                                        cell.ReadOnly = false;
                                        cell1.ReadOnly = false;
                                    }
                                }
                                else if (varBatchNo == "73")
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                    DataGridView dataGridView1 = grdGrnlist;
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmInvoiceBatch"];
                                    cell1.Style.BackColor = Color.LightGray;
                                    cell1.Style.ForeColor = Color.Black;
                                    cell1.ReadOnly = false;
                                } 
                                if (varNoDiffFlag == 0)
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmMismatchQty"];
                                    cell.Style.BackColor = Color.PaleGreen;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = false;
                                }
                                else
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmMismatchQty"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                }
                                udfnrowclear(); 
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
            finally
            {
                grdGrnlist.Sort(grdGrnlist.Columns[0], ListSortDirection.Descending); 
                if(grdGrnlist.Rows.Count>0)
                {
                    grdGrnlist.CurrentCell = grdGrnlist[2,0];
                }
            }
        }

        public void udfnrowclear()
        {
            try
            {
                errGRNDetails.Clear(); 
                cmbProType.BackColor = Color.White;
                txtProductName.Text = "";
                txtmrprate.Text = "";
                txtDate.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchno.Text = "";
                txtMismatchQty.Text = "";
                txtProductName.BackColor = Color.White;
                txtmrprate.BackColor = Color.White;
                txtDate.BackColor = Color.White;
                txtMonth.BackColor = Color.White;
                txtYear.BackColor = Color.White;
                txtBatchno.BackColor = Color.White;
                txtMismatchQty.BackColor = Color.White;
                cmbReason.Enabled = true;
                cmbReason.SelectedValue = 286;
                udfnConditionClear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfncleardata()
        {
            try
            {
                errGRNDetails.Clear();
                cmbProType.BackColor = Color.White; 
                txtmrprate.Text = "";
                txtDate.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchno.Text = "";
                txtMismatchQty.Text = ""; 
                txtmrprate.BackColor = Color.White;
                txtDate.BackColor = Color.White;
                txtMonth.BackColor = Color.White;
                txtYear.BackColor = Color.White;
                txtBatchno.BackColor = Color.White;
                txtMismatchQty.BackColor = Color.White;
                udfnConditionClear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDatevalidationset()
        {
            try
            {
                string varDay = "", varMonth = "", varYear = "", varDate = ""; string varDcDay = "", varDcMonth = "", varDcYear = "", varExpiry = "";
                int varExpiryDays = 0; int error = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (txtDate.Text.Trim() == "")
                {
                    varDay = "01";
                }
                else
                {
                    if (Convert.ToInt64(txtDate.Text) > 31 || Convert.ToInt64(txtDate.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(95);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtDate.Text.Length == 1)
                        { txtDate.Text = 0 + txtDate.Text.Trim(); }
                        varDay = txtDate.Text.Trim();
                    }
                }
                if (txtMonth.Text.Trim() != "")
                {
                    if (Convert.ToInt64(txtMonth.Text) > 12 || Convert.ToInt64(txtMonth.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(90);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtMonth.Text.Length == 1)
                        { txtMonth.Text = 0 + txtMonth.Text.Trim(); }
                    }
                }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Length < 2)
                    {
                        pbDateflag = 1;
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(92);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (pbDateflag == 0)
                {
                    varMonth = Convert.ToString(txtMonth.Text.Trim());
                    varYear = 20 + Convert.ToString(txtYear.Text.Trim());
                    if (txtDate.Text.Trim() == "")
                    {
                        varDate = varDay + "/" + varMonth + "/" + varYear;
                        MR_Master objMR_Master1 = new MR_Master();
                        objMR_Master1.ViewType = 5;
                        objMR_Master1.paraDate = varDate;
                        objDS = objDServ.udfnMaster(objMR_Master1);
                        objDServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varExpiryDate = objDS.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();
                            string varTempYear = "0";
                            object cellValue = varExpiryDate;
                            string[] DMY = varExpiryDate.Split('/');
                            if (DMY.Count() == 3)
                            {
                                varTempYear = DMY[2];
                                if (varTempYear.Length == 4)
                                {
                                    int year = Convert.ToInt32(varTempYear) - 2000;
                                    varExpiryDateAdd = DMY[0] + "/" + DMY[1] + "/" + year;
                                }
                            }
                        }
                    }
                    else
                    {
                        varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                        varExpiryDateAdd = varDay + "/" + varMonth + "/" + txtYear.Text.Trim();
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 10;
                    objMR_Master.paraDate = dpGrnDate.Text.Trim();
                    objMR_Master.ParaExpiryDate = varExpiryDate;
                    objMR_Master.paraProductId = Convert.ToInt32(lblProductcode.Text.Trim());
                    objDS = objDServ.udfnMaster(objMR_Master);
                    objDServ.CloseConnection();
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                        {
                            pbDateflag = 1; error = 1;
                        }
                        else
                        {
                            if (objDS.Tables.Count != 0)
                            {
                                if (objDS.Tables[1].Rows.Count > 0)
                                {
                                    varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                }
                            }
                            if (varExpiryDays < 0)
                            {
                                pbDateflag = 1; error = 1;
                            }
                            else
                            {
                                if (varShelflife == 1)
                                {
                                    if (objDS.Tables.Count > 1)
                                    {
                                        if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                        {
                                            pbDateflag = 1;
                                            txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            string varMessage = objDServ.udfnGetMessages(98);
                                            objDServ.CloseConnection();
                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        pbDateflag = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                if (error == 1)
                {
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    string varMessage = objDServ.udfnGetMessages(94);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                btnAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpinvoicedate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpinvoicedate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpinvoicedate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpinvoicedate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpinvoicedate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceamt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceamt.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceamt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPayment.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtProductName.Text == "")
                //{
                //    errPO.SetError(txtProductName, "Please enter product");
                //    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpProduct.ShowAlways = true;
                //    tpProduct.Show("Please enter product.", txtProductName, 5000);
                //}
                //else
                //{
                errGRNDetails.Clear();
                txtProductName.BackColor = Color.White;
                tpProduct.Active = false;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                /*
                if (e.KeyCode == Keys.Enter)
                {
                    txtmrprate.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvproduct.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtProductName.Focus();
                        lvproduct.Visible = false;
                    }
                    else
                    {
                        lvproduct.Focus();
                    }
                    if (lvproduct.Items.Count > 0)
                    {
                        lvproduct.Items[0].Selected = true;
                    }
                }*/

                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblDEGroup.Text = "Search by P.I Code (F11)";
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblDEGroup.Text = "Search by Product Name (F11)";
                    }
                }
                //if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                //{
                //    cmbQtyType.Focus();
                //}
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount==0)
                {
                    return;
                }
                else
                {
                    DGV_FilterProduct.Focus();
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (-1))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewProduct();
                                    btnConditions.Focus();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnConditions.Focus();
                    }
                }
                //if (e.KeyCode == Keys.F10)
                //{
                //    varEditPRID = lblProductcode.Text;
                //    varAutocompleteProduct = 1;
                //    udfnProDataChange();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProDataChange()
        {
            try
            {
                MainForm.objCP_Items = new CP_Product();
                MainForm.objCP_Items.varproductcode = Convert.ToInt32(varEditPRID);
                MainForm.objCP_Items.varMasterType = "2";
                MainForm.objCP_Items.btnSave.Text = "Update";
                MainForm.objCP_Items.ShowDialog();
                udfnProductWiseDetails();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnListviewProduct();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //udfnListviewProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    varDateEnable = 0;
                    txtmrprate.Text = "";
                    txtDate.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtBatchno.Text = "";
                    varBatchNo = "0"; varBatchNoGeneration = "0"; varShelflife = 0; expirydateFlag = 0; varMRPFlag = 0;varMRPEditflag = 0;
                    varRMProductionFlag = 0;
                    /*
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[2].Text;
                    lblProductcode.Text = selectedItem.SubItems[4].Text;
                    varBatchNo = selectedItem.SubItems[5].Text;
                    varBatchNoGeneration = selectedItem.SubItems[6].Text;
                    varRMProduction = selectedItem.SubItems[7].Text;
                    varPrcategory = selectedItem.SubItems[8].Text;
                    varShelflife = Convert.ToInt32(selectedItem.SubItems[9].Text);
                    */
                    //udfnProductAdd();

                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varEditPRID = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    varAutocompleteProduct = 1;
                    udfnProductWiseDetails();
                    udfnDefalutLocation();
                    if (varRMProductionFlag == 1)
                    {
                        txtDate.Enabled = false; txtDate.ReadOnly = true;
                        txtMonth.Enabled = false; txtMonth.ReadOnly = true;
                        txtYear.Enabled = false; txtYear.ReadOnly = true;
                    }
                    //varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNo"].Value.ToString();
                    //varBatchNoGeneration = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNoGeneration"].Value.ToString();
                    //varRMProduction = DGV_FilterProduct.SelectedRows[0].Cells["PR_RMForProduction"].Value.ToString();
                    //varPrcategory = DGV_FilterProduct.SelectedRows[0].Cells["PR_PRCTID"].Value.ToString();
                    //varShelflife = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_ShelfLife"].Value.ToString());
                    //varMRPFlag = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_MRPflag"].Value);
                    //lblUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    //varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    //txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                }
                btnConditions.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }
        public void udfnProductWiseDetails()
        {
            try
            {
                if (varEditPRID != "0")
                {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 1;
                        objMR_Product.ParaProductCode = Convert.ToInt32(varEditPRID);
                        SPDataService objspservice = new SPDataService();
                        DataSet objDS;
                        objDS = objspservice.udfnproductmasterlist(objMR_Product);
                        objspservice.CloseConnection();
                        if (objDS != null)
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                varBatchNo = Convert.ToString(objDS.Tables[0].Rows[0]["BATCHNO"].ToString());
                                varBatchNoGeneration = Convert.ToString(objDS.Tables[0].Rows[0]["BARCODE GENERATION"].ToString());
                                varRMProduction = Convert.ToString(objDS.Tables[0].Rows[0]["RM PRODUCTION"].ToString());
                                varPrcategory = Convert.ToString(objDS.Tables[0].Rows[0]["PRODUCTCATEGORY"].ToString());
                                varShelflife = Convert.ToInt32(objDS.Tables[0].Rows[0]["SHELFLIFE"].ToString());
                                varMRPFlag = Convert.ToInt32(objDS.Tables[0].Rows[0]["PR_MRPflag"].ToString());
                                lblUnit.Text = Convert.ToString(objDS.Tables[0].Rows[0]["UT_Symbol"].ToString());
                                varDecimal = Convert.ToInt32(objDS.Tables[0].Rows[0]["UT_Decimal"].ToString());
                                varPICode = Convert.ToString(objDS.Tables[0].Rows[0]["PICODE"].ToString());
                                varEName = Convert.ToString(objDS.Tables[0].Rows[0]["ENAME"].ToString());
                                varTName = Convert.ToString(objDS.Tables[0].Rows[0]["TNAME"].ToString());
                                var_Symbol = Convert.ToString(objDS.Tables[0].Rows[0]["UT_Symbol"].ToString());
                                varunitid = Convert.ToString(objDS.Tables[0].Rows[0]["UNIT"].ToString());
                                varexp = Convert.ToString(objDS.Tables[0].Rows[0]["PRODUCT EXPIRY"].ToString());
                                if (varAutocompleteProduct == 1)
                                {
                                    if (varShelflife == 1)
                                    {
                                        expirydateFlag = 1;
                                        txtDate.ReadOnly = false;
                                        txtMonth.ReadOnly = false;
                                        txtYear.ReadOnly = false;
                                        txtDate.Enabled = true;
                                        txtMonth.Enabled = true;
                                        txtYear.Enabled = true;
                                    }
                                    else
                                    {
                                        expirydateFlag = 0;
                                        txtDate.ReadOnly = true;
                                        txtMonth.ReadOnly = true;
                                        txtYear.ReadOnly = true;
                                        txtDate.Enabled = false;
                                        txtMonth.Enabled = false;
                                        txtYear.Enabled = false;
                                        varDateEnable = 1;
                                    }
                                    if (varMRPFlag == 1)
                                    {
                                        varMRPEditflag = 1;
                                        txtmrprate.ReadOnly = false;
                                        txtmrprate.Enabled = true;
                                    }
                                    else
                                    {
                                        varMRPEditflag = 0;
                                        txtmrprate.ReadOnly = true;
                                        txtmrprate.Enabled = false;
                                    }

                                if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                                {
                                    txtBatchno.Text = "";
                                    txtBatchno.Enabled = false;
                                    //  txtBatchNo.ReadOnly = true;
                                }
                                else if (Convert.ToInt32(varBatchNo) == 72) //enabled
                                {
                                    if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                                    {
                                        txtBatchno.Enabled = true;
                                        txtBatchno.ReadOnly = false;
                                        txtBatchno.BackColor = Color.White;
                                    }
                                    else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                                    {
                                        MR_Master objMR_Master = new MR_Master();
                                        objMR_Master.ViewType = 14;
                                        SPDataService objspdservice = new SPDataService();
                                        DataSet objDs = new DataSet();
                                        objDs = objspdservice.udfnMaster(objMR_Master);
                                        objspdservice.CloseConnection();
                                        if (objDs.Tables[0] != null)
                                        {
                                            if (objDs.Tables[0].Rows.Count != 0)
                                            {
                                                txtBatchno.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                                txtBatchno.Enabled = false;
                                                txtBatchno.ReadOnly = true;
                                            }
                                        }
                                    }
                                }
                                if (Convert.ToInt32(varPrcategory) == 16)
                                {
                                    if (Convert.ToInt32(varRMProduction) == 1)
                                    {
                                        varRMProductionFlag = 1;
                                        MR_Master objMR_Master = new MR_Master();
                                        objMR_Master.ViewType = 15;
                                        objMR_Master.paraDate = dpGrnDate.Text;
                                        objMR_Master.paraProductId = Convert.ToInt32(lblProductcode.Text.Trim());
                                        SPDataService objspdservice = new SPDataService();
                                        DataSet objDs = new DataSet();
                                        objDs = objspdservice.udfnMaster(objMR_Master);
                                        objspdservice.CloseConnection();
                                        if (objDs.Tables[0] != null)
                                        {
                                            if (objDs.Tables[0].Rows.Count != 0)
                                            {
                                                txtDate.Text = objDs.Tables[0].Rows[0][0].ToString();
                                                txtMonth.Text = objDs.Tables[0].Rows[1][0].ToString();
                                                txtYear.Text = objDs.Tables[0].Rows[2][0].ToString();
                                            }
                                        }
                                    }
                                }
                            }
                            if(varAutocompleteProduct==2)
                            {
                                DataGridView dataGridView1 = grdGrnlist;
                                DataGridViewCell cell1 = dataGridView1.CurrentRow.Cells["clmmrp"];
                                DataGridView dataGridView2 = grdGrnlist;
                                DataGridViewCell cell2 = dataGridView2.CurrentRow.Cells["clmexpirydate"];
                                DataGridView dataGridView3 = grdGrnlist;
                                DataGridViewCell cell3 = dataGridView3.CurrentRow.Cells["clmBatchno"];
                                if (varMRPFlag == 0)
                                {
                                    cell1.Style.BackColor = Color.LightGray;
                                    cell1.Style.ForeColor = Color.Black;
                                    cell1.ReadOnly = true;
                                    cell1.Value = "0.00";
                                }
                                else
                                {
                                    cell1.Style.BackColor = Color.PaleGreen;
                                    cell1.Style.ForeColor = Color.Black;
                                    cell1.ReadOnly = false;
                                }
                                if (varShelflife == 0)
                                {
                                    cell2.Style.BackColor = Color.LightGray;
                                    cell2.Style.ForeColor = Color.Black;
                                    cell2.ReadOnly = true;
                                    cell2.Value = "";
                                }
                                else
                                {
                                    cell2.Style.BackColor = Color.PaleGreen;
                                    cell2.Style.ForeColor = Color.Black;
                                    cell2.ReadOnly = false;
                                }
                                if (varBatchNo == "72" && varBatchNoGeneration == "75")
                                {
                                    cell3.Style.BackColor = Color.PaleGreen;
                                    cell3.Style.ForeColor = Color.Black;
                                    cell3.ReadOnly = false;
                                }
                                if (varBatchNo == "72" && varBatchNoGeneration == "74")
                                {
                                    cell3.Style.BackColor = Color.LightGray;
                                    cell3.Style.ForeColor = Color.Black;
                                    cell3.ReadOnly = true;
                                    cell3.Value = "";
                                }
                                else if (varBatchNo == "73")
                                {
                                    cell3.Style.BackColor = Color.LightGray;
                                    cell3.Style.ForeColor = Color.Black;
                                    cell3.ReadOnly = true;
                                    cell3.Value = "";
                                }
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
        public void udfnProductAdd()
        {
            try
            {
                if (Convert.ToInt32(lblProductcode.Text) != 0)
                {
                    varPICode = ""; varEName = ""; var_Symbol = ""; var_Text = ""; var_RMinSaleQty = ""; varSTOCK = ""; varPrevious = "";
                    varPARITAL = ""; varReOrderQty = ""; varorderSaleQty = ""; addproductid = ""; varunitid = ""; varexp = "";
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 34;
                    objMR_Product.ParaProductCode = Convert.ToInt32(lblProductcode.Text);
                    objMR_Product.ParaScheduleid = lblschedule.Text;
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varPICode = objDs.Tables[0].Rows[0]["PR_PICode"].ToString();
                            varEName = objDs.Tables[0].Rows[0]["PR_EName"].ToString();
                            varTName = objDs.Tables[0].Rows[0]["PR_TName"].ToString();
                            var_Symbol = objDs.Tables[0].Rows[0]["UT_Symbol"].ToString();
                            var_Text = objDs.Tables[0].Rows[0]["GST_Text"].ToString();
                            var_RMinSaleQty = objDs.Tables[0].Rows[0]["PR_MinStock"].ToString();
                            varSTOCK = objDs.Tables[0].Rows[0]["STOCK"].ToString();
                            varPrevious = objDs.Tables[0].Rows[0]["PRE.PEND"].ToString();
                            varPARITAL = objDs.Tables[0].Rows[0]["PARITAL"].ToString();
                            varReOrderQty = objDs.Tables[0].Rows[0]["PR_ReOrderQty"].ToString();
                            varorderSaleQty = "0";
                            addproductid = objDs.Tables[0].Rows[0]["PRID"].ToString();
                            varunitid = objDs.Tables[0].Rows[0]["UTID"].ToString();
                            varexp = objDs.Tables[0].Rows[0]["PRODUCTEXP"].ToString();
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

        public void udfnsupplierLoad()
        {
            try
            {
                if (lblSupplierCode.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            lblSuppliername.Text = objDs.Tables[0].Rows[0]["NAME"].ToString();
                            lblSupplierCity.Text = objDs.Tables[0].Rows[0]["CITY"].ToString();
                            lblsupplierGST.Text = objDs.Tables[0].Rows[0]["GSTIN"].ToString();
                            if (lblsupplierGST.Text != "URD")
                            {
                                lblsupplierGST.Text = "GSTIN - XXXXXXXXXXXXXXX";
                            }
                            else
                            {
                                lblsupplierGST.Text = "GSTIN - " + lblsupplierGST.Text;
                            }
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString();
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString();
                            lblSupplierOrderpolicy.Text = "Return Policy -" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                        }
                        if (objDs.Tables[7].Rows.Count > 0)
                        {
                            varDamage = objDs.Tables[7].Rows[0]["DAMAGE"].ToString();
                            varReturnDC = objDs.Tables[7].Rows[0]["RETURNDC"].ToString();
                        }
                        if (objDs.Tables[5].Rows.Count > 0)
                        {
                            grdPODetails.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[5].Rows.Count; i++)
                            {
                                grdPODetails.Rows.Add(objDs.Tables[5].Rows[i]["PO_No"].ToString(),
                                objDs.Tables[5].Rows[i]["PO_Date"].ToString(), objDs.Tables[5].Rows[i]["QTY"].ToString(), objDs.Tables[5].Rows[i]["PO_Final_STSID"].ToString(), objDs.Tables[5].Rows[i]["POID"].ToString()
                                );
                                if (varPoIDs == "")
                                {
                                    varPoIDs = Convert.ToString(objDs.Tables[5].Rows[i]["POID"]);
                                }
                                else
                                {
                                   varPoIDs = varPoIDs + ',' + Convert.ToString(objDs.Tables[5].Rows[i]["POID"]);
                                }
                            }
                            DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdPODetails_DataBindingComplete(grdPODetails, args);
                        }
                        else
                        {
                            grdPODetails.Rows.Clear();
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
                if (varReturnDC == "0")
                {
                    btnDC.Enabled = false;
                }
                else
                {
                    btnDC.Enabled = true;
                }
                if (varDamage == "0")
                {
                    btnDamage.Enabled = false;
                }
                else
                {
                    btnDamage.Enabled = true;
                }
            }
        }
        public void udfnEditLoad()
        {
            try
            {
                if (pbGRNId != "0")
                {
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnGrnListLoad(2, Convert.ToInt32(pbSupplierId), 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0,0, "0","","", 0, 0, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                cmbConcern.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_COMID"]);
                                dpGrnDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Date"]);
                                txtgrnno.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_No"]);
                                txtSupplier.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SUPPLIER"]);
                                lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_SPID"]);
                                cmbOrderType.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_OrderType"]);
                                lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_SPSCID"]);
                                dpinvoicedate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceDate"]);
                                txtInvoiceno.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceNo"]);
                                txtInvoiceamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceAmnt"]);
                                txtRemark.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Remarks"]);
                                cmbPayment.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Payment_StsID"]);
                                varBlockedSupplier = Convert.ToString(objDs.Tables[0].Rows[0]["SP_STSId"]);
                                varBlockedReason = Convert.ToString(objDs.Tables[0].Rows[0]["Reason"]);
                                lblDPercentage.Text = "< " + Convert.ToString(objDs.Tables[0].Rows[0]["Level1"]) + "%";
                                lblPercentage.Text = "< " + Convert.ToString(objDs.Tables[0].Rows[0]["Level2"]) + "%";
                                udfnsupplierLoad();
                                LV_Supplier.Visible = false;
                                cmbConcern.Enabled = false;
                                dpGrnDate.Enabled = false;
                                txtSupplier.Enabled = false;
                                cmbOrderType.Enabled = false;
                                if (Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "23" || Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "24" || Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "44")
                                {
                                    chkCompleted.Enabled = false;
                                    chkCompleted.Checked = true;
                                    btnDC.Enabled = false;
                                    gpAddrow.Enabled = false;
                                    grpGrnDetails.Enabled = false;
                                    grdGrnlist.Enabled = true;
                                    grdGrnlist.ReadOnly = false;
                                    grdGrnlist.Columns["clmRemove"].Visible = false; 
                                }
                                else
                                {
                                    chkCompleted.Enabled = true;
                                }
                                if (Convert.ToDecimal(txtInvoiceamt.Text) >= 25000)
                                {
                                    if (chkCompleted.Enabled == false)
                                    {
                                        btnVerify1.Enabled = true;
                                    }
                                }
                                else
                                {
                                    btnVerify1.Enabled = false;
                                    btnVerify2.Enabled = false;
                                }
                            }
                            if (objDs.Tables[3].Rows.Count != 0)
                            {
                                string POType = Convert.ToString(objDs.Tables[3].Rows[0]["newproflag"]);
                                grdGrnlist.Rows.Clear();
                                if (POType != "5")
                                {
                                    for (int i = 0; i < objDs.Tables[3].Rows.Count; i++)
                                    {
                                        lblNoRecordsFound.Visible = false;
                                        string varMRP = "", varInvoiceMRP = "";
                                        if (Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_MRP"]) == "0")
                                        {  varMRP = "";   }
                                        else
                                        {   varMRP = Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_MRP"]); } 

                                        if (Convert.ToString(objDs.Tables[3].Rows[i]["Invoice MRP"]) == "0")
                                        {  varInvoiceMRP = "";  }
                                        else
                                        { varInvoiceMRP = Convert.ToString(objDs.Tables[3].Rows[i]["Invoice MRP"]);   } 
                                        grdGrnlist.Rows.Add(grdGrnlist.Rows.Count + 1, Convert.ToString(objDs.Tables[3].Rows[i]["POID"]), Convert.ToString(objDs.Tables[3].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[3].Rows[i]["PENAME"]), Convert.ToString(objDs.Tables[3].Rows[i]["PTNAME"]), Convert.ToString(objDs.Tables[3].Rows[i]["UNIT"]),
                                            Convert.ToString(objDs.Tables[3].Rows[i]["Condition Type"]), Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_MismatchQty"]), Convert.ToString(objDs.Tables[3].Rows[i]["Reason"]),
                                            Convert.ToString(string.Format("{0:G29}", decimal.Parse(varMRP))),  Convert.ToString(objDs.Tables[3].Rows[i]["Invoice MRP"]),  Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_Expirydate"]), Convert.ToString(objDs.Tables[3].Rows[i]["Invoice Expiry"]),   Convert.ToString(objDs.Tables[3].Rows[i]["PRODUCTEXP"]),   Convert.ToString(objDs.Tables[3].Rows[i]["actuallife"]),  Convert.ToString(objDs.Tables[3].Rows[i]["Shelflifeper"]), Convert.ToString(objDs.Tables[3].Rows[i]["BATCHDATE"]), Convert.ToString(objDs.Tables[3].Rows[i]["Invoice BatchNo"]), Convert.ToString(objDs.Tables[3].Rows[i]["Location"]),   Convert.ToString(objDs.Tables[3].Rows[i]["Rack"]),Convert.ToString(objDs.Tables[3].Rows[i]["PRID"]),   
                                            Convert.ToString(objDs.Tables[3].Rows[i]["POID"]), Convert.ToString(objDs.Tables[3].Rows[i]["UTID"]),    
                                            Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_Condition_Type"]),Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_ReturnType"]), Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_MRPflag"]),    Convert.ToString(objDs.Tables[3].Rows[i]["PR_ShelfLife"]),Convert.ToString(objDs.Tables[3].Rows[i]["BATCHNO"]),     Convert.ToString(objDs.Tables[3].Rows[i]["Batchnogeneration"]), Convert.ToString(objDs.Tables[3].Rows[i]["Location ID"]),  Convert.ToString(objDs.Tables[3].Rows[i]["Rack ID"]),Convert.ToString(objDs.Tables[3].Rows[i]["Unit_Decimal"]),   Convert.ToString(objDs.Tables[3].Rows[i]["RM Flag"]));   
                                        dtPurchaseAutoComplete.Rows.Add(grdGrnlist.Rows.Count + 1, Convert.ToString(objDs.Tables[3].Rows[i]["PRID"]), string.Format("{0:G29}", decimal.Parse(varMRP)), Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_Expirydate"]),
                                         Convert.ToString(objDs.Tables[3].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[3].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[3].Rows[i]["Location ID"]),Convert.ToString(objDs.Tables[3].Rows[i]["Rack ID"]), Convert.ToString(objDs.Tables[3].Rows[i]["PR_ShelfLife"]), Convert.ToString(objDs.Tables[3].Rows[i]["POID"]), 0);

                                        grdGrnlist.Columns["clmtam"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        if (Convert.ToString(objDs.Tables[3].Rows[i]["PR_ShelfLife"]) == "0")
                                        {
                                            grdGrnlist.Rows[i].Cells["clmexpirydate"].ReadOnly = true;
                                            grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                                        }
                                        if (Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_MRPflag"]) == "0")
                                        {
                                            grdGrnlist.Rows[i].Cells["clmmrp"].ReadOnly = true;
                                            grdGrnlist.Rows[i].Cells["clmmrp"].Style.BackColor = Color.LightGray;
                                            grdGrnlist.Rows[i].Cells["clmInvoiceMRP"].ReadOnly = true;
                                            grdGrnlist.Rows[i].Cells["clmInvoiceMRP"].Style.BackColor = Color.LightGray;
                                        }
                                        if (varProducts == "")
                                        {
                                            varProducts = Convert.ToString(grdGrnlist.Rows[i].Cells["clmProid"].Value);
                                        }
                                        else
                                        {
                                            varProducts = varProducts + ',' + Convert.ToString(grdGrnlist.Rows[i].Cells["clmProid"].Value);
                                        }
                                        varProductsIDs.Add(Convert.ToInt32(objDs.Tables[3].Rows[i]["PRID"])); 
                                        
                                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConditionId"].Value) == "275")
                                        {
                                            grdGrnlist.Rows[i].Cells["clmMismatchQty"].ReadOnly = true;
                                            grdGrnlist.Rows[i].Cells["clmMismatchQty"].Style.BackColor = Color.LightGray;
                                        }
                                        else
                                        {
                                            grdGrnlist.Rows[i].Cells["clmMismatchQty"].ReadOnly = false;
                                            grdGrnlist.Rows[i].Cells["clmMismatchQty"].Style.BackColor = Color.PaleGreen;
                                        }
                                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmRMFlag"].Value)=="1")
                                        {
                                            grdGrnlist.Rows[i].Cells["clmexpirydate"].ReadOnly = true;
                                            grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                                            grdGrnlist.Rows[i].Cells["clmInvoiceExpiry"].ReadOnly = true;
                                            grdGrnlist.Rows[i].Cells["clmInvoiceExpiry"].Style.BackColor = Color.LightGray; 
                                        }
                                    }
                                    txtTotalpro.Text = Convert.ToString(grdGrnlist.Rows.Count);
                                    DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                    GrdGrnlist_DataBindingComplete(grdGrnlist, args2);
                                }
                            } 
                            if (objDs.Tables[5].Rows.Count != 0)
                            {
                                if (Convert.ToString(objDs.Tables[5].Rows[0]["VERIFIED1"]) != "")
                                {
                                    //lblVerified1.Text = Convert.ToString(objDs.Tables[5].Rows[0]["VERIFIED1"]);
                                    //lblVerifyDateTime.Text = Convert.ToString(objDs.Tables[5].Rows[0]["VERIFIEDON1"]);
                                    btnVerify1.Enabled = false;
                                    btnVerify2.Enabled = false;
                                    btnDC.Enabled = false;
                                    if (pbStsID != "17")
                                    {
                                        gpAddrow.Enabled = false;
                                        grpGrnDetails.Enabled = false;
                                        grdGrnlist.Columns["clmRemove"].Visible = false;
                                    }
                                   // grdGrnlist.Enabled = false;
                                    grdGrnlist.ClearSelection();
                                }
                                else
                                {
                                    if (chkCompleted.Enabled == false && chkCompleted.Checked == true)
                                    {
                                        btnVerify1.Enabled = true;
                                        btnVerify2.Enabled = false;
                                    }
                                    //gpAddrow.Enabled = true;
                                }
                            } 
                            if (objDs.Tables[6].Rows.Count != 0)
                            {
                                if (Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIED2"]) != "")
                                {
                                    //lblVerified2.Text = Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIED2"]);
                                    //lblVerifyDateTime2.Text = Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIEDON2"]);
                                    btnVerify2.Enabled = false;
                                }
                                else
                                {
                                    if (lblVerified1.Text != "")
                                    {
                                        if (Convert.ToDecimal(txtInvoiceamt.Text) >= 25000)
                                        {
                                            btnVerify2.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        btnVerify2.Enabled = false;
                                    } 
                                }
                            }
                            if (objDs.Tables[7].Rows.Count != 0)
                            {
                                grdReurnDC.Rows.Clear();
                                for (int i = 0; i < objDs.Tables[7].Rows.Count; i++)
                                {
                                    grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[7].Rows[i]["DCDATE"]), Convert.ToString(objDs.Tables[7].Rows[i]["DCNO"]),
                                    Convert.ToString(objDs.Tables[7].Rows[i]["PRCOUNT"]), Convert.ToString(objDs.Tables[7].Rows[i]["DCVALUE"]), Convert.ToString(objDs.Tables[7].Rows[i]["ID"]));
                                }
                                if (pbStsID != "17")
                                {
                                    grdReurnDC.Columns["clmDCRemove"].Visible = false;
                                }
                            }
                            if (objDs.Tables[8].Rows.Count != 0)
                            {
                                lbltotProduct.Text= Convert.ToString(objDs.Tables[8].Rows[0]["TotalPro"]);
                                if (objDs.Tables[9].Rows.Count != 0)
                                {
                                    lblAddProduct.Text = Convert.ToString(objDs.Tables[9].Rows[0]["AddedCount"]);
                                }
                                int Remaining = 0;
                                Remaining = Convert.ToInt32(lbltotProduct.Text) - Convert.ToInt32(lblAddProduct.Text);
                                lblRemainProduct.Text = Convert.ToString(Remaining);
                            }
                        }
                    }
                    if(chkCompleted.Checked == true && pbStsID!="17")
                    {
                        btnVerified.Enabled = false;
                        btnSave.Enabled = false;
                        txtRemark.Enabled = false;
                        udfnDisable();
                        udfnVerifiedBy();
                    }
                    else
                    {
                        btnVerified.Enabled = true;
                        udfnVerifiedBy();
                    }
                    //if (Convert.ToInt32(cmbQtyType.SelectedValue) == 202)
                    //{
                    //    DataGridView dataGridView = grdGrnlist;
                    //    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmInvoiceQty"];
                    //    cell.Style.BackColor = Color.LightGray;
                    //    cell.Style.ForeColor = Color.Black;
                    //    cell.ReadOnly = true;
                    //}
                    //else
                    //{
                    //    DataGridView dataGridView = grdGrnlist;
                    //    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmInvoiceQty"];
                    //    cell.Style.BackColor = Color.PaleGreen;
                    //    cell.Style.ForeColor = Color.White;
                    //    cell.ReadOnly = true;
                    //}
                    if (varBlockedSupplier == "98")
                    {
                        tsbSupplier.Visible = true;
                        txtSupplier.BackColor = Color.LightPink;
                        tsbSupplier.Text = varBlockedReason;
                    }
                    else
                    {
                        tsbSupplier.Visible = false;
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
                if(grdGrnlist.Rows.Count>0)
                {
                    grdGrnlist.CurrentCell = grdGrnlist[6, 0];
                }
            }
        }
        public void udfnDisable()
        {
            try
            {
                grdGrnlist.Columns["clmMismatchQty"].ReadOnly = true;
                //grdGrnlist.Columns["clmExcessQty"].ReadOnly = true;
                grdGrnlist.Columns["clmMismatchQty"].DefaultCellStyle.BackColor = Color.LightGray;
                //grdGrnlist.Columns["clmExcessQty"].DefaultCellStyle.BackColor = Color.LightGray;
                grdGrnlist.Columns["clmmrp"].ReadOnly = true;
                grdGrnlist.Columns["clmmrp"].DefaultCellStyle.BackColor = Color.LightGray;
                grdGrnlist.Columns["clmInvoiceMRP"].ReadOnly = true;
                grdGrnlist.Columns["clmInvoiceMRP"].DefaultCellStyle.BackColor = Color.LightGray;
                grdGrnlist.Columns["clmexpirydate"].ReadOnly = true;
                grdGrnlist.Columns["clmInvoiceExpiry"].ReadOnly = true;
                grdGrnlist.Columns["clmBatchno"].ReadOnly = true;
                grdGrnlist.Columns["clmInvoiceBatch"].ReadOnly = true;
                grdGrnlist.Columns["clmMismatchQty"].ReadOnly = true;
                grdGrnlist.Columns["clmexpirydate"].DefaultCellStyle.BackColor = Color.LightGray;
                grdGrnlist.Columns["clmInvoiceExpiry"].DefaultCellStyle.BackColor = Color.LightGray;
                grdGrnlist.Columns["clmBatchno"].DefaultCellStyle.BackColor = Color.LightGray;
                grdGrnlist.Columns["clmInvoiceBatch"].DefaultCellStyle.BackColor = Color.LightGray;
                grdGrnlist.Columns["clmMismatchQty"].DefaultCellStyle.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if (grdGrnlist.Focused)
                {
                    grid_flag = 1;
                }
                if (grdGrnlist.Rows.Count > 0)
                {
                    if (grdGrnlist.CurrentCell.Selected == true && grdGrnlist.IsCurrentCellInEditMode == true)
                    {
                        grid_flag = 1;
                    }
                }
                if (grid_flag == 1)
                {
                    if (keyData == Keys.Enter || keyData == Keys.Right || keyData == Keys.Tab)
                    {
                        int icolumn = grdGrnlist.CurrentCell.ColumnIndex;
                        int irow = grdGrnlist.CurrentCell.RowIndex;
                        int i = irow;
                        int intsection = 0, intlvariant = 0;
                        intsection = grdGrnlist.Columns.Count - 1;
                        intlvariant = grdGrnlist.Columns.Count - 11;
                        if (intsection == icolumn)
                        {
                            grdGrnlist.CurrentCell = grdGrnlist[intsection, irow + 1];
                            icolumn = grdGrnlist.Columns.Count - 1;//grdProDetails.CurrentCell.ColumnIndex;
                            irow = grdGrnlist.CurrentCell.RowIndex;
                        }
                        else if (intlvariant == icolumn)
                        {
                        A: if (icolumn == grdGrnlist.Columns.Count - 11)
                            {
                                //grdProDetails.Rows.Add();
                                if (irow < grdGrnlist.Rows.Count - 1)
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[6, irow + 1];
                                    if (grdGrnlist.CurrentCell.ReadOnly==false)
                                    {
                                        grdGrnlist.CurrentCell = grdGrnlist[6, irow + 1];
                                    }
                                    else if(grdGrnlist[7, irow + 1].ReadOnly==false)
                                    {
                                        grdGrnlist.CurrentCell = grdGrnlist[7, irow + 1];
                                    }
                                    else
                                    {
                                        grdGrnlist.CurrentCell = grdGrnlist[9, irow + 1];

                                    }
                                    icolumn = grdGrnlist.CurrentCell.ColumnIndex;
                                    irow = grdGrnlist.CurrentCell.RowIndex;
                                    //goto A;
                                }
                                else
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[icolumn + 1, irow];
                                    if (grdGrnlist.CurrentCell.ReadOnly == true)
                                    {
                                        icolumn++; goto A;
                                    }

                                }
                            }
                            else
                            {
                                grdGrnlist.CurrentCell = grdGrnlist[icolumn + 1, irow];
                                if (grdGrnlist.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                            }
                        }
                        else
                        {
                        A: if (icolumn == grdGrnlist.Columns.Count - 1)
                            {
                                //grdProDetails.Rows.Add();
                                if (irow < grdGrnlist.Rows.Count - 1)
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[1, irow + 1];
                                    icolumn = grdGrnlist.CurrentCell.ColumnIndex;
                                    irow = grdGrnlist.CurrentCell.RowIndex;
                                    //goto A;
                                }
                                else
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[icolumn + 1, irow];
                                    if (grdGrnlist.CurrentCell.ReadOnly == true)
                                    {
                                        icolumn++; goto A;
                                    }

                                }
                            }
                            else
                            {
                                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmBatchno")
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[6, irow + 1];
                                    if (grdGrnlist.CurrentCell.ReadOnly==false)
                                    {
                                        grdGrnlist.CurrentCell = grdGrnlist[6, irow + 1];
                                    }
                                    else if (grdGrnlist[7, irow + 1].ReadOnly == false)
                                    {
                                        grdGrnlist.CurrentCell = grdGrnlist[7, irow + 1];
                                    }
                                    else
                                    {
                                        grdGrnlist.CurrentCell = grdGrnlist[9, irow + 1];

                                    }
                                    icolumn = grdGrnlist.CurrentCell.ColumnIndex;
                                    irow = grdGrnlist.CurrentCell.RowIndex;
                                }
                                else if (grdGrnlist[icolumn + 1, irow].Visible == false)
                                {
                                    { icolumn++; goto A; }
                                }
                                else
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[icolumn + 1, irow];
                                    if (grdGrnlist.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                                }
                                
                            }
                        }
                        //A: if (icolumn == grdProDetails.Columns.Count - 1)
                        //{
                        //    //grdProDetails.Rows.Add();
                        //    if (irow < grdProDetails.Rows.Count - 1)
                        //    {
                        //        grdProDetails.CurrentCell = grdProDetails[1, irow + 1];
                        //        icolumn = grdProDetails.CurrentCell.ColumnIndex;
                        //        irow = grdProDetails.CurrentCell.RowIndex;
                        //        goto A;
                        //    }
                        //    else
                        //    {
                        //        grdProDetails.CurrentCell = grdProDetails[icolumn + 1, irow];
                        //        if (grdProDetails.CurrentCell.ReadOnly == true)
                        //        {
                        //            icolumn++; goto A;
                        //        }

                        //    }
                        //}
                        //else
                        //{
                        //    grdProDetails.CurrentCell = grdProDetails[icolumn + 1, irow];
                        //    if (grdProDetails.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                        //}

                        grid_flag = 0;
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            //// below is for escape key return
            //return base.ProcessCmdKey(ref msg, keyData);
            // below is for enter key return
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
