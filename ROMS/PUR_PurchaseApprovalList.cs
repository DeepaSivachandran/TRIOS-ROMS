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
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    public partial class PUR_PurchaseApprovalList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpSupplier = new ToolTip();
        DataTable Deftable = new DataTable();
        public int MenuCode = 0;
        string privilege = "",MismatachApprovalPrivilege="";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
       
        public PUR_PurchaseApprovalList()
        {
            InitializeComponent();
        }

        private void PUR_PurchaseApprovalList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 202;
                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                udfnDate();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (14) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,56) AND MSTID !=-1", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
                objDataBind = null; 
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
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
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions;    
                btnExport.Visible = privilege.Contains("6");
                tsbIncompleteList.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 25 && sp.EditAccess.Split(',').Contains("9"));
                tsbRejectedProduct.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 25 && sp.EditAccess.Split(',').Contains("9")); 
                tsbEntryApprovedList.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 26 && sp.EditAccess.Split(',').Contains("9"));
                  
                var MismatchApprovalresult = UserAccessHelper.LoadUserAccess(105);
                MismatachApprovalPrivilege = MismatchApprovalresult.PrivilegeCode;
                tsbPurchaseApproval.Visible = MismatachApprovalPrivilege.Contains("1");
                tsbMismatchCount.Visible = MismatachApprovalPrivilege.Contains("1");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDate()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 9;
                objMR_Master.paraID = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Master.paraFlag = 18;
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(objMR_Master);
                if (objd.Tables[0].Rows.Count > 0)
                {
                    DateTime varDate = DateTime.ParseExact(objd.Tables[0].Rows[0]["Transaction Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpToDate.MinDate = varDate;
                    dpFromDate.Text = Convert.ToString(DateTime.ParseExact(objd.Tables[0].Rows[0]["Transaction Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
                objDServ.CloseConnection();
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                //cmbConcern.SelectedValue = 1;
                udfnList();
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
                int Varflag = 0;
                string varSupplierId = "0";
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                else
                {
                    string[] values = new string[0];
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 31;
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblScheduleCode.Text);
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
                        errPurchaseEntryApproval.SetError(txtSupplier, "Invalid supplier.");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedleCode.Text = "0";
                        Varflag = 1;
                    }
                    else
                    {
                        errPurchaseEntryApproval.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedleCode.Text = values[1];
                        txtSupplier.BackColor = Color.White;

                    }
                }
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblScheduleCode.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                this.ActiveControl = dpFromDate;
                //********** To display a data in a grid  ****************** 
                grdPurchaseEntryApproval.DataSource = null;
                errPurchaseEntryApproval.Clear();
                DGV_SearchGrid.DataSource = null;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 12;
                objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue); 
                objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(lblScheduleCode.Text);
                objTRN_PurchaseEntry.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_PurchaseEntry.ParaPEFromDate = dpFromDate.Text;
                objTRN_PurchaseEntry.ParaPEToDate = dpToDate.Text;
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0 && Varflag == 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdPurchaseEntryApproval.DataSource = objDs.Tables[0];
                            grdPurchaseEntryApproval.Columns["S.No."].Width = 50;
                            grdPurchaseEntryApproval.Columns["Concern"].Width = 80;
                            grdPurchaseEntryApproval.Columns["Vouc No."].Width = 70;
                            grdPurchaseEntryApproval.Columns["Vouc Date"].Width = 80;
                            grdPurchaseEntryApproval.Columns["Supplier"].Width = 300;
                            grdPurchaseEntryApproval.Columns["Entry Type"].Width = 100;
                            grdPurchaseEntryApproval.Columns["GSTIN"].Width = 120;
                            grdPurchaseEntryApproval.Columns["Overall Status"].Width = 100;
                            grdPurchaseEntryApproval.Columns["Status"].Visible = false;
                            grdPurchaseEntryApproval.Columns["STSID"].Visible = false;
                            grdPurchaseEntryApproval.Columns["PURID"].Visible = false;
                            grdPurchaseEntryApproval.Columns["PUR_Created"].Visible = false;
                            grdPurchaseEntryApproval.Columns["PUR_LastTransNo"].Visible = false;
                            grdPurchaseEntryApproval.Columns["Overall Full Status"].Visible = false;
                            grdPurchaseEntryApproval.Columns["PUR_Approval_STSID"].Visible = false;
                            grdPurchaseEntryApproval.Columns["IssuseCount"].Visible = false;
                            grdPurchaseEntryApproval.Columns["Inv Date"].Width = 100;
                            grdPurchaseEntryApproval.Columns["Inv No."].Width = 100;
                            grdPurchaseEntryApproval.Columns["Remarks"].Width = 100;
                            grdPurchaseEntryApproval.Columns["Created By"].Width = 200;
                            grdPurchaseEntryApproval.Columns["Tot Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdPurchaseEntryApproval.Columns["Vouc Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryApproval.Columns["Inv Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryApproval.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryApproval.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryApproval.Columns["Inv Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                            Deftable = objDs.Tables[0];
                        }
                        if(objDs.Tables[1].Rows.Count != 0)
                        {
                            tsbRejectedProduct.Text = Convert.ToString(objDs.Tables[1].Rows[0]["TotCount"].ToString());
                        }
                        if (objDs.Tables[2].Rows.Count != 0)
                        {
                            tsbMismatchCount.Text = Convert.ToString(objDs.Tables[2].Rows[0]["MismatchCount"].ToString());
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                        Deftable = objDs.Tables[0];
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    Deftable = objDs.Tables[0];
                }
                udfnSearchGridHead();
                if (lblNoRecordsFound.Visible == true)
                {
                    udfnDefcolumns();
                }
                else { DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                lblTotal.Text = Convert.ToString(grdPurchaseEntryApproval.RowCount);
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
                    MainForm.objPUR_PurchaseEntryApproval = new PUR_PurchaseEntryApproval();
                    MainForm.objPUR_PurchaseEntryApproval.PbSTS = Convert.ToString(grdPurchaseEntryApproval.SelectedRows[0].Cells["STSID"].Value.ToString());
                    MainForm.objPUR_PurchaseEntryApproval.pbPurchaseno = Convert.ToString(grdPurchaseEntryApproval.SelectedRows[0].Cells["PURID"].Value.ToString());
                    MainForm.objPUR_PurchaseEntryApproval.lblstatusvalue.Text = Convert.ToString(grdPurchaseEntryApproval.SelectedRows[0].Cells["Status"].Value.ToString());
                    MainForm.objPUR_PurchaseEntryApproval.varApprovalStatus = Convert.ToInt32(grdPurchaseEntryApproval.SelectedRows[0].Cells["PUR_Approval_STSID"].Value.ToString());
                    MainForm.objPUR_PurchaseEntryApproval.ApproveAccess = SpecialPermissions.Any(sp => sp.MUP_Code == 23 && sp.EditAccess.Split(',').Contains("9")); 
                    MainForm.objPUR_PurchaseEntryApproval.BillrateViewAccess = SpecialPermissions.Any(sp => sp.MUP_Code == 24 && sp.EditAccess.Split(',').Contains("9")); 
                    MainForm.objPUR_PurchaseEntryApproval.BillrateEditAccess = SpecialPermissions.Any(sp => sp.MUP_Code == 24 && sp.EditAccess.Split(',').Contains("10")); 
                    MainForm.objPUR_PurchaseEntryApproval.MdiParent = this.ParentForm;
                    MainForm.objPUR_PurchaseEntryApproval.Show();
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
        public void udfnDefcolumns()
        {
            try
            {
                DGV_SearchGrid.DataSource = null;
                DGV_SearchGrid.DataSource = Deftable;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Concern"].Width = 80;
                DGV_SearchGrid.Columns["Vouc No."].Width = 100;
                DGV_SearchGrid.Columns["Vouc Date"].Width = 100;
                DGV_SearchGrid.Columns["Supplier"].Width = 300;
                DGV_SearchGrid.Columns["GSTIN"].Width = 120;
                DGV_SearchGrid.Columns["Inv Date"].Width = 100;
                DGV_SearchGrid.Columns["Inv No."].Width = 100;
                DGV_SearchGrid.Columns["Created By"].Width = 100;
                DGV_SearchGrid.Columns["Entry Type"].Width = 100;
                DGV_SearchGrid.Columns["Tot Pro"].Width = 150;
                DGV_SearchGrid.Columns["Remarks"].Width = 100;
                DGV_SearchGrid.Columns["Status"].Visible = false;
                DGV_SearchGrid.Columns["PUR_Approval_STSID"].Visible = false;
                DGV_SearchGrid.Columns["STSID"].Visible = false;
                DGV_SearchGrid.Columns["PURID"].Visible = false;
                DGV_SearchGrid.Columns["PUR_Created"].Visible = false;
                DGV_SearchGrid.Columns["PUR_LastTransNo"].Visible = false;
                DGV_SearchGrid.Columns["IssuseCount"].Visible = false;
                DGV_SearchGrid.Columns["Overall Full Status"].Visible = false;
                //DGV_SearchGrid.Columns["clmEdit"].Visible = false;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
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
                    udfnGridSearchHeading(grdPurchaseEntryApproval, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdPurchaseEntryApproval.Columns)
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
        public void udfnCmbConcern()
        {
            try
            {
                this.ActiveControl = cmbConcern;
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdPurchaseApproval_DoubleClick(object sender, EventArgs e)
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
        private void PUR_PurchaseApprovalList_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtSupplierName_Enter(object sender, EventArgs e)
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
        private void TxtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvSupplier.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        lvSupplier.Visible = false;
                    }
                    else
                    {
                        lvSupplier.Focus();
                    }
                    if (lvSupplier.Items.Count > 0)
                    {
                        lvSupplier.Items[0].Selected = true;
                    }
                }
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
        private void TxtSupplierName_Leave(object sender, EventArgs e)
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
        private void TxtSupplierName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSupplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    objMR_Supplier.ParaToDate = dpToDate.Text;
                    objMR_Supplier.paraFlag = 5;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSupplier.Items.Add(objList);
                                }
                                lvSupplier.Visible = true;
                                lvSupplier.BringToFront();
                                lvSupplier.Columns[1].Width = 0;
                                lvSupplier.Columns[2].Width = 0;
                                lvSupplier.Columns[0].Width = 250;
                                lvSupplier.Columns[3].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    lvSupplier.Visible = false;
                    lvSupplier.Items.Clear();
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
        private void LvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvSupplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                btnView.Focus();
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
                    ListViewItem selectedItem = lvSupplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblScheduleCode.Text = selectedItem.SubItems[2].Text;
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSupplier.Visible = false;
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
        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.LemonChiffon;
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
                    cmbReason.Focus();
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
        private void CmbReason_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbReason.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReason_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbReason_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbReason_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReason.BackColor = Color.White;
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
                dpFromDate.BackColor = Color.LemonChiffon;
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
        private void DpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
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
                    txtSupplier.Focus();
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

        private void PUR_PurchaseApprovalList_Leave(object sender, EventArgs e)
        {
            try
            {
                tpSupplier.Active = false;
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
                    grdPurchaseEntryApproval.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseEntryApproval);
                    objDser.CloseConnection();
                    grdPurchaseEntryApproval.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //DGV_SearchGrid_CellPainting(sender,e);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {

                    if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                        return;
                    if (!(e.ColumnIndex == 0))   /*If not our desired columns*/
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
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdPurchaseEntryApproval.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdPurchaseEntryApproval.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdPurchaseEntryApproval.SortOrder == SortOrder.Ascending)
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
                    grdPurchaseEntryApproval.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseEntryApproval.HorizontalScrollingOffset;
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
                    if (grdPurchaseEntryApproval.ColumnCount > 0)
                    {
                        grdPurchaseEntryApproval.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseEntryApproval.HorizontalScrollingOffset;
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
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdPurchaseEntryApproval.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseEntryApproval);
                objDser.CloseConnection();
                grdPurchaseEntryApproval.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }

            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdPurchaseEntryApproval.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseEntryApproval);
                    objDser.CloseConnection();
                    grdPurchaseEntryApproval.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //DGV_SearchGrid_CellPainting(sender,e);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdPurchaseEntryApproval.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdPurchaseEntryApproval.Width > grdPurchaseEntryApproval.HorizontalScrollingOffset && grdPurchaseEntryApproval.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
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

        private void GrdPurchaseEntryApproval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdPurchaseEntryApproval.Columns["S.No."].Frozen = true;
                grdPurchaseEntryApproval.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseEntryApproval.Columns["Concern"].Frozen = true;
                grdPurchaseEntryApproval.Columns["Concern"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseEntryApproval.Columns["Overall Status"].Frozen = true;
                grdPurchaseEntryApproval.Columns["Overall Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseEntryApproval.Columns["Vouc No."].Frozen = true;
                //grdPurchaseEntryApproval.Columns["Vouc No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseEntryApproval.Columns["Vouc Date"].Frozen = true;
                //grdPurchaseEntryApproval.Columns["Vouc Date"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseEntryApproval.Columns["Supplier"].Frozen = true;
                //grdPurchaseEntryApproval.Columns["Supplier"].DefaultCellStyle.BackColor = Color.AliceBlue;

                for (int i = 0; i < grdPurchaseEntryApproval.Rows.Count; i++)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    int varError = Convert.ToInt32(grdPurchaseEntryApproval.Rows[i].Cells["IssuseCount"].Value);
                    int varStatus = Convert.ToInt32(grdPurchaseEntryApproval.Rows[i].Cells["STSID"].Value);
                    int varApprovalStatus = Convert.ToInt32(grdPurchaseEntryApproval.Rows[i].Cells["PUR_Approval_STSID"].Value);
                   
                    //When purchase entry completed                  
                    if(varError > 0 )
                    {
                        grdPurchaseEntryApproval.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        grdPurchaseEntryApproval.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    if(varApprovalStatus == 63) // Entry approval  completed
                    {
                        grdPurchaseEntryApproval.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        grdPurchaseEntryApproval.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
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
                grdPurchaseEntryApproval.ClearSelection();
            }
        }
        public void udfnscrollVisible(DataGridView DGV, DataGridView grdGroupList)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    var vScrollbar = grdPurchaseEntryApproval.Controls.OfType<VScrollBar>().First();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdPurchaseEntryApproval_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdPurchaseEntryApproval.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdPurchaseEntryApproval.Width > grdPurchaseEntryApproval.HorizontalScrollingOffset && grdPurchaseEntryApproval.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdPurchaseEntryApproval);
                }
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
                btnExport.Enabled = false;
                if ((grdPurchaseEntryApproval.Rows.Count > 0))
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
                    ExcelSheet.Name = "Purchase Entry Approval";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdPurchaseEntryApproval.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Purchase Entry Approval";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdPurchaseEntryApproval.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "S.No." )
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            else if(col.Name=="GSTIN")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }
                            else if (col.Name == "Supplier")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 40;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 22;
                            }
                            if (col.Name == "S.No." || col.Name == "Vouc Date" || col.Name == "Inv Date")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Tot Pro" || col.Name=="Inv Amt")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            int varSLno = 1;
                            foreach (DataGridViewRow rowa in grdPurchaseEntryApproval.Rows)
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

        private void TsbQue_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PurchaseEntryApprovedList = new PUR_PurchaseEntryApprovedList();
                MainForm.objPUR_PurchaseEntryApprovedList.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseEntryApprovedList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseEntryApproval_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
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

        private void GrdPurchaseEntryApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TsbPurchaseApproval_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRNApprovalList = new PUR_GRNApprovalList();
                MainForm.objPUR_GRNApprovalList.ApprovalFlag = 1;
                MainForm.objPUR_GRNApprovalList.MdiParent = this.ParentForm;
                MainForm.objPUR_GRNApprovalList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseEntryApproval_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdPurchaseEntryApproval.Columns["Overall Status"].Index)
                {
                    var cell = grdPurchaseEntryApproval.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdPurchaseEntryApproval.Rows[e.RowIndex].Cells["Overall Full Status"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PurchaseEntryRejectedList = new PUR_PurchaseEntryRejectedList();
                MainForm.objPUR_PurchaseEntryRejectedList.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseEntryRejectedList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
