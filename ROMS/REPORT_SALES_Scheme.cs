using ROMS.Model;
using ROMS.Service_Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms; 

namespace ROMS
{
    public partial class REPORT_SALES_Scheme : Form
    {
        MainForm objMainForm = new MainForm();
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        private ToolTip tpReportType = new ToolTip();
        private ToolTip tpDays = new ToolTip();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument(); public int varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyProduct = 0, varUpDownKeyBrand = 0, varUpDownKeyLocation=0;
        public string pbRateCategoryIDs = "";
        private List<ComboItem> days;
        public REPORT_SALES_Scheme()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tsProductCategoryReport, this);
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
                //if (skipControl != txtGroup)
                //{
                //    varUpDownKeyGroup = 0; 
                //    DGV_FilterGroup.Visible = false;
                //}
                //if (skipControl != txtSubGroup)
                //{
                //    varUpDownKeySubgroup = 0; 
                //    DGV_FilterSubgroup.Visible = false;
                //}
                //if (skipControl != txtBrand)
                //{
                //    varUpDownKeyBrand = 0; 
                //    DGV_FilterBrand.Visible = false;
                //} 
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
                RPTViewer.ReportSource = null;
                RPTViewer.Visible = false;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();

                if (Convert.ToInt32(cmbSchemeType.SelectedValue) == -1)
                {
                    epReport.SetError(cmbSchemeType, "Please select report type.");
                    cmbSchemeType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReportType.ShowAlways = true;
                    tpReportType.Show("Please select report type.", cmbSchemeType, 5000);
                    cmbSchemeType.Focus();
                    return;
                }
                else
                {
                    int varDaysType = Convert.ToInt32(cmbDaysType.SelectedValue);
                    if (varDaysType != 0)
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
                    udfnPrint(0);
                }

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
                epReport.Clear(); int varViewType = 0,paraFlag=0;
                string varApplicationRateIDs="0", varApplicationRateType = "-All-", varSubgroupName = "-All-", varBrandName = "-All-", varReportType="";
                int varGroupId = 0, varSubgroupId = 0, varBrandId = 0;

                var selDayIds = cmbMultiSelectDays.CheckedIds;
                var selDayItems = days.Where(d => selDayIds.Contains(d.Id)).ToList();
                btnView.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                 Application.DoEvents();
                int varPrint = 0; string varDays = "0"; string varDayName = "-All-";

                if (Convert.ToInt32(cmbDaysType.SelectedValue) == 0)
                {
                    lblDays.Text = ""; 
                    varDays = "0"; 
                    varDayName = "-All-"; 
                }
                else if (Convert.ToInt16(cmbDaysType.SelectedValue) == 701)
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
                if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 626)
                {
                    varViewType = 0;
                }
                else if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 627)
                { varViewType = 1; }
                else if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 628)
                { varViewType = 2; paraFlag = 628; }
                else if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 629)
                { varViewType = 2; paraFlag = 629; }
                else if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 630)
                { varViewType = 2; paraFlag = 630; }


                TRN_Scheme objTRN_Scheme = new TRN_Scheme();
                objTRN_Scheme.ViewType = varViewType;  
                objTRN_Scheme.paraFlag = paraFlag;  
                objTRN_Scheme.paraConcernID = Convert.ToInt32(cmbConcern.SelectedValue);  
                objTRN_Scheme.paraAppRateType = Convert.ToInt32(cmbRateCategory.SelectedValue); ;  
                objTRN_Scheme.paraRecursive = Convert.ToInt32(cmbRecursive.SelectedValue);  
                objTRN_Scheme.paraValitityType = Convert.ToInt32(cmbValidityType.SelectedValue);  
                objTRN_Scheme.paraDaysType = Convert.ToInt32(cmbDaysType.SelectedValue);  
                objTRN_Scheme.paraSchAvailTime = Convert.ToInt32(cmbSchemeAvailTime.SelectedValue);  
                objTRN_Scheme.paraAppStatus = Convert.ToInt32(cmbAppStatus.SelectedValue);  
                objTRN_Scheme.paraStatus = Convert.ToInt32(cmbSts.SelectedValue);  
                objTRN_Scheme.paraDaysId = varDays;  
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnSchemeReport(objTRN_Scheme);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                     
                    if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 626)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_SCH_ProductScheme.rpt");
                        objBillreport.SetParameterValue("paraRecursiveName", Convert.ToString(cmbRecursive.Text));
                    }
                    else if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 627)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_SCH_RateScheme.rpt");
                    } 
                    else if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 628 || Convert.ToInt32(cmbSchemeType.SelectedValue) == 629)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_SCH_DiscountScheme_Value.rpt");
                        objBillreport.SetParameterValue("paraFlag", Convert.ToInt16(cmbSchemeType.SelectedValue));
                        if(Convert.ToInt32(cmbSchemeType.SelectedValue) == 628)
                        {
                            varReportType = "Bill Discount Scheme(Value) Report";
                        }
                        else if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 629)
                        {
                            varReportType = "Bill Discount Scheme(Percentage) Report";
                        }
                        objBillreport.SetParameterValue("paraReportName", varReportType); 
                    }
                    else if (Convert.ToInt32(cmbSchemeType.SelectedValue) == 703)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_SCH_DiscountScheme_Product.rpt");
                    }
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName ?? "");
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName ?? ""); 
                    objBillreport.SetParameterValue("paraRecursive", Convert.ToInt16(cmbRecursive.SelectedValue) );
                    objBillreport.SetParameterValue("paraDaysType", Convert.ToInt16(cmbDaysType.SelectedValue) );
                    objBillreport.SetParameterValue("paraSchemeAvailTime", Convert.ToInt16(cmbSchemeAvailTime.SelectedValue));
                    objBillreport.SetParameterValue("paraAppRateType", Convert.ToInt16(cmbRateCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraConcernID", Convert.ToInt16(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraSchAvailTime", Convert.ToInt16(cmbSchemeAvailTime.SelectedValue));
                    objBillreport.SetParameterValue("paraStatus", Convert.ToInt16(cmbSts.SelectedValue));
                    objBillreport.SetParameterValue("paraAppStatus", Convert.ToInt16(cmbAppStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraValitityType", Convert.ToInt16(cmbValidityType.SelectedValue));
                    objBillreport.SetParameterValue("paraDaysId", varDays);
                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraValidityName", Convert.ToString(cmbValidityType.Text));
                    objBillreport.SetParameterValue("paraApplicableRateName", Convert.ToString(cmbRateCategory.Text));
                    objBillreport.SetParameterValue("paraSATName", Convert.ToString(cmbSchemeAvailTime.Text));
                    objBillreport.SetParameterValue("paraDaysName", varDayName);
                    
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
                        string varReportName = "Product_Category";
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

                dynamicToolStripLabelControl1.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 1404;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicToolStripLabelControl1.BindMenuHierarchy(currentMUCode);
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
                DataBind objDataBind = new DataBind();


                objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID in(1,2) and COMID !=-1 Order by COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (190) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSchemeType, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,214) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbRecursive, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,167) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbRateCategory, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,159) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbValidityType, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,215) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbDaysType, "", "MST_DisplayText", "MSTID");  
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,160) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSchemeAvailTime, "", "MST_DisplayText", "MSTID");  
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (0,31) AND STSID NOT IN (-1)  ORDER BY STSID", "STS_Name,STSID", cmbAppStatus, "", "STS_Name", "STSID");  
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (0,1) AND STSID NOT IN (-1)  ORDER BY STSID", "STS_Name,STSID", cmbSts, "", "STS_Name", "STSID");  
                objDataBind = null;
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 32;
                DataSet objDTable = new DataSet();
                SPDataService objdSer = new SPDataService();
                objDTable = objdSer.udfnMaster(objMR_Master);
                objdSer.CloseConnection();
                udfnLoadDays();
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

        private void btnTelegram_Click(object sender, EventArgs e)
        {
            udfnPrint(1);
        }      
        private void cmbconcern_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbConcern.BackColor = Color.LemonChiffon;
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
                    cmbConcern.Focus();
                    e.Handled = true;
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

        private void cmbRecursive_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbRecursive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRecursive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRateCategory.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRecursive_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbRecursive_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbRecursive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }      

        private void cmbValidityType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbValidityType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbValidityType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbDaysType.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbValidityType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbValidityType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbValidityType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDaysType_Enter(object sender, EventArgs e) 
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbDaysType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDaysType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbMultiSelectDays.Enabled == true)
                    {
                        cmbMultiSelectDays.Focus();
                    }
                    else
                    {
                        cmbSchemeAvailTime.Focus();
                    } 
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDaysType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbDaysType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDaysType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSchemeAvailTime_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbSchemeAvailTime.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSchemeAvailTime_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSts.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSchemeAvailTime_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbSchemeAvailTime_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSchemeAvailTime.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbAppStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbAppStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRateCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbRateCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRateCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbValidityType.Enabled == true)
                    {
                        cmbValidityType.Focus();
                    }
                    else { cmbDaysType.Focus(); }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRateCategory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbRateCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbRateCategory.BackColor = Color.White;
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
                    cmbSchemeAvailTime.Focus();
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

        private void cmbSchemeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchemeType.SelectedValue == null)
                return;
             

            if (!int.TryParse(
                cmbSchemeType.SelectedValue.ToString(),
                out int varReportType))
            {
                return;
            } 
            cmbConcern.SelectedValue = 0;
            cmbRecursive.SelectedValue = 0;
            cmbRateCategory.SelectedValue = 0;
            cmbValidityType.SelectedValue = 0;
            cmbDaysType.SelectedValue = 0;
            cmbSchemeAvailTime.SelectedValue = 0;
            cmbAppStatus.SelectedValue = 0;   
            cmbMultiSelectDays.Enabled = false; 
            lblDays.Text = ""; 
            epReport.Clear(); 

            if(Convert.ToInt16(cmbSchemeType.SelectedValue) != 626)
            {
                cmbRecursive.Enabled = false;
            }
            if( Convert.ToInt16(cmbSchemeType.SelectedValue)== 628 || Convert.ToInt16(cmbSchemeType.SelectedValue) == 629|| Convert.ToInt16(cmbSchemeType.SelectedValue) == 703)
            {
                cmbValidityType.Enabled = false;
            }
            else { cmbValidityType.Enabled = true; }
        }

        private void cmbDaysType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbDaysType.SelectedValue) != 0)
                {
                    cmbMultiSelectDays.Enabled = true;
                }
                else
                {
                    lblDays.Text = "";  
                    cmbMultiSelectDays.Enabled = false; 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSts_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbSts.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbAppStatus.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSts_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbSts_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSts.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbconcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbRecursive.Enabled == true)
                    {
                        cmbRecursive.Focus();
                    }
                    else
                    {
                        cmbRateCategory.Focus();
                    }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbconcern_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbconcern_Leave(object sender, EventArgs e)
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

        private void cmbOrderType_KeyPress(object sender, KeyPressEventArgs e)
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
         
    }
}
