using CrystalDecisions.ReportAppServer;
using DocumentFormat.OpenXml.Bibliography;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace ROMS
{
    public partial class REPORT_SALES_SummaryDetail : Form
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
        public REPORT_SALES_SummaryDetail()
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
                }
                else
                {
                    int varReportType = Convert.ToInt32(cmbReportType.SelectedValue);
                    if (varReportType == 645 || varReportType == 647 || varReportType == 649)
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
                    else if (varReportType == 646 || varReportType == 648 || varReportType == 650)
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
                    else
                    {
                        udfnSalesProductwise(varFlag);
                    }
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
        public void udfnSalesProductwise(int varFlag)
        {
            try
            {
                epReport.Clear();
                string varCategoryName = "-All-";
                string varProductName = "-All-";
                string varBillTypeName = "-All-";
                string varSalesTypeName = "-All-";
                string varBillByName = "-All-";
                string varBilledByName = "-All-";
                string varCustomerName = "-All-";
                string varSchemeTypeName = "-All-";
                string varDayName = "-All-";
                string varMonthName = "-All-";
                int varBillType = 0;
                int varSalesType = 0;
                int varCustomerId = 0;
                int varBillCategoryId = 0;
                int varCusCategoryId = 0;
                int varBilledBy = 0;
                int varSchemeType = 0;
                int varparaFlag = 0;
                int varPrintType = 0;
                string varDays = "0";
                string varMonths = "0";
                var selIds = cmbMultiMonths.CheckedIds;
                var selItems = months.Where(m => selIds.Contains(m.Id)).ToList();
                var selDayIds = cmbMultiSelectDays.CheckedIds;
                var selDayItems = days.Where(d => selDayIds.Contains(d.Id)).ToList();
                int varViewType = 0;
                if (cmbSalesType.SelectedValue != null &&
                   cmbSalesType.SelectedValue.ToString() != "")
                {
                    int.TryParse(
                        cmbSalesType.SelectedValue.ToString(),
                        out varSalesType);
                }
                if (cmbBillCategory.SelectedValue != null &&
                   cmbBillCategory.SelectedValue.ToString() != "")
                {
                    int.TryParse(
                        cmbBillCategory.SelectedValue.ToString(),
                        out varBillCategoryId);
                }
                if (cmbBillType.SelectedValue != null &&
                    cmbBillType.SelectedValue.ToString() != "")
                {
                    int.TryParse(
                        cmbBillType.SelectedValue.ToString(),
                        out varBillType);
                }
                if (!string.IsNullOrWhiteSpace(cmbSalesType.Text))
                    varSalesTypeName = cmbSalesType.Text.Trim();
                if (!string.IsNullOrWhiteSpace(cmbBillType.Text))
                    varBillTypeName = cmbBillType.Text.Trim();
                int varReportType = Convert.ToInt32(cmbReportType.SelectedValue);
                if (varReportType == 666)
                {
                    varViewType = 0;
                }
                else if (varReportType == 667)
                {
                    varViewType = 2;
                }
                else if (varReportType == 668)
                {
                    varViewType = 4;
                }
                else if (varReportType == 669)
                {
                    varViewType = 6;
                }
                if (varReportType == 668)
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
                if (cmbBillType.SelectedValue != null && !string.IsNullOrWhiteSpace(cmbBillType.SelectedValue.ToString()))
                {
                    int.TryParse(
                        cmbBillType.SelectedValue.ToString(),
                        out varBillType);
                }
                if (!string.IsNullOrWhiteSpace(cmbBillType.Text))
                {
                    varBillTypeName = cmbBillType.Text.Trim();
                }
                if (cmbSalesType.SelectedValue != null && !string.IsNullOrWhiteSpace(cmbSalesType.SelectedValue.ToString()))
                {
                    int.TryParse(
                        cmbSalesType.SelectedValue.ToString(),
                        out varSalesType);
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
                if (cmbCustomerCategory.SelectedValue != null &&
    !string.IsNullOrWhiteSpace(cmbCustomerCategory.SelectedValue.ToString()))
                {
                    int.TryParse(
                        cmbCustomerCategory.SelectedValue.ToString(),
                        out varCusCategoryId);
                }
                if (cmbSchemeType.SelectedValue != null &&
   !string.IsNullOrWhiteSpace(cmbSchemeType.SelectedValue.ToString()))
                {
                    int.TryParse(
                        cmbSchemeType.SelectedValue.ToString(),
                        out varSchemeType);
                }
                if (!string.IsNullOrWhiteSpace(cmbSchemeType.Text))
                {
                    varSchemeTypeName = cmbSchemeType.Text.Trim();
                }
                if (!string.IsNullOrWhiteSpace(txtBilledBy.Text))
                {
                    varBilledByName = txtBilledBy.Text.Trim();
                    int.TryParse(
                       lblBilledByID.Text.Trim(),
                       out varBilledBy);
                }
                if (cmbPrintType.SelectedValue != null && !string.IsNullOrWhiteSpace(cmbPrintType.SelectedValue.ToString()))
                {
                    int.TryParse(
                        cmbPrintType.SelectedValue.ToString(),
                        out varFlag);
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
                objMR_Sales.paraFromDate = dpFromDate.Text.Trim();
                objMR_Sales.paraToDate = dpToDate.Text.Trim();
                objMR_Sales.paraFromTime = Convert.ToString(dpFromTime.Value.TimeOfDay);
                objMR_Sales.paraToTime = Convert.ToString(dpToTime.Value.TimeOfDay);
                objMR_Sales.paraSalesType = varSalesType;
                objMR_Sales.paraBillType = varBillType;
                objMR_Sales.paraCustomerId = varCustomerId;
                objMR_Sales.paraCUS_CategoryTypeID = varCusCategoryId;
                objMR_Sales.paraBilledBy = varBilledBy;
                objMR_Sales.paraSchemeType = varSchemeType;
                objMR_Sales.paraFlag = varparaFlag;
                objMR_Sales.paraDays = varDays;
                objMR_Sales.paraMonths = varMonths;
                objMR_Sales.paraBillCategory = varBillCategoryId;
                objDs = objdserv.udfnSalesReports(objMR_Sales);
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
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 666)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Summary.rpt");
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 667)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Details.rpt");
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 668)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Daywise.rpt");
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 669)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Monthwise.rpt");
                    }
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName ?? "");
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName ?? "");
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text.Trim());
                    objBillreport.SetParameterValue("paraToDate", dpToDate.Text.Trim());
                    if (varReportType == 666)
                    {
                        objBillreport.SetParameterValue("paraCategoryName", varCategoryName);
                        objBillreport.SetParameterValue("paraProductName", varProductName);
                        objBillreport.SetParameterValue("paraBillTypeName", varBillTypeName);
                        objBillreport.SetParameterValue("paraSalesTypeName", varSalesTypeName);
                        objBillreport.SetParameterValue("paraFromTime", dpFromTime.Value.ToString("HH:mm:ss"));
                        objBillreport.SetParameterValue("paraToTime", dpToTime.Value.ToString("HH:mm:ss"));
                        objBillreport.SetParameterValue("paraBillByName", varBillByName);
                        objBillreport.SetParameterValue("paraCustomerName", varCustomerName);
                        objBillreport.SetParameterValue("paraSchemeTypeName", varSchemeTypeName);
                        objBillreport.SetParameterValue("paraBilledBy", varBilledBy);
                        objBillreport.SetParameterValue("paraBilltype", varBillType);
                        objBillreport.SetParameterValue("paraCusCategoryld", varCusCategoryId);
                        objBillreport.SetParameterValue("paraCustomerld", varCustomerId);
                        objBillreport.SetParameterValue("paraSchemeType", varSchemeType);
                        objBillreport.SetParameterValue("paraViewType", varViewType);
                    }
                    else if (varReportType == 667)
                    {
                        string subReportName = objBillreport.Subreports[0].Name;

                        objBillreport.SetParameterValue("paraCategoryName", varCategoryName);
                        objBillreport.SetParameterValue("paraProductName", varProductName);
                        objBillreport.SetParameterValue("paraBillTypeName", varBillTypeName);
                        objBillreport.SetParameterValue("paraSalesTypeName", varSalesTypeName);
                        objBillreport.SetParameterValue("paraFromTime", dpFromTime.Value.ToString("HH:mm:ss"));
                        objBillreport.SetParameterValue("paraToTime", dpToTime.Value.ToString("HH:mm:ss"));
                        objBillreport.SetParameterValue("paraBillByName", varBillByName);
                        objBillreport.SetParameterValue("paraCustomerName", varCustomerName);
                        objBillreport.SetParameterValue("paraSchemeTypeName", varSchemeTypeName);
                        objBillreport.SetParameterValue("paraBilledBy", varBilledBy);
                        objBillreport.SetParameterValue("paraBilltype", varBillType);
                        objBillreport.SetParameterValue("paraCusCategoryld", varCusCategoryId);
                        objBillreport.SetParameterValue("paraCustomerld", varCustomerId);
                        objBillreport.SetParameterValue("paraFlag", varFlag);
                        objBillreport.SetParameterValue("paraSchemeType", varSchemeType);
                        objBillreport.SetParameterValue("paraViewType", varViewType);

                        objBillreport.SetParameterValue("paraCategoryName", varCategoryName, subReportName);
                        objBillreport.SetParameterValue("paraProductName", varProductName, subReportName);
                        objBillreport.SetParameterValue("paraBillTypeName", varBillTypeName, subReportName);
                        objBillreport.SetParameterValue("paraSalesTypeName", varSalesTypeName, subReportName);
                        objBillreport.SetParameterValue("paraFromTime", dpFromTime.Value.ToString("HH:mm:ss"), subReportName);
                        objBillreport.SetParameterValue("paraToTime", dpToTime.Value.ToString("HH:mm:ss"), subReportName);
                        objBillreport.SetParameterValue("paraBillByName", varBillByName, subReportName);
                        objBillreport.SetParameterValue("paraCustomerName", varCustomerName, subReportName);
                        objBillreport.SetParameterValue("paraSchemeTypeName", varSchemeTypeName, subReportName);
                        objBillreport.SetParameterValue("paraBilledBy", varBilledBy, subReportName);
                        objBillreport.SetParameterValue("paraBilltype", varBillType, subReportName);
                        objBillreport.SetParameterValue("paraCusCategoryld", varCusCategoryId, subReportName);
                        objBillreport.SetParameterValue("paraCustomerld", varCustomerId, subReportName);
                        objBillreport.SetParameterValue("paraFlag", varFlag, subReportName);
                        objBillreport.SetParameterValue("paraSchemeType", varSchemeType, subReportName);
                        objBillreport.SetParameterValue("paraViewType", varViewType, subReportName);
                    }
                    else if (varReportType == 668)
                    {
                        objBillreport.SetParameterValue("paraBillTypeName", varBillTypeName);
                        objBillreport.SetParameterValue("paraSalesTypeName", varSalesTypeName);
                        objBillreport.SetParameterValue("paraCustomerName", varCustomerName);
                        objBillreport.SetParameterValue("paraBilledByName", varBilledByName);
                        objBillreport.SetParameterValue("paraDayName", varDayName);
                        objBillreport.SetParameterValue("paraBilledBy", varBilledBy);
                        objBillreport.SetParameterValue("paraBilltype", varBillType);
                        objBillreport.SetParameterValue("paraCustomerld", varCustomerId);
                        objBillreport.SetParameterValue("paraDays", varDays);
                        objBillreport.SetParameterValue("paraViewType", varViewType);
                    }
                    else if (varReportType == 669)
                    {
                        objBillreport.SetParameterValue("paraBillTypeName", varBillTypeName);
                        objBillreport.SetParameterValue("paraSalesTypeName", varSalesTypeName);
                        objBillreport.SetParameterValue("paraCustomerName", varCustomerName);
                        objBillreport.SetParameterValue("paraMonthName", varMonthName);
                        objBillreport.SetParameterValue("paraBilledByName", varBilledByName);
                        objBillreport.SetParameterValue("paraBilledBy", varBilledBy);
                        objBillreport.SetParameterValue("paraBilltype", varBillType);
                        objBillreport.SetParameterValue("paraCustomerld", varCustomerId);
                        objBillreport.SetParameterValue("paraMonths", varMonths);
                        objBillreport.SetParameterValue("paraViewType", varViewType);
                    }

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
                        string varReportName = "PriceList";
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
                int currentMUCode = 140301;
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
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (169,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbBillType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (198)", "MST_DisplayText,MSTID", cmbPrintType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,190,202) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbSchemeType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,157) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbCustomerCategory, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,201) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbBillCategory, "", "MST_DisplayText", "MSTID");
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
                    dpFromDate.Focus();
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
                    cmbBillType.Focus();
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
                    cmbSchemeType.Focus();
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
                cmbPrintType.BackColor = Color.LemonChiffon;
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
        private void cmbPrintType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPrintType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpFromTime_Enter(object sender, EventArgs e)
        {
            try
            {
                dpFromTime.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpFromTime_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpToTime.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpFromTime_Leave(object sender, EventArgs e)
        {
            try
            {
                dpFromTime.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpToTime_Enter(object sender, EventArgs e)
        {
            try
            {
                dpToTime.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void dpToTime_KeyDown(object sender, KeyEventArgs e)
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
        private void dpToTime_Leave(object sender, EventArgs e)
        {
            try
            {
                dpToTime.BackColor = Color.White;
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
                    cmbMultiSelectDays.Focus();
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
                        cmbMultiSelectDays.Focus();
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
                cmbMultiSelectDays.Focus();
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
                        cmbMultiSelectDays.Focus();
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
                cmbSchemeType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbSchemeType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBilledBy.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbSchemeType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cmbMultiSelectDays_Enter(object sender, EventArgs e)
        {
            try
            {
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
                    cmbMultiMonths.Focus();
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
                    cmbPrintType.Focus();
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
        private void cmbBillCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBillCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbBillCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCustomerCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbBillCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void cmbBillCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBillCategory.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbSchemeType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSchemeType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtBilledBy_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBilledBy.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtBilledBy_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyBilledBy = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_BilledBy.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_BilledBy.Visible == false)
                {
                    cmbBillCategory.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_BilledBy.Focus();
                }
                if (DGV_BilledBy.CurrentCell == null && DGV_BilledBy.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_BilledBy.Focus();
                    int RowIndex = DGV_BilledBy.CurrentCell.RowIndex;
                    int ClmIndex = DGV_BilledBy.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyBilledBy = 1;
                    }
                    else
                    {
                        varUpDownKeyBilledBy = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_BilledBy.CurrentCell = DGV_BilledBy.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtBilledBy.Text = DGV_BilledBy.Rows[RowIndex].Cells["SU_Name"].Value.ToString();
                            }
                            txtBilledBy.Focus();
                            txtBilledBy.SelectionStart = txtBilledBy.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_BilledBy.Rows.Count) DGV_BilledBy.CurrentCell = DGV_BilledBy.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (DGV_BilledBy.Rows.Count))
                            {
                                txtBilledBy.Text = DGV_BilledBy.Rows[RowIndex].Cells["SU_Name"].Value.ToString();
                            }
                            txtBilledBy.Focus();
                            txtBilledBy.SelectionStart = txtBilledBy.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_BilledBy.Rows.Count > 0)
                                {
                                    varUpDownKeyBilledBy = 1;
                                    udfnListviewBilledBy();
                                    DGV_BilledBy.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtBilledBy.Focus();
                    //txtBilledBy.SelectionStart = txtBilledBy.Text.Length;
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
                        cmbBillCategory.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtBilledBy_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBilledBy.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtBilledBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyBilledBy == 0)
                {
                    //lvproduct.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtBilledBy.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnSalesUserList(5, txtBilledBy.Text, "", "", 0, 0, "");
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_BilledBy.Visible = true;
                                    DGV_BilledBy.DataSource = objDs.Tables[0];
                                    DGV_BilledBy.Columns["SUID"].Visible = false;
                                    DGV_BilledBy.Columns["SU_Name"].HeaderText = "User Name";
                                    DGV_BilledBy.Columns["SU_Name"].Width = 150;
                                    DGV_BilledBy.BringToFront();
                                }
                                else
                                {
                                    DGV_BilledBy.Visible = false;
                                    DGV_BilledBy.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_BilledBy.Visible = false;
                                DGV_BilledBy.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_BilledBy.Visible = false;
                            DGV_BilledBy.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_BilledBy.Visible = false;
                        DGV_BilledBy.DataSource = null;
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
        public void udfnListviewBilledBy()
        {
            try
            {
                if (txtBilledBy.Text.Trim() != "")
                {
                    lblBilledByID.Text = DGV_BilledBy.SelectedRows[0].Cells["SUID"].Value.ToString();
                    txtBilledBy.Text = DGV_BilledBy.SelectedRows[0].Cells["SU_Name"].Value.ToString();
                }
                cmbBillCategory.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_BilledBy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyBilledBy = 1;
                udfnListviewBilledBy();
                cmbBillCategory.Focus();
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
                if (e.KeyCode == Keys.Enter)
                {
                    dpFromTime.Focus();
                }
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
        private void cmbCustomerCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbCustomerCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbCustomerCategory_KeyDown(object sender, KeyEventArgs e)
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
        private void cmbCustomerCategory_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmbCustomerCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbCustomerCategory.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_BilledBy_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_BilledBy.CurrentCell.RowIndex;
                    int ClmIndex = DGV_BilledBy.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyBilledBy = 1;
                    }
                    else
                    {
                        varUpDownKeyBilledBy = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_BilledBy.CurrentCell = DGV_BilledBy.Rows[RowIndex].Cells[ClmIndex];
                            txtBilledBy.Text = DGV_BilledBy.SelectedRows[0].Cells["SU_Name"].Value.ToString();
                            txtBilledBy.Focus();
                            txtBilledBy.SelectionStart = txtBilledBy.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_BilledBy.Rows.Count) DGV_BilledBy.CurrentCell = DGV_BilledBy.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (DGV_BilledBy.Rows.Count))
                            {
                                txtBilledBy.Text = DGV_BilledBy.Rows[RowIndex].Cells["SU_Name"].Value.ToString();
                            }
                            txtBilledBy.Focus();
                            txtBilledBy.SelectionStart = txtBilledBy.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_BilledBy.Rows.Count > 0)
                                {
                                    varUpDownKeyBilledBy = 1;
                                    udfnListviewBilledBy();
                                    DGV_BilledBy.Visible = false;
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
                        cmbBillCategory.Focus();
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
