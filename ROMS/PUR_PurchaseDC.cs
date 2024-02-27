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
using ROMS.Model;

namespace ROMS
{
    public partial class PUR_PurchaseDC : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public bool VarSearchFlag = true;
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpDCDate = new ToolTip();
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpDay = new ToolTip();
        private ToolTip tpMonth = new ToolTip();
        private ToolTip tpYear = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpQuantity = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tpDcNo = new ToolTip();

        DataTable dtPurchaseDC = new DataTable();
        public bool varDiscardFlag = true;
        public int pbScheduleid = 0, pbSupplierId = 0,pbDateflag=0, varShelflife=0,varDecimal=0;
        public string varSuppliervalue = "",  varExpiryDate = "";
        public string varPICode = "", varTName="", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = "",
        varorderSaleQty = "", varorderqty = "", addproductid = "", flag = "", varunitid = "0", pbProductsCode = "", pbunitname = "", varupdate = "0", varpendingPOID = "0", varReturnDC = "0", varDamage = "0", varcomid = "0";
        public string pbFormStatus;
        public int VarPrevSupplierid = 0,varDCID=0, varCloseFlag=0,varClose = 0, varDateChange = 0, varUpDownKey= 0;
        public string varBatchNo = "0";
        public string varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0";
        public string varErrQty = "0"; int expirydateFlag = 0;
        public int editFlag=0;
        public string varSupplierID = "";
        public string varSupplierScheduleID = "";
        public string varSupplierName = "";
        bool varVoucherSkip = false;

        public PUR_PurchaseDC()
        {
            InitializeComponent();
        }
        public void udfnTooltipHide()
        {
            try
            {
                tpcompanyname.Active = false;
                tpDCDate.Active = false;
                tpDcNo.Active = false;
                tpSuppliername.Active = false;
                tpProduct.Active = false;
                tpMRP.Active = false;
                tpDay.Active = false;
                tpMonth.Active = false;
                tpYear.Active = false;
                tpBatchNo.Active = false;
                tpQuantity.Active = false;
                tpStockLocation.Active = false;
                tpRack.Active = false;
                epPurchaseDC.Clear();
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
                if(varDCID!=0)
                {
                    int varviewtype = 1;
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_Purchase_DC objTRNG_Purchase_DC = new TRN_Purchase_DC();
                    objTRNG_Purchase_DC.ViewType = varviewtype;
                    objTRNG_Purchase_DC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRNG_Purchase_DC.paraIPAddress = MainForm.pbIpAddress;
                    objTRNG_Purchase_DC.paraDCID = varDCID;
                    objTRNG_Purchase_DC.paraSupplierID = pbSupplierId;
                    objTRNG_Purchase_DC.paraScheduleID = pbScheduleid;
                    objDs = objdserv.udfnPurchaseDCList(objTRNG_Purchase_DC);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                grdPurchaseDC.Rows.Clear();
                                cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["DC_COMID"].ToString();
                                dpDCDate.Text = objDs.Tables[0].Rows[0]["DC_Date"].ToString();
                                txtDcNo.Text = objDs.Tables[0].Rows[0]["DC_No"].ToString();
                                txtSupplier.Text = objDs.Tables[0].Rows[0]["Supplier"].ToString();
                                lblSupplierCode.Text = objDs.Tables[0].Rows[0]["SPID"].ToString();
                                lblschedule.Text = objDs.Tables[0].Rows[0]["SPSCID"].ToString();
                                txtRemark.Text = objDs.Tables[0].Rows[0]["DC_Remarks"].ToString();
                                //btnSave.Text = "Update";
                                udfnsupplierLoad();
                            }
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                                {

                                    grdPurchaseDC.Rows.Add(objDs.Tables[1].Rows[i]["S.No."], objDs.Tables[1].Rows[i]["P.I Code"].ToString(),
                                    objDs.Tables[1].Rows[i]["Product Name"].ToString(), 
                                    objDs.Tables[1].Rows[i]["MRP"].ToString(),
                                    objDs.Tables[1].Rows[i]["Expiry Date"].ToString(), objDs.Tables[1].Rows[i]["Batch No."].ToString(),
                                    objDs.Tables[1].Rows[i]["Quantity"].ToString(), objDs.Tables[1].Rows[i]["Unit"].ToString(),
                                    objDs.Tables[1].Rows[i]["Stock Location"].ToString(), objDs.Tables[1].Rows[i]["Rack"].ToString()
                                    , objDs.Tables[1].Rows[i]["PRID"].ToString(), objDs.Tables[1].Rows[i]["SLID"].ToString(),
                                    objDs.Tables[1].Rows[i]["RKID"].ToString(), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), objDs.Tables[1].Rows[i]["Stock"].ToString(),
                                    objDs.Tables[1].Rows[i]["Remove Flag"].ToString());

                                    if (objDs.Tables[1].Rows[i]["Remove Flag"].ToString() == "1")
                                    {                           
                                        ((DataGridViewImageCell)grdPurchaseDC.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1); ;
                                    }
                                    dtPurchaseDC.Rows.Add(objDs.Tables[1].Rows[i]["PRID"],
                                    string.Format("{0:G29}", decimal.Parse(Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]))), objDs.Tables[1].Rows[i]["Expiry Date"].ToString(),
                                    objDs.Tables[1].Rows[i]["Batch No."].ToString(),objDs.Tables[1].Rows[i]["Quantity"].ToString(),
                                    objDs.Tables[1].Rows[i]["UTID"].ToString(), objDs.Tables[1].Rows[i]["SLID"].ToString(),
                                    objDs.Tables[1].Rows[i]["RKID"].ToString());
                                }
                            }
                            grdPurchaseDC.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdPurchaseDC.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdPurchaseDC.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseDC.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                        }
                    }
                    udfnProductCount();
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
                grdPurchaseDC.ClearSelection();
                grdRepDetails.ClearSelection();
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
                //lblReturnType.Text = "";
                lblSalesmanName.Text = "";
                lblMobileNo.Text = "";
                lblWhatsAppNo.Text = "";
                grdRepDetails.DataSource = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAddClear()
        {
            try
            {
                lblUnit.Text = "";
                //txtProductName.Text = "";
                //lblProductcode.Text = "0";
                txtMrp.Text = "";
                txtDay.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchNo.Text = "";
                txtActualQty.Text = "";
                txtStockLocation.Text = "";
                lblStockLocationCode.Text = "0";
                txtRack.Text = "";
                lblRackCode.Text = "0";
                txtMrp.BackColor = Color.White;
                txtDay.BackColor = Color.White;
                txtMonth.BackColor = Color.White;
                txtYear.BackColor = Color.White;
                txtBatchNo.BackColor = Color.White;
                txtActualQty.BackColor = Color.White;
                txtRack.BackColor = Color.White;
                this.ActiveControl = txtProductName;
                epPurchaseDC.Clear();
                txtStockLocation.BackColor = Color.White;
                txtRack.Enabled = true;
                txtBatchNo.Enabled = true;
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
                ClearSupplier();
                udfnAddClear();
                txtProductName.BackColor = Color.White;
                txtProductName.Text = "";
                lblProductcode.Text = "0";
                grdPurchaseDC.Rows.Clear();
                dtPurchaseDC.Rows.Clear();
                dtPurchaseDC.AcceptChanges();
                txtTotalProducts.Text = "";
                txtRemark.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (varDiscardFlag == false)
            {
                udfnDiscard();
            }
            else
            {
                udfnclose();
            }
        }
        public void udfnclose()
        {
            try
            {
                if (varClose == 0)
                {
                    if (varCloseFlag == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    if (varCloseFlag == 1)
                    {
                        this.Close();
                    }
                    MainForm.objPUR_PurchaseDCList.udfnList();
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
            dtPurchaseDC.TableName = "TRN_Purchase_DC";
            //objPurchaseDC.Columns.Add("PR_PICode", typeof(string));
            // objPurchaseDC.Columns.Add("PR_EName", typeof(string));
            //objPurchaseDC.Columns.Add("DCPR_DCID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_PRID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_MRP", typeof(decimal));
            dtPurchaseDC.Columns.Add("DCPR_ExpiryDate", typeof(string));
            dtPurchaseDC.Columns.Add("DCPR_BatchNo", typeof(string));
            dtPurchaseDC.Columns.Add("DCPR_Qty", typeof(decimal));
            dtPurchaseDC.Columns.Add("DCPR_UTID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_SLID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_RKID", typeof(int));
        }

        private void PUR_PurchaseDC_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm objMainForm = new MainForm();
                objMainForm.udfnGetDefaultCompany();
                lblUnit.Text = "";
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                grdPurchaseDC.Columns["clmQuantity"].ReadOnly = false;
                ClearSupplier();
                udfnUddtTable();
                udfnCmbConcern();
                //DataService objDservice = new DataService();
                //string vardate = objDservice.displaydata("SELECT CONVERT(datetime,GETDATE(),103)");
                //objDservice.CloseConnection();
                //dpDCDate.Text = vardate;
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dpDCDate.MinDate = MainForm.pbFYStartDate;
                dpDCDate.MaxDate = MainForm.pbCurrentDate;
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    this.ActiveControl = txtSupplier;
                    txtSupplier.Focus();
                    if (editFlag == 0)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        EditLoad();
                        grpDCSupplier.Enabled = false;
                        if (editFlag == 2)
                        {
                            //grpDC.Enabled = false;
                            txtProductName.Enabled = false;
                            txtMrp.Enabled = false;
                            txtDay.Enabled = false;
                            txtMonth.Enabled = false;
                            txtYear.Enabled = false;
                            txtBatchNo.Enabled = false;
                            txtActualQty.Enabled = false;
                            txtStockLocation.Enabled = false;
                            txtRack.Enabled = false;
                            btnAdd.Enabled = false;
                            btnSave.Enabled = false;
                            txtRemark.Enabled = false;
                            chkCompleted.Enabled = false;
                            txtTotalProducts.Enabled = false;
                            grdPurchaseDC.ReadOnly = true;
                            txtProductName.BackColor = Color.White;
                            txtActualQty.BackColor = Color.White;
                            txtStockLocation.BackColor = Color.White;
                            txtRack.BackColor = Color.White;
                            tpProduct.Active = false;
                            btnClose.Enabled = true;
                            grdPurchaseDC.Columns["clmRemove"].Visible = false;
                            epPurchaseDC.Clear();
                            chkCompleted.Checked = true;
                            udfnTooltipHide();
                        }
                    }
                    ((DataGridViewTextBoxColumn)grdPurchaseDC.Columns["clmQuantity"]).MaxInputLength = 8;
                    grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.BackColor = Color.PaleGreen;
                    grdPurchaseDC.Columns["clmQuantity"].ReadOnly = false;
                    grdPurchaseDC.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdPurchaseDC.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdPurchaseDC.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdPurchaseDC.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError(); 
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbConcern()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                int varconcerntype = 4;
                //if (btnSave.Text == "Save")
                //{
                //    varconcerntype = 3;
                //}
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
                    dpDCDate.Focus();
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
                    epPurchaseDC.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    epPurchaseDC.Clear();
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
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                txtDcNo.Text = "";
                varDateChange = 0;
                udfnVocherno();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDCDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpDCDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDCDate_KeyDown(object sender, KeyEventArgs e)
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
        private void DpDCDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpDCDate.BackColor = Color.White;
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
                    epPurchaseDC.SetError(txtSupplier, "Please enter supplier");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                }
                else
                {
                    epPurchaseDC.Clear();
                    txtSupplier.BackColor = Color.White;
                    tpSuppliername.Active = false;
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
        }
        public void udfnsupplierLoad()
        {
            try
            {
                //pbSupplierpend = 0;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                grdRepDetails.DataSource = null;
                //if (lblSupplierCode.Text != "0")
                //{
                //    tbSupplierDetails.Enabled = true;
                //}
                //else
                //{
                //    tbSupplierDetails.Enabled = false;
                //}
                varSupplierID = lblSupplierCode.Text;
                varSupplierScheduleID = lblschedule.Text;
                varSupplierName = txtSupplier.Text;
                if (lblSupplierCode.Text.Length > 0)
                {
                    int varReturnApplicable = 0, varReturnType = 0;
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
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
                            lblReturn.Text= objDs.Tables[0].Rows[0]["RETURNAPPLICABLE"].ToString();
                            //if (varReturnApplicable == 22)
                            //{ lblReturn.Text = "Return Applicable - Yes"; }
                            //else if (varReturnApplicable == 23)
                            //{ lblReturn.Text = "Return Applicable - No"; }
                            //if (varReturnType == 24)
                            //{ lblReturnType.Text = "Return Cycle - Any Time"; }
                            //if (varReturnType == 25)
                            //{ lblReturnType.Text = "Return Cycle - Weekly"; }
                            //if (varReturnType == 26)
                            //{ lblReturnType.Text = "Return Cycle - Monthly"; }
                            //if (varReturnType == 27)
                            //{ lblReturnType.Text = "Return Cycle - Quarterly"; }
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            if (objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString() != "")
                            { lblSalesmanName.Text = "Salesman Name - " + objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString(); }
                            if (objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString() != "")
                            { lblMobileNo.Text = "Mobile No. - " + objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString(); }
                            if (objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString() != "")
                            { lblWhatsAppNo.Text = "WhatsApp No. - " + objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString(); }
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
                    varSuppliervalue = selectedItem.SubItems[3].Text;
                    if (Convert.ToInt32(grdPurchaseDC.Rows.Count) != 0)
                    {
                        if (Convert.ToString(lblSupplierCode.Text.Trim()) != Convert.ToString(varSupplierID))
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(78);
                            objDServ.CloseConnection();

                            DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                dtPurchaseDC.Rows.Clear();
                                grdPurchaseDC.Rows.Clear();
                                grdPurchaseDC.DataSource = null;
                                grdRepDetails.DataSource = null;
                            }
                            else
                            {
                                grdPurchaseDC.Refresh();
                                txtSupplier.Text = varSupplierName;
                                lblSupplierCode.Text = varSupplierID;
                                lblschedule.Text = varSupplierScheduleID;
                            }
                        }
                    }
                    udfnsupplierLoad();
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
                udfnDefalutLocation();
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
        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                txtProductName.Focus();
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
                LV_Supplier.Visible = false;
                if (Convert.ToString(txtSupplier.Text) != "")
                {
                    //txtSupplier.BackColor = Color.White;
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
                        epPurchaseDC.SetError(txtSupplier, "Invalid supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        ClearSupplier();
                    }
                    else
                    {
                        epPurchaseDC.Clear();
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
                else
                {
                    ClearSupplier();
                }
                txtProductName.BackColor = Color.LemonChiffon;
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
                        lblProductName.Text = "Search by P.I Code";
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductName.Text = "Search by Product Name";
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                /*
                if (e.KeyCode == Keys.Enter)
                {
                    txtMrp.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvproduct.Items.Count == 0 || txtProductName.Text == "")
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
                */

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                //if (DGV_FilterProduct.RowCount > 0)
                //{
                //    DGV_FilterProduct.Focus();
                //}
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
                                    txtMrp.Focus();
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
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtMrp.Focus();
                    }
                }
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
                        ObjsLocation = objDserv.udfnStockLocationList(25, 0, 0, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0, 0, 0,"","",0);
                        objDserv.CloseConnection();
                        if (ObjsLocation != null)
                        {
                            if (ObjsLocation.Tables.Count > 0)
                            {
                                if (ObjsLocation.Tables[0].Rows.Count > 0)
                                {
                                    lblStockLocationCode.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SLID"]);
                                    txtStockLocation.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SL_EName"]);
                                    lblRackCode.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RKID"]);
                                    //if (lblRackCode.Text == "0")
                                    //{
                                    //    txtRack.Text = "None";
                                    //    txtRack.Enabled = false;
                                    //}
                                    //else
                                    //{
                                    //    txtRack.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RK_ShortName"]);
                                    //}
                                    if(Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RK_ShortName"])!="")
                                    {
                                        txtRack.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RK_ShortName"]);
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(ObjsLocation.Tables[0].Rows[0]["RackCount"]) ==0)
                                        {
                                            txtRack.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RKNAME"]);
                                            txtRack.Enabled = false;
                                            lblRackCode.Text = "0";
                                        }
                                    }
                                    lvStockLocation.Visible = false;
                                    lvRack.Visible = false;
                                }
                            }
                            else
                            {
                                lblStockLocationCode.Text = "0";
                                txtStockLocation.Text = "";
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductName.Text.Trim() == "")
                {
                    epPurchaseDC.SetError(txtProductName, "Please enter product.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    txtStockLocation.Text = "";
                    lblStockLocationCode.Text = "0";
                }
                else
                {
                    epPurchaseDC.Clear();
                    txtProductName.BackColor = Color.White;
                    tpProduct.Active = false;
                }
                //udfnDefalutLocation();
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
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                txtMrp.BackColor = Color.LemonChiffon;
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
                    txtDay.Focus();
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
        private void TxtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.LemonChiffon;
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
        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
        private void TxtMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtMrp.Text.Trim() == "")
                //{
                //    txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    epPurchaseDC.SetError(txtMrp, "Please enter MRP");
                //    tpMRP.ShowAlways = true;
                //    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                //}
                //else
                //{
                //    txtMrp.BackColor = Color.White;
                //    epPurchaseDC.Clear();
                //}
                txtMrp.BackColor = Color.White;
                if (txtMrp.Text.Trim() != "")
                {
                    //string mrp = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                    txtMrp.Text = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero));
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
        private void TxtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
        private void TxtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epPurchaseDC.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epPurchaseDC.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if(txtMonth.Text!="" )
                {
                    if(Convert.ToInt32(txtMonth.Text.Trim())>12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epPurchaseDC.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epPurchaseDC.Clear();
                    }
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
        private void TxtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epPurchaseDC.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epPurchaseDC.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if(txtYear.Text.Trim()!="")
                {
                    if(txtYear.Text.Trim()=="00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epPurchaseDC.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epPurchaseDC.Clear();
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
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0)
                {
                    objDs = objspdservice.udfnStockLocationList(26, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0,"","",0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_TName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvStockLocation.Items.Add(objList);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                                }
                                lvStockLocation.Visible = true;
                            }
                        }
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
                txtStockLocation.Focus();
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

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
                        udfnAddClear();
                        udfnTooltipHide();
                        //txtStockLocation.Text = "";
                        //lblStockLocationCode.Text = "0";
                        //lvStockLocation.Visible = false;
                    }
                    string varProductsCodes = "0";
                    txtRack.Text = "";
                    txtRack.Enabled = true;
                    lblRackCode.Text = "0";
                    //lvproduct.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 29;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.ParaScheduleid = lblschedule.Text;
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
                                {   /*
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(),objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(),
                                        objDs.Tables[0].Rows[i]["PR_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PR_BatchNoGeneration"].ToString(),objDs.Tables[0].Rows[i]["PR_RMForProduction"].ToString(),objDs.Tables[0].Rows[i]["PR_PRCTID"].ToString(),objDs.Tables[0].Rows[i]["PR_ShelfLife"].ToString(),
                                    objDs.Tables[0].Rows[i]["UT_Decimal"].ToString()};
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvproduct.Items.Add(objList);
                                    }
                                    lvproduct.Visible = true;
                                    lvproduct.Columns[0].Width = 130;
                                    lvproduct.Columns[1].Width = 500;
                                    lvproduct.Columns[2].Width = 0;
                                    lvproduct.Columns[3].Width = 50;
                                    //lvproduct.Columns[4].Width = 0;
                                    //lvproduct.Columns[5].Width = 0;
                                    //lvproduct.Columns[6].Width = 0;
                                    //lvproduct.Columns[7].Width = 0;
                                    //lvproduct.Columns[8].Width = 0;
                                    //lvproduct.Columns[9].Width = 0;

                                    if (VarSearchFlag == false)
                                    {
                                        lvproduct.Columns[2].Width = 500;
                                        lvproduct.Columns[1].Width = 0;
                                    }
                                    else
                                    {
                                        lvproduct.Columns[2].Width = 0;
                                        lvproduct.Columns[1].Width = 500;
                                    }
                                    // lvproduct.EndUpdate();
                                    */
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
                                    //lvProduct.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                                //lvProduct.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                            //lvProduct.Visible = false;
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
            }
        }
        public void udfnPurLocationAutocomplete()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    ListViewItem selectedItem = lvStockLocation.SelectedItems[0];
                    txtStockLocation.Text = selectedItem.SubItems[0].Text;
                    lblStockLocationCode.Text = selectedItem.SubItems[2].Text;
                    lvStockLocation.Visible = false;
                    txtRack.Text = "";
                    lblRackCode.Text = "0";
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
        private void LvStockLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnPurLocationAutocomplete();
                if (txtRack.Enabled == false)
                { txtRack.Focus(); }
                else
                { btnAdd.Focus(); }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(lblStockLocationCode.Text), 0, txtRack.Text.Trim(), 0, 0);
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

        private void LvStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPurLocationAutocomplete();
                    if (txtRack.Enabled == false)
                    { btnAdd.Focus(); }
                    else
                    { txtRack.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnPurRackAutocomplete();
                btnAdd.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurRackAutocomplete()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    lblRackCode.Text = selectedItem.SubItems[2].Text;
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
        private void TxtBatchNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchNo.Text.Trim() == "")
                    {
                        txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epPurchaseDC.SetError(txtBatchNo, "Please enter BatchNo.");
                        tpBatchNo.ShowAlways = true;
                        tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                    }
                    else
                    {
                        txtBatchNo.BackColor = Color.White;
                        epPurchaseDC.Clear();
                    }
                }
                else
                {
                    txtBatchNo.BackColor = Color.White;
                }
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
                txtRemark.BackColor= Color.LemonChiffon;
            }
            catch(Exception ex)
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

        private void TxtRemark_KeyDown(object sender, KeyEventArgs e)
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

        public void udfnsave()
        {
            try
            {
                if (grdPurchaseDC.RowCount > 0)
                {
                    bool varErrorFlag = true;
                    if (txtSupplier.Text == "")
                    {
                        epPurchaseDC.SetError(txtSupplier, "Please select supplier.");
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
                        epPurchaseDC.SetError(cmbConcern, "Please select company.");
                        cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpcompanyname.ShowAlways = true;
                        tpcompanyname.Show("Please select company.", cmbConcern, 5000);
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
                            epPurchaseDC.SetError(txtSupplier, "Invalid supplier.");
                            txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpSuppliername.ShowAlways = true;
                            tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                            lblSupplierCode.Text = "0";
                            lblschedule.Text = "0";
                            varErrorFlag = false;
                        }
                        else
                        {
                            epPurchaseDC.Clear();
                            lblSupplierCode.Text = values[0];
                            lblschedule.Text = values[1];
                            txtSupplier.BackColor = Color.White;
                        }
                    }
                    if (txtDcNo.Text == "")
                    {
                        epPurchaseDC.SetError(txtDcNo, "DC No. is empty.");
                        //txtDcNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpDcNo.ShowAlways = true;
                        tpDcNo.Show("DC No. is empty.", txtDcNo, 5000);
                        varErrorFlag = false;
                    }
                    for (int i = 0; i < grdPurchaseDC.Rows.Count; i++)
                    {
                        if (Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmQuantity"].Value) == "0")
                        {
                            varErrorFlag = false;
                            grdPurchaseDC.Rows[i].Cells["clmError"].Value = 1;
                            grdPurchaseDC.Rows[i].Cells["clmQuantity"].Style.BackColor = Color.LightPink;
                        }
                        else
                        {
                            grdPurchaseDC.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                            grdPurchaseDC.Rows[i].Cells["clmQuantity"].Style.BackColor = Color.PaleGreen;
                        }
                    }
                    if (varErrorFlag == true && varErrQty == "0")
                    {
                        udfnTooltipHide(); int varDC_PURID = 0;
                        int varStatusID = 0;
                        if (grdPurchaseDC.Rows.Count > 0)
                        {
                            if (lblSupplierCode.Text != "0" && lblschedule.Text != "0")
                            {
                                string result = "", varorginator = "Purchase DC";
                                int varviewtype = 0;
                                //if (btnSave.Text == "Draft")
                                //{
                                //    varviewtype = 1;
                                //    varorginator = "Purchase DC Update";
                                //}
                                if (chkCompleted.Checked == true)
                                { varStatusID = 34; }
                                else { varStatusID = 18; }
                                //if (editFlag==0)
                                //{
                                //    varviewtype = 0;
                                //    varorginator = "Purchase DC Insert";
                                //}
                                //else
                                //{
                                //    varviewtype = 1;
                                //    varorginator = "Purchase DC Update";
                                //}
                                TRN_Purchase_DC objTRNS_Purchase_DC = new TRN_Purchase_DC();
                                objTRNS_Purchase_DC.ViewType = varviewtype;
                                objTRNS_Purchase_DC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                                objTRNS_Purchase_DC.paraIPAddress = MainForm.pbIpAddress;
                                objTRNS_Purchase_DC.paraOriginator = varorginator;
                                objTRNS_Purchase_DC.paraDCID = varDCID;
                                objTRNS_Purchase_DC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                                objTRNS_Purchase_DC.paraDC_Date = dpDCDate.Text;
                                objTRNS_Purchase_DC.paraDC_NO = txtDcNo.Text.Trim();
                                objTRNS_Purchase_DC.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text.Trim());
                                objTRNS_Purchase_DC.paraScheduleID = Convert.ToInt32(lblschedule.Text.Trim());
                                objTRNS_Purchase_DC.paraDC_Remarks = txtRemark.Text.Trim();
                                objTRNS_Purchase_DC.paraDC_PURID = varDC_PURID;
                                objTRNS_Purchase_DC.paraStatusID = varStatusID;
                                objTRNS_Purchase_DC.ParaTRN_Purchase_DC = dtPurchaseDC;
                                SPDataService objspdservice = new SPDataService();
                                result = objspdservice.udfnPurchaseDc(objTRNS_Purchase_DC);
                                objspdservice.CloseConnection();
                                string[] varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.ActiveControl = txtSupplier;
                                    //if(btnSave.Text=="Save")
                                    //{
                                    //   udfnClear();
                                    //}
                                    //else
                                    //{
                                    //    varCloseFlag = 1;
                                    //    udfnclose();
                                    //}
                                    varCloseFlag = 1;
                                    udfnclose();
                                    MainForm.objPUR_PurchaseDCList.udfnList();
                                }
                                else if (varvalue[0] == "4")
                                {
                                    MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                if (varvalue[0] == "5")
                                {
                                    MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    string varProductID = "", Expirydate = "";
                                    for (int j = 0; j < grdPurchaseDC.RowCount; j++)
                                    {
                                        grdPurchaseDC.Rows[j].DefaultCellStyle.BackColor = Color.White;

                                        string[] varFirstList = varvalue[2].Split('|');
                                        for (int i = 0; i < varFirstList.Length; i++)
                                        {
                                            string[] varSecondList = varFirstList[i].Split(',');
                                            varProductID = varSecondList[0];
                                            Expirydate = varSecondList[1];
                                            if (Convert.ToString(grdPurchaseDC.Rows[j].Cells["clmPRID"].Value) == varProductID && Convert.ToString(grdPurchaseDC.Rows[j].Cells["clmExpiryDate"].Value) == Expirydate)
                                            {
                                                  grdPurchaseDC.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                              //  grdPurchaseDC.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                                            }
                                        }
                                    }
                                }
                                if (varvalue[0] == "6")
                                {
                                    MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    string varProductID = "", varMRP = "", varSLID = "", varRKID = "", varBatchNo = "", Expirydate = "";
                                    for (int j = 0; j < grdPurchaseDC.RowCount; j++)
                                    {
                                        grdPurchaseDC.Rows[j].DefaultCellStyle.BackColor = Color.White;

                                        string[] varFirstList = varvalue[2].Split('|');
                                        for (int i = 0; i < varFirstList.Length; i++)
                                        {
                                            string[] varSecondList = varFirstList[i].Split(',');
                                            varProductID = varSecondList[0];
                                            varMRP = varSecondList[1];
                                            varSLID = varSecondList[2];
                                            varRKID = varSecondList[3];
                                           /// varBatchNo = varSecondList[4];
                                            //Expirydate = varSecondList[5];
                                            if (Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmPRID"].Value) == varProductID && Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmExpiryDate"].Value) == Expirydate && Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmSLID"].Value) == varSLID && Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmRKID"].Value) == varRKID &&
                                                Convert.ToString(grdPurchaseDC.Rows[j].Cells["clmMRP"].Value) == varMRP && Convert.ToString(grdPurchaseDC.Rows[j].Cells["clmBatchNo"].Value) == varBatchNo)
                                            {
                                               // grdPurchaseDC.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                                 grdPurchaseDC.Rows[j].Cells["clmQuantity"].Style.BackColor = Color.LightPink;
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
                    string varMessage = objDServ.udfnGetMessages(100);
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

        private void PUR_PurchaseDC_Leave(object sender, EventArgs e)
        {
            try
            {
                udfnTooltipHide();
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
                int varDecimal = Convert.ToInt32(grdPurchaseDC.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdPurchaseDC.CurrentCell.OwningColumn.Name == "clmQuantity")
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
        private void GrdPurchaseDC_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //try
            //{
            //    if (grdPurchaseDC.CurrentCell.OwningColumn.Name == "clmQuantity")
            //    {
            //        e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            try
            {
                if (grdPurchaseDC.CurrentCell.OwningColumn.Name == "clmQuantity")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdPurchaseDC.CurrentCell.OwningColumn.Name == "clmQuantity")
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
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdPurchaseDC.CurrentCell.OwningColumn.Name == "clmQuantity")
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

        private void LvRack_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListviewProduct();
                txtMrp.Focus();
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
                                    txtMrp.Focus();
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
                        txtMrp.Focus();
                    }
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
                //udfnListviewProduct();
                //txtMrp.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdPurchaseDC_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal Quantity = Convert.ToDecimal(grdPurchaseDC.CurrentRow.Cells["clmQuantity"].Value);
                decimal Stock = Convert.ToDecimal(grdPurchaseDC.CurrentRow.Cells["clmStockQuantity"].Value);
                if (Convert.ToString(Quantity) == "0" || Convert.ToString(Quantity) == "")
                {
                    varErrQty = "1";
                }
                else
                {
                    varErrQty = "0";
                }
                if(btnSave.Text=="Update")
                {
                    if (Quantity <= Stock)
                    {
                       // grdPurchaseDC.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.Red;
                        varErrQty = "1";
                       // grdPurchaseDC.Rows[e.RowIndex].Cells["clmError"].Value = varErrQty;
                    }
                    else
                    {
                        varErrQty = "0";
                    }
                }
                if(varErrQty == "1")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdPurchaseDC.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.LightPink;
                    grdPurchaseDC.Rows[e.RowIndex].Cells["clmError"].Value = varErrQty;
                }
                else
                {
                    varErrQty = "0";
                    grdPurchaseDC.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.PaleGreen;
                    grdPurchaseDC.Rows[e.RowIndex].Cells["clmError"].Value = varErrQty;
                }

                int varDecimal = Convert.ToInt32(grdPurchaseDC.CurrentRow.Cells["clmUTDecimal"].Value);

                string Qty = objValidation.udfnDecimal(Convert.ToString(grdPurchaseDC.CurrentRow.Cells["clmQuantity"].Value), varDecimal);
                grdPurchaseDC.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;
                //Update the same column value in the DataTable
                object varEditQty = grdPurchaseDC.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                dtPurchaseDC.Rows[e.RowIndex]["DCPR_Qty"] = varEditQty;
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
                if(chkCompleted.Checked==true)
                { btnSave.Text = "Save";  }
                else { btnSave.Text = "Save as draft"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdPurchaseDC_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdPurchaseDC.ClearSelection();
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
        private void GrdPurchaseDC_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex != -1)
            //    {
            //        switch (grdPurchaseDC.Columns[e.ColumnIndex].Name)
            //        {
            //            case "clmQuantity":
            //                if (Convert.ToString(grdPurchaseDC.Rows[e.RowIndex].Cells["clmQuantity"].Value) == "" || Convert.ToString(grdPurchaseDC.Rows[e.RowIndex].Cells["clmQuantity"].Value) == "0")
            //                {
            //                    grdPurchaseDC.CurrentRow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fabdbd");
            //                }
            //                else
            //                {
            //                    DataGridView dataGridView = (DataGridView)sender;
            //                    DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells["clmOrderqty"];
            //                    grdPurchaseDC.CurrentRow.DefaultCellStyle.BackColor = Color.White;
            //                    cell.Style.BackColor = Color.PaleGreen;
            //                    cell.Style.ForeColor = Color.Black;// Set the background color to the default background color}
            //                }
            //                break;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
        private void PUR_PurchaseDC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    BtnSave_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose.Focus();
                    BtnClose_Click(sender, e);
                }
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
                    udfnPurRackAutocomplete();
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (grdPurchaseDC.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdPurchaseDC.SelectedRows[0].Cells["clmPRID"].Value);
                                DataGridViewRow row = grdPurchaseDC.Rows[e.RowIndex];
                                grdPurchaseDC.Rows.Remove(row);
                                for (int i = 0; i < dtPurchaseDC.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtPurchaseDC.Rows[i]["DCPR_PRID"]) == Convert.ToInt32(varProductID) )
                                    {
                                        dtPurchaseDC.Rows[i].Delete();
                                        dtPurchaseDC.AcceptChanges();
                                    }
                                }
                                for (int i = 0; i < grdPurchaseDC.RowCount; i++)
                                {
                                    grdPurchaseDC.Rows[i].Cells["clmSno"].Value = i + 1;
                                }
                                udfnProductCount();
                            }
                            break;
                    }
                    varDiscardFlag = false;
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
                    txtStockLocation.Focus();
                }
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
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtActualQty, "Please enter quantity.");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity.", txtActualQty, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtActualQty.Text).Trim(), varDecimal);
                    txtActualQty.Text = Qty;
                    txtActualQty.BackColor = Color.White;
                    epPurchaseDC.Clear();
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
                if (e.KeyCode == Keys.Enter)
                {
                    if(txtRack.Enabled==true)
                    { txtRack.Focus(); }
                    else
                    { btnAdd.Focus(); }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvStockLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        txtStockLocation.Focus();
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
                if (txtStockLocation.Text.Trim() == "")
                {
                    txtStockLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtStockLocation, "Please enter stock location.");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location.", txtStockLocation, 5000);
                    txtRack.Enabled = true;
                }
                else
                {
                    txtStockLocation.BackColor = Color.White;
                    epPurchaseDC.Clear();
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
                if(txtRack.Text=="")
                {
                    txtRack.Enabled = true;
                }
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
                    btnAdd.Focus();
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
        private void TxtRack_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtRack.Text.Trim() == "")
                //{
                //    txtRack.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    epPurchaseDC.SetError(txtRack, "Please enter rack.");
                //    tpRack.ShowAlways = true;
                //    tpRack.Show("Please enter rack.", txtRack, 5000);
                //}
                //else
                //{
                //    txtRack.BackColor = Color.White;
                //    epPurchaseDC.Clear();
                //}
                txtRack.BackColor = Color.White;
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
        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
                lvRack.Visible = false;
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
        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAdd_Click(sender, e);
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
                bool blnErrorFlag = false; pbDateflag = 0;
                if (Convert.ToString(txtProductName.Text).Trim() == "")
                {
                    epPurchaseDC.SetError(txtProductName, "Please enter product.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    blnErrorFlag = true;
                }
                //if (txtMrp.Text.Trim() == "")
                //{
                //    txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    epPurchaseDC.SetError(txtMrp, "Please enter MRP.");
                //    tpMRP.ShowAlways = true;
                //    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                //    blnErrorFlag = true;
                //}
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epPurchaseDC.SetError(txtMonth, "Please enter month.");
                        blnErrorFlag = true;
                    }
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epPurchaseDC.SetError(txtYear, "Please enter year.");
                        blnErrorFlag = true;
                    }
                }
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchNo.Text.Trim() == "")
                    {
                        txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epPurchaseDC.SetError(txtBatchNo, "Please enter BatchNo.");
                        tpBatchNo.ShowAlways = true;
                        tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtActualQty, "Please enter quantity.");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity.", txtActualQty, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtActualQty.Text).Trim(), varDecimal);
                    txtActualQty.Text = Qty;
                }
                if (txtStockLocation.Text.Trim() == "")
                {
                    txtStockLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtStockLocation, "Please enter location.");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location.", txtStockLocation, 5000);
                    blnErrorFlag = true;
                }
                //if (txtRack.Text.Trim() == "")
                //{
                //    txtRack.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    epPurchaseDC.SetError(txtRack, "Please enter rack.");
                //    tpRack.ShowAlways = true;
                //    tpRack.Show("Please enter rack.", txtRack, 5000);
                //    blnErrorFlag = true;
                //}
                /*Checking valid product or not */
                if (Convert.ToString(txtProductName.Text) != "")
                {
                    string varproductID = "0";
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 39;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.paraProductName = txtProductName.Text;
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
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
                        //epPurchaseDC.SetError(txtProductName, "Invalid product");
                        //txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        //tpProduct.ShowAlways = true;
                        //tpProduct.Show("Invalid product", txtProductName, 5000);
                        SPDataService objDser = new SPDataService();
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDser.udfnGetMessages(91);
                        objDser.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        lblProductcode.Text = varproductID;
                        epPurchaseDC.Clear();
                        txtProductName.BackColor = Color.White;
                    }
                }
                /* Check location is valid or not*/
                if (txtStockLocation.Text != "")
                {
                    string varLocationId = "0";
                    DataSet objDsLocation = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsLocation = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0,"","",0);
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
                    lblStockLocationCode.Text = Convert.ToString(varLocationId);
                    if (varLocationId == "0" || varLocationId == "-1")
                    {
                        epPurchaseDC.SetError(txtStockLocation, "Please select valid location.");
                        txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please select location.", txtStockLocation, 5000);
                        blnErrorFlag = true;
                    }
                }
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
                string varId_PurchaseRackCount = "0";
                DataSet objDsPurchaseRack = new DataSet();
                SPDataService objDServ6 = new SPDataService();
                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(lblStockLocationCode.Text), 0, txtRack.Text.Trim(), 0, 0);
                objDServ6.CloseConnection();
                if (txtRack.Text.Trim() != "")
                {
                    if (lblStockLocationCode.Text != "0")
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
                                if(varId_PurchaseRackCount=="0")
                                 { varId_PurchaseRack = "0"; }
                            }
                        }
                        lblRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (Convert.ToInt32(varId_PurchaseRackCount) > 0)
                        {
                            if (Convert.ToInt32(varId_PurchaseRack) < 0 || varId_PurchaseRack == "-1")
                            {
                                epPurchaseDC.SetError(txtRack, "Please enter valid rack.");
                                txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                                tpRack.ShowAlways = true;
                                tpRack.Show("Please enter valid rack.", txtRack, 5000);
                                blnErrorFlag = true;
                            }
                        }
                    }
                }
                else
                {
                    if (lblStockLocationCode.Text != "0")
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
                        lblRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (Convert.ToInt32( varId_PurchaseRack )> 0)
                        {
                            epPurchaseDC.SetError(txtRack, "Please enter rack.");
                            txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpRack.ShowAlways = true;
                            tpRack.Show("Please enter rack.", txtRack, 5000);
                            blnErrorFlag = true;
                        }
                        if (varId_PurchaseRack == "0")
                        {
                            txtRack.Text = "None";
                            txtRack.Enabled = false;
                            lblRackCode.Text = "0";
                        }
                        else
                        {
                            txtRack.Enabled = true;
                        }
                    }
                }
                if (Convert.ToString(txtProductName.Text.Trim()) != "")
                {
                    if (expirydateFlag == 1|| txtDay.Text!="" || txtMonth.Text!="" || txtYear.Text!="")
                    {
                        udfnExpiryDate();
                    }
                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    DataSet objDSExpiry = new DataSet();
                    int flag = 0;
                    //if (varExpiryDate != "")
                    //{
                    //    //objDS = objDServ.udfnMaster(8, 0, 0,varExpiryDate, "", 0);
                    //    //objDServ.CloseConnection();
                    //    //if (objDS.Tables[0].Rows.Count > 0)
                    //    //{
                    //    //    if (Convert.ToString(objDS.Tables[0].Rows[0]["DATE"]) == "0")
                    //    //    {
                    //    //        epPurchaseDC.SetError(txtYear, "Invalid date.");
                    //    //        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    //        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    //        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    //        blnErrorFlag = true;
                    //    //        flag = 1;
                    //    //    }
                    //    //}
                    //    if (flag == 0)
                    //    {
                    //        objDSExpiry = objDServ.udfnMaster(7, 0, 0, dpDCDate.Text, varExpiryDate, Convert.ToInt32(lblProductcode.Text));
                    //        objDServ.CloseConnection();
                    //        if (objDSExpiry.Tables[0].Rows.Count > 0)
                    //        {
                    //            if (Convert.ToString(objDSExpiry.Tables[0].Rows[0]["DATEVALIDATE"]) == "0")
                    //            {
                    //                //epPurchaseDC.SetError(txtYear, "Invalid expiry date.");
                    //                string varMessage = objDServ.udfnGetMessages(94);
                    //                objDServ.CloseConnection();
                    //                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //                txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //                txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //                txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //                blnErrorFlag = true;
                    //            }
                    //        }
                    //    }
                    //}
                    string varMRP = "", varNewExpiryDate = "", varBatch = "", varSLID = "", varRKID = "",varmrptxt ="";
                    if (txtMrp.Text == "") { varmrptxt = "0"; }
                    else
                    { varmrptxt = txtMrp.Text.Trim(); }
                     varmrptxt = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(varmrptxt), 2, MidpointRounding.AwayFromZero));
                    for (int i = 0; i < grdPurchaseDC.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(lblProductcode.Text) == Convert.ToInt32(grdPurchaseDC.Rows[i].Cells["ClmPRID"].Value))
                        {
                             varMRP = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmMRP"].Value).Trim();
                             varNewExpiryDate = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmExpiryDate"].Value).Trim();
                             varBatch = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmBatchNo"].Value).Trim();
                             varSLID = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmSLID"].Value).Trim();
                             varRKID = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmRKID"].Value).Trim();
                            
                            if (varmrptxt == varMRP && varExpiryDate == varNewExpiryDate && txtBatchNo.Text.Trim() == varBatch ) 
                            {
                                if(lblStockLocationCode.Text.Trim() == varSLID && lblRackCode.Text.Trim() == varRKID)
                                {
                                    lblProductcode.Text = "0";
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
                if (blnErrorFlag == false && pbDateflag == 0)
                {
                    udfnAdd();
                }
                varDiscardFlag = false;
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
               txtTotalProducts.Text = Convert.ToString(grdPurchaseDC.Rows.Count);
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
                string varDay = "", varMonth = "", varYear = "", varDate = ""; string varDcDay = "", varDcMonth = "", varDcYear = "", varExpiry="";
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
                        if(txtDay.Text.Length==1)
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
                    objDS = objDServ.udfnMaster(10, 0, 0, dpDCDate.Text.Trim(), varExpiryDate, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0);
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
                    if(error==1)
                    {
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(94);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //string[] date = dpDCDate.Text.Split('/');
                    //varDay = date[0].ToString();
                    //varDcMonth = date[1].ToString();
                    //varDcYear = date[2].ToString();
                    //if(Convert.ToInt32(varYear)<Convert.ToInt32(varDcYear))
                    //{
                    //    if(Convert.ToInt32(varMonth) < Convert.ToInt32(varDcMonth) && Convert.ToInt32(varDay) < Convert.ToInt32(varDcDay))
                    //    {
                    //        pbDateflag = 1;
                    //        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //       txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //        string varMessage = objDServ.udfnGetMessages(94);
                    //        objDServ.CloseConnection();
                    //        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    }
                    //}
                    //else
                    //{
                    //    varExpiryDate = txtDay.Text.Trim() + "/" + txtMonth.Text.Trim() + "/" + txtYear.Text.Trim();
                    //}
                    //else
                    //{
                    //    string[] date = dpDCDate.Text.Split('/');
                    //    varDay = date[0].ToString();
                    //    if (Convert.ToInt32(txtDay.Text)<Convert.ToInt32(varDay))
                    //    {
                    //        pbDateflag = 1;
                    //        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //        string varMessage = objDServ.udfnGetMessages(95);
                    //        objDServ.CloseConnection();
                    //        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    }
                    //    else
                    //    {
                    //        varExpiryDate = txtDay.Text.Trim() + "/" + txtMonth.Text.Trim() + "/" + txtYear.Text.Trim();
                    //    }
                    //}
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        public void udfnAdd()
        {
            try
            {
                if(txtActualQty.Text.Trim() == "0")
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
                        if(txtMrp.Text=="")
                        { txtMrp.Text = "0"; }
                        decimal varMRP = Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()),2, MidpointRounding.AwayFromZero);
                        string mrp=string.Format("{0:0.00}",varMRP);
                        string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                        grdPurchaseDC.Rows.Add(grdPurchaseDC.Rows.Count + 1, varPICode.Trim(), varTName.Trim(),Convert.ToDecimal(mrp), varExpiryDate, txtBatchNo.Text.Trim(), txtActualQty.Text.Trim(), lblUnit.Text, txtStockLocation.Text.Trim(), txtRack.Text.Trim(), addproductid, lblStockLocationCode.Text, lblRackCode.Text, varunitid,Convert.ToString(varDecimal));
                        dtPurchaseDC.Rows.Add(Convert.ToInt32(addproductid), Convert.ToDecimal(mrp1), varExpiryDate, txtBatchNo.Text.Trim(), Convert.ToDecimal(txtActualQty.Text.Trim()), Convert.ToInt32(varunitid), Convert.ToInt32(lblStockLocationCode.Text), Convert.ToInt32(lblRackCode.Text));
                        ((DataGridViewTextBoxColumn)grdPurchaseDC.Columns["clmQuantity"]).MaxInputLength = 8;
                        grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.BackColor = Color.PaleGreen;
                        //grdPurchaseDC.Columns["clmQuantity"].ReadOnly = false;
                        grdPurchaseDC.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdPurchaseDC.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdPurchaseDC.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                        udfnAddClear();
                        txtProductName.Text = "";
                        lblProductcode.Text = "0";
                      //  txtProductName.BackColor = Color.White;
                        udfnProductCount();
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
                grdPurchaseDC.ClearSelection();
            }
        }
        public void udfnVocherno()
        {
            try
            {
                if (varDCID==0)
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpDCDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetVoucherNo("149", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string pono = parts[0];
                        if (pono != "")
                        {
                            txtDcNo.Text = pono;
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
                        txtDcNo.Text = "";
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
                txtDcNo.Text = "";
                if (varVoucherSkip == false)
                {
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
                        varCloseFlag = 1;
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
        private void DpDCDate_ValueChanged(object sender, EventArgs e)
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
        public void udfnProductAdd()
        {
            try
            {
                if (Convert.ToInt32(lblProductcode.Text) != 0)
                {
                    varPICode = ""; varTName = ""; var_Symbol = ""; var_Text = ""; var_RMinSaleQty = ""; varSTOCK = ""; varPrevious = "";
                    varPARITAL = ""; varReOrderQty = ""; varorderSaleQty = ""; addproductid = ""; varunitid = ""; flag = "0";
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
                            //varEName = objDs.Tables[0].Rows[0]["PR_EName"].ToString();
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
                            flag = "3";
                            lblUnit.Text= objDs.Tables[0].Rows[0]["UT_Symbol"].ToString();
                            
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
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    varBatchNo = "0"; varBatchNoGeneration = "0"; varShelflife = 0;expirydateFlag = 0;
                    /*
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[2].Text;
                    lblProductcode.Text = selectedItem.SubItems[4].Text;
                    varBatchNo = selectedItem.SubItems[5].Text;
                    varBatchNoGeneration = selectedItem.SubItems[6].Text;
                    varRMProduction = selectedItem.SubItems[7].Text;
                    varPrcategory = selectedItem.SubItems[8].Text;
                    varShelflife =Convert.ToInt32(selectedItem.SubItems[9].Text);
                    varDecimal =Convert.ToInt32(selectedItem.SubItems[10].Text);
                    */
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNo"].Value.ToString();
                    varBatchNoGeneration = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNoGeneration"].Value.ToString();
                    varRMProduction = DGV_FilterProduct.SelectedRows[0].Cells["PR_RMForProduction"].Value.ToString();
                    varPrcategory = DGV_FilterProduct.SelectedRows[0].Cells["PR_PRCTID"].Value.ToString();
                    varShelflife = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_ShelfLife"].Value.ToString());
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_ShelfLife"].Value.ToString());
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                    if (varShelflife==1)
                    { expirydateFlag = 1; }
                    udfnProductAdd();
                    udfnDefalutLocation();
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
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(14, 0, 0, "", "", 0, "",0);
                            objspdservice.CloseConnection();
                            if(objDs.Tables[0]!=null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtBatchNo.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                    txtBatchNo.Enabled = false;
                                }
                            }
                        }
                    }
                    if(Convert.ToInt32(varPrcategory)==16)
                    {
                        if(Convert.ToInt32(varRMProduction)==1)
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(15,0, 0,dpDCDate.Text,"", Convert.ToInt32(lblProductcode.Text), "",0);
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
            }
        }
        private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnListviewProduct();
                //    txtMrp.Focus();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
