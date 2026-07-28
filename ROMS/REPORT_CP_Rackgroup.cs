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
    public partial class REPORT_CP_Rackgroup : Form
    {
        MainForm objMainForm = new MainForm();
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyRackGroup = 0;
        public REPORT_CP_Rackgroup()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tsRackGroupReport, this);
        }
        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                lvRack.Visible = false;
                varUpDownKeyRackGroup = 0;
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
                    int itemType = Convert.ToInt32(cmbType.SelectedValue);

                    if (itemType == 405) ////withpicode
                    { itemType = 2; }
                    else if (itemType == 406) ////withoutpicode
                    { itemType = 1; }

                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 117)
                    {
                        udfnRG(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 118)
                    {
                        udfnRGProduct(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 119)
                    {
                        udfnRGProBarcode(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 120)
                    {
                        udfnRGProMsq(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 121)
                    {
                        udfnRGProWeight(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 122)
                    {
                        udfnRGProRackMinQty(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 432)
                    {
                        udfnRGProShelflife(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 465)
                    {
                        udfnRKGProductOrderNo(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 473)
                    {
                        udfnRKGProductStockTaking(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 474)
                    {
                        udfnRKGProductAssigned(varFlag, itemType);
                    }
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 475)
                    {
                        udfnRKGProductUnassigned(varFlag, itemType);
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
        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbReportType.Select(int.MaxValue, 0)));
                cmbLocationType.SelectedValue = 466;
                chkLocBreakup.Checked = false;
                cmbShopLocType.SelectedValue = 0;
                cmbShopLocType.Enabled = true;
                if (Convert.ToInt32(cmbReportType.SelectedValue) == -1)
                {
                    cmbConcern.SelectedValue = 0;
                    cmbRackGroup.SelectedValue = 0; ;
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 117)
                {
                    cmbRackGroup.Enabled = false;

                    txtEmployeeName.Enabled = false;
                    txtRack.Enabled = false;
                    cmbProductCategory.SelectedValue = 0;
                    cmbSubgroupType.SelectedValue = 0;
                    
                    cmbProductCategory.Enabled = false;
                    cmbSubgroupType.Enabled = false;
                    
                }
                else
                {
                    cmbRackGroup.Enabled = true;
                    txtEmployeeName.Enabled = true;
                    txtRack.Enabled = true;
                    cmbProductCategory.Enabled = true;
                    cmbSubgroupType.Enabled = true;
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 120 || Convert.ToInt32(cmbReportType.SelectedValue) == 121)
                {
                    cmbFormat.Enabled = true;
                }
                else
                {
                    cmbFormat.Enabled = false;
                }
                udfnClear();
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

                cmbType.Enabled = true;
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 117)
                {
                    cmbType.Enabled = false;
                    cmbShopLocType.Enabled = false;
                }
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 465 || Convert.ToInt32(cmbReportType.SelectedValue) == 473 || Convert.ToInt32(cmbReportType.SelectedValue) == 474 || Convert.ToInt32(cmbReportType.SelectedValue) == 475)
                {
                    cmbType.Enabled = false;
                }
                if (cmbReportType.SelectedValue != null)
                {
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 122 || Convert.ToInt32(cmbReportType.SelectedValue) == 121)
                    {
                        cmbLocationType.Enabled = true;
                        chkLocBreakup.Enabled = true;
                    }
                    else
                    {
                        cmbLocationType.Enabled = false;
                        chkLocBreakup.Enabled = false;
                        cmbLocationType.SelectedValue = 467;
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
            txtEmployeeName.Text = "";
            txtRack.Text = "";
            cmbConcern.SelectedValue = 0;
            cmbStatus.SelectedValue = 1;
        }
        public void udfnRG(int varFlag, int itemType)
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
                objDs = objspservice.udfnRackGroupList(3, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, Convert.ToInt32(cmbStatus.SelectedValue), "", Convert.ToInt32(cmbproductStatus.SelectedValue), Convert.ToInt32(cmbStockTakken.SelectedValue));
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup.rpt");
                    objBillreport.PrintOptions.NoPrinter = true;
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraProductStatusID", Convert.ToInt32(cmbproductStatus.SelectedValue));
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
                        string varReportName = "Rackgroup";
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
        public void udfnRGProduct(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
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
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 20;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraRackId = RKCode;
                objMR_Product.paraRKGId = RKGCode;
                objMR_Product.paraEMPId = EMPCode;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.paraSubgroupType = Convert.ToInt32(cmbSubgroupType.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.ParaOrderby = Convert.ToInt32(cmbOrderBy.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.ParaStockType = Convert.ToInt32(cmbStockTakken.SelectedValue);

                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product.rpt");
                    objBillreport.PrintOptions.NoPrinter = true;
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraSubgroupType", Convert.ToInt32(cmbSubgroupType.SelectedValue));
                    objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text));
                    objBillreport.SetParameterValue("paraSubgroupTypeName", Convert.ToString(cmbSubgroupType.Text));
                    objBillreport.SetParameterValue("ParaOrderby", Convert.ToInt32(cmbOrderBy.SelectedValue));
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue));
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraWithCode", itemType);
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt16(cmbShopLocType.SelectedValue));
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
                        string varReportName = "Rackgroup_Product";
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
        public void udfnRGProBarcode(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
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
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 21;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraRackId = RKCode;
                objMR_Product.paraRKGId = RKGCode;
                objMR_Product.paraEMPId = EMPCode;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.paraSubgroupType = Convert.ToInt32(cmbSubgroupType.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.ParaOrderby = Convert.ToInt32(cmbOrderBy.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.ParaStockType = Convert.ToInt32(cmbStockTakken.SelectedValue);
                objMR_Product.paraShopLocType = Convert.ToInt32(cmbShopLocType.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (Convert.ToInt32(cmbType.SelectedValue) == 405)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_Barcode_PICode.rpt");
                        objBillreport.PrintOptions.NoPrinter = true;
                    }
                    else
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_Barcode.rpt");
                        objBillreport.PrintOptions.NoPrinter = true;
                    }
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbproductStatus.Text));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraSubgroupType", Convert.ToInt32(cmbSubgroupType.SelectedValue));
                    objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text));
                    objBillreport.SetParameterValue("paraSubgroupTypeName", Convert.ToString(cmbSubgroupType.Text));
                    objBillreport.SetParameterValue("ParaOrderby", Convert.ToInt32(cmbOrderBy.SelectedValue));
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue));
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraWithCode", itemType);
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt32(cmbShopLocType.SelectedValue));

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
                        string varReportName = "Rackgroup_Product_Barcode";
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
        public void udfnRGProMsq(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
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
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 22;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraRackId = RKCode;
                objMR_Product.paraRKGId = RKGCode;
                objMR_Product.paraEMPId = EMPCode;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.paraSubgroupType = Convert.ToInt32(cmbSubgroupType.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.ParaOrderby = Convert.ToInt32(cmbOrderBy.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.ParaStockType = Convert.ToInt32(cmbStockTakken.SelectedValue);
                objMR_Product.paraShopLocType = Convert.ToInt32(cmbShopLocType.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_Msq.rpt");
                    objBillreport.PrintOptions.NoPrinter = true;
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraSubgroupType", Convert.ToInt32(cmbSubgroupType.SelectedValue));
                    objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text));
                    objBillreport.SetParameterValue("paraSubgroupTypeName", Convert.ToString(cmbSubgroupType.Text));
                    objBillreport.SetParameterValue("paraType", Convert.ToString(cmbFormat.SelectedValue));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraWithCode", itemType);
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue));
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt32(cmbShopLocType.SelectedValue));
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
                        string varReportName = "Rackgroup_Product_Msq";
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
        public void udfnRGProWeight(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
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
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 23;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraRackId = RKCode;
                objMR_Product.paraRKGId = RKGCode;
                objMR_Product.paraEMPId = EMPCode;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.paraSubgroupType = Convert.ToInt32(cmbSubgroupType.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.ParaOrderby = Convert.ToInt32(cmbOrderBy.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.ParaStockType = Convert.ToInt32(cmbStockTakken.SelectedValue);
                objMR_Product.paraLocationType = Convert.ToInt32(cmbLocationType.SelectedValue);
                objMR_Product.paraShopLocType = Convert.ToInt32(cmbShopLocType.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (chkLocBreakup.Checked == true)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_Weight_Loc_Split.rpt");
                    }
                    else
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_Weight.rpt");
                    }
                    objBillreport.PrintOptions.NoPrinter = true;

                    int varChkLocationBreakupFlag = 0;
                    if (chkLocBreakup.Checked == true)
                    {
                        varChkLocationBreakupFlag = 1;
                    }
                    objBillreport.SetParameterValue("paraLocationGroupingFlag", varChkLocationBreakupFlag);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGId", RKGCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraSubgroupType", Convert.ToInt32(cmbSubgroupType.SelectedValue));
                    objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text));
                    objBillreport.SetParameterValue("paraSubgroupTypeName", Convert.ToString(cmbSubgroupType.Text));
                    objBillreport.SetParameterValue("paraType", Convert.ToString(cmbFormat.SelectedValue));
                    objBillreport.SetParameterValue("ParaOrderby", Convert.ToInt32(cmbOrderBy.SelectedValue));
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue));
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue));
                    objBillreport.SetParameterValue("paraLocationType", Convert.ToInt32(cmbLocationType.SelectedValue));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraWithCode", itemType);
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt32(cmbShopLocType.SelectedValue));
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
                        string varReportName = "Rackgroup_Product_Weight";
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
        public void udfnRGProRackMinQty(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
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
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 24;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraRackId = RKCode;
                objMR_Product.paraRKGId = RKGCode;
                objMR_Product.paraEMPId = EMPCode;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.paraSubgroupType = Convert.ToInt32(cmbSubgroupType.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.ParaOrderby = Convert.ToInt32(cmbOrderBy.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.ParaStockType = Convert.ToInt32(cmbStockTakken.SelectedValue);
                objMR_Product.paraLocationType = Convert.ToInt32(cmbLocationType.SelectedValue);
                objMR_Product.paraShopLocType = Convert.ToInt32(cmbShopLocType.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    //int varType = Convert.ToInt32(cmbType.SelectedValue);

                    //if (varType == 405) ////withpicode
                    //{ varType = 2; }
                    //else if (varType == 406) ////withoutpicode
                    //{ varType = 1; }

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.PrintOptions.NoPrinter = true;
                    if (Convert.ToInt32(cmbType.SelectedValue) == 405)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_RackMin_Qty_PICode.rpt");
                    }
                    else
                    {
                        if (chkLocBreakup.Checked == true)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_RackMin_Qty_Loc_Split.rpt");
                        }
                        else
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_RackMin_Qty.rpt");
                        }
                    }
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt16(cmbShopLocType.SelectedValue));
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraLocationType", Convert.ToInt32(cmbLocationType.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraSubgroupType", Convert.ToInt32(cmbSubgroupType.SelectedValue));
                    string varCategoryName = "";
                    if (Convert.ToInt32(cmbProductCategory.SelectedValue) == 16)
                    {
                        objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text) + "-" + Convert.ToString(cmbStockTakken.Text));
                    }
                    else
                    {
                        objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text));
                    }
                    int varChkLocationBreakupFlag = 0;
                    if (chkLocBreakup.Checked == true)
                    {
                        varChkLocationBreakupFlag = 1;
                    }
                    objBillreport.SetParameterValue("paraLocationGroupingFlag", varChkLocationBreakupFlag);

                    objBillreport.SetParameterValue("paraSubgroupTypeName", Convert.ToString(cmbSubgroupType.Text));
                    objBillreport.SetParameterValue("ParaOrderby", Convert.ToInt32(cmbOrderBy.SelectedValue));
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue));
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraWithCode", itemType);

                    /*Subreport parameter pass*/
                    objBillreport.SetParameterValue("paraEMPID", EMPCode, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraRKGID", RKGCode, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraRKID", RKCode, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraLocationType", Convert.ToInt32(cmbLocationType.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraSubgroupType", Convert.ToInt32(cmbSubgroupType.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("ParaOrderby", Convert.ToInt32(cmbOrderBy.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt32(cmbShopLocType.SelectedValue), objBillreport.Subreports[0].Name.ToString());

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
                        string varReportName = "Rackgroup_Product_RackMin_Qty";
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
        public void udfnRGProShelflife(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0, RKCode = 0, EMPCode = 0;
                string RKGName = "", RKName = "", RKInchargeName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
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
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 84;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraRackId = RKCode;
                objMR_Product.paraRKGId = RKGCode;
                objMR_Product.paraEMPId = EMPCode;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.paraSubgroupType = Convert.ToInt32(cmbSubgroupType.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.ParaOrderby = Convert.ToInt32(cmbOrderBy.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.ParaStockType = Convert.ToInt32(cmbStockTakken.SelectedValue);
                objMR_Product.paraShopLocType = Convert.ToInt32(cmbShopLocType.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    ////  //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_ShelfLife.rpt");
                    objBillreport.PrintOptions.NoPrinter = true;
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraEMPID", EMPCode);
                    objBillreport.SetParameterValue("paraRKID", RKCode);
                    objBillreport.SetParameterValue("paraRKGName", RKGName);
                    objBillreport.SetParameterValue("paraRKInchargeName", RKInchargeName);
                    objBillreport.SetParameterValue("paraRKName", RKName);
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraSubgroupType", Convert.ToInt32(cmbSubgroupType.SelectedValue));
                    objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text));
                    objBillreport.SetParameterValue("paraSubgroupTypeName", Convert.ToString(cmbSubgroupType.Text));
                    objBillreport.SetParameterValue("ParaOrderby", Convert.ToInt32(cmbOrderBy.SelectedValue));
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue));
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraWithCode", itemType);
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt32(cmbShopLocType.SelectedValue));
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
                        string varReportName = "Rackgroup_Product_RackMin_Qty";
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
        public void udfnRKGProductOrderNo(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0;
                string RKGName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 91;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraRKGId = RKGCode;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.paraShopLocType = Convert.ToInt32(cmbShopLocType.SelectedValue);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Product_Mapping.rpt");
                    objBillreport.PrintOptions.NoPrinter = true;
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraRKGID", RKGCode);
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue));
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt32(cmbShopLocType.SelectedValue));
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
                        string varReportName = "Rackgroup_Product_Mapping";
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
        public void udfnRKGProductAssigned(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0;
                string RKGName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 92;
                objMR_Product.paraFlag = 0;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraGroup = 0;
                objMR_Product.paraSubgroup = 0;
                objMR_Product.paraBrandID = 0;
                objMR_Product.paraLocationId = 0;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.ParaStockType = Convert.ToInt32(cmbStockTakken.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.paraRKGId = Convert.ToInt32(cmbRackGroup.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.paraShopLocType = Convert.ToInt32(cmbShopLocType.SelectedValue);
                objMR_Product.paraPicode = "";
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Rack_Product_Assigned.rpt");
                    objBillreport.PrintOptions.NoPrinter = true;
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue));
                    objBillreport.SetParameterValue("paraRKGId", Convert.ToInt32(cmbRackGroup.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue));

                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text));
                    objBillreport.SetParameterValue("paraStockTaking", Convert.ToString(cmbStockTakken.Text));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbproductStatus.Text));
                    objBillreport.SetParameterValue("paraGroup", 0);
                    objBillreport.SetParameterValue("paraSubgroup", 0);
                    objBillreport.SetParameterValue("paraBrandID", 0);
                    objBillreport.SetParameterValue("paraType", 0);
                    objBillreport.SetParameterValue("paraUnitId", 0);
                    objBillreport.SetParameterValue("paraPicode", "");
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt32(cmbShopLocType.SelectedValue));

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
                        string varReportName = "Rackgroup_Rack_Product_Assigned";
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
        public void udfnRKGProductUnassigned(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0;
                string RKGName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 92;
                objMR_Product.paraFlag = 1;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraGroup = 0;
                objMR_Product.paraSubgroup = 0;
                objMR_Product.paraBrandID = 0;
                objMR_Product.paraLocationId = 0;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.ParaStockType = Convert.ToInt32(cmbStockTakken.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.paraRKGId = Convert.ToInt32(cmbRackGroup.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.paraShopLocType = Convert.ToInt32(cmbShopLocType.SelectedValue);
                objMR_Product.paraPicode = "";
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Rack_Product_Unassigned.rpt");
                    objBillreport.PrintOptions.NoPrinter = true;
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue));
                    objBillreport.SetParameterValue("paraRKGId", Convert.ToInt32(cmbRackGroup.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue));

                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text));
                    objBillreport.SetParameterValue("paraStockTaking", Convert.ToString(cmbStockTakken.Text));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbproductStatus.Text));
                    objBillreport.SetParameterValue("paraGroup", 0);
                    objBillreport.SetParameterValue("paraSubgroup", 0);
                    objBillreport.SetParameterValue("paraBrandID", 0);
                    objBillreport.SetParameterValue("paraType", 0);
                    objBillreport.SetParameterValue("paraUnitId", 0);
                    objBillreport.SetParameterValue("paraPicode", "");
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt32(cmbShopLocType.SelectedValue));
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
                        string varReportName = "Rackgroup_Rack_Product_Assigned";
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
        public void udfnRKGProductStockTaking(int varFlag, int itemType)
        {
            try
            {
                udfnRackValid();
                udfnRackGroupValid();
                udfnRackInchargeValid();
                btnListPrint.Enabled = false;
                lblReportType.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                int RKGCode = 0;
                string RKGName = "";

                RKGCode = Convert.ToInt32(cmbRackGroup.SelectedValue);
                RKGName = Convert.ToString(cmbRackGroup.Name);
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 93;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.paraGroup = 0;
                objMR_Product.paraSubgroup = 0;
                objMR_Product.paraBrandID = 0;
                objMR_Product.paraLocationId = 0;
                objMR_Product.paraProductCategory = Convert.ToInt32(cmbProductCategory.SelectedValue);
                objMR_Product.ParaStockType = Convert.ToInt32(cmbStockTakken.SelectedValue);
                objMR_Product.ParaRate = Convert.ToInt32(cmbRetailRate.SelectedValue);
                objMR_Product.paraRackStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.paraRKGId = Convert.ToInt32(cmbRackGroup.SelectedValue);
                objMR_Product.paraStatusId = Convert.ToInt32(cmbproductStatus.SelectedValue);
                objMR_Product.paraShopLocType = Convert.ToInt32(cmbShopLocType.SelectedValue);
                objMR_Product.paraPicode = "";
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    //// /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Rackgroup_Rack_Product_StockTaking.rpt");
                    objBillreport.PrintOptions.NoPrinter = true;
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    objBillreport.SetParameterValue("ParaStockType", Convert.ToInt32(cmbStockTakken.SelectedValue));
                    objBillreport.SetParameterValue("paraRKGId", Convert.ToInt32(cmbRackGroup.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbproductStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraRackStatusID", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("ParaRate", Convert.ToInt32(cmbRetailRate.SelectedValue));

                    objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraCategoryName", Convert.ToString(cmbProductCategory.Text));
                    objBillreport.SetParameterValue("paraStockTaking", Convert.ToString(cmbStockTakken.Text));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbproductStatus.Text));
                    objBillreport.SetParameterValue("paraGroup", 0);
                    objBillreport.SetParameterValue("paraSubgroup", 0);
                    objBillreport.SetParameterValue("paraBrandID", 0);
                    objBillreport.SetParameterValue("paraLocationId", 0);
                    objBillreport.SetParameterValue("paraPicode", "");
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName); 
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraShopLocType", Convert.ToInt32(cmbShopLocType.SelectedValue));
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
                        string varReportName = "Rackgroup_Rack_Product_StockTaking";
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
        public void udfnRackValid()
        {
            /* Check purchase rack is valid or not*/
            if (txtRack.Text != "")
            {
                string varId_PurRack = "0";
                DataSet objDsPurRack = new DataSet();
                SPDataService objDServ4 = new SPDataService();
                objDsPurRack = objDServ4.udfnRackList(9, 0, 0, 0, 0, txtRack.Text.Trim(), 0, 0);
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
            ///* Check purchase rack is valid or not*/
            //if (txtRackgroup.Text != "")
            //{
            //    string varId_RackGroup = "0";
            //    DataSet objDsRackGroup = new DataSet();
            //    SPDataService objDServ4 = new SPDataService();
            //    objDsRackGroup = objDServ4.udfnRackGroupList(5, 0, 0, 0, 0, txtRackgroup.Text.Trim(),0);
            //    objDServ4.CloseConnection();
            //    if (objDsRackGroup != null)
            //    {
            //        if (objDsRackGroup.Tables.Count > 0)
            //        {
            //            if (objDsRackGroup.Tables[0].Rows.Count > 0)
            //            {
            //                varId_RackGroup = Convert.ToString(objDsRackGroup.Tables[0].Rows[0][0]);
            //            }
            //        }
            //    }
            //    lblRackgroupCode.Text = Convert.ToString(varId_RackGroup);
            //    if (varId_RackGroup == "0" || varId_RackGroup == "-1")
            //    {
            //        //lblRackgroupCode.Text = "0";
            //    }
            //}
        }
        public void udfnRackInchargeValid()
        {
            /* Check purchase rack is valid or not*/
            if (txtEmployeeName.Text != "")
            {
                string varId_RackIncharge = "0";
                DataSet objDsRackIncharge = new DataSet();
                SPDataService objDServ4 = new SPDataService();
                objDsRackIncharge = objDServ4.udfnEmployeeList(8, txtEmployeeName.Text.Trim(), 0, "", 0, 0, 0);
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
                    cmbConcern.Focus();
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
                varUpDownKeyRackGroup = 0;
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

        private void REPORT_CP_Rackgroup_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80111;

                string ReportTypeIDs = string.Join(",",
               MainForm.objDtMenuDetailsUser?.AsEnumerable()
                   .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                   .Select(r => r.Field<int?>("MU_EQID"))
                   .Where(q => q.HasValue)
                   .Select(q => q.Value.ToString())
                   ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                int varViewType = 2;
                objDs = objdserv.udfnCompanyList(varViewType, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                cmbConcern.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDs.Tables[0];
                        }
                    }
                }
                objDs = objdserv.udfnRackGroupList(6, 0, 0, 0, 0, "", 0, 0);
                objdserv.CloseConnection();

                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbRackGroup.ValueMember = "RKGID";
                            cmbRackGroup.DisplayMember = "RKG_Name";
                            cmbRackGroup.DataSource = objDs.Tables[0];
                        }
                    }
                }

                DataSet objDsPro = new DataSet();
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 34;
                objDsPro = objdserv.udfnMaster(objMR_Master);

                if (objDsPro != null)
                {
                    if (objDsPro.Tables.Count > 0)
                    {
                        if (objDsPro.Tables[0].Rows.Count > 0)
                        {
                            cmbProductCategory.ValueMember = "MSTID";
                            cmbProductCategory.DisplayMember = "MST_DisplayText";
                            cmbProductCategory.DataSource = objDsPro.Tables[0];
                        }
                    }
                }
                DataBind objDataBind = new DataBind(); //Transaction id 	41
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MSTID IN (" + ReportTypeIDs + ") ORDER BY MST_OrderID ASC", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,92) AND MSTID<>-1 ", "MST_DisplayText,MSTID", cmbSubgroupType, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (5,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbProductCategory, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (124)  ", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=107 ", "MST_DisplayText,MSTID", cmbFormat, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1)   Order by STSID,STS_Name", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1) OR STSID=0 Order by STSID,STS_Name", "STS_Name,STSID", cmbproductStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=133 ", "MST_DisplayText,MSTID", cmbOrderBy, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,120) AND MSTID<>-1 ", "MST_DisplayText,MSTID", cmbRetailRate, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,143) AND MSTID<>-1 ", "MST_DisplayText,MSTID", cmbStockTakken, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=144", "MST_DisplayText,MSTID", cmbLocationType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (3,0) AND MSTID<>-1 ", "MST_ShortName,MSTID", cmbShopLocType, "", "MST_ShortName", "MSTID");
                objDataBind = null;
                cmbReportType.SelectedValue = -1;
                cmbProductCategory.SelectedValue = 0;
                cmbSubgroupType.SelectedValue = 0;
                cmbStatus.SelectedValue = 1;
                cmbproductStatus.SelectedValue = 0;
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

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //txtEmployeeName.Focus();
                btnListPrint.Focus();
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
                    objDs = objspdservice.udfnEmployeeList(2, txtEmployeeName.Text.Trim(), 0, "", 0, 0, 0);
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

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                varUpDownKeyRackGroup = 0;
                cmbConcern.BackColor = Color.LemonChiffon;
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
                    if (cmbRackGroup.Enabled == true)
                    {
                        cmbRackGroup.Focus();
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

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyRackGroup = 1;
                udfnRackgroup();
                cmbSubgroupType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void CmbSubgroupType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSubgroupType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubgroupType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbProductCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubgroupType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbSubgroupType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSubgroupType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProductCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbFormat.Enabled == true)
                    {
                        cmbFormat.Focus();
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

        private void CmbProductCategory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbProductCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProductCategory.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbFormat_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbFormat.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbFormat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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

        private void CmbFormat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbFormat_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbFormat.BackColor = Color.White;
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
                    cmbproductStatus.Focus();
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

        private void btnTelegram_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList(1);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbproductStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbproductStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbproductStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbType.Enabled == true)
                    {
                        cmbType.Focus();
                    }
                    else
                    {
                        cmbRetailRate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbproductStatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbproductStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbproductStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRackGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRackGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRackGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbRackGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRackGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbProductCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRackGroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRetailRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbOrderBy_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbOrderBy.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbOrderBy_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRetailRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbOrderBy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbOrderBy_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderBy.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRetailRate_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRetailRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRetailRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbStockTakken.Enabled == true)
                    {
                        cmbStockTakken.Focus();
                    }
                    else
                    {
                        cmbShopLocType.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRetailRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbRetailRate_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbRetailRate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStockTakken_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStockTakken.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStockTakken_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStockTakken.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void cmbStockTakken_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbStockTakken_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbLocationType.Enabled == true)
                    {
                        cmbLocationType.Focus();
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

        private void cmbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                cmbStockTakken.Enabled = false;

                if (Convert.ToInt32(cmbProductCategory.SelectedValue) == 16 && Convert.ToInt32(cmbReportType.SelectedValue) != 465)
                {
                    cmbStockTakken.Enabled = true;
                }
                cmbStockTakken.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkLocBreakup_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbLocationType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbLocationType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbLocationType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbShopLocType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbLocationType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbLocationType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbLocationType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbShopLocType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbShopLocType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbShopLocType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (chkLocBreakup.Enabled == true)
                    {
                        chkLocBreakup.Focus();
                    }
                    else { btnListPrint.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbShopLocType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbShopLocType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbShopLocType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
