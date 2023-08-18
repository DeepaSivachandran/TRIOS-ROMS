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
{
    public partial class CP_UserCategoryList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_UserCategoryList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_UserCategory = new CP_UserCategory();
                MainForm.objCP_UserCategory.ShowDialog();
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

        private void CP_UserList_Load(object sender, EventArgs e)
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
        public void udfndelete()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void udfnEdit()
        {
            try
            {
                MainForm.objCP_UserCategory = new CP_UserCategory();
                MainForm.objCP_UserCategory.btnSave.Text = "Update";
                MainForm.objCP_UserCategory.ShowDialog();
                //    if (grdUserList.SelectedRows.Count > 0)
                //    {
                //        MainForm.objCP_User = new CP_User();
                //        //MainForm.objCP_User.MdiParent = this.ParentForm;
                //        MainForm.objCP_User.varusercode = grdUserList.SelectedRows[0].Cells["Autonum"].Value.ToString();
                //        MainForm.objCP_User.ShowDialog();

                //    }

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
                picLoader.Visible = true;
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdUserCategoryList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
              //  objDs = objdserv.udfnSPUserList("List", "0", MainForm.pbUserID, MainForm.pbIpAddress);
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
                            grdUserCategoryList.DataSource = objDs.Tables[0];
                            grdUserCategoryList.Columns["Name of the User"].Width = 320;
                            grdUserCategoryList.Columns["User Role"].Width = 320;
                            grdUserCategoryList.Columns["SI.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdUserCategoryList.Columns["Autonum"].Visible = false;
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdUserCategoryList.ClearSelection();
                picLoader.Visible = false;
            }
        }

        private void CP_UserList_KeyDown(object sender, KeyEventArgs e)
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
         
        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 1))   /*If not our desired columns*/
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
                if (grdUserCategoryList.ColumnCount > 0)
                {
                    grdUserCategoryList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdUserCategoryList.HorizontalScrollingOffset;
                    //grdUserList.HorizontalScrollingOffset = 0;
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
                grdUserCategoryList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdUserCategoryList);
                objDser.CloseConnection();
                grdUserCategoryList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdUserCategoryList, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdUserCategoryList.Columns)
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
                DGV_SearchGrid.Columns["SI.No."].ReadOnly = true;
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
                        bs.DataSource = grdUserCategoryList.DataSource;
                        string filter = "";
                        for (int j = 1; j < DGV_SearchGrid.ColumnCount; j++)
                        {
                            if (Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) != "")
                            {
                                if (filter != "") filter += "And ";
                                //if (objValidation.FormatNumeric(Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value)))
                                //    filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + "=" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value);
                                //else
                                    filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + " LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                            }
                        }
                        bs.Filter = filter;
                        grdUserCategoryList.DataSource = bs;
                    }
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
        private void grdUserList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {

                int totalWidth = 0;
                int offSetValue = grdUserCategoryList.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;

                if (totalWidth - grdUserCategoryList.Width > grdUserCategoryList.HorizontalScrollingOffset && grdUserCategoryList.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue ;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdUserCategoryList);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = grdUserCategoryList.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = grdUserCategoryList.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    grdUserCategoryList.SortOrder == SortOrder.Ascending)
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
            grdUserCategoryList.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;
            DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
            DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
            DGV_SearchGrid.HorizontalScrollingOffset = grdUserCategoryList.HorizontalScrollingOffset;
            DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
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

    }
}
