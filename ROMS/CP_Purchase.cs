using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_Purchase : Form
    {
        DataTable dtTaxTable = new DataTable();
        DataTable dtRefresh = new DataTable();
        public DataTable dtPurchaseAutoComplete = new DataTable();
        DataTable dtProductDetails = new DataTable();
        DateTime varmaxdate;
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpconcern = new ToolTip();
        ToolTip tpInvoice = new ToolTip();
        ToolTip tpDiscountPer = new ToolTip();
        ToolTip tpbatchno = new ToolTip();
        ToolTip tpProduct = new ToolTip();
        ToolTip tpdate = new ToolTip();
        ToolTip tpRack = new ToolTip();
        ToolTip tpStockLocation = new ToolTip();
        ToolTip tpSuppliername = new ToolTip();
        ToolTip tpQRCode = new ToolTip();
        ToolTip tpinvamt = new ToolTip();
        ToolTip tpInvNo = new ToolTip();
        ToolTip tpEntryType = new ToolTip();
        ToolTip tpmrp = new ToolTip();
        ToolTip tpInvoiceQty = new ToolTip();
        ToolTip tpReason = new ToolTip();
        int flag = 0;
        public bool skipValidation = false;
        public DataTable objDtProductCondition = new DataTable();
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public string varPurchaseRate = "0", varcomid = "0", pbPONO = "0", pbPurchaseno = "0", pbDCNo = "0", pbGRNNo = "0", PbSTS = "0", PbID = "0", PbFlag = "0";
        public bool VarSearchFlag = true;
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = ""
        , varorderSaleQty = "", varorderqty = "", addproductid = "", varunitid = "0", varDamage = "0", varReturnDC = "0", pbGRNId = "0", pbSupplierId = "0", dcid = "0",
        varenablefalg = "0", varUserID = "0", varflag = "0", varExpiryDate = "", varExpiryDateAdd = "", varTName = "", varexp = "", pbScheduleId = "0", pbPOIdS = "0", varTempExpiryDate = "0", varProExpiryDate = "0",
        varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0", varBatchNo = "0", varNewFlag = "0", VarGridError = "0", PurchaseDcIds = "0", varTypeErrId = "0";
        public decimal PbDiscamt = 0, PbTaxvalue = 0, PbGstamt = 0, PbCGstamt = 0, PbSGstamt = 0, PbIGstamt = 0, PbNetamt = 0, pbDiffQty = 0, pbDisper = 0, PbDicountValue = 0;
        public int varGrnId = 0, varCloseflag = 0, pbDateflag = 0, varShelflife = 0, expirydateFlag = 0, varErrorFormat = 0, varcount = 0, varErroronGrid = 0, varExpiryError = 0, shelfLifeError = 0, InvoiceAmountErr = 0,  VarPrevSupplierid = 0, varModifiedFlag = 0, varDecimal = 0, varQueueFlag = 0, varRMFlag = 0, varRemarkCount = 0, varRemarkFlag = 0, varerrFlag = 0, varHSNid = 0;
        public string pbQRCode = "";
        public int varClose = 0, varDateChange = 0, varCloseFalg = 0, varEntryTypeRefresh = 0, varUpDownKey = 0, varcount1 = 0, varCount2 = 0, flagSave = 0, varTabFlag = 0, varEntryType = 0;
        bool varVoucherSkip = false;
        public int grid_flag = 0, varEditProAdd = 0, varEditFlag = 0, varQuantityErr = 0, varDiscountErr = 0, PbApprovalStsid = 0, varPurEditFlag = 0, varDiscountFlag = 0,
            varSupplierType = 0, pbRefreshFlag = 0, pbConcernTin = 0, pbSupplierTin = 0, varTinFlag = 0;
        public decimal varDiscountPer = 0, varDiscountAmount = 0, pbCostingRate = 0;
        public string varCalculator = "0", varGRNPaymentType = "0";
        public string varPrMRP = "", varPrDate = "", varPrMonth = "", varPrYear = "", varPrLocation = "", varPrRack = "", varPrBatch = "", varPrInvFlag = "",
            varPrslid = "0", varPrRkid = "0", varGRNProCount = "0", varId = "0", varPrid = "0", varPrMRPFlag = "0", varGRNProType = "0", varGrnType = "0", varProductMRP = "0", varProductBatch = "", varProductExpiry = "";
        public int varPOdropdownFlag = 0, varPrCountFlag = 0, varPrCount = 0, varEntryTypeViewFlag = 0, varRMProductionFlag = 0;
        public string varGRNDate = "", varVoucherDate = "", varDCDate = "";
        public int tallyFlag = 0, varUnApproveFlag = 0;
        private Timer timer;
        public string varProducts = "", varEntryTypeDate = "", varGSTIN = "";
        List<int> varProductsIDs = new List<int>();
        public int varAutocompleteProduct = 0, pbPurchaseEntryUnapprovedFlag = 0, pbUnapprovePURID = 0, varGRNPRID = 0, varConvertFlag = 0, varPaymentStatus = 0;
        public string varEditPRID = "0";
        public int pbVerifiedBy1 = 0, PbVerified1 = 0, pbVerifiedBy2 = 0, PbVerified2 = 0, varShelflifeLevel1 = 0, varShelflifeLevel2 = 0;
        public string pbVerifiedOn1 = "", pbVerifiedTime1 = "", pbVerifiedFormat1 = "", pbVerifiedName1 = "", pbVerifiedOn2 = "", pbVerifiedTime2 = "", pbVerifiedFormat2 = "", pbVerifiedName2 = "", varPurVerifyFlag = "0", varPurVerifyFlag2 = "0";
        public string varBlockedSupplier = "0", varBlockedReason = "", varInwardDate = "";
        public double varDVA = 0, varCPA = 0; 
        public int pbGSTINCloseFlag = 0, pbPaymentCompletedFlag = 0;
        public string pbConditionIDs = "0", pbCondition = "";
        public int varLPFlag = 0, varNoDiffFlag = 0, varExpDateValidFlag = 0,MA_ReasonFlag=0, varProValidation = 0, varReasonFlag = 0;
        public CP_Purchase()
        {
            InitializeComponent();
            //Timer ticked after 2 seconds, so load the other form
            timer = new Timer();
            timer.Interval = 2; // 2 seconds
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }
        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                errPurchaseentry.Clear();
                DGV_FilterProduct.Visible = false;
                txtProductName.Text = "";
                udfnrowclear();
                if (pbPurchaseno == "0")
                {
                    grdSupplierList.Enabled = true;
                    btnViewDataView.Visible = true;
                    txtInvoiceNo.Enabled = true;
                    txtInvoiceNo.ReadOnly = false;
                    txtInvoiceNo.Text = "";
                    txtInvoiceamt.Enabled = true;
                    txtInvoiceamt.ReadOnly = false;
                    txtInvoiceamt.Text = "";
                    txtFrightGrn.Text = "";
                    txtUnLoadingchargeGrn.Text = "";
                    if (varEntryTypeRefresh == 0)
                    {
                        dtProductDetails.Rows.Clear();
                        dtPurchaseAutoComplete.Rows.Clear();
                        grdSupplierList.Rows.Clear();
                        grdPODetails.Rows.Clear();
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "54") // GRN
                    {
                        if (PbFlag == "0")
                        {
                            if (varEntryTypeRefresh == 0)
                            { grdPODetails.Rows.Clear(); }
                            grdReurnDC.Rows.Clear();
                            udfnPODropdownload();
                            udfnPurchaseGrnLoad();
                            udfnProDetailsTolProCount();
                            udfnGRNProload();
                            grdSupplierList.Columns["clmPono"].Visible = true;
                            grdReurnDC.Rows.Clear();
                            txtQRCode.ReadOnly = false;
                            txtQRCode.Enabled = true;
                            txtGstin.Text = varGSTIN;
                            grdReurnDC.Visible = false;
                            grdPODetails.Visible = true;
                        }
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "55") // PO
                    {
                        grdReurnDC.Rows.Clear();
                        grdPODetails.Visible = true;
                        udfnPODropdownload();
                        udfnPendingPOLoad();
                        udfnProDetailsTolProCount();
                        txtQRCode.Text = "";
                        txtQRCode.ReadOnly = true;
                        txtQRCode.Enabled = false;
                        dpInvoiceDate.Enabled = true;
                        txtInvoiceNo.ReadOnly = false;
                        grdPODetails.Visible = true;
                        grdReurnDC.Visible = false;
                        grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                        grdSupplierList.Columns["clmPono"].Visible = true;
                        if (grdSupplierList.Rows.Count != 0)
                        {
                            btnClear.Enabled = true;
                        }
                        if (grdPODetails.Rows.Count != 0)
                        {
                            lblFinishedNoRecord.Visible = false;
                        }
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "56") // Direct
                    {
                        grdPODetails.Rows.Clear();
                        grdReurnDC.Rows.Clear();
                        udfnPODropdownload();
                        cmbPONo.Enabled = false;
                        cmbPONo.Text = "";
                        lblPOdropDown.Text = "";
                        grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                        grdSupplierList.Columns["clmPono"].Visible = false;
                        btnViewDataView.Visible = false;
                        txtQRCode.ReadOnly = true;
                        txtQRCode.Enabled = false;
                        txtQRCode.Text = "";
                        dpInvoiceDate.Enabled = true;
                        txtInvoiceNo.ReadOnly = false;
                        grdPODetails.Visible = true;
                        grdReurnDC.Visible = false;
                        tsbTotal.Visible = false; tsbTotal.Enabled = false;
                        tsbAdded.Visible = false; tsbAdded.Enabled = false;
                        tsbPO.Visible = false; tsbPO.Enabled = false;
                        tsbTotalProducts.Visible = false; tsbRemainingProduct.Visible = false; tsbAddedProduct.Visible = false;
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                    {
                        if (PbFlag == "0")
                        {
                            grdPODetails.Rows.Clear();
                            udfnPODropdownload();
                            udfnPurchaseDC();
                            udfnProDetailsTolProCount();
                            grdPODetails.Visible = false;
                            grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                            grdSupplierList.Columns["clmPono"].Visible = true;
                            txtQRCode.Text = "";
                            txtQRCode.ReadOnly = true;
                            txtQRCode.Enabled = false;
                            grdReurnDC.Visible = true;
                            if (grdSupplierList.Rows.Count != 0)
                            {
                                btnClear.Enabled = true;
                            }
                            if (grdReurnDC.Rows.Count != 0)
                            {
                                lblFinishedNoRecord.Visible = false;
                            }
                        }
                    }
                    grdSupplierList.Enabled = true; 
                }
                if (varEntryTypeViewFlag == 1 || varQueueFlag == 1)
                {
                    udfnProDetailsTolProCount();
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count);
                udfnVerifyEnable();
                if (Convert.ToString(cmbEntryType.SelectedValue) == "57")
                {   btnConditions.Enabled = false; }
                if (Convert.ToString(cmbEntryType.SelectedValue) == "55" || Convert.ToString(cmbEntryType.SelectedValue) == "56")
                { cmbTransactionType.Enabled = true; }
                else { cmbTransactionType.Enabled = false; cmbTransactionType.SelectedValue = 58; }
            }
        }
        public void udfnConditionEnable()
        {
            try
            {
                pbCondition = ""; pbConditionIDs = "";
                if (Convert.ToString(cmbPONo.SelectedValue) == "220") //Against dc
                {
                    btnConditions.Enabled = false;  
                    var result = (grdConditions.DataSource as DataTable).AsEnumerable()
                        .Where(r=>r.Field<int>("ConditionID") == 275)  // Filter where clmCheck is true
                        .Select(r => new
                        {
                            ConditionId = r["ConditionID"],
                            ConditionName = r["ConditionShortName"]
                        })
                        .ToList();
                    pbConditionIDs = string.Join(",", result.Select(r => r.ConditionId.ToString()));
                    pbCondition = string.Join(",", result.Select(r => r.ConditionName));
                    cmbReason.SelectedValue = 286;
                    cmbReason.Enabled = false;
                }
                else
                {
                    btnConditions.Enabled = true;
                    cmbReason.SelectedValue = 286;
                    cmbReason.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVerifyEnable()
        {
            try
            {
                if (Convert.ToString(cmbEntryType.SelectedValue) == "55" || Convert.ToString(cmbEntryType.SelectedValue) == "56") //Direct and against PO
                { btnVerified.Enabled = true; }
                else
                { btnVerified.Enabled = false; }
                if (Convert.ToString(cmbEntryType.SelectedValue) == "54")//GRN
                {
                    grpGRNloadingUnloading.Enabled = true;
                }
                else { grpGRNloadingUnloading.Enabled = false; }
                if (Convert.ToString(cmbEntryType.SelectedValue) == "57") //DC
                {
                    btnConditions.Enabled = false; txtMismatchQty.Enabled = false;
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
                if (Convert.ToString(cmbEntryType.SelectedValue) == "54")//GRN
                {
                    varFlag = 1;
                    if (varQueueFlag == 1)
                    { varID = PbID; }
                    else { varID = pbGRNNo; }
                }
                else if (Convert.ToString(cmbEntryType.SelectedValue) == "55")//po
                {
                    varFlag = 0;
                    varID = pbPONO;
                }
                else if (Convert.ToString(cmbEntryType.SelectedValue) == "57") //DC
                {
                    varFlag = 2;
                    if (varQueueFlag == 1)
                    { varID = PbID; }
                    else { varID = pbDCNo; }
                }
                dtProductDetails = null;
                dtProductDetails = new DataTable();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 15;
                objTRN_PurchaseEntry.paraType = varFlag;
                objTRN_PurchaseEntry.ParaIds = varID;
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                dtProductDetails = objDs.Tables[0];
                if (varFlag == 0)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            tsbTotalProducts.Text = Convert.ToString(objDs.Tables[1].Rows[0]["ProductCount"]);
                            tsbRemainingProduct.Text = Convert.ToString(objDs.Tables[1].Rows[0]["ProductCount"]);
                        }
                    }
                }
                else
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            tsbTotalProducts.Text = Convert.ToString(objDs.Tables[1].Rows[0]["ProductCount"]);
                            tsbRemainingProduct.Text = Convert.ToString(objDs.Tables[1].Rows[0]["ProductCount"]);
                        }
                    }
                }
                if (Convert.ToString(cmbEntryType.SelectedValue) == "57")
                {
                    if (objDs.Tables[2].Rows.Count != 0)
                    {
                        varDCDate = Convert.ToString(objDs.Tables[2].Rows[0]["DC Date"]);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductDetails()
        {
            try
            {
                int varFlag = 0; string varID = "0";
                if (Convert.ToString(cmbEntryType.SelectedValue) == "54")//GRN
                {
                    varFlag = 1;
                    varID = pbGRNNo;
                }
                else if (Convert.ToString(cmbEntryType.SelectedValue) == "55")//po
                {
                    varFlag = 0;
                    varID = pbPONO;
                }
                else if (Convert.ToString(cmbEntryType.SelectedValue) == "57") //DC
                {
                    varFlag = 2; varID = pbDCNo;
                }
                dtProductDetails = null;
                dtProductDetails = new DataTable();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 15;
                objTRN_PurchaseEntry.paraType = varFlag;
                objTRN_PurchaseEntry.ParaIds = varID;
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                dtProductDetails = objDs.Tables[0];
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefReturnDc()
        {
            try
            {
                if (pbDCNo != "0")
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 2;
                    objTRN_PurchaseEntry.ParaIds = pbDCNo;
                    objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();
                    grdSupplierList.Rows.Clear();

                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            lblNoRecordsFound.Visible = false;
                            string varMRP = "";
                            if (Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_MRP"]) == "0")
                            {
                                varMRP = "";
                            }
                            else
                            {
                                varMRP = Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_MRP"]);
                            }
                            if (Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_Expirydate"]) != "")
                            {
                                string varTempYear = "0";
                                object cellValue = objDs.Tables[0].Rows[i]["GRNPR_Expirydate"].ToString();
                                string varExpiryDate = "";
                                varExpiryDate = cellValue.ToString();
                                string[] DMY = varExpiryDate.Split('/');
                                if (DMY.Count() == 3)
                                {
                                    varTempYear = DMY[2];
                                    if (varTempYear.Length == 4)
                                    {
                                        int year = Convert.ToInt32(varTempYear) - 2000;
                                        cellValue = DMY[0] + "/" + DMY[1] + "/" + year;
                                    }
                                }
                                varTempExpiryDate = cellValue.ToString();
                            }
                            else
                            {
                                varTempExpiryDate = "";
                            }
                            grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, "None",
                            Convert.ToString(objDs.Tables[0].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[0].Rows[i]["PTNAME"]), Convert.ToString(objDs.Tables[0].Rows[i]["UNIT"]), varMRP, varMRP,
                            Convert.ToString(varTempExpiryDate), Convert.ToString(objDs.Tables[0].Rows[i]["PRODUCTEXP"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["Location"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["RKNAME"]),
                            "0", Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[0].Rows[i]["BATCHNO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Batchnogeneration"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_ShelfLife"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RackCount"])
                            , Convert.ToString(objDs.Tables[0].Rows[i]["DCID"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["TotQty"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["GRNQty"])
                            , Convert.ToDecimal(objDs.Tables[0].Rows[i]["DCQty"]), Convert.ToInt16(objDs.Tables[0].Rows[i]["DCPRID"]), 0, Convert.ToInt16(objDs.Tables[0].Rows[i]["DCPRID"]),
                            Convert.ToInt16(objDs.Tables[0].Rows[i]["InvFlag"]), Convert.ToString(objDs.Tables[0].Rows[i]["HSNID"]));
                            grdSupplierList.Columns["clmProTname"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                            ((DataGridViewImageCell)grdSupplierList.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
                            DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
                            grdSupplierList.Enabled = true;
                            if (Convert.ToInt16(objDs.Tables[0].Rows[i]["InvFlag"]) == 1 )
                            {
                                grdSupplierList.Rows[i].ReadOnly = true;
                            }
                            else
                            {
                                grdSupplierList.Rows[i].ReadOnly = false;
                            }
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count); }
        }
        public void udfnDefGrnGridLoad()
        {
            try
            {
                if (pbPONO != "0")
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 0;
                    objTRN_PurchaseEntry.ParaIds = pbPONO;
                    objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();
                    grdSupplierList.Rows.Clear();

                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            lblNoRecordsFound.Visible = false;
                            string varMRP = "";
                            if (Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_MRP"]) == "0")
                            {
                                varMRP = "";
                            }
                            else
                            {
                                varMRP = Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_MRP"]);
                            }
                            if (Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_Expirydate"]) != "")
                            {
                                string varTempYear = "0";
                                object cellValue = objDs.Tables[0].Rows[i]["GRNPR_Expirydate"].ToString();
                                string varExpiryDate = "";
                                varExpiryDate = cellValue.ToString();
                                string[] DMY = varExpiryDate.Split('/');
                                if (DMY.Count() == 3)
                                {
                                    varTempYear = DMY[2];
                                    if (varTempYear.Length == 4)
                                    {
                                        int year = Convert.ToInt32(varTempYear) - 2000;
                                        cellValue = DMY[0] + "/" + DMY[1] + "/" + year;
                                    }
                                }
                                varTempExpiryDate = cellValue.ToString();
                            }
                            else
                            {
                                varTempExpiryDate = "";
                            }
                            grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, Convert.ToString(objDs.Tables[0].Rows[i]["PONO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[0].Rows[i]["PTNAME"]), Convert.ToString(objDs.Tables[0].Rows[i]["UNIT"]), varMRP, varMRP,
                            Convert.ToString(varTempExpiryDate), Convert.ToString(objDs.Tables[0].Rows[i]["PRODUCTEXP"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["Location"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["RKNAME"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["POID"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[0].Rows[i]["BATCHNO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Batchnogeneration"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_ShelfLife"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RackCount"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["POID"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["TotQty"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["GRNQty"])
                            , Convert.ToDecimal(objDs.Tables[0].Rows[i]["DCQty"]), 0, 0, Convert.ToInt16(objDs.Tables[0].Rows[i]["POPRID"]), 0, Convert.ToString(objDs.Tables[0].Rows[i]["HSNID"]));
                            grdSupplierList.Columns["clmProTname"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                            ((DataGridViewImageCell)grdSupplierList.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
                            DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count); }
        }
        public void udfnDisableDiscount()
        {
            txtLoadingCharge.Enabled = false;
            txtUnLoadingCharge.Enabled = false;
            txtCouriercharge.Enabled = false;
            txtotherexpense.Enabled = false;
            txtTcsamt.Enabled = false;
            txtUnLoadingchargeGrn.Enabled = false;
            txtFrightGrn.Enabled = false;
            Txtdiscount.Enabled = false;
            txtDiscountamt.Enabled = false;
            txtOtherdiscount.Enabled = false;
            txtDamagecost.Enabled = false;
            if (Convert.ToString(cmbEntryType.SelectedValue) == "54")
            {
                txtUnLoadingchargeGrn.Enabled = true;
                txtFrightGrn.Enabled = true;
            }
        }
        public void udfnPendingPOLoad()
        {
            try
            {
                for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                {
                    if (pbPONO == "0")
                    {
                        pbPONO = Convert.ToString(grdSupplierList.Rows[i].Cells["clmTransId"].Value);
                    }
                    else
                    {
                        pbPONO = pbPONO + ',' + Convert.ToString(grdSupplierList.Rows[i].Cells["clmTransId"].Value);
                    }
                }
                MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                MainForm.objPUR_GRNOrderType.varMasterType = 2;
                MainForm.objPUR_GRNOrderType.ShowDialog();
                varTypeErrId = pbPONO;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurchaseDC()
        {
            try
            {
                for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                {
                    if (pbDCNo == "0")
                    {
                        pbDCNo = Convert.ToString(grdReurnDC.Rows[i].Cells["ID"].Value);
                    }
                    else
                    {
                        pbDCNo = pbDCNo + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["ID"].Value);
                    }
                }
                MainForm.objPUR_DCDeatils = new PUR_DCDeatils();
                MainForm.objPUR_DCDeatils.ShowDialog();
                varTypeErrId = pbDCNo;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurchaseGrnLoad()
        {
            try
            {
                if (grdSupplierList.Rows.Count != 0)
                {
                    pbGRNNo = Convert.ToString(grdSupplierList.Rows[0].Cells["clmTransId"].Value);
                }
                MainForm.objPUR_Purchase_GRNDetails = new PUR_Purchase_GRNDetails();
                MainForm.objPUR_Purchase_GRNDetails.ShowDialog();
                txtQRCode.Text = pbQRCode;
                varTypeErrId = pbGRNNo;
                if (pbGRNNo != "0")
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 11;
                    objTRN_PurchaseEntry.ParaIds = pbGRNNo;
                    objTRN_PurchaseEntry.paraType = Convert.ToInt32(PbFlag);
                    objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();

                    if (objDs.Tables[0].Rows.Count != 0) //  PO DETAILS LOAD
                    {
                        grdPODetails.Rows.Clear();
                        lblPOnorecord.Visible = false;
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            grdPODetails.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["PO_No"]), Convert.ToString(objDs.Tables[0].Rows[i]["PO_Date"]),
                                Convert.ToString(objDs.Tables[0].Rows[i]["POPR_PRID"]), Convert.ToString(objDs.Tables[0].Rows[i]["POID"]));
                        }
                        grdPODetails.Columns["clmRemovePO"].Visible = false;
                    }
                    if (objDs.Tables[2].Rows.Count != 0) //  GRN DETAILS LOAD
                    {
                        grdGRN.Rows.Clear();
                        grdGRN.Visible = true;
                        lblFinishedNoRecord.Visible = false;
                        for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                        {
                            grdGRN.Rows.Add(Convert.ToString(objDs.Tables[2].Rows[i]["GRN_No"]), Convert.ToString(objDs.Tables[2].Rows[i]["GRN_Date"]),
                                Convert.ToString(objDs.Tables[2].Rows[i]["GRNPRID"]), Convert.ToString(objDs.Tables[2].Rows[i]["GRNID"]));
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
        public void udfnGRNProload()
        {
            try
            {
                if (pbGRNNo != "0")
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 3;
                    objTRN_PurchaseEntry.ParaIds = pbGRNNo;
                    objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();
                    grdSupplierList.Rows.Clear();
                    grdPODetails.Rows.Clear();
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        txtInvoiceNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Invno"]);
                        txtInvoiceamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["invamt"]);
                        txtUnLoadingchargeGrn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_FrieghtCharges"]);
                        txtFrightGrn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_UnloadingCharges"]);
                        varGRNPaymentType = Convert.ToString(objDs.Tables[0].Rows[0]["PaymentType"]);
                        txtQRCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN Code"]);
                        if (Convert.ToInt32(cmbEntryType.SelectedValue) == 54)
                        {
                            dpInvoiceDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceDate"]);
                            varGRNDate = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Date"]);
                        }
                        if (varGRNPaymentType == "199" || varGRNPaymentType == "200") //199- NONE,200-  GRN cash issued
                        {
                            rbPurchaseCash.Checked = true;
                            rbPaymentCash.Checked = true;
                        }
                        if (varGRNPaymentType == "201")  //Cheque issued
                        {
                            rbPurchaseCredit.Checked = true;
                            rbPaymentCheque.Checked = true;
                        }
                        if (varGRNPaymentType == "199") //None
                        {
                            gpPurchase.Enabled = true;
                            gpPayment.Enabled = true;
                        }
                        else
                        {
                            gpPurchase.Enabled = false;
                            gpPayment.Enabled = false;
                        }
                        if (Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "45" || Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "46")
                        {
                            grdSupplierList.Enabled = false;
                        }
                        else
                        {
                            grdSupplierList.Enabled = true;
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                    if (objDs.Tables[1].Rows.Count != 0)
                    {
                        for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                        {
                            lblFinishedNoRecord.Visible = false;
                            grdPODetails.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["PO_No"]), Convert.ToString(objDs.Tables[1].Rows[i]["PO_Date"]),
                            Convert.ToString(objDs.Tables[1].Rows[i]["Procount"]), Convert.ToString(objDs.Tables[1].Rows[i]["POID"]));
                        }
                    }

                    if (objDs.Tables[2].Rows.Count != 0)
                    {
                        lblVerifyDateTime.Text = Convert.ToString(objDs.Tables[2].Rows[0]["VERIFIED1"]);
                        lblGRNNoRecord.Visible = false;
                    }
                    if (objDs.Tables[3].Rows.Count != 0)
                    {
                        lblVerifyDateTime2.Text = Convert.ToString(objDs.Tables[3].Rows[0]["VERIFIED2"]);
                        lblGRNNoRecord.Visible = false;
                    }
                    if (objDs.Tables[4].Rows.Count != 0)
                    {
                        lblFinishedNoRecord.Visible = false;
                        grdGRN.Rows.Clear();
                        for (int i = 0; i < objDs.Tables[4].Rows.Count; i++)
                        {
                            grdGRN.Rows.Add(Convert.ToString(objDs.Tables[4].Rows[i]["GRN_Date"]), Convert.ToString(objDs.Tables[4].Rows[i]["GRN_No"]),
                                Convert.ToString(objDs.Tables[4].Rows[i]["Procount"]), Convert.ToString(objDs.Tables[4].Rows[i]["GRNID"]));
                        }
                        varGRNDate = Convert.ToString(objDs.Tables[4].Rows[0]["GRN_Date"]);
                    }
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
                    if (varClose == 0)
                    {
                        if (varCloseflag == 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                pbGSTINCloseFlag = 1;
                                this.Close();
                            }
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    if (varQueueFlag == 1)
                    {
                        MainForm.objPUR_PurchaseQueue.udfnDate();
                        MainForm.objPUR_PurchaseQueue.udfnList();
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
        private void BtnDamage_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamagedView = new PUR_PODamagedView();
                MainForm.objPUR_PODamagedView.varMasterType = "5";
                MainForm.objPUR_PODamagedView.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRemark()
        {
            try
            {
                string varID = "0";
                int varflag = 0;
                if (Convert.ToInt32(cmbEntryType.SelectedValue) == 54) //grn
                {
                    varflag = 54;
                    varID = pbGRNNo;
                }
                else if (Convert.ToInt32(cmbEntryType.SelectedValue) == 55) //PO
                {
                    varflag = 55;
                    varID = pbPONO;
                }
                else if (Convert.ToInt32(cmbEntryType.SelectedValue) == 57) //DC
                {
                    varflag = 57;
                    varID = pbDCNo;
                }
                else if (Convert.ToInt32(cmbEntryType.SelectedValue) == 56) //Direct
                {
                    varflag = 56;
                }
                MainForm.objPUR_PurchaseRemarksHistory = new PUR_PurchaseRemarksHistory();
                MainForm.objPUR_PurchaseRemarksHistory.varID = Convert.ToInt32(varID);
                MainForm.objPUR_PurchaseRemarksHistory.varRemarkFlag = Convert.ToInt32(varflag);
                MainForm.objPUR_PurchaseRemarksHistory.varPurchaseID = Convert.ToInt32(pbPurchaseno);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnRemarks_Click(object sender, EventArgs e)
        {
            try
            {
                udfnRemark();
                MainForm.objPUR_PurchaseRemarksHistory.ShowDialog();
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
                udfnProMasterOpen();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProMasterOpen()
        {
            try
            {
                MainForm.objCP_Items = new CP_Product();
                MainForm.objCP_Items.varMasterType = "1";
                MainForm.objCP_Items.ShowDialog();
                udfnNewProductadd();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
        public void udfnRefreshTable()
        {
            try
            {
                dtRefresh = new DataTable();
                dtRefresh.Columns.Add("PURPR_PRID", typeof(int));
                dtRefresh.Columns.Add("PURPR_UTID", typeof(int));
                dtRefresh.Columns.Add("PURPR_InvoiceMRP", typeof(decimal));
                dtRefresh.Columns.Add("PURPR_ExpiryDate", typeof(string));
                dtRefresh.Columns.Add("PURPR_Batch", typeof(string));
                dtRefresh.Columns.Add("PURPR_BatchNoStatus", typeof(int));
                dtRefresh.Columns.Add("PURPR_BatchNoGenration", typeof(int));
                dtRefresh.Columns.Add("PURPR_ShelfLife_Flag", typeof(int));
                dtRefresh.Columns.Add("PURPR_ShelfLifevalue", typeof(float));
                dtRefresh.Columns.Add("PURPR_ShelfLifePer", typeof(decimal));
                dtRefresh.Columns.Add("ProShelfLife", typeof(float));
                dtRefresh.Columns.Add("PURPR_HSNID", typeof(int));
                dtRefresh.Columns.Add("PURPRID", typeof(int));
                dtRefresh.Columns.Add("PURPR_CGSTPer", typeof(float));
                dtRefresh.Columns.Add("PURPR_CGSTAmnt", typeof(float));
                dtRefresh.Columns.Add("PURPR_SGSTPer", typeof(float));
                dtRefresh.Columns.Add("PURPR_SGSTAmnt", typeof(float));
                dtRefresh.Columns.Add("PURPR_ISGSTPer", typeof(float));
                dtRefresh.Columns.Add("PURPR_IGSTAmnt", typeof(float));
                dtRefresh.Columns.Add("PURPR_MRPflag", typeof(int));
                dtRefresh.Columns.Add("PURPR_RMProductionFlag", typeof(int));
                dtRefresh.Columns.Add("InvFlag", typeof(int));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRefresh()
        {
            try
            {
                if (Convert.ToString(grdSupplierList.Rows.Count) != "0")
                {
                    for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                    {
                        decimal varMRP = 0, varGrnMRP = 0; decimal varShelfPer = 0; varTempExpiryDate = ""; int varConvertProduct = 0;
                        int Shelflifevalue = 0, ProShelflife = 0, POno = 0; string[] varShelflifevaluesplit; string[] varShelflifeper; string[] varProShelfLife;

                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmMRP"].Value) != "")
                        {
                            varMRP = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmMRP"].Value);
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmGrnMrp"].Value) != "")
                        {
                            varGrnMRP = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmGrnMrp"].Value);
                        }
                        varTempExpiryDate = "0";
                        string varTempYear = "0";
                        object cellValue = Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value);
                        string varExpiryDate = "";
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
                        varTempExpiryDate = cellValue.ToString(); 
                        int varPURPRID = 0;
                        int varProductId = 0;  // dc or grn or po- product id
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmPURPRIDDetail"].Value) != "" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmPURPRIDDetail"].Value) != "0")
                        {
                            varPURPRID = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmPURPRIDDetail"].Value);
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmProductID"].Value) != "" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmProductID"].Value) != "0")
                        {
                            varProductId = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmProductID"].Value);
                        }
                        dtRefresh.Rows.Add(Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmProid"].Value),
                                Convert.ToInt32(grdSupplierList.Rows[i].Cells["UTID"].Value),
                                varMRP, Convert.ToString(varTempExpiryDate)
                                , Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchno"].Value), Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value),
                                 Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value), Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmShelflifeenable"].Value),
                                 Shelflifevalue, varShelfPer, ProShelflife,
                                 Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmHSNid"].Value), varPURPRID,
                                0, 0, 0, 0, 0, 0, Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmMrpFlag"].Value),
                                Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmRMFlag"].Value), 0);
                    }
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 17;
                    objTRN_PurchaseEntry.ParaPurchaseRefresh = dtRefresh;
                    objTRN_PurchaseEntry.paraDate = Convert.ToString(dpVoucherDate.Text);
                    objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();
                    for (int i = 0; i < grdSupplierList.RowCount; i++)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdSupplierList.Rows[i].Cells["UTID"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_UTID"]);
                            grdSupplierList.Rows[i].Cells["clmMRP"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_InvoiceMRP"]);
                            grdSupplierList.Rows[i].Cells["clmexpirydate"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_ExpiryDate"]);
                            grdSupplierList.Rows[i].Cells["clmBatchno"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_Batch"]);
                            grdSupplierList.Rows[i].Cells["clmBatchenable"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_BatchNoStatus"]);
                            grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_BatchNoGenration"]);
                            grdSupplierList.Rows[i].Cells["clmShelflifeenable"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_ShelfLife_Flag"]);
                            grdSupplierList.Rows[i].Cells["clmShelflife"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_ShelfLifeValue"]);
                            grdSupplierList.Rows[i].Cells["clmshelfper"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_ShelfLifePer"]);
                            grdSupplierList.Rows[i].Cells["clmactuallife"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["ProShelLife"]);
                            grdSupplierList.Rows[i].Cells["clmHSNid"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_HSNID"]);
                            grdSupplierList.Rows[i].Cells["clmMrpFlag"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_MRPflag"]);
                            grdSupplierList.Rows[i].Cells["clmRMFlag"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_RMProductionFlag"]);
                        }
                    }
                    DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                    GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void CP_Purchase_Load(object sender, EventArgs e)
        {
            try
            {
                lblDPercentage.Text = "< " + Convert.ToString(MainForm.pbShelflifeLevel1) + "%";
                lblPercentage.Text = "< " + Convert.ToString(MainForm.pbShelflifeLevel2) + "%";
                varShelflifeLevel1 = Convert.ToInt32(MainForm.pbShelflifeLevel1);
                varShelflifeLevel2 = Convert.ToInt32(MainForm.pbShelflifeLevel2);
                MainForm objMainForm = new MainForm();
                dtTaxTable = new DataTable();
                udfnRefreshTable();
                udfnGeneralSettingsList();
                objMainForm.udfnGetDefaultCompany();
                dtTaxTable.Columns.Add("GST%", typeof(string));
                dtTaxTable.Columns.Add("Taxable Value", typeof(decimal));
                dtTaxTable.Columns.Add("Tax Value", typeof(decimal));
                dtTaxTable.Columns.Add("IGST%", typeof(string));
                dtTaxTable.Columns.Add("IGST", typeof(decimal));
                dtTaxTable.Columns.Add("SGST%", typeof(string));
                dtTaxTable.Columns.Add("SGST", typeof(decimal));
                dtTaxTable.Columns.Add("CGST%", typeof(string));
                dtTaxTable.Columns.Add("CGST", typeof(decimal));
                udfnDropdownLoad();
                udfnDtProductAutocomplte();
                tsbTotalProducts.ForeColor = Color.Blue;
                if (pbPurchaseno == "0")
                {
                    cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                    DateTime varmindate = MainForm.pbCurrentDate; 
                    dpVoucherDate.MaxDate = varmindate;
                    dpVoucherDate.Text = Convert.ToString(MainForm.pbCurrentDate);
                }
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    udfnDateset();
                    varVoucherDate = Convert.ToString(dpVoucherDate.Text);
                    udfnPODropdownload();
                    if (Convert.ToString(cmbConcern.SelectedValue) == "-1")
                    {
                        this.ActiveControl = cmbConcern;
                    }
                    else
                    {
                        this.ActiveControl = txtSupplier;
                    }
                    grdTaxDetails.DataSource = dtTaxTable;
                    grdTaxDetails.Columns["GST%"].Width = 40;
                    grdTaxDetails.Columns["Taxable Value"].Width = 80;
                    grdTaxDetails.Columns["Tax Value"].Width = 60;
                    udfnEditLoad();
                    tsbStatus.Text = lblstatusvalue.Text;
                    if ((pbPurchaseno == "0" || varPurEditFlag == 1) && varConvertFlag == 0)
                    {
                        udfnFormDisable();
                    }
                    if (varQueueFlag == 1)
                    {
                        udfnSupplierDetails();
                        cmbConcern.Enabled = false;
                        btnClear.Enabled = false;
                        txtSupplier.Enabled = false;
                        cmbEntryType.Enabled = false;
                        btnViewDataView.Enabled = false;
                        LV_Supplier.Visible = false;
                        cmbTransactionType.Enabled = false;
                        txtQRCode.ReadOnly = true;
                        txtQRCode.Enabled = false;
                        grdPODetails.Columns["clmRemovePO"].Visible = false;
                        grdReurnDC.Columns["clmRemoveDC"].Visible = false;
                        if (Convert.ToInt32(cmbEntryType.SelectedValue) == 57) //against dc
                        {
                            txtGstin.Text = "";
                        }
                        this.ActiveControl = txtInvoiceNo;
                    }
                    if (varRemarkCount == 0)
                    {
                        btnRemarks.Enabled = false;
                    }
                    else { btnRemarks.Enabled = true; }

                    if (PbSTS == "50")
                    {
                        btnSave.Text = "Update"; btnSave.Enabled = false; txtInvoiceamt.Enabled = false; txtInvoiceamt.ReadOnly = true;
                        txtInvoiceNo.Enabled = false; txtInvoiceNo.ReadOnly = true;
                    }
                    if (varConvertFlag == 1)
                    {
                        btnSave.Enabled = true;
                    }
                }
                //if (varPaymentStatus == 65) // Payment approved
                //{
                //    txtInvoiceNo.Enabled = true;
                //    txtInvoiceNo.ReadOnly = false;
                //    dpInvoiceDate.Enabled = true;
                //    btnSave.Enabled = false;
                //    txtRemarks.Enabled = false;
                //    txtRemarks.ReadOnly = true;
                //}
                if (Convert.ToString(cmbEntryType.SelectedValue) == "57")
                { btnConditions.Enabled = false; }
                if (grdSupplierList.RowCount != 0)
                { btnClear.Enabled = false; }
                if (pbPaymentCompletedFlag == 65)
                {
                    btnUnapprove.Enabled = false;
                }
                if (PbSTS == "50")
                { 
                    udfndisablevalue();
                    txtInvoiceamt.Enabled = false;txtInvoiceamt.ReadOnly = true;
                    txtInvoiceNo.Enabled = false;txtInvoiceNo.ReadOnly = true;
                }
                if(varPaymentStatus==70)
                {
                    btnSave.Enabled = true;
                }
                else if(varPaymentStatus==63)
                {
                    btnSave.Enabled = false;
                }

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
                DataSet objDs = new DataSet();
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
        public void udfnFormDisable()
        {
            try
            {
                if ((varPurEditFlag == 1 && pbPurchaseEntryUnapprovedFlag != 1) || tallyFlag == 1)
                {
                    btnSave.Enabled = false;
                    txtRemarks.Enabled = false;
                    btnDC.Enabled = false;
                    chkCompleted.Enabled = false;
                    udfndisablevalue();
                    grdSupplierList.ReadOnly = true;
                    grdPurchaseList.ReadOnly = true;
                    udfnDisableDiscount();
                    txtInvoiceamt.Enabled = false;
                    txtInvoiceamt.ReadOnly = false;
                    txtInvoiceNo.Enabled = false;
                    txtInvoiceNo.ReadOnly = false;
                    dpInvoiceDate.Enabled = false;
                    grdSupplierList.Columns["clmRemove"].Visible = false;
                }
                else
                {
                    if (PbSTS == "50")
                    {
                        udfndisablevalue();
                        udfnDisableDiscount();
                        tbDetails.TabPages[0].Enabled = true; // First tab 
                        tbDetails.TabPages[1].Enabled = true; // Second tab
                        grdPurchaseList.ReadOnly = true;
                        grdSupplierList.ReadOnly = true;
                        cmbPONo.Enabled = false;
                        txtProductName.Enabled = false;
                        txtMrp.Enabled = false;
                        txtDate.Enabled = false;
                        txtMonth.Enabled = false;
                        txtYear.Enabled = false;
                        txtInvoiceamt.Enabled = false;
                        txtInvoiceNo.Enabled = false;
                        chkCompleted.Enabled = false;
                        txtSourceLocation.Enabled = false;
                        cmbrack.Enabled = false;
                        btnAdd.Enabled = false;
                        btnClear.Enabled = false;
                        if (PbApprovalStsid == 70)  // purchase entry approved incomplete
                        {
                            grdSupplierList.ReadOnly = false;
                            grdPurchaseList.ReadOnly = false;

                            grdSupplierList.Columns["clmPicode"].ReadOnly = true;
                            grdSupplierList.Columns["clmProTname"].ReadOnly = true;
                            grdSupplierList.Columns["clmUnit"].ReadOnly = true;
                            grdSupplierList.Columns["clmGrnMrp"].ReadOnly = true;
                            grdSupplierList.Columns["clmShelflife"].ReadOnly = true;
                            grdSupplierList.Columns["clmactuallife"].ReadOnly = true;
                            grdSupplierList.Columns["clmshelfper"].ReadOnly = true;
                            grdSupplierList.Columns["clmLocation"].ReadOnly = true;
                            grdSupplierList.Columns["clmrack"].ReadOnly = true;

                            grdPurchaseList.Columns["sno"].ReadOnly = true;
                            grdPurchaseList.Columns["picode"].ReadOnly = true;
                            grdPurchaseList.Columns["clmProductName"].ReadOnly = true;
                            grdPurchaseList.Columns["clminvMRP"].ReadOnly = true;
                            grdPurchaseList.Columns["clmExpdate"].ReadOnly = true;
                            grdPurchaseList.Columns["clminvoiceBatch"].ReadOnly = true;
                            grdPurchaseList.Columns["clminvLocation"].ReadOnly = true;
                            grdPurchaseList.Columns["clminvRack"].ReadOnly = true;
                            grdPurchaseList.Columns["clmHSN"].ReadOnly = true;
                            grdPurchaseList.Columns["clmInvQty"].ReadOnly = true;
                            grdPurchaseList.Columns["clmRecqty"].ReadOnly = true;
                            grdPurchaseList.Columns["clmDiffqty"].ReadOnly = true;
                            grdPurchaseList.Columns["clmFreeqty"].ReadOnly = true;
                            grdPurchaseList.Columns["unit"].ReadOnly = true;
                            grdPurchaseList.Columns["clmPurchaseRate"].ReadOnly = true;
                            grdPurchaseList.Columns["clmDiscAmt"].ReadOnly = true;
                            grdPurchaseList.Columns["clmDiscPer"].ReadOnly = true;
                            grdPurchaseList.Columns["clmTax"].ReadOnly = true;
                            grdPurchaseList.Columns["clmGstper"].ReadOnly = true;
                            grdPurchaseList.Columns["clmGstamt"].ReadOnly = true;
                            grdPurchaseList.Columns["clmCGST"].ReadOnly = true;
                            grdPurchaseList.Columns["clmCGSTamt"].ReadOnly = true;
                            grdPurchaseList.Columns["clmSGST"].ReadOnly = true;
                            grdPurchaseList.Columns["clmSGSTamt"].ReadOnly = true;
                            grdPurchaseList.Columns["clmIGST"].ReadOnly = true;
                            grdPurchaseList.Columns["clmIGSTamt"].ReadOnly = true;
                            grdPurchaseList.Columns["clmDiscountValue"].ReadOnly = true;
                            grdPurchaseList.Columns["clmnetamt"].ReadOnly = true;
                            grdPurchaseList.Columns["clmCosting"].ReadOnly = true;
                            grdPurchaseList.Columns["clmHSNCode"].ReadOnly = true;
                            grdPurchaseList.Columns["clmHSNGST"].ReadOnly = true;
                        }
                    }

                    if (pbPurchaseEntryUnapprovedFlag == 1) // unapprove
                    {
                        udfndisablevalue();
                        btnSave.Visible = false;
                        btnUnapprove.Visible = true;
                        txtRemarks.Enabled = true;
                        txtRemarks.ReadOnly = false;
                        tbDetails.TabPages[0].Enabled = true;
                        tbDetails.TabPages[1].Enabled = true;
                        tbDetails.TabPages[2].Enabled = false;
                        grdSupplierList.ReadOnly = true;
                        grdPurchaseList.ReadOnly = true;
                        btnClear.Enabled = false;
                        txtInvoiceamt.ReadOnly = true; txtInvoiceamt.Enabled = false;
                        txtInvoiceNo.ReadOnly = true; txtInvoiceNo.Enabled = false;
                        grdSupplierList.Columns["clmRemove"].Visible = false;
                        tspHeader.Text = "Purchase Entry - Unapprove";
                    }
                    if (PbSTS == "49")
                    {
                        udfndisablevalue();
                    }
                    if (varConvertFlag == 1)
                    { btnSave.Enabled = true; }
                }
                if (varConvertFlag == 1)
                {
                    udfndisablevalue();
                    grdSupplierList.ReadOnly = false;
                    grdPurchaseList.ReadOnly = false;
                    grdPurchaseList.Enabled = true;
                    grdPurchaseList.Enabled = true;

                    grdSupplierList.Columns["clmPicode"].ReadOnly = true;
                    grdSupplierList.Columns["clmProTname"].ReadOnly = true;
                    grdSupplierList.Columns["clmUnit"].ReadOnly = true;
                    grdSupplierList.Columns["clmGrnMrp"].ReadOnly = true;
                    grdSupplierList.Columns["clmShelflife"].ReadOnly = true;
                    grdSupplierList.Columns["clmactuallife"].ReadOnly = true;
                    grdSupplierList.Columns["clmshelfper"].ReadOnly = true;
                    grdSupplierList.Columns["clmLocation"].ReadOnly = true;
                    grdSupplierList.Columns["clmrack"].ReadOnly = true;

                    grdPurchaseList.Columns["sno"].ReadOnly = true;
                    grdPurchaseList.Columns["picode"].ReadOnly = true;
                    grdPurchaseList.Columns["clmProductName"].ReadOnly = true;
                    grdPurchaseList.Columns["clminvMRP"].ReadOnly = true;
                    grdPurchaseList.Columns["clmExpdate"].ReadOnly = true;
                    grdPurchaseList.Columns["clminvoiceBatch"].ReadOnly = true;
                    grdPurchaseList.Columns["clminvLocation"].ReadOnly = true;
                    grdPurchaseList.Columns["clminvRack"].ReadOnly = true;
                    grdPurchaseList.Columns["clmHSN"].ReadOnly = true;
                    grdPurchaseList.Columns["clmInvQty"].ReadOnly = true;
                    grdPurchaseList.Columns["clmRecqty"].ReadOnly = true;
                    grdPurchaseList.Columns["clmDiffqty"].ReadOnly = true;
                    grdPurchaseList.Columns["clmFreeqty"].ReadOnly = true;
                    grdPurchaseList.Columns["unit"].ReadOnly = true;
                    grdPurchaseList.Columns["clmPurchaseRate"].ReadOnly = true;
                    grdPurchaseList.Columns["clmDiscAmt"].ReadOnly = true;
                    grdPurchaseList.Columns["clmDiscPer"].ReadOnly = true;
                    grdPurchaseList.Columns["clmTax"].ReadOnly = true;
                    grdPurchaseList.Columns["clmGstper"].ReadOnly = true;
                    grdPurchaseList.Columns["clmGstamt"].ReadOnly = true;
                    grdPurchaseList.Columns["clmCGST"].ReadOnly = true;
                    grdPurchaseList.Columns["clmCGSTamt"].ReadOnly = true;
                    grdPurchaseList.Columns["clmSGST"].ReadOnly = true;
                    grdPurchaseList.Columns["clmSGSTamt"].ReadOnly = true;
                    grdPurchaseList.Columns["clmIGST"].ReadOnly = true;
                    grdPurchaseList.Columns["clmIGSTamt"].ReadOnly = true;
                    grdPurchaseList.Columns["clmDiscountValue"].ReadOnly = true;
                    grdPurchaseList.Columns["clmnetamt"].ReadOnly = true;
                    grdPurchaseList.Columns["clmCosting"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                if (Convert.ToInt32(cmbEntryType.SelectedValue) != 54 && (Convert.ToInt32(cmbEntryType.SelectedValue) != -1) && varQueueFlag == 1 && varSupplierType != 32)
                {
                    udfnGSTINPopup();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGSTINPopup()
        {
            try
            {
                if (pbGSTINCloseFlag == 0)
                { 
                    MainForm.objPUR_GSTINVerify = new PUR_GSTINVerify();
                    MainForm.objPUR_GSTINVerify.pbvarSupplierCode = Convert.ToInt16(lblSupplierCode.Text);
                    MainForm.objPUR_GSTINVerify.ShowDialog();
                    txtGstin.Text = Convert.ToString(MainForm.objPUR_GSTINVerify.varGSTINText);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEditLoad()
        {
            try
            {
                if (pbPurchaseno != "0")
                {
                    dpVoucherDate.Enabled = false;
                    varEditFlag = 1;
                    varRemarkFlag = 1;
                    udfnRemark();
                    grdSupplierList.Rows.Clear();
                    MainForm.objPUR_PurchaseRemarksHistory.udfnRemarkList();
                    if (varRemarkCount == 0)
                    {
                        btnRemarks.Enabled = false;
                    }
                    if (PbSTS == "50")
                    { chkCompleted.Checked = true; }
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 6;
                    objTRN_PurchaseEntry.ParaIds = pbPurchaseno;
                    objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[5].Rows.Count != 0) //GRN DETAILS LOAD
                            {
                                lblFinishedNoRecord.Visible = false; 
                                for (int i = 0; i < objDs.Tables[5].Rows.Count; i++)
                                {
                                    grdGRN.Rows.Add(Convert.ToString(objDs.Tables[5].Rows[i]["GRN_Date"]), Convert.ToString(objDs.Tables[5].Rows[i]["GRN_No"]),
                                        Convert.ToString(objDs.Tables[5].Rows[i]["GRNPR_PRID"]), Convert.ToString(objDs.Tables[5].Rows[i]["GRNID"]));
                                }
                                txtQRCode.Text = Convert.ToString(objDs.Tables[5].Rows[0]["GRN Code"]);
                                grdGRN.Visible = true;
                                varTypeErrId = Convert.ToString(objDs.Tables[5].Rows[0]["GRNID"]);
                                pbGRNNo = Convert.ToString(objDs.Tables[5].Rows[0]["GRNID"]);
                                varGRNDate = Convert.ToString(objDs.Tables[5].Rows[0]["GRN_Date"]);
                            } 
                            if (objDs.Tables[0].Rows.Count != 0) //DETAILS LOAD
                            {
                                cmbConcern.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_COMID"]);
                                dpVoucherDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_VoucherDate"]);
                                txtPENO.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_VoucherNo"]);
                                txtSupplier.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Supplier"]);
                                lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SPID"]);
                                lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SPSCID"]);
                                cmbEntryType.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_EntryType"]);
                                dpInvoiceDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_InvoiceDate"]);
                                txtInvoiceamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_InvAmt"]);
                                txtInvoiceNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_InvoiceNo"]);
                                cmbTransactionType.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_TransactionType"]);
                                txtBroker.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Broker"]);
                                lblBrokerId.Text = Convert.ToString(objDs.Tables[0].Rows[0]["BRID"]);
                                txtGstin.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_GSTIN"]);
                                varPaymentStatus = Convert.ToInt16(objDs.Tables[0].Rows[0]["Payment Status"]);
                                varShelflifeLevel1 = Convert.ToInt32(objDs.Tables[0].Rows[0]["Level1"]);
                                varShelflifeLevel2 = Convert.ToInt32(objDs.Tables[0].Rows[0]["Level2"]);
                                PbSTS = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_STSID"]);

                                if (Convert.ToString(objDs.Tables[0].Rows[0]["PUR_Einvoice"]) == "0")
                                {
                                    chkInvoice.Checked = false;
                                }
                                else
                                {
                                    chkInvoice.Checked = true;
                                }
                                if (Convert.ToString(objDs.Tables[0].Rows[0]["PUR_PurchaseType"]) == "1")
                                {
                                    rbPurchaseCash.Checked = true;
                                }
                                else
                                {
                                    rbPurchaseCredit.Checked = true;
                                }
                                if (Convert.ToString(objDs.Tables[0].Rows[0]["PUR_PaymentType"]) == "1")
                                {
                                    rbPaymentCash.Checked = true;
                                }
                                else
                                {
                                    rbPaymentCheque.Checked = true;
                                }
                                if (Convert.ToString(objDs.Tables[0].Rows[0]["PUR_RateCalculation"]) == "1")
                                {
                                    rbRateBefore.Checked = true;
                                }
                                else
                                {
                                    rbAfterBefore.Checked = true;
                                }
                                if (Convert.ToString(objDs.Tables[0].Rows[0]["PUR_DiscCalculation"]) == "1")
                                {
                                    rbDiscountBefore.Checked = true;
                                }
                                else
                                {
                                    rbDiscountAfter.Checked = true;
                                }
                                udfnDiscountColumnHide();
                                txtLoadingCharge.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_FrieghtCharges"]);
                                txtUnLoadingCharge.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_UnloadingCharges"]);
                                txtCouriercharge.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_CourierCharges"]);
                                txtotherexpense.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_OtherExpenses"]);
                                Txtdiscount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_DiscPer"]);
                                txtDiscountamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_DiscAmnt"]);
                                txtTcsamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_TcsAmnt"]);
                                txtDamagecost.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_DamageCost"]);
                                txtOtherdiscount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_OtherDisc"]);
                                lblSubtotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_SubTotal"]);
                                lblGstamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_GSTAmnt"]);
                                lblRoundoff.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_RoundOff"]);
                                lblTotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_Total"]);
                                lblGrandTotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_GrandTotal"]);
                                txtUnLoadingchargeGrn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_FrieghtChargesGRN"]);
                                txtFrightGrn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_UnloadingChargesGRN"]);
                                txtRemarks.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_Remarks"]);
                                chkCompleted.Enabled = true;
                                udfnSupplierDetails();
                                varSupplierType = Convert.ToInt32(objDs.Tables[0].Rows[0]["PUR_SupplierType"]);
                                pbConcernTin = Convert.ToInt32(objDs.Tables[0].Rows[0]["Concern_Tin"]);
                                pbSupplierTin = Convert.ToInt32(objDs.Tables[0].Rows[0]["SP_Tin"]);
                                varBlockedSupplier = Convert.ToString(objDs.Tables[0].Rows[0]["SP_STSId"]);
                                lv_Broker.Visible = false;
                                udfnLoadingGrandTotCalculation();
                                if (Convert.ToString(cmbEntryType.SelectedValue) == "56")//Direct
                                { cmbPONo.Enabled = false; }
                            }
                            ////// tab1 load
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                lblNoRecordsFound.Visible = false;
                                btnViewDataView.Visible = false;
                                grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                                if (cmbEntryType.SelectedValue.ToString() == "54") // GRN
                                {
                                    grdGRN.Visible = true; 
                                }
                                gpPurchase.Enabled = false;
                                gpPayment.Enabled = false;
                                if (cmbEntryType.SelectedValue.ToString() == "55") // PO
                                {
                                    grdPODetails.Visible = true;
                                }
                                if (cmbEntryType.SelectedValue.ToString() == "56") // Direct
                                {
                                    grdPODetails.Visible = true;
                                    grdSupplierList.Columns["clmPono"].Visible = false;
                                }
                                if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                                {
                                    grdPODetails.Visible = false;
                                    grdReurnDC.Visible = false;
                                }
                                udfnFormDisable();
                                if (varUnApproveFlag == 1)
                                {
                                    btnUnapprove.Enabled = false;
                                }
                                for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                                {
                                    string varMRP = "",varMRP1="0";
                                    if (Convert.ToString(objDs.Tables[1].Rows[i]["GRNPR_MRP"]) == "0")
                                    {
                                        varMRP = "";
                                    }
                                    else
                                    {
                                        varMRP = Convert.ToString(objDs.Tables[1].Rows[i]["GRNPR_MRP"]);
                                        varMRP1 = (Convert.ToString(objDs.Tables[1].Rows[i]["GRNPR_MRP"]));
                                    }
                                    if (Convert.ToString(objDs.Tables[1].Rows[i]["GRNPR_Expirydate"]) != "")
                                    {
                                        string varTempYear = "0";
                                        object cellValue = objDs.Tables[1].Rows[i]["GRNPR_Expirydate"].ToString();
                                        string varExpiryDate = "";
                                        varExpiryDate = cellValue.ToString();
                                        string[] DMY = varExpiryDate.Split('/');
                                        varTempExpiryDate = cellValue.ToString();
                                    }
                                    else
                                    {
                                        varTempExpiryDate = "";
                                    }
                                    grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, null, Convert.ToString(objDs.Tables[1].Rows[i]["ProductEntryType"]), Convert.ToString(objDs.Tables[1].Rows[i]["Inward Date"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[1].Rows[i]["PTNAME"]), Convert.ToString(objDs.Tables[1].Rows[i]["UNIT"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["Condition"]),  
                                     Convert.ToString(objDs.Tables[1].Rows[i]["Mismatch Qty"]),
                                     Convert.ToString(objDs.Tables[1].Rows[i]["Return Type"]), varMRP, varMRP,
                                    Convert.ToString(objDs.Tables[1].Rows[i]["Product MRP"]), Convert.ToString(varTempExpiryDate), Convert.ToString(objDs.Tables[1].Rows[i]["Product Expiry"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRODUCTEXP"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["actuallife"]), Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["Product BatchNo"]), Convert.ToString(objDs.Tables[1].Rows[i]["Location"]),Convert.ToString(objDs.Tables[1].Rows[i]["RKNAME"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["ProductType"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["BATCHNO"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["Batchnogeneration"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLife"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RackCount"])
                                    , Convert.ToString(objDs.Tables[1].Rows[i]["GRNID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["TotQty"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GRNQty"])
                                    , Convert.ToDecimal(objDs.Tables[1].Rows[i]["DCQty"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["PURPRID"]), 0, Convert.ToInt32(objDs.Tables[1].Rows[i]["ID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["InvFlag"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["PURPR_HSNID"]), Convert.ToString(objDs.Tables[1].Rows[i]["MRP Flag"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["GRN ProType"]), Convert.ToString(objDs.Tables[1].Rows[i]["RM Flag"]), Convert.ToString(objDs.Tables[1].Rows[i]["GRN Type"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["Condition ID"]), Convert.ToString(objDs.Tables[1].Rows[i]["ConvertProduct"]), Convert.ToString(objDs.Tables[1].Rows[i]["PURPR_Parent_PURPRID"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["ConvertFlag"]),Convert.ToString(objDs.Tables[1].Rows[i]["ReturnID"]), Convert.ToString(objDs.Tables[1].Rows[i]["GRNReasonFlag"]));

                                    dtPurchaseAutoComplete.Rows.Add(grdSupplierList.Rows.Count + 1, Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), 
                                        string.Format("{0:G29}", decimal.Parse(varMRP1)), varTempExpiryDate,
                                         Convert.ToString(objDs.Tables[1].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]),
                                         Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLife"]), Convert.ToString(objDs.Tables[1].Rows[i]["ProductType"]), Convert.ToInt16(objDs.Tables[1].Rows[i]["ID"]));

                                    grdSupplierList.Columns["clmProTname"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    varProductsIDs.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]));
                                    if (Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmProductID"].Value) != 0)
                                    {
                                        ((DataGridViewImageCell)grdSupplierList.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
                                    }
                                    if (Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmConvertProduct"].Value) == 0)
                                    {
                                        ((DataGridViewImageCell)grdSupplierList.Rows[i].Cells["clmConvert"]).Value = new System.Drawing.Bitmap(1, 1);
                                    }
                                    else { varConvertFlag = 1; }
                                    if (Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmConvertParentFlag"].Value) == 1)
                                    {
                                        ((DataGridViewImageCell)grdSupplierList.Rows[i].Cells["clmConvert"]).Value = new System.Drawing.Bitmap(1, 1);
                                    }
                                    if (PbApprovalStsid == 70) // approval incomplete then allow to edit allow error column
                                    {
                                        if (Convert.ToInt16(objDs.Tables[1].Rows[i]["BatchNoErr"]) == 1)
                                        {
                                            grdSupplierList.Rows[i].Cells["clmBatchno"].ReadOnly = false;
                                            grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                        }
                                        else
                                        {
                                            grdSupplierList.Rows[i].Cells["clmBatchno"].ReadOnly = true;
                                            grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                                        }
                                        if (Convert.ToInt16(objDs.Tables[1].Rows[i]["ExpiryDateErr"]) == 1)
                                        {
                                            grdSupplierList.Rows[i].Cells["clmexpirydate"].ReadOnly = false;
                                            grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                        }
                                        else
                                        {
                                            grdSupplierList.Rows[i].Cells["clmexpirydate"].ReadOnly = true;
                                            grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                                        }
                                        if (Convert.ToInt16(objDs.Tables[1].Rows[i]["InvoiceMRPErr"]) == 1)
                                        {
                                            grdSupplierList.Rows[i].Cells["clmMRP"].ReadOnly = false;
                                            grdSupplierList.Rows[i].Cells["clmMRP"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                        }
                                        else
                                        {
                                            grdSupplierList.Rows[i].Cells["clmMRP"].ReadOnly = true;
                                            grdSupplierList.Rows[i].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                                        } 
                                        if (Convert.ToInt16(objDs.Tables[1].Rows[i]["ProExpiryDateErr"]) == 1)
                                        {
                                            grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].ReadOnly = false;
                                            grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                        }
                                        else
                                        {
                                            grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].ReadOnly = true;
                                            grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].Style.BackColor = Color.LightGray;
                                        }
                                        if (Convert.ToInt16(objDs.Tables[1].Rows[i]["ProBatchNoErr"]) == 1)
                                        {
                                            grdSupplierList.Rows[i].Cells["clmProductBatchNo"].ReadOnly = false;
                                            grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                        }
                                        else
                                        {
                                            grdSupplierList.Rows[i].Cells["clmProductBatchNo"].ReadOnly = true;
                                            grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Style.BackColor = Color.LightGray;
                                        }
                                        if (Convert.ToInt16(objDs.Tables[1].Rows[i]["ProMRPErr"]) == 1)
                                        {
                                            grdSupplierList.Rows[i].Cells["clmProductMrp"].ReadOnly = false;
                                            grdSupplierList.Rows[i].Cells["clmProductMrp"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                        }
                                        else
                                        {
                                            grdSupplierList.Rows[i].Cells["clmProductMrp"].ReadOnly = true;
                                            grdSupplierList.Rows[i].Cells["clmProductMrp"].Style.BackColor = Color.LightGray;
                                        }   
                                        grdSupplierList.Rows[i].Cells["clmMismatchQty"].ReadOnly = true;
                                        grdSupplierList.Rows[i].Cells["clmMismatchQty"].Style.BackColor = Color.LightGray;  
                                    }
                                    else
                                    {
                                        if (Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmInvFlag"].Value) == 1 || Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value) == "220" || Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmGRNMAFlag"].Value) == 1) 
                                        { grdSupplierList.Rows[i].ReadOnly = true; }
                                        else
                                        {
                                            grdSupplierList.Rows[i].ReadOnly = false;
                                        }
                                        DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                        GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
                                    }
                                }
                                if (varConvertFlag == 1)
                                { grdSupplierList.Columns["clmConvert"].Visible = true; }
                                else { grdSupplierList.Columns["clmConvert"].Visible = false; }
                                lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count);
                                if (varPurEditFlag == 1)
                                {
                                    DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                    GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
                                }
                            } 
                            if (objDs.Tables[2].Rows.Count != 0) //GST DETAILS LOAD
                            {
                                for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                                {
                                    if (Convert.ToString(objDs.Tables[2].Rows[i]["Taxable Value"]) != "0")
                                    {
                                        grdTaxDetails.DataSource = objDs.Tables[2];
                                        grdTaxDetails.Columns["GST%"].Width = 40;
                                        grdTaxDetails.Columns["Taxable Value"].Width = 100;
                                        grdTaxDetails.Columns["Tax Value"].Width = 80;
                                        grdTaxDetails.Columns["IGST%"].Width = 45;
                                        grdTaxDetails.Columns["CGST%"].Width = 45;
                                        grdTaxDetails.Columns["SGST%"].Width = 45;
                                        grdTaxDetails.Columns["IGST Value"].Width = 80;
                                        grdTaxDetails.Columns["CGST Value"].Width = 80;
                                        grdTaxDetails.Columns["SGST Value"].Width = 80;
                                        grdTaxDetails.Columns["GST%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdTaxDetails.Columns["IGST%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdTaxDetails.Columns["SGST%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdTaxDetails.Columns["CGST%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdTaxDetails.Columns["Taxable Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdTaxDetails.Columns["IGST Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdTaxDetails.Columns["CGST Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdTaxDetails.Columns["SGST Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdTaxDetails.Columns["Tax Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
                                    }
                                }
                                if (pbSupplierTin != pbConcernTin) //IGST
                                {
                                    grdTaxDetails.Columns["SGST%"].Visible = false;
                                    grdTaxDetails.Columns["CGST%"].Visible = false;
                                    grdTaxDetails.Columns["SGST Value"].Visible = false;
                                    grdTaxDetails.Columns["CGST Value"].Visible = false;
                                    grdTaxDetails.Columns["IGST%"].Visible = true;
                                    grdTaxDetails.Columns["IGST Value"].Visible = true;
                                }
                                else
                                {
                                    grdTaxDetails.Columns["GST%"].Visible = true;
                                    grdTaxDetails.Columns["CGST%"].Visible = true;
                                    grdTaxDetails.Columns["SGST Value"].Visible = true;
                                    grdTaxDetails.Columns["CGST Value"].Visible = true;
                                    grdTaxDetails.Columns["GST%"].Visible = true;
                                    grdTaxDetails.Columns["CGST%"].Visible = true;
                                    grdTaxDetails.Columns["IGST%"].Visible = false;
                                    grdTaxDetails.Columns["IGST Value"].Visible = false;
                                } 
                            }
                            else
                            {
                                grdTaxDetails.DataSource = grdTaxDetails;
                                grdTaxDetails.Columns["GST%"].Width = 40;
                                grdTaxDetails.Columns["Taxable Value"].Width = 80;
                                grdTaxDetails.Columns["Tax Value"].Width = 60; 
                            }
                            if (objDs.Tables[3].Rows.Count != 0) //PO DETAILS LOAD
                            {
                                lblPOnorecord.Visible = false;
                                for (int i = 0; i < objDs.Tables[3].Rows.Count; i++)
                                {
                                    grdPODetails.Rows.Add(Convert.ToString(objDs.Tables[3].Rows[i]["PO_No"]), Convert.ToString(objDs.Tables[3].Rows[i]["PO_Date"]),
                                        Convert.ToString(objDs.Tables[3].Rows[i]["POPR_PRID"]), Convert.ToString(objDs.Tables[3].Rows[i]["POID"]));
                                    pbPONO = pbPONO + ',' + Convert.ToString(objDs.Tables[3].Rows[i]["POID"]);
                                }
                                varTypeErrId = Convert.ToString(objDs.Tables[3].Rows[0]["POID"]);
                            }
                            else
                            {
                                grdPODetails.Rows.Clear();
                            }
                            if (objDs.Tables[4].Rows.Count != 0) //DC DETAILS LOAD
                            {
                                grdDCVerificationDetails.Rows.Clear();
                                grdDCVerificationDetails.BringToFront();
                                lblFinishedNoRecord.Visible = false;
                                for (int i = 0; i < objDs.Tables[4].Rows.Count; i++)
                                {
                                    grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[4].Rows[i]["DC_No"]), Convert.ToString(objDs.Tables[4].Rows[i]["DC_DATE"]),
                                        Convert.ToString(objDs.Tables[4].Rows[i]["DCPR_PRID"]), Convert.ToString(objDs.Tables[4].Rows[i]["DCID"]));
                                    pbDCNo = pbDCNo + ',' + Convert.ToString(objDs.Tables[4].Rows[i]["DCID"]);
                                    grdDCVerificationDetails.Rows.Add(Convert.ToString(objDs.Tables[4].Rows[i]["DC_No"]), Convert.ToString(objDs.Tables[4].Rows[i]["DC Verification Details"]));
                                    lblVerifyNorecord.Visible = false;
                                }
                                grdReurnDC.Visible = true;
                                varTypeErrId = Convert.ToString(objDs.Tables[4].Rows[0]["DCID"]);
                            }
                            grdReurnDC.Columns["clmRemoveDC"].Visible = false;
                            grdPODetails.Columns["clmRemovePO"].Visible = false;

                            if (objDs.Tables[6].Rows.Count != 0)
                            {
                                lblVerifyDateTime.Text = Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIED1"]);
                                lblGRNNoRecord.Visible = false;
                            }
                            if (objDs.Tables[7].Rows.Count != 0)
                            {
                                lblVerifyDateTime2.Text = Convert.ToString(objDs.Tables[7].Rows[0]["VERIFIED2"]);
                                lblGRNNoRecord.Visible = false;
                            }
                            if (objDs.Tables[8].Rows.Count != 0)
                            {
                                varPurEditFlag = Convert.ToInt32(objDs.Tables[8].Rows[0]["Flag"]); //From settings purchase should be edditaable or not
                            }
                            if (objDs.Tables.Count > 9)
                            {
                                if (Convert.ToString(cmbEntryType.SelectedValue) != "56")
                                {
                                    if (objDs.Tables[10].Rows.Count != 0)
                                    {
                                        tsbAddedProduct.Text = Convert.ToString(objDs.Tables[10].Rows[0]["AddedCount"]);
                                    }
                                    if (objDs.Tables[11].Rows.Count != 0)
                                    {
                                        tsbTotalProducts.Text = Convert.ToString(objDs.Tables[11].Rows[0]["TotalProducts"]);
                                    }
                                    int Remaining = 0;
                                    Remaining = Convert.ToInt32(tsbTotalProducts.Text) - Convert.ToInt32(tsbAddedProduct.Text);
                                    tsbRemainingProduct.Text = Convert.ToString(Remaining);
                                }
                            }
                            if (Convert.ToString(cmbEntryType.SelectedValue) == "57") //dc
                            {
                                if (objDs.Tables[12].Rows.Count != 0)
                                {
                                    varDCDate = Convert.ToString(objDs.Tables[12].Rows[0]["DC_Date"]);
                                }
                            }
                            if (Convert.ToString(cmbEntryType.SelectedValue) == "54") //GRN
                            {
                                if (tsbRemainingProduct.Text == "0")
                                { cmbPONo.SelectedValue = 217; cmbPONo.Enabled = false; }
                            }
                            else if (Convert.ToString(cmbEntryType.SelectedValue) == "57")
                            {
                                if (tsbRemainingProduct.Text == "0")
                                { cmbPONo.SelectedValue = 219; cmbPONo.Enabled = false; }
                            }
                            else if (Convert.ToString(cmbEntryType.SelectedValue) == "55") //po
                            {
                                if (tsbRemainingProduct.Text == "0")
                                { cmbPONo.SelectedValue = 214; cmbPONo.Enabled = false; }
                            }
                            if (objDs.Tables.Count > 8)
                            {
                                if (objDs.Tables[9].Rows.Count != 0)
                                {
                                    PbVerified1 = 1;
                                    varPurVerifyFlag = Convert.ToString(objDs.Tables[9].Rows[0]["EditFlag"]);
                                    pbVerifiedBy1 = Convert.ToInt16(objDs.Tables[9].Rows[0]["Verifiedby"]);
                                    pbVerifiedName1 = Convert.ToString(objDs.Tables[9].Rows[0]["Verified Name"]);
                                    pbVerifiedOn1 = Convert.ToString(objDs.Tables[9].Rows[0]["PUR_VerfiedOn"]);
                                    pbVerifiedTime1 = Convert.ToString(objDs.Tables[9].Rows[0]["PUR_Verified_Time"]);
                                    pbVerifiedFormat1 = Convert.ToString(objDs.Tables[9].Rows[0]["PUR_Verified_format"]);
                                    lblPurchaseVerification.Text = Convert.ToString(objDs.Tables[9].Rows[0]["Purchase Verification Details"]);
                                    PbVerified2 = 1;
                                    varPurVerifyFlag2 = Convert.ToString(objDs.Tables[9].Rows[0]["EditFlag2"]);
                                    pbVerifiedBy2 = Convert.ToInt16(objDs.Tables[9].Rows[0]["Verifiedby2"]);
                                    pbVerifiedName2 = Convert.ToString(objDs.Tables[9].Rows[0]["Verified Name2"]);
                                    pbVerifiedOn2 = Convert.ToString(objDs.Tables[9].Rows[0]["PUR_VerfiedOn2"]);
                                    pbVerifiedTime2 = Convert.ToString(objDs.Tables[9].Rows[0]["PUR_Verified_Time2"]);
                                    pbVerifiedFormat2 = Convert.ToString(objDs.Tables[9].Rows[0]["PUR_Verified_format2"]);
                                    lblPurchaseVerification2.Text = Convert.ToString(objDs.Tables[9].Rows[0]["Purchase Verification Details2"]);
                                }
                            }
                        }
                    }
                    DataGridViewBindingCompleteEventArgs args3 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                    GrdPurchaseList_DataBindingComplete(grdPurchaseList, args3);
                    udfnPurchaseEntryTabLoad();
                    if (PbSTS == "49")
                    {
                        if (tbDetails.SelectedIndex == 0)
                        { this.ActiveControl = txtProductName; }
                        if (Convert.ToDecimal(lblSubtotal.Text) == 0)
                        {
                            gpdiscount.Enabled = true;
                        }
                        else
                        {
                            gpdiscount.Enabled = false;
                        }
                        dpInvoiceDate.Enabled = true;
                    }
                    if (PbSTS == "50")
                    {
                        grdSupplierList.Columns["clmRemove"].Visible = false;
                        txtInvoiceNo.Enabled = false;
                        txtInvoiceamt.Enabled = false;
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
                if (grdSupplierList.RowCount != 0)
                { btnClear.Enabled = false; }
            }
        }
        public void udfndisablevalue()
        {
            try
            {
                cmbConcern.Enabled = false;
                txtPENO.Enabled = false;
                txtSupplier.Enabled = false;
                cmbEntryType.Enabled = false;
                txtQRCode.Enabled = false;
                txtInvoiceamt.Enabled = true;
                dpInvoiceDate.Enabled = false;
                txtInvoiceNo.Enabled = true;
                cmbTransactionType.Enabled = false;
                txtBroker.Enabled = false;
                tbDetails.TabPages[0].Enabled = true;
                chkInvoice.Enabled = false;
                if (PbSTS == "50" || varPurEditFlag == 1 || pbPurchaseEntryUnapprovedFlag == 1)
                {
                    tbDetails.TabPages[0].Enabled = true;
                    tbDetails.TabPages[1].Enabled = true;
                    chkCompleted.Enabled = false;
                    gpdiscount.Enabled = false;
                    gpPayment.Enabled = false;
                    gpPurchase.Enabled = false;
                    gprate.Enabled = false;
                    btnClear.Enabled = false;
                    cmbPONo.Enabled = false;
                    txtProductName.Enabled = false;
                    txtMrp.Enabled = false;
                    txtDate.Enabled = false;
                    txtMonth.Enabled = false;
                    txtBatchno.Enabled = false;
                    txtYear.Enabled = false;
                    txtSourceLocation.Enabled = false;
                    cmbrack.Enabled = false;
                    btnAdd.Enabled = false;
                    btnConditions.Enabled = false;
                }
                // btnClear.Enabled = false;
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
                int varEntryType = 0;
                varEntryType = Convert.ToInt32(cmbEntryType.SelectedValue);
                DataBind objDataBind = new DataBind();
                tsbTotal.Visible = true; tsbTotal.Enabled = true;
                tsbAdded.Visible = true; tsbAdded.Enabled = true;
                tsbPO.Visible = true; tsbPO.Enabled = true;
                tsbTotalProducts.Visible = true; tsbRemainingProduct.Visible = true; tsbAddedProduct.Visible = true;
                tss1.Visible = true; tss2.Visible = true; tss3.Visible = true;
                if (varQueueFlag == 0)
                {
                    tsbTotalProducts.Text = "0"; tsbRemainingProduct.Text = "0"; tsbAddedProduct.Text = "0";
                }
                if (varEntryType == 54)  //GRN
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (69)  ORDER BY MSTID DESC", "MST_DisplayText,MSTID", cmbPONo, "", "MST_DisplayText", "MSTID");
                    lblPOdropDown.Text = "GRN Type";
                    tsbTotal.Text = "&GRN Products : ";
                }
                else if (varEntryType == 55) //PO
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (68)  ORDER BY MSTID DESC", "MST_DisplayText,MSTID", cmbPONo, "", "MST_DisplayText", "MSTID");
                    lblPOdropDown.Text = "PO Type";
                    tsbTotal.Text = "&PO Products : ";
                }
                else if (varEntryType == 57) // DC
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (70)  ORDER BY MSTID DESC", "MST_DisplayText,MSTID", cmbPONo, "", "MST_DisplayText", "MSTID");
                    lblPOdropDown.Text = "DC Type";
                    tsbTotal.Text = "&DC Products : ";
                }
                else if (varEntryType == 56 || varEntryType == -1) // Direct
                {
                    cmbPONo.Text = "";
                    cmbPONo.DataSource = null;
                    tsbTotal.Visible = false; tsbTotal.Enabled = false;
                    tsbAdded.Visible = false; tsbAdded.Enabled = false;
                    tsbPO.Visible = false; tsbPO.Enabled = false;
                    tsbTotalProducts.Visible = false; tsbRemainingProduct.Visible = false; tsbAddedProduct.Visible = false;
                    tss1.Visible = false; tss2.Visible = false; tss3.Visible = false;
                }
                objDataBind = null;
                cmbPONo.Enabled = true;
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
            MR_Master objMR_Master = new MR_Master();
            objMR_Master.ViewType = 23;
            DataSet objds = new DataSet();
            objds = objdserv.udfnMaster(objMR_Master);
            objdserv.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDtProductCondition = objds.Tables[0];
                    }
                }
            }
            DataBind objDataBind = new DataBind();
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (0,17) AND MSTID<>0 ORDER BY MST_DisplayText desc", "MST_DisplayText,MSTID", cmbEntryType, "", "MST_DisplayText", "MSTID");
            objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID in (18) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (83) ORDER BY MST_OrderID", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
            udfnLoadConditions();
            objDataBind = null;
            objDataBind = null; //id
            if (PbFlag == "1")
            {
                cmbEntryType.SelectedValue = "54"; //grn
                pbGRNNo = PbID;
                varTypeErrId = PbID;
                udfnGRNDCDetailsLoadQueue();
                udfnGRNProload();
                txtQRCode.ReadOnly = false;
                grdPODetails.Visible = true;
                grdReurnDC.Visible = false;
            }
            else if (PbFlag == "2")
            {
                cmbEntryType.SelectedValue = "57"; // dc
                pbDCNo = PbID;
                varTypeErrId = PbID;
                udfnGRNDCDetailsLoadQueue();
                // grdPODetails.Visible = false;
                grdReurnDC.Visible = true;
                if (grdSupplierList.Rows.Count != 0)
                {
                    btnClear.Enabled = true;
                }
                if (grdReurnDC.Rows.Count != 0)
                {
                    lblFinishedNoRecord.Visible = false;
                }
            }
            else
            {
                cmbEntryType.SelectedValue = "-1";
            }
            cmbTransactionType.SelectedValue = "58";
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
        public void udfnGRNDCDetailsLoadQueue()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 11;
                objTRN_PurchaseEntry.ParaIds = PbID;
                objTRN_PurchaseEntry.paraType = Convert.ToInt32(PbFlag);
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                if (Convert.ToInt32(PbFlag) == 1)
                {
                    if (objDs.Tables[0].Rows.Count != 0) //  PO DETAILS LOAD
                    {
                        grdPODetails.Rows.Clear();
                        lblPOnorecord.Visible = false;
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            grdPODetails.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["PO_No"]), Convert.ToString(objDs.Tables[0].Rows[i]["PO_Date"]),
                                Convert.ToString(objDs.Tables[0].Rows[i]["POPR_PRID"]), Convert.ToString(objDs.Tables[0].Rows[i]["POID"]));
                        }
                    }
                    if (objDs.Tables[2].Rows.Count != 0) //  GRN DETAILS LOAD
                    {
                        grdGRN.Rows.Clear();
                        grdGRN.Visible = true;
                        lblFinishedNoRecord.Visible = false;
                        for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                        {
                            grdGRN.Rows.Add(Convert.ToString( objDs.Tables[2].Rows[i]["GRN_Date"]),Convert.ToString(objDs.Tables[2].Rows[i]["GRN_No"]), 
                                Convert.ToString(objDs.Tables[2].Rows[i]["GRNPRID"]), Convert.ToString(objDs.Tables[2].Rows[i]["GRNID"]));
                        }
                    }
                }
                if (Convert.ToInt32(PbFlag) == 2)
                {
                    if (objDs.Tables[1].Rows.Count > 0) // DC Details load
                    {
                        grdReurnDC.Rows.Clear();
                        for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                        {
                            lblNoRecordsFound.Visible = false; lblVerifyNorecord.Visible = false; grdReurnDC.BringToFront();
                            grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["DCNo"]), Convert.ToString(objDs.Tables[1].Rows[i]["DCDate"]),
                                Convert.ToString(objDs.Tables[1].Rows[i]["T.PRO"]), Convert.ToString(objDs.Tables[1].Rows[i]["ID"]));
                            grdDCVerificationDetails.Rows.Add(objDs.Tables[1].Rows[i]["DCNo"], objDs.Tables[1].Rows[i]["DC Verification Details"]);
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
        public void udfnPurchaseDCDetailsLoad()
        {
            try
            {
                if (pbDCNo != "0")
                {
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    grdReurnDC.Visible = true;
                    TRN_Purchase_DC objTRNG_Purchase_DC = new TRN_Purchase_DC();
                    objTRNG_Purchase_DC.ViewType = 2;
                    objTRNG_Purchase_DC.paraDCIDS = pbDCNo;
                    objTRNG_Purchase_DC.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                    objTRNG_Purchase_DC.paraScheduleID = Convert.ToInt32(lblschedule.Text);
                    objDs = objdserv.udfnPurchaseDCList(objTRNG_Purchase_DC);
                    objdserv.CloseConnection();
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        grdReurnDC.Rows.Clear();
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            lblNoRecordsFound.Visible = false;
                            grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["DCNo"]), Convert.ToString(objDs.Tables[0].Rows[i]["DCDate"]),
                                Convert.ToString(objDs.Tables[0].Rows[i]["T.PRO"]), Convert.ToString(objDs.Tables[0].Rows[i]["ID"])
                            );
                        }
                    }
                    else
                    {
                        lblFinishedNoRecord.Visible = true;
                        grdReurnDC.DataSource = null;
                        grdReurnDC.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public void udfnDateset()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 4;
                objMR_Master.paraID = 6;
                DataSet objd = new DataSet();
                SPDataService objDServ = new SPDataService();
                objd = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                if (objd.Tables[1].Rows.Count != 0)
                {
                    varmaxdate = DateTime.ParseExact(objd.Tables[1].Rows[0]["mintoday"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                DateTime varmindate = MainForm.pbFYStartDate;
                dpInvoiceDate.MinDate = varmindate;
                dpInvoiceDate.MaxDate = varmaxdate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Purchase_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (pnlConditions.Visible == true)
                    {
                        pnlConditions.Visible = false;
                    }
                    else
                    {
                        udfnclose();
                    }
                }
                if (e.KeyCode == Keys.F5)
                {
                    BtnSave_Click(sender, e);
                }
                if(e.KeyCode==Keys.F1)
                {
                    if(pnlConditions.Visible==true)
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

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplier.Text.Trim() == "")
                {
                    grdPODetails.Rows.Clear();
                }
                txtSupplier.BackColor = Color.White;
                udfnrowclear();
                txtProductName.Text = "";
                lblProductcode.Text = "0";
                if (varBlockedSupplier == "98")
                {
                    tsbSupplier.Visible = true;
                    txtSupplier.BackColor = Color.LightPink;
                    tsbSupplier.Text = varBlockedReason;
                }
                else
                {
                    tsbSupplier.Visible = false;
                    txtSupplier.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (PbSTS == "50")
                { btnSave.Text = "Update"; }
                else
                {
                    if (pbPurchaseno == "0")
                    { btnSave.Text = "Save as Draft"; }
                    else
                    {
                        if (chkCompleted.Checked == true)
                        {
                            btnSave.Text = "Update";
                        }
                        else
                        {
                            btnSave.Text = "Save as Draft";
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

        private void TbDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (PbSTS == "50")
                {
                    tbDetails.TabPages[0].Enabled = true; // First tab 
                                                          // tbDetails.TabPages[1].Enabled = true; // Second tab 
                                                          // udfnPurchaseEntryTabLoad(); //tab2 load
                    udfnDisableDiscount();
                }
                else
                {
                    if (pbPurchaseno == "0")
                    {
                        tbDetails.TabPages[0].Enabled = true; // First tab 
                        tbDetails.TabPages[1].Enabled = false; // Second tab
                    }
                    else
                    {
                        if (grdTaxDetails.Rows.Count > 0)
                        {
                            grdTaxDetails.Columns["GST%"].Width = 40;
                            grdTaxDetails.Columns["Taxable Value"].Width = 100;
                            grdTaxDetails.Columns["Tax Value"].Width = 80;
                            grdTaxDetails.Columns["IGST%"].Width = 45;
                            grdTaxDetails.Columns["CGST%"].Width = 45;
                            grdTaxDetails.Columns["SGST%"].Width = 45;
                            grdTaxDetails.Columns["IGST Value"].Width = 80;
                            grdTaxDetails.Columns["CGST Value"].Width = 80;
                            grdTaxDetails.Columns["SGST Value"].Width = 80;
                        }
                    }
                }
                if (pbPurchaseno != "0")
                {
                    if (grdReurnDC.Visible == true)
                    {
                        grdReurnDC.Columns["clmRemoveDC"].Visible = false;
                    }
                    if (grdPODetails.Visible == true)
                    {
                        grdPODetails.Columns["clmRemovePO"].Visible = false;
                    }
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private Color[] TColors = { Color.Salmon, Color.White, Color.LightBlue };
        private void TbDetails_DrawItem(object sender, DrawItemEventArgs e)
        {
            //// get ref to this page
            //TabPage tp = ((TabControl)sender).TabPages[e.Index];

            //using (Brush br = new SolidBrush(TColors[e.Index]))
            //{
            //    Rectangle rect = e.Bounds;
            //    e.Graphics.FillRectangle(br, e.Bounds);

            //    rect.Offset(1, 1);
            //    TextRenderer.DrawText(e.Graphics, tp.Text,
            //           tp.Font, rect, tp.ForeColor);

            //    // draw the border
            //    rect = e.Bounds;
            //    rect.Offset(0, 1);
            //    rect.Inflate(0, -1);

            //    // ControlDark looks right for the border
            //    using (Pen p = new Pen(SystemColors.ControlDark))
            //    {
            //        e.Graphics.DrawRectangle(p, rect);
            //    }

            //    if (e.State == DrawItemState.Selected) e.DrawFocusRectangle();
            //}
        }
        private void GrdPurchaseList_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.F4)
            //    {
            //        int column = grdPurchaseList.CurrentCellAddress.X;
            //        string columnName = grdPurchaseList.Columns[column].Name;
            //        if (columnName == "clmPurchaseRate") {
            //            MainForm.objPUR_Calculator = new PUR_Calculator();
            //            MainForm.objPUR_Calculator.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        public void udfnCalculator()
        {
            try
            {
                int varColumn = grdPurchaseList.CurrentCellAddress.X;
                int varRow = grdPurchaseList.CurrentCellAddress.Y;
                string columnName = grdPurchaseList.Columns[varColumn].Name;
                string Varvalue = Convert.ToString(grdPurchaseList.Rows[varRow].Cells[varColumn].Value);
                MainForm.objPUR_Calculator = new PUR_Calculator();
                MainForm.objPUR_Calculator.PbValue = Varvalue;
                MainForm.objPUR_Calculator.ShowDialog();
                varPurchaseRate = varCalculator;
                grdPurchaseList.Rows[varRow].Cells[varColumn].Value = Convert.ToString(varPurchaseRate);


                decimal varInvQty = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmInvQty"].Value)) != "") { varInvQty = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmInvQty"].Value); }
                decimal varRecQty = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmRecqty"].Value)) != "") { varRecQty = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmRecqty"].Value); }
                decimal varDiffQty = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmDiffqty"].Value)) != "") { varDiffQty = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmDiffqty"].Value); }
                decimal varFreeQty = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmFreeqty"].Value)) != "") { varFreeQty = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmFreeqty"].Value); }
                decimal varPurRate = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmPurchaseRate"].Value)) != "")
                {
                    string mrp = string.Format("{0:0.000}", Math.Round(Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmPurchaseRate"].Value), 6, MidpointRounding.AwayFromZero));
                    grdPurchaseList.CurrentRow.Cells["clmPurchaseRate"].Value = mrp;
                    varPurRate = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmPurchaseRate"].Value);
                }
                decimal varCellDiscAmt = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Value)) != "") { varCellDiscAmt = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Value); }
                decimal varTaxValue = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmTax"].Value)) != "") { varTaxValue = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmTax"].Value); }
                decimal varGstAmt = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmGstamt"].Value)) != "") { varGstAmt = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmGstamt"].Value); }
                decimal varNetAmt = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmnetamt"].Value)) != "") { varNetAmt = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmnetamt"].Value); }
                decimal varDiscPer = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmDiscPer"].Value)) != "") { varDiscPer = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmDiscPer"].Value); }
                int varHSNGSTValue = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["GstValue"].Value)) != "") { varHSNGSTValue = Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["GstValue"].Value); }

                udfnDiscountToAmount(varCellDiscAmt, Convert.ToDecimal(varPurchaseRate), varInvQty, varPurRate);
                varDiscountFlag = 0;
                udfnValuesCalcultaion(varInvQty, varRecQty, varDiffQty, varPurRate, varCellDiscAmt, varTaxValue, varGstAmt, varNetAmt, varDiscPer, varHSNGSTValue, varFreeQty);
                grdPurchaseList.CurrentRow.Cells["clmGstamt"].Value = PbGstamt.ToString("0.00");
                grdPurchaseList.CurrentRow.Cells["clmnetamt"].Value = PbNetamt.ToString("0.00");
                grdPurchaseList.CurrentRow.Cells["clmTax"].Value = PbTaxvalue.ToString("0.00");
                grdPurchaseList.CurrentRow.Cells["clmCosting"].Value = pbCostingRate.ToString("0.00");
                grdPurchaseList.CurrentRow.Cells["clmDiscountValue"].Value = PbDicountValue.ToString("0.00");
                grdPurchaseList.CurrentRow.Cells["clmSGstamt"].Value = PbSGstamt.ToString("0.00");
                grdPurchaseList.CurrentRow.Cells["clmCGstamt"].Value = PbCGstamt.ToString("0.00");
                grdPurchaseList.CurrentRow.Cells["clmIGstamt"].Value = PbIGstamt.ToString("0.00");
                udfnSubtotCalc();
                udfnGstvalue();
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                PbGstamt = 0; PbNetamt = 0; pbDiffQty = 0; PbDiscamt = 0; PbTaxvalue = 0; pbDisper = 0; pbCostingRate = 0; PbDicountValue = 0; PbSGstamt = 0;
                PbIGstamt = 0; PbCGstamt = 0;
            }
        }
        private void GrdPurchaseList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (PbSTS != "50" || PbSTS == "70" || varPaymentStatus==70)
                {
                    if (e.KeyCode == Keys.F4)
                    {
                        if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmPurchaseRate"
                            || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscAmt")
                        {
                            udfnCalculator();
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
        private void GrdPurchaseList_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                ////if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer")
                ////{
                //    if (e.KeyChar == (char)Keys.F4)
                //    {
                //    //e.Handled = false;
                //    udfnCalculator();
                //}
                ////}
                //if (PbSTS != "50")
                //{
                //    if (e.KeyChar == (char)Keys.F4)
                //    {
                //        int varColumn = grdPurchaseList.CurrentCellAddress.X;
                //        int varRow = grdPurchaseList.CurrentCellAddress.Y;
                //        string columnName = grdPurchaseList.Columns[varColumn].Name;
                //        //if (columnName == "clmPurchaseRate" || columnName = "clmDiscPer"
                //        if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmPurchaseRate")
                //        {
                //            udfnCalculator();
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdSupplierList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (this.grdSupplierList.Columns[e.ColumnIndex].Name == "clmExpDate")
            //{
            //    ShortFormDateFormat(e);
            //}
        }
        private static void ShortFormDateFormat(DataGridViewCellFormattingEventArgs formatting)
        {
            if (formatting.Value != null)
            {
                try
                {
                    DateTime theDate = DateTime.Parse(formatting.Value.ToString());
                    String dateString = theDate.ToString("dd-MM-yy");
                    formatting.Value = dateString;
                    formatting.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    // Set to false in case there are other handlers interested trying to
                    // format this DataGridViewCellFormattingEventArgs instance.
                    formatting.FormattingApplied = false;
                }
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
        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToInt32(lblSupplierCode.Text.Trim()) != 0 && Convert.ToInt32(lblschedule.Text.Trim()) != 0 && (Convert.ToInt32(cmbEntryType.SelectedValue) != 54) && (Convert.ToInt32(cmbEntryType.SelectedValue) != -1) && varSupplierType != 32)
                    {
                        udfnGSTINPopup();
                    }
                    cmbEntryType.Focus();
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

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplier.Text.Trim() == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedule.Text = "0";
                    txtGstin.Text = "";
                }
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString(), objDs.Tables[0].Rows[i]["GSTIN"].ToString(), objDs.Tables[0].Rows[i]["ST_TIN"].ToString(), objDs.Tables[0].Rows[i]["STSID"].ToString(), objDs.Tables[0].Rows[i]["Reason"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[3].Width = 0;
                                LV_Supplier.Columns[4].Width = 0;
                                LV_Supplier.Columns[5].Width = 0;
                                LV_Supplier.Columns[6].Width = 0;
                                LV_Supplier.Columns[7].Width = 0;
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
        }

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try { cmbConcern.BackColor = Color.LemonChiffon; }
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
                    errPurchaseentry.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpconcern.ShowAlways = true;
                    tpconcern.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    errPurchaseentry.Clear();
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
                    dpVoucherDate.Focus();
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
                if (PbFlag == "0")
                {
                    BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                    if (btnSave.Text == "Save as Draft")
                    {
                        if (varcomid != Convert.ToString(cmbConcern.SelectedValue))
                        {
                            if (Convert.ToString(cmbConcern.SelectedValue) != "-1" && Convert.ToInt32(grdSupplierList.Rows.Count) != 0)
                            {
                                SPDataService objDServ = new SPDataService();
                                string varMessage = objDServ.udfnGetMessages(78);
                                objDServ.CloseConnection();

                                DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    grdSupplierList.Rows.Clear();
                                    grdPurchaseList.Rows.Clear();
                                    txtSupplier.Text = "";
                                    lblSupplierCode.Text = "0";
                                    txtQRCode.Text = "";
                                    lblschedule.Text = "0";
                                    txtInvoiceNo.Text = "0";
                                    cmbEntryType.SelectedValue = "56";
                                    cmbTransactionType.SelectedValue = "58";
                                    txtBroker.Text = "";
                                    txtGstin.Text = "";
                                    lblBrokerId.Text = "0";
                                    ClearSupplier();
                                }
                            }
                        }
                    }
                }
                varcomid = Convert.ToString(cmbConcern.SelectedValue);
                varDateChange = 0;
                udfnVocherno();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void ClearSupplier()
        {
            try
            {
                lblSuppliername.Text = "";
                lblSupplierCity.Text = "";
                lblsupplierGST.Text = "";
                lblsupplierScheduletype.Text = "";
                lblsupplierpayment.Text = "";
                lblSupplierOrderpolicy.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVocherno()
        {
            try
            {
                if (btnSave.Text == "Save as Draft")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpVoucherDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetVoucherNo("40", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string peno = parts[0];
                        if (peno != "")
                        {
                            txtPENO.Text = peno;
                        }
                        else
                        {
                            varVoucherSkip = false;
                            if (varDateChange == 0)
                            {
                                udfnvoucheradd();
                            }
                        }
                    }
                    else
                    {
                        txtPENO.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnvoucheradd()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(75);
                objDServ.CloseConnection();
                txtPENO.Text = "";
                DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    varVoucherSkip = true;
                    varClose = 1;
                    udfnclose();
                    MainForm.objCP_Settings = new CP_Settings();
                    MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                    MainForm.objCP_Settings.varValues = Convert.ToString(38);
                    MainForm.objCP_Settings.MdiParent = this.ParentForm;
                    MainForm.objCP_Settings.Show();
                }
                else { varVoucherSkip = true; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    pbSupplierTin = Convert.ToInt32(selectedItem.SubItems[5].Text);
                    varBlockedSupplier = selectedItem.SubItems[6].Text;
                    varBlockedReason = selectedItem.SubItems[7].Text;
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                    udfnSupplierDetails();
                    grdSupplierList.Rows.Clear();
                    grdReurnDC.Rows.Clear();
                    lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count);
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    cmbEntryType.Focus();
                }
                if (varBlockedSupplier == "98")
                {
                    tsbSupplier.Visible = true;
                    txtSupplier.BackColor = Color.LightPink;
                    tsbSupplier.Text = varBlockedReason;
                }
                else
                {
                    tsbSupplier.Visible = false;
                    txtSupplier.BackColor = Color.White;
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
        private void CmbEntryType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtGstin.Text.Trim() == "" && Convert.ToInt32(lblSupplierCode.Text.Trim()) != 0 && Convert.ToInt32(lblschedule.Text.Trim()) != 0 && (Convert.ToInt32(cmbEntryType.SelectedValue) != 54) && (Convert.ToInt32(cmbEntryType.SelectedValue) != -1) && pbPurchaseno == "0" && varQueueFlag == 0 && varSupplierType != 32 && varEntryTypeRefresh == 0)
                {
                    udfnGSTINPopup();
                }
                if (Convert.ToInt32(cmbEntryType.SelectedValue) == -1)
                {
                    errPurchaseentry.SetError(cmbEntryType, "Please select entry type");
                    cmbEntryType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEntryType.ShowAlways = true;
                    tpEntryType.Show("Please select entry type", cmbEntryType, 5000);
                }
                else
                {
                    cmbEntryType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbEntryType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbEntryType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSupplierValidation()
        {
            try
            {
                LV_Supplier.Visible = false;
                if (Convert.ToString(txtSupplier.Text) != "")
                {
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 23;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varSupplierId = Convert.ToString(objDsSupplierId.Tables[0].Rows[0][0]);
                                values = Convert.ToString(varSupplierId).Split(',');
                            }
                        }
                    }
                    if (values[0] == "-1")
                    {
                        errPurchaseentry.SetError(txtSupplier, "Invalid supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        grdSupplierList.Rows.Clear();
                        ClearSupplier();
                        lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count);
                    }
                    else
                    {
                        errPurchaseentry.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White;
                        if (VarPrevSupplierid != Convert.ToInt32(lblSupplierCode.Text))
                        {
                            udfnSupplierDetails();
                        }
                    }
                    VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                }
                txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbEntryType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtGstin.Text.Trim() == "" && Convert.ToInt32(lblSupplierCode.Text.Trim()) != 0 && Convert.ToInt32(lblschedule.Text.Trim()) != 0 && (Convert.ToInt32(cmbEntryType.SelectedValue) != 54) && (Convert.ToInt32(cmbEntryType.SelectedValue) != -1) && pbPurchaseno == "0" && varQueueFlag == 0 && varSupplierType != 32 && varEntryTypeRefresh == 0)
                    {
                        udfnGSTINPopup();
                    }
                    if (dpInvoiceDate.Enabled == true)
                    {
                        dpInvoiceDate.Focus();
                    }
                    else { txtInvoiceNo.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbEntryType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void DpVoucherDate_KeyDown(object sender, KeyEventArgs e)
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
                if (Convert.ToString(txtInvoiceNo.Text) == "")
                {
                    errPurchaseentry.SetError(txtInvoiceNo, "Please enter invoice");
                    txtInvoiceNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoice.ShowAlways = true;
                    tpInvoice.Show("Please enter invoice", txtInvoiceNo, 5000);
                }
                else
                {
                    errPurchaseentry.Clear();
                    txtInvoiceNo.BackColor = Color.White;
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
                    txtInvoiceamt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBroker_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBroker.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBroker_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtGstin.Enabled == true)
                    { txtGstin.Focus(); }
                    else
                    { chkInvoice.Focus(); }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lv_Broker.Items.Count == 0 || txtBroker.Text == "")
                    {
                        txtBroker.Focus();
                        lv_Broker.Visible = false;
                    }
                    else
                    {
                        lv_Broker.Focus();
                    }
                    if (lv_Broker.Items.Count > 0)
                    {
                        lv_Broker.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBroker_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBroker.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGstin_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGstin.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGstin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    chkInvoice.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGstin_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGstin.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbPurchaseCash_Enter(object sender, EventArgs e)
        {
            try
            {
                rbPurchaseCash.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbPurchaseCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbPurchaseCredit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbPurchaseCash_Leave(object sender, EventArgs e)
        {
            try
            {
                rbPurchaseCash.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbPurchaseCredit_Enter(object sender, EventArgs e)
        {
            try
            {
                rbPurchaseCredit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbPurchaseCredit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbPaymentCash.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbPurchaseCredit_Leave(object sender, EventArgs e)
        {
            try
            {
                rbPurchaseCredit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbRateBefore_Enter(object sender, EventArgs e)
        {
            try
            {
                rbRateBefore.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public AutoCompleteStringCollection AutoCompleteLocationName(int varCOMID)
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataTable objDt = new DataTable();
            SPDataService objspdservice = new SPDataService();
            DataSet objds = new DataSet();
            objds = objspdservice.udfnStockLocationList(31, Convert.ToInt32(varCOMID), 0, 0, "", 0, 0, 0, "", "", 0);
            objspdservice.CloseConnection();
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
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("SL_EName") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteRackName(int varSLID, int varPRID)
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            SPDataService objdservice = new SPDataService();
            DataTable objDt = new DataTable();
            objds = objdservice.udfnRackList(11, 0, 0, Convert.ToInt32(varSLID), 0, "", 0, 0);
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
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("RK_ShortName") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteProduct(int varCOMID)
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            DataTable objDt = new DataTable();
            SPDataService objspdservice = new SPDataService();
            MR_Product objMR_Product = new MR_Product();
            objMR_Product.paraViewType = 29;
            objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
            objMR_Product.ParaScheduleid = lblschedule.Text;
            objMR_Product.ParaProductCode = 0;
            objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
            objMR_Product.paraPurchaseAutoComplete = dtPurchaseAutoComplete;
            objds = objspdservice.udfnproductmasterlist(objMR_Product);
            if (objds != null)
            {
                if (objds.Tables.Count != 0)
                {
                    if (objds.Tables[0].Rows.Count != 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("PR_PICode") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteProductCondition()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            var varValue = from r in objDtProductCondition.AsEnumerable() group r by r.Field<string>("MST_DisplayText") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        private void GrdSupplierList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmMRP" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmGrnMrp")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmLocation")
                {
                    TextBox txtPurStockLocation = e.Control as TextBox;
                    if (txtPurStockLocation != null)
                    {
                        int varCOMID = Convert.ToInt16(cmbConcern.SelectedValue);
                        txtPurStockLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtPurStockLocation.AutoCompleteCustomSource = AutoCompleteLocationName(varCOMID);
                        txtPurStockLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }

                else if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmrack")
                {
                    TextBox txtPurRack = e.Control as TextBox;
                    if (txtPurRack != null)
                    {
                        int varSLID = 0;
                        string varSLName = "";
                        int varPRID = Convert.ToInt16(grdSupplierList.CurrentRow.Cells["clmProid"].Value);
                        varSLID = Convert.ToInt32(grdSupplierList.CurrentRow.Cells["slid"].Value);
                        txtPurRack.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtPurRack.AutoCompleteCustomSource = AutoCompleteRackName(varSLID, varPRID);
                        txtPurRack.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmBatchno" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmMRP" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate"
                    || grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductExpiryDate" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductBatchNo" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductMrp")
                {
                    e.Control.KeyPress -= udfnHandleKeyPressGRD1;
                    e.Control.KeyPress += udfnHandleKeyPressGRD1;
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmPicode")
                {
                    TextBox txtProduct = e.Control as TextBox;
                    int varCOMID = Convert.ToInt16(cmbConcern.SelectedValue);
                    txtProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtProduct.AutoCompleteCustomSource = AutoCompleteProduct(varCOMID);
                    txtProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmCondition")
                {
                    TextBox txtProduct = e.Control as TextBox;
                    txtProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtProduct.AutoCompleteCustomSource = AutoCompleteProductCondition();
                    txtProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (tbDetails.SelectedIndex == 0)
                {
                    if (grdSupplierList.Enabled == true)
                    {
                        if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmGrnMrp" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmMRP")
                        {
                            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                            {
                                e.Handled = true;
                            }
                            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                            {
                                e.Handled = true;
                            }
                        }
                    }
                }
                if (tbDetails.SelectedIndex == 1)
                {
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmPOqty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty"
                        || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmRecqty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiffqty"
                        || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscAmt" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer"
                        || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmPurchaseRate" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmFreeqty")
                    {
                        if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                        {
                            e.Handled = true;
                        }
                        if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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

        private void udfnHandleKeyPressGRD1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmMRP" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductMrp")
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
                    if (vartb.Text.Length >= 7 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmBatchno" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductBatchNo")
                {
                    TextBox vartb = sender as TextBox;
                    if (vartb.Text.Length >= 10 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductExpiryDate"
                    || grdSupplierList.CurrentCell.OwningColumn.Name == "clmInwardDate")
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdSupplierList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToString(lblSupplierCode.Text) != "0")
                {
                    VarGridError = "0";
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cellSlname = dataGridView.Rows[e.RowIndex].Cells["clmLocation"];
                    DataGridViewCell cellSlid = dataGridView.Rows[e.RowIndex].Cells["slid"];
                    DataGridViewCell cellRkname = dataGridView.Rows[e.RowIndex].Cells["clmrack"];
                    DataGridViewCell cellRkid = dataGridView.Rows[e.RowIndex].Cells["rkid"];
                    DataGridViewCell cellRkcount = dataGridView.Rows[e.RowIndex].Cells["clmrkcount"];
                    DataGridViewCell cellSno = dataGridView.Rows[e.RowIndex].Cells["clmsno"];
                    DataGridViewCell cellProConditionID = dataGridView.Rows[e.RowIndex].Cells["clmConditionID"];

                    int varsno = Convert.ToInt16(grdSupplierList.Rows[e.RowIndex].Cells["clmsno"].Value);
                    var varRowsToUpdate = dtPurchaseAutoComplete.AsEnumerable().Where(r => r.Field<int>("SNo") == Convert.ToInt16(varsno));

                    if (e.ColumnIndex == grdSupplierList.Columns["clmLocation"].Index && e.RowIndex >= 0)
                    {
                        string SelectedLocationName = grdSupplierList.Rows[e.RowIndex].Cells["clmLocation"].Value?.ToString();
                        if (!string.IsNullOrEmpty(SelectedLocationName))
                        {
                            /* Check purchase location is valid or not*/
                            string varId_PurLocation = "0", varRkCount = "0";
                            DataSet objDsPurLoc = new DataSet();
                            SPDataService objDServ3 = new SPDataService();
                            objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, SelectedLocationName, 0, 0, 0, "", "", 0);
                            objDServ3.CloseConnection();
                            if (objDsPurLoc != null)
                            {
                                if (objDsPurLoc.Tables.Count > 0)
                                {
                                    if (objDsPurLoc.Tables[0].Rows.Count > 0)
                                    {
                                        varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                                    }
                                }
                                if (objDsPurLoc.Tables[1].Rows.Count > 0)
                                {
                                    varRkCount = Convert.ToString(objDsPurLoc.Tables[1].Rows[0][0]);
                                }
                            }
                            if (varRkCount == "0")
                            {
                                cellRkid.Value = varRkCount;
                                cellRkname.Value = "None";
                                cellRkcount.Value = 0;
                                cellRkname.ReadOnly = true; cellRkname.Style.BackColor = Color.LightGray;
                            }
                            else
                            {
                                cellRkid.Value = "-1";
                                cellRkname.Value = "";
                                cellRkcount.Value = 0;
                                cellRkname.ReadOnly = false; cellRkname.Style.BackColor = Color.PaleGreen;
                            }
                            if (varId_PurLocation != "-1")
                            {
                                cellSlname.Style.BackColor = Color.PaleGreen;
                                cellSlid.Value = Convert.ToString(varId_PurLocation);
                            }
                            else
                            {
                                cellSlname.Style.BackColor = Color.LightPink;
                                cellSlid.Value = Convert.ToString(varId_PurLocation);
                                VarGridError = "1";
                            }
                            foreach (var row in varRowsToUpdate)
                            { row.SetField("SLID", cellSlid); row.SetField("RKID", cellRkid); }
                        }
                    }
                    else if (e.ColumnIndex == grdSupplierList.Columns["clmRack"].Index && e.RowIndex >= 0)
                    {
                        if (Convert.ToString(cellSlid.Value) != "-1")
                        {
                            string SelectedRackName = grdSupplierList.Rows[e.RowIndex].Cells["clmRack"].Value?.ToString().Trim().ToLower();
                            if (!string.IsNullOrEmpty(SelectedRackName))
                            {
                                /*check location have a rack or not*/
                                string varId_PurchaseRack = "0";
                                DataSet objDsPurchaseRack = new DataSet();
                                SPDataService objDServ6 = new SPDataService();
                                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(cellSlid.Value), 0, SelectedRackName, 0, 0);
                                objDServ6.CloseConnection();
                                if (objDsPurchaseRack != null)
                                {
                                    if (objDsPurchaseRack.Tables.Count > 0)
                                    {
                                        if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                        {
                                            varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                        }
                                    }
                                }
                                if (varId_PurchaseRack != "-1" || SelectedRackName.ToLower() == "none")
                                {
                                    cellRkname.Style.BackColor = Color.PaleGreen;
                                    cellRkid.Value = Convert.ToString(varId_PurchaseRack);
                                }
                                else
                                {
                                    cellRkname.Style.BackColor = Color.LightPink;
                                    cellRkid.Value = Convert.ToString(varId_PurchaseRack);
                                    VarGridError = "1";
                                }
                            }
                            foreach (var row in varRowsToUpdate)
                            { row.SetField("RKID", cellRkid); }
                        }
                    }
                    else if (e.ColumnIndex == grdSupplierList.Columns["clmCondition"].Index && e.RowIndex >= 0)
                    {
                        string varConditionID = "0";
                        string SelectedProductCondition = grdSupplierList.Rows[e.RowIndex].Cells["clmCondition"].Value?.ToString().Trim().ToLower();
                        if (!string.IsNullOrEmpty(SelectedProductCondition))
                        {
                            var varRemoveProuct = (from r in objDtProductCondition.AsEnumerable()
                                                   where (r.Field<string>("MST_DisplayText").ToLower().Equals(SelectedProductCondition.ToLower()))
                                                   select r.Field<int>("MSTID")).ToList();

                            if (varRemoveProuct.Count() != 0)
                            {
                                varConditionID = Convert.ToString(varRemoveProuct[0]);
                                cellProConditionID.Value = Convert.ToInt16(varConditionID);
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
        public void udfnConvertProductDetails(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(grdSupplierList.Rows.Count - 1);
                string SelectedPICode = grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmPicode"].Value?.ToString();
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewCell cellPICode = dataGridView.Rows[row].Cells["clmPicode"];
                DataGridViewCell cellPrid = dataGridView.Rows[row].Cells["clmProid"];
                DataGridViewCell cellUnit = dataGridView.Rows[row].Cells["clmUnit"];
                DataGridViewCell cellProductName = dataGridView.Rows[row].Cells["clmProTname"];
                DataGridViewCell cellUTID = dataGridView.Rows[row].Cells["UTID"];
                DataGridViewCell cellMismatchqty = dataGridView.Rows[row].Cells["clmMismatchQty"];
                DataGridViewCell cellGRNMrp = dataGridView.Rows[row].Cells["clmGrnMrp"];
                DataGridViewCell cellMrp = dataGridView.Rows[row].Cells["clmMRP"];
                DataGridViewCell cellProMrp = dataGridView.Rows[row].Cells["clmProductMrp"];
                DataGridViewCell cellExpiryDate = dataGridView.Rows[row].Cells["clmexpirydate"];
                DataGridViewCell cellProExpiryDate = dataGridView.Rows[row].Cells["clmProductExpiryDate"];
                DataGridViewCell cellShelfLife = dataGridView.Rows[row].Cells["clmShelflife"];
                DataGridViewCell cellActualShelfLife = dataGridView.Rows[row].Cells["clmactuallife"];
                DataGridViewCell cellShelfLifePer = dataGridView.Rows[row].Cells["clmshelfper"];
                DataGridViewCell cellBatchNo = dataGridView.Rows[row].Cells["clmBatchno"];
                DataGridViewCell cellProBatchNo = dataGridView.Rows[row].Cells["clmProductBatchNo"];
                DataGridViewCell cellBatchenable = dataGridView.Rows[row].Cells["clmBatchenable"];
                DataGridViewCell cellBatchgeneration = dataGridView.Rows[row].Cells["clmBatchgeneration"];
                DataGridViewCell cellLocation = dataGridView.Rows[row].Cells["clmLocation"];
                DataGridViewCell cellRack = dataGridView.Rows[row].Cells["clmrack"];
                DataGridViewCell cellProductType = dataGridView.Rows[row].Cells["clmid"]; //Product Entry Type
                DataGridViewCell cellPRID = dataGridView.Rows[row].Cells["clmProid"];
                DataGridViewCell cellShelfLifeEnable = dataGridView.Rows[row].Cells["clmShelflifeenable"];
                DataGridViewCell cellSLID = dataGridView.Rows[row].Cells["slid"];
                DataGridViewCell cellRKID = dataGridView.Rows[row].Cells["rkid"];
                DataGridViewCell cellRKCount = dataGridView.Rows[row].Cells["clmrkcount"];
                DataGridViewCell cellHSNID = dataGridView.Rows[row].Cells["clmHSNid"];
                DataGridViewCell cellMRPFlag = dataGridView.Rows[row].Cells["clmMrpFlag"];
                DataGridViewCell cellRMFlag = dataGridView.Rows[row].Cells["clmRMFlag"];
                DataGridViewCell cellProCondition = dataGridView.Rows[row].Cells["clmCondition"];

                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 61;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.ParaScheduleid = lblschedule.Text;
                objMR_Product.ParaProductCode = 0;
                objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                objMR_Product.paraPicode = SelectedPICode;
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    string varPRID = "0", varBatchNoEnable = "0", varBatchNoGeneration = "0", varRMProduction = "0", varPrcategory = "0",
                     varShelflifeFlag = "0", varShelflife = "0", varDecimal = "0", varHSNid = "0", varPrMRPFlag = "0", varProductMRPFlag = "0",
                     varproTname = "", varUnit = "", varGRNmrp = "0", varBatchNo = "", varProBatchNo = "", varExpiryDate = "", varProExpiryDate = "", varRMProductionFlag = "0", varLocationName = "", varLocationID = "0",
                     varRackName = "", varRackID = "0", varRkcount = "0", varRMFlag = "0", varUTID = "0";
                    string varProductType = "217"; //Product type againt grn -none

                    varPRID = Convert.ToString(objDs.Tables[0].Rows[0]["PRID"]);
                    varproTname = Convert.ToString(objDs.Tables[0].Rows[0]["PR_TName"]);
                    varUnit = Convert.ToString(objDs.Tables[0].Rows[0]["UT_Symbol"]);
                    varUTID = Convert.ToString(objDs.Tables[0].Rows[0]["UTID"]);
                    varBatchNoEnable = Convert.ToString(objDs.Tables[0].Rows[0]["PR_BatchNo"]);
                    varBatchNoGeneration = Convert.ToString(objDs.Tables[0].Rows[0]["PR_BatchNoGeneration"]);
                    varPrMRPFlag = Convert.ToString(objDs.Tables[0].Rows[0]["PR_MRPflag"]);
                    varProductMRPFlag = Convert.ToString(objDs.Tables[0].Rows[0]["PR_MRPflag"]);
                    varRMFlag = Convert.ToString(objDs.Tables[0].Rows[0]["RM Flag"]);
                    varShelflifeFlag = Convert.ToString(objDs.Tables[0].Rows[0]["ShelfLife Flag"]);
                    varHSNid = Convert.ToString(objDs.Tables[0].Rows[0]["PR_HSNID"]);
                    varShelflife = Convert.ToString(objDs.Tables[0].Rows[0]["Product Shelf Life"]);
                    varLocationID = Convert.ToString(objDs.Tables[0].Rows[0]["Location ID"]);
                    varLocationName = Convert.ToString(objDs.Tables[0].Rows[0]["Location"]);
                    varRackID = Convert.ToString(objDs.Tables[0].Rows[0]["RKID"]);
                    varRackName = Convert.ToString(objDs.Tables[0].Rows[0]["Rack"]);
                    varRkcount = Convert.ToString(objDs.Tables[0].Rows[0]["RackCount"]);
                    varBatchNo = Convert.ToString(objDs.Tables[0].Rows[0]["BatchNo"]);
                    varProBatchNo = Convert.ToString(objDs.Tables[0].Rows[0]["BatchNo"]);
                    varExpiryDate = Convert.ToString(objDs.Tables[1].Rows[0]["Expiry Date"]);
                    varProExpiryDate = Convert.ToString(objDs.Tables[1].Rows[0]["Expiry Date"]);

                    cellPrid.Value = varPRID;
                    cellProductName.Value = varproTname;
                    cellUnit.Value = varUnit;
                    cellUTID.Value = varUTID;
                    cellBatchenable.Value = varBatchNoEnable;
                    cellBatchgeneration.Value = varBatchNoGeneration;
                    cellMRPFlag.Value = varPrMRPFlag;
                    cellShelfLifeEnable.Value = varShelflifeFlag;
                    cellRMFlag.Value = varRMFlag;
                    cellHSNID.Value = varHSNid;
                    cellShelfLife.Value = varShelflife;
                    cellSLID.Value = varLocationID;
                    cellLocation.Value = varLocationName;
                    cellRKID.Value = varRackID;
                    cellRack.Value = varRackName;
                    //cellBatchNo.Value = varBatchNo;
                    cellProBatchNo.Value = varBatchNo;
                    //cellExpiryDate.Value = varExpiryDate;
                    //cellProExpiryDate.Value = varExpiryDate;
                    cellProductType.Value = varProductType;

                    cellShelfLife.ReadOnly = true;
                    if (varPrMRPFlag == "0")
                    {
                        cellMrp.Style.BackColor = Color.LightGray; cellMrp.Style.ForeColor = Color.Black;
                        cellMrp.ReadOnly = true; cellMrp.Value = "0.00";
                        cellProMrp.Style.BackColor = Color.LightGray; cellProMrp.Style.ForeColor = Color.Black;
                        cellProMrp.ReadOnly = true; cellProMrp.Value = "0.00";
                    }
                    else
                    {
                        cellMrp.Style.BackColor = Color.PaleGreen;
                        cellMrp.Style.ForeColor = Color.Black; cellMrp.ReadOnly = false;
                        cellProMrp.Style.BackColor = Color.PaleGreen;
                        cellProMrp.Style.ForeColor = Color.Black; cellProMrp.ReadOnly = false;
                    }
                    if (varShelflifeFlag == "0")
                    {
                        cellShelfLife.Value = "";
                        cellExpiryDate.Style.BackColor = Color.LightGray;
                        cellExpiryDate.ReadOnly = true;
                        cellProExpiryDate.Style.BackColor = Color.LightGray;
                        cellProExpiryDate.ReadOnly = true;
                    }
                    else
                    {
                        cellExpiryDate.Style.BackColor = Color.PaleGreen; cellExpiryDate.ReadOnly = false;
                        cellProExpiryDate.Style.BackColor = Color.PaleGreen; cellProExpiryDate.ReadOnly = false;
                    }
                    if (varBatchNoEnable == "73")
                    {
                        cellBatchNo.Style.BackColor = Color.LightGray;
                        cellBatchNo.Style.ForeColor = Color.Black;
                        cellBatchNo.ReadOnly = true;
                        cellBatchNo.Value = "";
                        cellProBatchNo.Style.BackColor = Color.LightGray;
                        cellProBatchNo.Style.ForeColor = Color.Black;
                        cellProBatchNo.ReadOnly = true;
                        cellProBatchNo.Value = "";
                    }
                    else if (varBatchNoEnable == "72")
                    {
                        if (varBatchNoGeneration == "75") //manul
                        {
                            cellBatchNo.Style.BackColor = Color.PaleGreen; cellBatchNo.Style.ForeColor = Color.Black;
                            cellBatchNo.ReadOnly = false; cellBatchNo.Value = "";
                            cellProBatchNo.Style.BackColor = Color.PaleGreen; cellProBatchNo.Style.ForeColor = Color.Black;
                            cellProBatchNo.ReadOnly = false; cellProBatchNo.Value = "";
                        }
                        else if (varBatchNoGeneration == "74")//Auto
                        {
                            cellBatchNo.Style.BackColor = Color.LightGray; cellBatchNo.Style.ForeColor = Color.Black;
                            cellBatchNo.ReadOnly = true;
                            cellProBatchNo.Style.BackColor = Color.LightGray; cellProBatchNo.Style.ForeColor = Color.Black;
                            cellProBatchNo.ReadOnly = true;
                        }
                    }
                    if (varRMProductionFlag == "1")
                    {
                        cellExpiryDate.Style.BackColor = Color.LightGray;
                        cellExpiryDate.Style.ForeColor = Color.Black;
                        cellExpiryDate.ReadOnly = true;
                        cellProExpiryDate.Style.BackColor = Color.LightGray;
                        cellProExpiryDate.Style.ForeColor = Color.Black;
                        cellProExpiryDate.ReadOnly = true;
                    } 
                    cellPICode.ReadOnly = true;
                    cellPrid.ReadOnly = true;
                    cellUnit.ReadOnly = true;
                    cellProductName.ReadOnly = true;
                    cellUTID.ReadOnly = true; 
                    //cellProCondition.ReadOnly = false;
                    //cellGRNMrp.ReadOnly = true;
                    //cellMrp.ReadOnly = true;
                    //cellProMrp.ReadOnly = true;
                    //cellExpiryDate.ReadOnly = true;
                    //cellProExpiryDate.ReadOnly = true;
                    cellShelfLife.ReadOnly = true;
                    cellActualShelfLife.ReadOnly = true;
                    cellShelfLifePer.ReadOnly = true;
                    //cellBatchNo.ReadOnly = true;
                    //cellProBatchNo.ReadOnly = true;
                    //cellBatchenable.ReadOnly = true;
                    //cellBatchgeneration.ReadOnly = true;
                    //cellLocation.ReadOnly = true;
                    //cellRack.ReadOnly = true;
                    //cellProductType.ReadOnly = true;
                    //cellPRID.ReadOnly = true;
                    //cellShelfLifeEnable.ReadOnly = true;
                    //cellSLID.ReadOnly = true;
                    //cellRKID.ReadOnly = true;
                      
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                varUpDownKey = 0;
                txtMrp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMrp.BackColor = Color.White;
                if (txtMrp.Text.Trim() != "")
                {
                    string mrp = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtMrp.Text = mrp;
                }
                if (varPrMRPFlag == "1" && (txtMrp.Text.Trim() == "" || Convert.ToDecimal(txtMrp.Text) == 0))
                {
                    txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errPurchaseentry.SetError(txtMrp, "Please enter MRP.");
                    tpmrp.ShowAlways = true;
                    tpmrp.Show("Please enter MRP.", txtMrp, 5000);
                }
                else
                {
                    txtMrp.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtDate.Enabled == true)
                    { txtDate.Focus(); }
                    else if (txtBatchno.Enabled == true)
                    { txtBatchno.Focus(); }
                    else if (txtSourceLocation.Enabled == true)
                    { txtSourceLocation.Focus(); }
                    else if (cmbrack.Enabled == true)
                    { cmbrack.Focus(); }
                    else { btnAdd.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvSourceLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLocationset();
                udfnCmbSourceRack();
                if (cmbrack.Enabled == true)
                {
                    cmbrack.Focus();
                }
                else
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
        public void udfnLocationset()
        {
            try
            {
                if (txtSourceLocation.Text != "")
                {
                    ListViewItem selectedItem = lvSourceLocation.SelectedItems[0];
                    txtSourceLocation.Text = selectedItem.SubItems[0].Text;
                    lblLocationcode.Text = Convert.ToString(selectedItem.SubItems[1].Text);
                    lvSourceLocation.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbSourceRack()
        {
            try
            {
                if (Convert.ToInt32(lblLocationcode.Text) != 0 && Convert.ToString(txtSourceLocation.Text) != "")
                {
                    DataSet objDs = new DataSet();
                    SPDataService objdserv = new SPDataService();
                    objDs = objdserv.udfnRackList(7, 0, 0, Convert.ToInt32(lblLocationcode.Text), 0, "", 0, 0);
                    objdserv.CloseConnection();
                    cmbrack.DataSource = null;
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count > 0)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToInt32(objDs.Tables[0].Rows[0][0]) == 0)
                                {
                                    cmbrack.Text = "None";
                                    cmbrack.Enabled = false;
                                }
                                else
                                {
                                    if (objDs.Tables[0].Rows.Count > 0)
                                    {
                                        cmbrack.ValueMember = "RKID";
                                        cmbrack.DisplayMember = "RK_ShortName";
                                        cmbrack.DataSource = objDs.Tables[0];
                                        cmbrack.Enabled = true;
                                    }
                                }
                            }
                            else
                            {
                                cmbrack.Text = "None";
                                cmbrack.Enabled = false;
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
        private void TxtSourceLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSourceLocation.Items.Clear();
                if (txtSourceLocation.Text.Length > 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnStockLocationList(31, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSourceLocation.Text, 0, 0, 0, "", "", 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSourceLocation.Columns[1].Width = 0;
                                    lvSourceLocation.Items.Add(objList);
                                }
                                lvSourceLocation.Visible = true;
                            }
                            else
                            {
                                lvSourceLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvSourceLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvSourceLocation.Visible = false;
                    }
                }
                else
                {
                    lvSourceLocation.Visible = false;
                    lvSourceLocation.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSourceLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbrack.Enabled == true)
                    {
                        cmbrack.Focus();
                    }
                    else { btnAdd.Focus(); }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSourceLocation.Items.Count == 0 || txtSourceLocation.Text == "")
                    {
                        txtSourceLocation.Focus();
                        lvSourceLocation.Visible = false;
                    }
                    else
                    {
                        lvSourceLocation.Focus();
                    }
                    if (lvSourceLocation.Items.Count > 0)
                    {
                        lvSourceLocation.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvSourceLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLocationset();
                    udfnCmbSourceRack();
                    if (cmbrack.Enabled == true)
                    {
                        cmbrack.Focus();
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
        private void TxtSourceLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSourceLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSourceLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSourceLocation.Text == "")
                {
                    txtSourceLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errPurchaseentry.SetError(txtSourceLocation, "Please select source location.");
                }
                else
                {
                    txtSourceLocation.BackColor = Color.White;
                    errPurchaseentry.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmbrack_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbrack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmbrack_KeyDown(object sender, KeyEventArgs e)
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
        private void Cmbrack_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbrack.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmbrack_KeyPress(object sender, KeyPressEventArgs e)
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
                        errPurchaseentry.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        errPurchaseentry.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errPurchaseentry.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        errPurchaseentry.Clear();
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
                        errPurchaseentry.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        errPurchaseentry.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errPurchaseentry.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        errPurchaseentry.Clear();
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
                        txtSourceLocation.Focus();
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
                    if (txtSourceLocation.Enabled == true)
                    { txtSourceLocation.Focus(); }
                    else if (cmbrack.Enabled == true)
                    { cmbrack.Focus(); }
                    else { btnAdd.Focus(); }
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
                        errPurchaseentry.SetError(txtBatchno, "Please enter BatchNo.");
                        tpbatchno.ShowAlways = true;
                        tpbatchno.Show("Please enter BatchNo.", txtBatchno, 5000);
                    }
                    else
                    {
                        txtBatchno.BackColor = Color.White;
                        errPurchaseentry.Clear();
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
        private void CmbPONo_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPONo.BackColor = Color.LemonChiffon;
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
                cmbPONo.BackColor = Color.White;
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
        private void TxtMrp_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtMonth_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtYear_KeyPress(object sender, KeyPressEventArgs e)
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
        public void udfnProductCount()
        {
            try
            {
                varPrid = "";
                int varProductType = Convert.ToInt16(cmbPONo.SelectedValue);
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
                    if (Convert.ToString(cmbPONo.SelectedValue) == "215")
                    {
                        tsbAddedProduct.Text = Convert.ToString(varProIds.Count());
                        tsbRemainingProduct.Text = Convert.ToString(Convert.ToInt32(tsbTotalProducts.Text) - varProIds.Count());
                    }
                }
                if (varProductType == 218) //218-GRN 
                {
                    var varProIds = from r in dtPurchaseAutoComplete.AsEnumerable()
                                    where (r.Field<int>("Flag").Equals(varProductType) && r.Field<int>("ID").Equals(Convert.ToInt32(varId)))
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
                    if (Convert.ToInt32(varProIds.Count()) != 0)
                    {
                        tsbRemainingProduct.Text = Convert.ToString(Convert.ToInt32(tsbRemainingProduct.Text) - 1);
                        tsbAddedProduct.Text = Convert.ToString(Convert.ToInt32(tsbTotalProducts.Text) - Convert.ToInt32(tsbRemainingProduct.Text));
                    }
                }
                if (varProductType == 220) //  220 - DC
                {
                    var varProIds = from r in dtPurchaseAutoComplete.AsEnumerable()
                                    where (r.Field<int>("Flag").Equals(varProductType))
                                    group r by new
                                    {
                                        PRID = r["PRID"],
                                        MRP = r["MRP"],
                                        ExpiryDate = r["ExpiryDate"],
                                        BatchNo = r["BatchNo"],
                                        SLID = r["SLID"],
                                        RKID = r["RKID"]
                                    } into g
                                    select g;
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
                    if (Convert.ToInt32(varProIds.Count()) != 0)
                    {
                        tsbAddedProduct.Text = Convert.ToString(varProIds.Count());
                        tsbRemainingProduct.Text = Convert.ToString(Convert.ToInt32(tsbTotalProducts.Text) - varProIds.Count());
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPoDropdownDisable()
        {
            try
            {
                if (Convert.ToString(cmbEntryType.SelectedValue) == "54") //Grn
                {
                    if (tsbRemainingProduct.Text == "0")
                    { cmbPONo.SelectedValue = 217; cmbPONo.Enabled = false; }
                    else { cmbPONo.Enabled = true; }
                }
                else if (Convert.ToString(cmbEntryType.SelectedValue) == "57") //DC
                {
                    if (tsbRemainingProduct.Text == "0")
                    { cmbPONo.SelectedValue = 219; cmbPONo.Enabled = false; }
                    else { cmbPONo.Enabled = true; }
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
                //udfnProductCount();
                udfnPoDropdownDisable();
                if (grdSupplierList.Rows.Count != 0)
                {
                    if (grdReurnDC.Rows.Count != 0)
                    { grdReurnDC.Columns["clmRemoveDC"].Visible = false; }
                    if (grdPODetails.Rows.Count != 0)
                    { grdPODetails.Columns["clmRemovePO"].Visible = false; }
                }
                else
                {
                    if (grdReurnDC.Rows.Count != 0)
                    { grdReurnDC.Columns["clmRemoveDC"].Visible = true; }
                    if (grdReurnDC.Rows.Count != 0)
                    { grdPODetails.Columns["clmRemovePO"].Visible = true; }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count);
            }
        }
        public void udfnEntryTypeErr()
        {
            try
            {
                int varmsgID = 0;
                if (varTypeErrId == "0")
                {
                    if (Convert.ToInt32(cmbEntryType.SelectedValue) == 54) //against grn
                    {
                        if (Convert.ToString(pbGRNNo) == "0")
                        { varerrFlag = 1; varmsgID = 105; }
                        else
                        { varerrFlag = 0; }
                    }
                    if (Convert.ToInt32(cmbEntryType.SelectedValue) == 55) //against po
                    {
                        if (Convert.ToString(pbPONO) == "0")
                        { varerrFlag = 1; varmsgID = 81; }
                        else
                        { varerrFlag = 0; }
                    }
                    if (Convert.ToInt32(cmbEntryType.SelectedValue) == 57) //against dc
                    {
                        if (Convert.ToString(pbDCNo) == "0")
                        { varerrFlag = 1; varmsgID = 106; }
                        else
                        { varerrFlag = 0; }
                    }
                    if (varerrFlag == 1)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(varmsgID);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                { varerrFlag = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEntryTypeDate()
        {
            try
            {
                varEntryTypeDate = "";
                if (Convert.ToString(cmbPONo.SelectedValue) == "218")  //product type GRN
                { varEntryTypeDate = varGRNDate; }
                else if (Convert.ToString(cmbPONo.SelectedValue) == "220")  //product type DC
                { varEntryTypeDate = varDCDate; }
                else { varEntryTypeDate = varVoucherDate; }
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
                DGV_FilterProduct.Visible = false;
                varExpiryDate = ""; varExpiryDateAdd = ""; varPrid = "0";varLPFlag = 0; varNoDiffFlag = 0; varProValidation = 0; varReasonFlag = 0; 
                int varSourceLocationID = 0; String varPurProductType = "";
                int varProConFlag = 0,varConCheckFlag=0; String varQuantityType = "";
                  
                if(Convert.ToString(cmbPONo.SelectedValue) == "214" || Convert.ToString(cmbPONo.SelectedValue) == "217" || Convert.ToString(cmbPONo.SelectedValue) == "219")
                {
                    varProConFlag = 1;
                } 
                var conditionSet = new HashSet<string>(pbConditionIDs.Split(',')); 
                if(conditionSet.Contains("281") || conditionSet.Contains("278") || conditionSet.Contains("277") || conditionSet.Contains("276") || conditionSet.Contains("279"))
                {
                    varConCheckFlag = 1;
                } 
                if (conditionSet.Contains("281") == true) //Line item pending
                { varLPFlag = 1; }
                if (conditionSet.Contains("275") == true) //No difference
                { varNoDiffFlag = 1; }
                if (conditionSet.Contains("281") == true || conditionSet.Contains("280") == true || conditionSet.Contains("275") == true)
                { varReasonFlag = 1; }
                if (conditionSet.Contains("281") == true || conditionSet.Contains("280") == true || Convert.ToInt16(cmbReason.SelectedValue) == 284)
                { varProValidation = 1; } //No need to validte product details
                udfnEntryTypeDate(); 
                if (varReasonFlag == 0)
                {
                    if (Convert.ToInt32(cmbReason.SelectedValue) == 286)
                    {
                        errPurchaseentry.SetError(cmbReason, "Please select valid reason.");
                        cmbReason.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpReason.ShowAlways = true;
                        tpReason.Show("Please select valid reason.", txtProductName, 5000);
                        varErrorFlag = true;
                    }
                }
                if (varNoDiffFlag == 0 && txtMismatchQty.Text.Trim() == "")
                {
                    errPurchaseentry.SetError(txtMismatchQty, "Please enter quantity");
                    txtMismatchQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoiceQty.ShowAlways = true;
                    tpInvoiceQty.Show("Please enter quantity", txtMismatchQty, 5000);
                    varErrorFlag = true;
                }
                /* Check  source location is valid or not*/
                if (varConCheckFlag==0 || varProConFlag==1)
                {
                    if (txtSourceLocation.Text != "" && varRMFlag != 59 && Convert.ToString(cmbPONo.SelectedValue) != "220")
                    {
                        string varId_SourceLocation = "0";
                        DataSet objDsSourceLoc = new DataSet();
                        SPDataService objDServ3 = new SPDataService();
                        objDsSourceLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSourceLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        objDServ3.CloseConnection();
                        if (objDsSourceLoc != null)
                        {
                            if (objDsSourceLoc.Tables.Count > 0)
                            {
                                if (objDsSourceLoc.Tables[0].Rows.Count > 0)
                                {
                                    varId_SourceLocation = Convert.ToString(objDsSourceLoc.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        varSourceLocationID = Convert.ToInt32(varId_SourceLocation);
                        if (varProValidation == 0)
                        {
                            if (varId_SourceLocation == "0" || varId_SourceLocation == "-1")
                            {
                                errPurchaseentry.SetError(txtSourceLocation, "Please select valid location.");
                                txtSourceLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpStockLocation.ShowAlways = true;
                                tpStockLocation.Show("Please select valid location.", txtSourceLocation, 5000);
                                varErrorFlag = true;
                            }
                        }
                    } 
                    if (varPrMRPFlag == "1" && (txtMrp.Text.Trim() == "" || Convert.ToDecimal(txtMrp.Text) == 0) && varProValidation==0)
                    {
                        txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errPurchaseentry.SetError(txtMrp, "Please enter MRP.");
                        tpmrp.ShowAlways = true;
                        tpmrp.Show("Please enter MRP.", txtMrp, 5000);
                        varErrorFlag = true;
                    }
                    if (txtProductName.Text == "")
                    {
                        errPurchaseentry.SetError(txtProductName, "Please enter product");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpProduct.ShowAlways = true;
                        tpProduct.Show("Please enter product.", txtProductName, 5000);
                        varErrorFlag = true;
                    }
                } 
                /*check location have a rack or not*/
                if (varRMFlag != 59 && Convert.ToString(cmbPONo.SelectedValue) != "220" &&   varProValidation==0 || varProConFlag==1)
                {
                    string varId_PurchaseRack = "0";
                    string varId_PurchaseRackCount = "0";
                    DataSet objDsPurchaseRack = new DataSet();
                    SPDataService objDServ6 = new SPDataService();
                    objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(lblLocationcode.Text), 0, cmbrack.Text.Trim(), 0, 0);
                    objDServ6.CloseConnection();
                    if (Convert.ToInt32(cmbrack.SelectedValue) != -1)
                    {
                        if (lblLocationcode.Text != "0")
                        {
                            if (objDsPurchaseRack != null)
                            {
                                if (objDsPurchaseRack.Tables.Count > 0)
                                {
                                    if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                    {
                                        varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                    }
                                    if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                    {
                                        varId_PurchaseRackCount = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                    }
                                    if (varId_PurchaseRackCount == "0")
                                    { varId_PurchaseRack = "0"; }
                                }
                            } 
                            if (Convert.ToString(cmbrack.Text.Trim().ToLower()) != "none")
                            {
                                if (Convert.ToInt32(varId_PurchaseRackCount) > 0)
                                {
                                    if (Convert.ToInt32(varId_PurchaseRack) < 0 || varId_PurchaseRack == "-1")
                                    {
                                        errPurchaseentry.SetError(cmbrack, "Please enter valid rack.");
                                        cmbrack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                        tpRack.ShowAlways = true;
                                        tpRack.Show("Please enter valid rack.", cmbrack, 5000);
                                        varErrorFlag = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (lblLocationcode.Text != "0")
                        {
                            if (objDsPurchaseRack != null)
                            {
                                if (objDsPurchaseRack.Tables.Count > 0)
                                {
                                    if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                    {
                                        varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                    }
                                }
                            } 
                            if (varProValidation == 0)
                            {
                                if (Convert.ToInt32(varId_PurchaseRack) > 0)
                                {
                                    errPurchaseentry.SetError(cmbrack, "Please enter rack.");
                                    cmbrack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpRack.ShowAlways = true;
                                    tpRack.Show("Please enter rack.", cmbrack, 5000);
                                    varErrorFlag = true;
                                }
                                if (varId_PurchaseRack == "0")
                                {
                                    cmbrack.Text = "None";
                                    cmbrack.Enabled = false; 
                                }
                                else
                                {
                                    cmbrack.Enabled = true;
                                }
                            }
                        }
                    }
                }
                if ((varConCheckFlag==0 || varProConFlag==1) && varProValidation ==0)
                {
                    if (varShelflife == 1)
                    {
                        if (txtMonth.Text.Trim() == "")
                        {
                            txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            errPurchaseentry.SetError(txtMonth, "Please enter month.");
                            varErrorFlag = true;
                        }
                        if (txtYear.Text.Trim() == "")
                        {
                            txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            errPurchaseentry.SetError(txtYear, "Please enter year.");
                            varErrorFlag = true;
                        }
                    }
                    if (txtSourceLocation.Text == "")
                    {
                        txtSourceLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errPurchaseentry.SetError(txtSourceLocation, "Please select location.");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please select location.", txtSourceLocation, 5000);
                        varErrorFlag = true;
                    }
                    if (varBatchNoGeneration == "75")
                    {
                        if (txtBatchno.Text.Trim() == "")
                        {
                            txtBatchno.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            errPurchaseentry.SetError(txtBatchno, "Please enter BatchNo.");
                            tpbatchno.ShowAlways = true;
                            tpbatchno.Show("Please enter Batch No.", txtBatchno, 5000);
                            varErrorFlag = true;
                        }
                    }
                } 
                if (varErrorFlag == false)
                {
                    int varflag = 0;
                    string varShelflifevalue = "", varAcutalshelflife = "", varProMrp = "", varProExpiry = "", varProBatchNo = "", varCondition = "";
                    lblNoRecordsFound.Visible = false;
                    if (varProValidation == 0 || varProConFlag==0 || varProConFlag==1)
                    {
                        if ((expirydateFlag == 1 || varProValidation==0) && (txtDate.Text != "" || txtMonth.Text != "" || txtYear.Text != ""))
                        {
                            udfnDatevalidationset();
                        }
                    }
                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    if (varExpiryDate != "")
                    {
                        MR_Master objMR_Master = new MR_Master();
                        objMR_Master.ViewType = 7;
                        objMR_Master.paraDate = varEntryTypeDate;
                        objMR_Master.ParaExpiryDate = varExpiryDate;
                        objMR_Master.paraProductId = Convert.ToInt32(lblProductcode.Text.Trim());
                        objDS = objDServ.udfnMaster(objMR_Master);
                        objDServ.CloseConnection();
                        if (expirydateFlag == 1)
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(objDS.Tables[0].Rows[0]["DATEVALIDATE"]) == "0")
                                {
                                    errPurchaseentry.SetError(txtDate, "Invalid expiry date");
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
                        else
                        {
                            if (objDS.Tables[2].Rows.Count > 0)
                            {
                                varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                            }
                        }
                    }  
                    if (Convert.ToInt32(lblSupplierCode.Text) != 0)
                    {
                        if (varflag == 0)
                        {
                            udfnEntryTypeErr();
                            if (pbDateflag == 0 && varerrFlag == 0)
                            {
                                varEditProAdd = 1;
                                errPurchaseentry.Clear();
                                tpdate.Active = false;
                                txtDate.BackColor = Color.White;
                                txtMonth.BackColor = Color.White;
                                txtYear.BackColor = Color.White;
                                txtSourceLocation.BackColor = Color.White;
                                cmbrack.BackColor = Color.White;
                                string[] varpono = cmbPONo.Text.Split('~');
                                string productCode = "0", varRackCount = "0", varRackId = "0", varMismatchQty = "0", varConditionsId = "0", varConditions = "";
                                var maxSno = 0;
                                decimal varMRP = 0, varGrnMrp = 0; string mrp = "0", mrp1 = "0";  

                                productCode = lblProductcode.Text;
                                if (cmbrack.Enabled == true)
                                {
                                    varRackCount = "1";
                                    varRackId = Convert.ToString(cmbrack.SelectedValue);
                                    if (cmbrack.SelectedValue == null)
                                    { varRackId = "0"; }
                                }
                                else
                                {
                                    varRackCount = "0";
                                    varRackId = "0";
                                }
                                if (cmbEntryType.SelectedValue.ToString() == "54" && txtGRNMrp.Text.Trim() != "") // GRN
                                {
                                    varGrnMrp = Convert.ToDecimal(txtGRNMrp.Text.Trim());
                                } 
                                if (Convert.ToString(cmbPONo.SelectedValue) == "220" || varPrInvFlag == "1") //Dc type -- Inward Received
                                { varRackId = varPrRkid; }
                                if (cmbEntryType.SelectedValue.ToString() == "54")
                                {
                                    varProMrp = varProductMRP;
                                    varProExpiry = varProductExpiry;
                                    varProBatchNo = varProductBatch;
                                }
                                else
                                {
                                    varProMrp = (txtMrp.Text).Trim();
                                    varProExpiry = (varExpiryDateAdd).Trim();
                                    varProBatchNo = (txtBatchno.Text).Trim();
                                }
                                if (grdSupplierList.Rows.Count > 0)
                                {
                                    maxSno = (from row in grdSupplierList.Rows.Cast<DataGridViewRow>()
                                              let snoValue = string.IsNullOrEmpty(Convert.ToString(row.Cells["clmsno"].Value)) ? 0 : Convert.ToInt32(row.Cells["clmsno"].Value)
                                              select snoValue).Max();
                                } 
                                if (Convert.ToString(txtMismatchQty.Text.Trim()) != "")
                                { varMismatchQty = Convert.ToString(txtMismatchQty.Text); }
                                
                                if (Convert.ToString(cmbPONo.Text) != "" && Convert.ToString(cmbPONo.Text) != "null")
                                { varPurProductType = Convert.ToString(cmbPONo.Text); }
                                else { varPurProductType = "None"; }

                                grdSupplierList.Rows.Add(maxSno + 1, null, varPurProductType, "", (varPICode).Trim(), (varTName).Trim(), (var_Symbol).Trim(), pbCondition, varMismatchQty,Convert.ToString(cmbReason.Text), varGrnMrp, (txtMrp.Text).Trim(), varProMrp, (varExpiryDateAdd).Trim()
                                , varProExpiry, (varexp).Trim(), varAcutalshelflife, varShelflifevalue, (txtBatchno.Text).Trim(), varProBatchNo, txtSourceLocation.Text, cmbrack.Text, cmbPONo.SelectedValue,  (productCode).Trim(), (varunitid).Trim(), varBatchNo, varBatchNoGeneration, expirydateFlag, lblLocationcode.Text, varRackId, varRackCount, 0, 0, 0, 0, 0, 0, varId, varPrInvFlag, varHSNid,  varPrMRPFlag, varGRNProType, varRMProductionFlag, varGrnType, pbConditionIDs, "0", "0", "0",Convert.ToString(cmbReason.SelectedValue));
                                  
                                if (varPrInvFlag == "1" && PbSTS != "0" && PbSTS != "49" )
                                { ((DataGridViewImageCell)grdSupplierList.Rows[grdSupplierList.RowCount - 1].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1); }
                                if (Convert.ToInt32(cmbPONo.SelectedValue) == 220 || MA_ReasonFlag == 1) //dc type
                                {
                                    grdSupplierList.Rows[grdSupplierList.RowCount - 1].ReadOnly = true;
                                } 
                                if (txtMrp.Text.Trim() != "")
                                {
                                    varMRP = Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                                    mrp = string.Format("{0:0.00}", varMRP);
                                    mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                                }
                                dtPurchaseAutoComplete.Rows.Add(maxSno + 1, productCode, mrp1, varExpiryDateAdd, (txtBatchno.Text).Trim(), varunitid, lblLocationcode.Text, (varRackId), expirydateFlag, Convert.ToInt16(cmbPONo.SelectedValue), varId);
                                varProductsIDs.Add(Convert.ToInt32(lblProductcode.Text));
                                udfnrowclear();
                                udfnConditionClear();
                                udfnProductCount();
                                txtProductName.Text = "";
                                lblProductcode.Text = "0";
                                txtProductName.BackColor = Color.White;
                                txtProductName.Focus(); 
                                string[] varShelflifeper = Convert.ToString(varShelflifevalue).Split(' ');
                                if (varShelflifeper[0] != "")
                                {
                                    if (Convert.ToDecimal(varShelflifeper[0]) < varShelflifeLevel1)
                                    {
                                        DataGridView dataGridView = grdSupplierList;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.Red;
                                        cell.Style.ForeColor = Color.White;
                                    }
                                    else if (Convert.ToDecimal(varShelflifeper[0]) < varShelflifeLevel2)
                                    {
                                        DataGridView dataGridView = grdSupplierList;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.Orange;
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                        DataGridView dataGridView = grdSupplierList;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.White;
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                }
                                if (varBatchNo == "72" && varBatchNoGeneration == "74")
                                {
                                    DataGridView dataGridView = grdSupplierList;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmProductBatchNo"];
                                    if (Convert.ToString(dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmConditionID"]) != "226")
                                    {
                                        cell.Style.BackColor = Color.LightGray; cell.Style.ForeColor = Color.Black;
                                        cell1.Style.BackColor = Color.LightGray; cell1.Style.ForeColor = Color.Black;
                                        cell1.ReadOnly = true;
                                    } 
                                }
                                else if (varBatchNo == "73")
                                {
                                    DataGridView dataGridView = grdSupplierList;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmProductBatchNo"];
                                    cell.Style.BackColor = Color.LightGray;  cell.Style.ForeColor = Color.Black;  cell.ReadOnly = true;
                                    cell1.Style.BackColor = Color.LightGray;  cell1.Style.ForeColor = Color.Black;  cell1.ReadOnly = true;
                                }
                                if (varRMProductionFlag == 1)
                                {
                                    DataGridView dataGridView = grdSupplierList;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmexpirydate"];
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmProductExpiryDate"];
                                    cell.Style.BackColor = Color.LightGray;   cell.Style.ForeColor = Color.Black;  cell.ReadOnly = true;
                                    cell1.Style.BackColor = Color.LightGray; cell1.Style.ForeColor = Color.Black; cell1.ReadOnly = true;
                                }
                                if(varNoDiffFlag==1)
                                {
                                    DataGridView dataGridView = grdSupplierList;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmMismatchQty"]; 
                                    cell.Style.BackColor = Color.LightGray; cell.Style.ForeColor = Color.Black; cell.ReadOnly = true; 
                                }
                                if(varPrMRPFlag=="0")
                                {
                                    DataGridView dataGridView = grdSupplierList;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmMRP"];
                                    DataGridViewCell cell1 = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmProductMrp"];
                                    cell.Style.BackColor = Color.LightGray; cell.Style.ForeColor = Color.Black; cell.ReadOnly = true;
                                    cell1.Style.BackColor = Color.LightGray; cell1.Style.ForeColor = Color.Black; cell1.ReadOnly = true;
                                }
                                if (varEditFlag == 1 && varEditProAdd == 1)
                                {
                                    chkCompleted.Checked = false;
                                    chkCompleted.Enabled = false;
                                }
                                if (Convert.ToString(grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmid"].Value) == "220")
                                {
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmProTname"].Style.BackColor = ColorTranslator.FromHtml("#FFD3B6");
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmPicode"].Style.BackColor = ColorTranslator.FromHtml("#FFD3B6");
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
            finally
            {
                grdSupplierList.Sort(grdSupplierList.Columns[0], ListSortDirection.Descending);
            }
        }
        public void udfnResetAddRoeIds()
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
        public void udfnrowclear()
        {
            try
            {
                errPurchaseentry.Clear();
                cmbPONo.BackColor = Color.White;
                txtMismatchQty.Text = "";
                txtSourceLocation.Text = "";
                cmbrack.Text = "";
                lblLocationcode.Text = "0";
                txtMrp.Text = "";
                txtDate.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchno.Text = "";
                txtSourceLocation.BackColor = Color.White;
                txtMrp.BackColor = Color.White;
                txtDate.BackColor = Color.White;
                txtMonth.BackColor = Color.White;
                txtYear.BackColor = Color.White;
                txtBatchno.BackColor = Color.White;
                cmbrack.BackColor = Color.White;
                txtMonth.Enabled = true;
                txtDate.Enabled = true;
                txtMonth.Enabled = true;
                txtYear.Enabled = true;
                txtBatchno.Enabled = true;
                txtSourceLocation.Enabled = true;
                txtMrp.Enabled = true;
                cmbrack.Enabled = true;
                cmbrack.DataSource = null;
                txtGRNMrp.Text = "";
                btnConditions.Enabled = true;
                txtMismatchQty.Enabled = false;
                txtMismatchQty.ReadOnly = false;
                pbConditionIDs = "";
                pbCondition = "";
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
                string varDay = "", varMonth = "", varYear = "", varDate = "";
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
                            varExpiryDateAdd = objDS.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();
                        }
                    }
                    else
                    {
                        varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                        varExpiryDateAdd = varDay + "/" + varMonth + "/" + varYear;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 10;
                    objMR_Master.paraDate = varEntryTypeDate;
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
                    if (txtYear.Text.Trim() != "" && txtMonth.Text.Trim() != "")
                    {
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(94);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbRateBefore_Leave(object sender, EventArgs e)
        {
            try
            {
                rbRateBefore.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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
        private void GrdSupplierList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                int varsno = Convert.ToInt16(grdSupplierList.Rows[e.RowIndex].Cells["clmsno"].Value);
                //Auto complete data table to update value
                var varRowsToUpdate = dtPurchaseAutoComplete.AsEnumerable().Where(r => r.Field<int>("SNo") == Convert.ToInt16(varsno));
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmMRP")
                {
                    if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmMRP"].Value) != "")
                    {
                        decimal varMRP = Convert.ToDecimal(grdSupplierList.CurrentRow.Cells["clmMRP"].Value);
                        string mrp = string.Format("{0:0.00}", varMRP);
                        string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                        grdSupplierList.Rows[e.RowIndex].Cells["clmMRP"].Value = mrp;
                        foreach (var row in varRowsToUpdate)
                        { row.SetField("MRP", mrp1); }
                    }
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductMrp")
                {
                    if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmProductMrp"].Value) != "")
                    {
                        decimal varMRP = Convert.ToDecimal(grdSupplierList.CurrentRow.Cells["clmProductMrp"].Value);
                        string mrp = string.Format("{0:0.00}", varMRP);
                        string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                        grdSupplierList.Rows[e.RowIndex].Cells["clmProductMrp"].Value = mrp; 
                    }
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmInvoiceQty")
                {
                    if (Convert.ToString(grdSupplierList.CurrentRow.Cells["clmInvoiceQty"].Value) != "" && Convert.ToString(grdSupplierList.CurrentRow.Cells["clmInvoiceQty"].Value) != "0")
                    {
                        int varDecimal = Convert.ToInt32(grdSupplierList.CurrentRow.Cells["clmUTDecimal"].Value);

                        string Qty = objValidation.udfnDecimal(Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmInvoiceQty"].Value), varDecimal);
                        grdSupplierList.Rows[e.RowIndex].Cells["clmInvoiceQty"].Value = Qty;
                    }
                    else
                    {
                        grdSupplierList.Rows[e.RowIndex].Cells["clmInvoiceQty"].Value = "0";
                    }
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmMismatchQty")
                {
                    if (pbPurchaseno != "0")
                    { 
                        string varPurid = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmPURPRIDDetail"].Value);
                        if (grdPurchaseList.RowCount != 0)
                        {
                            for (int i = 0; i < grdPurchaseList.RowCount; i++)
                            {
                                if (varPurid == Convert.ToString(grdPurchaseList.Rows[i].Cells["clmPURPRID"].Value))
                                {
                                    grdPurchaseList.Rows[i].Cells["clmDiffqty"].Value = grdSupplierList.CurrentCell.Value;
                                }
                            }
                        }
                    }
                }

                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate")
                {
                    int rowIndex = e.RowIndex, columnIndex = e.ColumnIndex, varProid = 0, PR_Shelflife = 0, Date = 0;

                    if (grdSupplierList.Rows.Count > 0)
                    {
                        PR_Shelflife = Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["clmShelflifeenable"].Value);
                    }
                    if (PR_Shelflife == 1)
                    {
                        varTempExpiryDate = Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Value);
                        if (grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Value != null && Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Value) != "0")
                        {
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 8;
                            objMR_Master.paraDate = varTempExpiryDate;
                            DataSet objDSer = new DataSet();
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
                                        if (varTempExpiryDate != "")
                                        {
                                            string varMessage = objdServ.udfnGetMessages(95);
                                            objdServ.CloseConnection();
                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                        }
                                        if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmConditionID"].Value) == "226" && varTempExpiryDate=="")
                                        {
                                            grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmConditionID"].Value) != "226")
                            {
                                MessageBox.Show("Please enter expirydate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                            }
                            else
                            {
                                grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                            }
                        }
                    }
                    foreach (var row in varRowsToUpdate)
                    { row.SetField("ExpiryDate", varTempExpiryDate); }
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductExpiryDate")
                {
                    int rowIndex = e.RowIndex, columnIndex = e.ColumnIndex, PR_Shelflife = 0, Date = 0;

                    if (grdSupplierList.Rows.Count > 0)
                    {
                        PR_Shelflife = Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["clmShelflifeenable"].Value);
                    }
                    if (PR_Shelflife == 1)
                    {
                        varProExpiryDate = Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Value);
                        if (grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Value != null && Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Value) != "0")
                        {
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 8;
                            objMR_Master.paraDate = varProExpiryDate;
                            DataSet objDSer = new DataSet();
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
                                        if (varProExpiryDate != "")
                                        {
                                            string varMessage = objdServ.udfnGetMessages(95);
                                            objdServ.CloseConnection();
                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Style.BackColor = Color.LightPink;
                                        }
                                    }
                                    if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmConditionID"].Value) == "226" && varTempExpiryDate == "")
                                    {
                                        grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Style.BackColor = Color.PaleGreen;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmConditionID"].Value) != "226")
                            {
                                MessageBox.Show("Please enter expirydate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Style.BackColor = Color.LightPink;
                            }
                            else
                            {
                                grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Style.BackColor = Color.PaleGreen;
                            }
                        }
                    }
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmInwardDate")
                {
                    int rowIndex = e.RowIndex, columnIndex = e.ColumnIndex, PR_Shelflife = 0, Date = 0;
                    varInwardDate = Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmInwardDate"].Value);
                    if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmConvertProductFlag"].Value) == "1")
                    {
                        if (grdSupplierList.Rows[rowIndex].Cells["clmInwardDate"].Value != null && Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmInwardDate"].Value) != "0")
                        {
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 8;
                            objMR_Master.paraDate = varInwardDate;
                            DataSet objDSer = new DataSet();
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
                                        string varMessage = objdServ.udfnGetMessages(95);
                                        objdServ.CloseConnection();
                                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        grdSupplierList.Rows[rowIndex].Cells["clmInwardDate"].Style.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter Inward date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdSupplierList.Rows[rowIndex].Cells["clmInwardDate"].Style.BackColor = Color.LightPink;
                        }

                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmPicode")
                    {
                        udfnConvertProductDetails(sender, e);
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
                varExpiryDate = ""; string varProductxpiryDate = ""; string varParaExpiryDate = "";
                varShelflife = 0;
                varErroronGrid = 0;
                int varExpiryDays = 0; int error = 0, rowIndex = value.RowIndex, columnIndex = value.ColumnIndex, varProid = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate")
                {
                    varExpiryDate = Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Value);
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
                    varTempExpiryDate = cellValue.ToString();
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductExpiryDate")
                {
                    varProductxpiryDate = Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Value);
                    string varTempYear = "0";
                    object cellValue = varProductxpiryDate;
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
                    varProExpiryDate = cellValue.ToString();
                }
                int varInvFlag = 0; string varDate = "";
                varProid = Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["clmProid"].Value);
                if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmid"].Value) == "218")
                { varDate = varGRNDate; }
                else if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmid"].Value) == "220")
                { varDate = varDCDate; }
                else { varDate = varVoucherDate; }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate")
                { varParaExpiryDate = varTempExpiryDate; }
                else if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductExpiryDate")
                { varParaExpiryDate = varProExpiryDate; }
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 10;
                objMR_Master.paraDate = varDate;
                objMR_Master.ParaExpiryDate = varParaExpiryDate;
                objMR_Master.paraProductId = varProid;
                objDS = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                //for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                //{
                varShelflife = Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["clmShelflifeenable"].Value);
                pbDateflag = 0; varInvFlag = 0;
                varInvFlag = Convert.ToInt16(grdSupplierList.Rows[rowIndex].Cells["clmInvFlag"].Value);
                if (pbDateflag == 0)
                {
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate")
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
                                                if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                                                {
                                                    varErrorFormat = 5;
                                                    grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                                    string varMessage = objDServ.udfnGetMessages(98);
                                                    objDServ.CloseConnection();
                                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                            //else
                                            //{
                                            //    grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
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
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductExpiryDate")
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
                                                if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Value) == varProExpiryDate)
                                                {
                                                    varErrorFormat = 5;
                                                    grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Style.BackColor = Color.LightPink;
                                                    string varMessage = objDServ.udfnGetMessages(98);
                                                    objDServ.CloseConnection();
                                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
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
                        if (varTempExpiryDate != "" && grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate")
                        {
                            if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                            {
                                varErroronGrid = 1;
                                grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                string varMessage = objDServ.udfnGetMessages(94);
                                objDServ.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        if (varProExpiryDate != "" && grdSupplierList.CurrentCell.OwningColumn.Name == "clmProductExpiryDate")
                        {
                            if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Value) == varProExpiryDate)
                            {
                                varErroronGrid = 1;
                                grdSupplierList.Rows[rowIndex].Cells["clmProductExpiryDate"].Style.BackColor = Color.LightPink;
                                string varMessage = objDServ.udfnGetMessages(94);
                                objDServ.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void GrdSupplierList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (PbSTS == "49" || pbPurchaseno == "0" || varPurEditFlag != 1 || PbApprovalStsid == 70)
                {
                    string varshelflife = "";
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    int varCellprodid = 0;  
                    if (grdSupplierList.Columns[e.ColumnIndex].Name == "clmProductExpiryDate")
                    {
                        int rowIndex = e.RowIndex;
                        int columnIndex = e.ColumnIndex;
                        if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmProductExpiryDate"].Value) != "")
                        {
                            varCellprodid = Convert.ToInt32(grdSupplierList.Rows[e.RowIndex].Cells["clmProid"].Value);
                            if (rowIndex >= 0 && columnIndex >= 0)
                            {
                                string varTempYear = "0", varTempMonth = "0", varTempDay = "0";
                                object cellValue = grdSupplierList.Rows[rowIndex].Cells[columnIndex].Value;
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

                                    MR_Master objMR_Master = new MR_Master();
                                    objMR_Master.ViewType = 5;
                                    objMR_Master.paraDate = varDate;
                                    DataSet objDSer = new DataSet();
                                    SPDataService objdServ = new SPDataService();
                                    objDSer = objdServ.udfnMaster(objMR_Master);
                                    objdServ.CloseConnection();
                                    if (objDSer.Tables[0].Rows.Count > 0)
                                    {
                                        varProExpiryDate = objDSer.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();

                                        cellValue = varProExpiryDate;
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
                                string varEntryTypeDate = "";
                                varProExpiryDate = cellValue.ToString();
                                if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmid"].Value) == "218")
                                { varEntryTypeDate = varGRNDate; }
                                else if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmid"].Value) == "220")
                                { varEntryTypeDate = varDCDate; }
                                else { varEntryTypeDate = varVoucherDate; }
                                if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmConvertProductFlag"].Value) == "1")
                                {
                                    if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmInwardDate"].Value) != "")
                                    { varEntryTypeDate = Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmInwardDate"].Value); }
                                }
                                if (cellValue != null && Convert.ToString(cellValue) != "")
                                {
                                    varshelflife = cellValue.ToString();
                                    if (varshelflife != "" || varshelflife != null)
                                        objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, varEntryTypeDate, varCellprodid, 0, "0", "", "", 0, 0, 0, 0);
                                    objdserv.CloseConnection();
                                    if (objDs != null)
                                    {
                                        if (objDs.Tables[0].Rows.Count != 0)
                                        {
                                            if (objDs.Tables[0].Rows.Count > 0)
                                            {
                                                grdSupplierList.Rows[rowIndex].Cells["clmshelfper"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
                                            }
                                        }
                                        if (objDs.Tables[1].Rows.Count > 0)
                                        {
                                            grdSupplierList.Rows[rowIndex].Cells["clmactuallife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
                                        }

                                        string[] varShelflifevalue = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]).Split(' ');
                                        if (varShelflifevalue[0] != "")
                                        {
                                            if (Convert.ToDecimal(varShelflifevalue[0]) < varShelflifeLevel1)
                                            {
                                                DataGridView dataGridView = grdSupplierList;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                                cell.Style.BackColor = Color.Red;
                                                cell.Style.ForeColor = Color.White;
                                            }
                                            else if (Convert.ToDecimal(varShelflifevalue[0]) < varShelflifeLevel2)
                                            {
                                                DataGridView dataGridView = grdSupplierList;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                                cell.Style.BackColor = Color.Orange;
                                                cell.Style.ForeColor = Color.Black;
                                            }
                                            else
                                            {
                                                DataGridView dataGridView = grdSupplierList;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                                cell.Style.BackColor = Color.White;
                                                cell.Style.ForeColor = Color.Black;
                                            }
                                        }
                                    }
                                }
                            }
                            grdSupplierList.Rows[e.RowIndex].Cells["clmProductExpiryDate"].Value = varProExpiryDate;
                            udfnGridaddvalue(sender, e);
                        }
                        else
                        {
                            grdSupplierList.Rows[rowIndex].Cells["clmactuallife"].Value = "";
                            DataGridView dataGridView = grdSupplierList;
                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.White;
                            cell.Style.ForeColor = Color.Black;
                        }
                    }
                    if (grdSupplierList.Columns[e.ColumnIndex].Name == "clmexpirydate")
                    {
                        int rowIndex = e.RowIndex;
                        int columnIndex = e.ColumnIndex;
                        if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmexpirydate"].Value) != "")
                        {
                            varCellprodid = Convert.ToInt32(grdSupplierList.Rows[e.RowIndex].Cells["clmProid"].Value);
                            if (rowIndex >= 0 && columnIndex >= 0)
                            {
                                string varTempYear = "0", varTempMonth = "0", varTempDay = "0";
                                object cellValue = grdSupplierList.Rows[rowIndex].Cells[columnIndex].Value;
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
                                    MR_Master objMR_Master = new MR_Master();
                                    objMR_Master.ViewType = 5;
                                    objMR_Master.paraDate = varDate;
                                    DataSet objDSer = new DataSet();
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
                                string varEntryTypeDate = "";
                                varTempExpiryDate = cellValue.ToString();
                                if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmid"].Value) == "218")
                                { varEntryTypeDate = varGRNDate; }
                                else if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmid"].Value) == "220")
                                { varEntryTypeDate = varDCDate; }
                                else { varEntryTypeDate = varVoucherDate; }
                                if (cellValue != null && Convert.ToString(cellValue) != "")
                                {
                                    varshelflife = cellValue.ToString();
                                    if (varshelflife != "" || varshelflife != null)
                                        objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, varEntryTypeDate, varCellprodid, 0, "0", "", "", 0, 0, 0, 0);
                                    objdserv.CloseConnection();
                                }
                            }
                            grdSupplierList.Rows[e.RowIndex].Cells["clmexpirydate"].Value = varTempExpiryDate;
                            udfnGridaddvalue(sender, e);
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

        private void GrdSupplierList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdSupplierList.IsCurrentCellDirty)
                {
                    grdSupplierList.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
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
                btnAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnViewDataView_Click(object sender, EventArgs e)
        {
            try
            {
                varEntryTypeRefresh = 1;
                CmbType_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { varEntryTypeRefresh = 0; }
        }

        private void BtnViewDataView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnViewDataView.BackColor = Color.LemonChiffon;
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
                if (varPaymentStatus == 65)
                { udfnAfterPaymentSave(); }
                else
                { udfnSave(sender, e); }
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
        public void udfnLoadingGrandTotCalculation()
        {
            try
            {
                decimal varGrandTot = 0, varloadcharge = 0, varUnloadcharge = 0, varCouriercharge = 0, varOtherexpense = 0, varDiscountper = 0, varDiscountamt = 0, varTcsamt = 0, varDamagecost = 0,
                                    varOtherdiscount = 0, varLoadinggrn = 0, varFrightgrn = 0, varSubtotal = 0, varGstamt = 0,
                                    varRoundoff = 0, varTotal = 0, varAdditionalValue = 0, varDiscountValue = 0;
                if (lblTotal.Text != "")
                { varGrandTot = Convert.ToDecimal(lblTotal.Text.Trim()); }
                //if (txtLoadingchargeGrn.Text != "")
                //{ varLoadinggrn = Convert.ToDecimal(txtLoadingchargeGrn.Text); }
                //if (txtFrightGrn.Text != "")
                //{ varFrightgrn = Convert.ToDecimal(txtFrightGrn.Text); }
                if (txtLoadingCharge.Text != "")
                { varloadcharge = Convert.ToDecimal(txtLoadingCharge.Text); }
                if (txtUnLoadingCharge.Text != "")
                { varUnloadcharge = Convert.ToDecimal(txtUnLoadingCharge.Text); }
                if (txtCouriercharge.Text != "")
                { varCouriercharge = Convert.ToDecimal(txtCouriercharge.Text); }
                if (txtotherexpense.Text != "")
                { varOtherexpense = Convert.ToDecimal(txtotherexpense.Text); }
                if (Txtdiscount.Text != "")
                { varDiscountper = Convert.ToDecimal(Txtdiscount.Text); }
                if (txtDiscountamt.Text != "")
                { varDiscountamt = Convert.ToDecimal(txtDiscountamt.Text); }
                if (txtTcsamt.Text != "")
                { varTcsamt = Convert.ToDecimal(txtTcsamt.Text); }
                if (txtDamagecost.Text != "")
                { varDamagecost = Convert.ToDecimal(txtDamagecost.Text); }
                if (txtOtherdiscount.Text != "")
                { varOtherdiscount = Convert.ToDecimal(txtOtherdiscount.Text); }
                if (lblSubtotal.Text != "")
                { varSubtotal = Convert.ToDecimal(lblSubtotal.Text); }
                if (lblGstamt.Text != "")
                { varGstamt = Convert.ToDecimal(lblGstamt.Text); }
                if (lblRoundoff.Text != "")
                { varRoundoff = Convert.ToDecimal(lblRoundoff.Text); }
                if (lblTotal.Text != "")
                { varTotal = Convert.ToDecimal(lblTotal.Text); }
                varAdditionalValue = varloadcharge + varUnloadcharge + varCouriercharge + varOtherexpense + varTcsamt;
                varDiscountValue = varDiscountamt + varOtherdiscount + varDamagecost;
                varGrandTot = varTotal + varAdditionalValue - varDiscountValue;
                lblAdditionalValue.Text = varAdditionalValue.ToString("#,##0.00");
                lblDiscount.Text = varDiscountValue.ToString("#,##0.00");

                lblGrandTotal.Text = Math.Round(varGrandTot).ToString("#,##0.00");
                lblRoundoff.Text = Convert.ToString(Convert.ToDecimal(lblGrandTotal.Text) - (varTotal + varAdditionalValue - varDiscountValue));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAfterPaymentSave()
        {
            try
            {
                string varResult = "";
                SPDataService objspdservice = new SPDataService();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 8;
                objTRN_PurchaseEntry.paraPurchaseId = Convert.ToInt32(pbPurchaseno);
                objTRN_PurchaseEntry.paraINVDate = dpInvoiceDate.Text;
                objTRN_PurchaseEntry.paraINVNo = txtInvoiceNo.Text;
                objTRN_PurchaseEntry.ParaInvAmt = Convert.ToDecimal(txtInvoiceamt.Text.Trim());
                varResult = objspdservice.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varCloseflag = 1;
                    udfnclose();
                }
                else if (varResult.Split('~')[0] == "4")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                grdSupplierList.ClearSelection();
                grdPurchaseList.ClearSelection();
                udfntooltiphide(); udfnrowclear();
                txtProductName.Text = "";
                lblProductcode.Text = "0";
                txtProductName.BackColor = Color.White;
                bool varErrorFlag = false; varCount2 = 0; varTabFlag = 0; InvoiceAmountErr = 0;
                string varGrandtotal = "";
                int varTotalIssue = 0;
                if (grdSupplierList.RowCount > 0)
                {
                    udfnEntryTypeErr();
                    if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                    {
                        errPurchaseentry.SetError(cmbConcern, "Please select company");
                        cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpconcern.ShowAlways = true;
                        tpconcern.Show("Please select company", cmbConcern, 5000);
                        varErrorFlag = true;
                    }
                    if (txtSupplier.Text == "")
                    {
                        errPurchaseentry.SetError(txtSupplier, "Please enter supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                        varErrorFlag = true;
                    }
                    if (txtPENO.Text == "")
                    {
                        varErrorFlag = true;
                    }
                    if (Convert.ToInt32(cmbEntryType.SelectedValue) == -1 || Convert.ToString(cmbEntryType.SelectedValue) == "")
                    {
                        errPurchaseentry.SetError(cmbEntryType, "Please select entry type");
                        cmbEntryType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpEntryType.ShowAlways = true;
                        tpEntryType.Show("Please select entry type", cmbEntryType, 5000);
                        varErrorFlag = true;
                    }
                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == -1 || Convert.ToString(cmbTransactionType.SelectedValue) == "")
                    {
                        errPurchaseentry.SetError(cmbTransactionType, "Please select transaction type");
                        cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        varErrorFlag = true;
                    }
                    if (txtInvoiceNo.Text == "")
                    {
                        errPurchaseentry.SetError(txtInvoiceNo, "Please enter invoice No.");
                        txtInvoiceNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpInvNo.ShowAlways = true;
                        tpInvNo.Show("Please enter invoice No.", txtInvoiceNo, 5000);
                        varErrorFlag = true;
                    }
                    if (Convert.ToString(txtInvoiceamt.Text) == "")
                    {
                        errPurchaseentry.SetError(txtInvoiceamt, "Please enter invoice amount");
                        txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpinvamt.ShowAlways = true;
                        tpinvamt.Show("Please enter invoice amount", txtInvoiceamt, 5000);
                        varErrorFlag = true;
                    }
                    int varVerifiedErr = 0;
                    if (chkCompleted.Checked == true && (pbVerifiedBy1 == 0 || PbVerified1 == 0) && (Convert.ToString(cmbEntryType.SelectedValue) == "55" || Convert.ToString(cmbEntryType.SelectedValue) == "56"))
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(119);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrorFlag = true;
                        varVerifiedErr = 1;
                        BtnVerified_Click(sender, e); 
                    }
                    if (varVerifiedErr == 0)
                    {
                        if (chkCompleted.Checked == true && (Convert.ToDouble(txtInvoiceamt.Text)) >= varDVA && (Convert.ToString(cmbEntryType.SelectedValue) == "55" || Convert.ToString(cmbEntryType.SelectedValue) == "56"))
                        {
                            if (pbVerifiedBy1 == 0 || pbVerifiedBy1 == -1 || pbVerifiedBy2 == 0 || pbVerifiedBy2 == -1)
                            {
                                SPDataService objDServ1 = new SPDataService();
                                string varMessage = objDServ1.udfnGetMessages(120);
                                objDServ1.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varErrorFlag = true;
                            }
                        }
                    }
                    if (varBlockedSupplier == "98")
                    {
                        txtSupplier.BackColor = Color.LightPink;
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(134);
                        objDServ.CloseConnection();
                        DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            varErrorFlag = true;
                        }
                    } 
                    if (varErrorFlag == false && varerrFlag == 0)
                    {
                        string result = "", varorginator = "Purchase entry save"; int varSaveFlag = 1;
                        SPDataService objspdservice = new SPDataService();
                        DataTable objPurchaseentry = new DataTable();
                        DataTable objPurchaseentryDetails = new DataTable();
                        DataTable objPurchaseProdValidation = new DataTable();
                        (objPurchaseentry, objPurchaseProdValidation) = udfnobjPurchaseprod();  
                        if (varPrCountFlag == 1)
                        {
                            int varmsgId = 0;
                            if (Convert.ToInt16(cmbEntryType.SelectedValue) == 54) //grn
                            { varmsgId = 129; }
                            if (Convert.ToInt16(cmbEntryType.SelectedValue) == 57) //DC
                            { varmsgId = 130; }
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(varmsgId);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (varPrCountFlag == 0)
                        {
                            if (shelfLifeError != 0)
                            {
                                string varShelflifeMessage = "", varShelflifeLevel = "";
                                varShelflifeLevel = Convert.ToString(varShelflifeLevel2) + '%';
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
                            if(shelfLifeError==0)
                            { 
                                DataSet Result = new DataSet();
                                TRN_Validate_Products_By_Condition objTRN_Validate_Products_By_Condition = new TRN_Validate_Products_By_Condition();
                                objTRN_Validate_Products_By_Condition.ProductList = objPurchaseProdValidation;
                                objTRN_Validate_Products_By_Condition.ParaEntryDate = Convert.ToString(dpVoucherDate.Text);
                                Result = objspdservice.udfnValidateProductsByCondition(objTRN_Validate_Products_By_Condition);
                                if (Result.Tables[0].Rows.Count != 0)
                                {
                                    varTotalIssue = Convert.ToInt32(Result.Tables[0].Rows[0]["Total_Issues"]);
                                    if (varTotalIssue != 0)
                                    {

                                        for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                                        {
                                            var gridRow = grdSupplierList.Rows[i];
                                            var varIssuerow = Result.Tables[0].Rows[i];
                                            if (Convert.ToString(gridRow.Cells["clmsno"].Value) == Convert.ToString(varIssuerow["GRNPR_SNO"]))
                                            {
                                                if (Convert.ToInt32(varIssuerow["Expiry_Date_Issue"]) != 0 || Convert.ToInt32(varIssuerow["Pro_Expiry_Date_Issue"]) != 0)
                                                {
                                                    gridRow.Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                                    gridRow.Cells["clmProductExpiryDate"].Style.BackColor = Color.LightPink;
                                                }
                                                else
                                                {
                                                    gridRow.Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                                    gridRow.Cells["clmProductExpiryDate"].Style.BackColor = Color.PaleGreen;    
                                                }
                                                if (Convert.ToInt32(varIssuerow["MRP_Valid_Issue"]) != 0 || Convert.ToInt32(varIssuerow["Pro_MRP_Valid_Issue"]) != 0)
                                                {
                                                    gridRow.Cells["clmMRP"].Style.BackColor = Color.LightPink;
                                                    gridRow.Cells["clmProductMrp"].Style.BackColor = Color.LightPink;
                                                }
                                                else
                                                {
                                                    gridRow.Cells["clmMRP"].Style.BackColor = Color.PaleGreen;
                                                    gridRow.Cells["clmProductMrp"].Style.BackColor = Color.PaleGreen;
                                                }
                                                if (Convert.ToInt32(varIssuerow["Pro_BatchNo_Issue"]) != 0 || Convert.ToInt32(varIssuerow["Invoice_BatchNo_Issue"]) != 0)
                                                {
                                                    gridRow.Cells["clmBatchno"].Style.BackColor = Color.LightPink;
                                                    gridRow.Cells["clmProductBatchNo"].Style.BackColor = Color.LightPink;
                                                }
                                                else
                                                {
                                                    gridRow.Cells["clmBatchno"].Style.BackColor = Color.PaleGreen;
                                                    gridRow.Cells["clmProductBatchNo"].Style.BackColor = Color.PaleGreen;
                                                }
                                                if (Convert.ToInt32(varIssuerow["Location_Issue"]) != 0)
                                                {
                                                    gridRow.Cells["clmLocation"].Style.BackColor = Color.LightPink;
                                                }
                                                else
                                                {
                                                    gridRow.Cells["clmLocation"].Style.BackColor = Color.PaleGreen;
                                                }
                                                if (Convert.ToInt32(varIssuerow["Rack_Issue"]) != 0)
                                                {
                                                    gridRow.Cells["clmrack"].Style.BackColor = Color.LightPink;
                                                }
                                                else
                                                {
                                                    gridRow.Cells["clmrack"].Style.BackColor = Color.PaleGreen;
                                                }
                                            }
                                        }
                                    }
                                }
                            } 
                            varGrandtotal = lblGrandTotal.Text;
                            if (lblTotal.Text == "")
                            {
                                varGrandtotal = "0";
                            }
                            if (shelfLifeError == 0 && chkCompleted.Checked == true && varTotalIssue == 0)
                            {
                                if (((Convert.ToDecimal(txtInvoiceamt.Text)) != (Convert.ToDecimal(varGrandtotal))) && Convert.ToDecimal(varGrandtotal) != 0)
                                { 
                                    SPDataService objDServe1 = new SPDataService();
                                    string varMessage = objDServe1.udfnGetMessages(115);
                                    objDServe1.CloseConnection();
                                    DialogResult dialogResult1 = MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        if (pbPurchaseno != "0" && varTotalIssue==0)
                        { 
                            if (grdSupplierList.Rows.Count == grdPurchaseList.Rows.Count)
                            {
                                objPurchaseentryDetails = udfnobjPurchaseprodDetails();
                                if (varcount1 != 0)
                                {
                                    tbDetails.SelectedIndex = 1;
                                }
                            }
                            if (grdSupplierList.Rows.Count == grdPurchaseList.Rows.Count)
                            {
                                if (varcount == 0 && Convert.ToInt32(VarGridError) == 0 && shelfLifeError == 0 && varQuantityErr == 0 && varDiscountErr == 0 && InvoiceAmountErr == 0 && varPrCountFlag == 0)
                                {
                                    flagSave = 0;
                                }
                                else
                                {
                                    flagSave = 1;
                                }
                            }
                            else
                            {
                                if (varCount2 == 0)
                                {
                                    flagSave = 0; varTabFlag = 1;
                                    decimal varFreeQty = 0, varPOqty = 0, varCosting = 0, varDiscountValue = 0, varInvQty = 0, varRecQty = 0;
                                    if (varcount == 0 && shelfLifeError == 0 && InvoiceAmountErr == 0 && varPrCountFlag == 0)
                                    { flagSave = 0; }
                                    else { flagSave = 1; }
                                    for (int i = 0; i < grdPurchaseList.Rows.Count; i++)
                                    {
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmFreeqty"].Value) != "" && Convert.ToString(grdPurchaseList.Rows[i].Cells["clmFreeqty"].Value) != "0")
                                        {
                                            varFreeQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmFreeqty"].Value);
                                        }
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmPOqty"].Value) != "" && Convert.ToString(grdPurchaseList.Rows[i].Cells["clmPOqty"].Value) != "0")
                                        {
                                            varPOqty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmPOqty"].Value);
                                        }
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value) != "")
                                        {
                                            varInvQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value);
                                        }
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmRecqty"].Value) != "")
                                        {
                                            varRecQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmRecqty"].Value);
                                        }
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmCosting"].Value) != "")
                                        {
                                            varCosting = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCosting"].Value);
                                        }
                                        if (rbDiscountAfter.Checked == true)
                                        {
                                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmDiscountValue"].Value) != "")
                                            {
                                                varDiscountValue = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscountValue"].Value);
                                            }
                                        }
                                        decimal varSGSTPer = 0, varCGSTPer = 0, varIGSTPer = 0, varSGSTAmt = 0, varCGSTAmt = 0, varIGSTAmt = 0;
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmSGST"].Value) != "" && Convert.ToString(grdPurchaseList.Rows[i].Cells["clmSGST"].Value) != "0")
                                        {
                                            varSGSTPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGST"].Value);
                                        }
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmCGST"].Value) != "" && Convert.ToString(grdPurchaseList.Rows[i].Cells["clmCGST"].Value) != "0")
                                        {
                                            varCGSTPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGST"].Value);
                                        }
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmIGST"].Value) != "" && Convert.ToString(grdPurchaseList.Rows[i].Cells["clmIGST"].Value) != "0")
                                        {
                                            varIGSTPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGST"].Value);
                                        }
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmSGSTamt"].Value) != "" && Convert.ToString(grdPurchaseList.Rows[i].Cells["clmSGSTamt"].Value) != "0")
                                        {
                                            varSGSTAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGSTamt"].Value);
                                        }
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmCGSTamt"].Value) != "" && Convert.ToString(grdPurchaseList.Rows[i].Cells["clmCGSTamt"].Value) != "0")
                                        {
                                            varCGSTAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGSTamt"].Value);
                                        }
                                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmIGSTamt"].Value) != "" && Convert.ToString(grdPurchaseList.Rows[i].Cells["clmIGSTamt"].Value) != "0")
                                        {
                                            varIGSTAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGSTamt"].Value);
                                        }
                                        if (varcount == 0)
                                        {
                                            if (objPurchaseentryDetails.Rows.Count==0)
                                            {
                                                objPurchaseentryDetails.TableName = "TRN_Purchase_Products_Details";
                                                objPurchaseentryDetails.Columns.Add("PURPR_PURID", typeof(int));
                                                objPurchaseentryDetails.Columns.Add("PURPR_PRID", typeof(int));
                                                objPurchaseentryDetails.Columns.Add("PURPR_HSNID", typeof(int));
                                                objPurchaseentryDetails.Columns.Add("PURPR_PurchaseRate", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_POQty", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_InvoiceQty", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_ReceivedQty", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_DiffQty", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_FreeQty", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_DiscPer", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_DiscAmnt", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_TaxableValue", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_GSTPer", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_GSTAmnt", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_NettAmnt", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_Error", typeof(int));
                                                objPurchaseentryDetails.Columns.Add("PURPRID", typeof(int));
                                                objPurchaseentryDetails.Columns.Add("ID", typeof(int));
                                                objPurchaseentryDetails.Columns.Add("PURPR_Costing", typeof(decimal));
                                                objPurchaseentryDetails.Columns.Add("PURPR_DiscountValue", typeof(decimal));
                                                objPurchaseentryDetails.Columns.Add("PURPR_CGSTPer", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_SGSTPer", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_CGSTAmnt", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_SGSTAmnt", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_ISGSTPer", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_IGSTAmnt", typeof(float));
                                                objPurchaseentryDetails.Columns.Add("PURPR_ConvertedProductID", typeof(int));
                                                objPurchaseentryDetails.Columns.Add("PURPR_GRNProType", typeof(int));
                                                objPurchaseentryDetails.Columns.Add("PURPR_ConvertProduct", typeof(int));
                                            }
                                            objPurchaseentryDetails.Rows.Add(pbPurchaseno, Convert.ToInt32(grdPurchaseList.Rows[i].Cells["proid"].Value),
                                            Convert.ToInt32(grdPurchaseList.Rows[i].Cells["hsnid"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value),
                                            Convert.ToDecimal(varPOqty), varInvQty, varRecQty, Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiffqty"].Value),
                                            varFreeQty, Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscPer"].Value),
                                            Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmTax"].Value),
                                            Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["GstValue"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmGstamt"].Value),
                                            Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmnetamt"].Value), 0, Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmPURPRID"].Value),
                                            Convert.ToInt32(grdPurchaseList.Rows[i].Cells["poid"].Value), Convert.ToDecimal(varCosting), varDiscountValue, Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGST"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGST"].Value),
                                            Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGSTamt"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGSTamt"].Value),
                                            Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGST"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGSTamt"].Value), 0, 0, 0);
                                        }
                                    }
                                }
                                else
                                {
                                    flagSave = 1; varTabFlag = 0;
                                }
                            } 
                        }
                        else
                        {
                            if (varcount == 0 && shelfLifeError == 0 && InvoiceAmountErr == 0 && varPrCountFlag == 0 && VarGridError == "0" && varTotalIssue==0)
                            { flagSave = 0; }
                            else { flagSave = 1; }
                        }

                        if (flagSave == 0)
                        {
                            string result2 = ""; int varViewType = 0;
                            if (pbPurchaseno != "0")
                            { varViewType = 1; }
                            if (varPaymentStatus == 65)
                            { varViewType = 8; }
                            TRN_PurchaseEntry objTRN_PurchaseEntry1 = new TRN_PurchaseEntry();  
                            varUserID = Convert.ToString(MainForm.pbUserID); 
                            Label l;
                            int passkeyflag = 0;
                        l: if (chkCompleted.Checked == true)
                            {
                                MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                                MainForm.objPUR_GRNApprovalVerify.varTrnType = 3;
                                MainForm.objPUR_GRNApprovalVerify.ShowDialog();
                                varUserID = MainForm.objPUR_GRNApprovalVerify.varUserId;
                                passkeyflag = MainForm.objPUR_GRNApprovalVerify.flag;
                            }
                            else
                            {
                                passkeyflag = 1;
                            }
                            if (passkeyflag == 1)
                            {
                                int varBrokerid = 0;
                                decimal loadcharge = 0, unloadcharge = 0, couriercharge = 0, otherexpense = 0, discountper = 0, discountamt = 0, tcsamt = 0, damagecost = 0,
                               otherdiscount = 0, loadinggrn = 0, frightgrn = 0, subtotal = 0, gstamt = 0, roundoff = 0, grandtotal = 0, total = 0, varGRNFrightCharges = 0; decimal varGRNUnloadingCharges = 0;
                                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                                objTRN_PurchaseEntry.ViewType = varViewType;
                                objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                                objTRN_PurchaseEntry.paraPurchaseId = Convert.ToInt32(pbPurchaseno);
                                objTRN_PurchaseEntry.paraPurchaseDate = dpVoucherDate.Text;
                                objTRN_PurchaseEntry.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                                objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(lblschedule.Text);
                                objTRN_PurchaseEntry.paraEntryType = Convert.ToInt32(cmbEntryType.SelectedValue);
                                objTRN_PurchaseEntry.paraINVDate = dpInvoiceDate.Text;
                                objTRN_PurchaseEntry.paraINVNo = txtInvoiceNo.Text;
                                objTRN_PurchaseEntry.paraRefreshFlag = pbRefreshFlag;
                                objTRN_PurchaseEntry.ParaInvAmt = Convert.ToDecimal(txtInvoiceamt.Text.Trim());
                                objTRN_PurchaseEntry.paraTransactionType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                                if (lblBrokerId.Text != "") { varBrokerid = Convert.ToInt32(lblBrokerId.Text); }
                                objTRN_PurchaseEntry.paraBrokerID = varBrokerid;
                                objTRN_PurchaseEntry.paraGSTIN = txtGstin.Text;
                                objTRN_PurchaseEntry.paraSaveFlag = varSaveFlag;
                                if (chkInvoice.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraEinvoice = "1";
                                }
                                else
                                {
                                    objTRN_PurchaseEntry.paraEinvoice = "0";
                                }
                                objTRN_PurchaseEntry.paraUserID = Convert.ToInt32(varUserID);
                                objTRN_PurchaseEntry.paraRemarks = txtRemarks.Text.Trim();
                                objTRN_PurchaseEntry.ParaPurchase_Products = objPurchaseentry;

                                if (chkCompleted.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraStatus = 50;
                                    if (cmbEntryType.SelectedValue.ToString() == "54")
                                    { // GRN  
                                        objTRN_PurchaseEntry.paraOriginator = "Purchase entry against GRN Complete";
                                    }
                                    if (cmbEntryType.SelectedValue.ToString() == "55") // PO
                                    {
                                        objTRN_PurchaseEntry.paraOriginator = "Purchase entry against PO Complete";
                                    }
                                    if (cmbEntryType.SelectedValue.ToString() == "56") // Direct
                                    {
                                        objTRN_PurchaseEntry.paraOriginator = "Purchase entry against Direct Complete";
                                    }
                                    if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                                    {
                                        objTRN_PurchaseEntry.paraOriginator = "Purchase entry against DC Complete";
                                    }
                                }
                                else
                                {
                                    objTRN_PurchaseEntry.paraStatus = 49;
                                    if (cmbEntryType.SelectedValue.ToString() == "54")
                                    { // GRN  
                                        objTRN_PurchaseEntry.paraOriginator = "Purchase entry against GRN draft";
                                    }
                                    if (cmbEntryType.SelectedValue.ToString() == "55") // PO
                                    {
                                        objTRN_PurchaseEntry.paraOriginator = "Purchase entry against PO draft";
                                    }
                                    if (cmbEntryType.SelectedValue.ToString() == "56") // Direct
                                    {
                                        objTRN_PurchaseEntry.paraOriginator = "Purchase entry against Direct draft";
                                    }
                                    if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                                    {
                                        objTRN_PurchaseEntry.paraOriginator = "Purchase entry against DC draft";
                                    }
                                }
                                if (rbPurchaseCash.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraPurchaseType = 1;
                                }
                                if (rbPurchaseCredit.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraPurchaseType = 2;
                                }
                                if (rbPaymentCash.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraPaymentType = 1;
                                }
                                if (rbPaymentCheque.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraPaymentType = 2;
                                }
                                if (rbRateBefore.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraRateCalculation = 1;
                                }
                                if (rbAfterBefore.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraRateCalculation = 2;
                                }
                                if (rbDiscountBefore.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraDiscCalculation = 1;
                                }
                                if (rbDiscountAfter.Checked == true)
                                {
                                    objTRN_PurchaseEntry.paraDiscCalculation = 2;
                                }
                                if (txtUnLoadingchargeGrn.Text.Trim() != "")
                                {
                                    loadinggrn = Convert.ToDecimal(txtUnLoadingchargeGrn.Text.Trim());
                                }
                                if (txtFrightGrn.Text.Trim() != "")
                                {
                                    frightgrn = Convert.ToDecimal(txtFrightGrn.Text.Trim());
                                }
                                if (txtLoadingCharge.Text.Trim() != "")
                                {
                                    loadcharge = Convert.ToDecimal(txtLoadingCharge.Text.Trim());
                                }
                                if (txtUnLoadingCharge.Text.Trim() != "")
                                {
                                    unloadcharge = Convert.ToDecimal(txtUnLoadingCharge.Text.Trim());
                                }
                                if (txtCouriercharge.Text.Trim() != "")
                                {
                                    couriercharge = Convert.ToDecimal(txtCouriercharge.Text.Trim());
                                }
                                if (txtotherexpense.Text.Trim() != "")
                                {
                                    otherexpense = Convert.ToDecimal(txtotherexpense.Text.Trim());
                                }
                                if (Txtdiscount.Text.Trim() != "")
                                {
                                    discountper = Convert.ToDecimal(Txtdiscount.Text.Trim());
                                }
                                if (txtDiscountamt.Text.Trim() != "")
                                {
                                    discountamt = Convert.ToDecimal(txtDiscountamt.Text.Trim());
                                }
                                if (txtTcsamt.Text.Trim() != "")
                                {
                                    tcsamt = Convert.ToDecimal(txtTcsamt.Text.Trim());
                                }
                                if (txtDamagecost.Text.Trim() != "")
                                {
                                    damagecost = Convert.ToDecimal(txtDamagecost.Text.Trim());
                                }
                                if (txtOtherdiscount.Text.Trim() != "")
                                {
                                    otherdiscount = Convert.ToDecimal(txtOtherdiscount.Text.Trim());
                                }
                                if (lblSubtotal.Text.Trim() != "")
                                {
                                    subtotal = Convert.ToDecimal(lblSubtotal.Text.Trim());
                                }
                                if (lblGstamt.Text.Trim() != "")
                                {
                                    gstamt = Convert.ToDecimal(lblGstamt.Text.Trim());
                                }
                                if (lblRoundoff.Text.Trim() != "")
                                {
                                    roundoff = Convert.ToDecimal(lblRoundoff.Text.Trim());
                                }
                                if (lblTotal.Text.Trim() != "")
                                {
                                    total = Convert.ToDecimal(lblTotal.Text.Trim());
                                }
                                if (lblGrandTotal.Text.Trim() != "")
                                {
                                    grandtotal = Convert.ToDecimal(lblGrandTotal.Text.Trim());
                                }
                                if (txtUnLoadingchargeGrn.Text.Trim() != "")
                                {
                                    varGRNUnloadingCharges = Convert.ToDecimal(txtUnLoadingchargeGrn.Text);
                                }
                                if (txtFrightGrn.Text.Trim() != "")
                                {
                                    varGRNFrightCharges = Convert.ToDecimal(txtFrightGrn.Text);
                                }
                                objTRN_PurchaseEntry.paraLoadingCharges = loadcharge;
                                objTRN_PurchaseEntry.paraUnloadingCharges = unloadcharge;
                                objTRN_PurchaseEntry.paraCourierCharges = couriercharge;
                                objTRN_PurchaseEntry.paraOtherExpenses = otherexpense;
                                objTRN_PurchaseEntry.paraDiscAmnt = discountamt;
                                objTRN_PurchaseEntry.paraDiscPer = discountper;
                                objTRN_PurchaseEntry.paraTcsAmnt = tcsamt;
                                objTRN_PurchaseEntry.paraDamageCost = damagecost;
                                objTRN_PurchaseEntry.paraOtherDisc = otherdiscount;
                                objTRN_PurchaseEntry.paraLoadingChargesGRN = loadinggrn;
                                objTRN_PurchaseEntry.paraFrightGRN = frightgrn;
                                objTRN_PurchaseEntry.paraSubTotal = subtotal;
                                objTRN_PurchaseEntry.paraGSTAmnt = gstamt;
                                objTRN_PurchaseEntry.paraRoundOff = roundoff;
                                objTRN_PurchaseEntry.paraGRNFrightCharges = varGRNFrightCharges;
                                objTRN_PurchaseEntry.paraGRNUnloadingCharge = varGRNUnloadingCharges;
                                objTRN_PurchaseEntry.paraGrandTotal = grandtotal;
                                objTRN_PurchaseEntry.paraTotal = total;
                                objTRN_PurchaseEntry.ParaEditFlag = 1;
                                objTRN_PurchaseEntry.ParaPurchaseDC = PurchaseDcIds;
                                objTRN_PurchaseEntry.paraSupplierType = varSupplierType;
                                objTRN_PurchaseEntry.paraTinFlag = varTinFlag;
                                objTRN_PurchaseEntry.paraGRNID = Convert.ToInt32(pbGRNNo);
                                objTRN_PurchaseEntry.paraPOID = Convert.ToString(pbPONO);
                                objTRN_PurchaseEntry.paraUserID = Convert.ToInt32(varUserID);
                                objTRN_PurchaseEntry.paraCompletedBy = Convert.ToInt32(varUserID);
                                objTRN_PurchaseEntry.ParaVerifyBy = pbVerifiedBy1;
                                objTRN_PurchaseEntry.ParaVerifyDate = pbVerifiedOn1;
                                objTRN_PurchaseEntry.paraVerifiedTime = pbVerifiedTime1;
                                objTRN_PurchaseEntry.paraVerifiedFormat = pbVerifiedFormat1;
                                objTRN_PurchaseEntry.ParaVerifyBy2 = pbVerifiedBy2;
                                objTRN_PurchaseEntry.ParaVerifyDate2 = pbVerifiedOn2;
                                objTRN_PurchaseEntry.paraVerifiedTime2 = pbVerifiedTime2;
                                objTRN_PurchaseEntry.paraVerifiedFormat2 = pbVerifiedFormat2;
                                if (pbPurchaseno != "0")
                                {
                                    objTRN_PurchaseEntry.Purchase_Products_Details = objPurchaseentryDetails;
                                }
                                result = objspdservice.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                                objspdservice.CloseConnection();
                                string[] varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    chkCompleted.Enabled = true;
                                    varModifiedFlag = 0;
                                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.ActiveControl = txtSupplier;
                                    MainForm.objCP_PurchaseList.udfnListLoad();

                                    if (grdReurnDC.Visible == true)
                                    {
                                        grdReurnDC.Columns["clmRemoveDC"].Visible = false;
                                    }
                                    if (grdPODetails.Visible == true)
                                    {
                                        grdPODetails.Columns["clmRemovePO"].Visible = false;
                                    }
                                    if (btnSave.Text == "Save as Draft" && varEditFlag == 0 && varConvertFlag == 0)
                                    {
                                        pbPurchaseno = varvalue[2];
                                        grdSupplierList.Rows.Clear();
                                        grdPODetails.Rows.Clear();
                                        grdReurnDC.Rows.Clear();
                                        udfnEditLoad();
                                        udfndisablevalue();
                                        udfnPurchaseEntryTabLoad(); //tab2 load
                                        tbDetails.SelectedIndex = 1;
                                        if (varTabFlag == 1)
                                        {
                                            tbDetails.SelectedIndex = 1;
                                        }
                                        else
                                        { varCloseflag = 1; }
                                    }
                                    else if (btnSave.Text == "Save as Draft" && varEditFlag == 1 && varConvertFlag == 0)
                                    {
                                        grdSupplierList.Rows.Clear();
                                        grdPODetails.Rows.Clear();
                                        grdReurnDC.Rows.Clear();
                                        udfnEditLoad();
                                        udfnPurchaseEntryTabLoad(); //tab2 load
                                        if (varTabFlag == 1)
                                        {
                                            tbDetails.SelectedIndex = 1;
                                        }

                                    }
                                    else if (varConvertFlag == 1)
                                    {
                                        if (Convert.ToInt16(grdSupplierList.RowCount) == Convert.ToInt16(grdPurchaseList.RowCount))
                                        {
                                            varCloseflag = 1;
                                            udfnclose();
                                        }
                                        else
                                        {
                                            udfnEditLoad();
                                            tbDetails.SelectedIndex = 1;
                                        }
                                    }
                                    else
                                    {
                                        varCloseflag = 1;
                                        udfnclose();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    if (varvalue[0] == "5")
                                    {
                                        goto l;
                                    }
                                }
                            } 
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
                if (varQuantityErr != 0)
                {
                    //Against dc receivedquantity+freeqty+diffqty and inward quantity not equal
                    SPDataService objDServ = new SPDataService();
                    //string varMessage = objDServ.udfnGetMessages(112);
                    string varMessage = objDServ.udfnGetMessages(113);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (varDiscountErr != 0)
                {
                    //Against dc receivedquantity+freeqty+diffqty and inward quantity not equal
                    SPDataService objDServ = new SPDataService();
                    //string varMessage = objDServ.udfnGetMessages(112);
                    string varMessage = objDServ.udfnGetMessages(114);
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
        public void udfnPurchaseEntryTabLoad()
        {
            try
            {
                if (pbPurchaseno != "0")
                {
                    if (PbSTS != "50")
                    {
                        tbDetails.TabPages[0].Enabled = true; // First tab 
                        tbDetails.TabPages[1].Enabled = true; // Second tab  
                    }
                    if (varConvertFlag == 1)
                    {
                        grdPurchaseList.ReadOnly = false;
                        grdPurchaseList.Enabled = true;
                    }
                    cmbConcern.Enabled = false;
                    txtSupplier.Enabled = false;
                    cmbEntryType.Enabled = false;
                    btnViewDataView.Visible = false;
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 4;
                    objTRN_PurchaseEntry.ParaIds = pbPurchaseno;
                    objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();
                    grdPurchaseList.Rows.Clear();
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        string varQty = "";pbConditionIDs = "";
                        decimal varInvQty = 0;
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                            {
                                varQty = Convert.ToString(objDs.Tables[0].Rows[i]["QTY"]);
                            }
                            grdPurchaseList.Rows.Add(grdPurchaseList.Rows.Count + 1, "None", Convert.ToString(objDs.Tables[0].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_InvoiceMRP"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_ExpiryDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_Batch"]), Convert.ToString(objDs.Tables[0].Rows[i]["SL_EName"]), Convert.ToString(objDs.Tables[0].Rows[i]["RK_ShortName"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["HSN_Name"]), Convert.ToString(objDs.Tables[0].Rows[i]["HSN_Code"]), Convert.ToString(objDs.Tables[0].Rows[i]["GST_Text"]),
                            varQty, Convert.ToString(objDs.Tables[0].Rows[i]["INVQTY"]), Convert.ToString(objDs.Tables[0].Rows[i]["RecivedQty"]), Convert.ToString(objDs.Tables[0].Rows[i]["diffqty"]), Convert.ToString(objDs.Tables[0].Rows[i]["freeqty"])
                             , Convert.ToString(objDs.Tables[0].Rows[i]["Unit"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_PurchaseRate"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_DiscAmnt"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_DiscPer"])
                            , Convert.ToString(objDs.Tables[0].Rows[i]["TAX"]), Convert.ToString(objDs.Tables[0].Rows[i]["Gstper"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_GSTAmnt"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_CGSTPer"]), Convert.ToString(objDs.Tables[0].Rows[i]["CGSTAmnt"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_SGSTPer"]), Convert.ToString(objDs.Tables[0].Rows[i]["SGSTAmnt"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_IGSTPer"]), Convert.ToString(objDs.Tables[0].Rows[i]["IGSTAmnt"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["DiscountValue"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_NettAmnt"])
                            , Convert.ToString(objDs.Tables[0].Rows[i]["ID"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[0].Rows[i]["HSNID"]), Convert.ToString(objDs.Tables[0].Rows[i]["Gst value"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_SLID"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_RKID"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["PURPRID"]), Convert.ToString(objDs.Tables[0].Rows[i]["MST_DisplayText"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["DC Qty"]), Convert.ToString(objDs.Tables[0].Rows[i]["Inv Flag"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Costing"]), Convert.ToString(objDs.Tables[0].Rows[i]["GRN ProType"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["ConvertFlag"]), Convert.ToString(objDs.Tables[0].Rows[i]["Remaining Qty"]), Convert.ToString(objDs.Tables[0].Rows[i]["Converted ProductID"]));
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmGRNProType"].Value) == "202")// purchase against dc --for first time load dc quantity in billed qty
                            {
                                if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value) == "0" || Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value) == "")
                                {
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["DC Qty"]);
                                }
                                if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmRecqty"].Value) == "0" || Convert.ToString(grdPurchaseList.Rows[i].Cells["clmRecqty"].Value) == "")
                                {
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].Value = Convert.ToString(objDs.Tables[0].Rows[i]["DC Qty"]);
                                }
                            }
                            if (Convert.ToString(objDs.Tables[0].Rows[i]["INVQTY"]) != "")
                            {
                                if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value) != "")
                                {
                                    if (varInvQty == 0)
                                    {
                                        varInvQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value);
                                    }
                                    else
                                    {
                                        varInvQty = varInvQty + Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value);
                                    }
                                }
                            }
                            if (Convert.ToInt16(grdPurchaseList.Rows[i].Cells["ConvertFlag"].Value) == 1)
                            {
                                varConvertFlag = 1;
                            }
                            if (PbApprovalStsid == 70) // approval incomplete then allow to edit allow error column
                            {
                                if (Convert.ToInt16(objDs.Tables[0].Rows[i]["PurchaseRateErr"]) == 1)
                                {
                                    grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].ReadOnly = false;
                                    grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                }
                                else
                                {
                                    grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = Color.LightGray;
                                }
                                if (Convert.ToInt16(objDs.Tables[0].Rows[i]["DiscAmtErr"]) == 1)
                                {
                                    grdPurchaseList.Rows[i].Cells["clmDiscAmt"].ReadOnly = false;
                                    grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                }
                                else
                                {
                                    grdPurchaseList.Rows[i].Cells["clmDiscAmt"].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Style.BackColor = Color.LightGray;
                                }
                                if (Convert.ToInt16(objDs.Tables[0].Rows[i]["DisPerErr"]) == 1)
                                {
                                    grdPurchaseList.Rows[i].Cells["clmDiscPer"].ReadOnly = false;
                                    grdPurchaseList.Rows[i].Cells["clmDiscPer"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                }
                                else
                                {
                                    grdPurchaseList.Rows[i].Cells["clmDiscPer"].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmDiscPer"].Style.BackColor = Color.LightGray;
                                }
                                if (Convert.ToInt16(objDs.Tables[0].Rows[i]["InvoiceQtyErr"]) == 1)
                                {
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].ReadOnly = false;
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                }
                                else
                                {
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.LightGray;
                                }
                                if (Convert.ToInt16(objDs.Tables[0].Rows[i]["ReceivedQtyErr"]) == 1)
                                {
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].ReadOnly = false;
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                }
                                else
                                {
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.LightGray;
                                }
                                if (Convert.ToInt16(objDs.Tables[0].Rows[i]["FreeQtyErr"]) == 1)
                                {
                                    grdPurchaseList.Rows[i].Cells["clmFreeqty"].ReadOnly = false;
                                    grdPurchaseList.Rows[i].Cells["clmFreeqty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                                }
                                else
                                {
                                    grdPurchaseList.Rows[i].Cells["clmFreeqty"].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmFreeqty"].Style.BackColor = Color.LightGray;
                                }
                            }
                            if (varConvertFlag == 1)
                            {
                                if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmConvertedProID"].Value) != "0" && Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInwardFlag"].Value) == "0")
                                {
                                    grdPurchaseList.Rows[i].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].ReadOnly = false;
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmFreeqty"].ReadOnly = false;
                                    grdPurchaseList.Rows[i].Cells["clmDiscAmt"].ReadOnly = true;
                                    grdPurchaseList.Rows[i].Cells["clmDiscPer"].ReadOnly = true;

                                    grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = Color.LightGray;
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.PaleGreen;
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.LightGray;
                                    grdPurchaseList.Rows[i].Cells["clmFreeqty"].Style.BackColor = Color.PaleGreen;
                                    grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Style.BackColor = Color.LightGray;
                                    grdPurchaseList.Rows[i].Cells["clmDiscPer"].Style.BackColor = Color.LightGray;
                                }
                                else
                                {
                                    grdPurchaseList.Rows[i].ReadOnly = true;

                                    grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = Color.LightGray;
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.LightGray;
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.LightGray;
                                    grdPurchaseList.Rows[i].Cells["clmFreeqty"].Style.BackColor = Color.LightGray;
                                    grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Style.BackColor = Color.LightGray;
                                    grdPurchaseList.Rows[i].Cells["clmDiscPer"].Style.BackColor = Color.LightGray;
                                }
                            }
                            pbConditionIDs = Convert.ToString(grdPurchaseList.Rows[i].Cells["clmGRNProType"].Value);
                            var idSet = new HashSet<string>(pbConditionIDs.Split(',').Select(id => id.Trim()));
                            
                            if (PbSTS == "49" && idSet.Contains("281"))
                            {
                                grdPurchaseList.Rows[i].ReadOnly = true;
                                grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].ReadOnly = false;  
                                grdPurchaseList.Rows[i].Cells["clmInvQty"].ReadOnly = false;
                                grdPurchaseList.Rows[i].Cells["clmDiscAmt"].ReadOnly = false;
                                grdPurchaseList.Rows[i].Cells["clmDiscPer"].ReadOnly = false;
                                grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = Color.PaleGreen;
                                grdPurchaseList.Rows[i].Cells["clmFreeqty"].Style.BackColor = Color.LightGray;
                                grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.LightGray;
                                grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Style.BackColor = Color.LightGray;
                                grdPurchaseList.Rows[i].Cells["clmDiscPer"].Style.BackColor = Color.LightGray;
                                grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.PaleGreen;
                                grdPurchaseList.Rows[i].Cells["clmDiscPer"].Style.BackColor = Color.PaleGreen;
                                grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Style.BackColor = Color.PaleGreen;
                            } 
                        }
                        grdPurchaseList.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                        lblTpro.Text = Convert.ToString(grdPurchaseList.RowCount) + " / " + Convert.ToString(varInvQty);
                    }
                    if (pbSupplierTin != pbConcernTin)  //Supplier type IGST
                    {
                        grdPurchaseList.Columns["clmGstper"].Visible = false;
                        grdPurchaseList.Columns["clmGstamt"].Visible = false;
                        grdPurchaseList.Columns["clmCGST"].Visible = false;
                        grdPurchaseList.Columns["clmCGSTamt"].Visible = false;
                        grdPurchaseList.Columns["clmSGST"].Visible = false;
                        grdPurchaseList.Columns["clmSGSTamt"].Visible = false;
                        grdPurchaseList.Columns["clmIGST"].Visible = true;
                        grdPurchaseList.Columns["clmIGSTamt"].Visible = true;
                    }
                    else
                    {
                        grdPurchaseList.Columns["clmGstper"].Visible = true;
                        grdPurchaseList.Columns["clmGstamt"].Visible = true;
                        grdPurchaseList.Columns["clmCGST"].Visible = true;
                        grdPurchaseList.Columns["clmCGSTamt"].Visible = true;
                        grdPurchaseList.Columns["clmSGST"].Visible = true;
                        grdPurchaseList.Columns["clmSGSTamt"].Visible = true;
                        grdPurchaseList.Columns["clmIGST"].Visible = false;
                        grdPurchaseList.Columns["clmIGSTamt"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfntooltiphide()
        {
            try
            {
                errPurchaseentry.Clear();
                cmbConcern.BackColor = Color.White;
                txtInvoiceNo.BackColor = Color.White;
                txtInvoiceamt.BackColor = Color.White;
                txtSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public DataTable udfnobjPurchaseprodDetails()
        {
            varcount1 = 0; varQuantityErr = 0;//used for-- if error redirect to 2nd tab
            varDiscountErr = 0;
            string varConvertProductFlag = "0";
            DataTable objPurchaseentryDetails = new DataTable();
            try
            {
                if (pbPurchaseno != "0")
                {
                    objPurchaseentryDetails.TableName = "TRN_Purchase_Products_Details";
                    objPurchaseentryDetails.Columns.Add("PURPR_PURID", typeof(int));
                    objPurchaseentryDetails.Columns.Add("PURPR_PRID", typeof(int));
                    objPurchaseentryDetails.Columns.Add("PURPR_HSNID", typeof(int));
                    objPurchaseentryDetails.Columns.Add("PURPR_PurchaseRate", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_POQty", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_InvoiceQty", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_ReceivedQty", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_DiffQty", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_FreeQty", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_DiscPer", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_DiscAmnt", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_TaxableValue", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_GSTPer", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_GSTAmnt", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_NettAmnt", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_Error", typeof(int));
                    objPurchaseentryDetails.Columns.Add("PURPRID", typeof(int));
                    objPurchaseentryDetails.Columns.Add("ID", typeof(int));
                    objPurchaseentryDetails.Columns.Add("PURPR_Costing", typeof(decimal));
                    objPurchaseentryDetails.Columns.Add("PURPR_DiscountValue", typeof(decimal));
                    objPurchaseentryDetails.Columns.Add("PURPR_CGSTPer", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_SGSTPer", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_CGSTAmnt", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_SGSTAmnt", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_ISGSTPer", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_IGSTAmnt", typeof(float));
                    objPurchaseentryDetails.Columns.Add("PURPR_ConvertedProductID", typeof(int));
                    objPurchaseentryDetails.Columns.Add("PURPR_GRNProType", typeof(int));
                    objPurchaseentryDetails.Columns.Add("PURPR_ConvertProduct", typeof(int));
                    if (grdPurchaseList.Rows.Count != 0)
                    {
                        for (int i = 0; i < grdPurchaseList.Rows.Count; i++)
                        {
                            string varZero = "0"; pbConditionIDs = "";
                            int varDecimal = Convert.ToInt32(grdPurchaseList.Rows[i].Cells["UT_Decimal"].Value);
                            varZero = 0 + objValidation.udfnDecimal(Convert.ToString(varZero), varDecimal);
                            varConvertProductFlag = "0";
                            varConvertProductFlag = Convert.ToString(grdPurchaseList.Rows[i].Cells["clmConvertedProID"].Value);
                            pbConditionIDs = Convert.ToString(grdPurchaseList.Rows[i].Cells["clmGRNProType"].Value);
                            var idSet = new HashSet<string>(pbConditionIDs.Split(',').Select(id => id.Trim()));
                            decimal varQty = 0, varFreeQuantity = 0, varRecqty = 0, varDiffQty = 0, varInvqty = 0, varFlag = 0, varDCQty = 0, varerrFlag = 0;
                            int varProductType = 0,varConvertProductID=0;
                            decimal varPurchaseRate = 0, varDiscAmt = 0; decimal varPOqty = 0, varCosting = 0, varDiscountValue = 0;
                            decimal varSGSTPer = 0, varCGSTPer = 0, varIGSTPer = 0, varSGSTAmt = 0, varCGSTAmt = 0, varIGSTAmt = 0;
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmRecqty"].Value) != "")
                            { varRecqty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmRecqty"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmFreeqty"].Value) != "")
                            { varFreeQuantity = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmFreeqty"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmDiffqty"].Value) != "")
                            { varDiffQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiffqty"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value) != "")
                            { varInvqty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmConvertedProID"].Value) != "")
                            { varConvertProductID = Convert.ToInt16(grdPurchaseList.Rows[i].Cells["clmConvertedProID"].Value); }
                            if(Convert.ToString((grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value)) != "")
                            {  varPurchaseRate = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value);  }
                            if(Convert.ToString((grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Value)) != "")
                            { varDiscAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmDCQuantity"].Value) != "")
                            { varDCQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDCQuantity"].Value); } 
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInwardFlag"].Value) != "")
                            { varFlag = Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmInwardFlag"].Value); }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["poid"].Value)) != "")
                            { varProductType = Convert.ToInt32(grdPurchaseList.Rows[i].Cells["poid"].Value); } 
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmPOqty"].Value) != "")
                            { varPOqty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmPOqty"].Value);}
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmCosting"].Value) != "")
                            {  varCosting = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCosting"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmSGST"].Value) != "")
                            { varSGSTPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGST"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmCGST"].Value) != "")
                            { varCGSTPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGST"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmIGST"].Value) != "")
                            { varIGSTPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGST"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmSGSTamt"].Value) != "")
                            { varSGSTAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGSTamt"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmCGSTamt"].Value) != "")
                            { varCGSTAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGSTamt"].Value); }
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmIGSTamt"].Value) != "")
                            { varIGSTAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGSTamt"].Value); }
                            if (rbDiscountAfter.Checked == true)
                            {
                                if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmDiscountValue"].Value) != "")
                                { varDiscountValue = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscountValue"].Value); }
                            }

                            if (chkCompleted.Checked == true)
                            {
                                if (!idSet.Contains("281") && varConvertProductID==0)  //Parent item and condition should be pro not received
                                {
                                    if (varPurchaseRate == 0)
                                    {
                                        varcount++; varcount1++;
                                        grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = Color.LightPink;
                                        grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.ForeColor = Color.Black;
                                    }
                                    else
                                    {  grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = Color.PaleGreen;   }
                                    if (varInvqty == 0 || Convert.ToString(varInvqty) == varZero)
                                    {
                                        varcount++;   varcount1++;
                                        grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.LightPink;
                                        grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.ForeColor = Color.Black;
                                    }
                                    else
                                    {  grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.PaleGreen; }
                                    if(varRecqty ==0 || Convert.ToString(varRecqty) == varZero)
                                    {
                                        varcount++; varcount1++;
                                        grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.LightPink;
                                        grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.ForeColor = Color.Black;
                                    }
                                    else
                                    {  grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.PaleGreen; }
                                    if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmDiscPer"].Value) != "")
                                    {
                                        if (Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscPer"].Value) > 100)
                                        {
                                            varcount++; varcount1++;
                                            grdPurchaseList.Rows[i].Cells["clmDiscPer"].Style.BackColor = Color.LightPink;
                                            grdPurchaseList.Rows[i].Cells["clmDiscPer"].Style.ForeColor = Color.Black;
                                        }
                                    }
                                } 
                                if (varProductType==220 && (!idSet.Contains("281")))  //Against DC Product type && not a LP condition
                                { 
                                    if ( varRecqty!= 0 &&  varInvqty != 0 && varConvertProductFlag != "0")
                                    { 
                                        varQty = varInvqty + varDiffQty; 
                                        if (varFlag == 1)
                                        {
                                            if (varDCQty != varQty || varRecqty != varQty || varInvqty != varRecqty)
                                            {
                                                varcount++; varQuantityErr++; varerrFlag = 1;
                                            }
                                        }
                                        else
                                        {
                                            if (varProductType == 220) //dc products
                                            {
                                                if (varDCQty != varQty || varRecqty != varQty || varRecqty != varDCQty)
                                                {
                                                    varcount++; varQuantityErr++; varerrFlag = 1;
                                                }
                                            } 
                                        }
                                        if (varDiffQty != 0)
                                        {
                                            varcount++; varQuantityErr++; varerrFlag = 1;
                                        } 
                                    }
                                }
                                else
                                {
                                    if (varRecqty != 0 && varInvqty != 0 && varConvertProductFlag == "0")
                                    {
                                        varQty = varRecqty + varDiffQty;
                                        if (varFlag == 1)
                                        { 
                                            if (varDCQty != (varRecqty) || varDiffQty != varQty)
                                            {
                                                varcount++; varQuantityErr++; varerrFlag = 1;
                                            }
                                        }
                                        else
                                        {
                                            if (varInvqty != varQty)
                                            {
                                                varcount++; varQuantityErr++; varerrFlag = 1;
                                            }
                                        }
                                    }
                                }
                                if (varerrFlag == 1)
                                {
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.LightPink;
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.LightPink;
                                }
                                else
                                {
                                    grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.PaleGreen;
                                    grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.PaleGreen;
                                }
                                if ((varPurchaseRate * varInvqty) < varDiscAmt)
                                {
                                    varDiscountErr++;
                                    grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Style.BackColor = Color.LightPink;
                                    grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Style.ForeColor = Color.Black;
                                }
                            }  
                            
                            if (varcount == 0)
                            {
                                objPurchaseentryDetails.Rows.Add(pbPurchaseno, Convert.ToInt32(grdPurchaseList.Rows[i].Cells["proid"].Value),
                                Convert.ToInt32(grdPurchaseList.Rows[i].Cells["hsnid"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value),
                                Convert.ToDecimal(varPOqty), varInvqty,
                                varRecqty, Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiffqty"].Value),
                                varFreeQuantity, Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscPer"].Value),
                                Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmTax"].Value),
                                Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["GstValue"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmGstamt"].Value),
                                Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmnetamt"].Value), 0, Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmPURPRID"].Value),
                                Convert.ToInt32(grdPurchaseList.Rows[i].Cells["poid"].Value), Convert.ToDecimal(varCosting), varDiscountValue,
                                Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGST"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGST"].Value),
                                Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGSTamt"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGSTamt"].Value),
                                Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGST"].Value), Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGSTamt"].Value),
                                //0,0
                                Convert.ToInt16(grdPurchaseList.Rows[i].Cells["clmConvertedProID"].Value),
                                0,
                               Convert.ToInt16(grdPurchaseList.Rows[i].Cells["ConvertFlag"].Value));
                            }
                        }

                        string varProductID = "", varTotalRemainingQty = "";
                        int varConvertProduct = 0; int varGRNProductType = 193; //GRN productType pending qty

                        //Sum the received qty for converted product by grouping the parent id 
                        var result = from purchase in objPurchaseentryDetails.AsEnumerable()
                                     where purchase.Field<int>("PURPR_ConvertProduct") == varConvertProduct && purchase.Field<int>("PURPR_ConvertedProductID") != 0
                                     group purchase by purchase.Field<int>("PURPR_ConvertedProductID") into grp
                                     select new
                                     {
                                         TotalReceivedQuantity = grp.Sum(p => p.Field<float>("PURPR_ReceivedQty")),
                                         PURID = grp.Key
                                     }; 
                        varProductID = string.Join(",", result.Select(r => r.PURID).ToList());
                        varTotalRemainingQty = string.Join(",", result.Select(r => r.TotalReceivedQuantity).ToList());

                        List<int> varPURPRIDs = new List<int>(); List<float> varTotReceivedQty = new List<float>();

                        varPURPRIDs = result.Select(r => r.PURID).ToList();
                        varTotReceivedQty = result.Select(r => r.TotalReceivedQuantity).ToList();
                        //Parent Difference quantity should not be greater than Converted product
                        for (int i = 0; i < varPURPRIDs.Count(); i++)
                        {
                            for (int j = 0; j < grdPurchaseList.RowCount; j++)
                            {
                                if (Convert.ToString(varPURPRIDs[i]) == Convert.ToString(grdPurchaseList.Rows[j].Cells["clmPURPRID"].Value))
                                {
                                    if (Convert.ToDecimal(varTotReceivedQty[i]) > Convert.ToDecimal(grdPurchaseList.Rows[j].Cells["clmParentRemaingingQty"].Value) || Convert.ToDecimal(varTotReceivedQty[i]) == 0)
                                    {
                                        for (int k = 0; k < grdPurchaseList.RowCount; k++)
                                        {
                                            if (Convert.ToString(varPURPRIDs[i]) == Convert.ToString(grdPurchaseList.Rows[k].Cells["clmConvertedProID"].Value))
                                            {
                                                varQuantityErr++;  
                                                //Converted product error
                                                grdPurchaseList.Rows[k].Cells["clmInvQty"].Style.BackColor = Color.LightPink;
                                                grdPurchaseList.Rows[k].Cells["clmRecqty"].Style.BackColor = Color.LightPink;
                                                grdPurchaseList.Rows[k].Cells["clmFreeqty"].Style.BackColor = Color.LightPink;
                                                //Parentproduct error
                                                grdPurchaseList.Rows[j].Cells["clmInvQty"].Style.BackColor = Color.LightPink;
                                                grdPurchaseList.Rows[j].Cells["clmRecqty"].Style.BackColor = Color.LightPink;
                                                grdPurchaseList.Rows[j].Cells["clmFreeqty"].Style.BackColor = Color.LightPink;
                                            }
                                        }
                                    }
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
            return objPurchaseentryDetails;
        }
        public (DataTable objPurchaseentry, DataTable objPurchaseProdValidation) udfnobjPurchaseprod()
        {
            varcount = 0; varExpiryError = 0; shelfLifeError = 0; varPrCountFlag = 0; varPrCount = 0;
            PurchaseDcIds = "0"; 
            DialogResult result1 = DialogResult.Yes;
            DataTable objPurchaseentry = new DataTable();
            DataTable objPurchaseProdValidation = new DataTable();
            try
            {
                objPurchaseentry.TableName = "TRN_Purchase_Products";
                objPurchaseentry.Columns.Add("PURPR_PURID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_PRID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_UTID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_GRNMRP", typeof(decimal));
                objPurchaseentry.Columns.Add("PURPR_InvoiceMRP", typeof(decimal));
                objPurchaseentry.Columns.Add("PURPR_ExpiryDate", typeof(string));
                objPurchaseentry.Columns.Add("PURPR_Batch", typeof(string));
                objPurchaseentry.Columns.Add("PURPR_SLID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_RKID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_HSNID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_PurchaseRate", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_POQty", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_InvoiceQty", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_ReceivedQty", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_DiffQty", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_FreeQty", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_DiscPer", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_DiscAmnt", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_TaxableValue", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_GSTPer", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_GSTAmnt", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_NettAmnt", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_Costing", typeof(decimal));
                objPurchaseentry.Columns.Add("PURPR_ShelfLife", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ShelfLifeValue", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ShelfLifePer", typeof(decimal));
                objPurchaseentry.Columns.Add("PURPR_Error", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_POID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_BatchNoStatus", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_BatchNoGenration", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ShelfLife_Flag", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ShelfLifeStatus", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_TOTQTY", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_GRNQTY", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_DCQTY", typeof(float));
                objPurchaseentry.Columns.Add("PURPRID", typeof(int));
                objPurchaseentry.Columns.Add("ID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_DiscountValue", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_CGSTPer", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_CGSTAmnt", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_SGSTPer", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_SGSTAmnt", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_ISGSTPer", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_IGSTAmnt", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_MRPflag", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_RMProductionFlag", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ConvertProduct", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ProMRP", typeof(decimal));
                objPurchaseentry.Columns.Add("PURPR_ProExpiryDate", typeof(string));
                objPurchaseentry.Columns.Add("PURPR_ProBatch", typeof(string));
                objPurchaseentry.Columns.Add("PURPR_Condition", typeof(string));
                objPurchaseentry.Columns.Add("PURPR_MismatchQty", typeof(decimal));
                objPurchaseentry.Columns.Add("PURPR_InwardDate", typeof(string));
                objPurchaseentry.Columns.Add("PURPR_ReturnType", typeof(int));

                objPurchaseProdValidation.TableName = "TRN_Products";
                objPurchaseProdValidation.Columns.Add("GRNPR_SNO", typeof(int));
                objPurchaseProdValidation.Columns.Add("GRNPR_PRID", typeof(int));
                objPurchaseProdValidation.Columns.Add("GRNPR_QTY", typeof(float));
                objPurchaseProdValidation.Columns.Add("GRNPR_Condition_Type", typeof(string));
                objPurchaseProdValidation.Columns.Add("GRNPR_MRP", typeof(float));
                objPurchaseProdValidation.Columns.Add("GRNPR_Expirydate", typeof(string));
                objPurchaseProdValidation.Columns.Add("GRNPR_SLID", typeof(int));
                objPurchaseProdValidation.Columns.Add("GRNPR_RKID", typeof(int));
                objPurchaseProdValidation.Columns.Add("GRNPR_InvoiceMRP", typeof(float));
                objPurchaseProdValidation.Columns.Add("GRNPR_InvoiceExpirydate", typeof(string));
                objPurchaseProdValidation.Columns.Add("GRNPR_Return_Type", typeof(int));
                objPurchaseProdValidation.Columns.Add("GRNPR_BatchNo", typeof(string));
                objPurchaseProdValidation.Columns.Add("GRNPR_InvoiceBatchNo", typeof(string));

                if (tbDetails.TabPages[0].Enabled == true)
                {
                    grdSupplierList.Sort(grdSupplierList.Columns[0], ListSortDirection.Ascending);
                    for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                    {
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value) != "0" || Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value) == "")
                        {
                            decimal varMRP = 0, varGrnMRP = 0; decimal varShelfPer = 0, varExcessQty = 0, varPendingQty = 0, varMismatchQty = 0, varDamageQty = 0; varTempExpiryDate = ""; int varConvertProduct = 0;
                            int Shelflifevalue = 0, ProShelflife = 0, POno = 0; string[] varShelflifevaluesplit; string[] varShelflifeper; string[] varProShelfLife;
                            decimal varProMRP = 0; string varProductExpiryDate = "", varProCondition  = "", dateString="";
                            string varInwardDate = ""; int varInwardDateFlag = 0;
                            string shelfper = ""; decimal shelflifeper = 0; varTempExpiryDate = "0";
                            string varTempYear = "0", varExpiryDate = "", varCondition = "0";
                            varProductExpiryDate = "0"; string varProExpiryDate = "", varProYear = "0";

                            varProCondition = Convert.ToString(grdSupplierList.Rows[i].Cells["clmConditionID"].Value);
                            var conditionSet = new HashSet<string>(varProCondition.Split(','));

                            varInwardDate = Convert.ToString(grdSupplierList.Rows[i].Cells["clmInwardDate"].Value);  
                            varTempExpiryDate = Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value);
                            dateString = varTempExpiryDate;

                            if (dateString.Length > 10 && dateString != "" && varProCondition.Contains("226") == false)
                            {
                                grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.ForeColor = Color.Black; 
                                varcount++; varCount2++;
                            }
                            else
                            {
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmshelfper"].Value.ToString().Trim()) != "")
                                { 
                                    object cellValue1 = Convert.ToString(grdSupplierList.Rows[i].Cells["clmshelfper"].Value); 
                                    shelfper = cellValue1.ToString();
                                    string[] shelfvalue = shelfper.Split('%');
                                    shelflifeper = Convert.ToDecimal(shelfvalue[0]);
                                    if (shelflifeper < varShelflifeLevel2)
                                    {
                                        shelfLifeError++;
                                    }
                                }  
                                //if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "73") //Disabled
                                //{
                                //    grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                                //    grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Style.BackColor = Color.LightGray;
                                //}
                                //else if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "72") //Enabled
                                //{
                                //    if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchno"].Value) == "" && (varProConditionType != "226" || varProConditionType != "264"
                                //    || varProConditionType != "265" || varProConditionType != "266" || varProConditionType != "267"))
                                //    {
                                //        varcount++; varCount2++;
                                //        grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightPink;
                                //    }
                                //    else
                                //    {
                                //        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "74") //Auto
                                //        {
                                //            grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                                //        }
                                //        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "75") //Manual
                                //        {
                                //            grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                                //        }
                                //    }
                                //    if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Value) == "")
                                //    {
                                //        varcount++; varCount2++;
                                //        grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Style.BackColor = Color.LightPink;
                                //    }
                                //    else
                                //    {
                                //        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "74") //Auto
                                //        {
                                //            grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Style.BackColor = Color.LightGray;
                                //        }
                                //        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "75") //Manual
                                //        {
                                //            grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Style.BackColor = Color.LightGray;
                                //        }
                                //    }
                                //} 
                                object cellValue = Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value); 
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
                                varTempExpiryDate = cellValue.ToString();  
                                object cellProExpiryDate = Convert.ToString(grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].Value);
                                
                                varProExpiryDate = cellProExpiryDate.ToString();
                                string[] ProDMY = varProExpiryDate.Split('/');
                                if (ProDMY.Count() == 3)
                                {
                                    varProYear = ProDMY[2];
                                    if (varProYear.Length == 2)
                                    {
                                        cellProExpiryDate = ProDMY[0] + "/" + ProDMY[1] + "/" + 20 + varProYear;
                                    }
                                    else
                                    {
                                        cellProExpiryDate = ProDMY[0] + "/" + ProDMY[1] + "/" + varProYear;
                                    }
                                }
                                varProductExpiryDate = cellProExpiryDate.ToString();

                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmMRP"].Value) != "")
                                {
                                    varMRP = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmMRP"].Value);
                                }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmProductMrp"].Value) != "")
                                {
                                    varProMRP = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmProductMrp"].Value);
                                } 
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmGrnMrp"].Value) != "")
                                {
                                    varGrnMRP = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmGrnMrp"].Value);
                                } 
                                varShelflifevaluesplit = Convert.ToString(grdSupplierList.Rows[i].Cells["clmactuallife"].Value).Split(' ');
                                varShelflifeper = Convert.ToString(grdSupplierList.Rows[i].Cells["clmshelfper"].Value).Split(' ');
                                varProShelfLife = Convert.ToString(grdSupplierList.Rows[i].Cells["clmshelflife"].Value).Split(' '); 
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
                            } 
                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value) == "")
                            {
                                POno = 0;
                            }
                            else { POno = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmid"].Value); }
                            if (chkCompleted.Checked == true)
                            {
                                if (Convert.ToInt16(cmbEntryType.SelectedValue) == 54 && POno == 218) //GRN product count
                                {
                                    varPrCount++;
                                }
                                if (Convert.ToInt16(cmbEntryType.SelectedValue) == 57 && POno == 220) //DC product count
                                {
                                    varPrCount++;
                                }
                            } 
                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmMismatchQty"].Value) != "" || Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmMismatchQty"].Value) != 0)
                            { varMismatchQty = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmMismatchQty"].Value); } 

                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmConditionID"].Value) != "")
                            { varCondition = Convert.ToString(grdSupplierList.Rows[i].Cells["clmConditionID"].Value); }

                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmConvertProductFlag"].Value) == "1")
                            {
                                if (varInwardDate == "")
                                {
                                    varcount++; varCount2++;
                                    grdSupplierList.Rows[i].Cells["clmInwardDate"].Style.BackColor = Color.LightPink;
                                }
                                else
                                {
                                    string varTempInvYear = "0";
                                    object cellValue = Convert.ToString(grdSupplierList.Rows[i].Cells["clmInwardDate"].Value);
                                    string varInvDate = "";
                                    varInvDate = cellValue.ToString();
                                    string[] DMY = varInwardDate.Split('/');
                                    if (DMY.Count() == 3)
                                    {
                                        varTempInvYear = DMY[2];
                                        if (varTempInvYear.Length == 2)
                                        {
                                            cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempInvYear;
                                        }
                                        else
                                        {
                                            cellValue = DMY[0] + "/" + DMY[1] + "/" + varTempInvYear;
                                        }
                                    }
                                    varInwardDate = cellValue.ToString();
                                }
                            }

                            if (varcount == 0 && Convert.ToInt32(VarGridError) == 0)
                            {
                                int varPURPRID = 0,varReasonID=0,slid=0,rkid=0, HSNid=0,BatchEnable=0,batchGeneration=0,shelflifeFlag=0,MRPFlag=0,RMFlag=0,sno=0;
                                int varProductId = 0;  // dc or grn or po- product id
                                decimal varTotQty = 0, varGRNQty = 0, varDCQty = 0;
                                string InvBatchno = "", ProBatchNo = "";
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmPURPRIDDetail"].Value) != "" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmPURPRIDDetail"].Value) != "0")
                                {
                                    varPURPRID = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmPURPRIDDetail"].Value);
                                }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmProductID"].Value) != "" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmProductID"].Value) != "0")
                                {
                                    varProductId = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmProductID"].Value);
                                }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmConvertProduct"].Value) != "" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmConvertProduct"].Value) != "0")
                                {
                                    varConvertProduct = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmConvertProduct"].Value);
                                }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["slid"].Value) != "")
                                { slid = Convert.ToInt32(grdSupplierList.Rows[i].Cells["slid"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["rkid"].Value) != "")
                                { rkid = Convert.ToInt32(grdSupplierList.Rows[i].Cells["rkid"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmHSNid"].Value) != "")
                                { HSNid = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmHSNid"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) != "")
                                { BatchEnable = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) != "")
                                { batchGeneration = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmShelflifeenable"].Value) != "")
                                { shelflifeFlag = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmShelflifeenable"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmMrpFlag"].Value) != "")
                                { MRPFlag = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmMrpFlag"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmRMFlag"].Value) != "")
                                { RMFlag = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmRMFlag"].Value); }

                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchno"].Value) != "")
                                { InvBatchno = Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchno"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Value) != "")
                                { ProBatchNo = Convert.ToString(grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Value); }

                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmTotQty"].Value) != "")
                                { varTotQty = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmTotQty"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmDCQty"].Value) != "")
                                { varDCQty = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmDCQty"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmGRNQty"].Value) != "")
                                { varGRNQty = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmGRNQty"].Value); }

                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmReasonID"].Value)!="") 
                                { varReasonID = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmReasonID"].Value); }
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmsno"].Value) != "")
                                { sno = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmsno"].Value); }

                                objPurchaseentry.Rows.Add(0, Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmProid"].Value),
                                Convert.ToInt32(grdSupplierList.Rows[i].Cells["UTID"].Value), varGrnMRP, varMRP, Convert.ToString(varTempExpiryDate)
                                , InvBatchno,slid,rkid, HSNid, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ProShelflife, varShelfPer , 0, POno, BatchEnable, batchGeneration , Shelflifevalue,shelflifeFlag, Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmTransId"].Value)
                                , varTotQty,varGRNQty  , varDCQty, varPURPRID, varProductId,0, 0, 0, 0, 0, 0, 0,MRPFlag, RMFlag, varConvertProduct, varProMRP,
                                Convert.ToString(varProductExpiryDate),  ProBatchNo, varCondition,  varMismatchQty, varInwardDate, varReasonID); 

                                objPurchaseProdValidation.Rows.Add(sno, Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmProid"].Value), varMismatchQty, varCondition, varProMRP, Convert.ToString(varProductExpiryDate), slid, rkid, varMRP, Convert.ToString(varTempExpiryDate), varReasonID, ProBatchNo, InvBatchno);
                            }
                            if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                            {
                                PurchaseDcIds = Convert.ToString(pbDCNo);       
                            }
                        }
                    }
                    if (Convert.ToString(cmbEntryType.SelectedValue) == "57")
                    {
                        if (Convert.ToInt16(tsbTotalProducts.Text) != varPrCount && chkCompleted.Checked == true)
                        {
                            varPrCountFlag = 1;
                        }
                    }
                    else if (Convert.ToString(cmbEntryType.SelectedValue) == "54")
                    {
                        if (Convert.ToInt16(tsbTotalProducts.Text) < varPrCount && chkCompleted.Checked == true)
                        {
                            varPrCountFlag = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return (objPurchaseentry, objPurchaseProdValidation);
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
        private void TxtInvoiceamt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceamt.BackColor = Color.White;
                if (txtInvoiceamt.Text.Trim() != "")
                {
                    string Invoiceamt = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtInvoiceamt.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtInvoiceamt.Text = Invoiceamt;
                }
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
                    if (cmbTransactionType.Enabled == true)
                    {
                        cmbTransactionType.Focus();
                    }
                    else { txtBroker.Focus(); }
                }
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
        private void GrdPurchaseList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmPOqty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty"
                        || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmRecqty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscAmt" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer"
                        || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmPurchaseRate" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmFreeqty")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
                if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmHSN")
                {
                    TextBox txtHSNName = e.Control as TextBox;
                    if (txtHSNName != null)
                    {
                        txtHSNName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtHSNName.AutoCompleteCustomSource = AutoCompleteHSN();
                        txtHSNName.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                TextBox textBox = (TextBox)sender;

                if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmRecqty"
                    || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiffqty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmFreeqty")
                {
                    int varDecimal = Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["UT_DECIMAL"].Value); 
                    if (textBox.Text.Length >= 8 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
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
                    //allow only one decimal
                    if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
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
        public AutoCompleteStringCollection AutoCompleteHSN()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("select  HSNID, HSN_Name from MR_HSN where HSNID NOT IN(-1, 0) AND HSN_STSID=1 ");
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
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("HSN_Name") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        private void TxtLoadingCharge_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLoadingCharge.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLoadingCharge_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLoadingCharge.BackColor = Color.White;
                if (txtCouriercharge.Text.Trim() != "")
                {
                    string loadingCharge = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtLoadingCharge.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtLoadingCharge.Text = loadingCharge;
                    udfnLoadingGrandTotCalculation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLoadingCharge_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUnLoadingCharge.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLoadingCharge_KeyPress(object sender, KeyPressEventArgs e)
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
        public void udfnGstvalue()
        {
            try
            {
                dtTaxTable.Rows.Clear();
                // Group by "Percentage" and calculate the sum of "Value1" and "Value2"
                var varTaxData = grdPurchaseList.Rows.Cast<DataGridViewRow>()
                    .GroupBy(row => row.Cells["clmGstper"].Value)
                    .Select(group =>
                    {
                        return new
                        {
                            GST = group.Key.ToString(),
                            Tax = group.Sum(row => Convert.ToDecimal(row.Cells["clmTax"].Value)),
                            GSTamount = group.Sum(row => Convert.ToDecimal(row.Cells["clmGstamt"].Value)),
                            IGSTamount = group.Sum(row => Convert.ToDecimal(row.Cells["clmGstamt"].Value)),
                            CGSTamount = group.Sum(row => Convert.ToDecimal(row.Cells["clmGstamt"].Value) / 2),
                            SGSTamount = group.Sum(row => Convert.ToDecimal(row.Cells["clmGstamt"].Value) / 2)

                        };
                    }).ToList();

                dtTaxTable = varTaxData.Select(item => dtTaxTable.LoadDataRow(new object[]
                { item.GST, item.Tax.ToString("0.00"),(item.GSTamount).ToString("0.00"),
                 Convert.ToDecimal(item.GST),(item.IGSTamount).ToString("0.00"),
                (Convert.ToDecimal(item.GST)/2).ToString("0.0"),(item.SGSTamount).ToString("0.00"),
                (Convert.ToDecimal(item.GST)/2).ToString("0.0"),(item.CGSTamount).ToString("0.00")
                }, false)).CopyToDataTable();

                var varTaxValue = dtTaxTable.AsEnumerable().Sum(x => x.Field<decimal>("Tax Value")).ToString();
                var varIGST = dtTaxTable.AsEnumerable().Sum(x => x.Field<decimal>("IGST ")).ToString();
                var varCGST = dtTaxTable.AsEnumerable().Sum(x => x.Field<decimal>("CGST")).ToString();
                var varSGST = dtTaxTable.AsEnumerable().Sum(x => x.Field<decimal>("CGST")).ToString();

                dtTaxTable.Rows.Add("Total", 0, Convert.ToDecimal(varTaxValue), "", Convert.ToDecimal(varIGST), "",
                    Convert.ToDecimal(varSGST), "", Convert.ToDecimal(varCGST));
                grdTaxDetails.DataSource = dtTaxTable;
                grdTaxDetails.Columns["GST%"].Width = 40;
                grdTaxDetails.Columns["Taxable Value"].Width = 80;

                grdTaxDetails.Columns["Tax Value"].Width = 40;
                grdTaxDetails.Columns["IGST%"].Width = 45;
                grdTaxDetails.Columns["CGST%"].Width = 45;
                grdTaxDetails.Columns["SGST%"].Width = 45;
                grdTaxDetails.Columns["IGST Value"].Width = 80;
                grdTaxDetails.Columns["CGST Value"].Width = 80;
                grdTaxDetails.Columns["SGST Value"].Width = 80;
                grdTaxDetails.Columns["GST%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTaxDetails.Columns["IGST%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTaxDetails.Columns["SGST%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTaxDetails.Columns["Taxable Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTaxDetails.Columns["IGST Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTaxDetails.Columns["CGST Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTaxDetails.Columns["SGST Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTaxDetails.Columns["Tax Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (grdTaxDetails.Rows.Count != 0)
                {
                    grdTaxDetails.Rows[grdTaxDetails.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                    grdTaxDetails.Rows[grdTaxDetails.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
                    grdTaxDetails.Rows[grdTaxDetails.Rows.Count - 1].DefaultCellStyle.Font = new Font("Oswald Regular", 9, FontStyle.Bold);
                }
                if (pbSupplierTin != pbConcernTin) //IGST
                {
                    grdTaxDetails.Columns["SGST%"].Visible = false;
                    grdTaxDetails.Columns["CGST%"].Visible = false;
                    grdTaxDetails.Columns["SGST Value"].Visible = false;
                    grdTaxDetails.Columns["CGST Value"].Visible = false;
                    grdTaxDetails.Columns["IGST%"].Visible = true;
                    grdTaxDetails.Columns["IGST Value"].Visible = true;
                }
                else
                {
                    grdTaxDetails.Columns["GST%"].Visible = true;
                    grdTaxDetails.Columns["CGST%"].Visible = true;
                    grdTaxDetails.Columns["SGST Value"].Visible = true;
                    grdTaxDetails.Columns["CGST Value"].Visible = true;
                    grdTaxDetails.Columns["GST%"].Visible = true;
                    grdTaxDetails.Columns["CGST%"].Visible = true;
                    grdTaxDetails.Columns["IGST%"].Visible = false;
                    grdTaxDetails.Columns["IGST Value"].Visible = false;
                }
                //grdTaxDetails.Columns["Taxable Value"].Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUnLoadingCharge_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCouriercharge.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtUnLoadingCharge_Leave(object sender, EventArgs e)
        {
            try
            {
                txtUnLoadingCharge.BackColor = Color.White;
                if (txtCouriercharge.Text.Trim() != "")
                {
                    string UnloadingCharge = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtUnLoadingCharge.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtUnLoadingCharge.Text = UnloadingCharge;
                    udfnLoadingGrandTotCalculation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtUnLoadingCharge_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtUnLoadingCharge_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUnLoadingCharge.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCouriercharge_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtotherexpense.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCouriercharge_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCouriercharge.BackColor = Color.White;
                if (txtCouriercharge.Text.Trim() != "")
                {
                    string courierCharge = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtCouriercharge.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtCouriercharge.Text = courierCharge;
                    udfnLoadingGrandTotCalculation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCouriercharge_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtCouriercharge_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCouriercharge.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtotherexpense_Leave(object sender, EventArgs e)
        {
            try
            {
                txtotherexpense.BackColor = Color.White;
                if (txtotherexpense.Text.Trim() != "")
                {
                    string otherExpense = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtotherexpense.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtotherexpense.Text = otherExpense;
                    udfnLoadingGrandTotCalculation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtotherexpense_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTcsamt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtotherexpense_KeyPress(object sender, KeyPressEventArgs e)
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
        private void Txtotherexpense_Enter(object sender, EventArgs e)
        {
            try
            {
                txtotherexpense.BackColor = Color.LemonChiffon;
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

        private void btnConditions_Click(object sender, EventArgs e)
        {  
            udfnPnlConditionVisible(); 
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
                pbCondition = ""; pbConditionIDs = "";
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
                        if (pbConditionIDs == "275")
                        { txtMismatchQty.Enabled = false; txtMismatchQty.ReadOnly = true; }
                        else { txtMismatchQty.Enabled = true; txtMismatchQty.ReadOnly = false; }
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
       
        private void btnApply_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
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

        private void txtMismatchQty_KeyPress(object sender, KeyPressEventArgs e)
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
        public void udfnConditionName()
        {
            try
            { 
                 var result = (grdConditions.DataSource as DataTable).AsEnumerable()
                          .Where(r => Convert.ToBoolean(r["clmCheck"])==true)  // Filter where clmCheck is true
                          .Select(r => new
                          {
                              ConditionId = r["ConditionID"],
                              ConditionName = r["ConditionShortName"]
                          })
                          .ToList();
                pbCondition = string.Join(",", result.Select(r => r.ConditionName));
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

        private void btnConditionClose_Click(object sender, EventArgs e)
        {
            try
            {
                pnlConditions.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                    if(txtMrp.Enabled==true)
                    { txtMrp.Focus(); }
                    else if (txtDate.Enabled == true)
                    { txtDate.Focus(); }
                    else if (txtBatchno.Enabled == true)
                    { txtBatchno.Focus(); }
                    else
                    { btnAdd.Focus(); }
                }
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

        private void Txtdiscount_Leave(object sender, EventArgs e)
        {
            try
            {
                Txtdiscount.BackColor = Color.White;
                decimal varDiscountAmt = 0, varDisPer = 0;
                if (Txtdiscount.Text.Trim() != "")
                { varDisPer = Convert.ToDecimal(Txtdiscount.Text); }
                if (txtDiscountamt.Text.Trim() != "")
                { varDiscountAmt = Convert.ToDecimal(txtDiscountamt.Text); }
                Txtdiscount.Text = varDisPer.ToString("0.00");
                txtDiscountamt.Text = varDiscountAmount.ToString("0.00");
                if (txtDiscountamt.Text.Trim() != "" && Convert.ToDecimal(Txtdiscount.Text) > 100)
                {
                    errPurchaseentry.SetError(Txtdiscount, "Discount percentage should not be >100");
                    Txtdiscount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                }
                else
                {
                    errPurchaseentry.Clear();
                    Txtdiscount.BackColor = Color.White;
                }
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtdiscount_Enter(object sender, EventArgs e)
        {
            try
            {
                Txtdiscount.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtdiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDiscountamt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtdiscount_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbQtyType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtMismatchQty.Enabled == true)
                    { txtMismatchQty.Focus(); }
                    else
                    {
                        if (txtMrp.Enabled == true)
                        { txtMrp.Focus(); }
                        else if (txtMismatchQty.Enabled == true)
                        { txtMismatchQty.Focus(); }
                        else if (txtMrp.Enabled == true)
                        { txtMrp.Focus(); }
                        else if (txtDate.Enabled == true)
                        { txtDate.Focus(); }
                        else if (txtMonth.Enabled == true)
                        { txtMonth.Focus(); }
                        else if (txtYear.Enabled == true)
                        { txtYear.Focus(); }
                        else if (txtBatchno.Enabled == true)
                        { txtBatchno.Focus(); }
                        else if (txtSourceLocation.Enabled == true)
                        { txtSourceLocation.Focus(); }
                        else if (cmbrack.Enabled == true)
                        { cmbrack.Focus(); }
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

        private void TxtInvoiceQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMismatchQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGRN_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPODetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmpo":
                            string cellGRNValue = Convert.ToString(grdGRN.Rows[e.RowIndex].Cells["clmGRNID"].Value);
                            MainForm.objPUR_GRNProducts = new PUR_GRNProducts();
                            MainForm.objPUR_GRNProducts.pbGRNid = cellGRNValue;
                            MainForm.objPUR_GRNProducts.pbSupplierCode = lblSupplierCode.Text;
                            MainForm.objPUR_GRNProducts.pbScheduleCode = lblschedule.Text;
                            MainForm.objPUR_GRNProducts.ShowDialog();
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
        private void TxtInvoiceQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMismatchQty.Text.Trim() == "")
                {
                    errPurchaseentry.SetError(txtMismatchQty, "Please enter quentity");
                    txtMismatchQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoiceQty.ShowAlways = true;
                    tpInvoiceQty.Show("Please enter quentity", txtMismatchQty, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtMismatchQty.Text).Trim(), varDecimal);
                    if (txtMismatchQty.Text.Trim() == "0" || txtMismatchQty.Text.Trim() == "00" || txtMismatchQty.Text.Trim() == "000")
                    {
                        txtMismatchQty.Text = "0" + Qty;
                    }
                    else
                    {
                        txtMismatchQty.Text = Qty;
                    }
                    errPurchaseentry.Clear();
                    txtMismatchQty.BackColor = Color.White;
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
                    { cmbReason.Focus(); }
                    else if (txtMrp.Enabled == true)
                    { txtMrp.Focus(); }
                    else if (txtDate.Enabled == true)
                    { txtDate.Focus(); }
                    else if (txtBatchno.Enabled == true)
                    { txtBatchno.Focus(); }
                    else if (txtSourceLocation.Enabled == true)
                    { txtSourceLocation.Focus(); }
                    else if (cmbrack.Enabled == true)
                    { cmbrack.Focus(); }
                    else { btnAdd.Focus(); }
                }
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
                string varProCondition = "0"; 
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
                }
                if (varPrMRPFlag == "1")
                {
                    txtMrp.ReadOnly = false;
                    txtMrp.Enabled = true;
                }
                else
                {
                    txtMrp.ReadOnly = true;
                    txtMrp.Enabled = false;
                }
                if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                {
                    txtBatchno.Text = "";
                    txtBatchno.Enabled = false; 
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
                        objMR_Master.paraDate = dpVoucherDate.Text;
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
                                txtDate.ReadOnly = true;
                                txtMonth.ReadOnly = true;
                                txtYear.ReadOnly = true;
                                txtDate.Enabled = false;
                                txtMonth.Enabled = false;
                                txtYear.Enabled = false;
                            }
                        }
                    }
                }
                if ( Convert.ToInt32(varBatchNo) == 72)
                {
                    txtBatchno.Enabled = true;  txtBatchno.ReadOnly = false;
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDiscountamt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOtherdiscount.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDiscountamt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDiscountamt.BackColor = Color.White;
                decimal varDiscountAmt = 0, varDisPer = 0;
                if (Txtdiscount.Text.Trim() != "")
                { varDisPer = Convert.ToDecimal(Txtdiscount.Text); }
                if (txtDiscountamt.Text.Trim() != "")
                { varDiscountAmt = Convert.ToDecimal(txtDiscountamt.Text); }
                Txtdiscount.Text = varDiscountPer.ToString("0.00");
                txtDiscountamt.Text = varDiscountAmt.ToString("0.00");
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDiscountamt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDiscountamt.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDiscountamt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtTcsamt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTcsamt.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtTcsamt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Txtdiscount.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnVerified_Enter(object sender, EventArgs e)
        {
            try
            {
                btnVerified.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnVerified_Leave(object sender, EventArgs e)
        {
            try
            {
                btnVerified.BackColor = Color.Transparent;
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
                MainForm.objPUR_Purchase_Level_Verified = new PUR_Purchase_Level_Verified();
                MainForm.objPUR_Purchase_Level_Verified.pbPurID = Convert.ToString(pbPurchaseno);
                MainForm.objPUR_Purchase_Level_Verified.varVoucherDate = Convert.ToString(dpVoucherDate.Text); 
                MainForm.objPUR_Purchase_Level_Verified.ShowDialog();
                btnSave.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtTcsamt_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtTcsamt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTcsamt.BackColor = Color.White;
                if (txtTcsamt.Text.Trim() != "")
                {
                    string Tcsamt = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtTcsamt.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtTcsamt.Text = Tcsamt;
                    udfnLoadingGrandTotCalculation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDamagecost_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (grpGRNVerifyDetails.Enabled == true)
                    {
                        txtUnLoadingchargeGrn.Focus();
                    }
                    else { txtRemarks.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDamagecost_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtDamagecost_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDamagecost.BackColor = Color.White;
                if (txtDamagecost.Text.Trim() != "")
                {
                    string DamageCost = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtDamagecost.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtDamagecost.Text = DamageCost;
                    udfnLoadingGrandTotCalculation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDamagecost_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDamagecost.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtOtherdiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDamagecost.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtOtherdiscount_KeyPress(object sender, KeyPressEventArgs e)
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
        private void BtnUnapprove_Enter(object sender, EventArgs e)
        {
            try
            {
                btnUnapprove.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUnapprove_Leave(object sender, EventArgs e)
        {
            try
            {
                btnUnapprove.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdTaxDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (grdTaxDetails.Rows.Count != 0)
                {
                    grdTaxDetails.Rows[grdTaxDetails.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                    grdTaxDetails.Rows[grdTaxDetails.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
                    grdTaxDetails.Rows[grdTaxDetails.Rows.Count - 1].DefaultCellStyle.Font = new Font("Oswald Regular", 9, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUnapprove_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    MainForm.objPUR_PurchaseEntryApprovedList.udfnUnapprove(Convert.ToInt32(pbPurchaseno));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUnapprove_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PurchaseEntryApprovedList.pbRemarks = txtRemarks.Text;
                MainForm.objPUR_PurchaseEntryApprovedList.udfnUnapprove(Convert.ToInt32(pbPurchaseno));
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtOtherdiscount_Leave(object sender, EventArgs e)
        {
            try
            {
                txtOtherdiscount.BackColor = Color.White;
                if (txtOtherdiscount.Text.Trim() != "")
                {
                    string OtherDiscount = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtOtherdiscount.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtOtherdiscount.Text = OtherDiscount;
                    udfnLoadingGrandTotCalculation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtOtherdiscount_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOtherdiscount.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdSupplierList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.F10)
                //{
                //    if (Convert.ToString(grdSupplierList.CurrentRow.Cells["clmid"].Value) != "220" && Convert.ToString(grdSupplierList.CurrentRow.Cells["clmInvFlag"].Value) != "1")
                //    {
                //        if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProTname" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmPicode")
                //        {
                //            varEditPRID = Convert.ToString(grdSupplierList.CurrentRow.Cells["clmProid"].Value);
                //            varAutocompleteProduct = 2;
                //            udfnProDataChange();
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtFrightGrn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnRemarks.Focus();
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
                txtProductName.Text = "";
                lblProductcode.Text = "0";
                udfnrowclear(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void TxtRemarks_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRemarks.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemarks_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRemarks.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnRemarks_Enter(object sender, EventArgs e)
        {
            try
            {
                btnRemarks.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnRemarks_Leave(object sender, EventArgs e)
        {
            try
            {
                btnRemarks.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnDC_Enter(object sender, EventArgs e)
        {
            try
            {
                btnDC.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnDC_Leave(object sender, EventArgs e)
        {
            try
            {
                btnDC.BackColor = Color.White;
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
                chkCompleted.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLoadingchargeGrn_Leave(object sender, EventArgs e)
        {
            try
            {
                txtUnLoadingchargeGrn.BackColor = Color.White;
                if (txtUnLoadingchargeGrn.Text.Trim() != "")
                {
                    string loadingGRnCharge = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtUnLoadingchargeGrn.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtUnLoadingchargeGrn.Text = loadingGRnCharge;
                    udfnLoadingGrandTotCalculation();
                }
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
                if (tsbRemainingProduct.Text != "0")
                {
                    string PRID = "0";
                    int GRNID = 0, varPRFlag = 0; string POID = "0", DCID = "0";
                    var strings1 = varProductsIDs.Select(xx => xx);
                    PRID = (string.Join(",", strings1));
                    if (PRID == "")
                    {
                        PRID = "0";
                    }
                    MainForm.objPUR_RemainingProductList = new PUR_RemainingProductList();
                    MainForm.objPUR_RemainingProductList.PbvarGRNID = pbGRNNo;
                    if (Convert.ToInt32(cmbEntryType.SelectedValue) == 55)  //Against Po
                    {
                        varPRFlag = 0;
                        POID = Convert.ToString(pbPONO);
                    }
                    else if (Convert.ToInt32(cmbEntryType.SelectedValue) == 54)  //Against GRN
                    {
                        varPRFlag = 1;
                        GRNID = Convert.ToInt16(pbGRNNo);
                    }
                    else if (Convert.ToInt32(cmbEntryType.SelectedValue) == 57)  //Against DC
                    {
                        DCID = Convert.ToString(pbDCNo);
                        varPRFlag = 2;
                    }
                    MainForm.objPUR_RemainingProductList.varFlag = varPRFlag;
                    MainForm.objPUR_RemainingProductList.pbGRNid = GRNID;
                    MainForm.objPUR_RemainingProductList.pbDCid = DCID;
                    MainForm.objPUR_RemainingProductList.pbPOid = POID;
                    MainForm.objPUR_RemainingProductList.varProducts = PRID;
                    MainForm.objPUR_RemainingProductList.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLoadingchargeGrn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtFrightGrn.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void TxtLoadingchargeGrn_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtLoadingchargeGrn_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUnLoadingchargeGrn.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtFrightGrn_Enter(object sender, EventArgs e)
        {
            try
            {
                txtFrightGrn.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtFrightGrn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemarks.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDiscountColumnHide()
        {
            try
            {
                if (rbDiscountAfter.Checked == true)
                {
                    grdPurchaseList.Columns["clmDiscountValue"].Visible = true;
                    grdPurchaseList.Columns["clmTax"].DisplayIndex = 19;
                    grdPurchaseList.Columns["clmGstper"].DisplayIndex = 20;
                    grdPurchaseList.Columns["clmGstamt"].DisplayIndex = 21;
                    grdPurchaseList.Columns["clmDiscAmt"].DisplayIndex = 22;
                    grdPurchaseList.Columns["clmDiscPer"].DisplayIndex = 23;
                    grdPurchaseList.Columns["clmDiscountValue"].DisplayIndex = 24;
                }
                if (rbDiscountBefore.Checked == true)
                {
                    grdPurchaseList.Columns["clmDiscountValue"].Visible = false;
                    grdPurchaseList.Columns["clmDiscAmt"].DisplayIndex = 19;
                    grdPurchaseList.Columns["clmDiscPer"].DisplayIndex = 20;
                    grdPurchaseList.Columns["clmTax"].DisplayIndex = 21;
                    grdPurchaseList.Columns["clmGstper"].DisplayIndex = 22;
                    grdPurchaseList.Columns["clmGstamt"].DisplayIndex = 23;
                    grdPurchaseList.Columns["clmDiscountValue"].DisplayIndex = 24;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbDiscountBefore_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                udfnDiscountColumnHide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdPurchaseList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (PbSTS == "50" || pbPurchaseEntryUnapprovedFlag == 1 || varPurEditFlag == 1)
                {
                    grdPurchaseList.Columns["clmInvQty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdPurchaseList.Columns["clmRecqty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdPurchaseList.Columns["clmFreeqty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdPurchaseList.Columns["clmPurchaseRate"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdPurchaseList.Columns["clmDiscAmt"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdPurchaseList.Columns["clmDiscPer"].DefaultCellStyle.BackColor = Color.LightGray; 
                    grdPurchaseList.Columns["clmInvQty"].ReadOnly = true;
                    grdPurchaseList.Columns["clmRecqty"].ReadOnly = true;
                    grdPurchaseList.Columns["clmFreeqty"].ReadOnly = true;
                    grdPurchaseList.Columns["clmPurchaseRate"].ReadOnly = true;
                    grdPurchaseList.Columns["clmDiscAmt"].ReadOnly = true;
                    grdPurchaseList.Columns["clmDiscPer"].ReadOnly = true;
                }
                if (varConvertFlag == 1)
                {
                    for (int i = 0; i < grdPurchaseList.Rows.Count; i++)
                    {
                        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmConvertedProID"].Value) != "0")
                        {
                            grdPurchaseList.Rows[i].Cells["clmInvQty"].ReadOnly = true;
                            grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.LightGray;
                            grdPurchaseList.Rows[i].Cells["clmRecqty"].ReadOnly = false;
                            grdPurchaseList.Rows[i].Cells["clmFreeqty"].ReadOnly = false;
                            grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].ReadOnly = false;
                            grdPurchaseList.Rows[i].Cells["clmDiscAmt"].ReadOnly = false;
                            grdPurchaseList.Rows[i].Cells["clmDiscPer"].ReadOnly = false;
                        }
                        else
                        {
                            grdPurchaseList.Rows[i].Cells["clmInvQty"].ReadOnly = true;
                            grdPurchaseList.Rows[i].Cells["clmRecqty"].ReadOnly = true;
                            grdPurchaseList.Rows[i].Cells["clmFreeqty"].ReadOnly = true;
                            grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].ReadOnly = true;
                            grdPurchaseList.Rows[i].Cells["clmDiscAmt"].ReadOnly = true;
                            grdPurchaseList.Rows[i].Cells["clmDiscPer"].ReadOnly = true;
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
        private void RbDiscountAfter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                udfnDiscountColumnHide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQRCode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtQRCode.BackColor = Color.LemonChiffon;
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
        private void GrdPurchaseList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.ColumnIndex == grdPurchaseList.Columns["clmDiscAmt"].Index && e.RowIndex >= 0)
                {
                    decimal varInvQty = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmInvQty"].Value)) != "") { varInvQty = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmInvQty"].Value); }
                    decimal varPurchaseRate = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value)) != "")
                    {
                        varPurchaseRate = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value);
                    }
                    decimal varDiscAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value)) != "") { varDiscAmt = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value); }
                    if ((varPurchaseRate * varInvQty) < varDiscAmt)
                    {
                        grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Style.BackColor = Color.LightPink;
                        grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Style.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLoadingCharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtUnLoadingCharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCouriercharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtotherexpense_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtTcsamt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDamagecost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnLoadingGrandTotCalculation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtOtherdiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnLoadingGrandTotCalculation();
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
                            string cellDCValue = Convert.ToString(grdReurnDC.Rows[e.RowIndex].Cells["ID"].Value);
                            MainForm.objPUR_DCProducts = new PUR_DCProducts();
                            MainForm.objPUR_DCProducts.pbDCid = cellDCValue;
                            MainForm.objPUR_DCProducts.pbSupplierCode = lblSupplierCode.Text;
                            MainForm.objPUR_DCProducts.pbScheduleCode = lblschedule.Text;
                            MainForm.objPUR_DCProducts.ShowDialog();
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
        private void GrdReurnDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdReurnDC.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemoveDC":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                string varID = "0", varDCID = "0";
                                string[] varDC = pbDCNo.Split(',');
                                varID = Convert.ToString(grdReurnDC.Rows[e.RowIndex].Cells["ID"].Value);
                                grdReurnDC.Rows.RemoveAt(this.grdReurnDC.SelectedCells[0].RowIndex);
                                for (int i = 0; i < varDC.Length; i++)
                                {
                                    if (Convert.ToInt16(varDC[i]) != Convert.ToInt16(varID))
                                    {
                                        if (varDCID == "0")
                                        { varDCID = varDC[i]; }
                                        else
                                        { varDCID = varDCID + ',' + varDC[i]; }
                                    }
                                }
                                pbDCNo = varDCID;
                                if (Convert.ToInt32(pbDCNo) == 0)
                                { grdSupplierList.Rows.Clear(); }
                                udfnProDetailsTolProCount();
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
                if (grdReurnDC.Rows.Count > 0)
                {
                    lblFinishedNoRecord.Visible = false;
                }
                else
                {
                    lblFinishedNoRecord.Visible = true;
                }
            }
        }
        private void DGV_FilterProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListviewProduct();
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
                if (DGV_FilterProduct.RowCount > 0)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null)
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
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (varPrInvFlag == "1" || Convert.ToString(cmbPONo.SelectedValue) == "220")
                        {
                            btnAdd.Focus();
                        }
                        else
                        {
                            if (varPrMRPFlag == "1")
                            {
                                txtMrp.ReadOnly = true;
                                txtMrp.Enabled = false;
                                txtMrp.Focus();
                            }
                            else
                            {
                                txtMrp.ReadOnly = false;
                                txtMrp.Enabled = true;
                                if (varShelflife == 1 && txtMonth.Enabled == true && txtMonth.ReadOnly == false)
                                {
                                    txtDate.Focus();
                                }
                                else
                                {
                                    if (txtBatchno.Enabled == true)
                                    { txtBatchno.Focus(); }
                                    else if (txtSourceLocation.Enabled == true)
                                    { txtSourceLocation.Focus(); }
                                    else if (cmbrack.Enabled == true)
                                    { cmbrack.Focus(); }
                                    else { btnAdd.Focus(); }
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
            finally
            {
                if (Convert.ToString(cmbEntryType.SelectedValue) == "57")
                {  btnConditions.Enabled = false; }
            }
        }
        private void GrdPODetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPODetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemovePO":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                string varID = "0", varPOID = "0";
                                string[] varPO = pbPONO.Split(',');
                                varID = Convert.ToString(grdPODetails.Rows[e.RowIndex].Cells["clmSelectedpoid"].Value);
                                grdPODetails.Rows.RemoveAt(this.grdPODetails.SelectedCells[0].RowIndex);

                                for (int i = 0; i < varPO.Length; i++)
                                {
                                    if (Convert.ToInt16(varPO[i]) != Convert.ToInt16(varID))
                                    {
                                        if (varPOID == "0")
                                        { varPOID = varPO[i]; }
                                        else
                                        { varPOID = varPOID + ',' + varPO[i]; }
                                    }
                                }
                                pbPONO = varPOID;
                                if (Convert.ToInt32(pbPONO) == 0)
                                {
                                    grdSupplierList.Rows.Clear();
                                }
                                udfnProDetailsTolProCount();
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
                if (grdPODetails.Rows.Count > 0)
                {
                    lblFinishedNoRecord.Visible = false;
                }
                else
                {
                    lblFinishedNoRecord.Visible = true;
                }
            }
        }
        private void Txtdiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal GrandTot = 0, vardisamt = 0, varDisper = 0, varDisPercent = 0;
                if (txtDiscountamt.Text.Trim() != "") { vardisamt = Convert.ToDecimal(txtDiscountamt.Text.Trim()); };
                if (Txtdiscount.Text.Trim() != "") { varDisper = Convert.ToDecimal(Txtdiscount.Text.Trim()); };
                if (lblTotal.Text.Trim() != "") { GrandTot = Convert.ToDecimal(lblTotal.Text.Trim()); }
                if (varDisper != 0)
                {
                    varDisPercent = (GrandTot * varDisper) / 100;
                }
                varDiscountAmount = varDisPercent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDiscountamt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal GrandTot = 0, vardisamt = 0, varDisper = 0, varDisPercent = 0;
                if (txtDiscountamt.Text.Trim() != "") { vardisamt = Convert.ToDecimal(txtDiscountamt.Text.Trim()); };
                if (Txtdiscount.Text.Trim() != "") { varDisper = Convert.ToDecimal(Txtdiscount.Text.Trim()); };
                if (lblGrandTotal.Text.Trim() != "")
                {
                    GrandTot = Convert.ToDecimal(lblGrandTotal.Text.Trim());
                }
                if (vardisamt != 0)
                {
                    varDisPercent = (vardisamt * 100) / GrandTot;
                }
                varDiscountPer = Convert.ToDecimal(varDisPercent);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQRCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGetGRNID();
                }
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
                    BtnSave_Click(sender, e);
                }
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
                if (e.KeyCode == Keys.Enter)
                {
                    BtnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGetGRNID()
        {
            try
            {
                if (Convert.ToInt16(cmbEntryType.SelectedValue) == 54)
                {
                    string varQRCode = "";
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnGrnListLoad(7, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, "", "", 0, 0, 0, "", "", 0, 0, "", txtQRCode.Text.Trim(), "", 0, 0, 0, 0);
                    objdserv.CloseConnection();
                    varGrnId = Convert.ToInt32(objDs.Tables[0].Rows[0]["GRNID"]);
                    if (varGrnId == -1)
                    {
                        string varMessage = objdserv.udfnGetMessages(108);
                        objdserv.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    varQRCode = txtQRCode.Text.Trim();
                    errPurchaseentry.Clear();
                    txtQRCode.BackColor = Color.White;
                    tpQRCode.Hide(txtQRCode);
                    if (varGrnId == -1)
                    {
                        txtQRCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtQRCode.Text = varQRCode;
                    }
                    if (pbPurchaseno == "0")
                    {
                        if (varGrnId != -1 && varGrnId != 0 && varQueueFlag != 1)
                        {
                            PUR_Purchase_GRNDetails objPUR_Purchase_GRNDetails = new PUR_Purchase_GRNDetails();
                            objPUR_Purchase_GRNDetails.QRFlag = 1;
                            pbGRNNo = Convert.ToString(varGrnId);
                            udfnGRNProload();
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
        private void TxtQRCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string varQRCode = "";
                if (Convert.ToString(txtQRCode.Text).Trim() != "" && txtQRCode.Text.Length < 6)
                {
                    errPurchaseentry.SetError(txtQRCode, "Please enter valid GRN scan code");
                    txtQRCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQRCode.ShowAlways = true;
                    tpQRCode.Show("Please enter valid GRN scan code", txtQRCode, 5000);
                }
                else
                {
                    udfnGetGRNID();
                }
                if (Convert.ToString(txtQRCode.Text).Trim() == "")
                {
                    errPurchaseentry.Clear();
                    txtQRCode.BackColor = Color.White;
                    tpQRCode.Hide(txtQRCode);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQRCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
        private void TxtFrightGrn_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtFrightGrn_Leave(object sender, EventArgs e)
        {
            try
            {
                txtFrightGrn.BackColor = Color.White;
                if (txtFrightGrn.Text.Trim() != "")
                {
                    string FrightGrn = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtFrightGrn.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
                    txtFrightGrn.Text = FrightGrn;
                    udfnLoadingGrandTotCalculation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpVoucherDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                varDateChange = 1;
                varVoucherDate = Convert.ToString(dpVoucherDate.Text);
                udfnVocherno();
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
                if (e.RowIndex != -1)
                {
                    switch (grdSupplierList.Columns[e.ColumnIndex].Name)
                    {           
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                string mrp1 = "0", varmrp = "0";
                                decimal MRP = 0;
                                DataGridViewRow row = grdSupplierList.Rows[e.RowIndex];
                                string varPurid = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmPURPRIDDetail"].Value);
                                string varSno = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmsno"].Value);
                                varmrp = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmProductMrp"].Value);
                                if (varmrp != "") { mrp1 = string.Format("{0:G29}", decimal.Parse(varmrp)); }
                                string varExpirydate = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmexpirydate"].Value);
                                string varRkid = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["rkid"].Value);
                                string varSlid = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["slid"].Value);
                                string varBatchNo = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmBatchno"].Value);
                                string varPrid = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmProid"].Value);
                                if (pbPurchaseno != "0")
                                {
                                    if (grdPurchaseList.RowCount != 0)
                                    {
                                        for (int i = 0; i < grdPurchaseList.RowCount; i++)
                                        {
                                            if (varPurid == Convert.ToString(grdPurchaseList.Rows[i].Cells["clmPURPRID"].Value))
                                            {
                                                grdPurchaseList.Rows.RemoveAt(i);
                                            }
                                        }
                                    }
                                }
                                if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmConvertProductFlag"].Value) == "0")
                                { 
                                    if (varmrp != "") { MRP = Convert.ToDecimal(varmrp); }
                                    if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmid"].Value) == "218") //GRN
                                    {
                                        var varRemoveProuct =
                                        from r in dtPurchaseAutoComplete.AsEnumerable()
                                        where (r.Field<string>("PRID").Equals(varPrid) &&
                                             r.Field<string>("ExpiryDate").Equals(varExpirydate) &&
                                             r.Field<string>("BatchNo").Equals(varBatchNo) &&
                                             r.Field<decimal>("MRP").Equals(MRP))
                                        group r by r.Field<string>("PRID") into g
                                        select g.Key;
                                        if (varRemoveProuct.Count() != 0)
                                        {
                                            tsbRemainingProduct.Text = Convert.ToString((Convert.ToInt16(tsbRemainingProduct.Text) + 1));
                                            tsbAddedProduct.Text = Convert.ToString(Convert.ToInt16(tsbTotalProducts.Text) - 1);
                                        }
                                        for (int i = 0; i < varProductsIDs.Count; i++)
                                        {
                                            if (varProductsIDs[i].Equals(Convert.ToInt16(varPrid)))
                                            { varProductsIDs.RemoveAt(i); goto L; }
                                        }
                                    L:
                                        for (int i = 0; i < dtPurchaseAutoComplete.Rows.Count; i++)
                                        {
                                            if (Convert.ToString(dtPurchaseAutoComplete.Rows[i]["Sno"]) == Convert.ToString(varSno))
                                            {
                                                dtPurchaseAutoComplete.Rows[i].Delete();
                                                dtPurchaseAutoComplete.AcceptChanges();
                                            }
                                        }
                                    }
                                    if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmid"].Value) == "220") //DC
                                    {
                                        var varRemoveProuct =
                                        from r in dtProductDetails.AsEnumerable()
                                        where (r.Field<string>("PRID").Equals(varPrid) &&
                                             r.Field<string>("ExpiryDate").Equals(varExpirydate) &&
                                             r.Field<string>("BatchNo").Equals(varBatchNo) &&
                                             r.Field<string>("SLID").Equals(varSlid) &&
                                             r.Field<string>("RKID").Equals(varRkid) &&
                                             r.Field<string>("MRP").Equals(mrp1))
                                        group r by r.Field<string>("PRID") into g
                                        select g.Key;
                                        if (varRemoveProuct.Count() != 0)
                                        {
                                            tsbRemainingProduct.Text = Convert.ToString((Convert.ToInt16(tsbRemainingProduct.Text) + 1));
                                            tsbAddedProduct.Text = Convert.ToString(Convert.ToInt16(tsbAddedProduct.Text) - Convert.ToInt16(tsbRemainingProduct.Text));
                                        }
                                        for (int i = 0; i < varProductsIDs.Count; i++)
                                        {
                                            if (varProductsIDs[i].Equals(Convert.ToInt16(varPrid)))
                                            { varProductsIDs.RemoveAt(i); goto L; }
                                        }
                                    L:
                                        for (int i = 0; i < dtPurchaseAutoComplete.Rows.Count; i++)
                                        {
                                            if (Convert.ToString(dtPurchaseAutoComplete.Rows[i]["Sno"]) == Convert.ToString(varSno))
                                            {
                                                dtPurchaseAutoComplete.Rows[i].Delete();
                                                dtPurchaseAutoComplete.AcceptChanges();
                                            }
                                        }
                                    }
                                    if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmid"].Value) == "215") //po
                                    {
                                        int varProductType = Convert.ToInt16(grdSupplierList.Rows[e.RowIndex].Cells["clmid"].Value);

                                        var varRemoveProuct = from r in dtPurchaseAutoComplete.AsEnumerable()
                                                              where (r.Field<string>("PRID").Equals(varPrid) && r.Field<int>("Flag").Equals(varProductType))
                                                              group r by r.Field<int>("Sno") into g
                                                              select g.Key;
                                        if (varRemoveProuct.Count() == 1)
                                        {
                                            tsbRemainingProduct.Text = Convert.ToString((Convert.ToInt16(tsbRemainingProduct.Text) + 1));
                                            tsbAddedProduct.Text = Convert.ToString(Convert.ToInt16(tsbTotalProducts.Text) - Convert.ToInt16(tsbRemainingProduct.Text));
                                        }
                                        for (int i = 0; i < varProductsIDs.Count; i++)
                                        {
                                            if (varProductsIDs[i].Equals(Convert.ToInt16(varPrid)))
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
                                    }
                                    grdSupplierList.Rows.Remove(row);
                                    //reset the calculation
                                    if (grdPurchaseList.RowCount != 0)
                                    {
                                        for (int i = 0; i < grdPurchaseList.RowCount; i++)
                                        {
                                            PbGstamt = 0; PbNetamt = 0; pbDiffQty = 0; PbDiscamt = 0; PbTaxvalue = 0; pbDisper = 0; pbCostingRate = 0; PbSGstamt = 0; PbCGstamt = 0; PbIGstamt = 0;
                                            decimal varInvQty = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmInvQty"].Value)) != "") { varInvQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value); }
                                            decimal varRecQty = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmRecqty"].Value)) != "") { varRecQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmRecqty"].Value); }
                                            decimal varDiffQty = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmDiffqty"].Value)) != "") { varDiffQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiffqty"].Value); }
                                            decimal varFreeQty = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmFreeqty"].Value)) != "") { varFreeQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmFreeqty"].Value); }
                                            decimal varPurchaseRate = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value)) != "")
                                            {
                                                string mrp = string.Format("{0:0.000}", Math.Round(Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value), 6, MidpointRounding.AwayFromZero));
                                                grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value = mrp;
                                                varPurchaseRate = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value);
                                            }
                                            decimal varCellDiscAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Value)) != "") { varCellDiscAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Value); }
                                            decimal varTaxValue = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmTax"].Value)) != "") { varTaxValue = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmTax"].Value); }
                                            decimal varGstAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmGstamt"].Value)) != "") { varGstAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmGstamt"].Value); }
                                            decimal varNetAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmnetamt"].Value)) != "") { varNetAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmnetamt"].Value); }
                                            decimal varDiscPer = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmDiscPer"].Value)) != "") { varDiscPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscPer"].Value); }
                                            int varHSNGSTValue = 0; if (Convert.ToString((grdPurchaseList.Rows[i].Cells["GstValue"].Value)) != "") { varHSNGSTValue = Convert.ToInt32(grdPurchaseList.Rows[i].Cells["GstValue"].Value); }
                                            udfnValuesCalcultaion(varInvQty, varRecQty, varDiffQty, varPurchaseRate, varCellDiscAmt, varTaxValue, varGstAmt, varNetAmt, varDiscPer, varHSNGSTValue, varFreeQty);
                                            udfnSubtotCalc();
                                            udfnGstvalue();
                                            udfnLoadingGrandTotCalculation();
                                            grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value = PbDiscamt.ToString("0.00");
                                            grdPurchaseList.Rows[e.RowIndex].Cells["clmCosting"].Value = pbCostingRate.ToString("0.00");
                                            grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value = PbGstamt.ToString("0.00");
                                            grdPurchaseList.Rows[e.RowIndex].Cells["clmSGstamt"].Value = PbSGstamt.ToString("0.00");
                                            grdPurchaseList.Rows[e.RowIndex].Cells["clmCGstamt"].Value = PbCGstamt.ToString("0.00");
                                            grdPurchaseList.Rows[e.RowIndex].Cells["clmIGstamt"].Value = PbIGstamt.ToString("0.00");
                                            grdPurchaseList.Rows[e.RowIndex].Cells["clmnetamt"].Value = PbNetamt.ToString("0.00");
                                            grdPurchaseList.Rows[e.RowIndex].Cells["clmTax"].Value = PbTaxvalue.ToString("0.00");
                                            grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscountValue"].Value = PbDicountValue.ToString("0.00");
                                        }
                                    }
                                    udfnPoDropdownDisable();
                                }
                                else
                                {
                                    grdSupplierList.Rows.Remove(row);
                                }
                            }
                            break;
                        case "clmConvert":
                            try
                            {
                                DataGridView dgv = sender as DataGridView;
                                string varPICode = "", varProMRP = "", varInvoiceMRP = "", varInvoiceBatchNo = "",
                                    varInvoiceExpiryDate = "", varProdutShelfLife = "", varActualShelffLife = "", varShelfLifePer = "", varProductExpiryDate="";
                                if (e.ColumnIndex != 0)
                                {
                                    grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, null, "None",
                                    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                    "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, "0", 0, "0", 0, 0, 0, 0, 0, 0, "");
                                    string varProductType = "0";
                                    if (Convert.ToString(cmbEntryType.SelectedValue) == "56")
                                    { varProductType = "0"; }
                                    else if (Convert.ToString(cmbEntryType.SelectedValue) == "55")
                                    { varProductType = "214"; }
                                    else if (Convert.ToString(cmbEntryType.SelectedValue) == "57")
                                    { varProductType = "219"; }
                                    else if (Convert.ToString(cmbEntryType.SelectedValue) == "54")
                                    { varProductType = "217"; }
                                    varPICode = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmPicode"].Value);
                                    varProMRP = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmProductMrp"].Value);
                                    varInvoiceMRP = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmMRP"].Value);
                                    varInvoiceBatchNo = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmBatchno"].Value);
                                    varInvoiceExpiryDate = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmexpirydate"].Value);
                                    varProductExpiryDate = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmProductExpiryDate"].Value);

                                    varProdutShelfLife = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmShelflife"].Value);
                                    varActualShelffLife = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmactuallife"].Value);
                                    varShelfLifePer = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmshelfper"].Value);

                                    string varInwardDate = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                                     
                                    grdSupplierList.ReadOnly = false;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].ReadOnly = false;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmConditionID"].Value = "275"; // nodifference 
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmMismatchQty"].Value = "0";
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmCondition"].Value = "ND";
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmReason"].Value = "None";
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmReasonID"].Value = "286";
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmid"].Value = varProductType;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmPicode"].Value = varPICode;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmConvertProduct"].Value = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmPURPRIDDetail"].Value);
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmProductMrp"].Value = varProMRP;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmMRP"].Value = varInvoiceMRP;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmInwardDate"].Value = varInwardDate;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmBatchno"].Value = varInvoiceBatchNo;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmexpirydate"].Value = varInvoiceExpiryDate;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmProductExpiryDate"].Value = varProductExpiryDate;

                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmShelflife"].Value = varProdutShelfLife;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmactuallife"].Value = varActualShelffLife;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmshelfper"].Value = varShelfLifePer;

                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmConvertProductFlag"].Value = "1";
                                    /*For converted product condition type is open to change when the item has only one condition allowed to map 
                                     * But now item has allowed to map multiple condition so condition column changed to read only*/
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmCondition"].ReadOnly = true;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmReason"].ReadOnly = true;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmMismatchQty"].ReadOnly = true;
                                    grdSupplierList.Columns["clmRemove"].Visible = true;
                                    int rowcount = Convert.ToInt32(grdSupplierList.RowCount - 1);
                                    for (int i = 0; i < rowcount; i++)
                                    {
                                        if (i==rowcount)
                                        {
                                            grdSupplierList.Rows[i].ReadOnly = false;
                                        }
                                        else
                                        {
                                            grdSupplierList.Rows[i].ReadOnly = true;
                                        }
                                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmConvertProductFlag"].Value) == "0")
                                        {
                                            ((DataGridViewImageCell)grdSupplierList.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
                                        }
                                    }
                                     ((DataGridViewImageCell)grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmConvert"]).Value = new System.Drawing.Bitmap(1, 1); 
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmInwardDate"].ReadOnly = false;
                                    grdSupplierList.CurrentCell = grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmPicode"];
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmInwardDate"].Style.BackColor = Color.PaleGreen;
                                    grdSupplierList.Rows[grdSupplierList.Rows.Count - 1].Cells["clmMismatchQty"].Style.BackColor = Color.LightGray;
                                    udfnConvertProductDetails(sender, e);   
                                }
                            }
                            catch (Exception ex)
                            {
                                objError = new DataError();
                                objError.WriteFile(ex);
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
        private void ChkCompleted_Leave(object sender, EventArgs e)
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
        private void GrdPurchaseList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varDiscountFlag = 0;  
                if (pbPurchaseno != "0")
                {
                    varEntryType = Convert.ToInt32(cmbEntryType.SelectedValue);
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cellHSNname = dataGridView.Rows[e.RowIndex].Cells["clmHSN"];
                    DataGridViewCell cellHSNid = dataGridView.Rows[e.RowIndex].Cells["hsnid"];
                    DataGridViewCell CellHSNGSTper = dataGridView.Rows[e.RowIndex].Cells["clmGstper"];
                    DataGridViewCell CellHSNGSTValue = dataGridView.Rows[e.RowIndex].Cells["GstValue"];
                    DataGridViewCell CellInvQty = dataGridView.Rows[e.RowIndex].Cells["clmInvQty"];
                    DataGridViewCell CellPurchaseRate = dataGridView.Rows[e.RowIndex].Cells["clmPurchaseRate"];
                    DataGridViewCell CellDiscPer = dataGridView.Rows[e.RowIndex].Cells["clmDiscPer"];
                    DataGridViewCell CellDiscAmt = dataGridView.Rows[e.RowIndex].Cells["clmDiscAmt"];
                    DataGridViewCell CellFreeQty = dataGridView.Rows[e.RowIndex].Cells["clmFreeqty"];

                    decimal varInvQty = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmInvQty"].Value)) != "") { varInvQty = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmInvQty"].Value); }
                    decimal varRecQty = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmRecqty"].Value)) != "") { varRecQty = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmRecqty"].Value); }
                    decimal varDiffQty = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmDiffqty"].Value)) != "") { varDiffQty = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmDiffqty"].Value); }
                    decimal varFreeQty = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmFreeqty"].Value)) != "") { varFreeQty = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmFreeqty"].Value); }
                    decimal varPurchaseRate = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value)) != "")
                    {
                        string mrp = string.Format("{0:0.000}", Math.Round(Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value), 6, MidpointRounding.AwayFromZero));
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value = mrp;
                        varPurchaseRate = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value);
                    }
                    decimal varCellDiscAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value)) != "") { varCellDiscAmt = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value); }
                    decimal varTaxValue = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmTax"].Value)) != "") { varTaxValue = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmTax"].Value); }
                    decimal varGstAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value)) != "") { varGstAmt = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value); }
                    decimal varNetAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmnetamt"].Value)) != "") { varNetAmt = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmnetamt"].Value); }
                    decimal varDiscPer = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscPer"].Value)) != "") { varDiscPer = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscPer"].Value); }
                    int varHSNGSTValue = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["GstValue"].Value)) != "") { varHSNGSTValue = Convert.ToInt32(grdPurchaseList.Rows[e.RowIndex].Cells["GstValue"].Value); }
                    if (e.ColumnIndex == grdPurchaseList.Columns["clmHSN"].Index && e.RowIndex >= 0)
                    {
                        VarGridError = "0";
                        if (e.ColumnIndex == grdPurchaseList.Columns["clmHSN"].Index && e.RowIndex >= 0)
                        {
                            string SelectedHSNName = grdPurchaseList.Rows[e.RowIndex].Cells["clmHSN"].Value?.ToString();
                            if (!string.IsNullOrEmpty(SelectedHSNName))
                            {
                                /* Check HSN is valid or not*/
                                string varHSNId = "0";
                                DataSet objDsPurLoc = new DataSet();
                                SPDataService objDServ3 = new SPDataService();
                                objDsPurLoc = objDServ3.udfnHsnList(11, 0, 0, 0, SelectedHSNName, "");
                                objDServ3.CloseConnection();
                                if (objDsPurLoc != null)
                                {
                                    if (objDsPurLoc.Tables.Count > 0)
                                    {
                                        if (objDsPurLoc.Tables[0].Rows.Count > 0)
                                        {
                                            varHSNId = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                                            if (varHSNId != "-1")
                                            {
                                                if (objDsPurLoc.Tables[1].Rows.Count > 0)
                                                {
                                                    CellHSNGSTper.Value = Convert.ToString(objDsPurLoc.Tables[1].Rows[0]["GST_Text"]);
                                                    CellHSNGSTValue.Value = Convert.ToString(objDsPurLoc.Tables[1].Rows[0]["GST_Value"]);
                                                    cellHSNid.Value = varHSNId;
                                                    varHSNGSTValue = Convert.ToInt32(objDsPurLoc.Tables[1].Rows[0]["GST_Value"]);
                                                    udfnValuesCalcultaion(varInvQty, varRecQty, varDiffQty, varPurchaseRate, varCellDiscAmt, varTaxValue, varGstAmt, varNetAmt, varDiscPer, varHSNGSTValue, varFreeQty);
                                                    udfnGstvalue();
                                                }
                                            }
                                            else
                                            {
                                                CellHSNGSTper.Value = "-";
                                                CellHSNGSTValue.Value = "0";
                                                cellHSNid.Value = varHSNId;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ((e.ColumnIndex == grdPurchaseList.Columns["clmPurchaseRate"].Index && e.RowIndex >= 0))
                    {
                        CellPurchaseRate.Style.BackColor = Color.PaleGreen;
                    }
                    if ((e.ColumnIndex == grdPurchaseList.Columns["clmDiscAmt"].Index && e.RowIndex >= 0))
                    {
                        CellDiscAmt.Style.BackColor = Color.PaleGreen;
                        udfnDiscountToAmount(varCellDiscAmt, varDiscPer, varInvQty, varPurchaseRate);
                        varDiscPer = pbDisper;
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscPer"].Value = pbDisper.ToString("0.00");
                    }
                    if ((e.ColumnIndex == grdPurchaseList.Columns["clmInvQty"].Index || e.ColumnIndex == grdPurchaseList.Columns["clmRecqty"].Index || e.ColumnIndex == grdPurchaseList.Columns["clmPurchaseRate"].Index) || e.ColumnIndex == grdPurchaseList.Columns["clmFreeqty"].Index && e.RowIndex >= 0)
                    {
                        if (Convert.ToString(grdPurchaseList.Rows[e.RowIndex].Cells["clmConvertedProID"].Value) == "0")
                        { CellInvQty.Style.BackColor = Color.PaleGreen; }
                    }
                    if ((e.ColumnIndex == grdPurchaseList.Columns["clmDiscPer"].Index) && e.RowIndex >= 0)
                    {
                        CellDiscAmt.Style.BackColor = Color.PaleGreen;
                        CellDiscPer.Style.BackColor = Color.PaleGreen;
                        udfnDiscountToAmount(varCellDiscAmt, varDiscPer, varInvQty, varPurchaseRate);
                        varCellDiscAmt = PbDiscamt;
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value = PbDiscamt.ToString("0.00");
                    }
                    if (Convert.ToString(grdPurchaseList.Rows[e.RowIndex].Cells["poid"].Value) == "219") // Product against DC
                    { 
                        if (grdPurchaseList.Columns[e.ColumnIndex].Name == "clmFreeqty")
                        {
                            decimal varDiffQqty = 0;
                            varDiffQqty = Math.Abs(varInvQty - (varRecQty + varFreeQty));
                            grdPurchaseList.Rows[e.RowIndex].Cells["clmDiffqty"].Value = varDiffQqty;
                        } 
                    }
                    udfnValuesCalcultaion(varInvQty, varRecQty, varDiffQty, varPurchaseRate, varCellDiscAmt, varTaxValue, varGstAmt, varNetAmt, varDiscPer, varHSNGSTValue, varFreeQty);
                    udfnSubtotCalc();
                    udfnGstvalue();
                    udfnLoadingGrandTotCalculation();
                    if (pbConcernTin != pbSupplierTin)
                    {
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmIGstamt"].Value = PbIGstamt.ToString("0.00");
                    }
                    else
                    {
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value = PbDiscamt.ToString("0.00");
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmCosting"].Value = pbCostingRate.ToString("0.00");
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value = PbGstamt.ToString("0.00");
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmSGstamt"].Value = PbSGstamt.ToString("0.00");
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmCGstamt"].Value = PbCGstamt.ToString("0.00");
                    }
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmnetamt"].Value = PbNetamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmTax"].Value = PbTaxvalue.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscountValue"].Value = PbDicountValue.ToString("0.00");
                    int varDecimal = Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["UT_Decimal"].Value);

                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmRecqty"
                        || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiffqty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmFreeqty")
                    {
                        string Qty = objValidation.udfnDecimal(Convert.ToString(grdPurchaseList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                        grdPurchaseList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;
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
                varDiscountFlag = 0;
                if (grdPurchaseList.Columns[e.ColumnIndex].Name == "clmHSN" || grdPurchaseList.Columns[e.ColumnIndex].Name == "clmInvQty" || grdPurchaseList.Columns[e.ColumnIndex].Name == "clmRecqty" || grdPurchaseList.Columns[e.ColumnIndex].Name == "clmDiscPer" || grdPurchaseList.Columns[e.ColumnIndex].Name == "clmDiscAmt" || grdPurchaseList.Columns[e.ColumnIndex].Name == "clmPurchaseRate")
                {
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value = PbGstamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmSGstamt"].Value = PbSGstamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmCGstamt"].Value = PbCGstamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmIGstamt"].Value = PbIGstamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmnetamt"].Value = PbNetamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmTax"].Value = PbTaxvalue.ToString("0.00");
                    udfnSubtotCalc();
                    udfnGstvalue();
                    udfnLoadingGrandTotCalculation();
                    PbGstamt = 0; PbNetamt = 0; pbDiffQty = 0; PbDiscamt = 0; PbTaxvalue = 0; pbDisper = 0; pbCostingRate = 0; PbSGstamt = 0; PbCGstamt = 0; PbIGstamt = 0;
                }
            }
        }
        public void udfnDiscountToAmount(decimal varCellDiscAmt, decimal varDiscPer, decimal varInvQty, decimal varPurchaseRate)
        {
            try
            {
                varDiscountFlag = 1;
                if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscAmt")
                {
                    if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Value)) != "")
                    { varCellDiscAmt = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Value); }
                    PbDiscamt = varCellDiscAmt;

                    pbDisper = (varCellDiscAmt * 100) / (varPurchaseRate * varInvQty);
                    varDiscPer = pbDisper;
                    grdPurchaseList.CurrentRow.Cells["clmDiscPer"].Value = pbDisper.ToString("0.00");
                }
                if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer")
                {
                    if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmDiscPer"].Value)) != "")
                    { varDiscPer = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmDiscPer"].Value); }
                    pbDisper = varDiscPer;

                    PbDiscamt = ((varPurchaseRate * varInvQty) * (varDiscPer)) / 100;
                    varCellDiscAmt = PbDiscamt;
                    grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Value = PbDiscamt.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnValuesCalcultaion(decimal varInvQty, decimal varRecQty, decimal varDiffQty, decimal varPurchaseRate, decimal varCellDiscAmt, decimal varTaxValue, decimal varGstAmt, decimal varNetAmt, decimal varDiscPer, int varHSNGSTValue, decimal varFreeQty)
        {
            try
            {
                int varQtyErrFlag = 0;

                if (varEntryType == 55 || varEntryType == 56)    //55-against po      56-Direct
                {
                    pbDiffQty = Math.Abs(varInvQty - (varRecQty + varFreeQty));
                }
                if (varEntryType == 57)   //against purchase dc 
                {
                    if (varDiffQty != 0)
                    { varQtyErrFlag = 1; }
                }
                if (varEntryType == 54)  //against GRN
                {
                    pbDiffQty = Math.Abs(varInvQty - (varRecQty + varFreeQty)); //Excess
                                                                                //varInvQty = varRecQty + varFreeQty + varDiffQty; //pending
                }
                if (varDiscountFlag == 0)
                {
                    //purchase rate , quantity, discount percentage  changed  then discount amount calculated 
                    if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmDiscPer"].Value)) != "")
                    { varDiscPer = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmDiscPer"].Value); }
                    PbDiscamt = ((varPurchaseRate * varInvQty)) * ((varDiscPer) / 100);
                    varCellDiscAmt = PbDiscamt;
                }
                if (rbDiscountBefore.Checked == true)
                {
                    PbTaxvalue = (varPurchaseRate * varInvQty) - varCellDiscAmt;
                    PbGstamt = (PbTaxvalue * varHSNGSTValue) / 100;
                    if (varSupplierType != 32 && varSupplierType != 31) 
                    {
                        PbNetamt = (PbTaxvalue + PbGstamt); //30 -Registered , 151 - IGST 
                    }
                    else
                    {
                        PbNetamt = (PbTaxvalue); //32 -  GSTIN Unregistered supplier 31-Composite
                    }
                }
                if (rbDiscountAfter.Checked == true)
                {
                    PbTaxvalue = (varPurchaseRate * varInvQty);
                    PbGstamt = ((PbTaxvalue * varHSNGSTValue) / 100);
                    if (varSupplierType != 32 && varSupplierType != 31 )  
                    {
                        PbNetamt = (PbTaxvalue + PbGstamt - varCellDiscAmt); //30 -Registered , 151 - IGST 
                    }
                    else
                    {
                        PbNetamt = (PbTaxvalue - varCellDiscAmt); //32 -  GSTIN Unregistered supplier 31-Composite
                    }
                    PbDicountValue = (PbTaxvalue - varCellDiscAmt);
                }
                if (varSupplierType == 151)
                {
                    PbIGstamt = PbGstamt;
                }
                else
                {
                    PbCGstamt = PbGstamt / 2;
                    PbSGstamt = PbGstamt / 2;
                }
                pbCostingRate = PbNetamt / varInvQty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSubtotCalc()
        {
            try
            {
                decimal varSubtotal = 0, varTaxTotal = 0, varInvQty = 0, varAdditionalValue = 0, varDiscount = 0;
                for (int i = 0; i < grdPurchaseList.Rows.Count; i++)
                {
                    decimal varTaxValue = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmTax"].Value);
                    decimal varGstAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmGstamt"].Value);
                    decimal varNetAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmnetamt"].Value);
                    if (rbDiscountBefore.Checked == true)
                    {
                        if (varSupplierType != 32 && varSupplierType != 31)  
                        {
                            varSubtotal = varSubtotal + varTaxValue; //30 -Registered , 151 - IGST 
                            varTaxTotal = varTaxTotal + varGstAmt;
                        }
                        else
                        {
                            varSubtotal = varSubtotal + varNetAmt; //32 -  GSTIN Unregistered supplier 31-Composite
                            varTaxTotal = varTaxTotal + varGstAmt;
                        }
                    }
                    if (rbDiscountAfter.Checked == true)
                    {
                        decimal varDiscountValue = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscountValue"].Value);
                        if (varSupplierType != 32 && varSupplierType != 31) //GSTIN unregistered suppplier
                        {
                            varSubtotal = varSubtotal + varDiscountValue; //30 -Registered , 151 - IGST 
                            varTaxTotal = varTaxTotal + varGstAmt;
                        }
                        else
                        {
                            varSubtotal = varSubtotal + varNetAmt; //32 -  GSTIN Unregistered supplier 31-Composite
                            varTaxTotal = varTaxTotal + varGstAmt;
                        }
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty")
                    {
                        if (varInvQty == 0)
                        {
                            varInvQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value);
                        }
                        else
                        {
                            varInvQty = varInvQty + Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value);
                        }
                    }
                }
                lblSubtotal.Text = Convert.ToString(varSubtotal);
                if (varSupplierType != 32 && varSupplierType != 31)  
                {
                    lblGstamt.Text = varTaxTotal.ToString("0.00"); //30 -Registered , 151 - IGST 
                    lblTotal.Text = (varSubtotal + varTaxTotal).ToString("0.00");
                }
                else
                {
                    varTaxTotal = 0; //32 -  GSTIN Unregistered supplier 31-Composite
                    lblGstamt.Text = varTaxTotal.ToString("0.00");
                    lblTotal.Text = varSubtotal.ToString("0.00");
                }
                varAdditionalValue = Convert.ToDecimal(lblAdditionalValue.Text);
                varDiscount = Convert.ToDecimal(lblDiscount.Text);
                lblGrandTotal.Text = Math.Round(varSubtotal + varTaxTotal + varAdditionalValue - varDiscount).ToString("#,##0.00");
                lblRoundoff.Text = Convert.ToString(Convert.ToDecimal(lblGrandTotal.Text) - (varSubtotal + varTaxTotal + varAdditionalValue - varDiscount));
                if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty")
                {
                    lblTpro.Text = Convert.ToString(grdPurchaseList.RowCount) + " / " + Convert.ToString(varInvQty);
                }
                if (varSubtotal == 0)
                {
                    gpdiscount.Enabled = true;
                }
                else
                {
                    gpdiscount.Enabled = false;
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
                    else { txtSourceLocation.Focus(); }
                }
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
                        case "clmpo":
                            string cellPOValue = Convert.ToString(grdPODetails.Rows[e.RowIndex].Cells["clmSelectedpoid"].Value);
                            MainForm.objPUR_POProducts = new PUR_POProducts();
                            MainForm.objPUR_POProducts.pbPoid = cellPOValue;
                            MainForm.objPUR_POProducts.pbSupplierCode = lblSupplierCode.Text;
                            MainForm.objPUR_POProducts.pbScheduleCode = lblschedule.Text;
                            MainForm.objPUR_POProducts.ShowDialog();
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
        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdSupplierList.Rows.Count > 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(133);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    { 
                        udfnRefresh();
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(79);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count); }
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

        private void BtnViewDataView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnViewDataView.BackColor = Color.Transparent;
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
                    txtInvoiceNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbRateBefore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbAfterBefore.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbAfterBefore_Enter(object sender, EventArgs e)
        {
            try
            {
                rbAfterBefore.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbAfterBefore_Leave(object sender, EventArgs e)
        {
            try
            {
                rbAfterBefore.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbAfterBefore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbDiscountBefore.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbPurchaseCheque_Enter(object sender, EventArgs e)
        {
            try
            {
                rbPaymentCheque.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPurchaseCheque_Leave(object sender, EventArgs e)
        {
            try
            {
                rbPaymentCheque.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPurchaseCheque_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbDiscountBefore.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbDiscountBefore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbDiscountAfter.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbDiscountBefore_Leave(object sender, EventArgs e)
        {
            try
            {
                rbDiscountBefore.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbDiscountBefore_Enter(object sender, EventArgs e)
        {
            try
            {
                rbDiscountBefore.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbDiscountAfter_Enter(object sender, EventArgs e)
        {
            try
            {
                rbDiscountAfter.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbDiscountAfter_Leave(object sender, EventArgs e)
        {
            try
            {
                rbDiscountAfter.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbDiscountAfter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbPONo.Enabled == true)
                    { cmbPONo.Focus(); }
                    else
                    { txtProductName.Focus(); }
                }
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
                cmbTransactionType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { varRMFlag = Convert.ToInt32(cmbTransactionType.SelectedValue); }

        }

        private void CmbTransactionType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBroker.Focus();
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

        private void ChkInvoice_Enter(object sender, EventArgs e)
        {
            try
            {
                chkInvoice.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkInvoice_Leave(object sender, EventArgs e)
        {
            try
            {
                chkInvoice.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (gpPurchase.Enabled == true)
                    { rbPurchaseCash.Focus(); }
                    else
                    {
                        if (gpPayment.Enabled == true)
                        { rbPaymentCash.Focus(); }
                        else { rbDiscountBefore.Focus(); }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPaymentCash_Enter(object sender, EventArgs e)
        {
            try
            {
                rbPaymentCash.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPaymentCash_Leave(object sender, EventArgs e)
        {
            try
            {
                rbPaymentCash.BackColor = Color.WhiteSmoke;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPaymentCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbPaymentCheque.Focus();
                }
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
                if (Convert.ToInt32(grdSupplierList.Rows.Count) != 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(78);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        grdSupplierList.Rows.Clear();
                    }
                    if (dialogResult == DialogResult.No)
                    { cmbTransactionType.SelectedValue = varRMFlag; }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBroker_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lv_Broker.Items.Clear();
                if (txtBroker.Text.Length > 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();
                    objDs = objspservice.udfnBrokerList(4, 0, 0, 0, txtBroker.Text);
                    objspservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["BR_Name"].ToString(), objDs.Tables[0].Rows[i]["BRID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lv_Broker.Items.Add(objList);
                                }
                                lv_Broker.Visible = true;
                                lv_Broker.Columns[1].Width = 0;
                            }
                        }
                    }
                }
                else
                {
                    lv_Broker.Visible = false;
                    lv_Broker.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Lv_Broker_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnBrokerData();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Lv_Broker_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnBrokerData();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdSupplierList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;
                for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                {
                    if (PbApprovalStsid != 70)
                    {
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmAddproflag"].Value) == "0")
                        {
                            DataGridViewCell cell2 = dataGridView.Rows[i].Cells["clmAddPro"];
                            cell2.Value = new Bitmap(1, 1);
                            cell2.ReadOnly = true;
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "73") //Disabled
                        {
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                            DataGridViewCell cellProBatch = dataGridView.Rows[i].Cells["clmProductBatchNo"];
                            cell.Style.BackColor = Color.LightGray; cellProBatch.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black; cellProBatch.Style.ForeColor = Color.Black;
                            cell.ReadOnly = true; cellProBatch.ReadOnly = true;
                        }
                        else if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "72")//Enabled
                        {
                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "74") //Auto
                            {
                                DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                                DataGridViewCell cellProBatch = dataGridView.Rows[i].Cells["clmProductBatchNo"];
                                cell.Style.BackColor = Color.LightGray; cellProBatch.Style.BackColor = Color.LightGray;
                                cell.Style.ForeColor = Color.Black; cellProBatch.Style.ForeColor = Color.Black;
                                cell.ReadOnly = true; cellProBatch.ReadOnly = true;
                                if(Convert.ToString(grdSupplierList.Rows[i].Cells["clmConditionID"].Value) == "226" )
                                {
                                    cell.ReadOnly = false; cellProBatch.ReadOnly = false;
                                    cell.Style.BackColor = Color.PaleGreen; cellProBatch.Style.BackColor = Color.PaleGreen;
                                }
                            }
                            else if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "75") //Manual
                            {
                                DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                                DataGridViewCell cellProBatch = dataGridView.Rows[i].Cells["clmProductBatchNo"];
                                cell.Style.BackColor = Color.PaleGreen; cellProBatch.Style.BackColor = Color.PaleGreen;
                                cell.Style.ForeColor = Color.Black; cellProBatch.Style.ForeColor = Color.Black;
                                cell.ReadOnly = false; cellProBatch.ReadOnly = false;
                            }
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["rkid"].Value) == "0" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmrkcount"].Value) == "0")
                        {
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmrack"];
                            cell.Style.BackColor = Color.LightGray;
                            cell.ReadOnly = true;
                        }
                        else
                        {
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["rkid"];
                            cell.Style.BackColor = Color.PaleGreen;
                        }
                        if (Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmMrpFlag"].Value) == 1)
                        {
                            grdSupplierList.Rows[i].Cells["clmMRP"].Style.BackColor = Color.PaleGreen;
                            grdSupplierList.Rows[i].Cells["clmProductMrp"].Style.BackColor = Color.PaleGreen;
                        }
                        else
                        {
                            grdSupplierList.Rows[i].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmMRP"].ReadOnly = true;
                            grdSupplierList.Rows[i].Cells["clmProductMrp"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmProductMrp"].ReadOnly = true;
                        }
                        if (Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmShelflifeenable"].Value) == 1)
                        {
                            grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                            grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].Style.BackColor = Color.PaleGreen;
                        }
                        else
                        {
                            grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmexpirydate"].ReadOnly = true;
                            grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].ReadOnly = true;
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmConditionID"].Value) == "202")//Nodifference
                        {
                            grdSupplierList.Rows[grdSupplierList.RowCount - 1].Cells["clmMismatchQty"].ReadOnly = true;
                            grdSupplierList.Rows[grdSupplierList.RowCount - 1].Cells["clmMismatchQty"].Style.BackColor = Color.LightGray;
                        }
                        else
                        {
                            grdSupplierList.Rows[grdSupplierList.RowCount - 1].Cells["clmMismatchQty"].ReadOnly = false;
                            grdSupplierList.Rows[grdSupplierList.RowCount - 1].Cells["clmMismatchQty"].Style.BackColor = Color.PaleGreen;
                        }
                        if (Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmInvFlag"].Value) == 1 || Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value) == "220" || PbSTS == "50" || pbPurchaseEntryUnapprovedFlag == 1 || Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmGRNMAFlag"].Value) == 1)
                        {
                            grdSupplierList.Rows[i].ReadOnly = true;
                            grdSupplierList.Rows[i].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmProductMrp"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmLocation"].Style.BackColor = Color.LightGray;
                            grdSupplierList.Rows[i].Cells["clmrack"].Style.BackColor = Color.LightGray;  
                            grdSupplierList.Rows[i].Cells["clmMismatchQty"].Style.BackColor = Color.LightGray;
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmConditionID"].Value) == "275") //No difference
                        {
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmMismatchQty"]; 
                            cell.Style.BackColor = Color.LightGray; cell.Style.ForeColor = Color.Black;  cell.ReadOnly = true;  
                        }
                    }
                    string[] varShelflifevalue = Convert.ToString(grdSupplierList.Rows[i].Cells["clmshelfper"].Value).Split(' ');
                    if (varShelflifevalue[0] != "")
                    {
                        if (Convert.ToDecimal(varShelflifevalue[0]) > 0 && Convert.ToDecimal(varShelflifevalue[0]) < varShelflifeLevel1)
                        {
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.Red;
                            cell.Style.ForeColor = Color.White;
                        }
                        else if (Convert.ToDecimal(varShelflifevalue[0]) > varShelflifeLevel1 - 1 && Convert.ToDecimal(varShelflifevalue[0]) < varShelflifeLevel2)
                        {
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.Orange;
                            cell.Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.White;
                            cell.Style.ForeColor = Color.Black;
                        }
                    }

                    if ( Convert.ToString(grdSupplierList.Rows[i].Cells["clmGRNProductType"].Value) == "264"
                        || Convert.ToString(grdSupplierList.Rows[i].Cells["clmGRNProductType"].Value) == "265" || Convert.ToString(grdSupplierList.Rows[i].Cells["clmGRNProductType"].Value) == "266"
                        || Convert.ToString(grdSupplierList.Rows[i].Cells["clmGRNProductType"].Value) == "227")
                    {
                        grdSupplierList.Rows[i].ReadOnly = true;
                        grdSupplierList.Rows[i].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                        grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                        grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                        grdSupplierList.Rows[i].Cells["clmProductMrp"].Style.BackColor = Color.LightGray;
                        grdSupplierList.Rows[i].Cells["clmProductExpiryDate"].Style.BackColor = Color.LightGray;
                        grdSupplierList.Rows[i].Cells["clmProductBatchNo"].Style.BackColor = Color.LightGray;
                        grdSupplierList.Rows[i].Cells["clmLocation"].Style.BackColor = Color.LightGray;
                        grdSupplierList.Rows[i].Cells["clmrack"].Style.BackColor = Color.LightGray;
                    }
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmRMFlag"].Value) == "1")
                    {
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmexpirydate"];
                        DataGridViewCell cellExpiry = dataGridView.Rows[i].Cells["clmProductExpiryDate"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black; 
                        cell.ReadOnly = true;
                        cellExpiry.Style.BackColor = Color.LightGray;
                        cellExpiry.Style.ForeColor = Color.Black;
                        cellExpiry.ReadOnly = true;
                    }
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value) == "220")
                    { 
                        grdSupplierList.Rows[i].Cells["clmProTname"].Style.BackColor = ColorTranslator.FromHtml("#FFD3B6");
                        grdSupplierList.Rows[i].Cells["clmPicode"].Style.BackColor = ColorTranslator.FromHtml("#FFD3B6");
                    }
                }
                if (varPurEditFlag == 1)
                {
                    grdSupplierList.Columns["clmMRP"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdSupplierList.Columns["clmexpirydate"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdSupplierList.Columns["clmBatchno"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdSupplierList.Columns["clmProductMrp"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdSupplierList.Columns["clmProductExpiryDate"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdSupplierList.Columns["clmProductBatchNo"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdSupplierList.Columns["clmLocation"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdSupplierList.Columns["clmrack"].DefaultCellStyle.BackColor = Color.LightGray;
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
                txtProductName.BackColor = Color.White;
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
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblDProduct.Text = "Search by P.I Code (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblDProduct.Text = "Search by Product Name (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    btnConditions.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.RowCount > 0)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
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
                                    // txtMrp.Focus();
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
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    { 
                        if (varPrInvFlag == "1" || Convert.ToString(cmbPONo.SelectedValue) == "220" || varGRNProType == "226" || varGRNProType == "264"
                        || varGRNProType == "265" || varGRNProType == "266" || varGRNProType == "26" || varGRNProType == "264")
                        {
                            btnAdd.Focus();
                        }
                        else
                        {
                            if (btnConditions.Enabled == true)
                            { btnConditions.Focus(); }
                            else if (varPrMRPFlag == "1")
                            {
                                txtMrp.ReadOnly = false;
                                txtMrp.Enabled = true;
                                txtMrp.Focus();
                            }
                            else
                            {
                                txtMrp.ReadOnly = true;
                                txtMrp.Enabled = false;
                                if (varShelflife == 1 && txtMonth.Enabled == true && txtMonth.ReadOnly == false)
                                {
                                    txtDate.Focus();
                                }
                                else
                                {
                                    if (txtBatchno.Enabled == true)
                                    { txtBatchno.Focus(); }
                                    else if (txtSourceLocation.Enabled == true)
                                    { txtSourceLocation.Focus(); }
                                    else if (cmbrack.Enabled == true)
                                    { cmbrack.Focus(); }
                                    else { btnAdd.Focus(); }
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
            finally
            {
                if (Convert.ToString(cmbPONo.SelectedValue) == "220")
                {   btnConditions.Enabled = false; }
                else if (Convert.ToString(cmbPONo.SelectedValue) == "219")
                { btnConditions.Enabled = true; }
            }
        }
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    varBatchNo = "0"; varBatchNoGeneration = "0"; varShelflife = 0; expirydateFlag = 0;
                    varBatchNo = "0"; varPrDate = "0"; varPrMonth = "0"; varPrYear = "0"; varPrLocation = "0";
                    varPrRack = "0"; varPrMRP = "0"; varPrInvFlag = "0"; varPrslid = "0"; varPrRkid = "0"; varId = "0"; varPrMRPFlag = "0"; MA_ReasonFlag= 0;
                    varGRNProType = "0"; varRMProductionFlag = 0; pbConditionIDs = "";
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varEditPRID = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    varAutocompleteProduct = 1;
                    udfnProductWiseDetails();

                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNo"].Value.ToString();
                    varBatchNoGeneration = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNoGeneration"].Value.ToString();
                    varRMProduction = DGV_FilterProduct.SelectedRows[0].Cells["PR_RMForProduction"].Value.ToString();
                    varPrcategory = DGV_FilterProduct.SelectedRows[0].Cells["PR_PRCTID"].Value.ToString();
                    varShelflife = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_ShelfLife"].Value.ToString());
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    varHSNid = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_HSNID"].Value);
                    varPrMRPFlag = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["PR_MRPflag"].Value);

                    if (varShelflife == 1)
                    {
                        expirydateFlag = 1;
                        txtMonth.Enabled = true;
                        txtDate.Enabled = true;
                        txtYear.Enabled = true;
                        txtMonth.ReadOnly = false;
                        txtDate.ReadOnly = false;
                        txtYear.ReadOnly = false;
                    }
                    else
                    {
                        txtMonth.Enabled = false;
                        txtDate.Enabled = false;
                        txtYear.Enabled = false;
                        txtMonth.ReadOnly = true;
                        txtDate.ReadOnly = true;
                        txtYear.ReadOnly = true;
                    }
                    udfnProductAdd();
                    if (varPOdropdownFlag == 1 || varPOdropdownFlag == 0 || Convert.ToString(cmbPONo.SelectedValue) == "215") //po , direct and none
                    {
                        udfnDefalutLocation();
                    }
                    else if (varPOdropdownFlag == 2 && Convert.ToInt16(cmbPONo.SelectedValue) != 214)
                    {
                        varPrBatch = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Batch No."].Value);
                        varPrDate = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Date"].Value);
                        varPrMonth = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Month"].Value);
                        varPrYear = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Year"].Value);
                        varPrLocation = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Location"].Value);
                        varPrRack = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Rack"].Value);
                        varPrMRP = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["MRP"].Value);
                        varPrInvFlag = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["InvFlag"].Value);
                        varPrslid = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Slid"].Value);
                        varPrRkid = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Rkid"].Value);
                        if (Convert.ToInt32(cmbPONo.SelectedValue) == 218) //GRN
                        {
                            varId = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["ID"].Value);
                            txtGRNMrp.Text = varPrMRP;
                            varGRNProType = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["GRN ProType"].Value);
                            varGrnType = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["GRN Type"].Value);
                            varProductMRP = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["ProductMRP"].Value);
                            varProductExpiry = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["ProductExpiryDate"].Value);
                            varProductBatch = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["ProductBatchNo"].Value);
                            pbConditionIDs= Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Condition"].Value);
                            txtMismatchQty.Text = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["Mismatch Qty"].Value);  
                            cmbReason.SelectedValue = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["GRNPR_ReturnType"].Value);
                            MA_ReasonFlag = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["MA_ReasonFlag"].Value);  
                            txtMismatchQty.ReadOnly = false;
                            txtMismatchQty.Enabled = false;
                            udfnCheckCondition();
                            udfnConditionName();
                           // cmbQtyType.Enabled = false;
                        }
                        txtBatchno.Text = varPrBatch;
                        txtMrp.Text = varPrMRP;
                        txtDate.Text = varPrDate;
                        txtMonth.Text = varPrMonth;
                        txtYear.Text = varPrYear;
                        txtSourceLocation.Text = varPrLocation;
                        lblLocationcode.Text = varPrslid;
                        udfnCmbSourceRack();
                        cmbrack.SelectedValue = varPrRkid;
                        cmbrack.Text = varPrRack;
                    }
                    udfnAddrowEnable();
                    if (Convert.ToString(cmbPONo.SelectedValue) != "220" && (varGRNProType == "226" || varGRNProType == "264"
                            || varGRNProType == "265" || varGRNProType == "266" || varGRNProType == "26" || varGRNProType == "264") || varGrnType == "214") //226-GRN pro type not received
                    {
                        if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                        {
                            txtBatchno.Text = "";
                            txtBatchno.Enabled = false;
                        }
                        else if (Convert.ToInt32(varBatchNo) == 72) //enabled
                        {
                            if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                            {
                                txtBatchno.Enabled = true;
                            }
                            else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                            {
                                txtBatchno.Enabled = false;
                            }
                        }
                    }
                } 
                if (varPrInvFlag == "1" || Convert.ToString(cmbPONo.SelectedValue) == "220" || (varGRNProType == "226" || varGRNProType == "264"
                        || varGRNProType == "265" || varGRNProType == "266" || varGRNProType == "26" || varGRNProType == "264"))
                {
                    btnAdd.Focus();
                }
                else
                {
                    if (btnConditions.Enabled == true)
                    { btnConditions.Focus(); }
                    else if (varPrMRPFlag == "1")
                    {
                        txtMrp.ReadOnly = false;
                        txtMrp.Enabled = true;
                        txtMrp.Focus();
                    }
                    else
                    {
                        txtMrp.ReadOnly = true;
                        txtMrp.Enabled = false;
                        if (varShelflife == 1 && txtMonth.Enabled == true && txtMonth.ReadOnly == false)
                        {
                            txtMonth.Focus();
                        }
                        else
                        {
                            if (txtBatchno.Enabled == true)
                            { txtBatchno.Focus(); }
                            else if (txtSourceLocation.Enabled == true)
                            { txtSourceLocation.Focus(); }
                            else if (cmbrack.Enabled == true)
                            { cmbrack.Focus(); }
                            else { btnAdd.Focus(); }
                        }
                    }
                } 
                if (varRMProductionFlag == 1)
                {
                    txtDate.Enabled = false; txtDate.ReadOnly = true;
                    txtMonth.Enabled = false; txtMonth.ReadOnly = true;
                    txtYear.Enabled = false; txtYear.ReadOnly = true;
                }
                if (Convert.ToString(cmbPONo.SelectedValue) == "220")
                { udfnConditionEnable(); }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterProduct.Visible = false;
                if (Convert.ToString(cmbPONo.SelectedValue) == "220")
                {  btnConditions.Enabled = false; }
                else if (Convert.ToString(cmbPONo.SelectedValue) == "219")
                { btnConditions.Enabled = true; }
            }
        }

        public void udfnCheckCondition()
        {
            try
            {  
                // Step 1: Convert to HashSet for O(1) lookup time
                var idSet = new HashSet<string>(pbConditionIDs.Split(',').Select(id => id.Trim())); 
                foreach (DataGridViewRow row in grdConditions.Rows)
                {
                    var cellValue = Convert.ToString(row.Cells["ConditionID"].Value);
                    if (idSet.Contains(cellValue))
                    {
                        row.Cells["clmCheck"].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnNewProductadd()
        {
            try
            {
                udfnProductAdd();
                udfnDefalutLocation();
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
                    if (lblProductcode.Text != "0" && lblProductcode.Text != "-1")
                    {
                        DataSet ObjsLocation = new DataSet();
                        SPDataService objDserv = new SPDataService();
                        if (varRMFlag == 59)
                        {
                            ObjsLocation = objDserv.udfnStockLocationList(25, Convert.ToInt32(cmbConcern.SelectedValue), 0, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0, 1, 0, "", "", 0);
                        }
                        else
                        {
                            ObjsLocation = objDserv.udfnStockLocationList(25, 0, 0, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0, 0, 0, "", "", 0);
                        }
                        objDserv.CloseConnection();
                        if (ObjsLocation != null)
                        {
                            if (ObjsLocation.Tables.Count > 0)
                            {
                                if (ObjsLocation.Tables[0].Rows.Count > 0)
                                {
                                    lblLocationcode.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SLID"]);
                                    txtSourceLocation.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SL_EName"]);
                                    udfnCmbSourceRack();
                                    lvSourceLocation.Visible = false;
                                    if (cmbrack.Text != "None")
                                    { cmbrack.SelectedIndex = 0; }
                                }
                            }
                            else
                            {
                                lblLocationcode.Text = "0";
                                txtSourceLocation.Text = "";
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
                    if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                    {
                        txtBatchno.Text = "";
                        txtBatchno.Enabled = false; 
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
                            if (varPOdropdownFlag == 2 && Convert.ToString(cmbPONo.SelectedValue) != "214" || Convert.ToString(cmbPONo.SelectedValue) != null)
                            {
                                SPDataService objspdservice = new SPDataService();
                                DataSet objDs = new DataSet();
                                MR_Master objMR_Master = new MR_Master();
                                objMR_Master.ViewType = 14;
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
                    }
                    if (Convert.ToInt32(varPrcategory) == 16 && varShelflife == 1 && Convert.ToString(cmbPONo.SelectedValue) != "220") //entry type not against dc
                    {
                        string vardate = "";
                        if (Convert.ToString(cmbPONo.SelectedValue) != "218")
                        {
                            vardate = varGRNDate;
                        }
                        else if (Convert.ToString(cmbPONo.SelectedValue) != "220")
                        {
                            vardate = varDCDate;
                        }
                        else { vardate = varVoucherDate; }
                        if (Convert.ToInt32(varRMProduction) == 1)
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 15;
                            objMR_Master.paraDate = dpVoucherDate.Text;
                            objMR_Master.paraProductId = Convert.ToInt32(lblProductcode.Text.Trim());
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
            finally
            {
                DGV_FilterProduct.Visible = false;
            }
        }
        public void udfnAddrowEnable()
        {
            try
            {
                if(Convert.ToString(cmbPONo.SelectedValue) == "220" || MA_ReasonFlag==1|| (varGRNProType == "226" || varGRNProType == "264"
                            || varGRNProType == "265" || varGRNProType == "266" || varGRNProType == "26" || varGRNProType == "264") && varGrnType == "215" || varPrInvFlag == "1")
                { 
                    txtMrp.Enabled = false;
                    txtDate.Enabled = false;
                    txtMonth.Enabled = false;
                    txtYear.Enabled = false;
                    txtSourceLocation.Enabled = false;
                    cmbrack.Enabled = false;
                    txtMrp.ReadOnly = true;
                    txtDate.ReadOnly = true;
                    txtMonth.ReadOnly = true;
                    txtYear.ReadOnly = true;
                    txtSourceLocation.ReadOnly = true;
                    btnConditions.Enabled = false;
                    cmbReason.Enabled = false; 
                }
                else
                {
                    if (varPrInvFlag == "1")
                    {
                        txtBatchno.Enabled = false;
                        txtMrp.Enabled = false;
                        txtDate.Enabled = false;
                        txtMonth.Enabled = false;
                        txtYear.Enabled = false;
                        txtSourceLocation.Enabled = false;
                        cmbrack.Enabled = false;
                        txtMrp.ReadOnly = true;
                        txtDate.ReadOnly = true;
                        txtMonth.ReadOnly = true;
                        txtYear.ReadOnly = true;
                        txtSourceLocation.ReadOnly = true;
                        btnConditions.Enabled = false;
                        cmbReason.Enabled = false;
                    }
                    else
                    {
                        // txtBatchno.Enabled = true;
                        if (varShelflife == 1)
                        {
                            txtDate.Enabled = true;
                            txtMonth.Enabled = true;
                            txtMonth.Enabled = true;
                            txtDate.ReadOnly = false;
                            txtMonth.ReadOnly = false;
                            txtYear.ReadOnly = false;
                        }
                        else
                        {
                            txtDate.Enabled = false;
                            txtMonth.Enabled = false;
                            txtYear.Enabled = false;
                            txtDate.ReadOnly = true;
                            txtMonth.ReadOnly = true;
                            txtYear.ReadOnly = true;
                        }
                        if (varPrMRPFlag == "1" && (varGRNProType != "226" || varGRNProType != "264"
                            || varGRNProType != "265" || varGRNProType != "266" || varGRNProType != "26" || varGRNProType != "264"))
                        { txtMrp.Enabled = true; txtMrp.ReadOnly = false; }
                        else { txtMrp.Enabled = false; txtMrp.ReadOnly = true; }
                        txtSourceLocation.Enabled = true;
                        cmbrack.Enabled = true; 
                        txtSourceLocation.ReadOnly = false;
                    }
                }
                lvSourceLocation.Visible = false;
                if (cmbrack.Text == "None")
                { cmbrack.Enabled = false; }
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
                            varPrMRPFlag = Convert.ToString(objDS.Tables[0].Rows[0]["PR_MRPflag"].ToString());
                            varunitid = Convert.ToString(objDS.Tables[0].Rows[0]["UT_Symbol"].ToString());
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
                                }
                                if (varPrMRPFlag == "1")
                                {
                                    varPrMRPFlag = "1";
                                    txtMrp.ReadOnly = false;
                                    txtMrp.Enabled = true;
                                }
                                else
                                {
                                    varPrMRPFlag = "0";
                                    txtMrp.ReadOnly = true;
                                    txtMrp.Enabled = false;
                                }

                                if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                                {
                                    txtBatchno.Text = "";
                                    txtBatchno.Enabled = false;
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
                                if (Convert.ToInt32(varPrcategory) == 16 && varShelflife == 1)
                                {
                                    if (Convert.ToInt32(varRMProduction) == 1)
                                    {
                                        varRMProductionFlag = 1;
                                        MR_Master objMR_Master = new MR_Master();
                                        objMR_Master.ViewType = 15;
                                        objMR_Master.paraDate = dpInvoiceDate.Text;
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
                            if (varAutocompleteProduct == 2)
                            {
                                DataGridView dataGridView1 = grdSupplierList;
                                DataGridViewCell cell1 = dataGridView1.CurrentRow.Cells["clmMRP"];
                                DataGridView dataGridView2 = grdSupplierList;
                                DataGridViewCell cell2 = dataGridView2.CurrentRow.Cells["clmexpirydate"];
                                DataGridView dataGridView3 = grdSupplierList;
                                DataGridViewCell cell3 = dataGridView3.CurrentRow.Cells["clmBatchenable"];
                                if (varPrMRPFlag == "0")
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
        public void udfnProDataChange()
        {
            try
            {
                MainForm.objCP_Items = new CP_Product();
                MainForm.objCP_Items.varproductcode = Convert.ToInt32(varEditPRID);
                MainForm.objCP_Items.varMasterType = "1";
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
        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int varViewType = 0; string PRID = "0";
                int GRNID = 0, varRMFlag = 0; string POID = "0", DCID = "0";
                int varflag = 0;  
                if (varProducts != "")
                {
                    var strings1 = varProductsIDs.Select(xx => xx);
                    PRID = (string.Join(",", strings1));
                }
                txtBatchno.BackColor = SystemColors.Control;
                string varProductsCodes = "0";
                if (varUpDownKey == 0)
                {
                    if (VarSearchFlag == true)
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                    if (txtProductName.Text != "" || txtProductName.Text == "")
                    {
                        udfnrowclear();
                        udfntooltiphide();
                    }
                    if (varBlockedSupplier == "98")
                    {
                        tsbSupplier.Visible = true;
                        txtSupplier.BackColor = Color.LightPink;
                        tsbSupplier.Text = varBlockedReason;
                    }
                    else
                    {
                        tsbSupplier.Visible = false;
                        txtSupplier.BackColor = Color.White;
                    }
                    varNewFlag = "0";

                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 59)
                    { varRMFlag = 1; }
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {
                        if (Convert.ToInt32(cmbPONo.SelectedValue) == 214 || Convert.ToInt32(cmbPONo.SelectedValue) == 217 || Convert.ToInt32(cmbPONo.SelectedValue) == 219 || Convert.ToString(cmbEntryType.SelectedValue) == "56") //none
                        {
                            varViewType = 29;
                            varPOdropdownFlag = 1;
                            DGV_FilterProduct.Width = 660;
                        }
                        else if (Convert.ToInt32(cmbPONo.SelectedValue) == 215)  //Against Po
                        {
                            varflag = 0;
                            POID = Convert.ToString(pbPONO);
                            varViewType = 60;
                            varPOdropdownFlag = 2;
                            DGV_FilterProduct.Width = 660;
                        }
                        else if (Convert.ToInt32(cmbPONo.SelectedValue) == 218)  //Against GRN
                        {
                            varflag = 1;
                            GRNID = Convert.ToInt16(pbGRNNo);
                            varViewType = 60;
                            varPOdropdownFlag = 2;
                            DGV_FilterProduct.Width = 1110;
                        }
                        else if (Convert.ToInt32(cmbPONo.SelectedValue) == 220)  //Against DC
                        {
                            varflag = 2;
                            DCID = Convert.ToString(pbDCNo);
                            varViewType = 60;
                            varPOdropdownFlag = 2;
                            DGV_FilterProduct.Width = 1110;
                        }
                        else
                        {
                            varViewType = 29; DGV_FilterProduct.Width = 660;
                        }
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = varViewType;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.ParaScheduleid = lblschedule.Text;
                        objMR_Product.ParaProductCode = 0;
                        objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                        objMR_Product.ParaProductsCode = varProductsCodes;
                        objMR_Product.ParaGRNID = GRNID;
                        objMR_Product.ParaPOID = POID;
                        objMR_Product.ParaDCID = DCID;
                        objMR_Product.ParaProductsCode = PRID;
                        objMR_Product.paraFlag = varflag;
                        objMR_Product.ParaRMFlag = varRMFlag;
                        objMR_Product.paraPurchaseAutoComplete = dtPurchaseAutoComplete;
                        if (VarSearchFlag == true)
                        {
                            objMR_Product.paraPicode = txtProductName.Text;
                        }
                        else
                        {
                            objMR_Product.paraProductName = txtProductName.Text;
                        }
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Visible = true;
                                    DGV_FilterProduct.Columns["pr_retailrate"].Visible = true;
                                    DGV_FilterProduct.Columns["PR_BatchNo"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_BatchNoGeneration"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_RMForProduction"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PRCTID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_ShelfLife"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["pr_retailrate"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_HSNID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_MRPflag"].Visible = false;
                                    if (varViewType != 29 && Convert.ToInt32(cmbPONo.SelectedValue) != 214 && Convert.ToInt32(cmbPONo.SelectedValue) != 215)
                                    {
                                        DGV_FilterProduct.Columns["Slid"].Visible = false;
                                        DGV_FilterProduct.Columns["Rkid"].Visible = false;
                                        DGV_FilterProduct.Columns["InvFlag"].Visible = false;
                                        DGV_FilterProduct.Columns["Date"].Visible = false;
                                        DGV_FilterProduct.Columns["Month"].Visible = false;
                                        DGV_FilterProduct.Columns["Year"].Visible = false;
                                    }
                                    if (Convert.ToInt32(cmbPONo.SelectedValue) == 218) //GRN
                                    {
                                        DGV_FilterProduct.Columns["ID"].Visible = false;
                                        DGV_FilterProduct.Columns["GRN MRP"].Visible = false;
                                        DGV_FilterProduct.Columns["GRN ProType"].Visible = false;
                                        DGV_FilterProduct.Columns["GRN Type"].Visible = false;
                                        DGV_FilterProduct.Columns["ProductMRP"].Visible = false;
                                        DGV_FilterProduct.Columns["ProductExpiryDate"].Visible = false;
                                        DGV_FilterProduct.Columns["ProductBatchNo"].Visible = false;
                                        DGV_FilterProduct.Columns["Condition"].Visible = false;
                                        DGV_FilterProduct.Columns["Mismatch Qty"].Visible = false;
                                        DGV_FilterProduct.Columns["GRNPR_ReturnType"].Visible = false;
                                        DGV_FilterProduct.Columns["MA_ReasonFlag"].Visible = false;
                                    }

                                    DGV_FilterProduct.Columns["PR_EName"].Width = 340;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 340;
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
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBrokerData()
        {
            try
            {
                if (txtBroker.Text != "")
                {
                    ListViewItem selectedItem = lv_Broker.SelectedItems[0];
                    txtBroker.Text = selectedItem.SubItems[0].Text;
                    lblBrokerId.Text = selectedItem.SubItems[1].Text;
                }
                if (txtGstin.Enabled == true)
                { txtGstin.Focus(); }
                else
                { chkInvoice.Focus(); }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lv_Broker.Visible = false;
            }
        } 

        public void udfnSupplierDetails()
        {
            try
            {
                if (Convert.ToInt32(lblSupplierCode.Text) > 0)
                {
                    btnClear.Enabled = true;
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
                            varSupplierType = Convert.ToInt32(objDs.Tables[0].Rows[0]["SP_SupplierType"].ToString());
                            pbSupplierTin = Convert.ToInt32(objDs.Tables[0].Rows[0]["SP_Tin"].ToString());
                            if (pbSupplierTin == 33)
                            {
                                varTinFlag = 0;
                            }
                            else
                            {
                                varTinFlag = 1;
                            }
                            if (lblsupplierGST.Text != "URD")
                            { lblsupplierGST.Text = "GSTIN - XXXXXXXXXXXXXXX"; }
                            else
                            {
                                lblsupplierGST.Text = "GSTIN - " + lblsupplierGST.Text;
                            }
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString();
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString();
                            lblSupplierOrderpolicy.Text = "Return Policy -" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                            varGSTIN = Convert.ToString(objDs.Tables[0].Rows[0]["SP_GSTIN"]);

                            if (Convert.ToString(objDs.Tables[0].Rows[0]["SP_GSTIN"]) != "" && pbPurchaseno == "0")
                            {
                                LV_Supplier.Visible = false;
                                if (Convert.ToInt32(cmbEntryType.SelectedValue) != 54 && (Convert.ToInt32(cmbEntryType.SelectedValue) != -1) && varQueueFlag == 0 && varSupplierType != 32)
                                {
                                    udfnGSTINPopup();
                                }
                            }
                            else
                            {
                                LV_Supplier.Visible = false;
                                txtGstin.Enabled = false;
                            }
                            udfnPODropdownload();
                        }
                        if (objDs.Tables[7].Rows.Count > 0)
                        {
                            varDamage = objDs.Tables[7].Rows[0]["DAMAGE"].ToString();
                            varReturnDC = objDs.Tables[7].Rows[0]["RETURNDC"].ToString();
                        }
                        if (objDs.Tables[10].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(objDs.Tables[10].Rows[0]["COUNT"].ToString());
                            if (count > 0)
                            {
                                btnDC.Enabled = true;
                            }
                            else
                            {
                                btnDC.Enabled = false;
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
                if (varReturnDC == "0")
                {
                    btnDC.Enabled = false;
                }
                else
                {
                    btnDC.Enabled = true;
                }
                lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count);
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if (tbDetails.SelectedIndex == 0)
                {
                    if (grdSupplierList.Focused)
                    {
                        grid_flag = 1;
                    }
                    if (grid_flag == 1)
                    {
                        if (keyData == Keys.Enter || keyData == Keys.Right || keyData == Keys.Tab)
                        {
                            int icolumn = grdSupplierList.CurrentCell.ColumnIndex;
                            int irow = grdSupplierList.CurrentCell.RowIndex;
                            int i = irow;
                            int intsection = 0, intlvariant = 0;
                            intsection = grdSupplierList.Columns.Count - 1;
                            intlvariant = grdSupplierList.Columns.Count - 19;
                            if (intsection == icolumn)
                            {
                                grdSupplierList.CurrentCell = grdSupplierList[intsection, irow + 1];
                                icolumn = grdSupplierList.Columns.Count - 1;//grdSupplierList.CurrentCell.ColumnIndex;
                                irow = grdSupplierList.CurrentCell.RowIndex;
                            }
                            else if (intlvariant == icolumn)
                            {
                            A: if (icolumn == grdSupplierList.Columns.Count - 19)
                                {
                                    if (irow < grdSupplierList.Rows.Count - 1)
                                    {
                                        grdSupplierList.CurrentCell = grdSupplierList[6, irow + 1];
                                        icolumn = grdSupplierList.CurrentCell.ColumnIndex;
                                        irow = grdSupplierList.CurrentCell.RowIndex;
                                    }
                                    else
                                    {
                                        grdSupplierList.ClearSelection();
                                        txtLoadingCharge.Focus();
                                    }
                                }
                                else
                                {
                                    grdSupplierList.CurrentCell = grdSupplierList[icolumn + 1, irow];
                                    if (grdSupplierList.CurrentCell.ReadOnly == true && grdSupplierList.CurrentCell.Visible == false)
                                    {
                                        icolumn++; goto A;
                                    }
                                }
                            }
                            else
                            {
                            A: if (icolumn == grdSupplierList.Columns.Count - 1)
                                {
                                    if (irow < grdSupplierList.Rows.Count - 1)
                                    {
                                        grdSupplierList.CurrentCell = grdSupplierList[6, irow + 1];
                                        icolumn = grdSupplierList.CurrentCell.ColumnIndex;
                                        irow = grdSupplierList.CurrentCell.RowIndex;
                                    }
                                    else
                                    {
                                        grdSupplierList.CurrentCell = grdSupplierList[icolumn + 1, irow];
                                        if (grdSupplierList.CurrentCell.ReadOnly == true)
                                        {
                                            icolumn++; goto A;
                                        }

                                    }
                                }
                                else
                                {
                                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmrack")
                                    {
                                        //To set the focus on next row's 1st editable cell
                                        icolumn = 11;
                                    L: if (grdSupplierList[icolumn, irow + 1].ReadOnly == true)
                                        {
                                            icolumn++;
                                            goto L;
                                        }
                                        grdSupplierList.CurrentCell = grdSupplierList[icolumn, irow + 1];
                                        icolumn = grdSupplierList.CurrentCell.ColumnIndex;
                                        irow = grdSupplierList.CurrentCell.RowIndex;
                                    }
                                    else if (grdSupplierList[icolumn + 1, irow].Visible == false)
                                    {
                                        { icolumn++; goto A; }
                                    }
                                    else
                                    {
                                        grdSupplierList.CurrentCell = grdSupplierList[icolumn + 1, irow];
                                        if (grdSupplierList.CurrentCell.ReadOnly == true || grdSupplierList.CurrentCell.Visible == false) { icolumn++; goto A; }
                                    }
                                }
                            }
                            grid_flag = 0;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (grdPurchaseList.Focused)
                    {
                        grid_flag = 1;
                    } 
                    if (grid_flag == 1)
                    {
                        if (keyData == Keys.Enter || keyData == Keys.Right || keyData == Keys.Tab)
                        {
                            int icolumn = grdPurchaseList.CurrentCell.ColumnIndex;
                            int irow = grdPurchaseList.CurrentCell.RowIndex;
                            int i = irow;
                            int intsection = 0, intlvariant = 0;
                            intsection = grdPurchaseList.Columns.Count - 1;
                            intlvariant = grdPurchaseList.Columns.Count - 9;
                            if (intsection == icolumn)
                            {
                                grdPurchaseList.CurrentCell = grdPurchaseList[intsection, irow + 1];
                                icolumn = grdPurchaseList.Columns.Count - 1;//grdProDetails.CurrentCell.ColumnIndex;
                                irow = grdPurchaseList.CurrentCell.RowIndex;
                            }
                            else if (intlvariant == icolumn)
                            {
                            A: if (icolumn == grdPurchaseList.Columns.Count - 9)
                                {
                                    //grdProDetails.Rows.Add();
                                    if (irow < grdPurchaseList.Rows.Count - 1)
                                    {
                                        grdPurchaseList.CurrentCell = grdPurchaseList[3, irow + 1];
                                        icolumn = grdPurchaseList.CurrentCell.ColumnIndex;
                                        irow = grdPurchaseList.CurrentCell.RowIndex;
                                        //goto A;
                                    }
                                    else
                                    {
                                        grdPurchaseList.CurrentCell = grdPurchaseList[icolumn + 1, irow];
                                        if (grdPurchaseList.CurrentCell.ReadOnly == true)
                                        {
                                            icolumn++; goto A;
                                        }

                                    }
                                }
                                else
                                {
                                    grdPurchaseList.CurrentCell = grdPurchaseList[icolumn + 1, irow];
                                    if (grdPurchaseList.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                                }
                            }
                            else
                            {
                            A: if (icolumn == grdPurchaseList.Columns.Count - 1)
                                {
                                    if (irow < grdPurchaseList.Rows.Count - 1)
                                    {
                                        //To set the focus on next row's 1st editable cell
                                        grdPurchaseList.CurrentCell = grdPurchaseList[13, irow + 1];
                                        icolumn = grdPurchaseList.CurrentCell.ColumnIndex;
                                        irow = grdPurchaseList.CurrentCell.RowIndex;
                                    }
                                    else
                                    {
                                        grdPurchaseList.ClearSelection();
                                        txtLoadingCharge.Focus();
                                    }
                                }
                                else
                                {
                                    if (grdPurchaseList[icolumn + 1, irow].Visible == false)
                                    {
                                        icolumn++; goto A;
                                    }
                                    else
                                    {
                                        grdPurchaseList.CurrentCell = grdPurchaseList[icolumn + 1, irow];
                                        if (grdPurchaseList.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                                    }
                                }
                            } 
                            grid_flag = 0;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
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
