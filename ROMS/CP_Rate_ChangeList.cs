using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    public partial class CP_Rate_ChangeList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public int varconcern = 0, vargroup = 0, varsubgroup = 0, varcategory = 0, varfiltertype = 0;
        public string varUserID = "";
        public int varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyProduct = 0, varUpDownKeyBrand = 0, varUpDownKeyLockProduct = 0;
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        Boolean BlnSearchImageYN = false;
        private ToolTip tpVerifier = new ToolTip();
        public string pbUnLockTellerName = "";
        public CP_Rate_ChangeList()
        {
            InitializeComponent();
            windowControl.Initialize(tsRateChange, this);
        }
        
        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
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
                string varGroupName = "", varSubgroupName = "", varProductName = "", varBrandName = "";
                int varGroupId = 0, varSubgroupId = 0, varProductId = 0, varBrandId = 0;
                if (txtGroup.Text.Trim() == "")
                {
                    varGroupName = "-All-";
                }
                else
                {
                    varGroupName = txtGroup.Text;
                    varGroupId = Convert.ToInt32(lblGroupCode.Text);
                }
                if (txtSubGroup.Text.Trim() == "")
                {
                    varSubgroupName = "-All-";
                }
                else
                {
                    varSubgroupName = txtSubGroup.Text;
                    varSubgroupId = Convert.ToInt32(lblSubGroupCode.Text);
                }
                if (txtProductName.Text.Trim() == "")
                {
                    varProductName = "-All-";
                }
                else
                {
                    varProductName = txtProductName.Text;
                    varProductId = Convert.ToInt32(lblProductcode.Text);
                }
                if (txtBrand.Text.Trim() == "")
                {
                    varBrandName = "-All-";
                    varBrandId = 0;
                }
                else
                {
                    varBrandName = txtBrand.Text;
                    varBrandId = Convert.ToInt32(lblBrandCode.Text);
                }
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                TRN_RateChange objRateChange = new TRN_RateChange(); 
                objRateChange.paraGroupID = varGroupId;
                objRateChange.paraSubGroupID = varSubgroupId;
                objRateChange.paraBrandID = varBrandId;
                objRateChange.paraProductID = varProductId;

                //*** All : varfiltertype = 0 , retail zero rate : varfiltertype= 1, wholesale zero rate : varfiltertype= 2 ***
                objRateChange.paraType = varfiltertype;

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
                            grdItemList.Columns["S.No."].Width = 50;
                            grdItemList.Columns["P.I Code"].Width = 100;
                            grdItemList.Columns["Product"].Width = 360;
                            grdItemList.Columns["Unit"].Width = 60;
                            grdItemList.Columns["Last R.Rate"].Width = 100;
                            grdItemList.Columns["Last W.Rate"].Visible = false;
                            grdItemList.Columns["Live R.Rate"].Width = 100;
                            grdItemList.Columns["Live W.Rate"].Visible = false;
                            grdItemList.Columns["Teller"].Width = 135;
                            grdItemList.Columns["Last Updated By"].Width = 280;
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


                            grdItemList.Columns["Group Id"].Visible = false; 
                            grdItemList.Columns["Group Name"].Visible = false; 
                            grdItemList.Columns["Subgroup Id"].Visible = false; 
                            grdItemList.Columns["Subgroup Name"].Visible = false; 
                            grdItemList.Columns["Brand Id"].Visible = false;
                            grdItemList.Columns["Brand Name"].Visible = false;
                            lblNoRecordsFound.Visible = false;


                            grdItemList.Columns["Last R.Rate"].HeaderText = "Last Rate"; 
                            grdItemList.Columns["Live R.Rate"].HeaderText = "Live Rate";

                            //grdItemList.Columns["Live W.Rate"].Visible = false;
                            //grdItemList.Columns["Last W.Rate"].Visible = false;

                            //grdItemList.Columns["Live R.Rate"].HeaderText = "New Rate";
                            //grdItemList.Columns["Last R.Rate"].HeaderText = "Last Rate";

                            lblNoRecordsFound.SendToBack();
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {  
                            tspTotal.Text = "Total Items : " + Convert.ToString(objDs.Tables[1].Rows[0]["TotalCount"]);
                            tspZeroRetail.Text = "Zero Rate Retail Items : " + Convert.ToString(objDs.Tables[1].Rows[0]["ZeroLiveRRateCount"]);
                            tspWholesale.Text = "Zero Rate Whole-Sale Items  : " + Convert.ToString(objDs.Tables[1].Rows[0]["ZeroLiveWRateCount"]);

                            //tspTotal.Enabled = true;
                            //tspZeroRetail.Enabled = true;
                            //tspWholesale.Enabled = true; 
                        }
                        else
                        {

                            tspTotal.Text = "Total Items : 0"  ;
                            tspZeroRetail.Text = "Zero Rate Retail Items : 0";
                            tspWholesale.Text = "Zero Rate Whole-Sale Items  : 0";

                            //tspTotal.Enabled = false;
                            //tspZeroRetail.Enabled = false;
                            //tspWholesale.Enabled = false; 
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

        public void udfnPrint() {

            try
            {
                dtDefaultGrid = null; 
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 
                string varGroupName = "", varSubgroupName = "", varProductName = "", varBrandName = "";
                int varGroupId = 0, varSubgroupId = 0, varProductId = 0, varBrandId = 0;
                if (txtGroup.Text.Trim() == "")
                {
                    varGroupName = "-All-";
                }
                else
                {
                    varGroupName = txtGroup.Text;
                    varGroupId = Convert.ToInt32(lblGroupCode.Text);
                }
                if (txtSubGroup.Text.Trim() == "")
                {
                    varSubgroupName = "-All-";
                }
                else
                {
                    varSubgroupName = txtSubGroup.Text;
                    varSubgroupId = Convert.ToInt32(lblSubGroupCode.Text);
                }
                if (txtProductName.Text.Trim() == "")
                {
                    varProductName = "-All-";
                }
                else
                {
                    varProductName = txtProductName.Text;
                    varProductId = Convert.ToInt32(lblProductcode.Text);
                }
                if (txtBrand.Text.Trim() == "")
                {
                    varBrandName = "-All-";
                    varBrandId = 0;
                }
                else
                {
                    varBrandName = txtBrand.Text;
                    varBrandId = Convert.ToInt32(lblBrandCode.Text);
                }
                DataSet objDs = new DataSet();

                int varPrint = 0;
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                TRN_RateChange objRateChange = new TRN_RateChange();
                objRateChange.paraGroupID = varGroupId;
                objRateChange.paraSubGroupID = varSubgroupId;
                objRateChange.paraBrandID = varBrandId;
                objRateChange.paraProductID = varProductId;

                //*** All : varfiltertype = 0 , retail zero rate : varfiltertype= 1, wholesale zero rate : varfiltertype= 2 ***
                objRateChange.paraType = varfiltertype;

                objDs = objdserv.udfnRateChangeList(objRateChange);
                objdserv.CloseConnection();

                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }

                if (varPrint == 1)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (Convert.ToInt32(cmbPrintType.SelectedValue) == 354)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Rate_Changes_Consolidated.rpt");
                    }
                    else
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Rate_Changes.rpt");
                    }
                    objBillreport.SetParameterValue("paraGroupID", varGroupId);
                    objBillreport.SetParameterValue("paraSubGroupID", varSubgroupId);
                    objBillreport.SetParameterValue("paraBrandID", varBrandId);
                    objBillreport.SetParameterValue("paraProductID", varProductId);
                    objBillreport.SetParameterValue("paraType", varfiltertype); 
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName); 
                    objValidation.CrySqlConnection(objBillreport); 
                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport; 
                    MainForm.objReportLoad.ShowDialog();
                }
                else {  
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
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

        public void udfnDefaultSearchGrid()
        {
            try
            {
                if (dtDefaultGrid.Rows.Count != 0)
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
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
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
                    //MainForm.objStart = new DEF_Start();
                    //MainForm.objStart.MdiParent = this.ParentForm;
                    //MainForm.objStart.Show();
                    //this.Close();
                    windowControl?.TriggerClose();
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
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 51304;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                MenuCode = 51304;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID=106", "MST_DisplayText,MSTID,MST_ShortName", cmbPrintType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                udfnList();
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }
                // * BeginInvoke is used to open render the list form first, render complete for the list screen then dialog shown* 
                // * By venkat on 13-08-2025 *
                if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        tsbNew_Click(sender, e);
                    });
                }
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
                tsbNew.Visible = privilege.Contains("2");   
                btnPrint.Visible = privilege.Contains("5");
                btnExport.Visible = privilege.Contains("6"); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tspTotal_Click(object sender, EventArgs e)
        {
            try {

                varfiltertype = 0;
                udfnList();
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tspZeroRetail_Click(object sender, EventArgs e)
        {
            try
            { 
                varfiltertype = 1;
                udfnList();
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void tspWholesale_Click(object sender, EventArgs e)
        {

            try
            {

                varfiltertype = 2;
                udfnList();
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void txtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtGroup)
                {
                    varUpDownKeyGroup = 0;
                    DGV_FilterGroup.DataSource = null;
                    DGV_FilterGroup.Visible = false;
                }
                if (skipControl != txtSubGroup)
                {
                    varUpDownKeySubgroup = 0;
                    DGV_FilterSubgroup.DataSource = null;
                    DGV_FilterSubgroup.Visible = false;
                }
                if (skipControl != txtProductName)
                {
                    varUpDownKeyProduct = 0;
                    DGV_FilterProduct.DataSource = null;
                    DGV_FilterProduct.Visible = false;
                }
                if (skipControl != txtBrand)
                {
                    varUpDownKeyBrand = 0;
                    DGV_FilterBrand.DataSource = null;
                    DGV_FilterBrand.Visible = false;
                }
                if (skipControl != txtProduct)
                {
                    varUpDownKeyLockProduct = 0;
                    DGV_Product.DataSource = null;
                    DGV_Product.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyGroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterGroup.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterGroup.Visible == false)
                {
                    txtSubGroup.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterGroup.Focus();
                }
                if (DGV_FilterGroup.CurrentCell == null && DGV_FilterGroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterGroup.Focus();
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
                            if (RowIndex != (-1))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }
                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
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
                    txtGroup.Focus();
                    //txtGroup.SelectionStart = txtGroup.Text.Length;
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
                        txtSubGroup.Focus();
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
                txtSubGroup.Focus();
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

                            txtGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
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
                        txtSubGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void txtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            { 
                udfnGridNull((Control)sender);
                txtSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtSubGroup_KeyDown(object sender, KeyEventArgs e)
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
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }
                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
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
                    txtSubGroup.Focus();
                    //txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
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
        private void txtSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeySubgroup == 0)
                {
                    if (txtGroup.Text.Trim() == "")
                    {
                        lblGroupCode.Text = "0";
                    } 
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtSubGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupCode.Text), 0, txtSubGroup.Text, 0, 0, 0, 0, 0);
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

                            txtSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
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

        private void txtGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSubGroup_FontChanged(object sender, EventArgs e)
        {

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
                udfnGridNull((Control)sender);
                txtBrand.BackColor = Color.LemonChiffon;
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
                    txtProductName.Focus();
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
                        txtProductName.Focus();
                    }
                }
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
                if (txtBrand.Text == "")
                {
                    lblBrandCode.Text = "0";
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
                txtProductName.Focus();
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
                        txtProductName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void txtGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyGroup == 0)
                {
                    //lvGroup.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnGroupList(7, 0, 0, txtGroup.Text, 0);
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


        private void txtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyProduct = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterProduct.Focus();
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }
                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
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
        private void txtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyProduct == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {

                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 49;
                        objMR_Product.paraGroup = Convert.ToInt32(lblGroupCode.Text);
                        objMR_Product.paraSubgroup = Convert.ToInt32(lblSubGroupCode.Text);
                        objMR_Product.paraProductName = txtProductName.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "P.I Code";
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 0;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
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



        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyProduct = 1;
                udfnListviewProduct(); 
                btnView.Focus(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
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

        private void grdItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdItemList.ClearSelection();
        }

        private void btnView_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
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

        private void CmbPrintType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPrintType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPrintType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnPrint.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPrintType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPrintType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPrintType.BackColor = Color.White;
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
                udfnExport();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnExport()
        {
            try
            {
                if (Convert.ToInt32(cmbPrintType.SelectedValue) == 354)
                {
                    udfnConsolidatedExcel();
                }
                else
                {
                    udfnDetailedExcel();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        public void udfnConsolidatedExcel()
        {
            try
            {
                btnExport.Enabled = false;
                label1.Focus();
                if ((grdItemList.Rows.Count > 0))
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
                    string varDate = MainForm.pbCurrentDate.ToString("dd/MM/yyyy");
                    ExcelSheet.Name = "Rate Change" + "_" + varDate;
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdItemList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }

                    ExcelSheet.Cells[1, 1].Value = "Rate Change" + "-" + varDate;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;

                    foreach (DataGridViewColumn col in grdItemList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            if (col.Name == "P.I Code")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 12;
                            }
                            if (col.Name == "Last R.Rate" || col.Name == "Last W.Rate" || col.Name == "Live R.Rate" || col.Name == "Live W.Rate")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;

                                Excel.Range rateRange = ExcelSheet.Range[
                                    ExcelSheet.Cells[3, cIndex],
                                    ExcelSheet.Cells[grdItemList.Rows.Count + 2, cIndex]
                                ];
                                rateRange.NumberFormat = "0.00"; 
                                rateRange.HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            if (col.Name == "Teller" || col.Name == "Last Updated By")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 35;
                            }
                            if (col.Name == "Product")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 40;
                                Excel.Range productRange = ExcelSheet.Range[
                                    ExcelSheet.Cells[3, cIndex],
                                    ExcelSheet.Cells[grdItemList.Rows.Count + 2, cIndex]
                                ];
                                productRange.Font.Name = "Uni Ila.Sundaram-03";
                                productRange.Font.Size = 11.75;
                            }

                            if (col.Name == "S.No." || col.Name == "Unit")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            foreach (DataGridViewRow rowa in grdItemList.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                            }
                        }
                    }
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

        public void udfnDetailedExcel()
        {
            try
            {
                btnExport.Enabled = false;
                label1.Focus();

                if (grdItemList.Rows.Count > 0)
                {
                    Excel._Application ExcelObj = new Excel.Application();
                    Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                    Excel._Worksheet ExcelSheet = ExcelBook.ActiveSheet;
                    ExcelObj.Visible = true;

                    string varDate = MainForm.pbCurrentDate.ToString("dd/MM/yyyy");
                    ExcelSheet.Name = "Rate Change_" + varDate;

                    int colCount = grdItemList.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible);

                    // Title Row
                    ExcelSheet.Cells[1, 1].Value = "Rate Change - " + varDate;
                    Excel.Range titleRange = ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, colCount]];
                    titleRange.Merge();
                    titleRange.HorizontalAlignment = Excel.Constants.xlCenter;
                    titleRange.Interior.Color = Color.LightGray;
                    titleRange.Font.Size = 12;
                    titleRange.Font.Bold = true;

                    int excelRow = 3;

                    int cIndexHeader = 0;
                    foreach (DataGridViewColumn col in grdItemList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndexHeader++;
                            ExcelSheet.Cells[excelRow, cIndexHeader].Value = col.HeaderText;
                            ExcelSheet.Cells[excelRow, cIndexHeader].Font.Bold = true;
                            ExcelSheet.Cells[excelRow, cIndexHeader].Interior.Color = Color.LightSlateGray;
                            ExcelSheet.Cells[excelRow, cIndexHeader].Font.Color = Color.White;
                        }
                    }
                    excelRow++;

                    var groupedData = grdItemList.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow)
                        .GroupBy(r => new
                        {
                            GroupName = r.Cells["Group Name"].Value?.ToString(),
                            SubGroupName = r.Cells["Subgroup Name"].Value?.ToString(),
                            BrandName = r.Cells["Brand Name"].Value?.ToString()
                        });
                    int serialNo = 1;
                    foreach (var grp in groupedData)
                    {
                        ExcelSheet.Cells[excelRow, 1].Value = $"Group : {grp.Key.GroupName}";
                        ExcelSheet.Cells[excelRow, 3].Value = $"SubGroup : {grp.Key.SubGroupName}";
                        ExcelSheet.Cells[excelRow, 6].Value = $"Brand : {grp.Key.BrandName}";

                        Excel.Range groupHeaderRange = ExcelSheet.Range[ExcelSheet.Cells[excelRow, 1], ExcelSheet.Cells[excelRow, colCount]];
                        //groupHeaderRange.Font.Bold = true;
                        groupHeaderRange.Font.Name = "Uni Ila.Sundaram-03";
                        groupHeaderRange.Font.Size = 11.75;
                        excelRow++;

                        foreach (var row in grp)
                        {
                            ExcelSheet.Cells[excelRow, 1].Value = serialNo;
                            ExcelSheet.Cells[excelRow, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            serialNo++;

                            int cIndex = 1;
                            foreach (DataGridViewColumn col in grdItemList.Columns)
                            {
                                if (col.Visible && col.Name != "S.No.")
                                {
                                    cIndex++;
                                    ExcelSheet.Cells[excelRow, cIndex].Value = row.Cells[col.Index].Value;

                                    if (col.Name == "P.I Code")
                                    {
                                        ExcelSheet.Columns[cIndex].ColumnWidth = 12;
                                    }
                                    object cellValue = row.Cells[col.Index].Value;
                                    if (col.Name == "Last R.Rate" || col.Name == "Last W.Rate" || col.Name == "Live R.Rate" || col.Name == "Live W.Rate")
                                    {
                                        ExcelSheet.Cells[excelRow, cIndex].Value = cellValue != null && double.TryParse(cellValue.ToString(), out double num) ? num : 0;
                                        ExcelSheet.Cells[excelRow, cIndex].NumberFormat = "0.00";
                                        ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                                    }
                                    else
                                    {
                                        ExcelSheet.Cells[excelRow, cIndex].Value = cellValue;
                                    }
                                    if (col.Name == "Teller" || col.Name == "Last Updated By")
                                    {
                                        ExcelSheet.Columns[cIndex].ColumnWidth = 35;
                                    }
                                    else if (col.Name == "Product")
                                    {
                                        ExcelSheet.Columns[cIndex].ColumnWidth = 40;
                                        Excel.Range productCell = ExcelSheet.Cells[excelRow, cIndex];
                                        productCell.Font.Name = "Uni Ila.Sundaram-03";
                                        productCell.Font.Size = 11.75;
                                    }
                                    else if (col.Name == "Unit")
                                    {
                                        ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                                    }
                                }
                            }
                            // Apply border to the entire row (all columns for the product row)
                            Excel.Range dataRowRange = ExcelSheet.Range[ExcelSheet.Cells[excelRow, 1], ExcelSheet.Cells[excelRow, colCount]];
                            dataRowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            dataRowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                            excelRow++;
                        }

                        excelRow++; 
                    }

                    //ExcelSheet.Columns.AutoFit();
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

        private void BtnPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                btnPrint.BackColor = Color.LemonChiffon;
            }
            finally
            {
                btnExport.Enabled = true;
            }
        }

        private void BtnPrint_Leave(object sender, EventArgs e)
        {
            try
            {
                btnPrint.BackColor = Color.Transparent;
            }
            finally
            {
                btnExport.Enabled = true;
            }
        }


        private void txtProduct_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtProduct.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyLockProduct = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_Product.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_Product.Visible == false)
                {
                    txtTeller.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_Product.Focus();
                }
                if (DGV_Product.CurrentCell == null && DGV_Product.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_Product.Focus();
                    int RowIndex = DGV_Product.CurrentCell.RowIndex;
                    int ClmIndex = DGV_Product.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLockProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyLockProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_Product.CurrentCell = DGV_Product.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProduct.Text = DGV_Product.Rows[RowIndex].Cells["Product Name"].Value.ToString();
                            }
                            txtProduct.Focus();
                            txtProduct.SelectionStart = txtProduct.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_Product.Rows.Count) DGV_Product.CurrentCell = DGV_Product.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_Product.Rows.Count))
                            {
                                txtProduct.Text = DGV_Product.Rows[RowIndex].Cells["Product Name"].Value.ToString();
                            }

                            txtProduct.Focus();
                            txtProduct.SelectionStart = txtProduct.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_Product.Rows.Count > 0)
                                {
                                    varUpDownKeyLockProduct = 1;
                                    udfnListviewLockProduct();
                                    DGV_Product.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProduct.Focus();
                    //txtProduct.SelectionStart = txtProduct.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProduct.SelectedText = true;
                        TextBox txtProduct = sender as TextBox;
                        txtProduct.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtTeller.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProduct_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProduct.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyLockProduct == 0)
                {
                    lblProductcode.Text = "0";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProduct.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 94;
                        objMR_Product.paraProductName = txtProduct.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_Product.Visible = true;
                                    DGV_Product.DataSource = objDs.Tables[0];
                                    DGV_Product.Columns["PRID"].Visible = false;
                                    DGV_Product.Columns["R.Rate"].Visible = false;
                                    DGV_Product.Columns["W.Rate"].Visible = false;
                                    DGV_Product.Columns["Location"].Visible = false;
                                    DGV_Product.Columns["Stock"].Visible = false;
                                    DGV_Product.Columns["Unit"].Visible = false;
                                    DGV_Product.Columns["Sales P.I Code"].Width = 120;
                                    DGV_Product.Columns["Product Name"].Width = 350;
                                    //DGV_Product.Columns["R.Rate"].Width = 80;
                                    //DGV_Product.Columns["W.Rate"].Width = 80;
                                    //DGV_Product.Columns["R.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    //DGV_Product.Columns["W.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    //DGV_Product.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_Product.BringToFront();
                                }
                                else
                                {
                                    DGV_Product.Visible = false;
                                    DGV_Product.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_Product.Visible = false;
                                DGV_Product.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_Product.Visible = false;
                            DGV_Product.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_Product.Visible = false;
                        DGV_Product.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_Product_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyLockProduct = 1;
                udfnListviewLockProduct();
                txtTeller.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_Product_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_Product.CurrentCell.RowIndex;
                    int ClmIndex = DGV_Product.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLockProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyLockProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_Product.CurrentCell = DGV_Product.Rows[RowIndex].Cells[ClmIndex];

                            txtProduct.Text = DGV_Product.SelectedRows[0].Cells["Product Name"].Value.ToString();

                            txtProduct.Focus();
                            txtProduct.SelectionStart = txtProduct.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_Product.Rows.Count) DGV_Product.CurrentCell = DGV_Product.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_Product.Rows.Count))
                            {
                                txtProduct.Text = DGV_Product.Rows[RowIndex].Cells["Product Name"].Value.ToString();
                            }

                            txtProduct.Focus();
                            txtProduct.SelectionStart = txtProduct.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_Product.Rows.Count > 0)
                                {
                                    varUpDownKeyLockProduct = 1;
                                    udfnListviewLockProduct();
                                    DGV_Product.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProduct = sender as TextBox;
                        txtProduct.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtTeller.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnLock_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                lvVerified1.Visible = false;
                btnLock.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnLock_Leave(object sender, EventArgs e)
        {
            try
            {
                btnLock.BackColor = Color.Transparent;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void btnProductSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdLockItems.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdLockItems.Rows.Count; i++)
                    {
                        grdLockItems.Rows[i].Cells[0].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_LockSearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdLockItems.DataSource = objDser.udfnGridSearchFilter(DGV_LockSearchGrid, grdLockItems);
                objDser.CloseConnection();
                grdLockItems.HorizontalScrollingOffset = DGV_LockSearchGrid.HorizontalScrollingOffset;
                //DGV_LockSearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_LockSearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                DGV_LockSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_LockSearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
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

        private void DGV_LockSearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdLockItems.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdLockItems.SortedColumn;
                ListSortDirection direction;
                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdLockItems.SortOrder == SortOrder.Ascending)
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
                grdLockItems.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
                DataGridViewColumn DGV = DGV_LockSearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                DGV_LockSearchGrid.HorizontalScrollingOffset = grdLockItems.HorizontalScrollingOffset;
                DGV_LockSearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_LockSearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdLockItems.ColumnCount > 0)
                {
                    grdLockItems.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_LockSearchGrid.HorizontalScrollingOffset = grdLockItems.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_LockSearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_LockSearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_LockSearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdLockItems.DataSource = objDser.udfnGridSearchFilter(DGV_LockSearchGrid, grdLockItems);
                objDser.CloseConnection();
                grdLockItems.HorizontalScrollingOffset = DGV_LockSearchGrid.HorizontalScrollingOffset;
                //DGV_LockSearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_LockSearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdLockItems.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_LockSearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdLockItems.Width > grdLockItems.HorizontalScrollingOffset && grdLockItems.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_LockSearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_LockSearchGrid.Invalidate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                if (txtProduct.Text.Trim() == "")
                {
                    string varMessage = objDServ.udfnGetMessages(100);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (Convert.ToInt32(lblProductId.Text) == 0)
                {
                    string varMessage = objDServ.udfnGetMessages(91);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }else if(Convert.ToString(txtTeller.Text).Trim() == "")
                {
                    epRateChange.SetError(txtTeller, "Please enter valid teller name");
                    txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerifier.ShowAlways = true;
                    tpVerifier.Show("Please enter valid teller name", txtTeller, 5000);
                    return;
                }
                udfnLockUnLock(1, lblProductId.Text);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            try
            {
                string productCodeString = GetCheckedProductCodes();

                SPDataService objDServ = new SPDataService();
                if (string.IsNullOrEmpty(productCodeString))
                {
                    string varMessage = objDServ.udfnGetMessages(80);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pbUnLockTellerName = "";
                MainForm.objCP_ProductLockTeller = new CP_ProductLockTeller();
                MainForm.objCP_ProductLockTeller.ShowDialog();
                if (pbUnLockTellerName == "")
                {
                    return;
                }
                udfnLockUnLock(2, productCodeString);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private string GetCheckedProductCodes()
        {
            List<string> selectedProducts = new List<string>();
            try
            {
                foreach (DataGridViewRow row in grdLockItems.Rows)
                {
                    var chkCell = row.Cells["clmCheck"];
                    bool isChecked = chkCell.Value != null && (bool)chkCell.Value;

                    if (!isChecked)
                        continue;
                    var codeCell = row.Cells["PRID"];
                    if (codeCell.Value != null)
                    {
                        selectedProducts.Add(codeCell.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return string.Join(",", selectedProducts);
        }

        public void udfnLockUnLock(int varFlag, string varProductCodes)
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                string result = "";
                result = objspdservice.udfnProductMaster(19, Convert.ToInt32(lblProductId.Text), "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "", 0, null, varFlag, varProductCodes, 0, 0, 0, 0, 0, null, "", "", "", 0, "", "", 0, 0, 0, null, 0, 0, 0, 0, null, 0, "", "", txtTeller.Text.Trim(), pbUnLockTellerName);
                string[] varvalue = result.Split('~');
                objspdservice.CloseConnection();
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    udfnClear();
                    udfnLockList();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                lblProductId.Text = "0";
                txtProduct.Text="";
                txtRRate.Text = "";
                txtWRate.Text = "";
                txtLocation.Text = "";
                txtStock.Text = "";
                txtUnit.Text = "";
                txtTeller.Text = "";
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
                MainForm.objStart = new DEF_Start();
                MainForm.objStart.MdiParent = this.ParentForm;
                MainForm.objStart.Show();
                this.Close();
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

        private void btnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnProductUnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdLockItems.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdLockItems.Rows.Count; i++)
                    {
                        grdLockItems.Rows[i].Cells[0].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdLockItems_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdLockItems.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_LockSearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdLockItems.Width > grdLockItems.HorizontalScrollingOffset && grdLockItems.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_LockSearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_LockSearchGrid.Invalidate();
                    udfnscrollVisible(DGV_LockSearchGrid, grdLockItems);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tbRateChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbRateChangeLockItem.SelectedIndex == 1)
                {
                    udfnLockList();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLockList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV_LockSearchGrid.DataSource = null;
                picLoaderLock.Visible = true;
                picLoaderLock.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdLockItems.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 95;
                objDs = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFoundLock.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFoundLock.Visible = false;
                            lblNoRecordsFoundLock.SendToBack();
                            grdLockItems.DataSource = objDs.Tables[0];
                            grdLockItems.Columns["PRID"].Visible = false;
                            grdLockItems.Columns["Product Name"].Visible = false;
                            grdLockItems.Columns["S.No."].Width = 50;
                            //grdLockItems.Columns["Product Name"].Width = 350;
                            grdLockItems.Columns["Product Name in Tamil"].Width = 350;
                            grdLockItems.Columns["Sales P.I Code"].Width = 110;
                            grdLockItems.Columns["Teller"].Width = 130;
                            grdLockItems.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdLockItems.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdLockItems.Columns["clmCheck"].Visible = true;
                            grdLockItems.Columns["clmCheck"].ReadOnly = false;
                            grdLockItems.Columns["S.No."].ReadOnly = true;
                        }
                        else
                        {
                            lblNoRecordsFoundLock.Visible = true;
                            lblNoRecordsFoundLock.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordsFoundLock.Visible = true;
                        lblNoRecordsFoundLock.BringToFront();
                    }
                }
                udfnLockSearchGridHead();
                grdLockItems.Columns["Sales P.I Code"].ReadOnly = true;
                grdLockItems.Columns["Product Name in Tamil"].ReadOnly = true;
                grdLockItems.Columns["Teller"].ReadOnly = true;
                if (lblNoRecordsFoundLock.Visible == true)
                {
                    dtDefaultGrid = objDs.Tables[0];
                    udfnDefaultLockSearchGrid();
                }
                else
                {
                    DGV_LockSearchGrid.ScrollBars = ScrollBars.Vertical;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoaderLock.Visible = false;
                picLoaderLock.SendToBack();
            }
        }
        public void udfnDefaultLockSearchGrid()
        {
            try
            {
                DGV_LockSearchGrid.DataSource = dtDefaultGrid;
                DGV_LockSearchGrid.Columns["PRID"].Visible = false;
                DGV_LockSearchGrid.Columns["S.No."].Width = 50;
                DGV_LockSearchGrid.Columns["Product Name in Tamil"].Width = 350;
                DGV_LockSearchGrid.Columns["Sales P.I Code"].Width = 110;
                DGV_LockSearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnLockSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridLockSearchHeading(grdLockItems, DGV_LockSearchGrid);
                    DGV_LockSearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdLockItems.Columns)
                    {
                        DGV_LockSearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_LockSearchGrid.Rows.Clear();
                    DGV_LockSearchGrid.Rows.Add();
                    //DGV_LockSearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                    DGV_LockSearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                    DGV_LockSearchGrid.Columns[2].DefaultCellStyle.NullValue = null;
                    for (int i = 1; i < visibleColumns.Count; i++)
                    {
                        DGV_LockSearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_LockSearchGrid.Columns["S.No."].ReadOnly = true;
                    DGV_LockSearchGrid.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridLockSearchHeading(DataGridView dgv1, DataGridView dgv2)
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
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void txtTeller_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.LemonChiffon;
                udfnGridNull((Control)sender);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvVerified1.Items.Count == 0 || txtTeller.Text == "")
                    {
                        lvVerified1.Visible = false;
                    }
                    else
                    {
                        lvVerified1.Focus();
                    }
                    if (lvVerified1.Items.Count > 0)
                    {
                        lvVerified1.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnLock.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTeller.Text.Length > 0)
                {
                    lvVerified1.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(14, txtTeller.Text.Trim(), 0, "", 1, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["EMP_Name"].ToString(), objDs.Tables[0].Rows[i]["EMPID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvVerified1.Columns[1].Width = 0;
                                    lvVerified1.Items.Add(objList);
                                }
                                lvVerified1.BringToFront();
                                lvVerified1.Visible = true;
                            }
                            else
                            {
                                lvVerified1.Visible = false;
                            }
                        }
                        else
                        {
                            lvVerified1.Visible = false;
                        }
                    }
                    else
                    {
                        lvVerified1.Visible = false;
                    }
                }
                else
                {
                    lvVerified1.Visible = false;
                    lvVerified1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvVerified1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnVerified1();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvVerified1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnVerified1();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVerified1()
        {
            try
            {
                if (txtTeller.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvVerified1.SelectedItems[0];
                    txtTeller.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvVerified1.Visible = false;
                txtTeller.Focus();
            }
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

        public void udfnGroupAutocomplete()
        {
            try
            {
                if (txtGroup.Text.Trim() != "")
                {
                    lblGroupCode.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRGID"].Value.ToString();
                    txtGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { 
                txtSubGroup.Focus();
            }
        }
        public void udfnSubGroupAutocomplete()
        {
            try
            {
                if (txtSubGroup.Text.Trim() != "")
                {
                    lblSubGroupCode.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSGID"].Value.ToString();
                    txtSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();
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
                    lblBrandCode.Text = DGV_FilterBrand.SelectedRows[0].Cells["BDID"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtProductName.Focus(); 
            }
        }
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text.Trim() != "")
                {
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                }
                btnView.Focus();
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
        public void udfnListviewLockProduct()
        {
            try
            {
                if (txtProduct.Text.Trim() != "")
                {
                    txtProduct.Text = DGV_Product.SelectedRows[0].Cells["Product Name"].Value.ToString();
                    txtRRate.Text = DGV_Product.SelectedRows[0].Cells["R.Rate"].Value.ToString();
                    txtWRate.Text = DGV_Product.SelectedRows[0].Cells["W.Rate"].Value.ToString();
                    txtLocation.Text = DGV_Product.SelectedRows[0].Cells["Location"].Value.ToString();
                    txtStock.Text = DGV_Product.SelectedRows[0].Cells["Stock"].Value.ToString();
                    txtUnit.Text = DGV_Product.SelectedRows[0].Cells["Unit"].Value.ToString();
                    lblProductId.Text = DGV_Product.SelectedRows[0].Cells["PRID"].Value.ToString();
                }
                txtTeller.Focus();
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

    }
}
