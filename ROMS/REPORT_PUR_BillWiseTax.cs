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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;

namespace ROMS
{
    public partial class REPORT_PUR_BillWiseTax : Form
    {
        private ContextMenuStrip contextMenu;
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        private ToolTip tpReportType = new ToolTip();
        public int varUpDownKeySupplier = 0;
        public REPORT_PUR_BillWiseTax()
        {
            InitializeComponent();
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
        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtSupplier)
                {
                    varUpDownKeySupplier = 0;
                    DGV_FilterSupplier.DataSource = null;
                    DGV_FilterSupplier.Visible = false;
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
                }
                else
                {
                    SPDataService objDataService = new SPDataService();
                    string varMessage = objDataService.udfnGetMessages(161);
                    MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objDataService.CloseConnection();
                    udfnPurchaseBillWiseReport();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurchaseBillWiseReport()
        {
            try
            {
                epReport.Clear();
                string varSupplierName = "-All-";
                int varSupplierId = 0, varViewType = 16, varScheduleId = 0;
                if (txtSupplier.Text.Trim() != "")
                {
                    varSupplierName = txtSupplier.Text;
                    varSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    varScheduleId = Convert.ToInt32(lblScheduleCode.Text);
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 329)
                {
                    varViewType = 17;
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
                objDs = objdserv.udfnPurHsnReport(varViewType, Convert.ToInt32(cmbSupplierType.SelectedValue), "", 0, dpFromDate.Text, dpToDate.Text, 0, 0, 0, 0, 0, 0, varSupplierId, varScheduleId, Convert.ToInt32(cmbInvType.SelectedValue), 0, 0, 0, 0, "", "");
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 328)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_Tax_TaxSummary_BillWise.rpt");
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 329)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_Tax_TaxDetails_BillWise.rpt");
                    }
                    objBillreport.SetParameterValue("paraSupplierType", Convert.ToInt32(cmbSupplierType.SelectedValue));
                    objBillreport.SetParameterValue("paraHSNCode", 0);
                    objBillreport.SetParameterValue("paraGST", 0);
                    objBillreport.SetParameterValue("paraCompanyId", 0);
                    objBillreport.SetParameterValue("paraInvioceType", Convert.ToInt32(cmbInvType.SelectedValue));
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
                    objBillreport.SetParameterValue("paraSupplierID", varSupplierId);
                    objBillreport.SetParameterValue("paraScheduleID", varScheduleId);
                    objBillreport.SetParameterValue("paraSupplierName", varSupplierName);
                    objBillreport.SetParameterValue("paraSupplierTypeName", cmbSupplierType.Text);
                    objBillreport.SetParameterValue("paraInvoiceTypeName", cmbInvType.Text);

                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
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
        private void REPORT_CP_City_Load(object sender, EventArgs e)
        {
            try
            {
                tsbExport.Enabled = false;
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,97) AND MSTID<>0", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,78) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbInvType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbSupplierType.SelectedValue = 0;
                cmbInvType.SelectedValue = 0;
                cmbReportType.SelectedValue = -1;
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

        private void TxtSupplier_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySupplier = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSupplier.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSupplier.Visible == false)
                {
                    cmbInvType.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSupplier.Focus();
                }
                if (DGV_FilterSupplier.CurrentCell == null && DGV_FilterSupplier.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSupplier.Focus();
                    int RowIndex = DGV_FilterSupplier.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSupplier.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySupplier = 1;
                    }
                    else
                    {
                        varUpDownKeySupplier = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSupplier.CurrentCell = DGV_FilterSupplier.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSupplier.Text = DGV_FilterSupplier.Rows[RowIndex].Cells["SP_NAME"].Value.ToString();
                            }
                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSupplier.Rows.Count) DGV_FilterSupplier.CurrentCell = DGV_FilterSupplier.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSupplier.Rows.Count))
                            {
                                txtSupplier.Text = DGV_FilterSupplier.Rows[RowIndex].Cells["SP_NAME"].Value.ToString();
                            }

                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSupplier.Rows.Count > 0)
                                {
                                    varUpDownKeySupplier = 1;
                                    udfnListViewData();
                                    DGV_FilterSupplier.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSupplier.Focus();
                    //txtSupplier.SelectionStart = txtSupplier.Text.Length;
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
                        cmbInvType.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeySupplier == 0)
                {
                    if (txtSupplier.Text.Length > 0)
                    {
                        MR_Supplier objMR_Supplier = new MR_Supplier();
                        objMR_Supplier.ViewType = 26;
                        objMR_Supplier.paraSupplierName = txtSupplier.Text;
                        objMR_Supplier.ParaFromDate = dpFromDate.Text;
                        objMR_Supplier.ParaToDate = dpToDate.Text;
                        objMR_Supplier.paraFlag = 8;
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
                                    DGV_FilterSupplier.Visible = true;
                                    DGV_FilterSupplier.DataSource = objDs.Tables[0];
                                    DGV_FilterSupplier.Columns["SPID"].Visible = false;
                                    DGV_FilterSupplier.Columns["SPSCID"].Visible = false;
                                    DGV_FilterSupplier.Columns["SupplierName"].Visible = false;
                                    DGV_FilterSupplier.Columns["ScheduleName"].Visible = false;
                                    DGV_FilterSupplier.Columns["SP_NAME"].HeaderText = "Supplier";
                                    DGV_FilterSupplier.Columns["SP_NAME"].Width = 260;
                                    DGV_FilterSupplier.Columns["SP_NAME"].DisplayIndex = 0;
                                    DGV_FilterSupplier.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSupplier.Visible = false;
                                    DGV_FilterSupplier.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterSupplier.Visible = false;
                                DGV_FilterSupplier.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterSupplier.Visible = false;
                            DGV_FilterSupplier.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterSupplier.Visible = false;
                        DGV_FilterSupplier.DataSource = null;
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

        private void DGV_FilterSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySupplier = 1;
                udfnListViewData();
                cmbInvType.Focus();
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
                if (txtSupplier.Text.Trim() != "")
                {
                    lblSupplierCode.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SPID"].Value.ToString();
                    lblScheduleCode.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SPSCID"].Value.ToString();
                    txtSupplier.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SP_NAME"].Value.ToString();
                }
                cmbInvType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_FilterSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSupplier.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSupplier.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySupplier = 1;
                    }
                    else
                    {
                        varUpDownKeySupplier = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSupplier.CurrentCell = DGV_FilterSupplier.Rows[RowIndex].Cells[ClmIndex];

                            txtSupplier.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SP_NAME"].Value.ToString();

                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSupplier.Rows.Count) DGV_FilterSupplier.CurrentCell = DGV_FilterSupplier.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSupplier.Rows.Count))
                            {
                                txtSupplier.Text = DGV_FilterSupplier.Rows[RowIndex].Cells["SP_NAME"].Value.ToString();
                            }

                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSupplier.Rows.Count > 0)
                                {
                                    varUpDownKeySupplier = 1;
                                    udfnListViewData();
                                    DGV_FilterSupplier.Visible = false;
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
                        cmbInvType.Focus();
                    }
                }
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
                udfnGridNull((Control)sender);
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
                    txtSupplier.Focus();
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
                udfnGridNull((Control)sender);
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
                    dpFromDate.Focus();
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
                if (cmbReportType.SelectedItem is DataRowView drv)
                {
                    if (drv.Row.Table.Columns.Contains("MST_ShortName") &&
                        drv["MST_ShortName"] != DBNull.Value)
                    {
                        tsbPrintFormat.Text = drv["MST_ShortName"]?.ToString() ?? string.Empty;
                    }
                    else
                    {
                        tsbPrintFormat.Text = string.Empty;
                    }
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == -1)
                {
                    cmbInvType.SelectedValue = 0;
                    cmbInvType.Enabled = false;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 329)
                {
                    tsbExport.Enabled = true;
                }
                else
                {
                    tsbExport.Enabled = false;
                    cmbInvType.Enabled = true;
                }
                tsbDownload.Enabled = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbInvType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbInvType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbInvType_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbInvType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbInvType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbInvType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnExcel(DataTable dt, string sheetTitle,string supplier, string supplierType, string invType,string fromDate, string toDate)
        {
            try
            {
                Application.DoEvents();
                Excel._Application ExcelObj = new Excel.Application();
                Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                Excel._Worksheet ExcelSheet = (Excel._Worksheet)ExcelBook.Sheets[1];
                ExcelSheet = ExcelBook.ActiveSheet;
                ExcelSheet.Name = "Purchase Tax Details";

                int currentRow = 1;

                // 1. Title Row
                ExcelSheet.Cells[currentRow, 1] = sheetTitle;
                Excel.Range titleRange = ExcelSheet.Range[
                    ExcelSheet.Cells[currentRow, 1],
                    ExcelSheet.Cells[currentRow, dt.Columns.Count - 1] // exclude Supplier Type column
                ];
                titleRange.Merge();
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titleRange.Font.Size = 14;
                titleRange.Font.Bold = true;
                titleRange.Interior.Color = Color.LightSlateGray;   // background
                titleRange.Font.Color = Color.White;
                currentRow++;

                // 2. Filter Row
                ExcelSheet.Cells[currentRow, 1] = $"Supplier :- {supplier}   Supplier Type :- {supplierType}   Inv Type :- {invType}   From :- {fromDate} - {toDate}";
                Excel.Range filterRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, dt.Columns.Count]];
                filterRange.Merge();
                filterRange.Font.Bold = true;
                currentRow += 2;

                // Group by Supplier Type
                var supplierTypes = dt.AsEnumerable()
                                      .Select(r => r.Field<string>("Supplier Type"))
                                      .Distinct()
                                      .ToList();

                foreach (var supType in supplierTypes)
                {
                    // 3. Supplier Type Row
                    ExcelSheet.Cells[currentRow, 1] = $"Supplier Type : {supType}";
                    Excel.Range supTypeRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, dt.Columns.Count]];
                    supTypeRange.Merge();
                    supTypeRange.Font.Bold = true;
                    //supTypeRange.Interior.Color = Color.LightGray;
                    currentRow++;

                    // 4. Complex Header (Row 1 of header)
                    ExcelSheet.Cells[currentRow, 1] = "Approval Date";
                    ExcelSheet.Cells[currentRow, 2] = "Supplier";
                    ExcelSheet.Cells[currentRow, 3] = "Invoice No.";
                    ExcelSheet.Cells[currentRow, 4] = "Invoice Date";

                    var gstSlabs = dt.Columns.Cast<DataColumn>()
                         .Select(c => c.ColumnName)
                         .Where(c => c.Contains("% Taxable Value"))
                         .Select(c => c.Replace(" Taxable Value", ""))
                         .Distinct()
                         .ToList();

                    int col = 5;
                    foreach (string gst in gstSlabs)
                    {
                        ExcelSheet.Cells[currentRow, col] = gst;
                        Excel.Range gstRange = ExcelSheet.Range[
                            ExcelSheet.Cells[currentRow, col],
                            ExcelSheet.Cells[currentRow, col + 1]
                        ];
                        gstRange.Merge();
                        gstRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        col += 2;
                    }

                    ExcelSheet.Cells[currentRow, col++] = "TCS Value";
                    ExcelSheet.Cells[currentRow, col++] = "Addl. Value";
                    ExcelSheet.Cells[currentRow, col++] = "Disc Value";
                    ExcelSheet.Cells[currentRow, col++] = "Round Off";
                    ExcelSheet.Cells[currentRow, col++] = "Total";

                    // Merge vertically Approval Date, Supplier, Invoice No, Invoice Date
                    Excel.Range mergeRange;
                    mergeRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow + 1, 1]]; mergeRange.Merge();
                    mergeRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, 2], ExcelSheet.Cells[currentRow + 1, 2]]; mergeRange.Merge();
                    mergeRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, 3], ExcelSheet.Cells[currentRow + 1, 3]]; mergeRange.Merge();
                    mergeRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, 4], ExcelSheet.Cells[currentRow + 1, 4]]; mergeRange.Merge();

                    // Merge TCS, Addl, Disc, Round Off, Total vertically
                    for (int c = col - 5; c <= col - 1; c++)
                    {
                        mergeRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, c], ExcelSheet.Cells[currentRow + 1, c]];
                        mergeRange.Merge();
                    }

                    // 5. Header Row 2
                    currentRow++;
                    col = 5;
                    foreach (string gst in gstSlabs)
                    {
                        ExcelSheet.Cells[currentRow, col++] = "Taxable Value";
                        ExcelSheet.Cells[currentRow, col++] = "Tax Value";
                    }

                    currentRow++;
                    // Apply border for header block (2 rows of headers)
                    Excel.Range headerBorder = ExcelSheet.Range[
           ExcelSheet.Cells[currentRow - 2, 1],
           ExcelSheet.Cells[currentRow - 1, dt.Columns.Count - 1] // exclude Supplier Type column
       ];
                    headerBorder.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    headerBorder.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    headerBorder.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerBorder.Font.Bold = true;

                    // 6. Bind Data
                    // 6. Bind Data (skip Supplier Type column, calculate total)
                    var rows = dt.AsEnumerable()
                                 .Where(r => r.Field<string>("Supplier Type") == supType)
                                 .ToList();

                    int dataStartRow = currentRow;
                    foreach (var dr in rows)
                    {
                        int c = 1;
                        decimal rowTotal = 0;

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string colName = dt.Columns[i].ColumnName;

                            if (colName == "Supplier Type") continue; // skip Supplier Type

                            // bind normally
                            var cell = ExcelSheet.Cells[currentRow, c];
                            cell.Value = dr[i];

                            // if numeric column, add to total
                            if (!(dr[i] is DBNull))
                            {
                                decimal num;
                                if (decimal.TryParse(dr[i].ToString(), out num) &&
                                    !new[] { "Approval Date", "Supplier", "Invoice No.", "Invoice Date" }.Contains(colName))
                                {
                                    rowTotal += num;
                                    cell.NumberFormat = "0.00";
                                }
                            }
                            c++;
                        }
                        // Write total in the last column
                        ExcelSheet.Cells[currentRow, c - 1] = rowTotal;
                        ExcelSheet.Cells[currentRow, c - 1].NumberFormat = "0.00";
                        currentRow++;
                    }

                    // Apply border for data rows of this Supplier Type
                    if (rows.Count > 0)
                    {
                        Excel.Range dataBorder = ExcelSheet.Range[
                            ExcelSheet.Cells[dataStartRow, 1],
                            ExcelSheet.Cells[currentRow - 1, dt.Columns.Count - 1]
                        ];
                        dataBorder.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        dataBorder.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    currentRow += 2; // Space before next group
                }

                ExcelSheet.Columns.AutoFit();
                string folderPath = Path.Combine(Application.StartupPath, "Excel", "Purchase");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                else
                {
                    string[] files = Directory.GetFiles(folderPath);
                    foreach (string file in files)
                    {
                        try
                        {
                            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                            {
                                fs.Close();
                                File.Delete(file);
                            }
                        }
                        catch (IOException)
                        {
                            objError = new DataError();
                            objError.WriteFile(new Exception("Skipped deleting '" + file + "' because it's in use."));
                        }
                        catch (Exception ex)
                        {
                            objError = new DataError();
                            objError.WriteFile(ex);
                        }
                    }
                }

                string fileName = "Billwise Purchase Tax Details.xlsx";
                string fullPath = Path.Combine(folderPath, fileName);
                ExcelBook.SaveAs(fullPath);

                ExcelBook.Close(false);
                ExcelObj.Quit();

                Marshal.ReleaseComObject(ExcelSheet);
                Marshal.ReleaseComObject(ExcelBook);
                Marshal.ReleaseComObject(ExcelObj);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private async void tsbExport_Click(object sender, EventArgs e)
        {
            try
            {
                epReport.Clear();
                string varSupplierName = "-All-";
                int varSupplierId = 0, varScheduleId = 0;
                if (txtSupplier.Text.Trim() != "")
                {
                    varSupplierName = txtSupplier.Text;
                    varSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    varScheduleId = Convert.ToInt32(lblScheduleCode.Text);
                }
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnPurHsnReport(17, Convert.ToInt32(cmbSupplierType.SelectedValue), "", 0, dpFromDate.Text, dpToDate.Text, 0, 0, 0, 1, 0, 0, varSupplierId, varScheduleId, Convert.ToInt32(cmbInvType.SelectedValue), 0, 0, 0, 0, "", "");
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    tsbDownload.Enabled = false;
                    tsbExport.Enabled = false;
                    tsbExport.Text = "Generating...";
                    string varSupplierType = cmbSupplierType.Text;
                    string varInvoiceType = cmbInvType.Text;
                    string varFromDate = dpFromDate.Text;
                    string varToDate = dpToDate.Text;
                    try
                    {
                        await Task.Run(() =>
                        {
                            udfnExcel(objDs.Tables[0], "BillWise Purchase Tax Details Report", varSupplierName, varSupplierType, varInvoiceType, varFromDate, varToDate);
                        });
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                    tsbExport.Text = "Generate";
                    tsbExport.Enabled = true;
                    tsbDownload.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceFolder = Path.Combine(Application.StartupPath, "Excel", "Purchase");
                if (!Directory.Exists(sourceFolder))
                {
                    MessageBox.Show("Export folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] excelFiles = Directory.GetFiles(sourceFolder, "*.xlsx");
                if (excelFiles.Length == 0)
                {
                    MessageBox.Show("No Excel file found to download.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sourceFilePath = excelFiles[0];

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Save Exported Excel File";
                saveDialog.FileName = Path.GetFileName(sourceFilePath);

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(sourceFilePath, saveDialog.FileName, true);
                        MessageBox.Show("Excel file downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tsbDownload.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmPurchaseTaxDetails_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left) // only left-click
                {
                    SetupPurchaseTax();
                    var ts = tsmPurchaseTaxDetails.GetCurrentParent();
                    if (ts != null)
                    {
                        // Show context menu just below the label
                        var location = ts.PointToScreen(new Point(
                            tsmPurchaseTaxDetails.Bounds.Left,
                            tsmPurchaseTaxDetails.Bounds.Bottom));
                        contextMenu.Show(location);
                    }
                }
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
    }
}
