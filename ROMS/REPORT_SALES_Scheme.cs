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
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument(); public int varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyProduct = 0, varUpDownKeyBrand = 0, varUpDownKeyLocation=0;
        public string pbRateCategoryIDs = "";
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
                udfnPrint(0);
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
                 
                epReport.Clear(); int varViewType = 0;
                string varGroupName = "-All-", varSubgroupName = "-All-", varBrandName = "-All-";
                int varGroupId = 0, varSubgroupId = 0, varBrandId = 0;
                 
                 
                btnView.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                 Application.DoEvents();
                int varPrint = 0; 
                TRN_Scheme objTRN_Scheme = new TRN_Scheme();
                objTRN_Scheme.ViewType = varViewType; 
                objTRN_Scheme.paraGroupID = varGroupId;
                objTRN_Scheme.paraSubGroupID = varSubgroupId;
                objTRN_Scheme.paraBrandID = varBrandId;   
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
                    objBillreport.SetParameterValue("paraGroupID", varGroupId);   
                    objBillreport.SetParameterValue("paraSubGroupID", varSubgroupId);   
                    objBillreport.SetParameterValue("paraBrandID", varBrandId);    
                    objBillreport.SetParameterValue("paraGroupName", varGroupName);   
                    objBillreport.SetParameterValue("paraSubGroupName", varSubgroupName);   
                    objBillreport.SetParameterValue("paraBrandName", varBrandName);   
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


                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,190) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSchemeType, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,214) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbRecursive, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,547) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbRateCategory, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,159) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbValidityType, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,215) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbDaysType, "", "MST_DisplayText", "MSTID");  
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,160) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSchemeAvailTime, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,160) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbStatus, "", "MST_DisplayText", "MSTID"); 
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (0,31)   ORDER BY STSID", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID"); 

                objDataBind = null;
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 32;
                DataSet objDTable = new DataSet();
                SPDataService objdSer = new SPDataService();
                objDTable = objdSer.udfnMaster(objMR_Master);
                objdSer.CloseConnection();
                if (objDTable != null)
                {
                    if (objDTable.Tables.Count > 0)
                    {
                        if (objDTable.Tables[0].Rows.Count > 0)
                        {
                            chkboxRatelist.DrawMode = DrawMode.Normal;
                            chkboxRatelist.FormattingEnabled = true;
                            chkboxRatelist.DisplayMember = "MST_DisplayText";
                            chkboxRatelist.ValueMember = "MSTID";
                            chkboxRatelist.DataSource = objDTable.Tables[0];
                            DataView dv = objDTable.Tables[0].DefaultView;
                            dv.RowFilter = "MSTID <> 0";
                            DataTable dt = dv.ToTable();
                            dt = objDTable.Tables[0];
                            chkboxRatelist.DataSource = dt;
                            chkboxRatelist.DisplayMember = "MST_DisplayText";   // text
                            chkboxRatelist.ValueMember = "MSTID";       // value 
                        }
                    }
                }
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
                    cmbRecursive.Focus();
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
                cmbSchemeType.BackColor = Color.LemonChiffon;
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
                    txtRateCategory.Focus();
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

        private void txtRateCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                pnlRateCategory.Visible = true;
                pnlRateCategory.BringToFront();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRateCategory_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbValidityType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRateCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                //pnlRateCategory.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSelectAll()
        {
            try
            {
                txtRateCategory.Text = "";
                pbRateCategoryIDs = "";
                List<string> texts = new List<string>();
                List<string> ids = new List<string>();

                for (int i = 0; i < chkboxRatelist.Items.Count; i++)
                {
                    DataRowView row = (DataRowView)chkboxRatelist.Items[i];
                    int id = Convert.ToInt32(row["MSTID"]);
                    if (Convert.ToInt32(row["MSTID"]) == 0)
                        continue;

                    chkboxRatelist.SetItemChecked(i, true);

                    texts.Add(row["MST_DisplayText"].ToString());
                    ids.Add(id.ToString());
                }
                // TextBox (RR, WR)
                txtRateCategory.Text = texts.Count > 0
                    ? string.Join(", ", texts)
                    : "";

                // Label (447,448)
                pbRateCategoryIDs = ids.Count > 0
                    ? string.Join(",", ids)
                    : "0";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            udfnSelectAll();
        }

        private void btnConditionClear_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < chkboxRatelist.Items.Count; i++)
                {
                    chkboxRatelist.SetItemChecked(i, false);
                }

                txtRateCategory.Text = "";
                pbRateCategoryIDs = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkboxRatelist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                BeginInvoke((MethodInvoker)UpdateSelectedValues);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void UpdateSelectedValues()
        {
            try
            {
                List<string> texts = new List<string>();
                List<string> ids = new List<string>();

                foreach (DataRowView row in chkboxRatelist.CheckedItems)
                {
                    int id = Convert.ToInt32(row["MSTID"]);

                    // ignore -All- in textbox
                    if (id == 0) continue;

                    texts.Add(row["MST_DisplayText"].ToString());
                    ids.Add(id.ToString());
                }

                // TextBox (RR, WR)
                txtRateCategory.Text = texts.Count > 0
                    ? string.Join(", ", texts)
                    : "";

                // Label (447,448)
                pbRateCategoryIDs = ids.Count > 0
                    ? string.Join(",", ids)
                    : "0";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void chkboxRatelist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbValidityType.Focus();
                }
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
                    cmbSchemeAvailTime.Focus();
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
                    cmbStatus.Focus();
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
                cmbStatus.BackColor = Color.LemonChiffon;
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
                cmbStatus.BackColor = Color.White;
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
                     cmbSchemeType.Focus();
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
