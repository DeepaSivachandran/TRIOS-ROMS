using DocumentFormat.OpenXml.VariantTypes;
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
    public partial class REPORT_CP_InactiveProduct : Form
    {
        MainForm objMainForm = new MainForm();
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyUser = 0, varUpDownKeySupplier = 0, varUpDownKeyRackGroup = 0;

        private ToolTip tpReportType = new ToolTip();
        public REPORT_CP_InactiveProduct()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tsInactiveProductReport, this);
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
                if (skipControl != txtRackgroup)
                {
                    varUpDownKeyRackGroup = 0;
                    DGV_FilterRackgroup.DataSource = null;
                    DGV_FilterRackgroup.Visible = false;
                }
                if (skipControl != txtUser)
                {
                    varUpDownKeyUser = 0;
                    DGV_FilterUser.DataSource = null;
                    DGV_FilterUser.Visible = false;
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
                udfnInactiveProducts(0);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnInactiveProducts(int varFlag)
        {
            try
            {
                string varGroupName = "-All-", varSubgroupName = "-All-", varRackGroupName = "-All-", varTellerName = "-All-", varChangedByName = "-All-";
                int varGroupCode = 0, varSubgroupCode = 0, varRackGroupCode = 0, varUserCode = 0;


                if (txtGroup.Text.Trim() != "")
                {
                    varGroupName = txtGroup.Text.Trim();
                    varGroupCode = Convert.ToInt32(lblGroupCode.Text);
                }
                if (txtSubGroup.Text.Trim() != "")
                {
                    varSubgroupName = txtSubGroup.Text.Trim();
                    varSubgroupCode = Convert.ToInt32(lblSubGroupCode.Text);
                }
                if (txtRackgroup.Text.Trim() != "")
                {
                    varRackGroupName = txtRackgroup.Text.Trim();
                    varRackGroupCode = Convert.ToInt32(lblRackgroupCode.Text);
                }
                if (txtTeller.Text.Trim() != "")
                {
                    varTellerName = txtTeller.Text.Trim();
                }
                if (txtUser.Text.Trim() != "")
                {
                    varChangedByName = txtUser.Text.Trim();
                    varUserCode = Convert.ToInt32(lblUserCode.Text);
                }
                btnView.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 73;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraGroup = varGroupCode;
                objMR_Product.paraSubgroup = varSubgroupCode;
                objMR_Product.paraRKGId = varRackGroupCode;
                objMR_Product.paraUserCode = varUserCode;
                objMR_Product.ParaFromDate = dpFromDate.Text;
                objMR_Product.ParaToDate = dpToDate.Text;
                objMR_Product.paraTeller = txtTeller.Text.Trim();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_InactiveProduct.rpt");
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraGroup", varGroupCode);
                    objBillreport.SetParameterValue("paraGroupName", varGroupName);
                    objBillreport.SetParameterValue("paraSubgroup", varSubgroupCode);
                    objBillreport.SetParameterValue("paraSubgroupName", varSubgroupName);
                    objBillreport.SetParameterValue("paraRKGID", varRackGroupCode);
                    objBillreport.SetParameterValue("paraRackGroupName", varRackGroupName);
                    objBillreport.SetParameterValue("paraUserCode", varUserCode);
                    objBillreport.SetParameterValue("paraChangedByName", varChangedByName);
                    objBillreport.SetParameterValue("paraTellerName", varTellerName);
                    objBillreport.SetParameterValue("paraTeller", txtTeller.Text.Trim());
                    objBillreport.SetParameterValue("ParaFromDate", dpFromDate.Text);
                    objBillreport.SetParameterValue("ParaToDate", dpToDate.Text);
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
                        string varReportName = "InactiveProduct";
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
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80114;
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID in(1,2) and COMID !=-1 Order by COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind = null;
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
                    txtRackgroup.Focus();
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
                        txtRackgroup.Focus();
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

                    //lvSubGroup.Items.Clear();
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
                txtRackgroup.Focus();
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
                        txtRackgroup.Focus();
                    }
                }
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
                txtRackgroup.Focus();
            }
        }

        private void TxtRackgroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRackgroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRackgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyRackGroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterRackgroup.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterRackgroup.Visible == false)
                {
                    txtTeller.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterRackgroup.Focus();
                }
                if (DGV_FilterRackgroup.CurrentCell == null && DGV_FilterRackgroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterRackgroup.Focus();
                    int RowIndex = DGV_FilterRackgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterRackgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyRackGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyRackGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterRackgroup.CurrentCell = DGV_FilterRackgroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtRackgroup.Text = DGV_FilterRackgroup.Rows[RowIndex].Cells["RKG_Name"].Value.ToString();
                            }
                            txtRackgroup.Focus();
                            txtRackgroup.SelectionStart = txtRackgroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterRackgroup.Rows.Count) DGV_FilterRackgroup.CurrentCell = DGV_FilterRackgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterRackgroup.Rows.Count))
                            {
                                txtRackgroup.Text = DGV_FilterRackgroup.Rows[RowIndex].Cells["RKG_Name"].Value.ToString();
                            }

                            txtRackgroup.Focus();
                            txtRackgroup.SelectionStart = txtRackgroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterRackgroup.Rows.Count > 0)
                                {
                                    varUpDownKeyRackGroup = 1;
                                    udfnRackgroup();
                                    DGV_FilterRackgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtRackgroup.Focus();
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtRackgroup.SelectedText = true;
                        TextBox txtRackgroup = sender as TextBox;
                        txtRackgroup.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtTeller.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRackgroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRackgroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterRackgroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyRackGroup = 1;
                udfnRackgroup();
                txtTeller.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterRackgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterRackgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterRackgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyRackGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyRackGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterRackgroup.CurrentCell = DGV_FilterRackgroup.Rows[RowIndex].Cells[ClmIndex];

                            txtRackgroup.Text = DGV_FilterRackgroup.SelectedRows[0].Cells["RKG_Name"].Value.ToString();

                            txtRackgroup.Focus();
                            txtRackgroup.SelectionStart = txtRackgroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterRackgroup.Rows.Count) DGV_FilterRackgroup.CurrentCell = DGV_FilterRackgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterRackgroup.Rows.Count))
                            {
                                txtRackgroup.Text = DGV_FilterRackgroup.Rows[RowIndex].Cells["RKG_Name"].Value.ToString();
                            }

                            txtRackgroup.Focus();
                            txtRackgroup.SelectionStart = txtRackgroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterRackgroup.Rows.Count > 0)
                                {
                                    varUpDownKeyRackGroup = 1;
                                    udfnRackgroup();
                                    DGV_FilterRackgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtRackgroup = sender as TextBox;
                        txtRackgroup.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtTeller.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRackgroup()
        {
            try
            {
                if (txtRackgroup.Text.Trim() != "")
                {
                    lblRackgroupCode.Text = DGV_FilterRackgroup.SelectedRows[0].Cells["RKGID"].Value.ToString();
                    txtRackgroup.Text = DGV_FilterRackgroup.SelectedRows[0].Cells["RKG_Name"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtTeller.Focus();
            }
        }

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
                udfnGridNull((Control)sender);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbConcern_Leave(object sender, EventArgs e)
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

        private void DpFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                dpFromDate.BackColor = Color.LemonChiffon;
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

        private void TxtTeller_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTeller_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUser.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTeller_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUser_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUser.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyUser = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterUser.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterUser.Visible == false)
                {
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterUser.Focus();
                }
                if (DGV_FilterUser.CurrentCell == null && DGV_FilterUser.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterUser.Focus();
                    int RowIndex = DGV_FilterUser.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterUser.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyUser = 1;
                    }
                    else
                    {
                        varUpDownKeyUser = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterUser.CurrentCell = DGV_FilterUser.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtUser.Text = DGV_FilterUser.Rows[RowIndex].Cells["U_Name"].Value.ToString();
                            }
                            txtUser.Focus();
                            txtUser.SelectionStart = txtUser.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterUser.Rows.Count) DGV_FilterUser.CurrentCell = DGV_FilterUser.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterUser.Rows.Count))
                            {
                                txtUser.Text = DGV_FilterUser.Rows[RowIndex].Cells["U_Name"].Value.ToString();
                            }

                            txtUser.Focus();
                            txtUser.SelectionStart = txtUser.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterUser.Rows.Count > 0)
                                {
                                    varUpDownKeyUser = 1;
                                    udfnUser();
                                    DGV_FilterUser.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtUser.Focus();
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtUser.SelectedText = true;
                        TextBox txtUser = sender as TextBox;
                        txtUser.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUser_Leave(object sender, EventArgs e)
        {
            try
            {
                txtUser.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUser()
        {
            try
            {
                if (txtUser.Text.Trim() != "")
                {
                    lblUserCode.Text = DGV_FilterUser.SelectedRows[0].Cells["UID"].Value.ToString();
                    txtUser.Text = DGV_FilterUser.SelectedRows[0].Cells["U_Name"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtTeller.Focus();
            }
        }

        private void DGV_FilterUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyUser = 1;
                udfnUser();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterUser_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterUser.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterUser.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyUser = 1;
                    }
                    else
                    {
                        varUpDownKeyUser = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterUser.CurrentCell = DGV_FilterUser.Rows[RowIndex].Cells[ClmIndex];

                            txtUser.Text = DGV_FilterUser.SelectedRows[0].Cells["U_Name"].Value.ToString();

                            txtUser.Focus();
                            txtUser.SelectionStart = txtUser.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterUser.Rows.Count) DGV_FilterUser.CurrentCell = DGV_FilterUser.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterUser.Rows.Count))
                            {
                                txtUser.Text = DGV_FilterUser.Rows[RowIndex].Cells["U_Name"].Value.ToString();
                            }

                            txtUser.Focus();
                            txtUser.SelectionStart = txtUser.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterUser.Rows.Count > 0)
                                {
                                    varUpDownKeyUser = 1;
                                    udfnUser();
                                    DGV_FilterUser.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtUser = sender as TextBox;
                        txtUser.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyUser == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtUser.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnUserList(5, txtUser.Text.Trim(), "", "", 0, 0, "");
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterUser.Visible = true;
                                    DGV_FilterUser.DataSource = objDs.Tables[0];
                                    DGV_FilterUser.Columns["UID"].Visible = false;
                                    DGV_FilterUser.Columns["U_CTID"].Visible = false;
                                    DGV_FilterUser.Columns["CTID"].Visible = false;
                                    DGV_FilterUser.Columns["Designation"].Visible = false;
                                    DGV_FilterUser.Columns["U_Name"].HeaderText = "User Name";
                                    DGV_FilterUser.Columns["U_Name"].Width = 200;
                                    DGV_FilterUser.Columns["U_Name"].DisplayIndex = 0;
                                    DGV_FilterUser.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterUser.Visible = false;
                                    DGV_FilterUser.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterUser.Visible = false;
                                DGV_FilterUser.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterUser.Visible = false;
                            DGV_FilterUser.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterUser.Visible = false;
                        DGV_FilterUser.DataSource = null;
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
            udfnInactiveProducts(1);
        }

        private void DpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
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
                    txtGroup.Focus();
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
        private void TxtRackgroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyRackGroup == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtRackgroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnRackGroupList(4, 0, 0, 0, 0, txtRackgroup.Text.Trim(),0,0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterRackgroup.Visible = true;
                                    DGV_FilterRackgroup.DataSource = objDs.Tables[0];
                                    DGV_FilterRackgroup.Columns["RKGID"].Visible = false;
                                    DGV_FilterRackgroup.Columns["RKG_Name"].HeaderText = "Rack Group";
                                    DGV_FilterRackgroup.Columns["RKG_Name"].Width = 200;
                                    DGV_FilterRackgroup.Columns["RKG_Name"].DisplayIndex = 0;
                                    DGV_FilterRackgroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterRackgroup.Visible = false;
                                    DGV_FilterRackgroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterRackgroup.Visible = false;
                                DGV_FilterRackgroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterRackgroup.Visible = false;
                            DGV_FilterRackgroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterRackgroup.Visible = false;
                        DGV_FilterRackgroup.DataSource = null;
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
    }
}
