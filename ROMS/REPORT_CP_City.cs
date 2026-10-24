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
    public partial class REPORT_CP_City : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        private List<ComboItem> transports;
        public int varUpDownKey = 0;
        public REPORT_CP_City()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tpCityReport, this);
        }
        

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbDelivery.Select(int.MaxValue, 0)));
                try
                {
                    ////cmbApplicable = 509 is  other shop type
                    if (Convert.ToInt32(cmbDelivery.SelectedValue) == 509)
                    {
                        cmbTransPref.Enabled = false;
                        lblTransports.Text = "";
                        cmbTransPref.ClearAll();
                    }
                    else
                    {
                        cmbTransPref.Enabled = true;
                    }

                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
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
                udfnCity();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public void udfnCity()
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtCity.Text) != "")
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

                    lblcityid.Text = VarCity;
                }
                string varTransportIds = "", varTransportName = "";
                var selIds = cmbTransPref.CheckedIds;
                var selItems = transports.Where(m => selIds.Contains(m.Id)).ToList();
                lblTransports.Text = string.Join(",", selItems.Select(x => x.Text));
                varTransportName = lblTransports.Text;
                varTransportIds = string.Join(",", selItems.Select(x => x.Id));
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                int viewType = 3;
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 360) {
                    viewType = 7;
                }
                int varcityid = 0;
                if (txtCity.Text == "")
                {
                    varcityid = 0; 
                }
                else
                {
                    varcityid = Convert.ToInt32(lblcityid.Text.Trim());
                }
                objDs = objspservice.udfnCitylist(viewType, "", 0,0, varcityid, Convert.ToInt32(cmbSalesApplicable.SelectedValue), Convert.ToInt32(cmbDelivery.SelectedValue),varTransportIds);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    ///////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (Convert.ToInt32(cmbReportType.SelectedValue) == 360)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Sales_Applicable_City.rpt");
                        objBillreport.SetParameterValue("paraSalesApplicable", Convert.ToInt32(cmbSalesApplicable.SelectedValue));
                        objBillreport.SetParameterValue("paraDeliveryPref", Convert.ToInt32(cmbDelivery.SelectedValue));
                        objBillreport.SetParameterValue("paraCityId", varcityid);
                        objBillreport.SetParameterValue("paraTransportIds", varTransportIds); 
                    }
                    else
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_City.rpt");
                    }
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
        private void REPORT_CP_City_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80101;
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=4 OR MSTID = 0 Order by MSTID", "MST_DisplayText,MSTID", cmbSalesApplicable, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=158 OR MSTID = 0 Order by MSTID", "MST_DisplayText,MSTID", cmbDelivery, "", "MST_DisplayText", "MSTID");
                 
                 
                //Transaction id 	36
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (108) ", "MST_DisplayText,MSTID,MST_ShortName", cmbReportType, "", "MST_DisplayText", "MSTID");

                objDataBind = null;
                cmbDelivery.SelectedValue = 0;
                cmbSalesApplicable.SelectedValue = 0;
                cmbReportType.SelectedIndex = 0;
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
                udfnLoadTrasnport();
                udfnCity();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadTrasnport()
        {
            try
            {
                lblTransports.Text = "";
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 44;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspdservice.udfnMaster(objMR_Master);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
                    {
                        transports = objDs.Tables[0].AsEnumerable()
                            .Select(r => new ComboItem
                            {
                                Id = r.Field<int>("PreferenceID"),
                                Text = r.Field<string>("Preference")
                            })
                            .ToList();
                        cmbTransPref.LoadItems(transports, "Select Transport");
                    }

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void REPORT_CP_City_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbReportType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCity.Enabled == true)
                    {

                        txtCity.Focus();
                    }
                    else {
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

        private void cmbReportType_Leave(object sender, EventArgs e)
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

        private void cmbReportType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbReportType_Enter(object sender, EventArgs e)
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

        private void Common_Enter(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = sender as ComboBox;

                if (cmb != null)
                {
                    string comboName = cmb.Name;

                    if (comboName == "cmbSalesApplicable")
                    {
                        cmbSalesApplicable.BackColor = Color.LemonChiffon;
                    }
                    else if (comboName == "cmbTransPref")
                    {
                        cmbTransPref.BackColor = Color.LemonChiffon;
                    }
                    else if (comboName == "cmbDelivery")
                    {
                        cmbDelivery.BackColor = Color.LemonChiffon;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Common_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ComboBox cmb = sender as ComboBox;

                if (cmb != null)
                {
                    string comboName = cmb.Name;

                    if (comboName == "cmbSalesApplicable")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            cmbDelivery.Focus();
                        }
                    }
                    else if (comboName == "cmbDelivery")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (cmbTransPref.Enabled == true) {
                                cmbTransPref.Focus();
                            }
                            else
                            {
                                btnListPrint.Focus();
                            }
                        }
                    }
                    else if (comboName == "cmbTransPref")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            btnListPrint.Focus();
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

        private void Common_Leave(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = sender as ComboBox;

                if (cmb != null)
                {
                    string comboName = cmb.Name;

                    if (comboName == "cmbSalesApplicable")
                    {
                        cmbSalesApplicable.BackColor = Color.White;
                    }
                    else if (comboName == "cmbTransPref")
                    {
                        cmbTransPref.BackColor = Color.White;
                    }
                    else if (comboName == "cmbDelivery")
                    {
                        cmbDelivery.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Common_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCity_Enter(object sender, EventArgs e)
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
        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            /*
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
            */
            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    //if (lvproduct.Items.Count == 0 && txtProductName.Text == "")
                    //{
                    //    txtMrp.Focus();
                    //    lvproduct.Visible = false;
                    //}
                    //else
                    //{
                    //    lvproduct.Focus();
                    //}
                    //if (lvproduct.Items.Count > 0)
                    //{
                    //    lvproduct.Items[0].Selected = true;
                    //}
                    DGV_FilterProduct.Focus();

                }
                //if (e.KeyCode == Keys.Enter)
                //{
                //    txtMrp.Focus();
                //}
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    cmbSalesApplicable.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterProduct.Focus();
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtCity.Text = DGV_FilterProduct.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }
                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtCity.Text = DGV_FilterProduct.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnGrdevent();
                                    DGV_FilterProduct.Visible = false;
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
                        cmbSalesApplicable.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtCity_Leave(object sender, EventArgs e)
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
        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    //lvCity.Items.Clear();
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
                                    DGV_FilterProduct.Visible = true;
                                    //for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    //{
                                    //    string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString() };
                                    //    ListViewItem objList = new ListViewItem(row);
                                    //    lvCity.Columns[1].Width = 0;
                                    //    lvCity.Items.Add(objList);
                                    //}
                                    //lvCity.Visible = true;
                                    //lvCity.BringToFront();
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["CTYID"].Visible = false;
                                    DGV_FilterProduct.Columns["STID"].Visible = false;
                                    DGV_FilterProduct.Columns["ST_Name"].Visible = false;
                                    DGV_FilterProduct.Columns["ST_TIN"].Visible = false;
                                    DGV_FilterProduct.Columns["CTY_NAME"].HeaderText = "City";
                                    DGV_FilterProduct.Columns["CTY_NAME"].Width = 180;
                                    DGV_FilterProduct.Columns["CTY_NAME"].DisplayIndex = 0;
                                    DGV_FilterProduct.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                    //lvCity.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                                //lvCity.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                            //lvCity.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                        //lvCity.Visible = false;
                        //lvCity.Items.Clear();
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


        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnGrdevent();
                cmbSalesApplicable.Focus();
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
                    //ListViewItem selectedItem = lvCity.SelectedItems[0];
                    //txtCity.Text = selectedItem.SubItems[0].Text;
                    //lblcityid.Text = selectedItem.SubItems[1].Text;
                    txtCity.Text = DGV_FilterProduct.SelectedRows[0].Cells["CTY_NAME"].Value.ToString();
                    lblcityid.Text = DGV_FilterProduct.SelectedRows[0].Cells["CTYID"].Value.ToString();
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

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnGridviewProduct();
                //    udfnPossibleSupplierLoad();
                //}
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtCity.Text = DGV_FilterProduct.SelectedRows[0].Cells["CTY_NAME"].Value.ToString();

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtCity.Text = DGV_FilterProduct.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnGrdevent();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbSalesApplicable.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSalesApplicable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ////== 12 means not applicable for sales, so disable delivery preference and multi transport
                if (Convert.ToInt32(cmbSalesApplicable.SelectedValue) == 12)
                {
                    cmbDelivery.Enabled = false; 
                    cmbDelivery.SelectedValue = 0;
                    lblTransports.Text = "";
                    cmbTransPref.ClearAll();
                }
                else
                {
                    cmbDelivery.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbReportType.SelectedValue) == 360)
                {
                    txtCity.Enabled = true;
                    cmbSalesApplicable.Enabled = true;
                    cmbDelivery.Enabled = true;
                    cmbTransPref.Enabled = true;
                }
                else
                {
                    txtCity.Enabled = false;
                    cmbSalesApplicable.Enabled = false;
                    cmbDelivery.Enabled = false;
                    cmbTransPref.Enabled = false;
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
