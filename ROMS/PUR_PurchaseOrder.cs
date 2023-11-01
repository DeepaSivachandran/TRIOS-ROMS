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
    public partial class PUR_PurchaseOrder : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varcount=0,SupplierUpdate = 0, vardayMonthID = 0, varWeekID = 0, vardayID = 0, varrecyclecode = 0, varMonthID = 0, varMasterid = 0, varUnitid = 0, varPOID = 0, VarStatusId = 10, pbSupplierpend = 0, pbSupplierId = 0, pbScheduleid = 0;

        public string vardays = "";
        private ToolTip tpsalesman = new ToolTip();
        private ToolTip tpsalemanph = new ToolTip();
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpQty = new ToolTip();
        private ToolTip tppono = new ToolTip();
        private ToolTip tpsts = new ToolTip();
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = ""
            , varorderSaleQty = "", varorderqty = "", addproductid = "", flag = "", varunitid = "0", pbProductsCode = "", pbunitname = "", varupdate = "0", varpendingPOID = "0", varReturnDC = "0", varDamage = "0", varcomid="0";
        public PUR_PurchaseOrder()
        {
            InitializeComponent();
        }

        private void PUR_PurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                tbSupplierDetails.Enabled = false;
                dpPlanDate.MinDate= DateTime.Today;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (8,0) AND MSTID NOT IN (0,-1) OR MSTID=-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnPolicy, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (9,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID=4 AND STSID in (8,9)", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                this.ActiveControl = cmbConcern;
                udfnDropdownLoad();
                udfnEditLoad();
                if (VarStatusId == 10)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    if (VarStatusId == 9)
                    {
                        btnSave.Enabled = false;
                        cmbStatus.Enabled = false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                    }
                }
                if (btnSave.Text == "Save")
                {
                    btnClear.Enabled = true;
                    cmbConcern.Enabled = true;
                }
                else
                {
                    btnClear.Enabled = false;
                    cmbConcern.Enabled = false;
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
                    cmbStatus.SelectedValue = Convert.ToInt32(MainForm.objPUR_PurchaseOrderList.grdPurchaseorderlist.SelectedRows[0].Cells["po_stsid"].Value.ToString());
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    objDs = objdserv.udfnPOEntry(3, pbSupplierId, pbScheduleid, 0, 0, 0, 0, 0, 0, "", "", varPOID, 0);
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
                                    lblNoRecordsFound.Visible = false;
                                    grdsupplieradd.Rows.Add(grdsupplieradd.Rows.Count + 1, objDs.Tables[0].Rows[i]["P.I Code"].ToString(),
                                    objDs.Tables[0].Rows[i]["Product Name"].ToString(), objDs.Tables[0].Rows[i]["Unit"].ToString(),
                                    objDs.Tables[0].Rows[i]["GST_Text"].ToString(), objDs.Tables[0].Rows[i]["MSQ"].ToString(),
                                    objDs.Tables[0].Rows[i]["STOCK"].ToString(), objDs.Tables[0].Rows[i]["PREVIOUS"].ToString(),
                                    objDs.Tables[0].Rows[i]["PARTIAL"].ToString(), objDs.Tables[0].Rows[i]["Reorder"].ToString()
                                    , objDs.Tables[0].Rows[i]["ORDERQTY"].ToString(), objDs.Tables[0].Rows[i]["Productid"].ToString(),
                                    objDs.Tables[0].Rows[i]["FLAG"].ToString(),Convert.ToString( objDs.Tables[0].Rows[i]["EDITFLAG"]));
                                    grdsupplieradd.Columns[10].ReadOnly = false;
                                }
                                cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["COMPANY"].ToString();
                                dpPlanDate.Text = objDs.Tables[0].Rows[0]["PODATE"].ToString();
                                txtpono.Text = objDs.Tables[0].Rows[0]["PONO"].ToString();
                                txtSupplier.Text = objDs.Tables[0].Rows[0]["Supplier"].ToString();
                                lblSupplierCode.Text = objDs.Tables[0].Rows[0]["SPID"].ToString();
                                lblschedule.Text = objDs.Tables[0].Rows[0]["SPSCID"].ToString();
                                btnSave.Text = "Update";
                                cmbStatus.Enabled = true;
                                udfnsupplierLoad();
                            }
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                dpissuedateandtime.Text = objDs.Tables[1].Rows[0]["PODATE"].ToString();
                                txtIssuedBy.Text = objDs.Tables[1].Rows[0]["Issuedby"].ToString();
                                txtissuemodevalue.Text = objDs.Tables[1].Rows[0]["Issueremark"].ToString();
                                txtTurnAroundTime.Text = objDs.Tables[1].Rows[0]["TAT"].ToString();
                                txtModeofissue.Text = objDs.Tables[1].Rows[0]["Issuemode"].ToString();
                                txtDmode.Text = objDs.Tables[1].Rows[0]["Issuemode"].ToString();
                            }

                            DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdPendingorder_DataBindingComplete(grdPendingorder, args);
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

            int varViewType = 2;
            if (btnSave.Text == "Save")
            {
                varViewType = 1;
            }
            //objDT = objdserv.udfnUnitList(varViewType, varUnitid, 0);
            //objdserv.CloseConnection();
            //cmbUnit.DataSource = null;
            //if (objDT != null)
            //{
            //    if (objDT.Tables.Count > 0)
            //    {
            //        if (objDT.Tables[0].Rows.Count > 0)
            //        {
            //            cmbUnit.ValueMember = "UTID";
            //            cmbUnit.DisplayMember = "UT_Symbol";
            //            cmbUnit.DataSource = objDT.Tables[0];
            //        }
            //    }
            //}
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
                cmbStatus.BackColor = Color.White;
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
                    udfnsave();
                }
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
                lblSupplierCode.Text = "0";
                txtProductQty.Text = "";
                txtUnit.Text = "";
                grdsupplieradd.Rows.Clear();
                cmbConcern.SelectedValue = "-1";
                cmbStatus.SelectedValue = "-1";
                txtRemark.Text = "";
                lblPC.Text = "0";
                txtpono.Text = "";
                this.ActiveControl = cmbConcern;
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
                    if (Convert.ToString(txtSupplier.Text) != "")
                    {
                        string varsuppliername = "0";
                        DataService objDserv = new DataService();
                        varsuppliername = objDserv.displaydata("SELECT COUNT(*) FROM MR_Supplier WHERE SP_Name='" + txtSupplier.Text + "'");
                        if (varsuppliername == "0")
                        {
                            lblSupplierCode.Text = "0";
                            lblschedule.Text = "0";
                            errPO.SetError(txtSupplier, "Invalid supplier");
                            txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpSuppliername.ShowAlways = true;
                            tpSuppliername.Show("Invalid supplier", txtSupplier, 5000);
                            varErrorFlag = false; 
                        }
                        else
                        {
                            errPO.Clear();
                            txtSupplier.BackColor = Color.White;
                        }
                    }
                    if (Convert.ToString(txtpono.Text) == "")
                    {
                        errPO.SetError(txtpono, "Invalid PO Number!");
                        txtpono.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppono.ShowAlways = true;
                        tppono.Show("Invalid PO Number.", txtpono, 5000);
                        varErrorFlag = false;
                    }
                    if (Convert.ToInt64(cmbStatus.SelectedValue) == -1)
                    {
                        errPO.SetError(cmbStatus, "Please select status");
                        cmbStatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpsts.ShowAlways = true;
                        tpsts.Show("Please select status.", cmbStatus, 5000);
                        varErrorFlag = false;
                    }
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
                        else { result1 = DialogResult.Yes; }

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
                                    SPDataService objspdservice = new SPDataService();
                                    DataTable objPurchaseOrder = new DataTable();
                                    objPurchaseOrder.TableName = "TRN_PO_Product";
                                    objPurchaseOrder.Columns.Add("POPR_PRID", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_MSQ", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_ReorderQty", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_OrderQty", typeof(float));
                                    objPurchaseOrder.Columns.Add("POPR_Flag", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_SPSCID", typeof(int));
                                    objPurchaseOrder.Columns.Add("POPR_EditFlag", typeof(int));
                                    objPurchaseOrder = udfnPurchaseProduct();
                                    if (varcount == 0)
                                    {
                                        result = objspdservice.udfnPurchaseEntry(varviewtype, POUpdate, Convert.ToInt32(cmbConcern.SelectedValue),
                                        txtpono.Text, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), "", varorginator, txtRemark.Text,
                                        txtTurnAroundTime.Text, objPurchaseOrder, "", "", "", "", Convert.ToInt32(cmbStatus.SelectedValue), dpPlanDate.Text);
                                        objspdservice.CloseConnection();
                                        string[] varvalue = result.Split('~');
                                        if (varvalue[0] == "3")
                                        {
                                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.ActiveControl = txtSupplier;
                                            MainForm.objPUR_PurchaseOrderList.udfnPOEntryLoad();
                                            udfnClear();
                                            varupdate = "1";
                                            udfnclose();
                                        }
                                        else
                                        {
                                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                                        this.ActiveControl = cmbConcern;
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
                    MessageBox.Show("No Records Found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string varproductname = "0", varproductID="0";
                    DataService objDserv = new DataService();
                    varproductname = objDserv.displaydata("SELECT COUNT(*) FROM MR_PRODUCT WHERE PR_ENAME='" + txtProductName.Text + "'");
                    if (varproductname == "0")
                    {
                        lblProductcode.Text = "0"; 
                        errPO.SetError(txtProductName, "Invalid product");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpProduct.ShowAlways = true;
                        tpProduct.Show("Invalid supplier", txtProductName, 5000);
                        varErrorFlag = false; 
                    }
                    else
                    { 
                        varproductID = objDserv.displaydata("SELECT PRID FROM MR_PRODUCT WHERE PR_ENAME='" + txtProductName.Text + "'");
                        lblProductcode.Text = varproductID;
                        errPO.Clear();
                        txtProductName.BackColor = Color.White;
                    }
                    objDserv.CloseConnection();
                }
                if (varErrorFlag == true)
                {
                    int varflag = 0;
                    lblNoRecordsFound.Visible = false;
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
                            grdsupplieradd.Rows.Add(grdsupplieradd.Rows.Count + 1, (varPICode).Trim(), (varEName).Trim(), (var_Symbol).Trim(), (var_Text).Trim(), (var_RMinSaleQty).Trim(), (varSTOCK).Trim(),
                                (varPrevious).Trim(), (varPARITAL).Trim(), (varReOrderQty).Trim(), (txtProductQty.Text).Trim(), (addproductid).Trim(), 3,1);
                            grdsupplieradd.Columns[10].ReadOnly = false;
                            udfnrowclear();
                            grdsupplieradd.Sort(grdsupplieradd.Columns[1], ListSortDirection.Ascending);
                            for (int i = 0; i < grdsupplieradd.RowCount; i++)
                            {
                                grdsupplieradd.Rows[i].Cells["clmsno"].Value = i + 1;
                            }
                            txtProductName.Focus();
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
                objPurchaseOrder.Columns.Add("POPR_EditFlag", typeof(int));
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
                        if (Convert.ToString(grdsupplieradd.Rows[i].Cells["clmOrderqty"].Value) == "" || Convert.ToString(grdsupplieradd.Rows[i].Cells["clmOrderqty"].Value) == "0")
                        {
                            orderqty = 0; 
                        } 
                        else
                        {
                            orderqty = Convert.ToDouble(grdsupplieradd.Rows[i].Cells["clmOrderqty"].Value);
                        } 
                        if (orderqty != 0)
                        {
                            DataService objDser = new DataService();
                            objPurchaseOrder.Rows.Add(Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value), Convert.ToInt64(grdsupplieradd.Rows[i].Cells["clmMSQ"].Value)
                            , Convert.ToDouble(grdsupplieradd.Rows[i].Cells["clmreorderqty"].Value), orderqty,
                            Convert.ToInt32(grdsupplieradd.Rows[i].Cells["clmflag"].Value), Convert.ToInt32(lblschedule.Text), Convert.ToInt32(grdsupplieradd.Rows[i].Cells["clmeditflag"].Value));
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
                txtUnit.Text = "";
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
                int varcmbconcernid = Convert.ToInt32(cmbConcern.SelectedValue);//,// varcmbunitid = Convert.ToInt32(cmbUnit.SelectedValue);
                if (txtUnit.Text != "")
                {
                    pbunitname = txtUnit.Text;
                }
                MainForm.objPUR_BulkUnit = new PUR_BulkUnit();
                MainForm.objPUR_BulkUnit.ShowDialog();
                udfnDropdownLoad();
                cmbConcern.SelectedValue = varcmbconcernid;
                // cmbUnit.SelectedValue = varcmbunitid;
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
                    "", txtSalesManMobile.Text, txtSalesManwhatsapp.Text, 0, "", Convert.ToInt32(lblschedule.Text), 0, "", "", "", "", "", "", "", "", "");

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
                if (btnSave.Text=="Save")
                { 
                    if (grdsupplieradd.Rows.Count > 0)
                    {
                        if (varcomid != Convert.ToString(cmbConcern.SelectedValue))
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(78);
                            objDServ.CloseConnection();

                            DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdsupplieradd.Rows.Clear();
                                txtSupplier.Text = "";
                                lblSupplierCode.Text = "0";
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

                txtSalesManMobile.Text = "";
                txtSalesManName.Text = "";
                txtSalesManwhatsapp.Text = "";
                tbSupplierDetails.Enabled = false;
                grdPendingorder.Rows.Clear();
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
                        varResult = objspdservice.udfngetPONO("38", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        if (varResult != "")
                        {
                            txtpono.Text = varResult;
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
                //if (txtSupplier.Text == "")
                //{
                //    errPO.SetError(txtSupplier, "Please enter supplier");
                //    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpSuppliername.ShowAlways = true;
                //    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                //}
                //else
                //{
                    errPO.Clear();
                    txtSupplier.BackColor = Color.White;
                    tpSuppliername.Active = false;
                //}
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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(15, 0, 0, 0, 0, txtSupplier.Text, 0, 0, 0, "", 0, 0, 0, 0, 0,varPOID);
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

        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
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
                //if (txtProductQty.Text == "")
                //{
                //    errPO.SetError(txtProductQty, "Please enter orderqty");
                //    txtProductQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpQty.ShowAlways = true;
                //    tpQty.Show("Please enter orderqty.", txtProductQty, 5000);
                //}
                //else
                //{
                    errPO.Clear();
                    txtProductQty.BackColor = Color.White;
                    tpQty.Active = false;
                //}
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
                    btnAdd.Focus();
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
                    result = objspdservice.udfnSupplierMaster(6, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, Convert.ToInt32(cmbReturnPolicy.SelectedValue), Convert.ToInt32(cmbReturnType.SelectedValue), 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Update supplier order type", 0, "", 0, vardayID, varMonthID, varWeekID, vardayMonthID, "", "", "", "", 0, "", 0, 0, "", "", "", "", "", "", "", "", "");
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm.objCP_Supplierlist.udfnList();
                        cmbReturnPolicy.Focus();
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

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
                    objDs = objspdservice.udfnproductmasterlist(29, 0, 0, 0, 0, txtProductName.Text, "", "",Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, txtProductName.Text, Convert.ToInt32(lblSupplierCode.Text), varProductsCodes);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(),  objDs.Tables[0].Rows[i]["PRID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.Columns[0].Width = 100;
                                lvproduct.Columns[1].Width = 250;
                                lvproduct.Columns[2].Width = 250; 
                                lvproduct.Columns[3].Width = 0;
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

        private void Grdsupplieradd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdsupplieradd.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DataGridViewRow row = grdsupplieradd.Rows[e.RowIndex];
                            grdsupplieradd.Rows.Remove(row);
                            for (int i = 0; i < grdsupplieradd.RowCount; i++)
                            {
                                grdsupplieradd.Rows[i].Cells["clmsno"].Value = i + 1;
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
                lblPC.Text = grdsupplieradd.Rows.Count.ToString();
            }
        }

        private void Grdsupplieradd_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value)=="" || Convert.ToString(grdsupplieradd.Rows[e.RowIndex].Cells["clmOrderqty"].Value) == "0")
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells["clmOrderqty"];
                    cell.Style.BackColor = Color.LightPink;
                    cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                }
                else
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells["clmOrderqty"];
                    cell.Style.BackColor = Color.PaleGreen;
                    cell.Style.ForeColor = Color.Black;// Set the background color to the default background color}
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
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                { 
                    string cellPOValue = Convert.ToString(grdPendingorder.Rows[e.RowIndex].Cells["poid"].Value);
                    MainForm.objPUR_POProducts = new PUR_POProducts();
                    MainForm.objPUR_POProducts.pbPoid = cellPOValue;
                    MainForm.objPUR_POProducts.pbSupplierCode = lblSupplierCode.Text;
                    MainForm.objPUR_POProducts.pbScheduleCode = lblschedule.Text;
                    MainForm.objPUR_POProducts.ShowDialog();
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

        private void GrdPendingorder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) 
        {
            for (int i = 0; i < grdPendingorder.Rows.Count; i++)
            {
                if (Convert.ToString(grdPendingorder.Rows[i].Cells["PLID"].Value) == "10" || Convert.ToString(grdPendingorder.Rows[i].Cells["PLID"].Value) == "11")
                {
                    grdPendingorder.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                    grdPendingorder.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    grdPendingorder.Rows[i].DefaultCellStyle.BackColor = Color.RoyalBlue;
                    grdPendingorder.Rows[i].DefaultCellStyle.ForeColor = Color.White;
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
                    cmbStatus.Focus();
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
                if (grdsupplieradd.CurrentCell.ColumnIndex == 10)
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
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;  // Disallow the character
                }
                TextBox vartb = sender as TextBox;
                if (e.KeyChar == '.' && vartb.Text.Contains('.'))
                {
                    e.Handled = true;
                }
                if (vartb.Text.Length >= 7 && !char.IsControl(e.KeyChar))
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
                    if (VarStatusId ==10)
                    {
                        ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                        txtSupplier.Text = selectedItem.SubItems[0].Text;
                        lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                        lblschedule.Text = selectedItem.SubItems[2].Text; 
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
                    objDs = objspdservice.udfnSupplierList(16, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, "", 0, 0, Convert.ToInt32(cmbConcern.SelectedValue),"",0,0,0,0,0,varPOID);
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
                                    grdsupplieradd.Rows.Add(grdsupplieradd.Rows.Count + 1, objDs.Tables[3].Rows[i]["PR_PICode"].ToString(),
                                    objDs.Tables[3].Rows[i]["PR_EName"].ToString(), objDs.Tables[3].Rows[i]["UT_Symbol"].ToString(),
                                    objDs.Tables[3].Rows[i]["GST_Text"].ToString(), objDs.Tables[3].Rows[i]["PR_MinStock"].ToString(),
                                    objDs.Tables[3].Rows[i]["STOCK"].ToString(), objDs.Tables[3].Rows[i]["PRE.PEND"].ToString(),
                                    objDs.Tables[3].Rows[i]["PARITAL"].ToString(), objDs.Tables[3].Rows[i]["PR_ReOrderQty"].ToString(),
                                    objDs.Tables[3].Rows[i]["ORDERQTY"].ToString().Trim(), objDs.Tables[3].Rows[i]["PRID"].ToString(), objDs.Tables[3].Rows[i]["FLAG"].ToString(),1);
                                    grdsupplieradd.Columns[10].ReadOnly = false;
                                }
                            }
                            else
                            {
                                lblNoRecordsFound.Visible = true;
                                grdsupplieradd.Rows.Clear();
                            }
                        }
                        if (objDs.Tables[4].Rows.Count > 0)
                        {
                            if (btnSave.Text == "Save")
                            {
                                txtTurnAroundTime.Text = objDs.Tables[4].Rows[0]["GSTAT_OrderDays"].ToString();
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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(17, 0, Convert.ToInt32(lblschedule.Text), 0, 0, "", 0, 0, 0, "", 0, 0, 0, 0, 0,0);
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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(18, Convert.ToInt32(lblSupplierCode.Text), 0, 0, 0, "", 0, 0, 0, "", 0, 0, 0, 0, 0,0);
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
            }
        }

        public void udfnProductAdd()
        {
            try
            {
                if (Convert.ToInt32(lblProductcode.Text) != 0)
                {
                    varPICode = ""; varEName = ""; var_Symbol = ""; var_Text = ""; var_RMinSaleQty = ""; varSTOCK = ""; varPrevious = "";
                    varPARITAL = ""; varReOrderQty = ""; varorderSaleQty = ""; addproductid = ""; varunitid = ""; flag = "0";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnproductmasterlist(34, Convert.ToInt32(lblProductcode.Text), 0, 0, 0, "", "", "", 0, 0, 0, Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, "", Convert.ToInt32(lblSupplierCode.Text), "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varPICode = objDs.Tables[0].Rows[0]["PR_PICode"].ToString();
                            varEName = objDs.Tables[0].Rows[0]["PR_EName"].ToString();
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
                            flag = "3";
                            txtUnit.Text = varunitid;
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

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbStatus.Select(int.MaxValue, 0)));
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
                }
                else
                {
                    cmbReturnType.Visible = false;
                    txtDReturnCycle.Visible = false;
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
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

    }
}
