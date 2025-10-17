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
    public partial class INV_StockTransferList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        MainForm objMainForm = new MainForm();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public string varUserID = "";
        public int varUpDownKey = 0, varUpDownKeyLocation = 0;
        Boolean BlnSearchImageYN = false;
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public INV_StockTransferList()
        {
            InitializeComponent();
            windowControl.Initialize(tsStockTransferList, this);
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objINV_StockTransfer = new INV_StockTransfer();
                    MainForm.objINV_StockTransfer.MdiParent = this.ParentForm;
                    MainForm.objINV_StockTransfer.EditFlag = 0;
                    MainForm.objINV_StockTransfer.Show();
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);

                }
            }
        } 

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        } 
        private void DGV_SearchGrid_Sorted(object sender, EventArgs e)
        {

        }

     
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdStockTransfer.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdStockTransfer.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn && grdStockTransfer.SortOrder == SortOrder.Ascending)
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
                        grdStockTransfer.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                        DGV_SearchGrid.HorizontalScrollingOffset = grdStockTransfer.HorizontalScrollingOffset;
                        DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    }
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
                    int offSetValue = grdStockTransfer.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdStockTransfer.Width > grdStockTransfer.HorizontalScrollingOffset && grdStockTransfer.HorizontalScrollingOffset > 0)
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
        public void udfnscrollVisible(DataGridView DGV,DataGridView grdStockTransfer)
        {
            try
            {
                var vScrollbar = grdStockTransfer.Controls.OfType<VScrollBar>().First();
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
                            if (DGV_SearchGrid.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                            {
                                DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                            }
                            else { DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = ""; }
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

        private void INV_StockTransferList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    TsbEdit_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D))
                {
                    if (Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["StatusID"].Value) == 32 || Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["Product STSID"].Value) == 0)
                    {
                        TsbDelete_Click(sender, e);
                    }
                }
                //if (e.KeyCode == Keys.Escape)
                //{
                //    MainForm.objStart = new DEF_Start();
                //    MainForm.objStart.MdiParent = this.ParentForm;
                //    MainForm.objStart.Show();   
                //    this.Close();
                //}
                if (e.KeyCode == Keys.Escape)
                {
                    windowControl?.TriggerClose();
                }
                if (e.KeyCode == Keys.Delete)
                {
                    if (Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["StatusID"].Value) == 32 || Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["Product STSID"].Value) == 0)
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

        private void INV_StockTransferList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 303;
                udfnCmbConcern();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (6) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                cmbStatus.SelectedValue = 0; 
                dpTrannsferFromDate.Text = Convert.ToString(MainForm.pbCurrentDate);
                dpTrannsferFromDate.MinDate = MainForm.pbFYStartDate;
                dpTrannsferFromDate.MaxDate = MainForm.pbCurrentDate;
                dpTransferToDate.MaxDate = MainForm.pbCurrentDate;
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                this.ActiveControl = txtSLocation;
                //tsbDelete.Visible = true;
                udfnList();
                udfnQueueCount();
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
                tssDelete.Visible = privilege.Contains("4"); 
                btnExport.Visible = privilege.Contains("6");
                tsbQue.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 30 && sp.EditAccess.Split(',').Contains("9"));
                tsbQueueCount.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 30 && sp.EditAccess.Split(',').Contains("9")); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnQueueCount()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                TRN_StockRequest objTRNG_StockRequest = new TRN_StockRequest();
                objTRNG_StockRequest.ViewType = 7;
                objDs = objspservice.udfnStockRequestList(objTRNG_StockRequest);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            tsbQueueCount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["QueueCount"]);
                            //lblQueueCount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["QueueCount"]);
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
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                btnView.Enabled = false;
                lblProductNamePICode.Focus();
                udfnList();
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
                /* Check source stock location is valid or not*/
                if (txtSLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsSalesLoc = new DataSet();
                    SPDataService objDServ5 = new SPDataService();
                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 14;
                    objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Location.paraLocationName = txtSLocation.Text.Trim();
                    objDsSalesLoc = objDServ5.udfnStockLocationList(objMR_Location);
                    objDServ5.CloseConnection();
                    //objDsSalesLoc = objDServ5.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSLocation.Text.Trim(), 0, 0, 0,"","",0);
                    if (objDsSalesLoc != null)
                    {
                        if (objDsSalesLoc.Tables.Count > 0)
                        {
                            if (objDsSalesLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_PurLocation = Convert.ToString(objDsSalesLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblSLocation.Text = Convert.ToString(varId_PurLocation);
                }
                else
                {
                    lblSLocation.Text = "0";
                }
                if(txtProductNamePICode.Text=="")
                {
                    lblProduct.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdStockTransfer.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnStockTransferList(0, 0, Convert.ToInt32(cmbConcern.SelectedValue), Convert.ToInt32(lblSLocation.Text), 0, Convert.ToInt32(lblProduct.Text), Convert.ToInt32(cmbStatus.SelectedValue), dpTrannsferFromDate.Text, dpTransferToDate.Text, 0, 0, MainForm.pbUserMappedLocationIds);
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
                            grdStockTransfer.DataSource = objDs.Tables[0];
                            grdStockTransfer.Columns["clmPrint"].Visible = true;
                            grdStockTransfer.Columns["SLID"].Visible = false;
                            grdStockTransfer.Columns["ConcernID"].Visible = false;
                            grdStockTransfer.Columns["StatusID"].Visible = false;
                            grdStockTransfer.Columns["Product STSID"].Visible = false;
                            grdStockTransfer.Columns["STRID"].Visible = false;
                            grdStockTransfer.Columns["SRQID"].Visible = false;
                            grdStockTransfer.Columns["Transfer Qty"].Visible = false;
                            grdStockTransfer.Columns["STR_TransactionType"].Visible = false;
                           //grdStockTransfer.Columns["Product STSID"].Width = 100;
                            grdStockTransfer.Columns["S.No."].Width = 50;
                            grdStockTransfer.Columns["clmPrint"].Width = 50;
                            grdStockTransfer.Columns["Status"].Width = 120;
                            grdStockTransfer.Columns["Source"].Width = 120;
                            grdStockTransfer.Columns["Created By"].Width = 100;
                            grdStockTransfer.Columns["Created On"].Width = 150;
                            grdStockTransfer.Columns["Transaction Type"].Width = 150;
                            grdStockTransfer.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockTransfer.Columns["Transfer Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockTransfer.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockTransfer.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                        {
                            grdStockTransfer.Columns["clmPrint"].Visible = false;
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        grdStockTransfer.Columns["clmPrint"].Visible = false;
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    grdStockTransfer.Columns["clmPrint"].Visible = false;
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
                grdStockTransfer.ClearSelection();
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
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["SLID"].Visible = false;
                DGV_SearchGrid.Columns["ConcernID"].Visible = false;
                DGV_SearchGrid.Columns["StatusID"].Visible = false;
                DGV_SearchGrid.Columns["STRID"].Visible = false;
                DGV_SearchGrid.Columns["Product STSID"].Visible = false;
                DGV_SearchGrid.Columns["STR_TransactionType"].Visible = false;
                DGV_SearchGrid.Columns["Transfer Qty"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Transaction Type"].Width = 150;
                DGV_SearchGrid.Columns["Status"].Width = 120;
                DGV_SearchGrid.Columns["Source"].Width = 120;
                DGV_SearchGrid.Columns["SRQID"].Visible = false;
                DGV_SearchGrid.Columns["Created By"].Width = 100;
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
                    udfnGridSearchHeading(grdStockTransfer, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdStockTransfer.Columns)
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
                    if (lblNoRecordsFound.Visible == false)
                    {
                        DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    }
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
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                DGV_FilterLocation.Visible = false;
                DGV_FilterLocation.DataSource = null;
                //lvProduct.Visible = false;
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
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpTrannsferFromDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTrannsferFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpTrannsferFromDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTrannsferFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpTransferToDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTrannsferFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpTrannsferFromDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTransferToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpTransferToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTransferToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTransferToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpTransferToDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductNamePICode_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterLocation.Visible = false;
                DGV_FilterLocation.DataSource = null;
                txtProductNamePICode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductNamePICode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                /*
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvProduct.Items.Count == 0 || txtProductNamePICode.Text == "")
                    {
                        btnView.Focus();
                        lvProduct.Visible = false;
                    }
                    else
                    {
                        lvProduct.Focus();
                    }
                    if (lvProduct.Items.Count > 0)
                    {
                        lvProduct.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                }*/
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
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
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                            }
                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                                    txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductNamePICode.Focus();
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
                        cmbStatus.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductNamePICode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductNamePICode.BackColor = Color.White;
                if(txtProductNamePICode.Text=="")
                {
                    lblProduct.Text = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                lvProduct.Visible = false;
                txtSLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSLocation_KeyDown(object sender, KeyEventArgs e)
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
                    txtProductNamePICode.Focus();
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
                                txtSLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtSLocation.Focus();
                            txtSLocation.SelectionStart = txtSLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtSLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSLocation.Focus();
                            txtSLocation.SelectionStart = txtSLocation.Text.Length;
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
                    txtSLocation.Focus();
                    //txtSLocation.SelectionStart = txtSLocation.Text.Length;
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
                        txtProductNamePICode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSLocation.BackColor = Color.White;
                if(txtSLocation.Text=="")
                {
                    lblSLocation.Text = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSLocationEvent();
                    txtProductNamePICode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSLocationEvent();
                txtProductNamePICode.Focus();
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
                if (txtSLocation.Text != "")
                {
                    lblSLocation.Text = Convert.ToString(DGV_FilterLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtSLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int varViewType = 0;
                if(Convert.ToInt32(cmbConcern.SelectedValue)==0)
                {
                    varViewType = 13;
                }
                else
                {
                    varViewType = 11;
                }
                if (varUpDownKeyLocation == 0)
                {
                    if (txtSLocation.Text.Length > 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 27;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtSLocation.Text;
                        objMR_Location.ParaFromDate = dpTrannsferFromDate.Text;
                        objMR_Location.ParaToDate = dpTransferToDate.Text;
                        objMR_Location.paraUserLocations = MainForm.pbUserMappedLocationIds;
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(27, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSLocation.Text, 0, 0, 0, dpTrannsferFromDate.Text, dpTransferToDate.Text, 0);
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
                                    DGV_FilterLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterLocation.Columns["SL_EName"].Width = 180;
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
        }
        private void DpTrannsferFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpTrannsferFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpTransferToDate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockTransfer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                udfnEdit(0);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnEdit(int EditFlag)
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (EditFlag == 0)
                    {
                        if (grdStockTransfer.SelectedRows.Count > 0)
                        {
                            picLoader.Visible = true;
                            picLoader.BringToFront();
                            Application.DoEvents();
                            MainForm.objINV_StockTransfer = new INV_StockTransfer();
                            MainForm.objINV_StockTransfer.MdiParent = ParentForm;
                            //MainForm.objINV_StockTransfer.btnSave.Text = "Update";
                            MainForm.objINV_StockTransfer.EditFlag = 0;
                            MainForm.objINV_StockTransfer.varStockTransferID = Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["STRID"].Value);
                            MainForm.objINV_StockTransfer.varSTSRQID = Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["SRQID"].Value);
                            MainForm.objINV_StockTransfer.varStatusID = Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["StatusID"].Value);
                            MainForm.objINV_StockTransfer.varTransactionType = Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["STR_TransactionType"].Value);
                            MainForm.objINV_StockTransfer.Show();
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
                    picLoader.Visible = false;
                    picLoader.SendToBack();
                }
            }
        }
        public void udfndelete()
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    DataTable dtStock = new DataTable();
                    dtStock.TableName = "TRN_StockTransfer_Product_AutoComplete";
                    dtStock.Columns.Add("STK_PRID", typeof(int));
                    dtStock.Columns.Add("STK_MRP", typeof(string));
                    dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                    dtStock.Columns.Add("STK_BatchNo", typeof(string));
                    dtStock.Columns.Add("STK_UTID", typeof(string));
                    dtStock.Columns.Add("STK_QTY", typeof(string));
                    dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                    dtStock.Columns.Add("STK_Dest_SLID", typeof(string));
                    dtStock.Columns.Add("STK_Dest_RKID", typeof(string));
                    dtStock.Columns.Add("STK_ProType", typeof(int));
                    dtStock.Columns.Add("STK_STSID", typeof(int));
                    if (grdStockTransfer.SelectedRows.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SPDataService objDser = new SPDataService();
                            string varResult = objDser.udfnStockTransfer(2, Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["STRID"].Value.ToString()), 0, "", 0, 0, "", Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["StatusID"].Value.ToString()), "Stock Transfer Delete", dtStock, 0, 0, 0, 0);
                            objDser.CloseConnection();
                            if (varResult.Split('~')[0] == "3")
                            {
                                if (varResult.Split('~')[1] == "1")
                                {
                                    MainForm.objCP_Verify = new CP_Verify();
                                    MainForm.objCP_Verify.ShowDialog();
                                    varUserID = MainForm.objCP_Verify.varUserId;
                                    if (MainForm.objCP_Verify.flag == 1)
                                    {
                                        objDser = new SPDataService();
                                        varResult = objDser.udfnStockTransfer(2, Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["STRID"].Value.ToString()), 0, "", 0, 0, "", Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["StatusID"].Value.ToString()), "Stock Transfer Delete", dtStock, 1, 0, 0, Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["SRQID"].Value.ToString()));
                                        objDser.CloseConnection();
                                        if (varResult.Split('~')[0] == "3")
                                        {
                                            MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            udfnList();
                                        }
                                        else { MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                    }
                                }
                            }
                            else if (varResult.Split('~')[0] == "4")
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
        }
        private void GrdStockTransfer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdStockTransfer.Rows.Count; i++)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    if (Convert.ToString(grdStockTransfer.Rows[i].Cells["StatusID"].Value) == "21")
                    {
                        grdStockTransfer.Rows[i].Cells["Status"].Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        grdStockTransfer.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdStockTransfer.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdStockTransfer.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    //if (Convert.ToString(grdStockTransfer.Rows[i].Cells["SRQID"].Value) == "0")
                    //{
                        //DataGridViewCell cell2 = dataGridView.Rows[i].Cells["clmPrint"];
                        //cell2.Value = new Bitmap(1, 1);
                        //cell2.ReadOnly = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdStockTransfer.ClearSelection();
            }
        }

        private void GrdStockTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit(0);
                }
                //if (e.KeyCode == Keys.Delete)
                //{
                //    udfndelete();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockTransfer_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdStockTransfer.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdStockTransfer.Width > grdStockTransfer.HorizontalScrollingOffset && grdStockTransfer.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdStockTransfer);
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
                grdStockTransfer.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockTransfer);
                objDser.CloseConnection();
                grdStockTransfer.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError(); objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdStockTransfer.ColumnCount > 0)
                {
                    grdStockTransfer.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdStockTransfer.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
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
            grdStockTransfer.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockTransfer);
            objDser.CloseConnection();
            grdStockTransfer.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
        }
        private void GrdStockTransfer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbDelete_Click(object sender, EventArgs e)
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

        private void TxtProductNamePICode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    //lvProduct.Items.Clear();
                    DataSet objDs = new DataSet();
                    if (txtProductNamePICode.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 46;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraLocationId = Convert.ToInt32(lblSLocation.Text);
                        objMR_Product.paraProductName = txtProductNamePICode.Text;
                        objMR_Product.ParaFromDate = dpTrannsferFromDate.Text;
                        objMR_Product.ParaToDate = dpTransferToDate.Text;
                        SPDataService objspdservice = new SPDataService();
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    /*
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvProduct.Items.Add(objList);
                                    }
                                    lvProduct.Visible = true;
                                    lvProduct.BringToFront();
                                    lvProduct.Columns[0].Width = 150;
                                    lvProduct.Columns[1].Width = 250;
                                    lvProduct.Columns[2].Width = 250;
                                    lvProduct.Columns[3].Width = 0;
                                    */
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 330;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 420;
                                    DGV_FilterProduct.Columns["Unit"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 150;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 2;
                                    DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product English Name";
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                }
                                else
                                {
                                    DGV_FilterProduct.DataSource = null;
                                    DGV_FilterProduct.Visible = false;
                                    //lvProduct.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.DataSource = null;
                                DGV_FilterProduct.Visible = false;
                                //lvProduct.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.DataSource = null;
                            DGV_FilterProduct.Visible = false;
                            //lvProduct.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.DataSource = null;
                        DGV_FilterProduct.Visible = false;
                        //lvProduct.Visible = false;
                        //lvProduct.Items.Clear();
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
        private void lvProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnProductEvent();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void lvProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductEvent();
                    cmbStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductEvent()
        {
            try
            {
                if (txtProductNamePICode.Text != "")
                {
                    ListViewItem selectedItem = lvProduct.SelectedItems[0];
                    //varPICode = selectedItem.SubItems[0].Text;
                    txtProductNamePICode.Text = selectedItem.SubItems[1].Text;
                    //txtMRP.Text = selectedItem.SubItems[4].Text;
                    //txtExpiryDate.Text = selectedItem.SubItems[5].Text;
                    //txtBatchNo.Text = selectedItem.SubItems[6].Text;
                    //txtStockQty.Text = selectedItem.SubItems[7].Text;
                    lblProduct.Text = selectedItem.SubItems[3].Text;
                    //varUTID = selectedItem.SubItems[9].Text;
                    //varUnitSymbol = selectedItem.SubItems[10].Text;
                    //varMRP = selectedItem.SubItems[4].Text;
                    //varExpiryDate = selectedItem.SubItems[5].Text;
                    //varBatchNo = selectedItem.SubItems[6].Text;
                    //varProductCode = selectedItem.SubItems[8].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvProduct.Visible = false;
            }
        }

        private void TsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnEdit(0);
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
                btnExport.Enabled = false; 
                lblProductNamePICode.Focus();
                if ((grdStockTransfer.Rows.Count > 0))
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
                    ExcelSheet.Name = "Stock Transfer";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdStockTransfer.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Stock Transfer";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdStockTransfer.Columns)
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
                            else if (col.Name == "Source" || col.Name == "Destination" || col.Name == "Created On" || col.Name == "Status")
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
                            if (col.Name == "Entry Date")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            foreach (DataGridViewRow rowa in grdStockTransfer.Rows)
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

        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterLocation.Visible = false;
                DGV_FilterLocation.DataSource = null;
                //lvProduct.Visible = false;
                cmbStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbQue_Click(object sender, EventArgs e)
        {
            try
            {
                //MainForm.objINV_StockTransferQueue = new INV_StockTransferQueue();
                //objMainForm.OpenReportForm(ref MainForm.objINV_StockTransferQueue, "INV_StockTransferQueue", 303);
                //MainForm.objINV_StockTransferQueue.EditAccess = SpecialPermissions.Any(sp => sp.MUP_Code == 30 && sp.EditAccess.Split(',').Contains("10"));
                this.Close();
                MainForm.objINV_StockTransferQueue = new INV_StockTransferQueue();
                MainForm.objINV_StockTransferQueue.MdiParent = this.ParentForm;
                MainForm.objINV_StockTransferQueue.EditAccess = SpecialPermissions.Any(sp => sp.MUP_Code == 30 && sp.EditAccess.Split(',').Contains("10"));
                MainForm.objINV_StockTransferQueue.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDeleteHide()
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["StatusID"].Value) == 40 || Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["Product STSID"].Value) > 0)
                    {
                        tsbDelete.Visible = false;
                        tssDelete.Visible = false;
                    }
                    else
                    {
                        tsbDelete.Visible = true;
                        tssDelete.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        }
        private void GrdStockTransfer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    udfnDeleteHide();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void GrdStockTransfer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdStockTransfer.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPrint":
                            try
                            {
                                string STRID = "0";
                                STRID = Convert.ToString(grdStockTransfer.SelectedRows[0].Cells["STRID"].Value.ToString());
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
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_INV_Shop_Stock_Issued.rpt");
                                    varHeader = "Shop Stock Issued";

                                    objBillreport.SetParameterValue("paraStockTransferID", Convert.ToInt32(STRID));
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

        private void GrdStockTransfer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                udfnDeleteHide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                cmbStatus.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 1;
                udfnSLocationEvent();
                txtProductNamePICode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

                            txtSLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtSLocation.Focus();
                            txtSLocation.SelectionStart = txtSLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtSLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSLocation.Focus();
                            txtSLocation.SelectionStart = txtSLocation.Text.Length;
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
                        txtProductNamePICode.Focus();
                    }
                }
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
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                            }
                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                                    txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
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
