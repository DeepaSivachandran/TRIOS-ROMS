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
    public partial class CP_Rate_ChangeList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public int varconcern = 0, vargroup = 0, varsubgroup = 0, varcategory = 0;
        public string varUserID = "";
        public CP_Rate_ChangeList()
        {
            InitializeComponent();
        }
        
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Rate_Change = new CP_Rate_Change();
                MainForm.objCP_Rate_Change.ShowDialog();
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
                grdItemList.DataSource = null;

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                TRN_RateChange objRateChange = new TRN_RateChange();
                objDs = objdserv.udfnRateChangeList(objRateChange);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdItemList.DataSource = objDs.Tables[0];
                            grdItemList.Columns["S.No."].Width = 60;
                            grdItemList.Columns["P.I Code"].Width = 100;
                            grdItemList.Columns["Product"].Width = 360;
                            grdItemList.Columns["Unit"].Width = 80;
                            grdItemList.Columns["Last R.Rate"].Width = 100;
                            grdItemList.Columns["Last W.Rate"].Width = 100;
                            grdItemList.Columns["Live R.Rate"].Width = 100;
                            grdItemList.Columns["Live W.Rate"].Width = 100;
                            grdItemList.Columns["Teller"].Width = 100;
                            grdItemList.Columns["Last Updated By"].Width = 200;
                            grdItemList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdItemList.Columns["Last R.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Last W.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Live R.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Live W.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Product"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdItemList.Columns["Last R.Rate"].DefaultCellStyle.ForeColor = Color.White;
                            grdItemList.Columns["Last R.Rate"].DefaultCellStyle.BackColor = Color.Red;
                            grdItemList.Columns["Last W.Rate"].DefaultCellStyle.ForeColor = Color.White;
                            grdItemList.Columns["Last W.Rate"].DefaultCellStyle.BackColor = Color.Red;
                            grdItemList.Columns["Last R.Rate"].DefaultCellStyle.Font = new Font(grdItemList.Font, FontStyle.Bold);
                            grdItemList.Columns["Last W.Rate"].DefaultCellStyle.Font = new Font(grdItemList.Font, FontStyle.Bold);

                            grdItemList.Columns["Live R.Rate"].DefaultCellStyle.ForeColor = Color.White;
                            grdItemList.Columns["Live R.Rate"].DefaultCellStyle.BackColor = Color.Green;
                            grdItemList.Columns["Live W.Rate"].DefaultCellStyle.ForeColor = Color.White;
                            grdItemList.Columns["Live W.Rate"].DefaultCellStyle.BackColor = Color.Green;
                            grdItemList.Columns["Live R.Rate"].DefaultCellStyle.Font = new Font(grdItemList.Font, FontStyle.Bold);
                            grdItemList.Columns["Live W.Rate"].DefaultCellStyle.Font = new Font(grdItemList.Font, FontStyle.Bold);

                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
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
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Product Name in English"].Width = 300;
                DGV_SearchGrid.Columns["P.I Code"].Width = 100;
                DGV_SearchGrid.Columns["Product Name in Tamil"].Width = 300;
                DGV_SearchGrid.Columns["Product Subgroup"].Width = 150;
                DGV_SearchGrid.Columns["Product Group"].Width = 150;
                DGV_SearchGrid.Columns["Status"].Width = 80;
                DGV_SearchGrid.Columns["HSN Name"].Width = 230;
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["STSID"].Visible = false;
                DGV_SearchGrid.Columns["PRGID"].Visible = false;
                DGV_SearchGrid.Columns["PR_PRSGID"].Visible = false;
                DGV_SearchGrid.Columns["PR_HSNID"].Visible = false;
                DGV_SearchGrid.Columns["PR_UTID"].Visible = false;
                DGV_SearchGrid.Columns["PR_COMID"].Visible = false;
                DGV_SearchGrid.Columns["PR_BDID"].Visible = false;
                DGV_SearchGrid.Columns["PR_SALE_RKID"].Visible = false;
                DGV_SearchGrid.Columns["PR_SALE_SLID"].Visible = false;
                DGV_SearchGrid.Columns["PR_PUR_RKID"].Visible = false;
                DGV_SearchGrid.Columns["PR_PUR_SLID"].Visible = false;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0)) /*If not our desired columns*/
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
                if (grdItemList.ColumnCount > 0)
                {
                    grdItemList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdItemList.HorizontalScrollingOffset;
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
                //if (DGV_SearchGrid.CurrentCell.OwningColumn.Name == "P.I Code" || DGV_SearchGrid.CurrentCell.OwningColumn.Name == "Product Name in English")
                //{
                //    grdItemList.DataSource = objDser.udfnGridSearchFilterStartWith(DGV_SearchGrid, grdItemList);
                //}
                //else
                //{
                //}
                grdItemList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdItemList);
                objDser.CloseConnection();
                grdItemList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdItemList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdItemList.Columns)
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
                    DGV_SearchGrid.Columns["Live R.Rate"].DefaultCellStyle.ForeColor = Color.Black;
                    DGV_SearchGrid.Columns["Live R.Rate"].DefaultCellStyle.BackColor = Color.White;
                    DGV_SearchGrid.Columns["Live R.Rate"].DefaultCellStyle.Font = new Font(grdItemList.Font, FontStyle.Regular);

                    DGV_SearchGrid.Columns["Live W.Rate"].DefaultCellStyle.ForeColor = Color.Black;
                    DGV_SearchGrid.Columns["Live W.Rate"].DefaultCellStyle.BackColor = Color.White;
                    DGV_SearchGrid.Columns["Live W.Rate"].DefaultCellStyle.Font = new Font(grdItemList.Font, FontStyle.Regular);

                    DGV_SearchGrid.Columns["Last R.Rate"].DefaultCellStyle.ForeColor = Color.Black;
                    DGV_SearchGrid.Columns["Last R.Rate"].DefaultCellStyle.BackColor = Color.White;
                    DGV_SearchGrid.Columns["Last R.Rate"].DefaultCellStyle.Font = new Font(grdItemList.Font, FontStyle.Regular);

                    DGV_SearchGrid.Columns["Last W.Rate"].DefaultCellStyle.ForeColor = Color.Black;
                    DGV_SearchGrid.Columns["Last W.Rate"].DefaultCellStyle.BackColor = Color.White;
                    DGV_SearchGrid.Columns["Last W.Rate"].DefaultCellStyle.Font = new Font(grdItemList.Font, FontStyle.Regular);

                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridSearchFilter()
        {
            try
            {
                for (int i = 0; i < DGV_SearchGrid.Rows.Count; ++i)
                {
                    if (DGV_SearchGrid.ColumnCount > 0)
                    {
                        BindingSource bs = new BindingSource();
                        bs.DataSource = grdItemList.DataSource;
                        string filter = "";
                        for (int j = 1; j < DGV_SearchGrid.ColumnCount; j++)
                        {
                            if (Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) != "")
                            {
                                if (filter != "") filter += "And ";
                                if (objValidation.FormatNumeric(Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value)))
                                    filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + "=" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value);
                                else
                                    filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + " LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                            }
                        }
                        bs.Filter = filter;
                        grdItemList.DataSource = bs;
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

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdItemList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdItemList.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdItemList.SortOrder == SortOrder.Ascending)
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
                grdItemList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGrid.HorizontalScrollingOffset = grdItemList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdItemList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdItemList.Width > grdItemList.HorizontalScrollingOffset && grdItemList.HorizontalScrollingOffset > 0)
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
                var vScrollbar = grdItemList.Controls.OfType<VScrollBar>().First();
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

        private void CP_ProductList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.S))
                {
                    tsbNew_Click(sender, e);
                } 
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

        private void CP_ProductList_Load(object sender, EventArgs e)
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

        private void grdItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdItemList.ClearSelection();
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                //if (DGV_SearchGrid.CurrentCell.OwningColumn.Name == "P.I Code" || DGV_SearchGrid.CurrentCell.OwningColumn.Name == "Product Name in English")
                //{
                //    grdItemList.DataSource = objDser.udfnGridSearchFilterStartWith(DGV_SearchGrid, grdItemList);
                //}
                //else
                //{
                //}
                grdItemList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdItemList);
                objDser.CloseConnection();
                grdItemList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void GrdItemList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdItemList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdItemList.Width > grdItemList.HorizontalScrollingOffset && grdItemList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdItemList);
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
                //if(DGV_SearchGrid.CurrentCell.OwningColumn.Name == "P.I Code" || DGV_SearchGrid.CurrentCell.OwningColumn.Name == "Product Name in English")
                //{
                //    grdItemList.DataSource = objDser.udfnGridSearchFilterStartWith(DGV_SearchGrid, grdItemList);
                //}
                //else
                //{
                //}
                grdItemList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdItemList);
                objDser.CloseConnection();
                grdItemList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
