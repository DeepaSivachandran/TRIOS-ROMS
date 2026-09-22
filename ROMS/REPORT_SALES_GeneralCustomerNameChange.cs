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
    public partial class REPORT_SALES_GeneralCustomerNameChange : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyRoute = 0, varUpDownKeyArea = 0;
        public REPORT_SALES_GeneralCustomerNameChange()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tpGenealCusNameChangeReport, this);
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
           
        public void udfnGridNull(Control skipControl)
        {
            try
            { 
                if (skipControl != txtBilledUser)
                {
                    varUpDownKeyArea = 0;
                    DGV_FilterArea.DataSource = null;
                    DGV_FilterArea.Visible = false;
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
                udfnGridNull((Control)sender);
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
            udfnPrint();
        }
        public void udfnPrint()
        {
            try
            {
                string BilledUser = "-All-";
                int billedUserID = 0;
                if(Convert.ToString(lblBilledUserID.Text)!="0")
                {
                    BilledUser = txtBilledUser.Text;
                    billedUserID=Convert.ToInt32(lblBilledUserID.Text);
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
                objMR_Sales.paraViewType =11; 
                objMR_Sales.paraConcernId =0; 
                objMR_Sales.paraFromDate = dpFromDate.Text; 
                objMR_Sales.paraToDate = dpToDate.Text; 
                objMR_Sales.paraBilledBy = billedUserID; 
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SALES_GeneralCustomerNameChange.rpt"); 
                    objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text);
                    objBillreport.SetParameterValue("paraTodate", dpToDate.Text);
                    objBillreport.SetParameterValue("paraBilledUser", billedUserID);
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt16(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraConcernName", cmbConcern.Text);
                    objBillreport.SetParameterValue("paraBilledUserName", BilledUser);
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
                int currentMUCode = 140210;
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID in(1,2) and COMID !=-1 Order by COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind = null;
                cmbConcern.SelectedValue = 0;
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
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

        //private void txtRoute_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        varUpDownKeyRoute = 0;
        //        if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
        //        {
        //            DGV_FilterRoute.Focus();

        //        }
        //        if (e.KeyCode == Keys.Enter && DGV_FilterRoute.Visible == false)
        //        {
        //            txtBilledUser.Focus();
        //        }
        //        if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
        //        {
        //            DGV_FilterRoute.Focus();
        //        }
        //        if (DGV_FilterRoute.CurrentCell == null && DGV_FilterRoute.RowCount == 0)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            DGV_FilterRoute.Focus();
        //            int RowIndex = DGV_FilterRoute.CurrentCell.RowIndex;
        //            int ClmIndex = DGV_FilterRoute.CurrentCell.ColumnIndex;
        //            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
        //            {
        //                varUpDownKeyRoute = 1;
        //            }
        //            else
        //            {
        //                varUpDownKeyRoute = 0;
        //            }
        //            switch (e.KeyCode)
        //            {
        //                case Keys.Up:
        //                    RowIndex--;
        //                    if (RowIndex >= 0) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];
        //                    if (RowIndex != (-1))
        //                    {
        //                        txtRoute.Text = DGV_FilterRoute.Rows[RowIndex].Cells["Route"].Value.ToString();
        //                    }
        //                    txtRoute.Focus();
        //                    txtRoute.SelectionStart = txtRoute.Text.Length;
        //                    e.Handled = true;
        //                    break;
        //                case Keys.Down:
        //                    RowIndex++;
        //                    if (RowIndex < DGV_FilterRoute.Rows.Count) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];

        //                    if (RowIndex != (DGV_FilterRoute.Rows.Count))
        //                    {
        //                        txtRoute.Text = DGV_FilterRoute.Rows[RowIndex].Cells["Route"].Value.ToString();
        //                    }

        //                    txtRoute.Focus();
        //                    txtRoute.SelectionStart = txtRoute.Text.Length;
        //                    e.Handled = true;
        //                    break;
        //                case Keys.Enter:
        //                    {
        //                        if (DGV_FilterRoute.Rows.Count > 0)
        //                        {
        //                            varUpDownKeyRoute = 1;
        //                            udfnRouteEvent();
        //                            DGV_FilterRoute.Visible = false;
        //                        }
        //                        e.Handled = e.SuppressKeyPress = true;
        //                        break;
        //                    }
        //            }
        //            txtRoute.Focus();
        //            //txtRoute.SelectionStart = txtRoute.Text.Length;
        //            e.Handled = true;
        //            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
        //            {
        //                //txtRoute.SelectedText = true;
        //                TextBox txtRoute = sender as TextBox;
        //                txtRoute.SelectAll();
        //                e.Handled = true;
        //            }
        //            if (e.KeyCode == Keys.Enter)
        //            {
        //                txtBilledUser.Focus();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}
         

        //private void txtRoute_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (varUpDownKeyRoute == 0)
        //        {
        //            if (txtRoute.Text.Length > 0)
        //            {
        //                MR_Route objMR_Route = new MR_Route();
        //                objMR_Route.ViewType = 3;
        //                objMR_Route.paraRouteEName = txtRoute.Text;
        //                SPDataService objspdservice = new SPDataService();
        //                DataSet objDs = new DataSet();
        //                objDs = objspdservice.udfnRouteList(objMR_Route);
        //                objspdservice.CloseConnection();
        //                if (objDs != null)
        //                {
        //                    if (objDs.Tables.Count != 0)
        //                    {
        //                        if (objDs.Tables[0].Rows.Count != 0)
        //                        {
        //                            DGV_FilterRoute.Visible = true;
        //                            DGV_FilterRoute.DataSource = objDs.Tables[0];
        //                            DGV_FilterRoute.Columns["RID"].Visible = false;
        //                            DGV_FilterRoute.Columns["Route"].Width = 250;
        //                            DGV_FilterRoute.BringToFront();
        //                        }
        //                        else
        //                        {
        //                            DGV_FilterRoute.Visible = false;
        //                            DGV_FilterRoute.DataSource = null;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        DGV_FilterRoute.Visible = false;
        //                        DGV_FilterRoute.DataSource = null;
        //                    }
        //                }
        //                else
        //                {
        //                    DGV_FilterRoute.Visible = false;
        //                    DGV_FilterRoute.DataSource = null;
        //                }
        //            }
        //            else
        //            {
        //                DGV_FilterRoute.Visible = false;
        //                DGV_FilterRoute.DataSource = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //    finally
        //    {

        //    }
        //}

        private void DGV_FilterRoute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyRoute = 1;
                udfnRouteEvent();
                txtBilledUser.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        //private void DGV_FilterRoute_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
        //        {
        //            int RowIndex = DGV_FilterRoute.CurrentCell.RowIndex;
        //            int ClmIndex = DGV_FilterRoute.CurrentCell.ColumnIndex;
        //            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
        //            {
        //                varUpDownKeyRoute = 1;
        //            }
        //            else
        //            {
        //                varUpDownKeyRoute = 0;
        //            }
        //            switch (e.KeyCode)
        //            {
        //                case Keys.Up:
        //                    RowIndex--;
        //                    if (RowIndex >= 0) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];

        //                    txtRoute.Text = DGV_FilterRoute.SelectedRows[0].Cells["Route"].Value.ToString();

        //                    txtRoute.Focus();
        //                    txtRoute.SelectionStart = txtRoute.Text.Length;
        //                    e.Handled = true;
        //                    break;
        //                case Keys.Down:
        //                    RowIndex++;
        //                    if (RowIndex < DGV_FilterRoute.Rows.Count) DGV_FilterRoute.CurrentCell = DGV_FilterRoute.Rows[RowIndex].Cells[ClmIndex];

        //                    if (RowIndex != (DGV_FilterRoute.Rows.Count))
        //                    {
        //                        txtRoute.Text = DGV_FilterRoute.Rows[RowIndex].Cells["Route"].Value.ToString();
        //                    }

        //                    txtRoute.Focus();
        //                    txtRoute.SelectionStart = txtRoute.Text.Length;
        //                    e.Handled = true;
        //                    break;
        //                case Keys.Enter:
        //                    {
        //                        if (DGV_FilterRoute.Rows.Count > 0)
        //                        {
        //                            varUpDownKeyRoute = 1;
        //                            udfnRouteEvent();
        //                            DGV_FilterRoute.Visible = false;
        //                        }
        //                        e.Handled = e.SuppressKeyPress = true;
        //                        break;
        //                    }
        //            }
        //            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
        //            {
        //                TextBox txtRoute = sender as TextBox;
        //                txtRoute.SelectAll();
        //                e.Handled = true;
        //            }
        //            if (e.KeyCode == Keys.Enter)
        //            {
        //                txtBilledUser.Focus();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}
        public void udfnRouteEvent()
        {
            try
            {
                //if (txtRoute.Text.Trim() != "")
                //{
                //    lblRouteId.Text = DGV_FilterRoute.SelectedRows[0].Cells["RID"].Value.ToString();
                //    txtRoute.Text = DGV_FilterRoute.SelectedRows[0].Cells["Route"].Value.ToString();
                //}
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

        private void txtArea_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtBilledUser.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyArea = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterArea.Focus();
                } 
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterArea.Focus();
                }
                if (DGV_FilterArea.CurrentCell == null && DGV_FilterArea.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterArea.Focus();
                    int RowIndex = DGV_FilterArea.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterArea.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyArea = 1;
                    }
                    else
                    {
                        varUpDownKeyArea = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtBilledUser.Text = DGV_FilterArea.Rows[RowIndex].Cells["User"].Value.ToString();
                            }
                            txtBilledUser.Focus();
                            txtBilledUser.SelectionStart = txtBilledUser.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterArea.Rows.Count) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterArea.Rows.Count))
                            {
                                txtBilledUser.Text = DGV_FilterArea.Rows[RowIndex].Cells["User"].Value.ToString();
                            }

                            txtBilledUser.Focus();
                            txtBilledUser.SelectionStart = txtBilledUser.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterArea.Rows.Count > 0)
                                {
                                    varUpDownKeyArea = 1;
                                    udfnBilledByData();
                                    DGV_FilterArea.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtBilledUser.Focus();
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

        private void txtArea_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBilledUser.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyArea == 0)
                {
                    if (txtBilledUser.Text.Length > 0)
                    {
                        DataSet objDs = new DataSet();
                        SPDataService objspdservice = new SPDataService(); 
                        objDs = objspdservice.udfnSalesUserList(9, txtBilledUser.Text, "", "", 0, 0, "");
                        objspdservice.CloseConnection();

                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterArea.Visible = true;
                                    DGV_FilterArea.DataSource = objDs.Tables[0];
                                    DGV_FilterArea.Columns["ID"].Visible = false;
                                    DGV_FilterArea.Columns["User"].Width = 250;
                                    DGV_FilterArea.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterArea.Visible = false;
                                    DGV_FilterArea.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterArea.Visible = false;
                                DGV_FilterArea.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterArea.Visible = false;
                            DGV_FilterArea.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterArea.Visible = false;
                        DGV_FilterArea.DataSource = null;
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

        private void DGV_FilterArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyArea = 1;
                udfnBilledByData();
                btnListPrint.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterArea_KeyDown(object sender, KeyEventArgs e)
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
                    int RowIndex = DGV_FilterArea.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterArea.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyArea = 1;
                    }
                    else
                    {
                        varUpDownKeyArea = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];

                            txtBilledUser.Text = DGV_FilterArea.SelectedRows[0].Cells["AreaName"].Value.ToString();

                            txtBilledUser.Focus();
                            txtBilledUser.SelectionStart = txtBilledUser.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterArea.Rows.Count) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterArea.Rows.Count))
                            {
                                txtBilledUser.Text = DGV_FilterArea.Rows[RowIndex].Cells["AreaName"].Value.ToString();
                            }

                            txtBilledUser.Focus();
                            txtBilledUser.SelectionStart = txtBilledUser.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterArea.Rows.Count > 0)
                                {
                                    varUpDownKeyArea = 1;
                                    udfnBilledByData();
                                    DGV_FilterArea.Visible = false;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
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

        private void cmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
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

        private void dpFromDate_Enter(object sender, EventArgs e)
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

        private void dpFromDate_KeyDown(object sender, KeyEventArgs e)
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

        private void dpFromDate_Leave(object sender, EventArgs e)
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

        private void dpFromDate_ValueChanged(object sender, EventArgs e)
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

        private void dpToDate_Enter(object sender, EventArgs e)
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

        private void dpToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBilledUser.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void dpToDate_Leave(object sender, EventArgs e)
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

        public void udfnBilledByData()
        {
            try
            {
                if (txtBilledUser.Text.Trim() != "")
                {
                    lblBilledUserID.Text = DGV_FilterArea.SelectedRows[0].Cells["ID"].Value.ToString();
                    txtBilledUser.Text = DGV_FilterArea.SelectedRows[0].Cells["User"].Value.ToString();
                }
                btnListPrint.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //  LV_Supplier.Visible = false;
            }
        }
    }
}
