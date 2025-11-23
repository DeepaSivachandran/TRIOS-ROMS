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
    public partial class PUR_PurchaseQueue : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public bool EditAccess = false;
        public PUR_PurchaseQueue()
        {
            InitializeComponent();
        }

        private void PUR_PurchaseQueue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    // tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    // tsbEdit_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    //MainForm objMainForm = new MainForm();
                    //objMainForm.udfnCloseChildForms();
                    //MainForm.objCP_PurchaseList = new CP_PurchaseList();
                    //MainForm.objCP_PurchaseList.MdiParent = this.ParentForm;
                    //MainForm.objCP_PurchaseList.Show();
                    this.Close();
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbPurchaseList_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                //MainForm.objCP_PurchaseList = new CP_PurchaseList();
                //MainForm.objCP_PurchaseList.MdiParent = this.ParentForm;
                //MainForm.objCP_PurchaseList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PUR_PurchaseQueue_Load(object sender, EventArgs e)
        {
            try
            {
                //cmbEntryType.Items.Add("From GRN");
                //cmbEntryType.Items.Add("From DC");
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                udfnDate();
                udfncmbDropdown();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                this.ActiveControl = cmbConcern;
                //txtSupplier.Focus();
                // cmbStatus.SelectedValue = 18; //pending
                udfnList();
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
                objMR_Master.paraFlag = 16;
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(objMR_Master);
                if (objd.Tables[0].Rows.Count > 0)
                {
                    DateTime varDate = DateTime.ParseExact(objd.Tables[0].Rows[0]["Entry Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpToDate.MinDate = varDate;
                    dpFromDate.Text = Convert.ToString(objd.Tables[0].Rows[0]["DATE1"]);
                }
                objDServ.CloseConnection();
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                //cmbConcern.SelectedValue = 1;
                //udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["Concern"].Width = 80;
                DGV_SearchGrid.Columns["Entry Date"].Width = 100;
                DGV_SearchGrid.Columns["Entry No."].Width = 80;
                DGV_SearchGrid.Columns["Supplier"].Width = 250;
                DGV_SearchGrid.Columns["Total Products"].Width = 100;
                DGV_SearchGrid.Columns["Created By"].Width = 110;
                DGV_SearchGrid.Columns["GRN_Payment_STSID"].Visible = false;
                DGV_SearchGrid.Columns["GSTIN"].Width = 150;
                DGV_SearchGrid.Columns["S.No."].Width = 60;
                DGV_SearchGrid.Columns["SPID"].Visible = false;
                DGV_SearchGrid.Columns["SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["Entry Date1"].Visible = false;
                DGV_SearchGrid.Columns["Flag"].Visible = false;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
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
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedule.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                this.ActiveControl = dpFromDate;
                //********** To display a data in a grid  ****************** 
                grdPurchaseEntryQueueList.DataSource = null;
                //errPurchaseList.Clear();
                DGV_SearchGrid.DataSource = null;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 7;
                objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(lblschedule.Text);
                objTRN_PurchaseEntry.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_PurchaseEntry.paraFromDate = dpFromDate.Text;
                objTRN_PurchaseEntry.paraToDate = dpToDate.Text;
                objTRN_PurchaseEntry.paraType = Convert.ToInt32(cmbEntryType.SelectedValue);
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdPurchaseEntryQueueList.DataSource = objDs.Tables[0];
                            grdPurchaseEntryQueueList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryQueueList.Columns["Entry No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryQueueList.Columns["Entry Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryQueueList.Columns["Invoice Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryQueueList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdPurchaseEntryQueueList.Columns["Concern"].Width = 80;
                            grdPurchaseEntryQueueList.Columns["Entry Date"].Width = 100;
                            grdPurchaseEntryQueueList.Columns["Entry No."].Width = 80;
                            grdPurchaseEntryQueueList.Columns["Supplier"].Width = 250;
                            grdPurchaseEntryQueueList.Columns["Total Products"].Width = 100;
                            grdPurchaseEntryQueueList.Columns["Created By"].Width = 200;
                            //grdPurchaseEntryQueueList.Columns["Created On"].Width = 140;
                            grdPurchaseEntryQueueList.Columns["GSTIN"].Width = 150;
                            grdPurchaseEntryQueueList.Columns["S.No."].Width = 60;
                            grdPurchaseEntryQueueList.Columns["SPID"].Visible = false;
                            grdPurchaseEntryQueueList.Columns["SPSCID"].Visible = false;
                            grdPurchaseEntryQueueList.Columns["ID"].Visible = false;
                            grdPurchaseEntryQueueList.Columns["Entry Date1"].Visible = false;
                            grdPurchaseEntryQueueList.Columns["Flag"].Visible = false;
                            grdPurchaseEntryQueueList.Columns["QR Code"].Visible = false;
                            grdPurchaseEntryQueueList.Columns["GRN_Payment_StsID"].Visible = false;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
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
                picLoader.SendToBack();
                grdPurchaseEntryQueueList.ClearSelection();
            }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdPurchaseEntryQueueList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdPurchaseEntryQueueList.Columns)
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
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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
        public void udfncmbDropdown()
        {
            try
            {
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();

                int varconcerntype = 2;
                objDT = objdserv.udfnCompanyList(varconcerntype, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=58 OR  MSTID IN (0)", "MST_DisplayText,MSTID", cmbEntryType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
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
                dpFromDate.BackColor = Color.LemonChiffon;
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
        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbEntryType.Focus();
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
        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 15;
                    //objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    //objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    //objMR_Supplier.ParaToDate = dpToDate.Text;
                   // objMR_Supplier.paraFlag = 5;
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
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                    //udfnsupplierLoad();
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    cmbEntryType.Focus();
                }
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
        private void CmbEntryType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbEntryType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbEntryType_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbEntryType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbEntryType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbEntryType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbEntryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbEntryType.Select(int.MaxValue, 0)));
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

        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdPurchaseEntryQueueList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseEntryQueueList);
                    objDser.CloseConnection();
                    grdPurchaseEntryQueueList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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

                            TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                                e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                            e.Handled = true;
                        }
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdPurchaseEntryQueueList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdPurchaseEntryQueueList.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdPurchaseEntryQueueList.SortOrder == SortOrder.Ascending)
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
                grdPurchaseEntryQueueList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseEntryQueueList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdPurchaseEntryQueueList.ColumnCount > 0)
                {
                    grdPurchaseEntryQueueList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseEntryQueueList.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
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
                grdPurchaseEntryQueueList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseEntryQueueList);
                objDser.CloseConnection();
                grdPurchaseEntryQueueList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }

            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void GrdPurchaseEntryQueueList_DoubleClick(object sender, EventArgs e)
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
            if (Convert.ToInt32(MainForm.pbUserRoleId) == 1 || EditAccess==true)
            {
                try
                {
                    MainForm.objCP_Purchase = new CP_Purchase();
                    MainForm.objCP_Purchase.varQueueFlag = 1;
                    MainForm.objCP_Purchase.PbID = Convert.ToString(grdPurchaseEntryQueueList.SelectedRows[0].Cells["ID"].Value.ToString());
                    MainForm.objCP_Purchase.PbFlag = Convert.ToString(grdPurchaseEntryQueueList.SelectedRows[0].Cells["Flag"].Value.ToString());
                    MainForm.objCP_Purchase.lblschedule.Text = Convert.ToString(grdPurchaseEntryQueueList.SelectedRows[0].Cells["SPSCID"].Value.ToString());
                    MainForm.objCP_Purchase.lblSupplierCode.Text = Convert.ToString(grdPurchaseEntryQueueList.SelectedRows[0].Cells["SPID"].Value.ToString());
                    MainForm.objCP_Purchase.txtSupplier.Text = Convert.ToString(grdPurchaseEntryQueueList.SelectedRows[0].Cells["SUPPLIER"].Value.ToString());
                    MainForm.objCP_Purchase.txtGstin.Text = Convert.ToString(grdPurchaseEntryQueueList.SelectedRows[0].Cells["GSTIN"].Value.ToString());
                    MainForm.objCP_Purchase.lbltotProduct.Text = Convert.ToString(grdPurchaseEntryQueueList.SelectedRows[0].Cells["Total Products"].Value.ToString());
                    MainForm.objCP_Purchase.lblRemainProduct.Text = Convert.ToString(grdPurchaseEntryQueueList.SelectedRows[0].Cells["Total Products"].Value.ToString());
                    MainForm.objCP_Purchase.txtQRCode.Text = Convert.ToString(grdPurchaseEntryQueueList.SelectedRows[0].Cells["QR Code"].Value.ToString());
                    MainForm.objCP_Purchase.MdiParent = this.ParentForm;
                    MainForm main = (MainForm)this.MdiParent;
                    main.IsEntryFormOpen = true;
                    main.CurrentEntryForm = MainForm.objCP_Purchase;
                    main.CurrentParentListForm = this;
                    MainForm.objCP_Purchase.Show();
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
                finally
                {
                    //picLoader.Visible = false;
                }
            }
        }
        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdPurchaseEntryQueueList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdPurchaseEntryQueueList.Width > grdPurchaseEntryQueueList.HorizontalScrollingOffset && grdPurchaseEntryQueueList.HorizontalScrollingOffset > 0)
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
        private void GrdPurchaseEntryQueueList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdPurchaseEntryQueueList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdPurchaseEntryQueueList.Width > grdPurchaseEntryQueueList.HorizontalScrollingOffset && grdPurchaseEntryQueueList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdPurchaseEntryQueueList);
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
        private void GrdPurchaseEntryQueueList_KeyDown(object sender, KeyEventArgs e)
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
    }
}
