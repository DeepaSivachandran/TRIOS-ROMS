using DocumentFormat.OpenXml.VariantTypes;
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
    public partial class REPORT_CP_Supplier : Form
    {
        MainForm objMainForm = new MainForm();
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyCity = 0;
        public REPORT_CP_Supplier()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tsSupplierReport, this);
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
                lvCity.Visible = false;
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
                lvCity.Visible = false;
                if (Convert.ToInt32(cmbReportType.SelectedValue) == -1)
                {
                    cmbReportType.Focus();
                }
                else
                {
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 123)
                    {
                        udfnSupplier(varFlag);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 124)
                    {
                        udfnSupplierAddress(varFlag);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 125)
                    {
                        udfnSupplierContact(varFlag);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 126)
                    {
                        udfnSupplierPODetails(varFlag);
                    }
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
        public void udfnSupplier(int varFlag)
        {
            try
            {
                int CityId = 0;
                string CityName = "";
                if(txtCity.Text=="")
                {
                    CityId = 0;
                    CityName = "-All-";
                }
                else
                {
                    string VarCity = "0";
                    DataSet objDsCity = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsCity = objDserv.udfnCitylist(2, txtCity.Text.Trim(), 0, 0);
                    objDserv.CloseConnection();
                    if (objDsCity != null)
                    {
                        if (objDsCity.Tables.Count > 0)
                        {
                            if (objDsCity.Tables[0].Rows.Count > 0)
                            {
                                VarCity = Convert.ToString(objDsCity.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    CityId = Convert.ToInt32(VarCity);
                    CityName = txtCity.Text.Trim();
                }
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 13;
                objMR_Supplier.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Supplier.paraStateId = Convert.ToInt32(cmbState.SelectedValue);
                objMR_Supplier.paraPaymentTerm = Convert.ToInt32(cmbPaymentTerm.SelectedValue);
                objMR_Supplier.paraGstType = Convert.ToInt32(cmbSupplierType.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnSupplierList(objMR_Supplier);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Supplier.rpt");
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraStateId", Convert.ToInt32(cmbState.SelectedValue));
                    objBillreport.SetParameterValue("paraStateName", Convert.ToString(cmbState.Text));
                    objBillreport.SetParameterValue("paraGstType", Convert.ToInt32(cmbSupplierType.SelectedValue));
                    objBillreport.SetParameterValue("paraGSTTypeName", Convert.ToString(cmbSupplierType.Text));
                    objBillreport.SetParameterValue("paraPaymentTerm", Convert.ToInt32(cmbPaymentTerm.SelectedValue));
                    objBillreport.SetParameterValue("parapaymentTermName", Convert.ToString(cmbPaymentTerm.Text));
                    objBillreport.SetParameterValue("paraCityId", Convert.ToInt32(CityId));
                    objBillreport.SetParameterValue("paraCityName", Convert.ToString(CityName));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
                        string varReportName = "Supplier";
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
        public void udfnSupplierAddress(int varFlag)
        {
            try
            {
                int CityId = 0;
                string CityName = "";
                if (txtCity.Text == "")
                {
                    CityId = 0;
                    CityName = "-All-";
                }
                else
                {
                    string VarCity = "0";
                    DataSet objDsCity = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsCity = objDserv.udfnCitylist(2, txtCity.Text.Trim(), 0, 0);
                    objDserv.CloseConnection();
                    if (objDsCity != null)
                    {
                        if (objDsCity.Tables.Count > 0)
                        {
                            if (objDsCity.Tables[0].Rows.Count > 0)
                            {
                                VarCity = Convert.ToString(objDsCity.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    CityId = Convert.ToInt32(VarCity);
                    CityName = txtCity.Text.Trim();
                }
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 14;
                objMR_Supplier.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Supplier.paraCityId = CityId;
                objMR_Supplier.paraStateId = Convert.ToInt32(cmbState.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnSupplierList(objMR_Supplier);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Supplier_Address.rpt");
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraStateId", Convert.ToInt32(cmbState.SelectedValue));
                    objBillreport.SetParameterValue("paraStateName", Convert.ToString(cmbState.Text));
                    objBillreport.SetParameterValue("paraCityId", Convert.ToInt32(CityId));
                    objBillreport.SetParameterValue("paraCityName", Convert.ToString(CityName));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
                        string varReportName = "Supplier_Address";
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
        public void udfnSupplierContact(int varFlag)
        {
            try
            {
                int CityId = 0;
                string CityName = "";
                if (txtCity.Text == "")
                {
                    CityId = 0;
                    CityName="-All-";
                }
                else
                {
                    string VarCity = "0";
                    DataSet objDsCity = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsCity = objDserv.udfnCitylist(2, txtCity.Text.Trim(), 0, 0);
                    objDserv.CloseConnection();
                    if (objDsCity != null)
                    {
                        if (objDsCity.Tables.Count > 0)
                        {
                            if (objDsCity.Tables[0].Rows.Count > 0)
                            {
                                VarCity = Convert.ToString(objDsCity.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    CityId = Convert.ToInt32(VarCity);
                    CityName = txtCity.Text.Trim();
                }
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 20;
                objMR_Supplier.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Supplier.paraCityId = CityId;
                objMR_Supplier.paraStateId = Convert.ToInt32(cmbState.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnSupplierList(objMR_Supplier);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Supplier_Contact.rpt");
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraStateId", Convert.ToInt32(cmbState.SelectedValue));
                    objBillreport.SetParameterValue("paraStateName", Convert.ToString(cmbState.Text));
                    objBillreport.SetParameterValue("paraCityId", Convert.ToInt32(CityId));
                    objBillreport.SetParameterValue("paraCityName", Convert.ToString(CityName));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
                        string varReportName = "Supplier_Contact";
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
        public void udfnSupplierPODetails(int varFlag)
        {
            try
            {
                int CityId = 0;
                string CityName = "";
                if (txtCity.Text == "")
                {
                    CityId = 0;
                    CityName = "-All-";
                }
                else
                {
                    string VarCity = "0";
                    DataSet objDsCity = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsCity = objDserv.udfnCitylist(2, txtCity.Text.Trim(), 0, 0);
                    objDserv.CloseConnection();
                    if (objDsCity != null)
                    {
                        if (objDsCity.Tables.Count > 0)
                        {
                            if (objDsCity.Tables[0].Rows.Count > 0)
                            {
                                VarCity = Convert.ToString(objDsCity.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    CityId = Convert.ToInt32(VarCity);
                    CityName = txtCity.Text.Trim();
                }
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 19;
                objMR_Supplier.paraordertype = Convert.ToInt32(cmbOrderType.SelectedValue);
                objMR_Supplier.paraCityId = CityId;
                objMR_Supplier.paraStateId = Convert.ToInt32(cmbState.SelectedValue);
                objMR_Supplier.paraReturnPolicy = Convert.ToInt32(cmbReturnPolicy.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnSupplierList(objMR_Supplier);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Supplier_PO_Details.rpt");
                    objBillreport.SetParameterValue("paraStateId", Convert.ToInt32(cmbState.SelectedValue));
                    objBillreport.SetParameterValue("paraStateName", Convert.ToString(cmbState.Text));
                    objBillreport.SetParameterValue("paraordertype", Convert.ToInt32(cmbOrderType.SelectedValue));
                    objBillreport.SetParameterValue("paraOrderTypeName", Convert.ToString(cmbOrderType.Text));
                    objBillreport.SetParameterValue("paraReturnPolicy", Convert.ToInt32(cmbReturnPolicy.SelectedValue));
                    objBillreport.SetParameterValue("paraReturnPolicyName", Convert.ToString(cmbReturnPolicy.Text));
                    objBillreport.SetParameterValue("paraCityId", Convert.ToInt32(CityId));
                    objBillreport.SetParameterValue("paraCityName", Convert.ToString(CityName));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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
                        string varReportName = "Supplier_PO_Details";
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
        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbReportType.Select(int.MaxValue, 0)));
                if(cmbReportType.SelectedIndex==1)
                {
                    cmbOrderType.Enabled = false;
                    cmbReturnPolicy.Enabled = false;
                    cmbState.Enabled = true;
                    cmbSupplierType.Enabled = true;
                    cmbPaymentTerm.Enabled = true;
                    cmbStatus.Enabled = true;
                    udfnClear();
                }
                if(cmbReportType.SelectedIndex==2)
                {
                    cmbSupplierType.Enabled = false;
                    cmbPaymentTerm.Enabled = false;
                    cmbOrderType.Enabled = false;
                    cmbReturnPolicy.Enabled = false;
                    cmbState.Enabled = true;
                    cmbStatus.Enabled = true;
                    udfnClear();
                }
                if (cmbReportType.SelectedIndex == 3)
                {
                    cmbSupplierType.Enabled = false;
                    cmbPaymentTerm.Enabled = false;
                    cmbOrderType.Enabled = false;
                    cmbReturnPolicy.Enabled = false;
                    cmbState.Enabled = true;
                    cmbStatus.Enabled = true;
                    udfnClear();
                }
                if (cmbReportType.SelectedIndex == 4)
                {
                    cmbSupplierType.Enabled = false;
                    cmbPaymentTerm.Enabled = false;
                    cmbStatus.Enabled = false;
                    cmbState.Enabled = true;
                    cmbOrderType.Enabled = true;
                    cmbReturnPolicy.Enabled = true;
                    udfnClear();
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
                    cmbState.Focus();
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
        private void REPORT_CP_Supplier_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80112;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind(); //Transaction id 	42
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MSTID IN (" + ReportTypeIDs + ")", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>-1 ORDER BY STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (8,0) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnPolicy, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (11,0) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (12,0) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPaymentTerm, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (13,0) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrderType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                udfncmbLoad();
                cmbReportType.SelectedValue = -1;
                cmbStatus.SelectedValue = 0;
                cmbState.SelectedValue = 0;
                cmbSupplierType.SelectedValue = 0;
                cmbPaymentTerm.SelectedValue = 0;
                cmbOrderType.SelectedValue = 0;
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
        public void udfncmbLoad()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 6;
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                cmbOrderType.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbOrderType.Enabled = true;
                            cmbOrderType.ValueMember = "MSTID";
                            cmbOrderType.DisplayMember = "MST_DisplayText";
                            cmbOrderType.DataSource = objDT.Tables[0];
                        }
                        if (objDT.Tables[1].Rows.Count > 0)
                        {
                            cmbReturnPolicy.Enabled = true;
                            cmbReturnPolicy.ValueMember = "MSTID";
                            cmbReturnPolicy.DisplayMember = "MST_DisplayText";
                            cmbReturnPolicy.DataSource = objDT.Tables[1];
                        }
                    }
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
            txtCity.Text = "";
            cmbStatus.SelectedValue = 0;
            cmbState.SelectedValue = 0;
            cmbSupplierType.SelectedValue = 0;
            cmbPaymentTerm.SelectedValue = 0;
            cmbReturnPolicy.SelectedValue = 0;
            cmbOrderType.SelectedValue = 0;
        }
        private void REPORT_CP_Supplier_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbState_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbState.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbState.BackColor = Color.White;
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
                    if (cmbSupplierType.Enabled == true)
                    {
                        cmbSupplierType.Focus();
                    }
                    else
                    {
                        if (cmbOrderType.Enabled == true)
                        {
                            cmbOrderType.Focus();
                        }
                        else
                        {
                            cmbStatus.Focus();
                        }
                    }
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
                        if (cmbSupplierType.Enabled == true)
                        {
                            cmbSupplierType.Focus();
                        }
                        else
                        {
                            if (cmbOrderType.Enabled == true)
                            {
                                cmbOrderType.Focus();
                            }
                            else
                            {
                                cmbStatus.Focus();
                            }
                        }
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

        private void TxtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyCity == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtCity.Text.Length > 0)
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

        private void CmbSupplierType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPaymentTerm.Focus();
                }
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

        private void CmbPaymentTerm_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbPaymentTerm.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentTerm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //if (cmbReportType.SelectedIndex == 1)
                    //{
                        cmbStatus.Focus();
                    //}
                    //else
                    //{
                    //    cmbOrderType.Focus();
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentTerm_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPaymentTerm.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbOrderType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbReturnPolicy.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbReturnPolicy.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbReturnPolicy_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReturnPolicy.BackColor = Color.White;
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
                    cmbSupplierType.Focus();
                }
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
                cmbStatus.Focus();
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

        private void CmbState_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPaymentTerm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbOrderType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReturnPolicy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DGV_FilterCity_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyCity = 1;
                udfnGrdevent();
                if (cmbSupplierType.Enabled == true)
                {
                    cmbSupplierType.Focus();
                }
                else
                {
                    if (cmbOrderType.Enabled == true)
                    {
                        cmbOrderType.Focus();
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

        private void DGV_FilterCity_KeyDown(object sender, KeyEventArgs e)
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
                        if (cmbSupplierType.Enabled == true)
                        {
                            cmbSupplierType.Focus();
                        }
                        else
                        {
                            if (cmbOrderType.Enabled == true)
                            {
                                cmbOrderType.Focus();
                            }
                            else
                            {
                                cmbStatus.Focus();
                            }
                        }
                    }
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
            udfnList(1);
        }
    }
}
