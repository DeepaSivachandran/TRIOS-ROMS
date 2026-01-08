
using DocumentFormat.OpenXml.Bibliography;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ROMS
{
    // Name  : venkat    Date : 07/01/2026
    public partial class CP_BulkUpdate_Minqty : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public int varFormFlag = 0;

        public int varId = 0, varGroupId = 0, grid_flag = 0;
        public int varSubGroupId = 0;
        public int varBrandId = 0;
        public int varViewType = 0;
        public int varStatusId = 0, varErrorflag = 0, Varupdateflag = 0;
        public int SearchFlag = 0;
        public int varUpDownKeyProduct = 0, varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyLocation = 0, varUpDownKeySupplier = 0, varUpDownKeyBrand = 0;

        Boolean BlnSearchImageYN = false;
         
        DataTable objdtProducts = new DataTable();
        DataTable objdtProductsMapping = new DataTable();
        private ToolTip tpFiledtype = new ToolTip();

        private void CP_Spl_Products_Bulk_Load(object sender, EventArgs e)
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

        DataSet objDSProduct = new DataSet();
        public int pbMenuFlag = 0;

        public CP_BulkUpdate_Minqty()
        {
            InitializeComponent();
            windowControl.Initialize(tsBulkAttribute, this);
        }


        private void DGV_SearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }


        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.Text = "";
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdProducts.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdProducts);
                objDser.CloseConnection();
                grdProducts.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                lblTotalProducts.Text = grdProducts.Rows.Count.ToString();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }


        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdProducts.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdProducts);
                objDser.CloseConnection();
                grdProducts.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            finally
            {
                SearchFlag = 1;
            }
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
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdProducts.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdProducts.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdProducts.SortOrder == SortOrder.Ascending)
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
                    grdProducts.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdProducts.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
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
                if (grdProducts.ColumnCount > 0)
                {
                    grdProducts.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdProducts.HorizontalScrollingOffset;
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
                int totalWidth = 0;
                int offSetValue = grdProducts.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdProducts.Width > grdProducts.HorizontalScrollingOffset && grdProducts.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }



        private void grdProducts_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdProducts.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in grdHeaderview.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdProducts.Width > grdProducts.HorizontalScrollingOffset && grdProducts.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                grdHeaderview.HorizontalScrollingOffset = offSetValue;
                grdHeaderview.Invalidate();
                udfnscrollVisible(grdHeaderview, grdProducts);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    int vscroll = grdProducts.FirstDisplayedScrollingRowIndex;
                    int hscroll = grdProducts.FirstDisplayedScrollingColumnIndex;
                    int varProId = Convert.ToInt16(grdProducts.SelectedRows[0].Cells["PRODUCTID"].Value);
                    udfnGetProductCount(varProId);
                    grdProducts.FirstDisplayedScrollingRowIndex = vscroll;
                    grdProducts.FirstDisplayedScrollingColumnIndex = hscroll;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdProducts_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdProducts.IsCurrentCellDirty)
                {
                    grdProducts.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdProducts.ClearSelection();
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
        private void txtMappingGroup_Enter(object sender, EventArgs e)
        {
            try
            { 
                txtMappingGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMappingGroup_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            txtMappingGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();

                            txtMappingGroup.Focus();
                            txtMappingGroup.SelectionStart = txtMappingGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtMappingGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtMappingGroup.Focus();
                            txtMappingGroup.SelectionStart = txtMappingGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyGroup = 1;
                                    udfnGroupAutocomplete();
                                    DGV_FilterGroup.Visible = false;
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
                        txtMappingSubGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMappingGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMappingGroup.BackColor = Color.White;
                if (txtMappingGroup.Text.Trim() == "") { varGroupId = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMappingGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyGroup == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtMappingGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnGroupList(7, 0, 0, txtMappingGroup.Text, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterGroup.Visible = true;
                                    DGV_FilterGroup.DataSource = objDs.Tables[0];
                                    DGV_FilterGroup.Columns["PRGID"].Visible = false;
                                    DGV_FilterGroup.Columns["PRG_EName"].HeaderText = "Group English Name";
                                    DGV_FilterGroup.Columns["PRG_TName"].HeaderText = "Group Tamil Name";
                                    DGV_FilterGroup.Columns["PRG_EName"].Width = 130;
                                    DGV_FilterGroup.Columns["PRG_TName"].Width = 130;
                                    DGV_FilterGroup.Columns["PRG_EName"].DisplayIndex = 0;
                                    DGV_FilterGroup.Columns["PRG_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterGroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterGroup.Visible = false;
                                    DGV_FilterGroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterGroup.Visible = false;
                                DGV_FilterGroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterGroup.Visible = false;
                            DGV_FilterGroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterGroup.Visible = false;
                        DGV_FilterGroup.DataSource = null;
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
                txtMappingGroup.ReadOnly = false;
                txtMappingSubGroup.ReadOnly = false;
                txtBrand.ReadOnly = false;
                btnMappingView.Enabled = true;
                txtMappingGroup.Enabled = true;
                txtMappingSubGroup.Enabled = true;
                txtBrand.Enabled = true;  
                if (varId != 0) { 
                    txtMappingGroup.ReadOnly = true;
                    txtMappingSubGroup.ReadOnly = true;
                    txtBrand.ReadOnly = true;
                    btnMappingView.Enabled = false;
                    txtMappingGroup.Enabled = false;
                    txtMappingSubGroup.Enabled = false;
                    txtBrand.Enabled = false;
                }

                if (varViewType == 2) { 
                 btnMappingsave.Text= "Approve";
                }
                else
                {
                    btnMappingsave.Text = "Update";
                }
                lblNoRecordsFound.Visible = false;
                grdProducts.DataSource = null;
                grdHeaderview.DataSource = null;
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 3;
                objMR_Product.paraGroup = varGroupId;
                objMR_Product.paraSubgroup = varSubGroupId;
                objMR_Product.paraBrandID = varBrandId;
                objMR_Product.paraId = varId;

                DataSet objDs = new DataSet();
                objdtProducts = null;
                udfnInitProduct();
                SPDataService objspservice = new SPDataService(); 
                objDs = objspservice.udfnRateCategoryList(objMR_Product);
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    grdHeaderview.DataSource = objDs.Tables[0];
                    foreach (DataGridViewColumn column in grdHeaderview.Columns)
                    {
                        column.Width = 100;
                    }

                    grdHeaderview.Columns[1].Width = 30;
                    grdHeaderview.Columns["S.No."].Width = 50;
                    grdHeaderview.Columns["P.I Code"].Width = 140;
                    grdHeaderview.Columns["Unit"].Width = 60;
                    grdHeaderview.Columns["Product Name in Tamil"].Width = 450;


                    grdHeaderview.Columns["S.No."].HeaderText = "";
                    grdHeaderview.Columns["P.I Code"].HeaderText = "";
                    grdHeaderview.Columns["Unit"].HeaderText = "";
                    grdHeaderview.Columns["Product Name in Tamil"].HeaderText = "";
                }
                if (objDs.Tables[1].Rows.Count != 0)
                {
                    //for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    //{
                    //    objdtProducts.Rows.Add(objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in Tamil"]
                    //        , objDs.Tables[0].Rows[i]["Unit"]
                    //        , Convert.ToDecimal(objDs.Tables[0].Rows[i]["Last Rate"])
                    //        , Convert.ToDecimal(objDs.Tables[0].Rows[i]["Live Rate"])
                    //        , Convert.ToDecimal(objDs.Tables[0].Rows[i]["Parent Rate"])
                    //        , Convert.ToDecimal(objDs.Tables[0].Rows[i]["UPP"]) 
                    //        , Convert.ToDecimal(objDs.Tables[0].Rows[i]["PRODUCTID"]));
                    //}
                    grdProducts.DataSource = objDs.Tables[1];
                    foreach (DataGridViewColumn column in grdProducts.Columns)
                    {

                        string[] parts = column.HeaderText.Split('-');

                        if (parts.Length > 1)
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            column.HeaderText = parts[parts.Length - 1];

                            if ((column.Index % 2) == 1)
                            {
                                column.ReadOnly = true; 
                            }
                            else {
                                column.ReadOnly = false;
                                column.DefaultCellStyle.BackColor = Color.PaleGreen; 
                            }
                            column.Width = 50;
                        }
                    }

                    //  grdProducts.Columns[0].Frozen = true;
                    grdProducts.Columns[1].HeaderText = "";
                    grdProducts.Columns[1].Width = 30;
                    grdProducts.Columns["S.No."].Width = 50;
                    grdProducts.Columns["P.I Code"].Width = 140;
                    grdProducts.Columns["Unit"].Width = 60;
                    grdProducts.Columns["Product Name in Tamil"].Width = 450;
                    grdProducts.Columns["Product Name in Tamil"].Frozen=true;

                    grdProducts.Columns["PRODUCTID"].Visible = false;

                    grdProducts.Columns["S.No."].ReadOnly = true; 
                    grdProducts.Columns["P.I Code"].ReadOnly = true;
                    grdProducts.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdProducts.Columns["Unit"].ReadOnly = true;
                    grdProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F); 
                    grdProducts.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    objdtProducts.Rows.Clear();
                    objdtProducts = null;
                    lblNoRecordsFound.BringToFront();
                    //objdtProducts.AcceptChanges();
                    grdProducts.DataSource = objdtProducts;
                }
                objspservice.CloseConnection();
                udfnSearchGridHead(); //grid 1
                udfnsearchgridHead(); //grid 2
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                SearchFlag = 0;
                lblTotalProducts.Text = grdProducts.Rows.Count.ToString();
            }
        }

        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdProducts, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdProducts.Columns)
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
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        public void udfnLvGroup()
        {
            try
            {
                //if (txtMappingGroup.Text.Trim() != "")
                //{
                //    ListViewItem selectedItem = lvMappingGroup.SelectedItems[0];
                //    txtMappingGroup.Text = selectedItem.SubItems[0].Text;
                //    varGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                //    lvMappingGroup.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvSubGroup()
        {
            //try
            //{
            //    if (txtMappingSubGroup.Text.Trim() != "")
            //    {
            //        ListViewItem selectedItem = lvMappingSubGroup.SelectedItems[0];
            //        txtMappingSubGroup.Text = selectedItem.SubItems[0].Text;
            //        varSubGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
            //        lvMappingSubGroup.Visible = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
         


        private void txtMappingSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterGroup.Visible = false;
                txtMappingSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMappingSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMappingSubGroup.BackColor = Color.White;
                if (txtMappingSubGroup.Text.Trim() == "") { varSubGroupId = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMappingSubGroup_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                varUpDownKeySubgroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSubgroup.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSubgroup.Visible == false)
                {
                    txtBrand.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSubgroup.Focus();
                }
                if (DGV_FilterSubgroup.CurrentCell == null && DGV_FilterSubgroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSubgroup.Focus();
                    int RowIndex = DGV_FilterSubgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSubgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySubgroup = 1;
                    }
                    else
                    {
                        varUpDownKeySubgroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtMappingSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }
                            txtMappingSubGroup.Focus();
                            txtMappingSubGroup.SelectionStart = txtMappingSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtMappingSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtMappingSubGroup.Focus();
                            txtMappingSubGroup.SelectionStart = txtMappingSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSubgroup.Rows.Count > 0)
                                {
                                    varUpDownKeySubgroup = 1;
                                    udfnSubGroupAutocomplete();
                                    DGV_FilterSubgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtMappingSubGroup.Focus();
                    //txtMappingSubGroup.SelectionStart = txtMappingSubGroup.Text.Length;
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
                        txtBrand.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMappingSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeySubgroup == 0)
                {
                    if (txtMappingGroup.Text.Trim() == "")
                    {
                        varSubGroupId = 0;
                    }
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtMappingSubGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(varGroupId), 0, txtMappingSubGroup.Text, 0, 0, 0, 0, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterSubgroup.Visible = true;
                                    DGV_FilterSubgroup.DataSource = objDs.Tables[0];
                                    DGV_FilterSubgroup.Columns["PRSGID"].Visible = false;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].HeaderText = "Subgroup English Name";
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].HeaderText = "Subgroup Tamil Name";
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].Width = 150;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].Width = 200;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].DisplayIndex = 0;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterSubgroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSubgroup.Visible = false;
                                    DGV_FilterSubgroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterSubgroup.Visible = false;
                                DGV_FilterSubgroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterSubgroup.Visible = false;
                            DGV_FilterSubgroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterSubgroup.Visible = false;
                        DGV_FilterSubgroup.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvMappingSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvSubGroup();
                txtBrand.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvMappingSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvSubGroup();
                    txtBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyBrand == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtBrand.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnBrandList(6, "0", 0, 0, 0, txtBrand.Text.Trim(), 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterBrand.Visible = true;
                                    DGV_FilterBrand.DataSource = objDs.Tables[0];
                                    DGV_FilterBrand.Columns["BDID"].Visible = false;
                                    DGV_FilterBrand.Columns["BD_EName"].HeaderText = "Brand English Name";
                                    DGV_FilterBrand.Columns["BD_TName"].HeaderText = "Brand Tamil Name";
                                    DGV_FilterBrand.Columns["BD_EName"].Width = 180;
                                    DGV_FilterBrand.Columns["BD_TName"].Width = 200;
                                    DGV_FilterBrand.Columns["BD_EName"].DisplayIndex = 0;
                                    DGV_FilterBrand.Columns["BD_TName"].DisplayIndex = 1;
                                    DGV_FilterBrand.Columns["BD_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterBrand.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterBrand.Visible = false;
                                    DGV_FilterBrand.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterBrand.Visible = false;
                                DGV_FilterBrand.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterBrand.Visible = false;
                            DGV_FilterBrand.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterBrand.Visible = false;
                        DGV_FilterBrand.DataSource = null;
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

        private void txtBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSubgroup.Visible = false;
                txtBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBrand_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBrand.BackColor = Color.White;
                if (txtBrand.Text.Trim() == "") { varBrandId = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                varUpDownKeyBrand = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterBrand.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterBrand.Visible == false)
                {
                    btnMappingView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterBrand.Focus();
                }
                if (DGV_FilterBrand.CurrentCell == null && DGV_FilterBrand.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterBrand.Focus();
                    int RowIndex = DGV_FilterBrand.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterBrand.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyBrand = 1;
                    }
                    else
                    {
                        varUpDownKeyBrand = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterBrand.CurrentCell = DGV_FilterBrand.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtBrand.Text = DGV_FilterBrand.Rows[RowIndex].Cells["BD_EName"].Value.ToString();
                            }
                            txtBrand.Focus();
                            txtBrand.SelectionStart = txtBrand.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterBrand.Rows.Count) DGV_FilterBrand.CurrentCell = DGV_FilterBrand.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterBrand.Rows.Count))
                            {
                                txtBrand.Text = DGV_FilterBrand.Rows[RowIndex].Cells["BD_EName"].Value.ToString();
                            }

                            txtBrand.Focus();
                            txtBrand.SelectionStart = txtBrand.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterBrand.Rows.Count > 0)
                                {
                                    varUpDownKeyBrand = 1;
                                    udfnBrandAutocomplete();
                                    DGV_FilterBrand.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtBrand.Focus();
                    //txtBrand.SelectionStart = txtBrand.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtBrand.SelectedText = true;
                        TextBox txtBrand = sender as TextBox;
                        txtBrand.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnMappingView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvBrand();
                    btnMappingView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvBrand_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvBrand();
                btnMappingView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public void udfnLvBrand()
        {
           
        }

        private void btnMappingView_Click(object sender, EventArgs e)
        {
            try
            {
                errSpl.Clear();
                btnMappingView.Enabled = false;
                if (txtMappingGroup.Text != "")
                {
                    DataSet objDgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDgroup = objDserv.udfnGroupList(9, 0, 0, txtMappingGroup.Text.Trim(), 0);
                    objDserv.CloseConnection();
                    if (objDgroup != null)
                    {
                        if (objDgroup.Tables.Count > 0)
                        {
                            if (objDgroup.Tables[0].Rows.Count > 0)
                            {
                                varGroupId = Convert.ToInt32(objDgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (txtMappingSubGroup.Text != "")
                {
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDServ = new SPDataService();
                    objDssubgroup = objDServ.udfnSubGroupList(11, 0, "", varGroupId, 0, txtMappingSubGroup.Text.Trim(), 0, 0, 0, 0, 0);
                    objDServ.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varSubGroupId = Convert.ToInt32(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (txtBrand.Text != "")
                {
                    DataSet objDsBrand = new DataSet();
                    SPDataService objDS = new SPDataService();
                    objDsBrand = objDS.udfnBrandList(8, "", varGroupId, varSubGroupId, 0, txtBrand.Text.Trim(), 0);
                    objDS.CloseConnection();
                    if (objDsBrand != null)
                    {
                        if (objDsBrand.Tables.Count > 0)
                        {
                            if (objDsBrand.Tables[0].Rows.Count > 0)
                            {
                                varBrandId = Convert.ToInt32(objDsBrand.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }

                //if (varBrandId == 0 && varSubGroupId == 0 && varGroupId == 0)
                //{

                //    SPDataService objDataService = new SPDataService();
                //    string varMessage = objDataService.udfnGetMessages(151);
                //    objDataService.CloseConnection();
                //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnMappingView.Enabled = true;
                btnMappingView.Focus();
            }
        }

        private void txtSearchByProduct1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdProducts.DataSource as DataTable).DefaultView.RowFilter = "([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%'";


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalProducts.Text = grdProducts.Rows.Count.ToString();
            }
        }


        private void DGV_SearchGrid1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
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

        private void grdFinalSupplierMapping_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

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

        public void udfnGetProductCount(int varProId)
        {
            try
            {
                int varProductCount = 0; string varRemoveProduct = "";
                for (int i = 0; i < grdProducts.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdProducts.Rows[i].Cells[0].Value) == true)
                    {
                        varProductCount++;
                    }
                }
                if (Convert.ToBoolean(grdProducts.SelectedRows[0].Cells[0].Value) == true)
                {
                    DataRow dr = objdtProducts.Select("PRODUCTID=" + varProId).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = true;
                        objdtProducts.AcceptChanges();
                    }
                }
                else
                {
                    DataRow dr = objdtProducts.Select("PRODUCTID=" + varProId).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = false;
                        objdtProducts.AcceptChanges();
                    }
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
                var vScrollbar = grdProducts.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = grdCityList.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        grdCityList.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            grdCityList.Rows[rowIndex].Cells[i].Value = "";
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




        private void udfnsearchgridHead()
        {

        }

        private void btnMappingClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnClose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClose()
        {
            try
            { 
                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
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

        public void udfnInitProduct()
        {
            try
            {
                objdtProducts = new DataTable();
                objdtProducts.Columns.Add("S.No.", typeof(string));
                objdtProducts.Columns.Add("P.I Code", typeof(string));
                objdtProducts.Columns.Add("Product Name in Tamil", typeof(string));
                objdtProducts.Columns.Add("Unit", typeof(string));
                objdtProducts.Columns.Add("Last Rate", typeof(decimal));
                objdtProducts.Columns.Add("Live Rate", typeof(decimal));
                objdtProducts.Columns.Add("Parent Rate", typeof(decimal));
                objdtProducts.Columns.Add("UPP", typeof(decimal));
                objdtProducts.Columns.Add("PRODUCTID", typeof(int));

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            try
            {  
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return; 
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
                if (grdProducts.CurrentCell.OwningColumn.Name == "Last Rate" || grdProducts.CurrentCell.OwningColumn.Name == "Live Rate")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                    {
                        e.Handled = true;
                    }
                    //only allow one decimal point
                    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    //if ((e.KeyChar == '.'))
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

        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int varDecimal = 2;
                if (grdProducts.CurrentCell.OwningColumn.Name == "Live Rate" || grdProducts.CurrentCell.OwningColumn.Name == "Last Rate")
                {
                    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    //{
                    //    e.Handled = true;  // Disallow the character
                    //}
                    TextBox textBox = (TextBox)sender;
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                        {
                            e.Handled = true;
                        }
                    }
                    if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
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

        private void grdProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                var col = grdProducts.Columns[e.ColumnIndex];

                // Only for Live / New columns
                if (col.HeaderText.Trim() == "New")
                {
                    if (e.Value != null && e.Value.ToString() == "-1")
                    {
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.LightGray;
                        e.Value = "";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.PaleGreen;
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex) 
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnMappingsave_Click(object sender, EventArgs e)
        {
            try
            { 
                    udfnSave();  
                //if (saveFlag == 0)
                //{
                //    SPDataService objDataService = new SPDataService();
                //    string varMessage = objDataService.udfnGetMessages(151);
                //    objDataService.CloseConnection();
                //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //else
                //{ 
                //    //udfnSave(); 
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

         


        private void DGV_FilterGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            txtMappingGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();

                            txtMappingGroup.Focus();
                            txtMappingGroup.SelectionStart = txtMappingGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtMappingGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtMappingGroup.Focus();
                            txtMappingGroup.SelectionStart = txtMappingGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyGroup = 1;
                                    udfnGroupAutocomplete();
                                    DGV_FilterGroup.Visible = false;
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
                        txtMappingSubGroup.Focus();
                    }
                }
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


                //DataTable saveobjDtProducts = objdtProducts.DefaultView.ToTable(false, "PRODUCTID", "Last Rate", "Live Rate");
                DataTable rowTable = (DataTable)grdProducts.DataSource; 

                DataTable saveobjDtProducts = ConvertColumnToRowFast(rowTable);

                string varoriginator = ""; int varType = 0; 
                varoriginator = "Rate Category Min Qty Bulk update"; 


                MR_Product obj = new MR_Product();
                obj.paraViewType = 4;  
                obj.paraOriginator = varoriginator;
                obj.paraBulkMinqty = saveobjDtProducts; 

                SPDataService objspservice = new SPDataService();  
                string varResult = objspservice.udfnRateCategory(obj);
                objspservice.CloseConnection(); 
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    udfnClear();
                    Varupdateflag = 1;
                    grdProducts.DataSource = null;
                    grdHeaderview.DataSource = null;
                    this.ActiveControl = txtMappingGroup;
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    //udfnClose();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnMappingsave.Enabled = true;
                    btnMappingsave.Focus();
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
            finally
            {
                btnMappingsave.Enabled = true;
                lblTotalProducts.Text = Convert.ToString(grdProducts.Rows.Count);
            }
        }

          

        private void DGV_FilterSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSubgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSubgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySubgroup = 1;
                    }
                    else
                    {
                        varUpDownKeySubgroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            txtMappingSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();

                            txtMappingSubGroup.Focus();
                            txtMappingSubGroup.SelectionStart = txtMappingSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtMappingSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtMappingSubGroup.Focus();
                            txtMappingSubGroup.SelectionStart = txtMappingSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSubgroup.Rows.Count > 0)
                                {
                                    varUpDownKeySubgroup = 1;
                                    udfnSubGroupAutocomplete();
                                    DGV_FilterSubgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtBrand.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Spl_Products_Bulk_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    //MainForm objMainForm = new MainForm();
                    //objMainForm.udfnCloseChildForms();
                    //MainForm.objStart = new DEF_Start();
                    //MainForm.objStart.MdiParent = this.ParentForm;
                    //MainForm.objStart.Show();
                    //this.Close();
                    udfnClose();
                }
            }
           catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdProducts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                var cell = grdProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value != null && cell.Value.ToString() == "-1")
                {
                    e.Cancel = true; // disable edit
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterBrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyBrand = 1;
                udfnBrandAutocomplete();
                btnMappingView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterBrand.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterBrand.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyBrand = 1;
                    }
                    else
                    {
                        varUpDownKeyBrand = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterBrand.CurrentCell = DGV_FilterBrand.Rows[RowIndex].Cells[ClmIndex];

                            txtBrand.Text = DGV_FilterBrand.SelectedRows[0].Cells["BD_EName"].Value.ToString();

                            txtBrand.Focus();
                            txtBrand.SelectionStart = txtBrand.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterBrand.Rows.Count) DGV_FilterBrand.CurrentCell = DGV_FilterBrand.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterBrand.Rows.Count))
                            {
                                txtBrand.Text = DGV_FilterBrand.Rows[RowIndex].Cells["BD_EName"].Value.ToString();
                            }

                            txtBrand.Focus();
                            txtBrand.SelectionStart = txtBrand.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterBrand.Rows.Count > 0)
                                {
                                    varUpDownKeyBrand = 1;
                                    udfnBrandAutocomplete();
                                    DGV_FilterBrand.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtBrand = sender as TextBox;
                        txtBrand.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnMappingView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyGroup = 1;
                udfnGroupAutocomplete();
                txtMappingSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSubgroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySubgroup = 1;
                udfnSubGroupAutocomplete();
                txtBrand.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnClear()
        {
            try
            {
                objdtProducts.Rows.Clear();
                objdtProductsMapping.Rows.Clear();
                grdProducts.DataSource = null;
                txtMappingGroup.Text = "";
                txtMappingSubGroup.Text = "";
                txtBrand.Text = "";
                varGroupId = 0;
                varSubGroupId = 0;
                varBrandId = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        DataTable ConvertColumnToRowFast(DataTable sourceTable)
        {
            DataTable result = new DataTable();

            result.Columns.Add("PRID", typeof(int));
            result.Columns.Add("Type", typeof(string));
            result.Columns.Add("QTY", typeof(float));

            result.BeginLoadData();

            int colCount = sourceTable.Columns.Count;

            foreach (DataRow row in sourceTable.Rows)
            {
                int prid = (int)row["PRODUCTID"];

                for (int i = 1; i < colCount; i++)
                { 

                    if (sourceTable.Columns[i].ColumnName != "S.No." &&
                        sourceTable.Columns[i].ColumnName != "P.I Code" &&
                        sourceTable.Columns[i].ColumnName != "Unit" &&
                        sourceTable.Columns[i].ColumnName != "Product Name in Tamil" &&
                        sourceTable.Columns[i].ColumnName != "PRODUCTID"
                        ) {

                        string colName = sourceTable.Columns[i].ColumnName;

                        // split by both '-' and '_'
                        string[] parts = colName.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length == 2)
                        {
                            string leftPart = parts[0].Trim();   // pp / rr
                            string rightPart = parts[1].Trim();   // old / new

                            if (rightPart == "New")
                            {

                                DataRow newRow = result.NewRow();
                                newRow[0] = prid;
                                newRow[1] = leftPart;
                                newRow[2] = row[i] == DBNull.Value ? 0 : (row[i] == "" ? 0 : row[i]);
                                result.Rows.Add(newRow);
                            } 
                        }
                         
                    }
                }
            }

            result.EndLoadData();
            return result;
        }

        public void udfnGroupAutocomplete()
        {
            try
            {
                if (txtMappingGroup.Text.Trim() != "")
                {
                    varGroupId = Convert.ToInt32(DGV_FilterGroup.SelectedRows[0].Cells["PRGID"].Value.ToString());
                    txtMappingGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtMappingSubGroup.Focus();
            }
        }
        public void udfnSubGroupAutocomplete()
        {
            try
            {
                if (txtMappingSubGroup.Text.Trim() != "")
                {
                    varSubGroupId = Convert.ToInt32(DGV_FilterSubgroup.SelectedRows[0].Cells["PRSGID"].Value.ToString());
                    txtMappingSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtBrand.Focus();
            }
        }
        public void udfnBrandAutocomplete()
        {
            try
            {
                if (txtBrand.Text.Trim() != "")
                {
                    txtBrand.Text = DGV_FilterBrand.SelectedRows[0].Cells["BD_EName"].Value.ToString();
                    varBrandId = Convert.ToInt32(DGV_FilterBrand.SelectedRows[0].Cells["BDID"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnMappingView.Focus();
            }
        }
    }
}
