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
    public partial class REPORT_CP_Brand : Form
    {
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public REPORT_CP_Brand()
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
                lvBrand.Visible = false;
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
                    //btnListPrint.Enabled = false;
                    
                    if (cmbReportType.SelectedIndex == 1)
                    {
                        udfnSubgroup();
                    }
                    if (cmbReportType.SelectedIndex == 2)
                    {
                       udfnProduct();
                    }
                    if (cmbReportType.SelectedIndex == 3)
                    {
                        udfnBrand();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBrand()
        {
            try
            {
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                RPTViewer.ReuseParameterValuesOnRefresh = true;
                RPTViewer.RefreshReport();
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Brand.rpt");
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
        public void udfnSubgroup()
        {
            try
            {
                string varId_Brand = "0";
                if (txtBrand.Text == "")
                {
                    varId_Brand = "0";
                    txtBrand.Text = "-All-";
                }
                else
                {
                    DataSet objDsBrand = new DataSet();
                    SPDataService objDServ2 = new SPDataService();
                    objDsBrand = objDServ2.udfnBrandList(8, "", 0, 0, 0, txtBrand.Text.Trim());
                    objDServ2.CloseConnection();
                    if (objDsBrand != null)
                    {
                        if (objDsBrand.Tables.Count > 0)
                        {
                            if (objDsBrand.Tables[0].Rows.Count > 0)
                            {
                                varId_Brand = Convert.ToString(objDsBrand.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_Brand == "-1")
                {
                    RPTViewer.Refresh();
                    lblNoRecordsFound.Visible = true;
                    RPTViewer.SendToBack();
                 }
                else
                {
                    lblBrandCode.Text = Convert.ToString(varId_Brand);


                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Brand_Subgroup.rpt");
                    objBillreport.SetParameterValue("paraBrandID", Convert.ToString(lblBrandCode.Text));
                    objBillreport.SetParameterValue("paraBrandName", Convert.ToString(txtBrand.Text));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToString(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                    txtBrand.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProduct()
        {
            try
            {

                /* Check product sub group is valid or not*/
                string varId_SubGroup = "0";
                if (txtSubGroup.Text == "")
                {
                    varId_SubGroup = "0";
                    txtSubGroup.Text = "-All-";
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
                if (varId_SubGroup == "-1")
                {
                    RPTViewer.Refresh();
                    lblNoRecordsFound.Visible = true;
                    RPTViewer.SendToBack();
                }
                lblSubGroupCode.Text = Convert.ToString(varId_SubGroup);

                /* Check product group is valid or not*/
                string varId_Group = "0";
                if (txtGroup.Text == "")
                {
                    varId_Group = "0";
                    txtGroup.Text = "-All-";
                }
                else
                {
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(),0);
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
                if (varId_Group == "-1")
                {
                    RPTViewer.Refresh();
                    lblNoRecordsFound.Visible = true;
                    RPTViewer.SendToBack();
                }
                lblGroupCode.Text = Convert.ToString(varId_Group);

                /* Check product brand is valid or not*/
                string varId_Brand = "0";
                if (txtBrand.Text == "")
                {
                    varId_Brand = "0";
                    txtBrand.Text = "-All-";
                }
                else
                {
                    DataSet objDsBrand = new DataSet();
                    SPDataService objDServ2 = new SPDataService();
                    objDsBrand = objDServ2.udfnBrandList(8, "", 0, 0, 0, txtBrand.Text.Trim());
                    objDServ2.CloseConnection();
                    if (objDsBrand != null)
                    {
                        if (objDsBrand.Tables.Count > 0)
                        {
                            if (objDsBrand.Tables[0].Rows.Count > 0)
                            {
                                varId_Brand = Convert.ToString(objDsBrand.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (varId_Brand == "-1")
                {
                    RPTViewer.Refresh();
                    lblNoRecordsFound.Visible = true;
                    RPTViewer.SendToBack();
                }
                lblBrandCode.Text = Convert.ToString(varId_Brand);

                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                RPTViewer.ReuseParameterValuesOnRefresh = true;
                RPTViewer.RefreshReport();
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Brand_Product.rpt");
                objBillreport.SetParameterValue("paraBrandId", Convert.ToString(lblBrandCode.Text));
                objBillreport.SetParameterValue("paraBrandName", Convert.ToString(txtBrand.Text));
                objBillreport.SetParameterValue("paraGroupId", Convert.ToString(lblGroupCode.Text));
                objBillreport.SetParameterValue("paraGroupName", Convert.ToString(txtGroup.Text));
                objBillreport.SetParameterValue("paraSubgroupId", Convert.ToString(lblSubGroupCode.Text));
                objBillreport.SetParameterValue("paraSubGroupName", Convert.ToString(txtSubGroup.Text));
                objBillreport.SetParameterValue("parastatusid", Convert.ToString(cmbStatus.SelectedValue));
                objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                objValidation.CrySqlConnection(objBillreport);
                RPTViewer.ReportSource = objBillreport;
                RPTViewer.Refresh();
                txtGroup.Text = "";
                txtSubGroup.Text = "";
                txtBrand.Text = "";
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
                    txtBrand.Enabled = true;
                    txtGroup.Enabled = false;txtGroup.Text = "";
                    txtSubGroup.Enabled = false;txtSubGroup.Text = "";
                }
                if(cmbReportType.SelectedIndex==2)
                {
                    txtBrand.Enabled = true;
                    txtGroup.Enabled = true;
                    txtSubGroup.Enabled = true;
                }
                if(cmbReportType.SelectedIndex==3)
                {
                    txtBrand.Enabled = false;txtBrand.Text = "";
                    txtGroup.Enabled = false;txtGroup.Text = "";
                    txtSubGroup.Enabled = false;txtSubGroup.Text = "";
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
                    if (txtBrand.Enabled == true)
                    {
                        txtBrand.Focus();
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

        private void REPORT_CP_Brand_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,37) AND MSTID<>0", "MST_DisplayText,MSTID", cmbReportType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                cmbReportType.SelectedValue = -1;
                //cmbHSN.SelectedValue = 0;
                //cmbGST.SelectedValue = 0;
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

        private void TxtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
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
                    txtGroup.Focus();
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
                    objDs = objspdservice.udfnSubGroupList(8, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 10.75F);
                                    lvSubGroup.Items.Add(objList);
                                }
                                lvSubGroup.Visible = true;
                                lvSubGroup.BringToFront();
                            }
                        }
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
                    txtGroup.Focus();
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
                    txtGroup.Text = selectedItem.SubItems[4].Text;
                    lblGroupCode.Text = selectedItem.SubItems[5].Text;
                    //string varbatchenable = selectedItem.SubItems[3].Text;
                    lvSubGroup.Visible = false;
                    //if (varbatchenable == "72")
                    //{
                    //    cmbBatchNoEntry.SelectedValue = 72;
                    //}
                    //else
                    //{
                    //    cmbBatchNoEntry.SelectedValue = 73;
                    //}
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
            }
        }

        private void TxtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.LemonChiffon;
                lvGroup.Visible = false;
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
                    cmbStatus.Focus();
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
                    objDs = objspdservice.udfnGroupList(7, 0, Convert.ToInt32(lblSubGroupCode.Text), txtGroup.Text.Trim(),0);
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
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 10.75F);
                                    lvGroup.Items.Add(objList);
                                }
                                lvGroup.Visible = true;
                                lvGroup.BringToFront();
                            }
                        }
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
                    txtBrand.Focus();
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
            }
        }

        private void TxtBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvBrand.Items.Count == 0 || txtBrand.Text == "")
                    {
                        txtBrand.Focus();
                        lvBrand.Visible = false;
                    }
                    else
                    {
                        lvBrand.Focus();
                    }
                    if (lvBrand.Items.Count > 0)
                    {
                        lvBrand.Items[0].Selected = true;
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

        private void TxtBrand_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBrand.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtBrand.Text.Length > 0)
                {
                    objDs = objspdservice.udfnBrandList(6, "0", 0, 0, 0, txtBrand.Text.Trim());
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["BD_EName"].ToString(), objDs.Tables[0].Rows[i]["BD_TName"].ToString(), objDs.Tables[0].Rows[i]["BDID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 10.75F);
                                    lvBrand.Items.Add(objList);
                                }
                                lvBrand.Visible = true;
                                lvBrand.BringToFront();
                            }
                        }
                    }
                }
                else
                {
                    lvBrand.Visible = false;
                    lvBrand.Items.Clear();
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

        private void LvBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnBrandAutocomplete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvBrand_DoubleClick(object sender, EventArgs e)
        {
            udfnBrandAutocomplete();
        }
        public void udfnBrandAutocomplete()
        {
            try
            {
                if (txtBrand.Text != "")
                {
                    ListViewItem selectedItem = lvBrand.SelectedItems[0];
                    txtBrand.Text = selectedItem.SubItems[0].Text;
                    lblBrandCode.Text = selectedItem.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtBrand.Focus();
                lvBrand.Visible = false;
            }
        }

        private void REPORT_CP_Brand_KeyDown(object sender, KeyEventArgs e)
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
