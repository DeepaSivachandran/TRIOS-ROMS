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
    public partial class PUR_PurchaseEntryApprovedList : Form
    {
        MainForm objMainForm = new MainForm();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpSupplier = new ToolTip();
        DataTable Deftable = new DataTable();
        Boolean BlnSearchImageYN = false;
        public string pbRemarks = "";
        public string varUserID = "";

        public PUR_PurchaseEntryApprovedList()
        {
            InitializeComponent();
        }

        private void PUR_PurchaseApprovalList_Load(object sender, EventArgs e)
        {
            try
            {
                //grdPurchaseApproval.Rows.Add("1","","24/07/2023","PR001", "24/07/2023", "PO001", "15200", "","10","Pending","User1 24/06/2023 10:00AM","User2","");
                //cmbConcern.Focus();
                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (14) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,56) AND MSTID !=-1", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
                objDataBind = null;

                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
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
                objTRN_PurchaseEntry.ViewType = 13;
                objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                //objTRN_PurchaseEntry.paraStatus = Convert.ToInt32(cmbStatus.SelectedValue);
                objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(lblScheduleCode.Text);
                objTRN_PurchaseEntry.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_PurchaseEntry.paraFromDate = dpFromDate.Text;
                objTRN_PurchaseEntry.paraToDate = dpToDate.Text;
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
                            grdPurchaseEntryApproval.Columns[0].HeaderText = "";
                            grdPurchaseEntryApproval.Columns["clmUnapproved"].Visible = true;
                            grdPurchaseEntryApproval.Columns["PURID"].Visible = false;
                            grdPurchaseEntryApproval.Columns["PUR_CompleteFlag"].Visible = false;
                            grdPurchaseEntryApproval.Columns["Overall Full Status"].Visible = false;
                            grdPurchaseEntryApproval.Columns["Payment Status"].Visible = false;
                            grdPurchaseEntryApproval.Columns["TallyExportFlag"].Visible = false;
                            grdPurchaseEntryApproval.Columns["S.No."].Width = 50;
                            grdPurchaseEntryApproval.Columns["Concern"].Width = 70;
                            grdPurchaseEntryApproval.Columns["Vouc No."].Width = 70;
                            grdPurchaseEntryApproval.Columns["Vouc Date"].Width = 80;
                            grdPurchaseEntryApproval.Columns["Supplier"].Width = 300;
                            grdPurchaseEntryApproval.Columns["Pur Type"].Width = 140;
                            grdPurchaseEntryApproval.Columns["GSTIN"].Width = 120;
                            grdPurchaseEntryApproval.Columns["Inv Date"].Width = 100;
                            grdPurchaseEntryApproval.Columns["Inv No."].Width = 100;
                            grdPurchaseEntryApproval.Columns["Remarks"].Width = 150;
                            grdPurchaseEntryApproval.Columns["Overall Status"].Width = 100;
                            grdPurchaseEntryApproval.Columns["Created By"].Width = 200;
                            grdPurchaseEntryApproval.Columns["Approved By1"].Width = 200;
                            grdPurchaseEntryApproval.Columns["Approved By2"].Width = 200;
                            grdPurchaseEntryApproval.Columns["Tot Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdPurchaseEntryApproval.Columns["Vouc Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryApproval.Columns["Inv Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryApproval.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryApproval.Columns["Inv Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            grdPurchaseEntryApproval.Columns["S.No."].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Concern"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Overall Status"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Overall Full Status"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Approval No."].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Vouc No."].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Vouc Date"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Supplier"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["GSTIN"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Inv Date"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Inv No."].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Tot Pro"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Inv Amt"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Pur Type"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Created By"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Approved By1"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Approved By2"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Remarks"].ReadOnly = true;
                            grdPurchaseEntryApproval.Columns["Overall Full Status"].ReadOnly = true;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            grdPurchaseEntryApproval.Columns["clmUnapproved"].Visible = false;
                            lblNoRecordsFound.BringToFront();
                            Deftable = objDs.Tables[0];
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        grdPurchaseEntryApproval.Columns["clmUnapproved"].Visible = false;
                        lblNoRecordsFound.BringToFront();
                        Deftable = objDs.Tables[0];
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    grdPurchaseEntryApproval.Columns["clmUnapproved"].Visible = false;
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
            }
        }
        public void udfnEdit()
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                MainForm.objCP_Purchase = new CP_Purchase();
                MainForm.objCP_Purchase.pbPurchaseEntryUnapprovedFlag = 1;
                MainForm.objCP_Purchase.pbUnapprovePURID = Convert.ToInt32(grdPurchaseEntryApproval.SelectedRows[0].Cells["PURID"].Value);
                MainForm.objCP_Purchase.pbPurchaseno = Convert.ToString(grdPurchaseEntryApproval.SelectedRows[0].Cells["PURID"].Value);
                MainForm.objCP_Purchase.varUnApproveFlag = Convert.ToInt32(grdPurchaseEntryApproval.SelectedRows[0].Cells["PUR_CompleteFlag"].Value);
                MainForm.objCP_Purchase.pbPaymentCompletedFlag = Convert.ToInt32(grdPurchaseEntryApproval.SelectedRows[0].Cells["Payment Status"].Value);
                //MainForm.objCP_Purchase.lblstatusvalue.Text = Convert.ToString(grdPurchaseEntryApproval.SelectedRows[0].Cells["Status"].Value.ToString());
                //MainForm.objCP_Purchase.MdiParent = this.ParentForm;
                objMainForm.CenterEntryForm(this, MainForm.objCP_Purchase);
                MainForm.objCP_Purchase.ShowDialog();
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
        public void udfnDefcolumns()
        {
            try
            {
                DGV_SearchGrid.DataSource = null;
                DGV_SearchGrid.DataSource = Deftable;
                DGV_SearchGrid.Columns["PURID"].Visible = false;
                //.Columns["clmUnapproved"].Visible = false;
                DGV_SearchGrid.Columns["PUR_CompleteFlag"].Visible = false;
                DGV_SearchGrid.Columns["Overall Full Status"].Visible = false;
                DGV_SearchGrid.Columns["Payment Status"].Visible = false;
                DGV_SearchGrid.Columns["TallyExportFlag"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Concern"].Width = 80;
                DGV_SearchGrid.Columns["Vouc No."].Width = 100;
                DGV_SearchGrid.Columns["Vouc Date"].Width = 100;
                DGV_SearchGrid.Columns["Supplier"].Width = 300;
                DGV_SearchGrid.Columns["GSTIN"].Width = 120;
                DGV_SearchGrid.Columns["Inv Date"].Width = 100;
                DGV_SearchGrid.Columns["Inv No."].Width = 100;
                DGV_SearchGrid.Columns["Created By"].Width = 100;
                DGV_SearchGrid.Columns["Pur Type"].Width = 100;
                DGV_SearchGrid.Columns["Tot Pro"].Width = 150;
                DGV_SearchGrid.Columns["Remarks"].Width = 100;
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
                    if (DGV_SearchGrid.ColumnCount > 1)
                    {
                        int rowIndex = 0;
                        DGV_SearchGrid.Rows.Clear();
                        DGV_SearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            if (i == 0)
                            { DGV_SearchGrid.Rows[0].Cells[i].ReadOnly = true; }
                            else
                            { DGV_SearchGrid.Rows[0].Cells[i].ReadOnly = false; }
                        }
                        DGV_SearchGrid.Columns[0].ReadOnly = true;
                        DGV_SearchGrid.Columns[1].ReadOnly = true;
                        DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                    }
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
                    this.Close();
                    //MainForm.objPUR_PurchaseApprovalList = new PUR_PurchaseApprovalList();
                    //MainForm.objPUR_PurchaseApprovalList.MdiParent = this.ParentForm;
                    //MainForm.objPUR_PurchaseApprovalList.Show();
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
                    if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                        if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                        {
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All
                                & ~(DataGridViewPaintParts.ContentForeground));

                            //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                            e.Handled = true;
                        }

                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        if (e.Value == null || !(bool)e.Value)
                        {
                            e.PaintBackground(e.CellBounds, false);
                            e.Handled = true;
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
                   
                    if (e.ColumnIndex != 0)
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
                        if (newColumn.GetType() != typeof(DataGridViewImageColumn))
                        {
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
                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdPurchaseEntryApproval.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseEntryApproval);
                    objDser.CloseConnection();
                    grdPurchaseEntryApproval.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //grdCompanyList(sender,e); 
                    //grdCompanyList(sender,e); 
                }
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
                grdPurchaseEntryApproval.Columns["clmCheck"].Frozen = true;
                grdPurchaseEntryApproval.Columns["clmCheck"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseEntryApproval.Columns["clmUnapproved"].Frozen = true;
                grdPurchaseEntryApproval.Columns["clmUnapproved"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseEntryApproval.Columns["S.No."].Frozen = true;
                grdPurchaseEntryApproval.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseEntryApproval.Columns["Concern"].Frozen = true;
                grdPurchaseEntryApproval.Columns["Concern"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseEntryApproval.Columns["Overall Status"].Frozen = true;
                grdPurchaseEntryApproval.Columns["Overall Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseEntryApproval.Columns["Approval No."].Frozen = true;
                //grdPurchaseEntryApproval.Columns["Approval No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseEntryApproval.Columns["Vouc No."].Frozen = true;
                //grdPurchaseEntryApproval.Columns["Vouc No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseEntryApproval.Columns["Vouc Date"].Frozen = true;
                //grdPurchaseEntryApproval.Columns["Vouc Date"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseEntryApproval.Columns["Supplier"].Frozen = true;
                //grdPurchaseEntryApproval.Columns["Supplier"].DefaultCellStyle.BackColor = Color.AliceBlue;

                for (int i = 0; i < grdPurchaseEntryApproval.Rows.Count; i++)
                {
                    //    DataGridView dataGridView = (DataGridView)sender;
                    //    DataGridViewCell cell = dataGridView.Rows[i].Cells["Status"];
                    //    if (Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["STSID"].Value) == "49")
                    //    {
                    //        cell.Style.BackColor = Color.Red;
                    //        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    //    }
                    //    if (Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["STSID"].Value) == "50")
                    //    {
                    //        cell.Style.BackColor = Color.Green;
                    //        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    //    }
                    if (Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["PUR_CompleteFlag"].Value) == "1")
                    {
                        DataGridViewTextBoxCell UnApprove = new DataGridViewTextBoxCell();
                        UnApprove.Value = "";
                        grdPurchaseEntryApproval.Rows[i].Cells["clmUnapproved"] = UnApprove;
                        UnApprove.ReadOnly = true;
                    }
                    if (Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["TallyExportFlag"].Value) == "1")
                    {
                        DataGridViewTextBoxCell Check = new DataGridViewTextBoxCell();
                        Check.Value = "";
                        grdPurchaseEntryApproval.Rows[i].Cells["clmCheck"] = Check;
                        Check.ReadOnly = true;
                    }
                    if (Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["Payment Status"].Value) == "65" ||
                        Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["Payment Status"].Value) == "77" ||
                          Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["Payment Status"].Value) == "117")
                    {
                        DataGridViewTextBoxCell UnApprove = new DataGridViewTextBoxCell();
                        UnApprove.Value = "";
                        grdPurchaseEntryApproval.Rows[i].Cells["clmUnapproved"] = UnApprove;
                        UnApprove.ReadOnly = true;
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
                            if (cIndex == 1) // Skip the first two columns (image columns)
                            {
                                continue;
                            }
                            ExcelSheet.Cells[2, cIndex - 1] = col.HeaderText;
                            ExcelSheet.Columns[cIndex - 1].NumberFormat = "@";

                            if (col.Name == "S.No." )
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 10;
                            }
                            else if(col.Name=="GSTIN")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 20;
                            }
                            else if (col.Name == "Supplier")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 40;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 22;
                            }
                            if (col.Name == "S.No." || col.Name == "Vouc Date" || col.Name == "Inv Date")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Tot Pro" || col.Name=="Inv Amt")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            int varSLno = 1;
                            foreach (DataGridViewRow rowa in grdPurchaseEntryApproval.Rows)
                            {
                                if (cIndex == 1)
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex - 1] = varSLno;
                                    varSLno++;
                                }
                                else
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex - 1] = rowa.Cells[col.Index].Value;
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
                this.Close();
                //MainForm.objPUR_PurchaseApprovalList = new PUR_PurchaseApprovalList();
                //MainForm.objPUR_PurchaseApprovalList.MdiParent = this.ParentForm;
                //MainForm.objPUR_PurchaseApprovalList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUnapprove(int varPurchaseID)
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(121);
                objDServ.CloseConnection();
                DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string varorginator = "Purchase Unapproved", result = "";
                    SPDataService objspservice = new SPDataService();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 5;
                    objTRN_PurchaseEntry.paraUnapprovedby = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_PurchaseEntry.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_PurchaseEntry.paraRemarks = pbRemarks;
                    objTRN_PurchaseEntry.paraSaveFlag = 0;
                    objTRN_PurchaseEntry.paraOriginator = varorginator;
                    //objTRN_PurchaseEntry.paraPurchaseId = Convert.ToInt32(grdPurchaseEntryApproval.SelectedRows[0].Cells["PURID"].Value);
                    objTRN_PurchaseEntry.paraPurchaseId = varPurchaseID;
                    SPDataService objspdservice = new SPDataService();
                    result = objspdservice.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (result.Split('~')[0] == "3")
                    {
                        if (result.Split('~')[1] == "1")
                        {
                            MainForm.objCP_Verify = new CP_Verify();
                            MainForm.objCP_Verify.ShowDialog();
                            varUserID = MainForm.objCP_Verify.varUserId;
                            if (MainForm.objCP_Verify.flag == 1)
                            {
                                objspservice = new SPDataService();
                                objTRN_PurchaseEntry.ViewType = 5;
                                objTRN_PurchaseEntry.paraUnapprovedby = Convert.ToInt32(varUserID);
                                objTRN_PurchaseEntry.paraIPAddress = MainForm.pbIpAddress;
                                objTRN_PurchaseEntry.paraRemarks = pbRemarks;
                                objTRN_PurchaseEntry.paraSaveFlag = 1;
                                objTRN_PurchaseEntry.paraOriginator = varorginator;
                                objTRN_PurchaseEntry.paraPurchaseId = varPurchaseID;
                                result = objspdservice.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                                objspdservice.CloseConnection();
                                string[] varvalue1 = result.Split('~');
                                if (varvalue1[0] == "3")
                                {
                                    MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    udfnList();
                                }
                            }
                        }
                        else if (result.Split('~')[0] == "4")
                        {
                            MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    //else { MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPurchaseEntryApproval.Columns[e.ColumnIndex].Name)
                    {
                        case "clmUnapproved":
                            int varPurchaseId= Convert.ToInt32(grdPurchaseEntryApproval.SelectedRows[0].Cells["PURID"].Value);
                            udfnUnapprove(varPurchaseId);
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

        private void GrdPurchaseEntryApproval_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnTally_Enter(object sender, EventArgs e)
        {
            try
            {
                btnTally.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnTally_Leave(object sender, EventArgs e)
        {
            try
            {
                btnTally.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnTally_Click(object sender, EventArgs e)
        {
            try
            {
                udfnExportTally();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnExportTally()
        {
            try
            {
                string VarPurchaseID = "0";
                //int varflag = 0;
                for (int i = 0; i < grdPurchaseEntryApproval.Rows.Count; i++)
                {
                    if (Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["TallyExportFlag"].Value) == "0")
                    {
                        if (VarPurchaseID == "0" && Convert.ToBoolean(grdPurchaseEntryApproval.Rows[i].Cells["clmCheck"].Value) == true)
                        {
                            VarPurchaseID = Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["PURID"].Value);
                        }
                        else if (VarPurchaseID != "0" && Convert.ToBoolean(grdPurchaseEntryApproval.Rows[i].Cells["clmCheck"].Value) == true)
                        {
                            VarPurchaseID = VarPurchaseID + ',' + Convert.ToString(grdPurchaseEntryApproval.Rows[i].Cells["PURID"].Value);
                        }
                    }
                }
                if (VarPurchaseID != "0")
                {
                    SPDataService objDServ = new SPDataService();
                    string result = "";
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 6;
                    objTRN_PurchaseEntry.paraCompletedIDs = Convert.ToString(VarPurchaseID);
                    result = objDServ.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                    objDServ.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnList();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    e.Value = null;
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
