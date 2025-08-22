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
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpSuppliername = new ToolTip();
        DataTable dtChequeTemplateDetails = new DataTable();
        public PAY_ChequePrint()
        {
            InitializeComponent();
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
                if (txtsuppliername.Text != "")
                {
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtsuppliername.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                    //if (Convert.ToInt32(grdSupplierPayment.Rows.Count) != 0)
                    //{
                    //    if (Convert.ToString(lblSupplierCode.Text.Trim()) != Convert.ToString(varSupplierID))
                    //    {
                    //        SPDataService objDServ = new SPDataService();
                    //        string varMessage = objDServ.udfnGetMessages(78);
                    //        objDServ.CloseConnection();

                    //        DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //        if (dialogResult == DialogResult.Yes)
                    //        {
                    //            //grdSupplierPayment.Rows.Clear();
                    //            //grdReurnDC.Rows.Clear();
                    //            //grdSupplierPayment.DataSource = null;
                    //            //grdReurnDC.DataSource = null;
                    //        }
                    //        else
                    //        {
                    //            //grdSupplierPayment.Refresh();
                    //            txtsuppliername.Text = varSupplierName;
                    //            lblSupplierCode.Text = varSupplierID;
                    //            lblschedule.Text = varSupplierScheduleID;
                    //        }
                    //    }
                    //}
                    udfnsupplierLoad();
                }
                //if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                //{
                //    cmbConcern.Focus();
                //    cmbConcern.BackColor = Color.LemonChiffon;
                //}
                //else
                //{
                //    //cmbReason.Focus();
                //}
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
                //dpDate.MaxDate = MainForm.pbCurrentDate;
                //DataBind objDataBind = new DataBind();
                //objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID IN (0,72) AND MSTID IN (-1,224,225)", "MST_DisplayText,MSTID", cmbBank, "", "MST_DisplayText", "MSTID");
                //objDataBind = null;
                udfnBankDropDown();
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
                    dpDate.Focus();
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
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter the amount", txtAmount, 5000);
                }
                else
                {
                    epCheque.Clear();
                    txtAmount.BackColor = Color.White;
                }
                txtAmount.BackColor = Color.White;
                //txtAmount.Text = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                //udfnCheckAmt();
                if (txtAmount.Text.Trim() != "")
                {
                    decimal varMRP = Math.Round(Convert.ToDecimal(txtAmount.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                    string varAmt = string.Format("{0:0}", varMRP);
                    int varAmount = Convert.ToInt32(varAmt);
                    lblAmount.Visible = true;
                    lblAmount.Text = Currency.NumbersToWords(varAmount);
                    //lblAmount.MaximumSize = new Size(300, 0);
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
                DateTime ChequeDateTime =DateTime.ParseExact(dpDate.Text, "dd/MM/yyyy", null);
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
                RPTViewer.RefreshReport();
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\" + varRPTName);
                objBillreport.SetParameterValue("paraSupplierName", txtsuppliername.Text);
                objBillreport.SetParameterValue("paraAmountInWords", lblAmount.Text);
                objBillreport.SetParameterValue("paraAmount", FinalAmnt);
                objBillreport.SetParameterValue("paraChequeDate", chequeDate);
                objValidation.CrySqlConnection(objBillreport);
                RPTViewer.ReportSource = objBillreport;
                RPTViewer.Refresh();
                MainForm.objReportLoad = new ReportLoad();
                MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                //if (Convert.ToInt32(cmbBank.SelectedValue) == 224)
                //{
                //    RPTViewer.Visible = true;
                //    RPTViewer.BringToFront();
                //    RPTViewer.ReuseParameterValuesOnRefresh = true;
                //    RPTViewer.RefreshReport();
                //    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TMB.rpt");
                //    objBillreport.SetParameterValue("paraSupplierName", txtsuppliername.Text);
                //    objBillreport.SetParameterValue("paraAmountInWords", lblAmount.Text);
                //    objBillreport.SetParameterValue("paraAmount", FinalAmnt);
                //    objBillreport.SetParameterValue("paraChequeDate", chequeDate);
                //    objValidation.CrySqlConnection(objBillreport);
                //    RPTViewer.ReportSource = objBillreport;
                //    RPTViewer.Refresh();
                //    MainForm.objReportLoad = new ReportLoad();
                //    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                //    //MainForm.objReportLoad.Text = varHeader;
                //    //MainForm.objReportLoad.ShowDialog();
                //}
                //else if(Convert.ToInt32(cmbBank.SelectedValue) == 225)
                //{
                //    RPTViewer.Visible = true;
                //    RPTViewer.BringToFront();
                //    RPTViewer.ReuseParameterValuesOnRefresh = true;
                //    RPTViewer.RefreshReport();
                //    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_HDFC.rpt");
                //    objBillreport.SetParameterValue("paraSupplierName", txtsuppliername.Text);
                //    objBillreport.SetParameterValue("paraAmountInWords", lblAmount.Text);
                //    objBillreport.SetParameterValue("paraAmount", FinalAmnt);
                //    objBillreport.SetParameterValue("paraChequeDate", chequeDate);
                //    objValidation.CrySqlConnection(objBillreport);
                //    RPTViewer.ReportSource = objBillreport;
                //    RPTViewer.Refresh();
                //    MainForm.objReportLoad = new ReportLoad();
                //    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                //}
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
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
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
    }
}
