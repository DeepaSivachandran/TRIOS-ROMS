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
        private ToolTip tpAmount = new ToolTip();
        private ToolTip tpDebitAmount = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpQTY = new ToolTip();
        public int varUpDownKey = 0;
        public int vareditflag = 0;
        public int varReturnDCID = 0, varCloseFlag = 0;
        public int pbScheduleid = 0, pbSupplierId = 0, varStatusId = 0, varModifiedFlag = 0, varDebitDCID=0, varEditFlag=0,varClose = 0, varDateChange = 0;
        public string varSuppliervalue = "";
        DataTable dtDebitNote = new DataTable();
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
        public int varRKID = 0, varDebitID = 0;
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
                            MainForm.objPAY_DebitNoteList.udfnList();
                        }
                    }
                    else
                    {
                        this.Close();
                        MainForm.objPAY_DebitNoteList.udfnList();
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
                this.grdReturnDC.Size = new System.Drawing.Size(1289, 317);
                grdReturnDC.Location = new Point(9, 23);
                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    ClearSupplier();
                    udfnUddtTable();
                    cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                    dpReturnDCDate.MinDate = MainForm.pbFYStartDate;
                    dpReturnDCDate.MaxDate = MainForm.pbCurrentDate;
                    this.ActiveControl = txtSupplier;
                    txtSupplier.Focus();
                    EditLoad();
                    if(varStatusId==112)
                    {
                        chkClosed.Checked = true;
                        chkClosed.Enabled = false;
                        txtAmount.Enabled = false;
                        txtAmount.ReadOnly = true;
                        btnSave.Enabled = false;
                        txtRemarks.ReadOnly = true;
                        txtRemarks.Enabled = false;
                    }
                    udfnDisable();
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
        public void udfnDisable()
        {
            try
            {
                cmbConcern.Enabled = false;
                txtSupplier.Enabled = false;
                txtSupplier.ReadOnly = true;
                dpReturnDCDate.Enabled = false;
                txtReturnDcNo.Enabled = false;
                txtReturnDcNo.ReadOnly = true;
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
        public void EditLoad()
        {
            try
            {
                if (varDebitID != 0)
                {
                    int varviewtype = 1;
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_DebitNote objTRN_DebitNote = new TRN_DebitNote();
                    objTRN_DebitNote.ViewType = varviewtype;
                    objTRN_DebitNote.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_DebitNote.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_DebitNote.paraDebitID = varDebitID;
                    objTRN_DebitNote.paraSupplierID = pbSupplierId;
                    objTRN_DebitNote.paraScheduleID = pbScheduleid;
                    objDs = objdserv.udfnDebitNoteList(objTRN_DebitNote);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                grdReturnDC.Rows.Clear();
                                cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["DN_COMID"].ToString();
                                dpReturnDCDate.Text = objDs.Tables[0].Rows[0]["DN_TransactionDate"].ToString();
                                txtReturnDcNo.Text = objDs.Tables[0].Rows[0]["DN_No"].ToString();
                                txtSupplier.Text = objDs.Tables[0].Rows[0]["Supplier"].ToString();
                                lblSupplierCode.Text = objDs.Tables[0].Rows[0]["SPID"].ToString();
                                lblschedule.Text = objDs.Tables[0].Rows[0]["SPSCID"].ToString();
                                txtRemarks.Text = objDs.Tables[0].Rows[0]["DN_Remarks"].ToString();
                                cmbReason.SelectedValue = objDs.Tables[0].Rows[0]["DN_ReasonId"].ToString();
                                txtSubTotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SubTotal"]);
                                txtTotalTax.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Total Tax"]);
                                txtApproxTotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Approximate Total"]);
                                varStatusId = Convert.ToInt32(objDs.Tables[0].Rows[0]["Status ID"]);
                                lblStatus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Status"]);
                                txtAmount.Text = objDs.Tables[0].Rows[0]["DN_Amount"].ToString();
                                //btnSave.Text = "Update";
                                udfnsupplierLoad();
                            }
                            if (objDs.Tables.Count != 0)
                            {
                                lblNoRecordsFound.Visible = false;
                                if (objDs.Tables[1].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                                    {
                                        grdReturnDC.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[1].Rows[i]["P.I Code"]), Convert.ToString(objDs.Tables[1].Rows[i]["Product Name"]),Convert.ToString(objDs.Tables[1].Rows[i]["Location"]), Convert.ToString(objDs.Tables[1].Rows[i]["Rack"]), Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["Batch No."]), Convert.ToString(objDs.Tables[1].Rows[i]["Approximate Rate"]), Convert.ToString(objDs.Tables[1].Rows[i]["Qty"]), Convert.ToString(objDs.Tables[1].Rows[i]["Unit"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["Taxable Amt"]), Convert.ToString(objDs.Tables[1].Rows[i]["Gst%"]), Convert.ToString(objDs.Tables[1].Rows[i]["GST Amt"]), Convert.ToString(objDs.Tables[1].Rows[i]["Net Amt"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]));

                                        dtDebitNote.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), string.Format("{0:G29}", decimal.Parse(Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]))), Convert.ToString(objDs.Tables[1].Rows[i]["Expiry Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["Batch No."]),
                                        Convert.ToDecimal(objDs.Tables[1].Rows[i]["Approximate Rate"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["Qty"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["UTID"]),
                                        Convert.ToDecimal(objDs.Tables[1].Rows[i]["Taxable Amt"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GST%"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GST Amt"]),
                                        Convert.ToDecimal(objDs.Tables[1].Rows[i]["Net Amt"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["RKID"]),0, Convert.ToInt32(objDs.Tables[1].Rows[i]["PURPRID"])); 
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
                                    grdReturnDC.Columns["clmSLID"].Visible = false;
                                    grdReturnDC.Columns["clmRKID"].Visible = false;
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
                            if (objDs.Tables[2].Rows.Count > 0)
                            {
                                if (objDs.Tables[2].Rows[0]["InvoiceNo"].ToString() != "")
                                { lblInvoiceNo2.Text = "Invoice No. - " + objDs.Tables[2].Rows[0]["InvoiceNo"].ToString(); }
                                if (objDs.Tables[2].Rows[0]["InvoiceDate"].ToString() != "")
                                { lblInvoiceDate2.Text = "Invoice Date - " + objDs.Tables[2].Rows[0]["InvoiceDate"].ToString(); }
                                if (objDs.Tables[2].Rows[0]["VoucherNo"].ToString() != "")
                                { lblVoucherNo.Text = "Voucher No. - " + objDs.Tables[2].Rows[0]["VoucherNo"].ToString(); }
                                if (objDs.Tables[2].Rows[0]["VoucherDate"].ToString() != "")
                                { lblVoucherDate.Text = "Voucher Date - " + objDs.Tables[2].Rows[0]["VoucherDate"].ToString(); }
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
                    if (chkClosed.Checked == true)
                    {
                        varStatusId = 112;
                    }
                    else
                    {
                        varStatusId = 111;
                    }
                    if(varStatusId==112)
                    {
                        if(txtAmount.Text=="0")
                        {
                            epReturnDc.SetError(txtAmount, "Debit amount is empty.");
                            tpDebitAmount.ShowAlways = true;
                            tpDebitAmount.Show("Debit amount is empty.", txtAmount, 5000);
                            varErrorFlag = false;
                        }
                    }
                    if (varErrorFlag == true)
                    {
                        udfnTooltipHide();
                        string varDebitAmount = "";
                        if (txtAmount.Text == "") { varDebitAmount = "0"; }
                        else
                        {
                            varDebitAmount = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                        }

                        if (grdReturnDC.Rows.Count > 0)
                        {
                            if (lblSupplierCode.Text != "0" && lblschedule.Text != "0")
                            {
                                string result = "", varorginator = ""; int varviewtype = 1;
                                varorginator = "Debit note update";
                                decimal subtotal = 0, TotalTax = 0;
                                if(txtSubTotal.Text.Trim()!="")
                                {
                                    subtotal = Convert.ToDecimal(txtSubTotal.Text);
                                }
                                if (txtTotalTax.Text.Trim() != "")
                                {
                                    TotalTax = Convert.ToDecimal(txtTotalTax.Text);
                                }
                                TRN_DebitNote objTRNG_DebitNote = new TRN_DebitNote();
                                objTRNG_DebitNote.ViewType = varviewtype;
                                objTRNG_DebitNote.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                                objTRNG_DebitNote.paraIPAddress = MainForm.pbIpAddress;
                                objTRNG_DebitNote.paraOriginator = varorginator;
                                objTRNG_DebitNote.paraDebitID = varDebitID;
                                objTRNG_DebitNote.paraStatusID = varStatusId;
                                objTRNG_DebitNote.paraAmount = Convert.ToDecimal(txtAmount.Text);
                                objTRNG_DebitNote.paraDebit_Remarks = Convert.ToString(txtRemarks.Text);
                                SPDataService objspdservice = new SPDataService();
                                result = objspdservice.udfnSetDebitNote(objTRNG_DebitNote);
                                objspdservice.CloseConnection();
                                string[] varvalue = result.Split('~');
                                varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.ActiveControl = txtSupplier;
                                    MainForm.objPAY_DebitNoteList.udfnList();
                                    udfnclose();
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
                    txtRemarks.Focus();
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
        private void ChkCompleted_CheckedChanged(object sender, EventArgs e)
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
