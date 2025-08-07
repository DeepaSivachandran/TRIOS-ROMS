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
    public partial class INV_InwardPurchase : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varConcernId = 0, varSupplierId = 0, varScheduleId = 0, varLocationId = 0, VarRackId = 0, varUnitId = 0,varGRNId=0,varInwardId=0,varEditFlag=0,varStausId=0;
        public int varPurchaseID = 0, varID = 0, varGRNPurchaseFlag = 0, varCloseFlag = 0, varTypeID = 0, varRemarkFlag = 0, vargrid_flag = 0;
        public int varRemarkCount = 0, varShelflife = 0, varErroronGrid = 0;
        public string varStatus = "", varPurApproved = "0";
        DataTable dtInwardPurchase = new DataTable();
        DataTable dtChkProducts = new DataTable();
        ToolTip tpInwardNo = new ToolTip();
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0, varPurchaseStatus = 0, varQuantityErr = 0, varError = 0;
        public int pbDateflag = 0;
        public decimal varReQty = 0, varShQty = 0;
        public int varErrorQty = 0, varStsErr = 0;
        public string varTempExpiryDate = "0", varExpiryDate = "";
        public string varGIPTransDate="";
        public INV_InwardPurchase()
        {
            InitializeComponent();
        }

        private void INV_InwardPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    udfnUddtTable();
                    ClearSupplier();
                    EditLoad();
                    udfnVocherno();
                    MainForm.objINV_InwardQueueList_Remarks = new INV_InwardQueueList_Remarks();
                    MainForm.objINV_InwardQueueList_Remarks.varID = varID;
                    MainForm.objINV_InwardQueueList_Remarks.varRemarkFlag = varRemarkFlag;
                    MainForm.objINV_InwardQueueList_Remarks.varFlag = varGRNPurchaseFlag;
                    MainForm.objINV_InwardQueueList_Remarks.udfnRemarkList();
                    if (varRemarkCount == 0)
                    {
                        btnRemarks.Enabled = false;
                    }
                }
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
        private void GrdGrnlist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdInward.ClearSelection();
                foreach (DataGridViewRow row in grdInward.Rows)
                {
                    if (Convert.ToString(grdInward.Rows[row.Index].Cells["clmConvertType"].Value) == "0")
                    {
                        grdInward.Rows[row.Index].Cells[0].Value = null;
                        grdInward.Rows[row.Index].Cells[0] = new DataGridViewTextBoxCell();
                        grdInward.Rows[row.Index].Cells[0].Value = "";
                        grdInward.Rows[row.Index].Cells[0].ReadOnly = true;

                        grdInward.Rows[row.Index].Cells["clmStatus"] = new DataGridViewTextBoxCell();
                        grdInward.Rows[row.Index].Cells["clmStatus"].Value = "";
                        grdInward.Rows[row.Index].Cells["clmStatus"].ReadOnly = true;
                    } 
                    if (Convert.ToString(grdInward.Rows[row.Index].Cells["clmRMFlag"].Value) == "1")
                    {
                        grdInward.Rows[row.Index].Cells["clmExpiryDate"].ReadOnly = true;
                        grdInward.Rows[row.Index].Cells["clmExpiryDate"].Style.BackColor = Color.LightGray;
                    }
                }
                //for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                //{
                //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConvertType"].Value) == "0")
                //    {
                //        grdGrnlist.Rows[i].Cells["clmCheck"].Value = null;
                //    }
                //}
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
        public AutoCompleteStringCollection AutoCompleteRackName(int varSLID)
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();
            objds = objdservice.GetDataset("SELECT RKID,RK_ShortName FROM MR_Rack WHERE RK_STSID=1 AND RKID NOT IN (-1,0) AND RK_SLID = " + varSLID);
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
        public void udfnVocherno()
        {
            try
            {
                if (varInwardId == 0)
                {
                    if (Convert.ToInt32(varConcernId) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpInwardDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetVoucherNo("183", vardate, varConcernId);
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string pono = parts[0];
                        if (pono != "")
                        {
                            txtInwardNo.Text = pono;
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
                        txtInwardNo.Text = "";
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
        public void udfnUddtTable()
        {
            try
            {
                //Add the count of default  Data table count when save
                dtInwardPurchase.TableName = "TRN_GoodsInward_Purchase_Products";
                dtInwardPurchase.Columns.Add("", typeof(Boolean));
                dtInwardPurchase.Columns.Add("GIPPR_SNO", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ConvertType", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_OrderID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_PRID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_UTID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ReceivedQty", typeof(decimal));
                dtInwardPurchase.Columns.Add("GIPPR_ShopQty", typeof(decimal));
                dtInwardPurchase.Columns.Add("GIPPR_RKID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ExpiryDate", typeof(string));
                dtInwardPurchase.Columns.Add("GIPPR_BatchNo", typeof(string));
                dtInwardPurchase.Columns.Add("GIPPR_MRP", typeof(decimal));
                dtInwardPurchase.Columns.Add("IDS", typeof(int));
                dtInwardPurchase.Columns.Add("PR_MRPStatus", typeof(int));
                dtInwardPurchase.Columns.Add("PR_ExpiryStatus", typeof(int));
                dtInwardPurchase.Columns.Add("PR_BatchNoStatus", typeof(int));
                dtInwardPurchase.Columns.Add("PR_BatchNoGeneration", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_INVSTSID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_RMProductionFlag", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ShelfLifeValue", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ShelfLifeType", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ShelfLife_Flag", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ShelfLifeStatus", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ShelfLife_Per", typeof(decimal));
                dtInwardPurchase.Columns.Add("GIPPR_InvoiceExpiryDate", typeof(string));
                dtInwardPurchase.Columns.Add("GIPPR_InvoiceBatchNo", typeof(string));
                dtInwardPurchase.Columns.Add("GIPPR_InvoiceMRP", typeof(decimal));

                dtChkProducts.TableName = "TRN_GoodsInward_Purchase_Products";
                dtChkProducts.Columns.Add("GIPPR_SNO", typeof(int));
                dtChkProducts.Columns.Add("GIPPR_ConvertType", typeof(int));
                dtChkProducts.Columns.Add("GIPPR_OrderID", typeof(int));
                dtChkProducts.Columns.Add("GIPPR_PRID", typeof(int));
                dtChkProducts.Columns.Add("GIPPR_UTID", typeof(int));
                dtChkProducts.Columns.Add("GIPPR_ReceivedQty", typeof(decimal));
                dtChkProducts.Columns.Add("GIPPR_ShopQty", typeof(decimal));
                dtChkProducts.Columns.Add("GIPPR_RKID", typeof(int));
                dtChkProducts.Columns.Add("GIPPR_ExpiryDate", typeof(string));
                dtChkProducts.Columns.Add("GIPPR_BatchNo", typeof(string));
                dtChkProducts.Columns.Add("GIPPR_MRP", typeof(decimal));
                dtChkProducts.Columns.Add("IDS", typeof(int));
                dtChkProducts.Columns.Add("GIPPR_INVSTSID", typeof(int));
                dtChkProducts.Columns.Add("GIPPR_RMProductionFlag", typeof(int));
                dtChkProducts.Columns.Add("GIPPR_InvoiceExpiryDate", typeof(string));
                dtChkProducts.Columns.Add("GIPPR_InvoiceBatchNo", typeof(string));
                dtChkProducts.Columns.Add("GIPPR_InvoiceMRP", typeof(decimal));
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

        private void GrdInward_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdInward.Columns["clmReason"].Index)
                {
                    var cell = grdInward.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdInward.Rows[e.RowIndex].Cells["clmFullReason"].Value.ToString();
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
                for (int i = 0; i < grdInward.Rows.Count; i++)
                {
                    if (Convert.ToString(grdInward.Rows[i].Cells["clmConvertType"].Value) == "1")
                    {
                        grdInward.Rows[i].Cells["clmCheck"].Value = true;
                        dtInwardPurchase.Rows[i]["Column1"] = true;
                    }
                }
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
                for (int i = 0; i < grdInward.Rows.Count; i++)
                {
                    if (Convert.ToString(grdInward.Rows[i].Cells["clmConvertType"].Value) == "1")
                    {
                        grdInward.Rows[i].Cells["clmCheck"].Value = false;
                        dtInwardPurchase.Rows[i]["Column1"] = false;
                    }
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
                if (e.RowIndex != -1)
                {
                    switch (grdInward.Columns[e.ColumnIndex].Name)
                    {
                        case "clmConvert":
                            try
                            {
                                DataGridView dgv = sender as DataGridView;
                                if (e.ColumnIndex != 0)
                                {
                                    string varSno = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmSno"].Value);
                                    string varPICode = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmPICode"].Value);
                                    string varPTName = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmProductName"].Value);
                                    string varMRP = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmMRP"].Value);
                                    string varInvMRP = "";
                                    string varExpiryDate = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmExpiryDate"].Value);
                                    string varInvExpiryDate = "";
                                    string varBatchNo = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmBatchNo"].Value);
                                    string varInvBatchNo = "";//  Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmInvoiceBatchNo"].Value);
                                    string varPendingQty = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmQty"].Value);
                                    string varReceivedQty = "";// Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmReceivedQty"].Value);
                                    string varShopQty = "";// Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmShopQty"].Value);
                                    string varUnit = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmUnit"].Value);
                                    string varRack =  Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmRack"].Value);
                                    string varPRID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmPRID"].Value);
                                    string varSLID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmSLID"].Value);
                                    string varRKID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmRKID"].Value);
                                    string varUTID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmUTID"].Value);
                                    string varGRN_DC_PUR_ID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmID"].Value);
                                    string varUT_Decimal = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmUTDecimal"].Value);
                                    string varRackCount = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmRackCount"].Value);

                                    string varclmBatchNoStatus = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmBatchNoStatus"].Value);
                                    string varclmBatchGeneration = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmBatchNoGeneration"].Value);
                                    string varclmShelflifeStatus = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmShelflifeStatus"].Value);
                                    string varclmMRPFlag = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmMRPFlag"].Value);
                                    string varclmRMFlag = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmRMFlag"].Value);
                                    string varclmDisable = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmDisable"].Value);
                                    int varConvertType = 0;
                                    string varActualLife = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmActuallife"].Value);
                                    string varShelflifeType = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmShelfType"].Value);
                                    string varShelflifePer = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmShelflifePer"].Value);
                                    string varShelflifeValue = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmShelfValue"].Value);
                                    string varShelfStatus = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmShelfStatus"].Value);
                                    if (Convert.ToString(grdInward.CurrentRow.Cells["clmBatchNoGeneration"].Value) == "75")
                                    {
                                        varBatchNo = "";
                                    }
                                    //SNO Order Here
                                    var varChildRowCount = from r in dtInwardPurchase.AsEnumerable()
                                                           where (r.Field<int>("GIPPR_SNO").Equals(Convert.ToInt32(varSno))
                                                           ) group r by r.Field<int>("GIPPR_OrderID") into g
                                                           select g.Key;
                                    int varChildRowNo = Convert.ToInt32(Convert.ToString(varSno) + Convert.ToString(varChildRowCount.Count()));

                                    bool value = false; int varPRStatus = 0;
                                    if (Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["clmCheck"].Value) == true)
                                    {
                                        value = true;
                                    }
                                    if (Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmStatus"].Value) != "")
                                    {
                                        varPRStatus = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["clmStatus"].Value);
                                    }
                                     grdInward.Rows.Add(false, null, "", varPICode, varPTName, varMRP,varInvMRP, varExpiryDate,varInvExpiryDate, varBatchNo,varInvBatchNo,
                                     varPendingQty,0, varReceivedQty, varShopQty, varUnit, varRack, varPRID, varSLID, 0, varUTID, varGRN_DC_PUR_ID, varUT_Decimal, varRackCount, varConvertType, 
                                     Convert.ToString(varChildRowNo),0, varclmBatchNoStatus, varclmBatchGeneration, varclmShelflifeStatus, varclmMRPFlag, varclmDisable, 0, varSno,0,0,0,
                                     Convert.ToInt32(varActualLife), Convert.ToDecimal(varShelflifePer), Convert.ToInt32(varShelflifeValue), Convert.ToInt32(varShelfStatus), 
                                     Convert.ToInt32(varShelflifeType));

                                    DataGridView dataGridView = grdInward;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmConvert"];
                                    cell.Value= new System.Drawing.Bitmap(1, 1);
                                    udfnConvertProductDetails(sender, e);
                                    //if (varclmMRPFlag == "0")
                                    //{
                                    //    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmConvert"].Style.BackColor = Color.LightGray;
                                    //    cellProMrp.Style.ForeColor = Color.Black;
                                    //    cellProMrp.ReadOnly = true; cellProMrp.Value = "0.00";
                                    //    cellInvMrp.Style.BackColor = Color.LightGray; cellInvMrp.Style.ForeColor = Color.Black;
                                    //    cellInvMrp.ReadOnly = true; cellInvMrp.Value = "0.00";
                                    //}
                                    //else
                                    //{
                                    //    cellInvMrp.Style.BackColor = Color.PaleGreen;
                                    //    cellInvMrp.Style.ForeColor = Color.Black; cellInvMrp.ReadOnly = false;
                                    //    cellProMrp.Style.BackColor = Color.PaleGreen;
                                    //    cellProMrp.Style.ForeColor = Color.Black; cellProMrp.ReadOnly = false;
                                    //}
                                    //if (varShelflifeFlag == "0")
                                    //{
                                    //    cellShelfLife.Value = "";
                                    //    cellInvExpiryDate.Style.BackColor = Color.LightGray;
                                    //    cellInvExpiryDate.ReadOnly = true;
                                    //    cellProExpiryDate.Style.BackColor = Color.LightGray;
                                    //    cellProExpiryDate.ReadOnly = true;
                                    //}
                                    //else
                                    //{
                                    //    cellShelfLife.Style.BackColor = Color.PaleGreen; cellShelfLife.Style.ForeColor = Color.Black;
                                    //    cellInvExpiryDate.Style.BackColor = Color.PaleGreen; cellInvExpiryDate.ReadOnly = false;
                                    //    cellProExpiryDate.Style.BackColor = Color.PaleGreen; cellProExpiryDate.ReadOnly = false;
                                    //}
                                    //if (varBatchNoEnable == "73")
                                    //{
                                    //    cellInvBatchNo.Style.BackColor = Color.LightGray;
                                    //    cellInvBatchNo.Style.ForeColor = Color.Black;
                                    //    cellInvBatchNo.ReadOnly = true;
                                    //    cellInvBatchNo.Value = "";
                                    //    cellProBatchNo.Style.BackColor = Color.LightGray;
                                    //    cellProBatchNo.Style.ForeColor = Color.Black;
                                    //    cellProBatchNo.ReadOnly = true;
                                    //    cellProBatchNo.Value = "";
                                    //}
                                    //else if (varBatchNoEnable == "72")
                                    //{
                                    //    if (varBatchNoGeneration == "75") //manul
                                    //    {
                                    //        cellInvBatchNo.Style.BackColor = Color.PaleGreen; cellInvBatchNo.Style.ForeColor = Color.Black;
                                    //        cellInvBatchNo.ReadOnly = false; cellInvBatchNo.Value = "";
                                    //        cellProBatchNo.Style.BackColor = Color.PaleGreen; cellProBatchNo.Style.ForeColor = Color.Black;
                                    //        cellProBatchNo.ReadOnly = false; cellProBatchNo.Value = "";
                                    //    }
                                    //    else if (varBatchNoGeneration == "74")//Auto
                                    //    {
                                    //        cellInvBatchNo.Style.BackColor = Color.LightGray; cellInvBatchNo.Style.ForeColor = Color.Black;
                                    //        cellInvBatchNo.ReadOnly = true;
                                    //        cellProBatchNo.Style.BackColor = Color.LightGray; cellProBatchNo.Style.ForeColor = Color.Black;
                                    //        cellProBatchNo.ReadOnly = true;
                                    //    }
                                    //}
                                    //if (varRMProductionFlag == "1")
                                    //{
                                    //    cellInvExpiryDate.Style.BackColor = Color.LightGray;
                                    //    cellInvExpiryDate.Style.ForeColor = Color.Black;
                                    //    cellInvExpiryDate.ReadOnly = true;
                                    //    cellProExpiryDate.Style.BackColor = Color.LightGray;
                                    //    cellProExpiryDate.Style.ForeColor = Color.Black;
                                    //    cellProExpiryDate.ReadOnly = true;
                                    //}
                                    if (varEditFlag == 0)
                                    {
                                        DataGridView dataGridView1 = grdInward;
                                        string cellPRID =Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmPRID"].Value);
                                        string cellUnit = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmUnit"].Value);
                                        string cellProductName = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmProductName"].Value);
                                        string cellUTID = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmUTID"].Value);
                                        string cellInvMrp = "0";
                                        if (Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmInvoiceMRP"].Value) != "")
                                        { cellInvMrp = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmInvoiceMRP"].Value);}
                                        string cellProMrp = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmMRP"].Value);
                                        string cellInvExpiryDate = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmInvoiceExpiryDate"].Value);
                                        string cellProExpiryDate = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmExpiryDate"].Value);
                                        string cellShelfLife = "0";
                                        string cellActualShelfLife = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmActuallife"].Value);
                                        string cellShelfLifePer = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmShelflifePer"].Value);
                                        string cellProBatchNo = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmBatchNo"].Value);
                                        string cellInvBatchNo = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmInvoiceBatchNo"].Value);
                                        string cellBatchenable = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmBatchNoStatus"].Value);
                                        string cellBatchgeneration = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmBatchNoGeneration"].Value);
                                        string cellRack = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmRack"].Value);
                                        string cellShelfLifeEnable = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmShelflifeStatus"].Value);
                                        string cellRKID = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmRKID"].Value);
                                        string cellRKCount = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmRackCount"].Value);
                                        string cellMRPFlag = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmMRPFlag"].Value);
                                        string cellRMFlag = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmRMFlag"].Value);
                                        string cellShelflifeType = Convert.ToString(grdInward.Rows[grdInward.Rows.Count - 1].Cells["clmShelfType"].Value);

                                        dtInwardPurchase.Rows.Add(value, Convert.ToInt32(varSno), varConvertType, varChildRowNo, Convert.ToInt32(cellPRID), Convert.ToInt32(cellUTID), 0,
                                        0, Convert.ToInt32(0),Convert.ToString(cellProExpiryDate), Convert.ToString(cellProBatchNo), Convert.ToDecimal(0),Convert.ToInt16(varGRN_DC_PUR_ID),
                                        Convert.ToInt16(cellMRPFlag),
                                        Convert.ToInt16(cellShelfLifeEnable),Convert.ToInt16(cellBatchenable), Convert.ToInt16(cellBatchgeneration), varPRStatus, 0, Convert.ToInt32(cellShelfLife),
                                        Convert.ToInt32(varShelflifeType), 
                                        Convert.ToInt32(varActualLife),Convert.ToInt32(cellShelfLifeEnable), Convert.ToDecimal(cellShelfLifePer), Convert.ToString(cellInvExpiryDate), Convert.ToString(cellInvBatchNo),
                                        Convert.ToDecimal(cellInvMrp));

                                    }
                                    DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                    GrdGrnlist_DataBindingComplete(grdInward, args2);

                                    if (e.RowIndex >= 0)
                                    {
                                        this.grdInward.Rows[e.RowIndex].Cells["clmDisable"].Value= e.RowIndex + 1;
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
                                grdInward.Sort(grdInward.Columns["clmOrder"], ListSortDirection.Ascending);
                            }
                            break;
                        case "clmRemove":
                            if (Convert.ToString(grdInward.CurrentRow.Cells["clmError"].Value) == "0")
                            {
                                for (int i = 0; i < dtInwardPurchase.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtInwardPurchase.Rows[i]["GIPPR_OrderID"]) == Convert.ToInt32(grdInward.CurrentRow.Cells["clmOrder"].Value))
                                    {
                                        dtInwardPurchase.Rows[i].Delete();
                                        dtInwardPurchase.AcceptChanges();
                                    }
                                }
                                grdInward.Rows.RemoveAt(this.grdInward.Rows[e.RowIndex].Index);
                            }
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    for (int i = 0; i < dtInwardPurchase.Rows.Count; i++)
                                    {
                                        if (Convert.ToInt32(dtInwardPurchase.Rows[i]["GIPPR_OrderID"]) == Convert.ToInt32(grdInward.CurrentRow.Cells["clmOrder"].Value))
                                        {
                                            dtInwardPurchase.Rows[i].Delete();
                                            dtInwardPurchase.AcceptChanges();
                                        }
                                    }
                                    grdInward.Rows.RemoveAt(this.grdInward.Rows[e.RowIndex].Index);
                                }
                            }
                            break;
                        case "clmCheck":
                            int varSNo = Convert.ToInt32(grdInward.CurrentRow.Cells["clmSno"].Value);
                            if (Convert.ToString(grdInward.Rows[e.RowIndex].Cells["clmSno"].Value)!="")
                            {
                                for (int i = 0; i < dtInwardPurchase.Rows.Count; i++)
                                {
                                    if (Convert.ToBoolean(grdInward.CurrentRow.Cells["clmCheck"].Value) == true)
                                    {
                                        if (Convert.ToInt32(dtInwardPurchase.Rows[i]["GIPPR_SNO"]) == varSNo)
                                        {
                                            dtInwardPurchase.Rows[i]["Column1"] = true;
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(dtInwardPurchase.Rows[i]["GIPPR_SNO"]) == varSNo)
                                        {
                                            dtInwardPurchase.Rows[i]["Column1"] = false;
                                        }
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
        public void udfnConvertProductDetails(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 int row = Convert.ToInt16(grdInward.Rows.Count - 1);

                string SelectedPICode = grdInward.Rows[row].Cells["clmPicode"].Value?.ToString();
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewCell cellPICode = dataGridView.Rows[row].Cells["clmPICode"];
                DataGridViewCell cellPrid = dataGridView.Rows[row].Cells["clmPRID"];
                DataGridViewCell cellUnit = dataGridView.Rows[row].Cells["clmUnit"];
                DataGridViewCell cellProductName = dataGridView.Rows[row].Cells["clmProductName"];
                DataGridViewCell cellUTID = dataGridView.Rows[row].Cells["clmUTID"];
                DataGridViewCell cellInvMrp = dataGridView.Rows[row].Cells["clmInvoiceMRP"];
                DataGridViewCell cellProMrp = dataGridView.Rows[row].Cells["clmMRP"];
                DataGridViewCell cellInvExpiryDate = dataGridView.Rows[row].Cells["clmInvoiceExpiryDate"];
                DataGridViewCell cellProExpiryDate = dataGridView.Rows[row].Cells["clmExpiryDate"];
                DataGridViewCell cellShelfLife = dataGridView.Rows[row].Cells["clmShelfValue"];
                DataGridViewCell cellActualShelfLife = dataGridView.Rows[row].Cells["clmActuallife"];
                DataGridViewCell cellShelfLifePer = dataGridView.Rows[row].Cells["clmShelflifePer"];
                DataGridViewCell cellProBatchNo  = dataGridView.Rows[row].Cells["clmBatchNo"];
                DataGridViewCell cellInvBatchNo = dataGridView.Rows[row].Cells["clmInvoiceBatchNo"];
                DataGridViewCell cellBatchenable = dataGridView.Rows[row].Cells["clmBatchNoStatus"];
                DataGridViewCell cellBatchgeneration = dataGridView.Rows[row].Cells["clmBatchNoGeneration"];
                DataGridViewCell cellRack = dataGridView.Rows[row].Cells["clmRack"];
                DataGridViewCell cellShelfLifeEnable = dataGridView.Rows[row].Cells["clmShelflifeStatus"];
                DataGridViewCell cellRKID = dataGridView.Rows[row].Cells["clmRKID"];
                DataGridViewCell cellRKCount = dataGridView.Rows[row].Cells["clmRackCount"];
                DataGridViewCell cellMRPFlag = dataGridView.Rows[row].Cells["clmMRPFlag"];
                DataGridViewCell cellRMFlag = dataGridView.Rows[row].Cells["clmRMFlag"];

                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 61;
                objMR_Product.ParaCompanycode = Convert.ToInt32(varConcernId);
                objMR_Product.ParaScheduleid =Convert.ToString(varScheduleId);
                objMR_Product.ParaProductCode = 0;
                objMR_Product.ParaSupplierId = Convert.ToInt16(varSupplierId);
                objMR_Product.paraPicode = SelectedPICode;
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    string varPRID = "0", varBatchNoEnable = "0", varBatchNoGeneration = "0", 
                     varShelflifeFlag = "0", varShelflife = "0",  varHSNid = "0", varPrMRPFlag = "0", varProductMRPFlag = "0",
                     varproTname = "", varUnit = "", varBatchNo = "", varProBatchNo = "", varExpiryDate = "", varProExpiryDate = "", varRMProductionFlag = "0", varLocationName = "", varLocationID = "0",
                     varRackName = "", varRackID = "0", varRkcount = "0", varRMFlag = "0", varUTID = "0";
                   
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
                    cellShelfLife.Value = varShelflife;
                    cellRKID.Value = varRackID;
                    cellRack.Value = varRackName;
                    cellProBatchNo.Value = varBatchNo;
                    cellProExpiryDate.Value = varExpiryDate;
                    cellShelfLife.ReadOnly = true;
                    if (varPrMRPFlag == "0")
                    {
                        cellProMrp.Style.BackColor = Color.LightGray; cellProMrp.Style.ForeColor = Color.Black;
                        cellProMrp.ReadOnly = true; cellProMrp.Value = "0.00";
                        cellInvMrp.Style.BackColor = Color.LightGray; cellInvMrp.Style.ForeColor = Color.Black;
                        cellInvMrp.ReadOnly = true; cellInvMrp.Value = "0.00";
                    }
                    else
                    {
                        cellInvMrp.Style.BackColor = Color.PaleGreen;
                        cellInvMrp.Style.ForeColor = Color.Black; cellInvMrp.ReadOnly = false;
                        cellProMrp.Style.BackColor = Color.PaleGreen;
                        cellProMrp.Style.ForeColor = Color.Black; cellProMrp.ReadOnly = false;
                    }
                    if (varShelflifeFlag == "0")
                    {
                        cellShelfLife.Value = "";
                        cellInvExpiryDate.Style.BackColor = Color.LightGray;
                        cellInvExpiryDate.ReadOnly = true;
                        cellProExpiryDate.Style.BackColor = Color.LightGray;
                        cellProExpiryDate.ReadOnly = true;
                    }
                    else
                    {
                        cellShelfLife.Style.BackColor = Color.PaleGreen; cellShelfLife.Style.ForeColor = Color.Black;
                        cellInvExpiryDate.Style.BackColor = Color.PaleGreen; cellInvExpiryDate.ReadOnly = false;
                        cellProExpiryDate.Style.BackColor = Color.PaleGreen; cellProExpiryDate.ReadOnly = false;
                    }
                    if (varBatchNoEnable == "73")
                    {
                        cellInvBatchNo.Style.BackColor = Color.LightGray;
                        cellInvBatchNo.Style.ForeColor = Color.Black;
                        cellInvBatchNo.ReadOnly = true;
                        cellInvBatchNo.Value = "";
                        cellProBatchNo.Style.BackColor = Color.LightGray;
                        cellProBatchNo.Style.ForeColor = Color.Black;
                        cellProBatchNo.ReadOnly = true;
                        cellProBatchNo.Value = "";
                    }
                    else if (varBatchNoEnable == "72")
                    {
                        if (varBatchNoGeneration == "75") //manul
                        {
                            cellInvBatchNo.Style.BackColor = Color.PaleGreen; cellInvBatchNo.Style.ForeColor = Color.Black;
                            cellInvBatchNo.ReadOnly = false; cellInvBatchNo.Value = "";
                            cellProBatchNo.Style.BackColor = Color.PaleGreen; cellProBatchNo.Style.ForeColor = Color.Black;
                            cellProBatchNo.ReadOnly = false; cellProBatchNo.Value = "";
                        }
                        else if (varBatchNoGeneration == "74")//Auto
                        {
                            cellInvBatchNo.Style.BackColor = Color.LightGray; cellInvBatchNo.Style.ForeColor = Color.Black;
                            cellInvBatchNo.ReadOnly = true;
                            cellProBatchNo.Style.BackColor = Color.LightGray; cellProBatchNo.Style.ForeColor = Color.Black;
                            cellProBatchNo.ReadOnly = true;
                        }
                    }
                    if (varRMProductionFlag == "1")
                    {
                        cellInvExpiryDate.Style.BackColor = Color.LightGray;
                        cellInvExpiryDate.Style.ForeColor = Color.Black;
                        cellInvExpiryDate.ReadOnly = true;
                        cellProExpiryDate.Style.BackColor = Color.LightGray;
                        cellProExpiryDate.Style.ForeColor = Color.Black;
                        cellProExpiryDate.ReadOnly = true;
                    }
                    //cellProductName.ReadOnly = true;
                    //cellProMrp.ReadOnly = true;
                    //cellInvExpiryDate.ReadOnly = true;
                    //cellInvBatchNo.ReadOnly = true;
                    //cellInvMrp.ReadOnly = true;
                    //cellPICode.ReadOnly = true;
                    //cellInvMrp.Style.BackColor = Color.LightGray;
                    //cellProMrp.Style.BackColor = Color.LightGray;
                    //cellInvMrp.Style.BackColor = Color.LightGray;
                    //cellInvBatchNo.Style.BackColor = Color.LightGray;
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
                DataSet objDs = new DataSet();
                int varCellprodid = 0;
                if (grdInward.Columns[e.ColumnIndex].Name == "clmExpiryDate")
                {
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    if (Convert.ToString(grdInward.Rows[e.RowIndex].Cells["clmExpiryDate"].Value) != "")
                    {
                        if (rowIndex >= 0 && columnIndex >= 0)
                        {
                            varCellprodid = Convert.ToInt32(grdInward.Rows[e.RowIndex].Cells["clmPRID"].Value);
                            string varTempYear = "0", varTempMonth = "0", varTempDay = "0";
                            object cellValue = grdInward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            string varExpiryDate = "";
                            varExpiryDate = cellValue.ToString();
                            string[] varDMY = varExpiryDate.Split('/');
                            if (varDMY.Count() == 2 || varDMY.Count() == 3 && varDMY[0] == "")
                            {
                                string varDate = "";
                                if (varDMY[0] == "")
                                {
                                    varDate = "01" + "/" + varDMY[1] + "/" + "20" + varDMY[2];
                                }
                                else
                                {
                                    varDate = "01" + "/" + varDMY[0] + "/" + "20" + varDMY[1];
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
                                    cellValue = objDSer.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();

                                    grdInward.Rows[e.RowIndex].Cells["clmExpiryDate"].Value = cellValue;
                                }
                            }
                            else if (varDMY.Count() == 3)
                            {
                                varTempDay = varDMY[0];
                                varTempMonth = varDMY[1];
                                varTempYear = varDMY[2];
                                if (varTempDay.Length == 1)
                                {
                                    varTempDay = "0" + varDMY[0];
                                }
                                if (varTempMonth.Length == 1)
                                {
                                    varTempMonth = "0" + varDMY[1];
                                }
                                if (varTempYear.Length == 2)
                                {
                                    varTempYear = "20" + varDMY[2];
                                }
                                cellValue = varTempDay + "/" + varTempMonth + "/" + varTempYear;
                                //grdInward.Rows[e.RowIndex].Cells["clmExpiryDate"].Value = cellValue;
                            }
                            varTempExpiryDate = cellValue.ToString();
                            if (cellValue != null && Convert.ToString(cellValue) != "")
                            {
                                varshelflife = cellValue.ToString();
                                if (varshelflife != "" || varshelflife != null)
                                {
                                    SPDataService objdserv = new SPDataService();
                                    TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                                    objTRN_GoodsInward_Purchase.ViewType = 7;
                                    objTRN_GoodsInward_Purchase.paraInwardId = varInwardId;
                                    objTRN_GoodsInward_Purchase.ParaInwardDate = dpInwardDate.Text;
                                    objTRN_GoodsInward_Purchase.ParaExpiryDate = varshelflife;
                                    objTRN_GoodsInward_Purchase.paraProductId = varCellprodid;
                                    objDs = objdserv.udfnInwardPurchaseList(objTRN_GoodsInward_Purchase);
                                    objdserv.CloseConnection();
                                    //objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, dpGrnDate.Text, varCellprodid, 0, "0", "", "");
                                    //objdserv.CloseConnection();
                                    if (objDs != null)
                                    {
                                        if (objDs.Tables[0].Rows.Count != 0)
                                        {
                                            if (objDs.Tables[0].Rows.Count > 0)
                                            {
                                                grdInward.Rows[rowIndex].Cells["clmShelflifePer"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
                                            }
                                        }
                                        if (objDs.Tables[1].Rows.Count != 0)
                                        {
                                            if (objDs.Tables[1].Rows.Count > 0)
                                            {
                                                grdInward.Rows[rowIndex].Cells["clmActuallife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
                                            }
                                        }
                                        string[] varShelflifevalue = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]).Split(' ');
                                        if (varShelflifevalue[0] != "")
                                        {
                                            if (Convert.ToDecimal(varShelflifevalue[0]) < 25)
                                            {
                                                DataGridView dataGridView = grdInward;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmActuallife"];
                                                cell.Style.BackColor = Color.Red;
                                                cell.Style.ForeColor = Color.White;

                                            }
                                            else if (Convert.ToDecimal(varShelflifevalue[0]) < 50)
                                            {
                                                DataGridView dataGridView = grdInward;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmActuallife"];
                                                cell.Style.BackColor = Color.Orange;
                                                cell.Style.ForeColor = Color.Black;
                                            }

                                            else
                                            {
                                                DataGridView dataGridView = grdInward;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                                cell.Style.BackColor = Color.White;
                                                cell.Style.ForeColor = Color.Black;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        grdInward.Rows[e.RowIndex].Cells["clmExpiryDate"].Value = varTempExpiryDate;
                        udfnGridAddvalue(sender, e);
                        /*if (dpGRNDate.Text != "")
                          {
                              string varTempExpiryDate = Convert.ToString(grdInward.Rows[e.RowIndex].Cells["clmExpiryDate"].Value);
                              MR_Master objMR_Master = new MR_Master();
                              objMR_Master.ViewType = 10;
                              objMR_Master.paraDate = dpGRNDate.Text.Trim();
                              objMR_Master.ParaExpiryDate = varTempExpiryDate;
                              objMR_Master.paraProductId = Convert.ToInt32(grdInward.CurrentRow.Cells["clmPRID"].Value);
                              SPDataService objDServe = new SPDataService();
                              DataSet objDS = new DataSet();
                              objDS = objDServe.udfnMaster(objMR_Master);
                              objDServe.CloseConnection();
                              if (objDS != null)
                              {
                                  DataGridView dgv = sender as DataGridView;
                                  if (objDS.Tables[0].Rows.Count > 0)
                                  {
                                      int Date = Convert.ToInt32(objDS.Tables[0].Rows[0]["DATE"]);
                                      if (Date == 0)
                                      {
                                          dgv.Rows[e.RowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                          pbDateflag = 1;
                                          string varMessage = objDServe.udfnGetMessages(95);
                                          objDServe.CloseConnection();
                                          MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                      }
                                  }

                                  if (objDS.Tables[1].Rows.Count > 0)
                                  {
                                      int ExpiryDate = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                      if (ExpiryDate < 0)
                                      {
                                          dgv.Rows[e.RowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                          pbDateflag = 1;
                                          string varMessage = objDServe.udfnGetMessages(95);
                                          objDServe.CloseConnection();
                                          MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                      }
                                  }
                                  if (objDS.Tables[2].Rows.Count > 0)
                                  {
                                      if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                      {
                                          pbDateflag = 1;
                                          if (Convert.ToString(grdInward.Rows[e.RowIndex].Cells["clmExpiryDate"].Value) == varTempExpiryDate)
                                          {
                                              dgv.Rows[e.RowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                              string varMessage = objDServe.udfnGetMessages(98);
                                              objDServe.CloseConnection();
                                              MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                          }
                                      }
                                      else
                                      {
                                          pbDateflag = 0
  ;
                                      }
                                      if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == -1)
                                      {
                                          dgv.Rows[e.RowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                          pbDateflag = 1;
                                          string varMessage = objDServe.udfnGetMessages(95);
                                          objDServe.CloseConnection();
                                          MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                      }
                                  }
                              }
                          }*/
                    }

                }
                if (grdInward.Columns[e.ColumnIndex].Name == "clmInvoiceExpiryDate")
                {
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    if (Convert.ToString(grdInward.Rows[e.RowIndex].Cells["clmInvoiceExpiryDate"].Value) != "")
                    {
                        if (rowIndex >= 0 && columnIndex >= 0)
                        {
                            varCellprodid = Convert.ToInt32(grdInward.Rows[e.RowIndex].Cells["clmPRID"].Value);
                            string varTempYear = "0", varTempMonth = "0", varTempDay = "0";
                            object cellValue = grdInward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            string varExpiryDate = "";
                            varExpiryDate = cellValue.ToString();
                            string[] varDMY = varExpiryDate.Split('/');
                            if (varDMY.Count() == 2 || varDMY.Count() == 3 && varDMY[0] == "")
                            {
                                string varDate = "";
                                if (varDMY[0] == "")
                                {
                                    varDate = "01" + "/" + varDMY[1] + "/" + "20" + varDMY[2];
                                }
                                else
                                {
                                    varDate = "01" + "/" + varDMY[0] + "/" + "20" + varDMY[1];
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
                                    cellValue = objDSer.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();

                                    grdInward.Rows[e.RowIndex].Cells["clmInvoiceExpiryDate"].Value = cellValue;
                                }
                            }
                            else if (varDMY.Count() == 3)
                            {
                                varTempDay = varDMY[0];
                                varTempMonth = varDMY[1];
                                varTempYear = varDMY[2];
                                if (varTempDay.Length == 1)
                                {
                                    varTempDay = "0" + varDMY[0];
                                }
                                if (varTempMonth.Length == 1)
                                {
                                    varTempMonth = "0" + varDMY[1];
                                }
                                if (varTempYear.Length == 2)
                                {
                                    varTempYear = "20" + varDMY[2];
                                }
                                cellValue = varTempDay + "/" + varTempMonth + "/" + varTempYear;
                                //grdInward.Rows[e.RowIndex].Cells["clmExpiryDate"].Value = cellValue;
                            }
                            varTempExpiryDate = cellValue.ToString();
                            if (cellValue != null && Convert.ToString(cellValue) != "")
                            {
                                varshelflife = cellValue.ToString();
                                if (varshelflife != "" || varshelflife != null)
                                {
                                    SPDataService objdserv = new SPDataService();
                                    TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                                    objTRN_GoodsInward_Purchase.ViewType = 7;
                                    objTRN_GoodsInward_Purchase.paraInwardId = varInwardId;
                                    objTRN_GoodsInward_Purchase.ParaInwardDate = dpInwardDate.Text;
                                    objTRN_GoodsInward_Purchase.ParaExpiryDate = varshelflife;
                                    objTRN_GoodsInward_Purchase.paraProductId = varCellprodid;
                                    objDs = objdserv.udfnInwardPurchaseList(objTRN_GoodsInward_Purchase);
                                    objdserv.CloseConnection();
                                    //objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, dpGrnDate.Text, varCellprodid, 0, "0", "", "");
                                    //objdserv.CloseConnection();
                                    if (objDs != null)
                                    {
                                        if (objDs.Tables[0].Rows.Count != 0)
                                        {
                                            if (objDs.Tables[0].Rows.Count > 0)
                                            {
                                                grdInward.Rows[rowIndex].Cells["clmShelflifePer"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
                                            }
                                        }
                                        if (objDs.Tables[1].Rows.Count != 0)
                                        {
                                            if (objDs.Tables[1].Rows.Count > 0)
                                            {
                                                grdInward.Rows[rowIndex].Cells["clmActuallife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
                                            }
                                        }
                                        string[] varShelflifevalue = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]).Split(' ');
                                        if (varShelflifevalue[0] != "")
                                        {
                                            if (Convert.ToDecimal(varShelflifevalue[0]) < 25)
                                            {
                                                DataGridView dataGridView = grdInward;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmActuallife"];
                                                cell.Style.BackColor = Color.Red;
                                                cell.Style.ForeColor = Color.White;

                                            }
                                            else if (Convert.ToDecimal(varShelflifevalue[0]) < 50)
                                            {
                                                DataGridView dataGridView = grdInward;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmActuallife"];
                                                cell.Style.BackColor = Color.Orange;
                                                cell.Style.ForeColor = Color.Black;
                                            }

                                            else
                                            {
                                                DataGridView dataGridView = grdInward;
                                                DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                                cell.Style.BackColor = Color.White;
                                                cell.Style.ForeColor = Color.Black;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        grdInward.Rows[e.RowIndex].Cells["clmInvoiceExpiryDate"].Value = varTempExpiryDate;
                        udfnGridAddvalue(sender, e);
       
                    }

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridAddvalue(object sender, DataGridViewCellEventArgs value)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;
                varExpiryDate = "";
                string varDate = "";
                varShelflife = 0;
                varErroronGrid = 0;
                int varExpiryDays = 0; int error = 0, rowIndex = value.RowIndex, columnIndex = value.ColumnIndex, varProid = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (varGRNPurchaseFlag == 1)
                {
                    varDate = dpGRNDate.Text;
                }
                else if (varGRNPurchaseFlag == 2)
                {
                    varDate = dpInwardDate.Text;
                }
                else
                {
                    varDate = dpGRNDate.Text;
                }
                if (grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate")
                {
                    varExpiryDate = Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value);
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
                    if (varDate != "")
                    {
                        string varTempExpiryDate = Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value);
                        MR_Master objMR_Master = new MR_Master();
                        objMR_Master.ViewType = 10;
                        objMR_Master.paraDate = varDate.Trim();
                        objMR_Master.ParaExpiryDate = varTempExpiryDate;
                        objMR_Master.paraProductId = Convert.ToInt32(grdInward.CurrentRow.Cells["clmPRID"].Value);
                        SPDataService objDServe = new SPDataService();
                        objDS = objDServe.udfnMaster(objMR_Master);
                        objDServe.CloseConnection();
                        varShelflife = Convert.ToInt32(grdInward.Rows[rowIndex].Cells["clmShelflifeStatus"].Value);
                        pbDateflag = 0;
                        if (pbDateflag == 0)
                        {
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate")
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
                                                        if (Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value) == varTempExpiryDate)
                                                        {
                                                            grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                                            string varMessage = objDServ.udfnGetMessages(98);
                                                            objDServ.CloseConnection();
                                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(grdInward.Rows[rowIndex].Cells["clmConvertType"].Value) != "1")
                                                        {
                                                            grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.PaleGreen;
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
                                if (varTempExpiryDate != "")
                                {
                                    if (Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value) == varTempExpiryDate)
                                    {
                                        varErroronGrid = 1;
                                        grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                        string varMessage = objDServ.udfnGetMessages(94);
                                        objDServ.CloseConnection();
                                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            
                        }
                    }
                }
                if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceExpiryDate")
                {
                    varExpiryDate = Convert.ToString(grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Value);
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

                    if (varDate != "")
                    {
                        string varTempExpiryDate = Convert.ToString(grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Value);
                        MR_Master objMR_Master = new MR_Master();
                        objMR_Master.ViewType = 10;
                        objMR_Master.paraDate = varDate.Trim();
                        objMR_Master.ParaExpiryDate = varTempExpiryDate;
                        objMR_Master.paraProductId = Convert.ToInt32(grdInward.CurrentRow.Cells["clmPRID"].Value);
                        SPDataService objDServe = new SPDataService();
                        objDS = objDServe.udfnMaster(objMR_Master);
                        objDServe.CloseConnection();
                        varShelflife = Convert.ToInt32(grdInward.Rows[rowIndex].Cells["clmShelflifeStatus"].Value);
                        pbDateflag = 0;
                        if (pbDateflag == 0)
                        {
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceExpiryDate")
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
                                                        if (Convert.ToString(grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Value) == varTempExpiryDate)
                                                        {
                                                            grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightPink;
                                                            string varMessage = objDServ.udfnGetMessages(98);
                                                            objDServ.CloseConnection();
                                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(grdInward.Rows[rowIndex].Cells["clmConvertType"].Value) != "1")
                                                        {
                                                            grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.PaleGreen;
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
                                if (varTempExpiryDate != "")
                                {
                                    if (Convert.ToString(grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Value) == varTempExpiryDate)
                                    {
                                        varErroronGrid = 1;
                                        grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightPink;
                                        string varMessage = objDServ.udfnGetMessages(94);
                                        objDServ.CloseConnection();
                                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void GrdGrnlist_CurrentCellDirtyStateChanged(object sender, EventArgs e)
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

        private void BtnRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    BtnRemarks_Click(sender,e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TspHeader_Click(object sender, EventArgs e)
        {

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
            }
        }
        public void udfnSave()
        {
            try
            {
                grdInward.ClearSelection();
                int varProCount = 0, varInvalidQty = 0;varQuantityErr = 0;
                varStsErr = 0;
                if (grdInward.RowCount > 0)
                {
                    decimal varTotalQty1 = 0, varQty1 = 0;
                    string varStockQty = "0";
                    bool varErrorFlag = true;
                    if (txtInwardNo.Text == "")
                    {
                        epInwardPurchase.SetError(txtInwardNo, "Inward No. is empty.");
                        tpInwardNo.ShowAlways = true;
                        tpInwardNo.Show("DC No. is empty.", txtInwardNo, 5000);
                        varErrorFlag = false;
                    }
                    if (varEditFlag == 0)
                    {
                        decimal varInvoiceQty = 0, varFinalQty=0;
                        for (int i = 0; i < dtInwardPurchase.Rows.Count; i++)
                        {
                            string varSno = "";
                            if (Convert.ToBoolean(dtInwardPurchase.Rows[i]["Column1"]) == true && Convert.ToString(dtInwardPurchase.Rows[i]["GIPPR_ConvertType"]) == "1")
                            {
                                varSno = Convert.ToString(dtInwardPurchase.Rows[i]["GIPPR_SNO"].ToString());
                                for (int j = 0; j < grdInward.Rows.Count; j++)
                                {
                                    int varApprovedQty = 0;
                                    if (Convert.ToString(grdInward.Rows[j].Cells["clmUnReadable"].Value) == "0")
                                    {
                                        if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) == "1" && Convert.ToBoolean(grdInward.Rows[j].Cells["clmCheck"].Value) == true)
                                        {
                                            if (Convert.ToString(grdInward.Rows[j].Cells["clmReceivedQty"].Value) != "")
                                            {
                                                decimal varReQty = Convert.ToDecimal(grdInward.Rows[j].Cells["clmReceivedQty"].Value);
                                                string varRQty = string.Format("{0:0.00}", varReQty);
                                                string varRQty1 = string.Format("{0:G29}", decimal.Parse(varRQty));

                                                if (Convert.ToString(grdInward.Rows[j].Cells["clmReceivedQty"].Value) != "" && Convert.ToDecimal(varRQty1) == 0)
                                                {
                                                    //if (Convert.ToString(grdInward.Rows[j].Cells["clmReceivedQty"].Value) != "0")
                                                    //{
                                                    grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                                    varErrorFlag = false;
                                                    // }
                                                }
                                            }
                                            //if (Convert.ToString(grdInward.Rows[j].Cells["clmShopQty"].Value) != "")
                                            //{
                                            //    decimal varShQty = Convert.ToDecimal(grdInward.Rows[j].Cells["clmShopQty"].Value);
                                            //    string varSQty = string.Format("{0:0.00}", varShQty);
                                            //    string varSQty1 = string.Format("{0:G29}", decimal.Parse(varSQty));
                                            //    //if (Convert.ToString(grdInward.Rows[j].Cells["clmShopQty"].Value) != "" && Convert.ToInt32(varSQty1) < 1)
                                            //    //{
                                            //    //    grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                            //    //    varErrorFlag = false;
                                            //    //}
                                            //}
                                            ////if (Convert.ToString(grdInward.Rows[j].Cells["clmStatus"].Value)=="81")
                                            ////{
                                            ////    grdInward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                            ////    varErrorFlag = false;
                                            ////}
                                            varInvoiceQty = Convert.ToDecimal(grdInward.Rows[j].Cells["clmQty"].Value);
                                            varFinalQty = Convert.ToDecimal(grdInward.Rows[j].Cells["clmFinalQty"].Value); //received quatity subtracted when it has return qtty or free qty or Credit qty
                                            if (Convert.ToString(dtInwardPurchase.Rows[i]["GIPPR_INVSTSID"].ToString()) == "82" &&
                                                Convert.ToString(dtInwardPurchase.Rows[i]["GIPPR_SNO"].ToString()) == Convert.ToString(grdInward.Rows[j].Cells["clmDuplicateSno"].Value)) // Product status approved
                                            {
                                                decimal varTotalQty = 0;
                                                int varIDvalue = Convert.ToInt32(grdInward.Rows[j].Cells["clmDuplicateSno"].Value);

                                                var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                                                            .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                                             .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                                var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                                        .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                         .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();
                                                if (varFinalQty != 0)
                                                {
                                                    varTotalQty = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);
                                                    if (varFinalQty < (Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty)))
                                                    {
                                                        if (varGRNPurchaseFlag != 1)
                                                        {
                                                            varQuantityErr++;
                                                            grdInward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                                            grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.LightPink;
                                                            grdInward.Rows[j].Cells["clmInvoiceMRP"].Style.BackColor = Color.LightPink;
                                                            grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                                            grdInward.Rows[j].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightPink;
                                                            grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightPink;
                                                            grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Style.BackColor = Color.LightPink;
                                                            grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                                            grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                                            grdInward.Rows[j].Cells["clmStatus"].Style.BackColor = Color.LightPink;
                                                            varApprovedQty = 1;
                                                        }
                                                    }
                                                }
                                                //if (varInvoiceQty != 0)
                                                //{
                                                //    varTotalQty = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);
                                                //    if (varInvoiceQty < Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty))
                                                //    {
                                                //        if (varGRNPurchaseFlag != 1)
                                                //        {
                                                //            varQuantityErr++;
                                                //            grdInward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                                //            grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.LightPink;
                                                //            grdInward.Rows[j].Cells["clmInvoiceMRP"].Style.BackColor = Color.LightPink;
                                                //            grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                                //            grdInward.Rows[j].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightPink;
                                                //            grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightPink;
                                                //            grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Style.BackColor = Color.LightPink;
                                                //            grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                                //            grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                                //            grdInward.Rows[j].Cells["clmStatus"].Style.BackColor = Color.LightPink;
                                                //            varApprovedQty = 1;
                                                //        }
                                                //    }
                                                //}
                                            }
                                        }
                                    }
                                    decimal varShopQty = 0, varReceivedQty = 0, varRackID = 0, varRackCount = 0;
                                    if (Convert.ToString(grdInward.Rows[j].Cells["clmDuplicateSno"].Value) == varSno)
                                    {
                                        if (varEditFlag == 0)
                                        {
                                            int varSnovalue = 0, varPRIDs = 0, varOrderID = 0, varBatchNo = 0, varShelflifeStatus = 0, varMRPFlag = 0;
                                            //if (Convert.ToString(grdGrnlist.Rows[j].Cells["clmConvertType"].Value) == "1")
                                            //{
                                                //if (Convert.ToBoolean(grdGrnlist.Rows[j].Cells["clmCheck"].Value) == true)
                                                //{
                                                    varSnovalue = Convert.ToInt32(grdInward.Rows[j].Cells["clmDuplicateSno"].Value);
                                                    varPRIDs = Convert.ToInt32(grdInward.Rows[j].Cells["clmPRID"].Value);
                                                    varOrderID = Convert.ToInt32(grdInward.Rows[j].Cells["clmOrder"].Value);
                                                    varBatchNo = Convert.ToInt32(grdInward.Rows[j].Cells["clmBatchNoStatus"].Value);
                                                    varShelflifeStatus = Convert.ToInt32(grdInward.Rows[j].Cells["clmShelflifeStatus"].Value);
                                                    varMRPFlag = Convert.ToInt32(grdInward.Rows[j].Cells["clmMRPFlag"].Value);
                                                //}
                                                //if (Convert.ToBoolean(grdGrnlist.Rows[j].Cells["clmCheck"].Value) == true)
                                                //{
                                                    varProCount = 1;
                                                    if (varGRNPurchaseFlag != 1)
                                                    {
                                                        int varIDvalue = Convert.ToInt32(grdInward.Rows[j].Cells["clmDuplicateSno"].Value);
                                                        varQty1 = Convert.ToDecimal(grdInward.Rows[j].Cells["clmQty"].Value);
                                                        varFinalQty= Convert.ToDecimal(grdInward.Rows[j].Cells["clmFinalQty"].Value);
                                                         var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                                 .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                                        var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                                 .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                                        varQty1 = Convert.ToDecimal(grdInward.Rows[j].Cells["clmQty"].Value);
                                                        if (varFinalQty != 0)
                                                        {
                                                            varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);
                                                            if (varFinalQty > varTotalQty1 || varFinalQty == varTotalQty1)
                                                            {
                                                                grdInward.Rows[j].DefaultCellStyle.BackColor = Color.White;
                                                                if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) == "1")
                                                                {
                                                                    grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                                                                    grdInward.Rows[j].Cells["clmInvoiceMRP"].Style.BackColor = Color.LightGray;
                                                                    grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightGray;
                                                                    grdInward.Rows[j].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightGray;
                                                                    grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightGray;
                                                                    grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Style.BackColor = Color.LightGray;
                                                                    //grdInward.Rows[j].Cells["clmQty"].Style.BackColor = Color.PaleGreen;
                                                                    grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.PaleGreen;
                                                                    grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.PaleGreen;
                                                                    grdInward.Rows[j].Cells["clmRack"].Style.BackColor = Color.PaleGreen;
                                                                }
                                                                else
                                                                {
                                                                   // grdInward.Rows[j].DefaultCellStyle.BackColor = Color.White;
                                                                    grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.White;
                                                                    grdInward.Rows[j].Cells["clmInvoiceMRP"].Style.BackColor = Color.White;
                                                                    grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.White;
                                                                    grdInward.Rows[j].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.White;
                                                                    grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.White;
                                                                    grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Style.BackColor = Color.White;
                                                                    //grdInward.Rows[j].Cells["clmQty"].Style.BackColor = Color.PaleGreen;
                                                                    grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.White;
                                                                    grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.White;
                                                                    grdInward.Rows[j].Cells["clmRack"].Style.BackColor = Color.White;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                varQuantityErr++;
                                                                //grdInward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                                                //grdInward.Rows[j].Cells["clmQty"].Style.BackColor = Color.PaleGreen;
                                                                grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                                                grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                                                grdInward.Rows[j].Cells["clmRack"].Style.BackColor = Color.LightPink;
                                                                //if (Convert.ToString(grdInward.Rows[j].Cells["clmShopQty"].Value) != "")
                                                                //{
                                                                //    grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                                                //}
                                                                varErrorFlag = false;
                                                            }
                                                        }
                                                    }
                                            //}
                                            
                                            if (Convert.ToString(grdInward.Rows[j].Cells["clmRack"].Value) == "")
                                            {
                                                varRackID = 0;
                                            }
                                            else if(Convert.ToString(grdInward.Rows[j].Cells["clmRack"].Value) == "None" || Convert.ToString(grdInward.Rows[j].Cells["clmRack"].Value) == "none")
                                            {
                                                varRackID = 0;
                                            }
                                            else
                                            {
                                                varRackID = Convert.ToInt32(grdInward.Rows[j].Cells["clmRKID"].Value);
                                            }
                                            if (varRackID == -1)
                                            {
                                                grdInward.Rows[j].Cells["clmRack"].Style.BackColor = Color.LightPink;
                                                varErrorFlag = false;
                                            }
                                            if (varSnovalue != 0)
                                            {
                                                var varDuplicateProduct = from r in dtInwardPurchase.AsEnumerable()
                                                                          where ((r.Field<bool>("Column1").Equals(true) &&
                                                                                 r.Field<int>("GIPPR_SNO").Equals(varSnovalue)) &&
                                                                                 r.Field<decimal>("GIPPR_MRP").Equals("0") &&
                                                                                 r.Field<int>("PR_MRPStatus").Equals(1) || //////MRP
                                                                                 r.Field<string>("GIPPR_ExpiryDate").Equals("") &&
                                                                                 r.Field<int>("PR_ExpiryStatus").Equals(1) || //////Expiry
                                                                                 r.Field<string>("GIPPR_BatchNo").Equals("") &&
                                                                                 //r.Field<int>("PR_BatchNoGeneration").Equals(74) ||
                                                                                 r.Field<int>("PR_BatchNoGeneration").Equals(75))
                                                                          group r by r.Field<int>("GIPPR_OrderID")
                                                                         into g
                                                                          select g.Key;

                                                int varcount = varDuplicateProduct.Count();
                                                if (varDuplicateProduct.Count() == 0)
                                                {
                                                    grdInward.Rows[j].Cells["clmError"].Value = 0;
                                                    if (varApprovedQty == 0)
                                                    {
                                                        //grdInward.Rows[j].DefaultCellStyle.BackColor = Color.White;
                                                        if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) == "1")
                                                        {
                                                            //grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.White;
                                                            //grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.White;
                                                            //grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.White;
                                                            //grdInward.Rows[j].Cells["clmStatus"].Style.BackColor = Color.White;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(grdInward.Rows[j].Cells["clmMRPFlag"].Value) == "1")
                                                            {
                                                                grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.PaleGreen;
                                                            }
                                                            else
                                                            {
                                                                grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                                                            }
                                                            if (Convert.ToString(grdInward.Rows[j].Cells["clmShelflifeStatus"].Value) == "1")
                                                            {
                                                                grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.PaleGreen;
                                                            }
                                                            else
                                                            {
                                                                grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightGray;
                                                            }
                                                            if (Convert.ToString(grdInward.Rows[j].Cells["clmBatchNoGeneration"].Value) == "75")
                                                            {
                                                                grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.PaleGreen;
                                                            }
                                                            else
                                                            {
                                                                grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightGray;
                                                            }
                                                        }
                                                        //grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.PaleGreen;
                                                        //grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.PaleGreen;
                                                        if (varRackID != -1)
                                                        {
                                                            if (varQuantityErr == 0)
                                                            {
                                                                grdInward.Rows[j].Cells["clmRack"].Style.BackColor = Color.PaleGreen;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    varInvalidQty = 2;
                                                    varErrorFlag = false;
                                                    grdInward.Rows[j].Cells["clmError"].Value = 1;
                                                    //grdInward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                                    //grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                                    //grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.LightPink;
                                                    //grdInward.Rows[j].Cells["clmInvoiceMRP"].Style.BackColor = Color.LightPink;
                                                    //grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                                    //grdInward.Rows[j].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightPink;
                                                    if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) == "1")
                                                    {
                                                        //grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightPink;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(grdInward.Rows[j].Cells["clmBatchNoGeneration"].Value) == "75")
                                                        {
                                                            //grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightPink;
                                                            //grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Style.BackColor = Color.LightPink;
                                                        }
                                                        else
                                                        {
                                                            grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightGray;
                                                            grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Style.BackColor = Color.LightGray;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        //if (chkCompleted.Checked == true )
                                        //{
                                        //    if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) == "1")
                                        //    {
                                        //        if (varGRNPurchaseFlag == 3 && varGRNPurchaseFlag == 187)   //From dc- Queue
                                        //        {
                                        //            int varIDvalue = Convert.ToInt32(grdInward.Rows[j].Cells["clmDuplicateSno"].Value);
                                        //            varQty1 = Convert.ToDecimal(grdInward.Rows[j].Cells["clmQty"].Value);
                                        //            varInvoiceQty = Convert.ToDecimal(grdInward.Rows[j].Cells["clmQty"].Value);

                                        //            var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                        //                                    .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                        //                                     .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                        //            var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                        //                                    .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                        //                                     .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                        //            varQty1 = Convert.ToDecimal(grdInward.Rows[j].Cells["clmQty"].Value);
                                        //            if (varQty1 != 0)
                                        //            {
                                        //                varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);
                                        //                if (varQty1 > varTotalQty1 || varQty1 == varTotalQty1)
                                        //                {
                                        //                    grdInward.Rows[j].DefaultCellStyle.BackColor = Color.White;
                                        //                    if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) == "1")
                                        //                    {
                                        //                        grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                                        //                        grdInward.Rows[j].Cells["clmInvoiceMRP"].Style.BackColor = Color.LightGray;
                                        //                        grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightGray;
                                        //                        grdInward.Rows[j].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightGray;
                                        //                        grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightGray;
                                        //                        grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Style.BackColor = Color.LightGray;
                                        //                        //grdInward.Rows[j].Cells["clmQty"].Style.BackColor = Color.PaleGreen;
                                        //                        grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.PaleGreen;
                                        //                        grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.PaleGreen;
                                        //                        grdInward.Rows[j].Cells["clmRack"].Style.BackColor = Color.PaleGreen;
                                        //                    }
                                        //                    else
                                        //                    {
                                        //                        grdInward.Rows[j].DefaultCellStyle.BackColor = Color.White;
                                        //                    }
                                        //                }
                                        //                else
                                        //                {
                                        //                    varQuantityErr++;
                                        //                    grdInward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                        //                    if (Convert.ToString(grdInward.Rows[j].Cells["clmShopQty"].Value) != "")
                                        //                    {
                                        //                        grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.Pink;
                                        //                    }
                                        //                    varErrorFlag = false;
                                        //                }
                                        //            }
                                        //        }

                                        //        if (varGRNPurchaseFlag == 2 && varGRNPurchaseFlag==175)   //From Purchase- Queue
                                        //        {
                                        //            int varIDvalue = Convert.ToInt32(grdInward.Rows[j].Cells["clmSno"].Value);

                                        //            var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                        //                                    .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                        //                                     .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                        //            var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                        //                                    .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                        //                                     .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                        //            varQty1 = Convert.ToDecimal(grdInward.Rows[j].Cells["clmQty"].Value);
                                        //            varInvoiceQty = Convert.ToDecimal(grdInward.Rows[j].Cells["clmQty"].Value);
                                        //            varFinalQty = Convert.ToDecimal(grdInward.Rows[j].Cells["clmFinalQty"].Value);
                                        //            if (varFinalQty != 0)
                                        //            {
                                        //                varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);

                                        //                if (varFinalQty < varTotalQty1)
                                        //                {
                                        //                    varQuantityErr++;
                                        //                    grdInward.Rows[j].Cells["clmQty"].Style.BackColor = Color.LightPink;
                                        //                    grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                        //                    grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                        //                }
                                        //            }
                                        //            //if (varQty1 != 0)
                                        //            //{
                                        //            //    varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);

                                        //            //    if (varQty1 < varTotalQty1)
                                        //            //    {
                                        //            //        varQuantityErr++;
                                        //            //        grdInward.Rows[j].Cells["clmQty"].Style.BackColor = Color.LightPink;
                                        //            //        grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                        //            //        grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                        //            //    }
                                        //            //}
                                        //        }
                                        //        //if(Convert.ToString(grdInward.Rows[j].Cells["clmStatus"].Value)=="81")
                                        //        //{
                                        //        //    grdInward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                        //        //    //MessageBox.Show("Please approve this product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        //        //    varErrorFlag = false;
                                        //        //}
                                        //    }
                                        //}
                                    }
                                    //if (Convert.ToBoolean(dtInwardPurchase.Rows[i]["Column1"]) == true && Convert.ToString(dtInwardPurchase.Rows[i]["GIPPR_ConvertType"]) == "1" && Convert.ToString(dtInwardPurchase.Rows[i]["GIPPR_SNO"]) == Convert.ToString(grdInward.Rows[j].Cells["clmDuplicateSno"].Value))
                                    //{
                                    //    //if(Convert.ToString(grdInward.Rows[j].Cells["clmStatus"].Value)=="81")
                                    //    //{
                                    //    //    grdInward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                    //    //}
                                    //}
                                    if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) == "1" && (Convert.ToString(grdInward.Rows[j].Cells["clmUnReadable"].Value) == "0")) 
                                    {
                                        if (Convert.ToBoolean(grdInward.Rows[j].Cells["clmCheck"].Value) == true)
                                        {
                                            if (Convert.ToString(grdInward.Rows[j].Cells["clmReceivedQty"].Value) != "" || Convert.ToString(grdInward.Rows[j].Cells["clmShopQty"].Value) != "")
                                            {
                                                if (Convert.ToString(grdInward.Rows[j].Cells["clmReceivedQty"].Value) == "0" && Convert.ToString(grdInward.Rows[j].Cells["clmShopQty"].Value) == "0")
                                                {
                                                    grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                                    grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                                    varErrorFlag = false;
                                                }
                                            }
                                            else
                                            {
                                                grdInward.Rows[j].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                                grdInward.Rows[j].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                                varErrorFlag = false;
                                            }
                                        }
                                    }

                                    //Empty then Cell Highlight
                                    if ((Convert.ToString(grdInward.Rows[j].Cells["clmMRP"].Value) == "" || Convert.ToString(grdInward.Rows[j].Cells["clmMRP"].Value) == "0" || 
                                        Convert.ToString(grdInward.Rows[j].Cells["clmMRP"].Value) == "0.00") && Convert.ToString(grdInward.Rows[j].Cells["clmMRPFlag"].Value) == "1")
                                    {
                                        if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) != "1")
                                        {
                                            grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            grdInward.Rows[j].Cells["clmMRP"].Style.BackColor = Color.LightGray;
                                        }
                                    }

                                    if ((Convert.ToString(grdInward.Rows[j].Cells["clmExpiryDate"].Value) == "") && Convert.ToString(grdInward.Rows[j].Cells["clmShelflifeStatus"].Value) == "1")
                                    {
                                        if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) != "1")
                                        {
                                            grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightGray;
                                        }
                                    }

                                    if ((Convert.ToString(grdInward.Rows[j].Cells["clmBatchNo"].Value) == "") && Convert.ToString(grdInward.Rows[j].Cells["clmBatchNoStatus"].Value) == "1")
                                    {
                                        if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) != "1")
                                        {
                                            grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            grdInward.Rows[j].Cells["clmBatchNo"].Style.BackColor = Color.LightGray;
                                        }
                                    }
                                    if (varGRNPurchaseFlag != 3 && varGRNPurchaseFlag != 187) //DC Wise no show Invoice MRP,Expiry,Batch 
                                    {
                                        if ((Convert.ToString(grdInward.Rows[j].Cells["clmInvoiceMRP"].Value) == "" || Convert.ToString(grdInward.Rows[j].Cells["clmInvoiceMRP"].Value) == "0.00") && Convert.ToString(grdInward.Rows[j].Cells["clmMRPFlag"].Value) == "1")
                                        {
                                            varErrorFlag = false;
                                            if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) != "1")
                                            {
                                                grdInward.Rows[j].Cells["clmInvoiceMRP"].Style.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                grdInward.Rows[j].Cells["clmInvoiceMRP"].Style.BackColor = Color.LightGray;
                                            }
                                        }
                                        if ((Convert.ToString(grdInward.Rows[j].Cells["clmInvoiceExpiryDate"].Value) == "") && Convert.ToString(grdInward.Rows[j].Cells["clmShelflifeStatus"].Value) == "1")
                                        {
                                            varErrorFlag = false;
                                            if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) != "1")
                                            {
                                                grdInward.Rows[j].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                grdInward.Rows[j].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightGray;
                                            }
                                        }
                                        if ((Convert.ToString(grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Value) == "") && Convert.ToString(grdInward.Rows[j].Cells["clmBatchNoStatus"].Value) == "1")
                                        {
                                            varErrorFlag = false;
                                            if (Convert.ToString(grdInward.Rows[j].Cells["clmConvertType"].Value) != "1")
                                            {
                                                grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Style.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                grdInward.Rows[j].Cells["clmInvoiceBatchNo"].Style.BackColor = Color.LightGray;
                                            }
                                        }
                                    }
                                }
                                int varStatus = 0;
                                if (Convert.ToString(grdInward.Rows[i].Cells["clmStatus"].Value) != "")
                                {
                                    varStatus = Convert.ToInt32(grdInward.Rows[i].Cells["clmStatus"].Value);
                                }
                                //{ row.SetField("GIPPR_INVSTSID", varStatus); }
                                dtInwardPurchase.Rows[i]["GIPPR_INVSTSID"] = varStatus;
                            }
                        }
                    }
                    if(varEditFlag==1)
                    {
                        int varRackID = 0; decimal varFinalQty= 0;
                        for (int i = 0; i < grdInward.Rows.Count; i++)
                        {
                            varProCount = 1;
                            if (varGRNPurchaseFlag != 174)
                            {
                                if (Convert.ToString(grdInward.Rows[i].Cells["clmConvertType"].Value) == "1")
                                {
                                    int varIDvalue = Convert.ToInt32(grdInward.Rows[i].Cells["clmEntrytypeProID"].Value);
                                    var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                            .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                             .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                    var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                            .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                             .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                    varQty1 = Convert.ToDecimal(grdInward.Rows[i].Cells["clmQty"].Value);
                                    varFinalQty = Convert.ToDecimal(grdInward.Rows[i].Cells["clmFinalQty"].Value);
                                    varStockQty = Convert.ToString(grdInward.Rows[i].Cells["clmStockQty"].Value);
                                    if (varFinalQty != 0)
                                    {
                                        varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);
                                        if (varFinalQty != varTotalQty1)
                                        {
                                            varQuantityErr++;
                                            grdInward.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                        }
                                    }
                                    if (varStockQty != "0")
                                    {
                                        decimal varReceivedQty = 0, varShopQty = 0;
                                        if (Convert.ToString(grdInward.Rows[i].Cells["clmReceivedQty"].Value) != "")
                                        {
                                            varReceivedQty = Convert.ToDecimal(grdInward.Rows[i].Cells["clmReceivedQty"].Value);
                                        }
                                        if (Convert.ToString(grdInward.Rows[i].Cells["clmShopQty"].Value) != "")
                                        {
                                            varShopQty = Convert.ToDecimal(grdInward.Rows[i].Cells["clmShopQty"].Value);
                                        }
                                        varTotalQty1 = varReceivedQty + varShopQty;
                                        if (varStockQty != "")
                                        {
                                            if (Convert.ToDecimal(varStockQty) > varTotalQty1)
                                            {
                                                varQuantityErr++;
                                                grdInward.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                                //grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                            }
                                        }
                                    }
                                }
                            }
                            if(Convert.ToString(grdInward.Rows[i].Cells["clmErrorQty"].Value) == "1")
                            {
                                grdInward.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                varErrorFlag = false;
                            }
                            //if(Convert.ToString(grdInward.Rows[i].Cells["clmStatus"].Value)=="81")
                            //{
                            //    grdInward.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                            //    grdInward.Rows[i].Cells["clmRack"].Style.BackColor = Color.LightPink;
                            //    grdInward.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                            //    grdInward.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                            //    varErrorFlag = false;
                            //}
                            //else
                            //{
                            //    grdInward.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            //    grdInward.Rows[i].Cells["clmRack"].Style.BackColor = Color.PaleGreen;
                            //    grdInward.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.PaleGreen;
                            //    grdInward.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.PaleGreen;
                            //}
                            if (Convert.ToString(grdInward.Rows[i].Cells["clmRack"].Value) == "")
                            {
                                varRackID = 0;
                            }
                            else if(Convert.ToString(grdInward.Rows[i].Cells["clmRack"].Value) == "None" || Convert.ToString(grdInward.Rows[i].Cells["clmRack"].Value) == "none")
                            {
                                varRackID = 0;
                            }
                            else
                            {
                                varRackID = Convert.ToInt32(grdInward.Rows[i].Cells["clmRKID"].Value);
                            }
                            if (varRackID == -1)
                            {
                                grdInward.Rows[i].Cells["clmRack"].Style.BackColor = Color.LightPink;
                                varErrorFlag = false;
                            }
                            if (chkCompleted.Checked == true)
                            {
                                if (Convert.ToString(grdInward.Rows[i].Cells["clmConvertType"].Value) == "1")
                                {
                                    if (varGRNPurchaseFlag == 3 && varGRNPurchaseFlag == 187)   //From dc- Queue
                                    {
                                        int varIDvalue = Convert.ToInt32(grdInward.Rows[i].Cells["clmDuplicateSno"].Value);
                                        varQty1 = Convert.ToDecimal(grdInward.Rows[i].Cells["clmQty"].Value);

                                        var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                        var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                        varQty1 = Convert.ToDecimal(grdInward.Rows[i].Cells["clmQty"].Value);
                                        if (varQty1 != 0)
                                        {
                                            varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);
                                            //if (varQty1 > varTotalQty1 || varQty1 == varTotalQty1)
                                            //{

                                            //}
                                            //else
                                            if(varTotalQty1!= varQty1)
                                            {
                                                varQuantityErr++;
                                                grdInward.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                                if (Convert.ToString(grdInward.Rows[i].Cells["clmShopQty"].Value) != "")
                                                {
                                                    grdInward.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.Pink;
                                                }
                                                varErrorFlag = false;
                                            }
                                        }
                                    }
                                }
                                if (Convert.ToString(grdInward.Rows[i].Cells["clmConvertType"].Value) == "1")
                                {
                                    if (varGRNPurchaseFlag == 2 && varGRNPurchaseFlag == 175)   //From Purchase- Queue
                                    {
                                        int varIDvalue = Convert.ToInt32(grdInward.Rows[i].Cells["clmEntrytypeProID"].Value);

                                        var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                        var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                        varQty1 = Convert.ToDecimal(grdInward.Rows[i].Cells["clmQty"].Value);
                                        if (varQty1 != 0)
                                        {
                                            varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);

                                            if (varQty1 != varTotalQty1)
                                            {
                                                varQuantityErr++;
                                                grdInward.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                            }
                                        }
                                    }
                                }
                                if (Convert.ToString(grdInward.Rows[i].Cells["clmConvertType"].Value) == "1")
                                {
                                    if ( varGRNPurchaseFlag == 174)   //From Purchase- Queue
                                    {
                                        int varIDvalue = Convert.ToInt32(grdInward.Rows[i].Cells["clmEntrytypeProID"].Value);

                                        var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                        var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                        varQty1 = Convert.ToDecimal(grdInward.Rows[i].Cells["clmFinalQty"].Value);
                                        if (varQty1 != 0)
                                        {
                                            varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);

                                            if (varQty1 != varTotalQty1)
                                            {
                                                varQuantityErr++;
                                                grdInward.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                            }
                                        }
                                    }
                                }
                            }
                            if (chkCompleted.Checked==true)
                            {
                                if (Convert.ToInt32(grdInward.Rows[i].Cells["clmStatus"].Value) == 81)
                                {
                                    varStsErr++;
                                }
                            }
                        }
                    }
                    /*
                    for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                    {
                        decimal varShopQty = 0,varReceivedQty=0,varRackID=0,varRackCount=0;
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value)=="")
                        { varShopQty = 0; }
                        else { varShopQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmShopQty"].Value); }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value) == "")
                        { varReceivedQty = 0; }
                        else { varReceivedQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value); }

                        if (varEditFlag == 0)
                        {
                            int varSnovalue = 0,varPRIDs =0, varOrderID=0, varBatchNo=0, varShelflifeStatus=0, varMRPFlag=0;
                            if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConvertType"].Value) == "1")
                            {
                                if (Convert.ToBoolean(grdGrnlist.Rows[i].Cells["clmCheck"].Value) == true)
                                {
                                    varSnovalue = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmSno"].Value);
                                    varPRIDs = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmPRID"].Value);
                                    varOrderID = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmOrder"].Value);
                                    varBatchNo = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmBatchNoStatus"].Value);
                                    varShelflifeStatus = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmShelflifeStatus"].Value);
                                    varMRPFlag = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmMRPFlag"].Value);
                                }
                            }
                            if (varSnovalue != 0)
                            {
                                var varDuplicateProduct = from r in dtInwardPurchase.AsEnumerable()
                                                          where ((r.Field<bool>("Column1").Equals(true) &&
                                                                 r.Field<int>("GIPPR_SNO").Equals(varSnovalue)) &&
                                                                 (r.Field<decimal>("GIPPR_MRP").Equals("0") &&
                                                                 r.Field<int>("PR_MRPStatus").Equals(1) || //////MRP
                                                                 //r.Field<decimal>("GIPPR_MRP").Equals("0") &&
                                                                //r.Field<int>("PR_MRPStatus").Equals(0) &&//||
                                                                 r.Field<string>("GIPPR_ExpiryDate").Equals("") &&
                                                                 r.Field<int>("PR_ExpiryStatus").Equals(1) || //////Expiry
                                                                 //r.Field<string>("GIPPR_ExpiryDate").Equals("") &&
                                                                 //r.Field<int>("PR_ExpiryStatus").Equals(0) &&//||
                                                                 r.Field<string>("GIPPR_BatchNo").Equals("") &&
                                                                 r.Field<int>("PR_BatchNoGeneration").Equals(75))) //&&//||
                                                                 //r.Field<string>("GIPPR_BatchNo").Equals("") &&
                                                                 //r.Field<int>("PR_BatchNoGeneration").Equals(74))
                                                          group r by r.Field<int>("GIPPR_OrderID")
                                                         into g
                                                          select g.Key;
                                //var varRowsToUpdate = dtInwardPurchase.AsEnumerable().Where(r => r.Field<int>("GIPPR_OrderID") == Convert.ToInt16(varOrderID));
                                int varcount = varDuplicateProduct.Count();
                                if (varDuplicateProduct.Count() == 0)
                                {
                                    grdGrnlist.Rows[i].Cells["clmError"].Value = 0;
                                    grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                    grdGrnlist.Rows[i].Cells["clmMRP"].Style.BackColor= Color.White;
                                    grdGrnlist.Rows[i].Cells["clmExpiryDate"].Style.BackColor= Color.White;
                                    if(Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchNoGeneration"].Value)=="75")
                                    {
                                        grdGrnlist.Rows[i].Cells["clmBatchNo"].Style.BackColor = Color.White;
                                    }
                                    grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor= Color.PaleGreen;
                                    grdGrnlist.Rows[i].Cells["clmRack"].Style.BackColor = Color.PaleGreen;
                                }
                                else
                                {
                                    varInvalidQty = 2;
                                    grdGrnlist.Rows[i].Cells["clmError"].Value = 1;
                                    grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                    grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                    grdGrnlist.Rows[i].Cells["clmMRP"].Style.BackColor = Color.LightPink;
                                    grdGrnlist.Rows[i].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchNoGeneration"].Value) == "75")
                                    {
                                        grdGrnlist.Rows[i].Cells["clmBatchNo"].Style.BackColor = Color.LightPink;
                                    }
                                    else
                                    {
                                        grdGrnlist.Rows[i].Cells["clmBatchNo"].Style.BackColor = Color.White;
                                    }
                                }
                            }
                        }

                        if (varEditFlag == 0)
                        {
                            
                            if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConvertType"].Value) == "1")
                            {
                                if (Convert.ToBoolean(grdGrnlist.Rows[i].Cells["clmCheck"].Value) == true)
                                {
                                    varProCount = 1;
                                    if (varGRNPurchaseFlag != 1)
                                    {
                                        int varIDvalue = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmSno"].Value);
                                        varQty1 = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);

                                        //var varDuplicateProuct = from r in dtInwardPurchase.AsEnumerable()
                                        //                         where (r.Field<int>("GIPPR_PRID").Equals(PRID) &&
                                        //                                r.Field<decimal>("GIPPR_MRP").Equals(varMRP) &&
                                        //                                r.Field<string>("GIPPR_ExpiryDate").Equals(ExpiryDate) &&
                                        //                                r.Field<string>("GIPPR_BatchNo").Equals(BatchNo) &&
                                        //                                r.Field<int>("GIPPR_RKID").Equals(RackID) &&
                                        //                                r.Field<int>("GIPPR_OrderID") != Convert.ToInt16(grdGrnlist.Rows[e.RowIndex].Cells["clmOrder"].Value)
                                        //                                 )
                                        //                         group r by r.Field<int>("GIPPR_OrderID")
                                        //                         into g
                                        //                         select g.Key;




                                        var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                        var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                        varQty1 = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);
                                        if (varQty1 != 0)
                                        {
                                            varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);
                                            if (varQty1 > varTotalQty1 || varQty1 == varTotalQty1)
                                            {

                                            }
                                            else
                                            {
                                                varInvalidQty = 1;
                                                grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.Pink;
                                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                                {
                                                    grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.Pink;
                                                }
                                                varErrorFlag = false;
                                            }
                                        }
                                    }
                                    
                                    //if (varGRNPurchaseFlag == 3)
                                    //{
                                    //    varQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);
                                    //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value) != "")
                                    //    {
                                    //        varReceivedQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value);
                                    //    }
                                    //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                    //    {
                                    //        varShopQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmShopQty"].Value);
                                    //    }
                                    //    varTotalQty = varReceivedQty + varShopQty;
                                    //}
                                    //if (varGRNPurchaseFlag == 2)
                                    //{
                                    //    varQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);
                                    //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value) != "")
                                    //    {
                                    //        varReceivedQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value);
                                    //    }
                                    //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                    //    {
                                    //        varShopQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmShopQty"].Value);
                                    //    }
                                    //    varTotalQty = varReceivedQty + varShopQty;
                                    //}
                                    
                                    //if (varQty > varTotalQty || varQty == varTotalQty)
                                    //{
                                    //    dtInwardPurchase.Rows.Add(Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmPRID"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmUTID"].Value),
                                    //        Convert.ToInt32(varReceivedQty), varShopQty, Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmRKID"].Value),
                                    //        Convert.ToString(grdGrnlist.Rows[i].Cells["clmExpiryDate"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchNo"].Value),
                                    //        Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmMRP"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["clmID"].Value));
                                    //    grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.PaleGreen;
                                    //    grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.PaleGreen;
                                    //}
                                    //else
                                    //{
                                    //    InvalidQty = 1;
                                    //    grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.Pink;
                                    //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                    //    {
                                    //        grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.Pink;
                                    //    }
                                    //    varErrorFlag = false;
                                    //}
                                }
                            }
                            
                        }


                        if(varEditFlag==1)
                        {
                            //if (Convert.ToBoolean(grdGrnlist.Rows[i].Cells[0].Value) == true)
                            //{
                                varProCount = 1;
                                //dtInwardPurchase.Rows.Add(Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmPRID"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmUTID"].Value),
                                //Convert.ToInt32(varReceivedQty), varShopQty, Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmRKID"].Value),
                                //Convert.ToString(grdGrnlist.Rows[i].Cells["clmExpiryDate"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchNo"].Value),
                                //Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmMRP"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["clmID"].Value));
                            //}
                        }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConvertType"].Value) == "1")
                        {
                            if (Convert.ToBoolean(grdGrnlist.Rows[i].Cells[0].Value) == true)
                            {
                                if (Convert.ToInt32(varReceivedQty) <= 0)
                                {
                                    grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                    //grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.LightPink;
                                    varInvalidQty = 1;
                                    varErrorFlag = false;
                                }
                                else
                                {
                                    if (varInvalidQty != 1 && varInvalidQty != 2)
                                    {
                                        grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.PaleGreen;
                                        //grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                    }
                                }
                            }
                        }
                        varRackID = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmRKID"].Value);
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmRack"].Value) == "")
                        {
                            varRackID = 0;
                        }
                        else
                        {
                            varRackID = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmRKID"].Value);
                        }
                        varRackCount = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmRackCount"].Value);
                        if (varRackCount != 0)
                        {
                            //if (Convert.ToString(grdGrnlist.Rows[i].Cells["Rack"].Value) == "")
                            //{
                            //    grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.LightPink;
                            //    varErrorFlag = false;
                            //}
                            //else
                            //{
                            //    grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.PaleGreen;
                            //}
                        }
                        if (varRackID == -1)
                        {
                            grdGrnlist.Columns["clmRack"].DefaultCellStyle.BackColor = Color.LightPink;
                            varErrorFlag = false;
                        }
                        //int varEntryType = 0;
                        //varEntryType = Convert.ToInt32(cmbTransactionType.SelectedIndex);
                        //if (varEntryType == 187) // direct and GRN
                        //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["DC Quantity"].Value) != "" || Convert.ToString(grdGrnlist.Rows[i].Cells["clmRecqty"].Value) != "")
                        //    {
                        //        decimal varQty = 0, varFreeQuantity = 0, varRecqty = 0, varDiffQty = 0, varInvqty = 0;
                        //        varRecqty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmRecqty"].Value);
                        //        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmFreeqty"].Value) != "")
                        //        { varFreeQuantity = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmFreeqty"].Value); }
                        //        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmDiffqty"].Value) != "")
                        //        { varDiffQty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmDiffqty"].Value); }
                        //        if (Convert.ToString(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value) != "")
                        //        { varInvqty = Convert.ToDecimal(grdPurchaseList.Rows[i].Cells["clmInvQty"].Value); }

                        //        if (varDiffQty != Math.Abs(varInvqty - (varRecqty + varFreeQuantity))) //low
                        //        {
                        //            varQuantityErr++;
                        //            grdPurchaseList.Rows[i].Cells["clmInvQty"].Style.BackColor = Color.LightPink;
                        //            grdPurchaseList.Rows[i].Cells["clmRecqty"].Style.BackColor = Color.LightPink;
                        //            grdPurchaseList.Rows[i].Cells["clmFreeqty"].Style.BackColor = Color.LightPink;
                        //        }
                        //}

                        if (chkCompleted.Checked == true)
                        {
                            if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConvertType"].Value) == "1")
                            {
                                if (varGRNPurchaseFlag == 3 && Convert.ToBoolean(grdGrnlist.Rows[i].Cells["clmCheck"].Value) == true)   //From dc- Queue
                                {
                                    int varIDvalue = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmSno"].Value);
                                    varQty1 = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);

                                    //var varDuplicateProuct = from r in dtInwardPurchase.AsEnumerable()
                                    //                         where (r.Field<int>("GIPPR_PRID").Equals(PRID) &&
                                    //                                r.Field<decimal>("GIPPR_MRP").Equals(varMRP) &&
                                    //                                r.Field<string>("GIPPR_ExpiryDate").Equals(ExpiryDate) &&
                                    //                                r.Field<string>("GIPPR_BatchNo").Equals(BatchNo) &&
                                    //                                r.Field<int>("GIPPR_RKID").Equals(RackID) &&
                                    //                                r.Field<int>("GIPPR_OrderID") != Convert.ToInt16(grdGrnlist.Rows[e.RowIndex].Cells["clmOrder"].Value)
                                    //                                 )
                                    //                         group r by r.Field<int>("GIPPR_OrderID")
                                    //                         into g
                                    //                         select g.Key;




                                    var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                            .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                             .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                    var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                            .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                             .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                    varQty1 = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);
                                    if (varQty1 != 0)
                                    {
                                        varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);
                                        if (varQty1 > varTotalQty1 || varQty1 == varTotalQty1)
                                        {

                                        }
                                        else
                                        {
                                            varInvalidQty = 1;
                                            grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.Pink;
                                            if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                            {
                                                grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.Pink;
                                            }
                                            varErrorFlag = false;
                                        }
                                    }
                                    //if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmQty"].Value) != "")
                                    //{ varDCQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value); }
                                    //if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value) != "")
                                    //{ varRecqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value); }
                                    //if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                    //{ varShopqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmShopQty"].Value); }
                                    //if (varDCQty != varRecqty + varShopqty)
                                    //{
                                    //    varQuantityErr++;
                                    //    grdGrnlist.Rows[i].Cells["clmQty"].Style.BackColor = Color.LightPink;
                                    //    grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                    //    grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                    //}
                                }
                            }
                            //if (varGRNPurchaseFlag == 1 && Convert.ToBoolean(grdGrnlist.Rows[i].Cells["clmCheck"].Value) == true)   //From GRN- Queue
                            //{
                            //    decimal varPendingQty = 0, varRecqty = 0, varShopqty = 0;

                            //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["Pending Qty"].Value) != "")
                            //    { varPendingQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Pending Qty"].Value); }
                            //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["Received Qty"].Value) != "")
                            //    { varRecqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Received Qty"].Value); }
                            //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["Shop Qty"].Value) != "")
                            //    { varShopqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Shop Qty"].Value); }
                            //    if (varPendingQty != varRecqty + varShopqty)
                            //    {
                            //        varQuantityErr++;
                            //        grdGrnlist.Rows[i].Cells["Pending Qty"].Style.BackColor = Color.LightPink;
                            //        grdGrnlist.Rows[i].Cells["Received Qty"].Style.BackColor = Color.LightPink;
                            //        grdGrnlist.Rows[i].Cells["Shop Qty"].Style.BackColor = Color.LightPink;
                            //    }
                            //}
                            if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConvertType"].Value) == "1")
                            {
                                if (varGRNPurchaseFlag == 2 && Convert.ToBoolean(grdGrnlist.Rows[i].Cells["clmCheck"].Value) == true)   //From Purchase- Queue
                                {
                                    int varIDvalue = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmSno"].Value);

                                    var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                            .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                             .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                    var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                            .Where(y => y.Field<int>("GIPPR_SNO").Equals(varIDvalue))
                                                             .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                    varQty1 = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);
                                    if (varQty1 != 0)
                                    {
                                        varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);

                                        if (varQty1 != Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty))
                                        {
                                            varQuantityErr++;
                                            grdGrnlist.Rows[i].Cells["clmQty"].Style.BackColor = Color.LightPink;
                                            grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                            grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                        }
                                    }
                                }
                            }
                            if(varEditFlag==1)
                            {
                                if (varGRNPurchaseFlag != 174)
                                {
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConvertType"].Value) == "1")
                                    {
                                        int varIDvalue = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmPRID"].Value);

                                        var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_PRID").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();
                                        var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                                .Where(y => y.Field<int>("GIPPR_PRID").Equals(varIDvalue))
                                                                 .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                        varQty1 = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);
                                        if (varQty1 != 0)
                                        {
                                            varTotalQty1 = Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty);

                                            if (varQty1 != Convert.ToDecimal(varSumRequestQty) + Convert.ToDecimal(varSumShopQty))
                                            {
                                                varQuantityErr++;
                                                grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                                grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                            }
                                            //if (varQty1 > varTotalQty1 || varQty1 == varTotalQty1)
                                            //{

                                            //}
                                            //else
                                            //{
                                            //    InvalidQty = 1;
                                            //    grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.Pink;
                                            //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                            //    {
                                            //        grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.Pink;
                                            //    }
                                            //    varErrorFlag = false;
                                            //}
                                        }
                                    }


                                    //decimal varqty = 0, varRecqty = 0, varShopqty = 0;
                                    //if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmQty"].Value) != "")
                                    //{ varqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value); }
                                    //if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value) != "")
                                    //{ varRecqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value); }
                                    //if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                    //{ varShopqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmShopQty"].Value); }

                                    //if (varqty != varRecqty + varShopqty)
                                    //{
                                    //    varQuantityErr++;
                                    //    grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                                    //    grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                                    //}
                                }
                            }

                            //if (varGRNPurchaseFlag == 2 && Convert.ToBoolean(grdGrnlist.Rows[i].Cells["clmCheck"].Value) == true)   //From Purchase- Queue
                            //{
                            //    decimal varInvoiceQty = 0, varRecqty = 0, varShopqty = 0;

                            //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["Invoice Qty"].Value) != "")
                            //    { varInvoiceQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Invoice Qty"].Value); }
                            //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["Received Qty"].Value) != "")
                            //    { varRecqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Received Qty"].Value); }
                            //    if (Convert.ToString(grdGrnlist.Rows[i].Cells["Shop Qty"].Value) != "")
                            //    { varShopqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Shop Qty"].Value); }
                            //    if (varInvoiceQty != varRecqty + varShopqty)
                            //    {
                            //        varQuantityErr++;
                            //        grdGrnlist.Rows[i].Cells["Invoice Qty"].Style.BackColor = Color.LightPink;
                            //        grdGrnlist.Rows[i].Cells["Received Qty"].Style.BackColor = Color.LightPink;
                            //        grdGrnlist.Rows[i].Cells["Shop Qty"].Style.BackColor = Color.LightPink;
                            //    }
                            //}
                        }

                        if (varEditFlag == 0)
                        {
                            string varvalue = "";
                            if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConvertType"].Value) == "1")
                            {
                                if (Convert.ToBoolean(grdGrnlist.Rows[i].Cells["clmCheck"].Value) == true)
                                {
                                    varvalue = Convert.ToString(grdGrnlist.Rows[i].Cells["clmSno"].Value);
                                }
                            }

                        }
                    }
                    */
                    if (varProCount == 0)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(80);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrorFlag = false;
                    }
                    if(varInvalidQty == 1)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrorFlag = false;
                    }
                    if (varQuantityErr != 0)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(113);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrorFlag = false;
                    }
                    if(varStsErr!=0)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(144);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrorFlag = false;
                    }
                    if (varErrorFlag == true && varQuantityErr==0)
                    {
                        if (varEditFlag == 0)
                        {
                            dtChkProducts = dtInwardPurchase.Clone();
                            for (int i = 0; i < dtInwardPurchase.Rows.Count; i++)
                            {
                                if (Convert.ToBoolean(dtInwardPurchase.Rows[i]["Column1"]) == true)
                                {
                                    DataRow drNew = dtChkProducts.NewRow();
                                    drNew.ItemArray = dtInwardPurchase.Rows[i].ItemArray;
                                    dtChkProducts.Rows.Add(drNew);
                                }
                            }
                            dtChkProducts.Columns.Remove("Column1");
                            dtChkProducts.Columns.Remove("PR_MRPStatus");
                            dtChkProducts.Columns.Remove("PR_ExpiryStatus");
                            dtChkProducts.Columns.Remove("PR_BatchNoStatus");
                            dtChkProducts.Columns.Remove("PR_BatchNoGeneration");
                        }
                        else
                        {
                            if (varError == 0)
                            {
                                if (Convert.ToInt32(dtInwardPurchase.Columns.Count) == 27) //default  Data table count
                                {
                                    dtInwardPurchase.Columns.Remove("Column1");
                                    dtInwardPurchase.Columns.Remove("PR_MRPStatus");
                                    dtInwardPurchase.Columns.Remove("PR_ExpiryStatus");
                                    dtInwardPurchase.Columns.Remove("PR_BatchNoStatus");
                                    dtInwardPurchase.Columns.Remove("PR_BatchNoGeneration");
                                }
                            }
                        }

                        int varStatusID = 0;
                        if (grdInward.Rows.Count > 0)
                        {
                            if (varSupplierId != 0 && varLocationId != 0)
                            {
                                string result = "", varorginator = "Inward from GRN", result1 = "";
                                int varviewtype = 0, varTypeID = 0;
                                if (varEditFlag == 0)
                                {
                                    varviewtype = 0;
                                    if (varGRNPurchaseFlag == 1)
                                    { varTypeID = 174; }
                                    else if (varGRNPurchaseFlag == 2)
                                    { varTypeID = 175; }
                                    else { varTypeID = 187; }
                                }
                                else if (varEditFlag == 1)
                                { varviewtype = 1; }
                                if (chkCompleted.Checked == true)
                                { varStatusID = 46; }
                                else { varStatusID = 45; }

                                TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                                objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                                objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                                objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                                objTRN_GoodsInward_Purchase.paraOriginator = varorginator;
                                objTRN_GoodsInward_Purchase.paraHostName = MainForm.pbHostName;
                                objTRN_GoodsInward_Purchase.paraGIP_Date = Convert.ToString(dpInwardDate.Text);
                                objTRN_GoodsInward_Purchase.paraGIP_NO = Convert.ToString(txtInwardNo.Text);
                                objTRN_GoodsInward_Purchase.paraCompanyId = Convert.ToInt32(varConcernId);
                                objTRN_GoodsInward_Purchase.paraFlag = varGRNPurchaseFlag;
                                objTRN_GoodsInward_Purchase.paraStatusID = varStatusID;
                                if (varGRNPurchaseFlag == 1)
                                {
                                    objTRN_GoodsInward_Purchase.paraGRNID = Convert.ToInt32(varID);
                                }
                                if (varGRNPurchaseFlag == 2)
                                {
                                    objTRN_GoodsInward_Purchase.paraPurchaseID = Convert.ToInt32(varID);
                                }
                                if (varGRNPurchaseFlag == 3)
                                {
                                    objTRN_GoodsInward_Purchase.paraPurchaseDCID = Convert.ToInt32(varID);
                                }
                                objTRN_GoodsInward_Purchase.paraInwardId = varInwardId;
                                objTRN_GoodsInward_Purchase.paraStatusID = Convert.ToInt32(varStatusID);
                                objTRN_GoodsInward_Purchase.paraRemarks = Convert.ToString(txtRemark.Text.Trim());
                                objTRN_GoodsInward_Purchase.paraLocationID = Convert.ToInt32(varLocationId);
                                objTRN_GoodsInward_Purchase.ParaSupplierId = Convert.ToInt32(varSupplierId);
                                objTRN_GoodsInward_Purchase.ParaScheduleId = Convert.ToInt32(varScheduleId);
                                objTRN_GoodsInward_Purchase.paraTypeID = Convert.ToInt32(varTypeID);
                                objTRN_GoodsInward_Purchase.paraEditFlag = 0;
                                objTRN_GoodsInward_Purchase.paraGIP_TransDate = varGIPTransDate;
                                if (varEditFlag == 0)
                                {
                                    objTRN_GoodsInward_Purchase.paraTRN_GoodsInward_Purchase_Products = dtChkProducts;
                                }
                                else
                                {
                                    objTRN_GoodsInward_Purchase.paraTRN_GoodsInward_Purchase_Products = dtInwardPurchase;
                                }
                                SPDataService objspdservice = new SPDataService();
                                result = objspdservice.udfnGoodsInwardPurchase(objTRN_GoodsInward_Purchase);
                                objspdservice.CloseConnection();
                                string[] varvalue1 = result.Split('~');
                                if (varvalue1[1] == "1")
                                {
                                    grdInward.ClearSelection();
                                    objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                                    objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                                    objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                                    objTRN_GoodsInward_Purchase.paraOriginator = varorginator;
                                    objTRN_GoodsInward_Purchase.paraHostName = MainForm.pbHostName;
                                    objTRN_GoodsInward_Purchase.paraGIP_Date = Convert.ToString(dpInwardDate.Text);
                                    objTRN_GoodsInward_Purchase.paraGIP_NO = Convert.ToString(txtInwardNo.Text);
                                    objTRN_GoodsInward_Purchase.paraCompanyId = Convert.ToInt32(varConcernId);
                                    objTRN_GoodsInward_Purchase.paraFlag = varGRNPurchaseFlag;
                                    objTRN_GoodsInward_Purchase.paraStatusID = varStatusID;
                                    if (varGRNPurchaseFlag == 1)
                                    {
                                        objTRN_GoodsInward_Purchase.paraGRNID = Convert.ToInt32(varID);
                                    }
                                    if (varGRNPurchaseFlag == 2)
                                    {
                                        objTRN_GoodsInward_Purchase.paraPurchaseID = Convert.ToInt32(varID);
                                    }
                                    if (varGRNPurchaseFlag == 3)
                                    {
                                        objTRN_GoodsInward_Purchase.paraPurchaseDCID = Convert.ToInt32(varID);
                                    }
                                    objTRN_GoodsInward_Purchase.paraInwardId = varInwardId;
                                    objTRN_GoodsInward_Purchase.paraStatusID = Convert.ToInt32(varStatusID);
                                    objTRN_GoodsInward_Purchase.paraRemarks = Convert.ToString(txtRemark.Text.Trim());
                                    objTRN_GoodsInward_Purchase.paraLocationID = Convert.ToInt32(varLocationId);
                                    objTRN_GoodsInward_Purchase.ParaSupplierId = Convert.ToInt32(varSupplierId);
                                    objTRN_GoodsInward_Purchase.ParaScheduleId = Convert.ToInt32(varScheduleId);
                                    objTRN_GoodsInward_Purchase.paraTypeID = Convert.ToInt32(varTypeID);
                                    objTRN_GoodsInward_Purchase.paraEditFlag = 1;
                                    objTRN_GoodsInward_Purchase.paraGIP_TransDate = varGIPTransDate;
                                    if (varEditFlag == 0)
                                    {
                                        objTRN_GoodsInward_Purchase.paraTRN_GoodsInward_Purchase_Products = dtChkProducts;
                                    }
                                    else
                                    {
                                        objTRN_GoodsInward_Purchase.paraTRN_GoodsInward_Purchase_Products = dtInwardPurchase;
                                    }
                                    result1 = objspdservice.udfnGoodsInwardPurchase(objTRN_GoodsInward_Purchase);
                                    objspdservice.CloseConnection();
                                    string[] varvalue = result1.Split('~');
                                    if (varvalue[0] == "3")
                                    {
                                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        varCloseFlag = 1;
                                        udfnclose();
                                        if (varEditFlag == 0)
                                        {
                                            MainForm.objINV_InwardQueueList.udfnDate();
                                            MainForm.objINV_InwardQueueList.udfnList();
                                        }
                                        else
                                        {
                                            MainForm.objINV_InwardPurchaseList.udfnList();
                                        }
                                    }
                                    else if (varvalue[0] == "4")
                                    {
                                        MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else if (varvalue[0] == "5")
                                    {
                                        MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        string varProductID = "", varMRP = "", varExpirydate = "", varBatchNo = "", varRKID = "";
                                        for (int j = 0; j < grdInward.RowCount; j++)
                                        {
                                            //grdGrnlist.Rows[j].DefaultCellStyle.BackColor = Color.White;

                                            string[] varFirstList = varvalue[2].Split('|');
                                            for (int i = 0; i < varFirstList.Length; i++)
                                            {
                                                string[] varSecondList = varFirstList[i].Split(',');
                                                varProductID = varSecondList[0];
                                                varMRP = varSecondList[1];
                                                varRKID = varSecondList[2];
                                                varBatchNo = varSecondList[3];
                                                varExpirydate = varSecondList[4];
                                                if (Convert.ToString(grdInward.Rows[j].Cells["clmPRID"].Value) == varProductID && Convert.ToString(grdInward.Rows[j].Cells["clmMRP"].Value) == varMRP && Convert.ToString(grdInward.Rows[j].Cells["clmExpiryDate"].Value) == varExpirydate && Convert.ToString(grdInward.Rows[j].Cells["clmBatchNo"].Value) == varBatchNo && Convert.ToString(grdInward.Rows[j].Cells["clmRKID"].Value) == varRKID)
                                                {
                                                    grdInward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                                }
                                            }
                                        }
                                        varError = 1;
                                    }
                                }
                                else
                                {
                                    grdInward.ClearSelection();
                                    if (varvalue1[0] == "5")
                                    {
                                        //string result3 = varvalue1[1];
                                        //string[] message = result3.Split('@');
                                        MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        string varProductID = "", Expirydate = "";
                                        for (int j = 0; j < grdInward.RowCount; j++)
                                        {
                                            string[] varFirstList = varvalue1[2].Split('|');
                                            for (int i = 0; i < varFirstList.Length; i++)
                                            {
                                                string[] varSecondList = varFirstList[i].Split(',');
                                                varProductID = varSecondList[0];
                                                Expirydate = varSecondList[1];

                                                string varTempYear = "0";
                                                object cellValue = Convert.ToString(grdInward.Rows[j].Cells["clmExpiryDate"].Value);
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
                                                }
                                                varTempExpiryDate = cellValue.ToString();
                                                if (Convert.ToString(grdInward.Rows[j].Cells["clmPRID"].Value) == varProductID && varTempExpiryDate == Expirydate)
                                                {
                                                    grdInward.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                                }
                                                
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(100);
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

        private void INV_InwardPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    udfnSave();
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
                if (chkCompleted.Checked == true)
                { btnSave.Text = "Save"; }
                else { btnSave.Text = "Save as Draft"; }
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
                if (grdInward.CurrentCell.OwningColumn.Name == "clmRack")
                {
                    TextBox txtPurRack = e.Control as TextBox;
                    if (txtPurRack != null)
                    {
                        txtPurRack.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtPurRack.AutoCompleteCustomSource = AutoCompleteRackName(varLocationId); 
                        txtPurRack.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                if (grdInward.CurrentCell.OwningColumn.Name == "clmMRP" || grdInward.CurrentCell.OwningColumn.Name == "clmShopQty" || grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty" || grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate" || grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceExpiryDate")
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
        private void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdInward.CurrentCell.OwningColumn.Name == "clmMRP" || grdInward.CurrentCell.OwningColumn.Name == "clmShopQty" || grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty")
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
                if (grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate" || grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceExpiryDate")
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
        private void GrdGrnlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string varTempExpiryDate = "";int varError = 0;
                if (grdInward.Rows.Count > 0)
                {
                    DataGridView dataGridView1 = grdInward;
                    DataGridViewCell cellMRP = dataGridView1.Rows[e.RowIndex].Cells["clmMRP"];
                    DataGridView dataGridView7 = grdInward;
                    DataGridViewCell cellInvoiceMRP = dataGridView1.Rows[e.RowIndex].Cells["clmInvoiceMRP"];
                    DataGridView dataGridView2 = grdInward;
                    DataGridViewCell cellExpiryDate = dataGridView2.Rows[e.RowIndex].Cells["clmExpiryDate"];
                    DataGridView dataGridView8 = grdInward;
                    DataGridViewCell cellInvoiceExpiryDate = dataGridView2.Rows[e.RowIndex].Cells["clmInvoiceExpiryDate"];
                    DataGridView dataGridView3 = grdInward;
                    DataGridViewCell cellBatchNo = dataGridView3.Rows[e.RowIndex].Cells["clmBatchNo"];
                    DataGridView dataGridView9 = grdInward;
                    DataGridViewCell cellInvoiceBatchNo = dataGridView3.Rows[e.RowIndex].Cells["clmInvoiceBatchNo"];
                    DataGridView dataGridView4 = grdInward;
                    DataGridViewCell cellReceivedQty = dataGridView4.Rows[e.RowIndex].Cells["clmReceivedQty"];
                    DataGridView dataGridView5 = grdInward;
                    DataGridViewCell cellShopQty = dataGridView5.Rows[e.RowIndex].Cells["clmShopQty"];
                    DataGridView dataGridView6 = grdInward;
                    DataGridViewCell cellRack = dataGridView6.Rows[e.RowIndex].Cells["clmRack"];

                    decimal varMRP = 0,varInvoiceMrp=0; 
                    if (Convert.ToString(grdInward.CurrentRow.Cells["clmMRP"].Value) != "")
                    {
                        decimal varMRP1 = Math.Round(Convert.ToDecimal(grdInward.CurrentRow.Cells["clmMRP"].Value), 2, MidpointRounding.AwayFromZero);
                        string mrp = string.Format("{0:0.00}", varMRP1);
                        string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                        varMRP = Convert.ToDecimal(mrp);
                        grdInward.Rows[e.RowIndex].Cells["clmMRP"].Value = mrp;
                    }
                    if (Convert.ToString(grdInward.CurrentRow.Cells["clmInvoiceMRP"].Value) != "")
                    {
                        decimal varMRP1 = Math.Round(Convert.ToDecimal(grdInward.CurrentRow.Cells["clmInvoiceMRP"].Value), 2, MidpointRounding.AwayFromZero);
                        string mrp = string.Format("{0:0.00}", varMRP1);
                        string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                        varInvoiceMrp = Convert.ToDecimal(mrp);
                        grdInward.Rows[e.RowIndex].Cells["clmInvoiceMRP"].Value = mrp;
                    }
                    string varExpiryDate = Convert.ToString(grdInward.CurrentRow.Cells["clmExpiryDate"].Value);
                    string varInvoiceExpiryDate = Convert.ToString(grdInward.CurrentRow.Cells["clmInvoiceExpiryDate"].Value);
                    string varBatchNo = Convert.ToString(grdInward.CurrentRow.Cells["clmBatchNo"].Value);
                    string varInvoiceBatchNo = Convert.ToString(grdInward.CurrentRow.Cells["clmInvoiceBatchNo"].Value);
                    int varRackID = Convert.ToInt32(grdInward.CurrentRow.Cells["clmRKID"].Value);
                    int varOrderID = Convert.ToInt32(grdInward.Rows[e.RowIndex].Cells["clmOrder"].Value);
                    int varPRID = Convert.ToInt32(grdInward.Rows[e.RowIndex].Cells["clmPRID"].Value);
                    decimal varShelflifePer = Convert.ToDecimal(grdInward.Rows[e.RowIndex].Cells["clmShelflifePer"].Value);
                    decimal ReceivedQty = 0, ShopQty = 0;
                    //decimal actual = Convert.ToInt32(grdInward.Rows[e.RowIndex].Cells["clmActuallife"].Value);


                    if (Convert.ToString(grdInward.CurrentRow.Cells["clmReceivedQty"].Value)!="")
                    {
                        ReceivedQty = Convert.ToDecimal(grdInward.CurrentRow.Cells["clmReceivedQty"].Value);
                    }
                    if (Convert.ToString(grdInward.CurrentRow.Cells["clmShopQty"].Value) != "")
                    {
                        ShopQty = Convert.ToDecimal(grdInward.CurrentRow.Cells["clmShopQty"].Value);
                    }
                    if (e.ColumnIndex == grdInward.Columns["clmReceivedQty"].Index && e.RowIndex >= 0)
                    {
                        int varDecimal = Convert.ToInt32(grdInward.CurrentRow.Cells["clmUTDecimal"].Value);
                        string Qty = objValidation.udfnDecimal(Convert.ToString(grdInward.CurrentRow.Cells["clmReceivedQty"].Value), varDecimal);
                        grdInward.Rows[e.RowIndex].Cells["clmReceivedQty"].Value = Qty;
                       // grdInward.Rows[e.RowIndex].Cells["clmError"].Value = 1;
                    }
                    if (e.ColumnIndex == grdInward.Columns["clmShopQty"].Index && e.RowIndex >= 0)
                    {
                        int varDecimal = Convert.ToInt32(grdInward.CurrentRow.Cells["clmUTDecimal"].Value);
                        string Qty = objValidation.udfnDecimal(Convert.ToString(grdInward.CurrentRow.Cells["clmShopQty"].Value), varDecimal);
                        grdInward.Rows[e.RowIndex].Cells["clmShopQty"].Value = Qty;
                        //grdInward.Rows[e.RowIndex].Cells["clmError"].Value = 1;
                    }

                    if (grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate")
                    {
                        int rowIndex = e.RowIndex, columnIndex = e.ColumnIndex, PR_Shelflife = 0, Date = 0;

                        if (grdInward.Rows.Count > 0)
                        {
                            PR_Shelflife = Convert.ToInt32(grdInward.Rows[rowIndex].Cells["clmShelflifeStatus"].Value);
                        }
                        if (PR_Shelflife == 1)
                        {
                            varTempExpiryDate = Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value);
                            if (grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value != null && Convert.ToString(grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Value) != "0")
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
                                            MessageBox.Show("Invalid date!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                            varError = 1;
                                        }
                                        else
                                        {
                                            if (pbDateflag == 0)
                                            {
                                                grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.PaleGreen;
                                                varError = 0;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter expirydate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                grdInward.Rows[rowIndex].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                varError = 1;
                            }
                        }
                    }
                    if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceExpiryDate")
                    {
                        int rowIndex = e.RowIndex, columnIndex = e.ColumnIndex, PR_Shelflife = 0, Date = 0;

                        if (grdInward.Rows.Count > 0)
                        {
                            PR_Shelflife = Convert.ToInt32(grdInward.Rows[rowIndex].Cells["clmShelflifeStatus"].Value);
                        }
                        if (PR_Shelflife == 1)
                        {
                            varTempExpiryDate = Convert.ToString(grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Value);
                            if (grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Value != null && Convert.ToString(grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Value) != "0")
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
                                            MessageBox.Show("Invalid date!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightPink;
                                            varError = 1;
                                        }
                                        else
                                        {
                                            if (pbDateflag == 0)
                                            {
                                                grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.PaleGreen;
                                                varError = 0;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter expirydate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                grdInward.Rows[rowIndex].Cells["clmInvoiceExpiryDate"].Style.BackColor = Color.LightPink;
                                varError = 1;
                            }
                        }
                    }


                    /*
                    if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmMRP" )
                    {
                        object varEditMRP = grdGrnlist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        dtInwardPurchase.Rows[e.RowIndex]["GIPPR_MRP"] = varEditMRP;
                    }
                    if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmExpiryDate")
                    {
                        object varExpiryDate = grdGrnlist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        dtInwardPurchase.Rows[e.RowIndex]["GIPPR_ExpiryDate"] = varExpiryDate;
                    }
                    if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmBatchNo")
                    {
                        object varBatchNo = grdGrnlist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        dtInwardPurchase.Rows[e.RowIndex]["GIPPR_BatchNo"] = varBatchNo;
                    }
                    if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmRack")
                    {
                        object varRKID = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmRKID"].Value);
                        dtInwardPurchase.Rows[e.RowIndex]["GIPPR_BatchNo"] = varRKID;
                    } */
                    if (grdInward.CurrentCell.OwningColumn.Name == "clmMRP" ||grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceMRP" || grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate" || grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceExpiryDate" || 
                        grdInward.CurrentCell.OwningColumn.Name == "clmBatchNo" || grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceBatchNo" || grdInward.CurrentCell.OwningColumn.Name == "clmRack" || grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty" || grdInward.CurrentCell.OwningColumn.Name == "clmShopQty")
                    {
                        grdInward.Rows[e.RowIndex].Cells["clmError"].Value = 1;
                        var varDuplicateProduct = from r in dtInwardPurchase.AsEnumerable()
                                                 where ( r.Field<int>("GIPPR_PRID").Equals(varPRID) && 
                                                        r.Field<decimal>("GIPPR_MRP").Equals(varMRP) &&
                                                        r.Field<string>("GIPPR_ExpiryDate").Equals(varExpiryDate) &&
                                                        r.Field<string>("GIPPR_BatchNo").Equals(varBatchNo) &&
                                                        r.Field<int>("GIPPR_RKID").Equals(varRackID) &&
                                                        r.Field<int>("GIPPR_OrderID") != Convert.ToInt16(grdInward.Rows[e.RowIndex].Cells["clmOrder"].Value)
                                                         )
                                                 group r by r.Field<int>("GIPPR_OrderID")
                                                 into g
                                                 select g.Key;
                        var varRowsToUpdate = dtInwardPurchase.AsEnumerable().Where(r => r.Field<int>("GIPPR_OrderID") == Convert.ToInt16(varOrderID));
                        int count = varDuplicateProduct.Count();
                        if (varDuplicateProduct.Count() == 0)
                        {
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty")
                            {
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_ReceivedQty", ReceivedQty); }
                                cellReceivedQty.Style.BackColor = Color.PaleGreen;
                                cellReceivedQty.Style.ForeColor = Color.Black;
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmShopQty")
                            {
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_ShopQty", ShopQty); }
                                cellShopQty.Style.BackColor = Color.PaleGreen;
                                cellShopQty.Style.ForeColor = Color.Black;
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmMRP")
                            {
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_MRP", varMRP); }
                                cellMRP.Style.BackColor = Color.PaleGreen;
                                cellMRP.Style.ForeColor = Color.Black;
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceMRP")
                            {
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_InvoiceMRP", varInvoiceMrp); }
                                cellInvoiceMRP.Style.BackColor = Color.PaleGreen;
                                cellInvoiceMRP.Style.ForeColor = Color.Black;
                            }
                            if (varError == 0)
                            {
                                if (grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate")
                                {
                                    foreach (var row in varRowsToUpdate)
                                    { row.SetField("GIPPR_ExpiryDate", varExpiryDate); }
                                    //Shelflifeper
                                    foreach (var row in varRowsToUpdate)
                                    { row.SetField("GIPPR_ShelfLife_Per", varShelflifePer); }
                                    if (pbDateflag == 0)
                                    {
                                        cellExpiryDate.Style.BackColor = Color.PaleGreen;
                                        cellExpiryDate.Style.ForeColor = Color.Black;
                                    }
                                }
                            }
                            else
                            {
                                if (grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate")
                                {
                                    foreach (var row in varRowsToUpdate)
                                    { row.SetField("GIPPR_ExpiryDate", ""); }
                                }
                            }
                            if (varError == 0)
                            {
                                if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceExpiryDate")
                                {
                                    foreach (var row in varRowsToUpdate)
                                    { row.SetField("GIPPR_InvoiceExpiryDate", varInvoiceExpiryDate); }
                                    if (pbDateflag == 0)
                                    {
                                        cellInvoiceExpiryDate.Style.BackColor = Color.PaleGreen;
                                        cellInvoiceExpiryDate.Style.ForeColor = Color.Black;
                                    }
                                }
                            }
                            else
                            {
                                if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceExpiryDate")
                                {
                                    foreach (var row in varRowsToUpdate)
                                    { row.SetField("GIPPR_InvoiceExpiryDate", ""); }
                                }
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmBatchNo")
                            {
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_BatchNo", varBatchNo); }
                                cellBatchNo.Style.BackColor = Color.PaleGreen;
                                cellBatchNo.Style.ForeColor = Color.Black;
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceBatchNo")
                            {
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_InvoiceBatchNo", varInvoiceBatchNo); }
                                cellInvoiceBatchNo.Style.BackColor = Color.PaleGreen;
                                cellInvoiceBatchNo.Style.ForeColor = Color.Black;
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmRack")
                            {
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_RKID", varRackID); }
                                cellRack.Style.BackColor = Color.PaleGreen;
                                cellRack.Style.ForeColor = Color.Black;
                            }
                        }
                        else
                        {
                            string varErrMrp = "0",varErrInvMrp = "0", varErrExp = "0", varErrBatch = "0", varErrRack = "0";
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty")
                            {
                                //grdGrnlist.CurrentCell.Value = "";
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_ReceivedQty", ReceivedQty); }
                                if (Convert.ToString(grdInward.CurrentRow.Cells["clmReceivedQty"].Value) == "")
                                {
                                    cellReceivedQty.Style.BackColor = Color.LightPink;
                                    cellReceivedQty.Style.ForeColor = Color.Black;
                                }
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmShopQty")
                            {
                                //grdGrnlist.CurrentCell.Value = "";
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_ShopQty", ShopQty); }
                                if (Convert.ToString(grdInward.CurrentRow.Cells["clmShopQty"].Value) == "")
                                {
                                    cellShopQty.Style.BackColor = Color.LightPink;
                                    cellShopQty.Style.ForeColor = Color.Black;
                                }
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmMRP")
                            {
                                varErrMrp = "1";
                                grdInward.CurrentCell.Value = "0";
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_MRP", "0"); }
                                cellMRP.Style.BackColor = Color.LightPink;
                                cellMRP.Style.ForeColor = Color.Black;
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceMRP")
                            {
                                varErrInvMrp = "1";
                                grdInward.CurrentCell.Value = "0";
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_InvoiceMRP", "0"); }
                                cellInvoiceMRP.Style.BackColor = Color.LightPink;
                                cellInvoiceMRP.Style.ForeColor = Color.Black;
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate")
                            {
                                varErrExp = "1";
                                grdInward.CurrentCell.Value = "";
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_ExpiryDate", ""); }
                                cellExpiryDate.Style.BackColor = Color.LightPink;
                                cellExpiryDate.Style.ForeColor = Color.Black;
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmBatchNo")
                            {
                                varErrBatch = "1";
                                grdInward.CurrentCell.Value = "";
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_BatchNo", ""); }
                                cellBatchNo.Style.BackColor = Color.LightPink;
                                cellBatchNo.Style.ForeColor = Color.Black;
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmRack")
                            {
                                varErrRack = "1";
                                grdInward.CurrentCell.Value = "";
                                grdInward.Rows[e.RowIndex].Cells["clmRKID"].Value = "0";
                                foreach (var row in varRowsToUpdate)
                                { row.SetField("GIPPR_RKID", "0"); }
                                cellRack.Style.BackColor = Color.LightPink;
                                cellRack.Style.ForeColor = Color.Black;
                            }
                            string varMRPErr = "0", varExpiryDateErr = "0", varBatchNoErr = "0", varInvoiceMRPErr = "0", varInvoiceExpiryDateErr = "0", varInvoiceBatchNoErr = "0", varRackErr = "0";
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmMRP" && Convert.ToString(grdInward.CurrentRow.Cells["clmMRP"].Value)!="" && Convert.ToString(grdInward.CurrentRow.Cells["clmMRP"].Value) != "0" || varErrMrp=="1")
                            {
                                varMRPErr = "1";
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceMRP" && Convert.ToString(grdInward.CurrentRow.Cells["clmInvoiceMRP"].Value)!="" && Convert.ToString(grdInward.CurrentRow.Cells["clmInvoiceMRP"].Value) != "0" || varErrInvMrp=="1")
                            {
                                varInvoiceMRPErr = "1";
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmExpiryDate" && Convert.ToString(grdInward.CurrentRow.Cells["clmExpiryDate"].Value) != "" || varErrExp=="1")
                            {
                                varExpiryDateErr = "1";
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceExpiryDate" && Convert.ToString(grdInward.CurrentRow.Cells["clmInvoiceExpiryDate"].Value) != "")
                            {
                                varInvoiceExpiryDateErr = "1";
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmBatchNo" && Convert.ToString(grdInward.CurrentRow.Cells["clmBatchNo"].Value) != "" || varErrBatch=="1")
                            {
                                varBatchNoErr = "1";
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmInvoiceBatchNo" && Convert.ToString(grdInward.CurrentRow.Cells["clmInvoiceBatchNo"].Value) != "")
                            {
                                varInvoiceBatchNoErr = "1";
                            }
                            if (grdInward.CurrentCell.OwningColumn.Name == "clmRack" && Convert.ToString(grdInward.CurrentRow.Cells["clmRack"].Value) != "" || varErrRack == "1")
                            {
                                varRackErr = "1";
                            }
                            if (varMRPErr == "1" || varExpiryDateErr == "1" || varBatchNoErr == "1" || varInvoiceMRPErr == "1" || varInvoiceExpiryDateErr == "1" || varInvoiceBatchNoErr == "1" || varRackErr == "1")
                            {
                                SPDataService objDServ = new SPDataService();
                                string varMessage = objDServ.udfnGetMessages(127);
                                objDServ.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    if(grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty" || grdInward.CurrentCell.OwningColumn.Name == "clmShopQty")
                    {
                        if (varGRNPurchaseFlag != 1 && varGRNPurchaseFlag != 174)
                        {
                            decimal varReceivedQty = 0, varQty = 0; string varProID = ""; int varConvertType = -1; int varSno = 0;
                            if (Convert.ToString(grdInward.CurrentRow.Cells["clmQty"].Value) != "")
                            {
                                varQty = Convert.ToDecimal(grdInward.CurrentRow.Cells["clmQty"].Value);
                            }
                            varConvertType = Convert.ToInt16(grdInward.CurrentRow.Cells["clmConvertType"].Value);
                            varSno = Convert.ToInt16(grdInward.CurrentRow.Cells["clmDuplicateSno"].Value);
                            if (varQty != 0)
                            {
                                if (Convert.ToString(grdInward.CurrentRow.Cells["clmConvertType"].Value) == "0")
                                {
                                    varReQty = 0; varShQty = 0;
                                    if (grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty")
                                    {
                                        var varSumRequestQty = dtInwardPurchase.AsEnumerable()
                                                                        .Where(y => y.Field<int>("GIPPR_SNO").Equals(varSno) &&
                                                                       y.Field<int>("GIPPR_ConvertType").Equals(varConvertType))
                                                                        .Sum(x => x.Field<decimal>("GIPPR_ReceivedQty")).ToString();

                                        varProID = Convert.ToString(grdInward.CurrentRow.Cells["clmPRID"].Value);
                                        varReQty = varQty - Convert.ToDecimal(varSumRequestQty);
                                    }
                                    if (grdInward.CurrentCell.OwningColumn.Name == "clmShopQty")
                                    {
                                        var varSumShopQty = dtInwardPurchase.AsEnumerable()
                                                                    .Where(y => y.Field<int>("GIPPR_SNO").Equals(varSno) &&
                                                                   y.Field<int>("GIPPR_ConvertType").Equals(varConvertType))
                                                                    .Sum(x => x.Field<decimal>("GIPPR_ShopQty")).ToString();

                                        varProID = Convert.ToString(grdInward.CurrentRow.Cells["clmPRID"].Value);
                                        varShQty = Convert.ToDecimal(varSumShopQty);
                                    }
                                }
                                else
                                {
                                    varReQty = ReceivedQty;
                                    varShQty = ShopQty;
                                }
                                for (int i = 0; i < grdInward.Rows.Count; i++)
                                {
                                    if (Convert.ToString(grdInward.Rows[i].Cells["clmConvertType"].Value) == "1" && Convert.ToString(grdInward.Rows[i].Cells["clmSno"].Value) == Convert.ToString(varSno))
                                    {
                                        if (grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty")
                                        {
                                            grdInward.Rows[i].Cells["clmReceivedQty"].Value = Convert.ToString(varReQty);
                                        }
                                        if (grdInward.CurrentCell.OwningColumn.Name == "clmShopQty")
                                        {
                                            grdInward.Rows[i].Cells["clmShopQty"].Value = Convert.ToString(varShQty);
                                        }
                                    }
                                }
                                int varSnovalue = Convert.ToInt32(grdInward.CurrentRow.Cells["clmDuplicateSno"].Value);
                                var varRowsToUpdate = dtInwardPurchase.AsEnumerable().Where(r => r.Field<int>("GIPPR_SNO") == Convert.ToInt32(varSnovalue) && r.Field<int>("GIPPR_ConvertType") == 1);

                                if (grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty")
                                {
                                    foreach (var row in varRowsToUpdate)
                                    { row.SetField("GIPPR_ReceivedQty", varReQty); }
                                    cellReceivedQty.Style.BackColor = Color.PaleGreen;
                                    cellReceivedQty.Style.ForeColor = Color.Black;
                                }
                                if (grdInward.CurrentCell.OwningColumn.Name == "clmShopQty")
                                {
                                    foreach (var row in varRowsToUpdate)
                                    { row.SetField("GIPPR_ShopQty", varShQty); }
                                    cellShopQty.Style.BackColor = Color.PaleGreen;
                                    cellShopQty.Style.ForeColor = Color.Black;
                                }
                            }
                        }
                    }
                    if(grdInward.CurrentCell.OwningColumn.Name == "clmStatus")
                    {
                        int varStatus = 0;
                        if(Convert.ToString(grdInward.CurrentRow.Cells["clmStatus"].Value)!="")
                        {
                            varStatus = Convert.ToInt32(grdInward.CurrentRow.Cells["clmStatus"].Value);
                        }
                        int varSnovalue = Convert.ToInt32(grdInward.CurrentRow.Cells["clmDuplicateSno"].Value);
                        var varRowsToUpdate = dtInwardPurchase.AsEnumerable().Where(r => r.Field<int>("GIPPR_SNO") == Convert.ToInt32(varSnovalue));
                        if (grdInward.CurrentCell.OwningColumn.Name == "clmStatus")
                        {
                            foreach (var row in varRowsToUpdate)
                            { row.SetField("GIPPR_INVSTSID", varStatus); }
                        }
                    }
                    if (varEditFlag == 1)
                    {
                        if (grdInward.CurrentCell.OwningColumn.Name == "clmReceivedQty" || grdInward.CurrentCell.OwningColumn.Name == "clmShopQty")
                        {
                            decimal varStock = Convert.ToDecimal(grdInward.CurrentRow.Cells["clmStockQty"].Value);
                            decimal varReceivedQty = 0, varShopQty = 0, varTotalQty = 0;
                            if (Convert.ToString(grdInward.CurrentRow.Cells["clmReceivedQty"].Value) != "")
                            {
                                varReceivedQty = Convert.ToDecimal(grdInward.CurrentRow.Cells["clmReceivedQty"].Value);
                            }
                            if (Convert.ToString(grdInward.CurrentRow.Cells["clmShopQty"].Value) != "")
                            {
                                varShopQty = Convert.ToDecimal(grdInward.CurrentRow.Cells["clmShopQty"].Value);
                            }
                            varTotalQty = varReceivedQty + varShopQty;
                            if ( varTotalQty < varStock )
                            {
                                varErrorQty = 1;
                            }
                            else
                            {
                                varErrorQty = 0;
                            }
                        }
                    }
                    if (varErrorQty == 1)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdInward.CurrentRow.Cells["clmReceivedQty"].Style.BackColor = Color.LightPink;
                        grdInward.CurrentRow.Cells["clmShopQty"].Style.BackColor = Color.LightPink;
                        grdInward.Rows[e.RowIndex].Cells["clmErrorQty"].Value = varErrorQty;
                    }
                    else
                    {
                        varErrorQty = 0;
                        grdInward.CurrentRow.Cells["clmReceivedQty"].Style.BackColor = Color.PaleGreen;
                        grdInward.CurrentRow.Cells["clmShopQty"].Style.BackColor = Color.PaleGreen;
                        grdInward.Rows[e.RowIndex].Cells["clmErrorQty"].Value = varErrorQty;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnlist_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdInward.Rows.Count > 0)
                {
                    if (e.ColumnIndex == grdInward.Columns["clmRack"].Index && e.RowIndex >= 0)
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cellRkname = dataGridView.Rows[e.RowIndex].Cells["clmRack"];
                        DataGridViewCell cellRkid = dataGridView.Rows[e.RowIndex].Cells["clmRKID"];
                        if (Convert.ToString(varLocationId) != "-1")
                        {
                            string SelectedRackName = grdInward.Rows[e.RowIndex].Cells["clmRack"].Value?.ToString();
                            if (!string.IsNullOrEmpty(SelectedRackName))
                            {
                                /*check location have a rack or not*/
                                string varId_PurchaseRack = "0";
                                DataSet objDsPurchaseRack = new DataSet();
                                SPDataService objDServ6 = new SPDataService();
                                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varLocationId), 0, SelectedRackName, 0, 0);
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
                                    cellRkname.Style.BackColor = Color.PaleGreen;
                                    cellRkid.Value = Convert.ToString(varId_PurchaseRack);
                                }
                                else
                                {
                                    cellRkname.Style.BackColor = Color.LightPink;
                                    cellRkid.Value = Convert.ToString(varId_PurchaseRack);
                                }
                                if(Convert.ToString(grdInward.Rows[e.RowIndex].Cells["clmRack"].Value) == "None" || Convert.ToString(grdInward.Rows[e.RowIndex].Cells["clmRack"].Value) == "none")
                                {
                                    cellRkid.Value = 0;
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

        public void udfnclose()
        {
            try
            {
                if (varCloseFlag == 0)
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
                if (varEditFlag == 0)
                {
                    MainForm.objINV_InwardQueueList.udfnList();
                }
                else
                {
                    MainForm.objINV_InwardPurchaseList.udfnList();
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
        public void EditLoad()
        {
            try
            {
                if (varID!=0 || varInwardId !=0 )
                {
                    varPurApproved = "0";
                    int varviewtype = 0;
                    if (varEditFlag == 1)
                    { varviewtype = 2; }
                    if(varStausId==45)
                    {
                        chkCompleted.Checked = false;
                    }
                    else if (varStausId==46)
                    {
                        chkCompleted.Checked = true;
                    }
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                    objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                    objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_GoodsInward_Purchase.paraID = varID;
                    //objTRN_GoodsInward_Purchase.paraGRNID = varGRNId;
                    objTRN_GoodsInward_Purchase.paraInwardId = varInwardId;
                    objTRN_GoodsInward_Purchase.paraSLID = varLocationId;
                    objTRN_GoodsInward_Purchase.paraCompanyId= varConcernId;
                    objTRN_GoodsInward_Purchase.paraFlag= varGRNPurchaseFlag;
                    objDs = objdserv.udfnInwardPurchaseList(objTRN_GoodsInward_Purchase);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            string Quantity = "Quantity";
                            if (objDs.Tables[1].Rows.Count > 0)
                            {
                                if (varGRNPurchaseFlag == 1 || varGRNPurchaseFlag == 174)
                                {
                                    textBox4.Visible = true;
                                    txtVerifiedby1.Visible = true;
                                    textBox5.Visible = true;
                                    txtVerifiedby2.Visible = true;
                                    txtDGRNDate.Text = "GRN Date";
                                    txtDGRNNo.Text = "GRN No.";
                                    dpGRNDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN_Date"]);
                                    txtGRNNo.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN_No"]);
                                    txtVerifiedby1.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Verified BY 1"]);
                                    txtVerifiedby2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Verified BY 2"]);
                                    txtCompletedby.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN User"]);
                                    lblStatusValue.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN STS"]);
                                    grdInward.Columns["clmPendingQty"].Visible = true;
                                    Quantity = "Pending Qty";
                                }
                                if(varGRNPurchaseFlag==2 || varGRNPurchaseFlag == 175)
                                {
                                    string PurEntryType = Convert.ToString(objDs.Tables[2].Rows[0]["PUR_EntryType"]);  // GET Purchase Entry Type

                                    grdInward.Columns["clmQty"].HeaderText = "Invoice Qty";
                                    grdInward.Columns["clmQty"].Visible = true;
                                    Quantity = "Invoice Qty";

                                    if (PurEntryType == "54") // Against GRN
                                    {
                                        grdInward.Columns["clmPendingQty"].Visible = true;
                                        textBox4.Visible = true;
                                        txtVerifiedby1.Visible = true;
                                        textBox5.Visible = true;
                                        txtVerifiedby2.Visible = true;
                                        txtVerifiedby1.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Verified BY 1"]);
                                        txtVerifiedby2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Verified BY 2"]);
                                        txtDGRNDate.Text = "GRN Date";
                                        txtDGRNNo.Text = "GRN No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN_No"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN User"]);
                                    }
                                    if (PurEntryType == "55") // Against PO
                                    {
                                        grdInward.Columns["clmPendingQty"].Visible = false;
                                        txtDGRNDate.Text = "PO Date";
                                        txtDGRNNo.Text = "PO No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PO_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PO_No"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PO User"]);
                                    }
                                    if(PurEntryType=="56") // Direct Purchase
                                    {
                                        grdInward.Columns["clmPendingQty"].Visible = false;
                                        lblStatusValue.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PUR STS"]);
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PUR Date"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PUR User"]);
                                    }
                                    if (PurEntryType == "57") // Against DC
                                    {
                                        grdInward.Columns["clmPendingQty"].Visible = false;
                                        txtDGRNDate.Text = "DC Date";
                                        txtDGRNNo.Text = "DC No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC_No"]);
                                        textBox5.Text = "DC Created by";
                                        txtVerifiedby2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC User"]);
                                        textBox5.Visible = true;
                                        txtVerifiedby2.Visible = true;
                                        txtVerifiedby2.Size = new Size(123, 25);
                                        txtVerifiedby2.Font = new Font("Oswald Regular", 9.75f);
                                    }
                                    grdInward.Columns["clmQty"].HeaderText = Quantity;
                                    txtApproved1.Visible = true;
                                    txtApprovedby1.Visible = true;
                                    txtApproved2.Visible = true;
                                    txtApprovedby2.Visible = true;
                                    if (varEditFlag == 0)
                                    {
                                        txtApprovedby1.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Approved By1"]);
                                        txtApprovedby2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Approved By2"]);
                                    }
                                    else
                                    {
                                        txtApprovedby1.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Approved By1"]);
                                        txtApprovedby2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Approved By2"]);
                                    }
                                }
                                if (varGRNPurchaseFlag == 3 || varGRNPurchaseFlag == 187)
                                {
                                    txtDGRNDate.Text = "DC Date";
                                    txtDGRNNo.Text = "DC No.";
                                    dpGRNDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC_Date"]);
                                    txtGRNNo.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC_No"]);
                                    txtCompletedby.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC User"]);
                                    lblStatusValue.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC STS"]);
                                    grdInward.Columns["clmQty"].HeaderText = Quantity;
                                    textBox4.Visible = true;
                                    txtVerifiedby1.Visible = true;
                                    txtVerifiedby1.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Verified BY 1"]);
                                    Quantity = "Quantity";
                                    grdInward.Columns["clmInvoiceMRP"].Visible = false;
                                    grdInward.Columns["clmInvoiceExpiryDate"].Visible = false;
                                    grdInward.Columns["clmInvoiceBatchNo"].Visible = false;
                                }
                                if(varStausId==46)
                                {
                                    txtApproved1.Visible = true;
                                    txtApproved2.Visible = true;
                                    txtApprovedby1.Visible = true;
                                    txtApprovedby2.Visible = true;
                                    txtApprovedby1.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Approved By1"]);
                                    txtApprovedby2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Approved By2"]);
                                }
                            }
                            if (varEditFlag == 1)
                            {
                                if (objDs.Tables[3].Rows.Count>0)
                                {
                                    if (Convert.ToString(objDs.Tables[3].Rows[0]["ApprovalStatus"]) != "")
                                    {
                                        varPurApproved = Convert.ToString(objDs.Tables[3].Rows[0]["ApprovalStatus"]);
                                    }
                                }
                            }
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string OrderID = "";
                                    if (varEditFlag==0)
                                    {
                                        OrderID = "S.No.";
                                    }
                                    else
                                    {
                                        OrderID = "ORDER ID";
                                    }
                                    string varRackName = "None";
                                    if (Convert.ToString(objDs.Tables[0].Rows[i]["Rack"]).Trim() != "")
                                    {
                                        varRackName = Convert.ToString(objDs.Tables[0].Rows[i]["Rack"]);
                                    }
                                    grdInward.Rows.Add(false, null, Convert.ToString(objDs.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[0].Rows[i]["P.I Code"]), Convert.ToString(objDs.Tables[0].Rows[i]["Product Name in Tamil"]), Convert.ToString(objDs.Tables[0].Rows[i]["Pro MRP"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice MRP"]),
                                        Convert.ToString(objDs.Tables[0].Rows[i]["Pro Expiry Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Expiry Date"]),Convert.ToString(objDs.Tables[0].Rows[i]["Pro Batch No."]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Batch No."]), Convert.ToString(objDs.Tables[0].Rows[i]["Pending Qty"]), 
                                        Convert.ToString(objDs.Tables[0].Rows[i][Quantity]),Convert.ToString(objDs.Tables[0].Rows[i]["Received Qty"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shop Qty"]),
                                         Convert.ToString(objDs.Tables[0].Rows[i]["Unit"]), varRackName, Convert.ToString(objDs.Tables[0].Rows[i]["Product ID"]), Convert.ToString(objDs.Tables[0].Rows[i]["Location ID"]), Convert.ToString(objDs.Tables[0].Rows[i]["Rack ID"]),
                                           Convert.ToString(objDs.Tables[0].Rows[i]["Unit ID"]), Convert.ToString(objDs.Tables[0].Rows[i]["ID"]), Convert.ToString(objDs.Tables[0].Rows[i]["UT_Decimal"]), Convert.ToString(objDs.Tables[0].Rows[i]["RackCount"]), Convert.ToString(objDs.Tables[0].Rows[i]["Convert"]), Convert.ToString(objDs.Tables[0].Rows[i][OrderID]),0
                                            ,Convert.ToString(objDs.Tables[0].Rows[i]["BatchNo Status"]), Convert.ToString(objDs.Tables[0].Rows[i]["BatchNo Generation"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shelflife Status"]), Convert.ToString(objDs.Tables[0].Rows[i]["MRP Flag"]), 
                                           Convert.ToString(objDs.Tables[0].Rows[i]["Disable"]), Convert.ToString(objDs.Tables[0].Rows[i]["UnReadable"]), Convert.ToString(objDs.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[0].Rows[i]["Stock Qty"]),0, Convert.ToString(objDs.Tables[0].Rows[i]["RM Flag"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["actuallife"]), 
                                           Convert.ToDecimal(objDs.Tables[0].Rows[i]["Per"]), Convert.ToString(objDs.Tables[0].Rows[i]["ShelflifeValue"]), Convert.ToString(objDs.Tables[0].Rows[i]["SheflifeStatus"]), Convert.ToString(objDs.Tables[0].Rows[i]["ShelflifeType"]), Convert.ToString(objDs.Tables[0].Rows[i]["Reason"]),
                                           Convert.ToString(objDs.Tables[0].Rows[i]["Full Reason"]), Convert.ToString(objDs.Tables[0].Rows[i]["FinalQty"]), Convert.ToString(objDs.Tables[0].Rows[i]["EntryTypeProID"]));
                                    udfnStatus();
                                    if(varEditFlag==0)
                                    {
                                        grdInward.Rows[i].Cells["clmStatus"].Value = Convert.ToInt32(objDs.Tables[0].Rows[i]["PR_STSID"]);
                                        grdInward.Rows[i].Cells["clmStatus"].Value = 82;
                                    }
                                    else
                                    {
                                        grdInward.Rows[i].Cells["clmStatus"].Value = Convert.ToInt32(objDs.Tables[0].Rows[i]["PR_STSID"]);
                                        
                                        if (Convert.ToInt32(objDs.Tables[0].Rows[i]["PR_STSID"])==82)
                                        {
                                            //grdGrnlist.Rows[i].Cells["clmStatus"].ReadOnly = true;
                                            //grdGrnlist.Rows[i].Cells["clmStatus"].Style.BackColor = Color.LightGray;
                                            //grdGrnlist.Rows[i].Cells["clmShopQty"].ReadOnly = true;
                                            //grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.LightGray;
                                        }
                                        if(Convert.ToInt32(grdInward.Rows[i].Cells["clmStatus"].Value) == 82)
                                        {
                                            grdInward.Rows[i].Cells["clmStatus"].ReadOnly = true;
                                        }

                                    }
                                    decimal ReceivedQty = 0, ShopQty = 0;
                                    if(Convert.ToString(objDs.Tables[0].Rows[i]["Received Qty"])!="")
                                    {
                                        ReceivedQty = Convert.ToDecimal(objDs.Tables[0].Rows[i]["Received Qty"]);
                                    }
                                    if (Convert.ToString(objDs.Tables[0].Rows[i]["Shop Qty"]) != "")
                                    {
                                        ShopQty = Convert.ToDecimal(objDs.Tables[0].Rows[i]["Shop Qty"]);
                                    }
                                    int varSNO = 0; //for quantity validation
                                    if(varEditFlag==0) 
                                    { varSNO=Convert.ToInt32(objDs.Tables[0].Rows[i]["S.No."]);  }
                                    else
                                    { varSNO=Convert.ToInt32(objDs.Tables[0].Rows[i]["EntryTypeProID"]);  }
                                    dtInwardPurchase.Rows.Add(false, varSNO, Convert.ToInt32(objDs.Tables[0].Rows[i]["Convert"]), Convert.ToInt32(objDs.Tables[0].Rows[i][OrderID]), Convert.ToInt32(objDs.Tables[0].Rows[i]["Product ID"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["Unit ID"]), ReceivedQty,ShopQty, Convert.ToInt32(objDs.Tables[0].Rows[i]["Rack ID"]),
                                        Convert.ToString(objDs.Tables[0].Rows[i]["Pro Expiry Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Pro Batch No."]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Pro MRP"]), Convert.ToString(objDs.Tables[0].Rows[i]["ID"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["MRP Flag"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["Shelflife Status"]),
                                        Convert.ToInt32(objDs.Tables[0].Rows[i]["BatchNo Status"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["BatchNo Generation"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["PR_STSID"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["RM Flag"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["ShelflifeValue"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["ShelflifeType"]),
                                        Convert.ToInt32(objDs.Tables[0].Rows[i]["actuallife"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["SheflifeStatus"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Per"]),
                                        Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Expiry Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Batch No."]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Invoice MRP"]));

                                    if (Convert.ToString(grdInward.Rows[i].Cells["clmConvertType"].Value)== "1")
                                    {
                                        ((DataGridViewImageCell)grdInward.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
                                    }
                                    if (Convert.ToString(grdInward.Rows[i].Cells["clmDisable"].Value) == "1")
                                    {
                                        ((DataGridViewImageCell)grdInward.Rows[i].Cells["clmConvert"]).Value = new System.Drawing.Bitmap(1, 1);
                                    }
                                    if (varEditFlag == 0)
                                    {
                                        if (Convert.ToString(grdInward.Rows[i].Cells["clmUnReadable"].Value) == "1")
                                        {
                                            ((DataGridViewImageCell)grdInward.Rows[i].Cells["clmConvert"]).Value = new System.Drawing.Bitmap(1, 1);
                                            grdInward.Rows[i].ReadOnly = true;
                                            grdInward.Rows[i].Cells["clmCheck"].ReadOnly = true;
                                            grdInward.Rows[i].Cells["clmCheck"].Value = null;
                                            grdInward.Rows[i].Cells["clmCheck"] = new DataGridViewTextBoxCell();
                                            grdInward.Rows[i].Cells["clmCheck"].Value = "";
                                            grdInward.Rows[i].Cells["clmCheck"].ReadOnly = true;
                                            //((DataGridViewCheckBoxCell)grdInward.Rows[i].Cells["clmCheck"]).Value = new System.Drawing.Bitmap(1, 1);
                                            grdInward.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                        }
                                        DataGridView dataGridView1 = grdInward;
                                        DataGridViewCell cell1 = dataGridView1.Rows[i].Cells["clmMRP"];
                                        DataGridView dataGridView5 = grdInward;
                                        DataGridViewCell cell5 = dataGridView1.Rows[i].Cells["clmInvoiceMRP"];
                                        if (Convert.ToString(grdInward.Rows[i].Cells["clmMRPFlag"].Value) == "1")
                                        {
                                            //cell1.Style.BackColor = Color.PaleGreen;
                                            //cell1.Style.ForeColor = Color.Black;
                                            cell1.ReadOnly = false;
                                            //cell5.Style.BackColor = Color.PaleGreen;
                                            //cell5.Style.ForeColor = Color.Black;
                                            cell5.ReadOnly = false;
                                        }
                                        else
                                        {
                                            cell1.Style.BackColor = Color.LightGray;
                                            cell1.Style.ForeColor = Color.Black;
                                            cell1.ReadOnly = true;
                                            cell5.Style.BackColor = Color.LightGray;
                                            cell5.Style.ForeColor = Color.Black;
                                            cell5.ReadOnly = true;
                                        }
                                        //Expiry Date
                                        DataGridView dataGridView2 = grdInward;
                                        DataGridViewCell cell2 = dataGridView2.Rows[i].Cells["clmExpiryDate"];
                                        DataGridView dataGridView4 = grdInward;
                                        DataGridViewCell cell4 = dataGridView1.Rows[i].Cells["clmInvoiceExpiryDate"];
                                        if (Convert.ToString(grdInward.Rows[i].Cells["clmShelfStatus"].Value) == "1")
                                        {
                                            //cell2.Style.BackColor = Color.PaleGreen;
                                            //cell2.Style.ForeColor = Color.Black;
                                            cell2.ReadOnly = false;
                                            //cell4.Style.BackColor = Color.PaleGreen;
                                            //cell4.Style.ForeColor = Color.Black;
                                            cell4.ReadOnly = false;
                                        }
                                        else
                                        {
                                            cell2.Style.BackColor = Color.LightGray;
                                            cell2.Style.ForeColor = Color.Black;
                                            cell2.ReadOnly = true;
                                            cell4.Style.BackColor = Color.LightGray;
                                            cell4.Style.ForeColor = Color.Black;
                                            cell4.ReadOnly = true;
                                        }
                                        if (Convert.ToString(grdInward.Rows[i].Cells["clmRMFlag"].Value) == "1")
                                        {
                                            cell2.Style.BackColor = Color.LightGray;
                                            cell2.Style.ForeColor = Color.Black;
                                            cell2.ReadOnly = true;
                                            cell4.Style.BackColor = Color.LightGray;
                                            cell4.Style.ForeColor = Color.Black;
                                            cell4.ReadOnly = true;
                                        }

                                        //Batch No
                                        DataGridView dataGridView3 = grdInward;
                                        DataGridViewCell cell3 = dataGridView3.Rows[i].Cells["clmBatchNo"];
                                        DataGridView dataGridView6 = grdInward;
                                        DataGridViewCell cell6 = dataGridView3.Rows[i].Cells["clmInvoiceBatchNo"];
                                        if (Convert.ToString(grdInward.Rows[i].Cells["clmBatchNoStatus"].Value) == "72" && Convert.ToString(grdInward.Rows[i].Cells["clmBatchNoGeneration"].Value) == "75")
                                        {
                                            //cell3.Style.BackColor = Color.PaleGreen;
                                            //cell3.Style.ForeColor = Color.Black;
                                            cell3.ReadOnly = false;
                                            //cell6.Style.BackColor = Color.PaleGreen;
                                            //cell6.Style.ForeColor = Color.Black;
                                            cell6.ReadOnly = false;
                                        }
                                        else
                                        {
                                            cell3.Style.BackColor = Color.LightGray;
                                            cell3.Style.ForeColor = Color.Black;
                                            cell3.ReadOnly = true;
                                            cell6.Style.BackColor = Color.LightGray;
                                            cell6.Style.ForeColor = Color.Black;
                                            cell6.ReadOnly = true;
                                        }
                                        if (Convert.ToString(grdInward.Rows[i].Cells["clmConvertType"].Value) == "1")
                                        {
                                            grdInward.Columns["clmMRP"].DefaultCellStyle.BackColor = Color.LightGray;
                                            grdInward.Columns["clmMRP"].ReadOnly = true;
                                            grdInward.Columns["clmInvoiceMRP"].DefaultCellStyle.BackColor = Color.LightGray;
                                            grdInward.Columns["clmInvoiceMRP"].ReadOnly = true;
                                            grdInward.Columns["clmExpiryDate"].DefaultCellStyle.BackColor = Color.LightGray;
                                            grdInward.Columns["clmExpiryDate"].ReadOnly = true;
                                            grdInward.Columns["clmInvoiceExpiryDate"].DefaultCellStyle.BackColor = Color.LightGray;
                                            grdInward.Columns["clmInvoiceExpiryDate"].ReadOnly = true;
                                            grdInward.Columns["clmBatchNo"].DefaultCellStyle.BackColor = Color.LightGray;
                                            grdInward.Columns["clmBatchNo"].ReadOnly = true;
                                            grdInward.Columns["clmInvoiceBatchNo"].DefaultCellStyle.BackColor = Color.LightGray;
                                            grdInward.Columns["clmInvoiceBatchNo"].ReadOnly = true;
                                        }
                                    }
                                }
                                grdInward.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmReceivedQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmShopQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInward.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInward.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                if (varEditFlag == 1)
                                {
                                    grdInward.Columns["clmReason"].Visible = false;
                                    grdInward.Columns["clmPendingQty"].Visible = false;
                                    //grdInward.Columns["clmQty"].Visible = false;
                                    grdInward.Columns["clmConvert"].Visible = false;
                                    grdInward.Columns["clmRemove"].Visible = false;
                                    //grdInward.Columns["clmStatus"].Visible = false;
                                    if (objDs.Tables[4].Rows.Count != 0)
                                    {
                                        txtRemark.Text = Convert.ToString(objDs.Tables[4].Rows[0]["GIP_Remarks"]);
                                    }
                                    if (varStausId == 46)
                                    {
                                        grdInward.ReadOnly = true;
                                        btnSave.Enabled = false;
                                        chkCompleted.Enabled = false;
                                        txtRemark.Enabled = false;
                                        txttotalProduct.Enabled = false;
                                    }
                                }
                            }
                            
                            /*
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                grdGrnlist.Rows.Clear();
                                grdGrnlist.DataSource = objDs.Tables[0];
                                grdGrnlist.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdGrnlist.Columns["MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                
                                grdGrnlist.Columns["Received Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["Shop Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["Product Name in English"].Visible = false;
                                grdGrnlist.Columns["Product Name in Tamil"].Width = 300;
                                
                                grdGrnlist.Columns["S.No."].Width = 50;
                                grdGrnlist.Columns["MRP"].Width = 80;
                                grdGrnlist.Columns["Unit"].Width = 70;

                                grdGrnlist.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdGrnlist.Columns["Shop Qty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdGrnlist.Columns["S.No."].ReadOnly = true;
                                grdGrnlist.Columns["MRP"].ReadOnly = true;
                                grdGrnlist.Columns["P.I Code"].ReadOnly = true;
                                grdGrnlist.Columns["Product Name in English"].ReadOnly = true;
                                grdGrnlist.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdGrnlist.Columns["Batch No."].ReadOnly = true;
                                grdGrnlist.Columns["Unit"].ReadOnly = true;
                                grdGrnlist.Columns["Expiry Date"].ReadOnly = true;
                                ((DataGridViewTextBoxColumn)grdGrnlist.Columns["Received Qty"]).MaxInputLength = 8;
                                ((DataGridViewTextBoxColumn)grdGrnlist.Columns["Shop Qty"]).MaxInputLength = 8;
                                //btnSave.Text = "Update";
                                udfnsupplierLoad();
                                grdGrnlist.Columns["Convert"].Visible = false;
                                grdGrnlist.Columns["Product ID"].Visible = false;
                                grdGrnlist.Columns["Unit ID"].Visible = false;
                                grdGrnlist.Columns["Location ID"].Visible = false;
                                grdGrnlist.Columns["Rack ID"].Visible = false;
                                grdGrnlist.Columns["RackCount"].Visible = false;
                                grdGrnlist.Columns["ID"].Visible = false;
                                grdGrnlist.Columns["UT_Decimal"].Visible = false;
                                if (varEditFlag == 0)
                                {
                                    //grdGrnlist.Columns["U_Name"].Visible = false;
                                }
                                //grdGrnlist.Columns["STS_Name"].Visible = false;
                                lblStatusValue.Text = varStatus;
                                if (grdGrnlist.Rows.Count > 0)
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist["Received Qty", 0];
                                }
                                if (varGRNPurchaseFlag == 3) //from Purchase DC
                                {
                                    txtDGRNDate.Text = "DC Date";
                                    txtDGRNNo.Text = "DC No.";
                                    dpGRNDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC_Date"]);
                                    txtGRNNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC_No"]);
                                    txtCompletedby.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC User"]);
                                    //lblStatusValue.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC STS"]);
                                    grdGrnlist.Columns["DC Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdGrnlist.Columns["DC Qty"].Width = 100;
                                    grdGrnlist.Columns["DC Qty"].ReadOnly = true;
                                    grdGrnlist.Columns["DC_No"].Visible = false;
                                    grdGrnlist.Columns["DC_Date"].Visible = false;
                                    grdGrnlist.Columns["DC User"].Visible = false;
                                    grdGrnlist.Columns["DC STS"].Visible = false;
                                }
                                if (varGRNPurchaseFlag == 2) //from  Purchase
                                {
                                    string PurEntryType= Convert.ToString(objDs.Tables[0].Rows[0]["PUR_EntryType"]);
                                    if(PurEntryType=="54") // Against GRN
                                    {
                                        txtDGRNDate.Text = "GRN Date";
                                        txtDGRNNo.Text = "GRN No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN_No"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN User"]);
                                        //lblStatusValue.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GRN STS"]);
                                    }
                                    if (PurEntryType == "55") // Against PO
                                    {
                                        txtDGRNDate.Text = "PO Date";
                                        txtDGRNNo.Text = "PO No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PO_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PO_No"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PO User"]);
                                        //lblStatusValue.Text = Convert.ToString(objDs.Tables[1].Rows[0]["PO STS"]);
                                    }
                                    if (PurEntryType == "57") // Against DC
                                    {
                                        txtDGRNDate.Text = "DC Date";
                                        txtDGRNNo.Text = "DC No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC_No"]);
                                        textBox5.Text = "DC Created by";
                                        txtVerifiedby2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC User"]);
                                        textBox5.Visible = true;
                                        txtVerifiedby2.Visible = true;
                                        txtVerifiedby2.Size = new Size(123, 25);
                                        txtVerifiedby2.Font = new Font("Oswald Regular", 9.75f);
                                        //lblStatusValue.Text = Convert.ToString(objDs.Tables[1].Rows[0]["DC STS"]);
                                    }
                                    lblStatusValue.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR STS"]);
                                    txtCompletedby.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR User"]);
                                    grdGrnlist.Columns["Invoice Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdGrnlist.Columns["Invoice Qty"].Width = 120;
                                    grdGrnlist.Columns["Invoice Qty"].ReadOnly = true;
                                    grdGrnlist.Columns["PUR_EntryType"].Visible = false;
                                    grdGrnlist.Columns["PUR STS"].Visible = false;
                                    grdGrnlist.Columns["PUR User"].Visible = false;
                                }
                                if (varGRNPurchaseFlag == 1) //from  grn
                                {
                                    textBox4.Visible = true;
                                    txtVerifiedby1.Visible = true;
                                    textBox5.Visible = true;
                                    txtVerifiedby2.Visible = true;
                                    txtDGRNDate.Text = "GRN Date";
                                    txtDGRNNo.Text = "GRN No.";
                                    dpGRNDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Date"]);
                                    txtGRNNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_No"]);
                                    txtVerifiedby1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Verified BY 1"]);
                                    txtVerifiedby2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Verified BY 2"]);
                                    txtCompletedby.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN User"]);
                                    lblStatusValue.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN STS"]);
                                    grdGrnlist.Columns["Pending Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdGrnlist.Columns["Pending Qty"].ReadOnly = true;
                                    //grdGrnlist.Columns["Invoice Received Qty"].Visible = false;
                                    grdGrnlist.Columns["Verified BY 1"].Visible = false;
                                    grdGrnlist.Columns["Verified BY 2"].Visible = false;
                                    grdGrnlist.Columns["GRN_Date"].Visible = false;
                                    grdGrnlist.Columns["GRN_No"].Visible = false;
                                    grdGrnlist.Columns["GRN User"].Visible = false;
                                    grdGrnlist.Columns["GRN STS"].Visible = false;
                                }
                                else
                                {
                                    textBox4.Visible = false;
                                    txtVerifiedby1.Visible = false;
                                    //textBox5.Visible = false;
                                    //txtVerifiedby2.Visible = false;
                                }
                                if (varGRNPurchaseFlag == 174) //from  grn
                                {
                                    textBox4.Visible = true;
                                    txtVerifiedby1.Visible = true;
                                    textBox5.Visible = true;
                                    txtVerifiedby2.Visible = true;
                                    txtDGRNDate.Text = "GRN Date";
                                    txtDGRNNo.Text = "GRN No.";
                                    dpGRNDate.Text = Convert.ToString(objDs.Tables[2].Rows[0]["GRN_Date"]);
                                    txtGRNNo.Text = Convert.ToString(objDs.Tables[2].Rows[0]["GRN_No"]);
                                    txtVerifiedby1.Text = Convert.ToString(objDs.Tables[2].Rows[0]["Verified BY 1"]);
                                    txtVerifiedby2.Text = Convert.ToString(objDs.Tables[2].Rows[0]["Verified BY 2"]);
                                    txtCompletedby.Text = Convert.ToString(objDs.Tables[2].Rows[0]["GRN User"]);
                                    ////lblStatusValue.Text = Convert.ToString(objDs.Tables[2].Rows[0]["GRN STS"]);
                                    grdGrnlist.Columns["PUR_EntryType"].Visible = false;
                                }
                                if (varGRNPurchaseFlag == 175) //from  Purchase
                                {
                                    string PurEntryType = Convert.ToString(objDs.Tables[0].Rows[0]["PUR_EntryType"]);
                                    if (PurEntryType == "54") // Against GRN
                                    {
                                        txtDGRNDate.Text = "GRN Date";
                                        txtDGRNNo.Text = "GRN No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[2].Rows[0]["GRN_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[2].Rows[0]["GRN_No"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[2].Rows[0]["GRN User"]);
                                        //lblStatusValue.Text = Convert.ToString(objDs.Tables[2].Rows[0]["GRN STS"]);
                                    }
                                    if (PurEntryType == "55") // Against PO
                                    {
                                        txtDGRNDate.Text = "PO Date";
                                        txtDGRNNo.Text = "PO No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[2].Rows[0]["PO_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[2].Rows[0]["PO_No"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[2].Rows[0]["PO User"]);
                                        //lblStatusValue.Text = Convert.ToString(objDs.Tables[2].Rows[0]["PO STS"]);
                                    }
                                    if (PurEntryType == "57") // Against DC
                                    {
                                        txtDGRNDate.Text = "DC Date";
                                        txtDGRNNo.Text = "DC No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[2].Rows[0]["DC_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[2].Rows[0]["DC_No"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[2].Rows[0]["DC User"]);
                                        //lblStatusValue.Text = Convert.ToString(objDs.Tables[2].Rows[0]["DC STS"]);
                                    }
                                    grdGrnlist.Columns["PUR_EntryType"].Visible = false;
                                }
                                if (varGRNPurchaseFlag == 187) //from  Purchase
                                {
                                    txtDGRNDate.Text = "DC Date";
                                    txtDGRNNo.Text = "DC No.";
                                    dpGRNDate.Text = Convert.ToString(objDs.Tables[2].Rows[0]["DC_Date"]);
                                    txtGRNNo.Text = Convert.ToString(objDs.Tables[2].Rows[0]["DC_No"]);
                                    txtCompletedby.Text = Convert.ToString(objDs.Tables[2].Rows[0]["DC User"]);
                                    //lblStatusValue.Text = Convert.ToString(objDs.Tables[2].Rows[0]["DC STS"]);
                                    grdGrnlist.Columns["PUR_EntryType"].Visible = false;
                                }
                                if (varEditFlag==1)
                                {
                                    grdGrnlist.Columns["GIPPR_GIPID"].Visible = false;
                                    grdGrnlist.Columns["GIPPR_DCPRID"].Visible = false;
                                    grdGrnlist.Columns["GIPPR_PURPRID"].Visible = false;
                                    grdGrnlist.Columns["Qty"].Visible = false;
                                    if(varStausId==46)
                                    {
                                        grdGrnlist.ReadOnly = true;
                                        btnSave.Enabled = false;
                                        chkCompleted.Enabled = false;
                                        txtRemark.Enabled = false;
                                        txttotalProduct.Enabled = false;
                                    }
                                    if (objDs.Tables[1].Rows.Count != 0)
                                    {
                                        txtRemark.Text = Convert.ToString(objDs.Tables[1].Rows[0]["GIP_Remarks"]);
                                    }
                                }
                                grdGrnlist.Columns["clmRemove"].DisplayIndex = 14;
                            }
                            else
                            {
                                lblNoRecordsFound.Visible = true;
                                lblNoRecordsFound.BringToFront();
                            }
                            */
                            udfnsupplierLoad(); 
                            if (varPurApproved == "1")
                            {
                                chkCompleted.Enabled = true;
                            }
                            else
                            {
                                chkCompleted.Enabled = false;
                            }
                            if(varStausId == 46)
                            {
                                chkCompleted.Enabled = false;
                            }
                        }
                    }
                    if(varEditFlag==1)
                    {
                        btnSelectAll.Visible = false;
                        btnUnselectAll.Visible = false;
                        grdInward.Columns["clmCheck"].Visible = false;
                        lblnarration.Location = new Point(12, 576);
                        txtRemark.Location = new Point(83, 580);
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
                if(varEditFlag==1)
                {
                    //grdGrnlist.Sort(grdGrnlist.Columns["clmOrder"], ListSortDirection.Ascending);
                    grdInward.Columns["clmMRP"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmMRP"].ReadOnly = true;
                    grdInward.Columns["clmInvoiceMRP"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmInvoiceMRP"].ReadOnly = true;
                    grdInward.Columns["clmExpiryDate"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmExpiryDate"].ReadOnly = true;
                    grdInward.Columns["clmInvoiceExpiryDate"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmInvoiceExpiryDate"].ReadOnly = true;
                    grdInward.Columns["clmBatchNo"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmBatchNo"].ReadOnly = true;
                    grdInward.Columns["clmInvoiceBatchNo"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmInvoiceBatchNo"].ReadOnly = true;
                    grdInward.Columns["clmRack"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmRack"].ReadOnly = true;
                    //grdInward.Columns["clmStatus"].DefaultCellStyle.BackColor = Color.LightGray;
                    //grdInward.Columns["clmStatus"].ReadOnly = true;
                }
                grdInward.ClearSelection();
                txttotalProduct.Text = Convert.ToString(grdInward.Rows.Count);
                txttotalProduct.Enabled = false;
                if (varStausId==46 && varPurchaseID==0)
                {
                    grdInward.ReadOnly = true;
                    grdInward.Columns["clmReceivedQty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmShopQty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmRack"].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if(varStausId!=45 && varPurchaseID!=0 && varPurchaseStatus!=49)
                {
                    grdInward.ReadOnly = true;
                    grdInward.Columns["clmReceivedQty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmShopQty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmRack"].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if(varStausId!=45 && varPurchaseID!=0 && varPurchaseStatus==49)
                {
                    grdInward.ReadOnly = true;
                    grdInward.Columns["clmReceivedQty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmShopQty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdInward.Columns["clmRack"].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }
        public void udfnStatus()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                //**** To call the function from SP ***************
                MR_Status objMR_Status = new MR_Status();
                objMR_Status.ViewType = 1;
                objDT = objdserv.udfnGetStatus(objMR_Status);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            var varComboBoxColoumn = (DataGridViewComboBoxColumn)grdInward.Columns["clmStatus"];
                            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                            varComboBoxColoumn.ValueMember = "ID";
                            varComboBoxColoumn.DisplayMember = "Status";
                            varComboBoxColoumn.DataSource = objDT.Tables[0];
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
                //pbSupplierpend = 0;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (varSupplierId!=0)
                {
                    int varReturnApplicable = 0, varReturnType = 0;
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(varSupplierId);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(varScheduleId);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(varConcernId);
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
                            lblSupplierOrderpolicy.Text = "Return Policy - " + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                            varReturnApplicable = Convert.ToInt16(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                            varReturnType = Convert.ToInt16(objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString());
                            lblReturn.Text = objDs.Tables[0].Rows[0]["RETURNAPPLICABLE"].ToString();
                        }
                        //if (objDs.Tables[1].Rows.Count > 0)
                        //{
                        //    if (objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString() != "")
                        //    { lblSalesmanName.Text = "Salesman Name - " + objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString(); }
                        //    if (objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString() != "")
                        //    { lblMobileNo.Text = "Mobile No. - " + objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString(); }
                        //    if (objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString() != "")
                        //    { lblWhatsAppNo.Text = "WhatsApp No. - " + objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString(); }
                        //}
                        //if (objDs.Tables[2].Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                        //    {
                        //        grdRepDetails.DataSource = objDs.Tables[2];
                        //        grdRepDetails.Columns["S.No."].Width = 40;
                        //        grdRepDetails.Columns["Rep Name"].Width = 150;
                        //        grdRepDetails.Columns["Brand"].Width = 150;
                        //        grdRepDetails.Columns["Phone No."].Width = 90;
                        //        grdRepDetails.Columns["WhatsApp No."].Width = 90;
                        //        grdRepDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //    }
                        //}
                    }
                }
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
                lblReturn.Text = "";
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
                MainForm.objINV_InwardQueueList_Remarks = new INV_InwardQueueList_Remarks();
                MainForm.objINV_InwardQueueList_Remarks.varID = varID;
                MainForm.objINV_InwardQueueList_Remarks.varRemarkFlag = varRemarkFlag;
                MainForm.objINV_InwardQueueList_Remarks.varFlag = varGRNPurchaseFlag;
                MainForm.objINV_InwardQueueList_Remarks.ShowDialog();
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
                if (grdInward.Focused)
                {
                    vargrid_flag = 1;
                }
                if (grdInward.Rows.Count > 0)
                {
                    if (grdInward.CurrentCell.Selected == true && grdInward.IsCurrentCellInEditMode == true)
                    {
                        vargrid_flag = 1;
                    }
                }
                if (vargrid_flag == 1)
                {
                    if (keyData == Keys.Enter || keyData == Keys.Right || keyData == Keys.Tab)
                    {
                        int icolumn = grdInward.CurrentCell.ColumnIndex;
                        int irow = grdInward.CurrentCell.RowIndex;
                        int i = irow;
                        int intsection = 0, intlvariant = 0;
                        intsection = grdInward.Columns.Count - 1;
                        intlvariant = grdInward.Columns.Count - 3;
                        if (intsection == icolumn)
                        {
                            grdInward.CurrentCell = grdInward[intsection, irow + 1];
                            icolumn = grdInward.Columns.Count - 1;//grdProDetails.CurrentCell.ColumnIndex;
                            irow = grdInward.CurrentCell.RowIndex;
                        }
                        else if (intlvariant == icolumn)
                        {
                        A: if (icolumn == grdInward.Columns.Count - 3)
                            {
                                //grdProDetails.Rows.Add();
                                if (irow < grdInward.Rows.Count - 1)
                                {
                                    grdInward.CurrentCell = grdInward[3, irow + 1];
                                    icolumn = grdInward.CurrentCell.ColumnIndex;
                                    irow = grdInward.CurrentCell.RowIndex;
                                    //goto A;
                                }
                                else
                                {
                                    grdInward.CurrentCell = grdInward[icolumn + 1, irow];
                                    if (grdInward.CurrentCell.ReadOnly == true)
                                    {
                                        icolumn++; goto A;
                                    }

                                }
                            }
                            else
                            {
                                grdInward.CurrentCell = grdInward[icolumn + 1, irow];
                                if (grdInward.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                            }
                        }
                        else
                        {
                        A: if (icolumn == grdInward.Columns.Count - 1)
                            {
                                //grdProDetails.Rows.Add();
                                if (irow < grdInward.Rows.Count - 1)
                                {
                                    grdInward.CurrentCell = grdInward["clmReceivedQty", irow + 1];
                                    icolumn = grdInward.CurrentCell.ColumnIndex;
                                    irow = grdInward.CurrentCell.RowIndex;
                                    //goto A;
                                }
                                else
                                {
                                    grdInward.CurrentCell = grdInward[icolumn + 1, irow];
                                    if (grdInward.CurrentCell.ReadOnly == true)
                                    {
                                        icolumn++; goto A;
                                    }
                                    if (irow < grdInward.Rows.Count - 1)
                                    {
                                        if (grdInward.CurrentCell.OwningColumn.Name == "clmRemove")
                                        {
                                            grdInward.CurrentCell = grdInward["clmReceivedQty", irow + 1];
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (grdInward[icolumn + 1, irow].Visible == false)
                                {
                                    { icolumn++; goto A; }
                                }
                                else
                                {
                                    grdInward.CurrentCell = grdInward[icolumn + 1, irow];
                                    if (grdInward.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                                }
                                if (irow < grdInward.Rows.Count - 1)
                                {
                                    if (grdInward.CurrentCell.OwningColumn.Name == "clmRemove")
                                    {
                                        grdInward.CurrentCell = grdInward["clmReceivedQty", irow + 1];
                                    }
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

                        vargrid_flag = 0;
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
