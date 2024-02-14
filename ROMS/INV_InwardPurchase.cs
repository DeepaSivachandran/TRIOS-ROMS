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
        public int varPurchaseID = 0, varID = 0, varGRNPurchaseFlag = 0, varCloseFlag = 0, varTypeID = 0, varRemarkFlag = 0;
        public int varRemarkCount=0;
        DataTable dtInwardPurchase = new DataTable();
        ToolTip tpInwardNo = new ToolTip();
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0;
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
                    ClearSupplier();
                    EditLoad();
                    udfnVocherno();
                    udfnUddtTable();
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
                        decimal varShopQty = 0,varReceivedty=0,varRackID=0,varRackCount=0;
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["Shop Qty"].Value)=="")
                        { varShopQty = 0; }
                        else { varShopQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Shop Qty"].Value); }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["Received Qty"].Value) == "")
                        { varReceivedty = 0; }
                        else { varReceivedty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["Received Qty"].Value); }
                        
                        if (varEditFlag == 0)
                        {
                            dtInwardPurchase.Rows.Add(Convert.ToInt32(grdGrnlist.Rows[i].Cells["Product ID"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["Unit ID"].Value),
                                Convert.ToInt32(varReceivedty), varShopQty, Convert.ToInt32(grdGrnlist.Rows[i].Cells["Rack ID"].Value), 
                                Convert.ToString(grdGrnlist.Rows[i].Cells["Expiry Date"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["Batch No."].Value), 
                                Convert.ToDecimal(grdGrnlist.Rows[i].Cells["MRP"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["ID"].Value));
                        }
                        if(varEditFlag==1)
                        {
                            dtInwardPurchase.Rows.Add(Convert.ToInt32(grdGrnlist.Rows[i].Cells["Product ID"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["Unit ID"].Value),
                                Convert.ToInt32(varReceivedty), varShopQty, Convert.ToInt32(grdGrnlist.Rows[i].Cells["Rack ID"].Value),
                                Convert.ToString(grdGrnlist.Rows[i].Cells["Expiry Date"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["Batch No."].Value),
                                Convert.ToDecimal(grdGrnlist.Rows[i].Cells["MRP"].Value), Convert.ToString(grdGrnlist.Rows[i].Cells["GIPPR_GIPID"].Value));
                        }
                        if (Convert.ToInt32(varReceivedty) <=0)
                        {
                            grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.LightPink;
                            varErrorFlag = false;
                        }
                        else
                        {
                            grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                        }
                        varRackID = Convert.ToInt32(grdGrnlist.Rows[i].Cells["Rack ID"].Value);
                        varRackCount = Convert.ToInt32(grdGrnlist.Rows[i].Cells["RackCount"].Value);
                        if (varRackCount != 0)
                        {
                            if(Convert.ToString(grdGrnlist.Rows[i].Cells["Rack"].Value)=="")
                            {
                                grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.LightPink;
                                varErrorFlag = false;
                            }
                            else
                            {
                                grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.PaleGreen;
                            }
                        }
                        if (varRackID == -1)
                        {
                            grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.LightPink;
                            varErrorFlag = false;
                        }
                        
                    }
                    if (varErrorFlag == true )
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
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "Rack")
                {
                    TextBox txtPurRack = e.Control as TextBox;
                    if (txtPurRack != null)
                    {
                        txtPurRack.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtPurRack.AutoCompleteCustomSource = AutoCompleteRackName(varLocationId); ;
                        txtPurRack.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "Shop Qty" || grdGrnlist.CurrentCell.OwningColumn.Name == "Received Qty")
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
                    if (e.ColumnIndex == grdGrnlist.Columns["Received Qty"].Index && e.RowIndex >= 0)
                    {
                        int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["UT_Decimal"].Value);
                        string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.CurrentRow.Cells["Received Qty"].Value), varDecimal);
                        grdGrnlist.Rows[e.RowIndex].Cells["Received Qty"].Value = Qty;
                    }
                    if (e.ColumnIndex == grdGrnlist.Columns["Shop Qty"].Index && e.RowIndex >= 0)
                    {
                        int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["UT_Decimal"].Value);
                        string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.CurrentRow.Cells["Shop Qty"].Value), varDecimal);
                        grdGrnlist.Rows[e.RowIndex].Cells["Shop Qty"].Value = Qty;
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
                if (e.ColumnIndex == grdGrnlist.Columns["Rack"].Index && e.RowIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cellRkname = dataGridView.Rows[e.RowIndex].Cells["Rack"];
                    DataGridViewCell cellRkid = dataGridView.Rows[e.RowIndex].Cells["Rack ID"];
                    if (Convert.ToString(varLocationId) != "-1")
                    {
                        string SelectedRackName = grdGrnlist.Rows[e.RowIndex].Cells["Rack"].Value?.ToString();
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
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                grdGrnlist.Rows.Clear();
                                grdGrnlist.DataSource = objDs.Tables[0];
                                grdGrnlist.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdGrnlist.Columns["MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                
                                grdGrnlist.Columns["Received Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["Shop Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["Product Name in English"].Width = 300;
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
                                grdGrnlist.Columns["Product ID"].Visible = false;
                                grdGrnlist.Columns["Unit ID"].Visible = false;
                                grdGrnlist.Columns["Location ID"].Visible = false;
                                grdGrnlist.Columns["Rack ID"].Visible = false;
                                grdGrnlist.Columns["RackCount"].Visible = false;
                                grdGrnlist.Columns["ID"].Visible = false;
                                grdGrnlist.Columns["UT_Decimal"].Visible = false;
                                grdGrnlist.Columns["U_Name"].Visible = false;
                                if (varGRNPurchaseFlag == 4) //from Purchase DC
                                {
                                    txtDGRNDate.Text = "DC Date";
                                    txtDGRNNo.Text = "DC No.";
                                    grdGrnlist.Columns["DC Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdGrnlist.Columns["DC Qty"].Width = 100;
                                    grdGrnlist.Columns["DC Qty"].ReadOnly = true;
                                }
                                if (varGRNPurchaseFlag == 2) //from  purchase
                                {
                                    grdGrnlist.Columns["Invoice Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdGrnlist.Columns["Invoice Qty"].Width = 120;
                                    grdGrnlist.Columns["Invoice Qty"].ReadOnly = true;
                                }
                                if (varGRNPurchaseFlag == 1) //from  grn
                                {
                                    textBox4.Visible = true;
                                    txtVerifiedby1.Visible = true;
                                    textBox5.Visible = true;
                                    txtVerifiedby2.Visible = true;
                                    txtVerifiedby1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Verified BY 1"]);
                                    txtVerifiedby2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Verified BY 2"]);
                                    txtCompletedby.Text = Convert.ToString(objDs.Tables[0].Rows[0]["U_Name"]);
                                    grdGrnlist.Columns["Invoice Received Qty"].Visible = false;
                                    grdGrnlist.Columns["Verified BY 1"].Visible = false;
                                    grdGrnlist.Columns["Verified BY 2"].Visible = false;
                                }
                                else
                                {
                                    textBox4.Visible = false;
                                    txtVerifiedby1.Visible = false;
                                    textBox5.Visible = false;
                                    txtVerifiedby2.Visible = false;
                                }
                                //if (varEditFlag==0)
                                //{
                                //    grdGrnlist.Columns["GRNPR_PRID"].Visible = false;
                                //    grdGrnlist.Columns["GRNPR_UTID"].Visible = false;
                                //    grdGrnlist.Columns["PR_PUR_SLID"].Visible = false;
                                //    grdGrnlist.Columns["PR_PUR_RKID"].Visible = false;
                                //    grdGrnlist.Columns["Invoice Received Qty"].Visible = false;
                                //    grdGrnlist.Columns["GRNPRID"].Visible = false;
                                //}
                                //else
                                if (varEditFlag==1)
                                {
                                    //grdGrnlist.Columns["Invoice Received Qty"].Visible = false;
                                    grdGrnlist.Columns["GIPPR_GIPID"].Visible = false;
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
                            }
                            else
                            {
                                lblNoRecordsFound.Visible = true;
                                lblNoRecordsFound.BringToFront();
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
                grdGrnlist.ClearSelection();
                txttotalProduct.Text = Convert.ToString(grdGrnlist.Rows.Count);
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

    }
}
