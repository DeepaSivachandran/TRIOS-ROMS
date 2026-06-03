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
using System.IO;

namespace ROMS
{
    public partial class REPORT_HSN_Tax_Summary : Form
    {
        MainForm objMainForm = new MainForm();
        private ContextMenuStrip contextMenu;
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        private ToolTip tpReportType = new ToolTip();
        private ToolTip tpSupplierType = new ToolTip();
        public int varUpDownKey = 0;
        public string varHSN_Name = "-All-";
        public REPORT_HSN_Tax_Summary()
        {
            InitializeComponent();
            windowControl.Initialize(tsHSNTaxSummary, this);
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
                udfnHSNCodeWiseReport(0);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHSNCodeWiseReport(int varFlag)
        {
            try
            {
                epReport.Clear();
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
                objDs = objspservice.udfnPurHsnReport(3, Convert.ToInt32(cmbSupplierType.SelectedValue), txtHsnName.Text.Trim(), Convert.ToInt32(cmbGST.SelectedValue), dpFromDate.Text, dpToDate.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "","", 0, 0, 0, 0, 0);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_HSNCodeWiseTaxDetails.rpt");
                    objBillreport.SetParameterValue("paraSupplierType", Convert.ToInt32(cmbSupplierType.SelectedValue));
                    objBillreport.SetParameterValue("paraHSNCode", txtHsnName.Text.Trim());
                    objBillreport.SetParameterValue("paraGST", Convert.ToInt32(cmbGST.SelectedValue));
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text);
                    objBillreport.SetParameterValue("paraToDate", dpToDate.Text);

                    objBillreport.SetParameterValue("paraSupplierTypeName", Convert.ToString(cmbSupplierType.Text));
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
                        string varReportName = "PUR_HSNCodeWiseTaxDetails";
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
        private void REPORT_CP_HSN_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80605;
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);

                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,11) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_GST", "GSTID<>-1", "GST_Text,GSTID", cmbGST, "", "GST_Text", "GSTID");
                objDataBind = null;
                cmbSupplierType.SelectedValue = 0;
                cmbGST.SelectedValue = 0;
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

        private void CmbSupplierType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

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
        private void btnTelegram_Click(object sender, EventArgs e)
        {
            udfnHSNCodeWiseReport(1);
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
