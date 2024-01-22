using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_Purchase : Form
    {
        DateTime varmaxdate;
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpconcern = new ToolTip();
        ToolTip tpInvoice = new ToolTip();
        ToolTip tpbatchno = new ToolTip();
        ToolTip tpProduct = new ToolTip();
        ToolTip tpdate = new ToolTip();
        ToolTip tpStockLocation = new ToolTip();
        ToolTip tpSuppliername = new ToolTip();
        ToolTip tpinvamt = new ToolTip();
        ToolTip tpInvNo = new ToolTip();
        public bool skipValidation = false;
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public string varPurchaseRate = "0", varcomid = "0", pbPONO = "0", pbPurchaseno = "0", pbDCNo="0", pbGRNNo="0";
        public bool VarSearchFlag = true;
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = ""
        , varorderSaleQty = "", varorderqty = "", addproductid = "", varunitid = "0", varDamage = "0", varReturnDC = "0", pbGRNId = "0", pbSupplierId = "0", dcid = "0",
        varenablefalg = "0", varUserID = "0", varflag = "0", varExpiryDate = "", varTName = "", varexp = "", pbScheduleId = "0", pbPOIdS = "0",
        varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0", varBatchNo = "0", varNewFlag = "0", VarGridError = "0", PurchaseDcIds="0";

        public int varGrnId = 0, varCloseflag = 0, pbDateflag = 0, varShelflife = 0, expirydateFlag = 0, varErrorFormat = 0, varcount = 0, varErroronGrid = 0, VarPrevSupplierid=0, varModifiedFlag=0;
        public CP_Purchase()
        {
            InitializeComponent();
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnViewDataView.Visible = true;
                txtInvoiceNo.Enabled = true;
                txtInvoiceNo.Text = "";
                if (cmbEntryType.SelectedValue.ToString() == "54") // GRN
                {
                    udfnPurchaseGrnLoad();
                    udfnGRNProload();
                    txtQRCode.ReadOnly = false;
                    dpInvoiceDate.Enabled = false;
                    txtInvoiceNo.ReadOnly = true;
                    txtInvoiceNo.Enabled = false;
                    grdPODetails.Visible = true;
                    grdReurnDC.Visible = false;
                }
                if (cmbEntryType.SelectedValue.ToString() == "55") // PO
                {
                    grdPODetails.Visible = true;
                    udfnPendingPOLoad();
                    udfnDefGrnGridLoad();
                    udfnPODropdownload();
                    txtQRCode.ReadOnly = true;
                    txtQRCode.Enabled = false;
                    dpInvoiceDate.Enabled = true;
                    txtInvoiceNo.ReadOnly = false;
                    grdPODetails.Visible = true;
                    grdReurnDC.Visible = false;
                    if (grdSupplierList.Rows.Count !=0)
                    {
                        btnClear.Enabled = true;
                    } 
                    if (grdPODetails.Rows.Count != 0)
                    {
                        lblFinishedNoRecord.Visible=false;
                    }
                }
                if (cmbEntryType.SelectedValue.ToString() == "56") // Direct
                {
                    btnViewDataView.Visible = false;
                    txtQRCode.ReadOnly = true;
                    txtQRCode.Enabled = false;
                    dpInvoiceDate.Enabled = true;
                    txtInvoiceNo.ReadOnly = false;
                    grdPODetails.Visible = true;
                    grdReurnDC.Visible = false;
                }
                if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                {
                    udfnPurchaseDC();
                    udfnDefReturnDc();
                    grdPODetails.Visible = false;
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
                            grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, "None",
                            Convert.ToString(objDs.Tables[0].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[0].Rows[i]["PTNAME"]), "", varMRP,
                            Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_Expirydate"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRODUCTEXP"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["Location"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["RKNAME"]), Convert.ToString(objDs.Tables[0].Rows[i]["UNIT"]),
                            "0", Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[0].Rows[i]["BATCHNO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Batchnogeneration"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_ShelfLife"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RackCount"])
                            ,Convert.ToString(objDs.Tables[0].Rows[i]["DCID"]));
                            grdSupplierList.Columns["clmGrnMrp"].Visible = false;
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
            finally { txtTpro.Text = Convert.ToString(grdSupplierList.Rows.Count); }
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
                            grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, Convert.ToString(objDs.Tables[0].Rows[i]["PONO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[0].Rows[i]["PTNAME"]), "", varMRP,
                            Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_Expirydate"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRODUCTEXP"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["Location"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["RKNAME"]), Convert.ToString(objDs.Tables[0].Rows[i]["UNIT"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["POID"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[0].Rows[i]["BATCHNO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Batchnogeneration"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_ShelfLife"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RackCount"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["POID"])
                            );
                            grdSupplierList.Columns["clmGrnMrp"].Visible = false;
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
            finally { txtTpro.Text =Convert.ToString(grdSupplierList.Rows.Count); }
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
                        pbPONO = Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value);
                    }
                    else
                    {
                        pbPONO = pbPONO + ',' + Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value);
                    }
                }
                MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                MainForm.objPUR_GRNOrderType.varMasterType = 2;
                MainForm.objPUR_GRNOrderType.ShowDialog();
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
                for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                {
                    if (pbGRNNo == "0")
                    {
                        pbGRNNo = Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value);
                    }
                    else
                    {
                        pbGRNNo = pbGRNNo + ',' + Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value);
                    }
                }
                MainForm.objPUR_Purchase_GRNDetails = new PUR_Purchase_GRNDetails(); 
                MainForm.objPUR_Purchase_GRNDetails.ShowDialog();
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
                            grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1,"None",
                            Convert.ToString(objDs.Tables[0].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[0].Rows[i]["PTNAME"]), "", varMRP,
                            Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_Expirydate"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRODUCTEXP"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["BATCHDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["Location"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["RKNAME"]), Convert.ToString(objDs.Tables[0].Rows[i]["UNIT"]),
                            "0", Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[0].Rows[i]["BATCHNO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Batchnogeneration"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_ShelfLife"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[0].Rows[i]["RackCount"])
                            , Convert.ToString(objDs.Tables[0].Rows[i]["GRNID"]));
                            grdSupplierList.Columns["clmGrnMrp"].Visible = false;
                            DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
                        } 
                        txtInvoiceNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Invno"]);
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
                            grdPODetails.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["PO_No"]),Convert.ToString(objDs.Tables[1].Rows[i]["PO_Date"]),
                            Convert.ToString(objDs.Tables[1].Rows[i]["Procount"]),Convert.ToString(objDs.Tables[1].Rows[i]["POID"]));
                        }
                    }
                    else
                    {
                        lblFinishedNoRecord.Visible = true;
                        lblFinishedNoRecord.BringToFront();
                    }
                    if (objDs.Tables[2].Rows.Count != 0)
                    { 
                        lblVerifyDateTime.Text = Convert.ToString(objDs.Tables[0].Rows[2]["VERIFIED1"]);
                    }
                    if (objDs.Tables[3].Rows.Count != 0)
                    { 
                        lblVerifyDateTime2.Text = Convert.ToString(objDs.Tables[3].Rows[0]["VERIFIED2"]);
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
                if (varCloseflag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
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
                MainForm.objPUR_POReturns = new PUR_POReturns();
                MainForm.objPUR_POReturns.ShowDialog();
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

                MainForm.objPUR_RemarksHistory = new PUR_RemarksHistory();
                MainForm.objPUR_RemarksHistory.ShowDialog();
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
                MainForm.objCP_Items = new CP_Product();
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
                udfnDateset();
                udfnDropdownLoad();
                udfnPODropdownload();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;

                if (Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    this.ActiveControl = cmbConcern;
                }
                else
                {
                    this.ActiveControl = txtSupplier;
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
                objDT = objdserv.udfnPOEntry(5, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, "", "", 0, 0, pbPONO, 0, 0, 0, 0, 0, Convert.ToInt32(pbGRNId));
                objdserv.CloseConnection();
                cmbPONo.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbPONo.ValueMember = "poid";
                            cmbPONo.DisplayMember = "PO_No";
                            cmbPONo.DataSource = objDT.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { pbPONO = "0"; }
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
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (17) ORDER BY MST_DisplayText desc", "MST_DisplayText,MSTID", cmbEntryType, "", "MST_DisplayText", "MSTID");
            objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID in (18) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
            objDataBind = null;
            cmbEntryType.SelectedValue = "56";
            cmbTransactionType.SelectedValue = "58";
        }
        public void udfnDateset()
        {
            try
            {
                DataSet objd = new DataSet();
                SPDataService objDServ = new SPDataService();
                objd = objDServ.udfnMaster(4, 6, 0, "", "", 0, "", 0);
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
                    this.Close();
                }
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblDProduct.Text = "Search by P.I Code";
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblDProduct.Text = "Search by Product Name";

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

        private void ChkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCompleted.Checked) { btnSave.Text = "Save"; } else { btnSave.Text = "Save as Draft"; }
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

        private void GrdPurchaseList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    int varColumn = grdPurchaseList.CurrentCellAddress.X;
                    int varRow = grdPurchaseList.CurrentCellAddress.Y;
                    string columnName = grdPurchaseList.Columns[varColumn].Name;
                    if (columnName == "clmPurchaseRate")
                    {
                        MainForm.objPUR_Calculator = new PUR_Calculator();
                        MainForm.objPUR_Calculator.ShowDialog();
                        grdPurchaseList.Rows[varRow].Cells[varColumn].Value = Convert.ToString(varPurchaseRate);
                    }
                }
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
                    MainForm.objPUR_GSTIN = new PUR_GSTIN();
                    MainForm.objPUR_GSTIN.ShowDialog();
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
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 30;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    // objMR_Supplier.ParaPOID = varPOID;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[3].Width = 0;
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
                varcomid = Convert.ToString(cmbConcern.SelectedValue);
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
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(75);
                            objDServ.CloseConnection();
                            txtPENO.Text = "";
                            DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                MainForm.objCP_Settings = new CP_Settings();
                                MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                                MainForm.objCP_Settings.varValues = Convert.ToString(38);
                                MainForm.objCP_Settings.MdiParent = this.ParentForm;
                                MainForm.objCP_Settings.Show();
                                this.Close();
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
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                    udfnSupplierDetails();
                    grdSupplierList.Rows.Clear();
                    grdReurnDC.Rows.Clear();
                    txtTpro.Text = Convert.ToString(grdSupplierList.Rows.Count);
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
                cmbEntryType.BackColor = Color.White;
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
                        txtTpro.Text = Convert.ToString(grdSupplierList.Rows.Count);
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
                    txtGstin.Focus();
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
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
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
                if (Convert.ToString(lblSupplierCode.Text) != "0")
                {
                    VarGridError = "0";
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cellSlname = dataGridView.Rows[e.RowIndex].Cells["clmLocation"];
                    DataGridViewCell cellSlid = dataGridView.Rows[e.RowIndex].Cells["slid"];
                    DataGridViewCell cellRkname = dataGridView.Rows[e.RowIndex].Cells["clmrack"];
                    DataGridViewCell cellRkid = dataGridView.Rows[e.RowIndex].Cells["rkid"];
                    if (e.ColumnIndex == grdSupplierList.Columns["clmLocation"].Index && e.RowIndex >= 0)
                    {
                        string SelectedLocationName = grdSupplierList.Rows[e.RowIndex].Cells["clmLocation"].Value?.ToString();
                        if (!string.IsNullOrEmpty(SelectedLocationName))
                        {
                            /* Check purchase location is valid or not*/
                            string varId_PurLocation = "0", varRkCount = "0";
                            DataSet objDsPurLoc = new DataSet();
                            SPDataService objDServ3 = new SPDataService();
                            objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, SelectedLocationName, 0, 0, 0, "", "");
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
                                cellRkname.ReadOnly = true; cellRkname.Style.BackColor = Color.LightGray;
                            }
                            else
                            {
                                cellRkid.Value = "-1";
                                cellRkname.Value = "";
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
                        }
                    }
                    else if (e.ColumnIndex == grdSupplierList.Columns["clmRack"].Index && e.RowIndex >= 0)
                    {
                        if (Convert.ToString(cellSlid.Value) != "-1")
                        {
                            string SelectedRackName = grdSupplierList.Rows[e.RowIndex].Cells["clmRack"].Value?.ToString();
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
                                if (varId_PurchaseRack != "-1")
                                {
                                    //if (varId_PurchaseRack != "0")
                                    //{
                                    //    cellRkname.Style.BackColor = Color.LightGray;
                                    //    cellRkname.ReadOnly = true;
                                    //}
                                    //else
                                    //{
                                    cellRkname.Style.BackColor = Color.PaleGreen;
                                    //}
                                    cellRkid.Value = Convert.ToString(varId_PurchaseRack);
                                }
                                else
                                {
                                    cellRkname.Style.BackColor = Color.LightPink;
                                    cellRkid.Value = Convert.ToString(varId_PurchaseRack);
                                    VarGridError = "1";
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

        private void TxtMrp_Enter(object sender, EventArgs e)
        {
            try
            {
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
                    txtDate.Focus();
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
                cmbrack.Focus();
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
                    objDs = objdserv.udfnRackList(3, 0, 0, Convert.ToInt32(lblLocationcode.Text), 0, "", 0, 0);
                    objdserv.CloseConnection();
                    cmbrack.DataSource = null;
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count > 0)
                        {
                            if (objDs.Tables[1].Rows.Count > 0)
                            {
                                if (Convert.ToInt32(objDs.Tables[1].Rows[0][0]) == 0)
                                {
                                    cmbrack.Text = "None";
                                    //lblLocationcode.Text = "0";
                                    cmbrack.Enabled = false;
                                }
                                else
                                {
                                    if (objDs.Tables[0].Rows.Count > 0)
                                    {
                                        cmbrack.ValueMember = "RKID";
                                        cmbrack.DisplayMember = "RK_Name";
                                        cmbrack.DataSource = objDs.Tables[0];
                                        cmbrack.Enabled = true;
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
                    objDs = objspdservice.udfnStockLocationList(10, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSourceLocation.Text, 0, 0, 0, "", "");
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
                    cmbrack.Focus();
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
                    cmbrack.Focus();
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                pbDateflag = 0;
                udfnAddProductsgrid();
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
                lvproduct.Visible = false;
                varExpiryDate = "";
                int varSourceLocationID = 0;
                /* Check  source location is valid or not*/
                if (txtSourceLocation.Text != "")
                {
                    string varId_SourceLocation = "0";
                    DataSet objDsSourceLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsSourceLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtSourceLocation.Text.Trim(), 0, 0, 0, "", "");
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
                    if (varId_SourceLocation == "0" || varId_SourceLocation == "-1")
                    {
                        errPurchaseentry.SetError(txtSourceLocation, "Please select valid stock location.");
                        txtSourceLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please select valid stock location.", txtSourceLocation, 5000);
                        varErrorFlag = true;
                    }
                }
                if (txtProductName.Text == "")
                {
                    errPurchaseentry.SetError(txtProductName, "Please enter product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    varErrorFlag = true;
                }
                if (expirydateFlag == 1)
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
                if (Convert.ToString(varNewFlag) == "0")
                {
                    if (Convert.ToString(txtProductName.Text) != "")
                    {
                        string varproductID = "0";
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 39;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraProductName = txtProductName.Text;
                        objMR_Product.paraId = Convert.ToInt32(cmbPONo.SelectedValue);
                        objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                        objMR_Product.ParaGRNID = Convert.ToInt32(pbGRNId);
                        DataSet objDsproductId = new DataSet();
                        SPDataService objDserv = new SPDataService();
                        objDsproductId = objDserv.udfnproductmasterlist(objMR_Product);
                        objDserv.CloseConnection();
                        if (objDsproductId != null)
                        {
                            if (objDsproductId.Tables.Count > 0)
                            {
                                if (objDsproductId.Tables[0].Rows.Count > 0)
                                {
                                    varproductID = Convert.ToString(objDsproductId.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        if (varproductID == "-1")
                        {
                            lblProductcode.Text = "0";
                            errPurchaseentry.SetError(txtProductName, "Invalid product");
                            txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpProduct.ShowAlways = true;
                            tpProduct.Show("Invalid product", txtProductName, 5000);
                            varErrorFlag = true;
                        }
                        else
                        {
                            lblProductcode.Text = varproductID;
                            errPurchaseentry.Clear();
                            txtProductName.BackColor = Color.White;
                        }
                    }
                }
                if (varErrorFlag == false)
                {
                    int varflag = 0;
                    string varShelflifevalue = "", varAcutalshelflife = "";
                    lblNoRecordsFound.Visible = false;

                    if (expirydateFlag == 1 || txtDate.Text != "" || txtMonth.Text != "" || txtYear.Text != "")
                    {
                        udfnDatevalidationset();
                    }
                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    if (varExpiryDate != "")
                    {
                        if (expirydateFlag == 1)
                        {
                            objDS = objDServ.udfnMaster(7, 0, 0, dpVoucherDate.Text, varExpiryDate, Convert.ToInt32(lblProductcode.Text), "", 0);
                            objDServ.CloseConnection();
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
                    }
                    if (varflag == 0)
                    {
                        string varRkId = "0";
                        if (cmbrack.Enabled == true)
                        {
                            varRkId = Convert.ToString(cmbrack.SelectedValue);
                        }
                        else { varRkId = "0"; }
                        for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(lblProductcode.Text) == Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmProid"].Value))
                            {
                                string varMRP = Convert.ToString(grdSupplierList.Rows[i].Cells["clmMRP"].Value).Trim();
                                string varNewExpiryDate = Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value).Trim();
                                string varBatch = Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchno"].Value).Trim();
                                string varPoid = Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value).Trim();
                                string varSLID = Convert.ToString(grdSupplierList.Rows[i].Cells["slid"].Value).Trim();
                                string varRKID = Convert.ToString(grdSupplierList.Rows[i].Cells["rkid"].Value).Trim();
                                if (txtMrp.Text.Trim() == varMRP && varExpiryDate == varNewExpiryDate && txtBatchno.Text.Trim() == varBatch)
                                {
                                    if (lblLocationcode.Text == varSLID && varRkId == varRKID)
                                    {
                                        if (Convert.ToString(cmbPONo.SelectedValue) == varPoid)
                                        {
                                            lblProductcode.Text = "0";
                                            //errPurchaseentry.SetError(txtProductName, "Product already Exist for this location");
                                            //txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            //tpdate.ShowAlways = true;
                                            //tpdate.Show("Product already Exist for this location", txtProductName, 5000);
                                            txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            string varMessage = objDServ.udfnGetMessages(93);
                                            objDServ.CloseConnection();
                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            varflag = 1;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (Convert.ToInt32(lblSupplierCode.Text) != 0)
                    {
                        if (varflag == 0)
                        {
                            if (pbDateflag == 0)
                            {
                                errPurchaseentry.Clear();
                                tpdate.Active = false;
                                txtDate.BackColor = Color.White;
                                txtMonth.BackColor = Color.White;
                                txtYear.BackColor = Color.White;
                                txtSourceLocation.BackColor = Color.White;
                                cmbrack.BackColor = Color.White;
                                string[] varpono = cmbPONo.Text.Split('~');
                                string productCode = "0",varRackCount="0", varRackId="0";
                                double varGrnMrp = 0;
                                productCode = lblProductcode.Text;
                                if (cmbrack.Enabled == true)
                                {
                                    varRackCount = "1";
                                    varRackId = Convert.ToString(cmbrack.SelectedValue);
                                }
                                else
                                {
                                    varRackCount = "0";
                                    varRackId = "0";
                                }
                                if (cmbEntryType.SelectedValue.ToString() == "55") // PO
                                {
                                    varGrnMrp = 0;
                                }

                                grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, (varpono[0]).Trim(), (varPICode).Trim() , (varTName).Trim(),varGrnMrp, (txtMrp.Text).Trim(), (varExpiryDate).Trim()
                                ,(varexp).Trim(), varAcutalshelflife, varShelflifevalue, (txtBatchno.Text).Trim(),txtSourceLocation.Text,cmbrack.Text, (var_Symbol).Trim(),cmbPONo.SelectedValue,
                                (productCode).Trim(), (varunitid).Trim(),  varBatchNo, varBatchNoGeneration, expirydateFlag,lblLocationcode.Text,varRackId,varRackCount);
                                udfnrowclear();
                                txtProductName.Focus(); 
                                DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
                                string[] varShelflifeper = Convert.ToString(varShelflifevalue).Split(' ');
                                if (varShelflifeper[0] != "")
                                {
                                    if (Convert.ToDecimal(varShelflifeper[0]) < 25)
                                    {
                                        DataGridView dataGridView = grdSupplierList;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.Red;
                                        cell.Style.ForeColor = Color.White;
                                    }
                                    else if (Convert.ToDecimal(varShelflifeper[0]) < 50)
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
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                }
                                else if (varBatchNo == "73")
                                {
                                    DataGridView dataGridView = grdSupplierList;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                }
                            }
                            else
                            {
                                //SPDataService objDServ1 = new SPDataService();
                                //string varMessage = objDServ1.udfnGetMessages(70);
                                //objDServ1.CloseConnection();
                                //MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                grdSupplierList.Sort(grdSupplierList.Columns[2], ListSortDirection.Ascending);
            }
        }

        public void udfnrowclear()
        {
            try
            {
                errPurchaseentry.Clear();
                cmbPONo.SelectedIndex = 0;
                cmbPONo.BackColor = Color.White;
                txtProductName.Text = "";
                txtSourceLocation.Text = "";
                lblLocationcode.Text = "0";
                txtMrp.Text = "";
                txtDate.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchno.Text = "";
                txtProductName.BackColor = Color.White;
                txtSourceLocation.BackColor = Color.White;
                txtMrp.BackColor = Color.White;
                txtDate.BackColor = Color.White;
                txtMonth.BackColor = Color.White;
                txtYear.BackColor = Color.White;
                txtBatchno.BackColor = Color.White;
                cmbrack.BackColor = Color.White;
                cmbrack.SelectedValue = -1;
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
                        objDS = objDServ.udfnMaster(5, 0, 0, varDate, "", 0, "", 0);
                        objDServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varExpiryDate = objDS.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();
                        }
                    }
                    else
                    {
                        varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                    }
                    objDS = objDServ.udfnMaster(10, 0, 0, dpInvoiceDate.Text.Trim(), varExpiryDate, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0);
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
                varErrorFormat = 0;
                if (skipValidation == false)
                {
                    if (grdSupplierList.Columns[e.ColumnIndex].Name == "clmexpirydate")
                    {
                        string dateString = e.FormattedValue.ToString();
                        if (dateString.Length != 10 && dateString != "")
                        {
                            varErrorFormat = 1;
                            MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (Convert.ToString(grdSupplierList.Rows[e.RowIndex].Cells["clmShelflifeenable"].Value) == "1" || dateString != "")
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
                    udfnGridaddvalue(sender, e);
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
                }
                varProid = Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["clmProid"].Value);
                objDS = objDServ.udfnMaster(10, 0, 0, dpVoucherDate.Text.Trim(), varExpiryDate, varProid, "", 0);
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
                                                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value) == varExpiryDate)
                                                    {
                                                        grdSupplierList.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                                        string varMessage = objDServ.udfnGetMessages(98);
                                                        objDServ.CloseConnection();
                                                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }
                                                }
                                                else
                                                {
                                                    grdSupplierList.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
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
                            if (varExpiryDate != "")
                            {
                                if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value) == varExpiryDate)
                                {
                                    varErroronGrid = 1;
                                    grdSupplierList.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
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
                                DataGridViewCell cell = dataGridView.Rows[i].Cells["clmMRP"];
                                DataGridViewCell cell1 = dataGridView.Rows[i].Cells["clmexpirydate"];
                                DataGridViewCell cell2 = dataGridView.Rows[i].Cells["clmBatchno"];
                                DataGridViewCell cell3 = dataGridView.Rows[i].Cells["clmLocation"];
                                DataGridViewCell cell4 = dataGridView.Rows[i].Cells["clmRack"];
                                if (VarGridError == "0")
                                {
                                    grdSupplierList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                    cell.Style.BackColor = Color.PaleGreen;
                                    cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                    cell1.Style.BackColor = Color.PaleGreen;
                                    cell1.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                    cell2.Style.BackColor = Color.PaleGreen;
                                    cell2.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                    cell3.Style.BackColor = Color.PaleGreen;
                                    cell3.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["rkid"].Value) == "0" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmrkcount"].Value) == "0" )
                                    {
                                        cell4.Style.BackColor = Color.LightGray;
                                        cell4.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                    }
                                    else
                                    {
                                        cell4.Style.BackColor = Color.PaleGreen;
                                        cell4.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                    }
                                }
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
                            //grdSupplierList.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                            if (Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["clmsno"].Value) != Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmsno"].Value))
                            {
                                if (Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["clmProid"].Value) == Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmProid"].Value))
                                {
                                    string varMRP = Convert.ToString(grdSupplierList.Rows[i].Cells["clmMRP"].Value).Trim();
                                    string varNewExpiryDate = Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value).Trim();
                                    string varBatch = Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchno"].Value).Trim();
                                    string varPoid = Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value).Trim();
                                    string varSLID = Convert.ToString(grdSupplierList.Rows[i].Cells["slid"].Value).Trim();
                                    string varRKID = Convert.ToString(grdSupplierList.Rows[i].Cells["rkid"].Value).Trim(); 
                                            
                                    if (Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmMRP"].Value) == varMRP && Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmexpirydate"].Value) == varNewExpiryDate && Convert.ToString(grdSupplierList.Rows[rowIndex].Cells["clmBatchno"].Value) == varBatch)
                                    {
                                        if (Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["clmid"].Value) == Convert.ToInt32(varPoid))
                                        {
                                            if (Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["slid"].Value) == Convert.ToInt32(varSLID) && Convert.ToInt32(grdSupplierList.Rows[rowIndex].Cells["rkid"].Value) == Convert.ToInt32(varRKID))
                                            {
                                                MessageBox.Show("Product already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                grdSupplierList.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                if (pbDateflag == 0)
                                                {
                                                    grdSupplierList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                                    DataGridViewCell cell = dataGridView.Rows[i].Cells["clmMRP"];
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

        private void GrdSupplierList_CellLeave(object sender, DataGridViewCellEventArgs e)
        { 
            try
            {
                string varshelflife = "";
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                int varCellprodid = 0;
                if (grdSupplierList.Columns[e.ColumnIndex].Name == "clmexpirydate")
                {
                    varCellprodid = Convert.ToInt32(grdSupplierList.Rows[e.RowIndex].Cells["clmProid"].Value);
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    if (rowIndex >= 0 && columnIndex >= 0)
                    {
                        object cellValue = grdSupplierList.Rows[rowIndex].Cells[columnIndex].Value;
                        if (cellValue != null && Convert.ToString(cellValue) != "")
                        {
                            varshelflife = cellValue.ToString();
                            if (varshelflife != "" || varshelflife != null)
                                objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, dpVoucherDate.Text, varCellprodid,0, "0");
                            objdserv.CloseConnection();
                            if (objDs != null)
                            {
                                if (objDs.Tables[0].Rows.Count > 0)
                                {
                                    grdSupplierList.Rows[rowIndex].Cells["clmshelfper"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
                                }
                                if (objDs.Tables[1].Rows.Count > 0)
                                {
                                    grdSupplierList.Rows[rowIndex].Cells["clmactuallife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
                                }

                                string[] varShelflifevalue = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]).Split(' ');
                                if (varShelflifevalue[0] != "")
                                {
                                    if (Convert.ToDecimal(varShelflifevalue[0]) < 25)
                                    {
                                        DataGridView dataGridView = grdSupplierList;
                                        DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.Red;
                                        cell.Style.ForeColor = Color.White;

                                    }
                                    else if (Convert.ToDecimal(varShelflifevalue[0]) < 50)
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
                CmbType_SelectedIndexChanged(sender,e);
            }
            catch (Exception ex) 
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                udfntooltiphide();
                bool varErrorFlag = false;
                if (grdSupplierList.RowCount > 0)
                {

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
                    if (cmbEntryType.SelectedValue.ToString() != "54")
                    { // GRN
                        if (txtInvoiceNo.Text == "")
                        {
                            errPurchaseentry.SetError(txtInvoiceNo, "Please enter invoice No.");
                            txtInvoiceNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpInvNo.ShowAlways = true;
                            tpInvNo.Show("Please enter invoice No.", txtInvoiceNo, 5000);
                            varErrorFlag = true;
                        }
                    }
                    if (Convert.ToString(txtInvoiceamt.Text) == "")
                    {
                        errPurchaseentry.SetError(txtInvoiceamt, "Please enter invoice amount");
                        txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpinvamt.ShowAlways = true;
                        tpinvamt.Show("Please enter invoice amount", txtInvoiceamt, 5000);
                        varErrorFlag = true;
                    }
                    if (varErrorFlag == false)
                    {  
                        string result = "", varorginator = "Purchase entry save"; 
                        SPDataService objspdservice = new SPDataService(); 
                        DataTable objPurchaseentry = new DataTable();
                        objPurchaseentry.TableName = "TRN_Purchase_Products";
                        objPurchaseentry.Columns.Add("PURPR_PURID", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_PRID", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_UTID", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_GRNMRP", typeof(float));
                        objPurchaseentry.Columns.Add("PURPR_InvoiceMRP", typeof(float));
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
                        objPurchaseentry.Columns.Add("PURPR_ShelfLife", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_ShelfLifeValue", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_ShelfLifePer", typeof(float));
                        objPurchaseentry.Columns.Add("PURPR_Error", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_POID", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_BatchNoStatus", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_BatchNoGenration", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_ShelfLife_Flag", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_ShelfLifeStatus", typeof(int));
                        objPurchaseentry.Columns.Add("PURPR_ID", typeof(int));
                        objPurchaseentry = udfnobjPurchaseprod(); 
                        if (varcount == 0)
                        {
                            string result2 = "";int varViewType=0;
                            if (btnSave.Text != "Save as Draft")
                            {
                                varViewType = 1;
                            }
                            TRN_PurchaseEntry objTRN_PurchaseEntry1 = new TRN_PurchaseEntry(); 
                            objTRN_PurchaseEntry1.ViewType = varViewType;
                            objTRN_PurchaseEntry1.ParaEditFlag = 0;
                            objTRN_PurchaseEntry1.paraPurchaseId = Convert.ToInt32(pbPurchaseno);
                            objTRN_PurchaseEntry1.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                            objTRN_PurchaseEntry1.paraPurchaseDate = dpVoucherDate.Text;
                            objTRN_PurchaseEntry1.ParaPurchase_Products = objPurchaseentry;
                            result2 = objspdservice.udfnSetPurchaseEntry(objTRN_PurchaseEntry1);
                            objspdservice.CloseConnection();
                            string[] varvalue1 = result2.Split('~');

                            if (varvalue1[1] == "1")
                            {
                                MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                                MainForm.objPUR_GRNApprovalVerify.varTrnType = 3;
                                MainForm.objPUR_GRNApprovalVerify.ShowDialog();
                                varUserID = MainForm.objPUR_GRNApprovalVerify.varUserId;
                                if (MainForm.objPUR_GRNApprovalVerify.flag == 1)
                                {
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
                                    objTRN_PurchaseEntry.ParaInvAmt = Convert.ToDecimal(txtInvoiceamt.Text); 
                                    objTRN_PurchaseEntry.paraTransactionType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                                    objTRN_PurchaseEntry.paraBrokerID = Convert.ToInt32(lblBrokerId.Text);
                                    objTRN_PurchaseEntry.paraGSTIN = txtGstin.Text;
                                    if (chkInvoice.Checked == true)
                                    {
                                        objTRN_PurchaseEntry.paraEinvoice = "1";
                                    }
                                    else
                                    {
                                        objTRN_PurchaseEntry.paraEinvoice = "0";
                                    }
                                    if (chkInvoice.Checked == true)
                                    {
                                        objTRN_PurchaseEntry.paraEinvoice = "1";
                                    }
                                    else
                                    {
                                        objTRN_PurchaseEntry.paraEinvoice = "0";
                                    }
                                    objTRN_PurchaseEntry.paraUserID = Convert.ToInt32(varUserID);
                                    objTRN_PurchaseEntry.paraRemarks = txtRemarks.Text; 
                                    objTRN_PurchaseEntry.ParaPurchase_Products = objPurchaseentry; 
                                    if (chkCompleted.Enabled == true)
                                    {
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
                                    decimal loadcharge = 0, unloadcharge = 0, couriercharge = 0, otherexpense = 0, discountper = 0, discountamt = 0, tcsamt = 0, damagecost=0,
                                    otherdiscount = 0, loadinggrn = 0,frightgrn = 0, subtotal = 0, gstamt = 0, roundoff = 0, grandtotal = 0;

                                    if (txtLoadingCharge.Text !="")
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
                                    if (txtSubtotal.Text != "")
                                    {
                                        subtotal = Convert.ToDecimal(txtSubtotal.Text);
                                    }
                                    if (txtGstamt.Text != "")
                                    {
                                        gstamt = Convert.ToDecimal(txtGstamt.Text);
                                    }
                                    if (txtRoundoff.Text != "")
                                    {
                                        roundoff = Convert.ToDecimal(txtRoundoff.Text);
                                    } 
                                    if (txtGrandtot.Text != "")
                                    {
                                        grandtotal = Convert.ToDecimal(txtGrandtot.Text);
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
                                    objTRN_PurchaseEntry.paraGrandTotal = grandtotal;
                                    objTRN_PurchaseEntry.ParaEditFlag = 1;
                                    objTRN_PurchaseEntry.ParaPurchaseDC = PurchaseDcIds;
                                    objTRN_PurchaseEntry.paraGRNID = Convert.ToInt32(pbGRNNo);
                                    result = objspdservice.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                                    objspdservice.CloseConnection();
                                    string[] varvalue = result.Split('~');
                                    if (varvalue[0] == "3")
                                    {
                                        varModifiedFlag = 0;
                                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.ActiveControl = txtSupplier;
                                        MainForm.objCP_PurchaseList.udfnListLoad();
                                        //varCloseflag = 1;
                                        //udfnclose();                 
                                        if (btnSave.Text== "Save as Draft")
                                        {
                                            pbPurchaseno = varvalue[2];
                                            udfnPurchaseEntryTabLoad();
                                        }
                                        tbDetails.SelectedIndex = 1;
                                        btnSave.Text = "Update as Draft";
                                    }
                                    else
                                    {
                                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                if (varvalue1[0] == "5")
                                {
                                    MessageBox.Show(result2.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    string varProductID = "", Expirydate = "";
                                    for (int j = 0; j < grdSupplierList.RowCount; j++)
                                    {
                                        grdSupplierList.Rows[j].DefaultCellStyle.BackColor = Color.White;

                                        string[] varFirstList = varvalue1[2].Split('|');
                                        for (int i = 0; i < varFirstList.Length; i++)
                                        {
                                            string[] varSecondList = varFirstList[i].Split(',');
                                            varProductID = varSecondList[0];
                                            Expirydate = varSecondList[1];
                                            if (Convert.ToString(grdSupplierList.Rows[j].Cells["clmProid"].Value) == varProductID && Convert.ToString(grdSupplierList.Rows[j].Cells["clmexpirydate"].Value) == Expirydate)
                                            {
                                                grdSupplierList.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                                //  grdPurchaseDC.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                            }
                                        }
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

                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 4;
                    objTRN_PurchaseEntry.ParaIds = pbPurchaseno;  
                    if (cmbEntryType.SelectedValue.ToString() == "55") // PO
                    {
                        objTRN_PurchaseEntry.ParaEditFlag = 1;
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "54") // GRN 
                    {
                        objTRN_PurchaseEntry.ParaEditFlag = 2;
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                    {
                        objTRN_PurchaseEntry.ParaEditFlag = 3;
                    }
                    if (cmbEntryType.SelectedValue.ToString() == "56") // Direct
                    {
                        objTRN_PurchaseEntry.ParaEditFlag = 4;
                    }
                    objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();
                    grdPurchaseList.Rows.Clear(); 
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            grdPurchaseList.Rows.Add(grdPurchaseList.Rows.Count + 1, "None",Convert.ToString(objDs.Tables[0].Rows[i]["PR_PICode"]), 
                            Convert.ToString(objDs.Tables[0].Rows[i]["PR_TName"]),Convert.ToString(objDs.Tables[0].Rows[i]["HSN_Code"]),"",
                            Convert.ToString(objDs.Tables[0].Rows[i]["POPR_TOTOrderQty"]),"","","","",Convert.ToString(objDs.Tables[0].Rows[i]["Unit"]),"","","", 
                            Convert.ToString(objDs.Tables[0].Rows[i]["Gstper"]),"","","", Convert.ToString(objDs.Tables[0].Rows[i]["POID"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[0].Rows[i]["HSNID"]), Convert.ToString(objDs.Tables[0].Rows[i]["Gst value"]));
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
        public DataTable udfnobjPurchaseprod()
        {
            varcount = 0;
            PurchaseDcIds = "0";
            DataTable objPurchaseentry = new DataTable();
            try
            {
                objPurchaseentry.TableName = "TRN_Purchase_Products";
                objPurchaseentry.Columns.Add("PURPR_PURID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_PRID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_UTID", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_GRNMRP", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_InvoiceMRP", typeof(float));
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
                objPurchaseentry.Columns.Add("PURPR_ShelfLife", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ShelfLifeValue", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ShelfLifePer", typeof(float));
                objPurchaseentry.Columns.Add("PURPR_Error", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_POID", typeof(int)); 
                objPurchaseentry.Columns.Add("PURPR_BatchNoStatus", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_BatchNoGenration", typeof(int));  
                objPurchaseentry.Columns.Add("PURPR_ShelfLife_Flag", typeof(int));  
                objPurchaseentry.Columns.Add("PURPR_ShelfLifeStatus", typeof(int));
                objPurchaseentry.Columns.Add("PURPR_ID", typeof(int));

                if (chkCompleted.Enabled == true)
                {
                    for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                    { 

                        if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                        {
                            PurchaseDcIds= Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value);
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["rkid"].Value) == "-1")
                        {
                            varcount++;
                            grdSupplierList.Rows[i].Cells["clmrack"].Style.BackColor = Color.LightPink;
                        }
                        else
                        {
                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["rkid"].Value) == "0" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmrkcount"].Value) != "0")
                            { 
                                varcount++;
                                grdSupplierList.Rows[i].Cells["clmrack"].Style.BackColor = Color.LightPink;
                            }
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["slid"].Value) == "-1")
                        {
                            varcount++;
                            grdSupplierList.Rows[i].Cells["clmLocation"].Style.BackColor = Color.LightPink;
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmShelflifeenable"].Value) == "1")
                        {
                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value) == "")
                            {
                                varcount++;
                                grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                            }
                            else
                            {
                                grdSupplierList.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                            } 
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "75")
                        {
                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchno"].Value) == "")
                            {
                                varcount++;
                                grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightPink;
                            }
                            else
                            {
                                grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.PaleGreen;
                            }
                        }
                        else
                        {
                            if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "74" || Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "-1")
                            {
                                grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                            }
                            else
                            {
                                grdSupplierList.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.PaleGreen;
                            }
                        }
                        decimal varMRP = 0,varGrnMRP=0;
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmMRP"].Value) != "")
                        {
                            varMRP = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmMRP"].Value);
                        }
                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmGrnMrp"].Value) != "")
                        {
                            varGrnMRP = Convert.ToDecimal(grdSupplierList.Rows[i].Cells["clmGrnMrp"].Value);
                        }
                        decimal varShelfPer = 0;
                        int Shelflifevalue = 0, ProShelflife = 0,   POno = 0;
                        string[] varShelflifevaluesplit = Convert.ToString(grdSupplierList.Rows[i].Cells["clmactuallife"].Value).Split(' ');
                        string[] varShelflifeper = Convert.ToString(grdSupplierList.Rows[i].Cells["clmshelfper"].Value).Split(' ');
                        string[] varProShelfLife = Convert.ToString(grdSupplierList.Rows[i].Cells["clmshelflife"].Value).Split(' ');

                        if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmid"].Value) == "")
                        {
                            POno = 0;
                        }
                        else { POno = Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmid"].Value); }

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

                        DataService objDser = new DataService();

                        objPurchaseentry.Rows.Add(0, Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmProid"].Value),
                        Convert.ToInt32(grdSupplierList.Rows[i].Cells["UTID"].Value), varGrnMRP,
                        varMRP,Convert.ToString(grdSupplierList.Rows[i].Cells["clmexpirydate"].Value)
                        ,Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchno"].Value),Convert.ToString(grdSupplierList.Rows[i].Cells["slid"].Value),
                        Convert.ToString(grdSupplierList.Rows[i].Cells["rkid"].Value),0, 0, 0,0,0,0,0,0,0,0,0,0,0,0, ProShelflife,varShelfPer
                        ,0,POno, Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value), Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value)
                        ,Shelflifevalue, Convert.ToInt32(grdSupplierList.Rows[i].Cells["clmShelflifeenable"].Value)); 
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return objPurchaseentry;
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
                    cmbTransactionType.Focus();
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
                    string varMessage = objDServ.udfnGetMessages(76);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
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
            finally { txtTpro.Text = Convert.ToString(grdSupplierList.Rows.Count); }
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
                    rbRateBefore.Focus();
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
                    cmbPONo.Focus();
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
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "59")
                {
                    txtSourceLocation.Enabled = false;
                    cmbrack.Enabled = false;
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
                for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "72" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "74")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "73")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.PaleGreen;
                        cell.Style.ForeColor = Color.Black;
                    }
                    string[] varShelflifevalue = Convert.ToString(grdSupplierList.Rows[i].Cells["clmshelfper"].Value).Split(' ');
                    if (varShelflifevalue[0] != "")
                    {
                        if (Convert.ToDecimal(varShelflifevalue[0]) < 25)
                        {
                            DataGridView dataGridView = grdSupplierList;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.Red;
                            cell.Style.ForeColor = Color.White;
                        }
                        else if (Convert.ToDecimal(varShelflifevalue[0]) < 50)
                        {
                            DataGridView dataGridView = grdSupplierList;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.Orange;
                            cell.Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            DataGridView dataGridView = grdSupplierList;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.White;
                            cell.Style.ForeColor = Color.Black;
                        }
                    }
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["rkid"].Value) == "0" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmrkcount"].Value) == "0")
                    {
                        DataGridView dataGridView = grdSupplierList;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmrack"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        DataGridView dataGridView = grdSupplierList;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["rkid"];
                        cell.Style.BackColor = Color.PaleGreen;
                    }
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
                if (e.KeyCode == Keys.Enter)
                {
                    txtMrp.Focus();
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
                }
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
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
                }
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
                udfnListviewProduct();
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
                    txtMrp.Text = "";
                    txtDate.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtBatchno.Text = "";
                    varBatchNo = "0"; varBatchNoGeneration = "0"; varShelflife = 0; expirydateFlag = 0;
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[3].Text;
                    lblProductcode.Text = selectedItem.SubItems[4].Text;
                    varBatchNo = selectedItem.SubItems[5].Text;
                    varBatchNoGeneration = selectedItem.SubItems[6].Text;
                    varRMProduction = selectedItem.SubItems[7].Text;
                    varPrcategory = selectedItem.SubItems[8].Text;
                    varShelflife = Convert.ToInt32(selectedItem.SubItems[9].Text);
                    if (varShelflife == 1)
                    { expirydateFlag = 1; }
                    udfnProductAdd();
                    udfnDefalutLocation();
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
                            //txtBatchNo.ReadOnly = false;
                        }
                        else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(14, 0, 0, "", "", 0, "", 0);
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
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(15, 0, 0, dpVoucherDate.Text, "", Convert.ToInt32(lblProductcode.Text), "", 0);
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
                txtMrp.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvproduct.Visible = false;
                lvSourceLocation.Visible = false;
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
                        ObjsLocation = objDserv.udfnStockLocationList(25, 0, 0, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0, 0, 0, "", "");
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
                                    cmbrack.SelectedIndex = 0;
                                    lvSourceLocation.Visible = false;
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
            finally
            {
                lvproduct.Visible = false;
            }
        }

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (VarSearchFlag == true)
                {
                    txtProductName.CharacterCasing = CharacterCasing.Upper;
                }
                else
                {
                    txtProductName.CharacterCasing = CharacterCasing.Normal;
                }
                string varProductsCodes = "0";
                lvproduct.Items.Clear();
                varNewFlag = "0";
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                int GRNID = 0;
                if (Convert.ToInt32(cmbPONo.SelectedValue) == 0)
                {
                    GRNID = 0;
                }
                else { GRNID = Convert.ToInt32(pbGRNId); }
                if (txtProductName.Text.Length > 0)
                {
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 29;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.ParaScheduleid = Convert.ToString(lblschedule.Text);
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Product.paraId = Convert.ToInt32(cmbPONo.SelectedValue);
                    objMR_Product.ParaGRNID = GRNID;
                    objMR_Product.ParaProductsCode = varProductsCodes;
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
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(),objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(),
                                        objDs.Tables[0].Rows[i]["PR_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PR_BatchNoGeneration"].ToString(),objDs.Tables[0].Rows[i]["PR_RMForProduction"].ToString(),objDs.Tables[0].Rows[i]["PR_PRCTID"].ToString(),objDs.Tables[0].Rows[i]["PR_ShelfLife"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.Columns[0].Width = 100;
                                lvproduct.Columns[1].Width = 320;
                                lvproduct.Columns[2].Width = 50;
                            }
                        }
                    }
                }
                else
                {
                    lvproduct.Visible = false;
                    lvproduct.Items.Clear();
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
                txtGstin.Focus();
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
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString();
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString();
                            lblSupplierOrderpolicy.Text = "Return Policy -" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                            txtGstin.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SP_GSTIN"]);
                            if (Convert.ToString(objDs.Tables[0].Rows[0]["SP_GSTIN"]) != "")
                            {
                                LV_Supplier.Visible = false;
                                txtGstin.Enabled = true;
                                MainForm.objPUR_GSTIN = new PUR_GSTIN();
                                MainForm.objPUR_GSTIN.ShowDialog();
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
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            if (varReturnDC == "0")
            {
                btnDC.Enabled = false;
            }
            else
            {
                btnDC.Enabled = true;
            } 
        } 
    }
}
