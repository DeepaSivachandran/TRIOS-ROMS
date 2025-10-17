using DocumentFormat.OpenXml.VariantTypes;
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
    public partial class CP_PurchaseList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable Deftable = new DataTable();
        ToolTip tpSupplier = new ToolTip();
        public Boolean BlnSearchImageYN = false;
        public int varDeleteFlag = 0;
        DateTime varmaxdate;
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public CP_PurchaseList()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tsPurchaseList, this);
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objCP_Purchase = new CP_Purchase();
                    MainForm.objCP_Purchase.MdiParent = this.ParentForm;
                    MainForm.objCP_Purchase.Show();
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

        public void udfnEdit()
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objCP_Purchase = new CP_Purchase();
                    MainForm.objCP_Purchase.btnSave.Text = "Save as Draft";
                    MainForm.objCP_Purchase.PbSTS = Convert.ToString(grdPurchaseEntryList.SelectedRows[0].Cells["STSID"].Value.ToString());
                    MainForm.objCP_Purchase.PbApprovalStsid = Convert.ToInt32(grdPurchaseEntryList.SelectedRows[0].Cells["PUR_Approval_STSID"].Value.ToString());
                    MainForm.objCP_Purchase.pbPurchaseno = Convert.ToString(grdPurchaseEntryList.SelectedRows[0].Cells["PURID"].Value.ToString());
                    MainForm.objCP_Purchase.lblstatusvalue.Text = Convert.ToString(grdPurchaseEntryList.SelectedRows[0].Cells["Pur Entry Full Status"].Value.ToString());
                    MainForm.objCP_Purchase.MdiParent = this.ParentForm;
                    MainForm.objCP_Purchase.Show();
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
                finally
                {
                    picLoader.Visible = false;
                }
            }
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                udfnDelete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDelete()
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (varDeleteFlag == 1)
                    {
                        if (grdPurchaseEntryList.SelectedRows.Count > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                string varorginator = "Purchase Deletion", result = "";

                                int varUserID = 0;


                                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                                objTRN_PurchaseEntry.ViewType = 2;
                                objTRN_PurchaseEntry.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                                objTRN_PurchaseEntry.paraIPAddress = MainForm.pbIpAddress;
                                objTRN_PurchaseEntry.paraOriginator = varorginator;
                                objTRN_PurchaseEntry.paraPurchaseId = Convert.ToInt32(grdPurchaseEntryList.SelectedRows[0].Cells["PURID"].Value);
                                objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                                objTRN_PurchaseEntry.paraDeleteFlag = 0;
                                SPDataService objspdservice = new SPDataService();
                                result = objspdservice.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                                objspdservice.CloseConnection();


                                string[] varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    if (result.Split('~')[1] == "1")
                                    {
                                        MainForm.objCP_Verify = new CP_Verify();
                                        MainForm.objCP_Verify.ShowDialog();
                                        if (MainForm.objCP_Verify.flag == 1)
                                        {
                                            varUserID = Convert.ToInt32(MainForm.objCP_Verify.varUserId);
                                            objTRN_PurchaseEntry.ViewType = 2;
                                            objTRN_PurchaseEntry.paraUserID = varUserID;
                                            objTRN_PurchaseEntry.paraIPAddress = MainForm.pbIpAddress;
                                            objTRN_PurchaseEntry.paraOriginator = varorginator;
                                            objTRN_PurchaseEntry.paraPurchaseId = Convert.ToInt32(grdPurchaseEntryList.SelectedRows[0].Cells["PURID"].Value);
                                            objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                                            objTRN_PurchaseEntry.paraDeleteFlag = 1;
                                            result = objspdservice.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                                            objspdservice.CloseConnection();
                                            if (result.Split('~')[0] == "3")
                                            {
                                                MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                udfnListLoad();
                                            }
                                            else { MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                        }
                                    }
                                }
                                else if (result.Split('~')[0] == "4")
                                {
                                    MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
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


        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                //if (lblNoRecordsFound.Visible == false)
                //{
                //    if (e.RowIndex < 0 || e.ColumnIndex < 3 && e.ColumnIndex != 1)        /*If a header cell*/
                //        return;
                //    if (DGV_SearchGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Name == "Image" && e.ColumnIndex != 1)
                //        return;
                //    //if ((e.ColumnIndex <2))  //|| e.ColumnIndex == IntDispIndex /*If not our desired columns*/
                //    //    return;

                //    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                //    {
                //        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                //            & ~(DataGridViewPaintParts.ContentForeground));

                //        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                //            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                //        e.Handled = true;
                //    }
                //    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                //    if (DGV_SearchGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Name != "Boolean")
                //    {
                //        if (e.ColumnIndex == 0)
                //        {
                //            DGV_SearchGrid.Rows[e.RowIndex].Cells[3].Value = null;
                //            DGV_SearchGrid.Rows[e.RowIndex].Cells[3] = new DataGridViewTextBoxCell();
                //            DGV_SearchGrid.Rows[e.RowIndex].Cells[3].Value = "";
                //            DGV_SearchGrid.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                //        }
                //    }
                //}
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
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false) 
                {
                    if (grdPurchaseEntryList.ColumnCount > 0)
                    {
                        grdPurchaseEntryList.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseEntryList.HorizontalScrollingOffset;
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
                if (lblNoRecordsFound.Visible == false)
                {
                    DataService objDser = new DataService();
                    grdPurchaseEntryList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseEntryList);
                    objDser.CloseConnection();
                    grdPurchaseEntryList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //DGV_SearchGrid_CellPainting(sender,e);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdPurchaseEntryList, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdPurchaseEntryList.Columns)
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

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (e.ColumnIndex != 0)
                    {
                        DataGridViewColumn newColumn = grdPurchaseEntryList.Columns[e.ColumnIndex];
                        DataGridViewColumn oldColumn = grdPurchaseEntryList.SortedColumn;
                        ListSortDirection direction;
                        // If oldColumn is null, then the DataGridView is not sorted.
                        if (oldColumn != null)
                        {
                            // Sort the same column again, reversing the SortOrder.
                            if (oldColumn == newColumn &&
                                grdPurchaseEntryList.SortOrder == SortOrder.Ascending)
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
                        grdPurchaseEntryList.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;
                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseEntryList.HorizontalScrollingOffset;
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
                    int offSetValue = grdPurchaseEntryList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdPurchaseEntryList.Width > grdPurchaseEntryList.HorizontalScrollingOffset && grdPurchaseEntryList.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
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
        public void udfnscrollVisible(DataGridView DGV,DataGridView grdGroupList)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    var vScrollbar = grdPurchaseEntryList.Controls.OfType<VScrollBar>().First();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_PurchaseList_KeyDown(object sender, KeyEventArgs e)
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
                    //MainForm objMainForm = new MainForm();
                    //objMainForm.udfnCloseChildForms();
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

        private void TsbQue_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                MainForm.objPUR_PurchaseQueue = new PUR_PurchaseQueue();
                MainForm.objPUR_PurchaseQueue.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseQueue.EditAccess = SpecialPermissions.Any(sp => sp.MUP_Code == 22 && sp.EditAccess.Split(',').Contains("10")); 
                MainForm.objPUR_PurchaseQueue.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_PurchaseList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 201;
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                this.ActiveControl = cmbConcern;
                 udfnDate();
                udfnDropDownLoad();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                cmbstatus.SelectedValue = 94; //Draft & Incomplete
                udfnListLoad();
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
            finally
            {
                grdPurchaseEntryList.ClearSelection();
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

                tsbQueue.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 22 && sp.EditAccess.Split(',').Contains("9"));
                tsTotalQueue.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 22 && sp.EditAccess.Split(',').Contains("9"));  
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
                objMR_Master.paraID = 6;
                objMR_Master.paraFlag = 11;
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
        public void udfnListLoad()
        {
            try
            {
                //udfnDate();
                int Varflag = 0;
                string varSupplierId = "0";
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                else
                {
                    string[] values = new string[0];
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 31;
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedleCode.Text);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varSupplierId = Convert.ToString(objDsSupplierId.Tables[0].Rows[0][0]);
                                values = Convert.ToString(varSupplierId).Split(',');
                            }
                        }
                    }
                    if (values[0] == "-1")
                    {
                        errPurchaseList.SetError(txtSupplier, "Invalid supplier.");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedleCode.Text = "0";
                        Varflag = 1;
                    }
                    else
                    {
                        errPurchaseList.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedleCode.Text = values[1];
                        txtSupplier.BackColor = Color.White;

                    }
                }
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                this.ActiveControl = dpFromDate;
                //********** To display a data in a grid  ****************** 
                grdPurchaseEntryList.DataSource = null;
                errPurchaseList.Clear();
                DGV_SearchGrid.DataSource = null;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 1;
                objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_PurchaseEntry.paraStatus = Convert.ToInt32(cmbstatus.SelectedValue);
                objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(lblschedleCode.Text);
                objTRN_PurchaseEntry.ParaPEFromDate = dpFromDate.Text;
                objTRN_PurchaseEntry.ParaPEToDate = dpToDate.Text;
                objTRN_PurchaseEntry.paraType = Convert.ToInt32(cmbOrdertype.SelectedValue);
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection(); 
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0 && Varflag == 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            //grdPurchaseEntryList.Columns["clmEdit"].Visible = true;
                            //grdPurchaseEntryList.Columns["clmEdit"].DisplayIndex = objDs.Tables[0].Columns.Count;
                            //grdPurchaseEntryList.Columns["clmEdit"].Width = 100; 
                            grdPurchaseEntryList.DataSource = objDs.Tables[0];
                            grdPurchaseEntryList.Columns[0].HeaderText = "";
                            grdPurchaseEntryList.Columns[0].Visible = false;
                            grdPurchaseEntryList.Columns["S.No."].Width = 50;
                            grdPurchaseEntryList.Columns["S.No."].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Concern"].Width = 70;
                            grdPurchaseEntryList.Columns["Concern"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Vouc No."].Width = 70;
                            grdPurchaseEntryList.Columns["Vouc No."].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Vouc Date"].Width = 80;
                            grdPurchaseEntryList.Columns["Vouc Date"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Supplier"].Width = 300;
                            grdPurchaseEntryList.Columns["Supplier"].ReadOnly = true;
                           // grdPurchaseEntryList.Columns["City"].Width = 100;
                            grdPurchaseEntryList.Columns["GSTIN"].Width = 120;
                            grdPurchaseEntryList.Columns["GSTIN"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Inv Date"].Width = 80;
                            grdPurchaseEntryList.Columns["Inv Date"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Inv No."].Width = 110; 
                            grdPurchaseEntryList.Columns["Inv No."].ReadOnly = true; 
                            grdPurchaseEntryList.Columns["Created By"].Width = 200;
                            grdPurchaseEntryList.Columns["Created By"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Entry Type"].Width = 150;
                            grdPurchaseEntryList.Columns["Entry Type"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Tot Pro"].Width = 100;
                            grdPurchaseEntryList.Columns["Tot Pro"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["clmCheck"].Width = 50;
                            grdPurchaseEntryList.Columns["Inv Amt"].Width = 80;
                            grdPurchaseEntryList.Columns["Inv Amt"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Pur Entry Status"].Width = 110;
                            grdPurchaseEntryList.Columns["Pur Entry Status"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["Overall Status"].Width = 100;
                            grdPurchaseEntryList.Columns["Overall Status"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["City"].ReadOnly = true;
                            grdPurchaseEntryList.Columns["PURID"].Visible = false;
                            grdPurchaseEntryList.Columns["SPSCID"].Visible = false;
                            grdPurchaseEntryList.Columns["SPID"].Visible = false; 
                            grdPurchaseEntryList.Columns["STSID"].Visible = false;
                            grdPurchaseEntryList.Columns["PUR_INVSTSID"].Visible = false;
                            grdPurchaseEntryList.Columns["PUR_Approval_STSID"].Visible = false;
                            grdPurchaseEntryList.Columns["PUR_LastTransNo"].Visible = false;
                            grdPurchaseEntryList.Columns["PUR_Approval_STSID"].Visible = false;
                            grdPurchaseEntryList.Columns["GRN_Payment_StsID"].Visible = false;
                            grdPurchaseEntryList.Columns["Payment Type"].Visible = false;
                            grdPurchaseEntryList.Columns["TallyExportFlag"].Visible = false;
                            grdPurchaseEntryList.Columns["Flag"].Visible = false;
                            grdPurchaseEntryList.Columns["DeleteFlag"].Visible = false;
                            grdPurchaseEntryList.Columns["Pur Entry Full Status"].Visible = false;
                            grdPurchaseEntryList.Columns["Overall Full Status"].Visible = false;
                            grdPurchaseEntryList.Columns["Tot Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdPurchaseEntryList.Columns["Inv Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
                            grdPurchaseEntryList.Columns["Vouc Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryList.Columns["Inv Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPurchaseEntryList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront(); 
                            grdPurchaseEntryList.Columns["clmEdit"].Visible = false;
                            Deftable = objDs.Tables[0];
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront(); 
                        grdPurchaseEntryList.Columns["clmEdit"].Visible = false;
                        Deftable = objDs.Tables[0];
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront(); 
                    grdPurchaseEntryList.Columns["clmEdit"].Visible = false;
                    Deftable = objDs.Tables[0];
                }
                udfnSearchGridHead();
                if (lblNoRecordsFound.Visible == true)
                {
                    udfnDefcolumns();
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
                udfnDeleteHide();
                udfnQueueListCount();
            }
        }
        public void udfnQueueListCount()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 14;
                objTRN_PurchaseEntry.paraType = 1;
                //objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        tsTotalQueue.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Queue Count"]); 
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefcolumns()
        {
            try
            {
                DGV_SearchGrid.DataSource = null;
                DGV_SearchGrid.DataSource = Deftable;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Concern"].Width = 80;
                DGV_SearchGrid.Columns["Vouc No."].Width = 100;
                DGV_SearchGrid.Columns["Vouc Date"].Width = 100;
                DGV_SearchGrid.Columns["Supplier"].Width = 300;
               // DGV_SearchGrid.Columns["City"].Width = 100;
                DGV_SearchGrid.Columns["GSTIN"].Width = 120;
                DGV_SearchGrid.Columns["Inv Date"].Width = 100;
                DGV_SearchGrid.Columns["Inv No."].Width = 100;
                DGV_SearchGrid.Columns["Created By"].Width = 100;
                DGV_SearchGrid.Columns["Entry Type"].Width = 100;
                DGV_SearchGrid.Columns["Tot Pro"].Width = 150;
                DGV_SearchGrid.Columns["Inv Amt"].Width = 150;
                DGV_SearchGrid.Columns["Pur Entry Status"].Width = 130;
                DGV_SearchGrid.Columns["Overall Status"].Width = 130;
                DGV_SearchGrid.Columns["PURID"].Visible = false;
                DGV_SearchGrid.Columns["SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["SPID"].Visible = false;
                DGV_SearchGrid.Columns["STSID"].Visible = false;
                DGV_SearchGrid.Columns["PUR_Approval_STSID"].Visible = false;
                DGV_SearchGrid.Columns["PUR_INVSTSID"].Visible = false;
                DGV_SearchGrid.Columns["Pur Entry Full Status"].Visible = false;
                DGV_SearchGrid.Columns["Overall Full Status"].Visible = false;
                DGV_SearchGrid.Columns["Pur_LastTransNo"].Visible = false;
                DGV_SearchGrid.Columns["GRN_Payment_StsID"].Visible = false;
                DGV_SearchGrid.Columns["Flag"].Visible = false;
                DGV_SearchGrid.Columns["TallyExportFlag"].Visible = false;
                DGV_SearchGrid.Columns["DeleteFlag"].Visible = false;
                //DGV_SearchGrid.Columns["clmEdit"].Visible = false;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDropDownLoad()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (17 ) OR MSTID  IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrdertype, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID=14 OR STSID=0 ", "STS_Name,STSID", cmbstatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STSID IN (0,49,50,70,93,94) ", "STS_Name,STSID", cmbstatus, "", "STS_Name", "STSID");
                objDataBind = null;
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


        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (DGV_SearchGrid.IsCurrentCellDirty)
                    {
                        // Commit the changes immediately
                        DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }

                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdPurchaseEntryList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseEntryList);
                    objDser.CloseConnection();
                    grdPurchaseEntryList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //grdCompanyList(sender,e); 

                }
            }

            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    ////udfnGridSearchFilter();
                    //DataService objDser = new DataService();
                    //grdPurchaseEntryList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseEntryList);
                    //objDser.CloseConnection();
                    //grdPurchaseEntryList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    ////DGV_SearchGrid_CellPainting(sender,e);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void GrdSupplierList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdPurchaseEntryList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdPurchaseEntryList.Width > grdPurchaseEntryList.HorizontalScrollingOffset && grdPurchaseEntryList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdPurchaseEntryList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_KeyDown(object sender, KeyEventArgs e)
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

        private void Cmbstatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmbstatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbstatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbstatus.BackColor = Color.LemonChiffon;
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
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
                    dpToDate.Focus();
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

        private void DpToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupplier.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrdertype.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (LV_Supplier.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        LV_Supplier.Visible = false;
                    }
                    else
                    {
                        LV_Supplier.Focus();
                    }
                    if (LV_Supplier.Items.Count > 0)
                    {
                        LV_Supplier.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {

            try
            {
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    objMR_Supplier.ParaToDate = dpToDate.Text;
                    objMR_Supplier.paraFlag = 5;
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString()
                                    , objDs.Tables[0].Rows[i]["SupplierName"].ToString(), objDs.Tables[0].Rows[i]["ScheduleName"].ToString()};
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.BringToFront();
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[3].Width = 0;
                                LV_Supplier.Columns[4].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    LV_Supplier.Visible = false;
                    LV_Supplier.Items.Clear();
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


        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                //TxtSupplier_Leave(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnListViewData()
        {
            try
            {
                if (txtSupplier.Text != "")
                { 
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0]; 
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedleCode.Text = selectedItem.SubItems[2].Text;
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                }
                cmbOrdertype.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                LV_Supplier.Visible = false;
            }
        }
        private void LV_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                }
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

        private void CmbOrdertype_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbOrdertype.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrdertype_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrdertype.BackColor = Color.White;
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
                dpToDate.MinDate = varmindate;
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
                udfnListLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseEntryList_DoubleClick(object sender, EventArgs e)
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
         
        private void CmbOrdertype_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbstatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseEntryList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            { 
                grdPurchaseEntryList.Columns["S.No."].Frozen = true;
                grdPurchaseEntryList.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseEntryList.Columns["Concern"].Frozen = true;
                grdPurchaseEntryList.Columns["Concern"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseEntryList.Columns["Pur Entry Status"].Frozen = true;
                grdPurchaseEntryList.Columns["Pur Entry Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseEntryList.Columns["Overall Status"].Frozen = true;
                grdPurchaseEntryList.Columns["Overall Status"].DefaultCellStyle.BackColor = Color.AliceBlue; 

                for (int i = 0; i < grdPurchaseEntryList.Rows.Count; i++)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[i].Cells["Pur Entry Status"];
                    DataGridViewCell cell2 = dataGridView.Rows[i].Cells["Overall Status"];
                    if (Convert.ToString(grdPurchaseEntryList.Rows[i].Cells["STSID"].Value) == "70")
                    {
                        cell.Style.BackColor = Color.Red;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    if (Convert.ToString(grdPurchaseEntryList.Rows[i].Cells["STSID"].Value) == "50")
                    {
                        cell.Style.BackColor = Color.Green;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    if (Convert.ToString(grdPurchaseEntryList.Rows[i].Cells["STSID"].Value) == "49")
                    {
                        cell.Style.BackColor = Color.Pink;
                        cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                    }
                    if(Convert.ToString(grdPurchaseEntryList.Rows[i].Cells["Flag"].Value) == "1") //flag =1 -Purchase entry incomplete
                    {
                        grdPurchaseEntryList.Rows[i].Cells["Overall Status"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("251, 154, 209");
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
                grdPurchaseEntryList.ClearSelection();
            }
        }
        private void GrdPurchaseEntryList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tsbEdit_Click(sender, e);
                }
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.D)
                {
                    tsbDelete_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDeleteHide()
        {
            try
            {
                if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
                {
                    if (lblNoRecordsFound.Visible == false && grdPurchaseEntryList.SelectedRows.Count == 1)
                    {
                        if (Convert.ToInt32(grdPurchaseEntryList.SelectedRows[0].Cells["DeleteFlag"].Value) == 1)
                        {
                            tsbDelete.Visible = false; 
                            varDeleteFlag = 0;
                        }
                        else
                        {
                            tsbDelete.Visible = true; 
                            varDeleteFlag = 1;
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
        private void GrdPurchaseEntryList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                udfnDeleteHide();
            }
            catch(Exception ex)
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
                if ((grdPurchaseEntryList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Purchase Entry List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdPurchaseEntryList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Purchase Entry List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdPurchaseEntryList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            if (cIndex == 1) // Skip the first column (image columns)
                            {
                                continue;
                            }
                            ExcelSheet.Cells[2, cIndex-1] = col.HeaderText;
                            ExcelSheet.Columns[cIndex-1].NumberFormat = "@";

                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlCenter;
                                ExcelSheet.Columns[cIndex-1].ColumnWidth = 10;
                            }
                            else if (col.Name == "Supplier" || col.Name == "Created On" || col.Name == "Overall Status" || col.Name == "City")
                            {
                                ExcelSheet.Columns[cIndex-1].ColumnWidth = 30;
                            }
                            if(col.Name=="Entry Type" || col.Name == "GSTIN")
                            {
                                ExcelSheet.Columns[cIndex-1].ColumnWidth = 15;
                            }
                            if (col.Name == "Vouc Date" || col.Name == "Inv Date" || col.Name == "Inv No."|| col.Name == "Vouc No.")
                            {
                                ExcelSheet.Columns[cIndex-1].HorizontalAlignment = Excel.Constants.xlCenter;
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 10;
                            }
                            if (col.Name == "Tot Pro")
                            {
                                ExcelSheet.Columns[cIndex-1].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            int varSLno = 1;
                            foreach (DataGridViewRow rowa in grdPurchaseEntryList.Rows)
                            {
                                if (cIndex == 1)
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex-1] = varSLno;
                                    varSLno++;
                                }
                                else
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex-1] = rowa.Cells[col.Index].Value;
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
        private void BtnTally_Click(object sender, EventArgs e)
        {

            try
            {
                string VarPurchaseID = "0";
                //int varflag = 0;
                for (int i = 0; i < grdPurchaseEntryList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdPurchaseEntryList.Rows[i].Cells["PUR_Approval_STSID"].Value) == "63" && Convert.ToString(grdPurchaseEntryList.Rows[i].Cells["TallyExportFlag"].Value) == "0")
                    {
                        if (VarPurchaseID == "0" && Convert.ToBoolean(grdPurchaseEntryList.Rows[i].Cells["clmCheck"].Value) == true)
                        {
                            VarPurchaseID = Convert.ToString(grdPurchaseEntryList.Rows[i].Cells["PURID"].Value);
                        }
                        else if (VarPurchaseID != "0" && Convert.ToBoolean(grdPurchaseEntryList.Rows[i].Cells["clmCheck"].Value) == true)
                        {
                            VarPurchaseID = VarPurchaseID + ',' + Convert.ToString(grdPurchaseEntryList.Rows[i].Cells["PURID"].Value);
                        }
                    }
                }
                if (VarPurchaseID != "0")
                {
                    SPDataService objDServ = new SPDataService();
                    string result = "";
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = 6;
                    objTRN_PurchaseEntry.paraCompletedIDs = Convert.ToString(VarPurchaseID);
                    result = objDServ.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                    objDServ.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnListLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
           
        private void GrdPurchaseEntryList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdPurchaseEntryList.Columns["Pur Entry Status"].Index)
                {
                    var cell = grdPurchaseEntryList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdPurchaseEntryList.Rows[e.RowIndex].Cells["Pur Entry Full Status"].Value.ToString();
                }
                if (e.ColumnIndex == grdPurchaseEntryList.Columns["Overall Status"].Index)
                {
                    var cell = grdPurchaseEntryList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdPurchaseEntryList.Rows[e.RowIndex].Cells["Overall Full Status"].Value.ToString();
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
        private void BtnTally_Enter(object sender, EventArgs e)
        {
            try
            {
                btnTally.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnTally_Leave(object sender, EventArgs e)
        {
            try
            {
                btnTally.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }
    }
}
