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
        public int pbScheduleid = 0, pbSupplierId = 0,pbDateflag=0;
        public string varSuppliervalue = "",  varExpiryDate = "";
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = "",
        varorderSaleQty = "", varorderqty = "", addproductid = "", flag = "", varunitid = "0", pbProductsCode = "", pbunitname = "", varupdate = "0", varpendingPOID = "0", varReturnDC = "0", varDamage = "0", varcomid = "0";
        public string pbFormStatus;
        public int VarPrevSupplierid = 0,varDCID=0, varCloseFlag=0;
        public string varErrQty = "0";

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
                                btnSave.Text = "Update";
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
                                    objDs.Tables[1].Rows[i]["RKID"].ToString(), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]));
                                    grdPurchaseDC.Columns[14].ReadOnly = false;

                                    dtPurchaseDC.Rows.Add(objDs.Tables[1].Rows[i]["PRID"],
                                    objDs.Tables[1].Rows[i]["MRP"].ToString(), objDs.Tables[1].Rows[i]["Expiry Date"].ToString(),
                                    objDs.Tables[1].Rows[i]["Batch No."].ToString(), objDs.Tables[1].Rows[i]["Quantity"].ToString(),
                                    objDs.Tables[1].Rows[i]["UTID"].ToString(), objDs.Tables[1].Rows[i]["SLID"].ToString(),
                                    objDs.Tables[1].Rows[i]["RKID"].ToString());
                                }
                            }
                            grdPurchaseDC.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdPurchaseDC.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            }
        }
        public void udfnDiscard()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Discard Changes ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                txtProductName.Text = "";
                lblProductcode.Text = "0";
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
                txtProductName.BackColor = Color.White;
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
                if (varCloseFlag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                if (varCloseFlag == 1)
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
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                grdPurchaseDC.Columns["clmQuantity"].ReadOnly = false;
                ClearSupplier();
                udfnUddtTable();
                udfnCmbConcern();
                DataService objDservice = new DataService();
                string vardate = objDservice.displaydata("SELECT CONVERT(datetime,GETDATE(),103)");
                objDservice.CloseConnection();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dpDCDate.Text = vardate;
                dpDCDate.MaxDate = DateTime.Now;
                if(btnSave.Text=="Update")
                {
                    EditLoad();
                    grpDCSupplier.Enabled = false;
                }
                ((DataGridViewTextBoxColumn)grdPurchaseDC.Columns["clmQuantity"]).MaxInputLength = 8;
                grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.BackColor = Color.PaleGreen;
                grdPurchaseDC.Columns["clmQuantity"].ReadOnly = false;
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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(30, 0, 0, 0, 0, txtSupplier.Text, 0, 0, 0, "", 0, 0, 0, 0, 0, 0,"");
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
                if (lblSupplierCode.Text.Length > 0)
                {
                    int varReturnApplicable = 0, varReturnType = 0;
                    objDs = objspdservice.udfnSupplierList(16, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, "", 0, 0, Convert.ToInt32(cmbConcern.SelectedValue), "", 0, 0, 0, 0, 0, 0,"");
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
                txtProductName.BackColor = Color.LemonChiffon;
                if (Convert.ToString(txtSupplier.Text) != "")
                {
                    txtSupplier.BackColor = Color.White;
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(23, 0, 0, 0, 0, txtSupplier.Text.Trim(), 0, 0, 0, "", 0, 0, 0, 0, 0, 0,"");
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
                        ObjsLocation = objDserv.udfnStockLocationList(25, 0, 0, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0, 0, 0);
                        objDserv.CloseConnection();
                        if (ObjsLocation != null)
                        {
                            if (ObjsLocation.Tables.Count > 0)
                            {
                                if (ObjsLocation.Tables[0].Rows.Count > 0)
                                {
                                    lblStockLocationCode.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SLID"]);
                                    txtStockLocation.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SL_EName"]);
                                    lvStockLocation.Visible = false;
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
                    epPurchaseDC.SetError(txtProductName, "Please enter product");
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
                udfnDefalutLocation();
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
                lvproduct.Visible = false;
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
                if (txtMrp.Text.Trim() == "")
                {
                    txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtMrp, "Please enter MRP");
                    tpMRP.ShowAlways = true;
                    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                }
                else
                {
                    txtMrp.BackColor = Color.White;
                    epPurchaseDC.Clear();
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
                if (txtMonth.Text.Trim() == "")
                {
                    txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtMonth, "Please enter MRP");
                }
                else
                {
                    txtMonth.BackColor = Color.White;
                    epPurchaseDC.Clear();
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
                    txtBatchNo.Focus();
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
                    objDs = objspdservice.udfnStockLocationList(10, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0);
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
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvStockLocation.Items.Add(objList);
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
                string varProductsCodes = "0";
                txtRack.Text = "";
                txtRack.Enabled = true;
                lblRackCode.Text = "0";
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnproductmasterlist(29, 0, 0, 0, 0, txtProductName.Text, "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, txtProductName.Text, Convert.ToInt32(lblSupplierCode.Text), varProductsCodes,"", null);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString() };
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
                txtRack.Focus();
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
                    txtRack.Focus();
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
                        DataSet objDsSupplierId = new DataSet();
                        SPDataService objDserv = new SPDataService();
                        objDsSupplierId = objDserv.udfnSupplierList(23, 0, 0, 0, 0, txtSupplier.Text.Trim(), 0, 0, 0, "", 0, 0, 0, 0, 0, 0,"");
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
                    if (txtDcNo.Text=="")
                    {
                        epPurchaseDC.SetError(txtDcNo, "DC No. is empty.");
                        //txtDcNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpDcNo.ShowAlways = true;
                        tpDcNo.Show("DC No. is empty.", txtDcNo, 5000);
                        varErrorFlag = false;
                    }
                    for(int i=0;i<grdPurchaseDC.Rows.Count;i++)
                    {
                        if(Convert.ToString( grdPurchaseDC.Rows[i].Cells["clmQuantity"].Value)=="0")
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
                    if (varErrorFlag == true && varErrQty=="0")
                    {
                        udfnTooltipHide(); int varDC_PURID = 0; int varStatusID = 18;
                        if (grdPurchaseDC.Rows.Count > 0)
                        {
                            if (lblSupplierCode.Text != "0" && lblschedule.Text != "0")
                            {
                                string result = "", varorginator = "Purchase DC";
                                int varviewtype = 0;
                                if (btnSave.Text == "Update")
                                {
                                    varviewtype = 1;
                                    varorginator = "Purchase DC Update";
                                }

                                
                            TRN_Purchase_DC objTRNS_Purchase_DC = new TRN_Purchase_DC();
                            objTRNS_Purchase_DC.ViewType = varviewtype;
                            objTRNS_Purchase_DC.paraUserID =Convert.ToInt32( MainForm.pbUserID);
                            objTRNS_Purchase_DC.paraIPAddress = MainForm.pbIpAddress;
                            objTRNS_Purchase_DC.paraOriginator = varorginator;
                            objTRNS_Purchase_DC.paraDCID = varDCID;
                            objTRNS_Purchase_DC.paraCompanyId =Convert.ToInt32( cmbConcern.SelectedValue);
                            objTRNS_Purchase_DC.paraDC_Date = dpDCDate.Text;
                            objTRNS_Purchase_DC.paraDC_NO = txtDcNo.Text.Trim();
                            objTRNS_Purchase_DC.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text.Trim());
                            objTRNS_Purchase_DC.paraScheduleID = Convert.ToInt32( lblschedule.Text.Trim());
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
                                            }
                                        }
                                    }
                                }
                                //else
                                //{
                                //    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    if (varvalue[0] == "5")
                                //    {
                                //        string[] values = varvalue[2].Split(',');
                                //        for (int i = 0; i < grdsupplieradd.Rows.Count; i++)
                                //        {
                                //            foreach (string value in values)
                                //            {
                                //                if (Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value) == value || Convert.ToString(grdsupplieradd.Rows[i].Cells["ID"].Value) == value)
                                //                {

                                //                    grdsupplieradd.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                //                    grdsupplieradd.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                                //                }
                                //            }
                                //        }
                                //    }
                                //}
                                //this.ActiveControl = cmbConcern;
                                //}
                                //else
                                //{
                                //    SPDataService objDServ = new SPDataService();
                                //    string varMessage = objDServ.udfnGetMessages(77);
                                //    objDServ.CloseConnection();
                                //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //}
                            }
                        }
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(41);
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

        private void GrdPurchaseDC_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
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
        private void GrdPurchaseDC_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    object varEditQty = grdPurchaseDC.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //    //Update the same column value in the DataTable
            //    dtPurchaseDC.Rows[e.RowIndex]["DCPR_Qty"] = varEditQty;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            try
            {
                int Quantity = Convert.ToInt32(grdPurchaseDC.CurrentRow.Cells["clmQuantity"].Value);
                if (Convert.ToString(Quantity) == "0" || Convert.ToString(Quantity) == "")
                {
                    grdPurchaseDC.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.LightPink;
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrQty = "1";
                    grdPurchaseDC.Rows[e.RowIndex].Cells["clmError"].Value = varErrQty;
                }
                else
                {
                    grdPurchaseDC.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.PaleGreen;
                    varErrQty = "0";
                    grdPurchaseDC.Rows[e.RowIndex].Cells["clmError"].Value = varErrQty;
                }
                object varEditQty = grdPurchaseDC.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                //Update the same column value in the DataTable
                dtPurchaseDC.Rows[e.RowIndex]["DCPR_Qty"] = varEditQty;
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
                                //for (int i = 0; i < grdPurchaseDC.RowCount; i++)
                                //{
                                //    grdPurchaseDC.Rows[i].Cells["clmSno"].Value = i + 1;
                                //}
                                for (int i = 0; i < dtPurchaseDC.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtPurchaseDC.Rows[i]["DCPR_PRID"]) == Convert.ToInt32(varProductID) )
                                    {
                                        dtPurchaseDC.Rows[i].Delete();
                                        dtPurchaseDC.AcceptChanges();
                                    }
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
                    txtRack.Focus();
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
                if (txtMrp.Text.Trim() == "")
                {
                    txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtMrp, "Please enter MRP.");
                    tpMRP.ShowAlways = true;
                    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                    blnErrorFlag = true;
                }
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
                if (txtBatchNo.Text.Trim() == "")
                {
                    txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtBatchNo, "Please enter BatchNo.");
                    tpBatchNo.ShowAlways = true;
                    tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                    blnErrorFlag = true;
                }
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtActualQty, "Please enter quantity.");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity.", txtActualQty, 5000);
                    blnErrorFlag = true;
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
                    DataSet objDsproductId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsproductId = objDserv.udfnproductmasterlist(39, 0, 0, 0, 0, "", "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, txtProductName.Text, Convert.ToInt32(lblSupplierCode.Text), "","" ,null);
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
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
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
                    objDsLocation = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0);
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
                        tpStockLocation.Show("Please select purchase stock location.", txtStockLocation, 5000);
                        blnErrorFlag = true;
                    }
                }
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
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
                            }
                        }
                        lblRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (Convert.ToInt32( varId_PurchaseRack )< 0 || varId_PurchaseRack == "-1")
                        {
                            epPurchaseDC.SetError(txtRack, "Please enter valid rack.");
                            txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                            tpRack.ShowAlways = true;
                            tpRack.Show("Please enter valid rack", txtRack, 5000);
                            blnErrorFlag = true;
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
                    udfnExpiryDate();
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
                    for (int i = 0; i < grdPurchaseDC.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(lblProductcode.Text) == Convert.ToInt32(grdPurchaseDC.Rows[i].Cells["ClmPRID"].Value))
                        {
                            string varMRP = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmMRP"].Value).Trim();
                            string varNewExpiryDate = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmExpiryDate"].Value).Trim();
                            string varBatch = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmBatchNo"].Value).Trim();
                            string varSLID = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmSLID"].Value).Trim();
                            string varRKID = Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmRKID"].Value).Trim();
                            if (txtMrp.Text.Trim() == varMRP && varExpiryDate == varNewExpiryDate && txtBatchNo.Text.Trim() == varBatch ) 
                            {
                                if(lblStockLocationCode.Text.Trim() == varSLID && lblRackCode.Text.Trim() == varRKID)
                                {
                                    lblProductcode.Text = "0";
                                    //epPurchaseDC.SetError(txtProductName, "Product already exist for this location");
                                    //txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    //tpProduct.ShowAlways = true;
                                    //tpProduct.Show("Product already Exist for this location", txtProductName, 5000);
                                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
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
                int varExpiryDays = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if(txtDay.Text.Trim()=="")
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
                    { varDay = txtDay.Text.Trim(); }
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
                }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Length < 4)
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
                    if (txtDay.Text.Trim() == "")
                    {
                        varMonth = Convert.ToString(txtMonth.Text.Trim());
                        varYear = Convert.ToString(txtYear.Text.Trim());
                        varDate = varDay + "/" + varMonth + "/" + varYear;
                        objDS = objDServ.udfnMaster(5, 0, 0, varDate, "", 0);
                        objDServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varExpiryDate = objDS.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();
                        }
                    }
                    varMonth = Convert.ToString(txtMonth.Text.Trim());
                    varYear = Convert.ToString(txtYear.Text.Trim());
                    varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                    objDS = objDServ.udfnMaster(10, 0, 0, dpDCDate.Text.Trim(), varExpiryDate,Convert.ToInt32(lblProductcode.Text.Trim()));
                    if (objDS.Tables.Count != 0)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varExpiryDays = Convert.ToInt32(objDS.Tables[0].Rows[0]["ExpiryDate"]);
                        }
                    }
                    if(varExpiryDays<0)
                    {
                        pbDateflag = 1;
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(94);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (objDS.Tables.Count > 1)
                        {
                            if (Convert.ToInt32(objDS.Tables[1].Rows[0]["DATEVALIDATE"])== 0)
                            {
                                pbDateflag = 1;
                                txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                string varMessage = objDServ.udfnGetMessages(94);
                                objDServ.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            pbDateflag = 0;
                        }
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
                if (txtActualQty.Text.Trim() == "0")
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
                        grdPurchaseDC.Rows.Add(grdPurchaseDC.Rows.Count + 1, varPICode.Trim(), varEName.Trim(), txtMrp.Text.Trim(), varExpiryDate, txtBatchNo.Text.Trim(), txtActualQty.Text.Trim(), lblUnit.Text, txtStockLocation.Text.Trim(), txtRack.Text.Trim(), addproductid, lblStockLocationCode.Text, lblRackCode.Text, varunitid);
                        dtPurchaseDC.Rows.Add(Convert.ToInt32(addproductid), Convert.ToDecimal(txtMrp.Text.Trim()), varExpiryDate, txtBatchNo.Text.Trim(), Convert.ToDecimal(txtActualQty.Text.Trim()), Convert.ToInt32(varunitid), Convert.ToInt32(lblStockLocationCode.Text), Convert.ToInt32(lblRackCode.Text));
                        ((DataGridViewTextBoxColumn)grdPurchaseDC.Columns["clmQuantity"]).MaxInputLength = 8;
                        grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.BackColor = Color.PaleGreen;
                        //grdPurchaseDC.Columns["clmQuantity"].ReadOnly = false;
                        grdPurchaseDC.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdPurchaseDC.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        udfnAddClear();
                        udfnProductCount();
                    }
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
                if (btnSave.Text == "Save")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpDCDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetPONO("149", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string pono = parts[0];
                        if (pono != "")
                        {
                            txtDcNo.Text = pono;
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(75);
                            objDServ.CloseConnection();
                            txtDcNo.Text = "";
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
        private void DpDCDate_ValueChanged(object sender, EventArgs e)
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
                    objDs = objspdservice.udfnproductmasterlist(34, Convert.ToInt32(lblProductcode.Text), 0, 0, 0, "", "", "", 0, 0, 0, Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, "", Convert.ToInt32(lblSupplierCode.Text), "","", null);
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
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[1].Text;
                    lblProductcode.Text = selectedItem.SubItems[3].Text;
                    udfnProductAdd();
                }
                udfnDefalutLocation();
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
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
                    txtMrp.Focus();
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
