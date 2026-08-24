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
        ToolTip tpSupplier = new ToolTip();
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
                string varMonthIds = "", varMonthName = "";
                var selIds = cmbMultiMonths.CheckedIds;
                var selItems = months.Where(m => selIds.Contains(m.Id)).ToList();
                lblMonths.Text = string.Join(", ", selItems.Select(x => x.Text));
                var selDayIds = cmbMultiSelectDays.CheckedIds;
                var selDayItems = days.Where(d => selDayIds.Contains(d.Id)).ToList();
                lblDays.Text = string.Join(", ", selDayItems.Select(x => x.Text));
                //if (Convert.ToInt32(cmbReportType.SelectedValue) == 334)
                //{
                //    lblMonths.Text = string.Join(", ", selItems.Select(x => x.Text));
                //}
                //else
                //{
                //    lblMonths.Text = "";
                //}
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
                //if (skipControl != txtGroup)
                //{
                //    varUpDownKeyGroup = 0;
                //    DGV_FilterGroup.DataSource = null;
                //    DGV_FilterGroup.Visible = false;
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
                    cmbReportType.Focus();
                }
                else
                {
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

                var selDayIds = cmbMultiSelectDays.CheckedIds;

                var selDayItems = days
                    .Where(d => selDayIds.Contains(d.Id))
                    .ToList();

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
                string varMonths = "0";

                var selIds = cmbMultiMonths.CheckedIds;

                var selItems = months
                    .Where(m => selIds.Contains(m.Id))
                    .ToList();

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
                /* 294 - Rate Changing Report
                 295 - Live Rate Change Report */
                if (Convert.ToString(cmbReportType.SelectedValue) == "294")
                {
                    dpFromDate.Enabled = true;
                    dpToDate.Enabled = true;
                }
                if (Convert.ToString(cmbReportType.SelectedValue) == "295")
                {
                    dpFromDate.Enabled = false;
                    dpToDate.Enabled = false;
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
                    cmbConcern.Focus();
                   
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
                int currentMUCode = 80312;

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
                //objDataBind.BindComboBoxListSelected("DEF_MASTER", "  MSTID IN (" + ReportTypeIDs + ")", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "  MST_TransactionID IN (195,0) AND MSTID<>0", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN(169,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbBillType, "", "MST_DisplayText", "MSTID");

                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (0,141) AND MSTID<>-1 ORDER BY MSTID  ASC", "MST_DisplayText,MSTID", cmbVendor, "", "MST_DisplayText", "MSTID");

                objDataBind.BindComboBoxListSelected("(SELECT 0 AS MachineID, '- All -' AS MachineName " + "UNION ALL " + "SELECT CRDMHID AS MachineID, CRDMH_Name AS MachineName FROM MR_CardMachine WHERE CRDMHID<>-2) AS M", "1=1 ORDER BY MachineID", "MachineName,MachineID", cmbMachineId, "", "CRDMH_Name", "CRDMHID");
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
                    dpToDate.Focus();
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
                    cmbMachineId.Focus();
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
            try {
                if (dpFromDate.Enabled == true)
                {
                    dpFromDate.Focus();
                }
                else
                {
                    cmbMachineId.Focus();
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
                    cmbVendor.Focus();
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
                    cmbBillType.Focus();
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
                    txtCustomer.Focus();
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
                if (e.KeyCode == Keys.Enter)
                {
                    txtBillno.Focus();
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
                    txtBillAmt.Focus();
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
                    cmbMultiSelectDays.Focus();
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
                    btnListPrint.Focus();
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
                    btnListPrint.Focus();
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
