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

namespace ROMS
{
    public partial class PAY_SupplierPayment : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataSet objDs = new DataSet();

        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpSuppliername = new ToolTip();
        public int varSupplierPaymentID = 0, VarPrevSupplierid = 0;
        public string varSupplierID = "", varSupplierScheduleID = "";
        public string varSupplierName="";
        public Decimal varNeftAmount = 0;
        public int id = 0;

        public PAY_SupplierPayment()
        {
            InitializeComponent();
        }
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    objMR_Supplier.ViewType = 30;
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
                udfnShowHideTextBoxes();
                if (Convert.ToInt32(cmbPaymentmode.SelectedValue) == 89 && (Convert.ToDecimal(lblGrandTotal.Text) < varNeftAmount))
                {
                    txtDPaymentType.Visible = true;
                    cmbPaymentType.Visible = true;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=32 AND MSTID IN(91,94)", "MST_DisplayText,MSTID", cmbPaymentType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
                else if((Convert.ToDecimal(lblGrandTotal.Text)>=varNeftAmount) && Convert.ToInt32(cmbPaymentmode.SelectedValue) == 89)
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
        public void udfnShowHideTextBoxes() {
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
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 97 || Convert.ToInt32(cmbPaymentType.SelectedValue) == 98) {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDChequeNo.Text = "UTR/Ref No.";
                    txtChequeDate.Text = "Transaction Date";
                }
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 94 && Convert.ToInt32(cmbPaymentmode.SelectedValue) == 89) {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDChequeNo.Text = "Cheque No.";
                    txtChequeDate.Text = "Cheque Date";
                }
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 93 && Convert.ToInt32(cmbPaymentmode.SelectedValue) == 89)
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
        private void PAY_SupplierPayment_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbConcern();
                ClearSupplier();
                dpDate.MinDate = MainForm.pbFYStartDate;
                dpDate.MaxDate = MainForm.pbCurrentDate;
                dtChequeDate.MinDate = MainForm.pbFYStartDate;
                dtChequeDate.MaxDate = MainForm.pbCurrentDate;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=31 AND MSTID IN (88,89)", "MST_DisplayText,MSTID", cmbPaymentmode, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                udfnGeneralSettingsList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
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
        public void udfnCmbPaymentMode()
        {
            try
            {
                //SPDataService objdserv = new SPDataService();
                //DataSet objDT = new DataSet();
                //Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                //objMR_Supplier.ViewType = 16;
                //objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                //objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                //objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                //objDT = objdserv.udfnSupplierList(objMR_Supplier);
                //objdserv.CloseConnection();
                //cmbPaymentmode.DataSource = null;
                //if (objDT != null)
                //{
                //    if (objDT.Tables.Count > 0)
                //    {
                //        if (objDT.Tables[9].Rows.Count > 0)
                //        {
                //            cmbPaymentmode.ValueMember = "SPP_PaymentMode";
                //            cmbPaymentmode.DisplayMember = "MST_DisplayText";
                //            cmbPaymentmode.DataSource = objDT.Tables[9];
                //        }
                //    }
                //}
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
                    udfnCmbPaymentMode();
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
                        //if (objDs.Tables[1].Rows.Count > 0)
                        //{
                        //    if (objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString() != "")
                        //    { lblSalesmanName.Text = "Salesman Name - " + objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString(); }
                        //    if (objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString() != "")
                        //    { lblMobileNo.Text = "Mobile No. - " + objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString(); }
                        //    if (objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString() != "")
                        //    { lblWhatsAppNo.Text = "WhatsApp No. - " + objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString(); }
                        //}
                        if (objDs.Tables[8].Rows.Count > 0)
                        {
                            lblBankName.Text = objDs.Tables[8].Rows[0]["SP_BankName"].ToString();
                            lblBranchName.Text = objDs.Tables[8].Rows[0]["SP_BranchName"].ToString();
                            lblBAccName.Text = objDs.Tables[8].Rows[0]["SP_AccountName"].ToString();
                            lblBAccNo.Text = objDs.Tables[8].Rows[0]["SP_AccNo"].ToString();
                            lblBIFSCode.Text = objDs.Tables[8].Rows[0]["SP_IFSC"].ToString();
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
                                grdSupplierPayment.Rows.Add(0, Convert.ToString(objDs.Tables[0].Rows[i]["S.No."]),Convert.ToString(objDs.Tables[0].Rows[i]["Voucher Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Voucher No."]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice No."]), Convert.ToString(objDs.Tables[0].Rows[i]["Entered By"]), Convert.ToString(objDs.Tables[0].Rows[i]["Approved By"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Taxable Amount"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Tax Amount"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Invoice Amount"]), Convert.ToString(objDs.Tables[0].Rows[i]["Advance"]), Convert.ToString(objDs.Tables[0].Rows[i]["Purchase Return Adjustment"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["Pay Amount"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["ID"]));
                                grdSupplierPayment.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmVoucherDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdSupplierPayment.Columns["clmInvoiceDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdSupplierPayment.Columns["clmTaxableAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmTaxAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmInvoiceAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmPayAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierPayment.Columns["clmReturnAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                if(Convert.ToInt32(objDs.Tables[0].Rows[i]["Flag"])==0)
                                {
                                    grdSupplierPayment.Rows[i].Cells["clmcheck"].Value = true;
                                    grdSupplierPayment.Rows[i].Cells["clmPayAmount"].ReadOnly = false;
                                    grdSupplierPayment.Rows[i].Cells["clmPayAmount"].Style.BackColor = Color.PaleGreen;
                                    decimal GrandTot = 0, Total = 0;
                                    GrandTot = Convert.ToDecimal(lblGrandTotal.Text);
                                    Total = GrandTot + Convert.ToDecimal(grdSupplierPayment.Rows[i].Cells["clmPayAmount"].Value);
                                    lblGrandTotal.Text = Total.ToString("#,##0.00");
                                }
                                else
                                {
                                    grdSupplierPayment.Rows[i].Cells["clmcheck"].Value = false;
                                    grdSupplierPayment.Rows[i].Cells["clmPayAmount"].ReadOnly = true;
                                    grdSupplierPayment.Rows[i].Cells["clmPayAmount"].Style.BackColor = Color.LightGray;
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
                    if (cmbPaymentType.Visible == true)
                    {
                        cmbPaymentType.Focus();
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
                if (e.KeyCode == Keys.Enter)
                {
                    if(dtChequeDate.Visible==true)
                    {
                        dtChequeDate.Focus();
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
                dtChequeDate.BackColor = Color.White;
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
                        txtTransactionno.Text = varvalue[0];
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(75);
                        objDServ.CloseConnection();
                        txtTransactionno.Text = "";
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
                    txtTransactionno.Text = "";
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
                    cmbPaymentmode.Focus();
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
                    btnSave.Focus();
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

        private void GrdSupplierPayment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdSupplierPayment.Rows.Count>0)
                {
                    if(Convert.ToBoolean(grdSupplierPayment.Rows[e.RowIndex].Cells["clmcheck"].Value)==true)
                    {
                        grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].ReadOnly = false;
                        grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].Style.BackColor = Color.PaleGreen;
                    }
                    else
                    {
                        grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].ReadOnly = true;
                        grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].Style.BackColor = Color.LightGray;
                    }

                }
                if (Convert.ToBoolean(grdSupplierPayment.Rows[e.RowIndex].Cells["clmcheck"].Value) == true)
                {
                    decimal GrandTot = 0, Total = 0;
                    GrandTot = Convert.ToDecimal(lblGrandTotal.Text);
                    Total = GrandTot + Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].Value);
                    lblGrandTotal.Text = Total.ToString("#,##0.00");
                }
                else
                {
                    decimal GrandTot = 0, Total = 0;
                    GrandTot = Convert.ToDecimal(lblGrandTotal.Text);
                    Total = GrandTot - Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].Value);
                    lblGrandTotal.Text = Total.ToString("#,##0.00");
                }
                if((Convert.ToDecimal(lblGrandTotal.Text)>=varNeftAmount) && Convert.ToInt32(cmbPaymentmode.SelectedValue)==89)
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=32 AND MSTID IN(91,93)", "MST_DisplayText,MSTID", cmbPaymentType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
                else if ((Convert.ToDecimal(lblGrandTotal.Text) < varNeftAmount) && Convert.ToInt32(cmbPaymentmode.SelectedValue) == 89)
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=32 AND MSTID IN(91,94)", "MST_DisplayText,MSTID", cmbPaymentType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierPayment_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //decimal GrandTot = 0, Total = 0 ;
                //GrandTot = Convert.ToDecimal(lblGrandTotal.Text);
                //Total = GrandTot+Convert.ToDecimal(grdSupplierPayment.Rows[e.RowIndex].Cells["clmPayAmount"].Value);
                //lblGrandTotal.Text = Total.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = 0;
                if (grdSupplierPayment.Rows.Count > 0)
                {
                    if (Convert.ToString(grdSupplierPayment.Columns[grdSupplierPayment.SelectedCells[0].ColumnIndex].Name) == "clmReturnAmt")
                    {
                        id = Convert.ToInt32(grdSupplierPayment.Rows[e.RowIndex].Cells["clmID"].Value);
                        udfnReturnDCLoad();

                    }
                }
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
                objDs = objspdservice.udfnGetSupplierPayment(objTRN_Supplier_Payment);
                objspdservice.CloseConnection();
                if(objDs!=null)
                {
                    if(objDs.Tables[1].Rows.Count>0)
                    {
                        grdReurnDC.Rows.Clear();
                        for(int i=0;i< objDs.Tables[1].Rows.Count;i++)
                        {
                            grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["PURREDC_DCNO"]), Convert.ToString(objDs.Tables[1].Rows[i]["PURREDC_DCDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["Return Amount"]));
                            grdReurnDC.Columns["clmReturnAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
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
        public void udfnAddAdvance()
        {
            try
            {
                MainForm.objPAY_Advance_Popup = new PAY_Advance_Popup();
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
    }
}
