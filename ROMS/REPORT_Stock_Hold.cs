using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class REPORT_Stock_Hold : Form
    {
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyProduct = 0, varUpDownKeyLocation = 0;
        private ToolTip tpReportType = new ToolTip();
        public REPORT_Stock_Hold()
        {
            InitializeComponent();
        }
        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                btnView.BackColor = Color.LemonChiffon;
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
                btnView.BackColor = Color.Transparent;
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
                if (skipControl != txtProductName)
                {
                    varUpDownKeyProduct = 0;
                    DGV_FilterProduct.DataSource = null;
                    DGV_FilterProduct.Visible = false;
                }
                if (skipControl != txtLocation)
                {
                    varUpDownKeyLocation = 0;
                    DGV_FilterLocation.DataSource = null;
                    DGV_FilterLocation.Visible = false;
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
                udfnStockHoldReport();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnStockHoldReport()
        {
            try
            {
                string varLocationName = "-All-", varProductName = "-All-", varAlphaName = "-All-";
                int varLocationId = 0, varProductId = 0;
                if (txtLocation.Text.Trim() != "")
                {
                    varLocationName = txtLocation.Text;
                    varLocationId = Convert.ToInt32(lblLocationCode.Text);
                }
                if (txtProductName.Text.Trim() != "")
                {
                    varProductName = txtProductName.Text;
                    varProductId = Convert.ToInt32(lblProductcode.Text);
                }
                if (txtSearchByPICode.Text.Trim() != "")
                {
                    varAlphaName = txtSearchByPICode.Text;
                }
                btnView.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                TRN_StockHold objTRNG_StockHold = new TRN_StockHold();
                objTRNG_StockHold.ViewType = 3;
                objTRNG_StockHold.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRNG_StockHold.paraFromDate = dpFromDate.Text;
                objTRNG_StockHold.paraToDate = dpToDate.Text;
                objTRNG_StockHold.paraSLID = varLocationId;
                objTRNG_StockHold.paraPRID = varProductId;
                objTRNG_StockHold.paraAlpha = txtSearchByPICode.Text;
                objTRNG_StockHold.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRNG_StockHold.paraIPAddress = MainForm.pbIpAddress;
                objDs = objdserv.udfnStockHoldList(objTRNG_StockHold);
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Stock_Hold.rpt");
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text);
                    objBillreport.SetParameterValue("paraToDate", dpToDate.Text);
                    objBillreport.SetParameterValue("paraCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraPRID", varProductId);
                    objBillreport.SetParameterValue("paraProductName", varProductName);
                    objBillreport.SetParameterValue("paraSLID", varLocationId);
                    objBillreport.SetParameterValue("paraLocationName", varLocationName);
                    objBillreport.SetParameterValue("paraAlpha", txtSearchByPICode.Text);
                    objBillreport.SetParameterValue("paraAlphaName", varAlphaName);
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
                btnView.Enabled = true;
                GC.Collect();
            }
        }
        private void REPORT_GRNSummary_KeyDown(object sender, KeyEventArgs e)
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
        private void REPORT_GRNSummary_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80404;
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID in(1,2) and COMID !=-1 Order by COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyProduct = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    txtSearchByPICode.Focus();
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
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }
                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
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
                        txtSearchByPICode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyProduct == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 49;
                        objMR_Product.paraProductName = txtProductName.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "P.I Code";
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 0;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
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
        private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListviewProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text.Trim() != "")
                {
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                }
                txtSearchByPICode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvproduct.Visible = false;
            }
        }
        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyLocation == 0)
                {
                    //lvLocation.Items.Clear();
                    //lvLocation.BringToFront();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtLocation.Text.Length > 0)
                    {
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 26;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtLocation.Text.Trim();
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(26, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterLocation.Visible = true;
                                    DGV_FilterLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_Default"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_StockApplicable"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterLocation.Columns["SL_EName"].Width = 220;
                                    DGV_FilterLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterLocation.Visible = false;
                                    DGV_FilterLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterLocation.Visible = false;
                                DGV_FilterLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterLocation.Visible = false;
                            DGV_FilterLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterLocation.Visible = false;
                        DGV_FilterLocation.DataSource = null;
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
                txtLocation.Focus();
            }
        }

        private void TxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterLocation.Visible == false)
                {
                    txtProductName.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterLocation.Focus();
                }
                if (DGV_FilterLocation.CurrentCell == null && DGV_FilterLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterLocation.Focus();
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnLvStockLocation();
                                    DGV_FilterLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtLocation.Focus();
                    //txtLocation.SelectionStart = txtLocation.Text.Length;
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
                        txtProductName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 1;
                udfnLvStockLocation();
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnLvStockLocation();
                                    DGV_FilterLocation.Visible = false;
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
                        txtProductName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvStockLocation()
        {
            try
            {
                if (txtLocation.Text.Trim() != "")
                {
                    lblLocationCode.Text = Convert.ToString(DGV_FilterLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
                udfnGridNull((Control)sender);
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
                    txtLocation.Focus();
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

        private void TxtSearchByPICode_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtSearchByPICode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByPICode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByPICode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchByPICode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLocation.BackColor = Color.White;
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
                varUpDownKeyProduct = 1;
                udfnListviewProduct();
                txtSearchByPICode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                dpFromDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpToDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                dpToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpToDate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
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
                        txtSearchByPICode.Focus();
                    }
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
