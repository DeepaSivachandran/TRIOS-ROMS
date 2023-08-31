using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
//using ClosedXML.Excel;
namespace ROMS
{
    public partial class CP_RepresentativeList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataSet objDs = new DataSet();
        DataTable objDtExcel = new DataTable();
        public CP_RepresentativeList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Representative = new CP_Representative();
                MainForm.objCP_Representative.ShowDialog();
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
                if (grdreplist.SelectedRows.Count > 0)
                {
                    string result = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SPDataService objspdservice = new SPDataService();
                        result = objspdservice.udfnRepMaster(2, Convert.ToInt32(grdreplist.SelectedRows[0].Cells["ID"].Value.ToString()) ,"","","","","",0, "Representative Delete");
                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            udfnlist();
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
                MainForm.objCP_Representative = new CP_Representative();
                MainForm.objCP_Representative.btnSave.Text = "Update";
                MainForm.objCP_Representative.varrepid = Convert.ToInt32(grdreplist.SelectedRows[0].Cells["ID"].Value.ToString());
                MainForm.objCP_Representative.VARBRANDLOADID = Convert.ToString(grdreplist.SelectedRows[0].Cells["BRANDID"].Value.ToString());
                MainForm.objCP_Representative.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
           
        }

        private void CP_RepresentativeList_KeyDown(object sender, KeyEventArgs e)
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
 
        private void CP_RepresentativeList_Load(object sender, EventArgs e)
        {
            try
            {
                udfnlist();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnlist()
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdreplist.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();

                objDs = objdserv.udfnRepMasterList(0,0, MainForm.pbUserID, MainForm.pbIpAddress);
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
                            grdreplist.DataSource = objDs.Tables[0];
                            grdreplist.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdreplist.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            grdreplist.Columns["S.No."].Width = 50;
                            grdreplist.Columns["Company Name"].Width = 200;
                            grdreplist.Columns["Representative name"].Width = 200;
                            grdreplist.Columns["Phone No."].Width = 100;
                            grdreplist.Columns["WhatsApp No."].Width = 100;
                            grdreplist.Columns["Total Brands"].Width = 150; 
                            grdreplist.Columns["Status"].Width = 80;
                            grdreplist.Columns["ID"].Visible = false;
                            grdreplist.Columns["STSID"].Visible = false;
                            grdreplist.Columns["BRANDID"].Visible = false;
                            
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
                grdreplist.ClearSelection();
                picLoader.Visible = false;
                picLoader.SendToBack();
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
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    dgv2.Rows[rowIndex].Cells[i].Value = "";
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdreplist, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdreplist.Columns)
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
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdreplist.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdreplist);
                objDser.CloseConnection();
                grdreplist.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = grdreplist.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = grdreplist.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    grdreplist.SortOrder == SortOrder.Ascending)
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
            grdreplist.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;

            DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
            DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

            DGV_SearchGrid.HorizontalScrollingOffset = grdreplist.HorizontalScrollingOffset;
            DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdreplist.ColumnCount > 0)
                {
                    grdreplist.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdreplist.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Grdreplist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                for (int i = 0; i < grdreplist.Rows.Count; i++)
                {
                    if (Convert.ToString(grdreplist.Rows[i].Cells["STSID"].Value) == "1")
                    {
                        grdreplist.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdreplist.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdreplist.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdreplist.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                grdreplist.ClearSelection();
            }
        }

        private void Grdreplist_DoubleClick(object sender, EventArgs e)
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

        private void Grdreplist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit();
                }
                if (e.KeyCode == Keys.Delete)
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
    }
}
