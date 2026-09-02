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
    public partial class REPORT_SALES_Area : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyRoute = 0, varUpDownKeyArea = 0, varUpDownKeyGroup = 0;

        private ToolTip tpReportType = new ToolTip();
        public REPORT_SALES_Area()
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
                    udfnRoute();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRoute()
        {
            try
            {
                int varRouteId = 0,varAreaId = 0,varCustomerId = 0;string varRouteName = "-All-",varAreaName = "-All-",varCustomerName = "-All-";
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
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                MR_Sales objMR_Sales = new MR_Sales();
                if(Convert.ToInt32(cmbReportType.SelectedValue) == 653)
                {
                    objMR_Sales.paraViewType = 1;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 654)
                {
                    objMR_Sales.paraViewType = 9;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 655)
                {
                    objMR_Sales.paraViewType = 10;
                }
                objMR_Sales.paraRouteId = varRouteId;
                objMR_Sales.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objDs = objdserv.udfnSalesMasterReports(objMR_Sales);
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    int reportType = Convert.ToInt32(cmbReportType.SelectedValue);
                    switch (reportType)
                    {
                        case 653:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Area.rpt");
                            objBillreport.SetParameterValue("paraRouteId",varRouteId);
                            objBillreport.SetParameterValue("paraRouteName",varRouteName);
                            break;

                        case 654:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Route_Area_Customer_Count.rpt");
                            objBillreport.SetParameterValue("paraRouteName",varRouteName);
                            objBillreport.SetParameterValue("paraAreaName",varAreaName);
                            objBillreport.SetParameterValue("paraAreaId",varAreaId);
                            objBillreport.SetParameterValue("paraRouteId",varRouteId);
                            break;
                        case 655:
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Route_Area_Customer.rpt");
                            objBillreport.SetParameterValue("paraRouteName",varRouteName);
                            objBillreport.SetParameterValue("paraAreaName",varAreaName);
                            objBillreport.SetParameterValue("paraAreaId",varAreaId);
                            objBillreport.SetParameterValue("paraRouteId",varRouteId);
                            objBillreport.SetParameterValue("paraCustomerName",varCustomerName);
                            objBillreport.SetParameterValue("paraCustomerTypeName",Convert.ToString(cmbCustomerType.Text));
                            objBillreport.SetParameterValue("paraCategoryName",Convert.ToString(cmbCustomerCategory.Text));
                            objBillreport.SetParameterValue("paraCusCategoryId",Convert.ToInt32(cmbCustomerCategory.SelectedValue));
                            objBillreport.SetParameterValue("paraCustomerId",varCustomerId);
                            objBillreport.SetParameterValue("paraCustomerTypeId",Convert.ToInt32(cmbCustomerType.SelectedValue));
                            objBillreport.SetParameterValue("paraPrintType",322/*Convert.ToInt32(cmbPrintType.SelectedValue)*/);
                            break;
                    }

                    objBillreport.SetParameterValue("paraUserName",MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraHostName",MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraStatusId",Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName",Convert.ToString(cmbStatus.Text));
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
                int currentMUCode = 140202;
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
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,157) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbCustomerType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("MR_Customer_Type", "CusTypeID<>-1 ORDER BY CusTypeID", "CusType_Name,CusTypeID", cmbCustomerCategory, "", "CusType_Name", "CusTypeID");
                objDataBind = null;
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
                    {
                        txtArea.Focus();
                    }
                    else
                    {
                        cmbStatus.Focus();
                    }
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
                        {
                            txtArea.Focus();
                        }
                        else
                        {
                            cmbStatus.Focus();
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
                {
                    txtArea.Focus();
                }
                else
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
                        {
                            txtArea.Focus();
                        }
                        else
                        {
                            cmbStatus.Focus();
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
                    if (txtCustomer.Enabled == true)
                    {
                        txtCustomer.Focus();
                    }
                    else
                    {
                        cmbStatus.Focus();
                    }
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
                        if (txtCustomer.Enabled == true)
                        {
                            txtCustomer.Focus();
                        }
                        else
                        {
                            cmbStatus.Focus();
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
                if (txtCustomer.Enabled == true)
                {
                    txtCustomer.Focus();
                }
                else
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
                        if (txtCustomer.Enabled == true)
                        {
                            txtCustomer.Focus();
                        }
                        else
                        {
                            cmbStatus.Focus();
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
                    cmbCustomerType.Focus();
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
                        cmbCustomerType.Focus();
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
                if (varUpDownKeyGroup == 0)
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
                varUpDownKeyGroup = 1;
                udfnCustomerAutocomplete();
                cmbCustomerType.Focus();
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
                    txtRoute.Focus();
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
                txtArea.Enabled = false;
                txtCustomer.Enabled = false;
                cmbCustomerType.Enabled = false;
                cmbCustomerCategory.Enabled = false;
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 654)
                {
                    txtArea.Enabled = true;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 655)
                {
                    txtArea.Enabled = true;
                    txtCustomer.Enabled = true;
                    cmbCustomerType.Enabled = true;
                    cmbCustomerCategory.Enabled = true;
                }
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

        private void cmbCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
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
                        cmbCustomerType.Focus();
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
