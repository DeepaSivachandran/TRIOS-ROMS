using Irony.Parsing;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class INV_StockRequest : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtStock = new DataTable(); 
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpGenerealBill = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpStockQty = new ToolTip();
        private ToolTip tpRequiredQty = new ToolTip();
        private ToolTip tpType = new ToolTip();
        private ToolTip tpProductType = new ToolTip();
        private ToolTip tpBillNo = new ToolTip();
        private ToolTip tpLocation = new ToolTip();


        public DataTable dtLocation = new DataTable();
        public DataTable dtCmbLocation = new DataTable();

        public string VarAdd = "0";
        public int pbShopFlag = 0;
        public string varProducts = "";
        public string varProductName = ""; 
        public int varModifiedFlag = 0;
        public int varStockRequestID = 0;
        public int varID = 0;
        public int varDecimal = 0;
        public int varStatus = 0, varMainStatus=0;
        public int varSLID = 0;
        public int varRKID = 0;
        public int varClose = 0, varCloseFlag = 0, varDateChange = 0, varUpDownKey=0,pbDeleteFlag=0;
        public string varErrQty = "0";
        public string SSRUpdatevalue = "";
        public bool VarSearchFlag = true;
        bool varVoucherSkip = false;
        byte[] varobjBarCodeByte;
        List<int> varProductsIDs = new List<int>();
        public int varRackGroupID = 0, varProductTypeID = 0, varTellerID = 0, pbscreenflag = 0, pbID = 0;
        public int pbPrintStatus=0;//print pending
        public INV_StockRequest()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Supplier = new CP_Supplier();
                MainForm.objCP_Supplier.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void INV_StockRequest_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm objMainForm = new MainForm();
                objMainForm.udfnGetDefaultCompany();
                dtStock.TableName = "TRN_StockRequest_Details";
                dtStock.Columns.Add("SRQ_PRID", typeof(int));
                dtStock.Columns.Add("SRQ_SLID", typeof(int));
                dtStock.Columns.Add("SRQ_RKID", typeof(int));
                dtStock.Columns.Add("SRQ_RequestedQty", typeof(decimal));
                dtStock.Columns.Add("SRQ_ReceivedQty", typeof(decimal));
                udfnDropdownLoad(); 
                dpDate.MinDate = MainForm.pbFYStartDate;
                dpDate.MaxDate = MainForm.pbCurrentDate;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID=11 AND STSID IN(28,29)", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                if(pbscreenflag==1)
                {
                    tspStockRequest.Text = "Shop Stock Request Queue";
                    grdStockRequest.Columns["clmRequiredQty"].HeaderText = "Issue Qty";
                }
                if (btnSave.Text == "Save")
                {
                    if (varStockRequestID == 0)
                    {
                        //udfnTransferNo();
                        dpDate.Value = MainForm.pbCurrentDate;
                        cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                        grdStockRequest.Columns["clmStatus"].Visible = false;
                    }
                    else
                    {
                        udfnEdit();
                    }
                }
                else
                {
                    //chkRackGroup.Enabled = false;
                    udfnEdit();
                }
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    if (varStatus != 29)
                    {
                        this.ActiveControl = txtTeller;
                    }
                }
                if (varStatus != 28 && varStatus != 47 && varStatus != 0)
                {
                    txtRemarks.Enabled = false;
                    this.ActiveControl = btnClose;
                }
                if (pbscreenflag == 1)
                {
                    cmbStatus.Visible = false;
                    btnPrint.Visible = true;
                    chbCompleted.Visible = true;
                    btnSave.Enabled = false;
                    btnSave.Text = "Save";
                }
                else
                {
                    btnPrint.Visible = false;
                    chbCompleted.Visible = false;
                }
                udfnProductCount();
                //udfnAddDuplicateSNoColumn();
                udfnStockRequestSearchGridHead();
                DGV_SearchStock.ScrollBars = ScrollBars.Vertical;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnAddDuplicateSNoColumn()
        { 
            try
            {
                // Avoid duplicate adding
                if (!grdStockRequest.Columns.Contains("clmSnoDup"))
                {
                    DataGridViewTextBoxColumn dupCol =
                        new DataGridViewTextBoxColumn();

                    dupCol.Name = "clmSnoDup";
                    dupCol.HeaderText = "S.No.";
                    dupCol.Width = 50;
                    dupCol.ReadOnly = true;
                    dupCol.Visible = true;

                    grdStockRequest.Columns.Insert(grdStockRequest.Columns["clmRequiredQty"].Index,  dupCol );
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
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 45;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.ParaProductsCode = "0";
                SPDataService objspdservice = new SPDataService();
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblProductCount.Text ="(" + Convert.ToString(objDs.Tables[0].Rows.Count) + ")";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefaultSearchGrid()
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
        public void udfnDropdownLoad()
        {
            try
            {
                cmbConcern.Focus();
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (0,172) AND MSTID<>0  ORDER BY MST_OrderID ASC", "MST_DisplayText,MSTID", cmbRequestType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID in (0,171) AND MSTID<>0 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbProductType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("MR_RackGroup", "RKGID NOT IN(0) ORDER BY RKG_SINO", "RKG_Name,RKGID", cmbRackGroup, "", "RKG_Name", "RKGID"); 
                objDataBind = null;
                udfnRackGroupEnable();
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
                if (varStockRequestID != 0)
                {
                    if (pbscreenflag == 1) { varStockRequestID = pbID; }
                    btnSave.Text = "Update";
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    DataTable dtStockLocation = new DataTable();
                    Model.TRN_StockRequest objTRNG_StockRequest = new Model.TRN_StockRequest();
                    objTRNG_StockRequest.ViewType = 1;
                    objTRNG_StockRequest.paraStockRequestID = varStockRequestID;
                    objTRNG_StockRequest.paraFlag = pbscreenflag;
                    objDS = objspservice.udfnStockRequestList(objTRNG_StockRequest);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[1].Rows.Count > 0)
                        {
                            dpDate.Text = objDS.Tables[1].Rows[0]["Request Date"].ToString().Replace("''", "'");
                            txtRequestNo.Text = objDS.Tables[1].Rows[0]["Request No."].ToString().Replace("''", "'");
                            txtRemarks.Text = objDS.Tables[1].Rows[0]["Remarks"].ToString().Replace("''", "'");
                            cmbConcern.SelectedValue =Convert.ToInt16(objDS.Tables[1].Rows[0]["ConcernID"]);
                            cmbRequestType.SelectedValue = Convert.ToInt16(objDS.Tables[1].Rows[0]["SR_RequestTypeID"]);
                            cmbRackGroup.SelectedValue = Convert.ToInt16(objDS.Tables[1].Rows[0]["SR_RKGID"]);
                            cmbProductType.SelectedValue = Convert.ToInt16(objDS.Tables[1].Rows[0]["SR_ProductTypeID"]);
                            txtGeneralBillNo.Text = Convert.ToString(objDS.Tables[1].Rows[0]["BillNo"]);
                            varTellerID = Convert.ToInt16(objDS.Tables[1].Rows[0]["SR_TellerID"]);
                            txtTeller.Text = Convert.ToString(objDS.Tables[1].Rows[0]["Teller"]);

                            if (Convert.ToInt16(objDS.Tables[1].Rows[0]["SR_LoadByRackGroup"]) == 0)
                            {
                                chkRackGroup.Checked = false;
                            }
                            else { chkRackGroup.Checked = true; chkRackGroup.Enabled = false; }
                            lvVerified.Visible = false;
                        }
                        if (varStatus == 28 && pbDeleteFlag == 0)
                        {
                            if (objDS.Tables[2].Rows.Count > 0)
                            { dtLocation = objDS.Tables[2]; }
                        }
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            grdStockRequest.Rows.Clear();
                            dtStock.Rows.Clear();
                            int shopFlag = 0, PRID=0,SLID=0;
                            for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                            {
                                decimal requestedQty = 0;

                                decimal.TryParse(
                                    Convert.ToString(objDS.Tables[0].Rows[i]["SRQD_RequestedQty"]),
                                    out requestedQty
                                );
                                grdStockRequest.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[0].Rows[i]["PR_PICode"]), Convert.ToString(objDS.Tables[0].Rows[i]["PR_TName"]), Convert.ToString(objDS.Tables[0].Rows[i]["Location"]), Convert.ToString(objDS.Tables[0].Rows[i]["RKG_Name"]), Convert.ToString(objDS.Tables[0].Rows[i]["RK_ShortName"]), 
                                    Convert.ToString(objDS.Tables[0].Rows[i]["EMP_Name"]), Convert.ToDecimal(objDS.Tables[0].Rows[i]["STOCK"]), Convert.ToString(objDS.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[0].Rows[i]["SRQD_RequestedQty"]), Convert.ToString(objDS.Tables[0].Rows[i]["UT_Symbol"]), Convert.ToString(objDS.Tables[0].Rows[i]["Status"]),
                                    Convert.ToString(objDS.Tables[0].Rows[i]["UT_Decimal"]), Convert.ToString(objDS.Tables[0].Rows[i]["SRQD_PRID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Status ID"]),Convert.ToString(objDS.Tables[0].Rows[i]["Location"]), Convert.ToInt16(objDS.Tables[0].Rows[i]["ShopFlag"]));
                                
                                dtStock.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["SRQD_PRID"]), Convert.ToInt16(objDS.Tables[0].Rows[i]["SRQD_SLID"]),  Convert.ToInt16(objDS.Tables[0].Rows[i]["SRQD_RKID"]), requestedQty, 0);

                                varProductsIDs.Add(Convert.ToInt32(objDS.Tables[0].Rows[i]["SRQD_PRID"]));

                                shopFlag = Convert.ToInt16(objDS.Tables[0].Rows[i]["ShopFlag"]);
                                PRID = Convert.ToInt16(objDS.Tables[0].Rows[i]["SRQD_PRID"]);
                                SLID = Convert.ToInt16(objDS.Tables[0].Rows[i]["SRQD_SLID"]);

                                if (varStatus == 28 && pbDeleteFlag == 0)
                                { 
                                    if (shopFlag == 1)
                                    {
                                        var rows = dtLocation.AsEnumerable().Where(x => x.Field<int>("PRID") == PRID);
                                        dtStockLocation = dtLocation.Clone();
                                        if (rows.Any())
                                        {
                                            dtStockLocation = rows.CopyToDataTable();
                                        }
                                        DataGridViewComboBoxCell cmb = (DataGridViewComboBoxCell)grdStockRequest.Rows[i].Cells["clmLoc"];

                                        cmb.DisplayMember = "Location";
                                        cmb.ValueMember = "LocationID";
                                        cmb.DataSource = dtStockLocation;
                                        grdStockRequest.Rows[i].Cells["clmLoc"].Value = SLID;
                                    }
                                    else
                                    {
                                        DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
                                        textBoxCell.Value = ""; // or any string value
                                        grdStockRequest.Rows[i].Cells["clmLoc"] = textBoxCell;
                                        grdStockRequest.Rows[i].Cells["clmLoc"].ReadOnly = true;
                                        grdStockRequest.Rows[i].Cells["clmLoc"].Style.BackColor = Color.LightGray;
                                    }
                                }

                            }
                            for (int j = 0; j < grdStockRequest.Rows.Count; j++)
                            {
                                if (varProducts == "")
                                {
                                    varProducts = Convert.ToString(grdStockRequest.Rows[j].Cells["clmPRID"].Value);
                                }
                                else
                                {
                                    varProducts = varProducts + ',' + Convert.ToString(grdStockRequest.Rows[j].Cells["clmPRID"].Value);
                                }
                            }
                            ((DataGridViewTextBoxColumn)grdStockRequest.Columns["clmRequiredQty"]).MaxInputLength = 8;
                            grdStockRequest.Columns["clmSno"].Width = 50;
                            //grdStockRequest.Columns["clmRequiredQty"].Width = 100;
                            grdStockRequest.Columns["clmIncharge"].Width = 250;
                            grdStockRequest.Columns["clmStockQty"].Width = 100;
                            grdStockRequest.Columns["clmRequiredQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockRequest.Columns["clmStockQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockRequest.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockRequest.Columns["clmSnoDup"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            if (varStatus != 28 || pbDeleteFlag==1)
                            {
                                txtProductNamePICode.Enabled = false;
                                this.ActiveControl = txtRemarks;
                                txtRequiredQty.Enabled = false;
                                btnAdd.Enabled = false;
                                cmbStatus.Enabled = false;
                                DGV_SearchStock.ReadOnly = true;
                                grdStockRequest.ReadOnly = true;
                                grdStockRequest.Columns["clmRemove"].Visible = false;
                                grdStockRequest.Columns["clmLoc"].Visible = false;
                                cmbStatus.SelectedValue = 29;
                                DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                GrdStockRequest_DataBindingComplete(grdStockRequest, args);
                                tpProduct.Active = false;
                                errStockRequest.Clear();
                            }
                            else
                            {
                                cmbStatus.SelectedValue = 28;
                            }
                        }
                    }
                    cmbConcern.Enabled = false;
                    dpDate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdStockRequest.ClearSelection();
                txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
                txttotalUnits.Text = grdStockRequest.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["clmRequiredQty"].Value != null
                             && decimal.TryParse(
                                    r.Cells["clmRequiredQty"].Value.ToString(),
                                    out _))
                    .Sum(r => Convert.ToDecimal(r.Cells["clmRequiredQty"].Value))
                    .ToString();
                if (varMainStatus==48 || varMainStatus==29 || pbDeleteFlag==1)
                {
                    btnSave.Enabled = false;
                    txtTeller.Enabled = false;
                    cmbProductType.Enabled = false;
                    cmbRackGroup.Enabled = false;
                    cmbRequestType.Enabled = false;
                    chkRackGroup.Enabled=false;
                }
            }
        }
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmRequiredQty")
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
        private void INV_StockRequest_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose.Focus();
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    dgv2.Rows[rowIndex].Cells[i].Value = "";
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        } 
        public void udfnscrollVisible(DataGridView DGV,DataGridView grdGroupList)
        {
            try
            {
                var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
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
                udfnclose();
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
                    if (varModifiedFlag == 1)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
                            MainForm.objINV_StockRequestList.udfnList();
                        }
                        else
                        { btnSave.Focus(); }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
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

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRequestType.Focus();
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

        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errStockRequest.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    errStockRequest.Clear();
                    cmbConcern.BackColor = Color.White;
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
                grdStockRequest.Rows.Clear();
                dtStock.Rows.Clear();
                varProducts = "";
                txttotalitem.Text = "";
                txttotalUnits.Text = "";
                grdGodownStock.Rows.Clear();
                if (btnSave.Text == "Save")
                {
                    txtProductNamePICode.Text = "";
                    txtRequiredQty.Text = "";
                    txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
                    txttotalUnits.Text = grdStockRequest.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["clmRequiredQty"].Value != null
                             && decimal.TryParse(
                                    r.Cells["clmRequiredQty"].Value.ToString(),
                                    out _))
                    .Sum(r => Convert.ToDecimal(r.Cells["clmRequiredQty"].Value))
                    .ToString();
                }
                varDateChange = 0;
                udfnTransferNo();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTransferNo()
        {
            if (varStockRequestID == 0)
            {
                if (btnSave.Text == "Save")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpDate.Text + "',103)");
                        varResult = objspdservice.udfngetVoucherNo("43", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] varvalue = varResult.Split('~');
                        if (varResult != "")
                        {
                            txtRequestNo.Text = varvalue[0];
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
                        txtRequestNo.Text = "";
                    }
                }
            }
        }
        public void udfnvoucheradd()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(75);
                objDServ.CloseConnection();
                txtRequestNo.Text = "";
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
                    varCloseFlag = 1;
                }
                else { varVoucherSkip = true; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductNamePICode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductNamePICode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductNamePICode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                /*
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvProduct.Items.Count == 0 || txtProductNamePICode.Text == "")
                    {
                        txtRequiredQty.Focus();
                        lvProduct.Visible = false;
                    }
                    else
                    {
                        lvProduct.Focus();
                    }
                    if (lvProduct.Items.Count > 0)
                    {
                        lvProduct.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtRequiredQty.Focus();
                }
                */
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblDEProductName.Text = "Search by P.I Code (F11)";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblDEProductName.Text = "Search by Product Name (F11)";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    txtRequiredQty.Focus();
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
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnProductEvent();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductNamePICode.Focus();
                    //txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
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
                        txtRequiredQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductNamePICode_Leave(object sender, EventArgs e)
        {
            try
            {
                errStockRequest.Clear();
                txtProductNamePICode.BackColor = Color.White;
                /*
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    errStockRequest.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductNamePICode, 5000);
                    lblProduct.Text = "0";
                }
                else
                {
                    errStockRequest.Clear();
                    txtProductNamePICode.BackColor = Color.White;
                }
                */
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductNamePICode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    txtStockQty.Text = "";
                    txtRequiredQty.Text = "";
                    lblProductTamil.Text = "";
                    string PRID = "0";
                    grdGodownStock.Rows.Clear();
                    //lvProduct.Items.Clear();
                    if (varProducts != "")
                    {
                        var strings1 = varProductsIDs.Select(xx => xx);
                        PRID = (string.Join(",", strings1));
                    }
                    if (txtProductNamePICode.Text.Length > 0)
                    {
                        DataSet objDs = new DataSet();
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 45;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.ParaProductsCode = PRID;
                        SPDataService objspdservice = new SPDataService();
                        if (VarSearchFlag == true)
                        {
                            objMR_Product.paraPicode = txtProductNamePICode.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraProductName = txtProductNamePICode.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {   /*
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["UT_Decimal"].ToString(),objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvProduct.Items.Add(objList);
                                }
                                lvProduct.Visible = true;
                                lvProduct.BringToFront();
                                lvProduct.Columns[0].Width = 150;
                                lvProduct.Columns[1].Width = 0;
                                lvProduct.Columns[2].Width = 0;
                                lvProduct.Columns[3].Width = 60;
                                lvProduct.Columns[4].Width = 0;
                                lvProduct.Columns[5].Width = 0;
                                //lvProduct.Columns[6].Width = 0;
                                //lvProduct.Columns[7].Width = 0;
                                if (VarSearchFlag == false)
                                {
                                    lvProduct.Columns[1].Width = 320;
                                    lvProduct.Columns[2].Width = 0;
                                }
                                else
                                {
                                    lvProduct.Columns[1].Width = 0;
                                    lvProduct.Columns[2].Width = 320;
                                }
                                */
                                    DGV_FilterProduct.BringToFront();
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Visible = true;
                                    DGV_FilterProduct.Columns["SLID"].Visible = false;
                                    DGV_FilterProduct.Columns["RKID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["ShopFlag"].Visible = false;
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
                                    DGV_FilterProduct.Columns["R.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                                    DGV_FilterProduct.DataSource = null;
                                    DGV_FilterProduct.Visible = false;
                                    //lvProduct.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.DataSource = null;
                                DGV_FilterProduct.Visible = false;
                                //lvProduct.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.DataSource = null;
                            DGV_FilterProduct.Visible = false;
                            //lvProduct.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.DataSource = null;
                        DGV_FilterProduct.Visible = false;
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

        private void LvProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //udfnProductEvent();
                //txtRequiredQty.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnProductEvent();
                //    txtRequiredQty.Focus();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductEvent()
        {
            try
            {
                if (txtProductNamePICode.Text != "")    
                {   /*
                    ListViewItem selectedItem = lvProduct.SelectedItems[0];
                    varProductName = selectedItem.SubItems[2].Text;
                    txtProductNamePICode.Text = selectedItem.SubItems[1].Text;
                    lblUnit.Text = selectedItem.SubItems[3].Text;
                    varDecimal = Convert.ToInt32(selectedItem.SubItems[4].Text);
                    lblProduct.Text = selectedItem.SubItems[5].Text;
                    varSLID =Convert.ToInt32(selectedItem.SubItems[6].Text);
                    varRKID = Convert.ToInt32(selectedItem.SubItems[7].Text);
                    */
                    varProductName = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    lblProductTamil.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    txtStockUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    txtReqUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varSLID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["SLID"].Value.ToString());
                    varRKID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["RKID"].Value.ToString());
                    txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    pbShopFlag = Convert.ToInt16(DGV_FilterProduct.SelectedRows[0].Cells["ShopFlag"].Value);
                    VarAdd = "1";
                    udfnStockLoad();
                    udfnlocation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { 
                txtStockQty.BackColor = SystemColors.Control;
                txtRequiredQty.BackColor = SystemColors.Control;
            }
        }
        public void udfnlocation()
        {
            try
            {
                if(pbShopFlag == 1)
                {
                    cmbLocation.Enabled = true;
                    SPDataService objdserv = new SPDataService();
                    DataSet objDT = new DataSet(); 
                    TRN_StockRequest objTRN_StockRequest = new TRN_StockRequest();
                    objTRN_StockRequest.ViewType = 11;
                    objTRN_StockRequest.paraPRID = Convert.ToInt16(lblProduct.Text);
                    SPDataService objdspservice = new SPDataService();
                    objDT = objdspservice.udfnStockRequestList(objTRN_StockRequest);
                    cmbLocation.DataSource = null; 
                    if (objDT != null)
                    {
                        if (objDT.Tables.Count > 0)
                        {
                            if (objDT.Tables[0].Rows.Count > 0)
                            {
                                cmbLocation.ValueMember = "LocationID";
                                cmbLocation.DisplayMember = "Location";
                                cmbLocation.DataSource = objDT.Tables[0];
                                dtCmbLocation = objDT.Tables[0];
                            }
                        }
                    }
                }
                else
                {
                    cmbLocation.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnStockLoad()
        {
            try
            {
                if(VarAdd=="1")
                {
                    DataSet objDS = new DataSet();
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 43;
                    objMR_Product.ParaProductCode = Convert.ToInt32(lblProduct.Text);
                    SPDataService objspservice = new SPDataService();
                    objDS = objspservice.udfnproductmasterlist(objMR_Product);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtStockQty.Text = objDS.Tables[0].Rows[0]["Stock"].ToString().Replace("''", "'");
                            txtStockQty.BackColor = SystemColors.Control;
                        }
                        if (objDS.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                            {
                                grdGodownStock.Rows.Add(Convert.ToString(objDS.Tables[1].Rows[i]["SL_ShortName"]), Convert.ToString(objDS.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDS.Tables[1].Rows[i]["STK_Qty"]));
                                varModifiedFlag = 1;
                            }
                            grdGodownStock.ClearSelection();
                        }
                    }
                }
                if (VarAdd == "2")
                {
                    DataSet objDs = new DataSet();
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 55;
                    objMR_Product.ParaProductCode = Convert.ToInt32(lblProduct.Text);
                    SPDataService objdspservice = new SPDataService();
                    objDs = objdspservice.udfnproductmasterlist(objMR_Product);
                    objdspservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (txtRequiredQty.Text != "")
                        {
                            string Qty = objValidation.udfnDecimal((txtRequiredQty.Text).Trim(), varDecimal);
                            txtRequiredQty.Text = Qty;
                        }
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            int slid = 0;string locationName = "";
                            if(pbShopFlag==1)
                            {
                                slid = Convert.ToInt32(cmbLocation.SelectedValue);
                                locationName = cmbLocation.Text;
                            }
                            else
                            {
                                slid = Convert.ToInt32(objDs.Tables[0].Rows[0]["SLID"]);
                            }
                                int rowIndex = grdStockRequest.Rows.Add(grdStockRequest.Rows.Count + 1, Convert.ToString(objDs.Tables[0].Rows[0]["PR_PICode"]),
                                    Convert.ToString(objDs.Tables[0].Rows[0]["PR_TName"]),locationName,
                                    Convert.ToString(objDs.Tables[0].Rows[0]["RKG_Name"]), Convert.ToString(objDs.Tables[0].Rows[0]["RK_ShortName"]),
                                    Convert.ToString(objDs.Tables[0].Rows[0]["EMP_Name"]), Convert.ToString(txtStockQty.Text), grdStockRequest.Rows.Count + 1,
                                    Convert.ToString(txtRequiredQty.Text), Convert.ToString(objDs.Tables[0].Rows[0]["UT_Symbol"]), "", Convert.ToString(objDs.Tables[0].Rows[0]["UT_Decimal"]), Convert.ToString(lblProduct.Text), 0, slid, pbShopFlag);
                            
                            dtStock.Rows.Add(Convert.ToInt32(lblProduct.Text), Convert.ToInt16(objDs.Tables[0].Rows[0]["SLID"]), Convert.ToInt16(objDs.Tables[0].Rows[0]["RKID"]), Convert.ToString(txtRequiredQty.Text), 0); 

                            if (pbShopFlag == 1)
                            { 
                                DataGridViewComboBoxCell cmb = (DataGridViewComboBoxCell)grdStockRequest.Rows[rowIndex].Cells["clmLoc"]; 
                                cmb.DisplayMember = "Location";
                                cmb.ValueMember = "LocationID";
                                cmb.DataSource = dtCmbLocation;
                                grdStockRequest.Rows[rowIndex].Cells["clmLoc"].Value = slid;
                            }
                            else
                            {
                                DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
                                textBoxCell.Value = ""; // or any string value
                                grdStockRequest.Rows[rowIndex].Cells["clmLoc"] = textBoxCell;
                                grdStockRequest.Rows[rowIndex].Cells["clmLoc"].ReadOnly = true;
                                grdStockRequest.Rows[rowIndex].Cells["clmLoc"].Style.BackColor = Color.LightGray;
                            } 

                            //for(int j=0;j<grdStockRequest.Rows.Count;j++)
                            //{
                            if (varProducts == "")
                            {
                                varProducts = Convert.ToString(lblProduct.Text);
                            }
                            else
                            {
                                varProducts = varProducts + ',' + Convert.ToString(lblProduct.Text);
                            }
                            varProductsIDs.Add(Convert.ToInt32(lblProduct.Text));
                            //}
                            ((DataGridViewTextBoxColumn)grdStockRequest.Columns["clmRequiredQty"]).MaxInputLength = 8;
                            grdStockRequest.Columns["clmSno"].Width = 50;
                            //grdStockRequest.Columns["clmRequiredQty"].Width = 100;
                            grdStockRequest.Columns["clmIncharge"].Width = 250;
                            grdStockRequest.Columns["clmStockQty"].Width = 100;
                            grdStockRequest.Columns["clmRequiredQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockRequest.Columns["clmStockQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockRequest.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockRequest.Columns["clmSnoDup"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            pbShopFlag = 0;
                            cmbLocation.DataSource = null;
                            udfnStockRequestSearchGridHead();
                        }
                    }
                    VarAdd = "0";
                    txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
                    txttotalUnits.Text = grdStockRequest.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["clmRequiredQty"].Value != null
                             && decimal.TryParse(
                                    r.Cells["clmRequiredQty"].Value.ToString(),
                                    out _))
                    .Sum(r => Convert.ToDecimal(r.Cells["clmRequiredQty"].Value))
                    .ToString();
                    errStockRequest.Clear();
                    txtProductNamePICode.Text = "";
                    txtStockQty.Text = "";
                    txtRequiredQty.Text = ""; 
                    txtStockUnit.Text = "";
                    txtReqUnit.Text = "";
                    grdGodownStock.Rows.Clear();
                    grdStockRequest.ClearSelection();
                    txtProductNamePICode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if(grdStockRequest.Rows.Count>0)
                {
                    cmbConcern.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                }
                grdStockRequest.Sort(grdStockRequest.Columns[0], ListSortDirection.Descending);
            }
        }
        private void TxtRequiredQty_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                //lvProduct.Visible = false; 
                txtRequiredQty.BackColor = Color.LemonChiffon;
                if(txtProductNamePICode.Text.Trim() !="")
                {
                    txtProductNamePICode.BackColor = Color.White;
                    errStockRequest.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRequiredQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pbShopFlag == 1)
                    {
                        cmbLocation.Focus();
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
        private void TxtRequiredQty_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal+1)
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
        private void TxtRequiredQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRequiredQty.Text.Trim() == "")
                {
                    errStockRequest.SetError(txtRequiredQty, "Please enter quantity");
                    txtRequiredQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRequiredQty.ShowAlways = true;
                    tpRequiredQty.Show("Please enter quantity", txtRequiredQty, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtRequiredQty.Text).Trim(), varDecimal);
                    txtRequiredQty.Text = Qty;
                    errStockRequest.Clear();
                    txtRequiredQty.BackColor = Color.White;
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

        private void TxtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbStatus.Enabled == true)
                    {
                        cmbStatus.Focus();
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    errStockRequest.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductNamePICode, 5000);
                    blnErrorFlag = true;
                }
                //if (Convert.ToString(txtStockQty.Text).Trim() == "")
                //{
                //    errStockRequest.SetError(txtStockQty, "Invalid stock");
                //    txtStockQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpStockQty.ShowAlways = true;
                //    tpStockQty.Show("Invalid stock", txtStockQty, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(txtRequiredQty.Text).Trim() != "")
                {
                    //if (Convert.ToInt32(txtStockQty.Text.Trim()) >= Convert.ToInt32(txtRequiredQty.Text.Trim()))
                    //{
                    //    errStockRequest.Clear();
                    //    txtRequiredQty.BackColor = Color.White;
                    //}
                    //else
                    //{
                    //    errStockRequest.SetError(txtRequiredQty, "Please enter valid quentity");
                    //    txtRequiredQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpRequiredQty.ShowAlways = true;
                    //    tpRequiredQty.Show("Please enter valid quentity", txtRequiredQty, 5000);
                    //    blnErrorFlag = true;
                    //}
                }
                else
                {
                    errStockRequest.SetError(txtRequiredQty, "Please enter quantity");
                    txtRequiredQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRequiredQty.ShowAlways = true;
                    tpRequiredQty.Show("Please enter quantity", txtRequiredQty, 5000);
                    blnErrorFlag = true;
                }
                if (pbShopFlag==1 && Convert.ToInt16(cmbLocation.SelectedValue)==-1)
                {
                    errStockRequest.SetError(cmbLocation, "Please select location");
                    cmbLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocation.ShowAlways = true;
                    tpLocation.Show("Please select location", cmbLocation, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToDecimal(txtRequiredQty.Text.Trim())==0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    VarAdd = "2";
                    udfnStockLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockRequest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdStockRequest.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                            {
                                int varPRID = Convert.ToInt32(grdStockRequest.Rows[e.RowIndex].Cells["clmPRID"].Value);
                                for (int i = 0; i < varProductsIDs.Count; i++)
                                {
                                    if (varProductsIDs[i].Equals(varPRID)) { varProductsIDs.RemoveAt(i); goto L; }
                                }
                                L: grdStockRequest.Rows.RemoveAt(this.grdStockRequest.Rows[e.RowIndex].Index);
                                for (int i = 0; i < grdStockRequest.RowCount; i++)
                                {
                                    grdStockRequest.Rows[i].Cells["clmSno"].Value = i + 1;
                                    grdStockRequest.Rows[i].Cells["clmSnoDup"].Value = i + 1;
                                }
                               varModifiedFlag = 1;
                                for (int i = 0; i < dtStock.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtStock.Rows[i]["SRQ_PRID"]) == Convert.ToInt32(varPRID))
                                    {
                                        dtStock.Rows[i].Delete();
                                        dtStock.AcceptChanges();
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
            finally
            {
                txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
                txttotalUnits.Text = grdStockRequest.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["clmRequiredQty"].Value != null
                             && decimal.TryParse(
                                    r.Cells["clmRequiredQty"].Value.ToString(),
                                    out _))
                    .Sum(r => Convert.ToDecimal(r.Cells["clmRequiredQty"].Value))
                    .ToString();
                if (grdStockRequest.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                }
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

        public void udfnStockRequestSave(object sender, EventArgs e)
        {
            try
            {
                errStockRequest.Clear(); varErrQty = "0";int varLocationError = 0; 
                bool blnErrorFlag = false;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errStockRequest.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (grdStockRequest.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }

                //Any one of the location should be mapped
                int count = dtStock.AsEnumerable() .Count(r =>
                        (r.Field<int>("SRQ_SLID") == 0 ||
                        r.Field<int>("SRQ_SLID") == -1) && r.Field<decimal>("SRQ_RequestedQty") != 0
                        );
                if (count!=0)
                {
                    varErrQty = "1"; varLocationError = 1;
                }

                if (chkRackGroup.Checked == false)
                {
                    for (int i = 0; i < grdStockRequest.Rows.Count; i++)
                    {
                        if (Convert.ToString(grdStockRequest.Rows[i].Cells["clmRequiredQty"].Value) == "" || Convert.ToDecimal(grdStockRequest.Rows[i].Cells["clmRequiredQty"].Value) == 0)
                        {
                            blnErrorFlag = true; varErrQty = "1";
                            //grdPurchaseDC.Rows[i].Cells["clmError"].Value = 1;
                            grdStockRequest.Rows[i].Cells["clmRequiredQty"].Style.BackColor = Color.LightPink;
                        }
                        else
                        {
                            grdStockRequest.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                            grdStockRequest.Rows[i].Cells["clmRequiredQty"].Style.BackColor = Color.PaleGreen;
                        }
                    }
                }
                else
                {  
                    if (varErrQty == "0") //Location mapped and Rec qry given 
                    { 
                        var rows = dtStock.AsEnumerable().Where(r => r.Field<decimal>("SRQ_RequestedQty") != 0);
                        dtStock = rows.Any() ? rows.CopyToDataTable() : dtStock.Clone();
                    } 
                }
                if (varTellerID == 0)
                {
                    errStockRequest.SetError(txtTeller, "Please enter teller name.");
                    txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGenerealBill.ShowAlways = true;
                    tpGenerealBill.Show("Please enter teller name.", txtTeller, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToInt32(cmbRequestType.SelectedValue) == -1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                    return;
                }
                if (varLocationError==1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(237);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                    return;
                }
                //if (Convert.ToInt32(cmbRequestType.SelectedValue) == 562 && txtGeneralBillNo.Text.Trim() == "")
                //{
                //    errStockRequest.SetError(txtGeneralBillNo, "Please enter Bill No.");
                //    txtGeneralBillNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpGenerealBill.ShowAlways = true;
                //    tpGenerealBill.Show("Please enter Bill No.", txtGeneralBillNo, 5000);
                //    blnErrorFlag = true;
                //}
                if (varErrQty == "1")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    errStockRequest.Clear();
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
                }
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
                if (pbscreenflag == 0)
                {
                    udfnStockRequestSave(sender, e);
                }
                else if (pbscreenflag == 1)
                {
                    udfnSaveFromQueue("Save");
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            { 
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0,varStatus = 0;
                varStatus = Convert.ToInt32(cmbStatus.SelectedValue);
                if (btnSave.Text== "Save")
                {
                    varoriginator = "Stock Request Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Stock Request Updation";
                    varType = 1;
                }
                int loadByRackGroup = 0;
                string varQrcodeQueue = "";
                var varImgMemoryStreamQueue = new MemoryStream();
                varImgMemoryStreamQueue = new MemoryStream();
                QrcodeImg.Text = varQrcodeQueue;
                QrcodeImg.Image.Save(varImgMemoryStreamQueue, System.Drawing.Imaging.ImageFormat.Png);
                varobjBarCodeByte = varImgMemoryStreamQueue.GetBuffer();
                if (chkRackGroup.Checked == true) { loadByRackGroup = 1; }
                else { loadByRackGroup = 0; }
                    Model.TRN_StockRequest objTRNS_StockRequest = new Model.TRN_StockRequest();
                objTRNS_StockRequest.ViewType = varType;
                objTRNS_StockRequest.paraStockRequestID = varStockRequestID;
                objTRNS_StockRequest.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRNS_StockRequest.paraRequestDate = dpDate.Text;
                objTRNS_StockRequest.paraRemarks = txtRemarks.Text;
                objTRNS_StockRequest.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objTRNS_StockRequest.paraOriginator = varoriginator;
                objTRNS_StockRequest.paraStockRequest = dtStock;
                objTRNS_StockRequest.paraRequestTypeID =Convert.ToInt32(cmbRequestType.SelectedValue);
                objTRNS_StockRequest.paraBillNo = Convert.ToString(txtGeneralBillNo.Text.Trim());
                objTRNS_StockRequest.paraLoadByRackGroup = loadByRackGroup;
                objTRNS_StockRequest.paraRKGID = Convert.ToInt32(cmbRackGroup.SelectedValue);
                objTRNS_StockRequest.paraProductTypeID = Convert.ToInt32(cmbProductType.SelectedValue); 
                objTRNS_StockRequest.paraTellerID = varTellerID;
                objTRNS_StockRequest.paraQrimg = (varobjBarCodeByte);
                varResult = objspservice.udfnStockRequest(objTRNS_StockRequest);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varModifiedFlag = 0;
                    try
                    {
                        if (varStockRequestID == 0)
                        {
                            SSRUpdatevalue = varvalue[2];
                            string varQrcode = varvalue[3];
                            var varImgMemoryStream = new MemoryStream();
                            QrcodeImg.Text = varQrcode;
                            QrcodeImg.Image.Save(varImgMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
                            varobjBarCodeByte = varImgMemoryStream.GetBuffer();
                            objTRNS_StockRequest.ViewType = 3;
                            objTRNS_StockRequest.paraStockRequestID = Convert.ToInt32(SSRUpdatevalue);
                            objTRNS_StockRequest.paraQrimg = (varobjBarCodeByte);
                            varResult = objspservice.udfnStockRequest(objTRNS_StockRequest);
                            objspservice.CloseConnection();
                        }
                        string SSR = "0";
                        if (varStockRequestID == 0)
                        {
                            SSR = varvalue[2];
                        }
                        else
                        {
                            SSR = Convert.ToString(varStockRequestID);
                        }
                        //DialogResult result1;
                        //SPDataService objDServ = new SPDataService();
                        //string varMessage = objDServ.udfnGetMessages(87);
                        //objDServ.CloseConnection();
                        //result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (result1 == DialogResult.Yes)
                        //{
                        //    string varHeader = "";
                        //    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        //    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        //    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_INV_Shop_Stock_Request.rpt");
                        //    varHeader = "Shop Stock Request";

                        //    objBillreport.SetParameterValue("paraStockRequestID", Convert.ToInt32(SSR));
                        //    objBillreport.SetParameterValue("paraConcern", Convert.ToInt32(cmbConcern.SelectedValue));
                        //    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                        //    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        //    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                        //    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                        //    objValidation.CrySqlConnection(objBillreport);

                        //    MainForm.objReportLoad = new ReportLoad();
                        //    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                        //    MainForm.objReportLoad.Text = varHeader;
                        //    MainForm.objReportLoad.ShowDialog();
                        //}
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                    MainForm.objINV_StockRequestList.udfnList();
                    this.Close();
                }
                else
                {
                    errStockRequest.Clear();
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
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
            }
        }
        private void GrdStockRequest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmRequiredQty")
                {
                    int varDecimal = Convert.ToInt32(grdStockRequest.CurrentRow.Cells["clmUTDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdStockRequest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                    grdStockRequest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                    object varEditQty = grdStockRequest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // Update the same column value in the DataTable
                    dtStock.Rows[e.RowIndex]["SRQ_RequestedQty"] = varEditQty;
                }
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmLoc") 
                {
                    int varLocID = Convert.ToInt16(grdStockRequest.CurrentRow.Cells["clmLoc"].Value);
                    dtStock.Rows[e.RowIndex]["SRQ_SLID"] = varLocID;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txttotalUnits.Text = grdStockRequest.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["clmRequiredQty"].Value != null
                         && decimal.TryParse(
                                r.Cells["clmRequiredQty"].Value.ToString(),
                                out _))
                .Sum(r => Convert.ToDecimal(r.Cells["clmRequiredQty"].Value))
                .ToString();
            }
        }
        private void CmbStatus_Enter(object sender, EventArgs e)
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
        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
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
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnProductEvent();
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
                        txtRequiredQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRackGroupEnable()
        {
            try
            {
                if (chkRackGroup.Checked == false)
                { 
                    lblDEProductName.Visible = true;
                    txtProductNamePICode.Visible = true;
                    lblProductType.Visible = true;
                    lblStock.Visible = true;
                    txtStockQty.Visible = true;
                    lblRequiredQty.Visible = true;
                    txtRequiredQty.Visible = true;
                    btnAdd.Visible = true;
                    lblProductCount.Visible = true;

                    lblRackGroup.Visible = false;
                    cmbRackGroup.Visible = false;
                    lblProductType.Visible = false;
                    cmbProductType.Visible = false;
                    //grdStockRequest.Rows.Clear();
                    //dtStock.Rows.Clear();
                    grdStockRequest.Columns["clmRemove"].Visible = true;
                    btnView.Visible = false;
                    txtReqUnit.Visible = true;
                    txtStockUnit.Visible = true;
                    lblProductTamil.Text = "";
                    txtProductNamePICode.Text = "";
                    cmbLocation.Visible = true;
                    lblLocation.Visible = true;  
                    udfnRemoveRequiredQty();
                }
                else if (chkRackGroup.Checked == true)
                {
                    lblDEProductName.Visible = false;
                    txtProductNamePICode.Visible = false;
                    lblProductType.Visible = false;
                    lblStock.Visible = false;
                    txtStockQty.Visible = false;
                    lblRequiredQty.Visible = false;
                    txtRequiredQty.Visible = false;
                    btnAdd.Visible = false;
                    lblProductCount.Visible = false;
                    lblProductTamil.Text = "";
                    txtProductNamePICode.Text = "";
                    lblRackGroup.Visible = true;
                    cmbRackGroup.Visible = true;
                    lblProductType.Visible = true;
                    cmbProductType.Visible = true;
                    grdStockRequest.SendToBack();
                    picLoader.BringToFront();
                    picLoader.Visible = true; 
                    picLoader.Visible = false;
                    picLoader.SendToBack();
                    grdStockRequest.BringToFront();
                    grdStockRequest.Columns["clmRemove"].Visible = false;
                    btnView.Visible = true;
                    txtReqUnit.Visible = false;
                    txtStockUnit.Visible = false;
                    cmbLocation.Visible = false;
                    lblLocation.Visible = false;
                }
                cmbRackGroup.SelectedValue = -1;
                cmbProductType.SelectedValue = -1;
                 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadByRackGroup()
        {
            try
            {
                DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                GrdStockRequest_DataBindingComplete(grdStockRequest, args);
                txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
                txttotalUnits.Text = grdStockRequest.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["clmRequiredQty"].Value != null
                             && decimal.TryParse(
                                    r.Cells["clmRequiredQty"].Value.ToString(),
                                    out _))
                    .Sum(r => Convert.ToDecimal(r.Cells["clmRequiredQty"].Value))
                    .ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnRemoveRequiredQty()
        {
            try
            {
                var rowsToDelete = grdStockRequest.Rows
                 .Cast<DataGridViewRow>()
                 .Where(r => !r.IsNewRow &&
                            (string.IsNullOrWhiteSpace(Convert.ToString(r.Cells["clmRequiredQty"].Value)) ||
                             Convert.ToDecimal(r.Cells["clmRequiredQty"].Value ?? 0) == 0))
                 .ToList();

                List<int> varPrIDs = grdStockRequest.Rows
      .Cast<DataGridViewRow>()
      .Where(r => !r.IsNewRow &&
                  decimal.TryParse(Convert.ToString(r.Cells["clmRequiredQty"].Value), out decimal qty) &&
                  qty != 0)
      .Select(r => Convert.ToInt32(r.Cells["clmPRID"].Value))
      .ToList();

                if (varPrIDs.Count != 0)
                {
                    varProductsIDs.AddRange(varPrIDs);
                    varProducts = string.Join(",", varPrIDs);
                }

                foreach (var row in rowsToDelete)
                {
                    grdStockRequest.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkRackGroup_CheckedChanged(object sender, EventArgs e)
        {
            udfnRackGroupEnable(); 
        }

        private void cmbType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRequestType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbRequestType.SelectedValue) == "" || Convert.ToString(cmbRequestType.SelectedValue) == "-1")
                {
                    errStockRequest.SetError(cmbRequestType, "Please select type");
                    cmbRequestType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpType.ShowAlways = true;
                    tpType.Show("Please select type", cmbRequestType, 5000);
                }
                else
                { 
                    errStockRequest.Clear();
                    cmbRequestType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBillNoEnable()
        {
            try
            {
                txtGeneralBillNo.Text = "";
                if (Convert.ToInt32(cmbRequestType.SelectedValue) == 562) //General Bill
                {
                    txtGeneralBillNo.Enabled = true;
                    txtGeneralBillNo.ReadOnly = false;
                }
                else
                {
                    txtGeneralBillNo.Enabled = false;
                    txtGeneralBillNo.ReadOnly = true;
                }
                chkRackGroup.Checked = false;
                if (Convert.ToInt16(cmbRequestType.SelectedValue) == 563)
                { chkRackGroup.Visible = true; }
                else { chkRackGroup.Visible = false; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnBillNoEnable();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToInt16(cmbRequestType.SelectedValue) == 562)
                    {
                        txtGeneralBillNo.Focus();
                    }
                    else
                    {
                        chkRackGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtGeneralBillNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGeneralBillNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtGeneralBillNo_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt32(cmbRequestType.SelectedValue) == 562)
                //{
                //    if (txtGeneralBillNo.Enabled == true && txtGeneralBillNo.Text.Trim() == "")
                //    {
                //        errStockRequest.SetError(txtGeneralBillNo, "Please enter Bill No.");
                //        txtGeneralBillNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpBillNo.ShowAlways = true;
                //        tpBillNo.Show("Please enter Bill No.", txtGeneralBillNo, 5000);
                //    }
                //    else
                //    {
                //        txtGeneralBillNo.BackColor = Color.White;
                //    }
                //}
                //else
                //{
                //    txtGeneralBillNo.BackColor = Color.White;
                //}
                txtGeneralBillNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtGeneralBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (chkRackGroup.Visible == true)
                    {
                        chkRackGroup.Focus();
                    }
                    else
                    {
                        if (txtProductNamePICode.Visible == true) { txtProductNamePICode.Focus(); }
                        else { cmbProductType.Focus(); }
                    }
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRackGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRackGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRackGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbRackGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRackGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbProductType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProductType.BackColor = Color.LemonChiffon; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProductType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTeller.Text.Length > 0)
                {
                    lvVerified.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(17, txtTeller.Text.Trim(), 0, "", 1, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["EMP_Name"].ToString(), objDs.Tables[0].Rows[i]["EMPID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvVerified.Columns[1].Width = 0;
                                    lvVerified.Items.Add(objList);
                                }
                                lvVerified.BringToFront();
                                lvVerified.Visible = true;
                            }
                            else
                            {
                                lvVerified.Visible = false;
                            }
                        }
                        else
                        {
                            lvVerified.Visible = false;
                        }
                    }
                    else
                    {
                        lvVerified.Visible = false;
                    }
                }
                else
                {
                    lvVerified.Visible = false;
                    lvVerified.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.LemonChiffon;
                udfnGridNull((Control)sender);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridNull(Control skipControl)
        {
            try
            {
                //if (skipControl != txtGroup)
                //{
                //    varUpDownKeyGroup = 0;
                //    DGV_FilterGroup.DataSource = null;
                //    DGV_FilterGroup.Visible = false;
                //}
                //if (skipControl != txtSubGroup)
                //{
                //    varUpDownKeySubgroup = 0;
                //    DGV_FilterSubgroup.DataSource = null;
                //    DGV_FilterSubgroup.Visible = false;
                //}
                //if (skipControl != txtProductName)
                //{
                //    varUpDownKeyProduct = 0;
                //    DGV_FilterProduct.DataSource = null;
                //    DGV_FilterProduct.Visible = false;
                //}
                //if (skipControl != txtBrand)
                //{
                //    varUpDownKeyBrand = 0;
                //    DGV_FilterBrand.DataSource = null;
                //    DGV_FilterBrand.Visible = false;
                //}
                //if (skipControl != txtProduct)
                //{
                //    varUpDownKeyLockProduct = 0;
                //    DGV_Product.DataSource = null;
                //    DGV_Product.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvVerified.Items.Count == 0 || txtTeller.Text == "")
                    {
                        lvVerified.Visible = false;
                    }
                    else
                    {
                        lvVerified.Focus();
                    }
                    if (lvVerified.Items.Count > 0)
                    {
                        lvVerified.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRequestType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvVerified_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnVerified1();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvVerified_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnVerified1();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVerified1()
        {
            try
            {
                if (txtTeller.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvVerified.SelectedItems[0];
                    txtTeller.Text = selectedItem.SubItems[0].Text;
                    varTellerID = Convert.ToInt16(selectedItem.SubItems[1].Text);
                }
                cmbRequestType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvVerified.Visible = false;  
            }
        } 
        private void cmbRackGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadProductByRackGroup();
        }
        public void udfnSaveFromQueue(string varSaveType)
        {
            try
            { 
                btnSave.Enabled = false; 
                if(chbCompleted.Checked==true)
                {
                    pbPrintStatus = 48;
                }
                else { pbPrintStatus = 47; }
                    SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0, varStatus = 0;
                varStatus = Convert.ToInt32(cmbStatus.SelectedValue); 
                int loadByRackGroup = 0;
                if (chkRackGroup.Checked == true) { loadByRackGroup = 1; }
                else { loadByRackGroup = 0; }
                Model.TRN_StockRequest objTRNS_StockRequest = new Model.TRN_StockRequest();
                objTRNS_StockRequest.ViewType = 4; 
                objTRNS_StockRequest.paraStockRequest = dtStock; 
                objTRNS_StockRequest.paraRequestTypeID = pbID; 
                objTRNS_StockRequest.paraStatusId = pbPrintStatus; 
                varResult = objspservice.udfnStockRequest(objTRNS_StockRequest);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                { 
                    if (varSaveType == "SavePrint")
                    {
                        udfnPrint();
                    }
                    MainForm.objINV_StockRequestQueueList.udfnList();
                    this.Close();
                }
                else
                {
                    errStockRequest.Clear();
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnPrint.Enabled = true;
                    btnPrint.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        public void udfnPrint()
        {
            try
            {
                string varHeader = "";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_INV_Shop_Stock_Request_Queue.rpt");
                varHeader = "Shop Stock Request";

                objBillreport.SetParameterValue("paraStockRequestID", Convert.ToInt32(pbID));
                objBillreport.SetParameterValue("paraConcern", Convert.ToInt32(cmbConcern.SelectedValue));
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Enabled = false;
                udfnSaveFromQueue("SavePrint");
                MainForm.objINV_StockRequestQueueList.udfnList();
                this.Close();
                btnPrint.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnPrint.Enabled = true;
            }
        }

        private void DGV_SearchStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                udfnStockRequestGridFilter();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadProductByRackGroup();
        }

        private void DGV_SearchStock_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGV_SearchStock.IsCurrentCellDirty)
            {
                DGV_SearchStock.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            udfnStockRequestGridFilter();
        }

        private void DGV_SearchStock_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdStockRequest.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchStock.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdStockRequest.Width > grdStockRequest.HorizontalScrollingOffset && grdStockRequest.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchStock.HorizontalScrollingOffset = offSetValue;
                DGV_SearchStock.Invalidate();
                udfnscrollVisible(DGV_SearchStock, grdStockRequest);    
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdStockRequest_Scroll(object sender, ScrollEventArgs e)
        { 
            try
            {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                {
                    DGV_SearchStock.HorizontalScrollingOffset =
                        grdStockRequest.HorizontalScrollingOffset;

                    DGV_SearchStock.Invalidate();
                }

                udfnscrollVisible(DGV_SearchStock, grdStockRequest);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchStock_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdStockRequest.Columns.Contains(e.Column.Name))
                {
                    grdStockRequest.Columns[e.Column.Name].Width = e.Column.Width;
                }
                DGV_SearchStock.HorizontalScrollingOffset = grdStockRequest.HorizontalScrollingOffset;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdStockRequest_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewColumn newColumn = grdStockRequest.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdStockRequest.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn && grdStockRequest.SortOrder == SortOrder.Ascending)
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
                if (newColumn.GetType() != typeof(DataGridViewImageColumn))
                {
                    grdStockRequest.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_SearchStock.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_SearchStock.HorizontalScrollingOffset = grdStockRequest.HorizontalScrollingOffset;
                    DGV_SearchStock.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdStockRequest_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 0))   /*If not our desired columns*/
                    //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                               & ~(DataGridViewPaintParts.ContentForeground));

                        e.Handled = true;
                    }
                DGV_SearchStock.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void grdStockRequest_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (DGV_SearchStock.Columns.Contains(e.Column.Name))
                {
                    DGV_SearchStock.Columns[e.Column.Name].Width = e.Column.Width;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chbCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(chbCompleted.Checked==true)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            udfnLoadByRackGroup(); 
            LoadProductByRackGroup();
            DGV_SearchStock.ScrollBars = ScrollBars.Vertical;
        }

        private void grdGodownStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbRequestType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbRackGroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbProductType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void chkRackGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                chkRackGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbLocation_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbLocation_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbLocation.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grpStockRequest_Enter(object sender, EventArgs e)
        {

        }

        private void chkRackGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                chkRackGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void chkRackGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbRackGroup.Visible == true)
                    {
                        cmbRackGroup.Focus();
                    }
                    else { txtProductNamePICode.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductClear()
        {
            try
            {
                if (varProductsIDs?.Count > 0)
                {
                    HashSet<int> productIds = new HashSet<int>(varProductsIDs);

                    for (int i = dtStock.Rows.Count - 1; i >= 0; i--)
                    {
                        if (!productIds.Contains(Convert.ToInt32(dtStock.Rows[i]["SRQ_PRID"])))
                        {
                            dtStock.Rows.RemoveAt(i);
                        }
                    }
                    for (int i = grdStockRequest.Rows.Count - 1; i >= 0; i--)
                    {
                        int prId = Convert.ToInt32(grdStockRequest.Rows[i].Cells["clmPRID"].Value);

                        if (!productIds.Contains(prId))
                        { 
                            grdStockRequest.Rows.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    grdStockRequest.Rows.Clear();
                    dtStock.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void LoadProductByRackGroup()
        {
            try
            {
                if(Convert.ToInt16(cmbRackGroup.SelectedValue)==-1 || Convert.ToInt16(cmbRackGroup.SelectedValue) == 0)
                {
                    errStockRequest.SetError(cmbRackGroup, "Please select rack group");
                    cmbRackGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpType.ShowAlways = true;
                    tpType.Show("Please select type", cmbRackGroup, 5000);
                    return;
                }
                if (Convert.ToInt16(cmbProductType.SelectedValue) == -1 || Convert.ToInt16(cmbProductType.SelectedValue) == 0)
                {
                    errStockRequest.SetError(cmbProductType, "Please select product type");
                    cmbProductType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductType.ShowAlways = true;
                    tpProductType.Show("Please select type", cmbProductType, 5000);
                    return;
                }
                string PRIDs = "0"; 
                if (varProducts != "")
                {
                    var strings1 = varProductsIDs.Select(xx => xx);
                    PRIDs = (string.Join(",", strings1));
                }
                DataSet objDs = new DataSet(); 
                 DataTable dtStockLocation = new DataTable(); 
                TRN_StockRequest objTRN_StockRequest = new TRN_StockRequest();
                objTRN_StockRequest.ViewType = 8;
                objTRN_StockRequest.paraRackGroupID = Convert.ToInt16(cmbRackGroup.SelectedValue); 
                objTRN_StockRequest.paraProTypeID = Convert.ToInt16(cmbProductType.SelectedValue); 
                objTRN_StockRequest.paraProductIDs = PRIDs; 
                SPDataService objdspservice = new SPDataService();
                objDs = objdspservice.udfnStockRequestList(objTRN_StockRequest);
                objdspservice.CloseConnection();
                if (objDs != null)
                {
                    //grdStockRequest.Rows.Clear();
                    //dtStock.Rows.Clear();
                    udfnProductClear();
                    if (objDs.Tables[1].Rows.Count > 0)
                    {
                        dtLocation = objDs.Tables[1];
                    }

                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        int shopFlag = 0,PRID=0;
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            int rowindex = Convert.ToInt16(grdStockRequest.Rows.Count);
                            grdStockRequest.Rows.Add(grdStockRequest.Rows.Count+1, Convert.ToString(objDs.Tables[0].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[0].Rows[i]["Location"]), Convert.ToString(objDs.Tables[0].Rows[i]["RKG_Name"]), Convert.ToString(objDs.Tables[0].Rows[i]["RK_ShortName"]),
                                Convert.ToString(objDs.Tables[0].Rows[i]["EMP_Name"]), "", grdStockRequest.Rows.Count + 1, "", Convert.ToString(objDs.Tables[0].Rows[i]["UT_Symbol"]), "",
                                Convert.ToString(objDs.Tables[0].Rows[i]["UT_Decimal"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]), 0, Convert.ToString(objDs.Tables[0].Rows[i]["SLID"]),Convert.ToInt16(objDs.Tables[0].Rows[i]["ShopFlag"])); 
                            dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[0].Rows[i]["PRID"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["SLID"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["RKID"]), 0, 0);
                             
                            shopFlag = Convert.ToInt16(objDs.Tables[0].Rows[i]["ShopFlag"]);    
                            PRID= Convert.ToInt16(objDs.Tables[0].Rows[i]["PRID"]);

                            if (shopFlag == 1)
                            { 
                                
                                var rows = dtLocation.AsEnumerable().Where(x => x.Field<int>("PRID") == PRID); 
                                dtStockLocation = dtLocation.Clone();
                                if (rows.Any())
                                {
                                    dtStockLocation = rows.CopyToDataTable();
                                }
                                if (dtStockLocation.Rows.Count > 0)
                                {
                                    DataGridViewComboBoxCell cmb = (DataGridViewComboBoxCell)grdStockRequest.Rows[rowindex].Cells["clmLoc"];

                                    cmb.DisplayMember = "Location";
                                    cmb.ValueMember = "LocationID";
                                    cmb.DataSource = dtStockLocation;
                                    grdStockRequest.Rows[rowindex].Cells["clmLoc"].Value = -1;
                                }
                            }
                            else
                            {
                                DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
                                textBoxCell.Value = ""; // or any string value
                                grdStockRequest.Rows[rowindex].Cells["clmLoc"] = textBoxCell;
                                grdStockRequest.Rows[rowindex].Cells["clmLoc"].ReadOnly = true;
                                grdStockRequest.Rows[rowindex].Cells["clmLoc"].Style.BackColor = Color.LightGray;
                            } 
                        }
                        ((DataGridViewTextBoxColumn)grdStockRequest.Columns["clmRequiredQty"]).MaxInputLength = 8;
                        grdStockRequest.Columns["clmSno"].Width = 50;
                        //grdStockRequest.Columns["clmRequiredQty"].Width = 100;
                        grdStockRequest.Columns["clmIncharge"].Width = 200;
                        grdStockRequest.Columns["clmStockQty"].Width = 100; 
                        grdStockRequest.Columns["clmRequiredQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdStockRequest.Columns["clmStockQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdStockRequest.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdStockRequest.Columns["clmSnoDup"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdStockRequest.Columns["clmRemove"].Visible = false;
                        udfnStockRequestSearchGridHead();
                        DGV_SearchStock.ScrollBars = ScrollBars.Vertical;
                    }
                }
                
                VarAdd = "0";
                txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
                txttotalUnits.Text = grdStockRequest.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["clmRequiredQty"].Value != null
                             && decimal.TryParse(
                                    r.Cells["clmRequiredQty"].Value.ToString(),
                                    out _))
                    .Sum(r => Convert.ToDecimal(r.Cells["clmRequiredQty"].Value))
                    .ToString();
                errStockRequest.Clear();
                txtProductNamePICode.Text = "";
                txtStockQty.Text = "";
                txtRequiredQty.Text = "";
                txtStockUnit.Text = "";
                txtReqUnit.Text = "";
                grdGodownStock.Rows.Clear();
                grdStockRequest.ClearSelection();
                txtProductNamePICode.Focus();
                DGV_SearchStock.ScrollBars = ScrollBars.Vertical;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnStockRequestSearchGridHead()
        {
            try
            {
                DGV_SearchStock.BringToFront();
                DGV_SearchStock.Columns.Clear();

                foreach (DataGridViewColumn col in grdStockRequest.Columns)
                {
                    if (col.Visible)
                    {
                        DGV_SearchStock.Columns.Add((DataGridViewColumn)col.Clone());
                    }
                    //DataGridViewColumn newCol = DGV_SearchStock.Columns[DGV_SearchStock.Columns.Count - 1];

                    //newCol.Width = col.Width;
                    //newCol.AutoSizeMode = col.AutoSizeMode;
                    //newCol.MinimumWidth = col.MinimumWidth;
                    //newCol.FillWeight = col.FillWeight;
                    //newCol.Resizable = col.Resizable;
                    //newCol.Frozen = col.Frozen;
                }

                DGV_SearchStock.Rows.Clear();
                DGV_SearchStock.Rows.Add();

                for (int i = 0; i < DGV_SearchStock.ColumnCount; i++)
                {
                    DGV_SearchStock.Columns[i].ReadOnly = false;

                    DGV_SearchStock.Rows[0].Cells[i].Value = ""; 
                }

                // Optional specific readonly columns
                DGV_SearchStock.Columns["clmSno"].ReadOnly = true;
                DGV_SearchStock.Columns["clmSnoDup"].ReadOnly = true;
                DGV_SearchStock.Columns["clmLoc"].ReadOnly = true; 

                // Last image column
                int lastCol = DGV_SearchStock.Columns.Count - 1;

                if (DGV_SearchStock.Columns[lastCol] is DataGridViewImageColumn)
                {
                    DGV_SearchStock.Rows[0].Cells[lastCol].Value = new Bitmap(1, 1);
                    ((DataGridViewImageColumn)DGV_SearchStock.Columns[lastCol])
                        .DefaultCellStyle.NullValue = null;

                    DGV_SearchStock.Columns[lastCol].ReadOnly = true;
                }
                if (DGV_SearchStock.Columns["clmLoc"] is DataGridViewComboBoxColumn)
                {  
                    DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
                    textBoxCell.Value = ""; // or any string value
                    DGV_SearchStock.Rows[0].Cells["clmLoc"] = textBoxCell;
                    DGV_SearchStock.Rows[0].Cells["clmLoc"].ReadOnly = true;
                    DGV_SearchStock.Rows[0].Cells["clmLoc"].Style.BackColor = Color.LightGray; 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnStockRequestGridFilter()
        {
            try
            {
                foreach (DataGridViewRow row in grdStockRequest.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    bool visible = true;

                    for (int i = 0; i < DGV_SearchStock.Columns.Count; i++)
                    {
                        object searchObj = DGV_SearchStock.Rows[0].Cells[i].Value;

                        if (searchObj == null)
                            continue;

                        string searchText = searchObj.ToString().Trim();

                        if (string.IsNullOrWhiteSpace(searchText))
                            continue;

                        string columnName = DGV_SearchStock.Columns[i].Name;

                        if (!grdStockRequest.Columns.Contains(columnName))
                            continue;

                        object cellObj = row.Cells[columnName].Value;

                        string cellValue = cellObj == null
                            ? ""
                            : cellObj.ToString();

                        if (!cellValue.ToLower().Contains(searchText.ToLower()))
                        {
                            visible = false;
                            break;
                        }
                    }

                    row.Visible = visible;
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
                udfnProductEvent();
                txtRequiredQty.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockRequest_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdStockRequest.Rows.Count; i++)
                {
                    if (varStatus == 29)
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmRequiredQty"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmRequiredQty"];
                        cell.Style.BackColor = Color.PaleGreen;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = false;
                    }
                    if (Convert.ToString(grdStockRequest.Rows[i].Cells["clmStatusID"].Value) == "47")
                    {
                        grdStockRequest.Rows[i].Cells["clmStatus"].Style.BackColor = Color.Orange;
                        grdStockRequest.Rows[i].Cells["clmStatus"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grdStockRequest.Rows[i].Cells["clmStatusID"].Value) == "48")
                    {
                        grdStockRequest.Rows[i].Cells["clmStatus"].Style.BackColor = Color.LimeGreen;
                        grdStockRequest.Rows[i].Cells["clmStatus"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdStockRequest.Rows[i].Cells["clmStatus"].Style.BackColor = Color.Tomato;
                        grdStockRequest.Rows[i].Cells["clmStatus"].Style.ForeColor = Color.White;
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
        private void GrdStockRequest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmRequiredQty")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmRequiredQty")
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
        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int varDecimal = Convert.ToInt32(grdStockRequest.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmRequiredQty")
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
