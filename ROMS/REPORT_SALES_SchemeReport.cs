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
    public partial class REPORT_SALES_SchemeReport : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKeyRoute = 0, varUpDownKeyArea = 0;
        public REPORT_SALES_SchemeReport()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tpGenealCusNameChangeReport, this);
        }
        
        public void udfnGridNull(Control skipControl)
        {
            try
            { 
                //if (skipControl != txtBilledUser)
                //{
                //    varUpDownKeyArea = 0;
                //    DGV_FilterArea.DataSource = null;
                //    DGV_FilterArea.Visible = false;
                //}
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
                int varViewType = 0;
                string varGroupName = "-All-", varSubgroupName = "-All-", varBrandName = "-All-";
                int varGroupId = 0, varSubgroupId = 0, varBrandId = 0;


                btnView.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                TRN_Scheme objTRN_Scheme = new TRN_Scheme();
                objTRN_Scheme.ViewType = varViewType;
                objTRN_Scheme.paraGroupID = varGroupId;
                objTRN_Scheme.paraSubGroupID = varSubgroupId;
                objTRN_Scheme.paraBrandID = varBrandId;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnSchemeReport(objTRN_Scheme);
                objspservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.SetParameterValue("paraGroupID", varGroupId);
                    objBillreport.SetParameterValue("paraSubGroupID", varSubgroupId);
                    objBillreport.SetParameterValue("paraBrandID", varBrandId);
                    objBillreport.SetParameterValue("paraGroupName", varGroupName);
                    objBillreport.SetParameterValue("paraSubGroupName", varSubgroupName);
                    objBillreport.SetParameterValue("paraBrandName", varBrandName);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);
                    /* 0 - from view, 1- from telegram*/
                    //if (varFlag == 0)
                    //{
                    //    RPTViewer.ReportSource = objBillreport;
                    //    RPTViewer.Refresh();
                    //    //Btn_Print.Enabled = true;
                    //}
                    //else
                    //{
                    //    MainForm.varcurrentdate = DateTime.Now.ToString("dd-MM-yyyy HH-mm tt");
                    //    string varReportName = "Product_Category";
                    //    string varfilePath = MainForm.pbTelegramPath + "\\" + varReportName + "-" + MainForm.varcurrentdate + ".pdf";
                    //    if (File.Exists(varfilePath)) { File.Delete(varfilePath); }
                    //    objBillreport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, varfilePath);
                    //    objMainForm.udfnSendToTelegram(varfilePath);
                    //    btnTelegram.Enabled = true;
                    //    MessageBox.Show("Sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
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
        private void REPORT_CP_Route_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 140210;
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind();
                //objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID in(1,2) and COMID !=-1 Order by COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID");
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
               
        private void btnView_Click(object sender, EventArgs e)
        {

        } 
    }
}
