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
    public partial class REPORT_SALES_Area : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyRoute = 0;
        public REPORT_SALES_Area()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tpRouteReport, this);
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
                DGV_FilterRoute.Visible=false;
                DGV_FilterRoute.DataSource = null;
                cmbStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    BeginInvoke(new Action(() => cmbStatus.Select(int.MaxValue, 0)));
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterRoute.Visible = false;
                DGV_FilterRoute.DataSource = null;
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
            udfnRoute();
        }
        public void udfnRoute()
        {
            try
            {
                int varRouteId = 0;string varRouteName = "-All-";
                if (txtRoute.Text.Trim() != "")
                {
                    varRouteId = Convert.ToInt32(lblRouteId.Text);
                    varRouteName = txtRoute.Text.Trim();
                }
                btnListPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                MR_Sales objMR_Sales = new MR_Sales();
                objMR_Sales.paraViewType = 1;
                objMR_Sales.paraRouteId = varRouteId;
                objMR_Sales.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objDs = objdserv.udfnSalesMasterReports(objMR_Sales);
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_Area.rpt");
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraRouteId", varRouteId);
                    objBillreport.SetParameterValue("paraRouteName", varRouteName);
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
        private void REPORT_CP_Route_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 140202;
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                cmbStatus.SelectedValue = 0;
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

        private void REPORT_CP_Route_KeyDown(object sender, KeyEventArgs e)
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

        private void txtRoute_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRoute.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRoute_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyRoute = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterRoute.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterRoute.Visible == false)
                {
                    cmbStatus.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterRoute.Focus();
                }
                if (DGV_FilterRoute.CurrentCell == null && DGV_FilterRoute.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterRoute.Focus();
                    int RowIndex = DGV_FilterRoute.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterRoute.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyRoute = 1;
                    }
                    else
                    {
                        varUpDownKeyRoute = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtRoute.Text = DGV_FilterRoute.Rows[RowIndex].Cells["Route"].Value.ToString();
                            }
                            txtRoute.Focus();
                            txtRoute.SelectionStart = txtRoute.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterRoute.Rows.Count) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterRoute.Rows.Count))
                            {
                                txtRoute.Text = DGV_FilterRoute.Rows[RowIndex].Cells["Route"].Value.ToString();
                            }

                            txtRoute.Focus();
                            txtRoute.SelectionStart = txtRoute.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterRoute.Rows.Count > 0)
                                {
                                    varUpDownKeyRoute = 1;
                                    udfnRouteEvent();
                                    DGV_FilterRoute.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtRoute.Focus();
                    //txtRoute.SelectionStart = txtRoute.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtRoute.SelectedText = true;
                        TextBox txtRoute = sender as TextBox;
                        txtRoute.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
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

        private void txtRoute_Leave(object sender, EventArgs e)
        {
            try
            {
                 txtRoute.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRoute_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyRoute == 0)
                {
                    if (txtRoute.Text.Length > 0)
                    {
                        MR_Route objMR_Route = new MR_Route();
                        objMR_Route.ViewType = 3;
                        objMR_Route.paraRouteEName = txtRoute.Text;
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnRouteList(objMR_Route);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterRoute.Visible = true;
                                    DGV_FilterRoute.DataSource = objDs.Tables[0];
                                    DGV_FilterRoute.Columns["RID"].Visible = false;
                                    DGV_FilterRoute.Columns["Route"].Width = 250;
                                    DGV_FilterRoute.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterRoute.Visible = false;
                                    DGV_FilterRoute.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterRoute.Visible = false;
                                DGV_FilterRoute.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterRoute.Visible = false;
                            DGV_FilterRoute.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterRoute.Visible = false;
                        DGV_FilterRoute.DataSource = null;
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

        private void DGV_FilterRoute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyRoute = 1;
                udfnRouteEvent();
                cmbStatus.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterRoute_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterRoute.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterRoute.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyRoute = 1;
                    }
                    else
                    {
                        varUpDownKeyRoute = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];

                            txtRoute.Text = DGV_FilterRoute.SelectedRows[0].Cells["Route"].Value.ToString();

                            txtRoute.Focus();
                            txtRoute.SelectionStart = txtRoute.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterRoute.Rows.Count) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterRoute.Rows.Count))
                            {
                                txtRoute.Text = DGV_FilterRoute.Rows[RowIndex].Cells["Route"].Value.ToString();
                            }

                            txtRoute.Focus();
                            txtRoute.SelectionStart = txtRoute.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterRoute.Rows.Count > 0)
                                {
                                    varUpDownKeyRoute = 1;
                                    udfnRouteEvent();
                                    DGV_FilterRoute.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtRoute = sender as TextBox;
                        txtRoute.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
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
        public void udfnRouteEvent()
        {
            try
            {
                if (txtRoute.Text.Trim() != "")
                {
                    lblRouteId.Text = DGV_FilterRoute.SelectedRows[0].Cells["RID"].Value.ToString();
                    txtRoute.Text = DGV_FilterRoute.SelectedRows[0].Cells["Route"].Value.ToString();
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
    }
}
