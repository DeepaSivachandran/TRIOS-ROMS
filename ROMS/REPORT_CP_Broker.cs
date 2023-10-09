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
    public partial class REPORT_CP_Broker : Form
    {
        ToolTip tpSupplier = new ToolTip();
        private ToolTip tpCity = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public REPORT_CP_Broker()
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
                lvCity.Visible = false;
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
                bool blnErrorFlag = false;
                if (Convert.ToString(txtCity.Text) != "")
                {
                    string VarCity = "0";
                    DataSet objDsCity = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsCity = objDserv.udfnCitylist(2, txtCity.Text.Trim(), 0,0);
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
                    
                    lblcityid.Text = VarCity;
                }
                if (blnErrorFlag == false)
                {

                    if (cmbReportType.SelectedIndex == 0)
                    {
                        cmbReportType.Focus();
                    }
                    else
                    {
                        //btnListPrint.Enabled = false;
                        
                        if (cmbReportType.SelectedIndex == 1)
                        {
                            udfnContact();
                        }
                        if (cmbReportType.SelectedIndex == 2)
                        {
                            udfnAddress();
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
        public void udfnContact()
        {
            try
            {
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnBrokerList(2,0, Convert.ToInt32(cmbStatus.SelectedValue),0);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Broker_Contact.rpt");
                    objBillreport.SetParameterValue("parastatusid", Convert.ToInt32(cmbStatus.SelectedValue));
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
            }
        }
        public void udfnAddress()
        {
            try
            {
                int varcityid = 0;
                string varCityName = "";
                if(txtCity.Text=="")
                {
                    varcityid = 0;
                    varCityName = "-All-";
                }
                else
                {
                    varcityid = Convert.ToInt32(lblcityid.Text.Trim());
                }
                if (varcityid == -1 || varcityid == 0)
                {
                    varCityName = "-All-";
                }
                else { varCityName = txtCity.Text.Trim(); }
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnBrokerList(3, 0, Convert.ToInt32(cmbStatus.SelectedValue),varcityid );
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Broker_Address.rpt");
                    objBillreport.SetParameterValue("parastatusid", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paracityid", varcityid);
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraCityName", Convert.ToString(varCityName));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                    txtCity.Text = "";
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
            }
        }
        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbReportType.Select(int.MaxValue, 0)));
                if (cmbReportType.SelectedIndex == 1)
                {
                    txtCity.Enabled = false;txtCity.Text = "";
                    cmbStatus.Enabled = true;
                }
                if (cmbReportType.SelectedIndex == 2)
                {
                    txtCity.Enabled = true;
                    cmbStatus.Enabled = true;
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
                    if(txtCity.Enabled==true)
                    {
                        txtCity.Focus();
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
        private void TxtCity_Enter(object sender, EventArgs e)
        {
            try
            {
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvCity.Items.Count == 0 || txtCity.Text == "")
                    {
                        txtCity.Focus();
                        lvCity.Visible = false;
                    }
                    else
                    {
                        lvCity.Focus();
                    }
                    if (lvCity.Items.Count > 0)
                    {
                        lvCity.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                    lvCity.Visible = false;
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
            txtCity.BackColor = Color.White;
        }
        private void TxtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtCity.Text.Length > 0)
                {
                    objDs = objspdservice.udfnCitylist(1, txtCity.Text,0,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvCity.Columns[1].Width = 0;
                                    lvCity.Items.Add(objList);
                                }
                                lvCity.Visible = true;
                                lvCity.BringToFront();
                            }
                            else
                            {
                                lvCity.Visible = false;
                            }
                        }
                        else
                        {
                            lvCity.Visible = false;
                        }
                    }
                    else
                    {
                        lvCity.Visible = false;
                    }
                }
                else
                {
                    lvCity.Visible = false;
                    lvCity.Items.Clear();
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
        private void LvCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGrdevent();
                    cmbStatus.Focus();
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
                if (txtCity.Text != "")
                {
                    ListViewItem selectedItem = lvCity.SelectedItems[0];
                    txtCity.Text = selectedItem.SubItems[0].Text;
                    lblcityid.Text = selectedItem.SubItems[1].Text;
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
        private void REPORT_CP_Broker_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,36) AND MSTID<>0", "MST_DisplayText,MSTID", cmbReportType, "", "MST_DisplayText", "MSTID");
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

        private void REPORT_CP_Broker_KeyDown(object sender, KeyEventArgs e)
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
