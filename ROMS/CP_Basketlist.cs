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
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    //Created By:Sathish ; Created On:-11/08/2023
    public partial class CP_Basketlist : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public string varUserID = "";
        public int MenuCode = 0;
        string privilege = "";
        Boolean BlnSearchImageYN = false;
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        private ToolTip tpSize = new ToolTip();

        public CP_Basketlist()
        {
            InitializeComponent();
            windowControl.Initialize(tsBasketList, this);
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objCP_Basket = new CP_Basket();
                    MainForm.objCP_Basket.FormBorderStyle = FormBorderStyle.FixedSingle;
                    MainForm.objCP_Basket.ShowDialog();
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
                    if (grdBasketList.SelectedRows.Count > 0)
                    {
                        string varResult = ""; int varBasketID = 0;
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                             
                            varResult = ""; 
                            varBasketID= Convert.ToInt32(grdBasketList.SelectedRows[0].Cells["ID"].Value);
                            SPDataService objspdservice = new SPDataService();
                            MR_Basket objMR_Basket = new MR_Basket();
                            objMR_Basket.paraViewType = 2;
                            objMR_Basket.paraBasketId = varBasketID; 
                            varResult = objspdservice.udfnBasket(objMR_Basket);
                            objspdservice.CloseConnection();
                            if (varResult.Split('~')[0] == "3")
                            {
                                MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                udfnList();
                            }
                            else { MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
                    if (grdBasketList.SelectedRows.Count > 0)
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        MainForm.objCP_Basket = new CP_Basket();  
                        MainForm.objCP_Basket.pbBasketID = Convert.ToInt32(grdBasketList.SelectedRows[0].Cells["ID"].Value); 
                        MainForm.objCP_Basket.ShowDialog();
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
        }
        public void udfnList()
        {
            try
            {
                RPTViewer.Visible = false;
                RPTViewer.SendToBack();
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdBasketList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                MR_Basket objMR_Basket = new MR_Basket();
                objMR_Basket.paraViewType = 0; 
                objMR_Basket.paraTypeId =Convert.ToInt16(cmbBasketType.SelectedValue); 
                objDs = objspservice.udfnBasketList(objMR_Basket); 
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdBasketList.DataSource = objDs.Tables[0];
                            grdBasketList.Columns["clmPrint"].Visible = true;
                            grdBasketList.Columns["ID"].Visible = false; 
                            grdBasketList.Columns["TypeId"].Visible = false; 
                            grdBasketList.Columns["S.No."].Width = 50; 
                            grdBasketList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                            grdBasketList.Columns["Basket No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            grdBasketList.Columns["clmPrint"].Visible = false;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        grdBasketList.Columns["clmPrint"].Visible = false;
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
                else
                {
                    DGV_SearchGrid.ScrollBars = ScrollBars.Vertical;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalCount.Text = Convert.ToString(grdBasketList.Rows.Count);
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
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Basket Type"].Width = 200;
                DGV_SearchGrid.Columns["Basket No."].Width = 100; 
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
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
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdBasketList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdBasketList.Columns)
                    {
                        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add(); 
                    DGV_SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
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
                    int ColIndex = 0;
                    dgv2.Rows.Clear();
                    dgv2.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                        {
                            //dgv2.Rows[rowIndex].Visible = false;
                            BlnSearchImageYN = true;
                            ColIndex = i;
                            dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                            dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                            ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
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
        private void CP_Citylist_KeyDown(object sender, KeyEventArgs e)
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
                if(((Control.ModifierKeys & Keys.Control)==Keys.Control)&& (e.KeyCode == Keys.D))
                {
                    tsbDelete_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    //MainForm objMainForm = new MainForm();
                    //objMainForm.udfnCloseChildForms();
                    //MainForm.objStart = new DEF_Start();
                    //MainForm.objStart.MdiParent = this.ParentForm;
                    //MainForm.objStart.Show();
                    //this.Close();
                    windowControl?.TriggerClose();
                }
                if(e.KeyCode==Keys.Delete)
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
        private void CP_Citylist_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 501;
                udfnDropDownLoad();
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
        private void udfnDropDownLoad()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID IN (0,175) AND MSTID<>-1  ORDER BY MSTID ASC", "MST_DisplayText,MSTID", cmbBasketType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79) AND MSTID NOT IN (0,301) ORDER BY ISNULL(MST_OrderID,0) ASC", "MST_DisplayText,MSTID", cmbLabelsize, "", "MST_DisplayText", "MSTID");
                objDataBind = null; 
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
                tssNew.Visible = privilege.Contains("2");
                tsbEdit.Visible = privilege.Contains("3");
                tssEdit.Visible = privilege.Contains("3");
                tsbDelete.Visible = privilege.Contains("4");   
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdCityList_DoubleClick(object sender, EventArgs e)
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
        private void GrdCityList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                udfnEdit();
            }
        }
        private void GrdCityList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdBasketList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdBasketList.Rows[i].Cells["StatusID"].Value) == "1")
                    {
                        grdBasketList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdBasketList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdBasketList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdBasketList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    grdBasketList.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }           
        }
        private void GrdCityList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdBasketList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdBasketList.Width > grdBasketList.HorizontalScrollingOffset && grdBasketList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdBasketList);
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
                var vScrollbar = grdCityList.Controls.OfType<VScrollBar>().First();
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
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdBasketList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdBasketList);
                objDser.CloseConnection();
                grdBasketList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
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
                    if (DGV_SearchGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Name != "Boolean")
                    {
                        if (e.ColumnIndex == 1)
                        {
                            DGV_SearchGrid.Rows[e.RowIndex].Cells[3].Value = null;
                            DGV_SearchGrid.Rows[e.RowIndex].Cells[3] = new DataGridViewTextBoxCell();
                            DGV_SearchGrid.Rows[e.RowIndex].Cells[3].Value = "";
                            DGV_SearchGrid.Rows[e.RowIndex].Cells[3].ReadOnly = true;

                        }
                    }

                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdBasketList.ColumnCount > 0)
                {
                    grdBasketList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdBasketList.HorizontalScrollingOffset;
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
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdBasketList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdBasketList.Width > grdBasketList.HorizontalScrollingOffset && grdBasketList.HorizontalScrollingOffset > 0)
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
        private void CP_Citylist_DoubleClick(object sender, EventArgs e)
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

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdBasketList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdBasketList.SortedColumn;
                ListSortDirection direction;
                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdBasketList.SortOrder == SortOrder.Ascending)
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
                grdBasketList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                DGV_SearchGrid.HorizontalScrollingOffset = grdBasketList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_SearchGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
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
                grdBasketList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdBasketList);
                objDser.CloseConnection();
                grdBasketList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalCount.Text = Convert.ToString(grdBasketList.Rows.Count);
            }
        }

        private void cmbBasketType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grbFilterByUser_Enter(object sender, EventArgs e)
        {

        }

        private void cmbBasketType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBasketType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbBasketType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbBasketType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmbBasketType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBasketType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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

        private void btnView_Leave(object sender, EventArgs e)
        {

        }

        private void grdBasketList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdBasketList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPrint":
                            try
                            {
                                if (Convert.ToInt32(cmbLabelsize.SelectedValue) != -1)
                                {
                                    epBasket.Clear();
                                    string BSKID = "0", TypeID = "0";
                                    BSKID = Convert.ToString(grdBasketList.SelectedRows[0].Cells["ID"].Value.ToString());
                                    TypeID = Convert.ToString(grdBasketList.SelectedRows[0].Cells["TypeId"].Value.ToString());
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
                                        if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 302)
                                        {
                                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Basket_50x35.rpt");
                                        }
                                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 268)
                                        {
                                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Basket_50x60.rpt");
                                        }
                                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269)
                                        {
                                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Basket_100x70.rpt");
                                        }
                                        varHeader = "Basket";
                                        objBillreport.SetParameterValue("paraBasketId", Convert.ToInt32(BSKID));
                                        objBillreport.SetParameterValue("paraTypeId", Convert.ToInt32(TypeID));
                                        objValidation.CrySqlConnection(objBillreport);
                                        MainForm.objReportLoad = new ReportLoad();
                                        MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                        MainForm.objReportLoad.Text = varHeader;
                                        MainForm.objReportLoad.ShowDialog();
                                    }
                                }
                                else
                                {
                                    epBasket.SetError(cmbLabelsize, "Please select size.");
                                    cmbLabelsize.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpSize.ShowAlways = true;
                                    tpSize.Show("Please select size.", cmbLabelsize, 5000);
                                    cmbLabelsize.Focus();
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

        private void btnView_Enter(object sender, EventArgs e)
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

        private void btnView_Leave_1(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.White ;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) != -1)
                {
                    udfnPrint();
                }
                else
                {
                    epBasket.SetError(cmbLabelsize, "Please select size.");
                    cmbLabelsize.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSize.ShowAlways = true;
                    tpSize.Show("Please select size.", cmbLabelsize, 5000);
                    cmbLabelsize.Focus();
                }
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
                epBasket.Clear();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varprint = 0;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                MR_Basket objMR_Basket = new MR_Basket();
                objMR_Basket.paraViewType = 3;
                objMR_Basket.paraTypeId = Convert.ToInt16(cmbBasketType.SelectedValue);
                objDs = objspservice.udfnBasketList(objMR_Basket);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varprint = 1;
                        }
                    }
                }
                if (varprint == 1)
                {
                    btnPrint.Enabled = false;
                    label1.Focus();
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 302)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Basket_50x35.rpt");
                    }
                    else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 268)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Basket_50x60.rpt");
                    }
                    else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Basket_100x70.rpt");
                    }
                    objBillreport.SetParameterValue("paraBasketId", 0);
                    objBillreport.SetParameterValue("paraTypeId", Convert.ToInt32(cmbBasketType.SelectedValue));
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                }
                else
                {
                    DGV_SearchGrid.Columns.Clear();
                    grdBasketList.DataSource = null;
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
                btnPrint.Enabled = true;
                picLoader.Visible = false;
                picLoader.SendToBack();
            }
        }

        private void cmbLabelsize_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbLabelsize.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbLabelsize_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
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

        private void cmbLabelsize_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbLabelsize_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbLabelsize.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
