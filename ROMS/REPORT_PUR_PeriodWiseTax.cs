using System;
using System.Collections.Generic;
using System.ComponentModel;
using ROMS.Model;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace ROMS
{
    public partial class REPORT_PUR_PeriodWiseTax : Form
    {
        MainForm objMainForm = new MainForm();
        private ContextMenuStrip contextMenu;
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        private ToolTip tpReportType = new ToolTip();
        private ToolTip tpMonths = new ToolTip();
        public int varUpDownKeySupplier = 0;
        private List<ComboItem> months;
        public REPORT_PUR_PeriodWiseTax()
        {
            InitializeComponent();
            windowControl.Initialize(tsPeriodWiseReport, this);
        }
        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbStatus_KeyPress(object sender, KeyPressEventArgs e)
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
        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
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
                    string varMonthIds = "";
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 331)
                    {
                        var selIds = cmbMultiMonths.CheckedIds;
                        var selItems = months.Where(m => selIds.Contains(m.Id)).ToList();
                        varMonthIds = string.Join(", ", selItems.Select(x => x.Id));
                        epReport.SetError(cmbMultiMonths, "Please select months.");
                        cmbMultiMonths.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpMonths.ShowAlways = true;
                        tpMonths.Show("Please select months.", cmbMultiMonths, 5000);
                        cmbMultiMonths.Focus();
                    }
                    if (varMonthIds.Trim() != "" || Convert.ToInt32(cmbReportType.SelectedValue) != 331)
                    {
                        udfnPurchaseReport(varFlag);
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
        public void udfnPurchaseReport(int varFlag)
        {
            try
            {
                string varMonthIds = "", varMonthName = "";
                var selIds = cmbMultiMonths.CheckedIds;
                var selItems = months.Where(m => selIds.Contains(m.Id)).ToList();
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 331)
                {
                    lblMonths.Text = string.Join(", ", selItems.Select(x => x.Text));
                }
                else
                {
                    lblMonths.Text = "";
                }
                varMonthName = lblMonths.Text;
                varMonthIds = string.Join(", ", selItems.Select(x => x.Id));
                if (varMonthIds.Trim() == "")
                {
                    varMonthIds = "0";
                    varMonthName = "-All-";
                }
                epReport.Clear();
                int varViewType = 18;
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 331)
                {
                    varViewType = 19;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 351)
                {
                    varViewType = 31;
                }
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnPurHsnReport("TRNG_Purchase_Reports_18_22", varViewType, Convert.ToInt32(cmbSupplierType.SelectedValue), "", 0, dpFromDate.Text, dpToDate.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", varMonthIds, 0, 0, 0, 0, 0, 0, "");
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                string varReportName = "";
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 330)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_Tax_TaxDetails_DayWise.rpt");
                        varReportName = "PUR_Tax_TaxDetails_DayWise";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 331)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_Tax_TaxDetails_MonthWise.rpt");
                        objBillreport.SetParameterValue("paraMonthName", varMonthName);
                        objBillreport.SetParameterValue("paraMonth", varMonthIds);
                        objBillreport.SetParameterValue("paraMonth", varMonthIds, objBillreport.Subreports[0].Name.ToString());
                        varReportName = "PUR_Tax_TaxDetails_MonthWise";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 351)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_Tax_TaxDetails_DayWise_Summary.rpt");
                        varReportName = "PUR_Tax_TaxDetails_DayWise_Summary";
                    }
                    objBillreport.SetParameterValue("paraSupplierType", Convert.ToInt32(cmbSupplierType.SelectedValue));
                    objBillreport.SetParameterValue("paraHSNCode", 0);
                    objBillreport.SetParameterValue("paraGST", 0);
                    objBillreport.SetParameterValue("paraCompanyId", 0);
                    objBillreport.SetParameterValue("paraInvioceType", 0);
                    objBillreport.SetParameterValue("paraPaymentType", 0);
                    objBillreport.SetParameterValue("paraPurchaseType", 0);
                    objBillreport.SetParameterValue("paraConditionType", 0);
                    objBillreport.SetParameterValue("paraBrandID", 0);
                    objBillreport.SetParameterValue("paraAlpha", "");
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text);
                    objBillreport.SetParameterValue("paraToDate", dpToDate.Text);
                    objBillreport.SetParameterValue("paraFlag", 0);
                    objBillreport.SetParameterValue("paraProductNameType", 0);
                    objBillreport.SetParameterValue("paraGroupId", 0);
                    objBillreport.SetParameterValue("paraSubgroupId", 0);
                    objBillreport.SetParameterValue("paraProductId", 0);
                    objBillreport.SetParameterValue("paraSupplierID", 0);
                    objBillreport.SetParameterValue("paraScheduleID", 0);


                    objBillreport.SetParameterValue("paraSupplierType", Convert.ToInt32(cmbSupplierType.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraHSNCode", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraGST", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraCompanyId", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraInvioceType", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraPaymentType", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraPurchaseType", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraConditionType", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraBrandID", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraAlpha", "", objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraToDate", dpToDate.Text, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraProductNameType", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraGroupId", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraSubgroupId", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraProductId", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraSupplierID", 0, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraScheduleID", 0, objBillreport.Subreports[0].Name.ToString());

                    objBillreport.SetParameterValue("paraSupplierTypeName", cmbSupplierType.Text);

                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
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
        private void REPORT_CP_City_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80604;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                udfnLoadMonths();
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                DataBind objDataBind = new DataBind(); //Transaction id 	98
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MSTID IN (" + ReportTypeIDs + ") ORDER BY MST_OrderID ASC" 
                    , "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Months", "MONID<>-1", "MON_Name,MONID", cmbMonths, "", "MON_Name", "MONID");
                objDataBind = null;
                cmbSupplierType.SelectedValue = 0;
                cmbMonths.SelectedValue = 0;
                cmbMonths.SelectedValue = 0;
                cmbReportType.SelectedValue = -1;
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

        private void REPORT_CP_City_KeyDown(object sender, KeyEventArgs e)
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

        private void DpFromDate_Enter(object sender, EventArgs e)
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
        private void DpFromDate_KeyDown(object sender, KeyEventArgs e)
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
        private void DpFromDate_Leave(object sender, EventArgs e)
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
        private void DpFromDate_ValueChanged(object sender, EventArgs e)
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

        private void CmbSupplierType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSupplierType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbSupplierType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbMultiMonths.Enabled == true)
                    {
                        cmbMultiMonths.Focus();
                    }
                    else
                    {
                        btnListPrint.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbSupplierType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbSupplierType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSupplierType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_Enter(object sender, EventArgs e)
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

        private void DpToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSupplierType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpToDate_Leave(object sender, EventArgs e)
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

        private void CmbReportType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbReportType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReportType_KeyDown(object sender, KeyEventArgs e)
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
                        cmbSupplierType.Focus();
                    }
                }
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

        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMonths.Text = "";
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
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 331)
                {
                    dpFromDate.Value = MainForm.pbCurrentDate;
                    dpToDate.Value = MainForm.pbCurrentDate;
                    dpFromDate.Enabled = false;
                    dpToDate.Enabled = false;
                    cmbMonths.Enabled = true;
                    cmbMultiMonths.Enabled = true;
                }
                else
                {
                    dpFromDate.Enabled = true;
                    dpToDate.Enabled = true;
                    cmbMonths.SelectedValue = 0;
                    cmbMonths.Enabled = false;
                    cmbMultiMonths.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMonths_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbMonths.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMonths_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbMonths_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbMonths_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbMonths.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMultiMonths_Enter(object sender, EventArgs e)
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

        private void CmbMultiMonths_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbMultiMonths_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbMultiMonths_Leave(object sender, EventArgs e)
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

        private void SetupPurchaseTax()
        {
            try
            {
                // Create ContextMenuStrip (does NOT hide your label)
                contextMenu = new ContextMenuStrip();
                contextMenu.Font = new Font("Oswald", 10, FontStyle.Regular);
                contextMenu.Items.Add("Purchase Bill Wise Tax", null, (s, ev) =>
                {
                    MainForm.objREPORT_PUR_BillWiseTax = new REPORT_PUR_BillWiseTax();
                    MainForm.objREPORT_PUR_BillWiseTax.MdiParent = this.ParentForm;
                    MainForm.objREPORT_PUR_BillWiseTax.Show();
                });
                contextMenu.Items.Add("Purchase TCS Value", null, (s, ev) =>
                {
                    MainForm.objREPORT_PUR_TCSValue = new REPORT_PUR_TCSValue();
                    MainForm.objREPORT_PUR_TCSValue.MdiParent = this.ParentForm;
                    MainForm.objREPORT_PUR_TCSValue.Show();
                });

                contextMenu.Items.Add("All Purchase Tax", null, (s, ev) =>
                {
                    MainForm.objREPORT_PUR_AllTax = new REPORT_PUR_AllTax();
                    MainForm.objREPORT_PUR_AllTax.MdiParent = this.ParentForm;
                    MainForm.objREPORT_PUR_AllTax.Show();
                });
                contextMenu.Items.Add("Purchase Period Wise Tax", null, (s, ev) =>
                {
                    MainForm.objREPORT_PUR_PeriodWiseTax = new REPORT_PUR_PeriodWiseTax();
                    MainForm.objREPORT_PUR_PeriodWiseTax.MdiParent = this.ParentForm;
                    MainForm.objREPORT_PUR_PeriodWiseTax.Show();
                });

                contextMenu.Items.Add("HSN Wise Tax Detail Summary", null, (s, ev) =>
                {
                    MainForm.objREPORT_HSN_Tax_Summary = new REPORT_HSN_Tax_Summary();
                    MainForm.objREPORT_HSN_Tax_Summary.MdiParent = this.ParentForm;
                    MainForm.objREPORT_HSN_Tax_Summary.Show();
                });

                contextMenu.Items.Add("HSN - Purchase Hsn Wise", null, (s, ev) =>
                {
                    MainForm.objREPORT_HSN_Code = new REPORT_HSN_Code();
                    MainForm.objREPORT_HSN_Code.MdiParent = this.ParentForm;
                    MainForm.objREPORT_HSN_Code.Show();
                });
                contextMenu.Items.Add("HSN - Purchase Hsn Name Wise Product", null, (s, ev) =>
                {
                    MainForm.objREPORT_HSN_NameWise_Product = new REPORT_HSN_NameWise_Product();
                    MainForm.objREPORT_HSN_NameWise_Product.MdiParent = this.ParentForm;
                    MainForm.objREPORT_HSN_NameWise_Product.Show();
                });
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
    }
}
