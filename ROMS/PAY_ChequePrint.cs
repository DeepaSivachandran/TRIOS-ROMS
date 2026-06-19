using ROMS.Model;
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

namespace ROMS
{
    public partial class PAY_ChequePrint : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpAmount = new ToolTip();
        DataTable dtChequeTemplateDetails = new DataTable();
        public PAY_ChequePrint()
        {
            InitializeComponent();
            windowControl.Initialize(tsDirectCheque, this);
        }

        private void Txtsuppliername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.BringToFront();
                LV_Supplier.Items.Clear();
                if (txtsuppliername.Text.Length > 0)
                {
                    int varTypeId = 0;
                    if (Convert.ToInt32(cmbType.SelectedValue) == 566)
                    {
                        varTypeId = 1;
                    }
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 43;
                    objMR_Supplier.paraSupplierName = txtsuppliername.Text;
                    objMR_Supplier.paraordertype = varTypeId;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString() , objDs.Tables[0].Rows[i]["Customer"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[3].Width = 0;
                                LV_Supplier.Columns[4].Width = 100;
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
                    cmbBank.Focus();
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
                    epCheque.SetError(txtsuppliername, "Please enter supplier name");
                    txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier name", txtsuppliername, 5000);
                }
                else
                {
                    epCheque.Clear();
                    txtsuppliername.BackColor = Color.White;
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
                if (txtsuppliername.Text != "" )
                {
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtsuppliername.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    if (Convert.ToInt16(cmbType.SelectedValue) == 566)
                    {
                        txtOthersText.Text = selectedItem.SubItems[4].Text;
                    } 
                    if (Convert.ToInt32(cmbType.SelectedValue) == 565)
                    {
                        udfnsupplierLoad();
                    }
                    else
                    {
                        udfnOthersLoad();
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
                    //objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
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
        public void udfnOthersLoad()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                MR_AddressBook objMR_AddressBook = new MR_AddressBook();
                objMR_AddressBook.ViewType = 3;
                objMR_AddressBook.paraABID = Convert.ToInt32(lblSupplierCode.Text);
                objDs = objspservice.udfnAddressBookList(objMR_AddressBook);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblSuppliername.Text = objDs.Tables[0].Rows[0]["NAME"].ToString();
                            lblSupplierCity.Text = objDs.Tables[0].Rows[0]["CITY"].ToString();
                            lblsupplierGST.Text = objDs.Tables[0].Rows[0]["MobileNo"].ToString();
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["State"].ToString();
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
        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                cmbBank.Focus();
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
                    cmbBank.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBank_SelectedIndexChanged(object sender, EventArgs e)
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

        private void PAY_ChequePrint_Load(object sender, EventArgs e)
        {
            try
            {
                dpDate.MinDate = MainForm.pbCurrentDate; 
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (173) AND MSTID<>564 ORDER BY MSTID ASC", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                udfnBankDropDown();
                this.ActiveControl = cmbType;
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
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                SPDataService objspdservice = new SPDataService();
                Model.TRN_Supplier_Payment objTRN_Supplier_Payment = new Model.TRN_Supplier_Payment();
                objTRN_Supplier_Payment.ViewType = 3;
                objDs = objspdservice.udfnGetSupplierPayment(objTRN_Supplier_Payment);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        cmbBank.ValueMember = "BankID";
                        cmbBank.DisplayMember = "Bank";
                        cmbBank.DataSource = objDs.Tables[0];
                        dtChequeTemplateDetails = objDs.Tables[0];
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
                    txtAmount.Focus();
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

        private void CmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtOthersText.Visible == true)
                    {
                        txtOthersText.Focus();
                    }
                    else
                    {
                        dpDate.Focus();
                    }
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
                if(txtAmount.Text=="" || Convert.ToDecimal(txtAmount.Text)==0)
                {
                    epCheque.SetError(txtAmount, "Please enter the amount");
                    txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAmount.ShowAlways = true;
                    tpAmount.Show("Please enter the amount", txtAmount, 5000);
                }
                else
                {
                    epCheque.Clear();
                    txtAmount.BackColor = Color.White;
                }
                txtAmount.BackColor = Color.White; 
                if (txtAmount.Text.Trim() != "")
                {
                    decimal varMRP = Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                    string varAmt = string.Format("{0:0}", varMRP);
                    int varAmount = Convert.ToInt32(varAmt);
                    lblAmount.Visible = true;
                    lblAmount.Text = Currency.NumbersToWords(varAmount); 
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
                    btnPreview.Focus();
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

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtAmount.Text=="")
                {
                    lblAmount.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                bool varErrFlag = false;
                if ((Convert.ToInt16(cmbType.SelectedValue) == 565 || Convert.ToInt16(cmbType.SelectedValue) == 566))
                {
                    if (txtsuppliername.Text.Trim() == "")
                    {
                        epCheque.SetError(txtsuppliername, "Please enter supplier name");
                        txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Please enter supplier name", txtsuppliername, 5000);
                        varErrFlag = true;
                    }
                    if (lblSupplierCode.Text == "0" || lblSupplierCode.Text == "")
                    {
                        epCheque.SetError(txtsuppliername, "Please enter valid supplier name");
                        txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Please enter valid supplier name", txtsuppliername, 5000);
                        varErrFlag = true;
                    }
                }
                if (txtAmount.Text.Trim() == "")
                {
                    epCheque.SetError(txtAmount, "Please enter amount");
                    txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAmount.ShowAlways = true;
                    tpAmount.Show("Please enter amount", txtAmount, 5000);
                    varErrFlag = true;
                }
                else if (Convert.ToInt32(txtAmount.Text) < 1)
                {
                    epCheque.SetError(txtAmount, "Please enter valid amount");
                    txtAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAmount.ShowAlways = true;
                    tpAmount.Show("Please enter valid amount", txtAmount, 5000);
                    varErrFlag = true;
                }
                if (varErrFlag == false)
                {
                    epCheque.Clear();
                    txtsuppliername.BackColor = Color.White;
                    txtAmount.BackColor = Color.White;
                    udfnPrint();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPrint()
        {
            try
            {
                DateTime ChequeDateTime = DateTime.ParseExact(dpDate.Text, "dd/MM/yyyy", null);
                string chequeDate = ChequeDateTime.ToString("ddMMyyyy");
                int totalAmt = Convert.ToInt32(txtAmount.Text);
                string FinalAmnt = totalAmt.ToString("#,##,##,##,##0");
                string varRPTName = "";
                var RPTName = dtChequeTemplateDetails.AsEnumerable()
                               .Where(b => b.Field<int>("BankID") == Convert.ToInt32(cmbBank.SelectedValue))
                                .Select(b => b.Field<string>("RPTName"))
                                .Where(rpt => !string.IsNullOrEmpty(rpt))
                                .ToList();
                varRPTName = RPTName[0];
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                RPTViewer.ReuseParameterValuesOnRefresh = true;
                string varName = "";

                if (Convert.ToInt16(cmbType.SelectedValue) == 565) //Supplier
                {
                    string[] supplierName = txtsuppliername.Text.Split('-');
                    varName = supplierName[0];
                }
                else if (Convert.ToInt16(cmbType.SelectedValue) == 566) //Others
                {
                    varName = txtOthersText.Text.Trim();
                }
                else if (Convert.ToInt16(cmbType.SelectedValue) == 607) //Direct
                {
                    varName = txtNameText.Text.Trim();
                }
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\" + varRPTName);
                objBillreport.SetParameterValue("paraSupplierName", varName);
                objBillreport.SetParameterValue("paraAmountInWords", lblAmount.Text);
                objBillreport.SetParameterValue("paraAmount", totalAmt);
                objBillreport.SetParameterValue("paraChequeDate", chequeDate);
                objValidation.CrySqlConnection(objBillreport);
                RPTViewer.ReportSource = objBillreport;
                RPTViewer.Refresh();
                MainForm.objReportLoad = new ReportLoad();
                MainForm.objReportLoad.cryptview.ReportSource = objBillreport; 
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
                txtsuppliername.Text = "";
                cmbBank.SelectedValue = -1;
                txtAmount.Text = "";
                RPTViewer.Visible = false;
                lblAmount.Text = "";
                lblSuppliername.Text = "";
                lblsupplierGST.Text = "";
                lblSupplierCity.Text = "";
                lblsupplierScheduletype.Text = "";
                lblsupplierpayment.Text = "";
                lblSupplierOrderpolicy.Text = "";
                lblReturn.Text = "";
                txtNameText.Text = "";
                txtOthersText.Text = "";
                udfnTooltipHide();
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
                tpSuppliername.Active = false;            
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PAY_ChequePrint_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                { 
                    windowControl?.TriggerClose();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PAY_ChequePrint_Leave(object sender, EventArgs e)
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

        private void cmbType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(Convert.ToInt16(cmbType.SelectedValue) == 607)//Direct
                    {
                        txtNameText.Focus();
                    }
                    else
                    {
                        txtsuppliername.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled=true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblSupplierCode.Text = "0";
                lblschedule.Text = "0";
                txtsuppliername.Text = "";
                lblSuppliername.Text = "";
                lblSupplierCity.Text = "";
                lblsupplierGST.Text = "";
                lblsupplierScheduletype.Text = "";
                lblsupplierpayment.Text = "";
                lblSupplierOrderpolicy.Text = "";
                lblReturn.Text = "";
                lblAmount.Text = "";
                txtAmount.Text = "";
                txtNameText.Text = "";
                txtOthersText.Text = "";
                RPTViewer.Visible = false;
                dpDate.Value = MainForm.pbCurrentDate;
                if(Convert.ToInt16(cmbType.SelectedValue)== 607)//Direct
                {
                    txtNameText.Visible = true;
                    txtsuppliername.Visible = false;
                    txtOthersText.Visible = false;
                    lblSupplier.Text = "Name";
                }
                else if(Convert.ToInt16(cmbType.SelectedValue)== 566)//Others
                {
                    txtNameText.Visible = false;
                    txtOthersText.Visible = true; 
                    txtsuppliername.Visible = true;
                    lblSupplier.Text = "Others";
                }
                else if (Convert.ToInt16(cmbType.SelectedValue) == 565)//Supplier
                {
                    txtsuppliername.Visible = true;
                    txtNameText.Visible = false; 
                    txtOthersText.Visible = false;
                    lblSupplier.Text = "Supplier";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtNameText_Enter(object sender, EventArgs e)
        {
            try
            {
                txtNameText.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtNameText_Leave(object sender, EventArgs e)
        {
            try
            {
                txtNameText.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 

        private void txtOthersText_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOthersText.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOthersText_Leave(object sender, EventArgs e)
        {
            try
            {
                txtOthersText.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtNameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNameText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBank.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOthersText_KeyDown(object sender, KeyEventArgs e)
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
    }
}
