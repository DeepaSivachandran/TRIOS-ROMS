using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class REPORT_SALES_CardPayment : Form
    {
        MainForm objMainForm = new MainForm();
        DynamicWindowControl windowControl = new DynamicWindowControl();

        private List<ComboItem> months;
        private List<ComboItem> days;
        private ToolTip tpMonths = new ToolTip();
        private ToolTip tpDays = new ToolTip();
        private ToolTip tpReportType = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyBrand = 0, varUpDownKeyProduct = 0;
        public REPORT_SALES_CardPayment()
        {
            InitializeComponent();
            windowControl.Initialize(tsRateChangeReport, this);
        } 
        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                var selIds = cmbMultiMonths.CheckedIds;
                var selItems = months.Where(m => selIds.Contains(m.Id)).ToList();

                var selDayIds = cmbMultiSelectDays.CheckedIds;
                var selDayItems = days.Where(d => selDayIds.Contains(d.Id)).ToList();

                int varReportType = Convert.ToInt32(cmbReportType.SelectedValue);

                lblDays.Text = "";
                lblMonths.Text = "";

                if (varReportType == 645 || varReportType == 647 || varReportType == 649)
                {
                    lblDays.Text = string.Join(", ", selDayItems.Select(x => x.Text));
                }
                else if (varReportType == 646 || varReportType == 648 || varReportType == 650)
                {
                    lblMonths.Text = string.Join(", ", selItems.Select(x => x.Text));
                }

                udfnGridNull((Control)sender);
                btnListPrint.BackColor = Color.LemonChiffon;
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
                btnListPrint.BackColor = Color.Transparent;
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
                //if (skipControl != txtCustomer)
                //{
                //    varUpDownKeyGroup = 0;
                //    DGV_Customer.DataSource = null;
                //    DGV_Customer.Visible = false;
                //}
                //if (skipControl != txtSubGroup)
                //{
                //    varUpDownKeySubgroup = 0;
                //    DGV_FilterSubgroup.DataSource = null;
                //    DGV_FilterSubgroup.Visible = false;
                //}
                //if (skipControl != txtBrand)
                //{
                //    varUpDownKeyBrand = 0;
                //    DGV_FilterBrand.DataSource = null;
                //    DGV_FilterBrand.Visible = false;
                //}
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

                    udfnReportLoad(Convert.ToInt32(cmbReportType.SelectedValue), varFlag);
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
        public void udfnReportLoad(int varReportTypeID, int varFlag)
        {
            try
            {
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();

                string varCustomerName = "-All-";
                string varBillNoName = "-All-";
                string varBillAmtName = "-All-";
                string varDayNames = "-All-";
                string varMonthNames = "-All-";

                int varCustomerId = 0;

                // Concern
                int varConcernId = Convert.ToInt32(cmbConcern.SelectedValue);
                string varConcernName = cmbConcern.Text;

                // Machine
                int varMachineId = Convert.ToInt32(cmbMachineId.SelectedValue);
                string varMachineName = cmbMachineId.Text;

                // Vendor / Provider
                int varProviderId = Convert.ToInt32(cmbVendor.SelectedValue);
                string varVendorName = cmbVendor.Text;

                // Bill Type
                int varTypeId = Convert.ToInt32(cmbBillType.SelectedValue);
                string varTypeName = cmbBillType.Text;

                // Customer
                if (string.IsNullOrWhiteSpace(txtCustomer.Text))
                {
                    varCustomerId = 0;
                    varCustomerName = "-All-";
                }
                else
                {
                    varCustomerId = Convert.ToInt32(lblCustomerId.Text);
                    varCustomerName = txtCustomer.Text.Trim();
                }

                // Bill No
                string varBillNo = txtBillno.Text.Trim();

                if (string.IsNullOrWhiteSpace(varBillNo))
                {
                    varBillNoName = "-All-";
                }
                else
                {
                    varBillNoName = varBillNo;
                }

                // Bill Amount
                string varBillAmt = txtBillAmt.Text.Trim();

                if (string.IsNullOrWhiteSpace(varBillAmt))
                {
                    varBillAmtName = "-All-";
                }
                else
                {
                    varBillAmtName = varBillAmt;
                }
                string varDays = "0";
                string varMonths = "0";

                var selIds = cmbMultiMonths.CheckedIds;
                var selItems = months.Where(m => selIds.Contains(m.Id)).ToList();

                var selDayIds = cmbMultiSelectDays.CheckedIds;
                var selDayItems = days.Where(d => selDayIds.Contains(d.Id)).ToList();

                int varReportType = Convert.ToInt32(cmbReportType.SelectedValue);

                lblDays.Text = "";
                lblMonths.Text = "";

                if (varReportType == 645 || varReportType == 647 || varReportType == 649)
                {
                    lblDays.Text = string.Join(", ", selDayItems.Select(x => x.Text));

                    if (string.IsNullOrWhiteSpace(lblDays.Text))
                    {
                        varDayNames = "-All-";
                        varDays = "0";
                    }
                    else
                    {
                        varDayNames = lblDays.Text;
                        varDays = string.Join(",", selDayIds);
                    }
                }
                else if (varReportType == 646 || varReportType == 648 || varReportType == 650)
                {
                    lblMonths.Text = string.Join(", ", selItems.Select(x => x.Text));

                    if (string.IsNullOrWhiteSpace(lblMonths.Text))
                    {
                        varMonthNames = "-All-";
                        varMonths = "0";
                    }
                    else
                    {
                        varMonthNames = lblMonths.Text;
                        varMonths = string.Join(",", selIds);
                    }
                }
                else
                {
                    // Reports 643 and 644 don't use Day/Month filters
                    lblDays.Text = "";
                    lblMonths.Text = "";

                    varDays = "0";
                    varMonths = "0";

                    varDayNames = "-All-";
                    varMonthNames = "-All-";
                }






                int varPrint = 0;
                DataSet objDs = new DataSet();

                SPDataService objdserv = new SPDataService();

                MR_Sales objCardPayment = new MR_Sales();
                if (varReportTypeID == 643)
                {
                    objCardPayment.paraViewType = 0;
                }
                else if (varReportTypeID == 644)
                {
                    objCardPayment.paraViewType = 1;
                }
                else if (varReportTypeID == 645)
                {
                    objCardPayment.paraViewType = 2;
                }
                else if (varReportTypeID == 646)
                {
                    objCardPayment.paraViewType = 3;
                }
                else if (varReportTypeID == 647)
                {
                    objCardPayment.paraViewType = 4;
                }
                else if (varReportTypeID == 648)
                {
                    objCardPayment.paraViewType = 5;
                }
                else if (varReportTypeID == 649)
                {
                    objCardPayment.paraViewType = 6;
                }
                else if (varReportTypeID == 650)
                {
                    objCardPayment.paraViewType = 7;
                }
                objCardPayment.paraConcernId = varConcernId;
                objCardPayment.paraFromDate = dpFromDate.Text;
                objCardPayment.paraToDate = dpToDate.Text;
                objCardPayment.paraMachineId = varMachineId;
                objCardPayment.paraProviderId = varProviderId;
                objCardPayment.paraTypeId = varTypeId;
                objCardPayment.paraCustomerId = varCustomerId;
                objCardPayment.paraBillNo = varBillNo;
                objCardPayment.paraBillAmt = varBillAmt;
                objCardPayment.paraDays = varDays;
                objCardPayment.paraMonths = varMonths;
                objDs = objdserv.udfnCardPaymentReports(objCardPayment);
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    string varReportName = Convert.ToString(cmbReportType.Text);
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (varReportTypeID == 643)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Card_Payment_Detail.rpt");

                        // Detail Report Only
                        objBillreport.SetParameterValue("paraFromDate", Convert.ToString(dpFromDate.Text));
                        objBillreport.SetParameterValue("paraToDate", Convert.ToString(dpToDate.Text));

                        objBillreport.SetParameterValue("paraCustomerName", varCustomerName);
                        objBillreport.SetParameterValue("paraBillNoName", varBillNoName);
                        objBillreport.SetParameterValue("paraBillAmountName", varBillAmtName);

                        objBillreport.SetParameterValue("paraBillAmt", varBillAmt);
                        objBillreport.SetParameterValue("paraBillNo", varBillNo);
                        objBillreport.SetParameterValue("paraCustomerId", varCustomerId);
                    }
                    else if (varReportTypeID == 644)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Card_Payment_Summary.rpt");

                        // Summary Report
                        objBillreport.SetParameterValue("paraFromDate", Convert.ToString(dpFromDate.Text));
                        objBillreport.SetParameterValue("paraToDate", Convert.ToString(dpToDate.Text));
                    }
                    else if (varReportTypeID == 645)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Card_Payment_Daywise.rpt");

                        // Daywise Report
                        objBillreport.SetParameterValue("paraFromDate", Convert.ToString(dpFromDate.Text));
                        objBillreport.SetParameterValue("paraToDate", Convert.ToString(dpToDate.Text));

                        objBillreport.SetParameterValue("paraDays", varDays);
                        objBillreport.SetParameterValue("paraDayName", varDayNames);
                    }
                    else if (varReportTypeID == 646)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Card_Payment_Monthwise.rpt");

                        // Monthwise Report
                        objBillreport.SetParameterValue("paraMonths", varMonths);
                        objBillreport.SetParameterValue("paraMonthName", varMonthNames);
                    }
                    else if (varReportTypeID == 647)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Card_Payment_Daywise_Mid.rpt");

                        // Daywise MID Report
                        objBillreport.SetParameterValue("paraFromDate", Convert.ToString(dpFromDate.Text));
                        objBillreport.SetParameterValue("paraToDate", Convert.ToString(dpToDate.Text));

                        objBillreport.SetParameterValue("paraDays", varDays);
                        objBillreport.SetParameterValue("paraDayName", varDayNames);
                    }
                    else if (varReportTypeID == 648)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Card_Payment_Monthwise_Mid.rpt");

                        // Monthwise MID Report
                        objBillreport.SetParameterValue("paraMonths", varMonths);
                        objBillreport.SetParameterValue("paraMonthName", varMonthNames);
                    }
                    else if (varReportTypeID == 649)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Card_Payment_Daywise_Vendor.rpt");

                        // Daywise Vendor Report
                        objBillreport.SetParameterValue("paraFromDate", Convert.ToString(dpFromDate.Text));
                        objBillreport.SetParameterValue("paraToDate", Convert.ToString(dpToDate.Text));

                        objBillreport.SetParameterValue("paraDays", varDays);
                        objBillreport.SetParameterValue("paraDayName", varDayNames);
                    }
                    else if (varReportTypeID == 650)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Card_Payment_Monthwise_Vendor.rpt");

                        // Monthwise Vendor Report
                        objBillreport.SetParameterValue("paraMonths", varMonths);
                        objBillreport.SetParameterValue("paraMonthName", varMonthNames);
                    }
                    // ============================================================
                    // COMMON PARAMETERS - ALL 8 REPORTS
                    // ============================================================
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraConcernId", varConcernId);
                    objBillreport.SetParameterValue("paraMachineId", varMachineId);
                    objBillreport.SetParameterValue("paraProviderId", varProviderId);
                    objBillreport.SetParameterValue("paraTypeId", varTypeId);
                    objBillreport.SetParameterValue("paraConcernName", varConcernName);
                    objBillreport.SetParameterValue("paraMachineName", varMachineName);
                    objBillreport.SetParameterValue("paraVendorName", varVendorName);
                    objBillreport.SetParameterValue("paraTypeName", varTypeName);
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
                btnListPrint.Enabled = true;
                btnListPrint.Focus();
                GC.Collect();
            }
        } 
        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbReportType.Select(int.MaxValue, 0)));
                udfnClear();
                int varReportTypeID = Convert.ToInt32(cmbReportType.SelectedValue);
                dpFromDate.Enabled = false;
                dpToDate.Enabled = false;
                cmbMachineId.Enabled = false;
                cmbVendor.Enabled = false;
                cmbBillType.Enabled = false;
                txtCustomer.Enabled = false;
                txtBillno.Enabled = false;
                txtBillAmt.Enabled = false;
                cmbMultiSelectDays.Enabled = false;
                cmbMultiMonths.Enabled = false;
                lblDays.Text = "";
                lblMonths.Text = "";
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;

                cmbMachineId.SelectedValue = 0;
                cmbVendor.SelectedValue = 0;
                cmbBillType.SelectedValue = 0;
                txtCustomer.Text = "";
                txtBillno.Text = "";
                txtBillAmt.Text = "";
                cmbMachineId.Enabled = true;
                cmbVendor.Enabled = true;
                cmbBillType.Enabled = true;
                if (varReportTypeID == 643)
                {
                    dpFromDate.Enabled = true;
                    dpToDate.Enabled = true;

                    txtCustomer.Enabled = true;
                    txtBillno.Enabled = true;
                    txtBillAmt.Enabled = true;
                }
                else if (varReportTypeID == 644)
                {
                    dpFromDate.Enabled = true;
                    dpToDate.Enabled = true;
                }
                else if (varReportTypeID == 645)
                {
                    dpFromDate.Enabled = true;
                    dpToDate.Enabled = true;

                    cmbMultiSelectDays.Enabled = true;
                }
                else if (varReportTypeID == 646)
                {
                    cmbMultiMonths.Enabled = true;
                }
                else if (varReportTypeID == 647)
                {
                    dpFromDate.Enabled = true;
                    dpToDate.Enabled = true;

                    cmbMultiSelectDays.Enabled = true;
                }
                else if (varReportTypeID == 648)
                {
                    cmbMultiMonths.Enabled = true;
                }
                else if (varReportTypeID == 649)
                {
                    dpFromDate.Enabled = true;
                    dpToDate.Enabled = true;

                    cmbMultiSelectDays.Enabled = true;
                }
                else if (varReportTypeID == 650)
                {
                    cmbMultiMonths.Enabled = true;
                }
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        { 
            lblProductcode.Text = "0";
            lblBrandCode.Text = "0";
            lblGroupCode.Text = "0";
            lblSubGroupCode.Text = "0";
        }
        private void CmbReportType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FocusNextEnabledControl(cmbReportType);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReportType_Leave(object sender, EventArgs e)
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
        private void CmbReportType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void FocusNextEnabledControl(Control currentControl)
        {
            try
            {
                if (currentControl == cmbReportType)
                {
                    cmbConcern.Focus();
                }
                else if (currentControl == cmbConcern)
                {
                    if (dpFromDate.Enabled)
                        dpFromDate.Focus();
                    else if (cmbMachineId.Enabled)
                        cmbMachineId.Focus();
                    else if (cmbVendor.Enabled)
                        cmbVendor.Focus();
                    else if (cmbBillType.Enabled)
                        cmbBillType.Focus();
                }
                else if (currentControl == dpFromDate)
                {
                    if (dpToDate.Enabled)
                        dpToDate.Focus();
                    else if (cmbMachineId.Enabled)
                        cmbMachineId.Focus();
                }
                else if (currentControl == dpToDate)
                {
                    if (cmbMachineId.Enabled)
                        cmbMachineId.Focus();
                    else if (cmbVendor.Enabled)
                        cmbVendor.Focus();
                }
                else if (currentControl == cmbMachineId)
                {
                    if (cmbVendor.Enabled)
                        cmbVendor.Focus();
                    else if (cmbBillType.Enabled)
                        cmbBillType.Focus();
                    else if (txtCustomer.Enabled)
                        txtCustomer.Focus();
                    else if (txtBillno.Enabled)
                        txtBillno.Focus();
                    else if (txtBillAmt.Enabled)
                        txtBillAmt.Focus();
                    else if (cmbMultiSelectDays.Enabled)
                        cmbMultiSelectDays.Focus();
                    else if (cmbMultiMonths.Enabled)
                        cmbMultiMonths.Focus();
                    else
                        btnListPrint.Focus();
                }
                else if (currentControl == cmbVendor)
                {
                    if (cmbBillType.Enabled)
                        cmbBillType.Focus();
                    else if (txtCustomer.Enabled)
                        txtCustomer.Focus();
                    else if (txtBillno.Enabled)
                        txtBillno.Focus();
                    else if (txtBillAmt.Enabled)
                        txtBillAmt.Focus();
                    else if (cmbMultiSelectDays.Enabled)
                        cmbMultiSelectDays.Focus();
                    else if (cmbMultiMonths.Enabled)
                        cmbMultiMonths.Focus();
                    else
                        btnListPrint.Focus();
                }
                else if (currentControl == cmbBillType)
                {
                    if (txtCustomer.Enabled)
                        txtCustomer.Focus();
                    else if (txtBillno.Enabled)
                        txtBillno.Focus();
                    else if (txtBillAmt.Enabled)
                        txtBillAmt.Focus();
                    else if (cmbMultiSelectDays.Enabled)
                        cmbMultiSelectDays.Focus();
                    else if (cmbMultiMonths.Enabled)
                        cmbMultiMonths.Focus();
                    else
                        btnListPrint.Focus();
                }
                else if (currentControl == txtCustomer)
                {
                    if (txtBillno.Enabled)
                        txtBillno.Focus();
                    else if (txtBillAmt.Enabled)
                        txtBillAmt.Focus();
                    else if (cmbMultiSelectDays.Enabled)
                        cmbMultiSelectDays.Focus();
                    else if (cmbMultiMonths.Enabled)
                        cmbMultiMonths.Focus();
                    else
                        btnListPrint.Focus();
                }
                else if (currentControl == txtBillno)
                {
                    if (txtBillAmt.Enabled)
                        txtBillAmt.Focus();
                    else if (cmbMultiSelectDays.Enabled)
                        cmbMultiSelectDays.Focus();
                    else if (cmbMultiMonths.Enabled)
                        cmbMultiMonths.Focus();
                    else
                        btnListPrint.Focus();
                }
                else if (currentControl == txtBillAmt)
                {
                    if (cmbMultiSelectDays.Enabled)
                        cmbMultiSelectDays.Focus();
                    else if (cmbMultiMonths.Enabled)
                        cmbMultiMonths.Focus();
                    else
                        btnListPrint.Focus();
                }
                else if (currentControl == cmbMultiSelectDays)
                {
                    if (cmbMultiMonths.Enabled)
                        cmbMultiMonths.Focus();
                    else
                        btnListPrint.Focus();
                }
                else if (currentControl == cmbMultiMonths)
                {
                    btnListPrint.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReportType_Enter(object sender, EventArgs e)
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

        private void REPORT_CP_RateChange_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 1401;

                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());

                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind();
                //Transaction id 	87
                udfnCmbConcern();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MSTID IN (" + ReportTypeIDs + ")", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_MASTER", "  MST_TransactionID IN (195,0) AND MSTID<>0", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");

                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN(169,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbBillType, "", "MST_DisplayText", "MSTID");

                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (0,141) AND MSTID<>-1 ORDER BY MSTID  ASC", "MST_DisplayText,MSTID", cmbVendor, "", "MST_DisplayText", "MSTID");

                objDataBind.BindComboBoxListSelected("(SELECT 0 AS MachineID, '-All-' AS MachineName " + "UNION ALL " + "SELECT CRDMHID AS MachineID, CRDMH_Name AS MachineName FROM MR_CardMachine WHERE CRDMHID<>-2) AS M", "1=1 ORDER BY MachineID","MachineName,MachineID",cmbMachineId,"","MachineName","MachineID");

                objDataBind = null;
                udfnLoadMonths();
                udfnLoadDays();

                 
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                cmbReportType.SelectedIndex = 0;
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
        private void dpFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.LemonChiffon;
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
                    FocusNextEnabledControl(dpFromDate);
                }
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

        private void dpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
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
                    FocusNextEnabledControl(dpToDate);
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

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyProduct = 1; 
                btnListPrint.Focus();
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

        private void cmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try 
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FocusNextEnabledControl(cmbConcern);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbConcern_Enter(object sender, EventArgs e)
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

        private void cmbMachineId_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbMachineId.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbMachineId_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbMachineId.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbMachineId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {   if (e.KeyCode == Keys.Enter)
                {
                    FocusNextEnabledControl(cmbMachineId);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbMachineId_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbVendor_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbVendor.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbVendor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FocusNextEnabledControl(cmbVendor);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbVendor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbVendor_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbVendor.BackColor = Color.LemonChiffon;
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
                    FocusNextEnabledControl(cmbBillType);
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
                varUpDownKeyGroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_Customer.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_Customer.Visible == false)
                {
                    FocusNextEnabledControl(txtCustomer);
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
                        varUpDownKeyGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyGroup = 0;
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
                                    varUpDownKeyGroup = 1;
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
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        FocusNextEnabledControl(txtCustomer);
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

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
          
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

        private void txtBillno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FocusNextEnabledControl(txtBillno);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtBillno_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBillno.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBillno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBillno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbillamtt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBillAmt.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtbillamtt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FocusNextEnabledControl(txtBillAmt);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbillamtt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBillAmt.BackColor = Color.LemonChiffon;
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
                    FocusNextEnabledControl(cmbMultiSelectDays);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbMultiSelectDays_KeyPress(object sender, KeyPressEventArgs e)
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
                    FocusNextEnabledControl(cmbMultiMonths);
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

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyGroup == 0)
                {
                    //lvGroup.Items.Clear();
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();

                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 3;
                    obj.paraCUS_TypeID = 2;
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
                                    DGV_Customer.Columns["Customer"].Width = 150;
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
                varUpDownKeyGroup = 1;
                udfnCustomerAutocomplete();
                FocusNextEnabledControl(txtCustomer);
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
                        varUpDownKeyGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyGroup = 0;
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
                                    varUpDownKeyGroup = 1;
                                    udfnCustomerAutocomplete();
                                    DGV_Customer.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        FocusNextEnabledControl(txtCustomer);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbMultiMonths_KeyPress(object sender, KeyPressEventArgs e)
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
         

        private void REPORT_CP_RateChange_KeyDown(object sender, KeyEventArgs e)
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
        public void udfnCmbConcern()
        {
            try
            {
                //cmbConcern.Focus();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(2, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
    }
}
