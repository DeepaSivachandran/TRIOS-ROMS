using ROMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ROMS
{
    public partial class PUR_POScheduledaywise : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_POScheduledaywise()
        {
            InitializeComponent();
            MainForm.objPUR_SupplierScheduleList.picLoader.Visible = false;
        }

        private void PUR_POScheduledaywise_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind(); 
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (5,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbProductCategory, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (151,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbCmbReportType, "", "MST_DisplayText", "MSTID");
                cmbConcern.DataSource = null;
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();
                
                objDT = objdserv.udfnCompanyList(2, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDT.Tables[0];
                        }
                    }
                }
                objdserv.CloseConnection();
                objDataBind = null;
                chkReportType.DrawMode = DrawMode.Normal;
                udfnDropDownBind();
                udfnList();
                pnlRateCategory.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex); 
            }
        }
        public void udfnDropDownBind()
        {
            try
            {
                txtReportType.Text = "";
                if (Convert.ToInt32(cmbProductCategory.SelectedValue) != 0 && Convert.ToInt32(cmbProductCategory.SelectedValue) != 13 && Convert.ToInt32(cmbProductCategory.SelectedValue) != 15)
                {
                    txtReportType.Enabled = true;
                    int varFlag = 0;
                    if (Convert.ToInt32(cmbProductCategory.SelectedValue) == 14 || Convert.ToInt32(cmbProductCategory.SelectedValue) == 16)
                    {
                        varFlag = 1;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 35;
                    objMR_Master.paraFlag = varFlag;
                    DataSet objDTable = new DataSet();
                    SPDataService objdSer = new SPDataService();
                    objDTable = objdSer.udfnMaster(objMR_Master);
                    objdSer.CloseConnection();
                    if (objDTable != null)
                    {
                        if (objDTable.Tables.Count > 0)
                        {
                            if (objDTable.Tables[0].Rows.Count > 0)
                            {
                                chkReportType.DrawMode = DrawMode.Normal;
                                chkReportType.FormattingEnabled = true;
                                chkReportType.DisplayMember = "MST_DisplayText";
                                chkReportType.ValueMember = "MSTID";
                                chkReportType.DataSource = objDTable.Tables[0];

                                DataView dv = objDTable.Tables[0].DefaultView;
                                dv.RowFilter = "MSTID <> 0";

                                DataTable dt = dv.ToTable();


                                dt = objDTable.Tables[0];

                                chkReportType.DataSource = dt;
                                chkReportType.DisplayMember = "MST_DisplayText";   // text
                                chkReportType.ValueMember = "MSTID";       // value

                            }
                        }
                    }
                }
                else
                {
                    txtReportType.Enabled = false;
                    lblReportTypeId.Text = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnList()
        {
            try
            {
                string varReportTypes = "0";
                if (chkReportType.CheckedItems.Count == chkReportType.Items.Count)
                {
                    varReportTypes = "0";
                }
                else
                {
                    varReportTypes = lblReportTypeId.Text;
                }
                pnlRateCategory.Visible = false;
                grdHeaderview.DataSource = null;
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 9;
                objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Supplier.paraProductCategory = Convert.ToInt32( cmbProductCategory.SelectedValue);
                //objMR_Supplier.paraFlag = Convert.ToInt32( cmbCmbReportType.SelectedValue);
                objMR_Supplier.paraReportFlag = varReportTypes;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService(); 
                objDs = objdserv.udfnSupplierList(objMR_Supplier);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    { 
                        if (objDs.Tables[0].Rows.Count != 0)
                        { 
                            grdHeaderview.DataSource = objDs.Tables[0];
                            foreach (DataGridViewColumn column in grdHeaderview.Columns)
                            {
                                if (column.Index > 1)  
                                {
                                    column.Width = 230;
                                }
                            }
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            grdPOSchedule.DataSource = objDs.Tables[1];
                            grdPOSchedule.Columns["DYID"].Visible = false;
                            foreach (DataGridViewColumn column in grdPOSchedule.Columns)
                            {
                                if (column.Index > 1)
                                {
                                    column.Width = 85;
                                }
                                string[] parts = column.HeaderText.Split('-');
                                 
                                if (parts.Length > 1)
                                { 
                                    column.HeaderText = parts[parts.Length - 1];
                                }
                            } 
                            if (grdPOSchedule.Rows.Count > 0) // Check if there are any rows
                            {
                                grdPOSchedule.Rows[grdPOSchedule.Rows.Count - 1].Cells[1].Value = null;
                                grdPOSchedule.Rows[grdPOSchedule.Rows.Count - 1].Cells["S.No."].Value = "";
                                grdPOSchedule.Columns["clmPrint8"].DisplayIndex = grdPOSchedule.Columns.Count - 3;
                                grdPOSchedule.Columns["clmPrint8"].Width = 30;
                                grdPOSchedule.Columns["clmPrint7"].DisplayIndex = grdPOSchedule.Columns.Count - 5;
                                grdPOSchedule.Columns["clmPrint7"].Width = 30;
                                grdPOSchedule.Columns["clmPrint6"].DisplayIndex = grdPOSchedule.Columns.Count - 7;
                                grdPOSchedule.Columns["clmPrint6"].Width = 30;
                                grdPOSchedule.Columns["clmPrint5"].DisplayIndex = grdPOSchedule.Columns.Count - 9;
                                grdPOSchedule.Columns["clmPrint5"].Width = 30;
                                grdPOSchedule.Columns["clmPrint4"].DisplayIndex = grdPOSchedule.Columns.Count - 11;
                                grdPOSchedule.Columns["clmPrint4"].Width = 30;
                                grdPOSchedule.Columns["clmPrint3"].DisplayIndex = grdPOSchedule.Columns.Count - 13;
                                grdPOSchedule.Columns["clmPrint3"].Width = 30;
                                grdPOSchedule.Columns["clmPrint2"].DisplayIndex = grdPOSchedule.Columns.Count - 15;
                                grdPOSchedule.Columns["clmPrint2"].Width = 30;
                                grdPOSchedule.Columns["clmPrint1"].DisplayIndex = grdPOSchedule.Columns.Count - 17;
                                grdPOSchedule.Columns["clmPrint1"].Width = 30;
                                grdPOSchedule.Columns["S.No."].Width = 50;
                                grdPOSchedule.Columns["Order Day"].Width = 100;
                                //grdPOSchedule.Columns["clmPrint1"].DisplayIndex = 4;
                                //grdPOSchedule.Columns["clmPrint2"].DisplayIndex = 5;
                                //grdPOSchedule.Columns["clmPrint3"].DisplayIndex = 8;
                                //grdPOSchedule.Columns["clmPrint4"].DisplayIndex = 9;
                                //grdPOSchedule.Columns["clmPrint5"].DisplayIndex = 12;
                                //grdPOSchedule.Columns["clmPrint6"].DisplayIndex = 13;
                                grdPOSchedule.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns["Order Day"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                grdPOSchedule.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPOSchedule.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                        if (objDs.Tables[2].Rows.Count != 0)
                        {
                            
                            if (grdPOSchedule.Rows.Count > 0 && grdPOSchedule.Columns.Count >= 2)
                            { 
                                DataGridViewRow lastRow = grdPOSchedule.Rows[grdPOSchedule.Rows.Count - 1]; 
                                DataGridViewCell beforeLastCell = lastRow.Cells[lastRow.Cells.Count - 2];
                                beforeLastCell.Value = Convert.ToString(objDs.Tables[2].Rows[0]["SuppCount"].ToString().Replace("''", "'")); ; 
                                DataGridViewCell lastCell = lastRow.Cells[lastRow.Cells.Count - 1];
                                lastCell.Value = Convert.ToString(objDs.Tables[2].Rows[0]["ProCount"].ToString().Replace("''", "'")); ;
                            } 
                        }
                        //grdPOSchedule.Rows[7].DefaultCellStyle.BackColor = Color.MistyRose;
                        //grdPOSchedule.Rows[7].DefaultCellStyle.ForeColor = Color.Black;
                        grdPOSchedule.Rows[7].DefaultCellStyle.BackColor = Color.RosyBrown;
                        grdPOSchedule.Rows[7].DefaultCellStyle.ForeColor = Color.White;
                        foreach (DataGridViewColumn column in grdHeaderview.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        foreach (DataGridViewColumn column in grdPOSchedule.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
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
                grdPOSchedule.ClearSelection();
            }
        }

        private void BtnPrintdaywise_Enter(object sender, EventArgs e)
        {
            try
            {
                btnPrintdaywise.BackColor = Color.LemonChiffon;
                pnlRateCategory.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPrintdaywise_Leave(object sender, EventArgs e)
        {
            try
            {
                btnPrintdaywise.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void BtnPrintdaywise_Click(object sender, EventArgs e)
        {
            try
            {
                try
                { 
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument(); 
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_SupplierScheduleProductDayWise.rpt"); 
                    varHeader = "Day Wise Supplier List";
                    objBillreport.SetParameterValue("@paracompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("@paraProductCategory", Convert.ToInt32(cmbProductCategory.SelectedValue));
                    //objBillreport.SetParameterValue("@paraFlag", Convert.ToInt32(cmbCmbReportType.SelectedValue)); 
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
                finally
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void PUR_POScheduledaywise_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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

        private void GrdPOSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    int varDYID = 0;
                    //if (e.ColumnIndex == grdPOSchedule.Rows.Count - 1)
                    //{
                    //    varDYID = Convert.ToInt32(grdPOSchedule.SelectedRows[0].Cells["DYID"].Value.ToString());
                    //}
                    if (e.RowIndex == 7)
                    {
                        varDYID = 0;
                    }
                    else
                    {
                        //varDYID = Convert.ToInt32(grdPOSchedule.SelectedRows[0].Cells["DYID"].Value.ToString());
                          varDYID = Convert.ToInt32(  grdPOSchedule.CurrentRow.Cells["DYID"].Value);

                    }
                    string varHeader = "";
                    string varReportTypes = "0";
                    if (chkReportType.CheckedItems.Count == chkReportType.Items.Count)
                    {
                        varReportTypes = "0";
                    }
                    else
                    {
                        varReportTypes = lblReportTypeId.Text;
                    }
                    switch (grdPOSchedule.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPrint1": case "clmPrint3": case "clmPrint5": case "clmPrint7":
                            string varOrderTypeName = "";
                            int varOrderId = 0;
                            if (grdPOSchedule.Columns[e.ColumnIndex].Name == "clmPrint1") {
                                varOrderTypeName= grdHeaderview.Columns[2].Name;
                            }
                            if (grdPOSchedule.Columns[e.ColumnIndex].Name == "clmPrint3")
                            {
                                varOrderTypeName = grdHeaderview.Columns[3].Name;
                            }
                            if (grdPOSchedule.Columns[e.ColumnIndex].Name == "clmPrint5")
                            {
                                varOrderTypeName = grdHeaderview.Columns[4].Name;
                            }
                            if (grdPOSchedule.Columns[e.ColumnIndex].Name == "clmPrint7")
                            {
                                varOrderTypeName = grdHeaderview.Columns[5].Name;
                            }
                            if (varOrderTypeName != "") {
                                MR_Master objMR_Master = new MR_Master();
                                objMR_Master.ViewType = 11;
                                objMR_Master.paraID = 13;
                                objMR_Master.paraText = varOrderTypeName;
                                DataSet objDs = new DataSet();
                                SPDataService objDserv = new SPDataService();
                                objDs = objDserv.udfnMaster(objMR_Master);
                                objDserv.CloseConnection();
                                if (objDs != null) {
                                    if (objDs.Tables.Count > 0) {
                                        varOrderId = Convert.ToInt32(objDs.Tables[0].Rows[0]["MSTID"]);
                                    }
                                }
                            }
                            CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            objBillreport1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            objBillreport1.Load(Application.StartupPath + "\\Reports\\RPT_PUR_SupplierScheduleProductDayWise.rpt");
                            varHeader = "Day Wise Supplier List";
                            objBillreport1.SetParameterValue("@paracompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                            objBillreport1.SetParameterValue("paraProductCategory", Convert.ToString(cmbProductCategory.SelectedValue));
                            objBillreport1.SetParameterValue("paraReportFlag", varReportTypes);
                            objBillreport1.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreport1.SetParameterValue("paraUserName", MainForm.pbUserName);
                            objBillreport1.SetParameterValue("@pardayid", varDYID);
                            objBillreport1.SetParameterValue("paraOrderId", varOrderId);
                            objValidation.CrySqlConnection(objBillreport1);

                            MainForm.objReportLoad = new ReportLoad();
                            MainForm.objReportLoad.cryptview.ReportSource = objBillreport1;
                            MainForm.objReportLoad.Text = varHeader;
                            MainForm.objReportLoad.ShowDialog();
                            break;
                        case "clmPrint2": case "clmPrint4":  case "clmPrint6": case "clmPrint8":
                            varOrderTypeName = "";
                            varOrderId = 0;
                            if (grdPOSchedule.Columns[e.ColumnIndex].Name == "clmPrint2")
                            {
                                varOrderTypeName = grdHeaderview.Columns[2].Name;
                            }
                            if (grdPOSchedule.Columns[e.ColumnIndex].Name == "clmPrint4")
                            {
                                varOrderTypeName = grdHeaderview.Columns[3].Name;
                            }
                            if (grdPOSchedule.Columns[e.ColumnIndex].Name == "clmPrint6")
                            {
                                varOrderTypeName = grdHeaderview.Columns[4].Name;
                            }
                            if (grdPOSchedule.Columns[e.ColumnIndex].Name == "clmPrint8")
                            {
                                varOrderTypeName = grdHeaderview.Columns[5].Name;
                            }
                            if (varOrderTypeName != "")
                            {
                                MR_Master objMR_Master = new MR_Master();
                                objMR_Master.ViewType = 11;
                                objMR_Master.paraID = 13;
                                objMR_Master.paraText = varOrderTypeName;
                                DataSet objDs = new DataSet();
                                SPDataService objDserv = new SPDataService();
                                objDs = objDserv.udfnMaster(objMR_Master);
                                objDserv.CloseConnection();
                                if (objDs != null)
                                {
                                    if (objDs.Tables.Count > 0)
                                    {
                                        varOrderId = Convert.ToInt32(objDs.Tables[0].Rows[0]["MSTID"]);
                                    }
                                }
                            }
                            int varlanguage = 0;
                            if (rbEnglish.Checked == true)
                            {
                                varlanguage = 1;
                            }
                            else { varlanguage = 2; }
                            CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_SupplierProductList.rpt");
                            objBillreport.SetParameterValue("@paracompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                            objBillreport.SetParameterValue("paraProductCategory", Convert.ToString(cmbProductCategory.SelectedValue));
                            objBillreport.SetParameterValue("paraReportFlag", varReportTypes);
                            objBillreport.SetParameterValue("@paraOrderID", varOrderId);
                            objBillreport.SetParameterValue("@parascheduleid", 0);
                            objBillreport.SetParameterValue("@parasupplierid", 0);
                            objBillreport.SetParameterValue("@paraProductType", varlanguage);
                            objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                            objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                            objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                            objBillreport.SetParameterValue("pardayid", varDYID);
                            objValidation.CrySqlConnection(objBillreport);
                            MainForm.objReportLoad = new ReportLoad();
                            MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                            MainForm.objReportLoad.Text = varHeader;
                            MainForm.objReportLoad.ShowDialog();
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void cmbConcern_Enter(object sender, EventArgs e)
        {
            try
            { 
                cmbConcern.BackColor = Color.LemonChiffon;
                pnlRateCategory.Visible = false;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbConcern_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
            }
            catch (Exception ex) 
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSchedulePopup_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbConcern_Leave(object sender, EventArgs e)
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

        private void cmbProductCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProductCategory.BackColor = Color.LemonChiffon;
                pnlRateCategory.Visible = false;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtReportType.Enabled == true)
                    {
                        txtReportType.Focus();
                    }
                    else
                    {
                        btnSchedulePopup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductCategory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbProductCategory_Leave(object sender, EventArgs e)
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
        private void cmbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnDropDownBind();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtReportType_Enter(object sender, EventArgs e)
        {
            try
            {
                pnlRateCategory.Visible = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtReportType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSchedulePopup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtReportType_Leave(object sender, EventArgs e)
        {
            try
            {
                //pnlRateCategory.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkboxRatelist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                BeginInvoke((MethodInvoker)UpdateSelectedValues);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void UpdateSelectedValues()
        {
            try
            {
                List<string> texts = new List<string>();
                List<string> ids = new List<string>();

                foreach (DataRowView row in chkReportType.CheckedItems)
                {
                    int id = Convert.ToInt32(row["MSTID"]);

                    // ignore -All- in textbox
                    if (id == 0) continue;

                    texts.Add(row["MST_DisplayText"].ToString());
                    ids.Add(id.ToString());
                }

                // TextBox (RR, WR)
                txtReportType.Text = texts.Count > 0
                    ? string.Join(", ", texts)
                    : "";

                // Label (447,448)
                lblReportTypeId.Text = ids.Count > 0
                    ? string.Join(",", ids)
                    : "0";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void chkboxRatelist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSchedulePopup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnConditionClear_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < chkReportType.Items.Count; i++)
                {
                    chkReportType.SetItemChecked(i, false);
                }

                txtReportType.Text = "";
                lblReportTypeId.Text = "0";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
