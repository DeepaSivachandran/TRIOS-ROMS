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
    public partial class REPORT_CP_Rackgroup : Form
    {
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public REPORT_CP_Rackgroup()
        {
            InitializeComponent();
        }
        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                lvRack.Visible = false;
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
                    if (cmbReportType.SelectedIndex == 1)
                    {
                        udfnRG();
                    }
                    if (cmbReportType.SelectedIndex == 2)
                    {
                        udfnRGProduct();
                    }
                    if (cmbReportType.SelectedIndex == 3)
                    {
                        udfnRGProBarcode();
                    }
                    if (cmbReportType.SelectedIndex == 4)
                    {
                        udfnRGProMsq();
                    }
                    if (cmbReportType.SelectedIndex == 5)
                    {
                        udfnRGProWeight();
                    }
                    if (cmbReportType.SelectedIndex == 6)
                    {
                        udfnRGProRackMinQty();
                    }
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
                BeginInvoke(new Action(() => cmbReportType.Select(int.MaxValue, 0)));
                if(cmbReportType.SelectedIndex==1)
                {
                    txtRackgroup.Enabled = false;
                    txtEmployeeName.Enabled = false;
                    txtRack.Enabled = false;
                    udfnClear();
                }
                else
                {
                    txtRackgroup.Enabled = true;
                    txtEmployeeName.Enabled = true;
                    txtRack.Enabled = true;
                }
                if(cmbReportType.SelectedIndex==2)
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        {
            txtRackgroup.Text = "";
            txtEmployeeName.Text = "";
            txtRack.Text = "";
        }
        public void udfnRG()
        {
            try
            {
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnRackGroupList(3,0,0,0,0,"");
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup.rpt");
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(0));
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
        public void udfnRGProduct()
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0,RKCode=0,EMPCode=0;
                string RKGName = "", RKName = "", RKInchargeName = "";
                if(txtRackgroup.Text=="")
                {
                    RKGCode = 0;
                    RKGName = "-All-";
                }
                else
                {
                    RKGCode = Convert.ToInt32(lblRackgroupCode.Text);
                    RKGName = Convert.ToString(txtRackgroup.Text);
                }
                if (txtEmployeeName.Text == "")
                {
                    EMPCode = 0;
                    RKInchargeName = "-All-";
                }
                else
                {
                    EMPCode = Convert.ToInt32(lblEmpCode.Text);
                    RKInchargeName = Convert.ToString(txtEmployeeName.Text);
                }
                if (txtRack.Text == "")
                {
                    RKCode = 0;
                    RKName = "-All";
                }
                else
                {
                    RKCode = Convert.ToInt32(lblRackCode.Text);
                    RKName = Convert.ToString(txtRack.Text);
                }
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(20,0,0,0,0,"","","",0,0,0,0,0,RKCode,0,0,0,0,0,RKGCode,EMPCode,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product.rpt");
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
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
        public void udfnRGProBarcode()
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";
                if (txtRackgroup.Text == "")
                {
                    RKGCode = 0;
                    RKGName = "-All-";
                }
                else
                {
                    RKGCode = Convert.ToInt32(lblRackgroupCode.Text);
                    RKGName = Convert.ToString(txtRackgroup.Text);
                }
                if (txtEmployeeName.Text == "")
                {
                    EMPCode = 0;
                    RKInchargeName = "-All-";
                }
                else
                {
                    EMPCode = Convert.ToInt32(lblEmpCode.Text);
                    RKInchargeName = Convert.ToString(txtEmployeeName.Text);
                }
                if (txtRack.Text == "")
                {
                    RKCode = 0;
                    RKName = "-All";
                }
                else
                {
                    RKCode = Convert.ToInt32(lblRackCode.Text);
                    RKName = Convert.ToString(txtRack.Text);
                }
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(21, 0, 0, 0, 0, "", "", "", 0, 0, 0, 0, 0, RKCode, 0, 0, 0, 0, 0, RKGCode, EMPCode,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_Barcode.rpt");
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
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
        public void udfnRGProMsq()
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";
                if (txtRackgroup.Text == "")
                {
                    RKGCode = 0;
                    RKGName = "-All-";
                }
                else
                {
                    RKGCode = Convert.ToInt32(lblRackgroupCode.Text);
                    RKGName = Convert.ToString(txtRackgroup.Text);
                }
                if (txtEmployeeName.Text == "")
                {
                    EMPCode = 0;
                    RKInchargeName = "-All-";
                }
                else
                {
                    EMPCode = Convert.ToInt32(lblEmpCode.Text);
                    RKInchargeName = Convert.ToString(txtEmployeeName.Text);
                }
                if (txtRack.Text == "")
                {
                    RKCode = 0;
                    RKName = "-All";
                }
                else
                {
                    RKCode = Convert.ToInt32(lblRackCode.Text);
                    RKName = Convert.ToString(txtRack.Text);
                }
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(22, 0, 0, 0, 0, "", "", "", 0, 0, 0, 0, 0, RKCode, 0, 0, 0, 0, 0, RKGCode, EMPCode,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_Msq.rpt");
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
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
        public void udfnRGProWeight()
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";
                if (txtRackgroup.Text == "")
                {
                    RKGCode = 0;
                    RKGName = "-All-";
                }
                else
                {
                    RKGCode = Convert.ToInt32(lblRackgroupCode.Text);
                    RKGName = Convert.ToString(txtRackgroup.Text);
                }
                if (txtEmployeeName.Text == "")
                {
                    EMPCode = 0;
                    RKInchargeName = "-All-";
                }
                else
                {
                    EMPCode = Convert.ToInt32(lblEmpCode.Text);
                    RKInchargeName = Convert.ToString(txtEmployeeName.Text);
                }
                if (txtRack.Text == "")
                {
                    RKCode = 0;
                    RKName = "-All";
                }
                else
                {
                    RKCode = Convert.ToInt32(lblRackCode.Text);
                    RKName = Convert.ToString(txtRack.Text);
                }
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(23, 0, 0, 0, 0, "", "", "", 0, 0, 0, 0, 0, RKCode, 0, 0, 0, 0, 0, RKGCode, EMPCode,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_Weight.rpt");
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
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
        public void udfnRGProRackMinQty()
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";
                if (txtRackgroup.Text == "")
                {
                    RKGCode = 0;
                    RKGName = "-All-";
                }
                else
                {
                    RKGCode = Convert.ToInt32(lblRackgroupCode.Text);
                    RKGName = Convert.ToString(txtRackgroup.Text);
                }
                if (txtEmployeeName.Text == "")
                {
                    EMPCode = 0;
                    RKInchargeName = "-All-";
                }
                else
                {
                    EMPCode = Convert.ToInt32(lblEmpCode.Text);
                    RKInchargeName = Convert.ToString(txtEmployeeName.Text);
                }
                if (txtRack.Text == "")
                {
                    RKCode = 0;
                    RKName = "-All";
                }
                else
                {
                    RKCode = Convert.ToInt32(lblRackCode.Text);
                    RKName = Convert.ToString(txtRack.Text);
                }
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(24, 0, 0, 0, 0, "", "", "", 0, 0, 0, 0, 0, RKCode, 0, 0, 0, 0, 0, RKGCode, EMPCode,"",0,"", null);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_RackMin_Qty.rpt");
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
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
        public void udfnRackValid()
        {
            /* Check purchase rack is valid or not*/
            if (txtRack.Text != "")
            {
                string varId_PurRack = "0";
                DataSet objDsPurRack = new DataSet();
                SPDataService objDServ4 = new SPDataService();
                objDsPurRack = objDServ4.udfnRackList(9, 0, 0, 0, 0, txtRack.Text.Trim(),0,0);
                objDServ4.CloseConnection();
                if (objDsPurRack != null)
                {
                    if (objDsPurRack.Tables.Count > 0)
                    {
                        if (objDsPurRack.Tables[0].Rows.Count > 0)
                        {
                            varId_PurRack = Convert.ToString(objDsPurRack.Tables[0].Rows[0][0]);
                        }
                    }
                }
                lblRackCode.Text = Convert.ToString(varId_PurRack);
                if (varId_PurRack == "0" || varId_PurRack == "-1")
                {
                    //lblRackCode.Text = "0";
                }
            }
        }
        public void udfnRackGroupValid()
        {
            /* Check purchase rack is valid or not*/
            if (txtRackgroup.Text != "")
            {
                string varId_RackGroup = "0";
                DataSet objDsRackGroup = new DataSet();
                SPDataService objDServ4 = new SPDataService();
                objDsRackGroup = objDServ4.udfnRackGroupList(5, 0, 0, 0, 0, txtRackgroup.Text.Trim());
                objDServ4.CloseConnection();
                if (objDsRackGroup != null)
                {
                    if (objDsRackGroup.Tables.Count > 0)
                    {
                        if (objDsRackGroup.Tables[0].Rows.Count > 0)
                        {
                            varId_RackGroup = Convert.ToString(objDsRackGroup.Tables[0].Rows[0][0]);
                        }
                    }
                }
                lblRackgroupCode.Text = Convert.ToString(varId_RackGroup);
                if (varId_RackGroup == "0" || varId_RackGroup == "-1")
                {
                    //lblRackgroupCode.Text = "0";
                }
            }
        }
        public void udfnRackInchargeValid()
        {
            /* Check purchase rack is valid or not*/
            if (txtEmployeeName.Text != "")
            {
                string varId_RackIncharge = "0";
                DataSet objDsRackIncharge = new DataSet();
                SPDataService objDServ4 = new SPDataService();
                objDsRackIncharge = objDServ4.udfnEmployeeList(8,txtEmployeeName.Text.Trim(),0,"",0,0,0);
                objDServ4.CloseConnection();
                if (objDsRackIncharge != null)
                {
                    if (objDsRackIncharge.Tables.Count > 0)
                    {
                        if (objDsRackIncharge.Tables[0].Rows.Count > 0)
                        {
                            varId_RackIncharge = Convert.ToString(objDsRackIncharge.Tables[0].Rows[0][0]);
                        }
                    }
                }
                lblEmpCode.Text = Convert.ToString(varId_RackIncharge);
                if (varId_RackIncharge == "0" || varId_RackIncharge == "-1")
                {
                    //lblEmpCode.Text = "0";
                }
            }
        }
        private void CmbReportType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtRackgroup.Enabled == true)
                    {
                        txtRackgroup.Focus();
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
        private void REPORT_CP_Rackgroup_KeyDown(object sender, KeyEventArgs e)
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

        private void REPORT_CP_Rackgroup_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,41) AND MSTID<>0", "MST_DisplayText,MSTID", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbReportType.SelectedValue = -1;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvRackgroup.Items.Count == 0 || txtRackgroup.Text == "")
                    {
                        txtRackgroup.Focus();
                        lvRackgroup.Visible = false;
                    }
                    else
                    {
                        lvRackgroup.Focus();
                    }
                    if (lvRackgroup.Items.Count > 0)
                    {
                        lvRackgroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtEmployeeName.Focus();
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

        private void TxtRackgroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvRackgroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRackgroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackGroupList(4,0,0,0,0,txtRackgroup.Text.Trim());
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RKG_Name"].ToString(),objDs.Tables[0].Rows[i]["RKGID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvRackgroup.Columns[0].Width = 200;
                                    lvRackgroup.Columns[1].Width = 0;
                                    lvRackgroup.Items.Add(objList);
                                }
                                lvRackgroup.Visible = true;
                                lvRackgroup.BringToFront();
                            }
                            else
                            {
                                lvRackgroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvRackgroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvRackgroup.Visible = false;
                    }
                }
                else
                {
                    lvRackgroup.Visible = false;
                    lvRackgroup.Items.Clear();
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
        private void TxtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                lvRackIncharge.Visible = false;
                txtRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvRack.Items.Count == 0 || txtRack.Text == "")
                    {
                        txtRack.Focus();
                        lvRack.Visible = false;
                    }
                    else
                    {
                        lvRack.Focus();
                    }
                    if (lvRack.Items.Count > 0)
                    {
                        lvRack.Items[0].Selected = true;
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

        private void TxtRack_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRack.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //int varLocationId = 0;
                lvRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(8, 0, 0, 0, 0, txtRack.Text, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_Name"].ToString(), objDs.Tables[0].Rows[i]["RK_Description"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvRack.Columns[0].Width = 100;
                                    lvRack.Items.Add(objList);
                                }
                                lvRack.Visible = true;
                                lvRack.BringToFront();
                            }
                            else
                            {
                                lvRack.Visible = false;
                            }
                        }
                        else
                        {
                            lvRack.Visible = false;
                        }
                    }
                    else
                    {
                        lvRack.Visible = false;
                    }
                }
                else
                {
                    lvRack.Visible = false;
                    lvRack.Items.Clear();
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

        private void LvRackgroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnRackgroup();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRackgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnRackgroup();
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
                if (txtRackgroup.Text != "")
                {
                    ListViewItem selectedItem = lvRackgroup.SelectedItems[0];
                    txtRackgroup.Text = selectedItem.SubItems[0].Text;
                    lblRackgroupCode.Text = selectedItem.SubItems[1].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtEmployeeName.Focus();
                lvRackgroup.Visible = false;
            }
        }

        private void LvRackIncharge_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnRackIncharge();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRackIncharge_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnRackIncharge();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRackIncharge()
        {
            try
            {
                if (txtEmployeeName.Text != "")
                {
                    ListViewItem selectedItem = lvRackIncharge.SelectedItems[0];
                    txtEmployeeName.Text = selectedItem.SubItems[1].Text;
                    lblEmpCode.Text = selectedItem.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtRack.Focus();
                lvRackIncharge.Visible = false;
            }
        }

        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnRack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnRack();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRack()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    lblRackCode.Text = selectedItem.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnListPrint.Focus();
                lvRack.Visible = false;
            }
        }

        private void TxtEmployeeName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtEmployeeName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvRackIncharge.Items.Count == 0 || txtEmployeeName.Text == "")
                    {
                        txtEmployeeName.Focus();
                        lvRackIncharge.Visible = false;
                    }
                    else
                    {
                        lvRackIncharge.Focus();
                    }
                    if (lvRackIncharge.Items.Count > 0)
                    {
                        lvRackIncharge.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEmployeeName_Enter(object sender, EventArgs e)
        {
            try
            {
                lvRackgroup.Visible = false;
                txtEmployeeName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvRackIncharge.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtEmployeeName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnEmployeeList(2,txtEmployeeName.Text.Trim(),0,"",0,0,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["EMP_Code"].ToString(), objDs.Tables[0].Rows[i]["EMP_Name"].ToString(), objDs.Tables[0].Rows[i]["EMPID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvRackIncharge.Columns[0].Width = 100;
                                    lvRackIncharge.Columns[1].Width = 150;
                                    lvRackIncharge.Columns[2].Width = 0;
                                    lvRackIncharge.Items.Add(objList);
                                }
                                lvRackIncharge.Visible = true;
                                lvRackIncharge.BringToFront();
                            }
                            else
                            {
                                lvRackIncharge.Visible = false;
                            }
                        }
                        else
                        {
                            lvRackIncharge.Visible = false;
                        }
                    }
                    else
                    {
                        lvRackIncharge.Visible = false;
                    }
                }
                else
                {
                    lvRackIncharge.Visible = false;
                    lvRackIncharge.Items.Clear();
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
