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
    public partial class PUR_POMappedProducts : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        Boolean BlnSearchImageYN = false;
        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode, DefProductsCode="";
        public DataTable dtMappedProduct;
        public string pbFormStatus;
        public int VARFLAG = 0;
        public PUR_POMappedProducts()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
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

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

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

        private void DGV_SearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdPurchaseOrder.ColumnCount > 0)
                {
                    grdPurchaseOrder.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseOrder.HorizontalScrollingOffset;
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
                grdPurchaseOrder.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseOrder);
                objDser.CloseConnection();
                grdPurchaseOrder.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
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
                udfnGridSearchHeading(grdPurchaseOrder, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdPurchaseOrder.Columns)
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
                for (int i = 1; i < visibleColumns.Count; i++)
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
                        //dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int i = e.ColumnIndex + 2;
            //if (e.ColumnIndex == 0)
            //{
            //    i = e.ColumnIndex;
            //}
            //DataGridViewColumn newColumn = grdPurchaseOrder.Columns[i];
            //DataGridViewColumn oldColumn = grdPurchaseOrder.SortedColumn;
            //ListSortDirection direction;

            //// If oldColumn is null, then the DataGridView is not sorted.
            //if (oldColumn != null)
            //{
            //    // Sort the same column again, reversing the SortOrder.
            //    if (oldColumn == newColumn &&
            //        grdPurchaseOrder.SortOrder == SortOrder.Ascending)
            //    {
            //        direction = ListSortDirection.Descending;
            //    }
            //    else
            //    {
            //        // Sort a new column and remove the old SortGlyph.
            //        direction = ListSortDirection.Ascending;
            //        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            //    }
            //}
            //else
            //{
            //    direction = ListSortDirection.Ascending;
            //}
            //grdPurchaseOrder.Sort(newColumn, direction);
            //newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
            //DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
            //DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
            //DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseOrder.HorizontalScrollingOffset;
            //DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int cl = grdPurchaseOrder.ColumnCount;
                int cls = DGV_SearchGrid.ColumnCount;
                int offSetValue = grdPurchaseOrder.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;

                if (totalWidth - grdPurchaseOrder.Width > grdPurchaseOrder.HorizontalScrollingOffset && grdPurchaseOrder.HorizontalScrollingOffset > 0)
                {
                    //offSetValue = offSetValue ;
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdPurchaseOrder);
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
                grdPurchaseOrder.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseOrder);
                objDser.CloseConnection();
                grdPurchaseOrder.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclose()
        {
            try
            {
                this.Close(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_POMappedProducts_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text) != 0)
                {
                    lblNoRecordsFound.Visible = false; 
                    this.Text = MainForm.objPUR_PurchaseOrder.txtSupplier.Text;
                    dtMappedProduct = new DataTable();
                    dtMappedProduct.Columns.Add("", typeof(Boolean));
                    dtMappedProduct.Columns.Add("S.No.", typeof(string));
                    dtMappedProduct.Columns.Add("P.I Code", typeof(string));
                    dtMappedProduct.Columns.Add("Product Name", typeof(string));
                    dtMappedProduct.Columns.Add("Unit", typeof(string));
                    dtMappedProduct.Columns.Add("Unit Per case", typeof(string));
                    dtMappedProduct.Columns.Add("R.Rate", typeof(string));
                    dtMappedProduct.Columns.Add("W.Rate", typeof(string));
                    dtMappedProduct.Columns.Add("Min Qty", typeof(string));
                    dtMappedProduct.Columns.Add("Max Qty", typeof(string));
                    dtMappedProduct.Columns.Add("Stock", typeof(float));
                    dtMappedProduct.Columns.Add("Reorder Qty", typeof(string));
                    dtMappedProduct.Columns.Add("Product ID", typeof(int));
                    dtMappedProduct.Columns.Add("GST_Text", typeof(string));
                    dtMappedProduct.Columns.Add("PREVIOUS", typeof(string));
                    dtMappedProduct.Columns.Add("PARTIAL", typeof(string));
                    dtMappedProduct.Columns.Add("ordervalue", typeof(string));
                    dtMappedProduct.Columns.Add("PR_UTID", typeof(int));
                    //for products weight value calc 
                    dtMappedProduct.Columns.Add("Unit Wt", typeof(string));
                    dtMappedProduct.Columns.Add("B.Unit Weight", typeof(string));
                    dtMappedProduct.Columns.Add("bunit", typeof(string));
                    dtMappedProduct.Columns.Add("qtyunit", typeof(string));
                    dtMappedProduct.Columns.Add("totunit", typeof(string));
                    dtMappedProduct.Columns.Add("finalunit", typeof(string));
                    dtMappedProduct.Columns.Add("PR_NettWeight", typeof(double));
                    dtMappedProduct.Columns.Add("PR_UPP", typeof(int));
                    dtMappedProduct.Columns.Add("B.UTID", typeof(int));
                    dtMappedProduct.Columns.Add("T.UTID", typeof(int));
                     

                    if (Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text) != 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 33;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue);
                        objMR_Product.ParaScheduleid = Convert.ToString(MainForm.objPUR_PurchaseOrder.lblschedule.Text);
                        objMR_Product.ParaSupplierId = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text);
                        objMR_Product.ParaProductsCode = MainForm.objPUR_PurchaseOrder.pbProductsCode;
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    { 
                                        dtMappedProduct.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name"]
                                        , objDs.Tables[0].Rows[i]["Unit"],
                                        objDs.Tables[0].Rows[i]["Unit Per box"], objDs.Tables[0].Rows[i]["SalesRate"], objDs.Tables[0].Rows[i]["WholeSaleRate"] , objDs.Tables[0].Rows[i]["Min Qty"], objDs.Tables[0].Rows[i]["Max Qty"] , objDs.Tables[0].Rows[i]["MXSTK"],
                                        objDs.Tables[0].Rows[i]["Reorder"], objDs.Tables[0].Rows[i]["Productid"], objDs.Tables[0].Rows[i]["GST_Text"],
                                        objDs.Tables[0].Rows[i]["PREVIOUS"], objDs.Tables[0].Rows[i]["PARTIAL"], objDs.Tables[0].Rows[i]["ordervalue"], 
                                        objDs.Tables[0].Rows[i]["PR_UTID"], objDs.Tables[0].Rows[i]["Unit Wt"], objDs.Tables[0].Rows[i]["B.Unit Weight"],
                                        objDs.Tables[0].Rows[i]["bt_symbol"], objDs.Tables[0].Rows[i]["unit"],
                                        objDs.Tables[0].Rows[i]["unit"], objDs.Tables[0].Rows[i]["tot_symbol"],
                                        objDs.Tables[0].Rows[i]["PR_NettWeight"], objDs.Tables[0].Rows[i]["PR_UPP"],
                                        objDs.Tables[0].Rows[i]["PR_Bulk_UTID"], objDs.Tables[0].Rows[i]["PR_QUTID"]);
                                    }

                                    grdPurchaseOrder.DataSource = dtMappedProduct; 
                                    grdPurchaseOrder.Columns[0].HeaderText = "";
                                    grdPurchaseOrder.Columns[0].Width = 30;
                                    grdPurchaseOrder.Columns["S.No."].Width = 50;
                                    grdPurchaseOrder.Columns[0].ReadOnly = false;
                                   // "Unit Per box"
                                    grdPurchaseOrder.Columns[0].Frozen = true;
                                    grdPurchaseOrder.Columns["P.I Code"].Width = 100;
                                    grdPurchaseOrder.Columns["Product Name"].Width = 300;
                                    grdPurchaseOrder.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    grdPurchaseOrder.Columns["Unit"].Width = 70;
                                    grdPurchaseOrder.Columns["R.Rate"].Width = 70;
                                    grdPurchaseOrder.Columns["W.Rate"].Width = 70;
                                    grdPurchaseOrder.Columns["Min Qty"].Width = 70;
                                    grdPurchaseOrder.Columns["Max Qty"].Width = 70;
                                    grdPurchaseOrder.Columns["Stock"].Width = 80;
                                    grdPurchaseOrder.Columns["Product id"].Visible = false;
                                    grdPurchaseOrder.Columns["GST_Text"].Visible = false;
                                    grdPurchaseOrder.Columns["PREVIOUS"].Visible = false;
                                    grdPurchaseOrder.Columns["PARTIAL"].Visible = false;
                                    grdPurchaseOrder.Columns["R.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["W.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["Reorder Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["Min Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["Max Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["S.No."].ReadOnly = true;
                                    grdPurchaseOrder.Columns["P.I Code"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Product Name"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Unit"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["R.Rate"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["W.Rate"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Min Qty"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Max Qty"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Stock"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Stock"].Visible = false;
                                    grdPurchaseOrder.Columns["Reorder Qty"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["ordervalue"].Visible = false; 
                                    grdPurchaseOrder.Columns["PR_UTID"].Visible = false; 
                                    grdPurchaseOrder.Columns["Reorder Qty"].Visible = false;
                                    grdPurchaseOrder.Columns["Unit Wt"].Visible = false;
                                    grdPurchaseOrder.Columns["B.Unit Weight"].Visible = false;
                                    grdPurchaseOrder.Columns["bunit"].Visible = false;
                                    grdPurchaseOrder.Columns["qtyunit"].Visible = false;
                                    grdPurchaseOrder.Columns["totunit"].Visible = false;
                                    grdPurchaseOrder.Columns["finalunit"].Visible = false;
                                    grdPurchaseOrder.Columns["PR_NettWeight"].Visible = false;
                                    grdPurchaseOrder.Columns["PR_UPP"].Visible = false;
                                    grdPurchaseOrder.Columns["B.UTID"].Visible = false;
                                    grdPurchaseOrder.Columns["T.UTID"].Visible = false; 
                                }
                                else { lblNoRecordsFound.Visible = true; }
                            }
                            else { lblNoRecordsFound.Visible = true; }
                        }
                        else { lblNoRecordsFound.Visible = true; }
                    }
                    else { lblNoRecordsFound.Visible = true; }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdPurchaseOrder.ClearSelection(); 
                lblPC.Text = grdPurchaseOrder.Rows.Count.ToString();
                udfnSearchGridHead();
            }
        }
         

        private void GrdPurchaseOrder_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPurchaseOrder.IsCurrentCellDirty)
                {
                    grdPurchaseOrder.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                udfnAddProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAddProduct()
        {
            try
            {
                DefProductsCode = "";
                for (int i = 0; i < grdPurchaseOrder.Rows.Count; i++)
                {
                    if (DefProductsCode == "")
                    {
                        DefProductsCode = Convert.ToString(grdPurchaseOrder.Rows[i].Cells["Product ID"].Value);
                    }
                    else
                    {
                        DefProductsCode = DefProductsCode + ',' + Convert.ToString(grdPurchaseOrder.Rows[i].Cells["Product ID"].Value);
                    }
                }

                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet(); 
                objDs = objspdservice.udfnSupplierList(28, Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text), Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text), 0, 0, "", 0, 0, Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue), "", 0, 0, 0, 0, 0, 0,DefProductsCode,"","",0);
                objspdservice.CloseConnection();

                for (int i = 0; i < grdPurchaseOrder.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdPurchaseOrder.Rows[i].Cells[0].Value) == true)
                    {
                        string defflag = "0";
                        if (objDs != null)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString( objDs.Tables[0].Rows[i]["prid"])== Convert.ToString((grdPurchaseOrder.Rows[i].Cells["Product ID"].Value)))
                                {
                                    defflag = Convert.ToString(objDs.Tables[0].Rows[i]["flag"]);
                                }
                                else
                                {
                                    defflag = "4";
                                }
                            }
                        } 
                        MainForm.objPUR_PurchaseOrder.grdsupplieradd.Rows.Add(MainForm.objPUR_PurchaseOrder.grdsupplieradd.Rows.Count + 1,
                        grdPurchaseOrder.Rows[i].Cells["P.I Code"].Value, grdPurchaseOrder.Rows[i].Cells["Product Name"].Value, grdPurchaseOrder.Rows[i].Cells["Unit"].Value,
                        grdPurchaseOrder.Rows[i].Cells["Unit Wt"].Value, grdPurchaseOrder.Rows[i].Cells["Unit Per case"].Value, grdPurchaseOrder.Rows[i].Cells["B.Unit Weight"].Value, 
                        grdPurchaseOrder.Rows[i].Cells["GST_Text"].Value, (grdPurchaseOrder.Rows[i].Cells["Min Qty"].Value), (grdPurchaseOrder.Rows[i].Cells["Max Qty"].Value),
                        (grdPurchaseOrder.Rows[i].Cells["Stock"].Value), Convert.ToString(grdPurchaseOrder.Rows[i].Cells["PREVIOUS"].Value), grdPurchaseOrder.Rows[i].Cells["PARTIAL"].Value, 
                        (grdPurchaseOrder.Rows[i].Cells["Reorder Qty"].Value),"", grdPurchaseOrder.Rows[i].Cells["bunit"].Value,"", grdPurchaseOrder.Rows[i].Cells["qtyunit"].Value,
                        "",grdPurchaseOrder.Rows[i].Cells["totunit"].Value,"", grdPurchaseOrder.Rows[i].Cells["finalunit"].Value, (grdPurchaseOrder.Rows[i].Cells["Product ID"].Value), 
                        defflag, 1, "", 10, (grdPurchaseOrder.Rows[i].Cells["PR_UTID"].Value), (grdPurchaseOrder.Rows[i].Cells["PR_NettWeight"].Value),
                        (grdPurchaseOrder.Rows[i].Cells["PR_UPP"].Value),"",(grdPurchaseOrder.Rows[i].Cells["B.UTID"].Value), (grdPurchaseOrder.Rows[i].Cells["T.UTID"].Value));
                        VARFLAG = 1;}
                }

                if(VARFLAG != 0)
                { 
                    MainForm.objPUR_PurchaseOrder.grdsupplieradd.Sort(MainForm.objPUR_PurchaseOrder.grdsupplieradd.Columns[1], ListSortDirection.Ascending);
                    for (int i = 0; i < MainForm.objPUR_PurchaseOrder.grdsupplieradd.RowCount; i++)
                    {
                        MainForm.objPUR_PurchaseOrder.grdsupplieradd.Rows[i].Cells["clmsno"].Value = i + 1;
                    }
                    this.Close();
                }
                 else
                {
                    SPDataService objDServ = new SPDataService();
                    if (grdPurchaseOrder.Rows.Count > 0)
                    {
                        string varMessage = objDServ.udfnGetMessages(80);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    { 
                        string varMessage = objDServ.udfnGetMessages(41);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_POMappedProducts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { 
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_POMappedProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (VARFLAG == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void BtnSave_Leave(object sender, EventArgs e)
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

        private void BtnSave_Enter(object sender, EventArgs e)
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

        private void BtnClose_Enter(object sender, EventArgs e)
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

        private void BtnClose_Leave(object sender, EventArgs e)
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

        private void Btnselectall_Click(object sender, EventArgs e)
        {
            try
            { 

                foreach (DataGridViewRow row in grdPurchaseOrder.Rows)
                {
                    row.Cells[0].Value = true;
                } 

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btnunselectall_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in grdPurchaseOrder.Rows)
                {
                    row.Cells[0].Value = false;
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
