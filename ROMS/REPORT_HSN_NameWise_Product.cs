using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class REPORT_HSN_NameWise_Product : Form
    {
        private ContextMenuStrip contextMenu;
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyHSN = 0, varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyProduct = 0;
        private ToolTip tpReportType = new ToolTip();
        private ToolTip tpSupplierType = new ToolTip();
        public string varHSN_Name = "-All-";
        public REPORT_HSN_NameWise_Product()
        {
            InitializeComponent();
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
                if (skipControl != txtGroup)
                {
                    varUpDownKeyGroup = 0;
                    DGV_FilterGroup.DataSource = null;
                    DGV_FilterGroup.Visible = false;
                }
                if (skipControl != txtSubGroup)
                {
                    varUpDownKeySubgroup = 0;
                    DGV_FilterSubgroup.DataSource = null;
                    DGV_FilterSubgroup.Visible = false;
                }
                if (skipControl != txtProductName)
                {
                    varUpDownKeyProduct = 0;
                    DGV_FilterProduct.DataSource = null;
                    DGV_FilterProduct.Visible = false;
                }
                if (skipControl != txtHsnName)
                {
                    varUpDownKeyHSN = 0;
                    DGV_FilterHSN.DataSource = null;
                    DGV_FilterHSN.Visible = false;
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
                    cmbReportType.Focus();
                    epReport.SetError(cmbReportType, "Please select report type.");
                    cmbReportType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReportType.ShowAlways = true;
                    tpReportType.Show("Please select report type.", cmbReportType, 5000);
                }
                else
                {
                    if ((Convert.ToInt32(cmbReportType.SelectedValue) == 290) && Convert.ToInt32(cmbSupplierType.SelectedValue) == -1)
                    {
                        cmbSupplierType.Focus();
                        epReport.SetError(cmbSupplierType, "Please select supplier type.");
                        cmbSupplierType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpReportType.ShowAlways = true;
                        tpReportType.Show("Please select supplier type.", cmbSupplierType, 5000);
                    }
                    else
                    {
                        udfnHSN();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHSN()
        {
            try
            {
                epReport.Clear();
                btnListPrint.Enabled = false;
                //lblStatus.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                int varViewType = 7, varProductId = 0, varGroupId = 0, varSubgroupId = 0, varHSNId = 0;
                string varProductName = "-All-", varGroupName = "-All-", varSubgroupName = "-All-";
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 290)
                {
                    if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 30)
                    {
                        varViewType = 4;
                    }
                    else if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 151)
                    {
                        varViewType = 5;
                    }
                    else
                    {
                        varViewType = 6;
                    }
                }
                if(txtHsnName.Text.Trim()=="")
                {
                    varHSN_Name = "-All-";
                }
                if (txtProductName.Text.Trim() != "")
                {
                    varProductName = txtProductName.Text.Trim();
                    varProductId = Convert.ToInt32(lblProductcode.Text);
                }
                if (txtGroup.Text.Trim() != "")
                {
                    varGroupName = txtGroup.Text.Trim();
                    varGroupId = Convert.ToInt32(lblGroupCode.Text);
                }
                if (txtSubGroup.Text.Trim() != "")
                {
                    varSubgroupName = txtSubGroup.Text.Trim();
                    varSubgroupId = Convert.ToInt32(lblSubGroupCode.Text);
                }
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnPurHsnReport(varViewType, Convert.ToInt32(cmbSupplierType.SelectedValue), txtHsnName.Text.Trim(), 0, dpFromDate.Text, dpToDate.Text, varProductId, varGroupId, varSubgroupId, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,"","");
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 290)
                    {
                        if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 30)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNNameWiseProduct.rpt");
                        }
                        else if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 31 || Convert.ToInt32(cmbSupplierType.SelectedValue) == 32)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNNameWiseProductComposite.rpt");
                        }
                        else
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNNameWiseProduct_IGST.rpt");
                        }
                    }
                    else
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNNameWiseProductConsolidated.rpt");
                    }
                    objBillreport.SetParameterValue("paraSupplierType", Convert.ToInt32(cmbSupplierType.SelectedValue));
                    objBillreport.SetParameterValue("paraHSNCode", txtHsnName.Text.Trim());
                    objBillreport.SetParameterValue("paraHSNName", varHSN_Name);
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text);
                    objBillreport.SetParameterValue("paraToDate", dpToDate.Text);
                    objBillreport.SetParameterValue("paraSupplierTypeName", Convert.ToString(cmbSupplierType.Text));
                    objBillreport.SetParameterValue("paraProductName", varProductName);
                    objBillreport.SetParameterValue("paraProductId", varProductId);
                    objBillreport.SetParameterValue("paraGroupName", varGroupName);
                    objBillreport.SetParameterValue("ParaGroupId", varGroupId);
                    objBillreport.SetParameterValue("paraSubgroupName", varSubgroupName);
                    objBillreport.SetParameterValue("paraSubgroupId", varSubgroupId);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraToDate", dpToDate.Text, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraProductId", varProductId, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("ParaGroupId", varGroupId, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraSubgroupId", varSubgroupId, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraSupplierType", Convert.ToInt32(cmbSupplierType.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraHSNCode", txtHsnName.Text.Trim(), objBillreport.Subreports[0].Name.ToString());
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
        private void REPORT_CP_HSN_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 8060602;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);

                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                DataBind objDataBind = new DataBind();  //Transaction id 	85
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MSTID IN (" + ReportTypeIDs + ")", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>0", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbReportType.SelectedValue = -1;
                cmbSupplierType.SelectedValue = -1;
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
        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                BeginInvoke(new Action(() => cmbReportType.Select(int.MaxValue, 0)));
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 290)
                {
                    objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>0", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                    cmbSupplierType.SelectedValue = -1;
                }
                else
                {
                    objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                    cmbSupplierType.SelectedValue = 0;
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
        private void REPORT_CP_HSN_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtHsnName_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtHsnName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyHSN = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterHSN.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterHSN.Visible == false)
                {
                    txtGroup.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterHSN.Focus();
                }
                if (DGV_FilterHSN.CurrentCell == null && DGV_FilterHSN.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterHSN.Focus();
                    int RowIndex = DGV_FilterHSN.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterHSN.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyHSN = 1;
                    }
                    else
                    {
                        varUpDownKeyHSN = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterHSN.CurrentCell = DGV_FilterHSN.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtHsnName.Text = DGV_FilterHSN.Rows[RowIndex].Cells["HSN_Code"].Value.ToString();
                            }
                            txtHsnName.Focus();
                            txtHsnName.SelectionStart = txtHsnName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterHSN.Rows.Count) DGV_FilterHSN.CurrentCell = DGV_FilterHSN.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterHSN.Rows.Count))
                            {
                                txtHsnName.Text = DGV_FilterHSN.Rows[RowIndex].Cells["HSN_Code"].Value.ToString();
                            }

                            txtHsnName.Focus();
                            txtHsnName.SelectionStart = txtHsnName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterHSN.Rows.Count > 0)
                                {
                                    varUpDownKeyHSN = 1;
                                    udfnHSNAutocomplete();
                                    DGV_FilterHSN.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtHsnName.Focus();
                    //txtHsnName.SelectionStart = txtHsnName.Text.Length;
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
                        txtGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtHsnName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyHSN == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtHsnName.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnHsnList(6, 0, 1, 0, txtHsnName.Text.Trim(), "");
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterHSN.Visible = true;
                                    DGV_FilterHSN.DataSource = objDs.Tables[0];
                                    DGV_FilterHSN.Columns["HSNID"].Visible = false;
                                    DGV_FilterHSN.Columns["GST_Text"].Visible = false;
                                    DGV_FilterHSN.Columns["HSN_Name"].Visible = false;
                                    //DGV_FilterHSN.Columns["HSN_Name"].HeaderText = "HSN Name";
                                    DGV_FilterHSN.Columns["HSN_Code"].HeaderText = "HSN Code";
                                    DGV_FilterHSN.Columns["HSN_Name"].Width = 160;
                                    DGV_FilterHSN.Columns["HSN_Code"].Width = 180;
                                    DGV_FilterHSN.Columns["HSN_Code"].DisplayIndex = 0;
                                    DGV_FilterHSN.Columns["HSN_Name"].DisplayIndex = 1;
                                    DGV_FilterHSN.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterHSN.Visible = false;
                                    DGV_FilterHSN.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterHSN.Visible = false;
                                DGV_FilterHSN.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterHSN.Visible = false;
                            DGV_FilterHSN.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterHSN.Visible = false;
                        DGV_FilterHSN.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvHsnName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnHSNAutocomplete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvHsnName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnHSNAutocomplete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHSNAutocomplete()
        {
            try
            {
                if (txtHsnName.Text.Trim() != "")
                {
                    txtHsnName.Text = DGV_FilterHSN.SelectedRows[0].Cells["HSN_Code"].Value.ToString();
                    varHSN_Name = DGV_FilterHSN.SelectedRows[0].Cells["HSN_Name"].Value.ToString();
                    lblHsnName.Text = DGV_FilterHSN.SelectedRows[0].Cells["HSNID"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvHsnName.Visible = false;
                txtGroup.Focus();
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

        private void CmbSupplierType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtHsnName.Focus();
                }
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
        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyProduct = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    btnListPrint.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterProduct.Focus();
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }
                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
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
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyProduct == 0)
                {
                    int varGroupCode = 0, varSubgroupCode = 0;
                    if (txtGroup.Text != "")
                    {
                        varGroupCode = Convert.ToInt32(lblGroupCode.Text);
                    }
                    if (txtSubGroup.Text != "")
                    {
                        varSubgroupCode = Convert.ToInt32(lblSubGroupCode.Text);
                    }
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 49;
                        objMR_Product.paraGroup = varGroupCode;
                        objMR_Product.paraSubgroup = varSubgroupCode;
                        objMR_Product.paraProductName = txtProductName.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "P.I Code";
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 0;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
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
        private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListviewProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text.Trim() != "")
                {
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                }
                btnListPrint.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvproduct.Visible = false;
            }
        }

        private void TxtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyGroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterGroup.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterGroup.Visible == false)
                {
                    txtSubGroup.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterGroup.Focus();
                }
                if (DGV_FilterGroup.CurrentCell == null && DGV_FilterGroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterGroup.Focus();
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
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
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }
                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyGroup = 1;
                                    udfnGroupAutocomplete();
                                    DGV_FilterGroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtGroup.Focus();
                    //txtGroup.SelectionStart = txtGroup.Text.Length;
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
                        txtSubGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyGroup == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnGroupList(7, 0, 0, txtGroup.Text, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterGroup.Visible = true;
                                    DGV_FilterGroup.DataSource = objDs.Tables[0];
                                    DGV_FilterGroup.Columns["PRGID"].Visible = false;
                                    DGV_FilterGroup.Columns["PRG_EName"].HeaderText = "Group English Name";
                                    DGV_FilterGroup.Columns["PRG_TName"].HeaderText = "Group Tamil Name";
                                    DGV_FilterGroup.Columns["PRG_EName"].Width = 130;
                                    DGV_FilterGroup.Columns["PRG_TName"].Width = 130;
                                    DGV_FilterGroup.Columns["PRG_EName"].DisplayIndex = 0;
                                    DGV_FilterGroup.Columns["PRG_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterGroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterGroup.Visible = false;
                                    DGV_FilterGroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterGroup.Visible = false;
                                DGV_FilterGroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterGroup.Visible = false;
                            DGV_FilterGroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterGroup.Visible = false;
                        DGV_FilterGroup.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGroupAutocomplete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGroupAutocomplete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGroupAutocomplete()
        {
            try
            {
                if (txtGroup.Text.Trim() != "")
                {
                    lblGroupCode.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRGID"].Value.ToString();
                    txtGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvGroup.Visible = false;
                txtSubGroup.Focus();
            }
        }

        private void TxtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Visible = false;
                udfnGridNull((Control)sender);
                txtSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySubgroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSubgroup.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSubgroup.Visible == false)
                {
                    txtProductName.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSubgroup.Focus();
                }
                if (DGV_FilterSubgroup.CurrentCell == null && DGV_FilterSubgroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSubgroup.Focus();
                    int RowIndex = DGV_FilterSubgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSubgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySubgroup = 1;
                    }
                    else
                    {
                        varUpDownKeySubgroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }
                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSubgroup.Rows.Count > 0)
                                {
                                    varUpDownKeySubgroup = 1;
                                    udfnSubGroupAutocomplete();
                                    DGV_FilterSubgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSubGroup.Focus();
                    //txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
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
                        txtProductName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeySubgroup == 0)
                {
                    if (txtGroup.Text.Trim() == "")
                    {
                        lblGroupCode.Text = "0";
                    }
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtSubGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupCode.Text), 0, txtSubGroup.Text, 0, 0, 0, 0, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterSubgroup.Visible = true;
                                    DGV_FilterSubgroup.DataSource = objDs.Tables[0];
                                    DGV_FilterSubgroup.Columns["PRSGID"].Visible = false;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].HeaderText = "Subgroup English Name";
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].HeaderText = "Subgroup Tamil Name";
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].Width = 150;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].Width = 200;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].DisplayIndex = 0;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterSubgroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSubgroup.Visible = false;
                                    DGV_FilterSubgroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterSubgroup.Visible = false;
                                DGV_FilterSubgroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterSubgroup.Visible = false;
                            DGV_FilterSubgroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterSubgroup.Visible = false;
                        DGV_FilterSubgroup.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSubGroupAutocomplete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSubGroupAutocomplete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSubGroupAutocomplete()
        {
            try
            {
                if (txtSubGroup.Text.Trim() != "")
                {
                    lblSubGroupCode.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSGID"].Value.ToString();
                    txtSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSubGroup.Visible = false;
                txtProductName.Focus();
            }
        }

        private void DGV_FilterHSN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyHSN = 1;
                udfnHSNAutocomplete();
                txtGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterHSN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterHSN.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterHSN.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyHSN = 1;
                    }
                    else
                    {
                        varUpDownKeyHSN = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterHSN.CurrentCell = DGV_FilterHSN.Rows[RowIndex].Cells[ClmIndex];

                            txtHsnName.Text = DGV_FilterHSN.SelectedRows[0].Cells["HSN_Code"].Value.ToString();

                            txtHsnName.Focus();
                            txtHsnName.SelectionStart = txtHsnName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterHSN.Rows.Count) DGV_FilterHSN.CurrentCell = DGV_FilterHSN.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterHSN.Rows.Count))
                            {
                                txtHsnName.Text = DGV_FilterHSN.Rows[RowIndex].Cells["HSN_Code"].Value.ToString();
                            }

                            txtHsnName.Focus();
                            txtHsnName.SelectionStart = txtHsnName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterHSN.Rows.Count > 0)
                                {
                                    varUpDownKeyHSN = 1;
                                    udfnHSNAutocomplete();
                                    DGV_FilterHSN.Visible = false;
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
                        txtGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyGroup = 1;
                udfnGroupAutocomplete();
                txtSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
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
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            txtGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyGroup = 1;
                                    udfnGroupAutocomplete();
                                    DGV_FilterGroup.Visible = false;
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
                        txtSubGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSubgroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySubgroup = 1;
                udfnSubGroupAutocomplete();
                txtProductName.Focus();
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

        private void DGV_FilterSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSubgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSubgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySubgroup = 1;
                    }
                    else
                    {
                        varUpDownKeySubgroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            txtSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSubgroup.Rows.Count > 0)
                                {
                                    varUpDownKeySubgroup = 1;
                                    udfnSubGroupAutocomplete();
                                    DGV_FilterSubgroup.Visible = false;
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
                        txtProductName.Focus();
                    }
                }
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
                udfnListviewProduct();
                btnListPrint.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
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
        private void SetupHsnUI()
        {
            // Create ContextMenuStrip (does NOT hide your label)
            contextMenu = new ContextMenuStrip();
            contextMenu.Font = new Font("Oswald", 10, FontStyle.Regular);
            contextMenu.Items.Add("Purchase Hsn Wise", null, (s, ev) =>
            {
                MainForm.objREPORT_HSN_Code = new REPORT_HSN_Code();
                MainForm.objREPORT_HSN_Code.MdiParent = this.ParentForm;
                MainForm.objREPORT_HSN_Code.Show();
            });
            contextMenu.Items.Add("Purchase Hsn Name Wise Product", null, (s, ev) =>
            {
                MainForm.objREPORT_HSN_NameWise_Product = new REPORT_HSN_NameWise_Product();
                MainForm.objREPORT_HSN_NameWise_Product.MdiParent = this.ParentForm;
                MainForm.objREPORT_HSN_NameWise_Product.Show();
            });
        }

    }

}
