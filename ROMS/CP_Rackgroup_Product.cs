using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
//using ClosedXML.Excel;
namespace ROMS
{   //Created By:-Sathish
    //Created On:-19/09/2023
    public partial class CP_Rackgroup_Product : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;

        DataSet objDs = new DataSet();
        DataTable objDtExcel = new DataTable();
        DataTable dtDefaultGrid = new DataTable();
        public string varUserID = "";
        public int MenuCode = 0,refreshFlag = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();

        DataTable dtRackgroupProduct = new DataTable();

        private int _oldOrderNo = 0;

        private ToolTip tbRackgroup = new ToolTip();
        public int varExistFlag = 0;

        public CP_Rackgroup_Product()
        {
            InitializeComponent();
            windowControl.Initialize(tsRackList, this);
        }

        private void CP_RackList_Load(object sender, EventArgs e)
        {
            try
            {
                dtRackgroupProduct.TableName = "MR_Rackgroup_Product";
                dtRackgroupProduct.Columns.Add("RKGID", typeof(int));
                dtRackgroupProduct.Columns.Add("RKID", typeof(int));
                dtRackgroupProduct.Columns.Add("PRID", typeof(int));
                dtRackgroupProduct.Columns.Add("OrderNo", typeof(string));

                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 50404;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                MenuCode = 50402;
                cmbGroupType.Focus();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_RackGroup", "RKG_STSID=1 AND RKGID !=0 Order by RKGID", "RKG_Name,RKGID", cmbGroupType, "", "RKG_Name", "RKGID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=95 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPrintLanguage, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbGroupType.SelectedValue = -1;
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
                cmbGroupType.BackColor = Color.White;
                epRackgroup.Clear();
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                btnView.Enabled = false;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGroupList.DataSource = null;

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();

                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 91;
                objMR_Product.paraRKGId = Convert.ToInt32(cmbGroupType.SelectedValue);
                objMR_Product.paraType =Convert.ToInt32(cmbPrintLanguage.SelectedValue);
                objDs = objdserv.udfnproductmasterlist(objMR_Product);
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
                            grdGroupList.ClearSelection();
                            grdGroupList.DataSource = objDs.Tables[0];

                            if (Convert.ToInt32(cmbPrintLanguage.SelectedValue) == 323)
                            {
                                grdGroupList.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            }
                            grdGroupList.Columns["S.No."].ReadOnly = true;
                            grdGroupList.Columns["RKGID"].Visible = false;
                            grdGroupList.Columns["RKID"].Visible = false;
                            grdGroupList.Columns["PRID"].Visible = false;
                            grdGroupList.Columns["Rack Group"].Visible = false;
                            grdGroupList.Columns["S.No."].Width = 50;
                            grdGroupList.Columns["PI Code"].Width = 150;
                            grdGroupList.Columns["Product Name"].Width = 350;
                            grdGroupList.Columns["Order No."].Width = 80;
                            grdGroupList.Columns["Unit"].Width = 50;
                            grdGroupList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGroupList.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGroupList.Columns["Order No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            ((DataGridViewTextBoxColumn)grdGroupList.Columns["Order No."]).MaxInputLength = 4;
                            
                            grdGroupList.Columns["PI Code"].SortMode= DataGridViewColumnSortMode.NotSortable;
                            grdGroupList.Columns["Product Name"].SortMode= DataGridViewColumnSortMode.NotSortable;
                            grdGroupList.Columns["Rack"].SortMode= DataGridViewColumnSortMode.NotSortable;
                            grdGroupList.Columns["Order No."].SortMode= DataGridViewColumnSortMode.NotSortable;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                        if (objDs.Tables.Count > 1)
                        {
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                varExistFlag = Convert.ToInt32(objDs.Tables[1].Rows[0]["existFlag"]);
                            }
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
                grdGroupList.Columns["PI Code"].ReadOnly = true;
                grdGroupList.Columns["Product Name"].ReadOnly = true;
                grdGroupList.Columns["Order No."].DefaultCellStyle.BackColor = Color.PaleGreen;
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
                btnView.Enabled = true;
                btnView.Focus();
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["ConcernID"].Visible = false;
                DGV_SearchGrid.Columns["StockLocationID"].Visible = false;
                DGV_SearchGrid.Columns["StatusID"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Concern"].Width = 100;
                DGV_SearchGrid.Columns["Stock Location"].Width = 200;
                DGV_SearchGrid.Columns["Rack Group"].Width = 250;
                DGV_SearchGrid.Columns["Rack Name"].Width = 200;
                DGV_SearchGrid.Columns["Short Name"].Width = 100;
                DGV_SearchGrid.Columns["Description"].Width = 200;
                DGV_SearchGrid.Columns["Total Products"].Width = 100;
                DGV_SearchGrid.Columns["Status"].Width = 80;
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
                    udfnGridSearchHeading(grdGroupList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdGroupList.Columns)
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

        private void CP_RackList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    windowControl?.TriggerClose();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGroupList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //for (int i = 0; i < grdGroupList.Rows.Count; i++)
                //{
                //    if (Convert.ToString(grdGroupList.Rows[i].Cells["StatusID"].Value) == "1")
                //    {
                //        grdGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                //        grdGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                //    }
                //    else
                //    {
                //        grdGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                //        grdGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                //    }
                //    grdGroupList.ClearSelection();
                //}
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
                epRackgroup.Clear();
                if (Convert.ToInt32(cmbGroupType.SelectedValue) == -1)
                {
                    epRackgroup.SetError(cmbGroupType, "Please select rackgroup");
                    cmbGroupType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tbRackgroup.ShowAlways = true;
                    tbRackgroup.Show("Please select rackgroup", cmbGroupType, 5000);
                    return;
                }
                udfnList();
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
                grdGroupList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGroupList);
                objDser.CloseConnection();
                grdGroupList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdGroupList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdGroupList.SortedColumn;
                ListSortDirection direction;
                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdGroupList.SortOrder == SortOrder.Ascending)
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
                grdGroupList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                DGV_SearchGrid.HorizontalScrollingOffset = grdGroupList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdGroupList.ColumnCount > 0)
                {
                    grdGroupList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdGroupList.HorizontalScrollingOffset;
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
                    int offSetValue = grdGroupList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdGroupList.Width > grdGroupList.HorizontalScrollingOffset && grdGroupList.HorizontalScrollingOffset > 0)
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

        private void GrdGroupList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdGroupList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdGroupList.Width > grdGroupList.HorizontalScrollingOffset && grdGroupList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdGroupList);
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

        private void CmbGroupType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGroupType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroupType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbGroupType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroupType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPrintLanguage.Focus();
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
                grdGroupList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGroupList);
                objDser.CloseConnection();
                grdGroupList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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
                DataService objDser = new DataService();
                grdGroupList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGroupList);
                objDser.CloseConnection();
                grdGroupList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbGroupType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void grdGroupList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (grdGroupList.Columns[e.ColumnIndex].Name != "Order No.")
                    return;

                var val = grdGroupList.Rows[e.RowIndex].Cells["Order No."].Value;
                _oldOrderNo = (val != null && int.TryParse(val.ToString(), out int v)) ? v : 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void grdGroupList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (grdGroupList.Columns[e.ColumnIndex].Name != "Order No.")
                    return;
                if (varExistFlag == 0)
                    return;
                var cell = grdGroupList.Rows[e.RowIndex].Cells["Order No."];
                string newValue = cell.Value?.ToString().Trim();

                if (string.IsNullOrEmpty(newValue))
                    return;

                if (!int.TryParse(newValue, out int editedOrder))
                {
                    RestoreOldValue(cell);
                    return;
                }

                var dt = (DataTable)grdGroupList.DataSource;
                var currentRow =
                    ((DataRowView)grdGroupList.Rows[e.RowIndex].DataBoundItem).Row;

                //bool invalid = dt.AsEnumerable().TakeWhile(r => r != currentRow).Any(r =>r["Order No."] != DBNull.Value && int.TryParse(r["Order No."].ToString(), out int v) && editedOrder <= v);

                //if (invalid)
                //{
                //    MessageBox.Show("Order No must be greater.","Invalid Order No",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                //    RestoreOldValue(cell);
                //    return;
                //}

                int nextOrder = editedOrder + 1;

                foreach (var row in dt.AsEnumerable().SkipWhile(r => r != currentRow).Skip(1))
                {
                    if (row["Order No."] != DBNull.Value && int.TryParse(row["Order No."].ToString(), out _))
                    {
                        row["Order No."] = nextOrder.ToString();
                        nextOrder++;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RestoreOldValue(DataGridViewCell cell)
        {
            cell.Value = _oldOrderNo == 0 ? "" : _oldOrderNo.ToString();
        }

        private void grdGroupList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdGroupList.CurrentCell.OwningColumn.Name == "Order No.")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdGroupList.CurrentCell.OwningColumn.Name == "Order No.")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //for (int i = 1; i < DGV_SearchGrid.ColumnCount; i++)
                //{
                //    DGV_SearchGrid.Rows[0].Cells[i].Value = "";
                //}
                udfnSave();
            }   
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave()
        {
            try
            {
                dtRackgroupProduct.Rows.Clear();

                foreach (DataGridViewRow row in grdGroupList.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    DataRow dr = dtRackgroupProduct.NewRow();

                    dr["RKGID"] = Convert.ToInt32(row.Cells["RKGID"].Value);
                    dr["RKID"] = Convert.ToInt32(row.Cells["RKID"].Value);
                    dr["PRID"] = Convert.ToInt32(row.Cells["PRID"].Value);

                    var orderCell = row.Cells["Order No."];

                    dr["OrderNo"] = (orderCell.Value == null)
                                        ? ""
                                        : orderCell.Value.ToString().Trim();

                    dtRackgroupProduct.Rows.Add(dr);
                }


                string varResult = "";
                SPDataService objDser = new SPDataService();
                varResult = objDser.udfnRackGroup(3, 0, 0, "", "", "", 0, "Rackgroup Product Mapping", MainForm.pbUserID, 0, 0, dtRackgroupProduct);
                objDser.CloseConnection();
                btnSave.Enabled = true;
                if (varResult.Split('~')[0] == "3")
                {
                    refreshFlag = 1;
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    udfnList();

                    refreshFlag = 0;
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                windowControl?.TriggerClose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPrintLanguage_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPrintLanguage.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPrintLanguage_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbPrintLanguage_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbPrintLanguage_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPrintLanguage.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.Transparent; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
