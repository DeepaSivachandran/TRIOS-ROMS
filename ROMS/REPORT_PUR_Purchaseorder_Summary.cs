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
    public partial class REPORT_PUR_Purchaseorder_Summary : Form
    {
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public string varRefNo = "0"; 
        public REPORT_PUR_Purchaseorder_Summary()
        {
            InitializeComponent();
        }
        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGrnstatus.Focus();
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
                LV_Supplier.Visible = false;
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
                bool varErrorFlag=false;
                if (Convert.ToString(txtDelaydays.Text) == "0")
                {
                    errGRNDetails.SetError(txtDelaydays, "Invalid delayvalue");
                    txtDelaydays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSupplier.ShowAlways = true;
                    tpSupplier.Show("Invalid delayvalue", txtDelaydays, 5000);
                    varErrorFlag = true;
                }
                if (varErrorFlag == false)
                {
                    errGRNDetails.Clear();
                    txtDelaydays.BackColor = Color.White;
                    udfnProductDetails();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        public void udfnProductDetails()
        {
            try
            {
                /* Check product group is valid or not*/
                string varId_Group = "0";
                string varGRN = "",varOrdertype="",varCity="", varSuppliername = "", varStatus="",varDtat="";
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    varSuppliername = "-All-";
                }
                else
                {
                    varSuppliername = txtSupplier.Text;
                }
                if (txtCity.Text == "")
                {
                    lblcityid.Text = "0";
                    varCity = "-All-";
                }
                else
                {
                    varCity = txtCity.Text;
                }
                if (txtDelaydays.Text == "")
                {
                    varDtat = "-All-";
                }
                else
                {
                    varDtat = txtDelaydays.Text + "Days";
                } 


                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0, varFilterTat = 0;
                varRefNo ="0";
                if (txtDelaydays.Text != "")
                {
                    varFilterTat = Convert.ToInt32(txtDelaydays.Text);
                }
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                //********** To display a data in a grid  ******************   
                int varsupplier = 0, varpono = 0, varFilter = 0; 
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                if (Convert.ToInt32(cmbReporttype.SelectedValue) == 162)
                {
                    objDs = objdserv.udfnPOEntry(8, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), 0, 0, varsupplier, varpono, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), "0", varFilter, 0, Convert.ToInt32(cmbOrdertype.SelectedValue), Convert.ToInt32(lblcityid.Text), Convert.ToInt32(varFilterTat), Convert.ToInt32(cmbGrnstatus.SelectedValue));
                    objdserv.CloseConnection();
                }
                else if (Convert.ToInt32(cmbReporttype.SelectedValue) == 163)
                {
                    objDs = objdserv.udfnPOEntry(9, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), 0, 0, varsupplier, varpono, Convert.ToInt32(lblGroupCode.Text), Convert.ToInt32(lblSubGroupCode.Text), "", "", 0, Convert.ToInt32(cmbStatus.SelectedValue), "0", varFilter, 0, Convert.ToInt32(cmbOrdertype.SelectedValue), Convert.ToInt32(lblcityid.Text), Convert.ToInt32(varFilterTat), Convert.ToInt32(cmbGrnstatus.SelectedValue));
                    objdserv.CloseConnection();
                }
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varPrint = 1;
                            if (Convert.ToInt32(cmbReporttype.SelectedValue) == 163)
                            {
                                varRefNo = objDs.Tables[0].Rows[0]["PORPT_RefNo"].ToString();
                            }
                        }
                    }
                }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    if(Convert.ToInt32(cmbReporttype.SelectedValue) == 162)
                    {
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_Summary_Report.rpt"); 
                        objBillreport.SetParameterValue("parafilter", 0);
                        objBillreport.SetParameterValue("paraSupplierid ", Convert.ToInt32(lblSupplierCode.Text));
                        objBillreport.SetParameterValue("ParaScheduleId ", Convert.ToInt32(lblschedleCode.Text));
                        objBillreport.SetParameterValue("paraStatus", Convert.ToInt32(cmbStatus.SelectedValue));
                        objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                        objBillreport.SetParameterValue("paraSupplierName", varSuppliername);
                        objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                        objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        objBillreport.SetParameterValue("paraOrdertype", Convert.ToInt32(cmbOrdertype.SelectedValue));
                        objBillreport.SetParameterValue("paraOrdertypevalue", (cmbOrdertype.Text));
                        objBillreport.SetParameterValue("paraCityid", Convert.ToInt32(lblcityid.Text));
                        objBillreport.SetParameterValue("paraCityname", (varCity));
                        objBillreport.SetParameterValue("paraDTAT", Convert.ToInt32(varFilterTat));
                        objBillreport.SetParameterValue("paraDTATvalue", (varDtat));
                        objBillreport.SetParameterValue("paraGRNstatus", Convert.ToInt32(cmbGrnstatus.SelectedValue)); 
                    }
                    else
                    { 
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_Detail_Report.rpt");

                        objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                        objBillreport.SetParameterValue("paraSupplierName", varSuppliername);
                        objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                        objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        objBillreport.SetParameterValue("paraOrdertypevalue", (cmbOrdertype.Text));
                        objBillreport.SetParameterValue("paraCityname", (varCity));
                        objBillreport.SetParameterValue("paraDTATvalue", (varDtat));
                        objBillreport.SetParameterValue("ParaRefNo", Convert.ToInt32(varRefNo), objBillreport.Subreports[0].Name.ToString()); 
                        //objBillreport.SetParameterValue("paraRefno", Convert.ToInt32(varRefNo), objBillreport.Subreports[1].Name.ToString()); 
                        objBillreport.SetParameterValue("ParaRefNo", varRefNo);
                    }
                    //objBillreport.SetParameterValue("paraGRNstatusvalue", cmbGrnstatus.Text); 
                      

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
        private void REPORT_CP_Product_Load(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.SelectedValue = 0;
                //btnListPrint.Enabled = true; 
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STSID  IN (11,13,12,27,14) AND STS_ModuleID=4 OR STSID=0  ", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID"); 
                objDataBind.BindComboBoxListSelected("DEF_Status", " STS_ModuleID=7 OR STSID=0  ", "STS_Name,STSID", cmbGrnstatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (13,0) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrdertype, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,51) AND MSTID<>0", "MST_DisplayText,MSTID", cmbReporttype, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
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


        private void TxtSupplier_Enter(object sender, EventArgs e)
        {
            try
            { 
                txtSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCity.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (LV_Supplier.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        LV_Supplier.Visible = false;
                    }
                    else
                    {
                        LV_Supplier.Focus();
                    }
                    if (LV_Supplier.Items.Count > 0)
                    {
                        LV_Supplier.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {

                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 15;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                    objMR_Supplier.paraFlag = 1;
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    //objDs = objspdservice.udfnSupplierList(15, 0, 0, 0, 0, txtSupplier.Text, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, "", "", "", 1);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString()
                                    , objDs.Tables[0].Rows[i]["SupplierName"].ToString(), objDs.Tables[0].Rows[i]["ScheduleName"].ToString()};
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.BringToFront();
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[3].Width = 0;
                                LV_Supplier.Columns[4].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    LV_Supplier.Visible = false;
                    LV_Supplier.Items.Clear();
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


        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                //TxtSupplier_Leave(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnListViewData()
        {
            try
            {
                if (txtSupplier.Text != "")
                {
                    string varsuppliername = "";
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    varsuppliername = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedleCode.Text = selectedItem.SubItems[2].Text;
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblscheduleName.Text = selectedItem.SubItems[4].Text; ;
                }
                txtCity.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                LV_Supplier.Visible = false;
            }
        }
        private void LV_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                    //TxtSupplier_Leave(sender, e);
                }
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
                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtCity.Text.Length != 0)
                {
                    objDs = objspdservice.udfnCitylist(1, txtCity.Text, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString() };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvCity.Items.Add(objList);
                                }
                                lvCity.Visible = true;
                                lvCity.BringToFront();
                            }
                        }
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
                    txtDelaydays.Focus();
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


        private void LvCity_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGrdevent();
                txtDelaydays.Focus();
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
                    txtDelaydays.Focus();
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
                if (txtCity.Text != "")
                {
                    ListViewItem selectedItem = lvCity.SelectedItems[0];
                    txtCity.Text = selectedItem.SubItems[0].Text;
                    lblcityid.Text = selectedItem.SubItems[2].Text;
                    lvCity.Visible = false;
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

        private void CmbGrnstatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupplier.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGrnstatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbGrnstatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void CmbGrnstatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbGrnstatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGrnstatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDelaydays_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDelaydays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDelaydays_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrdertype.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtDelaydays_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDelaydays.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrdertype_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbOrdertype.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrdertype_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbReporttype.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrdertype_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbOrdertype_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrdertype.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbReporttype_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbReporttype.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void CmbReporttype_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbReporttype_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReporttype_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReporttype.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtDelaydays_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void REPORT_PUR_Purchaseorder_Summary_Leave(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                SPDataService objspdservice = new SPDataService();
                result = objspdservice.udfnPurchaseEntry(4, 0, 0, "", 0, 0, "", "", "", "", null, "", "", "", "", 0, "", 0, 0, Convert.ToInt32(varRefNo));
                objspdservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
