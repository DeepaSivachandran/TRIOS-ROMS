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
{        //Created By:-Sathish
         //Created On:-09/08/2023
    public partial class PAY_AdvanceList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        MainForm objMainForm = new MainForm();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public string varUserID = "";
        Boolean BlnSearchImageYN = false;
        DateTime varmaxdate;
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public PAY_AdvanceList()
        {
            InitializeComponent();
            windowControl.Initialize(tsAdvanceList, this);
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objPAY_Advance = new PAY_Advance();
                    //MainForm.objPAY_Advance.MdiParent = this.ParentForm;
                    objMainForm.CenterEntryForm(this, MainForm.objPAY_Advance);
                    MainForm.objPAY_Advance.ShowDialog();
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
                    if (grdAdvanceList.SelectedRows.Count > 0)
                    {
                        if (Convert.ToString(grdAdvanceList.Rows[grdAdvanceList.CurrentCell.RowIndex].Cells["AD_STSID"].Value) == "74")
                        {
                            string varResult = "";
                            DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                SPDataService objspservice = new SPDataService();
                                Model.TRN_Advance objTRN_Advance = new Model.TRN_Advance();
                                objTRN_Advance.ViewType = 2;
                                objTRN_Advance.paraAdvanceId = Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["ADID"].Value);
                                objTRN_Advance.paraOriginator = "Advance Delete";
                                objTRN_Advance.paraDeleteFlag = 0;
                                varResult = objspservice.udfnAdvance(objTRN_Advance);
                                objspservice.CloseConnection();

                                //varResult = objspservice.udfnAdvance(2, Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["ADID"].Value), 0, "", 0, 0, 0, "Advance Delete", 0);
                                //objspservice.CloseConnection();
                                if (varResult.Split('~')[0] == "3")
                                {
                                    if (varResult.Split('~')[1] == "1")
                                    {
                                        MainForm.objCP_Verify = new CP_Verify();
                                        MainForm.objCP_Verify.ShowDialog();
                                        varUserID = MainForm.objCP_Verify.varUserId;
                                        if (MainForm.objCP_Verify.flag == 1)
                                        {
                                            objTRN_Advance.ViewType = 2;
                                            objTRN_Advance.paraAdvanceId = Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["ADID"].Value);
                                            objTRN_Advance.paraOriginator = "Advance Delete";
                                            objTRN_Advance.paraDeleteFlag = 1;
                                            varResult = objspservice.udfnAdvance(objTRN_Advance);
                                            objspservice.CloseConnection();
                                            //objspservice = new SPDataService();
                                            //varResult = objspservice.udfnAdvance(2, Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["ADID"].Value), 0, "", 0, 0, 0, "Advance Delete", 1);
                                            //objspservice.CloseConnection();
                                            if (varResult.Split('~')[0] == "3")
                                            {
                                                MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                udfnList();
                                            }
                                            else { MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void udfnEdit()
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdAdvanceList.SelectedRows.Count > 0)
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        MainForm.objPAY_Advance = new PAY_Advance();
                        //MainForm.objPAY_Advance.MdiParent = ParentForm;
                        MainForm.objPAY_Advance.btnSave.Text = "Update";
                        MainForm.objPAY_Advance.pbADID = Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["ADID"].Value);
                        MainForm.objPAY_Advance.PbStatus = Convert.ToInt32(grdAdvanceList.SelectedRows[0].Cells["AD_STSID"].Value);
                        MainForm.objPAY_Advance.varEditFlag = 1;
                        objMainForm.CenterEntryForm(this, MainForm.objPAY_Advance);
                        MainForm.objPAY_Advance.ShowDialog();
                    }
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
                grdAdvanceList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************    
                SPDataService objspservice = new SPDataService();
                Model.TRN_Advance objTRN_Advance = new Model.TRN_Advance();
                objTRN_Advance.ViewType = 0;
                objTRN_Advance.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_Advance.paraFromDate = dpFromDate.Text;
                objTRN_Advance.paraToDate = dpToDate.Text;
                objTRN_Advance.paraSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_Advance.paraScheduleId = Convert.ToInt32(lblschedleCode.Text);
                objTRN_Advance.paraStatusID = Convert.ToInt32(cmbstatus.SelectedValue);
                objDs = objspservice.udfnAdvanceList(objTRN_Advance);
                objspservice.CloseConnection();

                //objDs = objspservice.udfnAdvanceList(0, 0, Convert.ToInt32(cmbConcern.SelectedValue), dpFromDate.Text, dpToDate.Text,Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), Convert.ToInt32(cmbstatus.SelectedValue));
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdAdvanceList.DataSource = objDs.Tables[0];

                            grdAdvanceList.Columns["clmPrint"].Visible = true;
                            grdAdvanceList.Columns["clmEnvelopPrint"].Visible = true;
                            grdAdvanceList.Columns["ADID"].Visible = false;
                            grdAdvanceList.Columns["AD_COMID"].Visible = false;
                            grdAdvanceList.Columns["AD_SPID"].Visible = false;
                            grdAdvanceList.Columns["AD_SPSCID"].Visible = false;
                            grdAdvanceList.Columns["AD_STSID"].Visible = false;
                            grdAdvanceList.Columns["Source"].Visible = false;

                            grdAdvanceList.Columns["ChequeDate"].Visible = false;
                            grdAdvanceList.Columns["PrintFlag"].Visible = false;
                            grdAdvanceList.Columns["RPTName"].Visible = false;
                            grdAdvanceList.Columns["ChequeSupplierName"].Visible = false;
                            grdAdvanceList.Columns["BankID"].Visible = false; 

                            grdAdvanceList.Columns["S.No."].Width = 50;
                            grdAdvanceList.Columns["Status"].Width = 150;
                            grdAdvanceList.Columns["Transaction Date"].Width = 110;
                            grdAdvanceList.Columns["Created By"].Width = 170;
                            grdAdvanceList.Columns["Updated By"].Width = 170;
                            grdAdvanceList.Columns["Receipt No."].Width = 80;
                            grdAdvanceList.Columns["Current Balance"].Width = 110;
                            grdAdvanceList.Columns["Amount"].Width = 80;
                            grdAdvanceList.Columns["Concern"].Width = 60;
                            grdAdvanceList.Columns["Supplier Name"].Width = 250;
                            grdAdvanceList.Columns["GSTIN"].Width = 120;
                            grdAdvanceList.Columns["clmPrint"].Width = 40;
                            grdAdvanceList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAdvanceList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAdvanceList.Columns["Transaction Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAdvanceList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdAdvanceList.Columns["Current Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                    objspservice.CloseConnection();
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
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["ADID"].Visible = false;
                DGV_SearchGrid.Columns["AD_COMID"].Visible = false;
                DGV_SearchGrid.Columns["AD_SPID"].Visible = false;
                DGV_SearchGrid.Columns["AD_SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["AD_STSID"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Status"].Width = 80;
                DGV_SearchGrid.Columns["GSTIN"].Width = 150;
                DGV_SearchGrid.Columns["Transaction Date"].Width = 120;
                DGV_SearchGrid.Columns["Supplier Name"].Width = 350; DGV_SearchGrid.ScrollBars = ScrollBars.Both;
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
                if (grdAdvanceList.ColumnCount > 0)
                {
                    grdAdvanceList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdAdvanceList.HorizontalScrollingOffset;
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
                grdAdvanceList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdAdvanceList);
                objDser.CloseConnection();
                grdAdvanceList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                    udfnGridSearchHeading(grdAdvanceList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdAdvanceList.Columns)
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
                    DGV_SearchGrid.Columns[1].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[2].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[2].Value = new Bitmap(1, 1);
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
                        bs.DataSource = grdAdvanceList.DataSource;
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
                        grdAdvanceList.DataSource = bs;
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
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdAdvanceList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdAdvanceList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdAdvanceList.SortOrder == SortOrder.Ascending)
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
                        grdAdvanceList.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                        DGV_SearchGrid.HorizontalScrollingOffset = grdAdvanceList.HorizontalScrollingOffset;
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
                    int offSetValue = grdAdvanceList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdAdvanceList.Width > grdAdvanceList.HorizontalScrollingOffset && grdAdvanceList.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdAdvanceList);
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
                objMR_Master.paraFlag = 20;
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
        public void udfnConcernLoad()
        {
            try
            {
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
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void GrdUnitList_DoubleClick(object sender, EventArgs e)
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
        private void GrdUnitList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                udfnEdit();
            }
        }
        private void GrdUnitList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdAdvanceList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdAdvanceList.Width > grdAdvanceList.HorizontalScrollingOffset && grdAdvanceList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdAdvanceList);
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
            grdAdvanceList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdAdvanceList);
            objDser.CloseConnection();
            grdAdvanceList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                //DataService objDser = new DataService();
                //grdUnitList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdUnitList);
                //objDser.CloseConnection();
                //grdUnitList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.BringToFront();
                //RPTViewer.SendToBack();
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    objMR_Supplier.ParaToDate = dpToDate.Text;
                    objMR_Supplier.paraFlag = 9;
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

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                lblschedleCode.Focus();
                if (Convert.ToString(txtSupplier.Text).Trim() != "")
                {
                    //txtSupplier.BackColor = Color.White;
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 46;
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
                    lblSupplierCode.Text = values[0];
                    lblschedleCode.Text = values[1];
                    txtSupplier.BackColor = Color.White;
                }
                else
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                udfnList();
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

        private void GrdAdvanceList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdAdvanceList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdAdvanceList.Rows[i].Cells["AD_STSID"].Value) == "75")
                    {
                        grdAdvanceList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdAdvanceList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else if(Convert.ToString(grdAdvanceList.Rows[i].Cells["AD_STSID"].Value) == "74")
                    {
                        grdAdvanceList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdAdvanceList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grdAdvanceList.Rows[i].Cells["AD_STSID"].Value) == "78")
                    {
                        grdAdvanceList.Rows[i].Cells["Status"].Style.BackColor = Color.Orange;
                        grdAdvanceList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else   if (Convert.ToString(grdAdvanceList.Rows[i].Cells["AD_STSID"].Value) == "118")
                    {
                        grdAdvanceList.Rows[i].Cells["Status"].Style.BackColor = Color.Gold;
                        grdAdvanceList.Rows[i].Cells["Status"].Style.ForeColor = Color.Black;
                    }
                    else if (Convert.ToString(grdAdvanceList.Rows[i].Cells["AD_STSID"].Value) == "119")
                    {
                        grdAdvanceList.Rows[i].Cells["Status"].Style.BackColor = Color.LightGreen;
                        grdAdvanceList.Rows[i].Cells["Status"].Style.ForeColor = Color.Black;
                    }
                    if (Convert.ToString(grdAdvanceList.Rows[i].Cells["PrintFlag"].Value) == "0")
                    {
                        grdAdvanceList.Rows[i].Cells["clmChequePrint"].ReadOnly = true;
                        DataGridViewTextBoxCell print = new DataGridViewTextBoxCell();
                        print.Value = "";
                        grdAdvanceList.Rows[i].Cells["clmChequePrint"] = print;
                        print.ReadOnly = true;
                    }
                    grdAdvanceList.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdAdvanceList_DoubleClick(object sender, EventArgs e)
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

        private void PAY_AdvanceList_KeyDown(object sender, KeyEventArgs e)
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
                    tsbDelete_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm objMainForm = new MainForm();
                    objMainForm.udfnCloseChildForms();
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
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

        private void PAY_AdvanceList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 404;
                udfnDate();
                udfnConcernLoad();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (0,17) AND STSID!=-1", "STS_Name,STSID", cmbstatus, "", "STS_Name", "STSID");
                cmbstatus.SelectedValue = 0;
                objDataBind = null;
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                txtSupplier.Text = "";
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdAdvanceList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                udfnEdit();
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

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbstatus.Focus();
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
                btnExport.Enabled = false;
                lblSupplierCode.Focus();
                if ((grdAdvanceList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Advance";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdAdvanceList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Advance";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdAdvanceList.Columns)
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
                            else if (col.Name == "Transaction Date")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 20;
                            }
                            else if (col.Name == "Supplier Name")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 50;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 15;
                            }
                            if (col.Name == "S.No." || col.Name == "Transaction Date")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Amount")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdAdvanceList.Rows)
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

        private void DpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpToDate.MinDate = varmindate;
                dpToDate.MaxDate = varmaxdate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
        public void udfnListViewData()
        {
            try
            {
                if (txtSupplier.Text != "")
                {
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedleCode.Text = selectedItem.SubItems[2].Text;
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                    //udfnsupplierLoad();
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    cmbstatus.Focus();
                }
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

        private void GrdAdvanceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdAdvanceList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmChequePrint":
                            if (Convert.ToUInt32(grdAdvanceList.SelectedRows[0].Cells["BankID"].Value) != 0)
                            {
                                DialogResult result1 = DialogResult.Yes;
                                SPDataService objDServs = new SPDataService();
                                string varMessage = objDServs.udfnGetMessages(87);
                                objDServs.CloseConnection();
                                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result1 == DialogResult.Yes)
                                {
                                    string varRPTName = "";
                                    string varGrandTotal = Convert.ToString(grdAdvanceList.SelectedRows[0].Cells["Amount"].Value);
                                    decimal varMRP = Math.Round(Convert.ToDecimal(varGrandTotal.Trim()), 2, MidpointRounding.AwayFromZero);
                                    string varAmt = string.Format("{0:0}", varMRP);
                                    int varAmount = Convert.ToInt32(varAmt);
                                    string lblAmount = Currency.NumbersToWords(varAmount);
                                    //Added By Sathish ON 04-09-2025 For Check Date Without Space Format
                                    DateTime ChequeDateTime = DateTime.ParseExact(Convert.ToString(grdAdvanceList.SelectedRows[0].Cells["ChequeDate"].Value), "dd/MM/yyyy", null);
                                    string chequeDate = ChequeDateTime.ToString("ddMMyyyy");

                                    string varSupplierName = Convert.ToString(grdAdvanceList.SelectedRows[0].Cells["ChequeSupplierName"].Value);
                                    varRPTName = Convert.ToString(grdAdvanceList.SelectedRows[0].Cells["RPTName"].Value);
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\" + varRPTName);
                                    objBillreport.SetParameterValue("paraSupplierName", varSupplierName);
                                    objBillreport.SetParameterValue("paraAmountInWords", lblAmount);
                                    objBillreport.SetParameterValue("paraAmount", varGrandTotal);
                                    objBillreport.SetParameterValue("paraChequeDate", chequeDate);
                                    objValidation.CrySqlConnection(objBillreport);
                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                            }
                            break;
                        case "clmPrint":
                            try
                            {
                                int ADID = 0;string varAmountInWords = "";
                                ADID = Convert.ToInt32((grdAdvanceList.SelectedRows[0].Cells["ADID"].Value.ToString()));
                                string varAmountvalue = Convert.ToString((grdAdvanceList.SelectedRows[0].Cells["Amount"].Value.ToString()));
                                decimal varMRP = Math.Round(Convert.ToDecimal(varAmountvalue), 2, MidpointRounding.AwayFromZero);
                                varAmountvalue = string.Format("{0:0}", varMRP);
                                int varAmount = Convert.ToInt32(varAmountvalue);
                                varAmountInWords = Currency.NumbersToWords(varAmount);
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
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PAY_Advance_Receipt.rpt");
                                    varHeader = "Advance Receipt";

                                    objBillreport.SetParameterValue("paraAdvanceId", Convert.ToInt32(ADID), objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraAmountName", Convert.ToString(varAmountInWords), objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraAdvanceId", Convert.ToInt32(ADID), objBillreport.Subreports[1].Name.ToString());
                                    objBillreport.SetParameterValue("paraAmountName", Convert.ToString(varAmountInWords), objBillreport.Subreports[1].Name.ToString());
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[1].Name.ToString());
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[1].Name.ToString());
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
                        case "clmEnvelopPrint":
                            string varSPID = Convert.ToString((grdAdvanceList.SelectedRows[0].Cells["AD_SPID"].Value.ToString()));
                            MainForm.objLabelCount = new LabelCount();
                            MainForm.objLabelCount.varSupplierIds = varSPID;
                            MainForm.objLabelCount.ShowDialog();
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

        private void GrdAdvanceList_SelectionChanged(object sender, EventArgs e)
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    int varSource = Convert.ToInt32(grdAdvanceList.Rows[grdAdvanceList.CurrentCell.RowIndex].Cells["Source"].Value);
                    if (Convert.ToString(grdAdvanceList.Rows[grdAdvanceList.CurrentCell.RowIndex].Cells["AD_STSID"].Value) == "74")
                    {
                        tsbDelete.Visible = true;
                    }
                    /* 1- From GRN, 2 - Manual, 3 - From Supplier*/
                    else if (varSource != 2)
                    {
                        tsbDelete.Visible = false;
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
}
