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
    public partial class CP_RackSettinglist : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_RackSettinglist()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_RackSettings = new CP_RackSettings();
                MainForm.objCP_RackSettings.MdiParent = ParentForm;
                MainForm.objCP_RackSettings.Show();
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
                DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
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
                if (grdRackSettingList.SelectedRows.Count > 0)
                {
                    MainForm.objCP_RackSettings = new CP_RackSettings();
                    MainForm.objCP_RackSettings.btnSave.Text = "Update";
                    MainForm.objCP_RackSettings.varRacksettingID = Convert.ToInt32(grdRackSettingList.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_RackSettings.PbRKID = Convert.ToInt32(grdRackSettingList.SelectedRows[0].Cells["RKID"].Value);
                    MainForm.objCP_RackSettings.PbStockLocation = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["Stock Location"].Value);
                    MainForm.objCP_RackSettings.PbRackName = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["Rack Name"].Value);
                    MainForm.objCP_RackSettings.PbPICode = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["P.I Code"].Value);
                    MainForm.objCP_RackSettings.PbProductName = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["Product Name"].Value);
                    MainForm.objCP_RackSettings.PbUnit = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["Unit"].Value);
                    MainForm.objCP_RackSettings.ShowDialog();
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
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdRackSettingList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnRackSettingsList(0,0,(Convert.ToInt16(cmbGroupType.SelectedValue)));
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
                            grdRackSettingList.DataSource = objDs.Tables[0];
                            grdRackSettingList.Columns["ID"].Visible = false;
                            grdRackSettingList.Columns["RKID"].Visible = false;
                            grdRackSettingList.Columns["S.No."].Width = 50;
                            grdRackSettingList.Columns["P.I Code"].Width = 100;
                            grdRackSettingList.Columns["Stock Location"].Width = 200;
                            grdRackSettingList.Columns["Rack Name"].Width = 150;
                            grdRackSettingList.Columns["Product Name"].Width = 250;
                            grdRackSettingList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
        private void grdBrandList_Scroll(object sender, ScrollEventArgs e)
        {
             
        }

        private void DGV_SearchGrid_Sorted(object sender, EventArgs e)
        {

        }

        private void DGV_SearchGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = grdRackSettingList.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = grdRackSettingList.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    grdRackSettingList.SortOrder == SortOrder.Ascending)
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
            //grdSupplierMappingList.Sort(newColumn, direction);
            //newColumn.HeaderCell.SortGlyphDirection =
            //    direction == ListSortDirection.Ascending ?
            //    SortOrder.Ascending : SortOrder.Descending;

            //DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
            //DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

            //DGV_SearchGrid.HorizontalScrollingOffset = grdSupplierMappingList.HorizontalScrollingOffset;
            //DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        { 
        }
        public void udfnscrollVisible(DataGridView DGV,DataGridView grdGroupList)
        {
             
        }

        private void GrdSupplierList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
        }
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_RackSettinglist_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_RackSettinglist_Load(object sender, EventArgs e)
        {
            try
            {
                cmbGroupType.Focus();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_RackGroup", "RKG_STSID=1 and RKGID !=-1 Order by RKGID", "RKG_Name,RKGID", cmbGroupType, "", "RKG_Name", "RKGID");
                objDataBind = null;
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
