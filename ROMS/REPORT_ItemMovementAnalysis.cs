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
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using CrystalDecisions.Shared;

namespace ROMS
{
    public partial class REPORT_ItemMovementAnalysis : Form
    {
        ToolTip tpProduct = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varStockLocationId = 0;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyRack = 0, varUpDownKeyProduct = 0, varUpDownKeyLocation = 0;
        public REPORT_ItemMovementAnalysis()
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
        private void BtnListPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //bool varErrorFlag = true;
                //if (txtProductName.Text.Trim() == "")
                //{
                //    lblProduct.Text = "0";
                //    epItemAnalysis.SetError(txtProductName, "Please enter product.");
                //    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpProduct.ShowAlways = true;
                //    tpProduct.Show("Please enter product.", txtProductName, 5000);
                //    varErrorFlag = false;
                //}
                //if (varErrorFlag == true)
                //{
                //    udfnList();
                //}
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
                lvProduct.Visible = false;

                btnView.Enabled = false;
                lblConcern.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                if (txtProductName.Text == "")
                {
                    epItemAnalysis.SetError(txtProductName, "Please enter product name");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductName, 5000);
                    lblProduct.Text = "0";
                    varPrint = 1;
                }
                else
                {
                    epItemAnalysis.Clear();
                }
                if(txtLocation.Text=="")
                {
                    varStockLocationId = 0;
                }
                if(txtRack.Text=="")
                {
                    lblRackCode.Text = "0";
                }
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                Model.TRN_Item_Movement_Analysis objTRN_Item_Movement_Analysis = new Model.TRN_Item_Movement_Analysis();
                objTRN_Item_Movement_Analysis.Viewtype = 0;
                objTRN_Item_Movement_Analysis.paraProductId = Convert.ToInt32(lblProduct.Text.Trim());
                objTRN_Item_Movement_Analysis.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_Item_Movement_Analysis.paraLocationId = Convert.ToInt32(varStockLocationId);
                objTRN_Item_Movement_Analysis.paraRackId = Convert.ToInt32(lblRackCode.Text);
                objTRN_Item_Movement_Analysis.parafromdate = dpFromDate.Text;
                objTRN_Item_Movement_Analysis.paratodate = dptodate.Text;
                objTRN_Item_Movement_Analysis.paraLocation = 1;
                objTRN_Item_Movement_Analysis.paraRack = 1;
                objTRN_Item_Movement_Analysis.paraMRP = 1;
                objTRN_Item_Movement_Analysis.paraBatchNo = 1;
                objTRN_Item_Movement_Analysis.paraExpiryDate = 1;
                objDs = objspservice.udfnItemMovementAnalysis(objTRN_Item_Movement_Analysis);
                objspservice.CloseConnection();

                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        DataSet objDd = new DataSet();
                        SPDataService objservice = new SPDataService();
                        objTRN_Item_Movement_Analysis.Viewtype = 1;
                        objTRN_Item_Movement_Analysis.paraProductId = Convert.ToInt32(lblProduct.Text.Trim());
                        objTRN_Item_Movement_Analysis.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                        objTRN_Item_Movement_Analysis.paraLocationId = Convert.ToInt32(varStockLocationId);
                        objTRN_Item_Movement_Analysis.paraRackId = Convert.ToInt32(lblRackCode.Text);
                        objTRN_Item_Movement_Analysis.parafromdate = dpFromDate.Text;
                        objTRN_Item_Movement_Analysis.paratodate = dptodate.Text;
                        objDd = objservice.udfnItemMovementAnalysis(objTRN_Item_Movement_Analysis);
                        objspservice.CloseConnection();
                        if (objDs.Tables[0].Rows.Count > 0 && varPrint == 0)
                        {
                            RPTViewer.Visible = true;
                            RPTViewer.BringToFront();
                            RPTViewer.ReuseParameterValuesOnRefresh = true;
                            //RPTViewer.RefreshReport();
                            CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_ItemMovementAnalysis.rpt");
                            objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                            objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                            objBillreport.SetParameterValue("paraProductId ", Convert.ToInt32(lblProduct.Text.Trim()));
                            objBillreport.SetParameterValue("paraCompanyId ", Convert.ToInt32(cmbConcern.SelectedValue));
                            objBillreport.SetParameterValue("paraRackId ", Convert.ToInt32(lblRackCode.Text.Trim()));
                            objBillreport.SetParameterValue("paraLocationId ", Convert.ToInt32(varStockLocationId));
                            objBillreport.SetParameterValue("paralocationflag", 1);
                            objBillreport.SetParameterValue("paraRackflag", 1);
                            objBillreport.SetParameterValue("paraMrpflag", 1);
                            objBillreport.SetParameterValue("paraBatchflag", 1);
                            objBillreport.SetParameterValue("paraExpirydateflag", 1);
                            objBillreport.SetParameterValue("parafromdate ", dpFromDate.Text);
                            objBillreport.SetParameterValue("paratodate ", dptodate.Text);
                            objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                            objValidation.CrySqlConnection(objBillreport);
                            RPTViewer.ReportSource = objBillreport;
                            //RPTViewer.Refresh();
                        }
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
                btnView.Enabled = true;
                btnView.Focus();
                GC.Collect();
            }

        }
        private void REPORT_CP_Product_Load(object sender, EventArgs e)
        {
            try
            {
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
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                checkdata();
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dptodate.MaxDate = MainForm.pbCurrentDate;
                //udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void checkdata()
        {
            try
            {
                chkBatchno.Checked = true;
                chkLocation.Checked = true;
                chkRack.Checked = true;
                chkMrp.Checked = true;
                chkExpirydate.Checked = true;
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
        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
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
                    dpFromDate.Focus();
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
                    txtLocation.Focus();
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
                                    udfnProductEvent();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProduct.SelectedText = true;
                        TextBox txtProduct = sender as TextBox;
                        txtProduct.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtLocation.Focus();
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
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 48;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraProductName = txtProductName.Text;
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        objspdservice.CloseConnection();
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
                                    DGV_FilterProduct.Columns["R.Rate"].Visible = false;
                                    DGV_FilterProduct.Columns["W.Rate"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "P.I Code";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50;
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
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

        private void LvProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnProductEvent();
                txtLocation.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductEvent();
                    txtLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductEvent()
        {
            try
            {
                if (txtProductName.Text.Trim() != "")
                {
                    lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvProduct.Visible = false;
            }
        }

        private void TxtLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                lvProduct.Visible = false;
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
        private void TxtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                lvLocation.Visible = false;
                udfnGridNull((Control)sender);
                txtRack.BackColor = Color.LemonChiffon;
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
                    txtRack.Focus();
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
                        txtRack.Focus();
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
                    varStockLocationId = Convert.ToInt32(DGV_FilterLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvStockLocation();
                txtRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation();
                    txtRack.Focus();
                }
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
                varUpDownKeyRack = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterGroup.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterGroup.Visible == false)
                {
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterGroup.Focus();
                }
                if (DGV_FilterGroup.CurrentCell == null && DGV_FilterGroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterGroup.Focus();
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyRack = 1;
                    }
                    else
                    {
                        varUpDownKeyRack = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtRack.Text = DGV_FilterGroup.Rows[RowIndex].Cells["RK_Name"].Value.ToString();
                            }
                            txtRack.Focus();
                            txtRack.SelectionStart = txtRack.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtRack.Text = DGV_FilterGroup.Rows[RowIndex].Cells["RK_Name"].Value.ToString();
                            }

                            txtRack.Focus();
                            txtRack.SelectionStart = txtRack.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyRack = 1;
                                    udfnPurRackAutocomplete();
                                    DGV_FilterGroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtRack.Focus();
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtBrand = sender as TextBox;
                        txtBrand.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnView.Focus();
                    }
                }
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
                if (varUpDownKeyRack == 0)
                {
                    if(txtLocation.Text.Trim()=="")
                    { varStockLocationId = 0; }
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtRack.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnRackList(8, 0, 0, varStockLocationId, 0, txtRack.Text.Trim(), 0, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterGroup.Visible = true;
                                    DGV_FilterGroup.DataSource = objDs.Tables[0];
                                    DGV_FilterGroup.Columns["RKID"].Visible = false;
                                    DGV_FilterGroup.Columns["RK_Description"].Visible = false;
                                    DGV_FilterGroup.Columns["RK_ShortName"].Visible = false;
                                    DGV_FilterGroup.Columns["RK_Name"].HeaderText = "Rack Name";
                                    DGV_FilterGroup.Columns["RK_Name"].Width = 180;
                                    DGV_FilterGroup.Columns["RK_Name"].DisplayIndex = 0;
                                    DGV_FilterGroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterGroup.Visible = false;
                                    DGV_FilterGroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterGroup.Visible = false;
                                DGV_FilterGroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterGroup.Visible = false;
                            DGV_FilterGroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterGroup.Visible = false;
                        DGV_FilterGroup.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurRackAutocomplete()
        {
            try
            {
                if (txtRack.Text.Trim() != "")
                {
                    lblRackCode.Text = DGV_FilterGroup.SelectedRows[0].Cells["RKID"].Value.ToString();
                    txtRack.Text = DGV_FilterGroup.SelectedRows[0].Cells["RK_Name"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvRack.Visible = false;
            }
        }
        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnPurRackAutocomplete();
                btnView.Focus();
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
                    udfnPurRackAutocomplete();
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                        objDs = objspdservice.udfnStockLocationList(26, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        objspdservice.CloseConnection();
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

        private void LvRack_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnView_Click(object sender, EventArgs e)
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
        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtRack)
                {
                    varUpDownKeyRack = 0;
                    DGV_FilterGroup.DataSource = null;
                    DGV_FilterGroup.Visible = false;
                }
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
        private void ChkExpirydate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.SelectedValue = 0;
                txtProductName.Text = "";
                txtRack.Text = "";
                txtLocation.Text = "";
                dpFromDate.Value = DateTime.Today;
                dptodate.Value = DateTime.Today;
                chkBatchno.Checked = false;
                chkLocation.Checked = false;
                chkRack.Checked = false;
                chkMrp.Checked = false;
                chkExpirydate.Checked = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                lvRack.Visible = false;
                udfnGridNull((Control)sender);
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_Leave(object sender, EventArgs e)
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

        private void BtnExport_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                btnExport.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_Leave(object sender, EventArgs e)
        {
            try
            {
                btnExport.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnReset_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                btnReset.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnReset_Leave(object sender, EventArgs e)
        {
            try
            {
                btnReset.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dptodate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductName.Focus();
                }
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
                    dptodate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrpShow_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                lvRack.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkLocation_CheckedChanged(object sender, EventArgs e)
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

        private void DpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dptodate.MinDate = varmindate;
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
                udfnProductEvent();
                txtLocation.Focus();
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
                                    udfnProductEvent();
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
                        txtLocation.Focus();
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
                txtRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyRack = 1;
                udfnPurRackAutocomplete();
                btnView.Focus();
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
                        txtRack.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyRack = 1;
                    }
                    else
                    {
                        varUpDownKeyRack = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            txtRack.Text = DGV_FilterGroup.SelectedRows[0].Cells["RK_Name"].Value.ToString();

                            txtRack.Focus();
                            txtRack.SelectionStart = txtRack.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtRack.Text = DGV_FilterGroup.Rows[RowIndex].Cells["RK_Name"].Value.ToString();
                            }

                            txtRack.Focus();
                            txtRack.SelectionStart = txtRack.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyRack = 1;
                                    udfnPurRackAutocomplete();
                                    DGV_FilterGroup.Visible = false;
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
                        btnView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        //public void udfnPrint()
        //{
        //    try
        //    {
        //        btnExport.Enabled = false;
        //        lblProduct.Focus();
        //        DataSet objDs = new DataSet();
        //        SPDataService objspservice = new SPDataService();
        //        Model.TRN_Item_Movement_Analysis objTRN_Item_Movement_Analysis = new Model.TRN_Item_Movement_Analysis();
        //        objTRN_Item_Movement_Analysis.Viewtype = 0;
        //        objTRN_Item_Movement_Analysis.paraProductId = Convert.ToInt32(lblProduct.Text.Trim());
        //        objTRN_Item_Movement_Analysis.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
        //        objTRN_Item_Movement_Analysis.paraLocationId = Convert.ToInt32(varStockLocationId);
        //        objTRN_Item_Movement_Analysis.paraRackId = Convert.ToInt32(lblRackCode.Text);
        //        objTRN_Item_Movement_Analysis.parafromdate = dpFromDate.Text;
        //        objTRN_Item_Movement_Analysis.paratodate = dptodate.Text;
        //        objTRN_Item_Movement_Analysis.paraLocation = 1;
        //        objTRN_Item_Movement_Analysis.paraRack = 1;
        //        objTRN_Item_Movement_Analysis.paraMRP = 1;
        //        objTRN_Item_Movement_Analysis.paraBatchNo = 1;
        //        objTRN_Item_Movement_Analysis.paraExpiryDate = 1;
        //        objDs = objspservice.udfnItemMovementAnalysis(objTRN_Item_Movement_Analysis);
        //        objspservice.CloseConnection();

        //        if (objDs != null)
        //        {
        //            if (objDs.Tables.Count > 0)
        //            {
        //                DataSet objDd = new DataSet();
        //                SPDataService objservice = new SPDataService();
        //                objTRN_Item_Movement_Analysis.Viewtype = 1;
        //                objTRN_Item_Movement_Analysis.paraProductId = Convert.ToInt32(lblProduct.Text.Trim());
        //                objTRN_Item_Movement_Analysis.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
        //                objTRN_Item_Movement_Analysis.paraLocationId = Convert.ToInt32(varStockLocationId);
        //                objTRN_Item_Movement_Analysis.paraRackId = Convert.ToInt32(lblRackCode.Text);
        //                objTRN_Item_Movement_Analysis.parafromdate = dpFromDate.Text;
        //                objTRN_Item_Movement_Analysis.paratodate = dptodate.Text;
        //                objDd = objservice.udfnItemMovementAnalysis(objTRN_Item_Movement_Analysis);
        //                objspservice.CloseConnection();
        //                if (objDs.Tables[0].Rows.Count > 0)
        //                {
        //                    DataTable objDt = new DataTable();
        //                    //objDt = objDtExcel.Copy();
        //                    //objDt.Columns.Remove("GroupCode");
        //                    using (XLWorkbook wb = new XLWorkbook())
        //                    {
        //                        SaveFileDialog sv = new SaveFileDialog();
        //                        sv.Filter = "Execl files (*.xls)|*.xls";
        //                        sv.FilterIndex = 0;
        //                        if (sv.ShowDialog() == DialogResult.OK)
        //                        {
        //                            var sheet = wb.Worksheets.Add("Group List");
        //                            //sheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        //                            //sheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.White;
        //                            //sheet.Cell(1, 1).Style.Font.Bold = true;
        //                            //sheet.Cell(1, 1).Style.Font.FontSize = 15; 

        //                            sheet.Cell(1, 1).InsertTable(objDt);

        //                            //   sheet.Cell(objDt.Rows.Count + 4, 1).InsertData(objDt.Rows);
        //                            sheet.Tables.FirstOrDefault().ShowAutoFilter = false;
        //                            wb.SaveAs(sv.FileName);
        //                            MessageBox.Show("Successfully Downloaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No Record Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            objError = new DataError();
        //            objError.WriteFile(ex);
        //        }
        //}

        private void udfnExcel()
        {
            try
            {
                DataSet ds = new DataSet();
                SPDataService spservice = new SPDataService();
                string data = "";
                Microsoft.Office.Interop.Excel._Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet ExcelSheet = null;
                //     ExcelObj.Visible = true;
                ExcelSheet = ExcelBook.Sheets["Sheet1"];
                ExcelSheet = ExcelBook.ActiveSheet;
                ExcelSheet.Name = "Item movement analysis report";
                int count = 0;


                int IntReportType = 0;
                //if (Convert.ToInt32(Cmb_ReportList.SelectedValue.ToString()) == 4)
                //{
                //    IntReportType = 1;
                //}
                //else if (Convert.ToInt32(Cmb_ReportList.SelectedValue.ToString()) == 5)
                //{
                //    IntReportType = 2;
                //}
                //else if (Convert.ToInt32(Cmb_ReportList.SelectedValue.ToString()) == 6)
                //{
                //    IntReportType = 3;
                //}
                //else if (Convert.ToInt32(Cmb_ReportList.SelectedValue.ToString()) == 7)
                //{
                //    IntReportType = 4;
                //}
                //else if (Convert.ToInt32(Cmb_ReportList.SelectedValue.ToString()) == 8)
                //{
                //    IntReportType = 5;
                //}

                //int IntType = 0; IntType = 0;
                //int IntExport = 1;
                //int IntIndividualPrint = 0;



                ////string varCompName = "Company : All", varGroupName = "Group : All", varRawName = "Rawmaterial : All", varLocation = "Location : All";
                ////if (cmbCompany.SelectedValue.ToString() != "0") { varCompName = "Company : " + cmbCompany.Text; }
                ////if (Txt_Group.Text != "") { varGroupName = "Group : " + Txt_Group.Text; }
                ////if (Txt_RawMaterial.Text != "") { varRawName = "Rawmaterial : " + Txt_RawMaterial.Text; }
                ////if (txtLocation.Text != "") { varLocation = "Location : " + txtLocation.Text; }

                ////Microsoft.Office.Interop.Excel.Range range1 = ExcelSheet.UsedRange;
                ////Microsoft.Office.Interop.Excel.Range cell = range1.Cells[1][1];
                ////Microsoft.Office.Interop.Excel.Borders border = cell.Borders;
                //int varAll = 0;
                //int varinstk = 0;
                //int varzerostock = 0;
                //int varnegstk = 0;
                //if (chkAll.Checked == true)
                //{
                //    varAll = 1;
                //}
                //else
                //{
                //    varAll = 0;
                //}
                //if (chkinstock.Checked == true)
                //{
                //    varinstk = 1;
                //}
                //else
                //{
                //    varinstk = 0;
                //}
                //if (chkzerostock.Checked == true)
                //{
                //    varzerostock = 1;
                //}
                //else
                //{
                //    varzerostock = 0;
                //}


                //if (chk_NegativeStk.Checked == true)
                //{

                //    varnegstk = 0;
                //}
                var DOP = "";

                Model.TRN_Item_Movement_Analysis objTRN_Item_Movement_Analysis = new Model.TRN_Item_Movement_Analysis();
                objTRN_Item_Movement_Analysis.Viewtype = 0;
                objTRN_Item_Movement_Analysis.paraProductId = Convert.ToInt32(lblProduct.Text.Trim());
                objTRN_Item_Movement_Analysis.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_Item_Movement_Analysis.paraLocationId = Convert.ToInt32(varStockLocationId);
                objTRN_Item_Movement_Analysis.paraRackId = Convert.ToInt32(lblRackCode.Text);
                objTRN_Item_Movement_Analysis.parafromdate = dpFromDate.Text;
                objTRN_Item_Movement_Analysis.paratodate = dptodate.Text;
                objTRN_Item_Movement_Analysis.paraLocation = 1;
                objTRN_Item_Movement_Analysis.paraRack = 1;
                objTRN_Item_Movement_Analysis.paraMRP = 1;
                objTRN_Item_Movement_Analysis.paraBatchNo = 1;
                objTRN_Item_Movement_Analysis.paraExpiryDate = 1;
                ds = spservice.udfnItemMovementAnalysis(objTRN_Item_Movement_Analysis);
                spservice.CloseConnection();
                count = ds.Tables[0].Columns.Count;
                String VarReportHead = "";
                VarReportHead = "As on Date " + dpFromDate.Text;
                //ExcelSheet.Cells[1, 1].Value = Cmb_ReportList.Text;
                ExcelSheet.Cells[2, 1].Value = VarReportHead;
                //ExcelSheet.Cells[2, 1].Value = varCompName;
                //ExcelSheet.Cells[2, 2].Value = varGroupName;
                //ExcelSheet.Cells[2, 3].Value = varRawName;
                //ExcelSheet.Cells[2, 4].Value = varLocation;
                ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Excel.XlRgbColor.rgbGray;
                ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Bold = true;
                ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.color = Color.White;
                ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Merge();
                ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.Black;
                ExcelSheet.Range[ExcelSheet.Cells[3, 1], ExcelSheet.Cells[3, count]].Font.color = Color.White;
                ExcelSheet.Range[ExcelSheet.Cells[3, 1], ExcelSheet.Cells[3, count]].Interior.Color = Excel.XlRgbColor.rgbSlateGray;


                //Excel.Range _range;
                //_range = ExcelSheet.get_Range(ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]);
                //Excel.Borders borders = _range.Borders;
                //borders.LineStyle = Excel.XlLineStyle.xlContinuous;


                string[] varcolumnname = new string[ds.Tables[0].Columns.Count];
                int k = 0;
                //if (Mainform.objemployeelist.grdEmployeelist.Rows.Count > 0)
                //{
                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    if (k < ds.Tables[0].Columns.Count)
                    {
                        ExcelSheet.Cells[3, k + 1] = column.ColumnName;
                        ExcelSheet.Cells[3, k + 1].font.Bold = true;

                        //range1 = ExcelSheet.UsedRange;
                        //cell = range1.Cells[3][k + 1];
                        //border = cell.Borders;
                        //border[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
                        //Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //border[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                        //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //border[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                        //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //border[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
                        //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    }
                    k++;
                }
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        ExcelSheet.Cells[i + 4, j + 1] = data;

                        //range1 = ExcelSheet.UsedRange;
                        //cell = range1.Cells[i + 4][j + 1];
                        //border = cell.Borders;
                        //border[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
                        //Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //border[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                        //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //border[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                        //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        //border[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
                        //    Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    }
                }


                //foreach (Excel.Range cell in range.Rows[1].Cells)
                //{
                //    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                //    cell.Font.Bold = true;
                //}
                //range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //}

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    objBillreport.ExportToDisk(ExportFormatType.Excel, saveFileDialog.FileName);//+ ".xls"
                    MessageBox.Show("Report Exported Succesful..");
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnExcel();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }

}
