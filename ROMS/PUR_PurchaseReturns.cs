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
        private ToolTip tpCrNo = new ToolTip();
        private ToolTip tpAmount = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpQTY = new ToolTip();
        public int varUpDownKey = 0;
        public int vareditflag = 0;
        public int varReturnDCID = 0, varCloseFlag = 0;
        public int pbScheduleid = 0, pbSupplierId = 0, varStatusId = 0, varSource= 0, varModifiedFlag = 0, varCreditDCID=0, varEditFlag=0,varClose = 0, varDateChange = 0;
        public string varSuppliervalue = "";
        DataTable dtPurchaseReturnDC = new DataTable();
        DataTable dtStock = new DataTable();
        public DataTable dtExchangeProducts = new DataTable();
        public string varExchangeRemarks = "";
        public string varSupplierID = "";
        public string varSupplierScheduleID = "";
        public string varSupplierName = "";
        bool varVoucherSkip = false;
        public bool VarSearchFlag = true;
        public string varProductName = "";
        public string varPICode = "";
        public int varSLID = 0, vaReturnDCSts = 0;
        public int varGRNStatus = 0;
        public int varRKID = 0;
        public int varDecimal = 0;
        public decimal varApprox = 0;
        public int varGST = 0, VerifiedBy=0;
        public string varBlockedSupplier = "0", varBlockedReason = "";


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
                tpCrNo.Active = false;
                tpAmount.Active = false;
                tpProduct.Active = false;
                tpQTY.Active = false;
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
                lblSalesmanName.Text = "";
                lblMobileNo.Text = "";
                lblWhatsAppNo.Text = "";
                lblInvoiceDate.Text = "";
                lblInvoiceNo.Text = "";
                lblInvoiceDate2.Text = "";
                lblInvoiceNo2.Text = "";
                lblVoucherNo.Text = "";
                lblVoucherDate.Text = "";
                grdRepDetails.DataSource = null;
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
                /*if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 61 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 62 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 204) *///received credit note
                if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 192 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 207)
                {
                    txtDAmount.Visible = true;
                    txtAmount.Visible = true;
                    txtDCrNo.Visible = true;
                    txtCrNo.Visible = true;
                    dpCreditNoteDate.Visible = true;
                    dpDCreditNoteDate.Visible = true;
                    dpCreditNoteDate.Enabled = true;
                    btnView.Visible = false;
                    dtExchangeProducts.Rows.Clear();
                    dtExchangeProducts.AcceptChanges();
                    varModifiedFlag = 1;
                }
                else if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 63 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 205) //Received Equivalent Product
                {
                    txtDAmount.Visible = true;
                    txtAmount.Visible = true;
                    txtDCrNo.Visible = false;
                    txtCrNo.Visible = false;
                    txtCrNo.Text = "";
                    dpCreditNoteDate.Visible = false;
                    dpDCreditNoteDate.Visible = false;
                    btnView.Visible = true;
                    if (varStatusId != 39 && varStatusId != 79)
                    {
                        udfnView();
                    }
                    varModifiedFlag = 1;
                }
                else if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 64 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 314 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 192 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 206 )//|| Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 207) //Credit Note Created
                {
                    txtDAmount.Visible = true;
                    txtAmount.Visible = true;
                    txtDCrNo.Visible = false;
                    txtCrNo.Visible = false;
                    txtCrNo.Text = "";
                    dpCreditNoteDate.Visible = false;
                    dpDCreditNoteDate.Visible = false;
                    btnView.Visible = false;
                    varModifiedFlag = 1;
                }
                else if(Convert.ToInt32(cmbReasonForClosing.SelectedValue) == -1)
                {
                    txtDAmount.Visible = false;
                    txtAmount.Visible = false;
                    txtDCrNo.Visible = false;
                    txtCrNo.Visible = false;
                    txtCrNo.Text = "";
                    txtAmount.Text = "";
                    dpCreditNoteDate.Visible = false;
                    dpDCreditNoteDate.Visible = false;
                    btnView.Visible = false;
                    dtExchangeProducts.Rows.Clear();
                    dtExchangeProducts.AcceptChanges();
                }
                if (txtAmount.Visible == true)
                {
                    txtAmount.Text = txtApproxTotal.Text;
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
                if (varClose == 0)
                {
                    if (varStatusId == 39)
                    {
                        //this.Close();
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
                            MainForm.objINV_SalesInvoiceList.Show();
                            MainForm.objINV_SalesInvoiceList.udfnList();
                        }
                    }
                    else
                    {
                        if (varModifiedFlag == 1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                this.Close();
                                MainForm.objINV_SalesInvoiceList.Show();
                                MainForm.objINV_SalesInvoiceList.udfnList();
                            }
                            else
                            { btnSave.Focus(); }
                        }
                        else
                        {
                            if (varCloseFlag == 0)
                            {
                                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    this.Close();
                                    MainForm.objINV_SalesInvoiceList.Show();
                                    MainForm.objINV_SalesInvoiceList.udfnList();
                                }
                            }
                            else { this.Close(); }
                        }
                    }
                    //MainForm.objINV_SalesInvoiceList.udfnList();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbReason.SelectedValue) == 60) //damage
            {
                txtProductName.Enabled = false;
                txtpurchaseRate.Enabled = false;
                txtActualQty.Enabled = false;
                btnDAdd.Enabled = false;
                lblTotal.Text = "Approximate Total";
            }
            else if (Convert.ToInt32(cmbReason.SelectedValue) == 61) //excess
            {
                txtProductName.Enabled = true;
                txtpurchaseRate.Enabled = true;
                txtActualQty.Enabled = true;
                btnDAdd.Enabled = true;
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
                        varResult = objspdservice.udfngetVoucherNo("150", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string pono = parts[0];
                        if (pono != "")
                        {
                            txtReturnDcNo.Text = pono;
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
        public void udfnCreditNoteVocherno()
        {
            try
            {
                if (varReturnDCID != 0)
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpReturnDCDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetVoucherNo("150", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string pono = parts[0];
                        if (pono != "")
                        {
                            txtReturnDcNo.Text = pono;
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
        public void udfnvoucheradd()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(75);
                objDServ.CloseConnection();
                txtReturnDcNo.Text = "";
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
        public void udfnClear()
        {
            try
            {
                txtSupplier.Text = "";
                cmbReason.SelectedValue = -1;
                txtSubTotal.Text = "";
                txtApproxTotal.Text = "";
                txtTotalTax.Text = "";
                txtRemarks.Text = "";
                ClearSupplier();
                udfnTooltipHide();
                grdReturnDC.DataSource = null;
                txtAmount.Text = "";
                cmbReasonForClosing.SelectedValue = -1;
                txtCrNo.Text = "";
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
                if(btnSave.Text=="Save")
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID IN(0,19) AND MSTID NOT IN(0, 61) ", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
                else
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=19 OR MSTID =-1 ", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
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
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_SLID", typeof(int));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_RKID", typeof(int));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_FreeQty", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_PURPRID", typeof(int));
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
                dtStock.TableName = "TRN_StockTransfer_Product_AutoComplete";
                dtStock.Columns.Add("STK_PRID", typeof(int));
                dtStock.Columns.Add("STK_MRP", typeof(decimal));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(string));
                dtStock.Columns.Add("STK_QTY", typeof(decimal));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(string));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(string));
                dtStock.Columns.Add("STK_ProType", typeof(int));
                dtStock.Columns.Add("STK_Status", typeof(int));
                this.grdReturnDC.Size = new System.Drawing.Size(1289, 317);
                grdReturnDC.Location = new Point(9, 23);
                grbProDetails.SendToBack();
                udfnCmbConcern();
                chkVerified.Visible = false;
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    udfnReason();
                    ClearSupplier();
                    udfnUddtTable();
                    udfnClosingDropdown();
                    cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                    dpReturnDCDate.MinDate = MainForm.pbFYStartDate;
                    dpReturnDCDate.MaxDate = MainForm.pbCurrentDate;
                    dpCreditNoteDate.MinDate = MainForm.pbFYStartDate;
                    dpCreditNoteDate.MaxDate = MainForm.pbCurrentDate;
                    this.ActiveControl = txtSupplier;
                    txtSupplier.Focus();
                    if (btnSave.Text == "Save")
                    {
                        grpReason.Enabled = false;
                    }
                    else
                    {
                        if (varEditFlag == 1)
                        {
                            varReturnDCID = varCreditDCID;
                        }
                        EditLoad();
                        if (varStatusId == 39 && vareditflag==0)
                        {
                            txtAmount.Enabled = false;
                            txtCrNo.Enabled = false;
                            dpCreditNoteDate.Enabled = false;
                            cmbReasonForClosing.Enabled = false;
                            txtRemarks.Enabled = false;
                            btnSave.Enabled = false;
                            //lblStatus.Text = "Closed";
                            //Approximate Rate Readonly Color Set
                            grdReturnDC.Columns["clmApprox"].DefaultCellStyle.BackColor = Color.LightGray;
                            grdReturnDC.Columns["clmApprox"].ReadOnly = true;
                        }
                        else if (varStatusId == 39 && vareditflag == 1)
                        {
                            txtCrNo.Enabled = false;
                            dpCreditNoteDate.Enabled = false;
                            cmbReasonForClosing.Enabled = false;
                            txtRemarks.Enabled = true;
                            btnSave.Enabled = true;
                            txtAmount.Enabled = true;
                            chkVerified.Visible = true;
                            //lblStatus.Text = "Closed";
                            //chkVerified.Checked = true;
                            //chkVerified.Enabled = false;
                        }
                        else if (varStatusId==79)
                        {
                            txtAmount.Enabled = false;
                            chkVerified.Visible = true;
                            txtRemarks.Enabled = false;
                            btnSave.Enabled = false;
                            cmbReasonForClosing.Enabled = false;
                        }
                        else
                        {
                            grpReason.Enabled = false;
                            if (varStatusId == 16)
                            {
                                grpReason.Enabled = true;
                                //lblStatus.Text = "Linked with GRN";
                            }
                        }
                        grpReturnDCSupplier.Enabled = false;
                        if(varStatusId==68)
                        {
                            grbProDetails.Enabled = true;
                            if (varSource == 1)
                            {
                                chkCompleted.Checked = false;
                                chkCompleted.Enabled = false;
                            }
                            else
                            {
                                chkCompleted.Checked = false;
                                chkCompleted.Enabled = true;
                            }
                        }
                        else
                        {
                            grbProDetails.Enabled = false;
                            chkCompleted.Checked = true;
                            chkCompleted.Enabled = false;
                        }
                        if(varGRNStatus==23 || vaReturnDCSts == 101)
                        {
                            cmbReasonForClosing.Enabled = true;
                            txtAmount.Enabled = true;
                            txtCrNo.Enabled = true;
                            dpCreditNoteDate.Enabled = true;
                            grpReason.Enabled = true;
                        }
                        //else
                        //{
                        //    cmbReasonForClosing.Enabled = false;
                        //    txtAmount.Enabled = false;
                        //    txtCrNo.Enabled = false;
                        //    dpCreditNoteDate.Enabled = false;
                        //}
                        if(varStatusId!=39 && varStatusId!=79)
                        {
                            grbProDetails.Enabled = true;
                        }
                    }
                }
                ChkCompleted_CheckedChanged(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (btnSave.Enabled == false)
                {
                    cmbReasonForClosing.Enabled = false;
                    txtAmount.Enabled = false;
                    txtCrNo.Enabled = false;
                    dpCreditNoteDate.Enabled = false;
                }
                grdReturnDC.ClearSelection();
            }
        }
        public void udfnClosingDropdown()
        {
            try
            {
                if (Convert.ToInt32(cmbReason.SelectedValue) == 60) //damage
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
                else
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=65 OR MSTID=-1 ", "MST_DisplayText,MSTID", cmbReasonForClosing, "", "MST_DisplayText", "MSTID");
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
                int varStatusid = 0; int varviewtype = 0;
                if (Convert.ToInt32(cmbReason.SelectedValue) == 60)
                {
                    varviewtype = 2;
                    varStatusid = 20; //Damage entry status completed
                }
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                epReturnDc.Clear();
                grdReturnDC.DataSource = null;
                grdReturnDC.Rows.Clear();
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
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdReturnDC.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[0].Rows[i]["P.I Code"]), Convert.ToString(objDs.Tables[0].Rows[i]["Product Name"]),0,0, Convert.ToString(objDs.Tables[0].Rows[i]["MRP"]),
                                    Convert.ToString(objDs.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Batch No."]), Convert.ToString(objDs.Tables[0].Rows[i]["Approximate Rate"]), Convert.ToString(objDs.Tables[0].Rows[i]["Qty"]),0, Convert.ToString(objDs.Tables[0].Rows[i]["Unit"]),
                                    Convert.ToString(objDs.Tables[0].Rows[i]["Taxable Amt"]), Convert.ToString(objDs.Tables[0].Rows[i]["GST%"]), Convert.ToString(objDs.Tables[0].Rows[i]["GST Amt"]), Convert.ToString(objDs.Tables[0].Rows[i]["Net Amt"]), Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]));

                                dtPurchaseReturnDC.Rows.Add(Convert.ToInt32(objDs.Tables[0].Rows[i]["PRID"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Batch No."]),
                                        Convert.ToDecimal(objDs.Tables[0].Rows[i]["Approximate Rate"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Qty"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["UTID"]),
                                        Convert.ToDecimal(objDs.Tables[0].Rows[i]["Taxable Amt"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["GST%"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["GST Amt"]),
                                        Convert.ToDecimal(objDs.Tables[0].Rows[i]["Net Amt"]), Convert.ToString(objDs.Tables[0].Rows[i]["DMID"]), Convert.ToString(objDs.Tables[0].Rows[i]["DM_Dest_SLID"]), 0,0,0);
                            }
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdReturnDC.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdReturnDC.Columns["clmApprox"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdReturnDC.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdReturnDC.Columns["clmTax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdReturnDC.Columns["clmGSTAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdReturnDC.Columns["clmNettAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdReturnDC.Columns["clmGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdReturnDC.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdReturnDC.Columns["clmProduct"].Width = 300;
                            grdReturnDC.Columns["clmSno"].Width = 50;
                            grdReturnDC.Columns["clmMRP"].Width = 80;
                            grdReturnDC.Columns["clmQuantity"].Width = 70;
                            grdReturnDC.Columns["clmUnit"].Width = 70;
                            grdReturnDC.Columns["clmGST"].Width = 70;
                            grdReturnDC.Columns["clmGSTAmount"].Width = 70;
                            grdReturnDC.Columns["clmApprox"].Width = 120;
                            grdReturnDC.Columns["clmPRID"].Visible = false;
                            grdReturnDC.Columns["clmUTID"].Visible = false;
                            grdReturnDC.Columns["clmDMID"].Visible = false;
                            grdReturnDC.Columns["clmSLID"].Visible = false;
                            grdReturnDC.Columns["clmRKID"].Visible = false;
                            grdReturnDC.Columns["clmLocation"].Visible = false;
                            grdReturnDC.Columns["clmRack"].Visible = false;
                            grdReturnDC.Columns["clmRemove"].Visible = false;
                            grdReturnDC.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdReturnDC.Columns["clmUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                        if (objDs.Tables.Count == 2)
                        {
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                //lblNoRecordsFound.Visible = false;
                                //lblNoRecordsFound.SendToBack();
                                txtSubTotal.Text = Convert.ToString(objDs.Tables[1].Rows[0]["SubTotal"]);
                                txtTotalTax.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Total Tax"]);
                                txtApproxTotal.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Approximate Total"]);
                            }
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
            finally
            { grdReturnDC.ClearSelection(); }
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
                                cmbReason.SelectedValue = objDs.Tables[0].Rows[0]["PURREDC_ReasonId"].ToString();
                                txtSubTotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SubTotal"]);
                                txtTotalTax.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Total Tax"]);
                                txtApproxTotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Approximate Total"]);
                                varStatusId = Convert.ToInt32(objDs.Tables[0].Rows[0]["Status ID"]);
                                //lblStatus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Status"]);
                                tsbStatus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Status"]);
                                tsbStatus.Visible = true;
                                VerifiedBy = Convert.ToInt32(objDs.Tables[0].Rows[0]["PURREDC_VerifiedBy"]);
                                varBlockedSupplier = Convert.ToString(objDs.Tables[0].Rows[0]["SP_STSId"]);
                                varBlockedReason = Convert.ToString(objDs.Tables[0].Rows[0]["Reason"]);
                                varSource = Convert.ToInt32(objDs.Tables[0].Rows[0]["Source"]);
                                /* Disable completed option for auto generated DCs*/
                                if (varSource == 1) { chkCompleted.Enabled = false; }
                                udfnClosingDropdown();
                                //btnSave.Text = "Update";
                                udfnsupplierLoad();
                                if (varBlockedSupplier == "98")
                                {
                                    tsbSupplier.Visible = true;
                                    txtSupplier.BackColor = Color.LightPink;
                                    tsbSupplier.Text = varBlockedReason;
                                }
                                else
                                {
                                    tsbSupplier.Visible = false;
                                    txtSupplier.BackColor = Color.White;
                                }
                            }
                            if(varStatusId==79)
                            {
                                chkVerified.Checked = true;
                            }
                            if(VerifiedBy!=0)
                            {
                                chkVerified.Checked = true;
                            }
                            if (objDs.Tables.Count != 0)
                            {
                                lblNoRecordsFound.Visible = false;
                                if (objDs.Tables[1].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                                    {
                                        grdReturnDC.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[1].Rows[i]["P.I Code"]), Convert.ToString(objDs.Tables[1].Rows[i]["Product Name"]),Convert.ToString(objDs.Tables[1].Rows[i]["Location"]), Convert.ToString(objDs.Tables[1].Rows[i]["Rack"]), Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["Batch No."]), Convert.ToString(objDs.Tables[1].Rows[i]["Approximate Rate"]), Convert.ToString(objDs.Tables[1].Rows[i]["Qty"]), Convert.ToString(objDs.Tables[1].Rows[i]["FreeQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["Unit"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["Taxable Amt"]), Convert.ToString(objDs.Tables[1].Rows[i]["GST%"]), Convert.ToString(objDs.Tables[1].Rows[i]["GST Amt"]), Convert.ToString(objDs.Tables[1].Rows[i]["Net Amt"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["DMID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PURPRID"]));

                                        dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), string.Format("{0:G29}", decimal.Parse(Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]))), Convert.ToString(objDs.Tables[1].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["Batch No."]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["Qty"]), 0, Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), 0, 0); 

                                        dtPurchaseReturnDC.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["Batch No."]),
                                        Convert.ToDecimal(objDs.Tables[1].Rows[i]["Approximate Rate"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["Qty"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["UTID"]),
                                        Convert.ToDecimal(objDs.Tables[1].Rows[i]["Taxable Amt"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GST%"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GST Amt"]),
                                        Convert.ToDecimal(objDs.Tables[1].Rows[i]["Net Amt"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["DMID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["FreeQty"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["PURPRID"]));
                                    }
                                    grdReturnDC.Columns["clmProduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lblNoRecordsFound.Visible = false;
                                    lblNoRecordsFound.SendToBack();
                                    //grdReturnDC.DataSource = objDs.Tables[1];
                                    grdReturnDC.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    grdReturnDC.Columns["clmApprox"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdReturnDC.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdReturnDC.Columns["clmFreeQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdReturnDC.Columns["clmTax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdReturnDC.Columns["clmGSTAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdReturnDC.Columns["clmNettAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdReturnDC.Columns["clmGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdReturnDC.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    grdReturnDC.Columns["clmProduct"].Width = 300;
                                    grdReturnDC.Columns["clmSno"].Width = 50;
                                    grdReturnDC.Columns["clmMRP"].Width = 80;
                                    grdReturnDC.Columns["clmQuantity"].Width = 70;
                                    grdReturnDC.Columns["clmUnit"].Width = 70;
                                    grdReturnDC.Columns["clmGST"].Width = 70;
                                    grdReturnDC.Columns["clmGSTAmount"].Width = 70;
                                    grdReturnDC.Columns["clmApprox"].Width = 120;
                                    grdReturnDC.Columns["clmPRID"].Visible = false;
                                    grdReturnDC.Columns["clmUTID"].Visible = false;
                                    grdReturnDC.Columns["clmDMID"].Visible = false;
                                    grdReturnDC.Columns["clmSLID"].Visible = false;
                                    grdReturnDC.Columns["clmRKID"].Visible = false;
                                    if(Convert.ToInt32(cmbReason.SelectedValue) == 203)
                                    {
                                        if (varStatusId != 39 && varStatusId != 79 && varStatusId != 15)
                                        {
                                            grdReturnDC.Columns["clmRemove"].Visible = true;
                                        }
                                        else
                                        {
                                            //Approximate Rate Readonly Color Set
                                            grdReturnDC.Columns["clmApprox"].DefaultCellStyle.BackColor = Color.LightGray;
                                            grdReturnDC.Columns["clmApprox"].ReadOnly = true;
                                            grdReturnDC.Columns["clmRemove"].Visible = false;
                                        }
                                        grdReturnDC.Columns["clmLocation"].Visible = true;
                                        grdReturnDC.Columns["clmRack"].Visible = true;
                                    }
                                    else
                                    {
                                        //grdReturnDC.Columns["clmRemove"].Visible = false;
                                        grdReturnDC.Columns["clmLocation"].Visible = false;
                                        grdReturnDC.Columns["clmRack"].Visible = false;
                                    }
                                    grdReturnDC.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdReturnDC.Columns["clmUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    //grdReturnDC.Columns["clmProduct"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
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
                            if (objDs.Tables[2].Rows.Count != 0)
                            {
                                if ((varStatusId == 39 || varStatusId==79 || varStatusId==110) && (Convert.ToInt32(cmbReason.SelectedValue) == 60 || Convert.ToInt32(cmbReason.SelectedValue) == 61 || Convert.ToInt32(cmbReason.SelectedValue) == 203 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 192 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 204 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 205 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 206 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 207))
                                {
                                    cmbReasonForClosing.SelectedValue = objDs.Tables[2].Rows[0]["PURREDC_ClosingReasonId"].ToString();
                                    txtCrNo.Text = objDs.Tables[2].Rows[0]["PURREDC_CNNo"].ToString();
                                    txtAmount.Text = objDs.Tables[2].Rows[0]["PURREDC_Amnt"].ToString();
                                    dpCreditNoteDate.Text = objDs.Tables[2].Rows[0]["PURREDC_CNDate"].ToString();
                                }
                            }
                            if (objDs.Tables[3].Rows.Count > 0)
                            {
                                //if (objDs.Tables[3].Rows[0]["InvoiceNo"].ToString() != "")
                                //{ lblInvoiceNo.Text = "Invoice No. - " + objDs.Tables[3].Rows[0]["InvoiceNo"].ToString(); }
                                //if (objDs.Tables[3].Rows[0]["InvoiceDate"].ToString() != "")
                                //{ lblInvoiceDate.Text = "Invoice Date - " + objDs.Tables[3].Rows[0]["InvoiceDate"].ToString(); }
                                if (objDs.Tables[3].Rows[0]["InvoiceNo"].ToString() != "")
                                { lblInvoiceNo2.Text = "Invoice No. - " + objDs.Tables[3].Rows[0]["InvoiceNo"].ToString(); }
                                if (objDs.Tables[3].Rows[0]["InvoiceDate"].ToString() != "")
                                { lblInvoiceDate2.Text = "Invoice Date - " + objDs.Tables[3].Rows[0]["InvoiceDate"].ToString(); }
                                if (objDs.Tables[3].Rows[0]["VoucherNo"].ToString() != "")
                                { lblVoucherNo.Text = "Voucher No. - " + objDs.Tables[3].Rows[0]["VoucherNo"].ToString(); }
                                if (objDs.Tables[3].Rows[0]["VoucherDate"].ToString() != "")
                                { lblVoucherDate.Text = "Voucher Date - " + objDs.Tables[3].Rows[0]["VoucherDate"].ToString(); }
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
                if (cmbReasonForClosing.SelectedIndex == 1)
                {
                    MainForm.objPUR_DCGoodsInward = new PUR_DCGoodsInward();
                    MainForm.objPUR_DCGoodsInward.ShowDialog();
                }
                if (cmbReasonForClosing.SelectedIndex == 0)
                {
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
                    tpcompanyname.Show("Please select concern.", cmbConcern, 5000);
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
                if (Convert.ToInt32(grdReturnDC.Rows.Count) != 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(78);
                    objDServ.CloseConnection();

                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dtPurchaseReturnDC.Rows.Clear();
                        grdReturnDC.DataSource = null;
                        grdRepDetails.DataSource = null;
                    }
                    else
                    {
                        grdReturnDC.Refresh();
                    }
                }
                txtReturnDcNo.Text = "";
                varDateChange = 0;
                udfnVocherno();
                udfnCreditNoteVocherno();
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
                LV_Supplier.Visible = false;
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
                varDateChange = 1;
                udfnVocherno();
                udfnCreditNoteVocherno();
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
                    objMR_Supplier.ViewType = 35;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString(), objDs.Tables[0].Rows[i]["STSID"].ToString(), objDs.Tables[0].Rows[i]["Reason"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[3].Width = 0;
                                LV_Supplier.Columns[4].Width = 0;
                                LV_Supplier.Columns[5].Width = 0;
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
                    varBlockedSupplier = selectedItem.SubItems[4].Text;
                    varBlockedReason = selectedItem.SubItems[5].Text;

                    if (Convert.ToInt32(grdReturnDC.Rows.Count) != 0)
                    {
                        if (Convert.ToString(lblSupplierCode.Text.Trim()) != Convert.ToString(varSupplierID))
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(78);
                            objDServ.CloseConnection();

                            DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                dtPurchaseReturnDC.Rows.Clear();
                                grdReturnDC.DataSource = null;
                                grdReturnDC.Rows.Clear();
                                grdRepDetails.DataSource = null;
                                grdRepDetails.Rows.Clear();
                            }
                            else
                            {
                                grdReturnDC.Refresh();
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
                    cmbReason.Enabled = true;
                    cmbReason.Focus();
                }
                if (varBlockedSupplier == "98")
                {
                    tsbSupplier.Visible = true;
                    txtSupplier.BackColor = Color.LightPink;
                    tsbSupplier.Text = varBlockedReason;
                }
                else
                {
                    tsbSupplier.Visible = false;
                    txtSupplier.BackColor = Color.White;
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
                cmbReason.Focus();
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
                    cmbReason.Focus();
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
                if(varBlockedSupplier=="98")
                {
                    txtSupplier.BackColor = Color.LightPink;
                }
                else
                {
                    tsbSupplier.Visible = false;
                    txtSupplier.BackColor = Color.White;
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
                LV_Supplier.Visible = false;
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
                    if (Convert.ToInt32(cmbReason.SelectedValue)==203)
                    {
                        txtProductNamePICode.Focus();
                    }
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
                int varReturnDCStatusId = 0;
                if (grdReturnDC.RowCount > 0)
                {
                    bool varErrorFlag = true;
                    int  varVerifiedflag=0;
                    string varVerified = "";
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
                        if(varBlockedSupplier=="98")
                        {
                            txtSupplier.BackColor = Color.LightPink;
                        }
                    }
                    if (txtReturnDcNo.Text == "")
                    {
                        epReturnDc.SetError(txtReturnDcNo, "DC No. is empty.");
                        tpDcNo.ShowAlways = true;
                        tpDcNo.Show("DC No. is empty.", txtReturnDcNo, 5000);
                        varErrorFlag = false;
                    }
                    if (varStatusId == 16 || varStatusId==101)
                    {
                        if (Convert.ToString(cmbReasonForClosing.SelectedValue) == "" || Convert.ToString(cmbReasonForClosing.SelectedValue) == "-1")
                        {
                            epReturnDc.SetError(cmbReasonForClosing, "Please select reason for closing.");
                            cmbReasonForClosing.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpReason.ShowAlways = true;
                            tpReason.Show("Please select reason for closing.", cmbReasonForClosing, 5000);
                            varErrorFlag = false;
                        }
                        if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) != 205 && Convert.ToInt32(cmbReasonForClosing.SelectedValue) != 63)
                        {
                            if (txtAmount.Text.Trim() == "")
                            {
                                epReturnDc.SetError(txtAmount, "Please enter amount.");
                                txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpAmount.ShowAlways = true;
                                tpAmount.Show("Please enter amount.", txtAmount, 5000);
                                varErrorFlag = false;
                            }
                            else
                            {
                                //if (Convert.ToDecimal(txtAmount.Text) > Convert.ToDecimal(txtApproxTotal.Text))
                                //{
                                //    epReturnDc.SetError(txtAmount, "Please enter valid amount.");
                                //    txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                //    tpAmount.ShowAlways = true;
                                //    tpAmount.Show("Please enter valid amount.", txtAmount, 5000);
                                //    varErrorFlag = false;
                                //}
                            }
                        }
                        if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 62)
                        {
                            if (txtCrNo.Text == "")
                            {
                                epReturnDc.SetError(txtCrNo, "Please enter credit number.");
                                txtCrNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpCrNo.ShowAlways = true;
                                tpCrNo.Show("Please enter credit number.", txtCrNo, 5000);
                                varErrorFlag = false;
                            }
                        }
                        if (dtExchangeProducts.Rows.Count == 0)
                        {
                            if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 63 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 205)
                            {
                                MessageBox.Show("Please add atleast one exchange product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varErrorFlag = false;
                            }
                        }
                    }
                    if (varBlockedSupplier == "98")
                    {
                        txtSupplier.BackColor = Color.LightPink;
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(134);
                        objDServ.CloseConnection();
                        DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            varErrorFlag = false;
                        }
                    }
                    if (varErrorFlag == true)
                    {
                        udfnTooltipHide(); int varDC_PURID = 0; int varReasonforClosingId = 0;
                        string varReturnDcAmount = "";
                        if (varReturnDCID != 0)
                        { varReasonforClosingId = Convert.ToInt32(cmbReasonForClosing.SelectedValue); }
                        else { varReasonforClosingId = 0; }

                        if (txtAmount.Text == "") { varReturnDcAmount = "0"; }
                        else
                        {
                            varReturnDcAmount = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                        }

                        if (grdReturnDC.Rows.Count > 0)
                        {
                            //dtPurchaseReturnDC.Rows.Clear();
                            //dtPurchaseReturnDC.AcceptChanges();
                            /*
                            for (int i = 0; i < grdReturnDC.Rows.Count; i++)
                            {
                                dtPurchaseReturnDC.Rows.Add(Convert.ToInt32(grdReturnDC.Rows[i].Cells["clmPRID"].Value), Convert.ToDecimal(grdReturnDC.Rows[i].Cells["clmMRP"].Value), Convert.ToString(grdReturnDC.Rows[i].Cells["clmExpiryDate"].Value), Convert.ToString(grdReturnDC.Rows[i].Cells["clmBatchno"].Value),
                                   Convert.ToDecimal(grdReturnDC.Rows[i].Cells["clmApprox"].Value), Convert.ToDecimal(grdReturnDC.Rows[i].Cells["clmQuantity"].Value), Convert.ToInt32(grdReturnDC.Rows[i].Cells["clmUTID"].Value),
                                     Convert.ToDecimal(grdReturnDC.Rows[i].Cells["clmTax"].Value), Convert.ToDecimal(grdReturnDC.Rows[i].Cells["clmGST"].Value), Convert.ToDecimal(grdReturnDC.Rows[i].Cells["clmGSTAmount"].Value),
                                    Convert.ToDecimal(grdReturnDC.Rows[i].Cells["clmNettAmount"].Value),Convert.ToInt32(grdReturnDC.Rows[i].Cells["clmDMID"].Value), Convert.ToInt32(grdReturnDC.Rows[i].Cells["clmSLID"].Value), Convert.ToInt32(grdReturnDC.Rows[i].Cells["clmRKID"].Value));
                            }
                            */
                            if (lblSupplierCode.Text != "0" && lblschedule.Text != "0")
                            {
                                string result = "", varorginator = ""; int varviewtype = 0;
                                if (varReturnDCID == 0)
                                {
                                    varviewtype = 0;
                                    //if (Convert.ToInt32(cmbReason.SelectedValue) == 203)
                                    //{
                                        if (chkCompleted.Checked == true)
                                        {
                                            varStatusId = 15;
                                        }
                                        else
                                        {
                                            varStatusId = 68;
                                        }
                                    //}
                                    //else
                                    //{
                                        //varStatusId = 68;
                                    //}
                                    varorginator = "Purchase Return DC insertion";
                                }
                                if (varStatusId == 16 || varStatusId==39 || varStatusId==101)
                                {
                                    varviewtype = 1;
                                    varorginator = "Purchase Return DC updation";
                                    //varStatusId = 39;
                                }
                                if((varStatusId==15 && varReturnDCID!=0) || varStatusId==79)
                                {
                                    varviewtype = 1;
                                    varorginator = "Purchase Return DC updation";
                                }
                                if(varStatusId==68 && varReturnDCID!=0)
                                {
                                    if(chkCompleted.Checked==true)
                                    {
                                        varStatusId = 15;
                                    }
                                    else
                                    {
                                        varStatusId = 68;
                                    }
                                    varviewtype = 1;
                                    varorginator = "Purchase Return DC updation";
                                }
                                decimal subtotal = 0, TotalTax = 0;
                                if(txtSubTotal.Text.Trim()!="")
                                {
                                    subtotal = Convert.ToDecimal(txtSubTotal.Text);
                                }
                                if (txtTotalTax.Text.Trim() != "")
                                {
                                    TotalTax = Convert.ToDecimal(txtTotalTax.Text);
                                }
                                //The Past Status is closed time no need to check the Exchange products
                                varReturnDCStatusId = varStatusId;
                                if (chkVerified.Checked==true)
                                {
                                    varVerifiedflag = 1;
                                    varStatusId = 79;
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
                                objTRN_PurchaseReturnDC.ParaSubtotal = subtotal;
                                objTRN_PurchaseReturnDC.paraTax = TotalTax;
                                objTRN_PurchaseReturnDC.paraReturnDC_NO = txtReturnDcNo.Text.Trim();
                                objTRN_PurchaseReturnDC.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text.Trim());
                                objTRN_PurchaseReturnDC.ParaScheduleID = Convert.ToInt32(lblschedule.Text.Trim());
                                objTRN_PurchaseReturnDC.paraReturnDC_Remarks = txtRemarks.Text.Trim();
                                objTRN_PurchaseReturnDC.paraStatusID = varStatusId;
                                objTRN_PurchaseReturnDC.paraClosingReasonId = varReasonforClosingId;
                                objTRN_PurchaseReturnDC.paraReturnDCAmount = Convert.ToDecimal(varReturnDcAmount);
                                objTRN_PurchaseReturnDC.paraCreditNoteNo = txtCrNo.Text.Trim();
                                objTRN_PurchaseReturnDC.paraCreditNoteDate = dpCreditNoteDate.Text.Trim();
                                objTRN_PurchaseReturnDC.paraPurchaseId = 0;
                                objTRN_PurchaseReturnDC.paraFlag = varVerifiedflag;
                                objTRN_PurchaseReturnDC.paraUpdateflag = 0;
                                objTRN_PurchaseReturnDC.paraTRN_Purchase_ReturnDC = dtPurchaseReturnDC;
                                if (dtExchangeProducts.Rows.Count != 0)
                                {
                                    objTRN_PurchaseReturnDC.paraDeleteFlag = 1;
                                    objTRN_PurchaseReturnDC.ParaTRN_ReturnDCProducts = dtExchangeProducts;
                                    objTRN_PurchaseReturnDC.paraExchangeRemarks = varExchangeRemarks;
                                }
                                else
                                {
                                    if (varReasonforClosingId == 63 || varReasonforClosingId == 205)
                                    {
                                        if (varReturnDCStatusId != 39)
                                        {
                                            MessageBox.Show("Please add atleast one exchange product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            varErrorFlag = false;
                                        }
                                    }
                                }
                                if (varErrorFlag == true)
                                {
                                    SPDataService objspdservice = new SPDataService();
                                    result = objspdservice.udfnPurchaseReturnDc(objTRN_PurchaseReturnDC);
                                    objspdservice.CloseConnection();

                                    string[] varvalue = result.Split('~');
                                    if (result.Split('~')[0] == "3")
                                    {
                                        if (result.Split('~')[1] == "1")
                                        {
                                            MainForm.objCP_Verify = new CP_Verify();
                                            MainForm.objCP_Verify.ShowDialog();
                                            varVerified = Convert.ToString(MainForm.objCP_Verify.varUserId);
                                            if (MainForm.objCP_Verify.flag == 1)
                                            {
                                                objTRN_PurchaseReturnDC.paraViewType = varviewtype;
                                                objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                                                objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                                                objTRN_PurchaseReturnDC.paraOriginator = varorginator;
                                                objTRN_PurchaseReturnDC.paraReturnDCID = varReturnDCID;
                                                objTRN_PurchaseReturnDC.paraReasonId = Convert.ToInt32(cmbReason.SelectedValue);
                                                objTRN_PurchaseReturnDC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                                                objTRN_PurchaseReturnDC.paraReturnDC_Date = dpReturnDCDate.Text;
                                                objTRN_PurchaseReturnDC.ParaSubtotal = subtotal;
                                                objTRN_PurchaseReturnDC.paraTax = TotalTax;
                                                objTRN_PurchaseReturnDC.paraReturnDC_NO = txtReturnDcNo.Text.Trim();
                                                objTRN_PurchaseReturnDC.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text.Trim());
                                                objTRN_PurchaseReturnDC.ParaScheduleID = Convert.ToInt32(lblschedule.Text.Trim());
                                                objTRN_PurchaseReturnDC.paraReturnDC_Remarks = txtRemarks.Text.Trim();
                                                objTRN_PurchaseReturnDC.paraStatusID = varStatusId;
                                                objTRN_PurchaseReturnDC.paraClosingReasonId = varReasonforClosingId;
                                                objTRN_PurchaseReturnDC.paraReturnDCAmount = Convert.ToDecimal(varReturnDcAmount);
                                                objTRN_PurchaseReturnDC.paraCreditNoteNo = txtCrNo.Text.Trim();
                                                objTRN_PurchaseReturnDC.paraCreditNoteDate = dpCreditNoteDate.Text.Trim();
                                                objTRN_PurchaseReturnDC.paraPurchaseId = 0;
                                                objTRN_PurchaseReturnDC.paraFlag = 0;
                                                objTRN_PurchaseReturnDC.paraUpdateflag = 1;
                                                objTRN_PurchaseReturnDC.paraVerifiedBy = Convert.ToInt32(varVerified);
                                                result = objspdservice.udfnPurchaseReturnDc(objTRN_PurchaseReturnDC);
                                            }
                                        }
                                        string[] varvalue1 = result.Split('~');
                                        if (varvalue1[0] == "3")
                                        {
                                            if (varvalue1[1] != "1")
                                            {
                                                MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); this.ActiveControl = txtSupplier;
                                                if (varReturnDCID != 0)
                                                {
                                                    varCloseFlag = 1;
                                                    varModifiedFlag = 0;
                                                }
                                                string ReturnDCID = "0";
                                                if (varReturnDCID == 0)
                                                {
                                                    ReturnDCID = varvalue[2];
                                                }
                                                else
                                                {
                                                    ReturnDCID = Convert.ToString(varReturnDCID);
                                                }
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
                                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_PUR_ReturnDC.rpt");
                                                    varHeader = "Purchase Return DC";

                                                    objBillreport.SetParameterValue("paraReturnDCID", Convert.ToInt32(ReturnDCID));
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

                                                udfnClear();
                                                this.Close();
                                                if (vareditflag == 1)
                                                {
                                                    MainForm.objPUR_ReturnApprovedList.udfnList();
                                                }
                                                else
                                                {
                                                    MainForm.objINV_SalesInvoiceList.udfnList();
                                                }
                                            }
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
                if (Convert.ToString(cmbReasonForClosing.SelectedValue) == "" || Convert.ToString(cmbReasonForClosing.SelectedValue) == "-1")
                {
                    epReturnDc.SetError(cmbReasonForClosing, "Please select reason for closing.");
                    cmbReasonForClosing.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReason.ShowAlways = true;
                    tpReason.Show("Please select reason for closing.", cmbReasonForClosing, 5000);

                }
                {
                    epReturnDc.Clear();
                    cmbReasonForClosing.BackColor = Color.White;
                    tpReason.Active = false;
                }
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
                    txtAmount.Focus();
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
                if (txtAmount.Text == "")
                {
                    epReturnDc.SetError(txtAmount, "Please enter amount.");
                    txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAmount.ShowAlways = true;
                    tpAmount.Show("Please enter amount.", txtAmount, 5000);
                }
                else
                {
                    epReturnDc.Clear();
                    txtAmount.BackColor = Color.White;
                    tpAmount.Active = false;
                }
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
                    if (txtCrNo.Enabled == true)
                    {
                        txtCrNo.Focus();
                    }
                    else
                    {
                        if (txtRemarks.Enabled == true)
                        {
                            txtRemarks.Focus();
                        }
                        else
                        {
                            btnSave.Focus();
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
                if (txtCrNo.Text == "")
                {
                    epReturnDc.SetError(txtCrNo, "Please enter credit number.");
                    txtCrNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCrNo.ShowAlways = true;
                    tpCrNo.Show("Please enter credit number.", txtCrNo, 5000);
                }
                else
                {
                    epReturnDc.Clear();
                    txtCrNo.BackColor = Color.White;
                    tpCrNo.Active = false;
                }
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
        public void udfnView()
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
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                udfnView();
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

        private void CmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdReturnDC.Rows.Count > 0 && Convert.ToInt32(cmbReason.SelectedValue) !=-1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(78);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        dtPurchaseReturnDC.Rows.Clear();
                        grdReturnDC.DataSource = null;
                        grdRepDetails.DataSource = null;
                    }
                }
                if (Convert.ToInt32(cmbReason.SelectedValue) == 60) //damage
                {
                    this.grdReturnDC.Size = new System.Drawing.Size(1289, 317);
                    grdReturnDC.Location = new Point(9, 23);
                    grbProDetails.SendToBack();
                    grbProDetails.Visible = false;
                    DGV_FilterProduct.DataSource = null;
                    DGV_FilterProduct.Visible = false;
                    txtProductNamePICode.Text = "";
                    grdReturnDC.DataSource = null;
                    grdReturnDC.Rows.Clear();
                    txtProductName.Enabled = false;
                    txtpurchaseRate.Enabled = false;
                    txtActualQty.Enabled = false;
                    btnDAdd.Enabled = false;
                    lblTotal.Text = "Approximate Total";
                    lblNoRecordsFound.Visible = true;
                }
                if (Convert.ToInt32(cmbReason.SelectedValue) == 61) //excess
                {
                    this.grdReturnDC.Size = new System.Drawing.Size(1289, 317);
                    grdReturnDC.Location = new Point(9, 23);
                    grbProDetails.SendToBack();
                    grbProDetails.Visible = false;
                    grdReturnDC.DataSource = null;
                    grdReturnDC.Rows.Clear();
                    txtProductName.Enabled = true;
                    txtpurchaseRate.Enabled = true;
                    txtActualQty.Enabled = true;
                    btnDAdd.Enabled = true;
                    lblTotal.Text = "Actual Total";
                    lblNoRecordsFound.Visible = true;
                }
                if (Convert.ToInt32(cmbReason.SelectedValue) == 203) //Regular
                {
                    this.grdReturnDC.Size = new System.Drawing.Size(1289,250);
                    grdReturnDC.Location = new Point(9, 90);
                    grbProDetails.BringToFront();
                    grbProDetails.Visible = true;
                    lblNoRecordsFound.Visible = false;
                    grdReturnDC.DataSource = null;
                    grdReturnDC.Rows.Clear();
                }
                if (varReturnDCID==0)
                {
                    if (Convert.ToInt32(cmbReason.SelectedValue) != 203)
                    {
                        udfnList();
                    }
                }
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
                    txtMRP.Text = "";
                    txtRack.Text = "";
                    txtExpiryDate.Text = "";
                    txtBatchNo.Text = "";
                    txtQuantity.Text = "";
                    txtStockQty.Text = "";
                    txtLocation.Text = "";
                    if (txtProductNamePICode.Text.Length > 0)
                    {
                        if (dtStock.Rows.Count < 1)
                        {
                            dtStock.Rows.Add(0, 0, "", "", "", 0, "", "", "", 0);
                        }
                        DataSet objDs = new DataSet();
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 58;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.ParaSupplierId =Convert.ToInt32(lblSupplierCode.Text);
                        objMR_Product.paraStockTransfer = dtStock;
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
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.BringToFront();
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["RKID"].Visible = false;
                                    DGV_FilterProduct.Columns["SLID"].Visible = false;
                                    DGV_FilterProduct.Columns["APPROX"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["GST_Value"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["SL_ShortName"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["RK_ShortName"].DisplayIndex = 4;
                                    DGV_FilterProduct.Columns["STK_MRP"].DisplayIndex = 5;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].DisplayIndex = 6;
                                    DGV_FilterProduct.Columns["STK_BatchNo"].DisplayIndex = 7;
                                    DGV_FilterProduct.Columns["QTY"].DisplayIndex = 8;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 9;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["SL_ShortName"].HeaderText = "Location";
                                    DGV_FilterProduct.Columns["RK_ShortName"].HeaderText = "Rack";
                                    DGV_FilterProduct.Columns["STK_MRP"].HeaderText = "MRP";
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].HeaderText = "Expiry Date";
                                    DGV_FilterProduct.Columns["STK_BatchNo"].HeaderText = "Batch No.";
                                    DGV_FilterProduct.Columns["QTY"].HeaderText = "Quantity";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
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

        private void TxtProductNamePICode_Leave(object sender, EventArgs e)
        {
            try
            {
                epReturnDc.Clear();
                txtProductNamePICode.BackColor = Color.White;
                /*
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    epReturnDc.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductNamePICode, 5000);
                }
                else
                {
                    epReturnDc.Clear();
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

        private void TxtProductNamePICode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblProductNamePICode.Text = "Search by P.I Code (F11)";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductNamePICode.Text = "Search by Product Name (F11)";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Normal;
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
                                    txtQuantity.Focus();
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
                        txtQuantity.Focus();
                    }
                }
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
                {
                    varProductName = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                    lblUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varSLID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["SLID"].Value.ToString());
                    varRKID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["RKID"].Value.ToString());
                    txtStockQty.Text = DGV_FilterProduct.SelectedRows[0].Cells["QTY"].Value.ToString();
                    txtLocation.Text= DGV_FilterProduct.SelectedRows[0].Cells["SL_ShortName"].Value.ToString();
                    txtRack.Text= DGV_FilterProduct.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                    txtMRP.Text= DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                    txtExpiryDate.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                    txtBatchNo.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                    varApprox = Convert.ToDecimal(DGV_FilterProduct.SelectedRows[0].Cells["APPROX"].Value.ToString());
                    varGST = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["GST_Value"].Value.ToString());
                    txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
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
        private void TxtProductNamePICode_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                txtProductNamePICode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                txtQuantity.BackColor = Color.LemonChiffon;
                if(txtProductNamePICode.Text.Trim()!="")
                {
                    txtProductNamePICode.BackColor = Color.White;
                    epReturnDc.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQuantity_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantity.Text.Trim() != "")
                {
                    string Qty = objValidation.udfnDecimal((txtQuantity.Text).Trim(), varDecimal);
                    txtQuantity.Text = Qty;
                }
                epReturnDc.Clear();
                txtQuantity.BackColor = Color.White;
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
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    epReturnDc.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductNamePICode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtQuantity.Text).Trim() != "")
                {
                    if (Convert.ToDecimal(txtStockQty.Text.Trim()) >= Convert.ToDecimal(txtQuantity.Text.Trim()))
                    {
                        epReturnDc.Clear();
                        txtQuantity.BackColor = Color.White;

                        string Qty = objValidation.udfnDecimal((txtQuantity.Text).Trim(), varDecimal);
                        txtQuantity.Text = Qty;
                    }
                    else
                    {
                        epReturnDc.SetError(txtQuantity, "Please enter valid quantity");
                        txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpQTY.ShowAlways = true;
                        tpQTY.Show("Please enter valid quantity", txtQuantity, 5000);
                        blnErrorFlag = true;
                    }
                }
                else
                {
                    epReturnDc.SetError(txtQuantity, "Please enter quantity");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQTY.ShowAlways = true;
                    tpQTY.Show("Please enter quantity", txtQuantity, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    udfnAdd();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (grdReturnDC.Rows.Count > 0)
                {
                    cmbReason.Enabled = false;
                    cmbConcern.Enabled = false;
                }
                else
                {
                    cmbReason.Enabled = true;
                    cmbConcern.Enabled = true;
                }
            }
        }
        public void udfnAdd()
        {
            try
            {
                if (grdReturnDC.Rows.Count < 1)
                {
                    dtStock.Rows.Clear();
                }
                decimal TaxAmt = 0,GSTAmt = 0,NetAmt = 0;
                if (txtQuantity.Text.Trim() != "")
                {
                    TaxAmt = varApprox * Convert.ToDecimal(txtQuantity.Text);
                }
                if(TaxAmt != 0)
                {
                    GSTAmt = TaxAmt * varGST/100;
                }
                if(TaxAmt != 0)
                {
                    NetAmt = TaxAmt + GSTAmt;
                }
                string Tax = "0", GST = "0", Net = "0";
                if(txtQuantity.Text!="")
                {
                    decimal value1 = 0, value2 = 0, value3 = 0;
                    value1 = Convert.ToDecimal(TaxAmt);
                    Tax = Convert.ToString(value1.ToString("0." + new string('0', 2)));
                    value2 = Convert.ToDecimal(GSTAmt);
                    GST = Convert.ToString(value2.ToString("0." + new string('0', 2)));
                    value3 = Convert.ToDecimal(NetAmt);
                    Net = Convert.ToString(value3.ToString("0." + new string('0', 2)));
                    if (varGST == 0)
                    {
                        GST = 0 + GST;
                    }
                }
                grdReturnDC.Columns["clmProduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                grdReturnDC.Rows.Add(grdReturnDC.Rows.Count + 1, varPICode,varProductName,txtLocation.Text,txtRack.Text,txtMRP.Text,txtExpiryDate.Text,txtBatchNo.Text,varApprox,txtQuantity.Text,0,lblUnit.Text,Tax, varGST, GST,Net,lblProduct.Text,0,0,varSLID,varRKID);
                dtStock.Rows.Add((lblProduct.Text).Trim(), string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtMRP.Text.Trim()))), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), 0, (txtQuantity.Text).Trim(), 0,varSLID, varRKID,0,0);

                dtPurchaseReturnDC.Rows.Add(Convert.ToInt32(lblProduct.Text), Convert.ToDecimal(txtMRP.Text), Convert.ToString(txtExpiryDate.Text), Convert.ToString(txtBatchNo.Text),
                Convert.ToDecimal(varApprox), Convert.ToDecimal(txtQuantity.Text),0,Convert.ToDecimal(Tax), Convert.ToDecimal(varGST), Convert.ToDecimal(GST),
                Convert.ToDecimal(Net), 0, varSLID, varRKID,0,0);
                udfnTotal();
                grdReturnDC.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdReturnDC.Columns["clmApprox"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdReturnDC.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdReturnDC.Columns["clmFreeQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdReturnDC.Columns["clmTax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdReturnDC.Columns["clmGSTAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdReturnDC.Columns["clmNettAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdReturnDC.Columns["clmGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdReturnDC.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdReturnDC.Columns["clmProduct"].Width = 300;
                grdReturnDC.Columns["clmSno"].Width = 50;
                grdReturnDC.Columns["clmMRP"].Width = 80;
                grdReturnDC.Columns["clmQuantity"].Width = 70;
                grdReturnDC.Columns["clmUnit"].Width = 70;
                grdReturnDC.Columns["clmGST"].Width = 70;
                grdReturnDC.Columns["clmGSTAmount"].Width = 70;
                grdReturnDC.Columns["clmApprox"].Width = 120;
                grdReturnDC.Columns["clmPRID"].Visible = false;
                grdReturnDC.Columns["clmUTID"].Visible = false;
                grdReturnDC.Columns["clmDMID"].Visible = false;
                grdReturnDC.Columns["clmSLID"].Visible = false;
                grdReturnDC.Columns["clmRKID"].Visible = false;
                grdReturnDC.Columns["clmLocation"].Visible = true;
                grdReturnDC.Columns["clmRack"].Visible = true;
                grdReturnDC.Columns["clmRemove"].Visible = true;
                grdReturnDC.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                udfnProClear();
                if (txtAmount.Visible == true)
                {
                    txtAmount.Text = txtApproxTotal.Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTotal()
        {
            try
            {
                if (grdReturnDC.Rows.Count > 0)
                {
                    decimal TaxAmount = Convert.ToDecimal(dtPurchaseReturnDC.Compute("SUM(PURREDCPR_TaxableAmnt)", string.Empty));
                    txtSubTotal.Text = Convert.ToString(TaxAmount);
                    decimal GSTAmount = Convert.ToDecimal(dtPurchaseReturnDC.Compute("SUM(PURREDCPR_GSTAmnt)", string.Empty));
                    txtTotalTax.Text = Convert.ToString(GSTAmount);
                    txtApproxTotal.Text = Convert.ToString(TaxAmount + GSTAmount);
                }
                else
                {
                    txtSubTotal.Text = "";
                    txtTotalTax.Text = "";
                    txtApproxTotal.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProClear()
        {
            try
            {
                txtProductNamePICode.Text = "";
                txtLocation.Text = "";
                txtRack.Text = "";
                txtMRP.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStockQty.Text = "";
                txtQuantity.Text = "";
                lblUnit.Text = "";
                txtProductNamePICode.Focus();
                grdReturnDC.ClearSelection();
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
                txtQuantity.Focus();
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
                                    txtQuantity.Focus();
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
                        txtQuantity.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdReturnDC_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdReturnDC.CurrentCell.OwningColumn.Name == "clmApprox")
                {
                    if (grdReturnDC.CurrentRow.Cells["clmApprox"].Value.ToString().Trim() == "")
                    {
                        grdReturnDC.Rows[e.RowIndex].Cells["clmApprox"].Value = "0.00";
                    }

                    decimal varApproxRate = Convert.ToDecimal(grdReturnDC.CurrentRow.Cells["clmApprox"].Value);
                    decimal varQuantity = Convert.ToDecimal(grdReturnDC.CurrentRow.Cells["clmQuantity"].Value);
                    decimal varGSTValue = Convert.ToDecimal(grdReturnDC.CurrentRow.Cells["clmGST"].Value);

                    decimal varTaxAmt = 0, varGSTAmt = 0, varNetAmt = 0;

                    if (Convert.ToString(varApproxRate).Trim() != "")
                    {
                        varTaxAmt = varApproxRate * varQuantity;
                        varGSTAmt = varTaxAmt * varGSTValue / 100;
                        varNetAmt = varTaxAmt + varGSTAmt;
                        grdReturnDC.CurrentRow.Cells["clmApprox"].Style.BackColor = Color.PaleGreen;
                    }
                    grdReturnDC.Rows[e.RowIndex].Cells["clmApprox"].Value = Convert.ToString(varApproxRate.ToString("0." + new string('0', 2)));
                    grdReturnDC.Rows[e.RowIndex].Cells["clmTax"].Value = Convert.ToString(varTaxAmt.ToString("0." + new string('0', 2)));
                    grdReturnDC.Rows[e.RowIndex].Cells["clmGSTAmount"].Value = Convert.ToString(varGSTAmt.ToString("0." + new string('0', 2)));
                    grdReturnDC.Rows[e.RowIndex].Cells["clmNettAmount"].Value = Convert.ToString(varNetAmt.ToString("0." + new string('0', 2)));

                    object varEditRate = grdReturnDC.Rows[e.RowIndex].Cells["clmApprox"].Value;
                    object varEditTax = grdReturnDC.Rows[e.RowIndex].Cells["clmTax"].Value;
                    object varEditGSTAmount = grdReturnDC.Rows[e.RowIndex].Cells["clmGSTAmount"].Value;
                    object varEditNettAmount = grdReturnDC.Rows[e.RowIndex].Cells["clmNettAmount"].Value;


                    dtPurchaseReturnDC.Rows[e.RowIndex]["PURREDCPR_AppRate"] = varEditRate;
                    dtPurchaseReturnDC.Rows[e.RowIndex]["PURREDCPR_TaxableAmnt"] = varEditTax;
                    dtPurchaseReturnDC.Rows[e.RowIndex]["PURREDCPR_GSTAmnt"] = varEditGSTAmount;
                    dtPurchaseReturnDC.Rows[e.RowIndex]["PURREDCPR_NettAmnt"] = varEditNettAmount;

                    udfnTotal();
                    if (txtAmount.Visible == true)
                    {
                        txtAmount.Text = txtApproxTotal.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdReturnDC_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdReturnDC.CurrentCell.OwningColumn.Name == "clmApprox")
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
                if (grdReturnDC.CurrentCell.OwningColumn.Name == "clmApprox")
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

        private void GrdReturnDC_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdReturnDC.IsCurrentCellDirty)
                {
                    grdReturnDC.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdReturnDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0;
                string varMRP = "", varStockMRP = "", varExpiryDate = "", varBatchNo = "", varSLID = "", varRKID = "";
                if (e.RowIndex != -1)
                {
                    switch (grdReturnDC.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdReturnDC.CurrentRow.Cells["clmPRID"].Value);
                                varStockMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdReturnDC.CurrentRow.Cells["clmMRP"].Value)));
                                varMRP = Convert.ToString(grdReturnDC.CurrentRow.Cells["clmMRP"].Value);
                                varExpiryDate = Convert.ToString(grdReturnDC.CurrentRow.Cells["clmExpiryDate"].Value);
                                varBatchNo = Convert.ToString(grdReturnDC.CurrentRow.Cells["clmBatchno"].Value);
                                varSLID = Convert.ToString(grdReturnDC.CurrentRow.Cells["clmSLID"].Value);
                                varRKID = Convert.ToString(grdReturnDC.CurrentRow.Cells["clmRKID"].Value);
                                grdReturnDC.Rows.RemoveAt(this.grdReturnDC.CurrentRow.Index);
                                for (int i = 0; i < grdReturnDC.RowCount; i++)
                                {
                                }
                                varModifiedFlag = 1;
                                for (int i = 0; i < dtStock.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID) && Convert.ToString(dtStock.Rows[i]["STK_MRP"]) == varStockMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToString(dtStock.Rows[i]["STK_Dest_SLID"]) == varSLID && Convert.ToString(dtStock.Rows[i]["STK_Dest_RKID"]) == varRKID)
                                    {
                                        dtStock.Rows[i].Delete();
                                        dtStock.AcceptChanges();
                                    }
                                }
                                for (int i = 0; i < dtPurchaseReturnDC.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtPurchaseReturnDC.Rows[i]["PURREDCPR_PRID"]) == Convert.ToInt32(varProductID) && Convert.ToString(dtPurchaseReturnDC.Rows[i]["PURREDCPR_MRP"]) == varMRP && Convert.ToString(dtPurchaseReturnDC.Rows[i]["PURREDCPR_ExpDate"]) == varExpiryDate && Convert.ToString(dtPurchaseReturnDC.Rows[i]["PURREDCPR_BatchNo"]) == varBatchNo && Convert.ToString(dtPurchaseReturnDC.Rows[i]["PURREDCPR_SLID"]) == varSLID && Convert.ToString(dtPurchaseReturnDC.Rows[i]["PURREDCPR_RKID"]) == varRKID)
                                    {
                                        dtPurchaseReturnDC.Rows[i].Delete();
                                        dtPurchaseReturnDC.AcceptChanges();
                                    }
                                    //grdReturnDC.Rows[i].Cells["clmSno"].Value = i + 1;
                                }
                                udfnTotal();
                                if (txtAmount.Visible == true)
                                {
                                    txtAmount.Text = txtApproxTotal.Text;
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
                if (grdReturnDC.Rows.Count > 0)
                {
                    cmbReason.Enabled = false;
                    cmbConcern.Enabled = false;
                }
                else
                {
                    cmbReason.Enabled = true;
                    cmbConcern.Enabled = true;
                }
            }
        }
        private void ChkVerified_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(chkVerified.Checked==true)
                {

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
                if(chkCompleted.Checked==true && chkVerified.Checked==true)
                {
                    chkVerified.Enabled = false;
                }
                else if(chkCompleted.Checked== true && chkVerified.Checked == false)
                {
                    chkVerified.Enabled = true;
                }
                else
                {
                    chkVerified.Enabled = false;
                    chkVerified.Checked = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdReturnDC_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdReturnDC.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRepDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdRepDetails.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.Transparent;
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
                //if (varCloseFlag == 0)
                //{
                //    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (dialogResult == DialogResult.Yes)
                //    {
                //        e.Cancel = false;
                //    }
                //    else
                //    {
                //        e.Cancel = true;
                //    }
                //}

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
