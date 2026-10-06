using CrystalDecisions.ReportAppServer;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace ROMS
{
    public partial class REPORT_SALES_TaxDetail : Form
    {
        MainForm objMainForm = new MainForm();
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyCustomer = 0, varUpDownKeyBilledBy = 0;
        private ToolTip tpMonths = new ToolTip();
        private ToolTip tpDays = new ToolTip();
        private ToolTip tpReportType = new ToolTip();
        private List<ComboItem> months;
        private List<ComboItem> days;
        public REPORT_SALES_TaxDetail()
        {
            InitializeComponent();
            windowControl.Initialize(ReportSupplier, this);
        }
        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnListPrint_Leave(object sender, EventArgs e)
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
        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtCustomer)
                {
                    varUpDownKeyCustomer = 0;
                    DGV_Customer.DataSource = null;
                    DGV_Customer.Visible = false;
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnList(int varFlag)
        {
            try
            {
                if (Convert.ToInt32(cmbReportType.SelectedValue) == -1)
                {
                    epReport.SetError(cmbReportType, "Please select report type.");
                    cmbReportType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReportType.ShowAlways = true;
                    tpReportType.Show("Please select report type.", cmbReportType, 5000);
                    cmbReportType.Focus();
                    return;
                }
                else
                {
                    lblDays.Text = "";
                    lblMonths.Text = "";
                    if (Convert.ToInt32(cmbSalesType.SelectedValue) == 585)
                    {
                        RPTViewer.ReportSource = null;
                        RPTViewer.Visible = false;
                        RPTViewer.BringToFront();
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                        return;
                    }
                    int varReportType = Convert.ToInt32(cmbReportType.SelectedValue);
                    if (varReportType == 668)
                    {
                        if (Convert.ToInt32(cmbDayFilter.SelectedIndex) == 1)
                        {
                            var selDayIds = cmbMultiSelectDays.CheckedIds;
                            if (selDayIds == null || selDayIds.Count == 0)
                            {
                                epReport.SetError(cmbMultiSelectDays, "Please select at least one day.");
                                cmbMultiSelectDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpDays.ShowAlways = true;
                                tpDays.Show("Please select at least one day.", cmbMultiSelectDays, 5000);
                                cmbMultiSelectDays.Focus();
                                return;
                            }
                        }
                        lblMonths.Text = "";
                    }
                    else if (varReportType == 669)
                    {
                        if (Convert.ToInt32(cmbDayFilter.SelectedIndex) == 1)
                        {
                            var selMonthIds = cmbMultiMonths.CheckedIds;
                            if (selMonthIds == null || selMonthIds.Count == 0)
                            {
                                epReport.SetError(cmbMultiMonths, "Please select at least one month.");
                                cmbMultiMonths.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpMonths.ShowAlways = true;
                                tpMonths.Show("Please select at least one month.", cmbMultiMonths, 5000);
                                cmbMultiMonths.Focus();
                                return;
                            }
                        }
                        lblDays.Text = "";
                    }
                    udfnPrint(varFlag);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnListPrint_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList(0);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPrint(int varFlag)
        {
            try
            { 
                epReport.Clear();
                string varGSTTypeName = "-All-";
                string varBillTypeName = "-All-"; 
                string varSalesTypeName = "-All-"; 
                string varCustomerName = "-All-"; 
                string varDayName = "-All-";
                string varMonthName = "-All-"; 
                string varDays = "0";
                string varMonths = "0"; int varCustomerId = 0;
                var selIds = cmbMultiMonths.CheckedIds;
                var selItems = months.Where(m => selIds.Contains(m.Id)).ToList();
                var selDayIds = cmbMultiSelectDays.CheckedIds;
                var selDayItems = days.Where(d => selDayIds.Contains(d.Id)).ToList();
                int varViewType = 0;
                 
                if (!string.IsNullOrWhiteSpace(cmbSalesType.Text))
                    varSalesTypeName = cmbSalesType.Text.Trim();
                if (!string.IsNullOrWhiteSpace(cmbBillType.Text))
                    varBillTypeName = cmbBillType.Text.Trim();
                int varReportType = Convert.ToInt32(cmbReportType.SelectedValue);
                if (varReportType == 685)
                {
                    varViewType = 0;
                }
                else if (varReportType == 686)
                {
                    varViewType = 1;
                }
                else if (varReportType == 687)
                {
                    varViewType = 2;
                }
                else if (varReportType == 688)
                {
                    varViewType =3;
                }
                if (varReportType == 686)
                {
                    lblDays.Text = string.Join(", ", selDayItems.Select(x => x.Text));
                    if (string.IsNullOrWhiteSpace(lblDays.Text))
                    {
                        varDayName = "-All-";
                        varDays = "0";
                    }
                    else
                    {
                        varDayName = lblDays.Text;
                        varDays = string.Join(",", selDayIds);
                    }
                }
                else if (varReportType == 669)
                {
                    lblMonths.Text = string.Join(", ", selItems.Select(x => x.Text));
                    if (string.IsNullOrWhiteSpace(lblMonths.Text))
                    {
                        varMonthName = "-All-";
                        varMonths = "0";
                    }
                    else
                    {
                        varMonthName = lblMonths.Text;
                        varMonths = string.Join(",", selIds);
                    }
                }
                else
                {
                    lblDays.Text = "";
                    lblMonths.Text = "";
                    varDays = "0";
                    varMonths = "0";
                    varDayName = "-All-";
                    varMonthName = "-All-";
                }
                if (Convert.ToInt32(cmbDayFilter.SelectedIndex) == 0)
                {
                    lblDays.Text = "";
                    lblMonths.Text = "";
                    varDays = "0";
                    varMonths = "0";
                    varDayName = "-All-";
                    varMonthName = "-All-";
                }
                
                if (!string.IsNullOrWhiteSpace(cmbBillType.Text))
                {
                    varBillTypeName = cmbBillType.Text.Trim();
                }  
                if (!string.IsNullOrWhiteSpace(cmbSalesType.Text))
                {
                    varSalesTypeName = cmbSalesType.Text.Trim();
                }
                if (!string.IsNullOrWhiteSpace(txtCustomer.Text))
                {
                    varCustomerName = txtCustomer.Text.Trim();
                    int.TryParse(
                       lblCustomerId.Text.Trim(),
                       out varCustomerId);
                } 
                btnView.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                MR_Sales objMR_Sales = new MR_Sales();
                objMR_Sales.paraViewType = varViewType; 
                objMR_Sales.paraCustomerId = varCustomerId; 
                objMR_Sales.paraGSTType = Convert.ToInt16(cmbGSTType.SelectedValue); 
                objMR_Sales.paraBillType = Convert.ToInt16(cmbBillType.SelectedValue); 
                objMR_Sales.paraSalesType = Convert.ToInt16(cmbSalesType.SelectedValue); 
                objMR_Sales.paraFromDate =dpFromDate.Text; 
                objMR_Sales.paraToDate = dpToDate.Text; 
                objMR_Sales.paraFlag = 0; 
                objMR_Sales.paraDays = varDays; 
                objMR_Sales.paraMonths = varMonths;  
                objDs = objdserv.udfnSalesTaxReport(objMR_Sales);
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 685)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Tax_Billwise_Consolidated.rpt");
                    } 
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 686)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Tax_Billwise_Details.rpt");
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 687)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Tax_Billwise_Details.rpt");
                    }
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName ?? "");
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName ?? ""); 
                    objBillreport.SetParameterValue("paraBillType", Convert.ToInt16(cmbBillType.SelectedValue));
                    objBillreport.SetParameterValue("paraCustomerId",varCustomerId); 
                    objBillreport.SetParameterValue("paraDays", varDays); 
                    objBillreport.SetParameterValue("paraFlag",0); 
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text); 
                    objBillreport.SetParameterValue("paraGSTType",Convert.ToInt16(cmbGSTType.SelectedValue)); 
                    objBillreport.SetParameterValue("paraMonths", varMonths); 
                    objBillreport.SetParameterValue("paraSalesType", Convert.ToInt16(cmbSalesType.SelectedValue)); 
                    objBillreport.SetParameterValue("paraToDate",dpToDate.Text); 
                    objBillreport.SetParameterValue("paraGSTTypeName",cmbGSTType.Text); 
                    objBillreport.SetParameterValue("paraBillTypeName", cmbBillType.Text); 
                    objBillreport.SetParameterValue("paraSalesTypeName", cmbSalesType.Text); 
                    objBillreport.SetParameterValue("paraCustomerName",varCustomerName); 
                    objBillreport.SetParameterValue("paraDaysName", varDayName); 
                    objBillreport.SetParameterValue("paraMonthName",varMonthName);

                    //Subreport GST Summary
                    string subReportName = objBillreport.Subreports[0].Name;
                     
                    objBillreport.SetParameterValue("paraCustomerId", varCustomerId, subReportName);
                    objBillreport.SetParameterValue("paraGSTType", Convert.ToInt16(cmbGSTType.SelectedValue), subReportName);  
                    objBillreport.SetParameterValue("paraBillType", Convert.ToInt16(cmbBillType.SelectedValue), subReportName); 
                    objBillreport.SetParameterValue("paraSalesType", Convert.ToInt16(cmbSalesType.SelectedValue), subReportName); 
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text, subReportName); 
                    objBillreport.SetParameterValue("paraToDate", dpToDate.Text, subReportName); 
                    objBillreport.SetParameterValue("paraFlag", 0, subReportName); 
                    objBillreport.SetParameterValue("paraDays", varDays, subReportName); 
                    objBillreport.SetParameterValue("paraMonths", varMonths, subReportName); 

                    objValidation.CrySqlConnection(objBillreport);
                    /* 0 - from view, 1- from telegram*/
                    if (varFlag == 0)
                    {
                        RPTViewer.ReportSource = objBillreport;
                        RPTViewer.Refresh();
                        //Btn_Print.Enabled = true;
                    }
                    else
                    {
                        MainForm.varcurrentdate = DateTime.Now.ToString("dd-MM-yyyy HH-mm tt");
                        string varReportName = "Sales Summary and Details";
                        string varfilePath = MainForm.pbTelegramPath + "\\" + varReportName + "-" + MainForm.varcurrentdate + ".pdf";
                        if (File.Exists(varfilePath)) { File.Delete(varfilePath); }
                        objBillreport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, varfilePath);
                        objMainForm.udfnSendToTelegram(varfilePath);
                        btnTelegram.Enabled = true;
                        MessageBox.Show("Sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                picLoader.SendToBack();
                btnView.Enabled = true;
                GC.Collect();
            }
        }
        private void REPORT_GRNSummary_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    //MainForm.objStart = new DEF_Start();
                    //MainForm.objStart.MdiParent = this.ParentForm;
                    //MainForm.objStart.Show();
                    //this.Close();
                    windowControl?.TriggerClose();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void REPORT_GRNSummary_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 140304;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MSTID IN (" + ReportTypeIDs + ")  ORDER BY MST_OrderID ASC ", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MSTID IN(0,505,585)", "MST_DisplayText,MSTID", cmbSalesType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,208) AND MSTID NOT IN (-1) ", "MST_DisplayText,MSTID", cmbGSTType, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (210,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbBillType, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (169,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbSalesType, "", "MST_DisplayText", "MSTID"); 
                objDataBind = null;
                udfnLoadMonths();
                udfnLoadDays();
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    string privilege = "";
                    var result = UserAccessHelper.LoadUserAccess(currentMUCode);
                    privilege = result.PrivilegeCode;
                    btnTelegram.Visible = privilege.Contains("7");
                }
                cmbDayFilter.SelectedIndex = 0; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadDays()
        {
            try
            {
                lblDays.Text = "";
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 41;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspdservice.udfnMaster(objMR_Master);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
                    {
                        days = objDs.Tables[0].AsEnumerable()
                            .Select(r => new ComboItem
                            {
                                Id = r.Field<int>("DYID"),
                                Text = r.Field<string>("DayName")
                            })
                            .ToList();
                        cmbMultiSelectDays.LoadItems(days, "Select Day");
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadMonths()
        {
            try
            {
                lblMonths.Text = "";
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 29;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspdservice.udfnMaster(objMR_Master);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
                    {
                        months = objDs.Tables[0].AsEnumerable()
                            .Select(r => new ComboItem
                            {
                                Id = r.Field<int>("MONID"),
                                Text = r.Field<string>("MonthName")
                            })
                            .ToList();
                        cmbMultiMonths.LoadItems(months, "Select Month");
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbReportType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbReportType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbReportType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dpFromDate.Enabled == true)
                    {
                        dpFromDate.Focus();
                    }
                    else
                    {
                        cmbSalesType.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbReportType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmbReportType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReportType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                dpFromDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpToDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnTelegram_Click(object sender, EventArgs e)
        {
            udfnList(1);
        }
        private void btnTelegram_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                btnTelegram.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnTelegram_Leave(object sender, EventArgs e)
        {
            try
            {
                btnTelegram.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbSalesType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbSalesType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbSalesType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCustomer.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbSalesType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmbSalesType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSalesType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbBillType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbBillType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbBillType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSalesType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbBillType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmbBillType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBillType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbPrintType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbPrintType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbPrintType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtCustomer_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtCustomer.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyCustomer = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_Customer.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_Customer.Visible == false)
                {
                    if (cmbDayFilter.Enabled == true)
                    {
                        cmbDayFilter.Focus();
                    }
                    else if (cmbMultiSelectDays.Enabled == true)
                    {
                        cmbMultiSelectDays.Focus();
                    }
                    else if (cmbMultiMonths.Enabled == true)
                    {
                        cmbMultiMonths.Focus();
                    }   
                    else
                    {
                        btnView.Focus();
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_Customer.Focus();
                }
                if (DGV_Customer.CurrentCell == null && DGV_Customer.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_Customer.Focus();
                    int RowIndex = DGV_Customer.CurrentCell.RowIndex;
                    int ClmIndex = DGV_Customer.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyCustomer = 1;
                    }
                    else
                    {
                        varUpDownKeyCustomer = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_Customer.CurrentCell = DGV_Customer.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtCustomer.Text = DGV_Customer.Rows[RowIndex].Cells["Customer"].Value.ToString();
                            }
                            txtCustomer.Focus();
                            txtCustomer.SelectionStart = txtCustomer.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_Customer.Rows.Count) DGV_Customer.CurrentCell = DGV_Customer.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (DGV_Customer.Rows.Count))
                            {
                                txtCustomer.Text = DGV_Customer.Rows[RowIndex].Cells["Customer"].Value.ToString();
                            }
                            txtCustomer.Focus();
                            txtCustomer.SelectionStart = txtCustomer.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_Customer.Rows.Count > 0)
                                {
                                    varUpDownKeyCustomer = 1;
                                    udfnCustomerAutocomplete();
                                    DGV_Customer.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtCustomer.Focus();
                    //txtCustomer.SelectionStart = txtCustomer.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtBilledBy.SelectedText = true;
                        TextBox txtBilledBy = sender as TextBox;
                        txtBilledBy.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (cmbDayFilter.Enabled == true)
                        {
                            cmbDayFilter.Focus();
                        }
                        else if (cmbMultiSelectDays.Enabled == true)
                        {
                            cmbMultiSelectDays.Focus();
                        }
                        else if (cmbMultiMonths.Enabled == true)
                        {
                            cmbMultiMonths.Focus();
                        } 
                        else
                        {
                            btnView.Focus();
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
        public void udfnCustomerAutocomplete()
        {
            try
            {
                if (txtCustomer.Text.Trim() != "")
                {
                    lblCustomerId.Text = DGV_Customer.SelectedRows[0].Cells["TEMPCUSID"].Value.ToString();
                    txtCustomer.Text = DGV_Customer.SelectedRows[0].Cells["Customer"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCustomer.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyCustomer == 0)
                {
                    //lvGroup.Items.Clear();
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();
                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 6;
                    if (txtCustomer.Text.Length > 0)
                    {
                        obj.paraCUS_Name = txtCustomer.Text;
                        objDs = objspservice.udfnCustomerList(obj);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_Customer.Visible = true;
                                    DGV_Customer.DataSource = objDs.Tables[0];
                                    DGV_Customer.Columns["TEMPCUSID"].Visible = false;
                                    DGV_Customer.Columns["Mobileno"].Visible = false;
                                    DGV_Customer.Columns["Customer"].Width = 170;
                                    DGV_Customer.BringToFront();
                                }
                                else
                                {
                                    DGV_Customer.Visible = false;
                                    DGV_Customer.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_Customer.Visible = false;
                                DGV_Customer.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_Customer.Visible = false;
                            DGV_Customer.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_Customer.Visible = false;
                        DGV_Customer.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_Customer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyCustomer = 1;
                udfnCustomerAutocomplete();

                if (cmbDayFilter.Enabled == true)
                {
                    cmbDayFilter.Focus();
                }
                else if (cmbMultiSelectDays.Enabled == true)
                {
                    cmbMultiSelectDays.Focus();
                }
                else if (cmbMultiMonths.Enabled == true)
                {
                    cmbMultiMonths.Focus();
                } 
                else
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_Customer.CurrentCell.RowIndex;
                    int ClmIndex = DGV_Customer.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyCustomer = 1;
                    }
                    else
                    {
                        varUpDownKeyCustomer = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_Customer.CurrentCell = DGV_Customer.Rows[RowIndex].Cells[ClmIndex];
                            txtCustomer.Text = DGV_Customer.SelectedRows[0].Cells["Customer"].Value.ToString();
                            txtCustomer.Focus();
                            txtCustomer.SelectionStart = txtCustomer.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_Customer.Rows.Count) DGV_Customer.CurrentCell = DGV_Customer.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (DGV_Customer.Rows.Count))
                            {
                                txtCustomer.Text = DGV_Customer.Rows[RowIndex].Cells["Customer"].Value.ToString();
                            }
                            txtCustomer.Focus();
                            txtCustomer.SelectionStart = txtCustomer.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_Customer.Rows.Count > 0)
                                {
                                    varUpDownKeyCustomer = 1;
                                    udfnCustomerAutocomplete();
                                    DGV_Customer.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtBilledBy = sender as TextBox;
                        txtBilledBy.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (cmbDayFilter.Enabled == true)
                        {
                            cmbDayFilter.Focus();
                        }
                        else if (cmbMultiSelectDays.Enabled == true)
                        {
                            cmbMultiSelectDays.Focus();
                        }
                        else if (cmbMultiMonths.Enabled == true)
                        {
                            cmbMultiMonths.Focus();
                        } 
                        else
                        {
                            btnView.Focus();
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
        private void cmbSchemeType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }  
        private void cmbMultiSelectDays_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbMultiSelectDays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbMultiSelectDays_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbMultiSelectDays_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbMultiSelectDays.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbMultiMonths_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbMultiMonths.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbMultiMonths_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbMultiMonths_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbMultiMonths.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }           
        private void dpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                dpToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                cmbGSTType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReportType.SelectedValue == null)
                    return;

                if (cmbReportType.SelectedItem is DataRowView drv)
                {
                    if (drv.Row.Table.Columns.Contains("MST_ShortName") &&
                        drv["MST_ShortName"] != DBNull.Value)
                    {
                        string varTooltipText = drv["MST_ShortName"]?.ToString() ?? string.Empty;
                        tsbPrintFormat.Text = varTooltipText;
                        tsbPrintFormat.ToolTipText = varTooltipText;
                    }
                    else
                    {
                        tsbPrintFormat.Text = string.Empty;
                        tsbPrintFormat.ToolTipText = string.Empty;
                    }
                }

                if (!int.TryParse(
                    cmbReportType.SelectedValue.ToString(),
                    out int varReportType))
                {
                    return;
                }
                dpFromDate.Enabled = true;
                dpToDate.Enabled = true;
                cmbBillType.Enabled = true;
                cmbBillType.SelectedValue = 0;
                cmbSalesType.Enabled = true;
                txtCustomer.Enabled = true;
                
                cmbMultiSelectDays.Enabled = false;
                cmbMultiMonths.Enabled = false;
                cmbDayFilter.Enabled = false; 
                lblDays.Text = "";
                lblMonths.Text = "";
                epReport.Clear(); 
                switch (varReportType)
                { 
                    case 687:
                        label12.Text = "Days Filter";
                        //cmbMultiSelectDays.Enabled = true;
                        cmbDayFilter.Enabled = true;
                        cmbDayFilter.Items.Clear();
                        cmbDayFilter.Items.Add("-All Days-");
                        cmbDayFilter.Items.Add("Specific Days");
                        cmbDayFilter.SelectedIndex = 0;
                        break;
                    case 688:
                        label12.Text = "Months Filter";
                        //cmbMultiMonths.Enabled = true;
                        cmbDayFilter.Enabled = true;
                        cmbDayFilter.Items.Clear();
                        cmbDayFilter.Items.Add("-All Months-");
                        cmbDayFilter.Items.Add("Specific Months");
                        cmbDayFilter.SelectedIndex = 0; 
                        break;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void dpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpToDate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }  
        private void cmbDayFilter_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbDayFilter.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void cmbDayFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    if (cmbMultiSelectDays.Enabled == true)
                    {
                        cmbMultiSelectDays.Focus();
                    }
                    else if (cmbMultiMonths.Enabled == true)
                    {
                        cmbMultiMonths.Focus();
                    }
                    else
                    {
                        btnView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDayFilter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbDayFilter_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDayFilter.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void mtbTime1_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                epReport.Clear(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbGSTType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbGSTType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbGSTType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBillType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbGSTType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbGSTType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbGSTType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDayFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbDayFilter.SelectedIndex) == 1)
                {
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 687)
                    {
                        cmbMultiSelectDays.Enabled = true;
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 688)
                    {
                        cmbMultiMonths.Enabled = true;
                    }
                }
                else
                {
                    lblDays.Text = "";
                    lblMonths.Text = "";
                    cmbMultiSelectDays.Enabled = false;
                    cmbMultiMonths.Enabled = false;
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
