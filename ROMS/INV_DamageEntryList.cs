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
    public partial class INV_DamageEntryList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        MainForm objMainForm = new MainForm();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public string varUserID = "";
        Boolean BlnSearchImageYN = false;
        public int MenuCode = 0;
        string privilege = "";
        public int pbViewFlag = 0;
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public INV_DamageEntryList()
        {
            InitializeComponent();
            windowControl.Initialize(tsDamageEntry, this);
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objINV_DamageEntry = new INV_DamageEntry();
                    MainForm.objINV_DamageEntry.MdiParent = this.ParentForm;
                    //objMainForm.CenterEntryForm(this, MainForm.objINV_DamageEntry);
                    MainForm main = (MainForm)this.MdiParent;
                    main.IsEntryFormOpen = true;
                    main.CurrentEntryForm = MainForm.objINV_DamageEntry;
                    main.CurrentParentListForm = this;
                    MainForm.objINV_DamageEntry.Show();
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
        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/
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
                if (lblNoRecordsFound.Visible == false)
                {
                    if (grdDamageEntryList.ColumnCount > 0)
                    {
                        grdDamageEntryList.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdDamageEntryList.HorizontalScrollingOffset;
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
                grdDamageEntryList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdDamageEntryList);
                objDser.CloseConnection();
                grdDamageEntryList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdDamageEntryList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdDamageEntryList.Columns)
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
        private void udfnSupSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnSupGridSearchHeading(grdSupDEList, DGV_SupSearchGrid);
                    DGV_SupSearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdSupDEList.Columns)
                    {
                        DGV_SupSearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SupSearchGrid.Rows.Clear();
                    DGV_SupSearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        DGV_SupSearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    if (lblNoRecordsFound.Visible == false)
                    {
                        DGV_SupSearchGrid.Columns["S.No."].ReadOnly = true;
                    }
                    DGV_SupSearchGrid.Columns[0].ReadOnly = true;
                    DGV_SupSearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
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
                    udfnProGridSearchHeading(grdProDEList, DGV_ProSearchGrid);
                    DGV_ProSearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdProDEList.Columns)
                    {
                        DGV_ProSearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_ProSearchGrid.Rows.Clear();
                    DGV_ProSearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        DGV_ProSearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_ProSearchGrid.Columns["S.No."].ReadOnly = true;
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
                        bs.DataSource = grdDamageEntryList.DataSource;
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
                        grdDamageEntryList.DataSource = bs;
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
        private void udfnSupGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
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
        private void udfnProGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
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
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdDamageEntryList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdDamageEntryList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdDamageEntryList.SortOrder == SortOrder.Ascending)
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
                        grdDamageEntryList.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                        DGV_SearchGrid.HorizontalScrollingOffset = grdDamageEntryList.HorizontalScrollingOffset;
                        DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdDamageEntryList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdDamageEntryList.Width > grdDamageEntryList.HorizontalScrollingOffset && grdDamageEntryList.HorizontalScrollingOffset > 0)
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
        public void udfnscrollVisible(DataGridView DGV, DataGridView grdDamageEntryList)
        {
            try
            {
                var vScrollbar = grdDamageEntryList.Controls.OfType<VScrollBar>().First();
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
        public void udfnProscrollVisible(DataGridView DGV, DataGridView grdProDEList)
        {
            try
            {
                var vScrollbar = grdProDEList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }

                    int I = DGV_ProSearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_ProSearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_ProSearchGrid.Rows[rowIndex].Cells[i].Value = "";
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
        public void udfnSupscrollVisible(DataGridView DGV, DataGridView grdSupDEList)
        {
            try
            {
                var vScrollbar = grdSupDEList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }

                    int I = DGV_SupSearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SupSearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SupSearchGrid.Rows[rowIndex].Cells[i].Value = "";
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
        private void INV_DamageEntryList_KeyDown(object sender, KeyEventArgs e)
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
                    TsbDelete_Click(sender, e);
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
                    udfndelete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dtpoutwarddate_Enter(object sender, EventArgs e)
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

        private void Dtpoutwarddate_KeyDown(object sender, KeyEventArgs e)
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

        private void Dtpoutwarddate_Leave(object sender, EventArgs e)
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

        private void INV_DamageEntryList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 307;
                cmbconcern.Focus();
                udfnCmbConcern();
                cmbconcern.SelectedValue = MainForm.pbDefaultComId;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (3,0) AND STSID NOT IN(-1,36)", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (53) AND MSTID !=0", "MST_DisplayText,MSTID", cmbDMShow, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (186,0) AND MSTID !=-1", "MST_DisplayText,MSTID", cmbEntryType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                //cmbStatus.SelectedValue = 6; 
                pbViewFlag = 6;//For the fisttime only load all draft status records
                dpFromDate.Text = Convert.ToString(MainForm.pbCurrentDate);
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                udfngridchanges();
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }
                udfnQueueListCount();
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
                btnExport.Visible = privilege.Contains("6");
                tsbQue.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 29 && sp.EditAccess.Split(',').Contains("9"));
                tsTotalQueue.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 29 && sp.EditAccess.Split(',').Contains("9"));
                udfnGridAccess();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridAccess()
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                { 
                    grdDamageEntryList.Columns["clmSupPrint"].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 34 && sp.EditAccess.Split(',').Contains("9")); 
                    DGV_SearchGrid.Columns[0].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 19 && sp.EditAccess.Split(',').Contains("9"));
                    DGV_SearchGrid.Columns[1].Visible = privilege.Contains("3");
                    DGV_SearchGrid.Columns[2].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 44 && sp.EditAccess.Split(',').Contains("9"));
                    DGV_SearchGrid.Columns[3].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 20 && sp.EditAccess.Split(',').Contains("9"));
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
                cmbconcern.Focus();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(2, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                cmbconcern.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbconcern.ValueMember = "COMID";
                            cmbconcern.DisplayMember = "COM_ShortName";
                            cmbconcern.DataSource = objDT.Tables[0];
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

        private void Cmbconcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbconcern.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbconcern_KeyDown(object sender, KeyEventArgs e)
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

        private void Cmbconcern_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmbconcern_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbconcern.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnEdit()
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdDamageEntryList.SelectedRows.Count > 0)
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        MainForm.objINV_DamageEntry = new INV_DamageEntry();
                        MainForm.objINV_DamageEntry.MdiParent = ParentForm;
                        MainForm.objINV_DamageEntry.varID = Convert.ToInt32(grdDamageEntryList.SelectedRows[0].Cells["DMID"].Value);
                        MainForm.objINV_DamageEntry.varStatusID = Convert.ToInt32(grdDamageEntryList.SelectedRows[0].Cells["StatusID"].Value);
                        //objMainForm.CenterEntryForm(this, MainForm.objINV_DamageEntry);
                        MainForm main = (MainForm)this.MdiParent;
                        main.IsEntryFormOpen = true;
                        main.CurrentEntryForm = MainForm.objINV_DamageEntry;
                        main.CurrentParentListForm = this;
                        MainForm.objINV_DamageEntry.Show();
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
                    if (grdDamageEntryList.SelectedRows.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SPDataService objDser = new SPDataService();
                            Model.TRN_Damage objTRN_Damage = new Model.TRN_Damage();
                            objTRN_Damage.ViewType = 2;
                            objTRN_Damage.paraDamageEntryID = Convert.ToInt32(grdDamageEntryList.SelectedRows[0].Cells["DMID"].Value.ToString());
                            objTRN_Damage.paraStatusId = Convert.ToInt32(grdDamageEntryList.SelectedRows[0].Cells["StatusID"].Value.ToString());
                            objTRN_Damage.paraOriginator = "Damage Entry Delete";

                            string varResult = objDser.udfnDamageEntry(objTRN_Damage);
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
                                        //SPDataService objDser = new SPDataService();
                                        //Model.TRN_Damage objTRN_Damage = new Model.TRN_Damage();
                                        objTRN_Damage.ViewType = 2;
                                        objTRN_Damage.paraStatusId = Convert.ToInt32(grdDamageEntryList.SelectedRows[0].Cells["StatusID"].Value.ToString());
                                        objTRN_Damage.paraDamageEntryID = Convert.ToInt32(grdDamageEntryList.SelectedRows[0].Cells["DMID"].Value.ToString());
                                        objTRN_Damage.paraOriginator = "Damage Entry Delete";
                                        objTRN_Damage.paraDeleteFlag = 1;
                                        varResult = objDser.udfnDamageEntry(objTRN_Damage);
                                        if (varResult.Split('~')[0] == "3")
                                        {
                                            MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            udfnTransList();
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
        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGV_SearchGrid.IsCurrentCellDirty)
            {
                // Commit the changes immediately
                DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            DataService objDser = new DataService();
            grdDamageEntryList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdDamageEntryList);
            objDser.CloseConnection();
            grdDamageEntryList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                    cmbDMShow.Focus();
                }
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

        private void TxtSupplierName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSupplierName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvSupplier.Items.Count == 0 || txtSupplierName.Text == "")
                    {
                        txtSupplierName.Focus();
                        lvSupplier.Visible = false;
                    }
                    else
                    {
                        lvSupplier.Focus();
                    }
                    if (lvSupplier.Items.Count > 0)
                    {
                        lvSupplier.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbEntryType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplierName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplierName.BackColor = Color.White;
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
                lvSupplier.Visible = false;
                lblDSupplier.Focus();
                udfngridchanges();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfngridchanges()
        {
            try
            {
                if (Convert.ToInt32(cmbDMShow.SelectedValue) == 169)
                {
                    udfnTransList();
                }
                if (Convert.ToInt32(cmbDMShow.SelectedValue) == 170)
                {
                    udfnProductList();
                }
                if (Convert.ToInt32(cmbDMShow.SelectedValue) == 171)
                {
                    udfnSupList();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTransList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                if (Convert.ToString(txtSupplierName.Text) != "")
                {
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 23;
                    objMR_Supplier.paraSupplierName = txtSupplierName.Text.Trim();
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
                            else
                            {
                                lblSupplierCode.Text = "0";
                                lblScheduleCode.Text = "0";
                            }
                        }
                    }
                    if (objDsSupplierId.Tables[0].Rows.Count > 0)
                    {
                        if (values[0] == "-1")
                        {
                            lblSupplierCode.Text = "0";
                            lblScheduleCode.Text = "0";
                        }
                        else
                        {
                            lblSupplierCode.Text = values[0];
                            lblScheduleCode.Text = values[1];
                            txtSupplierName.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    lblSupplierCode.Text = "0";
                    lblScheduleCode.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdDamageEntryList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductDamage(1, 0, Convert.ToInt32(lblSupplierCode.Text), 0, Convert.ToInt32(cmbconcern.SelectedValue), Convert.ToInt32(cmbStatus.SelectedValue), dpFromDate.Text, dpToDate.Text, "", 0, "", 0,Convert.ToInt16(cmbEntryType.SelectedValue), pbViewFlag);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdDamageEntryList.Columns["clmPrint"].Visible = true;
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdDamageEntryList.DataSource = objDs.Tables[0];
                            grdDamageEntryList.Columns["ConcernID"].Visible = false;
                            grdDamageEntryList.Columns["StatusID"].Visible = false;
                            grdDamageEntryList.Columns["DMID"].Visible = false;
                            grdDamageEntryList.Columns["DM_SHID"].Visible = false;
                            //grdDamageEntryList.Columns["EMPID"].Visible = false;
                            grdDamageEntryList.Columns["S.No."].Width = 50;
                            grdDamageEntryList.Columns["Status"].Width = 120;
                            grdDamageEntryList.Columns["Created On"].Width = 150;
                            grdDamageEntryList.Columns["Employees"].Width = 300;
                            grdDamageEntryList.Columns["clmPrint"].Width = 50;
                            //grdDamageEntryList.Columns["Supplier"].Width = 330;
                            //grdDamageEntryList.Columns["City"].Width = 120;
                            //grdDamageEntryList.Columns["GSTIN"].Width = 150;
                            grdDamageEntryList.Columns["Created By"].Width = 100;
                            grdDamageEntryList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdDamageEntryList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdDamageEntryList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdDamageEntryList.Columns["Total Units"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdDamageEntryList.BringToFront();
                            grdProDEList.SendToBack();
                            grdSupDEList.SendToBack();
                        }
                        else
                        {
                            grdDamageEntryList.Columns["clmPrint"].Visible = false;
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        grdDamageEntryList.Columns["clmPrint"].Visible = false;
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    grdDamageEntryList.Columns["clmPrint"].Visible = false;
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
                DGV_SearchGrid.BringToFront();
                DGV_ProSearchGrid.SendToBack();
                DGV_SupSearchGrid.SendToBack();
                udfnSearchGridHead();
                if (lblNoRecordsFound.Visible == true)
                {
                    dtDefaultGrid = objDs.Tables[0];
                    udfnDefaultSearchGrid();
                }
                else { DGV_SearchGrid.ScrollBars = ScrollBars.None; }
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
                btnView.Enabled = true;
                btnView.Focus();
                pbViewFlag = 0;
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["ConcernID"].Visible = false;
                DGV_SearchGrid.Columns["StatusID"].Visible = false;
                DGV_SearchGrid.Columns["DMID"].Visible = false;
                DGV_SearchGrid.Columns["DM_SHID"].Visible = false;
                //DGV_SearchGrid.Columns["clmPrint"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Status"].Width = 120;
                DGV_SearchGrid.Columns["Employees"].Width = 300;
                DGV_SearchGrid.Columns["Created By"].Width = 100;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
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
                DGV_ProSearchGrid.DataSource = dtDefaultGrid;
                DGV_ProSearchGrid.Columns["DMID"].Visible = false;
                DGV_ProSearchGrid.Columns["StatusID"].Visible = false;
                DGV_ProSearchGrid.Columns["PRStatusID"].Visible = false;
                DGV_ProSearchGrid.Columns["DMPR_SPID"].Visible = false;
                DGV_ProSearchGrid.Columns["DMPR_SPSCID"].Visible = false;
                DGV_ProSearchGrid.Columns["S.No."].Width = 50;
                DGV_ProSearchGrid.Columns["Status"].Width = 150;
                DGV_ProSearchGrid.Columns["Product Status"].Width = 150;
                DGV_ProSearchGrid.Columns["PICode"].Width = 150;
                DGV_ProSearchGrid.Columns["Product"].Width = 200;
                DGV_ProSearchGrid.Columns["Reason"].Width = 130; DGV_ProSearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefaultSupSearchGrid()
        {
            try
            {
                DGV_SupSearchGrid.DataSource = dtDefaultGrid;
                DGV_SupSearchGrid.Columns["StatusID"].Visible = false;
                DGV_SupSearchGrid.Columns["DMID"].Visible = false;
                DGV_SupSearchGrid.Columns["clmSupPrint"].Visible = false;
                DGV_SupSearchGrid.Columns["SPID"].Visible = false;
                DGV_SupSearchGrid.Columns["SPSCID"].Visible = false;
                DGV_SupSearchGrid.Columns["S.No."].Width = 50;
                DGV_SupSearchGrid.Columns["Status"].Width = 120;
                DGV_SupSearchGrid.Columns["Quantity"].Width = 80;
                DGV_SupSearchGrid.Columns["clmSupPrint"].Width = 50;
                DGV_SupSearchGrid.Columns["Supplier"].Width = 250;
                DGV_SupSearchGrid.Columns["Created By"].Width = 100; DGV_SupSearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV_ProSearchGrid.DataSource = null;
                if (txtSupplierName.Text == "")
                {
                    lblSupplierCode.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdProDEList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductDamage(5, 0, Convert.ToInt32(lblSupplierCode.Text), 0, Convert.ToInt32(cmbconcern.SelectedValue), Convert.ToInt32(cmbStatus.SelectedValue), dpFromDate.Text, dpToDate.Text, "", 0, "", 0,Convert.ToInt16(cmbEntryType.SelectedValue),0);
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
                            grdProDEList.DataSource = objDs.Tables[0];
                            //grdProDEList.Columns["ConcernID"].Visible = false;
                            //grdProDEList.Columns["StatusID"].Visible = false;
                            grdProDEList.Columns["DMID"].Visible = false;
                            grdProDEList.Columns["StatusID"].Visible = false;
                            grdProDEList.Columns["PRStatusID"].Visible = false;
                            grdProDEList.Columns["DMPR_SPID"].Visible = false;
                            grdProDEList.Columns["DMPR_SPSCID"].Visible = false;
                            grdProDEList.Columns["S.No."].Width = 50;
                            grdProDEList.Columns["Status"].Width = 120;
                            grdProDEList.Columns["Created On"].Width = 150;
                            grdProDEList.Columns["Product Status"].Width = 120;
                            grdProDEList.Columns["PICode"].Width = 150;
                            grdProDEList.Columns["Product"].Width = 280;
                            grdProDEList.Columns["Reason"].Width = 130;
                            grdProDEList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDEList.Columns["Product"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdProDEList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDEList.Columns["Product Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            //grdProDEList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdProDEList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdProDEList.BringToFront();
                            grdDamageEntryList.SendToBack();
                            grdSupDEList.SendToBack();
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
                DGV_ProSearchGrid.BringToFront();
                DGV_SearchGrid.SendToBack();
                DGV_SupSearchGrid.SendToBack();
                udfnProSearchGridHead();
                if (lblNoRecordsFound.Visible == true)
                {
                    dtDefaultGrid = objDs.Tables[0];
                    udfnDefaultProSearchGrid();
                }
                else { DGV_ProSearchGrid.ScrollBars = ScrollBars.Vertical; }
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
                btnView.Enabled = true;
                btnView.Focus();
            }
        }
        public void udfnSupList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV_SupSearchGrid.DataSource = null;
                if (Convert.ToString(txtSupplierName.Text) != "")
                {
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 23;
                    objMR_Supplier.paraSupplierName = txtSupplierName.Text.Trim();
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
                            else
                            {
                                lblSupplierCode.Text = "0";
                                lblScheduleCode.Text = "0";
                            }
                        }
                    }
                    if (objDsSupplierId.Tables[0].Rows.Count > 0)
                    {
                        if (values[0] == "-1")
                        {
                            lblSupplierCode.Text = "0";
                            lblScheduleCode.Text = "0";
                        }
                        else
                        {
                            lblSupplierCode.Text = values[0];
                            lblScheduleCode.Text = values[1];
                            txtSupplierName.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    lblSupplierCode.Text = "0";
                    lblScheduleCode.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdSupDEList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductDamage(6, 0, Convert.ToInt32(lblSupplierCode.Text), 0, Convert.ToInt32(cmbconcern.SelectedValue), Convert.ToInt32(cmbStatus.SelectedValue), dpFromDate.Text, dpToDate.Text, "", 0, "", 0,Convert.ToInt16(cmbEntryType.SelectedValue),0);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdSupDEList.Columns["clmSupPrint"].Visible = true;
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdSupDEList.DataSource = objDs.Tables[0];
                            //grdSupDEList.Columns["ConcernID"].Visible = false;
                            grdSupDEList.Columns["StatusID"].Visible = false;
                            grdSupDEList.Columns["DMID"].Visible = false;
                            grdSupDEList.Columns["SPID"].Visible = false;
                            grdSupDEList.Columns["SPSCID"].Visible = false;
                            grdSupDEList.Columns["S.No."].Width = 50;
                            grdSupDEList.Columns["Status"].Width = 120;
                            grdSupDEList.Columns["Quantity"].Width = 80;
                            grdSupDEList.Columns["clmSupPrint"].Width = 50;
                            grdSupDEList.Columns["Supplier"].Width = 300;
                            //grdDamageEntryList.Columns["City"].Width = 120;
                            //grdDamageEntryList.Columns["GSTIN"].Width = 150;
                            grdSupDEList.Columns["Created By"].Width = 100;
                            grdSupDEList.Columns["Created On"].Width = 150;
                            grdSupDEList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdSupDEList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdSupDEList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdSupDEList.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdSupDEList.BringToFront();
                            grdProDEList.SendToBack();
                            grdDamageEntryList.SendToBack();
                        }
                        else
                        {
                            grdSupDEList.Columns["clmSupPrint"].Visible = false;
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        grdSupDEList.Columns["clmSupPrint"].Visible = false;
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    grdSupDEList.Columns["clmSupPrint"].Visible = false;
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
                DGV_SupSearchGrid.BringToFront();
                DGV_ProSearchGrid.SendToBack();
                DGV_SearchGrid.SendToBack();
                udfnSupSearchGridHead();
                if (lblNoRecordsFound.Visible == true)
                {
                    dtDefaultGrid = objDs.Tables[0];
                    udfnDefaultSupSearchGrid();
                }
                else { DGV_SupSearchGrid.ScrollBars = ScrollBars.None; }
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
                btnView.Enabled = true;
                btnView.Focus();
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

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(cmbDMShow.SelectedValue)==169)
                {
                    udfnDamageExport();
                }
                if (Convert.ToInt32(cmbDMShow.SelectedValue) == 170)
                {
                    udfnProductExport();
                }
                if (Convert.ToInt32(cmbDMShow.SelectedValue) == 171)
                {
                    udfnSupplierExport();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDamageExport()
        {
            try
            {
                btnExport.Enabled = false;
                lblDSupplier.Focus();
                if ((grdDamageEntryList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Damage Entry";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdDamageEntryList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Damage Entry";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdDamageEntryList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            if (cIndex == 1) // Skip the first two columns (image columns)
                            {
                                continue;
                            }
                            ExcelSheet.Cells[2, cIndex-1] = col.HeaderText;
                            ExcelSheet.Columns[cIndex - 1].NumberFormat = "@";

                            if (col.Name == "S.No." || col.Name == "Total Units")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 10;
                            }
                            else if (col.Name == "Concern" || col.Name == "Entry Date" || col.Name == "Entry No." || col.Name == "Created By" || col.Name == "Total Products" || col.Name == "Status")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 18;
                            }
                            else if (col.Name == "Employees")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 30;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 15;
                            }
                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Total Products" || col.Name == "Total Units")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdDamageEntryList.Rows)
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
        public void udfnProductExport()
        {
            try
            {
                btnExport.Enabled = false;
                lblDSupplier.Focus();
                if ((grdProDEList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Damage Products";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdProDEList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Damage Products";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdProDEList.Columns)
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
                            else if (col.Name == "Concern" || col.Name == "Entry Date" || col.Name == "Entry No." || col.Name == "Quantity")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            else if (col.Name == "Product" )
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 50;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }
                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Quantity")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdProDEList.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                                if (cIndex == 6)
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
        public void udfnSupplierExport()
        {
            try
            {
                btnExport.Enabled = false;
                lblDSupplier.Focus();
                if ((grdSupDEList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Damage Supplier";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdSupDEList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Damage Supplier";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdSupDEList.Columns)
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

                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 10;
                            }
                            else if (col.Name == "Concern" || col.Name == "Entry Date" || col.Name == "Entry No." || col.Name == "Quantity")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 15;
                            }
                            else if (col.Name == "Supplier")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 40;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 15;
                            }
                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Quantity")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdSupDEList.Rows)
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

        private void TxtSupplierName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSupplier.Items.Clear();
                if (txtSupplierName.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraSupplierName = txtSupplierName.Text;
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbconcern.SelectedValue);
                    objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    objMR_Supplier.ParaToDate = dpToDate.Text;
                    objMR_Supplier.paraFlag = 2;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSupplier.Items.Add(objList);
                                }
                                lvSupplier.Visible = true;
                                lvSupplier.BringToFront();
                                lvSupplier.Columns[1].Width = 0;
                                lvSupplier.Columns[2].Width = 0;
                                lvSupplier.Columns[0].Width = 250;
                                lvSupplier.Columns[3].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    lvSupplier.Visible = false;
                    lvSupplier.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void LvSupplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                cmbEntryType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                    cmbEntryType.Focus();
                }
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
                if (txtSupplierName.Text != "")
                {
                    ListViewItem selectedItem = lvSupplier.SelectedItems[0];
                    txtSupplierName.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblScheduleCode.Text = selectedItem.SubItems[2].Text;
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSupplier.Visible = false;
            }
        }

        private void LvSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewSupplier();
                    btnPrint.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSupplierName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewSupplier();
                btnPrint.Focus();
            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListViewSupplier()
        {
            try
            {
                if (txtSupplier.Text != "")
                {
                    ListViewItem selectedItem = lvSupplierName.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSPID.Text = selectedItem.SubItems[1].Text;
                    lblSPSCID.Text = selectedItem.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSupplierName.Visible = false;
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

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvSupplierName.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        lvSupplierName.Visible = false;
                    }
                    else
                    {
                        lvSupplierName.Focus();
                    }
                    if (lvSupplierName.Items.Count > 0)
                    {
                        lvSupplierName.Items[0].Selected = true;
                    }
                }
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

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(cmbDMShow.SelectedValue)==170)
                {
                    udfnProductPrint();
                }
                if (Convert.ToInt32(cmbDMShow.SelectedValue) == 171)
                {
                    udfnSupplierPrint();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductPrint()
        {
            try
            {
                if (Convert.ToString(txtSupplierName.Text) != "")
                {
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 23;
                    objMR_Supplier.paraSupplierName = txtSupplierName.Text.Trim();
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
                            else
                            {
                                lblSupplierCode.Text = "0";
                                lblScheduleCode.Text = "0";
                            }
                        }
                    }
                    if (objDsSupplierId.Tables[0].Rows.Count > 0)
                    {
                        if (values[0] == "-1")
                        {
                            lblSupplierCode.Text = "0";
                            lblScheduleCode.Text = "0";
                        }
                        else
                        {
                            lblSupplierCode.Text = values[0];
                            lblScheduleCode.Text = values[1];
                            txtSupplierName.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    lblSupplierCode.Text = "0";
                    lblScheduleCode.Text = "0";
                }
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductDamage(5, 0, Convert.ToInt32(lblSupplierCode.Text), 0, Convert.ToInt32(cmbconcern.SelectedValue), Convert.ToInt32(cmbStatus.SelectedValue), dpFromDate.Text, dpToDate.Text, "", 0, "", 0, Convert.ToInt16(cmbEntryType.SelectedValue),0);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    string DMID = "0";
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_Damage_Product.rpt");
                    varHeader = "Damaged Products List";

                    objBillreport.SetParameterValue("paraDamageEntryID", Convert.ToInt32(DMID));
                    objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(cmbconcern.SelectedValue));
                    objBillreport.SetParameterValue("ParaDMFromDate", Convert.ToString(dpFromDate.Text));
                    objBillreport.SetParameterValue("ParaDMToDate", Convert.ToString(dpToDate.Text));
                    objBillreport.SetParameterValue("ParaSupplierId", Convert.ToInt32(lblSupplierCode.Text));
                    objBillreport.SetParameterValue("ParaScheduleId", Convert.ToInt32(lblScheduleCode.Text));
                    objBillreport.SetParameterValue("paraStatus", Convert.ToInt32(cmbStatus.SelectedValue));
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
        public void udfnSupplierPrint()
        {
            try
            {
                if (Convert.ToString(txtSupplierName.Text) != "")
                {
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 23;
                    objMR_Supplier.paraSupplierName = txtSupplierName.Text.Trim();
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
                            else
                            {
                                lblSupplierCode.Text = "0";
                                lblScheduleCode.Text = "0";
                            }
                        }
                    }
                    if (objDsSupplierId.Tables[0].Rows.Count > 0)
                    {
                        if (values[0] == "-1")
                        {
                            lblSupplierCode.Text = "0";
                            lblScheduleCode.Text = "0";
                        }
                        else
                        {
                            lblSupplierCode.Text = values[0];
                            lblScheduleCode.Text = values[1];
                            txtSupplierName.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    lblSupplierCode.Text = "0";
                    lblScheduleCode.Text = "0";
                }
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnproductDamage(7, 0, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblScheduleCode.Text), Convert.ToInt32(cmbconcern.SelectedValue), Convert.ToInt32(cmbStatus.SelectedValue), dpFromDate.Text, dpToDate.Text, "", 0, "", 0, Convert.ToInt16(cmbEntryType.SelectedValue),0);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_Damage_Supplier_Detail.rpt");
                    varHeader = "Damaged Products List";

                    objBillreport.SetParameterValue("ParaSupplierId", Convert.ToInt32(lblSupplierCode.Text));
                    objBillreport.SetParameterValue("ParaScheduleId", Convert.ToInt32(lblScheduleCode.Text));
                    objBillreport.SetParameterValue("ParaDMFromDate", Convert.ToString(dpFromDate.Text));
                    objBillreport.SetParameterValue("ParaDMToDate", Convert.ToString(dpToDate.Text));
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
        private void BtnPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                btnPrint.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPrint_Leave(object sender, EventArgs e)
        {
            try
            {
                btnPrint.BackColor = Color.Transparent;
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

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSupplierName.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 15;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSupplierName.Items.Add(objList);
                                }
                                lvSupplierName.Visible = true;
                                lvSupplierName.BringToFront();
                                lvSupplierName.Columns[1].Width = 0;
                                lvSupplierName.Columns[2].Width = 0;
                                lvSupplierName.Columns[0].Width = 250;
                                lvSupplierName.Columns[3].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    lvSupplierName.Visible = false;
                    lvSupplierName.Items.Clear();
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

        private void GrdDamageEntryList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdDamageEntryList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdDamageEntryList.Width > grdDamageEntryList.HorizontalScrollingOffset && grdDamageEntryList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdDamageEntryList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdDamageEntryList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                //udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdDamageEntryList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdDamageEntryList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdDamageEntryList.Rows[i].Cells["StatusID"].Value) == "6")
                    {
                        grdDamageEntryList.Rows[i].Cells["Status"].Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        grdDamageEntryList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdDamageEntryList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdDamageEntryList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                grdDamageEntryList.ClearSelection();
            }
        }

        private void GrdDamageEntryList_DoubleClick(object sender, EventArgs e)
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

        private void GrdDamageEntryList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit();
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

        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                lvSupplier.Visible = false;
                cmbStatus.BackColor = Color.LemonChiffon;
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

        private void GrdDamageEntryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdDamageEntryList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPrint":
                        try
                        {
                            string DMID = "0";
                            DMID = Convert.ToString(grdDamageEntryList.SelectedRows[0].Cells["DMID"].Value.ToString());
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
                                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_Damage_Supplier.rpt");
                                varHeader = "Transaction Wise Damage Products List";

                                objBillreport.SetParameterValue("paraDamageEntryID", Convert.ToInt32(DMID));
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

        private void CmbDMShow_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbDMShow.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDMShow_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupplierName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDMShow_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbDMShow_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDMShow.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdProDEList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdProDEList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_ProSearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdProDEList.Width > grdProDEList.HorizontalScrollingOffset && grdProDEList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_ProSearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_ProSearchGrid.Invalidate();
                    udfnProscrollVisible(DGV_ProSearchGrid, grdProDEList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_ProSearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/
                                             //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_ProSearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_ProSearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdProDEList.DataSource = objDser.udfnGridSearchFilter(DGV_ProSearchGrid, grdProDEList);
                objDser.CloseConnection();
                grdProDEList.HorizontalScrollingOffset = DGV_ProSearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_ProSearchGrid_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdProDEList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdProDEList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdProDEList.SortOrder == SortOrder.Ascending)
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
                    grdProDEList.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_ProSearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_ProSearchGrid.HorizontalScrollingOffset = grdProDEList.HorizontalScrollingOffset;
                    DGV_ProSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_ProSearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (grdProDEList.ColumnCount > 0)
                    {
                        grdProDEList.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_ProSearchGrid.HorizontalScrollingOffset = grdProDEList.HorizontalScrollingOffset;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_ProSearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGV_ProSearchGrid.IsCurrentCellDirty)
            {
                // Commit the changes immediately
                DGV_ProSearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            DataService objDser = new DataService();
            grdProDEList.DataSource = objDser.udfnGridSearchFilter(DGV_ProSearchGrid, grdProDEList);
            objDser.CloseConnection();
            grdProDEList.HorizontalScrollingOffset = DGV_ProSearchGrid.HorizontalScrollingOffset;
        }

        private void DGV_ProSearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdProDEList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_ProSearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdProDEList.Width > grdProDEList.HorizontalScrollingOffset && grdProDEList.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
                        offSetValue = offSetValue;
                    }
                    DGV_ProSearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_ProSearchGrid.Invalidate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupDEList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdSupDEList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SupSearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdSupDEList.Width > grdSupDEList.HorizontalScrollingOffset && grdSupDEList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SupSearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SupSearchGrid.Invalidate();
                    udfnSupscrollVisible(DGV_SupSearchGrid, grdSupDEList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SupSearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdSupDEList.DataSource = objDser.udfnGridSearchFilter(DGV_SupSearchGrid, grdSupDEList);
                objDser.CloseConnection();
                grdSupDEList.HorizontalScrollingOffset = DGV_SupSearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SupSearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/
                                             //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SupSearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SupSearchGrid_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdSupDEList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdSupDEList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdSupDEList.SortOrder == SortOrder.Ascending)
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
                    grdSupDEList.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_SupSearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_SupSearchGrid.HorizontalScrollingOffset = grdSupDEList.HorizontalScrollingOffset;
                    DGV_SupSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SupSearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (grdSupDEList.ColumnCount > 0)
                    {
                        grdSupDEList.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_SupSearchGrid.HorizontalScrollingOffset = grdSupDEList.HorizontalScrollingOffset;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SupSearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGV_SupSearchGrid.IsCurrentCellDirty)
            {
                // Commit the changes immediately
                DGV_SupSearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            DataService objDser = new DataService();
            grdSupDEList.DataSource = objDser.udfnGridSearchFilter(DGV_SupSearchGrid, grdSupDEList);
            objDser.CloseConnection();
            grdSupDEList.HorizontalScrollingOffset = DGV_SupSearchGrid.HorizontalScrollingOffset;
        }

        private void DGV_SupSearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdSupDEList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SupSearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdSupDEList.Width > grdSupDEList.HorizontalScrollingOffset && grdSupDEList.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
                        offSetValue = offSetValue;
                    }
                    DGV_SupSearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SupSearchGrid.Invalidate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdProDEList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdProDEList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdProDEList.Rows[i].Cells["StatusID"].Value) == "6")
                    {
                        grdProDEList.Rows[i].Cells["Status"].Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        grdProDEList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdProDEList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdProDEList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                grdProDEList.ClearSelection();
            }
        }

        private void GrdSupDEList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdSupDEList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdSupDEList.Rows[i].Cells["StatusID"].Value) == "6")
                    {
                        grdSupDEList.Rows[i].Cells["Status"].Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        grdSupDEList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdSupDEList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdSupDEList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                grdSupDEList.ClearSelection();
            }
        }

        private void GrdSupDEList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdSupDEList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmSupPrint":
                            try
                            {
                                string SPID = "0";
                                string DMID = "0";
                                DMID = Convert.ToString(grdSupDEList.SelectedRows[0].Cells["DMID"].Value.ToString());
                                SPID = Convert.ToString(grdSupDEList.SelectedRows[0].Cells["SPID"].Value.ToString());
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
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_Damage_SupplierWise.rpt");
                                    varHeader = "Supplier Wise Damage Products List";

                                    objBillreport.SetParameterValue("ParaSupplierId", Convert.ToInt32(SPID));
                                    objBillreport.SetParameterValue("paraDamageEntryID", Convert.ToInt32(DMID));
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

        private void CmbDMShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(cmbDMShow.SelectedValue)==169)
                {
                    btnPrint.Visible = false;
                }
                else
                {
                    btnPrint.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdDamageEntryList_SelectionChanged(object sender, EventArgs e)
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdDamageEntryList.Rows.Count > 0)
                    {
                        //if (Convert.ToString(grdDamageEntryList.Rows[grdDamageEntryList.CurrentCell.RowIndex].Cells["DM_SHID"].Value) != "0")
                        //{
                        //    tsbDelete.Visible = false;
                        //}
                        if (Convert.ToString(grdDamageEntryList.Rows[grdDamageEntryList.CurrentCell.RowIndex].Cells["StatusID"].Value) != "6" && Convert.ToString(grdDamageEntryList.Rows[grdDamageEntryList.CurrentCell.RowIndex].Cells["StatusID"].Value) != "20")
                        {
                            tsbDelete.Visible = false;
                        }
                        else
                        {
                            tsbDelete.Visible = true; tsbEdit.Visible = true; tsbNew.Visible = true;
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

        private void tsbQue_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objINV_DamageEntryQueue = new INV_DamageEntryQueue();
                MainForm.objINV_DamageEntryQueue.MdiParent = this.ParentForm;
                MainForm.objINV_DamageEntryQueue.EditAccess = SpecialPermissions.Any(sp => sp.MUP_Code == 29 && sp.EditAccess.Split(',').Contains("10")); 
                MainForm main = (MainForm)this.MdiParent;
                main.IsEntryFormOpen = true;
                main.CurrentEntryForm = MainForm.objINV_DamageEntryQueue;
                main.CurrentParentListForm = this;
                MainForm.objINV_DamageEntryQueue.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        public void udfnQueueListCount()
        {
            try
            { 
                SPDataService objspservice = new SPDataService();
                DataSet objDs = new DataSet();

                objDs = objspservice.udfnproductDamage(10, 0, 0, 0, 0, 0, "", "", "",0, "", 0,0,0); 
                objspservice.CloseConnection(); 
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

        private void cmbEntryType_Enter(object sender, EventArgs e)
        {
            try
            {
                lvSupplier.Visible = false;
                cmbEntryType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbEntryType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbEntryType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbEntryType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbEntryType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
