using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; 

namespace ROMS
{
    public partial class PUR_SupplierScheduleList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        MainForm objMainForm = new MainForm();
        int Varflag = 0;
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        int MenuCode = 0;
        public PUR_SupplierScheduleList()
        {
            InitializeComponent();
            windowControl.Initialize(tsPOScheduleList, this);
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                
                MainForm.objCP_Supplier = new CP_Supplier();
                //MainForm.objCP_Supplier.MdiParent = this.ParentForm;
                MainForm.objCP_Supplier.PoScheduleFlag = 1;
                objMainForm.CenterEntryForm(this, MainForm.objCP_Supplier);
                MainForm.objCP_Supplier.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnSchedulePopup_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                MainForm.objPUR_POScheduledaywise = new PUR_POScheduledaywise();
                MainForm.objPUR_POScheduledaywise.ShowDialog();
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

        private void PUR_SupplierScheduleList_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.P))
                {
                     TsbList_Click(sender, e);
                }
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
        private void PUR_SupplierScheduleList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 101;
                this.ActiveControl = txtSupplier;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (-1)", "DY_Name,DYID", cmbDay, "", "DY_Name", "DYID");
                objDataBind.BindComboBoxListSelected("(SELECT STSID,STS_Name,STS_ModuleID FROM DEF_Status WHERE STS_ModuleID IN(0, 1) AND STSID<>-1 UNION ALL  SELECT -2, 'Not defined',1)AS DIV", "1=1", "STSID, STS_Name", cmbStatus, "", "STS_Name", "STSID");
                //  objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID in (13) OR MSTID IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrder, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("MR_Supplier_Schedule", "SPSCID=0", "SPSC_Name,SPSCID", cmbOrderSchedule, "", "SPSC_Name", "SPSCID");
                objDataBind = null;
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();

                int varconcerntype = 2;
                objDT = objdserv.udfnCompanyList(varconcerntype, 0, MainForm.pbUserID, MainForm.pbIpAddress,0);
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
                objDT = objdserv.udfnCompanyList(varconcerntype, 0, MainForm.pbUserID, MainForm.pbIpAddress,0);
                objdserv.CloseConnection();
                cmbConcernPrint.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbConcernPrint.ValueMember = "COMID";
                            cmbConcernPrint.DisplayMember = "COM_ShortName";
                            cmbConcernPrint.DataSource = objDT.Tables[0];
                        }
                    }
                }
                cmbDay.SelectedValue = 0;
                cmbOrder.SelectedValue = 0;
                cmbStatus.SelectedValue = 0;
                cmbOrderSchedule.SelectedValue = 0;
                cmbConcernPrint.SelectedValue = 0;
                udfncmbLoad();
                udfnList();
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(MenuCode); 
                string privilege = result.PrivilegeCode;
                List<(int MUP_Code, string EditAccess)> SpecialPermissions = result.SpecialPermissions; 
                btnPrint.Visible = privilege.Contains("5");
                btnExport.Visible = privilege.Contains("6");
                tsbList.Visible=SpecialPermissions.Any (sp => sp.MUP_Code == 13 && sp.EditAccess.Split(',').Contains("9")); 
                //for new supplier 
                var supplierResult = UserAccessHelper.LoadUserAccess(507);
                string SupPrivilege = supplierResult.PrivilegeCode;
                List<(int MUP_Code, string EditAccess)> SupSpecial = supplierResult.SpecialPermissions;
                tsbNew.Visible = SupPrivilege.Contains("2");
                tssNewSupplier.Visible = SupPrivilege.Contains("2");
                dgvSupplierScheduleList.Enabled = SupPrivilege.Contains("3"); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfncmbLoad()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 6;
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                cmbOrder.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbOrder.Enabled = true;
                            cmbOrder.ValueMember = "MSTID";
                            cmbOrder.DisplayMember = "MST_DisplayText";
                            cmbOrder.DataSource = objDT.Tables[0];
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
        public void udfnList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                Varflag = 0;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                ep_Supplierlist.Clear();
                dgvSupplierScheduleList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                string varSupplierId = "0";
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedule.Text = "0";
                }
                //else
                //{
                //    DataService objDServ = new DataService();
                //    string varId_Supplier = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_Supplier WHERE SP_Name = '" + txtSupplier.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT SPID FROM MR_Supplier WHERE SP_Name = '" + txtSupplier.Text.Trim() + "') END AS SPID ");
                //    objDServ.CloseConnection();
                //    varSupplierId = Convert.ToInt32(varId_Supplier);
                //} else
                else
                {
                    string[] values = new string[0];
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 31;
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varSupplierId = Convert.ToString(objDsSupplierId.Tables[0].Rows[0][0]);
                                values = Convert.ToString(varSupplierId).Split(',');
                            }
                        }
                    }
                    if (values[0] == "-1")
                    {
                        ep_Supplierlist.SetError(txtSupplier, "Invalid supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        Varflag = 1;
                    }
                    else
                    {
                        ep_Supplierlist.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White;
                    }
                    //VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                }
                if (Varflag == 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 8;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(cmbOrderSchedule.SelectedValue);
                    objMR_Supplier.pardayid = Convert.ToInt32(cmbDay.SelectedValue);
                    objMR_Supplier.paraOrderId = Convert.ToInt32(cmbOrder.SelectedValue);
                    objMR_Supplier.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                    objDs = objdserv.udfnSupplierList(objMR_Supplier);
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

                                dgvSupplierScheduleList.DataSource = objDs.Tables[0];
                                //grdSupplierList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //grdSupplierList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dgvSupplierScheduleList.Columns["S.No."].Width = 40;
                                dgvSupplierScheduleList.Columns["Supplier"].Width = 300;
                                dgvSupplierScheduleList.Columns["GSTIN"].Width = 120;
                                dgvSupplierScheduleList.Columns["City"].Width = 130;
                                dgvSupplierScheduleList.Columns["Schedule Status"].Width = 120;
                                dgvSupplierScheduleList.Columns["Order Type"].Width = 90;
                                dgvSupplierScheduleList.Columns["Ret. Policy"].Width = 90;
                                dgvSupplierScheduleList.Columns["Days"].Width = 90;
                                dgvSupplierScheduleList.Columns["Pro. Mapping"].Width = 90;
                                dgvSupplierScheduleList.Columns["Ret. Policy"].Width = 80;
                                dgvSupplierScheduleList.Columns["Scheduleid"].Visible = false;
                                dgvSupplierScheduleList.Columns["SupplierID"].Visible = false;
                                dgvSupplierScheduleList.Columns["ORDERTYPE"].Visible = false;
                                dgvSupplierScheduleList.Columns["MappedStatus"].Visible = false;
                                dgvSupplierScheduleList.Columns["STATUS CODE"].Visible = false;
                                dgvSupplierScheduleList.Columns["SP_ReturnApplicable"].Visible = false;
                                dgvSupplierScheduleList.Columns["SPSC_OrderType"].Visible = false;
                                dgvSupplierScheduleList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dgvSupplierScheduleList.Columns["Ret. Policy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dgvSupplierScheduleList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            }
                            else
                            {
                                lblNoRecordsFound.Visible = true;
                                lblNoRecordsFound.BringToFront();
                            }
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                    udfnSearchGridHead();
                    if (lblNoRecordsFound.Visible == true)
                    {
                        dtDefaultGrid = objDs.Tables[0];
                        udfnDefaultSearchGrid();
                    }
                    else
                    {
                        DGV_SearchGrid.ScrollBars = ScrollBars.Vertical;
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    dgvSupplierScheduleList.DataSource = null;

                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //  grdreplist.ClearSelection();
                picLoader.Visible = false;
                picLoader.SendToBack(); 
                btnView.Enabled = true;
                btnView.Focus();
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["S.No."].Width = 40;
                DGV_SearchGrid.Columns["Supplier"].Width = 300;
                DGV_SearchGrid.Columns["GSTIN"].Width = 120;
                DGV_SearchGrid.Columns["City"].Width = 130;
                DGV_SearchGrid.Columns["Schedule Status"].Width = 120;
                DGV_SearchGrid.Columns["Order Type"].Width = 90;
                DGV_SearchGrid.Columns["Ret. Policy"].Width = 90;
                DGV_SearchGrid.Columns["Days"].Width = 90;
                DGV_SearchGrid.Columns["Pro. Mapping"].Width = 90;
                DGV_SearchGrid.Columns["Ret. Policy"].Width = 80;
                DGV_SearchGrid.Columns["Scheduleid"].Visible = false;
                DGV_SearchGrid.Columns["SupplierID"].Visible = false;
                DGV_SearchGrid.Columns["ORDERTYPE"].Visible = false;
                DGV_SearchGrid.Columns["MappedStatus"].Visible = false;
                DGV_SearchGrid.Columns["STATUS CODE"].Visible = false;
                DGV_SearchGrid.Columns["SP_ReturnApplicable"].Visible = false;
                DGV_SearchGrid.Columns["SPSC_OrderType"].Visible = false;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
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
                    cmbStatus.Focus();
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

        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrder.Focus();
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

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbStatus.Select(int.MaxValue, 0)));
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
                LV_Supplier.Visible = false;
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrder.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDay_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbDay_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDay.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDay_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbDay.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbDay.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbOrder.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrder_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrder.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbOrder_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbOrder_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbOrder_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbOrder.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliernameprint_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrderSchedule.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSupplerName.Items.Count == 0 || txtsuppliernameprint.Text == "")
                    {
                        txtsuppliernameprint.Focus();
                        lvSupplerName.Visible = false;
                    }
                    else
                    {
                        lvSupplerName.Focus();
                    }
                    if (lvSupplerName.Items.Count > 0)
                    {
                        lvSupplerName.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsuppliernameprint_Leave(object sender, EventArgs e)
        {
            try
            {
                txtsuppliernameprint.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Txtsuppliernameprint_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                txtsuppliernameprint.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderSchedule_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrderSchedule_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderSchedule.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrderSchedule_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbOrderSchedule.BackColor = Color.LemonChiffon;
                cmbschedulebind();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        public void cmbschedulebind()
        {
            try
            {
                int cmbsuppleirid = 0;
                if (lblSuppliernameprint.Text == "0")
                {
                    cmbsuppleirid = 0;
                }
                else
                {
                    cmbsuppleirid = Convert.ToInt32(lblSuppliernameprint.Text);
                }
                if (txtsuppliernameprint.Text == "")
                {
                    lblSuppliernameprint.Text = "0";
                    cmbsuppleirid = 0;
                }
                if (Convert.ToString(txtsuppliernameprint.Text) != "")
                {
                    string varsuppliername = "0";
                    DataService objDserv = new DataService();
                    varsuppliername = objDserv.displaydata("SELECT COUNT(*) FROM MR_Supplier WHERE SP_Name='" + txtsuppliernameprint.Text + "'");
                    if (varsuppliername == "0")
                    {
                        lblSuppliernameprint.Text = "0";
                        ep_Supplierlist.SetError(txtsuppliernameprint, "Invalid supplier");
                        txtsuppliernameprint.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier", txtsuppliernameprint, 5000);
                    }
                    else
                    {
                        ep_Supplierlist.Clear();
                        txtsuppliernameprint.BackColor = Color.White;
                    }
                }

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Supplier_Schedule", "SPSC_SPID='" + cmbsuppleirid + "' or SPSCID=0", "SPSC_Name,SPSCID", cmbOrderSchedule, "", "SPSC_Name", "SPSCID");
                objDataBind = null;
            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderSchedule_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbOrderSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
                try
            {
                BeginInvoke(new Action(() => cmbOrderSchedule.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                rbTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                rbTamil.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbTamil_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbEnglish.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                rbEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                rbEnglish.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbEnglish_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
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

        private void BtnSchedulePopup_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSchedulePopup.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSchedulePopup_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                btnSchedulePopup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = dgvSupplierScheduleList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = dgvSupplierScheduleList.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        dgvSupplierScheduleList.SortOrder == SortOrder.Ascending)
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
                dgvSupplierScheduleList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGrid.HorizontalScrollingOffset = dgvSupplierScheduleList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }
        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 0))   /*If not our desired columns*/
                                                                   //return;

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
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (dgvSupplierScheduleList.ColumnCount > 0)
                {
                    dgvSupplierScheduleList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = dgvSupplierScheduleList.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(dgvSupplierScheduleList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in dgvSupplierScheduleList.Columns)
                    {
                        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                }
            }
            catch (Exception ex)
            { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
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
                    dgv2.Rows.Clear();
                    dgv2.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 15;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.BringToFront();
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
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

        private void LV_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
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
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                }
                cmbStatus.Focus();
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
        public void udfnListViewnameData()
        {
            try
            {
                if (txtsuppliernameprint.Text != "")
                {
                    ListViewItem selectedItem = lvSupplerName.SelectedItems[0];
                    txtsuppliernameprint.Text = selectedItem.SubItems[0].Text;
                    lblSuppliernameprint.Text = selectedItem.SubItems[1].Text;

                }
                cmbOrder.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSupplerName.Visible = false;
            }
        }


        private void Txtsuppliernameprint_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSupplerName.Items.Clear();
                if (txtsuppliernameprint.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 6;
                    objMR_Supplier.paraSupplierName = txtsuppliernameprint.Text;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSupplerName.Items.Add(objList);
                                }
                                lvSupplerName.Visible = true;
                                lvSupplerName.BringToFront();
                                lvSupplerName.Columns[1].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    lvSupplerName.Visible = false;
                    lvSupplerName.Items.Clear();
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

        private void LvSupplerName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewnameData();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void LvSupplerName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewnameData();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void DgvSupplierScheduleList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvSupplierScheduleList.Columns["S.No."].Frozen = true;
                dgvSupplierScheduleList.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                dgvSupplierScheduleList.Columns["City"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //dgvSupplierScheduleList.Columns["Supplier Type"].DefaultCellStyle.BackColor = Color.AliceBlue;
                dgvSupplierScheduleList.Columns["Supplier"].Frozen = true;
                dgvSupplierScheduleList.Columns["Supplier"].DefaultCellStyle.BackColor = Color.AliceBlue;
                dgvSupplierScheduleList.Columns["City"].Frozen = true;
               // dgvSupplierScheduleList.Columns["GSTIN"].DefaultCellStyle.BackColor = Color.AliceBlue;
                for (int i = 0; i < dgvSupplierScheduleList.Rows.Count; i++)
                {
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["MappedStatus"].Value) == "4" && Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["Pro. Mapping"].Value) != "")
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Pro. Mapping"].Style.BackColor = Color.PaleVioletRed;
                       dgvSupplierScheduleList.Rows[i].Cells["Pro. Mapping"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["MappedStatus"].Value) == "5" && Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["Pro. Mapping"].Value) != "")
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Pro. Mapping"].Style.BackColor = Color.DeepSkyBlue;
                        dgvSupplierScheduleList.Rows[i].Cells["Pro. Mapping"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["MappedStatus"].Value) == "-2" && Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["Pro. Mapping"].Value) != "")
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Pro. Mapping"].Style.BackColor = Color.SteelBlue;
                        dgvSupplierScheduleList.Rows[i].Cells["Pro. Mapping"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["Status Code"].Value) == "1") // Active
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Schedule Status"].Style.BackColor = Color.LimeGreen;
                        dgvSupplierScheduleList.Rows[i].Cells["Schedule Status"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["Status Code"].Value) == "0") // Not defined
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Schedule Status"].Style.BackColor = Color.SteelBlue;
                        dgvSupplierScheduleList.Rows[i].Cells["Schedule Status"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["Status Code"].Value) == "2") // Inactive
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Schedule Status"].Style.BackColor = Color.Red;
                        dgvSupplierScheduleList.Rows[i].Cells["Schedule Status"].Style.ForeColor = Color.White;

                        dgvSupplierScheduleList.Rows[i].Cells["Supplier"].Style.BackColor = Color.Red;
                        dgvSupplierScheduleList.Rows[i].Cells["Supplier"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["SP_ReturnApplicable"].Value) == "-1" || Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["SP_ReturnApplicable"].Value) == "0") // Not Defined
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Ret. Policy"].Style.BackColor = Color.SteelBlue;
                        dgvSupplierScheduleList.Rows[i].Cells["Ret. Policy"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["SPSC_OrderType"].Value) == "144") // Unscheduled order type
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Order Type"].Style.BackColor = Color.MediumSpringGreen;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["Order Type"].Value) == "Not Defined") // Unscheduled supplier order type
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Order Type"].Style.BackColor = Color.SteelBlue;
                        dgvSupplierScheduleList.Rows[i].Cells["Order Type"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["Days"].Value) == "Unscheduled") // Unscheduled order type
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Days"].Style.BackColor = Color.Purple;
                        dgvSupplierScheduleList.Rows[i].Cells["Days"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(dgvSupplierScheduleList.Rows[i].Cells["Days"].Value) == "Not Defined") // Not defined days
                    {
                        dgvSupplierScheduleList.Rows[i].Cells["Days"].Style.BackColor = Color.SteelBlue;
                        dgvSupplierScheduleList.Rows[i].Cells["Days"].Style.ForeColor = Color.White;
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
                dgvSupplierScheduleList.ClearSelection();
            }
        }

        private void udfnEdit()
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                if (dgvSupplierScheduleList.SelectedRows.Count > 0)
                {
                    MainForm.objCP_Supplier = new CP_Supplier();
                    //MainForm.objCP_Supplier.MdiParent = this.ParentForm;
                    MainForm.objCP_Supplier.btnSave.Text = "Update";
                    MainForm.objCP_Supplier.pbSupplierid = Convert.ToString(dgvSupplierScheduleList.SelectedRows[0].Cells["SupplierID"].Value.ToString());
                    MainForm.objCP_Supplier.PoScheduleFlag = 1;

                    objMainForm.CenterEntryForm(this, MainForm.objCP_Supplier);
                    MainForm.objCP_Supplier.ShowDialog();
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
            }
        }
        private void DgvSupplierScheduleList_DoubleClick(object sender, EventArgs e)
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

        private void DgvSupplierScheduleList_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                btnView.Enabled = false; 
                lblStatus.Focus();
                udfnList();
                RPTViewer.Visible = false; 
                RPTViewer.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                dgvSupplierScheduleList.ClearSelection(); 
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

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbConcern.BackColor = Color.LemonChiffon;
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
        private void BtnListPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnListPrint.Enabled = false;
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                RPTViewer.ReuseParameterValuesOnRefresh = true;
                RPTViewer.RefreshReport();
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                int varlanguage = 0;string varlblsupplierprint = "0";
                if (rbEnglish.Checked == true)
                {
                    varlanguage = 1;
                }
                else { varlanguage = 2; }

                if (txtsuppliernameprint.Text != "")
                {
                    varlblsupplierprint = lblSuppliernameprint.Text;
                }
                else
                {
                    varlblsupplierprint = "0";
                }
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_SupplierProductList.rpt");
                objBillreport.SetParameterValue("@paracompanycode",Convert.ToInt32(cmbConcernPrint.SelectedValue));
                objBillreport.SetParameterValue("@paraOrderID", Convert.ToInt32(cmbOrder.SelectedValue));
                objBillreport.SetParameterValue("@parascheduleid", Convert.ToInt32(cmbOrderSchedule.SelectedValue)); 
                objBillreport.SetParameterValue("@parasupplierid", varlblsupplierprint);
                objBillreport.SetParameterValue("@paraProductType", varlanguage); 
                objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                objBillreport.SetParameterValue("pardayid", Convert.ToInt32(cmbDay.SelectedValue));
                objValidation.CrySqlConnection(objBillreport);
                RPTViewer.ReportSource = objBillreport;
                RPTViewer.Refresh();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                dgvSupplierScheduleList.ClearSelection();
                btnListPrint.Enabled = true;
                GC.Collect();
            }
        }

        private void PUR_SupplierScheduleList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            { 
                //if (this.RPTViewer != null)
                //{
                //    RPTViewer.ReportSource = null;
                //    this.RPTViewer.Dispose();
                //    objBillreport.Close();
                //    objBillreport.Dispose();
                //    objBillreport = null;
                //    GC.Collect();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                GC.Collect(); 
            }
        }

        private void CmbConcernPrint_Leave(object sender, EventArgs e)
        { 
            try
            {
                cmbConcernPrint.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcernPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcernPrint.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcernPrint_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbDay.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcernPrint_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbConcernPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbConcernPrint.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void PUR_SupplierScheduleList_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.RPTViewer != null)
                {
                    RPTViewer.ReportSource = null;
                    this.RPTViewer.Dispose();
                    objBillreport.Close();
                    objBillreport.Dispose();
                    objBillreport = null;
                    GC.Collect();
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
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                dgvSupplierScheduleList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, dgvSupplierScheduleList);
                objDser.CloseConnection();
                dgvSupplierScheduleList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void TsbList_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                MainForm.objPUR_POScheduleSummary = new PUR_POScheduleSummary();
                MainForm.objPUR_POScheduleSummary.ShowDialog();
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
        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {

                    int totalWidth = 0;
                    int offSetValue = dgvSupplierScheduleList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - dgvSupplierScheduleList.Width > dgvSupplierScheduleList.HorizontalScrollingOffset && dgvSupplierScheduleList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();

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
                            DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
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
        private void DgvSupplierScheduleList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = dgvSupplierScheduleList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - dgvSupplierScheduleList.Width > dgvSupplierScheduleList.HorizontalScrollingOffset && dgvSupplierScheduleList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, dgvSupplierScheduleList);
                }
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
        public void udfnImport()
        {
            try
            {
                btnExport.Enabled = false;
                lblStatus.Focus();
                if ((dgvSupplierScheduleList.Rows.Count > 0))
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
                    ExcelSheet.Name = "PO Schedule";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in dgvSupplierScheduleList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "PO Schedule";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in dgvSupplierScheduleList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "Supplier")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 30;
                            }
                           else if ( col.Name == "GSTIN")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 25;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            if (col.Name == "S.No." )
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Total Products")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            int varSLno = 1;
                            foreach (DataGridViewRow rowa in dgvSupplierScheduleList.Rows)
                            {
                                if (cIndex == 1)
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex] = varSLno;
                                    varSLno++;
                                }
                                else
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                                }
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
                btnExport.Focus();
            }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnImport();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnView_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnExport_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string varSupplierId = "0";
                if (txtSupplier.Text == "")
                {
                    varSupplierId = "0";
                }
                else
                {
                    string[] values = new string[0];
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 31;
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varSupplierId = Convert.ToString(objDsSupplierId.Tables[0].Rows[0][0]);
                                values = Convert.ToString(varSupplierId).Split(',');
                            }
                        }
                    }
                    if (values[0] == "-1")
                    {
                        ep_Supplierlist.SetError(txtSupplier, "Invalid supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        Varflag = 1;
                    }
                    else
                    {
                        ep_Supplierlist.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White; 

                    }
                    //VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                }
                //else
                //{
                //    DataService objDServ = new DataService();
                //    string varId_Supplier = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_Supplier WHERE SP_Name = '" + txtSupplier.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT SPID FROM MR_Supplier WHERE SP_Name = '" + txtSupplier.Text.Trim() + "') END AS SPID ");
                //    objDServ.CloseConnection();
                //    varSupplierId = Convert.ToInt32(varId_Supplier);
                //}
                if (Varflag == 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 8;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.pardayid = Convert.ToInt32(cmbDay.SelectedValue);
                    objMR_Supplier.paraOrderId = Convert.ToInt32(cmbOrder.SelectedValue);
                    objMR_Supplier.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                    SPDataService objDServ = new SPDataService();
                    DataSet objDs = new DataSet();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objDs = objDServ.udfnSupplierList(objMR_Supplier);
                    objDServ.CloseConnection();
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        btnListPrint.Enabled = false;
                        lblStatus.Focus();
                        RPTViewer.Visible = true;
                        RPTViewer.BringToFront();
                        RPTViewer.ReuseParameterValuesOnRefresh = true;
                        RPTViewer.RefreshReport();
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_SupplierScheduleList.rpt");
                        objBillreport.SetParameterValue("paraSupplierid", Convert.ToInt32(lblSupplierCode.Text));
                        objBillreport.SetParameterValue("paradayid", Convert.ToInt32(cmbDay.SelectedValue));
                        objBillreport.SetParameterValue("paraSupplierScheduleid", Convert.ToInt32(cmbOrderSchedule.SelectedValue));
                        //objBillreport.SetParameterValue("paraSupplierid", Convert.ToInt32(cmbStatus.SelectedValue));
                        objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                        objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        objBillreport.SetParameterValue("paraStatusName", cmbStatus.Text);
                        objBillreport.SetParameterValue("paraOrderId", Convert.ToInt32(cmbOrder.SelectedValue));
                        objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                        objValidation.CrySqlConnection(objBillreport);
                        RPTViewer.ReportSource = objBillreport;
                        RPTViewer.Refresh();
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    dgvSupplierScheduleList.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                dgvSupplierScheduleList.ClearSelection();
                btnListPrint.Enabled = true;
                GC.Collect();
            }
        }
        
        private void BtnPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                btnPrint.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnPrint_Leave(object sender, EventArgs e)
        {
            try
            {
                btnPrint.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnPrint_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnPrint_Click(sender, e);
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
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                dgvSupplierScheduleList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, dgvSupplierScheduleList);
                objDser.CloseConnection();
                dgvSupplierScheduleList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
