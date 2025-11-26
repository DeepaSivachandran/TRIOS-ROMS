using DocumentFormat.OpenXml.VariantTypes;
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

namespace ROMS
{
    // Name  : Sivabharathi    Date : 02/09/2023
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
        public int varStatusId = 0, varErrorflag=0,Varupdateflag=0; 
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

        private void CP_Spl_Products_Bulk_Load(object sender, EventArgs e)
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
                objdtProducts.Columns.Add("MappedCount", typeof(int));
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
                for (int i = 0; i < grdProducts.RowCount; i++)
                {
                    if (Convert.ToString(grdProducts.Rows[i].Cells["MappedCount"].Value) != "0")
                    {
                        grdProducts.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
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


        #region Udfn Functions

        public void udfnList() {
            
            try
            {
                lblNoRecordsFound.Visible = false;
                grdProducts.DataSource = null;
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 3;
                objMR_Product.paraGroup = varGroupId;
                objMR_Product.paraSubgroup = varSubGroupId;
                objMR_Product.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objMR_Product.paraBrandID = varBrandId; 
                DataSet objDs = new DataSet();
                objdtProducts = null; 
                SPDataService objspservice = new SPDataService(); 
                objDs = objspservice.udfnproductmasterlist(objMR_Product);
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        objdtProducts.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in Tamil"]
                            , objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["Brand"], objDs.Tables[0].Rows[i]["Product SubGroup"], objDs.Tables[0].Rows[i]["Product Group"], objDs.Tables[0].Rows[i]["GROUPID"], objDs.Tables[0].Rows[i]["SUBGROUPID"],
                            objDs.Tables[0].Rows[i]["PRODUCTID"], objDs.Tables[0].Rows[i]["Product Name in English"], objDs.Tables[0].Rows[i]["MappedCount"]);
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
                    grdProducts.Columns["MappedCount"].Visible = false;
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
                    //objdtProducts.AcceptChanges();
                    grdProducts.DataSource = null;
                }
                objspservice.CloseConnection();
                udfnSearchGridHead();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                SearchFlag = 0;
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

        #endregion
    }
}
