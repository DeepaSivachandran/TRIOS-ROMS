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
using System.Globalization;

namespace ROMS
{
    public partial class PUR_PurchaseReturns : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpSupplier = new ToolTip();
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpReason = new ToolTip();
        private ToolTip tpDcNo = new ToolTip();

        public int varReturnDCID = 0, varCloseFlag=0;
        public int pbScheduleid = 0, pbSupplierId=0;
        public string varSuppliervalue = "";
        DataTable dtPurchaseReturnDC = new DataTable();
        public PUR_PurchaseReturns()
        {
            InitializeComponent();
        }
        public void udfnTooltipHide()
        {
            try
            {
                tpcompanyname.Active = false;
                tpSupplier.Active = false;
                tpSuppliername.Active = false;
                tpReason.Active = false;
                tpDcNo.Active = false;
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
        public void udfnReasonforClosing()
        {
            try
            {
                if(Convert.ToInt32(cmbReasonForClosing.SelectedValue)==61 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 62) //received credit note
                {
                    txtDAmount.Visible = true;
                    txtAmount.Visible = true;
                    txtDCrNo.Visible = true;
                    txtCrNo.Visible = true;
                    dpCreditNoteDate.Visible = true;
                    dpDCreditNoteDate.Visible = true;
                    dpCreditNoteDate.Enabled = true;
                    btnView.Visible = false;
                }
                else if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 63) //Received Equivalent Product
                {
                    txtDAmount.Visible = true;
                    txtAmount.Visible = true;
                    txtDCrNo.Visible = false;
                    txtCrNo.Visible = false;
                    dpCreditNoteDate.Visible = false;
                    dpDCreditNoteDate.Visible = false;
                    btnView.Visible = true;
                }
                else if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 64) //Debit Note Created
                {
                    txtDAmount.Visible = true;
                    txtAmount.Visible = true;
                    txtDCrNo.Visible = false;
                    txtCrNo.Visible = false;
                    dpCreditNoteDate.Visible = false;
                    dpDCreditNoteDate.Visible = false;
                    btnView.Visible = false;
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
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbReason.SelectedValue)==60) //damage
            {
                txtProductName.Enabled = false;
                txtpurchaseRate.Enabled = false;
                txtActualQty.Enabled = false;
                btnAdd.Enabled = false;
                lblTotal.Text = "Approximate Total";
            }
            else if (Convert.ToInt32(cmbReason.SelectedValue) == 61) //excess
            {
                txtProductName.Enabled = true;
                txtpurchaseRate.Enabled = true;
                txtActualQty.Enabled = true;
                btnAdd.Enabled = true;
                lblTotal.Text = "Actual Total";
            }
            udfnList();
        }
        public void udfnVocherno()
        {
            try
            {
                if (varReturnDCID == 0)
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpReturnDCDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetPONO("150", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string pono = parts[0];
                        if (pono != "")
                        {
                            txtReturnDcNo.Text = pono;
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(75);
                            objDServ.CloseConnection();
                            txtReturnDcNo.Text = "";
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
                        txtReturnDcNo.Text = "";
                    }
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
        public void udfnReason()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=19 OR MSTID=-1 ", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                txtDAmount.Visible = false;
                txtAmount.Visible = false;
                txtDCrNo.Visible = false;
                txtCrNo.Visible = false;
                dpCreditNoteDate.Visible = false;
                dpDCreditNoteDate.Visible = false;
                btnView.Visible = false;
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
                dtPurchaseReturnDC.TableName = "TRN_Purchase_ReturnDC";
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_PRID", typeof(int));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_MRP", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_ExpDate", typeof(string));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_BatchNo", typeof(string));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_AppRate", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_Qty", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_UTID", typeof(int));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_TaxableAmnt", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_GSTPer", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_GSTAmnt", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_NettAmnt", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("DMID", typeof(string));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PUR_PurchaseReturns_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                udfnReason();
                udfnUddtTable();
                udfnClosingDropdown();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dpReturnDCDate.MinDate = MainForm.pbFYStartDate;
                dpReturnDCDate.MaxDate = MainForm.pbCurrentDate;
                this.ActiveControl = txtSupplier;
                txtSupplier.Focus();
                if (btnSave.Text == "Save")
                {
                    grpReason.Enabled = false;
                }
                else
                {
                    EditLoad();
                    grpReturnDCSupplier.Enabled = false;
                    udfnClosingDropdown();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClosingDropdown()
        {
            try
            {
                if (Convert.ToInt32(cmbReason.SelectedValue)==60) //damage
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=20 OR MSTID=-1 ", "MST_DisplayText,MSTID", cmbReasonForClosing, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
                else if (Convert.ToInt32(cmbReason.SelectedValue) == 61) //excess
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=21 OR MSTID=-1 ", "MST_DisplayText,MSTID", cmbReasonForClosing, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnList()
        {
            try
            {
                // Varflag = 0;
                int varStatusid = 0; int varviewtype = 2;
                if (Convert.ToInt32(cmbReason.SelectedValue) == 60)
                {
                    varStatusid = 20; //Damage entry status completed
                }
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                epReturnDc.Clear();
                grdReturnDC.DataSource = null;
                DataSet objDs = new DataSet();
                string varSupplierId = "0";
                //**** To call the function from SP ********* 
                SPDataService objdserv = new SPDataService();
                TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                objTRN_PurchaseReturnDC.paraViewType = varviewtype;
                objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_PurchaseReturnDC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_PurchaseReturnDC.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_PurchaseReturnDC.ParaScheduleID = Convert.ToInt32(lblschedule.Text);
                objTRN_PurchaseReturnDC.paraStatusID = Convert.ToInt32(varStatusid);
                objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                objDs = objdserv.udfnReturnDC(objTRN_PurchaseReturnDC);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdReturnDC.DataSource = objDs.Tables[0];
                            grdReturnDC.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            txtSubTotal.Text= Convert.ToString(objDs.Tables[1].Rows[0]["SubTotal"]);
                            txtTotalTax.Text= Convert.ToString(objDs.Tables[1].Rows[0]["Total Tax"]);
                            txtApproxTotal.Text= Convert.ToString(objDs.Tables[1].Rows[0]["Approximate Total"]);
                            grdReturnDC.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                       
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
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
                if (varReturnDCID != 0)
                {
                    int varviewtype = 4;
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_ReturnDC objTRN_ReturnDC = new TRN_ReturnDC();
                    objTRN_ReturnDC.paraViewType = varviewtype;
                    objTRN_ReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_ReturnDC.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_ReturnDC.paraReturnDCID = varReturnDCID;
                    objTRN_ReturnDC.ParaSupplierId = pbSupplierId;
                    objTRN_ReturnDC.ParaScheduleID = pbScheduleid;
                    objDs = objdserv.udfnReturnDC(objTRN_ReturnDC);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                grdReturnDC.Rows.Clear();
                                cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["PURREDC_COMID"].ToString();
                                dpReturnDCDate.Text = objDs.Tables[0].Rows[0]["PURREDC_DCDate"].ToString();
                                txtReturnDcNo.Text = objDs.Tables[0].Rows[0]["PURREDC_DCNO"].ToString();
                                txtSupplier.Text = objDs.Tables[0].Rows[0]["Supplier"].ToString();
                                lblSupplierCode.Text = objDs.Tables[0].Rows[0]["SPID"].ToString();
                                lblschedule.Text = objDs.Tables[0].Rows[0]["SPSCID"].ToString();
                                txtRemarks.Text = objDs.Tables[0].Rows[0]["PURREDC_Remarks"].ToString();
                                cmbReason.SelectedValue= objDs.Tables[0].Rows[0]["PURREDC_ReasonId"].ToString();
                                txtSubTotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SubTotal"]);
                                txtTotalTax.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Total Tax"]);
                                txtApproxTotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Approximate Total"]);
                                //btnSave.Text = "Update";
                                udfnsupplierLoad();
                            }
                            if (objDs.Tables.Count != 0)
                            {
                                lblNoRecordsFound.Visible = false;
                                if (objDs.Tables[1].Rows.Count != 0)
                                {
                                    lblNoRecordsFound.Visible = false;
                                    lblNoRecordsFound.SendToBack();
                                    grdReturnDC.DataSource = objDs.Tables[1];
                                    grdReturnDC.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                }
                                else
                                {
                                    lblNoRecordsFound.Visible = true;
                                    lblNoRecordsFound.BringToFront();
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
                LV_Supplier.Visible = false;
                grdReturnDC.ClearSelection();
            }
        }
        private void CmbReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dpDCreditNoteDate.Visible = false;
                txtDCrNo.Visible = false;
                dpCreditNoteDate.Visible = false;
                txtCrNo.Visible = false;
                if (cmbReasonForClosing.SelectedIndex == 1) {
                    MainForm.objPUR_DCGoodsInward = new PUR_DCGoodsInward();
                    MainForm.objPUR_DCGoodsInward.ShowDialog();
                }
                if (cmbReasonForClosing.SelectedIndex == 0) {
                    dpDCreditNoteDate.Visible = true;
                    txtDCrNo.Visible = true;
                    dpCreditNoteDate.Visible = true;
                    txtCrNo.Visible = true;
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
                    txtSupplier.Focus();
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
                    epReturnDc.SetError(cmbConcern, "Please select concern.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select convern.", cmbConcern, 5000);
                }
                else
                {
                    epReturnDc.Clear();
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
                txtReturnDcNo.Text = "";
                udfnVocherno();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpReturnDCDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpReturnDCDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpReturnDCDate_KeyDown(object sender, KeyEventArgs e)
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
        private void DpReturnDCDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpReturnDCDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpReturnDCDate_ValueChanged(object sender, EventArgs e)
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
                            lblReturn.Text = objDs.Tables[0].Rows[0]["RETURNAPPLICABLE"].ToString();
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
                    cmbReason.Focus();
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
                    epReturnDc.SetError(txtSupplier, "Please enter supplier.");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                }
                else
                {
                    epReturnDc.Clear();
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
        private void LV_Supplier_DoubleClick_1(object sender, EventArgs e)
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
        private void LV_Supplier_KeyDown_1(object sender, KeyEventArgs e)
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
        private void CmbReason_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbReason.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReason_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbReason.SelectedValue) == "" || Convert.ToString(cmbReason.SelectedValue) == "-1")
                {
                    epReturnDc.SetError(cmbReason, "Please select reason.");
                    cmbReason.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReason.ShowAlways = true;
                    tpReason.Show("Please select reason.", cmbReason, 5000);
                }
                else
                {
                    epReturnDc.Clear();
                    cmbReason.BackColor = Color.White;
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReason_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // dpDCDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReason_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtRemarks_KeyDown(object sender, KeyEventArgs e)
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
                if (grdReturnDC.RowCount > 0)
                {
                    bool varErrorFlag = true;
                    if (txtSupplier.Text == "")
                    {
                        epReturnDc.SetError(txtSupplier, "Please enter supplier.");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                        varErrorFlag = false;
                    }
                    if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                    {
                        epReturnDc.SetError(cmbConcern, "Please select concern.");
                        cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpcompanyname.ShowAlways = true;
                        tpcompanyname.Show("Please select concern.", cmbConcern, 5000);
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
                            epReturnDc.SetError(txtSupplier, "Invalid supplier.");
                            txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpSuppliername.ShowAlways = true;
                            tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                            lblSupplierCode.Text = "0";
                            lblschedule.Text = "0";
                            varErrorFlag = false;
                        }
                        else
                        {
                            epReturnDc.Clear();
                            lblSupplierCode.Text = values[0];
                            lblschedule.Text = values[1];
                            txtSupplier.BackColor = Color.White;
                        }
                    }
                    if (txtReturnDcNo.Text == "")
                    {
                        epReturnDc.SetError(txtReturnDcNo, "DC No. is empty.");
                        tpDcNo.ShowAlways = true;
                        tpDcNo.Show("DC No. is empty.", txtReturnDcNo, 5000);
                        varErrorFlag = false;
                    }
                    if (varErrorFlag == true)
                    {
                        udfnTooltipHide(); int varDC_PURID = 0; int varReasonforClosingId = 0;
                        string varReturnDcAmount = ""; int varStatusID = 15;
                        if (varReturnDCID!=0)
                        {  varReasonforClosingId =Convert.ToInt32(cmbReasonForClosing.SelectedValue); }
                        else { varReasonforClosingId = 0; }

                        if (txtAmount.Text == "") { varReturnDcAmount = "0"; }
                        else
                        {
                            varReturnDcAmount = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                        }

                        if (grdReturnDC.Rows.Count > 0)
                        {
                            dtPurchaseReturnDC.Rows.Clear();
                            dtPurchaseReturnDC.AcceptChanges();
                            for (int i = 0; i < grdReturnDC.Rows.Count; i++)
                            {
                                dtPurchaseReturnDC.Rows.Add(Convert.ToInt32(grdReturnDC.Rows[i].Cells["PRID"].Value), Convert.ToDecimal(grdReturnDC.Rows[i].Cells["MRP"].Value),Convert.ToString(grdReturnDC.Rows[i].Cells["Expiry Date"].Value), grdReturnDC.Rows[i].Cells["Batch No."].Value,
                                   Convert.ToDecimal(grdReturnDC.Rows[i].Cells["Approximate Rate"].Value), Convert.ToDecimal(grdReturnDC.Rows[i].Cells["Qty"].Value), Convert.ToInt32(grdReturnDC.Rows[i].Cells["UTID"].Value),
                                     Convert.ToDecimal(grdReturnDC.Rows[i].Cells["Taxable Amt"].Value), Convert.ToDecimal(grdReturnDC.Rows[i].Cells["GST%"].Value), Convert.ToDecimal(grdReturnDC.Rows[i].Cells["GST Amt"].Value),
                                    Convert.ToDecimal(grdReturnDC.Rows[i].Cells["Net Amt"].Value), grdReturnDC.Rows[i].Cells["DMID"].Value);
                            }
                            if (lblSupplierCode.Text != "0" && lblschedule.Text != "0")
                            {
                                string result = "", varorginator = ""; int varviewtype = 0;
                                if (varReturnDCID == 0)
                                {
                                    varviewtype = 0;
                                    varorginator = "Purchase Return DC insertion";
                                }
                                else
                                {
                                    varviewtype = 1;
                                    varorginator = "Purchase Return DC updation";
                                }
                                TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                                objTRN_PurchaseReturnDC.paraViewType = varviewtype;
                                objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                                objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                                objTRN_PurchaseReturnDC.paraOriginator = varorginator;
                                objTRN_PurchaseReturnDC.paraReturnDCID = varReturnDCID;
                                objTRN_PurchaseReturnDC.paraReasonId = Convert.ToInt32(cmbReason.SelectedValue);
                                objTRN_PurchaseReturnDC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                                objTRN_PurchaseReturnDC.paraReturnDC_Date = dpReturnDCDate.Text;
                                objTRN_PurchaseReturnDC.ParaSubtotal = Convert.ToDecimal(txtSubTotal.Text.Trim());
                                objTRN_PurchaseReturnDC.paraTax = Convert.ToDecimal(txtTotalTax.Text.Trim());
                                objTRN_PurchaseReturnDC.paraReturnDC_NO = txtReturnDcNo.Text.Trim();
                                objTRN_PurchaseReturnDC.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text.Trim());
                                objTRN_PurchaseReturnDC.ParaScheduleID = Convert.ToInt32(lblschedule.Text.Trim());
                                objTRN_PurchaseReturnDC.paraReturnDC_Remarks = txtRemarks.Text.Trim();
                                objTRN_PurchaseReturnDC.paraStatusID = varStatusID;
                                objTRN_PurchaseReturnDC.paraClosingReasonId = varReasonforClosingId;
                                objTRN_PurchaseReturnDC.paraReturnDCAmount = Convert.ToDecimal(varReturnDcAmount);
                                objTRN_PurchaseReturnDC.paraCreditNoteDate = dpCreditNoteDate.Text.Trim();
                                objTRN_PurchaseReturnDC.paraCreditNoteNo = txtCrNo.Text.Trim();
                                objTRN_PurchaseReturnDC.paraTRN_Purchase_ReturnDC = dtPurchaseReturnDC;
                                SPDataService objspdservice = new SPDataService();
                                result = objspdservice.udfnPurchaseReturnDc(objTRN_PurchaseReturnDC);
                                objspdservice.CloseConnection();
                                string[] varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.ActiveControl = txtSupplier;
                                    if (varReturnDCID != 0)
                                    {
                                        varCloseFlag = 1;
                                    }
                                    udfnclose();
                                    MainForm.objPUR_PurchaseDCList.udfnList();
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void CmbReasonForClosing_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbReasonForClosing.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReasonForClosing_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReasonForClosing.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReasonForClosing_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbReasonForClosing.Select(int.MaxValue, 0)));
                udfnReasonforClosing();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReasonForClosing_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbReasonForClosing_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAmount.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAmount.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCrNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCrNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCrNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCrNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCrNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCrNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpCreditNoteDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_DCGoodsInward = new PUR_DCGoodsInward();
                MainForm.objPUR_DCGoodsInward.varConcernId = Convert.ToInt32(cmbConcern.SelectedValue);
                MainForm.objPUR_DCGoodsInward.varReturnDCDate = dpReturnDCDate.Text;
                MainForm.objPUR_DCGoodsInward.varSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                MainForm.objPUR_DCGoodsInward.varScheduleId = Convert.ToInt32(lblschedule.Text);
                MainForm.objPUR_DCGoodsInward.varReturnDCID = varReturnDCID;
                MainForm.objPUR_DCGoodsInward.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpCreditNoteDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpCreditNoteDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpCreditNoteDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpCreditNoteDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpCreditNoteDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemarks.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpCreditNoteDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpCreditNoteDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PUR_PurchaseReturns_KeyDown(object sender, KeyEventArgs e)
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
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PUR_PurchaseReturns_Leave(object sender, EventArgs e)
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

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PUR_PurchaseReturns_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

    }
}
