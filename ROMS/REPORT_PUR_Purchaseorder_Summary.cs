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
using System.IO;

namespace ROMS
{
    public partial class REPORT_PUR_Purchaseorder_Summary : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        MainForm objMainForm = new MainForm();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public string varRefNo = "0";
        public int varUpDownKeyCity = 0, varUpDownKeySupplier = 0;
        public REPORT_PUR_Purchaseorder_Summary()
        {
            InitializeComponent();
            windowControl.Initialize(tsPOSummaryDetailsReport, this);
        }
        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGrnstatus.Focus();
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
                if (skipControl != txtCity)
                {
                    varUpDownKeyCity = 0;
                    DGV_FilterCity.DataSource = null;
                    DGV_FilterCity.Visible = false;
                }
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
        public void udfnList(int varFlag)
        {
            try
            {
                bool varErrorFlag = false;
                if (Convert.ToString(txtDelaydays.Text) == "0")
                {
                    errGRNDetails.SetError(txtDelaydays, "Invalid delayvalue");
                    txtDelaydays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSupplier.ShowAlways = true;
                    tpSupplier.Show("Invalid delayvalue", txtDelaydays, 5000);
                    varErrorFlag = true;
                }
                if (varErrorFlag == false)
                {
                    errGRNDetails.Clear();
                    txtDelaydays.BackColor = Color.White;
                    udfnProductDetails(varFlag);
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
        public void udfnProductDetails(int varFlag)
        {
            try
            {
                /* Check product group is valid or not*/
                string varId_Group = "0";
                string varGRN = "",varOrdertype="",varCity="", varSuppliername = "", varStatus="",varDtat="";
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    varSuppliername = "-All-";
                }
                else
                {
                    varSuppliername = txtSupplier.Text;
                }
                if (txtCity.Text == "")
                {
                    lblcityid.Text = "0";
                    varCity = "-All-";
                }
                else
                {
                    varCity = txtCity.Text;
                }
                if (txtDelaydays.Text == "")
                {
                    varDtat = "-All-";
                }
                else
                {
                    varDtat = txtDelaydays.Text + "Days";
                } 


                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0, varFilterTat = 0;
                varRefNo ="0";
                if (txtDelaydays.Text != "")
                {
                    varFilterTat = Convert.ToInt32(txtDelaydays.Text);
                }
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                //********** To display a data in a grid  ******************   
                int varsupplier = 0, varpono = 0, varFilter = 0; 
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                if (Convert.ToInt32(cmbReporttype.SelectedValue) == 162)
                {
                    objDs = objdserv.udfnPOEntry(8, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), 0, 0, varsupplier, varpono, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), "0", varFilter, 0, Convert.ToInt32(cmbOrdertype.SelectedValue), Convert.ToInt32(lblcityid.Text), Convert.ToInt32(varFilterTat), Convert.ToInt32(cmbGrnstatus.SelectedValue),0,0);
                    objdserv.CloseConnection();
                }
                else if (Convert.ToInt32(cmbReporttype.SelectedValue) == 163)
                {
                    objDs = objdserv.udfnPOEntry(9, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), 0, 0, varsupplier, varpono, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), "0", varFilter, 0, Convert.ToInt32(cmbOrdertype.SelectedValue), Convert.ToInt32(lblcityid.Text), Convert.ToInt32(varFilterTat), Convert.ToInt32(cmbGrnstatus.SelectedValue),0,0);
                    objdserv.CloseConnection();
                }
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varPrint = 1;
                            if (Convert.ToInt32(cmbReporttype.SelectedValue) == 163)
                            {
                                varRefNo = objDs.Tables[0].Rows[0]["PORPT_RefNo"].ToString();
                            }
                        }
                    }
                }
                string varReportName = "";
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    if(Convert.ToInt32(cmbReporttype.SelectedValue) == 162)
                    {
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_Summary_Report.rpt"); 
                        objBillreport.SetParameterValue("parafilter", 0);
                        objBillreport.SetParameterValue("paraSupplierid ", Convert.ToInt32(lblSupplierCode.Text));
                        objBillreport.SetParameterValue("ParaScheduleId ", Convert.ToInt32(lblschedleCode.Text));
                        objBillreport.SetParameterValue("paraStatus", Convert.ToInt32(cmbStatus.SelectedValue));
                        objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                        objBillreport.SetParameterValue("paraSupplierName", varSuppliername);
                        objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                        objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        objBillreport.SetParameterValue("paraOrdertype", Convert.ToInt32(cmbOrdertype.SelectedValue));
                        objBillreport.SetParameterValue("paraOrdertypevalue", (cmbOrdertype.Text));
                        objBillreport.SetParameterValue("paraCityid", Convert.ToInt32(lblcityid.Text));
                        objBillreport.SetParameterValue("paraCityname", (varCity));
                        objBillreport.SetParameterValue("paraDTAT", Convert.ToInt32(varFilterTat));
                        objBillreport.SetParameterValue("paraDTATvalue", (varDtat));
                        objBillreport.SetParameterValue("paraGRNstatus", Convert.ToInt32(cmbGrnstatus.SelectedValue));
                        varReportName = "PUR_PO_Summary";
                    }
                    else
                    { 
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_Detail_Report.rpt");

                        objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                        objBillreport.SetParameterValue("paraSupplierName", varSuppliername);
                        objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                        objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        objBillreport.SetParameterValue("paraOrdertypevalue", (cmbOrdertype.Text));
                        objBillreport.SetParameterValue("paraCityname", (varCity));
                        objBillreport.SetParameterValue("paraDTATvalue", (varDtat));
                        objBillreport.SetParameterValue("ParaRefNo", Convert.ToInt32(varRefNo), objBillreport.Subreports[0].Name.ToString()); 
                        //objBillreport.SetParameterValue("paraRefno", Convert.ToInt32(varRefNo), objBillreport.Subreports[1].Name.ToString()); 
                        objBillreport.SetParameterValue("ParaRefNo", varRefNo);
                        varReportName = "PUR_PO_Detail";
                    }
                    //objBillreport.SetParameterValue("paraGRNstatusvalue", cmbGrnstatus.Text); 
                      

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
        private void REPORT_CP_Product_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80203;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());

                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                cmbStatus.SelectedValue = 0;
                //btnListPrint.Enabled = true; 
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STSID  IN (11,13,12,27,14) AND STS_ModuleID=4 OR STSID=0  ", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID"); 
                objDataBind.BindComboBoxListSelected("DEF_Status", " STS_ModuleID=7 OR STSID=0  ", "STS_Name,STSID", cmbGrnstatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (13,0) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrdertype, "", "MST_DisplayText", "MSTID");
                //Transaction id 	13
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MSTID IN (" + ReportTypeIDs + ")", "MST_DisplayText,MSTID,MST_ShortName", cmbReporttype, "", "MST_DisplayText", "MSTID");
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

        private void REPORT_CP_Product_KeyDown(object sender, KeyEventArgs e)
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
                    txtCity.Focus();
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
                        txtCity.Focus();
                    }
                }
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
                    //LV_Supplier.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtSupplier.Text.Length > 0)
                    {

                        MR_Supplier objMR_Supplier = new MR_Supplier();
                        objMR_Supplier.ViewType = 15;
                        objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                        objMR_Supplier.paraFlag = 1;
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
                                    DGV_FilterSupplier.Columns["SP_Name1"].Visible = false;
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


        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                //TxtSupplier_Leave(sender, e);
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
                    lblschedleCode.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SPSCID"].Value.ToString();
                    txtSupplier.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SP_NAME"].Value.ToString();
                }
                txtCity.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                LV_Supplier.Visible = false;
            }
        }
        private void LV_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                    //TxtSupplier_Leave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void TxtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyCity == 0)
                {
                    //lvCity.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtCity.Text.Length != 0)
                    {
                        objDs = objspdservice.udfnCitylist(4, txtCity.Text, 0, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterCity.Visible = true;
                                    DGV_FilterCity.DataSource = objDs.Tables[0];
                                    DGV_FilterCity.Columns["CTYID"].Visible = false;
                                    DGV_FilterCity.Columns["STID"].Visible = false;
                                    DGV_FilterCity.Columns["ST_Name"].Visible = false;
                                    DGV_FilterCity.Columns["ST_TIN"].Visible = false;
                                    DGV_FilterCity.Columns["CTY_NAME"].HeaderText = "City";
                                    DGV_FilterCity.Columns["CTY_NAME"].Width = 180;
                                    DGV_FilterCity.Columns["CTY_NAME"].DisplayIndex = 0;
                                    DGV_FilterCity.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterCity.Visible = false;
                                    DGV_FilterCity.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterCity.Visible = false;
                                DGV_FilterCity.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterCity.Visible = false;
                            DGV_FilterCity.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterCity.Visible = false;
                        DGV_FilterCity.DataSource = null;
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

        private void TxtCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyCity = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterCity.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterCity.Visible == false)
                {
                    txtDelaydays.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterCity.Focus();
                }
                if (DGV_FilterCity.CurrentCell == null && DGV_FilterCity.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterCity.Focus();
                    int RowIndex = DGV_FilterCity.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterCity.CurrentCell.ColumnIndex;
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
                            if (RowIndex >= 0) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtCity.Text = DGV_FilterCity.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }
                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterCity.Rows.Count) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterCity.Rows.Count))
                            {
                                txtCity.Text = DGV_FilterCity.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterCity.Rows.Count > 0)
                                {
                                    varUpDownKeyCity = 1;
                                    udfnGrdevent();
                                    DGV_FilterCity.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtCity.Focus();
                    //txtCity.SelectionStart = txtCity.Text.Length;
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
                        txtDelaydays.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCity_Leave(object sender, EventArgs e)
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

        private void TxtCity_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtCity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void LvCity_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGrdevent();
                txtDelaydays.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGrdevent();
                    txtDelaydays.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGrdevent()
        {
            try
            {
                if (txtCity.Text.Trim() != "")
                {
                    txtCity.Text = DGV_FilterCity.SelectedRows[0].Cells["CTY_NAME"].Value.ToString();
                    lblcityid.Text = DGV_FilterCity.SelectedRows[0].Cells["CTYID"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvCity.Visible = false;
            }
        }

        private void CmbGrnstatus_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbGrnstatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbGrnstatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void CmbGrnstatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbGrnstatus_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbGrnstatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDelaydays_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtDelaydays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDelaydays_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrdertype.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtDelaydays_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDelaydays.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrdertype_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbOrdertype.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrdertype_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbReporttype.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrdertype_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbOrdertype_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrdertype.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbReporttype_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbReporttype.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void CmbReporttype_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbReporttype_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReporttype_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReporttype.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtDelaydays_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySupplier = 1;
                udfnListViewData();
                txtCity.Focus();
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
                        txtCity.Focus();
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
                varUpDownKeyCity = 1;
                udfnGrdevent();
                txtDelaydays.Focus();
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
                    int RowIndex = DGV_FilterCity.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterCity.CurrentCell.ColumnIndex;
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
                            if (RowIndex >= 0) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];

                            txtCity.Text = DGV_FilterCity.SelectedRows[0].Cells["CTY_NAME"].Value.ToString();

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterCity.Rows.Count) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterCity.Rows.Count))
                            {
                                txtCity.Text = DGV_FilterCity.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterCity.Rows.Count > 0)
                                {
                                    varUpDownKeyCity = 1;
                                    udfnGrdevent();
                                    DGV_FilterCity.Visible = false;
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
                        txtDelaydays.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReporttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReporttype.SelectedItem is DataRowView drv)
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

        private void REPORT_PUR_Purchaseorder_Summary_Leave(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                SPDataService objspdservice = new SPDataService();
                result = objspdservice.udfnPurchaseEntry(4, 0, 0, "", 0, 0, "", "", "", "", null, "", "", "", "", 0, "", 0, 0, Convert.ToInt32(varRefNo));
                objspdservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
