using ROMS.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ROMS
{
    public partial class PUR_PurchaseOrder : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public bool VarSearchFlag = true;
        public int varRecqty = 0, varcount = 0, SupplierUpdate = 0, vardayMonthID = 0, varWeekID = 0, vardayID = 0, varrecyclecode = 0, varMonthID = 0, varMasterid = 0, varUnitid = 0,
            varPOID = 0, VarStatusId = 12, pbSupplierpend = 0, pbSupplierId = 0, pbScheduleid = 0, VarPrevSupplierid = 0, varcmbunitid = 0, Currentsts=0
            ,   varUPP = 0, qtyFlag = 0, varModifiedFlag = 0,
        varBulkunitvalue = 0, varUnitvalue = 0, varTotalunitvalue = 0, varprodFlag = 0, productcode = 0;
        public decimal totalKgQty = 0;
        public string vardays = "", unitweight = "", unitperbox = "", bulkunitweight = "", varUPPValue = "", varOtherSupPrevious = "", varOtherSupPartial = "";
        private ToolTip tpsalesman = new ToolTip();
        private ToolTip tpsalemanph = new ToolTip();
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpQty = new ToolTip();
        private ToolTip tppono = new ToolTip();
        private ToolTip tpsts = new ToolTip();
        private ToolTip tpIssuemodeValues = new ToolTip();
        private ToolTip tpIssuemode = new ToolTip();
        private ToolTip tpIssueby = new ToolTip();
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = "", var_MXSQ = ""
            , varorderSaleQty = "", varorderqty = "", addproductid = "", flag = "", varunitid = "0", pbProductsCode = "", pbunitname = "", varupdate = "0", varpendingPOID = "0", varReturnDC = "0", varDamage = "0",
            varcomid = "0", varSuppliervalue = "", var_BulkSymbol = "", var_TotSymbol = "";
        public decimal varNetweight = 0;
        public double totalBulkqty = 0, varFinalBulkUnit = 0;
        public decimal totalOrderQty = 0, totalUnitqty = 0, varFinalUnit = 0, varFinalTotalQty = 0, varFinalTotalKg = 0, varBulkunitqty = 0, varUnitqty = 0, varTotalunitqty = 0;
        public PUR_PurchaseOrder()
        {
            InitializeComponent();
        } 
        private void PUR_PurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            { 
                tbSupplierDetails.Enabled = false;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (8,0) AND MSTID NOT IN (0,-1) OR MSTID=-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnPolicy, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (9,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                this.ActiveControl = txtSupplier;
                udfnDropdownLoad();
                if (btnSave.Text == "Save")
                {
                    btnViewedProduct.Enabled = false;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(4, 6, varPOID, "", "", 0, "", 0);
                    if (objd.Tables[1].Rows.Count != 0)
                    {
                        DateTime varmindate = DateTime.ParseExact(objd.Tables[1].Rows[0]["MinToday"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        dpPlanDate.MinDate = varmindate; dpPlanDate.MaxDate = varmindate;
                    }
                }
                udfnEditLoad();
                //DataService objDservice = new DataService();
                //string vardate = objDservice.displaydata("SELECT CONVERT(datetime,GETDATE(),103)");
                //objDservice.CloseConnection();
                //dpPlanDate.Text = vardate;
                //if (VarStatusId == 12)
                //{
                //    btnSave.Enabled = true;
                //}
                //else
                //{
                if (VarStatusId == 14 || VarStatusId == 33)
                {
                    btnSave.Enabled = false;
                    chkStatus.Enabled = false;
                    gpissued.Enabled = false;
                    btnAdd.Enabled = false;
                    
                    btnViewedProduct.Enabled = false;
                    grdsupplieradd.Columns["clmRemove"].Visible = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
                if (Currentsts == 38 || Currentsts == 51)
                { 
                    gpissued.Enabled = false;
                    btnAdd.Enabled = false;
                    txtProductName.Enabled = false;
                    txtProductQty.Enabled = false;
                    cmbUnit.Enabled = false;
                    btnViewedProduct.Enabled = false;
                    grdsupplieradd.Columns["clmRemove"].Visible = false;
                }
                // }
                if (btnSave.Text == "Save")
                {
                    btnClear.Enabled = true;
                    cmbConcern.Enabled = true;
                    txtSupplier.Enabled = true;
                    foreach (TabPage tabPage in tbSupplierDetails.TabPages)
                    {
                        grdRepDetails.ClearSelection();
                        tabPage.Enabled = true;
                    }
                }
                else
                {
                    btnClear.Enabled = false;
                    cmbConcern.Enabled = false;
                    txtSupplier.Enabled = false;
                    LV_Supplier.Visible = false;
                    dpPlanDate.Enabled = false;

                    foreach (TabPage tabPage in tbSupplierDetails.TabPages)
                    {
                        tabPage.Enabled = false;
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
                lblPC.Text = grdsupplieradd.Rows.Count.ToString(); 
            }
        }
        public void udfnEditLoad()
        {
            try
            {
                if (varPOID != 0)
                {
                    Application.DoEvents();
                    //cmbStatus.SelectedValue = Convert.ToInt32(MainForm.objPUR_PurchaseOrderList.grdPurchaseorderlist.SelectedRows[0].Cells["po_stsid"].Value.ToString());

                    if (Convert.ToInt32(MainForm.objPUR_PurchaseOrderList.grdPurchaseorderlist.SelectedRows[0].Cells["po_stsid"].Value.ToString()) == 8)
                    {
                        chkStatus.Checked = false;
                    }
                    else if (Convert.ToInt32(MainForm.objPUR_PurchaseOrderList.grdPurchaseorderlist.SelectedRows[0].Cells["po_stsid"].Value.ToString()) == 9)
                    {
                        chkStatus.Checked = true;
                    }
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    objDs = objdserv.udfnPOEntry(3, pbSupplierId, pbScheduleid, 0, 0, 0, 0, 0, 0, "", "", varPOID, 0, "0", 0, 0, 0, 0, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                grdsupplieradd.Rows.Clear();
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string bulk = "0", unit = "0", MXSQ = "0", MXSTK = "0";
                                    if (Convert.ToString(objDs.Tables[0].Rows[i]["ORDERQTY"]) == "0")
                                    {
                                        bulk = "-";
                                    }
                                    else
                                    {
                                        bulk = Convert.ToString(objDs.Tables[0].Rows[i]["ORDERQTY"]);
                                    }
                                    if (Convert.ToString(objDs.Tables[0].Rows[i]["unitqty"]) == "0")
                                    {
                                        unit = "-";
                                    }
                                    else
                                    {
                                        unit = Convert.ToString(objDs.Tables[0].Rows[i]["unitqty"]);
                                    }
                                    if (Convert.ToString(objDs.Tables[0].Rows[i]["MXSQ"]) == "0")
                                    {
                                        MXSQ = "-";
                                    }
                                    else
                                    {
                                        MXSQ = Convert.ToString(objDs.Tables[0].Rows[i]["MXSQ"]);
                                    }
                                    if (Convert.ToString(objDs.Tables[0].Rows[i]["MXSTK"]) == "0")
                                    {
                                        MXSTK = "-";
                                    }
                                    else
                                    {
                                        MXSTK = Convert.ToString(objDs.Tables[0].Rows[i]["MXSTK"]);
                                    }
                                    lblNoRecordsFound.Visible = false;
                                    grdsupplieradd.Rows.Add(grdsupplieradd.Rows.Count + 1, objDs.Tables[0].Rows[i]["P.I Code"].ToString(),
                                    objDs.Tables[0].Rows[i]["Product Name"].ToString(), objDs.Tables[0].Rows[i]["Unit"].ToString(),
                                    objDs.Tables[0].Rows[i]["Unit Wt"].ToString(), objDs.Tables[0].Rows[i]["Unit Per box"].ToString(),
                                    objDs.Tables[0].Rows[i]["B.Unit Weight"].ToString(),
                                    objDs.Tables[0].Rows[i]["GST_Text"].ToString(), objDs.Tables[0].Rows[i]["MSQ"].ToString(), MXSQ,
                                    MXSTK, objDs.Tables[0].Rows[i]["PREVIOUS"].ToString(), objDs.Tables[0].Rows[i]["Other Supplier PRE.PEND"].ToString(),
                                    objDs.Tables[0].Rows[i]["PARTIAL"].ToString(), objDs.Tables[0].Rows[i]["Other Supplier PARITAL"].ToString(), objDs.Tables[0].Rows[i]["Reorder"].ToString()
                                    , bulk, objDs.Tables[0].Rows[i]["bunit"].ToString(), unit, objDs.Tables[0].Rows[i]["Unit"].ToString()
                                    , objDs.Tables[0].Rows[i]["totalqty"].ToString(), objDs.Tables[0].Rows[i]["totunit"].ToString()
                                    , objDs.Tables[0].Rows[i]["Finaltot"].ToString(), objDs.Tables[0].Rows[i]["finalunit"].ToString()
                                    , objDs.Tables[0].Rows[i]["Productid"].ToString(), objDs.Tables[0].Rows[i]["FLAG"].ToString(), Convert.ToString(objDs.Tables[0].Rows[i]["EDITFLAG"]),
                                    objDs.Tables[0].Rows[i]["STATUS"].ToString(), objDs.Tables[0].Rows[i]["PRSTSID"].ToString(), objDs.Tables[0].Rows[i]["PR_UTID"].ToString()
                                    , objDs.Tables[0].Rows[i]["PR_NettWeight"].ToString(), objDs.Tables[0].Rows[i]["PR_UPP"].ToString()
                                    , objDs.Tables[0].Rows[i]["bulkwtval"].ToString(), objDs.Tables[0].Rows[i]["B.UTID"].ToString(), objDs.Tables[0].Rows[i]["T.UTID"].ToString(),
                                    objDs.Tables[0].Rows[i]["P.Remarks"].ToString()
                                    );
                                    grdsupplieradd.Columns[10].ReadOnly = false;
                                }

                                cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["COMPANY"].ToString();
                                //cmbUnit.SelectedValue = objDs.Tables[0].Rows[0]["COMPANY"].ToString();
                                dpPlanDate.Text = objDs.Tables[0].Rows[0]["PODATE"].ToString();
                                dpPlanDate.Enabled = false;
                                txtpono.Text = objDs.Tables[0].Rows[0]["PONO"].ToString();
                                txtSupplier.Text = objDs.Tables[0].Rows[0]["Supplier"].ToString();
                                lblSupplierCode.Text = objDs.Tables[0].Rows[0]["SPID"].ToString();
                                lblschedule.Text = objDs.Tables[0].Rows[0]["SPSCID"].ToString();
                                lblKG.Text = objDs.Tables[0].Rows[0]["PO_PRTotQty"].ToString();
                                btnSave.Text = "Update";
                                if (VarStatusId == 12 || VarStatusId == 0)
                                {
                                    chkStatus.Enabled = false;
                                }
                                else
                                {
                                    chkStatus.Enabled = true;
                                }
                                udfnsupplierLoad();
                                grdsupplieradd.Columns["clmStsname"].Visible = true;
                            }

                            udfnIssuedDEtails();

                            DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdPendingorder_DataBindingComplete(grdPendingorder, args);

                            DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            Grdsupplieradd_DataBindingComplete(grdsupplieradd, args2);
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
        public void udfnIssuedDEtails()
        {
            try
            {

                dpissuedateandtime.Enabled = true;
                txtIssuedBy.Enabled = true;
                txtissuemodevalue.Enabled = true;
                txtTurnAroundTime.Enabled = true;
                cmbIssueMode.Enabled = true;
                txtIssuedBy.ReadOnly = false;
                txtissuemodevalue.ReadOnly = false;
                txtTurnAroundTime.ReadOnly = false;
                if (VarStatusId != 12)
                {
                    dpissuedateandtime.Enabled = false;
                    txtTurnAroundTime.Enabled = false;
                    if (Currentsts == 38 || Currentsts == 51)
                    {
                        grdsupplieradd.Columns["clmRemove"].Visible = false;
                        grdsupplieradd.Columns["clmOrderqty"].ReadOnly = true;
                        grdsupplieradd.Columns["clmunitorderqty"].ReadOnly = true;
                        grdsupplieradd.Columns["clmordertotalqty"].ReadOnly = true;
                        grdsupplieradd.Columns["Column2"].DefaultCellStyle.BackColor = Color.LightGray;
                        grdsupplieradd.Columns["clmOrderqty"].DefaultCellStyle.BackColor = Color.LightGray;
                        grdsupplieradd.Columns["clmordertotalqty"].DefaultCellStyle.BackColor = Color.LightGray;
                        grdsupplieradd.Columns["clmunitorderqty"].DefaultCellStyle.BackColor = Color.LightGray;


                        btnViewedProduct.Enabled = false;
                        btnAdd.Enabled = false;
                    }
                }
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnPOEntry(2, 0, 0, 0, 0, 0, 0, 0, 0, "", "", varPOID, 0, "0", 0, 0, 0, 0, 0, 0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            txtIssuedBy.Text = objDs.Tables[0].Rows[0]["Issuedby"].ToString();
                            txtTurnAroundTime.Text = objDs.Tables[0].Rows[0]["TAT"].ToString();
                            if (Convert.ToString(objDs.Tables[0].Rows[0]["IssueDate"]) != "")
                            {
                                dpissuedateandtime.Text = objDs.Tables[0].Rows[0]["IssueDate"].ToString();
                            }
                            else
                            {
                                dpissuedateandtime.Text = "";
                            }
                            if (objDs.Tables[0].Rows[0]["Issuemode"].ToString() != "" && objDs.Tables[0].Rows[0]["Issuemode"].ToString() != null)
                            {
                                cmbIssueMode.SelectedValue = objDs.Tables[0].Rows[0]["Issuemode"].ToString();
                            }
                            else
                            {
                                cmbIssueMode.SelectedValue = -1;
                            }
                            txtissuemodevalue.Text = objDs.Tables[0].Rows[0]["Issueremark"].ToString();
                            SPDataService objDServ = new SPDataService();
                            DataSet objd = new DataSet();
                            objd = objDServ.udfnMaster(4, 6, varPOID, "", "", 0, "", 0);
                            if (objd.Tables[0].Rows.Count != 0)
                            {
                                DateTime varmindate = DateTime.ParseExact(objd.Tables[0].Rows[0]["MINDATE"].ToString(), "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                                DateTime varmaxdate = DateTime.ParseExact(objd.Tables[0].Rows[0]["MAXDATE"].ToString(), "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                                dpissuedateandtime.MinDate = varmindate;
                                dpissuedateandtime.MaxDate = varmaxdate;
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
        public void udfnUnitDropdownload()
        {
            try
            {
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();

                int varViewType = 7;
                objDT = objdserv.udfnUnitList(varViewType, varUnitid, Convert.ToInt32(lblProductcode.Text));
                objdserv.CloseConnection();
                cmbUnit.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbUnit.ValueMember = "UTID";
                            cmbUnit.DisplayMember = "UT_Symbol";
                            cmbUnit.DataSource = objDT.Tables[0];
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
        public void udfnDropdownLoad()
        {
            SPDataService objdserv = new SPDataService();
            int varconcerntype = 4;
            if (btnSave.Text == "Save")
            {
                varconcerntype = 3;
            }
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

            cmbConcern.SelectedValue = Convert.ToInt32(MainForm.pbDefaultComId);
            DataBind objDataBind = new DataBind();
            DataService objdservice = new DataService();
            objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=44 AND MSTID NOT IN (135,136) OR MSTID=-1", "MST_DisplayText,MSTID", cmbIssueMode, "", "MST_DisplayText", "MSTID");
            objDataBind = null;
            cmbIssueMode.SelectedIndex = 0;
            int varViewType = 2;
            if (btnSave.Text == "Save")
            {
                varViewType = 1;
            }
        }
        public void udfntooltiphide()
        {
            try
            {
                errPO.Clear();
                tpsalesman.Active = false;
                tpsalemanph.Active = false;
                tpSuppliername.Active = false;
                tpProduct.Active = false;
                tpQty.Active = false;
                tppono.Active = false;
                tpsts.Active = false;
                txtpono.BackColor = Color.White;
                chkStatus.BackColor = Color.White;
                tpIssuemodeValues.Active = false;
                cmbIssueMode.BackColor = Color.White;
                tpIssueby.Active = false;
                tpIssuemode.Active = false;
                cmbIssueMode.BackColor = Color.White;
                tpIssuemodeValues.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }



        private void PUR_PurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    if (btnSave.Enabled == true)
                    {
                        udfnsave();
                    }
                }
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
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



        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose(); 
                MainForm.objPUR_PurchaseOrderList.udfnPOEntryLoad();
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

                if (varModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        udfntooltiphide();
                        this.Close();
                    }
                    else
                    { btnSave.Focus(); }
                }
                else
                {
                    if (varupdate == "0")
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            udfntooltiphide();
                            this.Close();
                        }
                    }
                    else
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
            finally
            {
                MainForm.objPUR_PurchaseOrderList.grdPurchaseorderlist.ClearSelection();
            }
        }


        private void btnDC_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamagedView = new PUR_PODamagedView();
                MainForm.objPUR_PODamagedView.varMasterType = "1";
                MainForm.objPUR_PODamagedView.ShowDialog();
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
                udfnsave();
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
        public void udfnClear()
        {
            try
            {
                txtProductName.Text = "";
                lblProductcode.Text = "0";
                txtSupplier.Text = "";
                varSuppliervalue = "";
                lblSupplierCode.Text = "0";
                txtProductQty.Text = "";
                grdsupplieradd.Rows.Clear();
                cmbConcern.SelectedValue = "-1";

                cmbUnit.SelectedIndex = 0;
                txtRemark.Text = "";
                lblPC.Text = "0";
                txtpono.Text = "";
                this.ActiveControl = txtSupplier;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnsave()
        {
            try
            {
                if (grdsupplieradd.RowCount > 0)
                {
                    bool varErrorFlag = true;
                    if (txtSupplier.Text == "")
                    {
                        errPO.SetError(txtSupplier, "Please select supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Please select supplier.", txtSupplier, 5000);
                        varErrorFlag = false;
                    }
                    //if (txtProductName.Text == "")
                    //{
                    //    errPO.SetError(txtProductName, "Please enter product");
                    //    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpProduct.ShowAlways = true;
                    //    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    //    varErrorFlag = false;
                    //}
                    //if (txtProductQty.Text == "")
                    //{
                    //    errPO.SetError(txtProductQty, "Please enter orderqty");
                    //    txtProductQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpQty.ShowAlways = true;
                    //    tpQty.Show("Please enter orderqty.", txtProductQty, 5000);
                    //    varErrorFlag = false;
                    //}
                    if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                    {
                        errPO.SetError(cmbConcern, "Please select company");
                        cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpsts.ShowAlways = true;
                        tpsts.Show("Please select company", cmbConcern, 5000);
                        varErrorFlag = false;
                    }
                    if (Convert.ToString(txtSupplier.Text) != "")
                    {
                        string varSupplierId = "0";
                        string[] values = new string[0];
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
                            errPO.SetError(txtSupplier, "Invalid supplier");
                            txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpSuppliername.ShowAlways = true;
                            tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                            lblSupplierCode.Text = "0";
                            lblschedule.Text = "0";
                            varErrorFlag = true;
                        }
                        else
                        {
                            errPO.Clear();
                            lblSupplierCode.Text = values[0];
                            lblschedule.Text = values[1];
                            txtSupplier.BackColor = Color.White;
                        }
                    }
                    //if (Convert.ToInt64(cmbStatus.SelectedValue) == -1)
                    //{
                    //    errPO.SetError(cmbStatus, "Please select status");
                    //    cmbStatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpsts.ShowAlways = true;
                    //    tpsts.Show("Please select status.", cmbStatus, 5000);
                    //    varErrorFlag = false;
                    //}

                    if (varErrorFlag == true)
                    {
                        udfntooltiphide();
                        DialogResult result1;
                        if (varReturnDC != "0")
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(72);
                            objDServ.CloseConnection();
                            result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        else
                        {
                            result1 = DialogResult.Yes;
                        }
                        if (result1 == DialogResult.Yes)
                        {
                            if (grdsupplieradd.Rows.Count > 0)
                            {
                                if (lblSupplierCode.Text != "0" && lblschedule.Text != "0")
                                {
                                    string result = "", varorginator = "Po Create";
                                    int varviewtype = 0, POUpdate = varPOID;
                                    if (btnSave.Text == "Update")
                                    {
                                        varviewtype = 1;
                                        varorginator = "Po Update";
                                    }
                                    varRecqty = 0;
                                    SPDataService objspdservice = new SPDataService();
                                    DataTable objPurchaseOrder = new DataTable();
                                    objPurchaseOrder.TableName = "TRN_PO_Product";
                                    objPurchaseOrder.Columns.Add("POPR_PRID", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_MSQ", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_ReorderQty", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_OrderQty", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_Flag", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_SPSCID", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_UTID", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_EditFlag", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_UTOrderQty", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_TOTOrderQty", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_KGORDERQTY", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_BulkUTID", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_QUTID", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_UPP", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_NetWeight", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_Remarks", typeof(string));
                                    objPurchaseOrder = udfnPurchaseProduct();

                                    int varstatus = 0;
                                    if (chkStatus.Checked == true)
                                    {
                                        varstatus = 9;
                                    }
                                    else if (chkStatus.Checked == false)
                                    {
                                        varstatus = 8;
                                        if (VarStatusId == 11)
                                        {
                                            varstatus = 11;
                                        }
                                    }
                                    if (varcount == 0)
                                    {
                                        if (chkStatus.Checked == false)
                                        {
                                            if (varRecqty != 0)
                                            {
                                                SPDataService objDServ = new SPDataService();
                                                string varMessage = objDServ.udfnGetMessages(99);
                                                objDServ.CloseConnection();
                                                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            }
                                            else { result1 = DialogResult.Yes; }
                                        }
                                        else { result1 = DialogResult.Yes; }
                                        if (result1 == DialogResult.Yes)
                                        {
                                            result = objspdservice.udfnPurchaseEntry(varviewtype, POUpdate, Convert.ToInt32(cmbConcern.SelectedValue),
                                            txtpono.Text, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), "", varorginator, txtRemark.Text,
                                            txtTurnAroundTime.Text, objPurchaseOrder, "", "", "", "", Convert.ToInt32(varstatus), dpPlanDate.Text, Convert.ToInt32(cmbUnit.SelectedValue), Convert.ToDouble(lblKG.Text), 0);
                                            objspdservice.CloseConnection();
                                            string[] varvalue = result.Split('~');
                                            string POUpdatevalue = "0";
                                            if (varvalue[0] == "3")
                                            {
                                                MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.ActiveControl = txtSupplier;
                                                MainForm.objPUR_PurchaseOrderList.udfnPOEntryLoad();
                                                varModifiedFlag = 0;
                                                varupdate = "1";
                                                if (btnSave.Text != "Update")
                                                {
                                                    POUpdatevalue = varvalue[2];
                                                }
                                                else
                                                {
                                                    POUpdatevalue = Convert.ToString(POUpdate);
                                                }
                                                SPDataService objDServ = new SPDataService();
                                                string varMessage = objDServ.udfnGetMessages(87);
                                                objDServ.CloseConnection();
                                                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (result1 == DialogResult.Yes)
                                                {
                                                    try
                                                    {
                                                        string varHeader = "";
                                                        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO.rpt");
                                                        varHeader = "Purchase Order";
                                                        objBillreport.SetParameterValue("paraPOID", Convert.ToInt32(POUpdatevalue), objBillreport.Subreports[0].Name.ToString());
                                                        objBillreport.SetParameterValue("paraPOID", Convert.ToInt32(POUpdatevalue), objBillreport.Subreports[1].Name.ToString());
                                                        objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(cmbConcern.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                                                        objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(cmbConcern.SelectedValue), objBillreport.Subreports[1].Name.ToString());
                                                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[0].Name.ToString());
                                                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[0].Name.ToString());
                                                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[1].Name.ToString());
                                                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[1].Name.ToString());
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
                                                    finally
                                                    {
                                                    }

                                                    udfnClear();
                                                    udfnclose();
                                                }
                                                else
                                                {
                                                    udfnclose();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                if (varvalue[0] == "5")
                                                {
                                                    string[] values = varvalue[2].Split(',');
                                                    for (int i = 0; i < grdsupplieradd.Rows.Count; i++)
                                                    {
                                                        foreach (string value in values)
                                                        {
                                                            if (Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value) == value || Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value) == value)
                                                            {

                                                                grdsupplieradd.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                                                grdsupplieradd.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                            this.ActiveControl = txtProductName;
                                        }
                                    }
                                    else
                                    {
                                        SPDataService objDServ = new SPDataService();
                                        string varMessage = objDServ.udfnGetMessages(77);
                                        objDServ.CloseConnection();
                                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool varErrorFlag = true;
                lvproduct.Visible = false;
                if (txtSupplier.Text == "")
                {
                    errPO.SetError(txtSupplier, "Please enter supplier");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                    varErrorFlag = false;
                }
                if (txtProductName.Text == "")
                {
                    errPO.SetError(txtProductName, "Please enter product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    varErrorFlag = false;
                }
                if (txtProductQty.Text == "")
                {
                    errPO.SetError(txtProductQty, "Please enter orderqty");
                    txtProductQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter orderqty.", txtProductQty, 5000);
                    varErrorFlag = false;
                }
                if (txtProductQty.Text == "0")
                {
                    errPO.SetError(txtProductQty, "Order quantity should not be 0!");
                    txtProductQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Order quantity should not be 0!.", txtProductQty, 5000);
                    varErrorFlag = false;
                }
                if (Convert.ToInt32(cmbUnit.SelectedValue) == -1 || Convert.ToString(cmbUnit.Text) == "")
                {
                    errPO.SetError(cmbUnit, "Please select unit");
                    cmbUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please select unit!.", cmbUnit, 5000);
                    varErrorFlag = false;
                }
                if (Convert.ToString(txtSupplier.Text) != "")
                {
                    //string varsuppliername = "0";
                    //DataService objDserv = new DataService();
                    //varsuppliername = objDserv.displaydata("SELECT COUNT(*) FROM MR_Supplier WHERE SP_Name='" + txtSupplier.Text + "'");
                    //if (varsuppliername == "0")
                    //{
                    //    lblSupplierCode.Text = "0";
                    //    lblschedule.Text = "0";
                    //    errPO.SetError(txtSupplier, "Invalid supplier");
                    //    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpSuppliername.ShowAlways = true;
                    //    tpSuppliername.Show("Invalid supplier", txtSupplier, 5000);
                    //    varErrorFlag = false;
                    //    udfnListViewData();
                    //}
                    //else
                    //{
                    //    errPO.Clear();
                    //    txtSupplier.BackColor = Color.White;
                    //}
                }
                if (Convert.ToString(txtProductName.Text) != "")
                {
                    //string varproductname = "0", varproductID="0";
                    //DataService objDserv = new DataService();
                    //varproductname = objDserv.displaydata("SELECT COUNT(*) FROM MR_PRODUCT WHERE PR_ENAME='" + txtProductName.Text + "'");
                    //if (varproductname == "0")
                    //{
                    //    lblProductcode.Text = "0"; 
                    //    errPO.SetError(txtProductName, "Invalid product");
                    //    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpProduct.ShowAlways = true;
                    //    tpProduct.Show("Invalid supplier", txtProductName, 5000);
                    //    varErrorFlag = false; 
                    //}
                    //else
                    //{ 
                    //    varproductID = objDserv.displaydata("SELECT PRID FROM MR_PRODUCT WHERE PR_ENAME='" + txtProductName.Text + "'");
                    //    lblProductcode.Text = varproductID;
                    //    errPO.Clear();
                    //    txtProductName.BackColor = Color.White;
                    //}
                    //objDserv.CloseConnection(); 
                    string varproductID = "0";
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 39;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Product.paraProductName = txtProductName.Text;
                    DataSet objDsproductId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsproductId = objDserv.udfnproductmasterlist(objMR_Product);
                    //objDsproductId = objDserv.udfnproductmasterlist(39, 0, 0, 0, 0, "", "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, txtProductName.Text, Convert.ToInt32(lblSupplierCode.Text), "", "", null, 0, null, "", "");

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
                        errPO.SetError(txtProductName, "Invalid product");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpProduct.ShowAlways = true;
                        tpProduct.Show("Invalid product", txtProductName, 5000);
                        varErrorFlag = false;

                    }
                    else
                    {
                        lblProductcode.Text = varproductID;
                        errPO.Clear();
                        txtProductName.BackColor = Color.White;
                    }
                }
                if (varErrorFlag == true)
                {
                    int varflag = 0;
                    lblNoRecordsFound.Visible = false; 
                    txtProductQty.BackColor = Color.White;
                    foreach (DataGridViewRow row in grdsupplieradd.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                        {
                            string gridValue1 = row.Cells[11].Value.ToString();

                            if (gridValue1.ToUpper() == (lblProductcode.Text).Trim().ToUpper())
                            {
                                varflag = 1;
                            }
                        }
                    }
                    if (Convert.ToInt32(lblProductcode.Text) != 0 && Convert.ToInt32(lblSupplierCode.Text) != 0)
                    {
                        if (varflag == 0)
                        {
                            MR_Supplier objMR_Supplier = new MR_Supplier();
                            objMR_Supplier.ViewType = 28;
                            objMR_Supplier.paraSupplierid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text);
                            objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text);
                            objMR_Supplier.paraStatusId = Convert.ToInt32(cmbUnit.SelectedValue);
                            objMR_Supplier.paraCompanycode = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue);
                            objMR_Supplier.paraProducts = addproductid;
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                            objspdservice.CloseConnection();
                            string defflag = "0";
                            if (objDs != null)
                            {
                                if (objDs.Tables[0].Rows.Count > 0)
                                {
                                    if (Convert.ToString(objDs.Tables[0].Rows[0]["prid"]) == Convert.ToString((addproductid)))
                                    {
                                        defflag = Convert.ToString(objDs.Tables[0].Rows[0]["flag"]);
                                    }
                                    else
                                    {
                                        defflag = "3";
                                    }
                                }
                            }
                            varBulkunitqty = 0; varUnitqty = 0;
                            if (varBulkunitvalue == (Convert.ToInt32(cmbUnit.SelectedValue)))
                            {
                                varBulkunitqty = 0; if (txtProductQty.Text != "") { varBulkunitqty = Convert.ToDecimal(txtProductQty.Text); }
                                qtyFlag = 1;
                            }
                            if (varUnitvalue == (Convert.ToInt32(cmbUnit.SelectedValue)))
                            {
                                varUnitqty = 0; if (txtProductQty.Text != "") { varUnitqty = Convert.ToDecimal(txtProductQty.Text); }
                                qtyFlag = 2;
                            }


                            //function for order qty weight
                            udfnweightcalc(varUPP, varNetweight, varBulkunitqty, varUnitqty, varTotalunitqty, varBulkunitvalue);

                            string bulk = "0", unit = "0", MXSQ = "0", MXSTK = "0";
                            if (varFinalBulkUnit == 0)
                            {
                                bulk = "-";
                            }
                            else
                            {
                                bulk = Convert.ToString(varFinalBulkUnit);
                            }
                            if (varFinalUnit == 0)
                            {
                                unit = "-";
                            }
                            else
                            {
                                unit = Convert.ToString(varFinalUnit);
                            }
                            if (Convert.ToString(var_MXSQ) == "0")
                            {
                                MXSQ = "-";
                            }
                            else
                            {
                                MXSQ = Convert.ToString(var_MXSQ);
                            }
                            if (Convert.ToString(varSTOCK) == "0")
                            {
                                MXSTK = "-";
                            }
                            else
                            {
                                MXSTK = Convert.ToString(varSTOCK);
                            }
                            udfnProductAdd();
                            //string[] unitparts = unitperbox.Split('/'); 
                            //string bunits = unitparts[0].Trim() +'/' + Convert.ToString(cmbUnit.Text);
                            grdsupplieradd.Rows.Add(grdsupplieradd.Rows.Count + 1, (varPICode).Trim(), (varEName).Trim(), (var_Symbol).Trim(),
                            (unitweight), unitperbox, bulkunitweight, (var_Text).Trim(), (var_RMinSaleQty).Trim(), (MXSQ).Trim(), (MXSTK).Trim(), (varPrevious).Trim(), (varOtherSupPrevious).Trim(),
                            (varPARITAL).Trim(), (varOtherSupPartial).Trim(), (varReOrderQty).Trim(), bulk, var_BulkSymbol, unit, var_Symbol, varFinalTotalQty, var_Symbol, varFinalTotalKg, var_TotSymbol,
                            (addproductid).Trim(), defflag, 1, "", 10, (Convert.ToInt32(varUnitvalue)), varNetweight, varUPP, 0, varBulkunitvalue, varTotalunitvalue,"",lblUnitDecimal.Text);

                            grdsupplieradd.Columns[10].ReadOnly = false;
                            udfnrowclear();
                            grdsupplieradd.Sort(grdsupplieradd.Columns[1], ListSortDirection.Ascending);
                            for (int i = 0; i < grdsupplieradd.RowCount; i++)
                            {
                                grdsupplieradd.Rows[i].Cells["clmsno"].Value = i + 1;
                            }
                            txtProductName.Focus();
                            DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            Grdsupplieradd_DataBindingComplete(grdsupplieradd, args2);
                            varModifiedFlag = 1;
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(70);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                lblPC.Text = grdsupplieradd.Rows.Count.ToString();
                udfnTotalKG();
                grdsupplieradd.ClearSelection();
            }
        }
        public void udfnTotalKG()
        {
            try
            {
                decimal vartot = 0;
                foreach (DataGridViewRow row in grdsupplieradd.Rows)
                {
                    // Check if the cell value is not null and can be converted to a decimal
                    if (row.Cells["clmtotalkg"].Value != null && decimal.TryParse(row.Cells["clmtotalkg"].Value.ToString(), out decimal cellValue))
                    {
                        vartot += cellValue;
                    }
                }
                lblKG.Text = Convert.ToString(vartot);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public DataTable udfnPurchaseProduct()
        {
            DataTable objPurchaseOrder = new DataTable();
            try
            {
                varcount = 0;
                objPurchaseOrder.TableName = "TRN_PO_Product";
                objPurchaseOrder.Columns.Add("POPR_PRID", typeof(int));
                objPurchaseOrder.Columns.Add("POPR_MSQ", typeof(float));
                objPurchaseOrder.Columns.Add("POPR_ReorderQty", typeof(float));
                objPurchaseOrder.Columns.Add("POPR_OrderQty", typeof(float));
                objPurchaseOrder.Columns.Add("POPR_Flag", typeof(int));
                objPurchaseOrder.Columns.Add("POPR_SPSCID", typeof(int));
                objPurchaseOrder.Columns.Add("POPR_UTID", typeof(int));
                objPurchaseOrder.Columns.Add("POPR_EditFlag", typeof(int));
                objPurchaseOrder.Columns.Add("POPR_UTOrderQty", typeof(float));
                objPurchaseOrder.Columns.Add("POPR_TOTOrderQty", typeof(float));
                objPurchaseOrder.Columns.Add("POPR_KGORDERQTY", typeof(float));
                objPurchaseOrder.Columns.Add("POPR_BulkUTID", typeof(int));
                objPurchaseOrder.Columns.Add("POPR_QUTID", typeof(int));
                objPurchaseOrder.Columns.Add("POPR_UPP", typeof(float));
                objPurchaseOrder.Columns.Add("POPR_NetWeight", typeof(float));
                objPurchaseOrder.Columns.Add("POPR_Remarks", typeof(string));
                for (int i = 0; i < grdsupplieradd.Rows.Count; i++)
                {

                    double orderqty = 0;
                    if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmOrderqty"].Value) == "" || Convert.ToString(grdsupplieradd.Rows[i].Cells["clmOrderqty"].Value) == "0")
                    {
                        orderqty = 0;
                        varcount++;
                        grdsupplieradd.Rows[i].Cells["clmOrderqty"].Style.BackColor = Color.LightPink;
                        grdsupplieradd.Rows[i].Cells["clmOrderqty"].Style.ForeColor = Color.Black;
                    }
                    else if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmunitorderqty"].Value) == "" || Convert.ToString(grdsupplieradd.Rows[i].Cells["clmunitorderqty"].Value) == "0")
                    {
                        orderqty = 0;
                        varcount++;
                        grdsupplieradd.Rows[i].Cells["clmunitorderqty"].Style.BackColor = Color.LightPink;
                        grdsupplieradd.Rows[i].Cells["clmunitorderqty"].Style.ForeColor = Color.Black;
                    }
                    else if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Value) == "" || Convert.ToString(grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Value) == "0")
                    {
                        orderqty = 0;
                        varcount++;
                        grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Style.BackColor = Color.LightPink;
                        grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Style.ForeColor = Color.Black;
                    }
                    else if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmMXSQ"].Value) != "" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmMXSQ"].Value) != "0" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmMXSQ"].Value) != "-")
                    {
                        decimal stockval = 0;
                        if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmstock"].Value) == "-" || Convert.ToString(grdsupplieradd.Rows[i].Cells["clmstock"].Value) == "")
                        {
                            stockval = 0;
                        }
                        else
                        {
                            stockval = Convert.ToDecimal(grdsupplieradd.Rows[i].Cells["clmstock"].Value);
                        }
                        if (stockval < Convert.ToDecimal(grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Value))
                        {
                            orderqty = 0;
                            varRecqty = -1;
                            grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Style.BackColor = Color.LightPink;
                            grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Style.ForeColor = Color.Black;
                        }
                    }

                    else
                    {
                        grdsupplieradd.Rows[i].Cells["clmOrderqty"].Style.BackColor = Color.PaleGreen;
                        grdsupplieradd.Rows[i].Cells["clmOrderqty"].Style.ForeColor = Color.Black;
                        grdsupplieradd.Rows[i].Cells["clmunitorderqty"].Style.BackColor = Color.PaleGreen;
                        grdsupplieradd.Rows[i].Cells["clmunitorderqty"].Style.ForeColor = Color.Black;
                        grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Style.BackColor = Color.PaleGreen;
                        grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Style.ForeColor = Color.Black;
                    }
                    //else
                    //{
                    //    orderqty = Convert.ToDouble(grdsupplieradd.Rows[i].Cells["clmOrderqty"].Value);
                    //}


                    //if (orderqty != 0)
                    //{
                    //    DataService objDser = new DataService();
                    //    objPurchaseOrder.Rows.Add(Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value), Convert.ToInt64(grdsupplieradd.Rows[i].Cells["clmMSQ"].Value)
                    //    , Convert.ToDouble(grdsupplieradd.Rows[i].Cells["clmreorderqty"].Value), orderqty,
                    //    Convert.ToInt32(grdsupplieradd.Rows[i].Cells["clmflag"].Value));
                    //}
                }

                if (varcount == 0)
                {
                    for (int i = 0; i < grdsupplieradd.Rows.Count; i++)
                    {

                        double orderqty = 0;
                        if (orderqty == 0)
                        {
                            string bulk = "0", unit = "0";
                            if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmOrderqty"].Value) == "-")
                            {
                                bulk = "0";
                            }
                            else
                            {
                                bulk = Convert.ToString(grdsupplieradd.Rows[i].Cells["clmOrderqty"].Value);
                            }
                            if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmunitorderqty"].Value) == "-")
                            {
                                unit = "0";
                            }
                            else
                            {
                                unit = Convert.ToString(grdsupplieradd.Rows[i].Cells["clmunitorderqty"].Value);
                            }

                            DataService objDser = new DataService();
                            objPurchaseOrder.Rows.Add(Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value), Convert.ToInt64(grdsupplieradd.Rows[i].Cells["clmMSQ"].Value)
                            , Convert.ToDouble(grdsupplieradd.Rows[i].Cells["clmreorderqty"].Value), bulk, Convert.ToInt32(grdsupplieradd.Rows[i].Cells["clmflag"].Value), Convert.ToInt32(lblschedule.Text),
                            Convert.ToInt32(grdsupplieradd.Rows[i].Cells["UTID"].Value), Convert.ToInt32(grdsupplieradd.Rows[i].Cells["clmeditflag"].Value),
                            Convert.ToDouble(unit), Convert.ToDecimal(grdsupplieradd.Rows[i].Cells["clmordertotalqty"].Value),
                            Convert.ToDouble(grdsupplieradd.Rows[i].Cells["clmtotalkg"].Value), Convert.ToInt32(grdsupplieradd.Rows[i].Cells["BulkUTID"].Value),
                            Convert.ToInt32(grdsupplieradd.Rows[i].Cells["QTID"].Value), Convert.ToDouble(grdsupplieradd.Rows[i].Cells["clmUPP"].Value),
                            Convert.ToDouble(grdsupplieradd.Rows[i].Cells["clmNettWeight"].Value),
                            Convert.ToString(grdsupplieradd.Rows[i].Cells["clmremarks"].Value)
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
            return objPurchaseOrder;
        }
        public void udfnrowclear()
        {
            try
            {
                lblProductcode.Text = "0";
                txtProductName.Text = "";
                txtProductQty.Text = "";
                lblWeightvalue.Text = "";
                lblMxsq.Text = "";
                cmbUnit.DataSource = null;
                grdpossiblesupplier.Rows.Clear();
                lblPossibleSupplierRecords.Visible = true;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnNewUnit_Click(object sender, EventArgs e)
        {
            try
            {
                pbunitname = "";
                int varcmbconcernid = Convert.ToInt32(cmbConcern.SelectedValue);
                varcmbunitid = 0;
                if (Convert.ToString(cmbUnit.SelectedValue) != "")
                {
                    pbunitname = cmbUnit.Text;
                }
                MainForm.objPUR_BulkUnit = new PUR_BulkUnit();
                MainForm.objPUR_BulkUnit.ShowDialog();
                udfnUnitDropdownload();

                udfnProductAdd();
                //cmbConcern.SelectedValue = varcmbconcernid;
                if (varcmbunitid != 0)
                {
                    cmbUnit.SelectedValue = varcmbunitid;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnViewedProduct_Click(object sender, EventArgs e)
        {
            try
            {
                pbProductsCode = "";
                for (int i = 0; i < grdsupplieradd.Rows.Count; i++)
                {
                    if (pbProductsCode == "")
                    {
                        pbProductsCode = Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value);
                    }
                    else
                    {
                        pbProductsCode = pbProductsCode + ',' + Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value);
                    }
                }
                MainForm.objPUR_POMappedProducts = new PUR_POMappedProducts();
                MainForm.objPUR_POMappedProducts.ShowDialog();

                DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                Grdsupplieradd_DataBindingComplete(grdsupplieradd, args2);
                varModifiedFlag = 1;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            finally
            {
                lblPC.Text = grdsupplieradd.Rows.Count.ToString();
                if (grdsupplieradd.Rows.Count != 0) { lblNoRecordsFound.Visible = false; }
            }
        }

        private void BtnSalesmanSave_Click(object sender, EventArgs e)
        {
            try
            {
                int errorflag = 0;
                if (txtSalesManMobile.Text.Length != 10 && txtSalesManMobile.Text != "")
                {
                    errPO.SetError(txtSalesManMobile, "Please enter valid salesman mobile No.");
                    txtSalesManMobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpsalemanph.ShowAlways = true;
                    tpsalemanph.Show("Please enter valid salesman mobile No.", txtSalesManMobile, 5000);
                    errorflag = 1;
                }
                if (txtSalesManwhatsapp.Text.Trim() != "")
                {
                    if (txtSalesManwhatsapp.Text.Length != 10)
                    {
                        errPO.SetError(txtSalesManwhatsapp, "Please enter valid salesman whatsapp No.");
                        txtSalesManwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpsalemanph.ShowAlways = true;
                        tpsalemanph.Show("Please enter valid salesman whatsapp No.", txtSalesManwhatsapp, 5000);
                        errorflag = 1;
                    }
                }
                if (txtSalesManName.Text.Trim() == "")
                {
                    errPO.SetError(txtSalesManName, "Please enter salesman name");
                    txtSalesManName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpsalemanph.ShowAlways = true;
                    tpsalemanph.Show("Please enter salesman name.", txtSalesManName, 5000);
                    errorflag = 1;
                }
                if (errorflag == 0)
                {
                    udfnSupplierOrderSave();
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
        public void udfntphide()
        {
            try
            {
                tpsalemanph.Active = false;
                tpsalesman.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSupplierOrderSave()
        {
            try
            {
                if (Convert.ToInt32(lblSupplierCode.Text) != 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    string result = "";
                    errPO.Clear();
                    udfnSchedulecolorchange();
                    result = objspdservice.udfnSupplierMaster(11, Convert.ToInt32(lblSupplierCode.Text), "", "", "", 0, "", "", "", "", "", "", 0,
                    0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Salesman Details Update PO", 0, "", 0, 0, 0, 0, 0, txtSalesManName.Text,
                    "", txtSalesManMobile.Text, txtSalesManwhatsapp.Text, 0, "", Convert.ToInt32(lblschedule.Text), 0, "", "", "", "", "", "", "", "", "", 0, "", 0);

                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {

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
                udfnsalesman();
            }
        }
        private void GrdPendingorder_DoubleClick(object sender, EventArgs e)
        {

        }
        public void udfnSchedulecolorchange()
        {
            try
            {
                txtSalesManwhatsapp.BackColor = Color.White;
                txtSalesManName.BackColor = Color.White;
                txtSalesManMobile.BackColor = Color.White;
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
                MainForm.objPUR_PODamaged.varMasterType = "1";
                MainForm.objPUR_PODamaged.ShowDialog();
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

        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.White;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errPO.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpsts.ShowAlways = true;
                    tpsts.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    errPO.Clear();
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
                    dpPlanDate.Focus();
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
                if (btnSave.Text == "Save")
                {
                    if (grdsupplieradd.Rows.Count > 0)
                    {
                        if (varcomid != Convert.ToString(cmbConcern.SelectedValue))
                        {
                            if (Convert.ToString(cmbConcern.SelectedValue) != "-1")
                            {
                                SPDataService objDServ = new SPDataService();
                                string varMessage = objDServ.udfnGetMessages(78);
                                objDServ.CloseConnection();

                                DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    grdsupplieradd.Rows.Clear();
                                    txtSupplier.Text = "";
                                    varSuppliervalue = "";
                                    lblSupplierCode.Text = "0";
                                    ClearSupplier();
                                    lblPC.Text = "0";
                                }
                                else
                                {
                                   cmbConcern.SelectedValue= varcomid;
                                }
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

                txtSalesManMobile.Text = "";
                txtSalesManName.Text = "";
                txtSalesManwhatsapp.Text = "";
                tbSupplierDetails.Enabled = false;
                grdPendingorder.Rows.Clear();
                grdpossiblesupplier.Rows.Clear();
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
                if (btnSave.Text == "Save")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpPlanDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetVoucherNo("38", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string pono = parts[0];
                        if (pono != "")
                        {
                            txtpono.Text = pono;
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(75);
                            objDServ.CloseConnection();
                            txtpono.Text = "";
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
                        txtpono.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpPlanDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpPlanDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpPlanDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpPlanDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpPlanDate_KeyDown(object sender, KeyEventArgs e)
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
                    txtProductName.Focus();
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
                if (txtSupplier.Text == "")
                {
                    errPO.SetError(txtSupplier, "Please enter supplier");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                    lblSupplierCode.Text = "0";
                    lblschedule.Text = "0";
                    grdsupplieradd.Rows.Clear();
                    ClearSupplier();
                    lblPC.Text = "0";
                    lblNoRecordsFound.Visible = true;
                }
                else
                {
                    errPO.Clear();
                    txtSupplier.BackColor = Color.White;
                    tpSuppliername.Active = false;
                    lblNoRecordsFound.Visible = false;
                }
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
                    objMR_Supplier.ParaPOID = varPOID;
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

        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                if (Convert.ToString(txtSupplier.Text) != "")
                {
                    if (VarStatusId != 14 || VarStatusId != 33)
                    {
                        if (lblSupplierCode.Text != "0")
                        {
                            btnViewedProduct.Enabled = true;
                        }
                    }
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
                        errPO.SetError(txtSupplier, "Invalid supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        grdsupplieradd.DataSource = null;
                        ClearSupplier();
                        lblPC.Text = "0";

                    }
                    else
                    {
                        errPO.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White;
                        if (VarPrevSupplierid != Convert.ToInt32(lblSupplierCode.Text))
                        {
                            udfnsupplierLoad();
                        }
                    }
                    VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                }
                txtProductName.BackColor = Color.LemonChiffon;
                DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                GrdPendingorder_DataBindingComplete(grdPendingorder, args);
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
                errPO.Clear();
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
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductQty.Focus();
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

        private void TxtProductQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductQty.Text == "")
                {
                    errPO.SetError(txtProductQty, "Please enter orderqty");
                    txtProductQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter orderqty.", txtProductQty, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtProductQty.Text).Trim(), Convert.ToInt32(lblUnitDecimal.Text)); txtProductQty.Text = Qty;
                errPO.Clear();
                txtProductQty.BackColor = Color.White;
                tpQty.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbUnit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtProductQty_Enter(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
                txtProductQty.BackColor = Color.LemonChiffon;
                if (txtProductName.Text == "")
                {
                    lblProductcode.Text = "0";
                }
                if (Convert.ToInt32(lblProductcode.Text) != 0)
                {
                    btnNewUnit.Enabled = true;
                }
                else
                {
                    btnNewUnit.Enabled = false;
                    lblWeightvalue.Text = "";
                    lblMxsq.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void BtnNewUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                btnNewUnit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnNewUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                btnNewUnit.BackColor = Color.Transparent;
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
                btnAdd.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnViewedProduct_Leave(object sender, EventArgs e)
        {
            try
            {
                btnViewedProduct.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnViewedProduct_Enter(object sender, EventArgs e)
        {
            try
            {
                btnViewedProduct.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesManName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSalesManName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesManName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSalesManName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSalesManMobile.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManMobile_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesManMobile.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManMobile_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesManMobile.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManMobile_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSalesManwhatsapp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManwhatsapp_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesManwhatsapp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManwhatsapp_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesManwhatsapp.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManwhatsapp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSalesmanSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSalesmanSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSalesmanSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSalesmanSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSalesmanSave.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSalesmanUndo_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSalesmanUndo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSalesmanUndo_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSalesmanUndo.BackColor = Color.White;
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

        private void BtnReturnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnReturnSave.Enabled = false;
                if (Convert.ToInt32(lblSupplierCode.Text) != 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    string result = "", varoriginator = "";
                    int Vartype = 0;
                    SupplierUpdate = Convert.ToInt32(lblSupplierCode.Text);
                    //if (Convert.ToInt32(varsupplierID) != 0)
                    //{
                    //    SupplierUpdate = Convert.ToInt32(varsupplierID);
                    //}
                    //else
                    //{
                    //    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                    //} 
                    result = objspdservice.udfnSupplierMaster(6, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, Convert.ToInt32(cmbReturnPolicy.SelectedValue), Convert.ToInt32(cmbReturnType.SelectedValue), 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Update supplier order type", 0, "", 0, vardayID, varMonthID, varWeekID, vardayMonthID, "", "", "", "", 0, "", 0, 0, "", "", "", "", "", "", "", "", "", 0, "", 0);
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MainForm.objCP_Supplierlist.udfnList();
                        cmbReturnPolicy.Focus();
                        udfnSupplierDetails();
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
                btnReturnSave.Enabled = true;
                btnReturnSave.Focus();
                udfnReturnCycle();
            }
        }

        public void udfnSupplierDetails()
        {
            try
            {
                if (Convert.ToInt32(lblSupplierCode.Text) > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 27;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.ParaPOID = varPOID;
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
                            cmbReturnPolicy.SelectedValue = Convert.ToInt64(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                            cmbReturnType.SelectedValue = objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString(); ;
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
                for (int i = 0; i < grdsupplieradd.Rows.Count; i++)
                {
                    if (varProductsCodes == "")
                    {
                        varProductsCodes = Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value);
                    }
                    else
                    {
                        varProductsCodes = varProductsCodes + ',' + Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value);
                    }
                }
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductName.Text.Length > 0)
                {
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 29;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.ParaScheduleid = Convert.ToString(lblschedule.Text);
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Product.ParaProductsCode = varProductsCodes;
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
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["pr_retailrate"].ToString(), objDs.Tables[0].Rows[i]["UT_Decimal"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    objList.SubItems[0].Font = new Font("Oswald Regular", 11.25F);
                                    objList.SubItems[5].Font = new Font("Oswald Regular", 11.25F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;

                                lvproduct.Columns[0].Width = 100;
                                lvproduct.Columns[3].Width = 0;
                                lvproduct.Columns[4].Width = 50;
                                lvproduct.Columns[5].Width = 60;
                                lvproduct.Columns[6].Width = 0;
                                if (VarSearchFlag == false)
                                {
                                    lvproduct.Columns[1].Width = 320;
                                    lvproduct.Columns[2].Width = 0;
                                }
                                else
                                {
                                    lvproduct.Columns[1].Width = 0;
                                    lvproduct.Columns[2].Width = 320;
                                }
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

        private void Dpissuedateandtime_Leave(object sender, EventArgs e)
        {
            //try
            //{ 
            //   dpissuedateandtime.col
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void Dpissuedateandtime_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtIssuedBy.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTurnAroundTime_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Dpissuedateandtime_Enter(object sender, EventArgs e)
        {

            //try
            //{
            //    txtIssuedBy.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void TxtIssuedBy_Leave(object sender, EventArgs e)
        {
            try
            {
                txtIssuedBy.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIssuedBy_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbIssueMode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Lvproduct_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            try
            { // Set the background color of the header
                //using (Brush brush = new SolidBrush(Color.SlateGray)) // Change this to your desired color
                //{
                //    e.Graphics.FillRectangle(brush, e.Bounds);
                //}

                //// Draw the header text
                //using (StringFormat sf = new StringFormat())
                //{
                //    sf.Alignment = StringAlignment.Center;
                //    sf.LineAlignment = StringAlignment.Center;

                //    using (Font headerFont = new Font("Oswald Regular", 10)) // Change this to your desired font
                //    {
                //        e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, e.Bounds, sf);
                //    }
                //} 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnCancel_Enter(object sender, EventArgs e)
        {
            try
            {
                btnCancel.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnCancel_Leave(object sender, EventArgs e)
        {
            try
            {
                btnCancel.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Lvproduct_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            try
            {
                // Handle the drawing for selected items
                //if ((e.State & ListViewItemStates.Selected) != 0)
                //{
                //    using (Brush brush = new SolidBrush(Color.White))
                //    {
                //        e.Graphics.FillRectangle(brush, e.Bounds);
                //    }

                //    // Change the text color for selected items
                //    e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                //}
                //else
                //{
                //    e.DrawDefault = true;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Lvproduct_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                //e.DrawText();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductQty_KeyPress(object sender, KeyPressEventArgs e)
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
                if (Convert.ToInt32(lblUnitDecimal.Text) == 0)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= Convert.ToInt32(lblUnitDecimal.Text) + 1)
                    {
                        e.Handled = true;
                    }
                }
                if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = false;
                }
                if (Convert.ToInt32(lblUnitDecimal.Text) == 0)
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
        //private void TxtProductQty_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {  
        //        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
        //        {
        //            e.Handled = true;
        //        }
        //        // Allow only one decimal point                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
        //        {
        //            e.Handled = true;
        //        }
        //        TextBox textBox = (TextBox)sender;
        //        if (Convert.ToInt32(lblUnitDecimal.Text) == 0)
        //        {
        //            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //            {
        //                e.Handled = true;
        //            }
        //        }
        //        else
        //        {
        //            if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= Convert.ToInt32(lblUnitDecimal.Text) + 1)
        //            {
        //                e.Handled = true;
        //            }
        //        }
        //        if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
        //        {
        //            e.Handled = false;
        //        }
        //        if (Convert.ToInt32(lblUnitDecimal.Text) == 0)
        //        {
        //            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //            {
        //                e.Handled = true;
        //            }
        //        }
        //        if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
        //        {
        //            e.Handled = true;
        //        }
        //        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
        //        {
        //            e.Handled = true;
        //        } 
                    
        //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //{
        //    e.Handled = true;
        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

        private void CmbIssueMode_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbIssueMode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbIssueMode_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbIssueMode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbIssueMode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtissuemodevalue.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbIssueMode_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbIssueMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) != -1)
                {
                    txtDmode.Text = cmbIssueMode.Text;
                    txtissuemodevalue.Text = "";
                }
                else
                {
                    txtDmode.Text = "";
                }
                string selectedValue = cmbIssueMode.SelectedItem.ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        private void TxtIssuedBy_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIssuedBy.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Grdsupplieradd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdsupplieradd.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":

                            if ((Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value) == "" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value) == "0" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value) == "-")
                                && (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value) == "" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value) == "0" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value) == "-")
                                && (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value) == "" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value) == "0" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value) == "-"))
                            {
                                DataGridViewRow row = grdsupplieradd.Rows[e.RowIndex];
                                grdsupplieradd.Rows.Remove(row);
                                grdsupplieradd.SuspendLayout();

                            }
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    DataGridViewRow row = grdsupplieradd.Rows[e.RowIndex];
                                    grdsupplieradd.Rows.Remove(row);
                                }
                            }
                            for (int i = 0; i < grdsupplieradd.RowCount; i++)
                            {
                                grdsupplieradd.Rows[i].Cells["clmsno"].Value = i + 1;
                            }
                            varModifiedFlag = 1;
                            break;
                        case "clmproductname":
                            varprodFlag = 1;
                            productcode = Convert.ToInt32((grdsupplieradd.Rows[e.RowIndex].Cells["ID"].Value));
                            udfnPossibleSupplierLoad();
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
                lblPC.Text = grdsupplieradd.Rows.Count.ToString(); udfnTotalKG();
            }
        }

        private void Grdsupplieradd_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmMXSQ"].Value) != "" && Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmMXSQ"].Value) != "0" && Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmMXSQ"].Value) != "-")
                    {
                        if (VarStatusId != 14 || VarStatusId != 33 || Currentsts != 38 || Currentsts != 51)
                        {
                            switch (grdsupplieradd.Columns[e.ColumnIndex].Name)
                            {
                                case "clmunitorderqty":
                                    //if (VarStatusId == 12 || VarStatusId == 0)
                                    //{
                                    if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value) == "")
                                    {
                                        DataGridView dataGridView = (DataGridView)sender;
                                        DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells["clmunitorderqty"];
                                        cell.Style.BackColor = Color.LightPink;
                                        cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                    }
                                    else
                                    {
                                        int stockval = 0;
                                        if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmstock"].Value) == "-" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmstock"].Value) == "")
                                        {
                                            stockval = 0;
                                        }
                                        else
                                        {
                                            stockval = Convert.ToInt32(grdsupplieradd.Rows[e.RowIndex].Cells["clmstock"].Value);
                                        }
                                        if (stockval < Convert.ToInt32(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value))
                                        {
                                            DataGridView dataGridView = (DataGridView)sender;
                                            DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells["clmordertotalqty"];
                                            cell.Style.BackColor = Color.LightPink;
                                            cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                        }
                                        else
                                        {
                                            DataGridView dataGridView = (DataGridView)sender;
                                            DataGridViewCell cell1 = dataGridView.Rows[e.RowIndex].Cells["clmunitorderqty"];
                                            DataGridViewCell cell3 = dataGridView.Rows[e.RowIndex].Cells["clmordertotalqty"];
                                            cell1.Style.BackColor = Color.PaleGreen;
                                            cell1.Style.ForeColor = Color.Black;// Set the background color to the default background color} 
                                            if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["BulkUTID"].Value) != "0")
                                            {
                                                DataGridViewCell cell2 = dataGridView.Rows[e.RowIndex].Cells["clmOrderqty"];
                                                cell2.Style.BackColor = Color.PaleGreen;
                                                cell2.Style.ForeColor = Color.Black;// Set the background color to the default background color}
                                            }
                                            cell3.Style.BackColor = Color.PaleGreen;
                                            cell3.Style.ForeColor = Color.Black;// Set the background color to the default background color}
                                        }


                                    }
                                    // }
                                    break;
                                case "clmOrderqty":
                                    //if (VarStatusId == 12 || VarStatusId == 0)
                                    //{
                                    if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["BulkUTID"].Value) != "0")
                                    {
                                        if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value) == "")
                                        {
                                            DataGridView dataGridView = (DataGridView)sender;
                                            DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells["clmOrderqty"];
                                            cell.Style.BackColor = Color.LightPink;
                                            cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                        }
                                        else
                                        { 
                                            int stockval = 0;
                                            if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmstock"].Value) == "-" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmstock"].Value) == "")
                                            {
                                                stockval = 0;
                                            }
                                            else
                                            {
                                                stockval = Convert.ToInt32(grdsupplieradd.Rows[e.RowIndex].Cells["clmstock"].Value);
                                            }
                                            if (stockval < Convert.ToInt32(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value))
                                            {
                                                DataGridView dataGridView = (DataGridView)sender;
                                                DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells["clmordertotalqty"];
                                                cell.Style.BackColor = Color.LightPink;
                                                cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                            }
                                            else
                                            {
                                                DataGridView dataGridView = (DataGridView)sender;
                                                DataGridViewCell cell1 = dataGridView.Rows[e.RowIndex].Cells["clmunitorderqty"];
                                                DataGridViewCell cell3 = dataGridView.Rows[e.RowIndex].Cells["clmordertotalqty"];
                                                cell1.Style.BackColor = Color.PaleGreen;
                                                cell1.Style.ForeColor = Color.Black;// Set the background color to the default background color}
                                                if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["BulkUTID"].Value) != "0")
                                                {
                                                    DataGridViewCell cell2 = dataGridView.Rows[e.RowIndex].Cells["clmOrderqty"];
                                                    cell2.Style.BackColor = Color.PaleGreen;
                                                    cell2.Style.ForeColor = Color.Black;// Set the background color to the default background color}
                                                }
                                                cell3.Style.BackColor = Color.PaleGreen;
                                                cell3.Style.ForeColor = Color.Black;// Set the background color to the default background color}
                                            }

                                        }
                                    }
                                    //}
                                    break;
                                case "clmordertotalqty":
                                    //if (VarStatusId == 12 || VarStatusId == 0)
                                    //{
                                    if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value) == "")
                                    {
                                        DataGridView dataGridView = (DataGridView)sender;
                                        DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells["clmordertotalqty"];
                                        cell.Style.BackColor = Color.LightPink;
                                        cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                    }
                                    else
                                    {
                                        int stockval = 0;
                                        if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmstock"].Value) == "-" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmstock"].Value) == "")
                                        {
                                            stockval = 0;
                                        }
                                        else { stockval = Convert.ToInt32(grdsupplieradd.Rows[e.RowIndex].Cells["clmstock"].Value); }
                                        if (stockval < Convert.ToInt32(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value))
                                        {
                                            DataGridView dataGridView = (DataGridView)sender;
                                            DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells["clmordertotalqty"];
                                            cell.Style.BackColor = Color.LightPink;
                                            cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                        }
                                        else
                                        {
                                            DataGridView dataGridView = (DataGridView)sender;
                                            DataGridViewCell cell1 = dataGridView.Rows[e.RowIndex].Cells["clmunitorderqty"];
                                            DataGridViewCell cell3 = dataGridView.Rows[e.RowIndex].Cells["clmordertotalqty"];
                                            cell1.Style.BackColor = Color.PaleGreen;
                                            cell1.Style.ForeColor = Color.Black;// Set the background color to the default background color}
                                            if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["BulkUTID"].Value) != "0")
                                            {
                                                DataGridViewCell cell2 = dataGridView.Rows[e.RowIndex].Cells["clmOrderqty"];
                                                cell2.Style.BackColor = Color.PaleGreen;
                                                cell2.Style.ForeColor = Color.Black;// Set the background color to the default background color}
                                            }
                                            cell3.Style.BackColor = Color.PaleGreen;
                                            cell3.Style.ForeColor = Color.Black;// Set the background color to the default background color}
                                        }

                                    }
                                    // }
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
        }

        private void DpPlanDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                udfnVocherno();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPendingorder_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdsupplieradd.Rows.Count > 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(76);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        for (int i = grdsupplieradd.Rows.Count - 1; i >= 0; i--)
                        {
                            if ((Convert.ToString(grdsupplieradd.Rows[i].Cells["clmflag"].Value) == "3" || Convert.ToString(grdsupplieradd.Rows[i].Cells["clmflag"].Value) == "4"))
                            {
                                grdsupplieradd.Rows.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < grdsupplieradd.RowCount; i++)
                        {
                            grdsupplieradd.Rows[i].Cells["clmsno"].Value = i + 1;
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

            finally
            {
                lblPC.Text = grdsupplieradd.Rows.Count.ToString();
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

        private void BtnIssued_Enter(object sender, EventArgs e)
        {
            try
            {
                btnIssued.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnIssued_Leave(object sender, EventArgs e)
        {
            try
            {
                btnIssued.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnIssued_Click(object sender, EventArgs e)
        {
            try
            {
                issuedon();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void issuedon()
        {
            try
            {
                bool varErrorFlag = true;
                if (btnSave.Text == "Update")
                {
                    if (Convert.ToInt32(cmbIssueMode.SelectedValue) == 139 || Convert.ToInt32(cmbIssueMode.SelectedValue) == 140)
                    {
                        if (txtissuemodevalue.Text == "")
                        {
                            errPO.SetError(txtissuemodevalue, "Please enter number");
                            txtissuemodevalue.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpIssuemodeValues.ShowAlways = true;
                            tpIssuemodeValues.Show("Please enter number.", txtissuemodevalue, 5000);
                            varErrorFlag = false;
                        }
                        else
                        {
                            if (txtissuemodevalue.Text.Length != 10)
                            {
                                errPO.SetError(txtissuemodevalue, "Please enter valid number");
                                txtissuemodevalue.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpIssuemodeValues.ShowAlways = true;
                                tpIssuemodeValues.Show("Please enter valid number.", txtissuemodevalue, 5000);
                                varErrorFlag = false;
                            }
                        }
                    }
                    if (Convert.ToInt32(cmbIssueMode.SelectedValue) == -1)
                    {
                        errPO.SetError(cmbIssueMode, "Please select mode of issue");
                        cmbIssueMode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIssuemode.ShowAlways = true;
                        tpIssuemode.Show("Please select mode of issue.", cmbIssueMode, 5000);
                        varErrorFlag = false;
                    }
                    if (txtIssuedBy.Text == "")
                    {
                        errPO.SetError(txtIssuedBy, "Please enter issuedby");
                        txtIssuedBy.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIssueby.ShowAlways = true;
                        tpIssueby.Show("Please enter issuedby.", txtIssuedBy, 5000);
                        varErrorFlag = false;
                    }
                    if (txtTurnAroundTime.Text == "0")
                    {
                        errPO.SetError(txtTurnAroundTime, "Invalid turn around time");
                        txtTurnAroundTime.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIssueby.ShowAlways = true;
                        tpIssueby.Show("Invalid turn around time.", txtTurnAroundTime, 5000);
                        varErrorFlag = false;
                    }
                }
                if (varErrorFlag == true)
                {
                    if (varPOID != 0)
                    {
                        udfntooltiphide();
                        string result = "", varorginator = "Issue Create";
                        int varviewtype = 3, POUpdate = varPOID;
                        SPDataService objspdservice = new SPDataService();
                        DataTable objPurchaseOrder = new DataTable();
                        objPurchaseOrder.TableName = "TRN_PO_Product";
                        objPurchaseOrder.Columns.Add("POPR_PRID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_MSQ", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_ReorderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_OrderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_Flag", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_SPSCID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_UTID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_EditFlag", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_UTOrderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_TOTOrderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_KGORDERQTY", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_BulkUTID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_QUTID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_UPP", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_NetWeight", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_Remarks", typeof(string));
                        result = objspdservice.udfnPurchaseEntry(varviewtype, POUpdate, 0, "", 0, 0
                        , "", varorginator, "", txtTurnAroundTime.Text, objPurchaseOrder, dpissuedateandtime.Text, txtIssuedBy.Text, Convert.ToString(cmbIssueMode.SelectedValue), txtissuemodevalue.Text, 11, "", 0, 0, 0);
                        objspdservice.CloseConnection();
                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ActiveControl = dpissuedateandtime;
                            MainForm.objPUR_PurchaseOrderList.udfnPOEntryLoad();
                            varupdate = "1";
                            udfnclose();
                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void GrdPendingorder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPendingorder.Columns[e.ColumnIndex].Name)
                    {
                        case "clmpono":
                            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                            {
                                string cellPOValue = Convert.ToString(grdPendingorder.Rows[e.RowIndex].Cells["poid"].Value);
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

        private void CmbUnit_Leave(object sender, EventArgs e)
        {
            try { cmbUnit.BackColor = Color.White; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbUnit.BackColor = Color.LemonChiffon;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Grdsupplieradd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int varValue = 0;
            try
            {
                //if (VarStatusId == 12 || VarStatusId == 0)
                //{
                switch (grdsupplieradd.Columns[e.ColumnIndex].Name)
                {
                    case "clmOrderqty":
                        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                        {
                            qtyFlag = 1;
                        }
                        break;
                    case "clmunitorderqty":
                        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                        {
                            qtyFlag = 2;
                        }
                        break;
                    case "clmordertotalqty":
                        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                        {
                            qtyFlag = 3;
                        }
                        break;

                }
                //}

                int varDecimal = Convert.ToInt32(grdsupplieradd.CurrentRow.Cells["clmUT_Decimal"].Value);
                //decimal varDecimalOrderqty = ;
                //decimal varDecimalUnitOrderqty = ;
                //decimal varDecimalTotalOrderqty = ; 
                //grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value = varDecimalOrderqty;
                //grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value = varDecimalUnitOrderqty;
                //grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value = varDecimalTotalOrderqty; 

                int varUPP = 0; if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmUPP"].Value) != "" && Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmUPP"].Value) != "-") { varUPP = Convert.ToInt32(grdsupplieradd.Rows[e.RowIndex].Cells["clmUPP"].Value); }
                decimal varNettWeight = 0; if (Convert.ToString(Convert.ToDouble(grdsupplieradd.Rows[e.RowIndex].Cells["clmNettWeight"].Value)) != "" && Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmNettWeight"].Value) != "-") { varNettWeight = Convert.ToDecimal(grdsupplieradd.Rows[e.RowIndex].Cells["clmNettWeight"].Value); }
                decimal varBulkUnitQty = 0; if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value) != "" && Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value) != "-") { varBulkUnitQty = Convert.ToDecimal((Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value))); }
                decimal varUnitQty = 0; if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value) != "" && Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value) != "-") { varUnitQty = Convert.ToDecimal(objValidation.udfnDecimal(Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value), varDecimal)); }
                decimal varTotalQty = 0; if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value) != "" && Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value) != "-") { varTotalQty = Convert.ToDecimal(objValidation.udfnDecimal(Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value), varDecimal)); }
                int varBulkUTID = 0; if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["BulkUTID"].Value) != "" && Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["BulkUTID"].Value) != "-") { varBulkUTID = Convert.ToInt32(grdsupplieradd.Rows[e.RowIndex].Cells["BulkUTID"].Value); }

                if (grdsupplieradd.CurrentCell.OwningColumn.Name == "clmOrderqty")
                {
                    if (varBulkUnitQty == 0)
                    {
                        varValue = 1;
                    }
                }
                else if (grdsupplieradd.CurrentCell.OwningColumn.Name == "clmunitorderqty")
                {
                    if (varUnitQty == 0)
                    {
                        varValue = 1;
                    }
                }
                else if (grdsupplieradd.CurrentCell.OwningColumn.Name == "clmordertotalqty")
                {
                    if (varTotalQty == 0)
                    {
                        varValue = 1;
                    }
                }
                if (varValue == 0)
                {
                    udfnweightcalc(varUPP, varNettWeight, varBulkUnitQty, varUnitQty, varTotalQty, varBulkUTID);
                }
                varModifiedFlag = 1;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //if (VarStatusId == 12 || VarStatusId == 0)
                //{
                if (varValue == 0)
                {
                    if (grdsupplieradd.Columns[e.ColumnIndex].Name != "clmremarks")
                    {
                        if (varFinalBulkUnit == 0)
                        {
                            grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value = "-";
                        }
                        else
                        {
                            grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value = varFinalBulkUnit;
                        }
                        if (varFinalUnit == 0)
                        {
                            grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value = "-";
                        }
                        else
                        {
                            grdsupplieradd.Rows[e.RowIndex].Cells["clmunitorderqty"].Value = varFinalUnit;
                        }
                        grdsupplieradd.Rows[e.RowIndex].Cells["clmordertotalqty"].Value = varFinalTotalQty;
                        grdsupplieradd.Rows[e.RowIndex].Cells["clmtotalkg"].Value = varFinalTotalKg;
                        varFinalBulkUnit = 0; varFinalUnit = 0; varFinalTotalQty = 0; varFinalTotalKg = 0;
                        udfnTotalKG();
                    }
                }
            }
            //}
        }

        public void udfnweightcalc(int varUPP, decimal varNettWeight, decimal varBulkUnitQty, decimal varUnitQty, decimal varTotalQty, int varBulkUTID)
        {
            try
            {
                //if (VarStatusId == 12 || VarStatusId == 0)
                //{
                if (qtyFlag == 1)
                {
                    int varDecimal = Convert.ToInt32(grdsupplieradd.CurrentRow.Cells["clmUT_Decimal"].Value);
                    DataValidation objValidation = new DataValidation();
                    totalBulkqty = Convert.ToInt32(varBulkUnitQty);
                    totalOrderQty = Convert.ToDecimal(varUPP * totalBulkqty);
                    totalKgQty = varNettWeight * Convert.ToDecimal(totalOrderQty);
                    // Update the column value
                    varFinalUnit = 0;
                    varFinalBulkUnit = Convert.ToDouble(varBulkUnitQty);
                    varFinalTotalQty =  Convert.ToDecimal(objValidation.udfnDecimal(Convert.ToString(totalOrderQty), varDecimal));
                    varFinalTotalKg = Convert.ToDecimal(objValidation.udfnDecimal(Convert.ToString(totalKgQty), varDecimal));

                }
                if (qtyFlag == 2)
                {
                    if (varBulkUTID == 0 || varBulkUTID == -1)
                    {
                        totalUnitqty = Convert.ToDecimal(varUnitQty);
                        totalOrderQty = totalUnitqty;
                        totalKgQty = varNettWeight * Convert.ToDecimal(totalOrderQty);
                        // Update the column value
                        varFinalUnit = totalUnitqty;
                        varFinalBulkUnit = 0;
                        varFinalTotalQty = totalOrderQty;
                        varFinalTotalKg = totalKgQty;
                    }
                    else
                    {
                        if (varUPP > varUnitQty)
                        {
                            totalUnitqty = Convert.ToDecimal(varUnitQty);
                            totalOrderQty = totalUnitqty;
                            totalKgQty = varNettWeight * Convert.ToDecimal(totalOrderQty);
                            // Update the column value
                            varFinalUnit = totalUnitqty;
                            varFinalBulkUnit = 0;
                            varFinalTotalQty = totalOrderQty;
                            varFinalTotalKg = totalKgQty;
                        }
                        else
                        {
                            totalUnitqty = Convert.ToDecimal(varUnitQty);
                            totalBulkqty = Math.Floor(Convert.ToDouble(totalUnitqty / varUPP));
                            totalUnitqty = totalUnitqty % varUPP;
                            totalOrderQty = Convert.ToDecimal(varUnitQty);
                            totalKgQty = varNettWeight * Convert.ToDecimal(totalOrderQty);
                            // Update the column value
                            varFinalUnit = totalUnitqty;
                            varFinalBulkUnit = Math.Round(Convert.ToDouble(totalBulkqty), 2, MidpointRounding.AwayFromZero);
                            varFinalTotalQty = totalOrderQty;
                            varFinalTotalKg = totalKgQty;
                        }
                    }
                }
                if (qtyFlag == 3)
                {
                    if (varBulkUTID == 0 || varBulkUTID == -1)
                    {
                        totalUnitqty = Convert.ToDecimal(varTotalQty);
                        totalOrderQty = totalUnitqty;
                        totalKgQty = varNettWeight * Convert.ToDecimal(totalOrderQty);
                        // Update the column value
                        varFinalUnit = totalUnitqty;
                        varFinalBulkUnit = 0;
                        varFinalTotalQty = totalOrderQty;
                        varFinalTotalKg = totalKgQty;
                    }
                    else
                    {
                        if (varUPP > varTotalQty && varUPP > 0)
                        {
                            totalUnitqty = Convert.ToDecimal(varTotalQty);
                            totalOrderQty = totalUnitqty;
                            totalKgQty = varNettWeight * Convert.ToDecimal(totalOrderQty);
                            // Update the column value
                            varFinalUnit = totalUnitqty;
                            varFinalBulkUnit = 0;
                            varFinalTotalQty = totalOrderQty;
                            varFinalTotalKg = totalKgQty;
                        }
                        else if (varUPP > 0)
                        {
                            totalUnitqty = Convert.ToDecimal(varTotalQty);
                            totalOrderQty = totalUnitqty;
                            totalBulkqty = Math.Floor( Convert.ToDouble(totalUnitqty / varUPP));
                            totalUnitqty = totalUnitqty % varUPP;
                            totalKgQty = varNettWeight * Convert.ToDecimal(totalOrderQty);
                            // Update the column value
                            varFinalUnit = totalUnitqty;
                            varFinalBulkUnit = Math.Round(Convert.ToDouble(totalBulkqty), 2, MidpointRounding.AwayFromZero);
                            varFinalTotalQty = totalOrderQty;
                            varFinalTotalKg = totalKgQty;
                        }
                        else
                        {
                            totalUnitqty = Convert.ToDecimal(varTotalQty);
                            totalBulkqty = 0;
                            totalOrderQty = totalUnitqty;
                            totalKgQty = varNettWeight * Convert.ToDecimal(totalOrderQty);
                            // Update the column value
                            varFinalUnit = totalUnitqty;
                            varFinalBulkUnit = Math.Round(Convert.ToDouble(totalBulkqty), 2, MidpointRounding.AwayFromZero);
                            varFinalTotalQty = totalOrderQty;
                            varFinalTotalKg = totalKgQty;
                        }
                    }
                    // }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                udfnTotalKG();
            }
        }

        private void CmbUnit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Grdsupplieradd_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdsupplieradd.Rows.Count; i++)
                {
                    if (btnSave.Text != "Save")
                    {
                        if (Convert.ToString(grdsupplieradd.Rows[i].Cells["prstsid"].Value) == "10" || Convert.ToString(grdsupplieradd.Rows[i].Cells["prstsid"].Value) == "11")
                        {
                            //grdsupplieradd.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                            //grdsupplieradd.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                            DataGridView dataGridView = (DataGridView)sender;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmStsname"];
                            cell.Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                            cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                        }
                        else
                        {
                            DataGridView dataGridView = (DataGridView)sender;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmStsname"];
                            cell.Style.BackColor = Color.LimeGreen;
                            cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                            //grdsupplieradd.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                            //grdsupplieradd.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                    if (Convert.ToString(grdsupplieradd.Rows[i].Cells["BulkUTID"].Value) == "0" || Convert.ToString(grdsupplieradd.Rows[i].Cells["BulkUTID"].Value) == "-1")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmOrderqty"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        if (VarStatusId == 14 || VarStatusId == 33 || Currentsts == 38 || Currentsts == 51)
                        {

                            DataGridView dataGridView = (DataGridView)sender;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmOrderqty"];
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = true;
                        }
                        else
                        {
                            DataGridView dataGridView = (DataGridView)sender;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmOrderqty"];
                            cell.Style.BackColor = Color.PaleGreen;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = false;
                        }
                    }
                    if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmpreviouspend"].Value) != "0" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmpreviouspend"].Value) != "-" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmpreviouspend"].Value) != "")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmpreviouspend"];
                        cell.Style.BackColor = Color.Moccasin;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmPartialPendingQty"].Value) != "0" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmPartialPendingQty"].Value) != "-" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmPartialPendingQty"].Value) != "")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmPartialPendingQty"];
                        cell.Style.BackColor = Color.Moccasin;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmOtherSupplierprevious"].Value) != "0" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmOtherSupplierprevious"].Value) != "-" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmOtherSupplierprevious"].Value) != "")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmOtherSupplierprevious"];
                        cell.Style.BackColor = Color.Moccasin;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmothersupplierpartialpending"].Value) != "0" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmothersupplierpartialpending"].Value) != "-" && Convert.ToString(grdsupplieradd.Rows[i].Cells["clmothersupplierpartialpending"].Value) != "")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmothersupplierpartialpending"];
                        cell.Style.BackColor = Color.Moccasin;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
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
                if (VarStatusId == 14 || VarStatusId == 33 || Currentsts == 38 || Currentsts == 51)
                {
                    grdsupplieradd.Columns["clmOrderqty"].ReadOnly = true;
                    grdsupplieradd.Columns["clmunitorderqty"].ReadOnly = true;
                    grdsupplieradd.Columns["clmordertotalqty"].ReadOnly = true;
                    grdsupplieradd.Columns["clmremarks"].ReadOnly = true;
                    grdsupplieradd.Columns["clmordertotalqty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdsupplieradd.Columns["clmremarks"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdsupplieradd.Columns["clmunitorderqty"].DefaultCellStyle.BackColor = Color.LightGray;
                    grdsupplieradd.Columns["clmOrderqty"].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private void GrdPendingorder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdPendingorder.Rows.Count; i++)
            {

                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewCell cell = dataGridView.Rows[i].Cells["clmpono"];
                if (Convert.ToString(grdPendingorder.Rows[i].Cells["PLID"].Value) == "13")
                {
                    //grdPendingorder.Rows[i].DefaultCellStyle.BackColor = Color.RoyalBlue;
                    //grdPendingorder.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    cell.Style.BackColor = Color.RoyalBlue;
                    cell.Style.ForeColor = Color.White;
                }
                else
                {
                    //grdPendingorder.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                    //grdPendingorder.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    cell.Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                    cell.Style.ForeColor = Color.White;

                }
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

        private void TxtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    chkStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Grdsupplieradd_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdsupplieradd.CurrentCell.OwningColumn.Name == "clmOrderqty" || grdsupplieradd.CurrentCell.OwningColumn.Name == "clmunitorderqty" || grdsupplieradd.CurrentCell.OwningColumn.Name == "clmordertotalqty" || grdsupplieradd.CurrentCell.OwningColumn.Name == "clmremarks")
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
                TextBox textBox = (TextBox)sender;
                if (grdsupplieradd.CurrentCell.OwningColumn.Name == "clmOrderqty")
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;  // Disallow the character
                    } 
                    //if (e.KeyChar == '.' && vartb.Text.Contains('.'))
                    //{
                    //    e.Handled = true;
                    //}
                    if (textBox.Text.Length >= 8 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }

                if ( grdsupplieradd.CurrentCell.OwningColumn.Name == "clmunitorderqty" || grdsupplieradd.CurrentCell.OwningColumn.Name == "clmordertotalqty")
                { 
                    int varDecimal = Convert.ToInt32(grdsupplieradd.CurrentRow.Cells["clmUT_Decimal"].Value);
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
                    if (grdsupplieradd.CurrentCell.OwningColumn.Name == "clmremarks")
                    {
                        TextBox vartb = sender as TextBox;
                        if (vartb.Text.Length >= 6 && !char.IsControl(e.KeyChar))
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

        private void TxtSalesManMobile_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Grdsupplieradd_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdsupplieradd.IsCurrentCellDirty)
                {
                    grdsupplieradd.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManwhatsapp_KeyPress(object sender, KeyPressEventArgs e)
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

        public void udfnListViewData()
        {
            try
            {
                if (txtSupplier.Text != "")
                {
                    cmbReturnType.SelectedValue = -1;
                    if (VarStatusId == 12)
                    {
                        ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                        txtSupplier.Text = selectedItem.SubItems[0].Text;
                        lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                        lblschedule.Text = selectedItem.SubItems[2].Text;
                        varSuppliervalue = selectedItem.SubItems[3].Text;
                    }
                    udfnsupplierLoad();
                    DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                    GrdPendingorder_DataBindingComplete(grdPendingorder, args);
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    txtProductName.Focus();
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

        public void udfnsupplierLoad()
        {
            try
            {
                pbSupplierpend = 0;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text != "0")
                {
                    tbSupplierDetails.Enabled = true;
                }
                else
                {
                    tbSupplierDetails.Enabled = false;
                }
                if (lblSupplierCode.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.ParaPOID = varPOID;
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            if (btnSave.Text == "Save")
                            {
                                txtTurnAroundTime.Text = objDs.Tables[0].Rows[0]["SPSC_TAT"].ToString();
                            }
                            lblSuppliername.Text = objDs.Tables[0].Rows[0]["NAME"].ToString();
                            lblSupplierCity.Text = objDs.Tables[0].Rows[0]["CITY"].ToString();
                            lblsupplierGST.Text = objDs.Tables[0].Rows[0]["GSTIN"].ToString();
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString();
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString();
                            lblSupplierOrderpolicy.Text = "Return Policy -" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                            cmbReturnPolicy.SelectedValue = Convert.ToInt64(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                            cmbReturnType.SelectedValue = objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString(); ;
                            if ((Convert.ToString(cmbReturnType.SelectedValue) == "23"))
                            {
                                cmbPolicyContent.SelectedValue = 0;
                                cmbSecondLevel.SelectedValue = 0;
                            }
                            if ((Convert.ToString(cmbReturnType.SelectedValue) == "25"))
                            {
                                cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["DAYID"].ToString();
                            }
                            if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                            {
                                cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["WEEKID"].ToString();
                                cmbSecondLevel.SelectedValue = objDs.Tables[0].Rows[0]["DAYID"].ToString();
                            }
                            if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                            {
                                cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["MONTHID"].ToString();
                                cmbSecondLevel.SelectedValue = objDs.Tables[0].Rows[0]["DAYOFMONTHID"].ToString();
                            }
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            txtSalesManMobile.Text = objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString();
                            txtSalesManName.Text = objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString();
                            txtSalesManwhatsapp.Text = objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString();
                        }
                        if (objDs.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                            {
                                grdRepDetails.DataSource = objDs.Tables[2];
                                grdRepDetails.Columns["S.No."].Width = 40;
                                grdRepDetails.Columns["Rep Name"].Width = 150;
                                grdRepDetails.Columns["Brand"].Width = 150;
                                grdRepDetails.Columns["Phone No."].Width = 90;
                                grdRepDetails.Columns["WhatsApp No."].Width = 90;
                                grdRepDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }

                        if (btnSave.Text == "Save")
                        {
                            if (objDs.Tables[3].Rows.Count > 0)
                            {
                                grdsupplieradd.Rows.Clear();
                                for (int i = 0; i < objDs.Tables[3].Rows.Count; i++)
                                {
                                    lblNoRecordsFound.Visible = false;
                                    string MXSQ = "0", MXSTK = "0";
                                    if (Convert.ToString(objDs.Tables[3].Rows[i]["PR_MaxStock"]) == "0")
                                    {
                                        MXSQ = "-";
                                    }
                                    else
                                    {
                                        MXSQ = Convert.ToString(objDs.Tables[3].Rows[i]["PR_MaxStock"]);
                                    }
                                    if (Convert.ToString(objDs.Tables[3].Rows[i]["MXSTK"]) == "0")
                                    {
                                        MXSTK = "-";
                                    }
                                    else
                                    {
                                        MXSTK = Convert.ToString(objDs.Tables[3].Rows[i]["MXSTK"]);
                                    }
                                    grdsupplieradd.Rows.Add(grdsupplieradd.Rows.Count + 1, objDs.Tables[3].Rows[i]["PR_PICode"].ToString(),
                                    objDs.Tables[3].Rows[i]["PR_TName"].ToString(), objDs.Tables[3].Rows[i]["UT_Symbol"].ToString(),
                                    Convert.ToString(objDs.Tables[3].Rows[i]["Unit Wt"]), Convert.ToString(objDs.Tables[3].Rows[i]["Unit Per box"]),
                                    Convert.ToString(objDs.Tables[3].Rows[i]["B.Unit Weight"]),
                                    objDs.Tables[3].Rows[i]["GST_Text"].ToString(), objDs.Tables[3].Rows[i]["PR_MinStock"].ToString(), MXSQ,
                                    MXSTK, objDs.Tables[3].Rows[i]["PRE.PEND"].ToString(), objDs.Tables[3].Rows[i]["Other Supplier PRE.PEND"].ToString()
                                    , objDs.Tables[3].Rows[i]["PARITAL"].ToString(), objDs.Tables[3].Rows[i]["Other Supplier PARITAL"].ToString()
                                    , objDs.Tables[3].Rows[i]["PR_ReOrderQty"].ToString(),
                                    objDs.Tables[3].Rows[i]["ORDERBQTY"].ToString().Trim(), objDs.Tables[3].Rows[i]["bunit"].ToString().Trim()
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["unitqty"]), Convert.ToString(objDs.Tables[3].Rows[i]["qtyunit"])
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["totalqty"]), Convert.ToString(objDs.Tables[3].Rows[i]["totunit"]),
                                    Convert.ToString(objDs.Tables[3].Rows[i]["Finaltot"]), Convert.ToString(objDs.Tables[3].Rows[i]["finalunit"]),
                                    objDs.Tables[3].Rows[i]["PRID"].ToString(), objDs.Tables[3].Rows[i]["FLAG"].ToString(), 1, "", "",
                                     objDs.Tables[3].Rows[i]["UTID"].ToString(), Convert.ToString(objDs.Tables[3].Rows[i]["PR_NettWeight"]),
                                     Convert.ToString(objDs.Tables[3].Rows[i]["PR_UPP"]), Convert.ToString(objDs.Tables[3].Rows[i]["bulkwtval"]),
                                     Convert.ToString(objDs.Tables[3].Rows[i]["B.UTID"]), Convert.ToString(objDs.Tables[3].Rows[i]["T.UTID"]),"", 
                                     Convert.ToString(objDs.Tables[3].Rows[i]["UT_Decimal"])
                                     );
                                    grdsupplieradd.Columns[10].ReadOnly = true;
                                    DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                    Grdsupplieradd_DataBindingComplete(grdsupplieradd, args2);
                                }
                            }
                            else
                            {
                                lblNoRecordsFound.Visible = true;
                                grdsupplieradd.Rows.Clear();
                            }
                        }
                        if (objDs.Tables[5].Rows.Count > 0)
                        {
                            varpendingPOID = "0";
                            grdPendingorder.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[5].Rows.Count; i++)
                            {
                                lblFinishedNoRecord.Visible = false;
                                grdPendingorder.Rows.Add(objDs.Tables[5].Rows[i]["SINO"].ToString(), objDs.Tables[5].Rows[i]["PO_No"].ToString(),
                                objDs.Tables[5].Rows[i]["PO_Date"].ToString(), objDs.Tables[5].Rows[i]["QTY"].ToString(), objDs.Tables[5].Rows[i]["PO_Final_STSID"].ToString(), objDs.Tables[5].Rows[i]["POID"].ToString()
                                );
                                pbSupplierpend = 1;
                            }
                        }
                        else
                        {
                            lblFinishedNoRecord.Visible = true;
                            grdPendingorder.Rows.Clear();
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
                lblPC.Text = Convert.ToString(grdsupplieradd.Rows.Count);
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

        public void udfnsalesman()
        {
            try
            {
                if (lblSupplierCode.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 17;
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            txtSalesManMobile.Text = objDs.Tables[0].Rows[0]["SPSC_SMMobileNo"].ToString();
                            txtSalesManName.Text = objDs.Tables[0].Rows[0]["SPSC_SMName"].ToString();
                            txtSalesManwhatsapp.Text = objDs.Tables[0].Rows[0]["SPSC_SMWhatsAppNo"].ToString();
                        }
                        else
                        {
                            txtSalesManMobile.Text = "";
                            txtSalesManName.Text = "";
                            txtSalesManwhatsapp.Text = "";
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
        public void udfnReturnCycle()
        {
            try
            {
                if (lblSupplierCode.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 18;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        cmbReturnPolicy.SelectedValue = Convert.ToInt64(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                        cmbReturnType.SelectedValue = objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString(); ;

                        if ((Convert.ToString(cmbReturnType.SelectedValue) == "23"))
                        {
                            cmbPolicyContent.SelectedValue = 0;
                            cmbSecondLevel.SelectedValue = 0;
                        }
                        if ((Convert.ToString(cmbReturnType.SelectedValue) == "25"))
                        {
                            cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["DAYID"].ToString();
                        }
                        if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                        {
                            cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["WEEKID"].ToString();
                            cmbSecondLevel.SelectedValue = objDs.Tables[0].Rows[0]["DAYID"].ToString();
                        }
                        if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                        {
                            cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["MONTHID"].ToString();
                            cmbSecondLevel.SelectedValue = objDs.Tables[0].Rows[0]["DAYOFMONTHID"].ToString();
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
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[1].Text;
                    lblProductcode.Text = selectedItem.SubItems[3].Text;
                    lblUnitDecimal.Text = selectedItem.SubItems[6].Text;
                    udfnProductAdd();
                }
                txtProductQty.Focus();
                txtProductQty.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvproduct.Visible = false;
                udfnPossibleSupplierLoad();
            }
        }
        public void udfnPossibleSupplierLoad()
        {
            try
            {
                DataSet objDs = new DataSet();
                if (varprodFlag == 0)
                {
                    productcode = Convert.ToInt32(lblProductcode.Text);
                }
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 44;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.ParaScheduleid = Convert.ToString(lblschedule.Text);
                objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                objMR_Product.paraProductName = txtProductName.Text;
                objMR_Product.ParaProductCode = Convert.ToInt32(productcode);
                SPDataService objspdservice = new SPDataService();
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdpossiblesupplier.Rows.Clear();
                            lblPossibleSupplierRecords.Visible = false;
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdpossiblesupplier.Rows.Add(grdpossiblesupplier.Rows.Count + 1, objDs.Tables[0].Rows[i]["SUPPLIER"].ToString(),
                                objDs.Tables[0].Rows[i]["INVOICEDATE"].ToString(), objDs.Tables[0].Rows[i]["INVOICENO"].ToString(),
                                objDs.Tables[0].Rows[i]["INVOICERATE"].ToString(), objDs.Tables[0].Rows[i]["Status"].ToString(),
                                objDs.Tables[0].Rows[i]["sts"].ToString());
                            }
                        }
                        else
                        {
                            grdpossiblesupplier.Rows.Clear();
                            lblPossibleSupplierRecords.Visible = true;
                        }
                    }
                    else
                    {
                        grdpossiblesupplier.Rows.Clear();
                        lblPossibleSupplierRecords.Visible = true;
                    }
                }
                else
                {
                    grdpossiblesupplier.Rows.Clear();
                    lblPossibleSupplierRecords.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { varprodFlag = 0; }
        }

        public void udfnProductAdd()
        {
            try
            {
                if (Convert.ToInt32(lblProductcode.Text) != 0)
                {
                    varPICode = ""; varEName = ""; var_Symbol = ""; var_Text = ""; var_RMinSaleQty = ""; varSTOCK = ""; varPrevious = "";
                    varPARITAL = ""; varReOrderQty = ""; varorderSaleQty = ""; addproductid = ""; varunitid = ""; var_MXSQ = ""; flag = "0";
                    varUPP = 0; varNetweight = 0; varBulkunitvalue = 0; varUnitvalue = 0; varTotalunitvalue = 0; var_BulkSymbol = ""; var_TotSymbol = "";
                    varBulkunitqty = 0; varUnitqty = 0; varTotalunitqty = 0; unitweight = ""; unitperbox = ""; bulkunitweight = "";
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 34;
                    objMR_Product.ParaProductCode = Convert.ToInt32(lblProductcode.Text);
                    objMR_Product.ParaScheduleid = Convert.ToString(lblschedule.Text);
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
                            varEName = objDs.Tables[0].Rows[0]["PR_TName"].ToString();
                            var_Text = objDs.Tables[0].Rows[0]["GST_Text"].ToString();
                            var_RMinSaleQty = objDs.Tables[0].Rows[0]["PR_MinStock"].ToString();
                            varSTOCK = objDs.Tables[0].Rows[0]["MXSTK"].ToString();
                            varPrevious = objDs.Tables[0].Rows[0]["PRE.PEND"].ToString();
                            varPARITAL = objDs.Tables[0].Rows[0]["PARITAL"].ToString();
                            varReOrderQty = objDs.Tables[0].Rows[0]["PR_ReOrderQty"].ToString();
                            varorderSaleQty = "0";
                            addproductid = objDs.Tables[0].Rows[0]["PRID"].ToString();
                            varunitid = objDs.Tables[0].Rows[0]["UT_Symbol"].ToString();
                            var_Symbol = objDs.Tables[0].Rows[0]["UT_Symbol"].ToString();
                            var_MXSQ = objDs.Tables[0].Rows[0]["PR_MaxStock"].ToString();
                            //for orderqty weight calculations columns
                            unitweight = objDs.Tables[0].Rows[0]["Unit Wt"].ToString();
                            unitperbox = objDs.Tables[0].Rows[0]["Unit Per box"].ToString();
                            bulkunitweight = objDs.Tables[0].Rows[0]["B.Unit Weight"].ToString();
                            var_BulkSymbol = objDs.Tables[0].Rows[0]["bt_symbol"].ToString();
                            var_TotSymbol = objDs.Tables[0].Rows[0]["tot_symbol"].ToString();
                            varUPP = Convert.ToInt32(objDs.Tables[0].Rows[0]["PR_UPP"]);
                            varNetweight = Convert.ToDecimal(objDs.Tables[0].Rows[0]["PR_NettWeight"]);
                            varBulkunitvalue = Convert.ToInt32(objDs.Tables[0].Rows[0]["B.UTID"]);
                            varUnitvalue = Convert.ToInt32(objDs.Tables[0].Rows[0]["UTID"]);
                            varTotalunitvalue = Convert.ToInt32(objDs.Tables[0].Rows[0]["T.UTID"]);
                            varOtherSupPrevious = Convert.ToString(objDs.Tables[0].Rows[0]["Other Supplier PRE.PEND"]);
                            varOtherSupPartial = Convert.ToString(objDs.Tables[0].Rows[0]["Other Supplier PARITAL"]);
                            lblWeightvalue.Text = unitperbox;
                            lblMxsq.Text = Convert.ToString(var_MXSQ);
                            flag = "3";
                            udfnUnitDropdownload();
                            if (Convert.ToString(varBulkunitvalue) != "-1")
                            {
                                cmbUnit.SelectedValue = varBulkunitvalue;
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
                lvproduct.Visible = false;
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

        private void BtnSalesmanUndo_Click(object sender, EventArgs e)
        {
            try
            {
                udfnsalesman();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnReturnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                udfnReturnCycle();
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
                    btnReturnSave.Focus();
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
                    cmbReturnType.SelectedIndex = 0;
                    //cmbPolicyContent.Visible = true;
                    //cmbSecondLevel.Visible = true;
                    //txtReturnText.Visible = true;
                    //txtNextLevel.Visible = true;
                }
                else
                {
                    cmbReturnType.Visible = false;
                    txtDReturnCycle.Visible = false;
                    cmbPolicyContent.Visible = false;
                    cmbSecondLevel.Visible = false;
                    txtReturnText.Visible = false;
                    txtNextLevel.Visible = false;
                    txtReturnText.Visible = false;
                    cmbPolicyContent.Visible = false;

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

        private void CmbPolicyContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPolicyContent.Select(int.MaxValue, 0)));
                if (cmbReturnPolicy.Text == "Yes")
                {
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
                if (cmbReturnPolicy.Text == "Yes")
                {
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

            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtissuemodevalue_Enter(object sender, EventArgs e)
        {
            try
            {
                txtissuemodevalue.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtissuemodevalue_Leave(object sender, EventArgs e)
        {
            try
            {
                txtissuemodevalue.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtissuemodevalue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtTurnAroundTime.Enabled == true)
                    {
                        txtTurnAroundTime.Focus();
                    }
                    else
                    {
                        btnIssued.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTAT_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTurnAroundTime.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTAT_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnIssued.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTAT_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTurnAroundTime.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

    }
}
