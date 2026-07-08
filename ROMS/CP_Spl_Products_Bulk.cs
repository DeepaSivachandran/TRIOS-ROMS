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
    // Name  : venkat    Date : 27/11/2025
    public partial class CP_Spl_Products_Bulk : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public int varFormFlag = 0;

        public int varGroupId = 0, grid_flag = 0;
        public int varSubGroupId = 0;
        public int varBrandId = 0;
        public int varViewType = 0;
        public int varStatusId = 0, varErrorflag = 0, Varupdateflag = 0;
        public int SearchFlag = 0;

        Boolean BlnSearchImageYN = false;

        DataSet objDSHSN = new DataSet();
        DataSet objDSSubGroup = new DataSet();
        DataSet objDSGroup = new DataSet();
        DataSet objDSBrand = new DataSet();
        DataSet objDSSubgroupBrand = new DataSet();
        DataSet objDSUnit = new DataSet();
        DataSet objDSLocation = new DataSet();
        DataSet objDSRack = new DataSet();
        DataSet objDSShelfLifeType = new DataSet();
        DataSet objDSQTYUnit = new DataSet();
        DataSet objDSProductCategory = new DataSet();
        DataSet objDSRMPRO = new DataSet();
        DataSet objDSBatchNo = new DataSet();
        DataSet objDSBatchNoGeneration = new DataSet();

        DataTable objdtProducts = new DataTable();
        DataTable objdtProductsMapping = new DataTable();
        private ToolTip tpFiledtype = new ToolTip();

        private void CP_Spl_Products_Bulk_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 50507;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0) AND MSTID<>0 OR MST_TransactionID=136", "MST_DisplayText,MSTID,MST_ShortName", cmbFiledtype, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbFiledtype.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        DataSet objDSProduct = new DataSet();
        public int pbMenuFlag = 0;

        public CP_Spl_Products_Bulk()
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
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdProducts.Width > grdProducts.HorizontalScrollingOffset && grdProducts.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdProducts);
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
                lvMappingSubGroup.Visible = false;
                lvBrand.Visible = false;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvMappingGroup.Items.Count == 0 || txtMappingGroup.Text == "")
                    {
                        txtMappingGroup.Focus();
                        lvMappingGroup.Visible = false;
                    }
                    else
                    {
                        lvMappingGroup.Focus();
                    }
                    if (lvMappingGroup.Items.Count > 0)
                    {
                        lvMappingGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtMappingSubGroup.Focus();
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
                lvMappingGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtMappingGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(8, 0, 0, txtMappingGroup.Text.Trim(), 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row); 
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvMappingGroup.Items.Add(objList);
                                }
                                lvMappingGroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvMappingGroup.Visible = false;
                    lvMappingGroup.Items.Clear();
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

                lblNoRecordsFound.Visible = false;
                grdProducts.DataSource = null;
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 86;
                objMR_Product.paraGroup = varGroupId;
                objMR_Product.paraSubgroup = varSubGroupId;
                objMR_Product.paraBrandID = varBrandId;
                if (Convert.ToInt32(cmbFiledtype.SelectedValue) == 437)
                {
                    //// Priority
                    objMR_Product.paraFlag = 1;
                }
                else if (Convert.ToInt32(cmbFiledtype.SelectedValue) == 438)
                {
                    ////Special
                    objMR_Product.paraFlag = 2;
                }
                else if (Convert.ToInt32(cmbFiledtype.SelectedValue) == 439)
                {
                    ////focus
                    objMR_Product.paraFlag = 3;
                }
                else if (Convert.ToInt32(cmbFiledtype.SelectedValue) == 440)
                {
                    ////own
                    objMR_Product.paraFlag = 4;
                }
                DataSet objDs = new DataSet();
                objdtProducts = null;

                udfnInitProduct();
                SPDataService objspservice = new SPDataService();

                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        objdtProducts.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in Tamil"]
                            , objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["Brand"], objDs.Tables[0].Rows[i]["Product SubGroup"], objDs.Tables[0].Rows[i]["Product Group"], Convert.ToInt32(objDs.Tables[0].Rows[i]["GROUPID"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["SUBGROUPID"]),
                            Convert.ToInt32(objDs.Tables[0].Rows[i]["PRODUCTID"]), objDs.Tables[0].Rows[i]["Product Name in English"]);
                    }

                    if (grdFinalSupplierMapping.Rows.Count != 0)
                    {
                        ///---- get the unique id
                        var ids = new HashSet<string>(
                            objdtProductsMapping.AsEnumerable()
                            .Select(x => x["PRODUCTID"].ToString())
                        );

                        ///---- filter the data from objdttable
                        var filteredRows = objdtProducts.AsEnumerable()
                            .Where(x => !ids.Contains(x["PRODUCTID"].ToString()));

                        objdtProducts = filteredRows.CopyToDataTable();

                    }

                    grdProducts.DataSource = objdtProducts;
                    //  grdProducts.Columns[0].Frozen = true;
                    grdProducts.Columns[0].HeaderText = "";
                    grdProducts.Columns[0].Width = 30;
                    grdProducts.Columns["S.No."].Width = 50;
                    grdProducts.Columns["P.I Code"].Width = 100;
                    grdProducts.Columns["Product Name in Tamil"].Width = 220;
                    grdProducts.Columns["Unit"].Width = 60;
                    grdProducts.Columns["Product SubGroup"].Width = 170;
                    grdProducts.Columns["GROUPID"].Visible = false;
                    grdProducts.Columns["SUBGROUPID"].Visible = false;
                    grdProducts.Columns["PRODUCTID"].Visible = false;
                    grdProducts.Columns["Product Name in English"].Visible = false;
                    grdProducts.Columns["S.No."].Visible = false;

                    grdProducts.Columns["S.No."].ReadOnly = true;
                    grdProducts.Columns["P.I Code"].ReadOnly = true;
                    grdProducts.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdProducts.Columns["Unit"].ReadOnly = true;
                    grdProducts.Columns["Product SubGroup"].ReadOnly = true;
                    grdProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
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
                if (objDs.Tables[1].Rows.Count > 0)
                {
                    if (grdFinalSupplierMapping.Rows.Count == 0)
                    {
                        objdtProductsMapping = null;
                        udfnInitMappedProduct();
                        grdFinalSupplierMapping.DataSource = null;
                    }

                    int varcount = 1;

                    if (grdFinalSupplierMapping.Rows.Count == 0)
                    {
                        for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                        {
                            objdtProductsMapping.Rows.Add(false, Convert.ToInt32(objdtProductsMapping.Rows.Count) + 1, objDs.Tables[1].Rows[i]["P.I Code"].ToString().Replace("''", "'"), objDs.Tables[1].Rows[i]["Product Name in Tamil"].ToString().Replace("''", "'")
                            , objDs.Tables[1].Rows[i]["Unit"].ToString().Replace("''", "'"), objDs.Tables[1].Rows[i]["Brand"].ToString().Replace("''", "'"), objDs.Tables[1].Rows[i]["Product SubGroup"].ToString().Replace("''", "'"),
                           objDs.Tables[1].Rows[i]["Product Group"].ToString().Replace("''", "'"),
                            objDs.Tables[1].Rows[i]["GROUPID"].ToString().Replace("''", "'"), objDs.Tables[1].Rows[i]["SUBGROUPID"].ToString().Replace("''", "'"),
                            objDs.Tables[1].Rows[i]["PRODUCTID"].ToString().Replace("''", "'"), objDs.Tables[1].Rows[i]["Product Name in English"].ToString().Replace("''", "'"),
                             Convert.ToInt32(objDs.Tables[1].Rows[i]["Mapped Flag"].ToString())
                            );
                        }
                    }
                    grdFinalSupplierMapping.DataSource = objdtProductsMapping;
                    //grdFinalSupplierMapping.Columns[0].Frozen = true;
                    grdFinalSupplierMapping.Columns[0].HeaderText = "";
                    grdFinalSupplierMapping.Columns[0].Width = 30;
                    grdFinalSupplierMapping.Columns["S.No."].Width = 50;
                    grdFinalSupplierMapping.Columns["P.I Code"].Width = 100;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].Width = 220;
                    grdFinalSupplierMapping.Columns["Unit"].Width = 100;
                    grdFinalSupplierMapping.Columns["Product SubGroup"].Width = 120;
                    grdFinalSupplierMapping.Columns["GROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["SUBGROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["PRODUCTID"].Visible = false;
                    grdFinalSupplierMapping.Columns["Product Name in English"].Visible = false;

                    grdFinalSupplierMapping.Columns["Mapped Flag"].Visible = false;
                    grdFinalSupplierMapping.Columns["S.No."].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Unit"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product SubGroup"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);

                    udfnGridRemove();
                    btnMappingsave.Text = "Update";
                }
                else
                {
                    //lblNoRecordsFound.Visible = true;
                    objdtProductsMapping.Rows.Clear();
                    objdtProductsMapping = null;
                    //objdtProducts.AcceptChanges();
                    grdFinalSupplierMapping.DataSource = objdtProductsMapping;
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
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
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
                if (txtMappingGroup.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvMappingGroup.SelectedItems[0];
                    txtMappingGroup.Text = selectedItem.SubItems[0].Text;
                    varGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvMappingGroup.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvSubGroup()
        {
            try
            {
                if (txtMappingSubGroup.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvMappingSubGroup.SelectedItems[0];
                    txtMappingSubGroup.Text = selectedItem.SubItems[0].Text;
                    varSubGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvMappingSubGroup.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvMappingGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvGroup();
                    txtMappingGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvMappingGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvGroup();
                txtMappingGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void txtMappingSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvMappingGroup.Visible = false;
                lvBrand.Visible = false;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvMappingSubGroup.Items.Count == 0 || txtMappingSubGroup.Text == "")
                    {
                        txtMappingSubGroup.Focus();
                        lvMappingSubGroup.Visible = false;
                    }
                    else
                    {
                        lvMappingSubGroup.Focus();
                    }
                    if (lvMappingSubGroup.Items.Count > 0)
                    {
                        lvMappingSubGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtBrand.Focus();
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
                lvMappingSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtMappingSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(8, 0, "", varGroupId, 0, txtMappingSubGroup.Text.Trim(), 0, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {

                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvMappingSubGroup.Items.Add(objList);
                                }
                                lvMappingSubGroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvMappingSubGroup.Visible = false;
                    lvMappingSubGroup.Items.Clear();
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
                lvBrand.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtBrand.Text.Length > 0)
                {
                    objDs = objspdservice.udfnBrandList(7, "", varGroupId, varSubGroupId, 0, txtBrand.Text.Trim(), 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["BD_EName"].ToString(), objDs.Tables[0].Rows[i]["BD_TName"].ToString(), objDs.Tables[0].Rows[i]["BDID"].ToString(), };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvBrand.Items.Add(objList);
                                }
                                lvBrand.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvBrand.Visible = false;
                    lvBrand.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                lvMappingSubGroup.Visible = false;
                lvMappingGroup.Visible = false;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvBrand.Items.Count == 0 || txtBrand.Text == "")
                    {
                        txtBrand.Focus();
                        lvBrand.Visible = false;
                    }
                    else
                    {
                        lvBrand.Focus();
                    }
                    if (lvBrand.Items.Count > 0)
                    {
                        lvBrand.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbStatus.Focus();
                    btnMappingView.Focus();
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
            try
            {
                if (txtBrand.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvBrand.SelectedItems[0];
                    txtBrand.Text = selectedItem.SubItems[0].Text;
                    varBrandId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvBrand.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnMappingView_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbFiledtype.SelectedValue) == -1)
                {
                    errSpl.SetError(cmbFiledtype, "Please select field type");
                    cmbFiledtype.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpFiledtype.ShowAlways = true;
                    tpFiledtype.Show("Please select field type.", cmbFiledtype, 5000);
                    return;
                }
                errSpl.Clear();
                cmbFiledtype.BackColor = Color.White;
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

        private void DGV_SearchGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdFinalSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid1, grdFinalSupplierMapping);
                objDser.CloseConnection();
                grdFinalSupplierMapping.HorizontalScrollingOffset = DGV_SearchGrid1.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            finally
            {
                //SearchFlag = 1; 
            }
        }

        private void DGV_SearchGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGrid1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }
        private void DGV_SearchGrid1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                DGV_SearchGrid1.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
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

        private void DGV_SearchGrid1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdFinalSupplierMapping.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdFinalSupplierMapping.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn
                            &&
                            grdFinalSupplierMapping.SortOrder == SortOrder.Ascending
                            )
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
                    grdFinalSupplierMapping.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGrid1.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGrid1.HorizontalScrollingOffset = grdFinalSupplierMapping.HorizontalScrollingOffset;
                    DGV_SearchGrid1.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdFinalSupplierMapping.ColumnCount > 0)
                {
                    grdFinalSupplierMapping.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid1.HorizontalScrollingOffset = grdFinalSupplierMapping.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                txtmappingproductsearch2.Text = "";
                if (DGV_SearchGrid1.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdFinalSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid1, grdFinalSupplierMapping);
                objDser.CloseConnection();
                grdFinalSupplierMapping.HorizontalScrollingOffset = DGV_SearchGrid1.HorizontalScrollingOffset;
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdFinalSupplierMapping.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid1, grdFinalSupplierMapping);
                objDser.CloseConnection();
                grdFinalSupplierMapping.HorizontalScrollingOffset = DGV_SearchGrid1.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdFinalSupplierMapping.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid1.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdFinalSupplierMapping.Width > grdFinalSupplierMapping.HorizontalScrollingOffset && grdFinalSupplierMapping.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid1.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid1.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void grdFinalSupplierMapping_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdFinalSupplierMapping.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid1.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdFinalSupplierMapping.Width > grdFinalSupplierMapping.HorizontalScrollingOffset && grdFinalSupplierMapping.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid1.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid1.Invalidate();
                udfnScrollVisible(DGV_SearchGrid1, grdFinalSupplierMapping);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdFinalSupplierMapping_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdFinalSupplierMapping.IsCurrentCellDirty)
                {
                    grdFinalSupplierMapping.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void grdFinalSupplierMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdFinalSupplierMapping.Columns[e.ColumnIndex].Name)
                    {
                        case "clmMappingRemove":

                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                objdtProducts.Rows.Add(false, "0", grdFinalSupplierMapping.SelectedRows[0].Cells["P.I Code"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["Product Name in Tamil"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["Unit"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["Product SubGroup"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["GROUPID"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["SUBGROUPID"].Value,
                                grdFinalSupplierMapping.SelectedRows[0].Cells["PRODUCTID"].Value, "0");
                                grdFinalSupplierMapping.Rows.RemoveAt(this.grdFinalSupplierMapping.SelectedRows[0].Index);
                                for (int i = 0; i < grdFinalSupplierMapping.RowCount; i++)
                                {
                                    grdFinalSupplierMapping.Rows[i].Cells["S.No."].Value = i + 1;
                                }
                                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
                                objdtProducts.AcceptChanges();
                                grdProducts.DataSource = objdtProducts;
                                // grdProducts.Columns[0].Frozen = true;
                                grdProducts.Columns[0].HeaderText = "";
                                grdProducts.Columns[0].Width = 30;
                                grdProducts.Columns["S.No."].Width = 50;
                                grdProducts.Columns["P.I Code"].Width = 100;
                                grdProducts.Columns["Product Name in Tamil"].Width = 220;
                                grdProducts.Columns["Unit"].Width = 100;
                                grdProducts.Columns["Product SubGroup"].Width = 170;
                                grdProducts.Columns["GROUPID"].Visible = false;
                                grdProducts.Columns["SUBGROUPID"].Visible = false;
                                grdProducts.Columns["PRODUCTID"].Visible = false;
                                grdProducts.Columns["Product Name in English"].Visible = false;
                                grdProducts.Columns["S.No."].Visible = false;


                                grdProducts.Columns["S.No."].ReadOnly = true;
                                grdProducts.Columns["P.I Code"].ReadOnly = true;
                                grdProducts.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdProducts.Columns["Unit"].ReadOnly = true;
                                grdProducts.Columns["Product SubGroup"].ReadOnly = true;
                                grdProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            }
                            break;
                    }
                }
                int vscroll = grdFinalSupplierMapping.FirstDisplayedScrollingRowIndex;
                int hscroll = grdFinalSupplierMapping.FirstDisplayedScrollingColumnIndex;
                int varPRID = Convert.ToInt16(grdFinalSupplierMapping.SelectedRows[0].Cells["PRODUCTID"].Value);
                udfnGetMappedProductCount(varPRID);
                grdFinalSupplierMapping.FirstDisplayedScrollingRowIndex = vscroll;
                grdFinalSupplierMapping.FirstDisplayedScrollingColumnIndex = hscroll;
                // udfnGetProductCount(0);       
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (grdProducts.RowCount > 0)
                {
                    this.grdProducts.Sort(this.grdProducts.Columns[2], ListSortDirection.Ascending);
                }
                grdProducts.ClearSelection();
            }
        }
        private void grdFinalSupplierMapping_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                for (int i = 0; i < grdFinalSupplierMapping.RowCount; i++)
                {
                    if (Convert.ToString(grdFinalSupplierMapping.Rows[i].Cells["Mapped Flag"].Value) != "0")
                    {
                        grdFinalSupplierMapping.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                grdFinalSupplierMapping.ClearSelection();
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
                if (varProductCount > 0)
                {
                    btnRemove.Enabled = false;
                    BtnaddMove.Enabled = true;
                    if (grdFinalSupplierMapping.RowCount > 0)
                    {
                        grdFinalSupplierMapping.Columns[0].ReadOnly = true;
                    }
                }
                else
                {
                    btnRemove.Enabled = true;
                    if (grdFinalSupplierMapping.RowCount > 0)
                    {
                        grdFinalSupplierMapping.Columns[0].ReadOnly = false;
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

        public void udfnGetMappedProductCount(int varPRID)
        {
            try
            {
                int varMappedProductCount = 0;
                for (int i = 0; i < grdFinalSupplierMapping.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdFinalSupplierMapping.Rows[i].Cells[0].Value) == true)
                    {
                        varMappedProductCount++;
                    }
                }
                if (Convert.ToBoolean(grdFinalSupplierMapping.SelectedRows[0].Cells[0].Value) == true)
                {
                    DataRow dr = objdtProductsMapping.Select("PRODUCTID=" + varPRID).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = true;
                        objdtProductsMapping.AcceptChanges();
                    }
                }
                else
                {
                    DataRow dr = objdtProductsMapping.Select("PRODUCTID=" + varPRID).FirstOrDefault();
                    if (dr != null)
                    {
                        dr[0] = false;
                        objdtProductsMapping.AcceptChanges();
                    }
                }
                if (varMappedProductCount > 0)
                {
                    BtnaddMove.Enabled = false;
                    btnRemove.Enabled = true;
                    grdProducts.Columns[0].ReadOnly = true;
                }
                else
                {
                    btnRemove.Enabled = false;
                    grdProducts.Columns[0].ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnScrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdFinalSupplierMapping.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGrid1.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid1.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGrid1.Rows[rowIndex].Cells[i].Value = "";
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

        private void txtmappingproductsearch2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    (grdFinalSupplierMapping.DataSource as DataTable).DefaultView.RowFilter = "([P.I Code]) LIKE '%" + txtmappingproductsearch2.Text + "%'";
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
                finally
                {
                    lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnaddMove_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;   // show loader
                picloader2.Visible = true;

                picLoader.BringToFront(); // show loader
                picloader2.BringToFront(); // show loader 

                udfnProductAdd();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;  // hide loader 
                picloader2.Visible = false;
                lblTotalProducts.Text = grdProducts.Rows.Count.ToString();
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();



            }
        }




        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;   // show loader
                picloader2.Visible = true;
                udfnProductRemove(sender, e);

                picLoader.Visible = false;  // hide loader 
                picloader2.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                udfnSno();


            }
        }


        public void udfnProductAdd()
        {
            try
            {
                string varRemoveProduct = "", varAddProduct = "", varGridRemove = "";
                //for (int i = 1; i < DGV_SearchGrid.ColumnCount; i++)
                //{
                //    DGV_SearchGrid.Rows[0].Cells[i].Value = "";
                //}
                //DGV_SearchGrid_CurrentCellDirtyStateChanged(sender, e);

                if (objdtProductsMapping == null || objdtProductsMapping.Columns.Count == 0)
                {
                    udfnInitMappedProduct();
                }
                if (objdtProducts.Rows.Count > 0)
                {
                    for (int i = 0; i < objdtProducts.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(objdtProducts.Rows[i][0]) == true)
                        {
                            int varFlag = 0, varcount = 1;
                            for (int j = 0; j < objdtProductsMapping.Rows.Count; j++)
                            {
                                varRemoveProduct = Convert.ToString(objdtProducts.Rows[i]["PRODUCTID"]);
                                if (varRemoveProduct == Convert.ToString(objdtProductsMapping.Rows[j]["PRODUCTID"]))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                objdtProductsMapping.Rows.Add(false, Convert.ToInt32(objdtProductsMapping.Rows.Count) + 1, objdtProducts.Rows[i]["P.I Code"], objdtProducts.Rows[i]["Product Name in Tamil"], objdtProducts.Rows[i]["Unit"], objdtProducts.Rows[i]["Brand"], objdtProducts.Rows[i]["Product SubGroup"], objdtProducts.Rows[i]["Product Group"],
                                objdtProducts.Rows[i]["GROUPID"], objdtProducts.Rows[i]["SUBGROUPID"], objdtProducts.Rows[i]["PRODUCTID"], objdtProducts.Rows[i]["Product Name in English"], 1);

                            }
                        }
                        else
                        {
                            for (int j = 0; j < objdtProductsMapping.Rows.Count; j++)
                            {
                                varAddProduct = Convert.ToString(objdtProducts.Rows[i]["PRODUCTID"]);
                                if (varAddProduct == Convert.ToString(objdtProductsMapping.Rows[j]["PRODUCTID"]))
                                {
                                    objdtProductsMapping.Rows[j].Delete();
                                    objdtProductsMapping.AcceptChanges();
                                }
                            }
                        }
                    }
                    grdFinalSupplierMapping.DataSource = null;
                    grdFinalSupplierMapping.DataSource = objdtProductsMapping;
                    //  grdFinalSupplierMapping.Columns[0].Frozen = true;
                    grdFinalSupplierMapping.Columns[0].HeaderText = "";
                    grdFinalSupplierMapping.Columns[0].Width = 30;
                    grdFinalSupplierMapping.Columns["S.No."].Width = 50;
                    grdFinalSupplierMapping.Columns["P.I Code"].Width = 100;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].Width = 220;
                    grdFinalSupplierMapping.Columns["Unit"].Width = 60;
                    grdFinalSupplierMapping.Columns["Product SubGroup"].Width = 120;
                    grdFinalSupplierMapping.Columns["GROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["SUBGROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["PRODUCTID"].Visible = false;
                    grdFinalSupplierMapping.Columns["Product Name in English"].Visible = false;
                    grdProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                    grdFinalSupplierMapping.Columns["S.No."].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Unit"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Product SubGroup"].ReadOnly = true;
                    grdFinalSupplierMapping.Columns["Mapped Flag"].Visible = false;

                    grdFinalSupplierMapping.Sort(grdFinalSupplierMapping.Columns["Mapped Flag"], ListSortDirection.Descending);
                    udfnsearchgridHead();
                    udfnGridRemove();

                    DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                    grdFinalSupplierMapping_DataBindingComplete(grdFinalSupplierMapping, args);

                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                udfnSno();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdProducts.Rows.Count; i++)
                {
                    grdProducts.Rows[i].Cells[0].Value = true;
                }
                btnRemove.Enabled = false;
                BtnaddMove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdProducts.Rows.Count; i++)
                {
                    grdProducts.Rows[i].Cells[0].Value = false;
                }
                btnRemove.Enabled = true;
                BtnaddMove.Enabled = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnMappingSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdFinalSupplierMapping.Rows.Count; i++)
                {
                    grdFinalSupplierMapping.Rows[i].Cells[0].Value = true;
                }
                BtnaddMove.Enabled = false;
                btnRemove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnMappingUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdFinalSupplierMapping.Rows.Count; i++)
                {
                    grdFinalSupplierMapping.Rows[i].Cells[0].Value = false;
                }
                btnRemove.Enabled = false;
                BtnaddMove.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnsearchgridHead()
        {
            try
            {
                udfnGridSearchHeading(grdFinalSupplierMapping, DGV_SearchGrid1);
                DGV_SearchGrid1.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdFinalSupplierMapping.Columns)
                {
                    DGV_SearchGrid1.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_SearchGrid1.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_SearchGrid1.Rows.Clear();
                    DGV_SearchGrid1.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_SearchGrid1.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_SearchGrid1.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_SearchGrid1.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        public void udfnGridRemove()
        {
            try
            {
                HashSet<string> productIdsToRemove = new HashSet<string>();
                foreach (DataGridViewRow row in grdFinalSupplierMapping.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the last row used for adding new entries 
                    string productId = row.Cells["PRODUCTID"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(productId))
                    {
                        productIdsToRemove.Add(productId);
                    }
                }
                if (objdtProducts != null)
                {
                    for (int i = 0; i < objdtProducts.Rows.Count; i++)
                    {
                        string productId = Convert.ToString(objdtProducts.Rows[i]["PRODUCTID"]);
                        if (productIdsToRemove.Contains(productId))
                        {
                            objdtProducts.Rows[i].Delete(); // Mark row for deletion
                        }
                    }

                    objdtProducts.AcceptChanges();
                    grdProducts.DataSource = objdtProducts;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbFiledtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnClear();
                //if (Convert.ToInt32(cmbFiledtype.SelectedValue) == -1)
                //{

                //    errSpl.SetError(cmbFiledtype, "Please select field type");
                //    cmbFiledtype.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpFiledtype.ShowAlways = true;
                //    tpFiledtype.Show("Please select field type.", cmbFiledtype, 5000);
                //    return;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                objdtProducts.Columns.Add("", typeof(Boolean));
                objdtProducts.Columns.Add("S.No.", typeof(string));
                objdtProducts.Columns.Add("P.I Code", typeof(string));
                objdtProducts.Columns.Add("Product Name in Tamil", typeof(string));
                objdtProducts.Columns.Add("Unit", typeof(string));
                objdtProducts.Columns.Add("Brand", typeof(string));
                objdtProducts.Columns.Add("Product SubGroup", typeof(string));
                objdtProducts.Columns.Add("Product Group", typeof(string));
                objdtProducts.Columns.Add("GROUPID", typeof(int));
                objdtProducts.Columns.Add("SUBGROUPID", typeof(int));
                objdtProducts.Columns.Add("PRODUCTID", typeof(int));
                objdtProducts.Columns.Add("Product Name in English", typeof(string));

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
                if (grdFinalSupplierMapping.Rows.Count != 0)
                {
                    string result = "", varOriginator = "";
                    SPDataService objDSer = new SPDataService();
                    int flag = 0;
                    if (Convert.ToInt32(cmbFiledtype.SelectedValue) == 437)
                    {
                        //// Priority
                        flag = 1;
                        varOriginator = "Priority Product Flag Update";
                    }
                    else if (Convert.ToInt32(cmbFiledtype.SelectedValue) == 438)
                    {
                        ////Special
                        flag = 2;
                        varOriginator = "Special Product Flag Update";
                    }
                    else if (Convert.ToInt32(cmbFiledtype.SelectedValue) == 439)
                    {
                        ////focus
                        flag = 3;
                        varOriginator = "focus Product Flag Update";
                    }
                    else if (Convert.ToInt32(cmbFiledtype.SelectedValue) == 440)
                    {
                        ////own
                        flag = 4;
                        varOriginator = "own Product Flag Update";
                    }

                    DataTable saveobjDtProductsMapping = objdtProductsMapping.DefaultView.ToTable(false, "PRODUCTID", "P.I Code");

                    result = objDSer.udfnProductMaster(18, 0, "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, varOriginator, 0, null, flag, "", 0, 0, 0, 0, 0, null, "", "", "", 0, "", "", 0, 0, 0, saveobjDtProductsMapping, 0, 0, 0, 0, null, 0, "", "", "", "", "", 0, 0);
                    objDSer.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //udfnList();
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    udfnClear();
                    cmbFiledtype.SelectedIndex = 0;
                    cmbFiledtype.Focus();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(80);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnInitMappedProduct()
        {
            try
            {

                objdtProductsMapping = new DataTable();
                objdtProductsMapping.Columns.Add("", typeof(Boolean));
                objdtProductsMapping.Columns.Add("S.No.", typeof(string));
                objdtProductsMapping.Columns.Add("P.I Code", typeof(string));
                objdtProductsMapping.Columns.Add("Product Name in Tamil", typeof(string));
                objdtProductsMapping.Columns.Add("Unit", typeof(string));
                objdtProductsMapping.Columns.Add("Brand", typeof(string));
                objdtProductsMapping.Columns.Add("Product SubGroup", typeof(string));
                objdtProductsMapping.Columns.Add("Product Group", typeof(string));
                objdtProductsMapping.Columns.Add("GROUPID", typeof(int));
                objdtProductsMapping.Columns.Add("SUBGROUPID", typeof(int));
                objdtProductsMapping.Columns.Add("PRODUCTID", typeof(int));
                objdtProductsMapping.Columns.Add("Product Name in English", typeof(string));
                objdtProductsMapping.Columns.Add("Mapped Flag", typeof(int));

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnProView_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbFiledtype.SelectedValue) == -1)
                {
                    errSpl.SetError(cmbFiledtype, "Please select field type");
                    cmbFiledtype.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpFiledtype.ShowAlways = true;
                    tpFiledtype.Show("Please select field type.", cmbFiledtype, 5000);
                    return;
                }
                errSpl.Clear();
                cmbFiledtype.BackColor = Color.White;
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbFiledtype_Enter(object sender, EventArgs e)
        {
            try { cmbFiledtype.BackColor = Color.LemonChiffon; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbFiledtype_Leave(object sender, EventArgs e)
        {
            try { cmbFiledtype.BackColor = Color.White; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Spl_Products_Bulk_KeyDown(object sender, KeyEventArgs e)
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

        public void udfnProductRemove(object sender, EventArgs e)
        {

            try
            {


                //DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dialogResult == DialogResult.Yes)
                //{
                if (objdtProducts == null)
                {
                    udfnInitProduct();
                }
                for (int k = 1; k < DGV_SearchGrid1.ColumnCount; k++)
                {
                    DGV_SearchGrid1.Rows[0].Cells[k].Value = "";
                }
                DGV_SearchGrid1_CurrentCellDirtyStateChanged(sender, e);
            L: for (int i = 0; i < objdtProductsMapping.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(objdtProductsMapping.Rows[i][0]) == true)
                    {
                        int varSlNo = 1;
                        if (objdtProducts != null)
                        { varSlNo = objdtProducts.Rows.Count + 1; }
                        objdtProducts.Rows.Add(false, varSlNo, objdtProductsMapping.Rows[i]["P.I Code"],
                        objdtProductsMapping.Rows[i]["Product Name in Tamil"],
                        objdtProductsMapping.Rows[i]["Unit"],
                        objdtProductsMapping.Rows[i]["Brand"],
                        objdtProductsMapping.Rows[i]["Product SubGroup"],
                        objdtProductsMapping.Rows[i]["Product Group"],
                        objdtProductsMapping.Rows[i]["GROUPID"],
                        objdtProductsMapping.Rows[i]["SUBGROUPID"],
                        objdtProductsMapping.Rows[i]["PRODUCTID"], objdtProductsMapping.Rows[i]["Product Name in English"]);
                        objdtProducts.AcceptChanges();
                        //for (int j = 0; j < objdtProductsMapping.Rows.Count; j++)
                        //{
                        //    if (Convert.ToString(grdFinalSupplierMapping.Rows[i].Cells["PRODUCTID"].Value) == Convert.ToString(objdtProductsMapping.Rows[j]["PRODUCTID"]))
                        //    {
                        objdtProductsMapping.Rows.RemoveAt(i);
                        objdtProductsMapping.AcceptChanges();
                        goto L;
                        //  }
                        //  }
                    }
                }
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
                grdProducts.DataSource = objdtProducts;
                // grdProducts.Columns[0].Frozen = true;
                grdProducts.Columns[0].HeaderText = "";
                grdProducts.Columns[0].Width = 30;
                grdProducts.Columns["S.No."].Width = 50;
                grdProducts.Columns["P.I Code"].Width = 100;
                grdProducts.Columns["Product Name in Tamil"].Width = 220;
                grdProducts.Columns["Unit"].Width = 60;
                grdProducts.Columns["Product SubGroup"].Width = 170;
                grdProducts.Columns["GROUPID"].Visible = false;
                grdProducts.Columns["SUBGROUPID"].Visible = false;
                grdProducts.Columns["PRODUCTID"].Visible = false;
                grdProducts.Columns["Product Name in English"].Visible = false;
                grdProducts.Columns["S.No."].Visible = false;
                grdProducts.Columns["S.No."].ReadOnly = true;
                grdProducts.Columns["P.I Code"].ReadOnly = true;
                grdProducts.Columns["Product Name in Tamil"].ReadOnly = true;
                grdProducts.Columns["Unit"].ReadOnly = true;
                grdProducts.Columns["Product SubGroup"].ReadOnly = true;
                grdProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                udfnSearchGridHead();


                grdFinalSupplierMapping.DataSource = objdtProductsMapping;
                // grdFinalSupplierMapping.Columns[0].Frozen = true;
                grdFinalSupplierMapping.Columns[0].HeaderText = "";
                grdFinalSupplierMapping.Columns[0].Width = 30;
                grdFinalSupplierMapping.Columns["S.No."].Width = 50;
                grdFinalSupplierMapping.Columns["P.I Code"].Width = 100;
                grdFinalSupplierMapping.Columns["Product Name in Tamil"].Width = 220;
                grdFinalSupplierMapping.Columns["Unit"].Width = 60;
                grdFinalSupplierMapping.Columns["Product SubGroup"].Width = 120;
                grdFinalSupplierMapping.Columns["GROUPID"].Visible = false;
                grdFinalSupplierMapping.Columns["SUBGROUPID"].Visible = false;
                grdFinalSupplierMapping.Columns["PRODUCTID"].Visible = false;
                grdFinalSupplierMapping.Columns["Product Name in English"].Visible = false;
                grdFinalSupplierMapping.Columns["Mapped Flag"].Visible = false;
                grdProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                grdFinalSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                grdFinalSupplierMapping.Columns["S.No."].ReadOnly = true;
                grdFinalSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                grdFinalSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                grdFinalSupplierMapping.Columns["Unit"].ReadOnly = true;
                grdFinalSupplierMapping.Columns["Product SubGroup"].ReadOnly = true;

                grdFinalSupplierMapping.Columns["Mapped Flag"].Visible = false;

                for (int j = 0; j < grdFinalSupplierMapping.RowCount; j++)
                {
                    grdFinalSupplierMapping.Rows[j].Cells["S.No."].Value = j + 1;
                }

                grdFinalSupplierMapping.Sort(grdFinalSupplierMapping.Columns["Mapped Flag"], ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalProducts.Text = grdProducts.Rows.Count.ToString();
                grdFinalSupplierMapping.Columns[0].ReadOnly = false;
                grdProducts.Columns[0].ReadOnly = false;

                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
            }

        }
        public void udfnClear()
        {
            try
            {
                objdtProducts.Rows.Clear();
                objdtProductsMapping.Rows.Clear();
                grdFinalSupplierMapping.DataSource = null;
                grdProducts.DataSource = null;
                txtMappingGroup.Text = "";
                txtMappingSubGroup.Text = "";
                txtBrand.Text = "";
                varGroupId = 0;
                varSubGroupId = 0;
                varBrandId = 0;
                lblTotalProducts.Text = grdProducts.Rows.Count.ToString();
                lblTotalMappingProduct.Text = grdFinalSupplierMapping.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSno()
        {
            try
            {
                for (int i = 0; i < grdFinalSupplierMapping.Rows.Count; i++)
                {
                    grdFinalSupplierMapping.Rows[i].Cells["S.No."].Value = i + 1;
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
