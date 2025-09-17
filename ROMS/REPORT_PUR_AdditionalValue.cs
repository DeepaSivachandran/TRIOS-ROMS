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

namespace ROMS
{
    public partial class REPORT_PUR_AdditionalValue : Form
    {
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        private ToolTip tpReportType = new ToolTip();
        public int varUpDownKeySupplier = 0;
        private DataService objService;

        private List<ComboItem> months;


        public REPORT_PUR_AdditionalValue()
        {
            InitializeComponent();
            //var months = new List<ComboItem>
            //{
            //    new ComboItem { Id = 1, Text = "January" },
            //    new ComboItem { Id = 2, Text = "February" },
            //    new ComboItem { Id = 3, Text = "March" },
            //    new ComboItem { Id = 4, Text = "April" },
            //    new ComboItem { Id = 5, Text = "May" },
            //    new ComboItem { Id = 6, Text = "June" },
            //    new ComboItem { Id = 7, Text = "July" },
            //    new ComboItem { Id = 8, Text = "August" },
            //    new ComboItem { Id = 9, Text = "September" },
            //    new ComboItem { Id = 10, Text = "October" },
            //    new ComboItem { Id = 11, Text = "November" },
            //    new ComboItem { Id = 12, Text = "December" }
            //};

            //multiSelectComboBox1.LoadItems(months, "Select Month");

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
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 332)
                    {
                        SPDataService objDataService = new SPDataService();
                        string varMessage = objDataService.udfnGetMessages(161);
                        MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objDataService.CloseConnection();
                    }
                    udfnPurchaseAdditionalValueReport();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnPurchaseAdditionalValueReport()
        {
            try
            {
                string varMonthIds = "";
                var selIds = cmbMultiMonths.CheckedIds;
                var selItems = months.Where(m => selIds.Contains(m.Id)).ToList();
                lblMonths.Text = string.Join(", ", selItems.Select(x => x.Text));
                varMonthIds = string.Join(", ", selItems.Select(x => x.Id));
                epReport.Clear();
                string varSupplierName = "-All-";
                int varSupplierId = 0, varViewType = 20, varScheduleId = 0;
                if (txtSupplier.Text.Trim() != "")
                {
                    varSupplierName = txtSupplier.Text;
                    varSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    varScheduleId = Convert.ToInt32(lblScheduleCode.Text);
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 333)
                {
                    varViewType = 21;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 334)
                {
                    varViewType = 22;
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
                objDs = objdserv.udfnPurHsnReport(varViewType, Convert.ToInt32(cmbSupplierType.SelectedValue), "", 0, dpFromDate.Text, dpToDate.Text, 0, 0, 0, 0, 0, 0, varSupplierId, varScheduleId, Convert.ToInt32(cmbInvType.SelectedValue), 0, 0, 0, 0, "", Convert.ToInt32(cmbMonths.SelectedValue));
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
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 332)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_Tax_AdditionalValue_BillWise.rpt");
                        objBillreport.SetParameterValue("paraSupplierName", varSupplierName);
                        objBillreport.SetParameterValue("paraInvoiceTypeName", Convert.ToString(cmbInvType.Text));
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 333)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_Tax_AdditionalValue_DayWise.rpt");
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 334)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_Tax_AdditionalValue_MonthWise.rpt");
                        objBillreport.SetParameterValue("paraMonthName", cmbMonths.Text);
                        objBillreport.SetParameterValue("paraMonth", Convert.ToInt32(cmbMonths.SelectedValue));
                    }
                    objBillreport.SetParameterValue("paraSupplierType", Convert.ToInt32(cmbSupplierType.SelectedValue));
                    objBillreport.SetParameterValue("paraHSNCode", 0);
                    objBillreport.SetParameterValue("paraGST", 0);
                    objBillreport.SetParameterValue("paraCompanyId", 0);
                    objBillreport.SetParameterValue("paraInvioceType", Convert.ToInt32(cmbInvType.SelectedValue));
                    objBillreport.SetParameterValue("paraPaymentType", 0);
                    objBillreport.SetParameterValue("paraPurchaseType", 0);
                    objBillreport.SetParameterValue("paraConditionType",0);
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
                    objBillreport.SetParameterValue("paraSupplierTypeName", cmbSupplierType.Text);

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
                udfnLoadMonths();
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,99) AND MSTID<>0", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,78) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbInvType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Months", "MONID<>-1", "MON_Name,MONID", cmbMonths, "", "MON_Name", "MONID");
                
                objDataBind = null;
                cmbSupplierType.SelectedValue = 0;
                cmbInvType.SelectedValue = 0;
                cmbMonths.SelectedValue = 0;
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
                    if (cmbInvType.Enabled == true)
                    {
                        cmbInvType.Focus();
                    }
                    else
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
                        if (cmbInvType.Enabled == true)
                        {
                            cmbInvType.Focus();
                        }
                        else
                        {
                            if (cmbMonths.Enabled == true)
                            {
                                cmbMonths.Focus();
                            }
                            else
                            {
                                btnListPrint.Focus();
                            }
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
                if (cmbInvType.Enabled == true)
                {
                    cmbInvType.Focus();
                }
                else
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
                if (cmbInvType.Enabled == true)
                {
                    cmbInvType.Focus();
                }
                else
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
                        if (cmbInvType.Enabled == true)
                        {
                            cmbInvType.Focus();
                        }
                        else
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
                    if(dpFromDate.Enabled==true)
                    {
                        dpFromDate.Focus();
                    }else
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
                        tsbPrintFormat.Text = drv["MST_ShortName"]?.ToString() ?? string.Empty;
                    }
                    else
                    {
                        tsbPrintFormat.Text = string.Empty;
                    }
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == -1)
                {
                    cmbMonths.Enabled = true;
                    cmbMonths.SelectedValue = 0;
                    cmbInvType.Enabled = true;
                    cmbInvType.SelectedValue = 0;
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 332)//Bill Wise Report
                {
                    cmbMonths.SelectedValue = 0;
                    cmbMonths.Enabled = false;
                    cmbInvType.Enabled = true;
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 333)//Day Wise Report
                {
                    cmbInvType.SelectedValue = 0;
                    cmbInvType.Enabled = false;
                    cmbMonths.SelectedValue = 0;
                    cmbMonths.Enabled = false;
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 334)//Month Wise Report
                {
                    cmbInvType.SelectedValue = 0;
                    cmbInvType.Enabled = false;
                    dpFromDate.Value = MainForm.pbCurrentDate;
                    dpToDate.Value = MainForm.pbCurrentDate;
                    dpFromDate.Enabled = false;
                    dpToDate.Enabled = false;
                    cmbMultiMonths.Enabled = true;
                    cmbMonths.Enabled = true;
                    cmbMonths.SelectedValue = 0;
                }
                else
                {
                    dpFromDate.Enabled = true;
                    dpToDate.Enabled = true;
                    cmbMultiMonths.Enabled = false;
                }
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
    }
}
