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
    public partial class CP_ProductList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_ProductList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Items = new CP_Product();
                MainForm.objCP_Items.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

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
            try
            {
                if (grdItemList.SelectedRows.Count > 0)
                { 
                    string result = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    { 
                        SPDataService objspdservice = new SPDataService(); 
                        result = objspdservice.udfnProductMaster(2, Convert.ToInt32(grdItemList.SelectedRows[0].Cells["ID"].Value.ToString()),"","","",0,0,0,0,0,0,0,"",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,"",0,0,0,0,"","","", "Product Delete");
                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            udfnList(); 
                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void udfnEdit()
        {
            try
            {

                if (grdItemList.SelectedRows.Count > 0)
                {
                    MainForm.objCP_Items = new CP_Product();
                    MainForm.objCP_Items.MdiParent = this.ParentForm;
                    MainForm.objCP_Items.varproductcode = Convert.ToInt32(grdItemList.SelectedRows[0].Cells["ID"].Value.ToString());
                    MainForm.objCP_Items.Show();
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
                    picLoader.Visible = true;
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************
                    grdItemList.DataSource = null;
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();

                    objDs = objdserv.udfnproductmasterlist(0, 0,Convert.ToInt32(cmbCategory.SelectedValue), Convert.ToInt32(cmbGroupType.SelectedValue), Convert.ToInt32(cmbsubgroup.SelectedValue), MainForm.pbUserID, MainForm.pbIpAddress, Convert.ToInt32(cmbConcern.SelectedValue));
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                lblNoRecordsFound.Visible = false;
                                lblNoRecordsFound.SendToBack();
                            grdItemList.DataSource = objDs.Tables[0];
                            grdItemList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                            grdItemList.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                            grdItemList.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdItemList.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdItemList.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdItemList.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                            grdItemList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                             

                            grdItemList.Columns["S.No."].Width = 50;
                            grdItemList.Columns["Product Name in English"].Width = 200;
                            grdItemList.Columns["Product Name in Tamil"].Width = 200;
                            grdItemList.Columns["Product Subgroup"].Width = 150;
                            grdItemList.Columns["Product Group"].Width = 150;
                            grdItemList.Columns["Status"].Width = 80;
                            grdItemList.Columns["ID"].Visible = false;
                            grdItemList.Columns["STSID"].Visible = false;
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
                    udfnSearchGridHead();
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
                finally
                {
              //  grdItemList.ClearSelection();
                 picLoader.Visible = false; 
                lblPC.Text = Convert.ToString(grdItemList.Rows.Count);
                }
        }
        

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 )) /*If not our desired columns*/
                                                                   //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

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
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdItemList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdItemList);
                objDser.CloseConnection();
                grdItemList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnSearchGridHead()
        {
            try
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
                DGV_SearchGrid.Columns["SI.No."].ReadOnly = true;
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
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        } 
        
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {

                int totalWidth = 0;
                int offSetValue = grdItemList.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;

                if (totalWidth - grdItemList.Width > grdItemList.HorizontalScrollingOffset && grdItemList.HorizontalScrollingOffset > 0)
                {
                    //offSetValue = offSetValue ;
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdItemList);
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

        private void CP_ProductList_KeyDown(object sender, KeyEventArgs e)
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
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D))
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

        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
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

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCategory.Focus();
                }
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

        private void CmbCategory_Leave(object sender, EventArgs e)
        {

            try
            {
                cmbCategory.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbCategory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbsubgroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbCategory.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Cmbsubgroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmbsubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGroupType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Cmbsubgroup_Leave(object sender, EventArgs e)
        {

            try
            {
                cmbsubgroup.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbsubgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbsubgroup.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Cmbsubgroup_Enter(object sender, EventArgs e)
        {

            try
            {
                cmbsubgroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbGroupType.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbGroupType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbGroupType.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbGroupType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbGroupType_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbGroupType_Enter(object sender, EventArgs e)
        {

            try
            {
                cmbGroupType.BackColor = Color.LemonChiffon;
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

        private void BtnView_Click(object sender, EventArgs e)
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
                udfnImport();
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public void udfnImport()
        {
            try
            {
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
                    ExcelSheet.Name = "Product List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdItemList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    } 

                    ExcelSheet.Cells[1, 1].Value = "Product List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;  
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    foreach (DataGridViewColumn col in grdItemList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@"; 
                            ExcelSheet.Cells[2, cIndex].Interior.Color = Color.LightSlateGray;
                            Excel.Range cell = ExcelSheet.Cells[2, cIndex];
                            cell.Font.Color = Excel.XlRgbColor.rgbWhite; 
                            if (cIndex == 1)
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 8; 
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            if (cIndex == 1 || cIndex == 7 || cIndex == 12 || cIndex == 13 || cIndex == 14 || cIndex == 15)
                            { 
                                ExcelSheet.Cells[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (cIndex == 2 || cIndex == 8 || cIndex == 9 || cIndex == 11)
                            {
                                ExcelSheet.Cells[cIndex].HorizontalAlignment = Excel.Constants.xlRight;  
                            }
                            
                            foreach (DataGridViewRow rowa in grdItemList.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                            }
                        }
                    } 
                    ExcelObj.Visible = true;
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

        private void CP_ProductList_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = cmbConcern;
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID=1 AND COMID !=-1 ORDER BY COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind.BindComboBoxListSelected("MR_ProductGroup", "PRGID !=-1 AND PRG_STSID=1 ORDER BY PRGID", "PRG_EName,PRGID", cmbGroupType, "", "PRG_EName", "PRGID");
                objDataBind.BindComboBoxListSelected("MR_ProductSubGroup", "PRSGID <> -1 AND PRSG_STSID=1", "PRSG_EName,PRSGID", cmbsubgroup, "", "PRSG_EName", "PRSGID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (5,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbCategory, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbConcern.SelectedValue = 0;
                cmbGroupType.SelectedValue = 0;
                cmbsubgroup.SelectedValue = 0;
                cmbCategory.SelectedValue = 0;

                udfnList();
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            
        }

        private void GrdItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                for (int i = 0; i < grdItemList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdItemList.Rows[i].Cells["STSID"].Value) == "1")
                    {
                        grdItemList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdItemList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdItemList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdItemList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally {
                grdItemList.ClearSelection();
            }
        }

        private void GrdItemList_DoubleClick(object sender, EventArgs e)
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

        private void GrdItemList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit();
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
