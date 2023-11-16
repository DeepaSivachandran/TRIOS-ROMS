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
    public partial class REPORT_CP_Product : Form
    {
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public REPORT_CP_Product()
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
                lvGroup.Visible = false;
                lvSubGroup.Visible = false;
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
        private void BtnListPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbReportType.SelectedIndex == 0)
                {
                    cmbReportType.Focus();
                }
                else
                {
                    lvGroup.Visible = false;
                    lvSubGroup.Visible = false;

                    if (cmbReportType.SelectedIndex == 1)
                    {
                        udfnProductGST();
                    }
                    if (cmbReportType.SelectedIndex == 2)
                    {
                        udfnProductRate();
                    }
                    if (cmbReportType.SelectedIndex == 3)
                    {
                        udfnProductDefaultStock();
                    }
                    if (cmbReportType.SelectedIndex == 4)
                    {
                        udfnProductShelfLife();
                    }
                    if (cmbReportType.SelectedIndex == 5)
                    {
                        udfnProductNettGross();
                    }
                    if (cmbReportType.SelectedIndex == 6)
                    {
                        udfnProductSubgroupGroupBrand();
                    }
                    if (cmbReportType.SelectedIndex == 7)
                    {
                        udfnProductMinSales();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        public void udfnProductGST()
        {
            try
            {
                /* Check product group is valid or not*/
                string varId_Group = "0";
                string varGroupName = "";
                if (txtGroup.Text == "")
                {
                    varId_Group = "0";
                    varGroupName = "-All-";
                }
                else
                {
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_Group == "-1" || varId_Group == "0")
                {
                    varGroupName = "-All-";
                }
                else { varGroupName = txtGroup.Text.Trim(); }
                lblGroupCode.Text = Convert.ToString(varId_Group);

                /* Check product sub group is valid or not*/
                string varId_SubGroup = "0";
                string varSubgroupName = "";
                if (txtSubGroup.Text == "")
                {
                    varId_SubGroup = "0";
                    varSubgroupName = "-All-";
                }
                else
                {
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_SubGroup == "-1" || varId_SubGroup == "0")
                {
                    varSubgroupName = "-All-";
                }
                else { varSubgroupName = txtSubGroup.Text.Trim(); }
                lblSubGroupCode.Text = Convert.ToString(varId_SubGroup);

                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(25, 0, 0, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,"",0,"",null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Product_GST.rpt");
                    objBillreport.SetParameterValue("paraGroupId", Convert.ToInt32(lblGroupCode.Text));
                    objBillreport.SetParameterValue("paraGroupName", Convert.ToString(varGroupName));
                    objBillreport.SetParameterValue("paraSubgroupId", Convert.ToInt32(lblSubGroupCode.Text));
                    objBillreport.SetParameterValue("paraSubgroupName", Convert.ToString(varSubgroupName));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
        public void udfnProductRate()
        {
            try
            {
                btnListPrint.Enabled = false;
                /* Check product group is valid or not*/
                string varId_Group = "0";
                string varGroupName = "";
                if (txtGroup.Text == "")
                {
                    varId_Group = "0";
                    varGroupName = "-All-";
                }
                else
                {
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_Group == "-1" || varId_Group == "0")
                {
                    varGroupName = "-All-";
                }
                else { varGroupName = txtGroup.Text.Trim(); }
                lblGroupCode.Text = Convert.ToString(varId_Group);

                /* Check product sub group is valid or not*/
                string varId_SubGroup = "0";
                string varSubgroupName = "";
                if (txtSubGroup.Text == "")
                {
                    varId_SubGroup = "0";
                    varSubgroupName = "-All-";
                }
                else
                {
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_SubGroup == "-1" || varId_SubGroup == "0")
                {
                    varSubgroupName = "-All-";
                }
                else { varSubgroupName = txtSubGroup.Text.Trim(); }
                lblSubGroupCode.Text = Convert.ToString(varId_SubGroup);


                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(26, 0, 0, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Product_Rate.rpt");
                    objBillreport.SetParameterValue("paraGroupId", Convert.ToInt32(lblGroupCode.Text));
                    objBillreport.SetParameterValue("paraGroupName", Convert.ToString(varGroupName));
                    objBillreport.SetParameterValue("paraSubgroupId", Convert.ToInt32(lblSubGroupCode.Text));
                    objBillreport.SetParameterValue("paraSubgroupName", Convert.ToString(varSubgroupName));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
        public void udfnProductDefaultStock() 
        {
            try
            {
                /* Check product group is valid or not*/
                string varId_Group = "0";
                string varGroupName = "";
                if (txtGroup.Text == "")
                {
                    varId_Group = "0";
                    varGroupName = "-All-";
                }
                else
                {
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_Group == "-1" || varId_Group == "0")
                {
                    varGroupName = "-All-";
                }
                else { varGroupName = txtGroup.Text.Trim(); }
                lblGroupCode.Text = Convert.ToString(varId_Group);

                /* Check product sub group is valid or not*/
                string varId_SubGroup = "0";
                string varSubgroupName = "";
                if (txtSubGroup.Text == "")
                {
                    varId_SubGroup = "0";
                    varSubgroupName = "-All-";
                }
                else
                {
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_SubGroup == "-1" || varId_SubGroup == "0")
                {
                    varSubgroupName = "-All-";
                }
                else { varSubgroupName = txtSubGroup.Text.Trim(); }
                lblSubGroupCode.Text = Convert.ToString(varId_SubGroup);

                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(27, 0, 0, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Product_Default_Stock.rpt");
                    objBillreport.SetParameterValue("paraGroupId", Convert.ToInt32(lblGroupCode.Text));
                    objBillreport.SetParameterValue("paraGroupName", Convert.ToString(varGroupName));
                    objBillreport.SetParameterValue("paraSubgroupId", Convert.ToInt32(lblSubGroupCode.Text));
                    objBillreport.SetParameterValue("paraSubgroupName", Convert.ToString(varSubgroupName));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
        public void udfnProductShelfLife()
        {
            try
            {
                btnListPrint.Enabled = false;
                /* Check product sub group is valid or not*/
                string varId_SubGroup = "0";
                string varSubgroupName = "";
                if (txtSubGroup.Text == "")
                {
                    varId_SubGroup = "0";
                    varSubgroupName = "-All-";
                }
                else
                {
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_SubGroup == "-1" || varId_SubGroup == "0")
                {
                    varSubgroupName = "-All-";
                }
                else { varSubgroupName = txtSubGroup.Text.Trim(); }
                lblSubGroupCode.Text = Convert.ToString(varId_SubGroup);

                /* Check product group is valid or not*/
                string varId_Group = "0";
                string varGroupName = "";
                if (txtGroup.Text == "")
                {
                    varId_Group = "0";
                    varGroupName = "-All-";
                }
                else
                {
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_Group == "-1" || varId_Group == "0")
                {
                    varGroupName = "-All-";
                }
                else { varGroupName = txtGroup.Text.Trim(); }
                lblGroupCode.Text = Convert.ToString(varId_Group);

                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(28, 0, 0, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Product_Stock_Shelflife.rpt");
                    objBillreport.SetParameterValue("paraGroupId", Convert.ToInt32(lblGroupCode.Text));
                    objBillreport.SetParameterValue("paraGroupName", Convert.ToString(varGroupName));
                    objBillreport.SetParameterValue("paraSubgroupId", Convert.ToInt32(lblSubGroupCode.Text));
                    objBillreport.SetParameterValue("paraSubgroupName", Convert.ToString(varSubgroupName));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
        public void udfnProductNettGross()
        {
            try
            {
                btnListPrint.Enabled = false;
                /* Check product sub group is valid or not*/
                string varId_SubGroup = "0";
                string varSubgroupName = "";
                if (txtSubGroup.Text == "")
                {
                    varId_SubGroup = "0";
                    varSubgroupName = "-All-";
                }
                else
                {
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_SubGroup == "-1" || varId_SubGroup == "0")
                {
                    varSubgroupName = "-All-";
                }
                else { varSubgroupName = txtSubGroup.Text.Trim(); }
                lblSubGroupCode.Text = Convert.ToString(varId_SubGroup);

                /* Check product group is valid or not*/
                string varId_Group = "0";
                string varGroupName = "";
                if (txtGroup.Text == "")
                {
                    varId_Group = "0";
                    varGroupName = "-All-";
                }
                else
                {
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_Group == "-1" || varId_Group == "0")
                {
                    varGroupName = "-All-";
                }
                else { varGroupName = txtGroup.Text.Trim(); }
                lblGroupCode.Text = Convert.ToString(varId_Group);

                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(30, 0, 0, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Product_Stock_Nett_Gross.rpt");
                    objBillreport.SetParameterValue("paraGroupId", Convert.ToInt32(lblGroupCode.Text));
                    objBillreport.SetParameterValue("paraGroupName", Convert.ToString(varGroupName));
                    objBillreport.SetParameterValue("paraSubgroupId", Convert.ToInt32(lblSubGroupCode.Text));
                    objBillreport.SetParameterValue("paraSubgroupName", Convert.ToString(varSubgroupName));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
        public void udfnProductSubgroupGroupBrand()
        {
            try
            {
                btnListPrint.Enabled = false;
                /* Check product sub group is valid or not*/
                string varId_SubGroup = "0";
                string varSubgroupName = "";
                if (txtSubGroup.Text == "")
                {
                    varId_SubGroup = "0";
                    varSubgroupName = "-All-";
                }
                else
                {
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_SubGroup == "-1" || varId_SubGroup == "0")
                {
                    varSubgroupName = "-All-";
                }
                else { varSubgroupName = txtSubGroup.Text.Trim(); }
                lblSubGroupCode.Text = Convert.ToString(varId_SubGroup);

                /* Check product group is valid or not*/
                string varId_Group = "0";
                string varGroupName = "";
                if (txtGroup.Text == "")
                {
                    varId_Group = "0";
                    varGroupName = "-All-";
                }
                else
                {
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_Group == "-1" || varId_Group == "0")
                {
                    varGroupName = "-All-";
                }
                else { varGroupName = txtGroup.Text.Trim(); }
                lblGroupCode.Text = Convert.ToString(varId_Group);

                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(31, 0, 0, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Product_Subgroup_Group_Brand.rpt");
                    objBillreport.SetParameterValue("paraGroupId", Convert.ToInt32(lblGroupCode.Text));
                    objBillreport.SetParameterValue("paraGroupName", Convert.ToString(varGroupName));
                    objBillreport.SetParameterValue("paraSubgroupId", Convert.ToInt32(lblSubGroupCode.Text));
                    objBillreport.SetParameterValue("paraSubgroupName", Convert.ToString(varSubgroupName));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
        public void udfnProductMinSales()
        {
            try
            {
                btnListPrint.Enabled = false;
                /* Check product sub group is valid or not*/
                string varId_SubGroup = "0";
                string varSubgroupName = "";
                if (txtSubGroup.Text == "")
                {
                    varId_SubGroup = "0";
                    varSubgroupName = "-All-";
                }
                else
                {
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_SubGroup == "-1" || varId_SubGroup == "0")
                {
                    varSubgroupName = "-All-";
                }
                else { varSubgroupName = txtSubGroup.Text.Trim(); }
                lblSubGroupCode.Text = Convert.ToString(varId_SubGroup);

                /* Check product group is valid or not*/
                string varId_Group = "0";
                string varGroupName = "";
                if (txtGroup.Text == "")
                {
                    varId_Group = "0";
                    varGroupName = "-All-";
                }
                else
                {
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_Group == "-1" || varId_Group == "0")
                {
                    varGroupName = "-All-";
                }
                else { varGroupName = txtGroup.Text.Trim(); }
                lblGroupCode.Text = Convert.ToString(varId_Group);

                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(32, 0, 0, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Product_Min_Sales_Qty.rpt");
                    objBillreport.SetParameterValue("paraGroupId", Convert.ToInt32(lblGroupCode.Text));
                    objBillreport.SetParameterValue("paraGroupName", Convert.ToString(varGroupName));
                    objBillreport.SetParameterValue("paraSubgroupId", Convert.ToInt32(lblSubGroupCode.Text));
                    objBillreport.SetParameterValue("paraSubgroupName", Convert.ToString(varSubgroupName));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbReportType.Select(int.MaxValue, 0))); 
                if (cmbReportType.SelectedIndex == 1)
                {
                    udfnClear();
                }
                if (cmbReportType.SelectedIndex == 2)
                {
                    udfnClear();
                }
                if (cmbReportType.SelectedIndex == 3)
                {
                    udfnClear();
                }
                if (cmbReportType.SelectedIndex == 4)
                {
                    udfnClear();
                }
                if (cmbReportType.SelectedIndex == 5)
                {
                    udfnClear();
                }
                if (cmbReportType.SelectedIndex == 6)
                {
                    udfnClear();
                }
                if (cmbReportType.SelectedIndex == 7)
                {
                    udfnClear(); 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        public void udfnClear()
        {
            txtGroup.Text = "";
            txtSubGroup.Text = "";
            cmbStatus.SelectedValue = 0;
        } 
        private void CmbReportType_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            { 
                lvGroup.Visible = false; 
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSubGroup.Items.Count == 0 || txtSubGroup.Text == "")
                    {
                        txtSubGroup.Focus();
                        lvSubGroup.Visible = false;
                    }
                    else
                    {
                        lvSubGroup.Focus();
                    }
                    if (lvSubGroup.Items.Count > 0)
                    {
                        lvSubGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
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
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupCode.Text), 0, txtSubGroup.Text, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvSubGroup.Columns[0].Width = 200;
                                    lvSubGroup.Columns[1].Width = 200;
                                    lvSubGroup.Columns[2].Width = 0;
                                    lvSubGroup.Items.Add(objList);
                                }
                                lvSubGroup.Visible = true;
                                lvSubGroup.BringToFront();
                            }
                            else
                            {
                                lvSubGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvSubGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvSubGroup.Visible = false;
                    }
                }
                else
                {
                    lvSubGroup.Visible = false;
                    lvSubGroup.Items.Clear();
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
            udfnSubGroupAutocomplete();
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
        public void udfnSubGroupAutocomplete()
        {
            try
            {
                if (txtSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    txtSubGroup.Text = selectedItem.SubItems[0].Text;
                    lblSubGroupCode.Text = selectedItem.SubItems[2].Text;
                    lvSubGroup.Visible = false;
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
                cmbStatus.Focus();
            }
        }

        private void TxtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.LemonChiffon;
                //lvBrand.Visible = false;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvGroup.Items.Count == 0 || txtGroup.Text == "")
                    {
                        txtGroup.Focus();
                        lvGroup.Visible = false;
                    }
                    else
                    {
                        lvGroup.Focus();
                    }
                    if (lvGroup.Items.Count > 0)
                    {
                        lvGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSubGroup.Enabled == true)
                    {
                        txtSubGroup.Focus();
                    }
                    else
                    {
                        cmbStatus.Focus();
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
                lvGroup.Items.Clear();
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
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvGroup.Columns[2].Width = 0;
                                    lvGroup.Columns[1].Width = 200;
                                    lvGroup.Columns[0].Width = 200;
                                    lvGroup.Items.Add(objList);
                                }
                                lvGroup.Visible = true;
                                lvGroup.BringToFront();
                            }
                            else
                            {
                                lvGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvGroup.Visible = false;
                    }
                }
                else
                {
                    lvGroup.Visible = false;
                    lvGroup.Items.Clear();
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
            udfnGroupAutocomplete();
        }
        public void udfnGroupAutocomplete()
        {
            try
            {
                if (txtGroup.Text != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    txtGroup.Text = selectedItem.SubItems[0].Text;
                    lblGroupCode.Text = selectedItem.SubItems[2].Text;
                    lvGroup.Visible = false;
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
                if (txtSubGroup.Enabled == true)
                {
                    txtSubGroup.Focus();
                }
                else
                {
                    cmbStatus.Focus();
                }
            }
        }
        private void REPORT_CP_Product_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,43) AND MSTID<>0", "MST_DisplayText,MSTID", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                cmbReportType.SelectedValue = -1;
                cmbStatus.SelectedValue = 0;
                //btnListPrint.Enabled = true;
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

        private void REPORT_CP_Product_KeyDown(object sender, KeyEventArgs e)
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
    }
}
