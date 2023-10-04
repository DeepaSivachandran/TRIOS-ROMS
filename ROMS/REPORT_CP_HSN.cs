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
    public partial class REPORT_CP_HSN : Form
    {
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public REPORT_CP_HSN()
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
                    //btnListPrint.Enabled = false;
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    if (cmbReportType.SelectedIndex == 1)
                    {
                        udfnHSN();
                    }
                    if (cmbReportType.SelectedIndex == 2)
                    {
                        udfnHSNProduct();
                    }
                    if (cmbReportType.SelectedIndex == 3)
                    {
                        udfnHSNSubgroup();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHSN()
        {
            try
            {
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_HSN_Master.rpt");
                objBillreport.SetParameterValue("parastatusid", Convert.ToString(cmbStatus.SelectedValue));
                objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                objValidation.CrySqlConnection(objBillreport);
                RPTViewer.ReportSource = objBillreport;
                RPTViewer.Refresh();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHSNProduct()
        {
            try
            {
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_HSN_Product.rpt");
                objBillreport.SetParameterValue("paraHSNID", Convert.ToString(cmbHSN.SelectedValue));
                objBillreport.SetParameterValue("paraGSTID", Convert.ToString(cmbGST.SelectedValue));
                objBillreport.SetParameterValue("paraStatusID", Convert.ToString(cmbStatus.SelectedValue));
                objBillreport.SetParameterValue("paraHSNName", Convert.ToString(cmbHSN.Text));
                objBillreport.SetParameterValue("paraGSTName", Convert.ToString(cmbGST.Text));
                objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                objValidation.CrySqlConnection(objBillreport);
                RPTViewer.ReportSource = objBillreport;
                RPTViewer.Refresh();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHSNSubgroup()
        {
            try
            {
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_HSN_Subgroup.rpt");
                objBillreport.SetParameterValue("paraHSNID", Convert.ToString(cmbHSN.SelectedValue));
                objBillreport.SetParameterValue("paraGSTID", Convert.ToString(cmbGST.SelectedValue));
                objBillreport.SetParameterValue("paraHSNName", Convert.ToString(cmbHSN.Text));
                objBillreport.SetParameterValue("paraGSTName", Convert.ToString(cmbGST.Text));
                objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                objValidation.CrySqlConnection(objBillreport);
                RPTViewer.ReportSource = objBillreport;
                RPTViewer.Refresh();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void REPORT_CP_HSN_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,35) AND MSTID<>0", "MST_DisplayText,MSTID", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("MR_HSN", "HSNID NOT IN (-1)", "HSN_Name,HSNID", cmbHSN, "", "HSN_Name", "HSNID");
                objDataBind.BindComboBoxListSelected("DEF_GST", " GSTID  NOT IN (-1)", "GST_Text,GSTID", cmbGST, "", "GST_Text", "GSTID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                cmbReportType.SelectedValue = -1;
                cmbHSN.SelectedValue = 0;
                cmbGST.SelectedValue = 0;
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
        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbReportType.Select(int.MaxValue, 0)));
                if(cmbReportType.SelectedIndex==1)
                {
                    cmbHSN.Enabled = false;
                    cmbGST.Enabled = false;
                    cmbStatus.Enabled = true;
                }
                if(cmbReportType.SelectedIndex==2)
                {
                    cmbHSN.Enabled = true;
                    cmbGST.Enabled = true;
                    cmbStatus.Enabled = true;
                }
                if(cmbReportType.SelectedIndex==3)
                {
                    cmbHSN.Enabled = true;
                    cmbGST.Enabled = true;
                    cmbStatus.Enabled = false;
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
                    if (cmbHSN.Enabled == true)
                    {
                        cmbHSN.Focus();
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
        private void CmbHSN_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbHSN.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbHSN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGST.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbHSN_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbHSN_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbHSN.BackColor = Color.White;
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
                    if (cmbStatus.Enabled == true)
                    {
                        cmbStatus.Focus();
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
    }
}
