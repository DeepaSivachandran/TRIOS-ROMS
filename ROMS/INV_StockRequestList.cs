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
    public partial class INV_StockRequestList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public INV_StockRequestList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objINV_StockRequest = new INV_StockRequest();
                MainForm.objINV_StockRequest.MdiParent = ParentForm;
                MainForm.objINV_StockRequest.Show();
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

        
        private void CP_Supplierlist_Load(object sender, EventArgs e)
        {
            try
            { 
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
                if (grdStockRequestList.SelectedRows.Count > 0)
                {
                    string result = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        SPDataService objspdservice = new SPDataService();
                        result = "";
                   
                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             

                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void udfnEdit()
        {
           

        }
         

      
        private void CP_Supplierlist_KeyDown(object sender, KeyEventArgs e)
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
        
        
        public void grdSupplierList_DoubleClick(object sender, EventArgs e)
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

        public void grdSupplierList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) { udfnEdit(); }
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

                //DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdStockRequestList.ColumnCount > 0)
                {
                    grdStockRequestList.Columns[e.Column.Index].Width = e.Column.Width;
                   // DGV_SearchGrid.HorizontalScrollingOffset = grdStockRequestList.HorizontalScrollingOffset;
                    //grdSupplierList.HorizontalScrollingOffset = 0;
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
            //try
            //{
            //    //udfnGridSearchFilter();
            //    DataService objDser = new DataService();
            //    grdStockRequestList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockRequestList);
            //    objDser.CloseConnection();
            //    grdStockRequestList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
            //    //DGV_SearchGrid_CellPainting(sender,e);
            //}
            //catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnSearchGridHead()
        {
            //try
            //{
            //    udfnGridSearchHeading(grdStockRequestList, DGV_SearchGrid);
            //    DGV_SearchGrid.Columns.Clear();
            //    List<int> visibleColumns = new List<int>();
            //    foreach (DataGridViewColumn col in grdStockRequestList.Columns)
            //    {
            //        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
            //        visibleColumns.Add(col.Index);
            //    }
            //    int rowIndex = 0;
            //    DGV_SearchGrid.Rows.Clear();
            //    DGV_SearchGrid.Rows.Add();
            //    for (int i = 0; i < visibleColumns.Count; i++)
            //    {
            //        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
            //    }
            //    DGV_SearchGrid.Columns["SI.No."].ReadOnly = true;
            //}
            //catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridSearchFilter()
        {
            //try
            //{
            //    for (int i = 0; i < DGV_SearchGrid.Rows.Count; ++i)
            //    {
            //        if (DGV_SearchGrid.ColumnCount > 0)
            //        {
            //            BindingSource bs = new BindingSource();
            //            bs.DataSource = grdStockRequestList.DataSource;
            //            string filter = "";
            //            for (int j = 1; j < DGV_SearchGrid.ColumnCount; j++)
            //            {
            //                if (Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) != "")
            //                {
            //                    if (filter != "") filter += "And ";
            //                    if (objValidation.FormatNumeric(Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value)))
            //                        filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + "=" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value);
            //                    else
            //                        filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + " LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
            //                }
            //            }
            //            bs.Filter = filter;
            //            grdStockRequestList.DataSource = bs;
            //        }
            //    }
            //}
            //catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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
        private void grdSupplierList_Scroll(object sender, ScrollEventArgs e)
        {
            //try
            //{

            //    int totalWidth = 0;
            //    int offSetValue = grdStockRequestList.HorizontalScrollingOffset;
            //    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
            //        totalWidth += col.Width;

            //    if (totalWidth - grdStockRequestList.Width > grdStockRequestList.HorizontalScrollingOffset && grdStockRequestList.HorizontalScrollingOffset > 0)
            //    {
            //        offSetValue = offSetValue ;
            //        offSetValue = offSetValue;
            //    }
            //    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
            //    DGV_SearchGrid.Invalidate();

            //    udfnscrollVisible(DGV_SearchGrid, grdStockRequestList);
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void DGV_SearchGrid_Sorted(object sender, EventArgs e)
        {

        }

        private void DGV_SearchGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

     
        //private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    DataGridViewColumn newColumn = grdStockRequestList.Columns[e.ColumnIndex];
        //    DataGridViewColumn oldColumn = grdStockRequestList.SortedColumn;
        //    ListSortDirection direction;

        //    // If oldColumn is null, then the DataGridView is not sorted.
        //    if (oldColumn != null)
        //    {
        //        // Sort the same column again, reversing the SortOrder.
        //        if (oldColumn == newColumn &&
        //            grdStockRequestList.SortOrder == SortOrder.Ascending)
        //        {
        //            direction = ListSortDirection.Descending;
        //        }
        //        else
        //        {
        //            // Sort a new column and remove the old SortGlyph.
        //            direction = ListSortDirection.Ascending;
        //            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
        //        }
        //    }
        //    else
        //    {
        //        direction = ListSortDirection.Ascending;
        //    }
        //    grdStockRequestList.Sort(newColumn, direction);
        //    newColumn.HeaderCell.SortGlyphDirection =
        //        direction == ListSortDirection.Ascending ?
        //        SortOrder.Ascending : SortOrder.Descending;

        //    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
        //    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

        //    DGV_SearchGrid.HorizontalScrollingOffset = grdStockRequestList.HorizontalScrollingOffset;
        //    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
        //}

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            //try
            //{

            //    int totalWidth = 0;
            //    int offSetValue = grdStockRequestList.HorizontalScrollingOffset;
            //    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
            //        totalWidth += col.Width;

            //    if (totalWidth - grdStockRequestList.Width > grdStockRequestList.HorizontalScrollingOffset && grdStockRequestList.HorizontalScrollingOffset > 0)
            //    {
            //        //offSetValue = offSetValue ;
            //        offSetValue = offSetValue;
            //    }
            //    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
            //    DGV_SearchGrid.Invalidate();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
        public void udfnscrollVisible(DataGridView DGV,DataGridView grdGroupList)
        {
            //try
            //{
            //    var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
            //    if (vScrollbar.Visible == true)
            //    {
            //        List<int> visibleColumns = new List<int>();
            //        foreach (DataGridViewColumn col in DGV.Columns)
            //        {
            //            visibleColumns.Add(col.Index);
            //        }

            //        int I = DGV_SearchGrid.Rows.Count - 1;
            //        if (I == 0)
            //        {
            //            int rowIndex = 1;
            //            DGV_SearchGrid.Rows.Add();
            //            for (int i = 0; i < visibleColumns.Count; i++)
            //            {
            //                DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
    }
}
