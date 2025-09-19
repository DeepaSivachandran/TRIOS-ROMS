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
    public partial class PUR_PurchaseEntryApproval : Form
    {
        DataTable dtTaxTable = new DataTable();
        DateTime varmaxdate;
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpconcern = new ToolTip();
        ToolTip tpInvoice = new ToolTip();
        ToolTip tpQRCode = new ToolTip();
        ToolTip tpinvamt = new ToolTip();
        ToolTip tpInvNo = new ToolTip();
        ToolTip tpEntryType = new ToolTip();
        int flag = 0;
        public bool skipValidation = false;
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public string varPurchaseRate = "0", varcomid = "0", pbPONO = "0", pbPurchaseno = "0", pbDCNo = "0", pbGRNNo = "0", PbSTS = "0", PbID = "0", PbFlag = "0";
        public bool VarSearchFlag = true;
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = ""
        , varorderSaleQty = "", varorderqty = "", addproductid = "", varunitid = "0", varDamage = "0", varReturnDC = "0", pbGRNId = "0", pbSupplierId = "0", dcid = "0",
        varenablefalg = "0", varUserID = "0", varflag = "0", varExpiryDate = "", varExpiryDateAdd = "", varTName = "", varexp = "", pbScheduleId = "0", pbPOIdS = "0", varTempExpiryDate = "0",
        varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0", varBatchNo = "0", varNewFlag = "0", VarGridError = "0", PurchaseDcIds = "0", varTypeErrId = "0";
        public decimal PbDiscamt = 0, PbTaxvalue = 0, PbGstamt = 0, PbCGstamt = 0, PbSGstamt = 0, PbIGstamt = 0, PbNetamt = 0, pbDiffQty = 0, pbDisper = 0,PbDicountValue=0;
        public int varGrnId = 0, varCloseflag = 0, pbDateflag = 0, varShelflife = 0, expirydateFlag = 0, varErrorFormat = 0, varcount = 0, varErroronGrid = 0, varExpiryError = 0, shelfLifeError = 0,InvoiceAmountErr = 0,
            VarPrevSupplierid = 0, varModifiedFlag = 0, varDecimal = 0, varQueueFlag = 0, varRMFlag = 0, varRemarkCount = 0, varRemarkFlag = 0, varerrFlag = 0,varHSNid=0;
        public string pbQRCode = "";
        public int varClose = 0, varDateChange = 0, varCloseFalg = 0, varEntryTypeRefresh = 0, varUpDownKey = 0, varcount1 = 0, varCount2 = 0, flagSave = 0, varTabFlag = 0, varEntryType = 0;
        bool varVoucherSkip = false;
        public int grid_flag = 0, varEditProAdd = 0, varEditFlag = 0, varQuantityErr = 0, varDiscountErr = 0,PbApprovalStsid=0,varPurEditFlag=0,varDiscountFlag=0,
            varSupplierType=0, pbRefreshFlag=0, varButtonFlag = 0, pbConcernTin = 0, pbSupplierTin = 0, varTinFlag = 0;
        public decimal varDiscountPer=0, varDiscountAmount=0,pbCostingRate=0;
        public string varCalculator = "0", varGRNPaymentType="0",varEntryApprovalNo="0";
        public int varGridErr = 0, varCheckCount = 0 , varCheckFlag=-1,varCheckButtonFlag=0, varApprovalStatus = 0, varShelflifeLevel1 = 0, varShelflifeLevel2 = 0;
        public PUR_PurchaseEntryApproval()
        {
            InitializeComponent();
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                errPurchaseentry.Clear();
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
                        grdSupplierList.Rows.Clear();
                        grdPODetails.Rows.Clear();
                    }
                    //grdReurnDC.Rows.Clear();
                    //  grdSupplierList.Columns["clmAddPro"].Visible = false;
                    if (cmbEntryType.SelectedValue.ToString() == "54") // GRN
                    {
                        if (PbFlag == "0")
                        {
                            if (varEntryTypeRefresh == 0)
                            { grdPODetails.Rows.Clear(); }
                            grdReurnDC.Rows.Clear();
                            udfnPurchaseGrnLoad();
                            udfnGRNProload();
                            udfnPODropdownload();
                            grdReurnDC.Rows.Clear();
                            txtQRCode.ReadOnly = false;
                            txtQRCode.Enabled = true;
                            //grdReurnDC.Visible = false;
                            grdPODetails.Visible = true;
                            //if (grdPODetails.Rows.Count != 0)
                            //{
                            //    grdSupplierList.Columns["clmPono"].Visible = true;
                            //}
                        }
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "55") // PO
                    {
                        grdReurnDC.Rows.Clear();
                        grdPODetails.Visible = true;
                        udfnPendingPOLoad();
                        udfnDefGrnGridLoad();
                        udfnPODropdownload();
                        txtQRCode.Text = "";
                        txtQRCode.ReadOnly = true;
                        txtQRCode.Enabled = false;
                        dpInvoiceDate.Enabled = true;
                        txtInvoiceNo.ReadOnly = false;
                        grdPODetails.Visible = true;
                       // grdReurnDC.Visible = false;
                        
                        if (grdPODetails.Rows.Count != 0)
                        {
                            lblPOnorecord.Visible = false;
                        }
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "56") // Direct
                    {
                        grdPODetails.Rows.Clear();
                        grdReurnDC.Rows.Clear();
                        grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                        //grdSupplierList.Columns["clmPono"].Visible = false;
                        btnViewDataView.Visible = false;
                        txtQRCode.ReadOnly = true;
                        txtQRCode.Enabled = false;
                        txtQRCode.Text = "";
                        dpInvoiceDate.Enabled = true;
                        txtInvoiceNo.ReadOnly = false;
                        grdPODetails.Visible = true;
                       // grdReurnDC.Visible = false;
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                    {
                        if (PbFlag == "0")
                        {
                            grdPODetails.Rows.Clear();
                            udfnPurchaseDC();
                            udfnDefReturnDc();
                            //grdPODetails.Visible = false;
                            //grdSupplierList.Columns["clmPono"].Visible = false;
                            txtQRCode.Text = "";
                            txtQRCode.ReadOnly = true;
                            txtQRCode.Enabled = false;
                            grdReurnDC.Visible = true;
                            
                            if (grdReurnDC.Rows.Count != 0)
                            {
                                lblFinishedNoRecord.Visible = false;
                            }
                        }
                    }
                    grdSupplierList.Enabled = true;
                }
                if (txtGstin.Text.Trim()=="" &&Convert.ToInt32(lblSupplierCode.Text.Trim()) != 0 && Convert.ToInt32(lblschedule.Text.Trim()) != 0 && (Convert.ToInt32(cmbEntryType.SelectedValue) != 54) && (Convert.ToInt32(cmbEntryType.SelectedValue) != -1) && pbPurchaseno=="0" && varQueueFlag == 0)
                {
                    MainForm.objPUR_GSTIN = new PUR_GSTIN();
                    //MainForm.objPUR_GSTIN.txtGstin.Text = txtGstin.Text.Trim();
                    MainForm.objPUR_GSTIN.ShowDialog();
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
                            Convert.ToInt16(objDs.Tables[0].Rows[i]["InvFlag"]),Convert.ToString(objDs.Tables[0].Rows[i]["HSNID"]));
                            grdSupplierList.Columns["clmProTname"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                            DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
                            grdSupplierList.Enabled = true;
                            if (Convert.ToInt16(objDs.Tables[0].Rows[i]["InvFlag"]) == 1)
                            {
                                //grdSupplierList.Rows[i].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmCheck"].ReadOnly = false;
                                //grdSupplierList.Rows[i].Cells["clmsno"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmPono"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmPicode"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmProTname"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmUnit"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmGrnMrp"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmMRP"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmMRPError"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmexpirydate"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmExpiryDateError"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmShelflife"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmactuallife"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmshelfper"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmBatchno"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmBatchError"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmLocation"].ReadOnly = true;
                                //grdSupplierList.Rows[i].Cells["clmrack"].ReadOnly = true;
                            }
                            else
                            {
                                //grdSupplierList.Rows[i].ReadOnly = false;
                                //grdSupplierList.Rows[i].Cells["clmCheck"].ReadOnly = false;
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
                            , Convert.ToDecimal(objDs.Tables[0].Rows[i]["DCQty"]), 0, 0, Convert.ToInt16(objDs.Tables[0].Rows[i]["POPRID"]), 0);
                            grdSupplierList.Columns["clmProTname"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                           // grdSupplierList.Columns["clmPono"].Visible = true;
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

        public void udfnPendingPOLoad()
        {
            try
            {
                pbPONO = "0";
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
                pbDCNo = "0";
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
                pbGRNNo = "0";
                if (grdSupplierList.Rows.Count != 0)
                {
                    pbGRNNo = Convert.ToString(grdSupplierList.Rows[0].Cells["clmTransId"].Value);
                }
                MainForm.objPUR_Purchase_GRNDetails = new PUR_Purchase_GRNDetails();
                MainForm.objPUR_Purchase_GRNDetails.ShowDialog();
                txtQRCode.Text = pbQRCode;
                varTypeErrId = pbGRNNo;
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
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            lblNoRecordsFound.Visible = false;
                            string varMRP = "", varInvoiceMrp = "";
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
                            if (Convert.ToInt16(objDs.Tables[0].Rows[i]["InvFlag"]) == 1)
                            {
                                varInvoiceMrp = varMRP;
                            }
                            grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, Convert.ToString(objDs.Tables[0].Rows[i]["PONO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[0].Rows[i]["PTNAME"]), Convert.ToString(objDs.Tables[0].Rows[i]["UNIT"]), varMRP, varInvoiceMrp,
                            Convert.ToString(varTempExpiryDate), Convert.ToString(objDs.Tables[0].Rows[i]["PRODUCTEXP"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["Location"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["RKNAME"]),
                             Convert.ToString(objDs.Tables[0].Rows[i]["POID"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[0].Rows[i]["BATCHNO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Batchnogeneration"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_ShelfLife"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RackCount"])
                            , Convert.ToString(objDs.Tables[0].Rows[i]["GRNID"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["TotQty"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["GRNQty"])
                            , Convert.ToDecimal(objDs.Tables[0].Rows[i]["DCQty"]), 0, Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_PRFlag"]), Convert.ToString(objDs.Tables[0].Rows[i]["GRNPRID"]),
                            Convert.ToInt32(objDs.Tables[0].Rows[i]["InvFlag"]),Convert.ToString(objDs.Tables[0].Rows[i]["HSNID"]));
                            //grdSupplierList.Columns["clmGrnMrp"].Visible = true;
                            // grdSupplierList.Columns["clmAddPro"].Visible = true;
                            grdSupplierList.Columns["clmProTname"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);

                            if (Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmInvFlag"].Value) == 1)
                            {
                                grdSupplierList.Rows[i].ReadOnly = true;
                                grdSupplierList.Rows[i].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                                grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                                grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                                grdSupplierList.Rows[i].Cells["clmLocation"].Style.BackColor = Color.LightGray;
                                grdSupplierList.Rows[i].Cells["clmrack"].Style.BackColor = Color.LightGray;
                            }
                        }
                        DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                        GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
                        txtInvoiceNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Invno"]);
                        txtInvoiceamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["invamt"]);
                        txtFrightGrn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_LoadingCharges"]);
                        txtUnLoadingchargeGrn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_UnloadingCharges"]);
                        varGRNPaymentType = Convert.ToString(objDs.Tables[0].Rows[0]["PaymentType"]);
                        if (varGRNPaymentType == "199" || varGRNPaymentType == "200") //199-GRN cash issued ,200- NONE
                        {
                            rbPurchaseCash.Checked = true;
                            rbPaymentCash.Checked = true;
                        }
                        if (varGRNPaymentType == "201")  //Cheque issued
                        {
                            rbPurchaseCredit.Checked = true;
                            rbPaymentCheque.Checked = true;
                        }
                        if (varGRNPaymentType == "200")
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
                        //txtInvoiceNo.Enabled = false;
                        //txtInvoiceamt.Enabled = false;
                        //txtLoadingchargeGrn.Enabled = false;
                        //txtFrightGrn.Enabled = false;
                        //txtInvoiceNo.ReadOnly = true;
                        //txtInvoiceamt.ReadOnly = true;
                        //txtLoadingchargeGrn.ReadOnly = true;
                        //txtFrightGrn.ReadOnly = true;
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
                    else
                    {
                        lblFinishedNoRecord.Visible = true;
                        lblFinishedNoRecord.BringToFront();
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
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                    MainForm.objPUR_PurchaseApprovalList.udfnList();
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
                MainForm.objPUR_PODamagedView.varMasterType = "3";
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
                //lblDPercentage.Text = "< " + Convert.ToString(MainForm.pbShelflifeLevel1) + "%";
                //lblPercentage.Text = "< " + Convert.ToString(MainForm.pbShelflifeLevel2) + "%";
                MainForm objMainForm = new MainForm();
                dtTaxTable = new DataTable();
                objMainForm.udfnGetDefaultCompany();
                dtTaxTable.Columns.Add("GST%", typeof(string));
                dtTaxTable.Columns.Add("Taxable Value", typeof(decimal));
                dtTaxTable.Columns.Add("Tax Value", typeof(decimal));
                dtTaxTable.Columns.Add("IGST%", typeof(decimal));
                dtTaxTable.Columns.Add("IGST Tax Value", typeof(decimal));
                dtTaxTable.Columns.Add("SGST%", typeof(decimal)); 
                dtTaxTable.Columns.Add("SGST Tax Value", typeof(decimal));
                dtTaxTable.Columns.Add("CGST%", typeof(decimal));
                dtTaxTable.Columns.Add("CGST Tax Value", typeof(decimal));
                udfnDropdownLoad();
                if (pbPurchaseno == "0")
                {
                    cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                }
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    udfnDateset();
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
                    grdTaxDetails.Columns["Taxable Value"].Width = 100;
                    grdTaxDetails.Columns["Tax Value"].Width = 80;
                    udfnEditLoad();
                   
                    if (varCheckButtonFlag==Convert.ToInt16(grdSupplierList.RowCount))
                    { btnselectall.Visible = false; }
                    else { btnselectall.Visible = true; }
                    if (varQueueFlag == 1)
                    {
                        udfnSupplierDetails();
                        cmbConcern.Enabled = false;
                        dpVoucherDate.Enabled = false;
                        txtSupplier.Enabled = false;
                        cmbEntryType.Enabled = false;
                        btnViewDataView.Enabled = false;
                        cmbTransactionType.Enabled = false;
                        grdReurnDC.Columns["clmRemoveDC"].Visible = false;
                        grdPODetails.Columns["clmRemovePO"].Visible = false;
                        if (Convert.ToInt32(cmbEntryType.SelectedValue) != 54 && (Convert.ToInt32(cmbEntryType.SelectedValue) != -1) && varQueueFlag == 1)
                        {
                            MainForm.objPUR_GSTIN = new PUR_GSTIN();
                            MainForm.objPUR_GSTIN.ShowDialog();
                        }
                        this.ActiveControl = txtInvoiceNo;
                    }
                    if (varRemarkCount == 0)
                    {
                        btnRemarks.Enabled = false;
                    }
                    else { btnRemarks.Enabled = true; }
                }
                if (varEntryApprovalNo == "0")
                {
                    //dpPurchaseApprovalVocDate.MinDate = MainForm.pbFYStartDate;
                    dpPurchaseApprovalVocDate.MinDate = DateTime.ParseExact(Convert.ToString(dpVoucherDate.Text), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpPurchaseApprovalVocDate.MaxDate = MainForm.pbCurrentDate;
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
                    varEditFlag = 1;
                    varRemarkFlag = 1;
                    udfnRemark();
                    MainForm.objPUR_PurchaseRemarksHistory.udfnRemarkList();
                    if (varRemarkCount == 0)
                    {
                        btnRemarks.Enabled = false;
                    }
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
                            if (objDs.Tables[0].Rows.Count != 0) //DETAILS LOAD
                            {
                                varEntryApprovalNo = Convert.ToString(objDs.Tables[0].Rows[0]["PurEntryAppNoFlag"]);
                                if (varEntryApprovalNo == "1")
                                {
                                    txtPurApprovalVocNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ApprovalNo"]);
                                    dpPurchaseApprovalVocDate.Enabled = false;
                                }
                                dpPurchaseApprovalVocDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ApprovalDate"]);
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
                                pbConcernTin = Convert.ToInt32(objDs.Tables[0].Rows[0]["Concern_Tin"]);
                                pbSupplierTin = Convert.ToInt32(objDs.Tables[0].Rows[0]["SP_Tin"]);

                                lblDPercentage.Text = "< " + Convert.ToString(objDs.Tables[0].Rows[0]["Level1"]) + "%";
                                varShelflifeLevel1 = Convert.ToInt32(objDs.Tables[0].Rows[0]["Level1"]);
                                lblPercentage.Text = "< " + Convert.ToString(objDs.Tables[0].Rows[0]["Level2"]) + "%";
                                varShelflifeLevel2 = Convert.ToInt32(objDs.Tables[0].Rows[0]["Level2"]);

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
                                txtFrightGrn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_FrieghtChargesGRN"]);
                                txtUnLoadingchargeGrn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_UnloadingChargesGRN"]);
                                txtRemarks.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_Remarks"]); 
                                udfnSupplierDetails();
                                varSupplierType = Convert.ToInt32(objDs.Tables[0].Rows[0]["PUR_SupplierType"]);
                                lv_Broker.Visible = false; 
                                udfnLoadingGrandTotCalculation();
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
                                    //grdPODetails.Visible = false;
                                    //grdReurnDC.Visible = false;
                                }
                                for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                                {
                                    string varMRP = "";
                                    if (Convert.ToString(objDs.Tables[1].Rows[i]["GRNPR_MRP"]) == "0")
                                    {
                                        varMRP = "";
                                    }
                                    else
                                    {
                                        varMRP = Convert.ToString(objDs.Tables[1].Rows[i]["GRNPR_MRP"]);
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
                                    grdSupplierList.Rows.Add(0,grdSupplierList.Rows.Count + 1, Convert.ToString(objDs.Tables[1].Rows[i]["ProductEntryType"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[1].Rows[i]["PTNAME"]), Convert.ToString(objDs.Tables[1].Rows[i]["UNIT"]), varMRP, varMRP, Convert.ToString(objDs.Tables[1].Rows[i]["Product MRP"]), 0,0,
                                    Convert.ToString(varTempExpiryDate),Convert.ToString(objDs.Tables[1].Rows[i]["Product Expiry"]), 0,0, Convert.ToString(objDs.Tables[1].Rows[i]["PRODUCTEXP"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["actuallife"]), Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["Product BatchNo"]), 0,0, Convert.ToString(objDs.Tables[1].Rows[i]["Location"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["RKNAME"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["POID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["BATCHNO"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["Batchnogeneration"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLife"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RackCount"])
                                    , Convert.ToString(objDs.Tables[1].Rows[i]["GRNID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["TotQty"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GRNQty"])
                                    , Convert.ToDecimal(objDs.Tables[1].Rows[i]["DCQty"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["PURPRID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["MRP Flag"]) , Convert.ToInt32(objDs.Tables[1].Rows[i]["ID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["InvFlag"]), Convert.ToString(objDs.Tables[1].Rows[i]["PURPR_HSNID"]),
                                    Convert.ToInt32(objDs.Tables[1].Rows[i]["Error"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["PURPR_EntryApprovalSTSID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GRNAPR_Reason"]));

                                    grdSupplierList.Columns["clmProTname"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    //grdSupplierList.Columns["clmAddPro"].Visible = false;
                                    grdSupplierList.Columns["clmRemove"].Visible = false;
                                    DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                    GrdSupplierList_DataBindingComplete(grdSupplierList, args2); 
                                }
                                lblTpro.Text = Convert.ToString(grdSupplierList.Rows.Count);
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
                                grdTaxDetails.Columns["Taxable Value"].Width = 100;
                                grdTaxDetails.Columns["Tax Value"].Width = 80; 
                            }
                            if (objDs.Tables[3].Rows.Count != 0) //PO DETAILS LOAD
                            {
                                lblPOnorecord.Visible = false;
                                for (int i = 0; i < objDs.Tables[3].Rows.Count; i++)
                                {
                                    grdPODetails.Rows.Add(Convert.ToString(objDs.Tables[3].Rows[i]["PO_No"]), Convert.ToString(objDs.Tables[3].Rows[i]["PO_Date"]),
                                        Convert.ToString(objDs.Tables[3].Rows[i]["POPR_PRID"]), Convert.ToString(objDs.Tables[3].Rows[i]["POID"]));
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
                                grdReurnDC.BringToFront();
                                for (int i = 0; i < objDs.Tables[4].Rows.Count; i++)
                                {
                                    grdDCVerificationDetails.Rows.Clear();
                                    grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[4].Rows[i]["DC_No"]), Convert.ToString(objDs.Tables[4].Rows[i]["DC_DATE"]),
                                        Convert.ToString(objDs.Tables[4].Rows[i]["DCPR_PRID"]), Convert.ToString(objDs.Tables[4].Rows[i]["DCID"]));
                                    pbDCNo = pbDCNo + ',' + Convert.ToString(objDs.Tables[4].Rows[i]["DCID"]);
                                    grdDCVerificationDetails.Rows.Add(Convert.ToString(objDs.Tables[4].Rows[i]["DC_No"]), Convert.ToString(objDs.Tables[4].Rows[i]["DC Verification Details"]));
                                    lblVerifyNorecord.Visible = false;
                                }
                                grdReurnDC.Visible = true;
                                varTypeErrId = Convert.ToString(objDs.Tables[4].Rows[0]["DCID"]);
                            }
                            else
                            {
                                grdReurnDC.Rows.Clear(); 
                            }
                            if (objDs.Tables[5].Rows.Count != 0) //GRN DETAILS LOAD
                            {
                                lblFinishedNoRecord.Visible = false;
                                grdGRN.BringToFront();
                                for (int i = 0; i < objDs.Tables[5].Rows.Count; i++)
                                {
                                    grdGRN.Rows.Add(Convert.ToString(objDs.Tables[5].Rows[i]["GRN_Date"]), Convert.ToString(objDs.Tables[5].Rows[i]["GRN_No"]),
                                        Convert.ToString(objDs.Tables[5].Rows[i]["GRNPR_PRID"]), Convert.ToString(objDs.Tables[5].Rows[i]["GRNID"]));
                                }
                                txtQRCode.Text = Convert.ToString(objDs.Tables[5].Rows[0]["GRN Code"]);
                                grdGRN.Visible = true;
                                varTypeErrId = Convert.ToString(objDs.Tables[5].Rows[0]["GRNID"]);
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
                                varPurEditFlag = Convert.ToInt32(objDs.Tables[8].Rows[0]["Flag"]);
                            }
                            if (objDs.Tables.Count > 8)
                            {
                                if (objDs.Tables[9].Rows.Count != 0)
                                {
                                    lblPurchaseVerification.Text = Convert.ToString(objDs.Tables[9].Rows[0]["Purchase Verification Details"]);
                                    lblPurchaseVerification2.Text = Convert.ToString(objDs.Tables[9].Rows[0]["Purchase Verification Details2"]);
                                }
                            }
                        }
                    }
                    udfnPurchaseEntryTabLoad();
                    DataGridViewBindingCompleteEventArgs args3 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                    GrdPurchaseList_DataBindingComplete(grdPurchaseList, args3);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //if (grdSupplierList.Rows.Count > 0)
                //{
                //    grdSupplierList.CurrentCell = grdSupplierList[5, 0];
                //}
                //if (grdPurchaseList.Rows.Count > 0)
                //{
                //    grdPurchaseList.CurrentCell = grdSupplierList[10, 0];
                //}
            }
        }
        public void udfndisablevalue()
        {
            try
            {
                cmbConcern.Enabled = false;
                dpVoucherDate.Enabled = false;
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
                if (PbSTS == "50" || varPurEditFlag==1)  
                {
                    tbDetails.TabPages[0].Enabled = true;
                    tbDetails.TabPages[1].Enabled = true;
                    gpdiscount.Enabled = false;
                    gpPayment.Enabled = false;
                    //grpLoadingCharge.Enabled = false;
                    //grpTCSamt.Enabled = false;
                    gpPurchase.Enabled = false;
                    //grdSupplierList.ReadOnly = true;
                    grdSupplierList.Columns["clmsno"].ReadOnly = true;
                    grdSupplierList.Columns["clmPono"].ReadOnly = true;
                    grdSupplierList.Columns["clmPicode"].ReadOnly = true;
                    grdSupplierList.Columns["clmProTname"].ReadOnly = true;
                    grdSupplierList.Columns["clmUnit"].ReadOnly = true;
                    grdSupplierList.Columns["clmGrnMrp"].ReadOnly = true;
                    grdSupplierList.Columns["clmMRP"].ReadOnly = true;
                    grdSupplierList.Columns["clmMRPError"].ReadOnly = true;
                    grdSupplierList.Columns["clmexpirydate"].ReadOnly = true;
                    grdSupplierList.Columns["clmExpiryDateError"].ReadOnly = true;
                    grdSupplierList.Columns["clmShelflife"].ReadOnly = true;
                    grdSupplierList.Columns["clmactuallife"].ReadOnly = true;
                    grdSupplierList.Columns["clmshelfper"].ReadOnly = true;
                    grdSupplierList.Columns["clmBatchno"].ReadOnly = true;
                    grdSupplierList.Columns["clmBatchError"].ReadOnly = true;
                    grdSupplierList.Columns["clmLocation"].ReadOnly = true;
                    grdSupplierList.Columns["clmrack"].ReadOnly = true;
                    //grdSupplierList.Columns["clmCheck"].ReadOnly = false;
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
                objDT = objdserv.udfnPOEntry(5, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, "", "", 0, 0, pbPONO, 0, 0, 0, 0, 0, Convert.ToInt32(pbGRNId),0);
                objdserv.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { //pbPONO = "0";
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
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (0,17) AND MSTID<>0 ORDER BY MST_DisplayText desc", "MST_DisplayText,MSTID", cmbEntryType, "", "MST_DisplayText", "MSTID");
            objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID in (18) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
            objDataBind = null; //id
            if (PbFlag == "1")
            {
                cmbEntryType.SelectedValue = "54"; //grn
                pbGRNNo = PbID;
                varTypeErrId = PbID;
                udfnGRNDCDetailsLoadQueue();
                udfnGRNProload();
                txtQRCode.ReadOnly = false;
                //dpInvoiceDate.Enabled = false;
                //txtInvoiceNo.ReadOnly = true;
                //txtInvoiceNo.Enabled = false;
                grdPODetails.Visible = true;
                //grdReurnDC.Visible = false;
            }
            else if (PbFlag == "2")
            {
                cmbEntryType.SelectedValue = "57"; //return dc
                pbDCNo = PbID;
                varTypeErrId = PbID;
                udfnGRNDCDetailsLoadQueue();
                udfnDefReturnDc();
              //  grdPODetails.Visible = false;
                grdReurnDC.Visible = true;
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
                    if (objDs.Tables[0].Rows.Count != 0) // GRN PO DETAILS LOAD
                    {
                        grdPODetails.Rows.Clear();
                        lblFinishedNoRecord.Visible = false;
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            grdPODetails.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["PO_No"]), Convert.ToString(objDs.Tables[0].Rows[i]["PO_Date"]),
                                Convert.ToString(objDs.Tables[0].Rows[i]["POPR_PRID"]), Convert.ToString(objDs.Tables[0].Rows[i]["POID"]));
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
                            lblNoRecordsFound.Visible = false;
                            grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["DCNo"]), Convert.ToString(objDs.Tables[1].Rows[i]["DCDate"]),
                                Convert.ToString(objDs.Tables[1].Rows[i]["T.PRO"]), Convert.ToString(objDs.Tables[1].Rows[i]["ID"])
                            );
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
                            lblPOnorecord.Visible = false;
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
                dpVoucherDate.MinDate = varmindate;
                dpInvoiceDate.MaxDate = varmaxdate;
                dpVoucherDate.MaxDate = varmaxdate;
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
                    udfnclose();
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

                  //  udfnPurchaseEntryTabLoad(); //tab2 load
                }
                else
                {
                    if (pbPurchaseno == "0")
                    {
                        tbDetails.TabPages[0].Enabled = true; // First tab 
                        tbDetails.TabPages[1].Enabled = false; // Second tab 
                                                               //if (PbSTS == "49")
                                                               //{
                                                               //    udfnPurchaseEntryTabLoad(); //tab2 load
                                                               //}
                    }
                    else
                    {
                        //tbDetails.TabPages[0].Enabled = false; // First tab 
                        // tbDetails.TabPages[1].Enabled = true; // Second tab  
                        //udfnPurchaseEntryTabLoad(); //tab2 load
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
                MainForm.objPUR_ApprovalCalculator = new PUR_ApprovalCalculator();
                MainForm.objPUR_ApprovalCalculator.PbValue = Varvalue;
                MainForm.objPUR_ApprovalCalculator.ShowDialog();
                varPurchaseRate = varCalculator;
                grdPurchaseList.Rows[varRow].Cells[varColumn].Value = Convert.ToString(varPurchaseRate);


                decimal varInvQty = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmInvQty"].Value)) != "") { varInvQty = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmInvQty"].Value); }
                decimal varRecQty = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmRecqty"].Value)) != "") { varRecQty = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmRecqty"].Value); }
                decimal varDiffQty = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmDiffqty"].Value)) != "") { varDiffQty = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmDiffqty"].Value); }
                decimal varFreeQty = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmFreeqty"].Value)) != "") { varFreeQty = Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmFreeqty"].Value); }
                decimal varPurRate = 0; if (Convert.ToString((grdPurchaseList.CurrentRow.Cells["clmPurchaseRate"].Value)) != "")
                {
                    string mrp = string.Format("{0:0.000}", Math.Round(Convert.ToDecimal(grdPurchaseList.CurrentRow.Cells["clmPurchaseRate"].Value), 3, MidpointRounding.AwayFromZero));
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
                //grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Value = PbDiscamt.ToString("0.00");
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
                if (e.KeyCode == Keys.F4)
                {
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmPurchaseRate")
                    {
                        udfnCalculator();
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
            if (this.grdSupplierList.Columns[e.ColumnIndex].Name == "clmExpDate")
            {
                ShortFormDateFormat(e);
            }
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
                    if (Convert.ToInt32(lblSupplierCode.Text.Trim()) != 0 && Convert.ToInt32(lblschedule.Text.Trim()) != 0 &&  (Convert.ToInt32(cmbEntryType.SelectedValue) != 54) && (Convert.ToInt32(cmbEntryType.SelectedValue) != -1))
                    {
                        MainForm.objPUR_GSTIN = new PUR_GSTIN();
                        //MainForm.objPUR_GSTIN.txtGstin.Text = txtGstin.Text.Trim();
                        MainForm.objPUR_GSTIN.ShowDialog();
                    }
                    cmbEntryType.Focus();
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
        private void CmbEntryType_Leave(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(cmbEntryType.SelectedValue)==-1)
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
        private void CmbEntryType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
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
        public AutoCompleteStringCollection AutoCompleteLocationName(int varCOMID)
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();
            if (varCOMID == 0)
            {
                objds = objdservice.GetDataset("SELECT SLID,SL_EName FROM MR_StockLocation WHERE SLID NOT IN (-1,0) AND SL_STSID=1");
            }
            else
            {
                objds = objdservice.GetDataset("SELECT SLID,SL_EName FROM MR_StockLocation WHERE SL_STSID=1 AND SL_COMID=" + varCOMID);
            }
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
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable(); objds = objdservice.GetDataset("SELECT RKID,RK_ShortName FROM MR_Rack WHERE RKID NOT IN (-1,0) AND  RK_STSID=1 AND RK_SLID = " + varSLID);
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
                        //int varPRID = Convert.ToInt16(grdLoction.CurrentRow.Cells["PRID"].Value);
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
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmBatchno" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmMRP" || grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate")
                {
                    e.Control.KeyPress -= udfnHandleKeyPressGRD1;
                    e.Control.KeyPress += udfnHandleKeyPressGRD1;
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
                            //only allow one decimal point
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
                        //only allow one decimal point
                        if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                        {
                            e.Handled = true;
                        }
                    }
                    //if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer")
                    //{
                    //    if (e.KeyChar == (char)Keys.F4)
                    //    {
                    //        e.Handled = false;
                    //    }
                    //}
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
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmMRP")
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
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmBatchno")
                {
                    TextBox vartb = sender as TextBox;
                    if (vartb.Text.Length >= 10 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate")
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
                //if (Convert.ToString(lblSupplierCode.Text) != "0")
                //{
                //    VarGridError = "0";
                //    DataGridView dataGridView = (DataGridView)sender;
                //    DataGridViewCell cellSlname = dataGridView.Rows[e.RowIndex].Cells["clmLocation"];
                //    DataGridViewCell cellSlid = dataGridView.Rows[e.RowIndex].Cells["slid"];
                //    DataGridViewCell cellRkname = dataGridView.Rows[e.RowIndex].Cells["clmrack"];
                //    DataGridViewCell cellRkid = dataGridView.Rows[e.RowIndex].Cells["rkid"];
                //    DataGridViewCell cellRkcount = dataGridView.Rows[e.RowIndex].Cells["clmrkcount"];
                //    if (e.ColumnIndex == grdSupplierList.Columns["clmLocation"].Index && e.RowIndex >= 0)
                //    {
                //        string SelectedLocationName = grdSupplierList.Rows[e.RowIndex].Cells["clmLocation"].Value?.ToString();
                //        if (!string.IsNullOrEmpty(SelectedLocationName))
                //        {
                //            /* Check purchase location is valid or not*/
                //            string varId_PurLocation = "0", varRkCount = "0";
                //            DataSet objDsPurLoc = new DataSet();
                //            SPDataService objDServ3 = new SPDataService();
                //            objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, SelectedLocationName, 0, 0, 0, "", "", 0);
                //            objDServ3.CloseConnection();
                //            if (objDsPurLoc != null)
                //            {
                //                if (objDsPurLoc.Tables.Count > 0)
                //                {
                //                    if (objDsPurLoc.Tables[0].Rows.Count > 0)
                //                    {
                //                        varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                //                    }
                //                }
                //                if (objDsPurLoc.Tables[1].Rows.Count > 0)
                //                {
                //                    varRkCount = Convert.ToString(objDsPurLoc.Tables[1].Rows[0][0]);
                //                }
                //            }
                //            if (varRkCount == "0")
                //            {
                //                cellRkid.Value = varRkCount;
                //                cellRkname.Value = "None";
                //                cellRkcount.Value = 0;
                //                cellRkname.ReadOnly = true; cellRkname.Style.BackColor = Color.LightGray;
                //            }
                //            else
                //            {
                //                cellRkid.Value = "-1";
                //                cellRkname.Value = "";
                //                cellRkcount.Value = 0;
                //                cellRkname.ReadOnly = false; cellRkname.Style.BackColor = Color.PaleGreen;
                //            }
                //            if (varId_PurLocation != "-1")
                //            {
                //                cellSlname.Style.BackColor = Color.PaleGreen;
                //                cellSlid.Value = Convert.ToString(varId_PurLocation);
                //            }
                //            else
                //            {
                //                cellSlname.Style.BackColor = Color.LightPink;
                //                cellSlid.Value = Convert.ToString(varId_PurLocation);
                //                VarGridError = "1";
                //            }
                //        }
                //    }
                //    else if (e.ColumnIndex == grdSupplierList.Columns["clmRack"].Index && e.RowIndex >= 0)
                //    {
                //        if (Convert.ToString(cellSlid.Value) != "-1")
                //        {
                //            string SelectedRackName = grdSupplierList.Rows[e.RowIndex].Cells["clmRack"].Value?.ToString().Trim();
                //            if (!string.IsNullOrEmpty(SelectedRackName))
                //            {
                //                /*check location have a rack or not*/
                //                string varId_PurchaseRack = "0";
                //                DataSet objDsPurchaseRack = new DataSet();
                //                SPDataService objDServ6 = new SPDataService();
                //                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(cellSlid.Value), 0, SelectedRackName, 0, 0);
                //                objDServ6.CloseConnection();
                //                if (objDsPurchaseRack != null)
                //                {
                //                    if (objDsPurchaseRack.Tables.Count > 0)
                //                    {
                //                        if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                //                        {
                //                            varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                //                        }
                //                    }
                //                }
                //                if (varId_PurchaseRack != "-1")
                //                {
                //                    //if (varId_PurchaseRack != "0")
                //                    //{
                //                    //    cellRkname.Style.BackColor = Color.LightGray;
                //                    //    cellRkname.ReadOnly = true;
                //                    //}
                //                    //else
                //                    //{
                //                    cellRkname.Style.BackColor = Color.PaleGreen;
                //                    //}
                //                    cellRkid.Value = Convert.ToString(varId_PurchaseRack);
                //                }
                //                else
                //                {
                //                    cellRkname.Style.BackColor = Color.LightPink;
                //                    cellRkid.Value = Convert.ToString(varId_PurchaseRack);
                //                    VarGridError = "1";
                //                }
                //            }

                //        }
                //    }
                //}
                if (grdSupplierList.Rows.Count > 0) 
                {
                    if (Convert.ToBoolean(grdSupplierList.Rows[e.RowIndex].Cells["clmcheck"].Value) == true)
                    {
                        varCheckCount++;
                    }
                    else if (Convert.ToBoolean(grdSupplierList.Rows[e.RowIndex].Cells["clmcheck"].Value) == false)
                    {
                        varCheckCount--;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
        private void GrdSupplierList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                //varErrorFormat = 0;
                //if (skipValidation == false)
                //{
                //    if (grdSupplierList.Columns[e.ColumnIndex].Name == "clmexpirydate")
                //    {
                //        string dateString = e.FormattedValue.ToString();
                //        if (dateString.Length != 10 && dateString != "")
                //        {
                //            varErrorFormat = 1;
                //            MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            e.Cancel = true;
                //        }
                //        else
                //        {
                //            if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmShelflifeenable"].Value) == "1" || dateString != "")
                //            {
                //                varExpiryDate = "";
                //                DataSet objDS = new DataSet();
                //                SPDataService objDServ = new SPDataService();
                //                objDS = objDServ.udfnMaster(8, 0, 0, dateString, "", 0, "", 0);
                //                objDServ.CloseConnection();
                //                if (objDS.Tables[0].Rows.Count > 0)
                //                {
                //                    if (Convert.ToString(objDS.Tables[0].Rows[0]["DATE"]) == "0")
                //                    {
                //                        varErrorFormat = 1;
                //                        MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //                        e.Cancel = true;
                //                    }
                //                    else
                //                    {
                //                        varExpiryDate = e.FormattedValue.ToString();
                //                    }
                //                }
                //            }
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


        private void GrdSupplierList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (varErrorFormat == 0)
                {
                    //udfnGridaddvalue(sender, e);
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmmrp")
                {
                    decimal varMRP = Convert.ToDecimal(grdSupplierList.CurrentRow.Cells["clmmrp"].Value);
                    string mrp = string.Format("{0:0.00}", varMRP);
                    string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                    grdSupplierList.Rows[e.RowIndex].Cells["clmmrp"].Value = mrp;
                }
                if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmInvoiceQty")
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
                    //udfnGridaddvalue( sender,value);
                }
                /*
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmExcessQty")
                {
                    decimal ExcessQty = Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmExcessQty"].Value);
                    if (Convert.ToString(ExcessQty) == "0" || Convert.ToString(ExcessQty) == "")
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrQty = "1";
                    }
                    else
                    {
                        grdGrnlist.CurrentRow.Cells["clmExcessQty"].Style.BackColor = Color.PaleGreen;
                        varErrQty = "0";
                    }

                    int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Value), varDecimal);
                    grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Value = Qty;
                    //udfnGridaddvalue( sender,value);
                }
                */
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
                                        string varMessage = objdServ.udfnGetMessages(95);
                                        objdServ.CloseConnection();
                                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                    }
                                    else
                                    {
                                        if (varErrorFormat != 5)
                                        {
                                            grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter expirydate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
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
                    //varTempDay = DMY[0];
                    //varTempMonth = DMY[1];
                    varTempExpiryDate = cellValue.ToString();
                }
                varProid = Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["clmProid"].Value);
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 10;
                objMR_Master.paraDate = dpVoucherDate.Text.Trim();
                objMR_Master.ParaExpiryDate = varTempExpiryDate;
                objMR_Master.paraProductId = varProid;
                objDS = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                {
                    varShelflife = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmShelflifeenable"].Value);
                    pbDateflag = 0;
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
                                                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                                                    {
                                                        varErrorFormat = 5;
                                                        grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                                        string varMessage = objDServ.udfnGetMessages(98);
                                                        objDServ.CloseConnection();
                                                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }
                                                }
                                                else
                                                {
                                                    grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
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
                            if (varTempExpiryDate != "")
                            {
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                                {
                                    varErroronGrid = 1;
                                    grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
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
                                //grdSupplierList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                DataGridViewCell cell = dataGridView.Rows[i].Cells["clmmrp"];
                                DataGridViewCell cell1 = dataGridView.Rows[i].Cells["clmexpirydate"];
                                DataGridViewCell cell2 = dataGridView.Rows[i].Cells["clmBatchno"];
                                //DataGridViewCell cell3 = dataGridView.Rows[i].Cells["clmInvoiceQty"];
                                cell.Style.BackColor = Color.PaleGreen;
                                cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                cell1.Style.BackColor = Color.PaleGreen;
                                cell1.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                cell2.Style.BackColor = Color.PaleGreen;
                                cell2.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                //cell3.Style.BackColor = Color.PaleGreen;
                                //cell3.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "72" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "74")
                                {
                                    cell2.Style.BackColor = Color.LightGray;
                                    cell2.Style.ForeColor = Color.Black;
                                    cell2.ReadOnly = true;
                                }
                                else if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "73")
                                {
                                    cell2.Style.BackColor = Color.LightGray;
                                    cell2.Style.ForeColor = Color.Black;
                                    cell2.ReadOnly = true;
                                }
                                else
                                {
                                    cell2.Style.BackColor = Color.PaleGreen;
                                    cell2.Style.ForeColor = Color.Black;
                                }
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
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    //string varshelflife = "";
            //    //SPDataService objdserv = new SPDataService();
            //    //DataSet objDs = new DataSet();
            //    //int varCellprodid = 0;
            //    //if (grdSupplierList.Columns[e.ColumnIndex].Name == "clmexpirydate")
            //    //{
            //    //    varCellprodid = Convert.ToInt32(grdSupplierList.Rows[e.RowIndex].Cells["clmProid"].Value);
            //    //    int rowIndex = e.RowIndex;
            //    //    int columnIndex = e.ColumnIndex;
            //    //    if (rowIndex >= 0 && columnIndex >= 0)
            //    //    {
            //    //        object cellValue = grdSupplierList.Rows[rowIndex].Cells[columnIndex].Value;
            //    //        if (cellValue != null && Convert.ToString(cellValue) != "")
            //    //        {
            //    //            varshelflife = cellValue.ToString();
            //    //            if (varshelflife != "" || varshelflife != null)
            //    //                objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, dpVoucherDate.Text, varCellprodid, 0, "0","");
            //    //            objdserv.CloseConnection();
            //    //            if (objDs != null)
            //    //            {
            //    //                if (objDs.Tables[0].Rows.Count > 0)
            //    //                {
            //    //                    grdSupplierList.Rows[rowIndex].Cells["clmshelfper"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
            //    //                }
            //    //                if (objDs.Tables[1].Rows.Count > 0)
            //    //                {
            //    //                    grdSupplierList.Rows[rowIndex].Cells["clmactuallife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
            //    //                }

            //    //                string[] varShelflifevalue = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]).Split(' ');
            //    //                if (varShelflifevalue[0] != "")
            //    //                {
            //    //                    if (Convert.ToDecimal(varShelflifevalue[0]) < 25)
            //    //                    {
            //    //                        DataGridView dataGridView = grdSupplierList;
            //    //                        DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
            //    //                        cell.Style.BackColor = Color.Red;
            //    //                        cell.Style.ForeColor = Color.White;

            //    //                    }
            //    //                    else if (Convert.ToDecimal(varShelflifevalue[0]) < 50)
            //    //                    {
            //    //                        DataGridView dataGridView = grdSupplierList;
            //    //                        DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
            //    //                        cell.Style.BackColor = Color.Orange;
            //    //                        cell.Style.ForeColor = Color.Black;
            //    //                    }

            //    //                    else
            //    //                    {
            //    //                        DataGridView dataGridView = grdSupplierList;
            //    //                        DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
            //    //                        cell.Style.BackColor = Color.White;
            //    //                        cell.Style.ForeColor = Color.Black;
            //    //                    }
            //    //                }
            //    //            }
            //    //        }
            //    //    }
            //    //}
            //    string varshelflife = "";
            //    SPDataService objdserv = new SPDataService();
            //    DataSet objDs = new DataSet();
            //    int varCellprodid = 0;
            //    if (grdSupplierList.Columns[e.ColumnIndex].Name == "clmexpirydate")
            //    {
            //        int rowIndex = e.RowIndex;
            //        int columnIndex = e.ColumnIndex;
            //        if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmexpirydate"].Value) != "")
            //        {
            //            varCellprodid = Convert.ToInt32(grdSupplierList.Rows[e.RowIndex].Cells["clmProid"].Value);
            //            if (rowIndex >= 0 && columnIndex >= 0)
            //            {
            //                string varTempYear = "0";
            //                object cellValue = grdSupplierList.Rows[rowIndex].Cells[columnIndex].Value;
            //                string varExpiryDate = "";
            //                varExpiryDate = cellValue.ToString();
            //                string[] DMY = varExpiryDate.Split('/');
            //                if (DMY.Count() == 3)
            //                {
            //                    varTempYear = DMY[2];
            //                    if (varTempYear.Length == 2)
            //                    {
            //                        cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
            //                    }
            //                }
            //                //varTempDay = DMY[0];
            //                //varTempMonth = DMY[1];
            //                varTempExpiryDate = cellValue.ToString();
            //                if (cellValue != null && Convert.ToString(cellValue) != "")
            //                {
            //                    varshelflife = cellValue.ToString();
            //                    if (varshelflife != "" || varshelflife != null)
            //                        objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, dpInvoiceDate.Text, varCellprodid, 0, "0", "");
            //                    objdserv.CloseConnection();
            //                    if (objDs != null)
            //                    {
            //                        if (objDs.Tables[0].Rows.Count != 0)
            //                        {
            //                            if (objDs.Tables[0].Rows.Count > 0)
            //                            {
            //                                grdSupplierList.Rows[rowIndex].Cells["clmshelfper"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
            //                            }
            //                        }
            //                        if (objDs.Tables[1].Rows.Count > 0)
            //                        {
            //                            grdSupplierList.Rows[rowIndex].Cells["clmactuallife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
            //                        }

            //                        string[] varShelflifevalue = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]).Split(' ');
            //                        if (varShelflifevalue[0] != "")
            //                        {
            //                            if (Convert.ToDecimal(varShelflifevalue[0]) < 25)
            //                            {
            //                                DataGridView dataGridView = grdSupplierList;
            //                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
            //                                cell.Style.BackColor = Color.Red;
            //                                cell.Style.ForeColor = Color.White;

            //                            }
            //                            else if (Convert.ToDecimal(varShelflifevalue[0]) < 50)
            //                            {
            //                                DataGridView dataGridView = grdSupplierList;
            //                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
            //                                cell.Style.BackColor = Color.Orange;
            //                                cell.Style.ForeColor = Color.Black;
            //                            }

            //                            else
            //                            {
            //                                DataGridView dataGridView = grdSupplierList;
            //                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
            //                                cell.Style.BackColor = Color.White;
            //                                cell.Style.ForeColor = Color.Black;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            grdSupplierList.Rows[rowIndex].Cells["clmactuallife"].Value = "";
            //            DataGridView dataGridView = grdSupplierList;
            //            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
            //            cell.Style.BackColor = Color.White;
            //            cell.Style.ForeColor = Color.Black;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            try
            {
                if (PbSTS == "49" || pbPurchaseno=="0")
                {
                    string varshelflife = "";
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    int varCellprodid = 0;
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
                                if (DMY.Count() == 3)
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
                                //varTempDay = DMY[0];
                                //varTempMonth = DMY[1];
                                varTempExpiryDate = cellValue.ToString();
                                if (cellValue != null && Convert.ToString(cellValue) != "")
                                {
                                    varshelflife = cellValue.ToString();
                                    if (varshelflife != "" || varshelflife != null)
                                        objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, dpVoucherDate.Text, varCellprodid, 0, "0", "","", 0, 0, 0, 0);
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
                                            //Shelflife Wise Color Set
                                            if (Convert.ToDecimal(varShelflifevalue[0]) <= varShelflifeLevel1)
                                            {
                                                DataGridView dataGridView = grdSupplierList;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                                cell.Style.BackColor = Color.Red;
                                                cell.Style.ForeColor = Color.White;
                                            }
                                            else if (Convert.ToDecimal(varShelflifevalue[0]) > varShelflifeLevel1 && Convert.ToDecimal(varShelflifevalue[0]) < varShelflifeLevel2)
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
                            grdSupplierList.Rows[e.RowIndex].Cells["clmexpirydate"].Value = varTempExpiryDate;
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
               // udfnSave(sender, e);
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
                                    varRoundoff = 0, varTotal = 0, varAdditionalValue=0, varDiscountValue=0;
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
                varAdditionalValue = varloadcharge + varUnloadcharge + varCouriercharge + varOtherexpense + varTcsamt ;
                varDiscountValue = varDiscountamt + varOtherdiscount + varDamagecost;
                varGrandTot = varTotal + varAdditionalValue - varDiscountValue;
                lblAdditionalValue.Text= varAdditionalValue.ToString("#,##0.00");
                lblDiscount.Text= varDiscountValue.ToString("#,##0.00");

                lblGrandTotal.Text = Math.Round(varGrandTot).ToString("#,##0.00");
                lblRoundoff.Text = Convert.ToString(Convert.ToDecimal(lblGrandTotal.Text) - (varTotal + varAdditionalValue - varDiscountValue));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    if (PbSTS == "50")
                    {
                        tbDetails.TabPages[0].Enabled = true; // First tab 
                        tbDetails.TabPages[1].Enabled = true; // Second tab
                        grdPurchaseList.ReadOnly = false; 
                        grdSupplierList.Columns["clmsno"].ReadOnly = true;
                        grdSupplierList.Columns["clmPono"].ReadOnly = true;
                        grdSupplierList.Columns["clmPicode"].ReadOnly = true;
                        grdSupplierList.Columns["clmProTname"].ReadOnly = true;
                        grdSupplierList.Columns["clmUnit"].ReadOnly = true;
                        grdSupplierList.Columns["clmGrnMrp"].ReadOnly = true;
                        grdSupplierList.Columns["clmMRP"].ReadOnly = true;
                        grdSupplierList.Columns["clmMRPError"].ReadOnly = true;
                        grdSupplierList.Columns["clmexpirydate"].ReadOnly = true;
                        grdSupplierList.Columns["clmExpiryDateError"].ReadOnly = true;
                        grdSupplierList.Columns["clmShelflife"].ReadOnly = true;
                        grdSupplierList.Columns["clmactuallife"].ReadOnly = true;
                        grdSupplierList.Columns["clmshelfper"].ReadOnly = true;
                        grdSupplierList.Columns["clmBatchno"].ReadOnly = true;
                        grdSupplierList.Columns["clmBatchError"].ReadOnly = true;
                        grdSupplierList.Columns["clmLocation"].ReadOnly = true;
                        grdSupplierList.Columns["clmrack"].ReadOnly = true; 
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
                        string varQty = "";
                        decimal varInvQty = 0;
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                            {
                                varQty = Convert.ToString(objDs.Tables[0].Rows[i]["QTY"]);
                            }
                            grdPurchaseList.Rows.Add(grdPurchaseList.Rows.Count + 1, "None", Convert.ToString(objDs.Tables[0].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_InvoiceMRP"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_ExpiryDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_Batch"]), Convert.ToString(objDs.Tables[0].Rows[i]["SL_EName"]), Convert.ToString(objDs.Tables[0].Rows[i]["RK_ShortName"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["HSN_Name"]), Convert.ToString(objDs.Tables[0].Rows[i]["HSN_Code"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["GST_Text"]), varQty, Convert.ToString(objDs.Tables[0].Rows[i]["INVQTY"]), Convert.ToString(objDs.Tables[0].Rows[i]["RecivedQty"]), Convert.ToString(objDs.Tables[0].Rows[i]["diffqty"]), Convert.ToString(objDs.Tables[0].Rows[i]["freeqty"])
                             , Convert.ToString(objDs.Tables[0].Rows[i]["Unit"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_PurchaseRate"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_DiscAmnt"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_DiscPer"])
                            , Convert.ToString(objDs.Tables[0].Rows[i]["TAX"]), Convert.ToString(objDs.Tables[0].Rows[i]["Gstper"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_GSTAmnt"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_CGSTPer"]), Convert.ToString(objDs.Tables[0].Rows[i]["CGSTAmnt"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_SGSTPer"]), Convert.ToString(objDs.Tables[0].Rows[i]["SGSTAmnt"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_IGSTPer"]), Convert.ToString(objDs.Tables[0].Rows[i]["IGSTAmnt"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["DiscountValue"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_NettAmnt"])
                            , Convert.ToString(objDs.Tables[0].Rows[i]["ID"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[0].Rows[i]["HSNID"]), Convert.ToString(objDs.Tables[0].Rows[i]["Gst value"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_SLID"]), Convert.ToString(objDs.Tables[0].Rows[i]["PURPR_RKID"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["PURPRID"]), Convert.ToString(objDs.Tables[0].Rows[i]["MST_DisplayText"]), 
                            Convert.ToString(objDs.Tables[0].Rows[i]["DC Qty"]), Convert.ToString(objDs.Tables[0].Rows[i]["Inv Flag"]),Convert.ToString(objDs.Tables[0].Rows[i]["Costing"]),
                            0,0,0,0,0,0, Convert.ToString(objDs.Tables[0].Rows[i]["GRN ProType"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["Error"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["PURPR_EntryApprovalSTSID"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["GRNAPR_Reason"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["PURPR_Parent_PURPRID"]));
                            if (Convert.ToString(objDs.Tables[0].Rows[i]["INVQTY"]) != "")
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
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmGRNProType"].Value) == "226")
                            {
                                grdPurchaseList.Rows[i].ReadOnly = true;
                                grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = Color.LightGray;
                                grdPurchaseList.Rows[i].Cells["clmFreeqty"].Style.BackColor = Color.LightGray;
                                grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.LightGray;
                                grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Style.BackColor = Color.LightGray;
                                grdPurchaseList.Rows[i].Cells["clmDiscPer"].Style.BackColor = Color.LightGray;
                                grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.LightGray;
                            }
                        }
                        grdPurchaseList.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                        lblTpro.Text = Convert.ToString(grdPurchaseList.RowCount) + " / " + Convert.ToString(varInvQty);
                    }
                    if(varSupplierType==151)  //Supplier type IGST
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
            varDiscountErr = 0; varcount = 0;
            DataTable objPurchaseentryApprovalError = new DataTable();
            try
            {
                if (pbPurchaseno != "0")
                {
                    objPurchaseentryApprovalError.TableName = "TRN_Purchase_Products";
                    objPurchaseentryApprovalError.Columns.Add("PURPR_PURID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_PRID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_UTID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_GRNMRP", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_InvoiceMRP", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ExpiryDate", typeof(string));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_Batch", typeof(string));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_SLID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_RKID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_HSNID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_PurchaseRate", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_POQty", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_InvoiceQty", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ReceivedQty", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_DiffQty", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_FreeQty", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_DiscPer", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_DiscAmnt", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_TaxableValue", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_GSTPer", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_GSTAmnt", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_NettAmnt", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_Costing", typeof(decimal));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLife", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLifeValue", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLifePer", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_Error", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_POID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_BatchNoStatus", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_BatchNoGenration", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLife_Flag", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLifeStatus", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_TOTQTY", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_GRNQTY", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_DCQTY", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPRID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("ID", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_DiscountValue", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_CGSTPer", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_CGSTAmnt", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_SGSTPer", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_SGSTAmnt", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ISGSTPer", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_IGSTAmnt", typeof(float));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_InvoiceMRPErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_PurchaseRateErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ExpiryDateErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_BatchErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_InvoiceQtyErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ReceivedQtyErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_FreeQtyErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_DiscAmntErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_DiscPerErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ApprovalSts", typeof(int));  
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ProMRPErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ProBatchErr", typeof(int));
                    objPurchaseentryApprovalError.Columns.Add("PURPR_ProExpiryDateErr", typeof(int));

                    if (grdPurchaseList.Rows.Count != 0)
                    {
                        for (int i = 0; i < grdPurchaseList.Rows.Count; i++)
                        {
                            string varZero = "0";
                            int varDecimal = Convert.ToInt32(grdPurchaseList.Rows[i].Cells["UT_Decimal"].Value);
                            varZero = 0 + objValidation.udfnDecimal(Convert.ToString(varZero), varDecimal);
                            if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmGRNProType"].Value) != "226")  //Product not received
                            {
                                if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmParentFlag"].Value) == "0")
                                {
                                    if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value) == "" || Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value) == 0)
                                    {
                                        varcount++;
                                        varcount1++;
                                        grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = Color.LightPink;
                                        grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.ForeColor = Color.Black;
                                    }  
                                    if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value) == "" || Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value) == 0 || Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value) == varZero)
                                    {
                                        varcount++;
                                        varcount1++;
                                        grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.LightPink;
                                        grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                        grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.PaleGreen;
                                    }
                                } 
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
                            int varutid = 0, varSlid = 0, varRkid = 0, varHsnId = 0, varShelfLife = 0, varShelfLifeValue = 0, varError = 0, varPoid = 0, varBatchNoStatus = 0, varBatchNoGeneration = 0, varShelfLifeFlag = 0, varShelfLifeStatus = 0, varPURPR_ID = 0, varPURPRID = 0, varID = 0, 
                                 varMRPerr = 0, varPurchaseRateErr = 0, varExpiryErr = 0, varBatchErr = 0,varInvoiceQtyErr = 0, varReceivedQtyErr = 0, varFreeQtyErr = 0, 
                                 varDisAmtErr = 0, varDisPerErr = 0 , varPURID=0 , varPRID=0, varcheck = 0, varProMRPErr = 0 , varProExpiryErr = 0 , varProBatchErr=0;
                            decimal varGrnMrp = 0, varInvoiceMrp = 0, varPurchaseRate = 0, varPoqty = 0, varInvoiceqty = 0, varReceivedqty = 0, varDiffQty = 0, varFreeqty = 0,
                                varDisPer = 0, varDisAmt = 0, varTaxValue = 0, varGSTper = 0, varGSTAmt = 0, varNetAmt = 0, varCosting = 0, varShelfLifePer = 0, varTotqty = 0, varGRNqty = 0, varDCqty = 0,
                                varDiscountValue = 0, varCGSTPer = 0, varCGSTAmnt = 0, varSGSTPer = 0, varSGSTAmnt = 0, varISGSTPer = 0, varIGSTAmnt = 0;
                            string varExpiryDate = "", varBatch = ""; 
                            varPURPRID = Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmPURPRID"].Value);
                            varPRID = Convert.ToInt32(grdPurchaseList.Rows[i].Cells["proid"].Value);

                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value)) != "")
                            {    varPurchaseRate = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmDiscPer"].Value)) != "")
                            {   varDisPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscPer"].Value);  }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Value)) != "")
                            {   varDisAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscAmt"].Value);  }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmTax"].Value)) != "")
                            {   varTaxValue = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmTax"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmGstper"].Value)) != "")
                            { varGSTper = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmGstper"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmGstamt"].Value)) != "")
                            { varGSTAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmGstamt"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmCGST"].Value)) != "")
                            { varCGSTPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGST"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmCGSTamt"].Value)) != "")
                            { varCGSTAmnt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCGSTamt"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmSGST"].Value)) != "")
                            { varSGSTPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGST"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmSGSTamt"].Value)) != "")
                            { varSGSTAmnt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmSGSTamt"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmIGST"].Value)) != "")
                            { varISGSTPer = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGST"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmIGSTamt"].Value)) != "")
                            { varIGSTAmnt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmIGSTamt"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmnetamt"].Value)) != "")
                            { varNetAmt = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmnetamt"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmCosting"].Value)) != "")
                            { varCosting = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmCosting"].Value);    }
                            if (Convert.ToString((grdPurchaseList.Rows[i].Cells["clmDiscountValue"].Value)) != "")
                            { varDiscountValue = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscountValue"].Value);    }

                            varMRPerr = Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmMRPError"].Value);
                            varPurchaseRateErr = Convert.ToInt16(grdPurchaseList.Rows[i].Cells["clmPurchaseRateErr"].Value);
                            varExpiryErr = Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmExpiryDateError"].Value);
                            varBatchErr = Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmBatchError"].Value);
                            varInvoiceQtyErr = Convert.ToInt16(grdPurchaseList.Rows[i].Cells["clmInvoiceError"].Value);
                            varReceivedQtyErr = Convert.ToInt16(grdPurchaseList.Rows[i].Cells["clmReceivedErr"].Value);
                            varFreeQtyErr = Convert.ToInt16(grdPurchaseList.Rows[i].Cells["clmFreeQtyErr"].Value);
                            varDisAmtErr = Convert.ToInt16(grdPurchaseList.Rows[i].Cells["clmDiscountErr"].Value);
                            varDisPerErr = Convert.ToInt16(grdPurchaseList.Rows[i].Cells["clmDisPerErr"].Value);

                            varProBatchErr = Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmProBatchError"].Value);
                            varProExpiryErr = Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmProExpiryDateError"].Value);
                            varProMRPErr = Convert.ToInt16(grdSupplierList.Rows[i].Cells["clmProMRPError"].Value); 
                            if (varMRPerr==0 && varPurchaseRateErr==0 &&  varExpiryErr ==0 &&  varBatchErr==0 && varInvoiceQtyErr==0 && varReceivedQtyErr==0 
                                && varFreeQtyErr==0 && varDisAmtErr==0 && varDisPerErr==0 && varProBatchErr==0 && varProExpiryErr==0 && varProMRPErr==0)
                            {
                                varError = 73; // Status no error                               
                            }
                            else
                            {
                                varError = 72; //status error
                                grdSupplierList.Columns["clmCheck"].DefaultCellStyle.NullValue = 0;
                                DataGridViewTextBoxCell Check = new DataGridViewTextBoxCell();
                                Check.Value = "";
                                grdSupplierList.Rows[i].Cells["clmCheck"] = Check;
                                Check.ReadOnly = true;
                            }
                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmcheck"].Value) == "" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmApprovalSts"].Value) == "0")
                            {
                                varcheck = 0;
                            }
                            else if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmcheck"].Value) == "" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmApprovalSts"].Value) == "63")
                            {
                                varcheck = 63;
                            }
                            else if (grdSupplierList.Rows[i].Cells["clmCheck"].ValueType == typeof(bool))
                            {
                                if (Convert.ToBoolean(grdSupplierList.Rows[i].Cells["clmCheck"].Value) == true)
                                {
                                    varcheck = 63;
                                }
                            }
                            if (varcount==0)
                            {
                                objPurchaseentryApprovalError.Rows.Add(pbPurchaseno, varPRID,varutid, varGrnMrp, varInvoiceMrp, varExpiryDate, varBatch, varSlid, varRkid, varHsnId, varPurchaseRate,  varPoqty,
                                    varInvoiceqty, varReceivedqty, varDiffQty, varFreeqty,varDisPer, varDisAmt, varTaxValue, varGSTper, varGSTAmt, varNetAmt, 
                                varCosting, varShelfLife, varShelfLifeValue, varShelfLifePer, varError, varPoid, varBatchNoStatus, varBatchNoGeneration, varShelfLifeFlag, varShelfLifeStatus, 
                                varPURPR_ID,varTotqty, varGRNqty, varDCqty, varPURPRID, varID, varDiscountValue, varCGSTPer, varSGSTPer,varCGSTAmnt, varSGSTAmnt, varISGSTPer, varIGSTAmnt, varMRPerr, varPurchaseRateErr,
                                varExpiryErr,  varBatchErr, varInvoiceQtyErr, varReceivedQtyErr, varFreeQtyErr, varDisAmtErr, varDisPerErr, varcheck,varProMRPErr,varProBatchErr,varProExpiryErr);
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
            return objPurchaseentryApprovalError;
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
                //if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmRecqty"
                //    || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiffqty" || grdPurchaseList.CurrentCell.OwningColumn.Name == "clmFreeqty")
                //{

                //    e.Control.KeyPress -= udfnHandleKeyPress;
                //    e.Control.KeyPress += udfnHandleKeyPress;
                //} 
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
                    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    //{
                    //    e.Handled = true;  // Disallow the character
                    //}
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
            //var varValueID = from r in objDt.AsEnumerable() group r by r.Field<string>("HSNID") into g select g.Key; 
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

        private void GrdPurchaseList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex == grdSupplierList.Columns["HSN Name"].Index && e.RowIndex >= 0)
                //{ 
                //    string SelectedGSTName = grdSupplierList.Rows[e.RowIndex].Cells["GSTValue"].Value?.ToString();
                //    if (!string.IsNullOrEmpty(SelectedGSTName))
                //    {
                //        if (SelectedGSTName != "0")
                //        {
                //            udfnGstvalue();
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
                var varIGST = dtTaxTable.AsEnumerable().Sum(x => x.Field<decimal>("IGST")).ToString();
                var varCGST = dtTaxTable.AsEnumerable().Sum(x => x.Field<decimal>("CGST")).ToString();
                var varSGST = dtTaxTable.AsEnumerable().Sum(x => x.Field<decimal>("CGST")).ToString();

                dtTaxTable.Rows.Add("Total", 0, Convert.ToDecimal(varTaxValue), "", Convert.ToDecimal(varIGST), "",
                    Convert.ToDecimal(varSGST), "", Convert.ToDecimal(varCGST));
                grdTaxDetails.DataSource = dtTaxTable;
                grdTaxDetails.Columns["GST%"].Width = 60;
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
                if (txtDiscountamt.Text.Trim()!="" &&  Convert.ToDecimal(Txtdiscount.Text)>100)
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
                    txtDiscPer.Focus();
                }
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


        public void udfnButtonChange()
        {
            try
            {
                if (varButtonFlag == 0)
                {
                    btnApprove.Text = "Approve";
                    btnApprove.Image = global::ROMS.Properties.Resources.approve;
                }
                else
                {
                    btnApprove.Text = "Update";
                    btnApprove.Image = global::ROMS.Properties.Resources.save;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdPurchaseList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.RowIndex != -1)
                    {
                        //if(Convert.ToString(grdSupplierList.CurrentRow.Cells["clmCheck"].Value)!="")
                        //{ 
                        if ((Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["clmErrorPro"].Value) == 0 && Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["clmApprovalStatus"].Value) != 63) || Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["clmErrorPro"].Value) > 0 && (Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["clmReason"].Value) != 230 && Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["clmReason"].Value) != 234 && Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["clmReason"].Value) != 0 && Convert.ToInt32(grdPurchaseList.CurrentRow.Cells["clmApprovalStatus"].Value) != 63))
                        {
                            switch (grdPurchaseList.Columns[e.ColumnIndex].Name)
                            {
                                //case "clmInvQty":
                                //    if (e.Button == MouseButtons.Right)
                                //    {
                                //        ContextMenuStrip menustrip = new ContextMenuStrip();
                                //        if (grdPurchaseList.CurrentRow.Cells["clmInvoiceError"].Value.ToString() == "0")
                                //        {
                                //            //cm.MenuItems.Add(new MenuItem("Error"));
                                //            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                //            cm.Name = "Error";
                                //            menustrip.Items.Add(cm);
                                //            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                //            cm.Click += new EventHandler(error_Click);
                                //        }
                                //        else
                                //        {
                                //            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                //            cm.Name = "Clear";
                                //            menustrip.Items.Add(cm);
                                //            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                //            cm.Click += new EventHandler(clear_Click);
                                //        }
                                //    }
                                //    break;

                                //case "clmRecqty":
                                //    if (e.Button == MouseButtons.Right)
                                //    {
                                //        ContextMenuStrip menustrip = new ContextMenuStrip();
                                //        if (grdPurchaseList.CurrentRow.Cells["clmReceivedErr"].Value.ToString() == "0")
                                //        {
                                //            //cm.MenuItems.Add(new MenuItem("Error"));
                                //            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                //            cm.Name = "Error";
                                //            menustrip.Items.Add(cm);
                                //            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                //            cm.Click += new EventHandler(error_Click);
                                //        }
                                //        else
                                //        {
                                //            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                //            cm.Name = "Clear";
                                //            menustrip.Items.Add(cm);
                                //            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                //            cm.Click += new EventHandler(clear_Click);
                                //        }
                                //    }
                                //    break;

                                //case "clmFreeqty":
                                //    if (e.Button == MouseButtons.Right)
                                //    {
                                //        ContextMenuStrip menustrip = new ContextMenuStrip();
                                //        if (grdPurchaseList.CurrentRow.Cells["clmFreeQtyErr"].Value.ToString() == "0")
                                //        {
                                //            //cm.MenuItems.Add(new MenuItem("Error"));
                                //            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                //            cm.Name = "Error";
                                //            menustrip.Items.Add(cm);
                                //            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                //            cm.Click += new EventHandler(error_Click);
                                //        }
                                //        else
                                //        {
                                //            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                //            cm.Name = "Clear";
                                //            menustrip.Items.Add(cm);
                                //            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                //            cm.Click += new EventHandler(clear_Click);
                                //        }
                                //    }
                                //    break;

                                case "clmPurchaseRate":
                                    if (e.Button == MouseButtons.Right)
                                    {
                                        ContextMenuStrip menustrip = new ContextMenuStrip();
                                        if (grdPurchaseList.CurrentRow.Cells["clmPurchaseRateErr"].Value.ToString() == "0")
                                        {
                                            //cm.MenuItems.Add(new MenuItem("Error"));
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                            cm.Name = "Error";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(error_Click);
                                        }
                                        else
                                        {
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                            cm.Name = "Clear";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(clear_Click);
                                        }
                                    }
                                    break;

                                case "clmDiscAmt":
                                    if (e.Button == MouseButtons.Right)
                                    {
                                        ContextMenuStrip menustrip = new ContextMenuStrip();
                                        if (grdPurchaseList.CurrentRow.Cells["clmDiscountErr"].Value.ToString() == "0")
                                        {
                                            //cm.MenuItems.Add(new MenuItem("Error"));
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                            cm.Name = "Error";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(error_Click);
                                        }
                                        else
                                        {
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                            cm.Name = "Clear";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(clear_Click);
                                        }
                                    }
                                    break;

                                case "clmDiscPer":
                                    if (e.Button == MouseButtons.Right)
                                    {
                                        ContextMenuStrip menustrip = new ContextMenuStrip();
                                        if (grdPurchaseList.CurrentRow.Cells["clmDisPerErr"].Value.ToString() == "0")
                                        {
                                            //cm.MenuItems.Add(new MenuItem("Error"));
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                            cm.Name = "Error";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(error_Click);
                                        }
                                        else
                                        {
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                            cm.Name = "Clear";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(clear_Click);
                                        }
                                    }
                                    break;
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
                grdPurchaseList.ClearSelection(); 
            }
        }
        private void error_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPurchaseList.Rows.Count != 0)
                {
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmInvQty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdPurchaseList.CurrentRow.Cells["clmInvoiceError"].Value = 1;
                        varButtonFlag++;
                      
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmRecqty")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmRecqty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdPurchaseList.CurrentRow.Cells["clmReceivedErr"].Value = 1;
                        varButtonFlag++;
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmFreeqty")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmFreeqty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdPurchaseList.CurrentRow.Cells["clmFreeQtyErr"].Value = 1;
                        varButtonFlag++;
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmPurchaseRate")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmPurchaseRate"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdPurchaseList.CurrentRow.Cells["clmPurchaseRateErr"].Value = 1;
                        varButtonFlag++;
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscAmt")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdPurchaseList.CurrentRow.Cells["clmDiscountErr"].Value = 1;
                        varButtonFlag++;
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmDiscPer"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdPurchaseList.CurrentRow.Cells["clmDisPerErr"].Value = 1;
                        varButtonFlag++;
                    }
                }
                if(grdSupplierList.Rows.Count!=0)
                {
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmMRP")
                    {
                        grdSupplierList.CurrentRow.Cells["clmMRP"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdSupplierList.CurrentRow.Cells["clmMRPError"].Value = 1;
                        varButtonFlag++;
                        //grdSupplierList.CurrentRow.Cells["clmCheck"].Value = false;
                        //DataGridViewTextBoxCell Check = new DataGridViewTextBoxCell();
                        //Check.Value = "";
                        //grdSupplierList.CurrentRow.Cells["clmCheck"] = Check;
                        //Check.ReadOnly = true;
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProMRP")
                    {
                        grdSupplierList.CurrentRow.Cells["clmProMRP"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdSupplierList.CurrentRow.Cells["clmProMRPError"].Value = 1;
                        varButtonFlag++; 
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate")
                    {
                        grdSupplierList.CurrentRow.Cells["clmexpirydate"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdSupplierList.CurrentRow.Cells["clmExpiryDateError"].Value = 1;
                        varButtonFlag++; 
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProExpiryDate")
                    {
                        grdSupplierList.CurrentRow.Cells["clmProExpiryDate"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdSupplierList.CurrentRow.Cells["clmProExpiryDateError"].Value = 1;
                        varButtonFlag++; 
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmBatchno")
                    {
                        grdSupplierList.CurrentRow.Cells["clmBatchno"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdSupplierList.CurrentRow.Cells["clmBatchError"].Value = 1;
                        varButtonFlag++;
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProBatchNo")
                    {
                        grdSupplierList.CurrentRow.Cells["clmProBatchNo"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
                        grdSupplierList.CurrentRow.Cells["clmProBatchError"].Value = 1;
                        varButtonFlag++;
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
                grdSupplierList.ClearSelection();
                grdPurchaseList.ClearSelection();
                udfnButtonChange();
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

        private void Btnselectall_Enter(object sender, EventArgs e)
        {
            try
            {
                btnselectall.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btnselectall_Leave(object sender, EventArgs e)
        {
            try
            {
                btnselectall.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btnselectall_Click(object sender, EventArgs e)
        {
            try
            {
                if(varCheckFlag==-1)
                { varCheckFlag = 1;
                    // btnselectall.Text = "Select";
                    btnselectall.Image = global::ROMS.Properties.Resources.checked1;
                }
                else if(varCheckFlag==1)
                { varCheckFlag = 2;
                    //btnselectall.Text = "UnSelect";
                    btnselectall.Image = global::ROMS.Properties.Resources.Unchecked;
                }
                else if(varCheckFlag==2)
                { varCheckFlag = 1;
                    btnselectall.Image = global::ROMS.Properties.Resources.checked1;
                    // btnselectall.Text = "Select";
                }
                if (varCheckFlag == 1)
                {
                    for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                    {
                        if (grdSupplierList.Rows[i].ReadOnly == false && grdSupplierList.Rows[i].Cells[0].ReadOnly==false)
                        {
                            grdSupplierList.Rows[i].Cells[0].Value = true;
                        }
                    }
                }
                else if(varCheckFlag==2)
                {
                    for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                    {
                        if (grdSupplierList.Rows[i].ReadOnly == false && grdSupplierList.Rows[i].Cells[0].ReadOnly == false)
                        {
                            grdSupplierList.Rows[i].Cells[0].Value = false;
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (varEntryApprovalNo == "0")
                {
                    udfnVocherno();
                }
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
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpPurchaseApprovalVocDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetVoucherNo("254", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string peno = parts[0];
                        if (peno != "")
                        {
                            txtPurApprovalVocNo.Text = peno;
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
                        txtPurApprovalVocNo.Text = "";
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
        private void GrdTaxDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (grdTaxDetails.Rows.Count != 0)
                { //grdTaxDetails.Rows[grdTaxDetails.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("192, 192, 255"); 
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
        private void clear_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPurchaseList.Rows.Count != 0)
                {
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmInvQty")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmInvQty"].Style.BackColor = Color.LightGray;
                        grdPurchaseList.CurrentRow.Cells["clmInvoiceError"].Value = 0;
                        varButtonFlag--;
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmRecqty")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmRecqty"].Style.BackColor = Color.LightGray;
                        grdPurchaseList.CurrentRow.Cells["clmReceivedErr"].Value = 0;
                        varButtonFlag--;
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmFreeqty")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmFreeqty"].Style.BackColor = Color.LightGray;
                        grdPurchaseList.CurrentRow.Cells["clmFreeQtyErr"].Value =0;
                        varButtonFlag--;
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmPurchaseRate")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmPurchaseRate"].Style.BackColor = Color.LightGray;
                        grdPurchaseList.CurrentRow.Cells["clmPurchaseRateErr"].Value = 0;
                        varButtonFlag--;
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscAmt")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmDiscAmt"].Style.BackColor = Color.LightGray;
                        grdPurchaseList.CurrentRow.Cells["clmDiscountErr"].Value = 0;
                        varButtonFlag--;
                    }
                    if (grdPurchaseList.CurrentCell.OwningColumn.Name == "clmDiscPer")
                    {
                        grdPurchaseList.CurrentRow.Cells["clmDiscPer"].Style.BackColor = Color.LightGray;
                        grdPurchaseList.CurrentRow.Cells["clmDisPerErr"].Value = 0;
                        varButtonFlag--;
                    }
                }
                if (grdSupplierList.Rows.Count != 0)
                {
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmMRP")
                    {
                        grdSupplierList.CurrentRow.Cells["clmMRP"].Style.BackColor = Color.LightGray;
                        grdSupplierList.CurrentRow.Cells["clmMRPError"].Value = 0;
                        varButtonFlag--;
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProMRP")
                    {
                        grdSupplierList.CurrentRow.Cells["clmProMRP"].Style.BackColor = Color.LightGray;
                        grdSupplierList.CurrentRow.Cells["clmProMRPError"].Value = 0;
                        varButtonFlag--;
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmexpirydate")
                    {
                        grdSupplierList.CurrentRow.Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                        grdSupplierList.CurrentRow.Cells["clmExpiryDateError"].Value = 0;
                        varButtonFlag--;
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProExpiryDate")
                    {
                        grdSupplierList.CurrentRow.Cells["clmProExpiryDate"].Style.BackColor = Color.LightGray;
                        grdSupplierList.CurrentRow.Cells["clmProExpiryDateError"].Value = 0;
                        varButtonFlag--;
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmBatchno")
                    {
                        grdSupplierList.CurrentRow.Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                        grdSupplierList.CurrentRow.Cells["clmBatchError"].Value = 0;
                        varButtonFlag--;
                    }
                    if (grdSupplierList.CurrentCell.OwningColumn.Name == "clmProBatchNo")
                    {
                        grdSupplierList.CurrentRow.Cells["clmProBatchNo"].Style.BackColor = Color.LightGray;
                        grdSupplierList.CurrentRow.Cells["clmProBatchError"].Value = 0;
                        varButtonFlag--;
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
                grdSupplierList.ClearSelection();
                grdPurchaseList.ClearSelection();
                udfnButtonChange();
            }
        }

        private void GrdSupplierList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if(Convert.ToString(grdSupplierList.CurrentRow.Cells["clmCheck"].Value)!="")
                    {  
                        switch (grdSupplierList.Columns[e.ColumnIndex].Name)
                        {
                            case "clmMRP":
                                if (e.Button == MouseButtons.Right)
                                {
                                    if (Convert.ToString(grdSupplierList.CurrentRow.Cells["clmMRPFlag"].Value) == "1")
                                    {
                                        ContextMenuStrip menustrip = new ContextMenuStrip();
                                        if (grdSupplierList.CurrentRow.Cells["clmMRPError"].Value.ToString() == "0")
                                        {
                                            //cm.MenuItems.Add(new MenuItem("Error"));
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                            cm.Name = "Error";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(error_Click);
                                        }
                                        else
                                        {
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                            cm.Name = "Clear";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(clear_Click);
                                        }
                                    }
                                }
                                break;

                            case "clmProMRP":
                                if (e.Button == MouseButtons.Right)
                                {
                                    if (Convert.ToString(grdSupplierList.CurrentRow.Cells["clmMRPFlag"].Value) == "1")
                                    {
                                        ContextMenuStrip menustrip = new ContextMenuStrip();
                                        if (grdSupplierList.CurrentRow.Cells["clmProMRPError"].Value.ToString() == "0")
                                        {
                                            //cm.MenuItems.Add(new MenuItem("Error"));
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                            cm.Name = "Error";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(error_Click);
                                        }
                                        else
                                        {
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                            cm.Name = "Clear";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(clear_Click);
                                        }
                                    }
                                }
                                break;

                            case "clmexpirydate":
                                if (e.Button == MouseButtons.Right)
                                {
                                    if (Convert.ToString(grdSupplierList.CurrentRow.Cells["clmShelflifeenable"].Value) == "1")
                                    {
                                        ContextMenuStrip menustrip = new ContextMenuStrip();
                                        if (grdSupplierList.CurrentRow.Cells["clmExpiryDateError"].Value.ToString() == "0")
                                        {
                                            //cm.MenuItems.Add(new MenuItem("Error"));
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                            cm.Name = "Error";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(error_Click);
                                        }
                                        else
                                        {
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                            cm.Name = "Clear";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(clear_Click);
                                        }
                                    }
                                }
                                break;

                            case "clmProExpiryDate":
                                if (e.Button == MouseButtons.Right)
                                {
                                    if (Convert.ToString(grdSupplierList.CurrentRow.Cells["clmShelflifeenable"].Value) == "1")
                                    {
                                        ContextMenuStrip menustrip = new ContextMenuStrip();
                                        if (grdSupplierList.CurrentRow.Cells["clmProExpiryDateError"].Value.ToString() == "0")
                                        {
                                            //cm.MenuItems.Add(new MenuItem("Error"));
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                            cm.Name = "Error";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(error_Click);
                                        }
                                        else
                                        {
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                            cm.Name = "Clear";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(clear_Click);
                                        }
                                    }
                                }
                                break;

                            case "clmBatchno":
                                if (e.Button == MouseButtons.Right)
                                {
                                    if (Convert.ToString(grdSupplierList.CurrentRow.Cells["clmBatchenable"].Value) == "72")
                                    {
                                        ContextMenuStrip menustrip = new ContextMenuStrip();
                                        if (grdSupplierList.CurrentRow.Cells["clmBatchError"].Value.ToString() == "0")
                                        {
                                            //cm.MenuItems.Add(new MenuItem("Error"));
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                            cm.Name = "Error";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(error_Click);
                                        }
                                        else
                                        {
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                            cm.Name = "Clear";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(clear_Click);
                                        }
                                    }
                                }
                                break;
                            case "clmProBatchNo":
                                if (e.Button ==   MouseButtons.Right)
                                {
                                    if (Convert.ToString(grdSupplierList.CurrentRow.Cells["clmBatchenable"].Value) == "72")
                                    {
                                        ContextMenuStrip menustrip = new ContextMenuStrip();
                                        if (grdSupplierList.CurrentRow.Cells["clmProBatchError"].Value.ToString() == "0")
                                        {
                                            //cm.MenuItems.Add(new MenuItem("Error"));
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Error");
                                            cm.Name = "Error";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(error_Click); 
                                        }
                                        else
                                        {
                                            ToolStripMenuItem cm = new ToolStripMenuItem("Clear");
                                            cm.Name = "Clear";
                                            menustrip.Items.Add(cm);
                                            menustrip.Show(grdSupplierList, grdSupplierList.PointToClient(Cursor.Position));
                                            cm.Click += new EventHandler(clear_Click);
                                        }
                                    }
                                }
                                break;
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
                grdSupplierList.ClearSelection();
            }
        }

        private void TxtDamagecost_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {

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


        //private void TxtLoadingchargeGrn_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtLoadingchargeGrn.BackColor = Color.White;
        //        if (txtLoadingchargeGrn.Text.Trim() != "")
        //        {
        //            string loadingGRnCharge = string.Format("{0:0.00}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtLoadingchargeGrn.Text.Trim()), 2, MidpointRounding.AwayFromZero)));
        //            txtLoadingchargeGrn.Text = loadingGRnCharge;
        //            udfnLoadingGrandTotCalculation();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

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

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                bool varErrorFlag = false;
                if (grdSupplierList.RowCount > 0)
                {
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
                    if (txtDiscountamt.Text.Trim() != "" && Convert.ToDecimal(Txtdiscount.Text) > 100)
                    {
                        Txtdiscount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        varErrorFlag = true;
                    }
                    if (varErrorFlag == false)
                    {
                        udfnApprove();
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
            }
        }
        public void udfnApprove()
        {
            try
            {
                string varGrandtotal = "";
                decimal varInvoiceAmt = 0;
                DataTable objPurchaseentryApprovalError = new DataTable();
                objPurchaseentryApprovalError.TableName = "TRN_Purchase_Products";
                objPurchaseentryApprovalError.Columns.Add("PURPR_PURID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_PRID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_UTID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_GRNMRP", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_InvoiceMRP", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ExpiryDate", typeof(string));
                objPurchaseentryApprovalError.Columns.Add("PURPR_Batch", typeof(string));
                objPurchaseentryApprovalError.Columns.Add("PURPR_SLID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_RKID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_HSNID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_PurchaseRate", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_POQty", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_InvoiceQty", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ReceivedQty", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_DiffQty", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_FreeQty", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_DiscPer", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_DiscAmnt", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_TaxableValue", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_GSTPer", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_GSTAmnt", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_NettAmnt", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_Costing", typeof(decimal));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLife", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLifeValue", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLifePer", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_Error", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_POID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_BatchNoStatus", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_BatchNoGenration", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLife_Flag", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ShelfLifeStatus", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_TOTQTY", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_GRNQTY", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_DCQTY", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPRID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("ID", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_DiscountValue", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_CGSTPer", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_CGSTAmnt", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_SGSTPer", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_SGSTAmnt", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ISGSTPer", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_IGSTAmnt", typeof(float));
                objPurchaseentryApprovalError.Columns.Add("PURPR_InvoiceMRPErr", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_PurchaseRateErr", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ExpiryDateErr", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_BatchErr", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_InvoiceQtyErr", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ReceivedQtyErr", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_FreeQtyErr", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_DiscAmntErr", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_DiscPerErr", typeof(int));
                objPurchaseentryApprovalError.Columns.Add("PURPR_ApprovalSts", typeof(int));
                objPurchaseentryApprovalError = udfnobjPurchaseprodDetails();

                if (varcount == 0 && Convert.ToInt32(VarGridError) == 0 && shelfLifeError == 0 && varQuantityErr == 0 && varDiscountErr == 0 && InvoiceAmountErr == 0)
                {
                    flagSave = 0;
                    varInvoiceAmt = Convert.ToDecimal(txtInvoiceamt.Text);
                    varGrandtotal = lblGrandTotal.Text;
                    if (lblTotal.Text == "")
                    {
                        varGrandtotal = "0";
                    }
                    if (((Convert.ToDecimal(txtInvoiceamt.Text)) != (Convert.ToDecimal(varGrandtotal))) && Convert.ToDecimal(varGrandtotal) != 0)
                    {
                        SPDataService objDServe1 = new SPDataService();
                        string varMessage = objDServe1.udfnGetMessages(115);
                        objDServe1.CloseConnection();
                        DialogResult dialogResult1 = MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        varInvoiceAmt = Convert.ToDecimal(varGrandtotal);
                    }
                }
                else
                {
                    flagSave = 1;
                }
                if (flagSave == 0  )
                {
                    //if (varCheckCount > 0 || varButtonFlag>0  )
                    //{
                        int varStatus = 0; string result = ""; 
                        varStatus = 63;
                        int varBrokerid = 0;
                        if (lblBrokerId.Text != "") { varBrokerid = Convert.ToInt32(lblBrokerId.Text); }

                        decimal loadcharge = 0, unloadcharge = 0, couriercharge = 0, otherexpense = 0, discountper = 0, discountamt = 0, tcsamt = 0, damagecost = 0,
                        otherdiscount = 0, Unloadinggrn = 0, frightgrn = 0, subtotal = 0, gstamt = 0, roundoff = 0, grandtotal = 0, total = 0;
                        if (txtUnLoadingchargeGrn.Text != "")
                        {
                            Unloadinggrn = Convert.ToDecimal(txtUnLoadingchargeGrn.Text);
                        }
                        if (txtFrightGrn.Text != "")
                        {
                            frightgrn = Convert.ToDecimal(txtFrightGrn.Text);
                        }
                        if (txtLoadingCharge.Text != "")
                        {
                            loadcharge = Convert.ToDecimal(txtLoadingCharge.Text);
                        }
                        if (txtUnLoadingCharge.Text != "")
                        {
                            unloadcharge = Convert.ToDecimal(txtUnLoadingCharge.Text);
                        }
                        if (txtCouriercharge.Text != "")
                        {
                            couriercharge = Convert.ToDecimal(txtCouriercharge.Text);
                        }
                        if (txtotherexpense.Text != "")
                        {
                            otherexpense = Convert.ToDecimal(txtotherexpense.Text);
                        }
                        if (Txtdiscount.Text != "")
                        {
                            discountper = Convert.ToDecimal(Txtdiscount.Text);
                        }
                        if (txtDiscountamt.Text != "")
                        {
                            discountamt = Convert.ToDecimal(txtDiscountamt.Text);
                        }
                        if (txtTcsamt.Text != "")
                        {
                            tcsamt = Convert.ToDecimal(txtTcsamt.Text);
                        }
                        if (txtDamagecost.Text != "")
                        {
                            damagecost = Convert.ToDecimal(txtDamagecost.Text);
                        }
                        if (txtOtherdiscount.Text != "")
                        {
                            otherdiscount = Convert.ToDecimal(txtOtherdiscount.Text);
                        }
                        if (lblGrandTotal.Text != "")
                        {
                            grandtotal = Convert.ToDecimal(lblGrandTotal.Text);
                        }
                        if (lblRoundoff.Text != "")
                        {
                            roundoff = Convert.ToDecimal(lblRoundoff.Text);
                        }
                        if (lblRoundoff.Text != "")
                        {
                            roundoff = Convert.ToDecimal(lblRoundoff.Text);
                        }
                        if (lblTotal.Text != "")
                        {
                            total = Convert.ToDecimal(lblTotal.Text);
                        }
                        if (lblSubtotal.Text != "")
                        {
                            subtotal = Convert.ToDecimal(lblSubtotal.Text);
                        }
                        if (lblGstamt.Text != "")
                        {
                            gstamt = Convert.ToDecimal(lblGstamt.Text);
                        }

                        TRN_PurchaseEntryApproval objTRN_PurchaseEntryApproval = new TRN_PurchaseEntryApproval();
                        objTRN_PurchaseEntryApproval.ViewType = 0;
                        objTRN_PurchaseEntryApproval.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                        objTRN_PurchaseEntryApproval.paraPurchaseId = Convert.ToInt32(pbPurchaseno);
                        objTRN_PurchaseEntryApproval.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                        objTRN_PurchaseEntryApproval.paraScheduleID = Convert.ToInt32(lblschedule.Text);
                        objTRN_PurchaseEntryApproval.paraStatus = varStatus;
                        objTRN_PurchaseEntryApproval.paraINVDate = dpInvoiceDate.Text.Trim();
                        objTRN_PurchaseEntryApproval.paraPurchaseDate = dpVoucherDate.Text.Trim();
                        objTRN_PurchaseEntryApproval.paraINVNo = txtInvoiceNo.Text.Trim();
                        objTRN_PurchaseEntryApproval.paraRemarks = txtRemarks.Text.Trim();
                        objTRN_PurchaseEntryApproval.ParaInvAmt = varInvoiceAmt;
                        objTRN_PurchaseEntryApproval.paraBrokerID = varBrokerid;
                        if (chkInvoice.Checked == true)
                        { objTRN_PurchaseEntryApproval.paraEinvoice = "1"; }
                        else
                        { objTRN_PurchaseEntryApproval.paraEinvoice = "0"; }
                        if (rbPurchaseCash.Checked == true)
                        {
                            objTRN_PurchaseEntryApproval.paraPurchaseType = 1;
                        }
                        if (rbPurchaseCredit.Checked == true)
                        {
                            objTRN_PurchaseEntryApproval.paraPurchaseType = 2;
                        }
                        if (rbPaymentCash.Checked == true)
                        {
                            objTRN_PurchaseEntryApproval.paraPaymentType = 1;
                        }
                        if (rbPaymentCheque.Checked == true)
                        {
                            objTRN_PurchaseEntryApproval.paraPaymentType = 2;
                        }
                        if (rbDiscountBefore.Checked == true)
                        {
                            objTRN_PurchaseEntryApproval.paraDiscCalculation = 1;
                        }
                        if (rbDiscountAfter.Checked == true)
                        {
                            objTRN_PurchaseEntryApproval.paraDiscCalculation = 2;
                        }
                        objTRN_PurchaseEntryApproval.paraLoadingCharges = loadcharge;
                        objTRN_PurchaseEntryApproval.paraUnloadingCharges = unloadcharge;
                        objTRN_PurchaseEntryApproval.paraCourierCharges = couriercharge;
                        objTRN_PurchaseEntryApproval.paraOtherExpenses = otherexpense;
                        objTRN_PurchaseEntryApproval.paraDiscAmnt = discountamt;
                        objTRN_PurchaseEntryApproval.paraDiscPer = discountper;
                        objTRN_PurchaseEntryApproval.paraTcsAmnt = tcsamt;
                        objTRN_PurchaseEntryApproval.paraDamageCost = damagecost;
                        objTRN_PurchaseEntryApproval.paraOtherDisc = otherdiscount;
                        objTRN_PurchaseEntryApproval.paraUnLoadingChargesGRN = Unloadinggrn;
                        objTRN_PurchaseEntryApproval.paraFrightGRN = frightgrn;
                        objTRN_PurchaseEntryApproval.paraSubTotal = subtotal;
                        objTRN_PurchaseEntryApproval.paraGSTAmnt = gstamt;
                        objTRN_PurchaseEntryApproval.paraRoundOff = roundoff;
                        objTRN_PurchaseEntryApproval.paraGrandTotal = grandtotal;
                        objTRN_PurchaseEntryApproval.paraTotal = total;
                        objTRN_PurchaseEntryApproval.paraSaveFlag = 0;
                        objTRN_PurchaseEntryApproval.paraPurchaseEntryApprovalDate = dpPurchaseApprovalVocDate.Text;
                        objTRN_PurchaseEntryApproval.ParaTRN_Purchase_Products_Error = objPurchaseentryApprovalError;
                        SPDataService objspdservice = new SPDataService();
                        result = objspdservice.udfnSetPurchaseEntryApproval(objTRN_PurchaseEntryApproval);
                        objspdservice.CloseConnection();
                        string[] varvalue1 = result.Split('~');
                        if (result.Split('~')[1] == "1")
                        {
                            l: MainForm.objCP_Verify = new CP_Verify();
                            MainForm.objCP_Verify.ShowDialog();
                            varUserID = MainForm.objCP_Verify.varUserId;
                            if (MainForm.objCP_Verify.flag == 1)
                            {
                                objTRN_PurchaseEntryApproval.paraSaveFlag = 1;
                                objTRN_PurchaseEntryApproval.paraUserID = Convert.ToInt32(varUserID);
                                result = objspdservice.udfnSetPurchaseEntryApproval(objTRN_PurchaseEntryApproval);
                                objspdservice.CloseConnection();
                                string[] varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    varModifiedFlag = 0;
                                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    varCloseflag = 1;
                                    MainForm.objPUR_PurchaseApprovalList.udfnList();
                                    udfnclose();
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
                        else
                        {
                            MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    //}
                    //else
                    //{
                    //    SPDataService objDServ = new SPDataService();
                    //    string varMessage = objDServ.udfnGetMessages(80);
                    //    objDServ.CloseConnection();
                    //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                }
                if(btnselectall.Visible==true && varCheckButtonFlag==0 && varCheckCount==0 && varButtonFlag==0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(80);
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

        private void TxtLoadingchargeGrn_Enter(object sender, EventArgs e)
        {
            try
            {
               // txtLoadingchargeGrn.BackColor = Color.LemonChiffon;
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
                    Txtdiscount.Focus();
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
                if(PbSTS=="50" || PbSTS == "61")
                {
                    grdPurchaseList.Columns["clmInvQty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdPurchaseList.Columns["clmRecqty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdPurchaseList.Columns["clmFreeqty"].DefaultCellStyle.BackColor = Color.LightGray;
                    //grdPurchaseList.Columns["clmPurchaseRate"].DefaultCellStyle.BackColor = Color.PaleGreen;
                    //grdPurchaseList.Columns["clmDiscAmt"].DefaultCellStyle.BackColor = Color.PaleGreen;
                    //grdPurchaseList.Columns["clmDiscPer"].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                DataGridView dataGridView = (DataGridView)sender;
                for (int i = 0; i < grdPurchaseList.Rows.Count; i++)
                {
                    int varReason = Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmReason"].Value);
                    int varApprovedStatus = Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmApprovalStatus"].Value);

                    if ((Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmErrorPro"].Value) == 1 && (varReason == 0)) || (Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmErrorPro"].Value) == 1 && (varReason == 230 || varReason == 234)) /*&& Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmApprovalStatus"].Value) != 0*/)
                    {
                        grdPurchaseList.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        grdPurchaseList.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        grdPurchaseList.Rows[i].ReadOnly = true;
                    }
                    if(varApprovalStatus == 63)
                    {
                        grdPurchaseList.Rows[i].ReadOnly = true;
                        grdPurchaseList.Rows[i].Cells["clmPurchaseRate"].Style.BackColor = Color.LightGray;
                    }
                    //(varError > 0 && varReason > 0) || (varError > 0 && varReason == 0 && varApprovalStatus != 61)
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
                    //string SelectedGSTName = grdSupplierList.Rows[e.RowIndex].Cells["GSTValue"].Value?.ToString();
                    //if (!string.IsNullOrEmpty(SelectedGSTName))
                    //{
                    //    if (SelectedGSTName != "0")
                    //    {
                    //        udfnGstvalue();
                    //    }
                    //}
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
                //if (e.ColumnIndex == grdPurchaseList.Columns["clmDiscPer"].Index && e.RowIndex >= 0)
                //{
                //    grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value = PbDiscamt.ToString("0.00"); 
                //}
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

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {

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
                                else
                                { udfnDefGrnGridLoad(); udfnDefReturnDc(); }

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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                                else
                                {
                                    udfnDefGrnGridLoad();
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
            //finally
            //{
            //    if (grdPODetails.Rows.Count > 0)
            //    {
            //        lblFinishedNoRecord.Visible = false;
            //    }
            //    else
            //    {
            //        lblFinishedNoRecord.Visible = true;
            //    }
            //}
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
                //txtDiscountamt.Text = varDisPercent.ToString();
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
                //Txtdiscount.Text = varDisPercent.ToString();
                //udfnLoadingGrandTotCalculation();
                //decimal varDisPer = (GrandTot * vardisamt) / 100;
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
                string varQRCode = "";
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objdserv.udfnGrnListLoad(7, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, "", "", 0, 0, 0, "", "", 0, 0, "", txtQRCode.Text.Trim(),"", 0, 0, 0, 0);
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
                if (varGrnId != -1 && varGrnId != 0)
                {
                    MainForm.objPUR_Purchase_GRNDetails.QRFlag = 1;
                    pbGRNNo = Convert.ToString(varGrnId);
                    udfnGRNProload();
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
                    //varQRCode = txtQRCode.Text.Trim();
                    //errPurchaseentry.Clear();
                    //txtQRCode.BackColor = Color.White;
                    //tpQRCode.Hide(txtQRCode);
                    //udfnGetGRNID();
                    //if(varGrnId==-1)
                    //{
                    //    txtQRCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    txtQRCode.Text = varQRCode;
                    //}
                    //if(varGrnId != -1 && varGrnId != 0)
                    //{
                    //    MainForm.objPUR_Purchase_GRNDetails.QRFlag = 1;
                    //    pbGRNNo = Convert.ToString( varGrnId);
                    //    udfnGRNProload();
                    //}
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
                        //case "clmAddPro":

                        //    string cellTname = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmProTname"].Value);
                        //    string cellNewProid = Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmProid"].Value);
                        //    MainForm.objCP_Items = new CP_Product();
                        //    MainForm.objCP_Items.varMasterType = "1";
                        //    MainForm.objCP_Items.varGRNid = pbGRNId;
                        //    MainForm.objCP_Items.varNewproid = cellNewProid;
                        //    MainForm.objCP_Items.varEname = cellTname;
                        //    MainForm.objCP_Items.ShowDialog();
                        //    udfnGRNProload();
                        //    break;
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                DataGridViewRow row = grdSupplierList.Rows[e.RowIndex];
                                grdSupplierList.Rows.Remove(row);
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
                    //DataGridViewCell CellRecQty = dataGridView.Rows[e.RowIndex].Cells["clmRecqty"];
                    //DataGridViewCell CellDiffQty = dataGridView.Rows[e.RowIndex].Cells["clmDiffqty"];
                    DataGridViewCell CellPurchaseRate = dataGridView.Rows[e.RowIndex].Cells["clmPurchaseRate"];
                    DataGridViewCell CellDiscPer = dataGridView.Rows[e.RowIndex].Cells["clmDiscPer"];
                    DataGridViewCell CellDiscAmt = dataGridView.Rows[e.RowIndex].Cells["clmDiscAmt"];
                    DataGridViewCell CellFreeQty = dataGridView.Rows[e.RowIndex].Cells["clmFreeqty"];
                    //DataGridViewCell CellTaxValue = dataGridView.Rows[e.RowIndex].Cells["clmTax"];
                    // DataGridViewCell CellGstAmt = dataGridView.Rows[e.RowIndex].Cells["clmGstamt"];
                    //DataGridViewCell CellNetAmt = dataGridView.Rows[e.RowIndex].Cells["clmnetamt"];
                    
                    decimal varInvQty = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmInvQty"].Value)) != "") { varInvQty = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmInvQty"].Value); }
                    decimal varRecQty = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmRecqty"].Value)) != "") { varRecQty = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmRecqty"].Value); }
                    decimal varDiffQty = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmDiffqty"].Value)) != "") { varDiffQty = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmDiffqty"].Value); }
                    decimal varFreeQty = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmFreeqty"].Value)) != "") { varFreeQty = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmFreeqty"].Value); }
                    decimal varPurchaseRate = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value)) != "")
                    {
                        string mrp = string.Format("{0:0.000}", Math.Round(Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value), 3, MidpointRounding.AwayFromZero));
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value = mrp;
                        varPurchaseRate = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmPurchaseRate"].Value);
                    }
                    decimal varCellDiscAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value)) != "") { varCellDiscAmt = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value); }
                    decimal varTaxValue = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmTax"].Value)) != "") { varTaxValue = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmTax"].Value); }
                    decimal varGstAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value)) != "") { varGstAmt = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value); }
                    decimal varNetAmt = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmnetamt"].Value)) != "") { varNetAmt = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmnetamt"].Value); }
                    decimal varDiscPer = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscPer"].Value)) != "") { varDiscPer = Convert.ToDecimal(grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscPer"].Value); }
                    int varHSNGSTValue = 0; if (Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["GstValue"].Value)) != "") { varHSNGSTValue = Convert.ToInt32(grdPurchaseList.Rows[e.RowIndex].Cells["GstValue"].Value); }
                    //decimal varGSTPer = 0; if(Convert.ToString((grdPurchaseList.Rows[e.RowIndex].Cells["clmGstper"].Value)) != "") { varGSTPer= Convert.ToInt32(grdPurchaseList.Rows[e.RowIndex].Cells["clmGstper"].Value); }
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
                                                    //object varEditQty = grdPurchaseList.Rows[e.RowIndex].Cells["clmGstper"].Value;
                                                    //object varEditQty1 = CellHSNGSTValue.Value;//grdPurchaseList.Rows[e.RowIndex].Cells["clmTax"].Value;
                                                    //object varEditQty2 = CellHSNGSTper.Value; //grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value;
                                                    //// Update the same column value in the DataTable
                                                    //dtTaxTable.Rows[e.RowIndex]["DM_Qty"] = varEditQty;
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
                    //if ((e.ColumnIndex == grdPurchaseList.Columns["clmPurchaseRate"].Index && e.RowIndex >= 0))
                    //{
                    //    CellPurchaseRate.Style.BackColor = Color.PaleGreen;
                    //    //udfnValuesCalcultaion(varInvQty, varRecQty, varDiffQty, varPurchaseRate, varCellDiscAmt, varTaxValue, varGstAmt, varNetAmt, varDiscPer, varHSNGSTValue, varFreeQty);
                    //    //udfnSubtotCalc();
                    //    //udfnGstvalue(); 
                    //    //udfnLoadingGrandTotCalculation();
                    //}
                    if ((e.ColumnIndex == grdPurchaseList.Columns["clmDiscAmt"].Index && e.RowIndex >= 0))
                    {
                        //CellDiscAmt.Style.BackColor = Color.PaleGreen;
                        //pbDisper = (varCellDiscAmt * 100) / (varPurchaseRate * varInvQty);
                        udfnDiscountToAmount(varCellDiscAmt,varDiscPer,varInvQty,varPurchaseRate);
                        varDiscPer = pbDisper;
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscPer"].Value = pbDisper.ToString("0.00");
                        //udfnValuesCalcultaion(varInvQty, varRecQty, varDiffQty, varPurchaseRate, varCellDiscAmt, varTaxValue, varGstAmt, varNetAmt, varDiscPer, varHSNGSTValue, varFreeQty);
                        //udfnSubtotCalc();
                        //udfnLoadingGrandTotCalculation();
                    }
                    if ((e.ColumnIndex == grdPurchaseList.Columns["clmInvQty"].Index || e.ColumnIndex == grdPurchaseList.Columns["clmRecqty"].Index || e.ColumnIndex == grdPurchaseList.Columns["clmPurchaseRate"].Index) || e.ColumnIndex == grdPurchaseList.Columns["clmFreeqty"].Index && e.RowIndex >= 0)
                    {
                        //CellInvQty.Style.BackColor = Color.PaleGreen;
                        //udfnValuesCalcultaion(varInvQty, varRecQty, varDiffQty, varPurchaseRate, varCellDiscAmt, varTaxValue, varGstAmt, varNetAmt, varDiscPer, varHSNGSTValue, varFreeQty);
                        //udfnGstvalue();
                        //udfnSubtotCalc();
                        //udfnLoadingGrandTotCalculation();
                    }
                    if ((e.ColumnIndex == grdPurchaseList.Columns["clmDiscPer"].Index) && e.RowIndex >= 0)
                    {
                        //CellDiscAmt.Style.BackColor = Color.PaleGreen;
                        //CellDiscPer.Style.BackColor = Color.PaleGreen;
                        // PbDiscamt = ((varPurchaseRate * varInvQty) * (varDiscPer)) / 100;
                        udfnDiscountToAmount(varCellDiscAmt, varDiscPer, varInvQty, varPurchaseRate);
                        varCellDiscAmt = PbDiscamt;
                        grdPurchaseList.Rows[e.RowIndex].Cells["clmDiscAmt"].Value = PbDiscamt.ToString("0.00");
                        //udfnValuesCalcultaion(varInvQty, varRecQty, varDiffQty, varPurchaseRate, varCellDiscAmt, varTaxValue, varGstAmt, varNetAmt, varDiscPer, varHSNGSTValue, varFreeQty);
                        //udfnSubtotCalc();
                        //udfnGstvalue();
                        //udfnLoadingGrandTotCalculation();
                    }
                    if (Convert.ToInt32(cmbEntryType.SelectedValue) == 57) //against dc
                    {
                        if (grdPurchaseList.Columns[e.ColumnIndex].Name == "clmFreeqty")
                        {
                            decimal varDiffQqty = 0;
                            varDiffQqty = Math.Abs(varInvQty - (varRecQty + varFreeQty));
                            grdPurchaseList.Rows[e.RowIndex].Cells["clmDiffqty"].Value = varDiffQqty;
                            //udfnSubtotCalc();
                            //udfnGstvalue();
                            //udfnLoadingGrandTotCalculation();
                        }
                    }
                    if (varEntryType == 55 || varEntryType == 56) // direct and against po
                    {
                        decimal varDiffQqty = 0;
                        if ((e.ColumnIndex == grdPurchaseList.Columns["clmInvQty"].Index) || (e.ColumnIndex == grdPurchaseList.Columns["clmRecqty"].Index) || (e.ColumnIndex == grdPurchaseList.Columns["clmFreeqty"].Index) && e.RowIndex >= 0)
                        {
                            varDiffQqty = 0;
                            varDiffQqty = Math.Abs(varInvQty - (varRecQty + varFreeQty));
                            grdPurchaseList.Rows[e.RowIndex].Cells["clmDiffqty"].Value = varDiffQqty;
                            //udfnSubtotCalc();
                            //udfnGstvalue();
                            //udfnLoadingGrandTotCalculation();
                        }
                    }
                    decimal varSGSTPer = 0 , varIGSTPer = 0 , varCGSTPer = 0 ;

                    //varSGSTPer = varGSTPer / 2;
                    //varCGSTPer= varGSTPer / 2;
                    //varIGSTPer = varGSTPer;

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

                    //grdPurchaseList.Rows[e.RowIndex].Cells["clmCGST"].Value = varCGSTPer;
                    //grdPurchaseList.Rows[e.RowIndex].Cells["clmIGST"].Value = varIGSTPer;
                    //grdPurchaseList.Rows[e.RowIndex].Cells["clmSGST"].Value = varSGSTPer;

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
                    //grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value = Math.Round(PbGstamt).ToString("0.00");
                    //grdPurchaseList.Rows[e.RowIndex].Cells["clmnetamt"].Value = Math.Round(PbNetamt).ToString("0.00");

                    grdPurchaseList.Rows[e.RowIndex].Cells["clmGstamt"].Value = PbGstamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmSGstamt"].Value = PbSGstamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmCGstamt"].Value = PbCGstamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmIGstamt"].Value = PbIGstamt.ToString("0.00");
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmnetamt"].Value = PbNetamt.ToString("0.00");
                    //if (varEntryType == 55 || varEntryType == 56)
                    //{
                    //    grdPurchaseList.Rows[e.RowIndex].Cells["clmDiffqty"].Value = pbDiffQty;
                    //}
                    grdPurchaseList.Rows[e.RowIndex].Cells["clmTax"].Value = PbTaxvalue.ToString("0.00");
                    udfnSubtotCalc();
                    udfnGstvalue();
                    udfnLoadingGrandTotCalculation();
                    PbGstamt = 0; PbNetamt = 0; pbDiffQty = 0; PbDiscamt = 0; PbTaxvalue = 0; pbDisper = 0; pbCostingRate=0; PbSGstamt = 0; PbCGstamt = 0; PbIGstamt = 0;
                }
            }
        }
        public void udfnDiscountToAmount(decimal varCellDiscAmt, decimal varDiscPer, decimal varInvQty,decimal varPurchaseRate)
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
                    if (varSupplierType == 30) //GSTIN registered supplier
                    {
                        PbNetamt = (PbTaxvalue + PbGstamt);
                    }
                    else
                    {
                        PbNetamt = (PbTaxvalue);
                    }
                }
                if(rbDiscountAfter.Checked==true)
                {
                    PbTaxvalue = (varPurchaseRate * varInvQty) ;
                    PbGstamt = ((PbTaxvalue * varHSNGSTValue) / 100);
                    if (varSupplierType == 30) //GSTIN registered supplier
                    {
                        PbNetamt = (PbTaxvalue + PbGstamt - varCellDiscAmt);
                    }
                    else
                    {
                        PbNetamt = (PbTaxvalue  - varCellDiscAmt);
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
                        if (varSupplierType == 30) //GSTIN registered suppplier
                        {
                            varSubtotal = varSubtotal + varTaxValue;
                            varTaxTotal = varTaxTotal + varGstAmt;
                        }
                        else
                        {
                            varSubtotal = varSubtotal + varNetAmt;
                            varTaxTotal = varTaxTotal + varGstAmt;
                        }
                    }
                    if (rbDiscountAfter.Checked == true)
                    {
                        decimal varDiscountValue = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiscountValue"].Value);
                        if (varSupplierType == 30) //GSTIN registered suppplier
                        {
                            varSubtotal = varSubtotal + varDiscountValue;
                            varTaxTotal = varTaxTotal + varGstAmt;
                        }
                        else
                        {
                            varSubtotal = varSubtotal + varNetAmt;
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
                if (varSupplierType == 30) //GSTIN registered suppplier
                {
                    lblGstamt.Text = varTaxTotal.ToString("0.00");
                    lblTotal.Text = (varSubtotal + varTaxTotal).ToString("0.00");
                }
                else
                {
                    varTaxTotal = 0;
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
                    string varMessage = objDServ.udfnGetMessages(104);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        pbRefreshFlag = 1;
                        for (int i = grdSupplierList.Rows.Count - 1; i >= 0; i--)
                        {
                            grdSupplierList.Rows.RemoveAt(i);
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                            grdReurnDC.Rows.Clear();
                            grdPODetails.Rows.Clear();
                            lblFinishedNoRecord.Visible = true;
                        }
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
                    rbPurchaseCash.Focus();
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
                //if (Convert.ToString(cmbTransactionType.SelectedValue) == "59")
                //{
                //    txtSourceLocation.Enabled = false;
                //    cmbrack.Enabled = false;
                //}
                //varRMFlag = Convert.ToInt32(cmbTransactionType.SelectedValue);
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
                    // objMR_Supplier.ParaPOID = varPOID;
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
            finally
            {
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
                DataGridView dataGridView = (DataGridView)sender; varCheckButtonFlag = 0;
                for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                {
                    string[] varShelflifevalue = Convert.ToString(grdSupplierList.Rows[i].Cells["clmshelfper"].Value).Split(' ');
                    int varReason = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmReaon"].Value);
                    int varApprovedStatus = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmApprovalSts"].Value);
                    if (varShelflifevalue[0] != "")
                    {
                        //Shelflife Wise Color Set
                        if (Convert.ToDecimal(varShelflifevalue[0]) <= varShelflifeLevel1)
                        {
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];    
                            cell.Style.BackColor = Color.Red;
                            cell.Style.ForeColor = Color.White;
                        }
                        else if (Convert.ToDecimal(varShelflifevalue[0]) > varShelflifeLevel1 && Convert.ToDecimal(varShelflifevalue[0]) < varShelflifeLevel2)
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
                    //if((Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmError"].Value)==1 && (varReason==0)) || (Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmError"].Value) == 1 && (varReason ==230 || varReason==234)) /*&& varApprovedStatus!=0*/)  
                    if ((Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmError"].Value) == 1 && (varReason == 0)) || (Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmError"].Value) == 1 && (varReason == 230 || varReason == 234)) /*&& Convert.ToInt32(grdPurchaseList.Rows[i].Cells["clmApprovalStatus"].Value) != 0*/)
                    {
                        grdSupplierList.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        grdSupplierList.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        grdSupplierList.Rows[i].ReadOnly=true;
                        DataGridViewTextBoxCell Check = new DataGridViewTextBoxCell();
                        Check.Value = "";
                        grdSupplierList.Rows[i].Cells["clmCheck"] = Check;
                        Check.ReadOnly = true;
                        varCheckButtonFlag++;
                    }
                    if(varApprovedStatus==63)
                    {
                        DataGridViewTextBoxCell Check = new DataGridViewTextBoxCell();
                        Check.Value = "";
                        grdSupplierList.Rows[i].Cells["clmCheck"] = Check;
                        Check.ReadOnly = true;
                        varCheckButtonFlag++;
                    }                 
                    //grdSupplierList.Rows[i].ReadOnly = true;
                    grdSupplierList.Rows[i].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                    grdSupplierList.Rows[i].Cells["clmProMRP"].Style.BackColor = Color.LightGray;
                    grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                    grdSupplierList.Rows[i].Cells["clmProExpiryDate"].Style.BackColor = Color.LightGray;
                    grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                    grdSupplierList.Rows[i].Cells["clmProBatchNo"].Style.BackColor = Color.LightGray;
                    grdSupplierList.Rows[i].Cells["clmLocation"].Style.BackColor = Color.LightGray;
                    grdSupplierList.Rows[i].Cells["clmrack"].Style.BackColor = Color.LightGray;
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
                            varSupplierType =Convert.ToInt32(objDs.Tables[0].Rows[0]["SP_SupplierType"].ToString());
                            if(lblsupplierGST.Text!="URD")
                            { lblsupplierGST.Text = "GSTIN - XXXXXXXXXXXXXXX";  }
                            else
                            {
                                lblsupplierGST.Text = "GSTIN - "+ lblsupplierGST.Text;
                            }
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString();
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString();
                            lblSupplierOrderpolicy.Text = "Return Policy -" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                            //txtGstin.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SP_GSTIN"]);

                            if (Convert.ToString(objDs.Tables[0].Rows[0]["SP_GSTIN"]) != "" && pbPurchaseno == "0")
                            {
                              //  LV_Supplier.Visible = false;
                                //txtGstin.Enabled = true;
                                if (Convert.ToInt32(cmbEntryType.SelectedValue) !=54 && (Convert.ToInt32(cmbEntryType.SelectedValue) != -1) && varQueueFlag==0)
                                {
                                    MainForm.objPUR_GSTIN = new PUR_GSTIN();
                                    MainForm.objPUR_GSTIN.ShowDialog();
                                }
                            }
                            else
                            {
                                //LV_Supplier.Visible = false;
                                txtGstin.Enabled = false;
                            }
                            udfnPODropdownload();
                        }
                        if (objDs.Tables[7].Rows.Count > 0)
                        {
                            varDamage = objDs.Tables[7].Rows[0]["DAMAGE"].ToString();
                            varReturnDC = objDs.Tables[7].Rows[0]["RETURNDC"].ToString();
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
                                    //grdProDetails.Rows.Add();
                                    if (irow < grdSupplierList.Rows.Count - 1)
                                    {
                                        grdSupplierList.CurrentCell = grdSupplierList[6, irow + 1];
                                        icolumn = grdSupplierList.CurrentCell.ColumnIndex;
                                        irow = grdSupplierList.CurrentCell.RowIndex;
                                        //goto A;
                                    }
                                    else
                                    {
                                        //grdSupplierList.CurrentCell = grdSupplierList[icolumn + 1, irow];
                                        //if (grdSupplierList.CurrentCell.ReadOnly == true)
                                        //{
                                        //    icolumn++; goto A;
                                        //}
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
                                    //grdProDetails.Rows.Add();
                                    if (irow < grdSupplierList.Rows.Count - 1)
                                    {
                                        grdSupplierList.CurrentCell = grdSupplierList[5, irow + 1];
                                        icolumn = grdSupplierList.CurrentCell.ColumnIndex;
                                        irow = grdSupplierList.CurrentCell.RowIndex;
                                        //goto A;
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
                                    if (grdSupplierList[icolumn + 1, irow].Visible == false)
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
                                    //grdProDetails.Rows.Add();
                                    if (irow < grdPurchaseList.Rows.Count - 1)
                                    {
                                        grdPurchaseList.CurrentCell = grdPurchaseList[11, irow + 1];
                                        icolumn = grdPurchaseList.CurrentCell.ColumnIndex;
                                        irow = grdPurchaseList.CurrentCell.RowIndex;
                                        //goto A;
                                    }
                                    else
                                    {
                                        //grdPurchaseList.CurrentCell = grdPurchaseList[icolumn + 1, irow];

                                        //if (grdPurchaseList.CurrentCell.ReadOnly == true)
                                        //{
                                        //    icolumn++; goto A;
                                        //}
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
