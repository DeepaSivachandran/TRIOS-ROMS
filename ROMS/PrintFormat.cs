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

namespace ROMS
{
    public partial class PrintFormat : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpCancel = new ToolTip();
        public string varTransactionId = "0";
        public int varFormType = 0;
        public PrintFormat()
        {
            InitializeComponent();
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string varHeader = "";
                if (varFormType == 1)
                {
                    varHeader="Goods Inward Report";
                }
                if (varFormType == 2)
                {
                    varHeader = "Goods Outward Report";
                } 
                else if (varFormType == 3)
                {
                    varHeader = "Stock Transfer Report";
                }
                if (Convert.ToInt32(cmbReportFormat.SelectedValue) == 468)
                {
                    udfnTPPrint(varTransactionId, varHeader);
                }
                else
                {
                    udfnDirectPrint(varTransactionId, varHeader);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTPPrint(string varTransactionId,string varHeader)
        {
            try
            {
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                if (varFormType == 1)
                {
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_INV_GoodsInward.rpt");
                }
                else if (varFormType == 2)
                {
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_INV_GoodsOutward.rpt");
                }
                if (varFormType == 1)
                {
                    objBillreport.SetParameterValue("paraGIID", Convert.ToInt32(varTransactionId));
                    objBillreport.SetParameterValue("paraGIID", Convert.ToInt32(varTransactionId), objBillreport.Subreports[0].Name);
                }
                else if (varFormType == 2)
                {
                    objBillreport.SetParameterValue("paraGOID", Convert.ToInt32(varTransactionId));
                    objBillreport.SetParameterValue("paraGOID", Convert.ToInt32(varTransactionId), objBillreport.Subreports[0].Name);
                }
                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[0].Name);
                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[0].Name);
                objValidation.CrySqlConnection(objBillreport);

                MainForm.objReportLoad = new ReportLoad();
                MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                MainForm.objReportLoad.Text = varHeader;
                MainForm.objReportLoad.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }public void udfnDirectPrint(string varTransactionId,string varHeader)
        {
            try
            {
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                if (varFormType == 1)
                {
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_GoodsInward.rpt");
                }
                else if (varFormType == 2)
                {
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_GoodsOutward.rpt");
                }
                if (varFormType == 1)
                {
                    objBillreport.SetParameterValue("paraGIID", Convert.ToInt32(varTransactionId));
                }
                else if (varFormType == 2)
                {
                    objBillreport.SetParameterValue("paraGOID", Convert.ToInt32(varTransactionId));
                }
                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                objValidation.CrySqlConnection(objBillreport);

                MainForm.objReportLoad = new ReportLoad();
                MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                MainForm.objReportLoad.Text = varHeader;
                MainForm.objReportLoad.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Brand_Leave(object sender, EventArgs e)
        {
            try
            {
                tpCancel.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CancelReason_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID = 145", "MST_DisplayText,MSTID", cmbReportFormat, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbReportFormat.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbReportFormat_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbReportFormat.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbReportFormat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbReportFormat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbReportFormat_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReportFormat.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
