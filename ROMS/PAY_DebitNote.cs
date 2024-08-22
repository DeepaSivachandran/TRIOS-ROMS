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
    public partial class PAY_DebitNote : Form
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
        public int pbScheduleid = 0, pbSupplierId = 0, varStatusId = 0, varModifiedFlag = 0, varDebitDCID=0, varEditFlag=0,varClose = 0, varDateChange = 0;
        public string varSuppliervalue = "";
        DataTable dtDebitNote = new DataTable();
        DataTable dtStock = new DataTable();
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


        public PAY_DebitNote()
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
                if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 61 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 62 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 204) //received credit note
                {
                    txtDAmount.Visible = true;
                    txtAmount.Visible = true;
                    txtDCrNo.Visible = true;
                    txtCrNo.Visible = true;
                    dpCreditNoteDate.Visible = true;
                    dpDCreditNoteDate.Visible = true;
                    dpCreditNoteDate.Enabled = true;
                    btnView.Visible = false;
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
                    if (varStatusId != 39)
                    {
                        udfnView();
                    }
                    varModifiedFlag = 1;
                }
                else if (Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 64 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 192 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 206 || Convert.ToInt32(cmbReasonForClosing.SelectedValue) == 207) //Debit Note Created
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
        public void udfnDebitNoteVocherno()
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
                dtDebitNote.TableName = "TRN_DebitNote";
                dtDebitNote.Columns.Add("DNPR_PRID", typeof(int));
                dtDebitNote.Columns.Add("DNPR_MRP", typeof(decimal));
                dtDebitNote.Columns.Add("DNPR_ExpDate", typeof(string));
                dtDebitNote.Columns.Add("DNPR_BatchNo", typeof(string));
                dtDebitNote.Columns.Add("DNPR_AppRate", typeof(decimal));
                dtDebitNote.Columns.Add("DNPR_Qty", typeof(decimal));
                dtDebitNote.Columns.Add("DNPR_UTID", typeof(int));
                dtDebitNote.Columns.Add("DNPR_TaxableAmnt", typeof(decimal));
                dtDebitNote.Columns.Add("DNPR_GSTPer", typeof(decimal));
                dtDebitNote.Columns.Add("DNPR_GSTAmnt", typeof(decimal));
                dtDebitNote.Columns.Add("DNPR_NettAmnt", typeof(decimal));
                dtDebitNote.Columns.Add("DNPR_SLID", typeof(int));
                dtDebitNote.Columns.Add("DNPR_RKID", typeof(int));
                dtDebitNote.Columns.Add("DNPR_FreeQty", typeof(decimal));
                dtDebitNote.Columns.Add("DNPR_PURPRID", typeof(int));
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
                            varReturnDCID = varDebitDCID;
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
                            chkCompleted.Checked = false;
                            chkCompleted.Enabled = true;
                        }
                        else
                        {
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
            { grdReturnDC.ClearSelection(); }
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

                                dtDebitNote.Rows.Add(Convert.ToInt32(objDs.Tables[0].Rows[i]["PRID"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Batch No."]),
                                        Convert.ToDecimal(objDs.Tables[0].Rows[i]["Approximate Rate"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Qty"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["UTID"]),
                                        Convert.ToDecimal(objDs.Tables[0].Rows[i]["Taxable Amt"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["GST%"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["GST Amt"]),
                                        Convert.ToDecimal(objDs.Tables[0].Rows[i]["Net Amt"]), Convert.ToString(objDs.Tables[0].Rows[i]["DMID"]), 0,0,0);
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
                                lblStatus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Status"]);
                                VerifiedBy = Convert.ToInt32(objDs.Tables[0].Rows[0]["PURREDC_VerifiedBy"]);                              
                                udfnClosingDropdown();
                                //btnSave.Text = "Update";
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
                                        Convert.ToString(objDs.Tables[1].Rows[i]["Taxable Amt"]), Convert.ToString(objDs.Tables[1].Rows[i]["GST%"]), Convert.ToString(objDs.Tables[1].Rows[i]["GST Amt"]), Convert.ToString(objDs.Tables[1].Rows[i]["Net Amt"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["DMID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]));

                                        dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), string.Format("{0:G29}", decimal.Parse(Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]))), Convert.ToString(objDs.Tables[1].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["Batch No."]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["Qty"]), 0, Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), 0, 0);

                                        dtDebitNote.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), string.Format("{0:G29}", decimal.Parse(Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]))), Convert.ToString(objDs.Tables[1].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["Batch No."]),
                                        Convert.ToDecimal(objDs.Tables[1].Rows[i]["Approximate Rate"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["Qty"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["UTID"]),
                                        Convert.ToDecimal(objDs.Tables[1].Rows[i]["Taxable Amt"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GST%"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GST Amt"]),
                                        Convert.ToDecimal(objDs.Tables[1].Rows[i]["Net Amt"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["DMID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["FreeQty"]));
                                    }
                                    grdReturnDC.Columns["clmProduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lblNoRecordsFound.Visible = false;
                                    lblNoRecordsFound.SendToBack();
                                    //grdReturnDC.DataSource = objDs.Tables[1];
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
                                    if(Convert.ToInt32(cmbReason.SelectedValue) == 203)
                                    {
                                        if (varStatusId == 68)
                                        {
                                            grdReturnDC.Columns["clmRemove"].Visible = true;
                                        }
                                        else
                                        {
                                            grdReturnDC.Columns["clmRemove"].Visible = false;
                                        }
                                        grdReturnDC.Columns["clmLocation"].Visible = true;
                                        grdReturnDC.Columns["clmRack"].Visible = true;
                                    }
                                    else
                                    {
                                        grdReturnDC.Columns["clmRemove"].Visible = false;
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
                        dtDebitNote.Rows.Clear();
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
                udfnDebitNoteVocherno();
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
                varDateChange = 1;
                udfnVocherno();
                udfnDebitNoteVocherno();
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
                    if (varStatusId == 16)
                    {
                        if (Convert.ToString(cmbReasonForClosing.SelectedValue) == "" || Convert.ToString(cmbReasonForClosing.SelectedValue) == "-1")
                        {
                            epReturnDc.SetError(cmbReasonForClosing, "Please select reason for closing.");
                            cmbReasonForClosing.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpReason.ShowAlways = true;
                            tpReason.Show("Please select reason for closing.", cmbReasonForClosing, 5000);
                            varErrorFlag = false;
                        }
                        if (txtAmount.Text == "")
                        {
                            epReturnDc.SetError(txtAmount, "Please enter amount.");
                            txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpAmount.ShowAlways = true;
                            tpAmount.Show("Please enter amount.", txtAmount, 5000);
                            varErrorFlag = false;
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
                                if(chkVerified.Checked==true)
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
                                objTRN_PurchaseReturnDC.paraTRN_Purchase_ReturnDC = dtDebitNote;
                                
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
                                            if(vareditflag == 1)
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
                        dtDebitNote.Rows.Clear();
                        grdReturnDC.DataSource = null;
                        grdRepDetails.DataSource = null;
                    }
                }
                if (Convert.ToInt32(cmbReason.SelectedValue) == 60) //damage
                {
                    this.grdReturnDC.Size = new System.Drawing.Size(1289, 317);
                    grdReturnDC.Location = new Point(9, 23);
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
  
        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void GrdReturnDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "", varSLID = "", varRKID = "";
                if (e.RowIndex != -1)
                {
                    switch (grdReturnDC.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdReturnDC.SelectedRows[0].Cells["clmPRID"].Value);
                                varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdReturnDC.SelectedRows[0].Cells["clmMRP"].Value)));
                                varExpiryDate = Convert.ToString(grdReturnDC.SelectedRows[0].Cells["clmExpiryDate"].Value);
                                varBatchNo = Convert.ToString(grdReturnDC.SelectedRows[0].Cells["clmBatchno"].Value);
                                varSLID = Convert.ToString(grdReturnDC.SelectedRows[0].Cells["clmSLID"].Value);
                                varRKID = Convert.ToString(grdReturnDC.SelectedRows[0].Cells["clmRKID"].Value);
                                grdReturnDC.Rows.RemoveAt(this.grdReturnDC.SelectedRows[0].Index);
                                for (int i = 0; i < grdReturnDC.RowCount; i++)
                                {
                                }
                                varModifiedFlag = 1;
                                for (int i = 0; i < dtStock.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID) && Convert.ToString(dtStock.Rows[i]["STK_MRP"]) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToString(dtStock.Rows[i]["STK_Dest_SLID"]) == varSLID && Convert.ToString(dtStock.Rows[i]["STK_Dest_RKID"]) == varRKID)
                                    {
                                        dtStock.Rows[i].Delete();
                                        dtStock.AcceptChanges();
                                    }
                                }
                                for (int i = 0; i < dtDebitNote.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtDebitNote.Rows[i]["PURREDCPR_PRID"]) == Convert.ToInt32(varProductID) && Convert.ToString(dtDebitNote.Rows[i]["PURREDCPR_MRP"]) == varMRP && Convert.ToString(dtDebitNote.Rows[i]["PURREDCPR_ExpDate"]) == varExpiryDate && Convert.ToString(dtDebitNote.Rows[i]["PURREDCPR_BatchNo"]) == varBatchNo && Convert.ToString(dtDebitNote.Rows[i]["PURREDCPR_SLID"]) == varSLID && Convert.ToString(dtDebitNote.Rows[i]["PURREDCPR_RKID"]) == varRKID)
                                    {
                                        dtDebitNote.Rows[i].Delete();
                                        dtDebitNote.AcceptChanges();
                                    }
                                    //grdReturnDC.Rows[i].Cells["clmSno"].Value = i + 1;
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
