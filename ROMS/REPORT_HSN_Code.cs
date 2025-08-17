using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class REPORT_HSN_Code : Form
    {
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        private ToolTip tpReportType = new ToolTip();
        private ToolTip tpSupplierType = new ToolTip();
        public int varUpDownKey = 0;
        public string varHSN_Name = "-All-";
        public REPORT_HSN_Code()
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
                if (skipControl != txtHsnName)
                {
                    varUpDownKey = 0;
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
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 287 || Convert.ToInt32(cmbReportType.SelectedValue) == 289)
                    {
                        if ((Convert.ToInt32(cmbReportType.SelectedValue) == 287 || Convert.ToInt32(cmbReportType.SelectedValue) == 289) && Convert.ToInt32(cmbSupplierType.SelectedValue) == -1)
                        {
                            cmbSupplierType.Focus();
                            epReport.SetError(cmbSupplierType, "Please select supplier type.");
                            cmbSupplierType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpReportType.ShowAlways = true;
                            tpReportType.Show("Please select supplier type.", cmbSupplierType, 5000);
                        }
                        else
                        {
                            udfnHSNCodeWiseReport();
                        }
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 288)
                    {
                        udfnHSNCodeWiseReport();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHSNCodeWiseReport()
        {
            try
            {
                epReport.Clear();
                int varViewType = 3;
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 287 || Convert.ToInt32(cmbReportType.SelectedValue) == 289)
                {
                    if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 30)
                    {
                        varViewType = 0;
                    }
                    else if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 151)
                    {
                        varViewType = 1;
                    }
                    else
                    {
                        varViewType = 2;
                    }
                }
                string varHSNName = "-All-";
                if (txtHsnName.Text.Trim() != "")
                {
                    varHSNName = txtHsnName.Text.Trim();
                }
                else
                {
                    varHSN_Name = "-All";
                }
                btnListPrint.Enabled = false;
                //lblStatus.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnPurHsnReport(varViewType, Convert.ToInt32(cmbSupplierType.SelectedValue), txtHsnName.Text.Trim(), Convert.ToInt32(cmbGST.SelectedValue), dpFromDate.Text, dpToDate.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "",0);
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
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 287)
                    {
                        if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 30)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNCodeWise.rpt");
                        }
                        else if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 31 || Convert.ToInt32(cmbSupplierType.SelectedValue) == 32)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNCodeWiseComposite.rpt");
                        }
                        else
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNCodeWise_IGST.rpt");
                        }
                        objBillreport.SetParameterValue("paraHSNName", varHSNName);
                        objBillreport.SetParameterValue("paraGSTName", Convert.ToString(cmbGST.Text));
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 289)
                    {
                        if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 30)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNNameWise.rpt");
                        }
                        else if (Convert.ToInt32(cmbSupplierType.SelectedValue) == 31 || Convert.ToInt32(cmbSupplierType.SelectedValue) == 32)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNNameWiseComposite.rpt");
                        }
                        else
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNNameWise_IGST.rpt");
                        }
                        objBillreport.SetParameterValue("paraHSNName", varHSN_Name);
                        objBillreport.SetParameterValue("paraGSTName", Convert.ToString(cmbGST.Text));
                    }
                    else
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNCodeWiseTaxDetails.rpt");
                    }
                    objBillreport.SetParameterValue("paraSupplierType", Convert.ToInt32(cmbSupplierType.SelectedValue));
                    objBillreport.SetParameterValue("paraHSNCode", txtHsnName.Text.Trim());
                    objBillreport.SetParameterValue("paraGST", Convert.ToInt32(cmbGST.SelectedValue));
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text);
                    objBillreport.SetParameterValue("paraToDate", dpToDate.Text);

                    objBillreport.SetParameterValue("paraSupplierTypeName", Convert.ToString(cmbSupplierType.Text));
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
        private void REPORT_CP_HSN_Load(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,84) AND MSTID<>0", "MST_DisplayText,MSTID", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>0", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_GST", "GSTID<>-1", "GST_Text,GSTID", cmbGST, "", "GST_Text", "GSTID");
                objDataBind = null;
                cmbReportType.SelectedValue = -1;
                cmbSupplierType.SelectedValue = -1;
                cmbGST.SelectedValue = 0;
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
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 288)
                {
                    txtHsnName.Text = "";
                    txtHsnName.Enabled = false;
                    cmbGST.SelectedValue = 0;
                    cmbGST.Enabled = false;
                    objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                    cmbSupplierType.SelectedValue = 0;
                }
                else
                {
                    txtHsnName.Enabled = true;
                    cmbGST.Enabled = true;
                    objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>0", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                    cmbSupplierType.SelectedValue = -1;
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
        private void CmbGST_Enter(object sender, EventArgs e)
        {
            try
            {
                lvHsnName.Visible = false;
                udfnGridNull((Control)sender);
                cmbGST.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbGST_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbGST_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbGST_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbGST.BackColor = Color.White;
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
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    //if (lvproduct.Items.Count == 0 && txtProductName.Text == "")
                    //{
                    //    txtMrp.Focus();
                    //    lvproduct.Visible = false;
                    //}
                    //else
                    //{
                    //    lvproduct.Focus();
                    //}
                    //if (lvproduct.Items.Count > 0)
                    //{
                    //    lvproduct.Items[0].Selected = true;
                    //}
                    DGV_FilterHSN.Focus();

                }
                //if (e.KeyCode == Keys.Enter)
                //{
                //    txtMrp.Focus();
                //}
                if (e.KeyCode == Keys.Enter && DGV_FilterHSN.Visible == false)
                {
                    cmbGST.Focus();
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
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
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
                                    varUpDownKey = 1;
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
                        cmbGST.Focus();
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
                if (varUpDownKey == 0)
                {
                    lvHsnName.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtHsnName.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnHsnList(6, 0, 0, 0, txtHsnName.Text.Trim(), "");
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
                                    DGV_FilterHSN.Columns["HSN_GSTID"].Visible = false;
                                    DGV_FilterHSN.Columns["GST_Text"].Visible = false;
                                    DGV_FilterHSN.Columns["HSN_Name"].HeaderText = "HSN Name";
                                    DGV_FilterHSN.Columns["HSN_Code"].HeaderText = "HSN Code";
                                    DGV_FilterHSN.Columns["HSN_Name"].Width = 160;
                                    DGV_FilterHSN.Columns["HSN_Code"].Width = 140;
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
                cmbGST.Focus();
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
                    if (txtHsnName.Enabled == true)
                    {
                        txtHsnName.Focus();
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

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnHSNAutocomplete();
                cmbGST.Focus();
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
                    int RowIndex = DGV_FilterHSN.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterHSN.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
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
                                    varUpDownKey = 1;
                                    udfnHSNAutocomplete();
                                    DGV_FilterHSN.Visible = false;
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
                        cmbGST.Focus();
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
