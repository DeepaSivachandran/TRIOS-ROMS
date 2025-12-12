using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ROMS
{
    public partial class PUR_MismatchApprovedList : Form
    {
        MainForm objMainForm = new MainForm();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public DataTable Deftable = new DataTable();
        public int varviewtype = 0, Varflag=0,varUpDownKey = 0;
        public int ApprovalFlag = 0;
        public PUR_MismatchApprovedList()
        {
            InitializeComponent();
        } 
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (grdGrnApprovalList.Rows.Count > 0)
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objPUR_GRNApproval = new PUR_GRNApproval();
                    MainForm.objPUR_GRNApproval.txtConcern.Text = Convert.ToString(grdGrnApprovalList.SelectedRows[0].Cells["Concern"].Value);
                    MainForm.objPUR_GRNApproval.txtVoucherDate.Text = Convert.ToString(grdGrnApprovalList.SelectedRows[0].Cells["Vouc Date"].Value);
                    MainForm.objPUR_GRNApproval.txtVoucherNo.Text = Convert.ToString(grdGrnApprovalList.SelectedRows[0].Cells["Vouc No."].Value);
                    MainForm.objPUR_GRNApproval.txtGrnDate.Text = Convert.ToString(grdGrnApprovalList.SelectedRows[0].Cells["GRN Date"].Value);
                    MainForm.objPUR_GRNApproval.txtGrnNo.Text = Convert.ToString(grdGrnApprovalList.SelectedRows[0].Cells["GRN No."].Value);
                    MainForm.objPUR_GRNApproval.txtInvoiceNo.Text = Convert.ToString(grdGrnApprovalList.SelectedRows[0].Cells["Inv No."].Value);
                    MainForm.objPUR_GRNApproval.txtInvoiceDate.Text = Convert.ToString(grdGrnApprovalList.SelectedRows[0].Cells["Inv Date"].Value);
                    MainForm.objPUR_GRNApproval.varSupplierID = Convert.ToInt32(grdGrnApprovalList.SelectedRows[0].Cells["Supplier ID"].Value);
                    MainForm.objPUR_GRNApproval.varScheduleID = Convert.ToInt32(grdGrnApprovalList.SelectedRows[0].Cells["Schedule ID"].Value);
                    MainForm.objPUR_GRNApproval.varConcernID = Convert.ToInt32(grdGrnApprovalList.SelectedRows[0].Cells["Concern ID"].Value);
                    MainForm.objPUR_GRNApproval.varID = Convert.ToInt32(grdGrnApprovalList.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objPUR_GRNApproval.txtPurchaseType.Text = Convert.ToString(grdGrnApprovalList.SelectedRows[0].Cells["Purchase Type"].Value);
                    MainForm.objPUR_GRNApproval.varGRNAID = Convert.ToInt32(grdGrnApprovalList.SelectedRows[0].Cells["GRNAID"].Value);
                    MainForm.objPUR_GRNApproval.varFlag = Convert.ToInt32(grdGrnApprovalList.SelectedRows[0].Cells["FLAG"].Value);
                    MainForm.objPUR_GRNApproval.varGRNID = Convert.ToInt32(grdGrnApprovalList.SelectedRows[0].Cells["Trans ID"].Value);
                    MainForm.objPUR_GRNApproval.pbEditFlag = 1; 
                    MainForm.objPUR_GRNApproval.MdiParent = this.ParentForm;
                    //objMainForm.CenterEntryForm(this, MainForm.objPUR_GRNApproval);
                    MainForm main = (MainForm)this.MdiParent;
                    main.IsEntryFormOpen = true;
                    main.CurrentEntryForm = MainForm.objPUR_GRNApproval;
                    main.CurrentParentListForm = this;
                    MainForm.objPUR_GRNApproval.Show();
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
            }
        }
        private void PUR_GRNApprovalList_Load(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.Focus();
                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId; 
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
        public void udfnDate()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 9;
                objMR_Master.paraID = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Master.paraFlag = 19;
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(objMR_Master);
                if (objd.Tables[0].Rows.Count != 0)
                {
                    DateTime vardate = DateTime.ParseExact(Convert.ToString(objd.Tables[0].Rows[0]["Transaction Date"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpToDate.MinDate = vardate;
                    dpFromDate.Text = Convert.ToString(objd.Tables[0].Rows[0]["DATE1"]);
                    udfnList();
                }
                objDServ.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbConcern()
        {
            try
            {
                cmbConcern.Focus();
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
        private void PUR_GRNApprovalList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (ApprovalFlag==0)
               // {
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                    {
                        tsbEdit_Click(sender, e);
                    }
                //}
                if (e.KeyCode == Keys.Escape)
                {
                    if (ApprovalFlag == 1)
                    {
                        MainForm.objPUR_PurchaseApprovalList = new PUR_PurchaseApprovalList();
                        MainForm.objPUR_PurchaseApprovalList.MdiParent = this.ParentForm;
                        MainForm main = (MainForm)this.MdiParent;
                        main.IsEntryFormOpen = true;
                        main.CurrentEntryForm = MainForm.objPUR_PurchaseApprovalList;
                        main.CurrentParentListForm = this;
                        MainForm.objPUR_PurchaseApprovalList.Show();
                    }               
                    else
                    {
                        MainForm.objStart = new DEF_Start();
                        MainForm.objStart.MdiParent = this.ParentForm;
                        MainForm.objStart.Show();
                        this.Close();
                    }
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
                LV_Supplier.Visible = false;
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
                grdGrnApprovalList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGrnApprovalList);
                objDser.CloseConnection();
                grdGrnApprovalList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
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
                grdGrnApprovalList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGrnApprovalList);
                objDser.CloseConnection();
                grdGrnApprovalList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdGrnApprovalList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdGrnApprovalList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdGrnApprovalList.SortOrder == SortOrder.Ascending)
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
                    grdGrnApprovalList.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_SearchGrid.HorizontalScrollingOffset = grdGrnApprovalList.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnMinimumWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdGrnApprovalList.ColumnCount > 0)
                {
                    grdGrnApprovalList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdGrnApprovalList.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdGrnApprovalList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGrnApprovalList);
                objDser.CloseConnection();
                grdGrnApprovalList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
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
                    int offSetValue = grdGrnApprovalList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdGrnApprovalList.Width > grdGrnApprovalList.HorizontalScrollingOffset && grdGrnApprovalList.HorizontalScrollingOffset > 0)
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

        private void GrdGrnApprovalList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdGrnApprovalList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdGrnApprovalList.Width > grdGrnApprovalList.HorizontalScrollingOffset && grdGrnApprovalList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdGrnApprovalList);
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
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdGrnApprovalList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdGrnApprovalList.Columns)
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
        private void GrdGrnApprovalList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (ApprovalFlag==0)
                //{
                    tsbEdit_Click(sender, e);
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnApprovalList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (ApprovalFlag==0)
                //{
                    if (e.KeyCode == Keys.Enter)
                    {
                        tsbEdit_Click(sender, e);
                    }
                //}
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
                    btnView.Focus();
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
                if (txtSupplier.Text.Trim() == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedule.Text = "0";
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
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    objMR_Supplier.ParaToDate = dpToDate.Text;
                    objMR_Supplier.paraFlag = 12;
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
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[3].Width = 0;
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
                    btnView.Focus();
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
         
        private void GrdGrnApprovalList_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdGrnApprovalList.ColumnCount > 0)
                {
                    grdGrnApprovalList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdGrnApprovalList.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdGrnApprovalList.ColumnCount > 0)
                {
                    grdGrnApprovalList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdGrnApprovalList.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnApprovalList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdGrnApprovalList.Columns["S.No."].Frozen = true;
                grdGrnApprovalList.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGrnApprovalList.Columns["Concern"].Frozen = true;
                grdGrnApprovalList.Columns["Concern"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGrnApprovalList.Columns["Overall Status"].Frozen = true;
                grdGrnApprovalList.Columns["Overall Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGrnApprovalList.Columns["Status"].Frozen = true;
                grdGrnApprovalList.Columns["Status"].DefaultCellStyle.BackColor = Color.AliceBlue; 
                grdGrnApprovalList.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //udfnDate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbApproval_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                //MainForm.objPUR_GRNApprovalList = new PUR_GRNApprovalList();
                //MainForm.objPUR_GRNApprovalList.MdiParent = this.ParentForm;
                //MainForm.objPUR_GRNApprovalList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnApprovalList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdGrnApprovalList.Columns["Status"].Index)
                {
                    var cell = grdGrnApprovalList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdGrnApprovalList.Rows[e.RowIndex].Cells["Full Status"].Value.ToString();
                }
                if (e.ColumnIndex == grdGrnApprovalList.Columns["Overall Status"].Index)
                {
                    var cell = grdGrnApprovalList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdGrnApprovalList.Rows[e.RowIndex].Cells["Overall Full Status"].Value.ToString();
                }
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

        public void udfnList()
        {
            try
            {
               // dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
               // Varflag = 0;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
               // epQueueList.Clear();
                grdGrnApprovalList.DataSource = null;
                DataSet objDs = new DataSet();
                if (Varflag == 0)
                { 
                    btnView.Enabled = false;
                    varviewtype = 26;
                    SPDataService objdserv = new SPDataService();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = varviewtype;
                    objTRN_PurchaseEntry.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_PurchaseEntry.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue); 
                    objTRN_PurchaseEntry.paraFromDate = Convert.ToString(dpFromDate.Text);
                    objTRN_PurchaseEntry.paraToDate = Convert.ToString(dpToDate.Text);
                    objTRN_PurchaseEntry.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                    objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(lblschedule.Text); 
                    objTRN_PurchaseEntry.paraFlag = 1;
                    objDs = objdserv.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
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
                                grdGrnApprovalList.DataSource = objDs.Tables[0];
                                grdGrnApprovalList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                                grdGrnApprovalList.Columns["GRN Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdGrnApprovalList.Columns["Vouc Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdGrnApprovalList.Columns["Inv Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                                grdGrnApprovalList.Columns["MA Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                                grdGrnApprovalList.Columns["Concern"].Width = 70;
                                grdGrnApprovalList.Columns["Vouc No."].Width = 70;
                                grdGrnApprovalList.Columns["GRN Date"].Width = 80;
                                grdGrnApprovalList.Columns["Vouc Date"].Width = 80;
                                grdGrnApprovalList.Columns["Status"].Width = 70;
                                grdGrnApprovalList.Columns["Overall Status"].Width = 100;
                                grdGrnApprovalList.Columns["GRN No."].Width = 70;
                                grdGrnApprovalList.Columns["Supplier"].Width = 250; 
                                grdGrnApprovalList.Columns["Approved By"].Width = 200; 
                                grdGrnApprovalList.Columns["GSTIN"].Width = 150;
                                grdGrnApprovalList.Columns["S.No."].Width = 60;
                                grdGrnApprovalList.Columns["ID"].Visible = false;
                                grdGrnApprovalList.Columns["Supplier ID"].Visible = false;
                                grdGrnApprovalList.Columns["Schedule ID"].Visible = false;
                                grdGrnApprovalList.Columns["GRNAID"].Visible = false;  
                                grdGrnApprovalList.Columns["Concern ID"].Visible = false;   
                                grdGrnApprovalList.Columns["Trans ID"].Visible = false;   
                                grdGrnApprovalList.Columns["FLAG"].Visible = false; 
                                grdGrnApprovalList.Columns["Status"].Visible = false;    
                                grdGrnApprovalList.Columns["Purchase ID"].Visible = false;    
                                grdGrnApprovalList.Columns["GRNID"].Visible = false;    
                                grdGrnApprovalList.Columns["Inv Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                        Deftable = objDs.Tables[0];
                        udfnDefaultSearchGrid();
                    }
                    else { DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    grdGrnApprovalList.DataSource = null;
                    DGV_SearchGrid.DataSource = null;
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
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = null;
                DGV_SearchGrid.DataSource = Deftable;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["GRN Date"].Width = 80;
                DGV_SearchGrid.Columns["Vouc No."].Width = 100;
                DGV_SearchGrid.Columns["Vouc Date"].Width = 100;
                DGV_SearchGrid.Columns["Inv No."].Width = 100;
                DGV_SearchGrid.Columns["Inv Date"].Width = 100;
                DGV_SearchGrid.Columns["Supplier"].Width = 300;
                DGV_SearchGrid.Columns["GSTIN"].Width = 120;  
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["Supplier ID"].Visible = false;
                DGV_SearchGrid.Columns["Schedule ID"].Visible = false;
                DGV_SearchGrid.Columns["GRNAID"].Visible = false; 
                DGV_SearchGrid.Columns["Concern ID"].Visible = false; 
                DGV_SearchGrid.Columns["Purchase Type"].Visible = false;
                DGV_SearchGrid.Columns["Overall Full Status"].Visible = false;    
                DGV_SearchGrid.Columns["Flag"].Visible = false; 
                DGV_SearchGrid.Columns["Trans ID"].Visible = false;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
