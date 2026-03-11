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
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    //Created By:Sathish ; Created On:-17/11/2025
    public partial class CP_DLP_MultipleProducts_List : Form
    {
        private HashSet<int> changedLPIDs = new HashSet<int>(); private bool isRunning = true;

        DynamicWindowControl windowControl = new DynamicWindowControl();
        MainForm objMainForm = new MainForm();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public string varUserID = "";
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();

        public CP_DLP_MultipleProducts_List()
        {
            InitializeComponent();
            windowControl.Initialize(tsDirectLabelList, this);
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objCP_DLP_MultipleProducts = new CP_DLP_MultipleProducts();
                    //objMainForm.CenterEntryForm(this, MainForm.objCP_DLP_MultipleProducts);
                    MainForm.objCP_DLP_MultipleProducts.MdiParent = this.ParentForm;
                    MainForm main = (MainForm)this.MdiParent;
                    main.IsEntryFormOpen = true;
                    main.CurrentEntryForm = MainForm.objCP_DLP_MultipleProducts_List;
                    main.CurrentParentListForm = this;
                    isRunning = false;
                    MainForm.objCP_DLP_MultipleProducts.Show();

                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
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
        private void tsbDelete_Click(object sender, EventArgs e)
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
                    if (grdDirectLabelList.SelectedRows.Count > 0)
                    {
                        string result = "";
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SPDataService objspdservice = new SPDataService();
                            MR_Product objMR_Product = new MR_Product();
                            objMR_Product.paraViewType = 2;
                            objMR_Product.paraId = Convert.ToInt32(grdDirectLabelList.SelectedRows[0].Cells["ID"].Value);
                            objMR_Product.paraOriginator = "Label Print Delete";
                            result = objspdservice.udfnLabelPrint(objMR_Product);
                            objspdservice.CloseConnection();
                            string[] varvalue = result.Split('~');
                            if (result.Split('~')[0] == "3")
                            {
                                if (result.Split('~')[0] != "1")
                                {
                                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(48);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void udfnEdit()
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdDirectLabelList.SelectedRows.Count > 0)
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        MainForm.objCP_DLP_MultipleProducts = new CP_DLP_MultipleProducts();
                        MainForm.objCP_DLP_MultipleProducts.pbLPID = Convert.ToInt32(grdDirectLabelList.SelectedRows[0].Cells["ID"].Value.ToString());
                        //objMainForm.CenterEntryForm(this, MainForm.objCP_DLP_MultipleProducts);
                        picLoader.Visible = false;
                        MainForm.objCP_DLP_MultipleProducts.MdiParent = this.ParentForm;
                        MainForm main = (MainForm)this.MdiParent;
                        main.IsEntryFormOpen = true;
                        main.CurrentEntryForm = MainForm.objCP_DLP_MultipleProducts_List;
                        main.CurrentParentListForm = this;
                        isRunning = false;
                        MainForm.objCP_DLP_MultipleProducts.Show();
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
        public void udfnList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdDirectLabelList.DataSource = null;

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 0;
                objDs = objdserv.udfnLabelPrintList(objMR_Product);
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
                            grdDirectLabelList.DataSource = objDs.Tables[0];
                            grdDirectLabelList.Columns["ID"].Visible = false;
                            grdDirectLabelList.Columns["S.No."].Width = 50;
                            grdDirectLabelList.Columns["P.I Code"].Width = 150;
                            grdDirectLabelList.Columns["Product Name"].Width = 400;
                            grdDirectLabelList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdDirectLabelList.Columns["MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdDirectLabelList.Columns["R.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdDirectLabelList.Columns["S.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdDirectLabelList.Columns["W.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdDirectLabelList.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdDirectLabelList.ClearSelection();
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
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Product Name"].Width = 200;
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
                    udfnGridSearchHeading(grdDirectLabelList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdDirectLabelList.Columns)
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
        private void CP_Citylist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    tsbEdit_Click(sender, e);
                }
                if(((Control.ModifierKeys & Keys.Control)==Keys.Control)&& (e.KeyCode == Keys.D))
                {
                    tsbDelete_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    isRunning = false;
                    windowControl?.TriggerClose();
                }
                if(e.KeyCode==Keys.Delete)
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
        private void CP_Citylist_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 51202;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                MenuCode = 51202;
                udfnList(); udfnLoad();//udfnRateChanged();
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
        public async void udfnLoad()
        {
            try
            {
                _ = RefreshLoop();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private async Task RefreshLoop()
        {
            while (isRunning)
            {
                await udfnRateChanged();   // call your function
                await Task.Delay(1000);    // wait 1 sec
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdCityList_DoubleClick(object sender, EventArgs e)
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
        private void GrdCityList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                udfnEdit();
            }
        }
        private void GrdCityList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdDirectLabelList.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public async Task udfnRateChanged()
        {
            try
            {
                await Task.Run(() =>
                {
                    DataSet objDs = new DataSet();
                    SPDataService objdserv = new SPDataService();
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 2;

                    objDs = objdserv.udfnLabelPrintList(objMR_Product);
                    objdserv.CloseConnection();

                    changedLPIDs.Clear();

                    if (objDs != null &&
                        objDs.Tables.Count > 0 &&
                        objDs.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in objDs.Tables[0].Rows)
                        {
                            if (dr["isFlagChange"] != DBNull.Value &&
                                dr["isFlagChange"].ToString() == "1")
                            {
                                changedLPIDs.Add(Convert.ToInt32(dr["LPID"]));
                            }
                        }
                    }
                });

                // After data is loaded → refresh grid color
                grdDirectLabelList.Invoke(new Action(() =>
                {
                    HighlightChangedRows();
                }));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void HighlightChangedRows()
        {
            foreach (DataGridViewRow row in grdDirectLabelList.Rows)
            {
                if (row.Cells["ID"].Value != null)
                {
                    int lpid = Convert.ToInt32(row.Cells["ID"].Value);
                    if (changedLPIDs.Contains(lpid))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }


        private void GrdCityList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdDirectLabelList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdDirectLabelList.Width > grdDirectLabelList.HorizontalScrollingOffset && grdDirectLabelList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdDirectLabelList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdCityList.Controls.OfType<VScrollBar>().First();
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
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdDirectLabelList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdDirectLabelList);
                objDser.CloseConnection();
                grdDirectLabelList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdDirectLabelList.ColumnCount > 0)
                {
                    grdDirectLabelList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdDirectLabelList.HorizontalScrollingOffset;
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
                    int offSetValue = grdDirectLabelList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdDirectLabelList.Width > grdDirectLabelList.HorizontalScrollingOffset && grdDirectLabelList.HorizontalScrollingOffset > 0)
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
        private void CP_Citylist_DoubleClick(object sender, EventArgs e)
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

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdDirectLabelList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdDirectLabelList.SortedColumn;
                ListSortDirection direction;
                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdDirectLabelList.SortOrder == SortOrder.Ascending)
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
                grdDirectLabelList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                DGV_SearchGrid.HorizontalScrollingOffset = grdDirectLabelList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_SearchGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
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
                grdDirectLabelList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdDirectLabelList);
                objDser.CloseConnection();
                grdDirectLabelList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_DirectLabelList_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
        }
    }
}
