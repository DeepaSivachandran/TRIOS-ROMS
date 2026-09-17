using ROMS.Model;
using ROMS.Service_Class;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms; 

namespace ROMS
{
    public partial class REPORT_SAL_Scheme : Form
    {
        MainForm objMainForm = new MainForm();
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument(); public int varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyProduct = 0, varUpDownKeyBrand = 0, varUpDownKeyLocation=0; 
        public REPORT_SAL_Scheme()
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
                MainForm objMainForm = new MainForm(); 
                //dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80124; 
                //string ReportTypeIDs = string.Join(",",
                // MainForm.objDtMenuDetailsUser?.AsEnumerable()
                //  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                //  .Select(r => r.Field<int?>("MU_EQID"))
                //  .Where(q => q.HasValue)
                //  .Select(q => q.Value.ToString())
                //  ?? Enumerable.Empty<string>());
                //dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
                DataBind objDataBind = new DataBind(); 
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,191) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSchemeType, "", "MST_DisplayText", "MSTID");   
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,109) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrderType, "", "MST_DisplayText", "MSTID");  
                 //Transaction id=190
                //objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MSTID IN (" + ReportTypeIDs + ")  ORDER BY MST_OrderID ASC", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");

                //objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,190) AND MSTID<>0    ORDER BY MST_OrderID ASC", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");

                objDataBind = null; 
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
                cmbconcern.BackColor = Color.LemonChiffon;
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
                    //if (cmbSchemeType.Enabled == true)
                    //{
                    //    cmbSchemeType.Focus();
                    //}
                    //else { txtGroup.Focus(); }
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
                cmbconcern.BackColor = Color.White;
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
