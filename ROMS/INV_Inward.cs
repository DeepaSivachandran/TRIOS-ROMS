using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class INV_Inward : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public string varIDCOUNT = "";
        string varStockLocationId = "",varPRID="",varPICode="",varUTID="", varExpiryDate = "", varBatchNo="", varRKID="", varTamilname="", varBatchNoGeneration="";
        public int varGIId = 0, pbDateflag = 0, varShelflife = 0, varSTRID = 0, varSLID = 0, varUpdateflag = 0, varStatusId = 0, varSTRPRID = 0, varGISTRID = 0, varcomID = 0, shelfLifeError = 0;
        string varShelflifevalue = "", varAcutalshelflife = "", result="", Shelflife="", ProductShelflifeValue="", ProductShelflifeType="";
        public bool VarSearchFlag = true;
        public bool varDiscardFlag = true;
        public int varEditflag = 0, varMRPFlag = 0, varMRPEditFlag = 0, varRMProductionFlag = 0, varErrorFormat = 0;
        public string  varPrcategory="0" , varRMProduction="0", varTempExpiryDate = "0", varErrExpiryDate = "0", varErrBatchNo = "0";
        public int varDecimal = 0, varErroronGrid=0;
        public int varSTSID = 0, Shelflifevalue = 0;
        decimal ProShelflife = 0;
        public bool varChangeFlag = true;
        DataTable dtInward = new DataTable();
        int expirydateFlag = 0, varUpDownKey = 0;
        public int varErrQty = 0;
        private ToolTip tpDay = new ToolTip();
        private ToolTip tpMonth = new ToolTip();
        private ToolTip tpYear = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpQuantity = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpCompany = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        private ToolTip tpmrp = new ToolTip();
        private ToolTip tpbatch = new ToolTip();
        private ToolTip tprack = new ToolTip();
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0;
        public int varDateEnable = 0;
        public int varAutocompleteProduct = 0;
        public string varEditPRID = "0";
        public INV_Inward()
        {
            InitializeComponent();
        }
        public void udfnclose()
        {
            try
            {
                if (varClose == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDiscard()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to discard changes ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (varChangeFlag == false)
                {
                    udfnDiscard();
                    MainForm.objINV_Inwardlist.udfnList();
                }
                else
                {
                    udfnclose();
                    MainForm.objINV_Inwardlist.udfnList();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_Inward_Load(object sender, EventArgs e)
        {
            try
            { 
                lbltwentyfiveper.Text = "< " + Convert.ToString(MainForm.pbShelflifeLevel1) + "%";
                lblFivetyPercentage.Text = "< " + Convert.ToString(MainForm.pbShelflifeLevel2) + "%";
                dtInward.TableName = "TRN_GoodsInward_Product";
                dtInward.Columns.Add("GIPR_PRID", typeof(int));
                dtInward.Columns.Add("GIPR_MRP", typeof(decimal));
                dtInward.Columns.Add("GIPR_ExpiryDate", typeof(string));
                dtInward.Columns.Add("GIPR_BatchNo", typeof(string));
                dtInward.Columns.Add("GIPR_QTY", typeof(decimal));
                dtInward.Columns.Add("GIPR_RKID", typeof(int));
                dtInward.Columns.Add("GIPR_SLID", typeof(int));
                dtInward.Columns.Add("GIPR_ReqQty", typeof(decimal));
                dtInward.Columns.Add("GIPR_TransferQty", typeof(decimal));
                dtInward.Columns.Add("GIPR_ShelfLife", typeof(int));
                dtInward.Columns.Add("GIPR_ShelfLifeValue", typeof(int));
                dtInward.Columns.Add("GIPR_ShelfLifeType", typeof(int));
                dtInward.Columns.Add("GIPR_ShelfLifePer", typeof(decimal));
                dtInward.Columns.Add("GIPR_MRPflag", typeof(int));
                dtInward.Columns.Add("GIPR_RMProductionFlag", typeof(int));
                dtInward.Columns.Add("GIPPR_BatchStatus", typeof(int));
                dtInward.Columns.Add("GIPPR_BatchGeneration", typeof(int));
                dtInward.Columns.Add("GIPR_ShelfLifeFlag", typeof(int));
                udfnCmbConcern();
                dpInwardDate.MinDate = MainForm.pbFYStartDate;
                dpInwardDate.MaxDate = MainForm.pbCurrentDate;
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    udfnTransactionData();
                    this.ActiveControl = txtStockLocation;
                    lblProductName.Text = "Search by P.I Code (F11)";
                    if (varEditflag == 0)
                    {
                        udfnEdit();
                    }
                    else
                    {
                        cbCompleted.Visible = false;
                        udfnTransferEdit();
                    }
                    if (varEditflag == 1 && Convert.ToInt32(cmbTransactionType.SelectedValue) == 69)
                    {
                        MainForm.objPUR_RemarksHistory = new PUR_RemarksHistory();
                        MainForm.objPUR_RemarksHistory.varSTRID = varSTRID;
                        MainForm.objPUR_RemarksHistory.varEditflag = 1;
                        MainForm.objPUR_RemarksHistory.varLoadFlag = 1;
                        MainForm.objPUR_RemarksHistory.udfnShowDialog();
                    }
                    else if (varEditflag == 0 && Convert.ToInt32(cmbTransactionType.SelectedValue) == 69)
                    {
                        MainForm.objPUR_RemarksHistory = new PUR_RemarksHistory();
                        MainForm.objPUR_RemarksHistory.varSTRID = varGISTRID;
                        MainForm.objPUR_RemarksHistory.varGIID = varGIId;
                        MainForm.objPUR_RemarksHistory.varEditflag = 0;
                        MainForm.objPUR_RemarksHistory.varLoadFlag = 1;
                        MainForm.objPUR_RemarksHistory.udfnShowDialog();
                    }
                    if (varIDCOUNT == "")
                    {
                        btnRemarks.Enabled = false;
                    }
                    //grdInward.Columns["clmactualqty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                grdInward.AutoSize = false;  // important!
                grdInward.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                grdInward.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                grdInward.ScrollBars = ScrollBars.Both;

                foreach (DataGridViewColumn col in grdInward.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }

                // Force scrollbar refresh when a column resizes
                grdInward.ColumnWidthChanged += (s, args) =>
                {
                    grdInward.HorizontalScrollingOffset = 0; // force grid to check scrollbars
                    grdInward.PerformLayout();
                    grdInward.Refresh();
                };

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
               // cmbConcern.SelectedValue = MainForm.pbDefaultComId;
            }
        }
        public void udfnTransactionData()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID = 23", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
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
                varErrQty = 0;
                if (varEditflag==0)
                {
                    for (int i = 0; i < grdInward.Rows.Count; i++)
                    {
                        if (Convert.ToDecimal(grdInward.Rows[i].Cells["clmactualqty"].Value) == 0)
                        {
                            grdInward.Rows[i].Cells["clmactualqty"].Style.BackColor = Color.LightPink;
                            varErrQty = 1;
                        }
                        else
                        {
                            grdInward.Rows[i].Cells["clmactualqty"].Style.BackColor = Color.PaleGreen;
                        }
                    }
                }
                udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave()
        {
            try
            {
                shelfLifeError = 0;
                int ViewType = 0; string varoriginator = "Goods Inward Creation";
                bool GIID = Convert.ToBoolean(varGIId);
                if (btnSave.Text=="Save as Draft" && cbCompleted.Checked == false && !GIID)
                {
                    varUpdateflag = 0;
                    ViewType = 0;
                    varStatusId = 41;
                }
                else if (btnSave.Text == "Save" && cbCompleted.Checked == true && GIID)
                {
                    varUpdateflag = 0;
                    ViewType = 0;
                    varStatusId = 42;
                }
                else if (btnSave.Text == "Save" && cbCompleted.Checked == true && !GIID)
                {
                    varUpdateflag = 0;
                    ViewType = 0;
                    varStatusId = 42;
                }
                else if (btnSave.Text == "Save as Draft" && cbCompleted.Checked == false && GIID)
                {
                    varUpdateflag = 0;
                    ViewType = 0;
                    varStatusId = 41;
                }               
                else if((btnSave.Text == "Update" && varUpdateflag==1) || (btnSave.Text == "Update" && Convert.ToInt32(cmbTransactionType.SelectedValue)==69))
                {
                    varUpdateflag = 1;
                    ViewType = 0;
                    varoriginator = "Goods Inward Queue Updation";
                    varStatusId = 42;
                }                
                bool blnErrorFlag = true;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epGoodsInward.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCompany.ShowAlways = true;
                    tpCompany.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtStockLocation.Text).Trim() == "")
                {
                    epGoodsInward.SetError(txtStockLocation, "Please enter stock location");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location", txtStockLocation, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epGoodsInward.SetError(cmbTransactionType, "Please select transaction type");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
                    blnErrorFlag = false;
                }
                if (grdInward.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                }

                if (varErrQty == 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                }
                for (int i = 0; i < grdInward.Rows.Count; i++)
                {
                    if (Convert.ToInt16(grdInward.Rows[i].Cells["clmExpiryErr"].Value) == 1 || Convert.ToInt16(grdInward.Rows[i].Cells["clmBatchErr"].Value) == 1)
                    {
                        blnErrorFlag = false;
                        if (Convert.ToDecimal(grdInward.Rows[i].Cells["clmExpiryErr"].Value) == 1)
                        {
                            grdInward.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                        }
                        if (Convert.ToDecimal(grdInward.Rows[i].Cells["clmBatchErr"].Value) == 1)
                        {
                            grdInward.Rows[i].Cells["clmbatchno"].Style.BackColor = Color.LightPink;
                        }
                    }
                    else
                    { 
                        if (Convert.ToDecimal(grdInward.Rows[i].Cells["clmExpiryErr"].Value) == 0)
                        {
                            grdInward.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                        }
                        if (Convert.ToDecimal(grdInward.Rows[i].Cells["clmBatchErr"].Value) == 0)
                        {
                            grdInward.Rows[i].Cells["clmbatchno"].Style.BackColor = Color.LightPink;
                        }
                    }
                    if (Convert.ToDecimal(grdInward.Rows[i].Cells["clmExpiryErr"].Value) == 0 && Convert.ToDecimal(grdInward.Rows[i].Cells["clmBatchErr"].Value) == 0)
                    {
                        grdInward.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                        grdInward.Rows[i].Cells["clmbatchno"].Style.BackColor = Color.PaleGreen;

                        if (Convert.ToString(grdInward.Rows[i].Cells["clmshelflifeper"].Value.ToString().Trim()) != "")
                        {
                            string shelfper = ""; decimal shelflifeper = 0;
                            object cellValue1 = Convert.ToString(grdInward.Rows[i].Cells["clmshelflifeper"].Value);

                            shelfper = cellValue1.ToString();
                            string[] shelfvalue = shelfper.Split('%');
                            shelflifeper = Convert.ToDecimal(shelfvalue[0]);
                            if (shelflifeper < (MainForm.pbShelflifeLevel2))
                            {
                                shelfLifeError++;
                            }
                        }
                    }
                    if (Convert.ToString(grdInward.Rows[i].Cells["clmBatchnoEnable"].Value) == "75")
                    {
                        if (Convert.ToString(grdInward.Rows[i].Cells["clmbatchno"].Value) == "")
                        {
                            blnErrorFlag = false;
                            grdInward.Rows[i].Cells["clmbatchno"].Style.BackColor = Color.LightPink;
                        }
                        else
                        {
                            grdInward.Rows[i].Cells["clmbatchno"].Style.BackColor = Color.PaleGreen;
                        }
                    }
                    else
                    {
                        if (Convert.ToString(grdInward.Rows[i].Cells["clmBatchnoEnable"].Value) == "74" || Convert.ToString(grdInward.Rows[i].Cells["clmBatchnoEnable"].Value) == "-1" || Convert.ToString(grdInward.Rows[i].Cells["clmBatchnoEnable"].Value) == "0" )
                        {
                            grdInward.Rows[i].Cells["clmbatchno"].Style.BackColor = Color.LightGray;
                        }
                        else
                        {
                            grdInward.Rows[i].Cells["clmbatchno"].Style.BackColor = Color.PaleGreen;
                        }
                    }
                    if ((Convert.ToString(grdInward.Rows[i].Cells["clmMRPFlag"].Value) == "1") && ((Convert.ToString(grdInward.Rows[i].Cells["clmmrp"].Value) == "") || (Convert.ToDecimal(grdInward.Rows[i].Cells["clmmrp"].Value) == 0)))
                    {
                        grdInward.Rows[i].Cells["clmmrp"].Style.BackColor = Color.LightPink;
                        blnErrorFlag = false;
                    }
                    else if ((Convert.ToInt32(grdInward.Rows[i].Cells["clmMRPFlag"].Value) == 1) && (Convert.ToString(grdInward.Rows[i].Cells["clmmrp"].Value) != ""))
                    {
                        grdInward.Rows[i].Cells["clmmrp"].Style.BackColor = Color.PaleGreen;
                    }
                }
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
                if (blnErrorFlag == true && varUpdateflag==0 && shelfLifeError==0)
                {
                    udfntooltiphide();
                    epGoodsInward.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();                   
                    TRN_GoodsInward objTRNS_GoodsInward = new TRN_GoodsInward();
                    objTRNS_GoodsInward.ViewType = ViewType;
                    objTRNS_GoodsInward.paraGIID = varGIId;
                    objTRNS_GoodsInward.paraSTRID = varSTRID;
                    objTRNS_GoodsInward.paraCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNS_GoodsInward.paraInwardDate = dpInwardDate.Text;
                    objTRNS_GoodsInward.paraTransferType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                    objTRNS_GoodsInward.paraSLID = Convert.ToInt32(varStockLocationId);
                    objTRNS_GoodsInward.paraRemarks = txtRemark.Text;
                    objTRNS_GoodsInward.paraGoodsInward = dtInward;
                    objTRNS_GoodsInward.paraFlag = varUpdateflag;
                    objTRNS_GoodsInward.paraStatusId = varStatusId;
                    objTRNS_GoodsInward.paraOriginator = varoriginator;
                    result = objspdservice.udfnGoodsInward(objTRNS_GoodsInward);
                    objspdservice.CloseConnection();

                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = txtProductName;
                        MainForm.objINV_Inwardlist.udfnList();
                        if (cbCompleted.Checked == true)
                        {
                            string InwardId = "0";
                            if (varGIId == 0)
                            {
                                InwardId = varvalue[2];
                            }
                            else
                            {
                                InwardId = Convert.ToString(varGIId);
                            }
                            udfnInwardReport(InwardId);
                        }
                        //udfnClear();
                        this.Close();
                    }
                    else
                    {
                        epGoodsInward.Clear();
                        txtProductName.BackColor = Color.White;
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = true;
                        btnSave.Focus();
                    }
                }
                else if(blnErrorFlag == true && varUpdateflag == 1)
                {
                    udfntooltiphide();
                    epGoodsInward.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();
                    TRN_GoodsInward objTRNS_GoodsInward = new TRN_GoodsInward();
                    objTRNS_GoodsInward.ViewType = ViewType;
                    objTRNS_GoodsInward.paraSTRID = varSTRID;
                    objTRNS_GoodsInward.paraCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNS_GoodsInward.paraInwardDate = dpInwardDate.Text;
                    objTRNS_GoodsInward.paraTransferType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                    objTRNS_GoodsInward.paraSLID = Convert.ToInt32(varSLID);
                    objTRNS_GoodsInward.paraRemarks = txtRemark.Text;
                    objTRNS_GoodsInward.paraGoodsInward = dtInward;
                    objTRNS_GoodsInward.paraFlag = varUpdateflag;
                    objTRNS_GoodsInward.paraStatusId = varStatusId;
                    objTRNS_GoodsInward.paraOriginator = varoriginator;
                    result = objspdservice.udfnGoodsInward(objTRNS_GoodsInward);
                    objspdservice.CloseConnection();

                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = txtProductName;
                        MainForm.objINV_InwardlistQueue.udfnDate();
                        MainForm.objINV_InwardlistQueue.udfnList();
                        //udfnClear();
                        this.Close();
                    }
                    else
                    {
                        epGoodsInward.Clear();
                        txtProductName.BackColor = Color.White;
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = true;
                        btnSave.Focus();
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
                grdInward.ClearSelection();
            }
        }
        public void udfnInwardReport(string varInwardId)
        {
            try
            {
                DialogResult result1;
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(87);
                objDServ.CloseConnection();
                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_GoodsInward.rpt");
                    varHeader = "Goods Inward Report";

                    objBillreport.SetParameterValue("paraGIID", Convert.ToInt32(varInwardId));
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);

                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                    MainForm.objReportLoad.Text = varHeader;
                    MainForm.objReportLoad.ShowDialog();
                }
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
                MainForm.objPUR_RemarksHistory.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtProductName.Text = "";
                txtRack.Text = "";
                txtMrp.Text = "";
                txtDay.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchNo.Text = "";
                txtActualQty.Text = "";
                //txtOutwardQuantity.Text = "";
                //lblQuantity.Text = "";
                //udfnSLocationValid();
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0 || txtStockLocation.Text == " ")
                {
                    var ViewType = 26;
                    objDs = objspdservice.udfnStockLocationList(ViewType, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text, 0, 0, 0, "", "",0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_TName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(), };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvStockLocation.Items.Add(objList);
                                }
                                lvStockLocation.Visible = true;
                            }
                            else
                            {
                                lvStockLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvStockLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvStockLocation.Visible = false;
                    }
                }

                else
                {
                    lvStockLocation.Visible = false;
                    lvStockLocation.Items.Clear();
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
        public void udfnCmbConcern()
        {
            try
            {
                //cmbConcern.Focus();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(3, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvStockLocation()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    ListViewItem selectedItem = lvStockLocation.SelectedItems[0];
                    txtStockLocation.Text = selectedItem.SubItems[0].Text;
                    varStockLocationId = selectedItem.SubItems[2].Text;
                    udfnRackcheck();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvStockLocation.Visible = false;
            }
        }
        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    //if (lvproduct.Items.Count == 0 && txtProductName.Text == "")
                    //{
                    //    txtMrp.Focus();
                    //    lvproduct.Visible = false;
                    //}
                    //else
                    //{
                    //    lvproduct.Focus();
                    //}
                    //if (lvproduct.Items.Count > 0)
                    //{
                    //    lvproduct.Items[0].Selected = true;
                    //}
                    DGV_FilterProduct.Focus();

                }
                //if (e.KeyCode == Keys.Enter)
                //{
                //    txtMrp.Focus();
                //}
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblProductName.Text = "Search by P.I Code (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductName.Text = "Search by Product Name (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    if (txtMrp.Enabled == true)
                    {
                        txtMrp.Focus();
                    }
                    else
                    {
                        if (txtDay.Enabled == true)
                        {
                            txtDay.Focus();
                        }
                        else
                        {
                            if (txtBatchNo.Enabled == true)
                            {
                                txtBatchNo.Focus();
                            }
                            else
                            {
                                txtActualQty.Focus();
                            }
                        }
                    }
                }
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
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
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
                        if (txtMrp.Enabled==true)
                        {
                            txtMrp.Focus();
                        }
                        else if (txtDay.Enabled==true)
                        {
                            txtDay.Focus();
                        }
                        else if (txtBatchNo.Enabled==true)
                        {
                            txtBatchNo.Focus();
                        }
                        else
                        {
                            txtActualQty.Focus();
                        }
                    }
                }
                if (e.KeyCode == Keys.F10)
                {
                    varEditPRID = varPRID;
                    varAutocompleteProduct = 1;
                    udfnProDataChange();
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
                MainForm.objCP_Items.varMasterType = "4";
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
        private void TxtDay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDay.TextAlign = HorizontalAlignment.Right;
                if (txtDay.Text.Length == 2)
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
                txtMonth.TextAlign = HorizontalAlignment.Right;
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
        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
                lvStockLocation.Visible = false;
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
                    epGoodsInward.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCompany.ShowAlways = true;
                    tpCompany.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    epGoodsInward.Clear();
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
                    dpInwardDate.Focus();
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
        private void DpInwardDate_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                lvStockLocation.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpInwardDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation();
                    txtStockLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
                lvRack.Visible = false;
                //udfnLvStockLocation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.White;
                if (txtStockLocation.Text == "")
                {
                    varStockLocationId = "0";
                    epGoodsInward.SetError(txtStockLocation, "Please enter stock location");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location", txtStockLocation, 5000);
                }
                else
                {
                    epGoodsInward.Clear();
                    txtStockLocation.BackColor = Color.White;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvStockLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        txtProductName.Focus();
                        lvStockLocation.Visible = false;
                    }
                    else
                    {
                        lvStockLocation.Focus();
                    }
                    if (lvStockLocation.Items.Count > 0)
                    {
                        lvStockLocation.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtRack.Focus();
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
                DGV_FilterProduct.Visible = false;
                lvStockLocation.Visible = false;
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
                    epGoodsInward.SetError(cmbTransactionType, "Please select transaction type");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
                }
                else
                {
                    epGoodsInward.Clear();
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
                    txtProductName.Focus();
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
                lvRack.Visible = false;
                lvStockLocation.Visible = false;
                //udfnListviewProduct();
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
                //if (Convert.ToString(txtProductName.Text.Trim()) == "")
                //{
                //    epGoodsInward.SetError(txtProductName, "Please enter the product");
                //    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpProduct.ShowAlways = true;
                //    tpProduct.Show("Please enter the product", txtProductName, 5000);
                //}
                //else
                //{
                //    epGoodsInward.Clear();
                //    txtProductName.BackColor = Color.White;
                //    tpProduct.Active = false;
                //}
                epGoodsInward.Clear();
                txtProductName.BackColor = Color.White;
                tpProduct.Active = false;
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
                lvStockLocation.Visible = false;
                DGV_FilterProduct.Visible = false;
                //DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                lvRack.Visible = false;
                //udfnListviewProduct();
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
                decimal varMRP = Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                string mrp = string.Format("{0:0.00}", varMRP);
                string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                txtMrp.Text = mrp;
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
                    if (txtDay.Enabled == true)
                    {
                        txtDay.Focus();
                    }
                    else
                    {
                        if (txtBatchNo.Enabled == true)
                        {
                            txtBatchNo.Focus();
                        }
                        else
                        {
                            txtActualQty.Focus();
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
        private void TxtBatchNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchNo.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBatchNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtActualQty.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
                //udfnListviewProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtActualQty.Text) == "")
                {
                    epGoodsInward.SetError(txtActualQty, "Please enter the quantity");
                    txtActualQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter the quantity", txtActualQty, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtActualQty.Text).Trim(), varDecimal);
                    txtActualQty.Text = Qty;
                    epGoodsInward.Clear();
                    txtActualQty.BackColor = Color.White;
                    tpQuantity.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtActualQty_KeyPress(object sender, KeyPressEventArgs e)
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
        private void LvStockLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvStockLocation();
                txtRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation();
                    if (txtRack.Enabled == false)
                    { txtProductName.Focus(); }
                    else
                    { txtRack.Focus(); }
                    txtRack.Focus();
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
                txtMrp.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            udfnListviewProduct();
        //            txtMrp.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}
        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnRackAutocomplete();
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnRackAutocomplete();
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtRack.Text == "")
                {
                    txtRack.Enabled = true;
                }
                DGV_FilterProduct.Visible = false;
                lvStockLocation.Visible = false;
                txtRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductName.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvRack.Items.Count == 0 || txtRack.Text == "")
                    {
                        txtRack.Focus();
                        lvRack.Visible = false;
                    }
                    else
                    {
                        lvRack.Focus();
                    }
                    if (lvRack.Items.Count > 0)
                    {
                        lvRack.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAdd()
        {
            try
            {
                if (Convert.ToDecimal(txtActualQty.Text.Trim()) == 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(77);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // udfnExpiryDate();
                    if (pbDateflag == 0)
                    {
                        if (txtMrp.Text == "")
                        { txtMrp.Text = "0"; }
                        decimal varMRP = Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                        string mrp = string.Format("{0:0.00}", varMRP);
                        string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                        string[] varShelflifeper = Convert.ToString(varShelflifevalue).Split(' ');
                        if (varShelflifevalue == "")
                        {
                            varShelflifeper[0] = "0";
                        }
                        if (txtActualQty.Text != "")
                        {
                            string Qty = objValidation.udfnDecimal((txtActualQty.Text).Trim(), varDecimal);
                            txtActualQty.Text = Qty;
                        }
                        grdInward.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                        grdInward.Rows.Add(grdInward.Rows.Count + 1,txtRack.Text,varPICode.Trim(), varTamilname.Trim(), Convert.ToDecimal(mrp), varExpiryDate, Shelflife, varAcutalshelflife,varShelflifevalue,txtBatchNo.Text.Trim(), txtActualQty.Text, 0, txtActualQty.Text, txtunit.Text,varPRID,varRKID,varStockLocationId,varUTID, varDecimal, varMRPFlag, varRMProductionFlag, varShelflife,varBatchNo,varBatchNoGeneration);
                        dtInward.Rows.Add(varPRID, Convert.ToDecimal(txtMrp.Text), varExpiryDate, txtBatchNo.Text.Trim(),txtActualQty.Text.Trim(),varRKID,varStockLocationId,0,0,varShelflife,ProductShelflifeValue,ProductShelflifeType,varShelflifeper[0],varMRPFlag,varRMProductionFlag, varBatchNo, varBatchNoGeneration, Shelflifevalue);
                        txttotalitem.Text = Convert.ToString(grdInward.Rows.Count);
                        //((DataGridViewTextBoxColumn)grdInward.Columns["clmQuantity"]).MaxInputLength = 8;
                        grdInward.Columns["clmactualqty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                        
                        if(varMRPEditFlag==1)
                        {
                            grdInward.Columns["clmMRPFlag"].ReadOnly = false;
                        }
                        else
                        {
                            grdInward.Columns["clmMRPFlag"].ReadOnly = true;
                        }
                        ////grdPurchaseDC.Columns["clmQuantity"].ReadOnly = false;
                        grdInward.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdInward.Columns["clmexpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdInward.Columns["clmactualqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdInward.Columns["clmshelflifeper"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdInward.Columns["clmproductname"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                        if (varDateEnable == 1)
                        {
                            DataGridView dataGridView = grdInward;
                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmexpirydate"];
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = true;
                        }
                        if (varRMProductionFlag == 1)
                        {
                            DataGridView dataGridView = grdInward;
                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmexpirydate"];
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = true;
                        }
                        if (varMRPEditFlag == 0)
                        {
                            DataGridView dataGridView = grdInward;
                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmmrp"];
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = true;
                        }
                        if (varRMProductionFlag == 1)
                        {
                            DataGridView dataGridView = grdInward;
                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmexpirydate"];
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = true;
                        }
                        if (varShelflifeper[0] != "")
                        {
                            //Shelflife Wise Color Set
                            if (Convert.ToDecimal(varShelflifeper[0]) <= (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifeper[0]) != 0)
                            {
                                DataGridView dataGridView = grdInward;
                                DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                cell.Style.BackColor = Color.Red;
                                cell.Style.ForeColor = Color.White;
                            }
                            else if (Convert.ToDecimal(varShelflifeper[0]) > (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel2) && Convert.ToDecimal(varShelflifeper[0]) != 0)
                            {
                                DataGridView dataGridView = grdInward;
                                DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                cell.Style.BackColor = Color.Orange;
                                cell.Style.ForeColor = Color.Black;
                            }
                            else
                            {
                                DataGridView dataGridView = grdInward;
                                DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                cell.Style.BackColor = Color.White;
                                cell.Style.ForeColor = Color.Black;
                            }
                        }
                        if (varBatchNo == "72" && varBatchNoGeneration == "75")
                        {
                            DataGridView dataGridView = grdInward;
                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmbatchno"];
                            cell.Style.BackColor = Color.PaleGreen;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = false;
                        }
                        if (varBatchNo == "72" && varBatchNoGeneration == "74")
                        {
                            DataGridView dataGridView = grdInward;
                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmbatchno"];
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = true;
                        }
                        else if (varBatchNo == "73")
                        {
                            DataGridView dataGridView = grdInward;
                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmbatchno"];
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = true;
                        }
                        udfnProductClear();
                        txtProductName.Focus();
                        //txtProductName.Text = "";
                        varPRID = "0";
                        udfnShelflifeCheck();
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
                grdInward.ClearSelection();
            }
        }
        public void udfnProductClear()
        {
            try
            {
                txtProductName.Text = "";
                txtMrp.Text = "";
                txtDay.Text = "";
                txtBatchNo.Text = "";
                txtActualQty.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                varPRID = "";
                varPICode = "";
                varRKID = "";
                varUTID = "";
                txtunit.Text = "";
                varExpiryDate = "";
                varTamilname = ""; 
                Shelflife = "";
                    varAcutalshelflife = "";
                varShelflifevalue = "";
                varMRPFlag =0;
                varRMProductionFlag = 0;
                varShelflife = 0;
                varBatchNo = "";
                varBatchNoGeneration = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnShelflifeCheck()
        {
            try
            {
                string[] varShelflifeper = Convert.ToString(varShelflifevalue).Split(' ');
                if (varShelflifeper[0] != "")
                {
                    //Shelflife Wise Color Set
                    if (Convert.ToDecimal(varShelflifeper[0]) <= (MainForm.pbShelflifeLevel1))
                    {
                        DataGridView dataGridView = grdInward;
                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                        cell.Style.BackColor = Color.Red;
                        cell.Style.ForeColor = Color.White;
                        txtRDPercentageCheck.Enabled = true;
                        lbltwentyfiveper.Enabled = true;
                        txtORPercentageCheck.Enabled = false;
                        lblFivetyPercentage.Enabled = false;
                    }
                    else if (Convert.ToDecimal(varShelflifeper[0]) > (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel2))
                    {
                        DataGridView dataGridView = grdInward;
                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                        cell.Style.BackColor = Color.Orange;
                        cell.Style.ForeColor = Color.Black;
                        txtORPercentageCheck.Enabled = true;
                        lblFivetyPercentage.Enabled = true;
                        txtRDPercentageCheck.Enabled = false;
                        lbltwentyfiveper.Enabled = false;
                    }
                    else
                    {
                        DataGridView dataGridView = grdInward;
                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                        cell.Style.BackColor = Color.White;
                        cell.Style.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtDay_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMonth.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epGoodsInward.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epGoodsInward.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epGoodsInward.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epGoodsInward.Clear();
                    }
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
        private void TxtYear_Enter(object sender, EventArgs e)
        {
            try
            {
                txtYear.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBatchNo.Enabled == true)
                    {
                        txtBatchNo.Focus();
                    }
                    else
                    {
                        txtActualQty.Focus();
                    }
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
        private void TxtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epGoodsInward.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epGoodsInward.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epGoodsInward.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epGoodsInward.Clear();
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
                varDateChange = 0;
                udfnVocherno();
                grdInward.Rows.Clear();
                if (btnSave.Text == "Save as Draft")
                {
                    txtStockLocation.Text = "";
                    txttotalitem.Text = Convert.ToString(grdInward.Rows.Count);
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
                if (btnSave.Text == "Update" && varEditflag == 0)
                {
                }
                else
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpInwardDate.Text + "',103)");
                        varResult = objspdservice.udfngetVoucherNo("41", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] varvalue = varResult.Split('~');
                        if (varResult != "")
                        {
                            txtInwardNo.Text = varvalue[0];
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
                txtInwardNo.Text = "";
                if (varVoucherSkip == false)
                {
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        varVoucherSkip = true;
                        varClose = 1;
                        udfnclose();
                        MainForm.objCP_Settings = new CP_Settings();
                        //MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                        //MainForm.objCP_Settings.varValues = Convert.ToString(44);
                        MainForm.objCP_Settings.MdiParent = this.ParentForm;
                        MainForm.objCP_Settings.Show();
                    }
                    else { varVoucherSkip = true; }
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
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 68) // Regular
                {
                    grdInward.Columns["clmreceivedqty"].Width = 0;
                    grdInward.Columns["clmtransferqty"].Width = 0;
                    grdInward.Columns["clmreceivedqty"].Visible = false;
                    grdInward.Columns["clmtransferqty"].Visible = false;
                    btnRemarks.Enabled = false;
                }
                else // Stock Transfer
                {
                    grdInward.Columns["clmreceivedqty"].Width = 90;
                    grdInward.Columns["clmtransferqty"].Width = 100;
                    grdInward.Columns["clmactualqty"].Width = 0;
                    grdInward.Columns["clmreceivedqty"].Visible = true;
                    grdInward.Columns["clmtransferqty"].Visible = true;
                    grdInward.Columns["clmactualqty"].Visible = false;
                    grdInward.Columns["clmremove"].Visible = false;
                    btnRemarks.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtActualQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMrp.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdInward_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varRKID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "", varProductID="";
                if (e.RowIndex != -1)
                {
                    switch (grdInward.Columns[e.ColumnIndex].Name)
                    {
                        case "clmremove":
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            varProductID = Convert.ToString(grdInward.CurrentRow.Cells["clmPRID"].Value);
                            varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdInward.CurrentRow.Cells["clmmrp"].Value)));
                            varExpiryDate = Convert.ToString(grdInward.CurrentRow.Cells["clmexpirydate"].Value);
                            varBatchNo = Convert.ToString(grdInward.CurrentRow.Cells["clmbatchno"].Value);
                            varRKID = Convert.ToInt32(grdInward.CurrentRow.Cells["clmRKID"].Value);
                            grdInward.Rows.RemoveAt(this.grdInward.CurrentRow.Index);
                            for (int i = 0; i < grdInward.RowCount; i++)
                            {
                                grdInward.Rows[i].Cells["clmsno"].Value = i + 1;
                            }
                            for (int i = 0; i < dtInward.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dtInward.Rows[i]["GIPR_PRID"]) == Convert.ToInt32(varProductID) && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtInward.Rows[i]["GIPR_MRP"]))) == varMRP && Convert.ToString(dtInward.Rows[i]["GIPR_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtInward.Rows[i]["GIPR_BatchNo"]) == varBatchNo && Convert.ToInt32(dtInward.Rows[i]["GIPR_RKID"]) == Convert.ToInt32(varRKID))
                                {
                                    dtInward.Rows[i].Delete();
                                    dtInward.AcceptChanges();
                                }
                            }
                        }
                        break;
                    }
                }

                varChangeFlag = false;
            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txttotalitem.Text = Convert.ToString(dtInward.Rows.Count);
                if (dtInward.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                    txtStockLocation.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                    txtStockLocation.Enabled = true;
                    txtStockLocation.BackColor = Color.White;
                    cmbConcern.BackColor = Color.White;

                }
            }
        }
        private void GrdInward_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                try
                {
                    if (grdInward.CurrentCell.OwningColumn.Name == "clmactualqty" || grdInward.CurrentCell.OwningColumn.Name=="clmexpirydate" || grdInward.CurrentCell.OwningColumn.Name == "clmmrp")
                    {
                        e.Control.KeyPress -= udfnHandleKeyPress;
                        e.Control.KeyPress += udfnHandleKeyPress;
                    }
                    if (grdInward.CurrentCell.OwningColumn.Name == "clmactualqty" || grdInward.CurrentCell.OwningColumn.Name == "clmmrp")
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
                if (grdInward.CurrentCell.OwningColumn.Name == "clmactualqty")
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
                if (grdInward.CurrentCell.OwningColumn.Name == "clmmrp")
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
       
        private void GrdInward_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal Quantity = Convert.ToDecimal(grdInward.CurrentRow.Cells["clmactualqty"].Value);
                string ExpiryDate = Convert.ToString(grdInward.CurrentRow.Cells["clmexpirydate"].Value);
                string BatchNo = Convert.ToString(grdInward.CurrentRow.Cells["clmBatchNo"].Value);
                string batchGeneration = Convert.ToString(grdInward.CurrentRow.Cells["clmBatchnoEnable"].Value);
                if (grdInward.CurrentCell.OwningColumn.Name == "clmactualqty")
                {
                    if (Convert.ToDecimal(Quantity) == 0 || Convert.ToString(Quantity) == "")
                    {
                        grdInward.Rows[e.RowIndex].Cells["clmactualqty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrQty = 1;
                    }
                    else
                    {
                        grdInward.CurrentRow.Cells["clmactualqty"].Style.BackColor = Color.PaleGreen;
                        varErrQty = 0;
                    }
                    int varDecimal = Convert.ToInt32(grdInward.CurrentRow.Cells["clmUnitDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdInward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                    grdInward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                    object varEditQty = grdInward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // Update the same column value in the DataTable
                    dtInward.Rows[e.RowIndex]["GIPR_QTY"] = varEditQty;
                }
                if (grdInward.CurrentCell.OwningColumn.Name == "clmexpirydate")
                {
                    int rowIndex = e.RowIndex, columnIndex = e.ColumnIndex, PR_Shelflife = 0, Date = 0;
                    varTempExpiryDate = Convert.ToString(grdInward.Rows[rowIndex].Cells["clmexpirydate"].Value);
                    if (grdInward.Rows.Count > 0)
                    {
                        PR_Shelflife = Convert.ToInt32(grdInward.Rows[rowIndex].Cells["clmShelflifeenable"].Value);
                    }
                    if (PR_Shelflife == 1)
                    {
                        if (grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value == null && Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value) == "0")
                        {
                            MessageBox.Show("Please enter expirydate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                        }
                    }
                    if (grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value != null && Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value) != "0")
                    {
                        MR_Master objMR_Master = new MR_Master();
                        objMR_Master.ViewType = 8;
                        objMR_Master.paraDate = varTempExpiryDate.Trim();
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
                                    grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                }
                                else
                                {
                                    if (varErrorFormat != 5)
                                    {
                                        //grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.PaleGreen;
                                    }
                                }
                            }
                        }
                    }
                    if ((ExpiryDate == "0" || ExpiryDate == "") && PR_Shelflife == 1)
                    {
                        varErrExpiryDate = "1";
                        grdInward.Rows[e.RowIndex].Cells["clmExpiryErr"].Value = varErrExpiryDate;
                        grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                    }
                    else
                    {
                        varErrExpiryDate = "0";
                        grdInward.Rows[e.RowIndex].Cells["clmExpiryErr"].Value = varErrExpiryDate;
                        //grdPurchaseDC.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.PaleGreen;
                    }
                    if (batchGeneration == "73") //Disabled
                    {
                        if (BatchNo == "")
                        {
                            varErrBatchNo = "1";
                            grdInward.Rows[e.RowIndex].Cells["clmBatchErr"].Value = varErrBatchNo;
                            grdInward.Rows[e.RowIndex].Cells["clmbatchno"].Style.BackColor = Color.LightPink;
                        }
                        else
                        {
                            varErrBatchNo = "0";
                            grdInward.Rows[e.RowIndex].Cells["clmBatchErr"].Value = varErrBatchNo;
                            grdInward.Rows[e.RowIndex].Cells["clmbatchno"].Style.BackColor = Color.PaleGreen;
                        }
                    }
                    if (Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value).Trim() != "" && Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value).Trim() != "0")
                    {
                        //Update the same column value in the DataTable
                        object varEditExpiry = grdInward.Rows[e.RowIndex].Cells["clmExpiryDate"].Value;
                        object varEditActualLife = grdInward.Rows[e.RowIndex].Cells["clmactualshelflife"].Value;
                        string[] Actual = Convert.ToString(varEditActualLife).Split(' ');
                        object varEditShelflifePer = grdInward.Rows[e.RowIndex].Cells["clmshelflifeper"].Value;
                        string[] ShelflifePer = Convert.ToString(varEditShelflifePer).Split(' ');

                        dtInward.Rows[e.RowIndex]["GIPR_ExpiryDate"] = varEditExpiry;
                        dtInward.Rows[e.RowIndex]["GIPR_ShelfLifePer"] = ShelflifePer[0];
                        dtInward.Rows[e.RowIndex]["GIPR_ShelfLifeFlag"] = Actual[0];
                    }
                    else
                    {
                        varErrExpiryDate = "1";
                        grdInward.Rows[e.RowIndex].Cells["clmExpiryErr"].Value = varErrExpiryDate;
                        grdInward.Rows[e.RowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                    }
                }
                if(grdInward.CurrentCell.OwningColumn.Name == "clmmrp")
                {
                    object varMRP = grdInward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // Update the same column value in the DataTable
                    dtInward.Rows[e.RowIndex]["GIPR_MRP"] = varMRP;
                }
                if(grdInward.CurrentCell.OwningColumn.Name == "clmbatchno")
                {
                    object varbatch = grdInward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // Update the same column value in the DataTable
                    dtInward.Rows[e.RowIndex]["GIPR_BatchNo"] = varbatch;
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
                int varDecimal = Convert.ToInt32(grdInward.CurrentRow.Cells["clmUnitDecimal"].Value);
                if (grdInward.CurrentCell.OwningColumn.Name == "clmactualqty" || grdInward.CurrentCell.OwningColumn.Name == "clmmrp")
                {
                    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    //{
                    //    e.Handled = true;  // Disallow the character
                    //}
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
                if (grdInward.CurrentCell.OwningColumn.Name == "clmexpirydate")
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

        private void INV_Inward_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                udfntooltiphide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdInward_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                try
                {
                    grdInward.Columns["clmactualqty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
                finally
                {

                }
                grdInward.ClearSelection();
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

        private void GrdInward_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdInward.IsCurrentCellDirty)
                {
                    grdInward.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
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

        private void GrdInward_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string varshelflife = "";
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                int varCellprodid = 0;
                if (grdInward.Columns[e.ColumnIndex].Name == "clmexpirydate")
                {
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    if (Convert.ToString(grdInward.Rows[e.RowIndex].Cells["clmexpirydate"].Value) != "")
                    {
                        varCellprodid = Convert.ToInt32(grdInward.Rows[e.RowIndex].Cells["clmPRID"].Value);
                        if (rowIndex >= 0 && columnIndex >= 0)
                        {
                            string varTempYear = "0", varTempMonth = "0", varTempDay = "0";
                            object cellValue = grdInward.Rows[rowIndex].Cells[columnIndex].Value;
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

                                    objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", 0, 0, 0, varshelflife, dpInwardDate.Text, varCellprodid, 0, "0", "", "", 0, 0, 0, 0);
                                objdserv.CloseConnection();
                                if (objDs != null )
                                {
                                    if (objDs.Tables[0].Rows.Count != 0)
                                    {
                                        if (objDs.Tables[0].Rows.Count > 0)
                                        {
                                            grdInward.Rows[rowIndex].Cells["clmshelflifeper"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
                                        }

                                        if (objDs.Tables[1].Rows.Count != 0)
                                        {
                                            if (objDs.Tables[1].Rows.Count > 0)
                                            {
                                                grdInward.Rows[rowIndex].Cells["clmactualshelflife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
                                            }
                                        }
                                    }
                                    string[] varShelflifevalue = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]).Split(' ');
                                    if (varShelflifevalue[0] != "")
                                    {
                                        //Shelflife Wise Color Set
                                        if (Convert.ToDecimal(varShelflifevalue[0]) <= (MainForm.pbShelflifeLevel1))
                                        {
                                            DataGridView dataGridView = grdInward;
                                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactualshelflife"];
                                            cell.Style.BackColor = Color.Red;
                                            cell.Style.ForeColor = Color.White;
                                        }
                                        else if (Convert.ToDecimal(varShelflifevalue[0]) > (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifevalue[0]) < (MainForm.pbShelflifeLevel2))
                                        {
                                            DataGridView dataGridView = grdInward;
                                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactualshelflife"];
                                            cell.Style.BackColor = Color.Orange;
                                            cell.Style.ForeColor = Color.Black;
                                        }
                                        else
                                        {
                                            DataGridView dataGridView = grdInward;
                                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactualshelflife"];
                                            cell.Style.BackColor = Color.White;
                                            cell.Style.ForeColor = Color.Black;
                                        }
                                    }
                                }
                            }
                        }
                        grdInward.Rows[e.RowIndex].Cells["clmexpirydate"].Value = varTempExpiryDate;
                        udfnGridaddvalue(sender, e);
                    }
                    else
                    {
                        grdInward.Rows[rowIndex].Cells["clmactualshelflife"].Value = "";
                        grdInward.Rows[rowIndex].Cells["clmshelflifeper"].Value = "";
                        DataGridView dataGridView = grdInward;
                        DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactualshelflife"];
                        DataGridViewCell cell1 = dataGridView.Rows[rowIndex].Cells["clmshelflifeper"];
                        cell.Style.BackColor = Color.White;
                        cell.Style.ForeColor = Color.Black;
                        cell1.Style.BackColor = Color.White;
                        cell1.Style.ForeColor = Color.Black;
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
                if (grdInward.CurrentCell.OwningColumn.Name == "clmexpirydate")
                {
                    varExpiryDate = Convert.ToString(grdInward.Rows[rowIndex].Cells["clmexpirydate"].Value);
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
                varProid = Convert.ToInt32(grdInward.Rows[rowIndex].Cells["clmPRID"].Value);
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 10;
                objMR_Master.paraDate = dpInwardDate.Text.Trim();
                objMR_Master.ParaExpiryDate = varTempExpiryDate;
                objMR_Master.paraProductId = varProid;
                int varInvFlag = 0;
                objDS = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                //for (int i = 0; i < grdPurchaseDC.Rows.Count; i++)
                //{
                varShelflife = Convert.ToInt32(grdInward.Rows[rowIndex].Cells["clmShelflifeenable"].Value);
                pbDateflag = 0; varInvFlag = 0;
                //varInvFlag = Convert.ToInt16(grdPurchaseDC.Rows[i].Cells["clmInvFlag"].Value);
                if (pbDateflag == 0)
                {
                    if (grdInward.CurrentCell.OwningColumn.Name == "clmexpirydate")
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
                                            if (Convert.ToString(grdInward.Rows[rowIndex].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                                            {
                                                varErrorFormat = 5;
                                                grdInward.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                                string varMessage = objDServ.udfnGetMessages(98);
                                                objDServ.CloseConnection();
                                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                        else
                                        {
                                            grdInward.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
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
                        if (Convert.ToString(grdInward.Rows[rowIndex].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                        {
                            // varErroronGrid = 1;
                            grdInward.Rows[rowIndex].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
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
        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnGridviewProduct();
                //    udfnPossibleSupplierLoad();
                //}
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
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

                            txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
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
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtMrp.Enabled == true)
                        {
                            txtMrp.Focus();
                        }
                        else if (txtDay.Enabled == true)
                        {
                            txtDay.Focus();
                        }
                        else if (txtBatchNo.Enabled == true)
                        {
                            txtBatchNo.Focus();
                        }
                        else
                        {
                            txtActualQty.Focus();
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

        private void GrdInward_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F10)
                {
                    if (grdInward.CurrentCell.OwningColumn.Name == "clmpicode" || grdInward.CurrentCell.OwningColumn.Name == "clmproductname")
                    {
                        varEditPRID = Convert.ToString(grdInward.CurrentRow.Cells["clmPRID"].Value);
                        varAutocompleteProduct = 2;
                        udfnProDataChange();
                    }
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
                if (txtMrp.Enabled == true)
                {
                    txtMrp.Focus();
                }
                else if (txtDay.Enabled == true)
                {
                    txtDay.Focus();
                }
                else if (txtBatchNo.Enabled == true)
                {
                    txtBatchNo.Focus();
                }
                else
                {
                    txtActualQty.Focus();
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
        private void TxtRemark_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRemark.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //btnRemarks.Focus();
                    cbCompleted.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRack.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdInward_Enter(object sender, EventArgs e)
        {
            try
            {
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemark_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRemark.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbCompleted_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int varStatusId = 0;
                if (cbCompleted.Checked)
                {
                    BtnSave_Click(sender, e);
                }
                else
                {
                    btnSave.Text = "Save as Draft";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbCompleted.Checked)
                {
                    btnSave.Text = "Save";
                    varStatusId = 42;
                }
                else
                {
                    btnSave.Text = "Save as Draft";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpInwardDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                varDateChange = 1;
                udfnVocherno();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GbshelfLife_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(varShelflifevalue)< (MainForm.pbShelflifeLevel1))
                {
                    txtRDPercentageCheck.Enabled = true;
                    lbltwentyfiveper.Enabled = true;
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
                tpCompany.Active = false;
                tpDay.Active = false;
                tpMonth.Active = false;
                tpYear.Active = false;
                tpBatchNo.Active = false;
                tpQuantity.Active = false;
                tpStockLocation.Active = false;
                tpProduct.Active = false;
                tpTransactionType.Active = false;
                tpmrp.Active = false;
                tpbatch.Active = false;
                tprack.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_Inward_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                txtMrp.TextAlign = HorizontalAlignment.Right;
                if (e.KeyCode == Keys.Escape)
                {
                    DGV_FilterProduct.Visible = false;
                    lvStockLocation.Visible = false;
                    udfntooltiphide();
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.DataSource = null;
                bool blnErrorFlag = false; pbDateflag = 0; ProShelflife = 0; Shelflifevalue = 0;
                if (Convert.ToString(txtProductName.Text).Trim() == "")
                {
                    epGoodsInward.SetError(txtProductName, "Please enter product.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    if (varPRID == "0")
                    {
                        epGoodsInward.SetError(txtProductName, "Please enter valid product.");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpProduct.ShowAlways = true;
                        tpProduct.Show("Please enter valid product.", txtProductName, 5000);
                        blnErrorFlag = true;
                    }

                }

                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epGoodsInward.SetError(txtMonth, "Please enter month.");
                        blnErrorFlag = true;
                    }
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epGoodsInward.SetError(txtYear, "Please enter year.");
                        blnErrorFlag = true;
                    }
                }
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchNo.Text.Trim() == "")
                    {
                        txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epGoodsInward.SetError(txtBatchNo, "Please enter BatchNo.");
                        tpBatchNo.ShowAlways = true;
                        tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epGoodsInward.SetError(txtActualQty, "Please enter quantity.");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity.", txtActualQty, 5000);
                    blnErrorFlag = true;
                }
                if (txtStockLocation.Text.Trim() == "")
                {
                    txtStockLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epGoodsInward.SetError(txtStockLocation, "Please enter location.");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location.", txtStockLocation, 5000);
                    blnErrorFlag = true;
                }
                if (varMRPFlag==1 && (txtMrp.Text.Trim() =="" || Convert.ToDecimal(txtMrp.Text)==0))
                {
                    txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epGoodsInward.SetError(txtMrp, "Please enter MRP.");
                    tpmrp.ShowAlways = true;
                    tpmrp.Show("Please enter MRP.", txtMrp, 5000);
                    blnErrorFlag = true;
                }
              
                /* Check location is valid or not*/
                if (txtStockLocation.Text != "")
                {
                    string varLocationId = "0";
                    DataSet objDsLocation = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsLocation = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0, "", "",0);
                    objDServ3.CloseConnection();
                    if (objDsLocation != null)
                    {
                        if (objDsLocation.Tables.Count > 0)
                        {
                            if (objDsLocation.Tables[0].Rows.Count > 0)
                            {
                                varLocationId = Convert.ToString(objDsLocation.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varStockLocationId = Convert.ToString(varLocationId);
                    if (varLocationId == "0" || varLocationId == "-1")
                    {
                        epGoodsInward.SetError(txtStockLocation, "Please select valid location.");
                        txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please select location.", txtStockLocation, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtRack.Text.Trim() != "" && txtRack.Text.Trim() != "None" && txtRack.Text.Trim() != "none")
                {
                    /*check location have a rack or not*/
                    string varId_PurchaseRack = "0";
                    string varId_PurchaseRackCount = "0";
                    DataSet objDsPurchaseRack = new DataSet();
                    SPDataService objDServ6 = new SPDataService();
                    objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varStockLocationId), 0, txtRack.Text.Trim(), 0, 0);
                    objDServ6.CloseConnection();
                    if (txtRack.Text.Trim() != "")
                    {
                        if (varStockLocationId != "0")
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
                            varRKID = Convert.ToString(varId_PurchaseRack);
                            if (Convert.ToInt32(varId_PurchaseRackCount) > 0)
                            {
                                if (Convert.ToInt32(varId_PurchaseRack) < 0 || varId_PurchaseRack == "-1")
                                {
                                    epGoodsInward.SetError(txtRack, "Please enter valid rack.");
                                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                                    tprack.ShowAlways = true;
                                    tprack.Show("Please enter valid rack.", txtRack, 5000);
                                    blnErrorFlag = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (varStockLocationId != "0")
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
                            varRKID = Convert.ToString(varId_PurchaseRack);
                            if (Convert.ToInt32(varId_PurchaseRack) > 0)
                            {
                                epGoodsInward.SetError(txtRack, "Please enter rack.");
                                txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tprack.ShowAlways = true;
                                tprack.Show("Please enter rack.", txtRack, 5000);
                                blnErrorFlag = true;
                            }
                            if (varId_PurchaseRack == "0")
                            {
                                txtRack.Text = "None";
                                txtRack.Enabled = false;
                                varRKID = "0";
                            }
                            else
                            {
                                txtRack.Enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    txtRack.Text = "None";
                    //txtRack.Enabled = false;
                    //txtRack.BackColor = SystemColors.Control;
                    varRKID = "0";
                }
                int varflag = 0;
                if (Convert.ToString(txtProductName.Text.Trim()) != "")
                {
                    if (expirydateFlag == 1 || txtDay.Text != "" || txtMonth.Text != "" || txtYear.Text != "")
                    {
                        udfnExpiryDate();
                    }
                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    if (varExpiryDate != "")
                    {
                        MR_Master objMR_Master = new MR_Master();
                        objMR_Master.ViewType = 7;
                        objMR_Master.paraDate = dpInwardDate.Text;
                        objMR_Master.ParaExpiryDate = varExpiryDate;
                        objMR_Master.paraProductId = Convert.ToInt32(varPRID);
                        objDS = objDServ.udfnMaster(objMR_Master);
                        objDServ.CloseConnection();
                        if (expirydateFlag == 1)
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(objDS.Tables[0].Rows[0]["DATEVALIDATE"]) == "0")
                                {
                                    epGoodsInward.SetError(txtDay, "Invalid expiry date");
                                    txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpProduct.ShowAlways = true;
                                    tpProduct.Show("Invalid expiry date", txtDay, 5000);
                                    varflag = 1;
                                }
                                else
                                {
                                    if (objDS.Tables[1].Rows.Count > 0)
                                    {
                                        varShelflifevalue = Convert.ToString(objDS.Tables[1].Rows[0]["SHELFLIFE"]);
                                        string[] varProShelfLife = varShelflifevalue.Split(' ');
                                        if (Convert.ToString(varProShelfLife[0]) != "")
                                        {
                                            ProShelflife = Convert.ToDecimal(varProShelfLife[0]);
                                        }

                                    }
                                    if (objDS.Tables[2].Rows.Count > 0)
                                    {
                                        varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                                        string[] varShelflifevaluesplit = varAcutalshelflife.Split(' ');
                                        if (Convert.ToString(varShelflifevaluesplit[0]) != "")
                                        {
                                            Shelflifevalue = Convert.ToInt32(varShelflifevaluesplit[0]);
                                        }
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

                    string varMRP = "", varNewExpiryDate = "", varBatch = "", varSLID = "", varRKID = "", varmrptxt = "";
                    if (txtMrp.Text == "") { varmrptxt = "0"; }
                    else
                    { varmrptxt = txtMrp.Text.Trim(); }
                    varmrptxt = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(varmrptxt), 2, MidpointRounding.AwayFromZero));
                    for (int i = 0; i < grdInward.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(varPRID) == Convert.ToInt32(grdInward.Rows[i].Cells["ClmPRID"].Value))
                        {
                            varMRP = Convert.ToString(grdInward.Rows[i].Cells["clmMRP"].Value).Trim();
                            varNewExpiryDate = Convert.ToString(grdInward.Rows[i].Cells["clmExpiryDate"].Value).Trim();
                            varBatch = Convert.ToString(grdInward.Rows[i].Cells["clmBatchNo"].Value).Trim();
                            varSLID = Convert.ToString(grdInward.Rows[i].Cells["clmSLID"].Value).Trim();
                            varRKID = Convert.ToString(grdInward.Rows[i].Cells["clmRKID"].Value).Trim();
                            if (varmrptxt == varMRP && varExpiryDate == varNewExpiryDate && txtBatchNo.Text.Trim() == varBatch)
                            {
                                if (varStockLocationId.Trim() == varSLID && varRKID.Trim() == varRKID)
                                {
                                    //epPurchaseDC.SetError(txtProductName, "Product already exist for this location");
                                    //txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    //tpProduct.ShowAlways = true;
                                    //tpProduct.Show("Product already Exist for this location", txtProductName, 5000);
                                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    string varMessage = objDServ.udfnGetMessages(93);
                                    objDServ.CloseConnection();
                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    blnErrorFlag = true;
                                }
                            }
                        }
                    }
                }

                if (blnErrorFlag == false && pbDateflag == 0 && varflag==0)
                {
                    udfnAdd();
                }
                varChangeFlag = false;
            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdInward.Rows.Count.ToString();
                grdInward.ClearSelection();
                if (grdInward.Rows.Count > 0)
                {
                    txtStockLocation.Enabled = false;
                    cmbConcern.Enabled = false;
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                }
                else
                {
                    //txtStockLocation.BackColor =Color.White;
                    cmbConcern.Enabled = true;
                    txtStockLocation.Enabled = true;
                }
            }
        }
        private void TxtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtYear.TextAlign = HorizontalAlignment.Right;
                if (txtYear.Text.Length == 2)
                {
                    if (txtBatchNo.Enabled == false)
                    { txtActualQty.Focus(); }
                    else
                    {
                        txtBatchNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnExpiryDate()
        {
            try
            {
                string varDay = "", varMonth = "", varYear = "", varDate = ""; string varDcDay = "", varDcMonth = "", varDcYear = "", varExpiry = "";
                int varExpiryDays = 0; int error = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (txtDay.Text.Trim() == "")
                {
                    varDay = "01";
                }
                else
                {
                    if (Convert.ToInt64(txtDay.Text) > 31 || Convert.ToInt64(txtDay.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(95);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtDay.Text.Length == 1)
                        { txtDay.Text = 0 + txtDay.Text.Trim(); }
                        varDay = txtDay.Text.Trim();
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
                    if (txtDay.Text.Trim() == "")
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
                        }
                    }
                    else
                    {
                        varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 10;
                    objMR_Master.paraDate = dpInwardDate.Text.Trim();
                    objMR_Master.ParaExpiryDate = varExpiryDate;
                    objMR_Master.paraProductId = Convert.ToInt32(varPRID);
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
                                            txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
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
                    txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
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

        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
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
        public void udfnRackAutocomplete()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    varRKID = selectedItem.SubItems[2].Text;
                    //txtRackDescription.Text = selectedItem.SubItems[1].Text;
                    lvRack.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvRack.Visible = false;
            }
        }
        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //txtBatchNo.Enabled = true;
                lvRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(varStockLocationId), 0, txtRack.Text.Trim(), 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RK_Description"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvRack.Items.Add(objList);
                                }
                                lvRack.Visible = true;
                                lvRack.Columns[1].Width = 200;
                            }
                        }
                    }
                }
                else
                {
                    lvRack.Visible = false;
                    lvRack.Items.Clear();
                }
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
                varDateEnable = 0;
                varBatchNo = "0"; varBatchNoGeneration = "0"; varShelflife = 0; expirydateFlag = 0; varMRPFlag = 0; varMRPEditFlag = 0; varRMProductionFlag = 0;
                varPRID = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                varEditPRID = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                varMRPEditFlag = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_MRPflag"].Value);
                varAutocompleteProduct = 1; 
                udfnProductWiseDetails();
                if (varRMProductionFlag == 1)
                {
                    txtDay.Enabled = false; txtDay.ReadOnly = true;
                    txtMonth.Enabled = false; txtMonth.ReadOnly = true;
                    txtYear.Enabled = false; txtYear.ReadOnly = true;
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //lvproduct.Visible = false;
            }
        }
        public void udfnProductWiseDetails()
        {
            try
            {
                varRMProduction = "0";varRMProductionFlag = 0;varShelflife = 0; varPrcategory = "0";
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

                            varPRID = Convert.ToString(objDS.Tables[0].Rows[0]["ID"].ToString());
                            varPICode = Convert.ToString(objDS.Tables[0].Rows[0]["PICODE"].ToString());
                            varUTID = Convert.ToString(objDS.Tables[0].Rows[0]["UNIT"].ToString());
                            varTamilname = Convert.ToString(objDS.Tables[0].Rows[0]["TNAME"].ToString());
                            varBatchNo = Convert.ToString(objDS.Tables[0].Rows[0]["BATCHNO"].ToString());
                            varBatchNoGeneration = Convert.ToString(objDS.Tables[0].Rows[0]["BARCODE GENERATION"].ToString());
                            varRMProduction = Convert.ToString(objDS.Tables[0].Rows[0]["RM PRODUCTION"].ToString());
                            varPrcategory = Convert.ToString(objDS.Tables[0].Rows[0]["PRODUCTCATEGORY"].ToString());
                            varShelflife = Convert.ToInt32(objDS.Tables[0].Rows[0]["SHELFLIFE"].ToString());
                            varMRPFlag = Convert.ToInt32(objDS.Tables[0].Rows[0]["PR_MRPflag"].ToString());
                            Shelflife = Convert.ToString(objDS.Tables[0].Rows[0]["PRODUCT EXPIRY"].ToString()); 
                            ProductShelflifeValue = Convert.ToString(objDS.Tables[0].Rows[0]["SHELFLIFE VALUE"].ToString());
                            ProductShelflifeType = Convert.ToString(objDS.Tables[0].Rows[0]["SHELF LIFE TYPE"].ToString());
                            varDecimal = Convert.ToInt32(objDS.Tables[0].Rows[0]["UT_Decimal"].ToString());
                            txtunit.Text = Convert.ToString(objDS.Tables[0].Rows[0]["UT_Symbol"].ToString());

                            if (varAutocompleteProduct == 1)
                            {
                                if (varShelflife == 1)
                                {
                                    expirydateFlag = 1;
                                    txtDay.ReadOnly = false;
                                    txtMonth.ReadOnly = false;
                                    txtYear.ReadOnly = false;
                                    txtDay.Enabled = true;
                                    txtMonth.Enabled = true;
                                    txtYear.Enabled = true;
                                }
                                else
                                {
                                    expirydateFlag = 0;
                                    txtDay.ReadOnly = true;
                                    txtMonth.ReadOnly = true;
                                    txtYear.ReadOnly = true;
                                    txtDay.Enabled = false;
                                    txtMonth.Enabled = false;
                                    txtYear.Enabled = false;
                                    varDateEnable = 1;
                                }
                                if (varMRPFlag == 1)
                                {
                                    varEditflag = 1;
                                    txtMrp.Enabled = true;
                                    txtMrp.ReadOnly = false;
                                }
                                else
                                {
                                    varEditflag = 0;
                                    txtMrp.Enabled = false;
                                    txtMrp.ReadOnly = true;
                                }
                                //udfnProductAdd(); 
                                if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                                {
                                    txtBatchNo.Text = "";
                                    txtBatchNo.Enabled = false;
                                    //  txtBatchNo.ReadOnly = true;
                                }
                                else if (Convert.ToInt32(varBatchNo) == 72) //enabled
                                {
                                    if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                                    {
                                        txtBatchNo.Enabled = true;
                                        //txtBatchNo.ReadOnly = false;
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
                                                txtBatchNo.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                                txtBatchNo.Enabled = false;
                                            }
                                        }
                                    }
                                }
                            }
                            if (varAutocompleteProduct == 2)
                            {
                                DataGridView dataGridView1 = grdInward;
                                DataGridViewCell cell1 = dataGridView1.CurrentRow.Cells["clmmrp"];
                                DataGridView dataGridView2 = grdInward;
                                DataGridViewCell cell2 = dataGridView2.CurrentRow.Cells["clmexpirydate"];
                                DataGridView dataGridView3 = grdInward;
                                DataGridViewCell cell3 = dataGridView3.CurrentRow.Cells["clmbatchno"];
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
                            if (Convert.ToInt32(varPrcategory) == 16 && varShelflife == 1)
                            {
                                if (Convert.ToInt32(varRMProduction) == 1)
                                {
                                    varRMProductionFlag = 1;
                                    MR_Master objMR_Master = new MR_Master();
                                    objMR_Master.ViewType = 15;
                                    objMR_Master.paraDate = dpInwardDate.Text;
                                    objMR_Master.paraProductId = Convert.ToInt32(varPRID);
                                    SPDataService objspdservice = new SPDataService();
                                    DataSet objDs = new DataSet();
                                    objDs = objspdservice.udfnMaster(objMR_Master);
                                    objspdservice.CloseConnection();
                                    if (objDs.Tables[0] != null)
                                    {
                                        if (objDs.Tables[0].Rows.Count != 0)
                                        {
                                            txtDay.Text = objDs.Tables[0].Rows[0][0].ToString();
                                            txtMonth.Text = objDs.Tables[0].Rows[1][0].ToString();
                                            txtYear.Text = objDs.Tables[0].Rows[2][0].ToString();
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
        public void udfnClear()
        {
            try
            {
                txtMrp.Text = "";
                txtDay.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchNo.Text = "";
                txtActualQty.Text = "";
                txtRack.Text = "";
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
                    txtBatchNo.Text = "";
                    txtMrp.Text = "";
                    txtActualQty.Text = "";
                    txtDay.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtunit.Text = "";
                    //SLID = varStockLocationId;
                    varPRID = "0";
                    if (VarSearchFlag == true)
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }

                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0 || txtProductName.Text == " ")
                    {
                        var ViewType = 51;
                        int varEntry = 0;
                        if (btnSave.Text == "Save") { varEntry = varGIId; }
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = ViewType;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraId = varEntry;
                        if (VarSearchFlag == false)
                        {
                            objMR_Product.paraProductName = txtProductName.Text.Trim();
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraPicode = txtProductName.Text.Trim();
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    //for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    //{
                                    DGV_FilterProduct.Visible = true;
                                    //    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["UTID"].ToString(), objDs.Tables[0].Rows[i]["PR_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PR_ShelfLife"].ToString(), objDs.Tables[0].Rows[i]["PR_BatchNoGeneration"].ToString(), objDs.Tables[0].Rows[i]["ShelfLife"].ToString(), objDs.Tables[0].Rows[i]["PR_ShelfLifeValue"].ToString(), objDs.Tables[0].Rows[i]["PR_ShelfLifeType"].ToString(), objDs.Tables[0].Rows[i]["UT_Decimal"].ToString() }; 
                                    //    ListViewItem objList = new ListViewItem(row);
                                    //    objList.UseItemStyleForSubItems = false;
                                    //    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    //    lvproduct.Items.Add(objList);
                                    //}
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["UTID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Visible = true;
                                    DGV_FilterProduct.Columns["PR_BatchNo"].Visible = false;
                                    DGV_FilterProduct.Columns["Product Shelf Life"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_ShelfLifeType"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_ShelfLife"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_ShelfLifeValue"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_BatchNoGeneration"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_MRPflag"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_RetailRate"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 115;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 60;
                                    DGV_FilterProduct.Columns["Retail Rate"].Width = 80;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["Retail Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                                    if (VarSearchFlag == false)
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2;
                                        //lvproduct.Columns[1].Width = 320;
                                        //lvproduct.Columns[2].Width = 0;
                                        //(DGV_FilterProduct.DataSource as DataTable).DefaultView.RowFilter = "([PR_EName]) LIKE '%" + txtProductName.Text + "%'";
                                    }
                                    else
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 2;
                                        //lvproduct.Columns[1].Width = 0;
                                        //lvproduct.Columns[2].Width = 320;
                                        //(DGV_FilterProduct.DataSource as DataTable).DefaultView.RowFilter = "([PR_PICode]) LIKE '%" + txtProductName.Text + "%'";
                                    }

                                }
                                else
                                {
                                    DGV_FilterProduct.DataSource = null;
                                    DGV_FilterProduct.Visible = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                        //lvproduct.Visible = false;
                        //lvproduct.Items.Clear();
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
                epGoodsInward.Clear();
            }
        }
        public void udfnRackcheck()
        {
            try
            {
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
                string varId_PurchaseRackCount = "0";
                DataSet objDsPurchaseRack = new DataSet();
                SPDataService objDServ6 = new SPDataService();
                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varStockLocationId), 0, txtRack.Text.Trim(), 0, 0);
                objDServ6.CloseConnection();
                if (txtRack.Text.Trim() != "")
                {
                    if (varStockLocationId != "0")
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
                        varRKID = Convert.ToString(varId_PurchaseRack);
                        if (Convert.ToInt32(varId_PurchaseRackCount) > 0)
                        {
                            if (Convert.ToInt32(varId_PurchaseRack) < 0 || varId_PurchaseRack == "-1")
                            {
                                epGoodsInward.SetError(txtRack, "Please enter valid rack.");
                                txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                                tprack.ShowAlways = true;
                                tprack.Show("Please enter valid rack.", txtRack, 5000);
                            }
                        }
                    }
                }
                else
                {
                    if (varStockLocationId != "0")
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
                        //varRKID = Convert.ToString(varId_PurchaseRack);
                        //if (Convert.ToInt32(varId_PurchaseRack) > 0)
                        //{
                        //    epGoodsInward.SetError(txtRack, "Please enter rack.");
                        //    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        //    tprack.ShowAlways = true;
                        //    tprack.Show("Please enter rack.", txtRack, 5000);
                        //}
                        if (varId_PurchaseRack == "0")
                        {
                            txtRack.Text = "None";
                            txtRack.Enabled = false;
                            varRKID = "0";
                        }
                        else
                        {
                            txtRack.Enabled = true;
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
        public void udfnEdit()
        {
            try
            {
                if (varGIId != 0)
                {
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    //SPDataService objspservice = new SPDataService();
                    SPDataService objdserv = new SPDataService();
                    TRN_GoodsInward objTRNG_GoodsInward = new TRN_GoodsInward();
                    objTRNG_GoodsInward.ViewType = 1;
                    objTRNG_GoodsInward.paraGIID = varGIId;
                    objTRNG_GoodsInward.paraSTRID = varGISTRID;
                    objDs = objdserv.udfnInwardList(objTRNG_GoodsInward);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["GI_COMID"].ToString();
                            dpInwardDate.Text = objDs.Tables[0].Rows[0]["GI_Date"].ToString();
                            txtInwardNo.Text = objDs.Tables[0].Rows[0]["GI_No"].ToString();
                            varStockLocationId = objDs.Tables[0].Rows[0]["GI_SLID"].ToString();
                            txtStockLocation.Text = objDs.Tables[0].Rows[0]["Stock Location"].ToString();
                            cmbTransactionType.Text = objDs.Tables[0].Rows[0]["Transaction Type"].ToString();
                            txtRemark.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                            if(Convert.ToString(objDs.Tables[0].Rows[0]["RackCount"])=="0")
                            { txtRack.Enabled = false;txtRack.ReadOnly = true;txtRack.Text = "None"; }
                        }

                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                string varshelflifeper = "";
                                if (Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]) != "")
                                {
                                    object shelflife = objDs.Tables[1].Rows[i]["Shelflifeper"];
                                    if (Convert.ToDouble(shelflife) < 0)
                                    {
                                        objDs.Tables[1].Rows[i]["Shelflifeper"] = "0";
                                        varshelflifeper = Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]);
                                    }
                                    else
                                    {
                                        varshelflifeper = Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]) + '%';
                                    }
                                }
                                grdInward.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                grdInward.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_ShelfLifeFlag"]), Convert.ToString(objDs.Tables[1].Rows[i]["actuallife"]), varshelflifeper, Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_BatchNo"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GIPR_Qty"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GIPR_TransferQty"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GIPR_ReceivedQty"]),
                                Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["GI_SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_UTID"]), 
                                Convert.ToString(objDs.Tables[1].Rows[i]["UT_Decimal"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_MRPflag"]), Convert.ToString(objDs.Tables[1].Rows[i]["RM Flag"]), Convert.ToString(objDs.Tables[1].Rows[i]["ShelfLife Enable"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_BatchNoStatus"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_BatchNoGenration"])); 
                                if (Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]) == "")
                                {
                                    objDs.Tables[1].Rows[i]["Shelflifeper"] = "0";
                                }
                                dtInward.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_BatchNo"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GIPR_Qty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), 
                                    Convert.ToString(objDs.Tables[1].Rows[i]["GI_SLID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GIPR_ReceivedQty"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GIPR_TransferQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLife"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLifeValue"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLifeType"]), 
                                    Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GIPR_MRPflag"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["RM Flag"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GIPR_BatchNoStatus"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GIPR_BatchNoGenration"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GIPR_ShelfLife"])); 
                                grdInward.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmtransferqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmreceivedqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmactualqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmshelflifeper"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                if (Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLife"]) == "0")
                                {
                                    grdInward.Rows[i].Cells["clmexpirydate"].ReadOnly = true;
                                    grdInward.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                                }
                                if (Convert.ToString(objDs.Tables[1].Rows[i]["RM Flag"]) == "1")
                                {
                                    grdInward.Rows[i].Cells["clmexpirydate"].ReadOnly = true;
                                    grdInward.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightGray;
                                }
                                if (Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_MRPflag"]) == "0")
                                {
                                    grdInward.Rows[i].Cells["clmmrp"].ReadOnly = true;
                                    grdInward.Rows[i].Cells["clmmrp"].Style.BackColor = Color.LightGray;
                                }
                                if (Convert.ToString(grdInward.Rows[i].Cells["clmBatchStatus"].Value) == "73") //Disabled
                                {
                                    grdInward.Rows[i].Cells["clmBatchNo"].Style.BackColor = Color.LightGray;
                                    grdInward.Rows[i].Cells["clmBatchNo"].ReadOnly = true;
                                }
                                else if (Convert.ToString(grdInward.Rows[i].Cells["clmBatchStatus"].Value) == "72")//Enabled
                                {
                                    if (Convert.ToString(grdInward.Rows[i].Cells["clmBatchnoEnable"].Value) == "74") //Auto
                                    {
                                        grdInward.Rows[i].Cells["clmBatchNo"].Style.BackColor = Color.LightGray;
                                        grdInward.Rows[i].Cells["clmBatchNo"].ReadOnly = true;
                                    }
                                    else if (Convert.ToString(grdInward.Rows[i].Cells["clmBatchnoEnable"].Value) == "75") //Manual
                                    {
                                        grdInward.Rows[i].Cells["clmBatchNo"].Style.BackColor = Color.PaleGreen;
                                        grdInward.Rows[i].Cells["clmBatchNo"].ReadOnly = false;
                                    }
                                }
                                if (Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]) != "")
                                {
                                    string[] varShelflifeper = Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]).Split(' ');
                                    if (varShelflifeper[0] != "")
                                    {
                                        //Shelflife Wise Color Set
                                        if (Convert.ToDecimal(varShelflifeper[0]) <= (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifeper[0])!=0)
                                        {
                                            DataGridView dataGridView = grdInward;
                                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                            cell.Style.BackColor = Color.Red;
                                            cell.Style.ForeColor = Color.White;
                                            txtRDPercentageCheck.Enabled = true;
                                            lbltwentyfiveper.Enabled = true;
                                        }
                                        else if (Convert.ToDecimal(varShelflifeper[0]) > (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel2) && Convert.ToDecimal(varShelflifeper[0]) != 0)
                                        {
                                            DataGridView dataGridView = grdInward;
                                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                            cell.Style.BackColor = Color.Orange;
                                            cell.Style.ForeColor = Color.Black;
                                            txtORPercentageCheck.Enabled = true;
                                            lblFivetyPercentage.Enabled = true;
                                        }
                                        else
                                        {
                                            DataGridView dataGridView = grdInward;
                                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                            cell.Style.BackColor = Color.White;
                                            cell.Style.ForeColor = Color.Black;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    grdInward.ClearSelection();
                    lvStockLocation.Visible = false;
                    cmbConcern.Enabled = false;
                    dpInwardDate.Enabled = false;
                    txtInwardNo.Enabled = false;
                    txtStockLocation.Enabled = false;
                    cmbTransactionType.Enabled = false;
                    epGoodsInward.Clear();
                     udfntooltiphide();
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                    if (varSTSID == 42)
                    {
                        txtProductName.Enabled = false;
                        txtActualQty.Enabled = false;                       
                        txtRack.Enabled = false;
                        txtBatchNo.Enabled = false;
                        txtMrp.Enabled = false;
                        txtDay.Enabled = false;
                        txtMonth.Enabled = false;
                        txtYear.Enabled = false;
                        txtRemark.Enabled = false;
                        cbCompleted.Checked = true;
                        btnSave.Enabled = false;
                        cbCompleted.Enabled = false;
                        btnAdd.Enabled = false;
                        grdInward.Columns["clmremove"].Visible = false;
                        grdInward.Columns["clmmrp"].DefaultCellStyle.BackColor = Color.LightGray;
                        grdInward.Columns["clmexpirydate"].DefaultCellStyle.BackColor = Color.LightGray;
                        grdInward.Columns["clmbatchno"].DefaultCellStyle.BackColor = Color.LightGray;
                        grdInward.Columns["clmactualqty"].DefaultCellStyle.BackColor = Color.LightGray;
                        txtProductName.BackColor = Color.White;
                        this.ActiveControl = btnClose;
                        epGoodsInward.Clear();
                        grdInward.ReadOnly = true;
                        udfntooltiphide();
                        txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        for (int i = 0; i < grdInward.Rows.Count; i++)
                        {
                            ((DataGridViewImageCell)grdInward.Rows[i].Cells["clmremove"]).Value = new System.Drawing.Bitmap(1, 1);
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
                txttotalitem.Text = Convert.ToString(grdInward.Rows.Count);
            }
        }
        public void udfnTransferEdit()
        {
            try
            {
                if (varSTRID != 0)
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDs;
                    objDs = objspservice.udfnStockTransferList(3, varSTRID, 0, varSLID, 0, 0, 0, "", "",0,0);
                    objspservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            //cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["GI_COMID"].ToString();
                            //dpInwardDate.Text = objDs.Tables[0].Rows[0]["GI_Date"].ToString();
                            //txtInwardNo.Text = objDs.Tables[0].Rows[0]["GI_No"].ToString();
                            varStockLocationId = Convert.ToString(varSLID);
                            txtStockLocation.Text = objDs.Tables[0].Rows[0]["SL_EName"].ToString();
                            cmbTransactionType.SelectedValue = 69;
                            cmbConcern.SelectedValue = varcomID;
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                object shelflife = objDs.Tables[1].Rows[i]["Shelflifeper"];
                                if (Convert.ToDouble(shelflife) < 0)
                                {
                                    objDs.Tables[1].Rows[i]["Shelflifeper"] = "0";
                                }
                                string varShelflifeFlag = Convert.ToString(objDs.Tables[1].Rows[i]["ShelflifeFlag"]).ToString();
                                string varPercentage = "";
                                if (varShelflifeFlag != "0")
                                {
                                    varPercentage = Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]);
                                }
                                grdInward.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                grdInward.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["GIPR_ShelfLife"]), Convert.ToString(objDs.Tables[1].Rows[i]["actualshelflife"]), varPercentage, Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_BatchNo"]), 0, Convert.ToDecimal(objDs.Tables[1].Rows[i]["STRPR_Qty"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STRPR_Qty"]),
                                Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_Dest_RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_Dest_SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_UTID"]));
                                dtInward.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_BatchNo"]), 0, Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_Dest_RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STRPR_Dest_SLID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STRPR_Qty"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STRPR_Qty"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLife"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLifeValue"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_ShelfLifeType"]), Convert.ToString(objDs.Tables[1].Rows[i]["shelflifeper"]));
                                grdInward.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmreceivedqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmtransferqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmshelflifeper"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //string[] varShelflifeper = Convert.ToString(objDs.Tables[1].Rows[i]["shelflifeper"]).Split(' ');
                                //if (varShelflifeper[0] != "")
                                //{
                                //    //Shelflife Wise Color Set
                                //    if (Convert.ToDecimal(varShelflifeper[0]) <= (MainForm.pbShelflifeLevel1))
                                //    {
                                //        DataGridView dataGridView = grdInward;
                                //        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                //        cell.Style.BackColor = Color.Red;
                                //        cell.Style.ForeColor = Color.White;
                                //        txtRDPercentageCheck.Enabled = true;
                                //        lbltwentyfiveper.Enabled = true;
                                //    }
                                //    else if (Convert.ToDecimal(varShelflifeper[0]) > (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel2))
                                //    {
                                //        DataGridView dataGridView = grdInward;
                                //        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                //        cell.Style.BackColor = Color.Orange;
                                //        cell.Style.ForeColor = Color.Black;
                                //        txtORPercentageCheck.Enabled = true;
                                //        lblFivetyPercentage.Enabled = true;
                                //    }
                                //    else
                                //    {
                                //        DataGridView dataGridView = grdInward;
                                //        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                //        cell.Style.BackColor = Color.White;
                                //        cell.Style.ForeColor = Color.Black;
                                //    }
                                //}

                                if (Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]) != "")
                                {
                                    string[] varShelflifeper = Convert.ToString(objDs.Tables[1].Rows[i]["Shelflifeper"]).Split(' ');
                                    if (varShelflifeper[0] != "" && varShelflifeFlag!="0")
                                    {
                                        //Shelflife Wise Color Set
                                        if (Convert.ToDecimal(varShelflifeper[0]) <= (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifeper[0]) != 0)
                                        {
                                            DataGridView dataGridView = grdInward;
                                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                            cell.Style.BackColor = Color.Red;
                                            cell.Style.ForeColor = Color.White;
                                            txtRDPercentageCheck.Enabled = true;
                                            lbltwentyfiveper.Enabled = true;
                                        }
                                        else if (Convert.ToDecimal(varShelflifeper[0]) > (MainForm.pbShelflifeLevel1) && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel2) && Convert.ToDecimal(varShelflifeper[0]) != 0)
                                        {
                                            DataGridView dataGridView = grdInward;
                                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                            cell.Style.BackColor = Color.Orange;
                                            cell.Style.ForeColor = Color.Black;
                                            txtORPercentageCheck.Enabled = true;
                                            lblFivetyPercentage.Enabled = true;
                                        }
                                        else
                                        {
                                            DataGridView dataGridView = grdInward;
                                            DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                            cell.Style.BackColor = Color.White;
                                            cell.Style.ForeColor = Color.Black;
                                        }
                                    }
                                }

                            }
                        }
                    }
                    grdInward.ClearSelection();
                    lvStockLocation.Visible = false;
                    cmbConcern.Enabled = false;
                    dpInwardDate.Enabled = false;
                    txtInwardNo.Enabled = false;
                    txtStockLocation.Enabled = false;
                    cmbTransactionType.Enabled = false;
                    epGoodsInward.Clear();
                    udfntooltiphide();
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 69)
                    {
                        txtRack.Enabled = false;
                        txtProductName.Enabled = false;
                        txtMrp.Enabled = false;
                        txtDay.Enabled = false;
                        txtMonth.Enabled = false;
                        txtYear.Enabled = false;
                        txtBatchNo.Enabled = false;
                        txtActualQty.Enabled = false;
                        btnAdd.Enabled = false;
                        udfntooltiphide();
                        epGoodsInward.Clear();
                        txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtBatchNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtActualQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
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
                txttotalitem.Text = Convert.ToString(grdInward.Rows.Count);
            }
        }
    }
}
