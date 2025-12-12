using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ROMS
{
    public partial class PUR_DC_PrintPopUp : Form
    {

        private SecurityController _security;
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpVerified1 = new ToolTip();
        private ToolTip tpVerified2 = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varUserId = "";
        public string varVerifiedName = "";
        public string pbDCId = "", pbstsId = "";
        public string varPasskey = "",varID="";
        public int flag = 0, verified1 = 0, verified2 = 0, varEditFlag = 0;
        int varCompanyID = 0;
        public PUR_DC_PrintPopUp()
        {

            InitializeComponent();
            _security = new SecurityController();
        }
        public string GenerateMD5(string HashString)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(HashString)).Select(s => s.ToString("x2")));
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = "0"; varCompanyID = 0;
                if (varEditFlag == 1)
                {
                    if (MainForm.objPUR_PurchaseDC.varDCID == 0)
                    {
                        ID = varID;
                    }
                    else
                    {
                        ID = Convert.ToString(MainForm.objPUR_PurchaseDC.varDCID);
                    }
                    varCompanyID = Convert.ToInt32(MainForm.objPUR_PurchaseDC.cmbConcern.SelectedValue);
                }
                else
                {
                    ID = Convert.ToString(MainForm.objPUR_PurchaseDCList.grdPurchaseDCList.SelectedRows[0].Cells["ID"].Value);
                    varCompanyID = Convert.ToInt32(MainForm.objPUR_PurchaseDCList.grdPurchaseDCList.SelectedRows[0].Cells["COMID"].Value);
                }
                if (rbThermal.Checked==true)
                {
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_PUR_PurchaseDC.rpt");
                    varHeader = "Purchase DC";

                    objBillreport.SetParameterValue("paraDCID", Convert.ToInt32(ID));
                    objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(varCompanyID));
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objValidation.CrySqlConnection(objBillreport);

                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                    MainForm.objReportLoad.Text = varHeader;
                    MainForm.objReportLoad.ShowDialog();
                    //MainForm.objPUR_DC_PrintPopUp.Close();
                }
                else if (rbA4Print.Checked==true)
                {
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_DC.rpt");
                    varHeader = "Purchase DC";

                    objBillreport.SetParameterValue("paraDCID", Convert.ToInt32(ID));
                    objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(varCompanyID));
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objValidation.CrySqlConnection(objBillreport);

                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                    MainForm.objReportLoad.Text = varHeader;
                    MainForm.objReportLoad.ShowDialog();
                    //MainForm.objPUR_DC_PrintPopUp.Close();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                errVerified.Clear();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_GRN_Level_Verified_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void PUR_GRN_Level_Verified_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    //btnAuthorise_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
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
