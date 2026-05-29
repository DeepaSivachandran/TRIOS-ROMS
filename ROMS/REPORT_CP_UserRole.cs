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
    public partial class REPORT_CP_UserRole : Form
    {
        MainForm objMainForm = new MainForm();
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        private ToolTip tpCity = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public REPORT_CP_UserRole()
        {
            InitializeComponent();
            windowControl.Initialize(tsUserRole, this);
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

        public void udfnList(int varFlag)
        {
            try
            {
                if (Convert.ToInt32(cmbReportType.SelectedValue) == -1)
                {
                    cmbReportType.Focus();
                }
                else
                { 
                    udfnUserRole(varFlag); 
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
        public void udfnUserRole(int varFlag)
        {
            try
            {
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();

                int reportType = 1;  ////user role report 

                ////user name report 
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 414)
                {
                    reportType = 2;
                }
                int varUserRoleId = 0, varUserId = 0, varViewType = 5;
                string varUserRoleName="-All-",varFilterUserName="-All-";
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 576)
                {
                    varViewType = 0;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 577)
                {
                    varViewType = 7;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 578)
                {
                    varViewType = 8;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 579)
                {
                    varViewType = 12;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 580)
                {
                    varViewType = 9;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 581)
                {
                    varViewType = 10;
                }
                else if (Convert.ToInt32(cmbReportType.SelectedValue) == 582)
                {
                    varViewType = 11;
                }
                if (txtUserRole.Text.Trim() != "") {
                    varUserRoleId=Convert.ToInt32(lblUserRoleId.Text);
                    varUserRoleName = txtUserRole.Text.Trim();
                }
                if (txtDUserList.Text.Trim() != "")
                {
                    varUserId=Convert.ToInt32(lblUserId.Text);
                    varFilterUserName = txtDUserList.Text.Trim();
                }
                objDs = objspservice.udfnUserRoleList(varViewType, varUserRoleId, 0, 0, "", reportType, varUserId);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                string varReportName = "";
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    
                    ///user role 
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 413)
                    { 
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_User_Role.rpt");
                        varReportName = "User_Role";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 414) ////user name report 
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_UserNamewise.rpt");
                        varReportName = "UserDetails";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 576)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_User_Role_Summary.rpt");
                        varReportName = "UserRoleSummary";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 577)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_User_Role_Details.rpt");
                        varReportName = "UserRoleDetails";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 578)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_User_Role_Users.rpt");
                        varReportName = "UserRoleUsers";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 579)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_UserWise_User_Role.rpt");
                        varReportName = "UserWiseUserRole";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 580)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_User_RoleWise_Menu.rpt");
                        varReportName = "UserRoleWiseMenu";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 581)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_User_RoleWise_SubMenu.rpt");
                        varReportName = "UserRoleWiseSubMenu";
                    }
                    else if (Convert.ToInt32(cmbReportType.SelectedValue) == 582)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_User_RoleWise_UserPermission.rpt");
                        varReportName = "UserRoleWiseUserPermission";
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) != 413 && Convert.ToInt32(cmbReportType.SelectedValue) != 414)
                    {
                        objBillreport.SetParameterValue("paraUId", varUserId);
                        objBillreport.SetParameterValue("paraUserRoleName", varUserRoleName);
                        objBillreport.SetParameterValue("paraFilterUserName", varFilterUserName);
                    }
                    objBillreport.SetParameterValue("paraUserRoleId", varUserRoleId);
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
        public void udfnRackgroup()
        {
            try
            {
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnRackGroupList(2,0,0,0,0,"",0,0);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rack_Rackgroup.rpt");
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
        private void CmbReportType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUserRole.Focus();
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
                cmbReportType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void REPORT_CP_Rack_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80122;
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
                cmbReportType.SelectedValue = -1; 
                //btnListPrint.Enabled = true;
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

        private void REPORT_CP_Rack_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
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

                txtDUserList.Enabled = true;
                txtDUserList.BackColor = Color.White;
                ////user role report
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 413)
                {
                    txtDUserList.Enabled = false;
                    txtDUserList.BackColor = SystemColors.Control;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtUserRole_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUserRole.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtUserRole_Leave(object sender, EventArgs e)
        {
            try
            {
                txtUserRole.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtUserRole_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvUserRole.Items.Count == 0 || txtUserRole.Text == "")
                    {
                        txtUserRole.Focus();
                        lvUserRole.Visible = false;
                    }
                    else
                    {
                        lvUserRole.Focus();
                    }
                    if (lvUserRole.Items.Count > 0)
                    {
                        lvUserRole.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtDUserList.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtUserRole_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvUserRole.Items.Clear();
                lvUserRole.BringToFront();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtUserRole.Text.Length > 0)
                {
                    objDs = objspdservice.udfnUserRoleList(4, 0, 1, 0, txtUserRole.Text,0,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["UR_Name"].ToString(), objDs.Tables[0].Rows[i]["URID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvUserRole.Items.Add(objList);
                                }
                                lvUserRole.Visible = true;
                            }
                            else
                            {
                                lvUserRole.Visible = false;
                            }
                        }
                        else
                        {
                            lvUserRole.Visible = false;
                        }
                    }
                    else
                    {
                        lvUserRole.Visible = false;
                    }
                }
                else
                {
                    lvUserRole.Visible = false;
                    lvUserRole.Items.Clear();
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

        private void lvUserRole_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGrdeventUserRole();
                    txtDUserList.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvUserRole_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGrdeventUserRole();
                txtDUserList.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnGrdeventUserRole()
        {
            try
            {
                if (txtUserRole.Text != "")
                {
                    ListViewItem selectedItem = lvUserRole.SelectedItems[0];
                    lblUserRoleId.Text = selectedItem.SubItems[1].Text;
                    txtUserRole.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvUserRole.Visible = false;
            }
        }


        private void txtDUserList_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvUserList.BringToFront();
                lvUserList.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtDUserList.Text.Length > 0)
                {
                    objDs = objspdservice.udfnUserList(5, txtDUserList.Text, "", "", 0, 0, "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["U_Name"].ToString(), objDs.Tables[0].Rows[i]["UID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvUserList.Items.Add(objList);
                                }
                                lvUserList.Visible = true;
                            }
                            else
                            {
                                lvUserList.Visible = false;
                            }
                        }
                        else
                        {
                            lvUserList.Visible = false;
                        }
                    }
                    else
                    {
                        lvUserList.Visible = false;
                    }
                }
                else
                {
                    lvUserList.Visible = false;
                    lvUserList.Items.Clear();
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
        private void txtDUserList_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDUserList.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtDUserList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvUserList.Items.Count == 0 || txtDUserList.Text == "")
                    {
                        txtDUserList.Focus();
                        lvUserList.Visible = false;
                    }
                    else
                    {
                        lvUserList.Focus();
                    }
                    if (lvUserList.Items.Count > 0)
                    {
                        lvUserList.Items[0].Selected = true;
                    }
                }
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


        private void txtDUserList_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDUserList.BackColor = Color.White;
                if (txtDUserList.Text.Trim() == "") { lblUserId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void lvUserList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGrdevent();
                btnListPrint.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void lvUserList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGrdevent();
                    btnListPrint.Focus();
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
                if (txtDUserList.Text != "")
                {
                    ListViewItem selectedItem = lvUserList.SelectedItems[0];
                    lblUserId.Text = selectedItem.SubItems[1].Text;
                    txtDUserList.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvUserList.Visible = false;
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
    }
}
