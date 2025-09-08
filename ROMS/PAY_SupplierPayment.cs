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
    public partial class PAY_SupplierPayment : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataSet objDs = new DataSet();
        DataTable dtPayment = new DataTable();
        DataTable dtChequeTemplateDetails = new DataTable();
        public DataTable dtCheckAdv = new DataTable();
        public DataTable dtAdvance = new DataTable();
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpbank = new ToolTip();
        private ToolTip tpIssue = new ToolTip();
        private ToolTip tpIssueMode = new ToolTip();
        private ToolTip tpChequeNo = new ToolTip();
        public Decimal varNeftAmount = 0, varGrandTotal = 0; 
        public int varSupplierPaymentID = 0, VarPrevSupplierid = 0, id = 0, varEditFlag = 0, varModifiedFlag = 0, VARFLAG = 0, varCellclickFlag = 0, varSource = 0, varCloseFlag = 0, varClose = 0, varSupplierType = 0, clearClick = 0, varApplyFlag = 0, varPaymentStatus = 0, varCreatemodeFlag = 0, varUncheckFlag = 0, varSPBankID = -1, varDefaultBank = 0;
        public string varSupplierPaymentMode = "", varSupplierID = "", varSupplierScheduleID = "", varUserID = "0", varSupplierName = "", varAdvanceID = "", advanceid = "", PurchaseID = "0", varAdvance = "", varPayAmnt = "", varCompanyID = "0";
        public decimal varGrandTot = 0, varTotal = 0, varamt = 0, varReturnAmnt = 0, varDiscAmnt = 0, varAdvanceAmnt = 0,varSubtotal = 0, varTaxableAmnt = 0, varAdditions = 0, varDeductions = 0, varRTGSMinLimit = 0, varCashPaymentLimit = 0,varTobepaid=0,varOutstanding=0; 
        DataTable dtBankDetails = new DataTable();
        DataTable dtChequeText = new DataTable(); 
        public PAY_SupplierPayment()
        {
            InitializeComponent();
        }
        public void udfnclose()
        {
            try
            {
                udfntooltiphide();
                if (varModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objPAY_SupplierPaymentList.udfnList();
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
                        MainForm.objPAY_SupplierPaymentList.udfnList();
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                epSupplier.Clear();
                bool blnErrorFlag = false;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epSupplier.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtsuppliername.Text) == "")
                {
                    epSupplier.SetError(txtsuppliername, "Please enter supplier name");
                    txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier name", txtsuppliername, 5000);
                    blnErrorFlag = true;
                }
                if (txtChequeNo.Visible==true && txtChequeNo.Text.Trim()=="")
                {
                    epSupplier.SetError(txtChequeNo, "Please enter Cheque name");
                    txtChequeNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpChequeNo.ShowAlways = true;
                    tpChequeNo.Show("Please enter Cheque name", txtChequeNo, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) == -1)
                {
                    epSupplier.SetError(cmbIssueMode, "Please select mode of issue");
                    cmbIssueMode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIssueMode.ShowAlways = true;
                    tpIssueMode.Show("Please select of issue", cmbIssueMode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) != -1)
                {
                    if (Convert.ToString(txtIssue.Text).Trim() == "")
                    {
                        epSupplier.SetError(txtIssue, "Please enter mode of issue");
                        txtIssue.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIssue.ShowAlways = true;
                        tpIssue.Show("Please enter mode of issue", txtIssue, 5000);
                        blnErrorFlag = true;
                    }
                }
                SPDataService objDServ = new SPDataService();
                if (Convert.ToInt16(cmbPaymentmode.SelectedValue) != 346)
                { 
                    //Check the cheque is sunday or not
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 27;
                    objMR_Master.paraDate = dpChequeDate.Text;
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();
                    objDs = objspservice.udfnMaster(objMR_Master);
                    if(objDs.Tables.Count!=0)
                    {
                        int flag = 0;
                        flag = Convert.ToInt16(objDs.Tables[0].Rows[0]["DateFlag"]);
                        if (flag == 1)
                        {
                            string varMessage = objDServ.udfnGetMessages(160);
                            objDServ.CloseConnection();
                            DialogResult result1 = DialogResult.Yes;
                            result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.No)
                            {
                                blnErrorFlag = true;
                                return;
                            }
                        }
                    }
                } 
                if ((grdSupplierPayment.Rows.Count == 0 || VARFLAG== 0) && varEditFlag==0)
                {
                    string varMessage = objDServ.udfnGetMessages(137);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if(varAdvanceID!="" && varApplyFlag== 0)
                {
                    string varMessage = objDServ.udfnGetMessages(141);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                int count = grdSupplierPayment.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Count(r =>
                    r.Cells["clmTobePaid"].Value != null &&
                    r.Cells["clmPayAmount"].Value != null &&
                    Convert.ToDecimal(r.Cells["clmTobePaid"].Value) <
                    Convert.ToDecimal(r.Cells["clmPayAmount"].Value)
                ); 
                if(count!=0)
                { 
                    string varMessage = objDServ.udfnGetMessages(162);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                } 
                if (blnErrorFlag==false)
                {
                    txtSearch.Text = "";
                    epSupplier.Clear(); 
                    udfnSave();
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
        public void udfnSave()
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int ViewType = 0, varStatusID = 0, varChequeLimitDays=0;
                PurchaseID = "0";
                bool varCheck = true;
                int varUpdateFlag = 0;
                DialogResult result1 = DialogResult.Yes;
                dtPayment.Clear();
                if(btnSave.Text=="Save")
                {
                    ViewType = 0;
                    varoriginator = "Supplier payment creation";
                    varStatusID = 77;
                }
                else if (btnSave.Text == "Update")
                {
                    ViewType = 1;
                    varoriginator = "Supplier payment updation";
                    varUpdateFlag = 1;
                } 
                for (int i=0;i<grdSupplierPayment.Rows.Count;i++)
                {
                    if(Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmcheck"].Value)=="")
                    {
                        varCheck = false;
                    }
                    else if(Convert.ToBoolean(grdSupplierPayment.Rows[i].Cells["clmcheck"].Value)==true)
                    {
                        varCheck = true;
                    }
                    else
                    {
                        varCheck = false;
                    } 
                    if (Convert.ToBoolean(varCheck) ==true)
                    {
                        dtPayment.Rows.Add(Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmID"].Value), Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmPayAmount"].Value), varStatusID,0, Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmAdvanceAmnt"].Value),0, Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmDiscAmount"].Value), Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmDISCID"].Value), Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmInvoiceNo"].Value), Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmAdditions"].Value), Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmDeductions"].Value), 
                             Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmTobePaid"].Value),
                             Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmBalance"].Value),
                             Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmTaxableAmnt"].Value),
                             Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmTaxAmount"].Value),
                             Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmReturnAmt"].Value),
                             Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmInvoiceAmnt"].Value),
                             Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmInvoiceDate"].Value) ,
                             Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmOutstandingAmt"].Value) 
                            );
                    }
                    if (Convert.ToBoolean(varCheck) == true)
                    {
                        if (PurchaseID == "0")
                        {
                            PurchaseID = Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmID"].Value);
                        }
                        else
                        {
                            PurchaseID = PurchaseID + ',' + Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmID"].Value);
                        }
                    }
                }
                if(Convert.ToString(txtChequeLimitDays.Text.Trim())!="")
                {
                    varChequeLimitDays = Convert.ToInt16(txtChequeLimitDays.Text.Trim());
                }
                if (lblGrandTotal.Text.Trim() != "")
                {
                    decimal varMRP = Math.Round(Convert.ToDecimal(lblGrandTotal.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                    string varAmt = string.Format("{0:0}", varMRP);
                    int varAmount = Convert.ToInt32(varAmt);
                    lblAmount.Text = Currency.NumbersToWords(varAmount); 
                }
                varUserID = Convert.ToString(MainForm.pbUserID);
            l: MainForm.objCP_Verify = new CP_Verify();
                MainForm.objCP_Verify.ShowDialog();
                varUserID = MainForm.objCP_Verify.varUserId;
                if (MainForm.objCP_Verify.flag == 1)
                {
                    dtAdvance.DefaultView.Sort = "ADID ASC";
                    dtAdvance = dtAdvance.DefaultView.ToTable();
                    Model.TRN_Supplier_Payment objTRN_Supplier_Payment = new Model.TRN_Supplier_Payment();
                    objTRN_Supplier_Payment.ViewType = ViewType;
                    objTRN_Supplier_Payment.paraPYID = varSupplierPaymentID;
                    objTRN_Supplier_Payment.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_Supplier_Payment.paraPaymentDate = dpDate.Text;
                    objTRN_Supplier_Payment.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objTRN_Supplier_Payment.paraScheduleId = Convert.ToInt32(lblschedule.Text);
                    objTRN_Supplier_Payment.paraTotalAmnt = Convert.ToDecimal(lblGrandTotal.Text);
                    objTRN_Supplier_Payment.paraChequeNo = txtChequeNo.Text;
                    //objTRN_Supplier_Payment.paraPayType = Convert.ToInt32(cmbPaymentType.SelectedValue);
                    objTRN_Supplier_Payment.paraChequeDate = dpChequeDate.Text;
                    objTRN_Supplier_Payment.paraAdvanceAmnt = Convert.ToDecimal(lblAdvance.Text);
                    objTRN_Supplier_Payment.paraSubTotal = Convert.ToDecimal(lblSubtotal.Text);
                    objTRN_Supplier_Payment.paraSTSID = varStatusID;
                    objTRN_Supplier_Payment.paraUserID = Convert.ToInt32(varUserID);
                    objTRN_Supplier_Payment.paraOriginator = varoriginator;
                    objTRN_Supplier_Payment.paraPayment = dtPayment;
                    objTRN_Supplier_Payment.paradtparaAdvance = dtAdvance;
                    objTRN_Supplier_Payment.paraAdvanceID = varAdvanceID;
                    objTRN_Supplier_Payment.paraPurchaseID = PurchaseID;
                    objTRN_Supplier_Payment.paraRemarks = Convert.ToString(txtRemark.Text.Trim());
                    objTRN_Supplier_Payment.paraPaymode = Convert.ToInt32(cmbPaymentmode.SelectedValue); 
                    objTRN_Supplier_Payment.paraModeOfIssue = Convert.ToInt32(cmbIssueMode.SelectedValue); 
                    objTRN_Supplier_Payment.paraModeOfIssue_Details = Convert.ToString(txtIssue.Text.Trim()); 
                    objTRN_Supplier_Payment.paraChequeLimitDays = varChequeLimitDays; 
                    if (Convert.ToInt32(cmbPaymentmode.SelectedValue) != 346)
                    { 
                        objTRN_Supplier_Payment.paraBankID = Convert.ToInt32(varSPBankID);
                        objTRN_Supplier_Payment.paraComBank = Convert.ToInt32(cmbBank.SelectedValue);
                    }
                    varResult = objspservice.udfnSetPayment(objTRN_Supplier_Payment);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Convert.ToUInt32(cmbPaymentmode.SelectedValue) !=346)
                        { 
                            string varRPTName = "",varChequeText= "";  int varBankID =0; int varChectTextID = 0;
                            varChectTextID = Convert.ToInt32(cmbPaymentmode.SelectedValue);

                            var BankID= dtBankDetails.AsEnumerable() 
                            .Where(b => b.Field<int>("CMBNK_ID") == Convert.ToInt32(cmbBank.SelectedValue))
                                .Select(b => b.Field<int>("BNKID"))
                            .ToList();

                            varBankID = BankID[0];

                            var RPTName = dtChequeTemplateDetails.AsEnumerable()
                            .Where(b => b.Field<int>("BankID") == varBankID)
                                .Select(b => b.Field<string>("RPTName"))
                                .Where(rpt => !string.IsNullOrEmpty(rpt))
                                .ToList();
                              
                            //if(varChectTextID == 347)
                            //{
                            //    if (varRTGSMinLimit > Convert.ToDecimal(lblGrandTotal.Text))
                            //    {   varChectTextID = 348;  }
                            //    else { varChectTextID = 349; }
                            //}

                            var chequeText = dtChequeText.AsEnumerable()
                            .Where(b => b.Field<int>("MST_Eq_STSID") == varChectTextID)
                            .Select(b => b.Field<string>("MST_DisplayText"))
                            .Where(rpt => !string.IsNullOrEmpty(rpt))
                            .ToList();

                            if (RPTName.Count != 0)
                            { varRPTName = RPTName[0]; }
                            if (chequeText.Count != 0)
                            {    varChequeText = chequeText[0];  }
                            if (RPTName.Count != 0  )
                            { 
                                string[] supplierName = txtsuppliername.Text.Split('-');
                                SPDataService objDServs = new SPDataService();
                                string varMessage = objDServs.udfnGetMessages(87);
                                objDServs.CloseConnection();
                                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result1 == DialogResult.Yes)
                                {
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\" + varRPTName);
                                    objBillreport.SetParameterValue("paraSupplierName", (varChequeText + supplierName[0]));
                                    objBillreport.SetParameterValue("paraAmountInWords", lblAmount.Text);
                                    objBillreport.SetParameterValue("paraAmount", lblGrandTotal.Text);
                                    objBillreport.SetParameterValue("paraChequeDate", dpChequeDate.Text);
                                    objValidation.CrySqlConnection(objBillreport);
                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                            }
                        }
                        this.ActiveControl = txtsuppliername;
                        MainForm.objPAY_SupplierPaymentList.udfnList();
                        varModifiedFlag = 0;
                        udfnClear();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = true;
                        btnSave.Focus();
                    }
                }
                //else
                //{
                //    if (varvalue[0] == "5")
                //    {
                //        goto l;
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = true;
                btnSave.Focus();
            } 
        }
        public void udfnClear()
        {
            try
            {
                cmbConcern.SelectedValue = -1;
                txtsuppliername.Text = "";
                txtChequeNo.Text = "";
                cmbPaymentmode.SelectedValue = -1;  
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                if (txtsuppliername.Text.Length > 0)
                {
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 43;
                    objMR_Supplier.paraSupplierName = txtsuppliername.Text;
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
        private void CmbPaymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnPaymentMode();
                udfnIssueDropDown();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        public void udfnChequeTemplateDetails()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                Model.TRN_Supplier_Payment objTRN_Supplier_Payment = new Model.TRN_Supplier_Payment();
                objTRN_Supplier_Payment.ViewType = 3; 
                objDs = objspdservice.udfnGetSupplierPayment(objTRN_Supplier_Payment);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        dtChequeTemplateDetails = objDs.Tables[0];
                    }
                    if(objDs.Tables.Count>1)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            dtChequeText = objDs.Tables[1];
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
        /*Update by deepa on 27-08-2025*/
        public void udfnPaymentDropDown()
        {
            try
            {
                /* 346 - Cash
                   347 - Cheque
                   348 - NEFT
                   349 - RTGS
                   350 - Trasfer
                 */
                /*
                 Supplier Payment Mode
                    88 - Cash
                    89 - Cheque
                    90 - Online

                    Cash Payment should not be less than 10,000(from settings)
                    If pay amount is more than 2,00,000, then payment should be made through RTGS/Cheque/Transfer
                    If pay amount is less than 2,00,000, then payment should be made through NEFT/Cheque/Transfer
                 */
                string varNotCondition = "";
                int varCashEnabled = 0, varChequeEnabled = 0, varNEFTEnabled = 0, varRTGSEnabled = 0, varTransferEnabled = 1;
                /* Check cash mode*/
                if (varSupplierPaymentMode.Contains("88"))
                {
                    /* If supplier payment mode is cash and pay amount > 10000 */
                    if (Convert.ToDecimal(lblGrandTotal.Text) > varCashPaymentLimit)
                    {
                        varCashEnabled = 0;
                    }
                    else { varCashEnabled = 1; }
                }
                /* Check Cheque mode*/
                if (varSupplierPaymentMode.Contains("89")) {
                    varChequeEnabled = 1;                 
                }
                /* Check Online mode*/
                if (varSupplierPaymentMode.Contains("90"))
                {
                    /* If supplier payment mode is online and pay amount < 2,00,000 */
                    if (Convert.ToDecimal(lblGrandTotal.Text) < varRTGSMinLimit)
                    {
                        varRTGSEnabled = 0;
                        varNEFTEnabled = 1;
                    }
                    else { 
                        varRTGSEnabled = 1;
                        varNEFTEnabled = 0;
                    }
                }
                if (varCashEnabled == 0) { if (varNotCondition == "") { varNotCondition = "346"; } else { varNotCondition = varNotCondition + ", 346"; } }
                if (varChequeEnabled == 0) { if (varNotCondition == "") { varNotCondition = "347"; } else { varNotCondition = varNotCondition + ", 347"; } }
                if (varNEFTEnabled == 0) { if (varNotCondition == "") { varNotCondition = "348"; } else { varNotCondition = varNotCondition + ", 348"; } }
                if (varRTGSEnabled == 0) { if (varNotCondition == "") { varNotCondition = "349"; } else { varNotCondition = varNotCondition + ", 349"; } }
                if (varTransferEnabled == 0) { if (varNotCondition == "") { varNotCondition = "350"; } else { varNotCondition = varNotCondition + ", 350"; } }
                if (varNotCondition == "") { varNotCondition = " 1=1 "; }
                else { varNotCondition = "MSTID NOT IN (" + varNotCondition +")"; }
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=104 AND "+ varNotCondition , "MST_DisplayText,MSTID", cmbPaymentmode, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnIssueDropDown()
        {
            try
            { 
                string varNotCondition = "0";int varPaymentMode = 0; txtIssue.Text = "";
                varPaymentMode = Convert.ToInt32(cmbPaymentmode.SelectedValue);

                if(varPaymentMode==346) //346 - Cash //In Person
                { varNotCondition = "0,222,223"; }
                else if(varPaymentMode==347) //347 - Cheque //In Person, Courier
                { varNotCondition = "0,223"; } 
                else if(varPaymentMode==348 || varPaymentMode == 349 || varPaymentMode == 350) //--348- NEFT,349 -RTGS,350 - Transfer //Presented in bank,Courier
                { varNotCondition = "0,221"; }
                  
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID IN (0,71) AND  MSTID NOT IN(" + varNotCondition + ")", "MST_DisplayText,MSTID", cmbIssueMode, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPaymentMode()
        {
            try
            {
                int paymentMode = Convert.ToInt32(cmbPaymentmode.SelectedValue);
                txtBank.Visible = true;
                cmbBank.Visible = true;
                txtChequeDate.Visible = true;
                dpChequeDate.Visible = true;
                txtDChequeNo.Visible = true;
                txtChequeNo.Visible = true; 
                txtChequeDate.Visible = true;
                txtChequeNo.Visible = true;
                dpChequeDate.Visible = true;
                txtDChequeNo.Visible = true; 
                cmbBank.Visible = true;
                txtBank.Visible = true; 
                cmbBank.Enabled = true;   
                txtChequeNo.Text = "";
                txtDChequeLimitDays.Visible = true;
                txtChequeLimitDays.Visible = true;
                txtChequeLimitDays.Text = "";
                txtChequeLimitDays.Enabled = true;
                txtChequeLimitDays.ReadOnly = false;
                if (paymentMode==346)
                {
                    txtBank.Visible = false;
                    cmbBank.Visible = false;
                    txtChequeDate.Visible = false;
                    dpChequeDate.Visible = false;
                    txtDChequeNo.Visible = false;
                    txtChequeNo.Visible = false;
                    txtChequeDate.Visible = false;
                    txtChequeNo.Visible = false;
                    dpChequeDate.Visible = false;
                    txtDChequeNo.Visible = false;
                    cmbBank.Visible = false;
                    txtBank.Visible = false;
                    txtDChequeLimitDays.Visible = false;
                    txtChequeLimitDays.Visible = false; 
                }
                else if(paymentMode==350)
                {
                    var Count = dtBankDetails.AsEnumerable()
                       .Where(b => b.Field<int>("BNKID") == varSPBankID)
                       .GroupBy(b => b.Field<int>("CMBNK_ID")) // dummy group to aggregate
                       .Select(g => g.Count() )
                       .ToList(); 
                    var result = dtBankDetails.AsEnumerable()
                    .Where(b => b.Field<int>("BNKID") == varSPBankID)
                    .GroupBy(b => b.Field<int>("CMBNK_ID")) // dummy group to aggregate
                    .Select(g => g.Count() > 1
                        ? g.First().Field<int>("BNKID")
                        : g.First().Field<int>("CMBNK_ID"))
                    .FirstOrDefault(); 
                    cmbBank.SelectedValue = result;
                    if (Count[0] == 1)
                    {     cmbBank.Enabled = false;  }
                    else { cmbBank.Enabled = true; }
                }
                else { cmbBank.SelectedValue = varDefaultBank; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }  
        private void PAY_SupplierPayment_Load(object sender, EventArgs e)
        {
            try
            {   
                dtPayment.TableName = "TRN_Supplier_Payment";
                dtPayment.Columns.Add("PY_PURID", typeof(int));
                dtPayment.Columns.Add("PY_Amount", typeof(float));
                dtPayment.Columns.Add("PY_STSID", typeof(int));
                dtPayment.Columns.Add("PAYIID", typeof(int));
                dtPayment.Columns.Add("PAY_AdvanceAmnt", typeof(float));
                dtPayment.Columns.Add("PAY_ADID", typeof(int));
                dtPayment.Columns.Add("PAY_discountAmnt", typeof(float));
                dtPayment.Columns.Add("PAY_DISCID", typeof(int));
                dtPayment.Columns.Add("PAY_InvoiceNo", typeof(string)); 
                dtPayment.Columns.Add("PAYI_Addition", typeof(decimal)); 
                dtPayment.Columns.Add("PAYI_Deduction", typeof(decimal));  
                dtPayment.Columns.Add("PAYI_ToBePaid", typeof(decimal)); 
                dtPayment.Columns.Add("PAYI_Balance", typeof(decimal)); 
                dtPayment.Columns.Add("PAYI_TaxableAmnt", typeof(decimal)); 
                dtPayment.Columns.Add("PAYI_TaxAmnt", typeof(decimal)); 
                dtPayment.Columns.Add("PAYI_RetAdjustAmnt", typeof(decimal)); 
                dtPayment.Columns.Add("PAYI_InvoiceAmount", typeof(decimal)); 
                dtPayment.Columns.Add("PAYI_InvoiceDate", typeof(string)); 
                dtPayment.Columns.Add("PAYI_OutstandingAmount", typeof(decimal)); 

                //For update Current balance in advance
                dtCheckAdv = new DataTable(); 
                dtCheckAdv.Columns.Add("Advance Amount", typeof(decimal));
                dtCheckAdv.Columns.Add("ADID", typeof(string));
                dtCheckAdv.Columns.Add("Current balance", typeof(decimal));

                //For update Purchase id
                dtAdvance = new DataTable();
                dtAdvance.Columns.Add("ADID", typeof(int));
                dtAdvance.Columns.Add("PURID", typeof(int));
                dtAdvance.Columns.Add("Current balance", typeof(decimal));
                dtAdvance.Columns.Add("Payment Amount", typeof(decimal));
                dtAdvance.Columns.Add("Payed Amount", typeof(decimal));
                dtAdvance.Columns.Add("Fixed Advance", typeof(decimal));
                dtAdvance.Columns.Add("SNo", typeof(int));
                udfnCmbConcern();
                udfnPaymentDropDown();
                udfnBankDropDown();
                ClearSupplier();
                dpDate.MinDate = MainForm.pbFYStartDate;
                dpDate.MaxDate = MainForm.pbCurrentDate;  
                udfnGeneralSettingsList();
                udfnIssueDropDown();
                udfnEditLoad();  
                if (varEditFlag==0)
                {
                    btnClear.Enabled = false;
                    udfnChequeDate();
                }
                //if (varPaymentStatus!=77)
                //{
                //    btnApply.Enabled = true;
                //}
                udfnChequeTemplateDetails();
                if (varPaymentStatus == 77 || varPaymentStatus == 117)
                {
                    btnSave.Enabled = false;
                    grdSupplierPayment.ReadOnly = true;
                    btnClear.Enabled = false;
                    btnApply.Enabled = false;
                    cmbPaymentmode.Enabled = false;
                    dpChequeDate.Enabled = false;
                    txtChequeNo.Enabled = false;
                    txtChequeNo.ReadOnly = true;
                    cmbBank.Enabled = false;
                    txtRemark.ReadOnly = true;
                    txtRemark.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                this.ActiveControl = txtsuppliername;
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
        public void udfnBankDropDown()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(13, Convert.ToInt16(cmbConcern.SelectedValue), "","", 0);
                objdserv.CloseConnection();
                cmbBank.DataSource = null;
                dtBankDetails = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbBank.ValueMember = "CMBNK_ID";
                            cmbBank.DisplayMember = "Bank";
                            cmbBank.DataSource = objDT.Tables[0];
                            dtBankDetails = objDT.Tables[0];
                            if(Convert.ToString(objDT.Tables[0].Rows[0]["Default"])!="0")
                            {
                                varDefaultBank = Convert.ToInt16(objDT.Tables[0].Rows[0]["Default"]); 
                            }
                            else { varDefaultBank =Convert.ToInt16(objDT.Tables[0].Rows[0]["CMBNK_ID"]); }
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
                lblBankName.Text = "";
                lblBranchName.Text = "";
                lblBAccName.Text = "";
                lblBIFSCode.Text = "";
                lblBAccNo.Text = "";
                varSPBankID = -1;
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
                    dpDate.Focus();
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
                    epSupplier.SetError(cmbConcern, "Please select concern.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select concern.", cmbConcern, 5000);
                }
                else
                {
                    epSupplier.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtsuppliername.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliername_Enter(object sender, EventArgs e)
        {
            try
            {
                txtsuppliername.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemark.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (LV_Supplier.Items.Count == 0 || txtsuppliername.Text == "")
                    {
                        txtsuppliername.Focus();
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
        private void Txtsuppliername_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtsuppliername.Text).Trim() == "")
                {
                    epSupplier.SetError(txtsuppliername, "Please enter supplier name");
                    txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier name", txtsuppliername, 5000);
                }
                else
                {
                    epSupplier.Clear();
                    txtsuppliername.BackColor = Color.White;
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
                    txtRemark.Focus();
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
        public void udfnListViewData()
        {
            try
            {
                if (txtsuppliername.Text != "")
                {
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtsuppliername.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                    if (Convert.ToInt32(grdSupplierPayment.Rows.Count) != 0)
                    {
                        if (Convert.ToString(lblSupplierCode.Text.Trim()) != Convert.ToString(varSupplierID))
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(78);
                            objDServ.CloseConnection();

                            DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdSupplierPayment.Rows.Clear();
                                grdReurnDC.Rows.Clear();
                                grdSupplierPayment.DataSource = null;
                                grdReurnDC.DataSource = null;
                            }
                            else
                            {
                                grdSupplierPayment.Refresh();
                                txtsuppliername.Text = varSupplierName;
                                lblSupplierCode.Text = varSupplierID;
                                lblschedule.Text = varSupplierScheduleID;
                            }
                        }
                    }
                    udfnsupplierLoad();
                    udfnGridLoad();
                    udfnClearAdvance();
                    VARFLAG = 0;
                    udfnSubtotalCalc();
                    udfnBankDropDown();
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    //cmbReason.Focus();
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
        public void udfnOutstandingAmount()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    string outstandingAmt = "0", type = "";
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 45;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            outstandingAmt = Convert.ToString(objDs.Tables[0].Rows[0]["Outstanding"]);
                            type = Convert.ToString(objDs.Tables[0].Rows[0]["Type"]);
                            tsbOutstandingAmount.Text = outstandingAmt + " " + type;

                            if (type == "Cr")
                            { tsbOutstandingAmount.ForeColor = Color.DarkGreen; }
                            else if (type == "Dr")
                            { tsbOutstandingAmount.ForeColor = Color.Red; }
                        }
                        else
                        {
                            tsbOutstandingAmount.Text = outstandingAmt + " " + type;
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
        public void udfnsupplierLoad()
        {
            try
            {
                //pbSupplierpend = 0;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    int varReturnApplicable = 0, varReturnType = 0;
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 44;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.paraPayID = varSupplierPaymentID;
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
                            varSupplierType = Convert.ToInt32(objDs.Tables[0].Rows[0]["PaymentTerm"]);
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            lblBankName.Text = objDs.Tables[1].Rows[0]["SP_BankName"].ToString();
                            lblBranchName.Text = objDs.Tables[1].Rows[0]["SP_BranchName"].ToString();
                            lblBAccName.Text = objDs.Tables[1].Rows[0]["SP_AccountName"].ToString();
                            lblBAccNo.Text = objDs.Tables[1].Rows[0]["SP_AccNo"].ToString();
                            lblBIFSCode.Text = objDs.Tables[1].Rows[0]["SP_IFSC"].ToString();
                            varSPBankID =Convert.ToInt16(objDs.Tables[1].Rows[0]["SP_BNKID"]) ;
                        }
                        if (objDs.Tables[2].Rows.Count > 0)
                        {
                            varSupplierPaymentMode = Convert.ToString(objDs.Tables[2].Rows[0]["Payment_Mode"]);
                        }
                        
                    }
                }
                udfnOutstandingAmount();
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
        public void udfnGridLoad()
        {
            try
            {
                varSupplierID = lblSupplierCode.Text;
                varSupplierScheduleID = lblschedule.Text;
                varSupplierName = txtsuppliername.Text;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    Model.TRN_Supplier_Payment objTRN_Supplier_Payment = new Model.TRN_Supplier_Payment();
                    objTRN_Supplier_Payment.ViewType = 0;
                    objTRN_Supplier_Payment.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objTRN_Supplier_Payment.paraScheduleId = Convert.ToInt32(lblschedule.Text);
                    objTRN_Supplier_Payment.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                    objDs = objspdservice.udfnGetSupplierPayment(objTRN_Supplier_Payment);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            grdSupplierPayment.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdSupplierPayment.Rows.Add(0, Convert.ToString(objDs.Tables[0].Rows[i]["S.No."]),Convert.ToString(objDs.Tables[0].Rows[i]["Voucher Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Voucher No."]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice No."]), Convert.ToString(objDs.Tables[0].Rows[i]["Filing Status"]),
                                    Convert.ToDecimal(objDs.Tables[0].Rows[i]["Taxable Amount"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Tax Amount"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Additions"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Deductions"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Invoice Amount"]),
                                    
                                    Convert.ToDecimal(objDs.Tables[0].Rows[i]["Outstading Amount"]),
                                    
                                    Convert.ToDecimal(objDs.Tables[0].Rows[i]["Discount Amount"]),
                                    Convert.ToString(objDs.Tables[0].Rows[i]["Purchase Return Adjustment"]),
                                    Convert.ToString(objDs.Tables[0].Rows[i]["Advance Amount"]),
                                    Convert.ToString(objDs.Tables[0].Rows[i]["To Be Paid"]), 
                                     
                                    Convert.ToDecimal(objDs.Tables[0].Rows[i]["Pay Amount"]),
                                    Convert.ToDecimal(objDs.Tables[0].Rows[i]["Balance Amount"]),
                                    
                                    Convert.ToDecimal(objDs.Tables[0].Rows[i]["ID"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["ID1"]), 0,Convert.ToString(objDs.Tables[0].Rows[i]["Status"]),Convert.ToString(objDs.Tables[0].Rows[i]["RetStatus"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["Disc ID"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["paymentAmount"]), Convert.ToString(objDs.Tables[0].Rows[i]["Entered By"]), Convert.ToString(objDs.Tables[0].Rows[i]["Approved By"]), Convert.ToString(objDs.Tables[0].Rows[i]["CNID"]), Convert.ToString(objDs.Tables[0].Rows[i]["Flag"]));
                                grdSupplierPayment.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmVoucherDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                decimal varAmnt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmInvoiceAmnt"].Value);
                                grdSupplierPayment.Columns["clmInvoiceDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdSupplierPayment.Columns["clmTaxableAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmTaxAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmInvoiceAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmTobePaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmReturnAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                varModifiedFlag = 1;
                                int varFlag = Convert.ToInt32(objDs.Tables[0].Rows[i]["Flag"]);
                                if( (varFlag == 3 || varFlag == 0) && (Convert.ToInt32(objDs.Tables[0].Rows[i]["RetStatus"]) == 0 || Convert.ToInt32(objDs.Tables[0].Rows[i]["RetStatus"]) == 79))
                                {
                                    grdSupplierPayment.Rows[i].Cells["clmcheck"].Value = false;
                                    grdSupplierPayment.Rows[i].Cells["clmTobePaid"].ReadOnly = true;
                                    grdSupplierPayment.Rows[i].Cells["clmTobePaid"].Style.BackColor = Color.LightGray;
                                }
                                else
                                {
                                    grdSupplierPayment.Rows[i].Cells["clmTobePaid"].ReadOnly = true;
                                    grdSupplierPayment.Rows[i].Cells["clmTobePaid"].Style.BackColor = Color.LightGray;
                                    DataGridViewTextBoxCell c = new DataGridViewTextBoxCell();
                                    c.Value = "";
                                    grdSupplierPayment.Rows[i].Cells["clmcheck"] = c;
                                    c.ReadOnly = true;
                                }
                                if (Convert.ToString(objDs.Tables[1].Rows[i]["Filing Status"]) == "F")
                                {
                                    grdSupplierPayment.Rows[i].Cells["clmFilingStatus"].Style.BackColor = Color.LightGreen;
                                    grdSupplierPayment.Rows[i].Cells["clmFilingStatus"].Style.ForeColor = Color.Black;
                                }
                                else if (Convert.ToString(objDs.Tables[1].Rows[i]["Filing Status"]) == "NF")
                                {
                                    grdSupplierPayment.Rows[i].Cells["clmFilingStatus"].Style.BackColor = Color.Red;
                                    grdSupplierPayment.Rows[i].Cells["clmFilingStatus"].Style.ForeColor = Color.White;
                                }
                                if (Convert.ToInt32(objDs.Tables[0].Rows[i]["GSTRFlag"]) == 1)
                                {
                                    grdSupplierPayment.Rows[i].Cells["clmTobePaid"].ReadOnly = true;
                                    grdSupplierPayment.Rows[i].Cells["clmTobePaid"].Style.BackColor = Color.LightGray;
                                    DataGridViewTextBoxCell c = new DataGridViewTextBoxCell();
                                    c.Value = "";
                                    grdSupplierPayment.Rows[i].Cells["clmcheck"] = c;
                                    c.ReadOnly = true;
                                }
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
        private void CmbPaymentmode_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPaymentmode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPaymentmode_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPaymentmode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPaymentmode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                    if(cmbBank.Visible==false)
                    { btnSave.Focus(); }
                    else if(cmbBank.Enabled==true)
                    { cmbBank.Focus();}
                    else
                    { dpChequeDate.Focus();}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPaymentmode_KeyPress(object sender, KeyPressEventArgs e)
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
        private void DtChequeDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpChequeDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DtChequeDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtChequeNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DtChequeDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpChequeDate.BackColor = Color.White;
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
                udfnTransferNo();
                grdSupplierPayment.Rows.Clear();
                if (btnSave.Text == "Save")
                {
                    txtsuppliername.Text = "";
                } 
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
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) == -1)
                {
                    txtTypeName.Visible = false;
                    txtIssue.Visible = false;
                }
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) == 221 || Convert.ToInt32(cmbIssueMode.SelectedValue) == 223)
                {
                    txtTypeName.Visible = true;
                    txtIssue.Visible = true;
                    txtTypeName.Text = "Person Name";
                }
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) == 222)
                {
                    txtTypeName.Visible = true;
                    txtIssue.Visible = true;
                    txtTypeName.Text = "Courier No.";
                }
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
                    if (txtIssue.Visible == true)
                    {
                        txtIssue.Focus();
                    }
                    else { txtRemark.Focus(); }
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

        private void TxtIssue_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIssue.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIssue_Leave(object sender, EventArgs e)
        {
            try
            {
                txtIssue.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIssue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemark.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeLimitDays_Enter(object sender, EventArgs e)
        {
            try
            {
                txtChequeLimitDays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeLimitDays_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dpChequeDate.Enabled == true)
                    {
                        dpChequeDate.Focus();
                    }
                    else
                    {
                        txtChequeNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeLimitDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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

        private void TxtChequeLimitDays_Leave(object sender, EventArgs e)
        {
            try
            {
                txtChequeLimitDays.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnChequeDate()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 28;
                objMR_Master.paraDate =Convert.ToString(dpChequeDate.Text);
                objMR_Master.paraFlag = Convert.ToInt32(txtChequeLimitDays.Text);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnMaster(objMR_Master);
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 1)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            dpChequeDate.MinDate = DateTime.ParseExact(objDs.Tables[1].Rows[0]["ChequeDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                    }
                    if (txtChequeLimitDays.Text.Trim() != "")
                    {
                        if (objDs.Tables.Count > 1)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                dpChequeDate.Text = Convert.ToString(DateTime.ParseExact(objDs.Tables[0].Rows[0]["Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                                if (txtChequeLimitDays.Text.Trim() != "0")
                                {
                                    dpChequeDate.Enabled = false;
                                }
                            }
                        }
                    }
                    else
                    { dpChequeDate.Enabled = true; }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtChequeLimitDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varEditFlag == 0)
                {
                    udfnChequeDate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        public void udfnTransferNo()
        {
            if (varSupplierPaymentID == 0)
            {
                if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                {
                    string vardate = "", varResult = "";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    DataService objDservice = new DataService();
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpDate.Text + "',103)");
                    varResult = objspdservice.udfngetVoucherNo("153", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                    objspdservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varResult != "")
                    {
                        txtTransactionNo.Text = varvalue[0];
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(75);
                        objDServ.CloseConnection();
                        txtTransactionNo.Text = "";
                        DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MainForm.objCP_Settings = new CP_Settings();
                            //MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                            //MainForm.objCP_Settings.varValues = Convert.ToString(44);
                            MainForm.objCP_Settings.MdiParent = this.ParentForm;
                            MainForm.objCP_Settings.Show();
                            this.Close();
                        }
                    }
                }
                else
                {
                    txtTransactionNo.Text = "";
                }
            }
        }
        private void DpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                udfnTransferNo();
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
                //LV_Supplier.Visible = false;
                //if (Convert.ToString(txtsuppliername.Text) != "")
                //{
                //    string[] values = new string[0];
                //    string varSupplierId = "0";
                //    MR_Supplier objMR_Supplier = new MR_Supplier();
                //    objMR_Supplier.ViewType = 23;
                //    objMR_Supplier.paraSupplierName = txtsuppliername.Text.Trim();
                //    DataSet objDsSupplierId = new DataSet();
                //    SPDataService objDserv = new SPDataService();
                //    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
                //    objDserv.CloseConnection();
                //    if (objDsSupplierId != null)
                //    {
                //        if (objDsSupplierId.Tables.Count > 0)
                //        {
                //            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                //            {
                //                varSupplierId = Convert.ToString(objDsSupplierId.Tables[0].Rows[0][0]);
                //                values = Convert.ToString(varSupplierId).Split(',');
                //            }
                //        }
                //    }
                //    if (values[0] == "-1")
                //    {
                //        epSupplier.SetError(txtsuppliername, "Invalid supplier");
                //        txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpSuppliername.ShowAlways = true;
                //        tpSuppliername.Show("Invalid supplier.", txtsuppliername, 5000);
                //        lblSupplierCode.Text = "0";
                //        lblschedule.Text = "0";
                //        grdSupplierPayment.DataSource = null;
                //        ClearSupplier();

                //    }
                //    else
                //    {
                //        epSupplier.Clear();
                //        lblSupplierCode.Text = values[0];
                //        lblschedule.Text = values[1];
                //        txtsuppliername.BackColor = Color.White;
                //        if (VarPrevSupplierid != Convert.ToInt32(lblSupplierCode.Text))
                //        {
                //            udfnGridLoad();
                //        }
                //    }
                //    VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                //}
                txtRemark.BackColor = Color.LemonChiffon;
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

        private void TxtChequeNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtChequeNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeNo_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtChequeNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtChequeNo.BackColor = Color.White;
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
        public void udfnSubtotalCalc()
        {
            try
            { 
                varGrandTot = 0; varTotal = 0; varamt = 0; varReturnAmnt = 0; varDiscAmnt = 0; varSubtotal = 0; varTaxableAmnt = 0; varAdditions = 0; varDeductions = 0;
                varOutstanding = 0;varTobepaid = 0;
                bool varCheck = false;
                decimal varResult = 0, CellAdvanceAmnt = 0;
                lblAdvance.Text = varAdvanceAmnt.ToString("#,##0.00");
                //for (int i= 0; i < grdSupplierPayment.Rows.Count;i++)
                //{
                //    if (Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmInvoiceAmnt"].Value)!="")
                //    {
                //        varamt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmInvoiceAmnt"].Value);
                //        varReturnAmnt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmReturnAmt"].Value);
                //        varDiscAmnt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmDiscAmount"].Value);
                //        varTaxableAmnt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmTaxableAmnt"].Value);
                //        varAdditions = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmAdditions"].Value);
                //        varDeductions = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmDeductions"].Value);
                //        CellAdvanceAmnt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmAdvanceAmnt"].Value);
                //        varOutstanding = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmOutstandingAmt"].Value);
                //        varTobepaid = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmTobePaid"].Value);
                         
                //        if (varSupplierType == 34)
                //        {
                //            varTotal = (Convert.ToDecimal(varTaxableAmnt) + 
                //                Convert.ToDecimal(varAdditions) - 
                //                Convert.ToDecimal(varDeductions)) - (varReturnAmnt + varDiscAmnt + CellAdvanceAmnt);
                //        }
                //        else
                //        {
                //            varResult = varamt - (varReturnAmnt + varDiscAmnt + CellAdvanceAmnt);
                //        }
                //    }                    
                //    if (Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmcheck"].Value)=="")
                //    {
                //        varCheck = false;
                //    }
                //    else if (Convert.ToBoolean(grdSupplierPayment.Rows[i].Cells["clmcheck"].Value) == true)
                //    {
                //        varCheck = true;
                //    }
                //    else
                //    {
                //        varCheck = false;
                //    }
                //    if (Convert.ToBoolean(varCheck) == true)
                //    {
                //        varTotal = varTotal + varResult;
                //        varGrandTot = varTotal - (Convert.ToDecimal(lblAdvance.Text));
                //    }
                //}
                decimal TaxableAmount = 0, TaxAmount = 0, SubTotal = 0, ReturnAdjustment = 0, Discount = 0, Advance = 0,
                    Addition = 0, Deduction = 0, GrandTotal = 0,Outstanding=0,Tobepaid=0,PaidAmount=0;

                var totals = grdSupplierPayment.Rows
                    .Cast<DataGridViewRow>()   .Where(row => !row.IsNewRow) // skip new row
                    .Where(row => !row.IsNewRow   && row.Cells["clmcheck"].Value != null   && row.Cells["clmcheck"].Value is bool  && (bool)row.Cells["clmcheck"].Value) //  only checked rows
                    .Select(row => new
                    {
                        Taxable = (row.Cells["clmTaxableAmnt"].Value != null &&    row.Cells["clmTaxableAmnt"].Value != DBNull.Value &&
                                   !string.IsNullOrWhiteSpace(row.Cells["clmTaxableAmnt"].Value.ToString()))  ? Convert.ToDecimal(row.Cells["clmTaxableAmnt"].Value)  : 0,

                        Tax = (row.Cells["clmTaxAmount"].Value != null &&   row.Cells["clmTaxAmount"].Value != DBNull.Value &&  !string.IsNullOrWhiteSpace(row.Cells["clmTaxAmount"].Value.ToString()))   ? Convert.ToDecimal(row.Cells["clmTaxAmount"].Value) : 0,

                        Disc = (row.Cells["clmDiscAmount"].Value != null &&    row.Cells["clmDiscAmount"].Value != DBNull.Value &&  !string.IsNullOrWhiteSpace(row.Cells["clmDiscAmount"].Value.ToString()))  ? Convert.ToDecimal(row.Cells["clmDiscAmount"].Value)     : 0,

                        Adv = (row.Cells["clmAdvanceAmnt"].Value != null &&   row.Cells["clmAdvanceAmnt"].Value != DBNull.Value &&   !string.IsNullOrWhiteSpace(row.Cells["clmAdvanceAmnt"].Value.ToString()))   ? Convert.ToDecimal(row.Cells["clmAdvanceAmnt"].Value)   : 0,

                        Add = (row.Cells["clmAdditions"].Value != null &&   row.Cells["clmAdditions"].Value != DBNull.Value &&  !string.IsNullOrWhiteSpace(row.Cells["clmAdditions"].Value.ToString()))  ? Convert.ToDecimal(row.Cells["clmAdditions"].Value)   : 0,

                        Ded = (row.Cells["clmDeductions"].Value != null &&  row.Cells["clmDeductions"].Value != DBNull.Value &&   !string.IsNullOrWhiteSpace(row.Cells["clmDeductions"].Value.ToString())) ? Convert.ToDecimal(row.Cells["clmDeductions"].Value)  : 0,

                        RetrunAdjustment = (row.Cells["clmReturnAmt"].Value != null && row.Cells["clmReturnAmt"].Value != DBNull.Value && !string.IsNullOrWhiteSpace(row.Cells["clmReturnAmt"].Value.ToString())) ? Convert.ToDecimal(row.Cells["clmReturnAmt"].Value) : 0,

                         OutstandingAmt = (row.Cells["clmOutstandingAmt"].Value != null && row.Cells["clmOutstandingAmt"].Value != DBNull.Value && !string.IsNullOrWhiteSpace(row.Cells["clmOutstandingAmt"].Value.ToString())) ? Convert.ToDecimal(row.Cells["clmOutstandingAmt"].Value) : 0,

                          TobepaidAmt = (row.Cells["clmTobePaid"].Value != null && row.Cells["clmTobePaid"].Value != DBNull.Value && !string.IsNullOrWhiteSpace(row.Cells["clmTobePaid"].Value.ToString())) ? Convert.ToDecimal(row.Cells["clmTobePaid"].Value) : 0,

                           PaidAmount = (row.Cells["clmPayAmount"].Value != null && row.Cells["clmPayAmount"].Value != DBNull.Value && !string.IsNullOrWhiteSpace(row.Cells["clmPayAmount"].Value.ToString())) ? Convert.ToDecimal(row.Cells["clmPayAmount"].Value) : 0
                    });
                    TaxableAmount = totals.Sum(x => x.Taxable);
                    TaxAmount = totals.Sum(x => x.Tax);
                    Discount = totals.Sum(x => x.Disc);
                    Advance = totals.Sum(x => x.Adv);
                    Addition = totals.Sum(x => x.Add);
                    Deduction = totals.Sum(x => x.Ded);
                    ReturnAdjustment = totals.Sum(x => x.RetrunAdjustment);
                    Outstanding = totals.Sum(x => x.OutstandingAmt);
                    Tobepaid = totals.Sum(x => x.TobepaidAmt);
                    PaidAmount = totals.Sum(x => x.PaidAmount);

                    /* 33 - Nett Amount, 34 - Taxable Amount*/
                if (varSupplierType == 34)
                {
                    SubTotal = TaxableAmount ;
                    GrandTotal = PaidAmount;
                }
                else
                {
                    SubTotal = TaxableAmount + TaxAmount;
                    GrandTotal = PaidAmount;
                }
                lblTaxableAmount.Text = TaxableAmount.ToString("#,##0.00");  
                lblTaxAmount.Text =  TaxAmount.ToString("#,##0.00") ;
                lblDiscount.Text =  Discount.ToString("#,##0.00") ;
                lblAdvance.Text =  Advance.ToString("#,##0.00");
                lblAddition.Text =  Addition.ToString("#,##0.00");
                lblDedution.Text =  Deduction.ToString("#,##0.00");
                lblReturnAdjustment.Text =  ReturnAdjustment.ToString("#,##0.00");
                lblOutstanding.Text =  Outstanding.ToString("#,##0.00");
                lblTobepaid.Text =  Tobepaid.ToString("#,##0.00");
                lblSubtotal.Text =  SubTotal.ToString("#,##0.00");
                lblGrandTotal.Text = PaidAmount.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }
        private void GrdSupplierPayment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                varModifiedFlag = 1;  decimal varBalanceAmt = 0,varTobePaid=0,varPayAmt=0,varOutstandingAmt=0,varReturnAdjAmt=0,varDiscount=0,varAdvance=0;
                
                if (grdSupplierPayment.CurrentCell.OwningColumn.Name == "clmPayAmount")
                {
                    object varEditQty = grdSupplierPayment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // Update the same column value in the DataTable
                    //dtPayment.Rows[e.RowIndex]["PY_Amount"] = varEditQty;
                    if (Convert.ToString(grdSupplierPayment.Rows[e.RowIndex].Cells["clmOutstandingAmt"].Value) != "")
                    { varOutstandingAmt = Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmOutstandingAmt"].Value); }
                    if (Convert.ToString(grdSupplierPayment.Rows[e.RowIndex].Cells["clmTobePaid"].Value)!="")
                    { varTobePaid = Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmTobePaid"].Value); }
                    if (Convert.ToString(grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].Value) != "")
                    { varPayAmt = Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].Value); }

                    if (Convert.ToString(grdSupplierPayment.Rows[e.RowIndex].Cells["clmReturnAmt"].Value) != "")
                    { varReturnAdjAmt = Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmReturnAmt"].Value);}
                    if (Convert.ToString(grdSupplierPayment.Rows[e.RowIndex].Cells["clmDiscAmount"].Value) != "")
                    { varDiscount = Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmDiscAmount"].Value); }
                    if (Convert.ToString(grdSupplierPayment.Rows[e.RowIndex].Cells["clmAdvanceAmnt"].Value) != "")
                    { varAdvance = Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmAdvanceAmnt"].Value); }

                    DataGridViewCell cellPayAmt = grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"];
                   
                    if (varTobePaid < varPayAmt)
                    {
                        cellPayAmt.Style.BackColor = Color.LightPink;
                    }
                    else
                    {
                        cellPayAmt.Style.BackColor = Color.PaleGreen;
                    }
                    varBalanceAmt = varOutstandingAmt-  (varPayAmt+varDiscount+varReturnAdjAmt+varAdvance);
                    grdSupplierPayment.Rows[e.RowIndex].Cells["clmBalance"].Value = (varBalanceAmt.ToString("##0.00")); 
                    udfnPaymentDropDown();
                    udfnSubtotalCalc();
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void GrdReurnDC_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (varCellclickFlag == 0)
                    {
                        switch (grdReurnDC.Columns[e.ColumnIndex].Name)
                        {
                            case "InvoiceNo":
                                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                                {
                                    string cellDCID = Convert.ToString(grdReurnDC.Rows[e.RowIndex].Cells["clmREDDCID"].Value);
                                    MainForm.objPUR_PurchaseOrderDamage = new PUR_PurchaseOrderDamage();
                                    MainForm.objPUR_PurchaseOrderDamage.varMasterType = "4";
                                    MainForm.objPUR_PurchaseOrderDamage.varDcCode = Convert.ToString(cellDCID);
                                    MainForm.objPUR_PurchaseOrderDamage.ShowDialog();
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (grdReurnDC.Columns[e.ColumnIndex].Name)
                        {
                            case "InvoiceNo":
                                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                                {
                                    string cellCreditID = Convert.ToString(grdReurnDC.Rows[e.RowIndex].Cells["clmREDDCID"].Value);
                                    MainForm.objPUR_CreditnoteDetails = new PUR_CreditnoteDetails();
                                    MainForm.objPUR_CreditnoteDetails.varCreditID = Convert.ToString(cellCreditID);
                                    MainForm.objPUR_CreditnoteDetails.ShowDialog();
                                }
                                break;
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
        private void CmbBank_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBank.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtChequeLimitDays.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filterText = txtSearch.Text.Trim().ToLower();

                grdSupplierPayment.Rows.Cast<DataGridViewRow>().Where(row => !row.IsNewRow).ToList().ForEach(row =>
                {
                        var cellValue1 = Convert.ToString(row.Cells["clmVoucherDate"].Value ?? "").Trim().ToLower();
                        var cellValue2 = Convert.ToString(row.Cells["clmVoucherNo"].Value ?? "").Trim().ToLower();
                        var cellValue3 = Convert.ToString(row.Cells["clmInvoiceDate"].Value ?? "").Trim().ToLower();
                        var cellValue4 = Convert.ToString(row.Cells["clmInvoiceNo"].Value ?? "").Trim().ToLower();
                        bool match = cellValue1.Contains(filterText) || cellValue2.Contains(filterText) || cellValue3.Contains(filterText) || cellValue4.Contains(filterText);
                        row.Visible = match;
                });
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearch.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearch.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBank_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbBank_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBank.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnReturnDCLoad()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                Model.TRN_Supplier_Payment objTRN_Supplier_Payment = new Model.TRN_Supplier_Payment();
                objTRN_Supplier_Payment.ViewType = 0;
                objTRN_Supplier_Payment.paraID = Convert.ToInt32(id);
                objTRN_Supplier_Payment.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_Supplier_Payment.paraScheduleId = Convert.ToInt32(lblschedule.Text);
                objTRN_Supplier_Payment.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_Supplier_Payment.paraSource = varSource; 
                 objDs = objspdservice.udfnGetSupplierPayment(objTRN_Supplier_Payment);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (varCellclickFlag == 0)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            grdReurnDC.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["PURREDC_DCNO"]), Convert.ToString(objDs.Tables[1].Rows[i]["PURREDC_DCDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["Return Amount"]), Convert.ToString(objDs.Tables[1].Rows[i]["ID"]));
                                grdReurnDC.Columns["clmReturnAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                        else
                        {
                            grdReurnDC.Rows.Clear();
                        }
                    }

                    else
                    {
                        if (objDs.Tables[2].Rows.Count > 0)
                        {
                            grdReurnDC.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                            {
                                grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[2].Rows[i]["Trans No"]), Convert.ToString(objDs.Tables[2].Rows[i]["Trans Date"]), Convert.ToString(objDs.Tables[2].Rows[i]["Amount"]), Convert.ToString(objDs.Tables[2].Rows[i]["ID"]));
                                grdReurnDC.Columns["clmReturnAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                        else
                        {
                            grdReurnDC.Rows.Clear();
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
        private void GrdSupplierPayment_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //int Id = 0;
                //if (grdSupplierPayment.Rows.Count > 0)
                //{
                //    if (Convert.ToString(grdSupplierPayment.Columns[grdSupplierPayment.SelectedCells[0].ColumnIndex].Name)=="clmReturnAmt")
                //    {
                //        Id = Convert.ToInt32(grdSupplierPayment.SelectedRows[0].Cells["clmID"].Value);
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdvance_Click(object sender, EventArgs e)
        {
            try
            {
                udfnAddAdvance();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierPayment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnSubtotalCalc();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (varEditFlag == 0)
                {
                    udfnCheckProcess(sender, e);
                    udfnPaymentDropDown();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }
        public void udfnClearAdvance()
        {
            try
            {
                varApplyFlag = 0;
                dtAdvance.Clear(); varAdvanceID = "";
                decimal varPayAmount = 0, varAdvanceAmount = 0, varTotalAmnt = 0;
                if (clearClick==1)
                {
                    //MainForm.objPAY_Advance_Popup.Btnunselectall_Click( sender,e);
                    for (int i = 0; i < grdSupplierPayment.Rows.Count; i++)
                    {
                        varAdvanceAmount = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmAdvanceAmnt"].Value);
                        varPayAmount = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmTobePaid"].Value);
                        varTotalAmnt = varAdvanceAmount + varPayAmount;
                        grdSupplierPayment.Rows[i].Cells["clmTobePaid"].Value = varTotalAmnt;
                        grdSupplierPayment.Rows[i].Cells["clmPaymentAmount"].Value = varTotalAmnt;
                        grdSupplierPayment.Rows[i].Cells["clmPayAmount"].Value = varTotalAmnt;
                        grdSupplierPayment.Rows[i].Cells["clmAdvanceAmnt"].Value = 0.00;
                        
                        //MainForm.objPAY_Advance_Popup.udfnEditAdvance();
                    }
                    lblAdvance.Text = "0.00";
                    varAdvanceAmnt = 0;
                    udfnSubtotalCalc();
                    btnAdvance.Enabled = true;
                    varAdvanceID = "";
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(142);
                DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    clearClick = 1;
                    varApplyFlag = 0;
                    udfnClearAdvance();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        public void udfnCheckProcess(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varpurchaseId = 0, payid = 0;
                decimal varTotal = 0;
                clearClick = 2;
                //int VARFLAG = 0;
                if (e.RowIndex != -1)
                {
                    if (grdSupplierPayment.Columns[e.ColumnIndex].Name == "clmcheck")
                    {
                        // bool value = Convert.ToBoolean(grdSupplierPayment.SelectedCells[0].Value);
                        if (varSupplierPaymentID != 0 && Convert.ToBoolean(grdSupplierPayment.SelectedCells[0].EditedFormattedValue) == false)
                        {
                            varpurchaseId = Convert.ToInt32(grdSupplierPayment.Rows[e.RowIndex].Cells["clmID"].Value);
                            payid = Convert.ToInt32(grdSupplierPayment.Rows[e.RowIndex].Cells["clmPAYIID"].Value);
                            for (int i = 0; i < grdSupplierPayment.RowCount; i++)
                            {
                                grdSupplierPayment.Rows[i].Cells["clmdsno"].Value = i + 1;
                            }
                            for (int i = 0; i < dtPayment.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dtPayment.Rows[i]["PY_PURID"]) == Convert.ToInt32(varpurchaseId) && Convert.ToInt32(dtPayment.Rows[i]["PAYIID"]) == payid)
                                {
                                    dtPayment.Rows[i].Delete();
                                    dtPayment.AcceptChanges();
                                } 
                            }
                        }
                        if (varPaymentStatus!=77)
                        {
                            if (Convert.ToBoolean(grdSupplierPayment.Rows[e.RowIndex].Cells[0].Value) == true)
                            {
                                VARFLAG++;
                                if (PurchaseID == "0")
                                {
                                    PurchaseID = Convert.ToString(grdSupplierPayment.Rows[e.RowIndex].Cells["clmID"].Value);
                                }
                                else
                                {
                                    PurchaseID = PurchaseID + ',' + Convert.ToString(grdSupplierPayment.Rows[e.RowIndex].Cells["clmID"].Value);

                                }
                                varTotal = Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmInvoiceAmnt"].Value);
                                /* 33 - Nett Amount, 34 - Taxable Amount*/
                                if (varSupplierType == 34)
                                {
                                    varTotal = (Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmOutstandingAmt"].Value) + Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmAdditions"].Value) - Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmDeductions"].Value)) - (Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmReturnAmt"].Value) + Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmDiscAmount"].Value));
                                }
                                else
                                {
                                    varTotal = Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmOutstandingAmt"].Value) - (Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmReturnAmt"].Value) + Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmDiscAmount"].Value));
                                }
                                //grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].Value = varTotal;
                                //varGrandTotal = varGrandTotal + varTotal;
                                ////lblSubtotal.Text = Convert.ToString(varGrandTotal);
                                //lblSubtotal.Text = varGrandTotal.ToString("#,##0.00");
                                //decimal varGrand = Convert.ToDecimal(lblSubtotal.Text);
                                //lblGrandTotal.Text = varGrand.ToString("#,##0.00"); ;

                            }
                            else
                            {
                                VARFLAG--;
                                varUncheckFlag = 1;
                                varApplyFlag = 0;
                                for (int i = 0; i < grdSupplierPayment.Rows.Count; i++)
                                {
                                    decimal varInvoiceAmnt = 0, varTaxableAmnt = 0, varReturnAmnt = 0, varDiscAmnt = 0, varAmnt = 0,
                                        varAdditions=0, varDeductions =0,varBalanceAmt=0,varOutstanding=0;
                                    varTaxableAmnt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmTaxableAmnt"].Value);
                                    varInvoiceAmnt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmInvoiceAmnt"].Value);
                                    varReturnAmnt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmReturnAmt"].Value);
                                    varDiscAmnt = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmDiscAmount"].Value);
                                    varAdditions = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmAdditions"].Value);
                                    varDeductions = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmDeductions"].Value);
                                    varOutstanding = Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmOutstandingAmt"].Value);
                                    /* 33 - Nett Amount, 34 - Taxable Amount*/
                                    if (varSupplierType == 34)
                                    {
                                        varAmnt = (varTaxableAmnt + varAdditions - varDeductions) - (varReturnAmnt + varDiscAmnt);
                                       
                                    }
                                    else
                                    {
                                        varAmnt = varInvoiceAmnt - (varReturnAmnt + varDiscAmnt);
                                    }
                                    grdSupplierPayment.Rows[i].Cells["clmPayAmount"].Value = varAmnt;
                                    grdSupplierPayment.Rows[i].Cells["clmTobePaid"].Value = varAmnt;
                                    varBalanceAmt = varOutstanding - (varAmnt+varReturnAmnt + varDiscAmnt);
                                    grdSupplierPayment.Rows[e.RowIndex].Cells["clmBalance"].Value = varBalanceAmt.ToString("###0.00");
                                   
                                }  
                                //grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].Value = grdSupplierPayment.Rows[e.RowIndex].Cells["clmOutstandingAmt"].Value; 
                                grdSupplierPayment.Rows[e.RowIndex].Cells["clmAdvanceAmnt"].Value = "0.00";
                                
                                int varPurchaseID = Convert.ToInt32(grdSupplierPayment.Rows[e.RowIndex].Cells["clmID"].Value);
                                //lblGrandTotal.Text = varOverallGrand.ToString("#,##0.00"); 
                            }
                            udfnSubtotalCalc();
                        }
                    }
                    if(VARFLAG!=0)
                    {
                        btnApply.Enabled = true;
                        btnAdvance.Enabled = true;
                        btnClear.Enabled = true;
                    }
                    else
                    {
                        btnApply.Enabled = false;
                        btnAdvance.Enabled = false;
                        btnClear.Enabled = false;
                        udfnClearAdvance();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierPayment_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = 0; varCellclickFlag = 0; varSource = 0;
                if (grdSupplierPayment.Rows.Count > 0)
                {
                    id = Convert.ToInt32(grdSupplierPayment.Rows[e.RowIndex].Cells["clmID1"].Value);
                    varSource = Convert.ToInt32(grdSupplierPayment.Rows[e.RowIndex].Cells["clmFlag"].Value);
                    if (Convert.ToString(grdSupplierPayment.Columns[grdSupplierPayment.SelectedCells[0].ColumnIndex].Name) == "clmReturnAmt")
                    {
                        varCellclickFlag = 0;
                        udfnReturnDCLoad();
                    }
                    else if (Convert.ToString(grdSupplierPayment.Columns[grdSupplierPayment.SelectedCells[0].ColumnIndex].Name) == "clmDiscAmount")
                    {
                        varCellclickFlag = 1;
                        udfnReturnDCLoad();
                    }
                    else
                    {
                        grdReurnDC.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdSupplierPayment_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                grdSupplierPayment.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        public void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                //udfnSubtotalCalc();
                udfnApply();
                udfnSubtotalCalc();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnApply()
        {
            try
            {
                if (varApplyFlag == 0)
                {
                    decimal CurrentAdvace = 0, AdvanceAmount = 0, varFinalAmount = 0, varFinalTotAmnt = 0, varAmountCalc = 0, varTotAmount = 0, varAdvAmount = 0,
                    RemainingAmnt = 0, varFixedAdvance = 0;
                    bool varCheck = true;
                    string varValue = "0", varID = "0", varAdvanceID = "0";
                    varApplyFlag = 1;
                    dtAdvance.Clear();
                    //if(varSupplierPaymentID==0 && varUncheckFlag==0)
                    //{
                    for (int i = 0; i < dtCheckAdv.Rows.Count; i++)
                    {
                        AdvanceAmount = Convert.ToDecimal(dtCheckAdv.Rows[i]["Current balance"]);
                        varFixedAdvance = Convert.ToDecimal(dtCheckAdv.Rows[i]["Current balance"]);
                        varAdvanceID = Convert.ToString(dtCheckAdv.Rows[i]["ADID"]);
                        for (int j = 0; j < grdSupplierPayment.Rows.Count; j++)
                        {
                            if (Convert.ToString(grdSupplierPayment.Rows[j].Cells["clmcheck"].Value) == "")
                            {
                                varCheck = false;
                            }
                            else if (Convert.ToBoolean(grdSupplierPayment.Rows[j].Cells["clmcheck"].Value) == true)
                            {
                                varCheck = true;
                            }
                            else
                            {
                                varCheck = false;
                            }
                            if (varCheck == true)
                            {
                                varValue = Convert.ToString(grdSupplierPayment.Rows[j].Cells["clmTobePaid"].Value);
                                varID = Convert.ToString(grdSupplierPayment.Rows[j].Cells["clmID"].Value);
                                if (varValue != "0" && AdvanceAmount != 0)
                                {
                                    if (Convert.ToDecimal(varValue) > Convert.ToDecimal(AdvanceAmount))
                                    {
                                        varFinalAmount = Convert.ToDecimal(varValue) - Convert.ToDecimal(AdvanceAmount);
                                        //dtCheckAdv.Rows[i]["Current balance"] = 0;
                                        grdSupplierPayment.Rows[j].Cells["clmPaymentAmount"].Value = varFinalAmount.ToString("##0.00");
                                        grdSupplierPayment.Rows[j].Cells["clmTobePaid"].Value = varFinalAmount.ToString("##0.00");
                                        grdSupplierPayment.Rows[j].Cells["clmPayAmount"].Value = varFinalAmount.ToString("##0.00");
                                        varTotAmount = AdvanceAmount;
                                        dtAdvance.Rows.Add(Convert.ToInt32(varAdvanceID), Convert.ToInt32(varID), 0, varFinalAmount, AdvanceAmount, varFixedAdvance, dtAdvance.Rows.Count + 1);
                                        AdvanceAmount = 0;
                                    }
                                    else
                                    {
                                        CurrentAdvace = AdvanceAmount - Convert.ToDecimal(varValue);
                                        //dtCheckAdv.Rows[i]["Current balance"] = CurrentAdvace;
                                        RemainingAmnt = AdvanceAmount - CurrentAdvace;
                                        varAdvAmount = RemainingAmnt;
                                        varFinalAmount = 0;
                                        grdSupplierPayment.Rows[j].Cells["clmPaymentAmount"].Value = varFinalAmount.ToString("##0.00");
                                        grdSupplierPayment.Rows[j].Cells["clmTobePaid"].Value = varFinalAmount.ToString("##0.00");
                                        grdSupplierPayment.Rows[j].Cells["clmPayAmount"].Value = varFinalAmount.ToString("##0.00");
                                        dtAdvance.Rows.Add(Convert.ToInt32(varAdvanceID), Convert.ToInt32(varID), CurrentAdvace, varFinalAmount, RemainingAmnt, varFixedAdvance, dtAdvance.Rows.Count + 1);
                                        AdvanceAmount = CurrentAdvace;
                                    }
                                    varAmountCalc = varTotAmount + varAdvAmount;
                                    varFinalTotAmnt = varFinalTotAmnt + varAmountCalc;
                                    varAdvAmount = 0;
                                    varTotAmount = 0;
                                }

                            }
                        }
                    }
                    varAdvanceAmnt = Convert.ToDecimal(varFinalTotAmnt);

                    //for (int i = 0; i < grdSupplierPayment.Rows.Count; i++)
                    //{
                    //varPurchaseID = Convert.ToInt32(grdSupplierPayment.Rows[i].Cells["clmID"].Value);
                    //varSumRequestQty = dtAdvance.AsEnumerable()
                    //                        //.Where(y => y.Field<int>("PURID").Equals(varPurchaseID))
                    //                                    .Sum(x => x.Field<decimal>("Payed Amount")).ToString();

                    var sumOfAdvance = (from r in dtAdvance.AsEnumerable()
                                        group r by r["PURID"] into g
                                        select new
                                        {
                                            PURID = g.Key,
                                            TotalAdvanceAmnt = g.Sum(x => x.Field<decimal>("Payed Amount"))
                                        }).ToList();

                    for (int j = 0; j < sumOfAdvance.Count(); j++)
                    {
                        for (int i = 0; i < grdSupplierPayment.Rows.Count; i++)
                        {
                            var key = sumOfAdvance[j];
                            var ID = key.PURID;
                            if (Convert.ToString(ID) == Convert.ToString(grdSupplierPayment.Rows[i].Cells["clmID"].Value))
                            {
                                grdSupplierPayment.Rows[i].Cells["clmAdvanceAmnt"].Value = key.TotalAdvanceAmnt;
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

        public void udfntooltiphide()
        {
            try
            {
                tpcompanyname.Active = false;
                tpSuppliername.Active = false;
                tpIssueMode.Active = false;
                tpbank.Active = false;
                tpIssueMode.Active = false;
                tpChequeNo.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PAY_SupplierPayment_KeyDown(object sender, KeyEventArgs e)
        
{
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    LV_Supplier.Visible = false;
                    udfntooltiphide();
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
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

        public void udfnAddAdvance()
        {
            try
            {
                varEditFlag = 1;
                MainForm.objPAY_Advance_Popup = new PAY_ADV();
                MainForm.objPAY_Advance_Popup.ShowDialog();
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
        public void udfnGeneralSettingsList()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGeneralSettingList(0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            varNeftAmount = Convert.ToDecimal(objDs.Tables[0].Rows[0]["GS_NEFT_Amount"]);
                            varRTGSMinLimit = Convert.ToDecimal(objDs.Tables[0].Rows[0]["RTGSMinLimit"]);
                            varCashPaymentLimit = Convert.ToDecimal(objDs.Tables[0].Rows[0]["RTGSMinLimit"]);
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
        public void udfnEditLoad()
        {
            try
            {
                if (varSupplierPaymentID != 0)
                {
                    varEditFlag = 1;
                    varApplyFlag = 1;
                    varCreatemodeFlag = 1;
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objspservice = new SPDataService();
                    SPDataService objdserv = new SPDataService();
                    TRN_Supplier_Payment objTRN_Supplier_Payment = new TRN_Supplier_Payment();
                    objTRN_Supplier_Payment.ViewType = 2;
                    objTRN_Supplier_Payment.paraPYID = varSupplierPaymentID; 
                    objDs = objdserv.udfnGetSupplierPayment(objTRN_Supplier_Payment);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbConcern.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_COMID"]);
                            dpDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Date"]);
                            txtTransactionNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_No"]);
                            txtsuppliername.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SP_Name"]);
                            lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_SPID"]);
                            lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_SPSCID"]);
                            udfnsupplierLoad();
                            txtRemark.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_Remarks"]);
                            udfnPaymentDropDown();
                            cmbPaymentmode.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["Payment Mode"]);
                            txtChequeLimitDays.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ChequeLimitDays"]);
                            if (Convert.ToInt16(cmbPaymentmode.SelectedValue) != 346)
                            {
                                dpChequeDate.Text =Convert.ToString( DateTime.ParseExact(objDs.Tables[0].Rows[0]["PAY_ChequeDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                            }
                            txtChequeNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_ChequeNo"]);
                            lblSubtotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_Subtotal"]);
                            lblAdvance.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_Advance"]);
                            lblGrandTotal.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_Total"]);
                            
                            udfnBankDropDown();
                            cmbBank.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["PAY_CMBNK_ID"]);
                            cmbIssueMode.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["ModeOfIssue"]);
                            txtIssue.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ModeOfIssue_Details"]);
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                grdSupplierPayment.Rows.Add(0, Convert.ToString(objDs.Tables[1].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[1].Rows[i]["Voucher Date"]), Convert.ToString(objDs.Tables[1].Rows[i]["PUR_VoucherNo"]), Convert.ToString(objDs.Tables[1].Rows[i]["PUR_InvoiceDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["PUR_InvoiceNo"]), Convert.ToString(objDs.Tables[1].Rows[i]["Filing Status"]),
                                    Convert.ToDecimal(objDs.Tables[1].Rows[i]["Taxable Amount"]),
                                    
                                    Convert.ToDecimal(objDs.Tables[1].Rows[i]["Tax Amount"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["Addition"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["Dedution"]), 
                                    Convert.ToDecimal(objDs.Tables[1].Rows[i]["Invoice Amount"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["Outstading Amount"]),
                                  Convert.ToDecimal(objDs.Tables[1].Rows[i]["Disc Amount"]),
                                    Convert.ToDecimal(objDs.Tables[1].Rows[i]["Purchase Return Adjustment"]),
                                    Convert.ToDecimal(objDs.Tables[1].Rows[i]["Advance Amount"]),
                                    Convert.ToDecimal(objDs.Tables[1].Rows[i]["ToBePaid"]), 
                                    Convert.ToDecimal(objDs.Tables[1].Rows[i]["PAYI_PayAmount"]),
                                    Convert.ToDecimal(objDs.Tables[1].Rows[i]["Balance"]),  
                                    Convert.ToInt32(objDs.Tables[1].Rows[i]["ID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["ID1"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["PAYIID"]), Convert.ToString(objDs.Tables[1].Rows[i]["status"]), Convert.ToString(objDs.Tables[1].Rows[i]["Return Status"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["Disc ID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["PAYI_PayAmount"]), Convert.ToString(objDs.Tables[1].Rows[i]["Entered By"]), Convert.ToString(objDs.Tables[1].Rows[i]["Approved By"]), Convert.ToString(objDs.Tables[1].Rows[i]["CNID"]), Convert.ToString(objDs.Tables[1].Rows[i]["Flag"]));
                                 
                                dtPayment.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["ID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["PAYI_PayAmount"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["PAYI_STSID"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["PAYIID"]), 0, 0, Convert.ToDecimal(objDs.Tables[1].Rows[i]["Disc Amount"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["Disc ID"]), Convert.ToString(objDs.Tables[1].Rows[i]["Invoice No"]),Convert.ToDecimal(objDs.Tables[1].Rows[i]["Addition"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["Dedution"]), 
                                     Convert.ToDecimal(objDs.Tables[1].Rows[i]["ToBePaid"]),
                                     Convert.ToDecimal(objDs.Tables[1].Rows[i]["Balance"]),
                                     Convert.ToDecimal(objDs.Tables[1].Rows[i]["TaxableAmnt"]),
                                     Convert.ToDecimal(objDs.Tables[1].Rows[i]["TaxAmnt"]),
                                     Convert.ToDecimal(objDs.Tables[1].Rows[i]["RetAdjustAmnt"]),
                                     Convert.ToDecimal(objDs.Tables[1].Rows[i]["InvoiceAmount"]),
                                     Convert.ToString(objDs.Tables[1].Rows[i]["InvoiceDate"]) ,
                                      Convert.ToDecimal(objDs.Tables[1].Rows[i]["Outstading Amount"])
                                    ); 
                                grdSupplierPayment.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmVoucherDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdSupplierPayment.Columns["clmInvoiceDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdSupplierPayment.Columns["clmTaxableAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmTaxAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmInvoiceAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmTobePaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmReturnAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Rows[i].Cells["clmcheck"].Value = true;

                                if (Convert.ToString(objDs.Tables[1].Rows[i]["Filing Status"]) == "F")
                                {
                                    grdSupplierPayment.Rows[i].Cells["clmFilingStatus"].Style.BackColor = Color.LightGreen;
                                    grdSupplierPayment.Rows[i].Cells["clmFilingStatus"].Style.ForeColor = Color.Black;
                                }
                                else if (Convert.ToString(objDs.Tables[1].Rows[i]["Filing Status"]) == "NF")
                                {
                                    grdSupplierPayment.Rows[i].Cells["clmFilingStatus"].Style.BackColor = Color.Red;
                                    grdSupplierPayment.Rows[i].Cells["clmFilingStatus"].Style.ForeColor = Color.White;
                                }
                            }
                        }
                        if(objDs.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                            {
                                dtAdvance.Rows.Add(Convert.ToInt32(objDs.Tables[2].Rows[i]["PAYAD_ADID"]), Convert.ToInt32(objDs.Tables[2].Rows[i]["PAYAD_PURID"]), Convert.ToDecimal(objDs.Tables[2].Rows[i]["AD_CurrentBalance"]), 0, Convert.ToDecimal(objDs.Tables[2].Rows[i]["PAYAD_PayedAdvanceAmnt"]), Convert.ToDecimal(objDs.Tables[2].Rows[i]["AD_Amount"]), dtAdvance.Rows.Count+1);
                            }
                        }
                        if (objDs.Tables[3].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[3].Rows.Count; i++)
                            {
                                dtCheckAdv.Rows.Add(Convert.ToDecimal(objDs.Tables[3].Rows[i]["Advance Amount"]), objDs.Tables[3].Rows[i]["ADID"], Convert.ToDecimal(objDs.Tables[3].Rows[i]["Advance Amount"]));
                            }
                        }
                    }
                    cmbConcern.Enabled = false;
                    dpDate.Enabled = false;
                    txtTransactionNo.Enabled = false;
                    txtTransactionNo.ReadOnly = true;
                    txtsuppliername.ReadOnly = true;
                    txtsuppliername.Enabled = false;
                    cmbIssueMode.Enabled = false;
                    txtIssue.ReadOnly = true;
                    txtIssue.Enabled = false;
                    txtChequeLimitDays.Enabled = false; 
                    udfnSubtotalCalc();
                }
                LV_Supplier.Visible = false; 
                grdSupplierPayment.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }
    }
}
