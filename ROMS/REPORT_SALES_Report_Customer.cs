using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace ROMS
{
    public partial class REPORT_SALES_Report_Customer : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyRoute = 0, varUpDownKeyArea = 0, varUpDownKeyGroup = 0, varUpDownKeyCity = 0;

        private ToolTip tpReportType = new ToolTip();
        public REPORT_SALES_Report_Customer()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tpRouteReport, this);
        }
        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbFilter.Enabled == true)
                    { cmbFilter.Focus(); }
                    else if (txtRoute.Enabled == true)
                    { txtRoute.Focus(); }
                    else if (txtArea.Enabled == true)
                    { txtArea.Focus(); }
                    else if (cmbVerificationOnLoc.Enabled == true)
                    { cmbVerificationOnLoc.Focus(); }
                    else if (cmbDeliveryPrefernce.Enabled == true)
                    { cmbDeliveryPrefernce.Focus(); }
                    else if (cmbPreferedTransport.Enabled == true)
                    { cmbPreferedTransport.Focus(); }
                    else if (cmbPreferedPeriod.Enabled == true)
                    { cmbPreferedPeriod.Focus(); }
                    else if (cmbPackingType.Enabled == true)
                    { cmbPackingType.Focus(); }
                    else if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    {   btnListPrint.Focus();  }
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

        private void CmbStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    BeginInvoke(new Action(() => cmbStatus.Select(int.MaxValue, 0)));
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
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
                if (skipControl != txtRoute)
                {
                    varUpDownKeyRoute = 0;
                    DGV_FilterRoute.DataSource = null;
                    DGV_FilterRoute.Visible = false;
                }
                if (skipControl != txtArea)
                {
                    varUpDownKeyArea = 0;
                    DGV_FilterArea.DataSource = null;
                    DGV_FilterArea.Visible = false;
                }
                if (skipControl != txtCustomer)
                {
                    varUpDownKeyGroup = 0;
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
        private void BtnListPrint_Click(object sender, EventArgs e)
        {
            try
            {
                RPTViewer.ReportSource = null;
                RPTViewer.Visible = false;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
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
                    epReport.Clear();
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
                int varRouteId = 0,varAreaId = 0,varCustomerId = 0,varViewType=0,varCityId=0;
                string varRouteName = "-All-",varAreaName = "-All-",varCustomerName = "-All-",varCityName="--All--";
                if (txtRoute.Text.Trim() != "")
                {
                    varRouteId = Convert.ToInt32(lblRouteId.Text);
                    varRouteName = txtRoute.Text.Trim();
                }
                if (txtArea.Text.Trim() != "")
                {
                    varAreaId = Convert.ToInt32(lblAreaId.Text);
                    varAreaName = txtArea.Text.Trim();
                }
                if (txtCustomer.Text.Trim() != "")
                {
                    varCustomerId = Convert.ToInt32(lblCustomerId.Text);
                    varCustomerName = txtCustomer.Text.Trim();
                }
                if (txtCity.Text.Trim() != "")
                {
                    varCityId = Convert.ToInt32(lblcityid.Text);
                    varCityName = txtCity.Text.Trim();
                }
                
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int reportType = Convert.ToInt32(cmbReportType.SelectedValue);
                if (reportType == 714)
                {
                    varViewType = 0;
                }
                else if (reportType == 715)
                {
                    varViewType = 1;
                }
                else if (reportType == 716)
                {
                    varViewType = 2;
                }
                else if (reportType == 717)
                {
                    varViewType =3;
                }
                else if (reportType == 718)
                {
                    varViewType = 4;
                }
                else if (reportType == 719)
                {
                    varViewType = 5;
                }
                else if (reportType == 720)
                {
                    varViewType = 6;
                }
                else if (reportType == 721)
                {
                    varViewType = 7;
                }

                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                MR_Sales objMR_Sales = new MR_Sales();
                
                objMR_Sales.paraViewType = varViewType;     
                objMR_Sales.paraGSTType = Convert.ToInt32(cmbGSTType.SelectedValue);   
                objMR_Sales.paraCusType = Convert.ToInt32(cmbCustomerType.SelectedValue);
                objMR_Sales.paraCityID = varCityId;
                objMR_Sales.paraCustomerName = txtCustomer.Text;   
                objMR_Sales.paraStatus = Convert.ToInt32(cmbStatus.SelectedValue);   
                objMR_Sales.paraFilterType = Convert.ToInt32(cmbFilter.SelectedValue);   
                objMR_Sales.paraCategoryType = Convert.ToInt32(cmbCustomerCategory.SelectedValue);   
                objMR_Sales.paraRouteID = varRouteId;   
                objMR_Sales.paraAreaID = varAreaId;   
                objMR_Sales.paraDeliPrefernceID = Convert.ToInt32(cmbDeliveryPrefernce.SelectedValue);   
                objMR_Sales.paraCusVerifyLoc = Convert.ToInt32(cmbVerificationOnLoc.SelectedValue);   
                objMR_Sales.paraCustomerID = varCustomerId;  
                objMR_Sales.paraGSTINStatus = Convert.ToInt32(cmbGstinStatus.SelectedValue);  
                objMR_Sales.paraPreferedTransID = Convert.ToInt32(cmbPreferedTransport.SelectedValue);  
                objMR_Sales.paraPrefPeriod = Convert.ToInt32(cmbPreferedPeriod.SelectedValue);  
                objMR_Sales.paraPackingTypeID = Convert.ToInt32(cmbPackingType.SelectedValue);  
                objMR_Sales.paraPackingPrefId = Convert.ToInt32(cmbPackingPreference.SelectedValue);  
                objDs = objdserv.udfnCustomerMasterReports(objMR_Sales);
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    
                    switch (reportType)
                    {
                        case 714:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_CUS_Contact.rpt"); 
                            break; 
                        case 715:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_CUS_Address.rpt");
                            objBillreport.SetParameterValue("paraFilterName", Convert.ToString(cmbFilter.Text)); 
                            break;
                        case 716:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_CUS_Route.rpt");
                            objBillreport.SetParameterValue("paraRouteName",varRouteName); 
                            objBillreport.SetParameterValue("paraAreaName", varAreaName); 
                            break;
                        case 717:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_CUS_Delivery_Preference.rpt");
                            objBillreport.SetParameterValue("paraDeliPreferenceName", Convert.ToString(cmbDeliveryPrefernce.Text));
                            objBillreport.SetParameterValue("paraPreferedTransportName", Convert.ToString(cmbPreferedTransport.Text));
                            objBillreport.SetParameterValue("paraPreferedTransID", Convert.ToString(cmbPreferedTransport.SelectedValue));
                            
                            break;
                        case 718:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_CUS_DeliveryTiming_PackingPreference.rpt");
                            objBillreport.SetParameterValue("paraDeliPreferenceName", Convert.ToString(cmbDeliveryPrefernce.Text));
                            objBillreport.SetParameterValue("paraPreferedTransportName", Convert.ToString(cmbPreferedTransport.Text));
                            objBillreport.SetParameterValue("paraPreferedPeriod", Convert.ToString(cmbPreferedPeriod.Text));
                            objBillreport.SetParameterValue("paraStatusName",Convert.ToString(cmbStatus.Text));
                            break;
                        case 719:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_CUS_Limit_Period_SchEligible.rpt");
                            objBillreport.SetParameterValue("paraDeliPreferenceName", Convert.ToString(cmbDeliveryPrefernce.Text));
                            objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                            break;
                        case 720:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_CUS_GST_Detail.rpt");
                            objBillreport.SetParameterValue("paraDeliPreferenceName", Convert.ToString(cmbDeliveryPrefernce.Text));
                            objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                            objBillreport.SetParameterValue("paraGSTINStatus", Convert.ToString(cmbGstinStatus.SelectedValue));
                            break;
                        case 721: 
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_CUS_ContactPersonDetail.rpt");
                            break;

                    }
                    objBillreport.SetParameterValue("paraAreaID", varAreaId);
                    objBillreport.SetParameterValue("paraCategoryType", Convert.ToInt16(cmbCustomerCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraCityID", varCityId);
                    objBillreport.SetParameterValue("paraCustomerID", varCustomerId);
                    objBillreport.SetParameterValue("paraCustomerName", varCustomerName);
                    objBillreport.SetParameterValue("paraCusType", Convert.ToInt16(cmbCustomerType.SelectedValue));
                    objBillreport.SetParameterValue("paraCusVerifyLoc", Convert.ToInt16(cmbVerificationOnLoc.SelectedValue));
                    objBillreport.SetParameterValue("paraDeliPrefernceID", Convert.ToInt16(cmbDeliveryPrefernce.SelectedValue));
                    objBillreport.SetParameterValue("paraFilterType", Convert.ToInt16(cmbFilter.SelectedValue));
                    objBillreport.SetParameterValue("paraGSTType", Convert.ToInt16(cmbGSTType.SelectedValue));
                    objBillreport.SetParameterValue("paraPackingPrefId", Convert.ToInt16(cmbPackingPreference.SelectedValue));
                    objBillreport.SetParameterValue("paraPackingTypeID", Convert.ToInt16(cmbPackingType.SelectedValue));
                    objBillreport.SetParameterValue("paraPrefPeriod", Convert.ToInt16(cmbPreferedPeriod.SelectedValue));
                    objBillreport.SetParameterValue("paraRouteID", varRouteId);
                    objBillreport.SetParameterValue("paraStatus", Convert.ToInt16(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraCusName", varCustomerName);
                    objBillreport.SetParameterValue("paraGSTTypeName", Convert.ToString(cmbGSTType.Text));
                    objBillreport.SetParameterValue("paraCusTypeName", Convert.ToString(cmbCustomerType.Text));
                    objBillreport.SetParameterValue("paraCusCategoryName", Convert.ToString(cmbCustomerCategory.Text));
                    objBillreport.SetParameterValue("paraCityName", varCityName); 
                    objBillreport.SetParameterValue("paraUserName",MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraHostName",MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraStatus", Convert.ToInt32(cmbStatus.SelectedValue)); 
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
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
        private void REPORT_CP_Route_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 140211;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MSTID IN (" + ReportTypeIDs + ")", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (29) OR STSID=0", "STS_Name,STSID", cmbGstinStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("MR_Customer_Type", "CusTypeID<>-1 ORDER BY CusTypeID", "CusType_Name,CusTypeID", cmbCustomerCategory, "", "CusType_Name", "CusTypeID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,157) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbGSTType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,206) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbCustomerType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,221) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbFilter, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,4) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbVerificationOnLoc, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,158) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbDeliveryPrefernce, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,216) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPreferedTransport, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,218) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPreferedPeriod, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,217) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPackingType, "", "MST_DisplayText", "MSTID");

                //objDataBind.BindComboBoxListSelected("MR_PackingInstruction", "  PIID IN (1,2,3,6) ORDER BY PI_EName", "PI_EName,PIID", cmbPackingPreference, "", "PI_EName", "PIID");
                cmbPackingPreference.DataSource = null;
                SPDataService objdserv = new SPDataService();
                MR_Master objMR_Master = new MR_Master();
                DataSet objDT = new DataSet();
                objMR_Master.ViewType = 45;
                DataSet objds = new DataSet();
                objds = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objds != null)
                {
                    if (objds.Tables.Count > 0)
                    {
                        if (objds.Tables[0].Rows.Count > 0)
                        {
                            cmbPackingPreference.ValueMember = "ID";
                            cmbPackingPreference.DisplayMember = "PackingInstruction";
                            cmbPackingPreference.DataSource = objds.Tables[0];
                        }
                    }
                } 
                cmbStatus.SelectedValue = 0;
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
            } 
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void REPORT_CP_Route_KeyDown(object sender, KeyEventArgs e)
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

        private void txtRoute_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtRoute.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRoute_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyRoute = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterRoute.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterRoute.Visible == false)
                {
                     if (txtArea.Enabled == true)
                    { txtArea.Focus(); }
                    else if (cmbVerificationOnLoc.Enabled == true)
                    { cmbVerificationOnLoc.Focus(); }
                    else if (cmbDeliveryPrefernce.Enabled == true)
                    { cmbDeliveryPrefernce.Focus(); }
                    else if (cmbPreferedTransport.Enabled == true)
                    { cmbPreferedTransport.Focus(); }
                    else if (cmbPreferedPeriod.Enabled == true)
                    { cmbPreferedPeriod.Focus(); }
                    else if (cmbPackingType.Enabled == true)
                    { cmbPackingType.Focus(); }
                    else if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); }
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterRoute.Focus();
                }
                if (DGV_FilterRoute.CurrentCell == null && DGV_FilterRoute.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterRoute.Focus();
                    int RowIndex = DGV_FilterRoute.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterRoute.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyRoute = 1;
                    }
                    else
                    {
                        varUpDownKeyRoute = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtRoute.Text = DGV_FilterRoute.Rows[RowIndex].Cells["Route"].Value.ToString();
                            }
                            txtRoute.Focus();
                            txtRoute.SelectionStart = txtRoute.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterRoute.Rows.Count) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterRoute.Rows.Count))
                            {
                                txtRoute.Text = DGV_FilterRoute.Rows[RowIndex].Cells["Route"].Value.ToString();
                            }

                            txtRoute.Focus();
                            txtRoute.SelectionStart = txtRoute.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterRoute.Rows.Count > 0)
                                {
                                    varUpDownKeyRoute = 1;
                                    udfnRouteEvent();
                                    DGV_FilterRoute.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtRoute.Focus();
                    //txtRoute.SelectionStart = txtRoute.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtRoute.SelectedText = true;
                        TextBox txtRoute = sender as TextBox;
                        txtRoute.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                         if (txtArea.Enabled == true)
                        { txtArea.Focus(); }
                        else if (cmbVerificationOnLoc.Enabled == true)
                        { cmbVerificationOnLoc.Focus(); }
                        else if (cmbDeliveryPrefernce.Enabled == true)
                        { cmbDeliveryPrefernce.Focus(); }
                        else if (cmbPreferedTransport.Enabled == true)
                        { cmbPreferedTransport.Focus(); }
                        else if (cmbPreferedPeriod.Enabled == true)
                        { cmbPreferedPeriod.Focus(); }
                        else if (cmbPackingType.Enabled == true)
                        { cmbPackingType.Focus(); }
                        else if (cmbPackingPreference.Enabled == true)
                        { cmbPackingPreference.Focus(); }
                        else if (cmbGstinStatus.Enabled == true)
                        { cmbGstinStatus.Focus(); }
                        else
                        { btnListPrint.Focus(); }
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRoute_Leave(object sender, EventArgs e)
        {
            try
            {
                 txtRoute.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRoute_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyRoute == 0)
                {
                    if (txtRoute.Text.Length > 0)
                    {
                        MR_Route objMR_Route = new MR_Route();
                        objMR_Route.ViewType = 3;
                        objMR_Route.paraRouteEName = txtRoute.Text;
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnRouteList(objMR_Route);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterRoute.Visible = true;
                                    DGV_FilterRoute.DataSource = objDs.Tables[0];
                                    DGV_FilterRoute.Columns["RID"].Visible = false;
                                    DGV_FilterRoute.Columns["Route"].Width = 250;
                                    DGV_FilterRoute.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterRoute.Visible = false;
                                    DGV_FilterRoute.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterRoute.Visible = false;
                                DGV_FilterRoute.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterRoute.Visible = false;
                            DGV_FilterRoute.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterRoute.Visible = false;
                        DGV_FilterRoute.DataSource = null;
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

        private void DGV_FilterRoute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyRoute = 1;
                udfnRouteEvent();
                if (txtArea.Enabled == true)
                { txtArea.Focus(); }
                else if (cmbVerificationOnLoc.Enabled == true)
                { cmbVerificationOnLoc.Focus(); }
                else if (cmbDeliveryPrefernce.Enabled == true)
                { cmbDeliveryPrefernce.Focus(); }
                else if (cmbPreferedTransport.Enabled == true)
                { cmbPreferedTransport.Focus(); }
                else if (cmbPreferedPeriod.Enabled == true)
                { cmbPreferedPeriod.Focus(); }
                else if (cmbPackingType.Enabled == true)
                { cmbPackingType.Focus(); }
                else if (cmbPackingPreference.Enabled == true)
                { cmbPackingPreference.Focus(); }
                else if (cmbGstinStatus.Enabled == true)
                { cmbGstinStatus.Focus(); }
                else
                { btnListPrint.Focus(); } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterRoute_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterRoute.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterRoute.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyRoute = 1;
                    }
                    else
                    {
                        varUpDownKeyRoute = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];

                            txtRoute.Text = DGV_FilterRoute.SelectedRows[0].Cells["Route"].Value.ToString();

                            txtRoute.Focus();
                            txtRoute.SelectionStart = txtRoute.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterRoute.Rows.Count) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterRoute.Rows.Count))
                            {
                                txtRoute.Text = DGV_FilterRoute.Rows[RowIndex].Cells["Route"].Value.ToString();
                            }

                            txtRoute.Focus();
                            txtRoute.SelectionStart = txtRoute.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterRoute.Rows.Count > 0)
                                {
                                    varUpDownKeyRoute = 1;
                                    udfnRouteEvent();
                                    DGV_FilterRoute.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtRoute = sender as TextBox;
                        txtRoute.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtArea.Enabled == true)
                        { txtArea.Focus(); }
                        else if (cmbVerificationOnLoc.Enabled == true)
                        { cmbVerificationOnLoc.Focus(); }
                        else if (cmbDeliveryPrefernce.Enabled == true)
                        { cmbDeliveryPrefernce.Focus(); }
                        else if (cmbPreferedTransport.Enabled == true)
                        { cmbPreferedTransport.Focus(); }
                        else if (cmbPreferedPeriod.Enabled == true)
                        { cmbPreferedPeriod.Focus(); }
                        else if (cmbPackingType.Enabled == true)
                        { cmbPackingType.Focus(); }
                        else if (cmbPackingPreference.Enabled == true)
                        { cmbPackingPreference.Focus(); }
                        else if (cmbGstinStatus.Enabled == true)
                        { cmbGstinStatus.Focus(); }
                        else
                        { btnListPrint.Focus(); }
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRouteEvent()
        {
            try
            {
                if (txtRoute.Text.Trim() != "")
                {
                    lblRouteId.Text = DGV_FilterRoute.SelectedRows[0].Cells["RID"].Value.ToString();
                    txtRoute.Text = DGV_FilterRoute.SelectedRows[0].Cells["Route"].Value.ToString();
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

        private void txtArea_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtArea.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyArea = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterArea.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterArea.Visible == false)
                {
                     if (cmbVerificationOnLoc.Enabled == true)
                    { cmbVerificationOnLoc.Focus(); }
                    else if (cmbDeliveryPrefernce.Enabled == true)
                    { cmbDeliveryPrefernce.Focus(); }
                    else if (cmbPreferedTransport.Enabled == true)
                    { cmbPreferedTransport.Focus(); }
                    else if (cmbPreferedPeriod.Enabled == true)
                    { cmbPreferedPeriod.Focus(); }
                    else if (cmbPackingType.Enabled == true)
                    { cmbPackingType.Focus(); }
                    else if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); }
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterArea.Focus();
                }
                if (DGV_FilterArea.CurrentCell == null && DGV_FilterArea.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterArea.Focus();
                    int RowIndex = DGV_FilterArea.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterArea.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyArea = 1;
                    }
                    else
                    {
                        varUpDownKeyArea = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtArea.Text = DGV_FilterArea.Rows[RowIndex].Cells["AreaName"].Value.ToString();
                            }
                            txtArea.Focus();
                            txtArea.SelectionStart = txtArea.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterArea.Rows.Count) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterArea.Rows.Count))
                            {
                                txtArea.Text = DGV_FilterArea.Rows[RowIndex].Cells["AreaName"].Value.ToString();
                            }

                            txtArea.Focus();
                            txtArea.SelectionStart = txtArea.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterArea.Rows.Count > 0)
                                {
                                    varUpDownKeyArea = 1;
                                    udfnAreaData();
                                    DGV_FilterArea.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtArea.Focus();
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
                        if (cmbVerificationOnLoc.Enabled == true)
                        { cmbVerificationOnLoc.Focus(); }
                        else if (cmbDeliveryPrefernce.Enabled == true)
                        { cmbDeliveryPrefernce.Focus(); }
                        else if (cmbPreferedTransport.Enabled == true)
                        { cmbPreferedTransport.Focus(); }
                        else if (cmbPreferedPeriod.Enabled == true)
                        { cmbPreferedPeriod.Focus(); }
                        else if (cmbPackingType.Enabled == true)
                        { cmbPackingType.Focus(); }
                        else if (cmbPackingPreference.Enabled == true)
                        { cmbPackingPreference.Focus(); }
                        else if (cmbGstinStatus.Enabled == true)
                        { cmbGstinStatus.Focus(); }
                        else
                        { btnListPrint.Focus(); }
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_Leave(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyArea == 0)
                {
                    if (txtArea.Text.Length > 0)
                    {
                        MR_Area objMR_Area = new MR_Area();
                        objMR_Area.ViewType = 2;
                        objMR_Area.paraAreaEName = txtArea.Text;
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnArealist(objMR_Area);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterArea.Visible = true;
                                    DGV_FilterArea.DataSource = objDs.Tables[0];
                                    DGV_FilterArea.Columns["AID"].Visible = false;
                                    DGV_FilterArea.Columns["AreaName"].Width = 250;
                                    DGV_FilterArea.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterArea.Visible = false;
                                    DGV_FilterArea.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterArea.Visible = false;
                                DGV_FilterArea.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterArea.Visible = false;
                            DGV_FilterArea.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterArea.Visible = false;
                        DGV_FilterArea.DataSource = null;
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

        private void DGV_FilterArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyArea = 1;
                udfnAreaData();
                    if (cmbVerificationOnLoc.Enabled == true)
                    { cmbVerificationOnLoc.Focus(); }
                    else if (cmbDeliveryPrefernce.Enabled == true)
                    { cmbDeliveryPrefernce.Focus(); }
                    else if (cmbPreferedTransport.Enabled == true)
                    { cmbPreferedTransport.Focus(); }
                    else if (cmbPreferedPeriod.Enabled == true)
                    { cmbPreferedPeriod.Focus(); }
                    else if (cmbPackingType.Enabled == true)
                    { cmbPackingType.Focus(); }
                    else if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnGridviewProduct();
                //    udfnPossibleSupplierLoad();
                //}
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterArea.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterArea.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyArea = 1;
                    }
                    else
                    {
                        varUpDownKeyArea = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];

                            txtArea.Text = DGV_FilterArea.SelectedRows[0].Cells["AreaName"].Value.ToString();

                            txtArea.Focus();
                            txtArea.SelectionStart = txtArea.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterArea.Rows.Count) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterArea.Rows.Count))
                            {
                                txtArea.Text = DGV_FilterArea.Rows[RowIndex].Cells["AreaName"].Value.ToString();
                            }

                            txtArea.Focus();
                            txtArea.SelectionStart = txtArea.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterArea.Rows.Count > 0)
                                {
                                    varUpDownKeyArea = 1;
                                    udfnAreaData();
                                    DGV_FilterArea.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (cmbVerificationOnLoc.Enabled == true)
                        { cmbVerificationOnLoc.Focus(); }
                        else if (cmbDeliveryPrefernce.Enabled == true)
                        { cmbDeliveryPrefernce.Focus(); }
                        else if (cmbPreferedTransport.Enabled == true)
                        { cmbPreferedTransport.Focus(); }
                        else if (cmbPreferedPeriod.Enabled == true)
                        { cmbPreferedPeriod.Focus(); }
                        else if (cmbPackingType.Enabled == true)
                        { cmbPackingType.Focus(); }
                        else if (cmbPackingPreference.Enabled == true)
                        { cmbPackingPreference.Focus(); }
                        else if (cmbGstinStatus.Enabled == true)
                        { cmbGstinStatus.Focus(); }
                        else
                        { btnListPrint.Focus(); }
                        e.Handled = true;
                    }
                }
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
                varUpDownKeyGroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_Customer.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_Customer.Visible == false)
                {
                    cmbStatus.Focus();
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
                        cmbStatus.Focus();
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
                    lblCustomerId.Text = DGV_Customer.SelectedRows[0].Cells["CusID"].Value.ToString();
                    txtCustomer.Text = DGV_Customer.SelectedRows[0].Cells["Customer"].Value.ToString();
                    DGV_Customer.Visible = false;
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
                if (varUpDownKeyGroup == 0)
                {
                    //lvGroup.Items.Clear();
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();

                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 9;
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
                                    DGV_Customer.Columns["CusID"].Visible = false;
                                    DGV_Customer.Columns["Mobileno"].Visible = false;
                                    DGV_Customer.Columns["Customer"].Width = 210;
                                    DGV_Customer.Columns["GST Type"].Width = 100;
                                    DGV_Customer.Columns["Customer Type"].Width = 100;
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
                cmbStatus.Focus();
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
                if(e.KeyCode == Keys.Enter)
                {
                    cmbGSTType.Focus();
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

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int reportType = 0;
                cmbGSTType.SelectedValue = 0;
                cmbCustomerType.SelectedValue =0;
                cmbCustomerCategory.SelectedValue =0;
                txtCity.Text = ""; lblcityid.Text = "0";
                txtCustomer.Text = ""; lblCustomerId.Text = "0";
                cmbStatus.SelectedValue = 0;
                cmbFilter.SelectedValue = 0;
                txtRoute.Text = ""; lblRouteId.Text = "0";
                txtArea.Text = ""; lblAreaId.Text = "0";
                cmbVerificationOnLoc.SelectedValue = 0;
                cmbDeliveryPrefernce.SelectedValue = 0;
                cmbPreferedTransport.SelectedValue = 0;
                cmbPreferedPeriod.SelectedValue = 0;
                cmbPackingType.SelectedValue = 0;
                cmbPackingPreference.SelectedValue = 0;
                cmbGstinStatus.SelectedValue = 0;

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
                reportType = Convert.ToInt32(cmbReportType.SelectedValue);

                cmbFilter.Enabled = false;
                txtRoute.Enabled = false; txtRoute.ReadOnly = true;
                txtArea.Enabled = false; txtArea.ReadOnly = true;
                cmbDeliveryPrefernce.Enabled = false;
                cmbVerificationOnLoc.Enabled = false;
                cmbGstinStatus.Enabled = false;
                cmbPreferedPeriod.Enabled = false;
                cmbPackingType.Enabled = false;
                cmbPackingPreference.Enabled = false;
                cmbPreferedTransport.Enabled = false;

                if (reportType== 714)
                {
                    cmbFilter.Enabled = true; 
                }
                else if (reportType == 715 )
                {
                    cmbFilter.Enabled = true;
                }
                else if (reportType == 716 )
                {
                    txtRoute.Enabled = true; txtRoute.ReadOnly = false;
                    txtArea.Enabled = true; txtArea.ReadOnly = false;
                }
                else if (reportType == 717)
                {
                    cmbDeliveryPrefernce.Enabled = true;
                    cmbVerificationOnLoc.Enabled = true;
                    cmbPreferedTransport.Enabled = true;
                }
                else if (reportType == 718)
                {
                    cmbDeliveryPrefernce.Enabled = true;
                    cmbPreferedPeriod.Enabled = true;
                    cmbPackingType.Enabled = true;
                    cmbPackingPreference.Enabled = true;
                }
                else if (reportType == 719)
                {
                    cmbDeliveryPrefernce.Enabled = true;  
                }
                else if (reportType == 720)
                {
                    cmbDeliveryPrefernce.Enabled = true;  
                    cmbGstinStatus.Enabled = true;  
                }
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
                    cmbStatus.Focus();
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
         
        private void cmbGSTType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGSTType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCustomerType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbCustomerType.BackColor = Color.LemonChiffon;
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

        private void cmbFilter_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbFilter.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDeliveryPrefernce_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbDeliveryPrefernce.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbVerificationOnLoc_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbVerificationOnLoc.BackColor = Color.LemonChiffon;
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
                cmbPreferedTransport.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbGstinStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGstinStatus.BackColor = Color.LemonChiffon;
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
                    cmbCustomerType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCustomerCategory_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCustomerType_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtRoute.Enabled == true)
                    { txtRoute.Focus(); }
                    else if (txtArea.Enabled == true)
                    { txtArea.Focus(); }
                    else if (cmbVerificationOnLoc.Enabled == true)
                    { cmbVerificationOnLoc.Focus(); }
                    else if (cmbDeliveryPrefernce.Enabled == true)
                    { cmbDeliveryPrefernce.Focus(); }
                    else if (cmbPreferedTransport.Enabled == true)
                    { cmbPreferedTransport.Focus(); }
                    else if (cmbPreferedPeriod.Enabled == true)
                    { cmbPreferedPeriod.Focus(); }
                    else if (cmbPackingType.Enabled == true)
                    { cmbPackingType.Focus(); }
                    else if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDeliveryPrefernce_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbPreferedTransport.Enabled == true)
                    { cmbPreferedTransport.Focus(); }
                    else if (cmbPreferedPeriod.Enabled == true)
                    { cmbPreferedPeriod.Focus(); }
                    else if (cmbPackingType.Enabled == true)
                    { cmbPackingType.Focus(); }
                    else if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbVerificationOnLoc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbDeliveryPrefernce.Enabled == true)
                    { cmbDeliveryPrefernce.Focus(); }
                    else if (cmbPreferedTransport.Enabled == true)
                    { cmbPreferedTransport.Focus(); }
                    else if (cmbPreferedPeriod.Enabled == true)
                    { cmbPreferedPeriod.Focus(); }
                    else if (cmbPackingType.Enabled == true)
                    { cmbPackingType.Focus(); }
                    else if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); }
                    e.Handled = true;
                }
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
                    if (cmbPreferedPeriod.Enabled == true)
                    { cmbPreferedPeriod.Focus(); }
                    else if (cmbPackingType.Enabled == true)
                    { cmbPackingType.Focus(); }
                    else if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbGstinStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { btnListPrint.Focus(); }
                e.Handled = true;
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

        private void cmbCustomerType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbCustomerCategory_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void cmbFilter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbDeliveryPrefernce_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbVerificationOnLoc_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbGstinStatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbCustomerType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbCustomerType.BackColor = Color.White;
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

        private void cmbFilter_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbFilter.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDeliveryPrefernce_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDeliveryPrefernce.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbVerificationOnLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbVerificationOnLoc.BackColor = Color.White;
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
                cmbPreferedTransport.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbGstinStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbGstinStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void cmbPreferedPeriod_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPreferedPeriod.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPackingType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPackingType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPackingPreference_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPackingPreference.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPreferedPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbPackingType.Enabled == true)
                    { cmbPackingType.Focus(); }
                    else if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPackingType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbPackingPreference.Enabled == true)
                    { cmbPackingPreference.Focus(); }
                    else if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPackingPreference_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbGstinStatus.Enabled == true)
                    { cmbGstinStatus.Focus(); }
                    else
                    { btnListPrint.Focus(); }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPreferedPeriod_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbPackingType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbPackingPreference_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbPreferedPeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPreferedPeriod.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPackingType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPackingType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPackingPreference_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPackingPreference.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyCity == 0)
                { 
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtCity.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnCitylist(1, txtCity.Text, 0, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_City.Visible = true; 
                                    DGV_City.DataSource = objDs.Tables[0];
                                    DGV_City.Columns["CTYID"].Visible = false;
                                    DGV_City.Columns["STID"].Visible = false;
                                    DGV_City.Columns["ST_Name"].Visible = false;
                                    DGV_City.Columns["ST_TIN"].Visible = false;
                                    DGV_City.Columns["CTY_NAME"].HeaderText = "City";
                                    DGV_City.Columns["CTY_NAME"].Width = 180;
                                    DGV_City.Columns["CTY_NAME"].DisplayIndex = 0;
                                    DGV_City.BringToFront();
                                }
                                else
                                {
                                    DGV_City.Visible = false;
                                    DGV_City.DataSource = null; 
                                }
                            }
                            else
                            {
                                DGV_City.Visible = false;
                                DGV_City.DataSource = null; 
                            }
                        }
                        else
                        {
                            DGV_City.Visible = false;
                            DGV_City.DataSource = null; 
                        }
                    }
                    else
                    {
                        DGV_City.Visible = false;
                        DGV_City.DataSource = null; 
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

        private void DGV_City_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyCity = 1;
                udfnCityEvent();
                cmbStatus.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCityEvent()
        {
            try
            {
                if (txtCity.Text.Trim() != "")
                { 
                    txtCity.Text = DGV_City.SelectedRows[0].Cells["CTY_NAME"].Value.ToString();
                    lblcityid.Text = DGV_City.SelectedRows[0].Cells["CTYID"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_City.Visible = false;
            }
        }

        private void DGV_City_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyCity = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_City.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_City.Visible == false)
                {
                    cmbDeliveryPrefernce.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_City.Focus();
                }
                if (DGV_City.CurrentCell == null && DGV_City.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_City.Focus();
                    int RowIndex = DGV_City.CurrentCell.RowIndex;
                    int ClmIndex = DGV_City.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyCity = 1;
                    }
                    else
                    {
                        varUpDownKeyCity = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_City.CurrentCell = DGV_City.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtCity.Text = DGV_City.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }
                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_City.Rows.Count) DGV_City.CurrentCell = DGV_City.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_City.Rows.Count))
                            {
                                txtCity.Text = DGV_City.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            } 
                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_City.Rows.Count > 0)
                                {
                                    varUpDownKeyCity = 1;
                                    udfnCityEvent();
                                    DGV_City.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtCity.Focus();
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
                        cmbDeliveryPrefernce.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCity.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterRoute_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyCity = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_City.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_City.Visible == false)
                {
                    txtCustomer.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_City.Focus();
                }
                if (DGV_City.CurrentCell == null && DGV_City.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_City.Focus();
                    int RowIndex = DGV_City.CurrentCell.RowIndex;
                    int ClmIndex = DGV_City.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyCity = 1;
                    }
                    else
                    {
                        varUpDownKeyCity = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_City.CurrentCell = DGV_City.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtCity.Text = DGV_City.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString(); 
                            }
                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_City.Rows.Count) DGV_City.CurrentCell = DGV_City.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_City.Rows.Count))
                            {
                                txtCity.Text = DGV_City.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_City.Rows.Count > 0)
                                {
                                    varUpDownKeyGroup = 1;
                                    udfnCityEvent();
                                    DGV_City.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtCity.Focus();
                    //txtCustomer.SelectionStart = txtCustomer.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtCityName = sender as TextBox;
                        txtCityName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtCustomer.Focus();
                    }
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
                        cmbStatus.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnAreaData()
        {
            try
            {
                if (txtArea.Text.Trim() != "")
                {
                    lblAreaId.Text = DGV_FilterArea.SelectedRows[0].Cells["AID"].Value.ToString();
                    txtArea.Text = DGV_FilterArea.SelectedRows[0].Cells["AreaName"].Value.ToString();
                }
                cmbStatus.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //  LV_Supplier.Visible = false;
            }
        }
    }
}
