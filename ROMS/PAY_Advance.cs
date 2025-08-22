using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ROMS
{
    //Created by:-Sathish;Created on:-08/08/2023
    public partial class PAY_Advance : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataSet objDs = new DataSet();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpSupplier = new ToolTip();
        private ToolTip tpReceipt = new ToolTip();
        private ToolTip tpCheque = new ToolTip();
        private ToolTip tpIssue = new ToolTip();
        private ToolTip tpAmount = new ToolTip();
        public string varcomid = "0";
        public string varSupplierID = "", varSupplierScheduleID = "", varSupplierName = "";
        public int varstatus; 
        public int PbStatus=0;
        public int varUpdate = 0;
        public decimal varNeftAmount = 0;
        public int pbADID = 0,varDateChange=0, varClose = 0, varCloseFlag=0;
        bool varVoucherSkip = false;
        public PAY_Advance()
        {
            InitializeComponent();
            // Timer ticked after 2 seconds, so load the other form
            timer = new Timer();
            timer.Interval = 2; // 2 seconds
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
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
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
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
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(12, Convert.ToInt32(cmbConcern.SelectedValue), MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                cmbPaymentmode.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbPaymentmode.ValueMember = "ID";
                            cmbPaymentmode.DisplayMember = "Payment Mode";
                            cmbPaymentmode.DataSource = objDT.Tables[0];
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = "";int ViewType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Advance Creation";
                }
                else
                {
                    varoriginator = "Advance Updation";
                    ViewType = 1;
                }
                Model.TRN_Advance objTRN_Advance = new Model.TRN_Advance();
                objTRN_Advance.ViewType = ViewType;
                objTRN_Advance.paraAdvanceId = pbADID;
                objTRN_Advance.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_Advance.paraAdvanceDate = dpAdvanceDate.Text;
                objTRN_Advance.paraSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_Advance.paraScheduleId = Convert.ToInt32(lblschedule.Text);
                objTRN_Advance.ParaAmt = Convert.ToDecimal(txtAmount.Text.Trim());
                if (cmbPaymentType.Visible == true)
                {
                    objTRN_Advance.paraPaymentType = Convert.ToInt32(cmbPaymentType.SelectedValue);
                    objTRN_Advance.paraChequeDate = dtChequeDate.Text;
                    objTRN_Advance.paraChequeNo = txtChequeNo.Text.Trim();
                }
                if(Convert.ToInt32(cmbPaymentmode.SelectedValue)!=88)
                {
                    objTRN_Advance.paraBankId =Convert.ToInt32(cmbPaymentmode.SelectedValue);
                    objTRN_Advance.paraPaymentMode = 89;
                }
                else
                {
                    objTRN_Advance.paraBankId = 0;
                    objTRN_Advance.paraPaymentMode = Convert.ToInt32(cmbPaymentmode.SelectedValue);
                }
                objTRN_Advance.paraModeOfIssue =Convert.ToInt32(cmbIssueMode.SelectedValue);
                if(Convert.ToInt32(cmbIssueMode.SelectedValue)==-1)
                {
                    objTRN_Advance.paraStatusID = 74;
                }
                else
                {
                    objTRN_Advance.paraIssueDetails = txtIssue.Text.Trim();
                    objTRN_Advance.paraStatusID = 78;
                }
                objTRN_Advance.paraRemarks = txtRemark.Text.Trim();
                objTRN_Advance.paraOriginator = varoriginator;
                varResult = objspservice.udfnAdvance(objTRN_Advance);
                objspservice.CloseConnection();
                //varResult = objspservice.udfnAdvance(ViewType, pbADID,Convert.ToInt32(cmbConcern.SelectedValue),dpAdvanceDate.Text,Convert.ToInt32(lblSupplierCode.Text),Convert.ToInt32(lblschedule.Text), Convert.ToDecimal(txtAmount.Text),varoriginator,0);
                //objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    string varAmountInWords = "";
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        if(txtAmount.Text.Trim()!="")
                        {
                            decimal varMRP = Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                            txtAmount.Text = string.Format("{0:0}", varMRP);
                            int varAmount = Convert.ToInt32(txtAmount.Text);
                            varAmountInWords = Currency.NumbersToWords(varAmount);
                        }
                        string ADID = "0";
                        if (pbADID == 0)
                        {
                            ADID = varvalue[2];
                        }
                        else
                        {
                            ADID = Convert.ToString(pbADID);
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
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PAY_Advance_Receipt.rpt");
                            varHeader = "Advance Receipt";

                            objBillreport.SetParameterValue("paraAdvanceId", Convert.ToInt32(ADID), objBillreport.Subreports[0].Name.ToString());
                            objBillreport.SetParameterValue("paraAmountName", Convert.ToString(varAmountInWords), objBillreport.Subreports[0].Name.ToString());
                            objBillreport.SetParameterValue("paraAdvanceId", Convert.ToInt32(ADID), objBillreport.Subreports[1].Name.ToString());
                            objBillreport.SetParameterValue("paraAmountName", Convert.ToString(varAmountInWords), objBillreport.Subreports[1].Name.ToString());
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
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                    MainForm.objPAY_AdvanceList.udfnList();
                    varUpdate = 1;
                    udfnclose();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnSave.Focus();
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epAdvance.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select company", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtSupplier.Text).Trim() == "")
                {
                    epAdvance.SetError(txtSupplier, "Please enter supplier.");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSupplier.ShowAlways = true;
                    tpSupplier.Show("Please enter supplier.", txtSupplier, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtAmount.Text).Trim() == "")
                {
                    epAdvance.SetError(txtAmount, "Please enter amount.");
                    txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAmount.ShowAlways = true;
                    tpAmount.Show("Please enter amount.", txtAmount, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    if(Convert.ToDecimal(txtAmount.Text)==0)
                    {
                        epAdvance.SetError(txtAmount, "Please enter valid amount.");
                        txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpAmount.ShowAlways = true;
                        tpAmount.Show("Please enter valid amount.", txtAmount, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtReceiptNo.Text).Trim() == "")
                {
                    epAdvance.SetError(txtReceiptNo, "Please enter receipt no.");
                    txtReceiptNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReceipt.ShowAlways = true;
                    tpReceipt.Show("Please enter receipt no.", txtReceiptNo, 5000);
                    blnErrorFlag = true;
                }
                if(txtChequeNo.Visible==true)
                {
                    if (Convert.ToString(txtChequeNo.Text).Trim() == "")
                    {
                        epAdvance.SetError(txtChequeNo, "Please enter cheque no.");
                        txtChequeNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCheque.ShowAlways = true;
                        tpCheque.Show("Please enter cheque no.", txtChequeNo, 5000);
                        blnErrorFlag = true;
                    }
                }
                if(Convert.ToInt32(cmbIssueMode.SelectedValue)!=-1)
                {
                    if (Convert.ToString(txtIssue.Text).Trim() == "")
                    {
                        epAdvance.SetError(txtIssue, "Please enter mode of issue");
                        txtIssue.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIssue.ShowAlways = true;
                        tpIssue.Show("Please enter mode of issue", txtIssue, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (blnErrorFlag == false)
                {
                    epAdvance.Clear();
                    udfnTooltipHide();
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
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
        private void btnSave_Enter(object sender, EventArgs e)
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
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Leave(object sender, EventArgs e)
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
        public void udfnclose()
        {
            try
            {
                if (varUpdate==0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objPAY_AdvanceList.Show();
                        MainForm.objPAY_AdvanceList.udfnList();
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
             
        }
        public void udfnTooltipHide()
        {
            try
            {
                tpConcern.Active = false;
                tpSupplier.Active = false;
                tpReceipt.Active = false;
                tpCheque.Active = false;
                tpIssue.Active = false;
                tpAmount.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnTooltipHide();
                udfnclose();
                MainForm.objPAY_AdvanceList.udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnClose_Enter(object sender, EventArgs e)
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
        private void btnClose_Leave(object sender, EventArgs e)
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
                   dpAdvanceDate.Focus();
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
                    epAdvance.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    epAdvance.Clear();
                    cmbConcern.BackColor = Color.White;
                }
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
                txtAmount.Text = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                udfnCheckAmt();
                if (txtAmount.Text.Trim() != "")
                {
                    decimal varMRP = Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                    string varAmt = string.Format("{0:0}", varMRP);
                    int varAmount = Convert.ToInt32(varAmt);
                    txtAmountInWords.Text = Currency.NumbersToWords(varAmount);
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
                    cmbPaymentmode.Focus();
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

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAmount.Focus();
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
                    epAdvance.SetError(txtSupplier, "Please enter supplier.");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSupplier.ShowAlways = true;
                    tpSupplier.Show("Please enter supplier.", txtSupplier, 5000);
                }
                else
                {
                    epAdvance.Clear();
                    txtSupplier.BackColor = Color.White;
                    tpSupplier.Active = false;
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
                txtAmount.Focus();
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
                    txtAmount.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PAY_Advance_KeyDown(object sender, KeyEventArgs e)
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
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpAdvanceDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
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

        private void DpAdvanceDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //udfnvoucherload(sender, e);
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
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    txtAmount.Focus();
                }
                udfnsupplierLoad();
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
                //pbSupplierpend = 0;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                varSupplierID = lblSupplierCode.Text;
                varSupplierScheduleID = lblschedule.Text;
                varSupplierName = txtSupplier.Text;
                if (lblSupplierCode.Text.Length > 0)
                {
                    int varReturnApplicable = 0, varReturnType = 0;
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
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
                            lblContactNo.Text = objDs.Tables[0].Rows[0]["Mobile No"].ToString();
                            lblEmailId.Text = objDs.Tables[0].Rows[0]["Email"].ToString();
                        }
                        if (objDs.Tables[8].Rows.Count > 0)
                        {
                            txtBankname.Text = objDs.Tables[8].Rows[0]["SP_BankName"].ToString();
                            txtBankShortName.Text = objDs.Tables[8].Rows[0]["SP_BankShortName"].ToString();
                            txtbranchname.Text = objDs.Tables[8].Rows[0]["SP_BranchName"].ToString();
                            txtAccName.Text = objDs.Tables[8].Rows[0]["SP_AccountName"].ToString();
                            txtAccno.Text = objDs.Tables[8].Rows[0]["SP_AccNo"].ToString();
                            txtIFScode.Text = objDs.Tables[8].Rows[0]["SP_IFSC"].ToString();
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                //In this Event call only on Form Load Event ==> concern changed wise show popup message multiple times not handled
                udfnvoucherload(sender, e);
                udfnPaymentMode();
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
                lblSupplierCode.Text = "";
                lblschedule.Text = "";
                txtSupplier.Text = "";
                txtAmount.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PAY_Advance_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm objMainForm = new MainForm();
                objMainForm.udfnGetDefaultCompany();
                udfnCmbConcern();
                udfnPaymentMode();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID IN (0,71) AND MSTID NOT IN (0)", "MST_DisplayText,MSTID", cmbIssueMode, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbIssueMode.SelectedIndex = 0;
                //DataBind objDataBind = new DataBind();
                //objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=31 AND MSTID IN (88,89)", "MST_DisplayText,MSTID", cmbPaymentmode, "", "MST_DisplayText", "MSTID"); objDataBind = null;
                udfnGeneralSettingsList();
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                    dpAdvanceDate.MinDate = MainForm.pbFYStartDate;
                    dpAdvanceDate.MaxDate = MainForm.pbCurrentDate;
                    varDateChange = 0;
                    if (btnSave.Text == "Update")
                    {
                        this.ActiveControl = cmbIssueMode;
                        udfnEdit();
                    }
                    else
                    {
                        this.ActiveControl = txtSupplier;
                        dtChequeDate.MinDate = MainForm.pbCurrentDate;
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
        public void udfnEdit()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                Model.TRN_Advance objTRN_Advance = new Model.TRN_Advance();
                objTRN_Advance.ViewType = 1;
                objTRN_Advance.paraAdvanceId = pbADID;
                objDs = objdserv.udfnAdvanceList(objTRN_Advance);
                objdserv.CloseConnection();
                int varSource = 0;
                //objDs = objdserv.udfnAdvanceList(1, pbADID, 0,"","",0, 0, 0);
                //objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        MainForm.objPAY_AdvanceList.picLoader.Visible = false;
                        MainForm.objPAY_AdvanceList.picLoader.SendToBack();
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbConcern.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["AD_COMID"]);
                            txtReceiptNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AD_ReceiptNo"]);
                            dpAdvanceDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AD_AdvanceDate"]);
                            dpEntryDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AD_EntryDate"]);
                            txtSupplier.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Supplier"]);
                            lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SPID"]);
                            lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SPSCID"]);
                            txtAmount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AD_Amount"]);
                            txtAmount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AD_Amount"]);
                            txtCurrentBalance.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Current Balance"]);
                            varSource = Convert.ToInt32(objDs.Tables[0].Rows[0]["Source"]);
                            if (Convert.ToString(objDs.Tables[0].Rows[0]["AD_PaymentMode"]) == "88")
                            {
                                cmbPaymentmode.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["AD_PaymentMode"]);
                            }
                            else
                            {
                                cmbPaymentmode.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["AD_CMBNK_ID"]);
                            }
                            if (Convert.ToString(objDs.Tables[0].Rows[0]["AD_PaymentType"]) != "0")
                            {
                                cmbPaymentType.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["AD_PaymentType"]);
                                dtChequeDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AD_ChequeDate"]);
                                txtChequeNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AD_ChequeNo"]);
                            }
                            cmbIssueMode.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["AD_ModeOfIssue"]);
                            txtIssue.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AD_ModeOfIssue_Details"]);
                            txtRemark.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AD_Remarks"]);
                            if (txtAmount.Text.Trim() != "")
                            {
                                decimal varMRP = Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                                string varAmt = string.Format("{0:0}", varMRP);
                                int varAmount = Convert.ToInt32(varAmt);
                                txtAmountInWords.Text = Currency.NumbersToWords(varAmount);
                            }
                            LV_Supplier.Visible = false;
                            udfnsupplierLoad();
                        }
                    }
                }
                /* 1- From GRN, 2 - Manual, 3 - From Supplier*/
                if (varSource == 2)
                {
                    if (PbStatus == 74)
                    {
                        txtSupplier.Enabled = false;
                        cmbConcern.Enabled = false;
                        cmbIssueMode.Focus();
                    }
                    if (PbStatus == 80)
                    {
                        txtSupplier.Enabled = false;
                        cmbConcern.Enabled = false;
                        cmbIssueMode.Focus();
                        grbIssuedDetails.Enabled = false;
                    }

                    if (PbStatus == 75)
                    {
                        cmbConcern.Enabled = false;
                        dpAdvanceDate.Enabled = false;
                        txtSupplier.Enabled = false;
                        txtAmount.Enabled = false;
                        btnSave.Enabled = false;
                        grbPayment.Enabled = false;
                        txtRemark.Enabled = false;
                        grbSupplierDetails.Enabled = false;
                        grbBankDetails.Enabled = false;
                        grbIssuedDetails.Enabled = false;
                        this.ActiveControl = btnClose;
                        btnClose.Focus();
                    }
                }
                else {
                    cmbConcern.Enabled = false;
                    dpAdvanceDate.Enabled = false;
                    txtSupplier.Enabled = false;
                    txtAmount.Enabled = false;
                    btnSave.Enabled = false;
                    grbPayment.Enabled = false;
                    txtRemark.Enabled = false;
                    grbSupplierDetails.Enabled = false;
                    grbBankDetails.Enabled = false;
                    grbIssuedDetails.Enabled = false;
                    this.ActiveControl = btnClose;
                    btnClose.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnvoucherload(object sender, EventArgs e)
        {
            try
            {
                if (pbADID == 0)
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        if (varDateChange == 0)
                        {
                            string vardate = "", varResult = "";
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            DataService objDservice = new DataService();
                            vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpAdvanceDate.Text + "',103)");
                            varResult = objspdservice.udfngetVoucherNo("216", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                            objspdservice.CloseConnection();
                            string[] parts = varResult.Split('~');
                            string grnno = parts[0];
                            if (grnno != "")
                            {
                                txtReceiptNo.Text = grnno;
                            }
                            else
                            {
                                udfnvoucheradd(sender, e);
                            }
                        }
                    }
                    else
                    {
                        txtReceiptNo.Text = "";
                    }
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
            udfnCheckAmt();
        }
        public void udfnShowHideTextBoxes()
        {
            try
            {
                txtDPaymentType.Visible = false;
                cmbPaymentType.Visible = false;
                udfnShowHideTextBoxes2ndlevel();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnShowHideTextBoxes2ndlevel()
        {
            try
            {
                txtChequeDate.Visible = false;
                txtChequeNo.Visible = false;
                dtChequeDate.Visible = false;
                txtDChequeNo.Visible = false;
                txtDChequeNo.Text = "";
                txtChequeDate.Text = "";
                txtChequeNo.Text = "";
                dtChequeDate.Value = MainForm.pbCurrentDate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCheckAmt()
        {
            try
            {
                udfnShowHideTextBoxes();
                if (Convert.ToInt32(cmbPaymentmode.SelectedValue) != 88 && (Convert.ToDecimal(txtAmount.Text) < varNeftAmount))
                {
                    txtDPaymentType.Visible = true;
                    cmbPaymentType.Visible = true;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=32 AND MSTID IN(91,94)", "MST_DisplayText,MSTID", cmbPaymentType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
                else if ((Convert.ToDecimal(txtAmount.Text) >= varNeftAmount) && Convert.ToInt32(cmbPaymentmode.SelectedValue) != 88)
                {
                    txtDPaymentType.Visible = true;
                    cmbPaymentType.Visible = true;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=32 AND MSTID IN(91,93)", "MST_DisplayText,MSTID", cmbPaymentType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
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
                txtAdvanceAmt.Text = txtAdvanceAmt.Text;
                cmbPaymentmode.BackColor = Color.LemonChiffon;
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
                    if (cmbPaymentType.Visible == true)
                    {
                        cmbPaymentType.Focus();
                    }
                    else
                    {
                        cmbIssueMode.Focus();
                    }
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

        private void CmbPaymentType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPaymentType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    dtChequeDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPaymentType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPaymentType.BackColor = Color.White;
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
                if (e.KeyCode==Keys.Enter)
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

        private void DtChequeDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dtChequeDate.BackColor = Color.LemonChiffon;
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
                if(e.KeyCode==Keys.Enter)
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
                dtChequeDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbIssueMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(cmbIssueMode.SelectedValue)==-1)
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
            if(Convert.ToInt32(cmbIssueMode.SelectedValue)==222)
            {
                txtTypeName.Visible = true;
                txtIssue.Visible = true;
                txtTypeName.Text = "Courier No.";
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
                    if(txtIssue.Visible==true)
                    {
                        txtIssue.Focus();
                    }
                    else
                    {
                        txtRemark.Focus();
                    }
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

        private void TxtIssue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
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

        private void PAY_Advance_Leave(object sender, EventArgs e)
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

        private void CmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                udfnShowHideTextBoxes2ndlevel();
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 91)
                {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDChequeNo.Text = "Cheque No.";
                    txtChequeDate.Text = "Cheque Date";
                }
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 92)
                {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDChequeNo.Text = "DD No.";
                    txtChequeDate.Text = "DD Date";
                }
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 97 || Convert.ToInt32(cmbPaymentType.SelectedValue) == 98)
                {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDChequeNo.Text = "UTR/Ref No.";
                    txtChequeDate.Text = "Transaction Date";
                }
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 94 && Convert.ToInt32(cmbPaymentmode.SelectedValue) != 88)
                {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDChequeNo.Text = "Cheque No.";
                    txtChequeDate.Text = "Cheque Date";
                }
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 93 && Convert.ToInt32(cmbPaymentmode.SelectedValue) != 88)
                {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDChequeNo.Text = "Cheque No.";
                    txtChequeDate.Text = "Cheque Date";
                }
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 96 && Convert.ToInt32(cmbPaymentmode.SelectedValue) == 90)
                {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDChequeNo.Text = "UTR/Ref No.";
                    txtChequeDate.Text = "Transaction Date";
                }
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 95 && Convert.ToInt32(cmbPaymentmode.SelectedValue) == 90)
                {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDChequeNo.Text = "UTR/Ref No.";
                    txtChequeDate.Text = "Transaction Date";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            
        }

        private void TxtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
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

        public void udfnvoucheradd(object sender, EventArgs e)
        {
            try
            {
                varDateChange = 1;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                if (varDateChange == 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(128);
                    objDServ.CloseConnection();
                    txtReceiptNo.Text = "";
                    if (varVoucherSkip == false)
                    {
                        MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 39;
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
    }
}
