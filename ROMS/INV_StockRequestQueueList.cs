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
    public partial class INV_StockRequestQueueList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        MainForm objMainForm = new MainForm();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public string varUserID = "";
        public int varUpDownKey = 0;
        Boolean BlnSearchImageYN = false;
        public int MenuCode = 0, varUpDownKeyLocation = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        private Timer timer;
        DateTime varmaxdate;
        public INV_StockRequestQueueList()
        {
            InitializeComponent();
            windowControl.Initialize(tsStockRequestList, this);
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objINV_StockRequest = new INV_StockRequest();
                    MainForm.objINV_StockRequest.MdiParent = ParentForm;
                    //objMainForm.CenterEntryForm(this, MainForm.objINV_StockRequest);
                    MainForm main = (MainForm)this.MdiParent;
                    main.IsEntryFormOpen = true;
                    main.CurrentEntryForm = MainForm.objINV_StockRequest;
                    main.CurrentParentListForm = this;
                    MainForm.objINV_StockRequest.Show();
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
                    if (grdStockRequestList.SelectedRows.Count > 0)
                    {
                        string result = "";
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {

                            SPDataService objspdservice = new SPDataService();
                            result = "";
                            Model.TRN_StockRequest objTRNS_StockRequest = new Model.TRN_StockRequest();
                            objTRNS_StockRequest.ViewType = 2;
                            objTRNS_StockRequest.paraStockRequestID = Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["SRQID"].Value.ToString());
                            objTRNS_StockRequest.paraOriginator = "Stock Request Delete";
                            result = objspdservice.udfnStockRequest(objTRNS_StockRequest);
                            objspdservice.CloseConnection();

                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "3")
                            {
                                if (result.Split('~')[1] == "1")
                                {
                                    MainForm.objCP_Verify = new CP_Verify();
                                    MainForm.objCP_Verify.ShowDialog();
                                    varUserID = MainForm.objCP_Verify.varUserId;
                                    if (MainForm.objCP_Verify.flag == 1)
                                    {
                                        objTRNS_StockRequest.ViewType = 2;
                                        objTRNS_StockRequest.paraStockRequestID = Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["SRQID"].Value.ToString());
                                        objTRNS_StockRequest.paraOriginator = "Stock Request Delete";
                                        objTRNS_StockRequest.paraDeleteFlag = 1;
                                        result = objspdservice.udfnStockRequest(objTRNS_StockRequest);
                                        if (result.Split('~')[0] == "3")
                                        {
                                            MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            udfnList();
                                        }
                                        else { MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                    }
                                }
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
                    if (grdStockRequestList.SelectedRows.Count > 0)
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        MainForm.objINV_StockRequest = new INV_StockRequest();
                        MainForm.objINV_StockRequest.MdiParent = ParentForm;
                        MainForm.objINV_StockRequest.btnSave.Text = "Update";
                        MainForm.objINV_StockRequest.varStockRequestID = Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["SRQID"].Value);
                        MainForm.objINV_StockRequest.varStatus = Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["StatusID"].Value);
                        MainForm.objINV_StockRequest.varMainStatus = Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["StatusID"].Value);
                        MainForm.objINV_StockRequest.pbID = Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["SREQID"].Value);
                        MainForm.objINV_StockRequest.pbscreenflag = 1;
                        //objMainForm.CenterEntryForm(this, MainForm.objINV_StockRequest);
                        MainForm main = (MainForm)this.MdiParent;
                        main.IsEntryFormOpen = true;
                        main.CurrentEntryForm = MainForm.objINV_StockRequest;
                        main.CurrentParentListForm = this;
                        MainForm.objINV_StockRequest.Show();
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
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D))
                {
                    if ((Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["Received Qty"].Value) == 0 || Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["StatusID"].Value) == 47 || Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["StatusID"].Value) == 28 || ((Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["StatusID"].Value) == 29) && (Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["Received Qty"].Value) == 0))))
                    {
                        tsbDelete_Click(sender, e);
                    }
                }
                if (e.KeyCode == Keys.Escape)
                {
                    //MainForm.objStart = new DEF_Start();
                    //MainForm.objStart.MdiParent = this.ParentForm;
                    //MainForm.objStart.Show();
                    //this.Close();
                    windowControl?.TriggerClose();
                }
                if (e.KeyCode == Keys.Delete)
                {
                    if ((Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["Received Qty"].Value) > 0 || Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["StatusID"].Value) == 47 || Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["StatusID"].Value) == 28 || ((Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["StatusID"].Value) == 29) && (Convert.ToInt32(grdStockRequestList.SelectedRows[0].Cells["Received Qty"].Value) == 0))))
                    {
                        udfndelete();
                    }
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

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

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
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdStockRequestList, DGV__SearchGrid);
                    DGV__SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdStockRequestList.Columns)
                    {
                        DGV__SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV__SearchGrid.Rows.Clear();
                    DGV__SearchGrid.Rows.Add();
                    DGV__SearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                    //DGV__SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                    for (int i = 2; i < visibleColumns.Count; i++)
                    {
                        DGV__SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV__SearchGrid.Columns["S.No."].ReadOnly = true;
                    DGV__SearchGrid.Columns[0].ReadOnly = true;
                    //DGV__SearchGrid.Columns[1].ReadOnly = true;
                    DGV__SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                    //DGV__SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnProSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnProGridSearchHeading(grdProDetails, DGV_SearchGridPro);
                    DGV_SearchGridPro.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdProDetails.Columns)
                    {
                        DGV_SearchGridPro.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGridPro.Rows.Clear();
                    DGV_SearchGridPro.Rows.Add();
                    DGV_SearchGridPro.Columns[0].DefaultCellStyle.NullValue = null;
                    //DGV__SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                    for (int i = 2; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGridPro.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_SearchGridPro.Columns["S.No."].ReadOnly = true;
                    DGV_SearchGridPro.Columns[0].ReadOnly = true;
                    //DGV_SearchGridPro.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnProGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
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
                    dpEntryToDate.Focus();
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

        private void DpEntryToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpEntryToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpEntryToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpEntryToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpEntryToDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_StockRequestList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 308;
                udfnDate();
                cmbConcern.Focus();
                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId; 
                //dpFromDate.Text = Convert.ToString(MainForm.pbCurrentDate);
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpEntryToDate.MaxDate = MainForm.pbCurrentDate;
                timer = new Timer();
                timer.Interval = 30000; // 30 seconds
                timer.Tick += Timer_Tick;
                timer.Enabled = true; 
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
        private void Timer_Tick(object sender, EventArgs e)
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
        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(MenuCode);
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions; 
                btnExport.Visible = privilege.Contains("6"); 
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
        public void udfnList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV__SearchGrid.DataSource = null;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdStockRequestList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                Model.TRN_StockRequest objTRNG_StockRequest = new Model.TRN_StockRequest();
                objTRNG_StockRequest.ViewType = 9; 
                objTRNG_StockRequest.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue); 
                objTRNG_StockRequest.ParaSTFromDate = Convert.ToString(dpFromDate.Text);
                objTRNG_StockRequest.ParaSTToDate = Convert.ToString(dpEntryToDate.Text); 
                objTRNG_StockRequest.paraSLID = Convert.ToInt16(lblLocationCode.Text); 
                objDs = objspservice.udfnStockRequestList(objTRNG_StockRequest);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdStockRequestList.DataSource = objDs.Tables[0];
                            grdStockRequestList.Columns["ConcernID"].Visible = false;
                            grdStockRequestList.Columns["StatusID"].Visible = false;
                            grdStockRequestList.Columns["SREQID"].Visible = false;
                            grdStockRequestList.Columns["SRQID"].Visible = false;
                            grdStockRequestList.Columns["S.No."].Width = 50;
                            grdStockRequestList.Columns["Status"].Width = 120;
                            grdStockRequestList.Columns["Created By"].Width = 100;
                            grdStockRequestList.Columns["Created On"].Width = 150;
                            grdStockRequestList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockRequestList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockRequestList.Columns["Request Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockRequestList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockRequestList.BringToFront();
                            DGV__SearchGrid.BringToFront();
                            grdProDetails.SendToBack();
                            DGV_SearchGridPro.SendToBack();
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
                else { DGV__SearchGrid.ScrollBars = ScrollBars.Vertical; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdStockRequestList.ClearSelection();
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
                DGV__SearchGrid.DataSource = dtDefaultGrid;
                DGV__SearchGrid.Columns["ConcernID"].Visible = false;
                DGV__SearchGrid.Columns["StatusID"].Visible = false;
                DGV__SearchGrid.Columns["SREQID"].Visible = false; 
                DGV__SearchGrid.Columns["SRQID"].Visible = false; 
                DGV__SearchGrid.Columns["S.No."].Width = 50;
                DGV__SearchGrid.Columns["Status"].Width = 80;
                DGV__SearchGrid.Columns["Created By"].Width = 100; DGV__SearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefaultProSearchGrid()
        {
            try
            {
                DGV_SearchGridPro.DataSource = dtDefaultGrid;
                DGV_SearchGridPro.Columns["S.No."].Width = 50;
                DGV_SearchGridPro.Columns["Status"].Width = 120;
                DGV_SearchGridPro.ScrollBars = ScrollBars.Both;
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
        public void udfnDate()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 4;
                objMR_Master.paraID = 6;
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                if (objd.Tables[1].Rows.Count != 0)
                {
                    varmaxdate = DateTime.ParseExact(objd.Tables[1].Rows[0]["mintoday"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                objMR_Master.ViewType = 9; 
                objMR_Master.paraFlag = 21;
                objd = null;
                objd = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                if (objd.Tables[0].Rows.Count != 0)
                {
                    DateTime varmindate = MainForm.pbFYStartDate;
                    dpFromDate.MinDate = varmindate;
                    dpFromDate.Text = Convert.ToString(objd.Tables[0].Rows[0]["DATE1"]);
                }
                dpFromDate.MaxDate = varmaxdate;
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
                btnView.Enabled = false; 
                udfnList();
                btnView.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV__SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdStockRequestList.DataSource = objDser.udfnGridSearchFilter(DGV__SearchGrid, grdStockRequestList);
                objDser.CloseConnection();
                grdStockRequestList.HorizontalScrollingOffset = DGV__SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError(); objError.WriteFile(ex);
            }
        }

        private void DGV__SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                DGV__SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV__SearchGrid_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdStockRequestList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdStockRequestList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn && grdStockRequestList.SortOrder == SortOrder.Ascending)
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
                        grdStockRequestList.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        DataGridViewColumn DGV = DGV__SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                        DGV__SearchGrid.HorizontalScrollingOffset = grdStockRequestList.HorizontalScrollingOffset;
                        DGV__SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV__SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdStockRequestList.ColumnCount > 0)
                {
                    grdStockRequestList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV__SearchGrid.HorizontalScrollingOffset = grdStockRequestList.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV__SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGV__SearchGrid.IsCurrentCellDirty)
            {
                // Commit the changes immediately
                DGV__SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            DataService objDser = new DataService();
            grdStockRequestList.DataSource = objDser.udfnGridSearchFilter(DGV__SearchGrid, grdStockRequestList);
            objDser.CloseConnection();
            grdStockRequestList.HorizontalScrollingOffset = DGV__SearchGrid.HorizontalScrollingOffset;
        }

        private void DGV__SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdStockRequestList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV__SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdStockRequestList.Width > grdStockRequestList.HorizontalScrollingOffset && grdStockRequestList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV__SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV__SearchGrid.Invalidate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockRequestList_KeyDown(object sender, KeyEventArgs e)
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

        private void GrdStockRequestList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockRequestList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdStockRequestList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdStockRequestList.Rows[i].Cells["StatusID"].Value) == "28")
                    {
                        grdStockRequestList.Rows[i].Cells["Status"].Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        grdStockRequestList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else if(Convert.ToString(grdStockRequestList.Rows[i].Cells["StatusID"].Value) == "48")
                    {
                        grdStockRequestList.Rows[i].Cells["Status"].Style.BackColor = ColorTranslator.FromHtml("108, 252, 45");
                        grdStockRequestList.Rows[i].Cells["Status"].Style.ForeColor = Color.Black;
                    }
                    else
                    {
                        grdStockRequestList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdStockRequestList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                }
                grdStockRequestList.Columns["clmprint"].Resizable = DataGridViewTriState.False;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdStockRequestList.ClearSelection();
            }
        }

        private void GrdStockRequestList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdStockRequestList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV__SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdStockRequestList.Width > grdStockRequestList.HorizontalScrollingOffset && grdStockRequestList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV__SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV__SearchGrid.Invalidate();
                    udfnscrollVisible(DGV__SearchGrid, grdStockRequestList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            { 
                udfnPrint(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPrint()
        {
            try
            {
                btnExport.Enabled = false; 
                if ((grdStockRequestList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Shop Stock Request";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdStockRequestList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Shop Stock Request";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdStockRequestList.Columns)
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

                            if (col.Name == "S.No." || col.Name == "Concern")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 10;
                            }
                            else if (col.Name == "Request Date" || col.Name == "Request No." || col.Name == "Created By" || col.Name == "Status" || col.Name == "Created On")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 20;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 15;
                            }
                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Total Products")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdStockRequestList.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex - 1] = rowa.Cells[col.Index].Value;
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
        public void udfnProPrint()
        {
            try
            {
                btnExport.Enabled = false; 
                if ((grdProDetails.Rows.Count > 0))
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
                    ExcelSheet.Name = "Shop Stock Request Products";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdProDetails.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Shop Stock Request Products";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdProDetails.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "S.No." || col.Name == "Concern" || col.Name == "Request No." || col.Name == "Unit")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            else if (col.Name == "Request Date" || col.Name == "PICode" )
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 25;
                            }
                            else if (col.Name == "Product Name")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 38;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            if (col.Name == "S.No." || col.Name == "Unit" || col.Name == "Status")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            foreach (DataGridViewRow rowa in grdProDetails.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                                if (col.Name == "Product Name")
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex].Font.Name = "Uni Ila.Sundaram-03";
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
        private void DpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpEntryToDate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void GrdStockRequestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdStockRequestList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmprint":
                            try
                            {
                                string SREQID = "0", SLID = "0";
                                SREQID = Convert.ToString(grdStockRequestList.SelectedRows[0].Cells["SREQID"].Value.ToString()); 
                                DialogResult result1;
                                SPDataService objDServ = new SPDataService();
                                string varMessage = objDServ.udfnGetMessages(87);
                                objDServ.CloseConnection();
                                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result1 == DialogResult.Yes)
                                { 
                                    string varHeader = "";
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_INV_Shop_Stock_Request_Queue.rpt");
                                    varHeader = "Shop Stock Request";

                                    objBillreport.SetParameterValue("paraStockRequestID", Convert.ToInt32(SREQID));
                                    objBillreport.SetParameterValue("paraConcern", Convert.ToInt32(cmbConcern.SelectedValue));
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                                    objValidation.CrySqlConnection(objBillreport);

                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.Text = varHeader;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            {
                                objError = new DataError();
                                objError.WriteFile(ex);
                            }
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
        private void GrdStockRequestList_SelectionChanged(object sender, EventArgs e)
        {
             
        }
           
        private void GrdProDetails_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdProDetails.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGridPro.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdProDetails.Width > grdProDetails.HorizontalScrollingOffset && grdProDetails.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGridPro.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGridPro.Invalidate();
                    udfnscrollVisible(DGV_SearchGridPro, grdProDetails);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridPro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdProDetails.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridPro, grdProDetails);
                objDser.CloseConnection();
                grdProDetails.HorizontalScrollingOffset = DGV_SearchGridPro.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError(); objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridPro_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }
                DGV_SearchGridPro.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridPro_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdProDetails.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdProDetails.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn && grdProDetails.SortOrder == SortOrder.Ascending)
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
                        grdProDetails.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        DataGridViewColumn DGV = DGV_SearchGridPro.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                        DGV_SearchGridPro.HorizontalScrollingOffset = grdProDetails.HorizontalScrollingOffset;
                        DGV_SearchGridPro.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridPro_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdProDetails.ColumnCount > 0)
                {
                    grdProDetails.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGridPro.HorizontalScrollingOffset = grdProDetails.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridPro_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGV_SearchGridPro.IsCurrentCellDirty)
            {
                // Commit the changes immediately
                DGV_SearchGridPro.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            DataService objDser = new DataService();
            grdProDetails.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridPro, grdProDetails);
            objDser.CloseConnection();
            grdProDetails.HorizontalScrollingOffset = DGV_SearchGridPro.HorizontalScrollingOffset;
        }

        private void DGV_SearchGridPro_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdProDetails.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGridPro.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdProDetails.Width > grdProDetails.HorizontalScrollingOffset && grdProDetails.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGridPro.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGridPro.Invalidate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdProDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdProDetails.Rows.Count; i++)
                {
                    if (Convert.ToString(grdProDetails.Rows[i].Cells["STSID"].Value) == "47")
                    {
                        grdProDetails.Rows[i].Cells["Status"].Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        grdProDetails.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grdProDetails.Rows[i].Cells["STSID"].Value) == "48")
                    {
                        grdProDetails.Rows[i].Cells["Status"].Style.BackColor = ColorTranslator.FromHtml("108, 252, 45");
                        grdProDetails.Rows[i].Cells["Status"].Style.ForeColor = Color.Black;
                    }
                    else
                    {
                        grdProDetails.Rows[i].Cells["Status"].Style.BackColor = Color.Red;
                        grdProDetails.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                grdProDetails.ClearSelection();
            }
        }

        private void pnlStockRequestList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                //udfnGridNull((Control)sender);
                txtLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterLocation.Visible == false)
                {
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterLocation.Focus();
                }
                if (DGV_FilterLocation.CurrentCell == null && DGV_FilterLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterLocation.Focus();
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnSLocationEvent();
                                    DGV_FilterLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtLocation.Focus();
                    //txtLocation.SelectionStart = txtLocation.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLocation.BackColor = Color.White;
                if (txtLocation.Text == "")
                {
                    lblLocationCode.Text = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyLocation == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtLocation.Text.Length > 0)
                    {
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 12;
                        objMR_Location.paraLocationName = txtLocation.Text;
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(12, 0, 0, 0, txtLocation.Text, 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterLocation.Visible = true;
                                    DGV_FilterLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_RKCreation"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterLocation.Columns["SL_EName"].Width = 220;
                                    DGV_FilterLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterLocation.Visible = false;
                                    DGV_FilterLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterLocation.Visible = false;
                                DGV_FilterLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterLocation.Visible = false;
                            DGV_FilterLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterLocation.Visible = false;
                        DGV_FilterLocation.DataSource = null;
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

            }
        }

        private void DGV_FilterLocation_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 1;
                udfnSLocationEvent();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSLocationEvent()
        {
            try
            {
                if (txtLocation.Text.Trim() != "")
                {
                    lblLocationCode.Text = DGV_FilterLocation.SelectedRows[0].Cells["SLID"].Value.ToString();
                    txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterLocation.Visible = false;
                btnView.Focus();
            }
        } 

        private void DGV_FilterLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnSLocationEvent();
                                    DGV_FilterLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnView.Focus();
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
