using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{        //Created By:-Sathish
         //Created On:-09/08/2023
    public partial class PAY_AdvanceList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public string varUserID = "";
        public PAY_AdvanceList()
        {
            InitializeComponent();
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPAY_Advance = new PAY_Advance();
                MainForm.objPAY_Advance.FormBorderStyle = FormBorderStyle.FixedSingle;
                MainForm.objPAY_Advance.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
            try
            {
                if (grdAdvanceList.SelectedRows.Count > 0)
                {
                    string varResult = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SPDataService objspservice = new SPDataService();
                        varResult = objspservice.udfnUnit(2, Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["ID"].Value), "", "", 0, 0, "Unit Delete", "", varUserID, 0,0);
                        objspservice.CloseConnection();
                        if (varResult.Split('~')[0] == "3")
                        {
                            if (varResult.Split('~')[1] == "1")
                            {
                                MainForm.objCP_Verify = new CP_Verify();
                                MainForm.objCP_Verify.ShowDialog();
                                varUserID = MainForm.objCP_Verify.varUserId;
                                if (MainForm.objCP_Verify.flag == 1)
                                {
                                    objspservice = new SPDataService();
                                    varResult = objspservice.udfnUnit(2, Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["ID"].Value), "", "", 0, 0, "Unit Delete", "", varUserID, 0, 1);
                                    objspservice.CloseConnection();
                                    if (varResult.Split('~')[0] == "3")
                                    {
                                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        udfnList();
                                    }
                                    else { MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void udfnEdit()
        {
            try
            {
                if (grdAdvanceList.SelectedRows.Count > 0)
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objCP_Unit = new CP_Unit();
                    MainForm.objCP_Unit.btnSave.Text = "Update";
                    MainForm.objCP_Unit.varUnitCode = Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_Unit.pbDecimalId = Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["decimalID"].Value);
                    MainForm.objCP_Unit.PbUnitName = Convert.ToString(grdAdvanceList.SelectedRows[0].Cells["Unit Name"].Value);
                    MainForm.objCP_Unit.PbSymbol = Convert.ToString(grdAdvanceList.SelectedRows[0].Cells["Unit"].Value);
                    MainForm.objCP_Unit.PbNoOfDecimals = Convert.ToString(grdAdvanceList.SelectedRows[0].Cells["No.of Decimals"].Value);
                    MainForm.objCP_Unit.PbStatus = Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["StatusID"].Value);
                    MainForm.objCP_Unit.pbInvoiceUnit = Convert.ToString(grdAdvanceList.SelectedRows[0].Cells["E-Invoice Unit"].Value);
                    MainForm.objCP_Unit.varBulkUnitId = Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["BulkUnitId"].Value);
                    MainForm.objCP_Unit.ShowDialog();
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
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdAdvanceList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************    
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnUnitList(0, 0,0);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdAdvanceList.DataSource = objDs.Tables[0];

                            grdAdvanceList.Columns["ID"].Visible = false;
                            grdAdvanceList.Columns["DecimalID"].Visible = false;
                            grdAdvanceList.Columns["StatusID"].Visible = false;
                            grdAdvanceList.Columns["BulkUnitId"].Visible = false;
                            grdAdvanceList.Columns["S.No."].Width = 50;
                            grdAdvanceList.Columns["Status"].Width = 80;
                            grdAdvanceList.Columns["Bulk Unit"].Width = 100;
                            grdAdvanceList.Columns["Bulk Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAdvanceList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAdvanceList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAdvanceList.Columns["No.of Decimals"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdAdvanceList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                    objspservice.CloseConnection();
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
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["DecimalID"].Visible = false;
                DGV_SearchGrid.Columns["StatusID"].Visible = false;
                DGV_SearchGrid.Columns["BulkUnitId"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Status"].Width = 80;
                DGV_SearchGrid.Columns["Bulk Unit"].Width = 100; DGV_SearchGrid.ScrollBars = ScrollBars.Both;
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

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);
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
                if (grdAdvanceList.ColumnCount > 0)
                {
                    grdAdvanceList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdAdvanceList.HorizontalScrollingOffset;
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
                grdAdvanceList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdAdvanceList);
                objDser.CloseConnection();
                grdAdvanceList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                    udfnGridSearchHeading(grdAdvanceList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdAdvanceList.Columns)
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
        private void udfnGridSearchFilter()
        {
            try
            {
                for (int i = 0; i < DGV_SearchGrid.Rows.Count; ++i)
                {
                    if (DGV_SearchGrid.ColumnCount > 0)
                    {
                        BindingSource bs = new BindingSource();
                        bs.DataSource = grdAdvanceList.DataSource;
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
                        grdAdvanceList.DataSource = bs;
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
                DataGridViewColumn newColumn = grdAdvanceList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdAdvanceList.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdAdvanceList.SortOrder == SortOrder.Ascending)
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
                grdAdvanceList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGrid.HorizontalScrollingOffset = grdAdvanceList.HorizontalScrollingOffset;
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
                    int offSetValue = grdAdvanceList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdAdvanceList.Width > grdAdvanceList.HorizontalScrollingOffset && grdAdvanceList.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdAdvanceList);
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
        private void CP_Unitlist_KeyDown(object sender, KeyEventArgs e)
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
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D))
                {
                    tsbDelete_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm objMainForm = new MainForm();
                    objMainForm.udfnCloseChildForms();
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
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
        private void CP_Unitlist_Load(object sender, EventArgs e)
        {
            try
            {
                //udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdUnitList_DoubleClick(object sender, EventArgs e)
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
        private void GrdUnitList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                udfnEdit();
            }
        }
        private void GrdUnitList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdAdvanceList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdAdvanceList.Rows[i].Cells["StatusID"].Value) == "1")
                    {
                        grdAdvanceList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdAdvanceList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdAdvanceList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdAdvanceList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    grdAdvanceList.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdUnitList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdAdvanceList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdAdvanceList.Width > grdAdvanceList.HorizontalScrollingOffset && grdAdvanceList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdAdvanceList);
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
            if (DGV_SearchGrid.IsCurrentCellDirty)
            {
                // Commit the changes immediately
                DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            DataService objDser = new DataService();
            grdAdvanceList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdAdvanceList);
            objDser.CloseConnection();
            grdAdvanceList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                //DataService objDser = new DataService();
                //grdUnitList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdUnitList);
                //objDser.CloseConnection();
                //grdUnitList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
    }
}
