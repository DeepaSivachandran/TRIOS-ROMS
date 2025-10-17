using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    public partial class PUR_PurchaseOrderList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        private static readonly Dictionary<ToolStripButton, EventHandler> _handlers = new Dictionary<ToolStripButton, EventHandler>();

        public DataTable Deftable = new DataTable();
        public DataTable Deftablepro = new DataTable();
        Boolean BlnSearchImageYN = false;
        public int Supplierpend = 0, Statuschange=0, SearchFlag=0;
        public string varUserID = "0";
        public int MenuCode=0;
        DateTime varmaxdate;
        string privilege="";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public PUR_PurchaseOrderList()
        {
            InitializeComponent();
            windowControl.Initialize(tsPurchaseOrderList, this);
        }
        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder();
                MainForm.objPUR_PurchaseOrder.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void TsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder();
                    MainForm.objPUR_PurchaseOrder.MdiParent = this.ParentForm;
                    MainForm.objPUR_PurchaseOrder.Show();
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
                finally { picLoader.Visible = false; }
            }
        }

        private void TsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PUR_PurchaseOrderList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    TsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    TsbEdit_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D))
                {
                    TsbDelete_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    //MainForm.objStart = new DEF_Start();
                    //MainForm.objStart.MdiParent = this.ParentForm;
                    //MainForm.objStart.Show();
                    //this.Close();
                    windowControl?.TriggerClose();
                }

                if (e.KeyCode == Keys.Delete)
                {
                    udfndelete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void GrdPurchaseorderlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPurchaseorderlist.Columns[e.ColumnIndex].Name)
                    {
                        case "clmView":
                            MainForm.objPUR_POIssuedDetails = new PUR_POIssuedDetails();
                            MainForm.objPUR_POIssuedDetails.varPOID = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString());
                            MainForm.objPUR_POIssuedDetails.Varordertype = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["SPSC_TAT"].Value.ToString());
                            MainForm.objPUR_POIssuedDetails.varsts = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_CurrentSTSID"].Value.ToString());
                            MainForm.objPUR_POIssuedDetails.pbDelayedStatus = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["STS1"].Value.ToString());
                            MainForm.objPUR_POIssuedDetails.EditAccess = SpecialPermissions.Any(sp => sp.MUP_Code == 14 && sp.EditAccess.Split(',').Contains("10"));
                            MainForm.objPUR_POIssuedDetails.ShowDialog();
                            break;
                        case "clmPrint":
                            try
                            { 
                                string POUpdatevalue = "0",POCOMID="0"; 
                                    POUpdatevalue = Convert.ToString((grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString())); 
                                    POCOMID = Convert.ToString((grdPurchaseorderlist.SelectedRows[0].Cells["COMID"].Value.ToString())); 
                                DialogResult result1;
                                SPDataService objDServ = new SPDataService();
                                string varMessage = objDServ.udfnGetMessages(87);
                                objDServ.CloseConnection();
                                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result1 == DialogResult.Yes)
                                {
                                    string varHeader = "";
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO.rpt");
                                    varHeader = "Purchase Order"; 

                                    objBillreport.SetParameterValue("paraPOID", Convert.ToInt32(POUpdatevalue), objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraPOID", Convert.ToInt32(POUpdatevalue), objBillreport.Subreports[1].Name.ToString());
                                    objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(POCOMID), objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(POCOMID), objBillreport.Subreports[1].Name.ToString());
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[1].Name.ToString());
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[1].Name.ToString());
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                                    objValidation.CrySqlConnection(objBillreport);
                                    //objValidation.CrySqlConnection(objBillreport);

                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.Text = varHeader;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            {
                                objError = new DataError();
                                objError.WriteFile(ex);
                            }
                            break;
                        case "clmEnvelopPrint":
                            string POSPID = Convert.ToString((grdPurchaseorderlist.SelectedRows[0].Cells["PO_SPID"].Value.ToString()));
                            udfnSupplierPrint(POSPID);
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
        private void udfnSupplierPrint(string varSPID)
        {
            try
            {
                SPDataService objSPdataservice = new SPDataService();
                DataSet objDs = new DataSet();
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 42;
                objMR_Supplier.paraSupplierIds = varSPID;
                objMR_Supplier.paraStickerCount = 1;
                objDs = objSPdataservice.udfnSupplierList(objMR_Supplier);
                objSPdataservice.CloseConnection();
                if (objDs != null)
                {
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Supplier_Envelope.rpt");
                    objBillreport.SetParameterValue("paraSupplierIds", varSPID);
                    objBillreport.SetParameterValue("paraStickerCount", 1);
                    objValidation.CrySqlConnection(objBillreport);
                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                    MainForm.objReportLoad.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PUR_PurchaseOrderList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 102;
                this.ActiveControl = cmbConcern;
                udfnDate();
                udfnDropdownLoad();
                cmbConcern.SelectedValue = Convert.ToInt32(MainForm.pbDefaultComId);
                udfngridchanges();
                DpPlanDate_ValueChanged(sender, e);
                cmbstatus.Enabled = true;
                if(Convert.ToInt32(MainForm.pbUserRoleId)!=1)
                {
                    udfnFieldAccess();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdPurchaseorderlist.ClearSelection();
            }
        } 
        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(MenuCode);
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions;
                tsbNew.Visible = privilege.Contains("2");
                tssNew.Visible = privilege.Contains("2");
                tsbEdit.Visible = privilege.Contains("3");
                tssEdit.Visible = privilege.Contains("3");
                tsbDelete.Visible = privilege.Contains("4"); 
                btnPrint.Visible = privilege.Contains("5");
                btnExport.Visible = privilege.Contains("6");
                udfnGridUserAcess(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridUserAcess()
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    grdPurchaseorderlist.Columns["clmView"].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 14 && sp.EditAccess.Split(',').Contains("9")); 
                    grdPurchaseorderlist.Columns["clmPrint"].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 15 && sp.EditAccess.Split(',').Contains("9"));
                    grdPurchaseorderlist.Columns["clmEnvelopPrint"].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 16 && sp.EditAccess.Split(',').Contains("9"));

                    DGV_SearchGrid.Columns[0].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 14 && sp.EditAccess.Split(',').Contains("9"));
                    DGV_SearchGrid.Columns[1].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 15 && sp.EditAccess.Split(',').Contains("9"));
                    DGV_SearchGrid.Columns[2].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 16 && sp.EditAccess.Split(',').Contains("9"));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public static void SetToolStripAccess(ToolStripButton button, EventHandler clickHandler, bool hasAccess)
        {
            if (!_handlers.ContainsKey(button))
                _handlers[button] = clickHandler; 
            button.Visible = hasAccess; 
            if (hasAccess)
            {
                // Detach first to prevent duplicates, then attach
                button.Click -= _handlers[button];
                button.Click += _handlers[button];
            }
            else
            {
                // Properly remove
                button.Click -= _handlers[button];
            }
        }
        public void udfnDate()
        {
            try
            {
                SPDataService objDServ = new SPDataService();

                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 4;
                objMR_Master.paraID = 6;
                DataSet objd = new DataSet(); 
                objd = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                if (objd.Tables[1].Rows.Count != 0)
                {
                    varmaxdate = DateTime.ParseExact(objd.Tables[1].Rows[0]["mintoday"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                objd = null;
                objMR_Master.ViewType = 9;
                objMR_Master.paraID = 6;
                objd = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                if (objd.Tables[0].Rows.Count != 0)
                {
                    DateTime varmindate = MainForm.pbFYStartDate;
                    dpPlanDate.MinDate = varmindate;
                    dpPlanDate.Text = Convert.ToString(objd.Tables[0].Rows[0]["DATE1"]);
                }
                dpPlanDate.MaxDate = varmaxdate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnDropdownLoad()
        {
            SPDataService objdserv = new SPDataService();
            DataSet objDT = new DataSet();
            objDT = objdserv.udfnCompanyList(2, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
            objdserv.CloseConnection();
            cmbConcern.DataSource = null;
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
            DataBind objDataBind = new DataBind();
            objDataBind.BindComboBoxListSelected("DEF_Status", "STSID  IN (11,13,12,27) AND STS_ModuleID=4 OR STSID=0  ", "STS_Name,STSID", cmbstatus, "", "STS_Name", "STSID");
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=15 AND MSTID IN (135,136)", "MST_DisplayText,MSTID", cmbShow, "", "MST_DisplayText", "MSTID");
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=50 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbGroup, "", "MST_DisplayText", "MSTID"); 
            objDataBind.BindComboBoxListSelected("DEF_Status", "STSID  IN (12,30) AND STS_ModuleID=4 OR STSID=0  ", "STS_Name,STSID", cmbProductStatus, "", "STS_Name", "STSID");
            objDataBind = null;
            cmbShow.SelectedIndex = 0;
            cmbProductStatus.SelectedValue = 0;
            cmbProductStatus.Enabled = true;
        }
         
        private void GrdPurchaseorderlist_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEdit()
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder();
                    MainForm.objPUR_PurchaseOrder.varPOID = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString());
                    MainForm.objPUR_PurchaseOrder.lblPOCreateby.Text = Convert.ToString(grdPurchaseorderlist.SelectedRows[0].Cells["Created By1"].Value.ToString());
                    MainForm.objPUR_PurchaseOrder.lblpocreatedon.Text = Convert.ToString(grdPurchaseorderlist.SelectedRows[0].Cells["Created On1"].Value.ToString());
                    MainForm.objPUR_PurchaseOrder.VarStatusId = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["STS"].Value.ToString());
                    MainForm.objPUR_PurchaseOrder.btnSave.Text = "Update";
                    MainForm.objPUR_PurchaseOrder.varPOID = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString());
                    MainForm.objPUR_PurchaseOrder.pbScheduleid = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_SPSCID"].Value.ToString());
                    MainForm.objPUR_PurchaseOrder.pbSupplierId = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_SPID"].Value.ToString());
                    MainForm.objPUR_PurchaseOrder.txtRemark.Text = Convert.ToString(grdPurchaseorderlist.SelectedRows[0].Cells["PO_Remarks"].Value.ToString());
                    MainForm.objPUR_PurchaseOrder.Currentsts = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_CurrentSTSID"].Value.ToString());
                    MainForm.objPUR_PurchaseOrder.pbSupplierpend = Supplierpend;
                    MainForm.objPUR_PurchaseOrder.PreCloseAccess = SpecialPermissions.Any(sp => sp.MUP_Code == 17 && sp.EditAccess.Split(',').Contains("9")); 
                    MainForm.objPUR_PurchaseOrder.MdiParent = this.ParentForm;
                    MainForm.objPUR_PurchaseOrder.Show();
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
                finally
                {
                    picLoader.Visible = false;
                }
            }
        }

        private void BtnViewProducts_Click(object sender, EventArgs e)
        {
            try
            {
                udfngridchanges(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        public void udfngridchanges()
        {

            try
            {
                RPTViewer.Visible = false;
                RPTViewer.SendToBack();
                if (Convert.ToInt32(cmbShow.SelectedValue) == 135)
                {
                    grpProFilter.Visible = false;
                    grdProDetails.Visible = false;
                    DGV_SearchGridPro.Visible = false;
                    grdPurchaseorderlist.Visible = true;
                    DGV_SearchGrid.Visible = true;
                    txtProductSearch.Text = "";
                    txtProductSearch.Visible = false;
                    lblDSearch.Visible = false;
                    udfnPOEntryLoad();
                    grdProDetails.ClearSelection();
                }
                else
                {
                    grpProFilter.Visible = true;
                    grdProDetails.Visible = true;
                    DGV_SearchGridPro.Visible = true;
                    grdPurchaseorderlist.Visible = false;
                    DGV_SearchGrid.Visible = false;
                    txtProductSearch.Visible = true;
                    lblDSearch.Visible = true;
                    txtProductSearch.Text = "";
                    Statuschange = 1;
                    udfnProductDetails();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { 
                grdPurchaseorderlist.ClearSelection();
                grdProDetails.ClearSelection();
            }
        }

        private void CbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                udfnProductDetails();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbPoNo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                udfnProductDetails();
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
                    dpPlanDate.Focus();
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

        private void CmbConcern_Enter(object sender, EventArgs e)
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
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

        private void DpPlanDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpPlanDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpPlanDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpPlanDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpPlanDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dptoPlanDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DptoPlanDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dptoPlanDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DptoPlanDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dptoPlanDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DptoPlanDate_KeyDown(object sender, KeyEventArgs e)
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
                    cmbShow.Focus();
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
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.ParaFromDate = dpPlanDate.Text;
                    objMR_Supplier.ParaToDate = dptoPlanDate.Text;
                    objMR_Supplier.paraFlag = 1;
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
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
                cmbShow.Focus();
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

        private void Cmbstatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbstatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnViewProducts.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmbstatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbstatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbstatus.Select(int.MaxValue, 0)));
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

        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbShow_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlProduct.Visible == false)
                    {
                        cmbstatus.Focus();
                    }
                    else
                    {
                        cmbProductStatus.Focus();
                    }
                }
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbShow_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbShow.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbShow_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbShow_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbShow.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbShow.Select(int.MaxValue, 0)));
                if (Convert.ToInt32(cmbShow.SelectedValue) == 135)
                {
                    cmbGroup.SelectedIndex = 0;
                    cmbstatus.SelectedValue = 0;
                    pnlProduct.Visible = false;
                    pnlPO.Visible = true;
                }
                else
                {
                    cmbProductStatus.SelectedIndex = 0;
                    cmbGroup.SelectedIndex = 0;
                    cmbstatus.SelectedValue = 0;
                    pnlProduct.Visible = true;
                    pnlPO.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbShow.SelectedValue) == 135)
                {
                    udfnPOEntryLoad();
                }
                else
                {
                    udfnProductDetails();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        public void udfnPOEntryLoad()
        {
            try
            {
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 
                grdPurchaseorderlist.DataSource = null;
                DGV_SearchGrid.DataSource = null;
                DGV_SearchGridPro.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from ;SP ***************
                int varFlag = 0, varStatusID = 0;
                if (rbComplete.Checked==true)
                {
                    varFlag = 1;
                    varStatusID = Convert.ToInt32(cmbstatus.SelectedValue);
                }
                else
                {
                    varStatusID = Convert.ToInt32(cmbstatus.SelectedValue);
                }
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnPOEntry(1, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, Convert.ToInt32(lblGroupId.Text), Convert.ToInt32(lblSubGroupId.Text), dpPlanDate.Text, dptoPlanDate.Text, 0, varStatusID, "0", 0, 0, 0, 0, 0, 0, varFlag);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            grdPurchaseorderlist.Columns["clmPrint"].Visible = true;
                            grdPurchaseorderlist.Columns["clmView"].Visible = true; 
                            grdPurchaseorderlist.Columns["clmEnvelopPrint"].Visible = true; 
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdPurchaseorderlist.DataSource = objDs.Tables[0];
                            //grdPurchaseorderlist.Columns["clmView"].Visible = true;
                            //grdPurchaseorderlist.Columns["clmView"].DisplayIndex = 0;
                            //grdPurchaseorderlist.Columns["clmView"].Width = 110;  
                            grdPurchaseorderlist.Columns["S.No."].Width = 50;
                            grdPurchaseorderlist.Columns["Concern"].Width = 50;
                            grdPurchaseorderlist.Columns["PO.No."].Width = 100;
                            grdPurchaseorderlist.Columns["PO Date"].Width = 100;
                            grdPurchaseorderlist.Columns["Supplier"].Width = 300;
                            grdPurchaseorderlist.Columns["City"].Width = 100; 
                            grdPurchaseorderlist.Columns["T.Pro"].Width = 50;
                            grdPurchaseorderlist.Columns["T.Units"].Width = 140;
                            grdPurchaseorderlist.Columns["TAT"].Width = 70;
                            grdPurchaseorderlist.Columns["DTAT"].Width = 70;
                            grdPurchaseorderlist.Columns["Created By"].Width = 200;
                            grdPurchaseorderlist.Columns["Mode of Issue"].Width = 100;
                            grdPurchaseorderlist.Columns["Issue Date"].Width = 100;
                            grdPurchaseorderlist.Columns["Issued By"].Width = 100;
                            grdPurchaseorderlist.Columns["PO Status"].Width = 120;
                            grdPurchaseorderlist.Columns["clmView"].Width = 50;
                            grdPurchaseorderlist.Columns["clmPrint"].Width = 50;
                            grdPurchaseorderlist.Columns["Overall Status"].Width = 130;

                            grdPurchaseorderlist.Columns["STS"].Visible = false;
                            grdPurchaseorderlist.Columns["COMID"].Visible = false;
                            grdPurchaseorderlist.Columns["Status1"].Visible = false;
                            grdPurchaseorderlist.Columns["Created By1"].Visible = false;
                            grdPurchaseorderlist.Columns["Created On1"].Visible = false;
                            grdPurchaseorderlist.Columns["STS1"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_ID"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_SPSCID"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_SPID"].Visible = false;
                            grdPurchaseorderlist.Columns["po_stsid"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_Remarks"].Visible = false;
                            grdPurchaseorderlist.Columns["SPSC_OrderType"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_Created"].Visible = false;
                            grdPurchaseorderlist.Columns["Total Products"].Visible = false;
                            grdPurchaseorderlist.Columns["Total Qty"].Visible = false;
                            grdPurchaseorderlist.Columns["Turn Around Time"].Visible = false;
                            grdPurchaseorderlist.Columns["GSTIN"].Visible = false;
                            grdPurchaseorderlist.Columns["SPSC_TAT"].Visible = false;
                            grdPurchaseorderlist.Columns["POVALUE"].Visible = false;
                            grdPurchaseorderlist.Columns["turn"].Visible = false;
                            grdPurchaseorderlist.Columns["DELAYVALUE"].Visible = false;
                            grdPurchaseorderlist.Columns["Mode of details"].Visible = false;
                            grdPurchaseorderlist.Columns["Issued DATES"].Visible = false;
                            grdPurchaseorderlist.Columns["DTURN"].Visible = false;
                            grdPurchaseorderlist.Columns["Currentsts"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_CurrentSTSID"].Visible = false;
                            grdPurchaseorderlist.Columns["COMID"].Visible = false;
                            grdPurchaseorderlist.Columns["COM_Name"].Visible = false;
                            grdPurchaseorderlist.Columns["AddressValue"].Visible = false;
                            grdPurchaseorderlist.Columns["CurrentDate"].Visible = false;
                            grdPurchaseorderlist.Columns["CurrentTime"].Visible = false;
                            grdPurchaseorderlist.Columns["FinanciyalYear"].Visible = false;
                            grdPurchaseorderlist.Columns["LogoPath"].Visible = false;
                            grdPurchaseorderlist.Columns["COMGSTIN"].Visible = false;
                            grdPurchaseorderlist.Columns["T.Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdPurchaseorderlist.Columns["T.Units"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdPurchaseorderlist.Columns["TAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseorderlist.Columns["DTAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseorderlist.Columns["PO Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseorderlist.Columns["Issue Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseorderlist.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                            grdPurchaseorderlist.Columns["clmPrint"].Visible = false;
                            grdPurchaseorderlist.Columns["clmView"].Visible = false;
                            grdPurchaseorderlist.Columns["clmEnvelopPrint"].Visible = false;
                            lblTotal.Text = "0";
                            Deftable= objDs.Tables[0];
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            lblPartial.Text = objDs.Tables[1].Rows[0]["PartialCount"].ToString();
                            lblIssued.Text = objDs.Tables[1].Rows[0]["IssuedCount"].ToString();
                            lblNotissued.Text = objDs.Tables[1].Rows[0]["NotIssuedCount"].ToString();
                            lblDelayed.Text = objDs.Tables[1].Rows[0]["DelayedCount"].ToString();
                            if (Convert.ToString(lblPartial.Text) != "" && Convert.ToString(lblIssued.Text) != "" && Convert.ToString(lblNotissued.Text) != "" && Convert.ToString(lblDelayed.Text) != "") 
                            {
                                lblTotal.Text = Convert.ToString(Convert.ToInt32(lblPartial.Text) + Convert.ToInt32(lblIssued.Text) + Convert.ToInt32(lblNotissued.Text) + Convert.ToInt32(lblDelayed.Text));
                            }
                        }
                        if (objDs.Tables[2].Rows.Count > 0)
                        {
                            if (Convert.ToInt32(objDs.Tables[2].Rows[0]["SupplierPend"].ToString().Replace("''", "'")) != 0)
                            {
                                Supplierpend = Convert.ToInt32(objDs.Tables[2].Rows[0]["SupplierPend"].ToString().Replace("''", "'"));
                            }
                            else
                            {
                                Supplierpend = 0;
                            }
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                        grdPurchaseorderlist.Columns["clmView"].Visible = false;
                        grdPurchaseorderlist.Columns["clmEnvelopPrint"].Visible = false;
                        grdPurchaseorderlist.Columns["clmPrint"].Visible = false;
                        Deftable = objDs.Tables[0];
                        lblTotal.Text = "0";
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    grdPurchaseorderlist.Columns["clmEnvelopPrint"].Visible = false;
                    grdPurchaseorderlist.Columns["clmView"].Visible = false;
                    grdPurchaseorderlist.Columns["clmPrint"].Visible = false;
                    Deftable = objDs.Tables[0];
                    lblTotal.Text = "0";

                }

                udfnSearchGridHead();
                if (lblNoRecordsFound.Visible == true)
                {
                    udfnDefcolumns();
                }
                else
                {
                    DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; udfnGridUserAcess();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdProDetails.ClearSelection();
                picLoader.Visible = false;
            }
        }

        public void udfnDefcolumns()
        {
            try
            {

                if (Convert.ToInt32(cmbShow.SelectedValue) == 135)
                {
                    DGV_SearchGrid.DataSource = Deftable;
                    DGV_SearchGrid.Columns["STS"].Visible = false;
                    DGV_SearchGrid.Columns["Status1"].Visible = false;
                    DGV_SearchGrid.Columns["STS1"].Visible = false;
                    DGV_SearchGrid.Columns["PO_ID"].Visible = false;
                    DGV_SearchGrid.Columns["PO_SPSCID"].Visible = false;
                    DGV_SearchGrid.Columns["PO_SPID"].Visible = false;
                    DGV_SearchGrid.Columns["po_stsid"].Visible = false;
                    DGV_SearchGrid.Columns["PO_Remarks"].Visible = false;
                    DGV_SearchGrid.Columns["SPSC_OrderType"].Visible = false;
                    DGV_SearchGrid.Columns["PO_Created"].Visible = false;
                    DGV_SearchGrid.Columns["Total Products"].Visible = false;
                    DGV_SearchGrid.Columns["Total Qty"].Visible = false;
                    DGV_SearchGrid.Columns["Turn Around Time"].Visible = false;
                    DGV_SearchGrid.Columns["GSTIN"].Visible = false;
                    DGV_SearchGrid.Columns["SPSC_TAT"].Visible = false;
                    DGV_SearchGrid.Columns["POVALUE"].Visible = false;
                    DGV_SearchGrid.Columns["turn"].Visible = false;
                    DGV_SearchGrid.Columns["DELAYVALUE"].Visible = false;
                    DGV_SearchGrid.Columns["Mode of details"].Visible = false;
                    DGV_SearchGrid.Columns["Issued DATES"].Visible = false;
                    DGV_SearchGrid.Columns["DTURN"].Visible = false;
                    DGV_SearchGrid.Columns["Currentsts"].Visible = false;
                    DGV_SearchGrid.Columns["PO_CurrentSTSID"].Visible = false;
                    DGV_SearchGrid.Columns["COMID"].Visible = false;
                    DGV_SearchGrid.Columns["COM_Name"].Visible = false;
                    DGV_SearchGrid.Columns["COMGSTIN"].Visible = false;
                    DGV_SearchGrid.Columns["AddressValue"].Visible = false;
                    DGV_SearchGrid.Columns["CurrentDate"].Visible = false;
                    DGV_SearchGrid.Columns["CurrentTime"].Visible = false;
                    DGV_SearchGrid.Columns["FinanciyalYear"].Visible = false;
                    DGV_SearchGrid.Columns["LogoPath"].Visible = false;
                    DGV_SearchGrid.Columns["S.No."].Width = 50;
                    DGV_SearchGrid.Columns["Concern"].Width = 50;
                    DGV_SearchGrid.Columns["PO.No."].Width = 100;
                    DGV_SearchGrid.Columns["PO Date"].Width = 100;
                    DGV_SearchGrid.Columns["Supplier"].Width = 300;
                    DGV_SearchGrid.Columns["City"].Width = 100;
                    DGV_SearchGrid.Columns["T.Pro"].Width = 50;
                    DGV_SearchGrid.Columns["T.Units"].Width = 50;
                    DGV_SearchGrid.Columns["TAT"].Width = 70;
                    DGV_SearchGrid.Columns["DTAT"].Width = 70;
                    DGV_SearchGrid.Columns["Created By"].Width = 200;
                    DGV_SearchGrid.Columns["Created By1"].Visible = false;
                    DGV_SearchGrid.Columns["Created On1"].Visible = false;
                    DGV_SearchGrid.Columns["Mode of Issue"].Width = 100;
                    DGV_SearchGrid.Columns["Issue Date"].Width = 100;
                    DGV_SearchGrid.Columns["Issued By"].Width = 100;
                    DGV_SearchGrid.Columns["PO Status"].Width = 100;
                    //DGV_SearchGrid.Columns["clmView"].Width = 50;
                    //DGV_SearchGrid.Columns["clmPrint"].Width = 50;
                    DGV_SearchGrid.ScrollBars = ScrollBars.Both;
                }
                else
                {
                    DGV_SearchGridPro.DataSource = Deftablepro;
                    DGV_SearchGridPro.Columns["STSID"].Visible = false;
                    DGV_SearchGridPro.Columns["STS1"].Visible = false;
                    DGV_SearchGridPro.Columns["SPSC_SMName"].Visible = false;
                    DGV_SearchGridPro.Columns["SPSC_SMMobileNo"].Visible = false;
                    DGV_SearchGridPro.Columns["status1"].Visible = false;
                    DGV_SearchGridPro.Columns["SP_PhoneNo"].Visible = false;
                    DGV_SearchGridPro.Columns["PO_LastTransNo"].Visible = false;
                    DGV_SearchGridPro.Columns["COMID"].Visible = false;
                    DGV_SearchGridPro.Columns["COM_Name"].Visible = false;
                    DGV_SearchGridPro.Columns["AddressValue"].Visible = false;
                    DGV_SearchGridPro.Columns["CurrentDate"].Visible = false;
                    DGV_SearchGridPro.Columns["CurrentTime"].Visible = false;
                    DGV_SearchGridPro.Columns["FinanciyalYear"].Visible = false;
                    DGV_SearchGridPro.Columns["LogoPath"].Visible = false;
                    DGV_SearchGridPro.Columns["COMGSTIN"].Visible = false;
                    DGV_SearchGridPro.Columns["DAyname"].Visible = false;
                    DGV_SearchGridPro.Columns["GSTIN"].Visible = false;

                    DGV_SearchGridPro.Columns["S.No."].Width = 50;
                    DGV_SearchGridPro.Columns["P.I Code"].Width = 100;
                    DGV_SearchGridPro.Columns["Product Name"].Width = 250;
                    DGV_SearchGridPro.Columns["Supplier"].Width = 250; 
                    DGV_SearchGridPro.Columns["Unit"].Width = 80;
                    DGV_SearchGridPro.Columns["PO no."].Width = 80;
                    DGV_SearchGridPro.Columns["Quantity"].Width = 80;
                    DGV_SearchGridPro.ScrollBars = ScrollBars.Both;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvGroup.Items.Count == 0 || txtProductGroup.Text == "")
                    {
                        txtProductGroup.Focus();
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
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.White;
                if (txtProductGroup.Text.Trim() == "") { lblGroupId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtProductGroup.Text, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvGroup.Columns[2].Width = 200;
                                    lvGroup.Columns[0].Width = 200;
                                    lvGroup.Items.Add(objList);
                                }
                                lvGroup.Visible = true;
                                lvGroup.BringToFront();
                            }
                            else
                            {
                                lvGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvGroup.Visible = false;
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
            finally
            {
            }
        }

        private void TxtProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Visible = false;
                txtProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSubGroup.Items.Count == 0 || txtProductSubGroup.Text == "")
                    {
                        txtProductSubGroup.Focus();
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
                    cmbProductStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.White;
                if (txtProductSubGroup.Text.Trim() == "") { lblSubGroupId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGroupevent();
                txtProductSubGroup.Focus();
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
                    udfnGroupevent();
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGroupevent()
        {
            try
            {
                if (txtProductGroup.Text != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    lblGroupId.Text = selectedItem.SubItems[1].Text;
                    txtProductGroup.Text = selectedItem.SubItems[0].Text;
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

        private void TxtProductSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupId.Text), 0, txtProductSubGroup.Text, 0, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvSubGroup.Columns[2].Width = 200;
                                    lvSubGroup.Columns[0].Width = 200;
                                    lvSubGroup.Items.Add(objList);
                                }
                                lvSubGroup.Visible = true;
                                lvSubGroup.BringToFront();
                            }
                            else
                            {
                                lvSubGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvSubGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvSubGroup.Visible = false;
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
            finally
            {
            }
        }

        private void LvSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSubGroupevent();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSubGroupevent();
                    cmbProductStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSubGroupevent()
        {
            try
            {
                if (txtProductSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    lblSubGroupId.Text = selectedItem.SubItems[1].Text;
                    txtProductSubGroup.Text = selectedItem.SubItems[0].Text;
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

        private void TxtProductSearch_TextChanged(object sender, EventArgs e)
        { 

            try
            {
                if (SearchFlag == 1)
                { 
                    (grdProDetails.DataSource as BindingSource).Filter = "([Product Name]) LIKE '%" + txtProductSearch.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductSearch.Text + "%'";
                }
                else
                { 
                    (grdProDetails.DataSource as DataTable).DefaultView.RowFilter = "([Product Name]) LIKE '%" + txtProductSearch.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductSearch.Text + "%'";

                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductView_Click(object sender, EventArgs e)
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
        public void udfnProductDetails()
        {
            try
            {
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 
                grdProDetails.DataSource = null;
                DGV_SearchGridPro.DataSource = null;
                //lblGroupId.Text = "0"; lblSubGroupId.Text = "0";
                //txtProductGroup.Text = "";txtProductSubGroup.Text = "";
                int varsupplier = 0, varpono = 0,varFilter=0;
                if (Convert.ToInt32(cmbGroup.SelectedValue) == 160)
                {
                    varpono = 1;
                }
                if (Convert.ToInt32(cmbGroup.SelectedValue) == 159)
                {
                    varsupplier = 1;
                }
                if (Convert.ToInt32(cmbGroup.SelectedValue) == 158)
                {
                    varsupplier = 0;
                    varpono = 0;
                }
                if (Convert.ToInt32(cmbGroup.SelectedValue) == 161)
                {
                    varsupplier = 1;
                    varpono = 1;
                    varFilter = 1;
                }
                int varstatus = 0,productstatus=0;
                if (rbComplete.Checked == true)
                {
                    varstatus = 14;
                }
                else
                {
                    varstatus = Convert.ToInt32(cmbstatus.SelectedValue);
                } 

                if (Statuschange == 1)
                {
                    productstatus= Convert.ToInt32(cmbProductStatus.SelectedValue);
                }
                else
                {
                    productstatus = varstatus;
                }
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnPOEntry(0, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), Convert.ToInt32(cmbConcern.SelectedValue), 0, varsupplier, varpono, Convert.ToInt32(lblGroupId.Text), Convert.ToInt32(lblSubGroupId.Text), dpPlanDate.Text, dptoPlanDate.Text, 0, productstatus, "0", varFilter,0, 0, 0, 0, 0,0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdProDetails.DataSource = objDs.Tables[0];
                            grdProDetails.Columns["S.No."].Width = 50;
                            grdProDetails.Columns["P.I Code"].Width = 100;
                            grdProDetails.Columns["Product Name"].Width = 250;
                            grdProDetails.Columns["Supplier"].Width = 250;
                            grdProDetails.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdProDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["Unit"].Width = 80;
                            grdProDetails.Columns["Quantity"].Width = 80;
                            grdProDetails.Columns["STSID"].Visible = false;
                            grdProDetails.Columns["STS1"].Visible = false;
                            grdProDetails.Columns["SPSC_SMName"].Visible = false;
                            grdProDetails.Columns["SPSC_SMMobileNo"].Visible = false;
                            grdProDetails.Columns["status1"].Visible = false;
                            grdProDetails.Columns["SP_PhoneNo"].Visible = false; 
                            grdProDetails.Columns["PO_LastTransNo"].Visible = false; 
                            grdProDetails.Columns["COMID"].Visible = false; 
                            grdProDetails.Columns["COM_Name"].Visible = false; 
                            grdProDetails.Columns["AddressValue"].Visible = false; 
                            grdProDetails.Columns["CurrentDate"].Visible = false; 
                            grdProDetails.Columns["CurrentTime"].Visible = false; 
                            grdProDetails.Columns["FinanciyalYear"].Visible = false; 
                            grdProDetails.Columns["LogoPath"].Visible = false;  
                            grdProDetails.Columns["COMGSTIN"].Visible = false;  
                            grdProDetails.Columns["DAyname"].Visible = false;  
                            grdProDetails.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            if (Convert.ToInt32(cmbGroup.SelectedValue) == 159)
                            {
                                grdProDetails.Columns["GSTIN"].Visible = false;
                                grdProDetails.Columns["PO No."].Width = 80;
                                grdProDetails.Columns["PO Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }  
                                //grdProDetails.Columns["Supplier"].Width = 300;
                                grdProDetails.Columns["GSTIN"].Visible = false;
                                grdProDetails.Columns["PO No."].Width = 80;
                                grdProDetails.Columns["PO Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                              
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                            Deftablepro = objDs.Tables[0];
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                        Deftablepro = objDs.Tables[0];
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    Deftablepro = objDs.Tables[0];
                } 
                udfnSearchGridHeadpro(); 
                if (lblNoRecordsFound.Visible == true)
                {
                    udfnDefcolumns();
                }
                else
                {
                    DGV_SearchGridPro.ScrollBars = ScrollBars.Vertical; 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false; Statuschange = 0;
            }
        } 
        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                        return;
                    //if (DGV_SearchGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Name == "Image")
                    //    return;
                    if ((e.ColumnIndex == 0 || e.ColumnIndex == 1))  //|| e.ColumnIndex == IntDispIndex /*If not our desired columns*/
                        return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    } 
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (grdPurchaseorderlist.ColumnCount > 0)
                    {
                        grdPurchaseorderlist.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseorderlist.HorizontalScrollingOffset;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdPurchaseorderlist.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseorderlist);
                    objDser.CloseConnection();
                    grdPurchaseorderlist.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //DGV_SearchGrid_CellPainting(sender,e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdPurchaseorderlist, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdPurchaseorderlist.Columns)
                    {
                        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    DGV_SearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                    for (int i = 1; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[1].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[2].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[2].Value = new Bitmap(1, 1);
                    //udfnGridSearchHeading(grdPurchaseorderlist, DGV_SearchGrid);
                    //if (DGV_SearchGrid.ColumnCount > 1)
                    //{
                    //    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    //    DGV_SearchGrid.Columns["clmView"].ReadOnly = true;
                    //}
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    dgv2.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in dgv1.Columns)
                    {
                        if (col.Visible)
                        {
                            dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                            visibleColumns.Add(col.Index);
                        }
                    }
                    int rowIndex = 0;
                    int ColIndex = 0;
                    dgv2.Rows.Clear();
                    dgv2.Rows.Add();
                    BlnSearchImageYN = false;
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                        if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                        {
                            //dgv2.Rows[rowIndex].Visible = false;
                            BlnSearchImageYN = true;
                            ColIndex = i;
                            dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                            dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                            ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                        }
                        else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                        {
                            BlnSearchImageYN = true;
                            dgv2.Rows[rowIndex].Cells[i].Value = false;
                        }
                        else
                        {
                            dgv2.Rows[rowIndex].Cells[i].Value = "";
                        }
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int i = e.ColumnIndex + 2;
                    if (e.ColumnIndex == 0)
                    {
                        i = e.ColumnIndex;
                    }
                    DataGridViewColumn newColumn = grdPurchaseorderlist.Columns[i];
                    DataGridViewColumn oldColumn = grdPurchaseorderlist.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdPurchaseorderlist.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            // Sort a new column and remove the old SortGlyph.
                            direction = ListSortDirection.Ascending;
                            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                        }
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    if (newColumn.GetType() != typeof(DataGridViewImageColumn))
                    {
                        grdPurchaseorderlist.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseorderlist.HorizontalScrollingOffset;
                        DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int cl = grdPurchaseorderlist.ColumnCount;
                    int cls = DGV_SearchGrid.ColumnCount;
                    int offSetValue = grdPurchaseorderlist.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdPurchaseorderlist.Width > grdPurchaseorderlist.HorizontalScrollingOffset && grdPurchaseorderlist.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdPurchaseorderlist);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnscrollVisible(DataGridView DGV, DataGridView grdGroupList)
        {
            try
            {
                var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }

                    int I = DGV_SearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            if (DGV_SearchGrid.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                            {
                                DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                            }
                            else { DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = ""; }
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
        public void udfnProscrollVisible(DataGridView DGV, DataGridView grdGroupList)
        {
            try
            {
                var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }

                    int I = DGV_SearchGridPro.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGridPro.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGridPro.Rows[rowIndex].Cells[i].Value = "";
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
        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (DGV_SearchGrid.IsCurrentCellDirty)
                    {
                        // Commit the changes immediately
                        DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }

                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdPurchaseorderlist.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseorderlist);
                    objDser.CloseConnection();
                    grdPurchaseorderlist.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //grdCompanyList(sender,e); 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseorderlist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                udfndelete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfndelete()
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (Convert.ToString(grdPurchaseorderlist.Rows[grdPurchaseorderlist.CurrentCell.RowIndex].Cells["PO_CurrentSTSID"].Value) == "12")
                    {
                        if (grdPurchaseorderlist.SelectedRows.Count > 0)
                        {
                            string result = "";
                            DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                SPDataService objspdservice = new SPDataService();
                                result = "";
                                result = objspdservice.udfnPurchaseEntry(2, Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString()), 0, "", 0, 0, "", "", "", "", null, "", "", "", "", 0, "", 0, 0, 0);
                                objspdservice.CloseConnection();
                                string[] varvalue = result.Split('~');
                                if (result.Split('~')[1] == "1")
                                {
                                    MainForm.objCP_Verify = new CP_Verify();
                                    MainForm.objCP_Verify.ShowDialog();
                                    varUserID = MainForm.objCP_Verify.varUserId;
                                    if (MainForm.objCP_Verify.flag == 1)
                                    {
                                        result = "";
                                        result = objspdservice.udfnPurchaseEntry(2, Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString()), 0, "", 0, 0, "", "", "", "", null, "", "", "", "", 0, "", 0, 0, 1);
                                        objspdservice.CloseConnection();
                                        string[] varvalue1 = result.Split('~');
                                        if (varvalue1[0] == "3")
                                        {
                                            MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            udfnPOEntryLoad();
                                        }
                                        else
                                        {
                                            MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
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
        } 
        private void DGV_SearchGridPro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdProDetails.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridPro, grdProDetails);
                    objDser.CloseConnection();
                    grdProDetails.HorizontalScrollingOffset = DGV_SearchGridPro.HorizontalScrollingOffset;
                    //DGV_SearchGrid_CellPainting(sender,e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { SearchFlag = 1; }
        }

        private void DGV_SearchGridPro_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        { 
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                        return;
                    if ((e.ColumnIndex == 0) || (e.ColumnIndex == 1))  //|| e.ColumnIndex == IntDispIndex /*If not our desired columns*/
                        return; 
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    } 
                    DGV_SearchGridPro.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridPro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {

                int i = e.ColumnIndex + 2;
                if (e.ColumnIndex == 0)
                {
                    i = e.ColumnIndex;
                }
                DataGridViewColumn newColumn = grdProDetails.Columns[i];
                DataGridViewColumn oldColumn = grdProDetails.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdProDetails.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                grdProDetails.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
                DataGridViewColumn DGV = DGV_SearchGridPro.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                DGV_SearchGridPro.HorizontalScrollingOffset = grdProDetails.HorizontalScrollingOffset;
                DGV_SearchGridPro.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_SearchGridPro_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        { 
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (grdProDetails.ColumnCount > 0)
                    {
                        grdProDetails.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_SearchGridPro.HorizontalScrollingOffset = grdProDetails.HorizontalScrollingOffset;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridPro_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (DGV_SearchGridPro.IsCurrentCellDirty)
                    {
                        // Commit the changes immediately
                        DGV_SearchGridPro.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }

                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdProDetails.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridPro, grdProDetails);
                    objDser.CloseConnection();
                    grdProDetails.HorizontalScrollingOffset = DGV_SearchGridPro.HorizontalScrollingOffset;
                    //grdCompanyList(sender,e); 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnSearchGridHeadpro()
        {
            try
            {
                //udfnGridSearchHeading(grdPurchaseorderlist, DGV_SearchGrid);
                //DGV_SearchGrid.Columns.Clear();
                //List<int> visibleColumns = new List<int>();
                //foreach (DataGridViewColumn col in grdPurchaseorderlist.Columns)
                //{
                //    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                //    visibleColumns.Add(col.Index);
                //}
                //int rowIndex = 0;
                //DGV_SearchGrid.Rows.Clear();
                //DGV_SearchGrid.Rows.Add();
                //for (int i = 0; i < visibleColumns.Count; i++)
                //{
                //    DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                //}
                //DGV_SearchGrid.Columns["S.No."].ReadOnly = true; 
                //DGV_SearchGrid.Columns["clmView"].ReadOnly = true;

                if (lblNoRecordsFound.Visible == false)
                {
                    udfnSearchGridHeadpro(grdProDetails, DGV_SearchGridPro);
                    if (DGV_SearchGridPro.ColumnCount > 1)
                    {
                        DGV_SearchGridPro.Columns["S.No."].ReadOnly = true;
                        // DGV_SearchGridPro.Columns["clmView"].ReadOnly = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void udfnSearchGridHeadpro(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    //dgv2.DataSource = null;
                    dgv2.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in dgv1.Columns)
                    {
                        if (col.Visible)
                        {
                            dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                            visibleColumns.Add(col.Index);
                        }
                    }
                    int rowIndex = 0;
                    int ColIndex = 0;
                    dgv2.Rows.Clear();
                    dgv2.Rows.Add();
                    BlnSearchImageYN = false;
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                        if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                        {
                            //dgv2.Rows[rowIndex].Visible = false;
                            BlnSearchImageYN = true;
                            ColIndex = i;
                            dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                            dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                            ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                        }
                        else
                        {
                            dgv2.Rows[rowIndex].Cells[i].Value = "";
                        }
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DpPlanDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpPlanDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dptoPlanDate.MinDate = varmindate;
                dptoPlanDate.MaxDate = varmaxdate; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdProDetails_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int cl = grdProDetails.ColumnCount;
                int cls = DGV_SearchGridPro.ColumnCount;
                int offSetValue = grdProDetails.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridPro.Columns)
                    totalWidth += col.Width;

                if (totalWidth - grdProDetails.Width > grdProDetails.HorizontalScrollingOffset && grdProDetails.HorizontalScrollingOffset > 0)
                {
                    //offSetValue = offSetValue ;
                    offSetValue = offSetValue;
                }
                DGV_SearchGridPro.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridPro.Invalidate();
                udfnProscrollVisible(DGV_SearchGridPro, grdProDetails);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseorderlist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdPurchaseorderlist.Columns["clmView"].Frozen = true;
                grdPurchaseorderlist.Columns["clmPrint"].Frozen = true;
                grdPurchaseorderlist.Columns["clmEnvelopPrint"].Frozen = true;
                grdPurchaseorderlist.Columns["S.No."].Frozen = true;
                grdPurchaseorderlist.Columns["Concern"].Frozen = true;
                grdPurchaseorderlist.Columns["PO Status"].Frozen = true;
                grdPurchaseorderlist.Columns["Overall Status"].Frozen = true;
                //grdPurchaseorderlist.Columns["PO.No."].Frozen = true;
                //grdPurchaseorderlist.Columns["PO Date"].Frozen = true;
                //grdPurchaseorderlist.Columns["Supplier"].Frozen = true;
                grdPurchaseorderlist.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseorderlist.Columns["clmView"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseorderlist.Columns["clmEnvelopPrint"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseorderlist.Columns["clmPrint"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseorderlist.Columns["Concern"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseorderlist.Columns["PO Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseorderlist.Columns["Overall Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseorderlist.Columns["PO.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseorderlist.Columns["PO Date"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseorderlist.Columns["Supplier"].DefaultCellStyle.BackColor = Color.AliceBlue;

                for (int i = 0; i < grdPurchaseorderlist.Rows.Count; i++)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[i].Cells["PO Status"];
                    DataGridViewCell cell1 = dataGridView.Rows[i].Cells["clmView"];
                    if (Convert.ToInt32(grdPurchaseorderlist.Rows[i].Cells["STS"].Value.ToString()) != 12)
                    {
                        cell1.Style.BackColor = Color.LightGray;
                    }
                    if (Convert.ToString(grdPurchaseorderlist.Rows[i].Cells["STS1"].Value) == "1")
                    {
                        cell.Style.BackColor = Color.Olive;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    else if (Convert.ToString(grdPurchaseorderlist.Rows[i].Cells["STS1"].Value) == "2")
                    {
                        cell.Style.BackColor = Color.BlueViolet;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    else if (Convert.ToString(grdPurchaseorderlist.Rows[i].Cells["STS1"].Value) == "3")
                    {
                        cell.Style.BackColor = Color.LimeGreen;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    else if (Convert.ToString(grdPurchaseorderlist.Rows[i].Cells["STS1"].Value) == "4")
                    {
                        cell.Style.BackColor = Color.Tomato;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color 
                    }
                    else if (Convert.ToString(grdPurchaseorderlist.Rows[i].Cells["STS1"].Value) == "5")
                    {
                        //grdPurchaseorderlist.Rows[i].DefaultCellStyle.BackColor = Color.SteelBlue;
                        //grdPurchaseorderlist.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        cell.Style.BackColor = Color.SteelBlue;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color 
                    }
                }
                grdPurchaseorderlist.Columns["clmEnvelopPrint"].Resizable = DataGridViewTriState.False;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdPurchaseorderlist.ClearSelection();
            }
        }

        private void GrdProDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            try
            {
                for (int i = 0; i < grdProDetails.Rows.Count; i++)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[i].Cells["Status"];
                    DataGridViewCell cell1 = dataGridView.Rows[i].Cells["PO Status"];

                    if (Convert.ToString(grdProDetails.Rows[i].Cells["STSID"].Value) == "10")
                    {
                        cell.Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    else
                    {
                        cell.Style.BackColor = Color.RoyalBlue;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color 
                    }

                    if (Convert.ToString(grdProDetails.Rows[i].Cells["STS1"].Value) == "1")
                    {
                        cell1.Style.BackColor = Color.Olive;
                        cell1.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    else if (Convert.ToString(grdProDetails.Rows[i].Cells["STS1"].Value) == "2")
                    {
                        cell1.Style.BackColor = Color.BlueViolet;
                        cell1.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    else if (Convert.ToString(grdProDetails.Rows[i].Cells["STS1"].Value) == "3")
                    {
                        cell1.Style.BackColor = Color.LimeGreen;
                        cell1.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    else if (Convert.ToString(grdProDetails.Rows[i].Cells["STS1"].Value) == "4")
                    {
                        cell1.Style.BackColor = Color.Tomato;
                        cell1.Style.ForeColor = Color.White;// Set the background color to the default background color 
                    }
                    else if (Convert.ToString(grdProDetails.Rows[i].Cells["STS1"].Value) == "5")
                    {
                        cell1.Style.BackColor = Color.SteelBlue;
                        cell1.Style.ForeColor = Color.White;// Set the background color to the default background color 
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
                grdProDetails.ClearSelection();
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnExport();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        public void udfnExport()
        {
            try
            {
                if (Convert.ToInt32(cmbShow.SelectedValue) == 135)
                { 
                    udfnPOExcel();
                }
                else
                {
                    udfnProductExcel();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        public void udfnPOExcel()
        {
            try
            {

                btnExport.Enabled = false;
                lblStatus.Focus();
                if ((grdPurchaseorderlist.Rows.Count > 0))
                {
                    Excel._Application ExcelObj = new Excel.Application();
                    // creating new WorkBook within Excel application  
                    Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                    // creating new Excelsheet in workbook  
                    Excel._Worksheet ExcelSheet = null;
                    // see the excel sheet behind the program  
                    ExcelObj.Visible = true;
                    ExcelSheet = ExcelBook.Sheets["Sheet1"];
                    ExcelSheet = ExcelBook.ActiveSheet;
                    // changing the name of active sheet  
                    ExcelSheet.Name = "PO List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdPurchaseorderlist.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "PO List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;

                    foreach (DataGridViewColumn col in grdPurchaseorderlist.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            if (cIndex != 1)
                            {
                                if (cIndex == 1 || cIndex == 2) // Skip the first two columns (image columns)
                                {
                                    continue;
                                }
                                ExcelSheet.Cells[2, cIndex - 2] = col.HeaderText;
                                ExcelSheet.Columns[cIndex - 2].NumberFormat = "@";


                                if (col.Name == "S.No." || col.Name == "Total Qty")
                                {
                                    ExcelSheet.Columns[cIndex - 2].ColumnWidth = 10;
                                }
                                if (col.Name == "Concern" || col.Name == "PO.No." || col.Name == "PO Date"   
                                    || col.Name == "Mode of issue" || col.Name == "Issue Date" || col.Name == "Created By" || col.Name == "TAT" || col.Name == "Total Products")
                                {
                                    ExcelSheet.Columns[cIndex - 2].ColumnWidth = 15;
                                }
                                if (col.Name == "Supplier" || col.Name == "City" || col.Name == "Overall Status" || col.Name == "Created By")
                                {
                                    ExcelSheet.Columns[cIndex - 2].ColumnWidth = 25;
                                }


                                //else if (col.Name == "HSN Name" || col.Name == "HSN Code")
                                //{
                                //    ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                                //}
                                //else
                                //{
                                //    ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                                //}
                                if (col.Name == "S.No.")
                                {
                                    ExcelSheet.Columns[cIndex - 2].HorizontalAlignment = Excel.Constants.xlCenter;
                                }

                                if (col.Name == "Issue Date")
                                {
                                    ExcelSheet.Columns[cIndex - 2].HorizontalAlignment = Excel.Constants.xlCenter;
                                }

                                if (col.Name == "PO Date")
                                {
                                    ExcelSheet.Columns[cIndex - 2].HorizontalAlignment = Excel.Constants.xlCenter;
                                }
                                if (col.Name == "T.Pro")
                                {
                                    ExcelSheet.Columns[cIndex - 2].HorizontalAlignment = Excel.Constants.xlRight;
                                }
                                if (col.Name == "T.Units")
                                {
                                    ExcelSheet.Columns[cIndex - 2].HorizontalAlignment = Excel.Constants.xlRight;
                                }
                                if (col.Name == "TAT")
                                {
                                    ExcelSheet.Columns[cIndex - 2].HorizontalAlignment = Excel.Constants.xlRight;
                                }

                                //if (col.Name == "Total Products" || col.Name == "GST%")
                                //{
                                //    ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                                //}
                                int varSLno = 1;
                                foreach (DataGridViewRow rowa in grdPurchaseorderlist.Rows)
                                {
                                    if (cIndex != 2)
                                    {
                                        //if (cIndex == 4)
                                        //{
                                        //    ExcelSheet.Cells[rowa.Index + 3, cIndex - 1] = varSLno;
                                        //    varSLno++;
                                        //}
                                        //else
                                        //{
                                            //ExcelSheet.Row(i + 2).Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            //ExcelSheet.Row(i + 2).Style.Fill.BackgroundColor.SetColor(Color.Red);
                                            //rowa.Interior.Color = System.Drawing.Color.Red;
                                            ExcelSheet.Cells[rowa.Index + 3, cIndex - 2] = rowa.Cells[col.Index].Value;
                                            if (cIndex == 2)
                                            {
                                                //-----GET BACK COLOR OF GRID
                                                Color cellBackColor = rowa.Cells[col.Index].Style.BackColor;
                                                //------SET THE BACK COLOR FOR GRID TO EXCEL
                                                ExcelSheet.Cells[rowa.Index + 3, cIndex - 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(cellBackColor);
                                            }
                                        //}
                                    }
                                }
                            }
                            //foreach (DataGridViewRow rowa in grdPurchaseorderlist.Rows)
                            //{
                            //    ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                            //}
                        }
                    }
                    //   ExcelSheet.Protect(System.Configuration.ConfigurationManager.AppSettings["ExcelPassword"]);
                    ExcelObj.Visible = true;
                }
                else
                {
                    MessageBox.Show("No Record Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnExport.Enabled = true;
                btnExport.Focus();
            }
        }


        public void udfnProductExcel()
        {
            try
            {
                btnExport.Enabled = false;
                lblStatus.Focus();
                if ((grdProDetails.Rows.Count > 0))
                {
                    Excel._Application ExcelObj = new Excel.Application();
                    // creating new WorkBook within Excel application  
                    Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                    // creating new Excelsheet in workbook  
                    Excel._Worksheet ExcelSheet = null;
                    // see the excel sheet behind the program  
                    ExcelObj.Visible = true;
                    ExcelSheet = ExcelBook.Sheets["Sheet1"];
                    ExcelSheet = ExcelBook.ActiveSheet;
                    // changing the name of active sheet  
                    ExcelSheet.Name = "PO Product List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdProDetails.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;
                    if (Convert.ToInt32(cmbGroup.SelectedValue) == 160)
                    {
                        grdProDetails.Columns["PO No."].Width = 80;
                        grdProDetails.Columns["PO Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    if (Convert.ToInt32(cmbGroup.SelectedValue) == 159)
                    {
                        grdProDetails.Columns["Supplier"].Width = 300;
                        grdProDetails.Columns["GSTIN"].Visible = false;
                    } 

                    if (Convert.ToInt32(cmbGroup.SelectedValue) == 158)
                    {
                        ExcelSheet.Cells[1, 1].Value = "PO Product List";
                    }
                    else
                    {
                        if (Convert.ToInt32(cmbGroup.SelectedValue) == 160)
                        {
                            ExcelSheet.Cells[1, 1].Value = "PO Product List - PO No. Wise";
                        }
                        if (Convert.ToInt32(cmbGroup.SelectedValue) == 159)
                        {
                            ExcelSheet.Cells[1, 1].Value = "PO Product List - Supplier Wise";
                        }
                        if (Convert.ToInt32(cmbGroup.SelectedValue) == 161)
                        {
                            ExcelSheet.Cells[1, 1].Value = "PO Product List - Status Wise";
                        }
                        //if (Convert.ToInt32(cmbGroup.SelectedValue) == 0)
                        //{
                        //    ExcelSheet.Cells[1, 1].Value = "PO Product List";
                        //}
                    }
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdProDetails.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@"; 
                           
                            if (col.Name == "S.No." || col.Name == "Quantity")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }  

                            if (col.Name == "S.No." || col.Name == "Quantity" || col.Name == "Unit")
                            {
                                ExcelSheet.Columns[cIndex ].ColumnWidth = 10;
                            }
                            if (col.Name == "P.I Code"  )
                            {
                                ExcelSheet.Columns[cIndex ].ColumnWidth = 15;
                            }
                            if (col.Name == "Product Name"  )
                            {
                                ExcelSheet.Columns[cIndex ].ColumnWidth = 25;
                            }


                            if (Convert.ToInt32(cmbGroup.SelectedValue) == 160)
                            {
                                if (col.Name == "PO Date")
                                {
                                    ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                                }
                                if (col.Name == "PO No." || col.Name == "PO Date" )
                                {
                                    ExcelSheet.Columns[cIndex ].ColumnWidth = 15;
                                }
                            }
                            if (Convert.ToInt32(cmbGroup.SelectedValue) == 159)
                            {
                                if (col.Name == "Supplier" || col.Name == "City")
                                {
                                    ExcelSheet.Columns[cIndex ].ColumnWidth = 25;
                                }
                            }
                            foreach (DataGridViewRow rowa in grdProDetails.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                            }
                        }
                    } 

                    //   ExcelSheet.Protect(System.Configuration.ConfigurationManager.AppSettings["ExcelPassword"]);
                    ExcelObj.Visible = true;
                }
                else
                {
                    MessageBox.Show("No Record Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnExport.Enabled = true; 
            }
        }

        private void BtnExport_Enter(object sender, EventArgs e)
        {
            try
            {
                btnExport.BackColor = Color.LemonChiffon;
            }
            finally
            {
                btnExport.Enabled = true; 
            }
        }

        private void BtnExport_Leave(object sender, EventArgs e)
        {
            try
            {
                btnExport.BackColor = Color.Transparent;
            }
            finally
            {
                btnExport.Enabled = true; 
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int varSupplierId = 0;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                int varsupplier = 0, varpono = 0, varFilter = 0;
                if (Convert.ToInt32(cmbGroup.SelectedValue) == 160)
                {
                    varpono = 1;
                }
                if (Convert.ToInt32(cmbGroup.SelectedValue) == 159)
                {
                    varsupplier = 1;
                }
                if (Convert.ToInt32(cmbGroup.SelectedValue) == 158)
                {
                    varsupplier = 1;
                    varpono = 1;
                }
                if (Convert.ToInt32(cmbGroup.SelectedValue) == 161)
                {
                    varsupplier = 1;
                    varpono = 1;
                    varFilter = 1;
                }
                int varprint = 0;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                int varstatus = 0;
                int varFlag = 0, varStatusID = 0;
                if (rbComplete.Checked == true)
                {
                    varFlag = 1;
                    varStatusID = Convert.ToInt32(cmbstatus.SelectedValue);
                }
                else
                {
                    varStatusID = Convert.ToInt32(cmbstatus.SelectedValue);
                }
                int varViewType = 0;
                if (Convert.ToInt32(cmbShow.SelectedValue) == 135)
                {
                    varViewType = 1;
                }
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnPOEntry(varViewType, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), 0, 0, varsupplier, varpono, Convert.ToInt32(lblGroupId.Text), Convert.ToInt32(lblSubGroupId.Text), dpPlanDate.Text, dptoPlanDate.Text, 0, varStatusID, "0", varFilter, 0, 0, 0, 0, 0, varFlag);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count > 0)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                varprint = 1;
                            }
                        }
                    }
                    if (varprint == 1)
                    {
                        if (Convert.ToInt32(cmbShow.SelectedValue) == 135 && Convert.ToInt16(grdPurchaseorderlist.RowCount)!=0)
                        {
                            grpProFilter.BringToFront();
                            grpProFilter.Visible = true;
                            btnPrint.Enabled = false;
                            lblStatus.Focus();
                            RPTViewer.Visible = true;
                            RPTViewer.BringToFront();
                            RPTViewer.ReuseParameterValuesOnRefresh = true;
                            RPTViewer.RefreshReport();
                            CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            //if (rbComplete.Checked == true)
                            //{
                            //    varstatus = 14;
                            //}
                            //else
                            //{
                            //    varstatus = Convert.ToInt32(cmbstatus.SelectedValue);
                            //}
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Purchase_Order_List.rpt");
                            objBillreport.SetParameterValue("paraSupplierid ", Convert.ToInt32(lblSupplierCode.Text));
                            objBillreport.SetParameterValue("paraSupplierScheduleid ", Convert.ToInt32(lblschedleCode.Text));
                            objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(cmbConcern.SelectedValue));
                            objBillreport.SetParameterValue("paraConcernName", Convert.ToString(cmbConcern.Text));
                            objBillreport.SetParameterValue("paraStatusId", varStatusID);
                            objBillreport.SetParameterValue("paraFlag", varFlag);
                            objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbstatus.Text));
                            objBillreport.SetParameterValue("paraFromDate", Convert.ToString(dpPlanDate.Text));
                            objBillreport.SetParameterValue("paraToDate", Convert.ToString(dptoPlanDate.Text));
                            objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                            objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                            objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                            objValidation.CrySqlConnection(objBillreport);
                            RPTViewer.ReportSource = objBillreport;
                            RPTViewer.Refresh();
                        }
                        else if (Convert.ToInt32(cmbShow.SelectedValue) == 136 && Convert.ToInt16(grdProDetails.RowCount) != 0)
                        {
                            grpProFilter.BringToFront();
                            grpProFilter.Visible = true;
                            btnPrint.Enabled = false;
                            lblStatus.Focus();
                            RPTViewer.Visible = true;
                            RPTViewer.BringToFront();
                            RPTViewer.ReuseParameterValuesOnRefresh = true;
                            RPTViewer.RefreshReport();
                            CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        if (Convert.ToInt32(cmbGroup.SelectedValue) == 158)
                            {
                                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_ProductList.rpt");
                                objBillreport.SetParameterValue("ParaPO", 0);
                                objBillreport.SetParameterValue("ParaSupplier", 0);
                                objBillreport.SetParameterValue("parafilter", 0);
                                objBillreport.SetParameterValue("varHeader", "PO Product List");
                            }
                            if (Convert.ToInt32(cmbGroup.SelectedValue) == 160)
                            {
                                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_ProductList.rpt");
                                objBillreport.SetParameterValue("ParaPO", 1);
                                objBillreport.SetParameterValue("ParaSupplier", 0);
                                objBillreport.SetParameterValue("parafilter", 0);
                                objBillreport.SetParameterValue("varHeader", "PO Product List - PO Wise");
                            }
                            if (Convert.ToInt32(cmbGroup.SelectedValue) == 161)
                            {
                                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_ProductList.rpt");
                                objBillreport.SetParameterValue("ParaPO", 0);
                                objBillreport.SetParameterValue("ParaSupplier", 0);
                                objBillreport.SetParameterValue("parafilter", 1);
                                objBillreport.SetParameterValue("varHeader", "PO Product List - Status Wise");
                            }
                            if (Convert.ToInt32(cmbGroup.SelectedValue) == 159)
                            {
                                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_ProductList_Supplier_wise.rpt");
                                objBillreport.SetParameterValue("ParaPO", 0);
                                objBillreport.SetParameterValue("ParaSupplier", 1);
                                objBillreport.SetParameterValue("varHeader", "PO Product List - Supplier Wise");
                            }
                            //else
                            //{
                            //    if (Convert.ToInt32(cmbGroup.SelectedValue) == 159)
                            //    {
                            //        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_ProductList_PO_wise.rpt");
                            //    }
                            //    if (Convert.ToInt32(cmbGroup.SelectedValue) == 158)
                            //    {
                            //        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_ProductList_Supplierwise.rpt");
                            //    }
                            //    //if (cbPoNo.Checked == false && cbSupplier.Checked == false)
                            //    //{
                            //    //    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_PO_ProductList_Product_wise.rpt");
                            //    //}
                            //}
                            objBillreport.SetParameterValue("ParaGroupID", Convert.ToInt32(lblGroupId.Text));
                            objBillreport.SetParameterValue("ParaSubGroupID", Convert.ToString(lblSubGroupId.Text));
                            objBillreport.SetParameterValue("paraSupplierid ", Convert.ToInt32(lblSupplierCode.Text));
                            objBillreport.SetParameterValue("ParaScheduleId ", Convert.ToInt32(lblschedleCode.Text));
                            objBillreport.SetParameterValue("paraCompanyID ", Convert.ToInt32(cmbConcern.SelectedValue));
                            objBillreport.SetParameterValue("paraStatus", Convert.ToInt32(cmbProductStatus.SelectedValue));
                            objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbProductStatus.Text));
                            objBillreport.SetParameterValue("ParaPOFromDate", Convert.ToString(dpPlanDate.Text));
                            objBillreport.SetParameterValue("ParaPOToDate", Convert.ToString(dptoPlanDate.Text));
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
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        DGV_SearchGridPro.Columns.Clear();
                        grdProDetails.DataSource = null;
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnPrint.Enabled = true;
                picLoader.Visible = false;
                picLoader.SendToBack();
            }
        }

        private void CmbGroup_Leave(object sender, EventArgs e)
        {

            try
            {
                cmbGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroup_KeyDown(object sender, KeyEventArgs e)
        { 
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnViewProducts.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbGroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void RbNotcomplete_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                udfnStatusChangeDropdown();
            }
            catch (Exception ex) 
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnStatusChangeDropdown()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                if (rbNotcomplete.Checked == true)
                {
                    //cmbstatus.Enabled = true;
                    objDataBind.BindComboBoxListSelected("DEF_Status", "STSID  IN (11,13,12,27) AND STS_ModuleID=4 OR STSID=0  ", "STS_Name,STSID", cmbstatus, "", "STS_Name", "STSID");
                }
                else
                {
                    //cmbstatus.Enabled = false;
                    objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (0,4) AND STSID IN (0,9,14)", "STS_Name,STSID", cmbstatus, "", "STS_Name", "STSID");
                }
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbComplete_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (rbComplete.Checked == true)
                //{
                //    cmbstatus.Enabled = false;
                //}
                //else
                //{
                //    cmbstatus.Enabled = true;
                //}
                udfnStatusChangeDropdown();
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbNotcomplete_Enter(object sender, EventArgs e)
        {
            try{ rbNotcomplete.BackColor = Color.LemonChiffon; }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbNotcomplete_Leave(object sender, EventArgs e)
        {
            try { rbNotcomplete.BackColor = Color.White; }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbComplete_Enter(object sender, EventArgs e)
        {
            try { rbComplete.BackColor = Color.LemonChiffon; }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductStatus_Leave(object sender, EventArgs e)
        {
            try { cmbProductStatus.BackColor = Color.White; }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductStatus_Enter(object sender, EventArgs e)
        {
            try { cmbProductStatus.BackColor = Color.LemonChiffon; }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void TxtProductSearch_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductSearch.BackColor = Color.LemonChiffon;
                for (int i = 1; i < DGV_SearchGridPro.ColumnCount; i++)
                {
                    DGV_SearchGridPro.Rows[0].Cells[i].Value = "";
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductSearch.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LblDSearch_Click(object sender, EventArgs e)
        {

        }

        private void DGV_SearchGridPro_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdProDetails.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGridPro.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdProDetails.Width > grdProDetails.HorizontalScrollingOffset && grdProDetails.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGridPro.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGridPro.Invalidate();
                    udfnscrollVisiblepro(DGV_SearchGridPro, grdProDetails);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnscrollVisiblepro(DataGridView DGV, DataGridView grdGroupList)
        {
            try
            {
                var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }

                    int I = DGV_SearchGridPro.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGridPro.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGridPro.Rows[rowIndex].Cells[i].Value = "";
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

        private void GrdPurchaseorderlist_SelectionChanged(object sender, EventArgs e)
        {
            if (privilege.Contains("4"))
            {
                try
                {
                    if (Convert.ToString(grdPurchaseorderlist.Rows[grdPurchaseorderlist.CurrentCell.RowIndex].Cells["PO_CurrentSTSID"].Value) != "12")
                    { tsbDelete.Visible = false; }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        }

        private void CmbProductStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGroup.Focus();
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbComplete_Leave(object sender, EventArgs e)
        {
            try { rbComplete.BackColor = Color.White; }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
