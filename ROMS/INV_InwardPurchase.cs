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
        public int varPurchaseID = 0, varID = 0, varGRNPurchaseFlag = 0, varCloseFlag = 0, varTypeID = 0, varRemarkFlag = 0, grid_flag = 0;
        public int varRemarkCount=0;
        public string varStatus = "";
        DataTable dtInwardPurchase = new DataTable();
        ToolTip tpInwardNo = new ToolTip();
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0, varPurchaseStatus = 0,varQuantityErr=0;
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
                grdGrnlist.ClearSelection();

                foreach (DataGridViewRow row in grdGrnlist.Rows)
                {
                    if (Convert.ToString(grdGrnlist.Rows[row.Index].Cells["clmConvertType"].Value) == "0")
                    {
                        grdGrnlist.Rows[row.Index].Cells[0].Value = null;
                        grdGrnlist.Rows[row.Index].Cells[0] = new DataGridViewTextBoxCell();
                        grdGrnlist.Rows[row.Index].Cells[0].Value = "";
                        grdGrnlist.Rows[row.Index].Cells[0].ReadOnly = true;
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
                dtInwardPurchase.TableName = "TRN_GoodsInward_Purchase_Products";
                dtInwardPurchase.Columns.Add("GIPPR_SNO", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_OrderID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_PRID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_UTID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ReceivedQty", typeof(decimal));
                dtInwardPurchase.Columns.Add("GIPPR_ShopQty", typeof(decimal));
                dtInwardPurchase.Columns.Add("GIPPR_RKID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ExpiryDate", typeof(string));
                dtInwardPurchase.Columns.Add("GIPPR_BatchNo", typeof(string));
                dtInwardPurchase.Columns.Add("GIPPR_MRP", typeof(decimal));
                dtInwardPurchase.Columns.Add("IDS", typeof(string)); 
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

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                {
                    grdGrnlist.Rows[i].Cells["clmCheck"].Value = true;
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
                for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                {
                    grdGrnlist.Rows[i].Cells["clmCheck"].Value = false;
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
                    switch (grdGrnlist.Columns[e.ColumnIndex].Name)
                    {
                        case "clmConvert":
                            try
                            {
                                DataGridView dgv = sender as DataGridView;

                                if (e.ColumnIndex != 0)
                                {
                                    string Sno =Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmSno"].Value);
                                    string PICode = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmPICode"].Value);
                                    //var PEName = dgv.Rows[e.RowIndex].Cells["Product Name in English"].Value;
                                    string PTName = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmProductName"].Value);
                                    string MRP = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmMRP"].Value);
                                    string ExpiryDate = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmExpiryDate"].Value);
                                    string BatchNo = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmBatchNo"].Value);
                                    string PendingQty = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmQty"].Value);
                                    string ReceivedQty = "";// Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmReceivedQty"].Value);
                                    string ShopQty = "";// Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmShopQty"].Value);
                                    string Unit = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmUnit"].Value);
                                    string Rack = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmRack"].Value);
                                    string PRID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmPRID"].Value);
                                    string SLID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmSLID"].Value);
                                    string RKID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmRKID"].Value);
                                    string UTID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmUTID"].Value);
                                    string GRN_DC_PUR_ID = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmID"].Value);
                                    string UT_Decimal = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmUTDecimal"].Value);
                                    string RackCount = Convert.ToString(dgv.Rows[e.RowIndex].Cells["clmRackCount"].Value);
                                    string ConvertType = "0";

                                    //SNO Order Here

                                    var varDuplicateProuct = from r in dtInwardPurchase.AsEnumerable()
                                                             where (r.Field<int>("GIPPR_SNO").Equals(Sno) &&
                                                             r.Field<int>("GIPPR_OrderID").Equals(0) &&
                                                             r.Field<int>("GIPPR_PRID").Equals(PRID) &&
                                                             r.Field<int>("GIPPR_UTID").Equals(UTID) &&
                                                             r.Field<decimal>("GIPPR_ReceivedQty").Equals(ReceivedQty) &&
                                                             r.Field<decimal>("GIPPR_ShopQty").Equals(ShopQty) &&
                                                             r.Field<int>("GIPPR_RKID").Equals(RKID) &&
                                                             r.Field<string>("GIPPR_ExpiryDate").Equals(ExpiryDate) &&
                                                             r.Field<string>("GIPPR_BatchNo").Equals(BatchNo) &&
                                                             r.Field<decimal>("GIPPR_MRP").Equals(MRP) &&
                                                             r.Field<string>("IDS").Equals(GRN_DC_PUR_ID) &&
                                                             r.Field<int>("GIPPR_SNO") != Convert.ToInt16(grdGrnlist.Rows[e.RowIndex].Cells["clmSno"].Value)
                                                             )group r by r.Field<int>("GIPPR_SNO") into g
                                                             select g.Key;

                                    var varRowsToUpdate = dtInwardPurchase.AsEnumerable().Where(r => r.Field<int>("GIPPR_SNO") == Convert.ToInt16(Sno));






                                    dtInwardPurchase.Rows.Add(Convert.ToInt32(Sno), 0, Convert.ToInt32(PRID), Convert.ToInt32(UTID), Convert.ToDecimal(ReceivedQty), Convert.ToDecimal(ShopQty), Convert.ToInt32(RKID), ExpiryDate, BatchNo, Convert.ToDecimal(MRP), GRN_DC_PUR_ID);

                                        grdGrnlist.Rows.Add(false, null, Sno, PICode, PTName, MRP, ExpiryDate, BatchNo,
                                     PendingQty, ReceivedQty, ShopQty, Unit, Rack, PRID, SLID, RKID, UTID,GRN_DC_PUR_ID,UT_Decimal,RackCount,ConvertType);
                                    

                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmConvert"];
                                    cell.Value= new System.Drawing.Bitmap(1, 1);

                                    DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                    GrdGrnlist_DataBindingComplete(grdGrnlist, args2);

                                }
                            }
                            catch (Exception ex)
                            {
                                objError = new DataError();
                                objError.WriteFile(ex);
                            }
                            break;
                        case "clmRemove":
                            if (Convert.ToString(grdGrnlist.CurrentRow.Cells["clmReceivedQty"].Value) == "")
                            {
                                grdGrnlist.Rows.RemoveAt(this.grdGrnlist.Rows[e.RowIndex].Index);
                            }
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    grdGrnlist.Rows.RemoveAt(this.grdGrnlist.Rows[e.RowIndex].Index);
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
            finally
            {
                //grdGrnlist.Sort(grdGrnlist.Columns["clmConvert"], ListSortDirection.Descending);
                grdGrnlist.Sort(grdGrnlist.Columns["clmSno"], ListSortDirection.Ascending);
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
                int ProCount = 0, InvalidQty = 0; varQuantityErr = 0;
                if (grdGrnlist.RowCount > 0)
                {
                    bool varErrorFlag = true;
                    if (txtInwardNo.Text == "")
                    {
                        epInwardPurchase.SetError(txtInwardNo, "Inward No. is empty.");
                        //txtDcNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpInwardNo.ShowAlways = true;
                        tpInwardNo.Show("DC No. is empty.", txtInwardNo, 5000);
                        varErrorFlag = false;
                    }
                    dtInwardPurchase.Rows.Clear();
                    for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                    {
                        decimal varQty = 0, varTotalQty = 0;
                        decimal varShopQty = 0,varReceivedQty=0,varRackID=0,varRackCount=0;
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value)=="")
                        { varShopQty = 0; }
                        else { varShopQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmShopQty"].Value); }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value) == "")
                        { varReceivedQty = 0; }
                        else { varReceivedQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value); }
                        
                        if (varEditFlag == 0)
                        {
                            if(Convert.ToBoolean(grdGrnlist.Rows[i].Cells[0].Value)==true)
                            {
                                ProCount = 1;
                                if(varGRNPurchaseFlag==3)
                                {
                                    varQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value) != "")
                                    {
                                        varReceivedQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value);
                                    }
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value)!="")
                                    {
                                        varShopQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmShopQty"].Value);
                                    }
                                    varTotalQty = varReceivedQty + varShopQty;
                                }
                                if(varGRNPurchaseFlag==2)
                                {
                                    varQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmQty"].Value);
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value) != "")
                                    {
                                        varReceivedQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmReceivedQty"].Value);
                                    }
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                    {
                                        varShopQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmShopQty"].Value);
                                    }
                                    varTotalQty = varReceivedQty + varShopQty;
                                }
                                if (varQty > varTotalQty || varQty == varTotalQty)
                                {
                                    dtInwardPurchase.Rows.Add(Convert.ToInt32(grdGrnlist.Rows[i].Cells["Product ID"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["Unit ID"].Value),
                                        Convert.ToInt32(varReceivedQty), varShopQty, Convert.ToInt32(grdGrnlist.Rows[i].Cells["Rack ID"].Value),
                                        Convert.ToString(grdGrnlist.Rows[i].Cells["Expiry Date"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["Batch No."].Value),
                                        Convert.ToDecimal(grdGrnlist.Rows[i].Cells["MRP"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["ID"].Value));
                                    grdGrnlist.Rows[i].Cells["Received Qty"].Style.BackColor = Color.PaleGreen;
                                    grdGrnlist.Rows[i].Cells["Shop Qty"].Style.BackColor = Color.PaleGreen;
                                }
                                else
                                {
                                    InvalidQty = 1;
                                    grdGrnlist.Rows[i].Cells["clmReceivedQty"].Style.BackColor = Color.Pink;
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShopQty"].Value) != "")
                                    {
                                        grdGrnlist.Rows[i].Cells["clmShopQty"].Style.BackColor = Color.Pink;
                                    }
                                    varErrorFlag = false;
                                }
                            }
                        }
                        if(varEditFlag==1)
                        {
                            //if (Convert.ToBoolean(grdGrnlist.Rows[i].Cells[0].Value) == true)
                            //{
                                ProCount = 1;
                                dtInwardPurchase.Rows.Add(Convert.ToInt32(grdGrnlist.Rows[i].Cells["Product ID"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["Unit ID"].Value),
                                Convert.ToInt32(varReceivedQty), varShopQty, Convert.ToInt32(grdGrnlist.Rows[i].Cells["Rack ID"].Value),
                                Convert.ToString(grdGrnlist.Rows[i].Cells["Expiry Date"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["Batch No."].Value),
                                Convert.ToDecimal(grdGrnlist.Rows[i].Cells["MRP"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["ID"].Value));
                            //}
                        }
                        if (Convert.ToBoolean(grdGrnlist.Rows[i].Cells[0].Value) == true)
                        {
                            if (Convert.ToInt32(varReceivedQty) <= 0)
                            {
                                grdGrnlist.Rows[i].Cells["Received Qty"].Style.BackColor = Color.LightPink;
                                //grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.LightPink;
                                InvalidQty = 1;
                                varErrorFlag = false;
                            }
                            else
                            {
                                if (InvalidQty != 1)
                                {
                                    grdGrnlist.Rows[i].Cells["Received Qty"].Style.BackColor = Color.PaleGreen;
                                    //grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                }
                            }
                        }
                        varRackID = Convert.ToInt32(grdGrnlist.Rows[i].Cells["Rack ID"].Value);
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["Rack"].Value) == "")
                        {
                            varRackID = 0;
                        }
                        else
                        {
                            varRackID = Convert.ToInt32(grdGrnlist.Rows[i].Cells["Rack ID"].Value);
                        }
                        varRackCount = Convert.ToInt32(grdGrnlist.Rows[i].Cells["RackCount"].Value);
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
                            grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.LightPink;
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
                            if (varGRNPurchaseFlag == 3 && Convert.ToBoolean(grdGrnlist.Rows[i].Cells["clmCheck"].Value)==true)   //From dc- Queue
                            {
                                decimal varDCQty = 0,  varRecqty = 0 , varShopqty = 0;
                               
                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["DC Qty"].Value) != "")
                                { varDCQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["DC Qty"].Value); }
                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["Received Qty"].Value) != "")
                                { varRecqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Received Qty"].Value); }
                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["Shop Qty"].Value) != "")
                                { varShopqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Shop Qty"].Value); }
                                if(varDCQty != varRecqty+ varShopqty)
                                {
                                    varQuantityErr++;
                                    grdGrnlist.Rows[i].Cells["DC Qty"].Style.BackColor = Color.LightPink;
                                    grdGrnlist.Rows[i].Cells["Received Qty"].Style.BackColor = Color.LightPink;
                                    grdGrnlist.Rows[i].Cells["Shop Qty"].Style.BackColor = Color.LightPink;
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
                            if (varGRNPurchaseFlag == 2 && Convert.ToBoolean(grdGrnlist.Rows[i].Cells["clmCheck"].Value) == true)   //From Purchase- Queue
                            {
                                decimal varInvoiceQty = 0, varRecqty = 0, varShopqty = 0;

                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["Invoice Qty"].Value) != "")
                                { varInvoiceQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Invoice Qty"].Value); }
                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["Received Qty"].Value) != "")
                                { varRecqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Received Qty"].Value); }
                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["Shop Qty"].Value) != "")
                                { varShopqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Shop Qty"].Value); }
                                if (varInvoiceQty != varRecqty + varShopqty)
                                {
                                    varQuantityErr++;
                                    grdGrnlist.Rows[i].Cells["Invoice Qty"].Style.BackColor = Color.LightPink;
                                    grdGrnlist.Rows[i].Cells["Received Qty"].Style.BackColor = Color.LightPink;
                                    grdGrnlist.Rows[i].Cells["Shop Qty"].Style.BackColor = Color.LightPink;
                                }
                            }
                            if(varEditFlag==1)
                            {
                                if (varGRNPurchaseFlag != 174)
                                {
                                    decimal varqty = 0, varRecqty = 0, varShopqty = 0;
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["Qty"].Value) != "")
                                    { varqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Qty"].Value); }
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["Received Qty"].Value) != "")
                                    { varRecqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Received Qty"].Value); }
                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["Shop Qty"].Value) != "")
                                    { varShopqty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Shop Qty"].Value); }

                                    if (varqty != varRecqty + varShopqty)
                                    {
                                        varQuantityErr++;
                                        grdGrnlist.Rows[i].Cells["Received Qty"].Style.BackColor = Color.LightPink;
                                        grdGrnlist.Rows[i].Cells["Shop Qty"].Style.BackColor = Color.LightPink;
                                    }
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
                    }
                    if (ProCount == 0)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(80);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrorFlag = false;
                    }
                    if(InvalidQty==1)
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
                    if (varErrorFlag == true && varQuantityErr==0)
                    {
                        int varStatusID = 0;
                        if (grdGrnlist.Rows.Count > 0)
                        {
                            if (varSupplierId != 0 && varLocationId != 0 )
                            {
                                string result = "", varorginator = "Inward from GRN"; 
                                int varviewtype = 0,varTypeID=0;
                                if(varEditFlag==0)
                                {
                                    varviewtype = 0;
                                    if (varGRNPurchaseFlag == 1)
                                    { varTypeID = 174;}
                                    else if (varGRNPurchaseFlag == 2)
                                    { varTypeID = 175; }
                                    else { varTypeID = 187; }
                                }
                                else if(varEditFlag==1)
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
                                objTRN_GoodsInward_Purchase.paraTRN_GoodsInward_Purchase_Products= dtInwardPurchase;
                                SPDataService objspdservice = new SPDataService();
                                result = objspdservice.udfnGoodsInwardPurchase(objTRN_GoodsInward_Purchase);
                                objspdservice.CloseConnection();
                                string[] varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    varCloseFlag=1;
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
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmRack")
                {
                    TextBox txtPurRack = e.Control as TextBox;
                    if (txtPurRack != null)
                    {
                        txtPurRack.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtPurRack.AutoCompleteCustomSource = AutoCompleteRackName(varLocationId); ;
                        txtPurRack.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmShopQty" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmReceivedQty")
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
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "Shop Qty" || grdGrnlist.CurrentCell.OwningColumn.Name == "Received Qty")
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
        private void GrdGrnlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdGrnlist.Rows.Count > 0)
                {
                    if (e.ColumnIndex == grdGrnlist.Columns["clmReceivedQty"].Index && e.RowIndex >= 0)
                    {
                        int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);
                        string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.CurrentRow.Cells["clmReceivedQty"].Value), varDecimal);
                        grdGrnlist.Rows[e.RowIndex].Cells["clmReceivedQty"].Value = Qty;
                    }
                    if (e.ColumnIndex == grdGrnlist.Columns["clmShopQty"].Index && e.RowIndex >= 0)
                    {
                        int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);
                        string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.CurrentRow.Cells["clmShopQty"].Value), varDecimal);
                        grdGrnlist.Rows[e.RowIndex].Cells["clmShopQty"].Value = Qty;
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
                if (e.ColumnIndex == grdGrnlist.Columns["clmRack"].Index && e.RowIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cellRkname = dataGridView.Rows[e.RowIndex].Cells["clmRack"];
                    DataGridViewCell cellRkid = dataGridView.Rows[e.RowIndex].Cells["clmRKID"];
                    if (Convert.ToString(varLocationId) != "-1")
                    {
                        string SelectedRackName = grdGrnlist.Rows[e.RowIndex].Cells["clmRack"].Value?.ToString();
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
                            string Quantity = "";
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                if (varGRNPurchaseFlag == 1)
                                {
                                    Quantity = "Pending Qty";
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
                                    grdGrnlist.Columns["clmQty"].HeaderText = Quantity;
                                }
                                if(varGRNPurchaseFlag==2)
                                {
                                    Quantity = "Invoice Qty";
                                    string PurEntryType = Convert.ToString(objDs.Tables[2].Rows[0]["PUR_EntryType"]);  // GET Purchase Entry Type
                                    if (PurEntryType == "54") // Against GRN
                                    {
                                        txtDGRNDate.Text = "GRN Date";
                                        txtDGRNNo.Text = "GRN No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_No"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN User"]);
                                    }
                                    if (PurEntryType == "55") // Against PO
                                    {
                                        txtDGRNDate.Text = "PO Date";
                                        txtDGRNNo.Text = "PO No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PO_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PO_No"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PO User"]);
                                    }
                                    if(PurEntryType=="56") // Direct Purchase
                                    {
                                        lblStatusValue.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR STS"]);
                                        txtCompletedby.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PUR User"]);
                                    }
                                    if (PurEntryType == "57") // Against DC
                                    {
                                        txtDGRNDate.Text = "DC Date";
                                        txtDGRNNo.Text = "DC No.";
                                        dpGRNDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC_Date"]);
                                        txtGRNNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC_No"]);
                                        textBox5.Text = "DC Created by";
                                        txtVerifiedby2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC User"]);
                                        textBox5.Visible = true;
                                        txtVerifiedby2.Visible = true;
                                        txtVerifiedby2.Size = new Size(123, 25);
                                        txtVerifiedby2.Font = new Font("Oswald Regular", 9.75f);
                                    }
                                    grdGrnlist.Columns["clmQty"].HeaderText = Quantity;
                                }
                                if (varGRNPurchaseFlag == 3)
                                {
                                    Quantity = "DC Qty";
                                    txtDGRNDate.Text = "DC Date";
                                    txtDGRNNo.Text = "DC No.";
                                    dpGRNDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC_Date"]);
                                    txtGRNNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC_No"]);
                                    txtCompletedby.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DC User"]);
                                    grdGrnlist.Columns["clmQty"].HeaderText = Quantity;
                                }
                            }
                            if (objDs.Tables[1].Rows.Count > 0)
                            {
                                for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                                {
                                    grdGrnlist.Rows.Add(false, null, Convert.ToString(objDs.Tables[1].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[1].Rows[i]["P.I Code"]), Convert.ToString(objDs.Tables[1].Rows[i]["Product Name in Tamil"]), Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["Batch No."]), Convert.ToString(objDs.Tables[1].Rows[i][Quantity]), Convert.ToString(objDs.Tables[1].Rows[i]["Received Qty"]), Convert.ToString(objDs.Tables[1].Rows[i]["Shop Qty"]),
                                         Convert.ToString(objDs.Tables[1].Rows[i]["Unit"]), Convert.ToString(objDs.Tables[1].Rows[i]["Rack"]), Convert.ToString(objDs.Tables[1].Rows[i]["Product ID"]), Convert.ToString(objDs.Tables[1].Rows[i]["Location ID"]), Convert.ToString(objDs.Tables[1].Rows[i]["Rack ID"]),
                                           Convert.ToString(objDs.Tables[1].Rows[i]["Unit ID"]), Convert.ToString(objDs.Tables[1].Rows[i]["ID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Decimal"]), Convert.ToString(objDs.Tables[1].Rows[i]["RackCount"]), Convert.ToString(objDs.Tables[1].Rows[i]["Convert"]), Convert.ToString(objDs.Tables[1].Rows[i]["S.No."]));
                                    decimal ReceivedQty = 0, ShopQty = 0;int OrderId = 0;
                                    if(Convert.ToString(objDs.Tables[1].Rows[i]["Received Qty"])!="")
                                    {
                                        ReceivedQty = Convert.ToDecimal(objDs.Tables[1].Rows[i]["Received Qty"]);
                                    }
                                    if (Convert.ToString(objDs.Tables[1].Rows[i]["Shop Qty"]) != "")
                                    {
                                        ShopQty = Convert.ToDecimal(objDs.Tables[1].Rows[i]["Shop Qty"]);
                                    }

                                    dtInwardPurchase.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["S.No."]), OrderId, Convert.ToInt32(objDs.Tables[1].Rows[i]["Product ID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["Unit ID"]), ReceivedQty,ShopQty, Convert.ToInt32(objDs.Tables[1].Rows[i]["Rack ID"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["Batch No."]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["ID"]));

                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmConvertType"].Value)== "1")
                                    {
                                        ((DataGridViewImageCell)grdGrnlist.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
                                    }

                                }

                                grdGrnlist.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["clmReceivedQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["clmShopQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdGrnlist.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
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
                        }
                    }
                    if(varEditFlag==1)
                    {
                        btnSelectAll.Visible = false;
                        btnUnselectAll.Visible = false;
                        grdGrnlist.Columns["clmCheck"].Visible = false;
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
                grdGrnlist.ClearSelection();
                txttotalProduct.Text = Convert.ToString(grdGrnlist.Rows.Count);
                txttotalProduct.Enabled = false;
                if (varStausId==46 && varPurchaseID==0)
                {
                    grdGrnlist.ReadOnly = true;
                    grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdGrnlist.Columns["Shop Qty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if(varStausId!=45 && varPurchaseID!=0 && varPurchaseStatus!=49)
                {
                    grdGrnlist.ReadOnly = true;
                    grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdGrnlist.Columns["Shop Qty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if(varStausId!=45 && varPurchaseID!=0 && varPurchaseStatus==49)
                {
                    grdGrnlist.ReadOnly = true;
                    grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdGrnlist.Columns["Shop Qty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.LightGray;
                }
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
                        intlvariant = grdGrnlist.Columns.Count - 3;
                        if (intsection == icolumn)
                        {
                            grdGrnlist.CurrentCell = grdGrnlist[intsection, irow + 1];
                            icolumn = grdGrnlist.Columns.Count - 1;//grdProDetails.CurrentCell.ColumnIndex;
                            irow = grdGrnlist.CurrentCell.RowIndex;
                        }
                        else if (intlvariant == icolumn)
                        {
                        A: if (icolumn == grdGrnlist.Columns.Count - 3)
                            {
                                //grdProDetails.Rows.Add();
                                if (irow < grdGrnlist.Rows.Count - 1)
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[3, irow + 1];
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
                                    grdGrnlist.CurrentCell = grdGrnlist["Received Qty", irow + 1];
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
                                if (grdGrnlist[icolumn + 1, irow].Visible == false)
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
