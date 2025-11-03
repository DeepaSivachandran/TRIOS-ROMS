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
    public partial class CP_BrandList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        MainForm objMainForm = new MainForm();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public int varGroupId = 0;
        public int varSubGroupId = 0;
        public string varUserID = "";
        int varActiveCount = 0, varInactiveCount = 0;
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();

        public CP_BrandList()
        {
            InitializeComponent();
            windowControl.Initialize(tsBrandList, this);
        }

        public void udfnCmbProductGroup()
        {
            try
            { 
              ///  SPDataService objdserv = new SPDataService();
              //  DataSet objDT = new DataSet();
              //  int varViewType = 3;
              //  objDT = objdserv.udfnGroupList(varViewType, 0,0,"");
              //  objdserv.CloseConnection();
              //  cmbProductgroup.DataSource = null;
              //  if (objDT != null)
              //  {
              //      if (objDT.Tables.Count > 0)
              //      {
              //          if (objDT.Tables[0].Rows.Count > 0)
              //          {
              //              cmbProductgroup.ValueMember = "PRGID";
              //              cmbProductgroup.DisplayMember = "PRG_EName";
              //              cmbProductgroup.DataSource = objDT.Tables[0];
              //          }
              //      }
              //  }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbProductSubGroup()
        {
            try
            { 
               // DataSet objDT = new DataSet();
               // SPDataService objdserv = new SPDataService();
               // int varViewType =5 ;
               // if (varGroupId==0)
               // {
               //     varViewType = 4;
               // }
               // objDT = objdserv.udfnSubGroupList(varViewType, 0,"", varGroupId,0,"");
               // objdserv.CloseConnection();
               //// cmbProductSubGroup.DataSource = null;
               // if (objDT != null)
               // {
               //     if (objDT.Tables.Count > 0)
               //     {
               //         if (objDT.Tables[0].Rows.Count > 0)
               //         {
               //             cmbProductSubGroup.ValueMember = "PRSGID";
               //             cmbProductSubGroup.DisplayMember = "PRSG_EName";
               //             cmbProductSubGroup.DataSource = objDT.Tables[0];
               //         }
               //     }
               // }
               // objdserv.CloseConnection(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objCP_Brand = new CP_Brand();
                    //MainForm.objCP_Brand.MdiParent = ParentForm;
                    objMainForm.CenterEntryForm(this, MainForm.objCP_Brand);
                    MainForm.objCP_Brand.ShowDialog();
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

        private void CP_BrandList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 507;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                cmbStatus.SelectedValue = 0;
                udfnList();
                this.ActiveControl = txtProductGroup;
                MenuCode = 103;
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

        public void udfndelete()
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdBrandList.SelectedRows.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SPDataService objDser = new SPDataService();
                            string varResult = objDser.udfnBrand(2, Convert.ToInt32(grdBrandList.SelectedRows[0].Cells["ID"].Value.ToString()), "", "", 0, "", "Brand Deletion", varUserID, 0);
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
                                        varResult = objDser.udfnBrand(2, Convert.ToInt32(grdBrandList.SelectedRows[0].Cells["ID"].Value.ToString()), "", "", 0, "", "Brand Deletion", varUserID, 1);
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

        private void udfnEdit()
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdBrandList.SelectedRows.Count > 0)
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        MainForm.objCP_Brand = new CP_Brand();
                        //MainForm.objCP_Brand.MdiParent = ParentForm;
                        MainForm.objCP_Brand.btnSave.Text = "Update";
                        MainForm.objCP_Brand.varId = Convert.ToInt32(grdBrandList.SelectedRows[0].Cells["ID"].Value);
                        MainForm.objCP_Brand.varStatusid = Convert.ToInt32(grdBrandList.SelectedRows[0].Cells["Status ID"].Value);
                        objMainForm.CenterEntryForm(this, MainForm.objCP_Brand);
                        MainForm.objCP_Brand.ShowDialog();
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
                grdBrandList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                int varGroupId = 0;
                if (txtProductGroup.Text == "")
                {
                    varGroupId = 0;
                }
                else
                {
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtProductGroup.Text.Trim(),0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varGroupId = Convert.ToInt32(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }

                int varSubGroupId = 0;
                if (txtProductSubGroup.Text == "")
                {
                    varSubGroupId = 0;
                }
                else
                {
                    //DataService objDServ = new DataService();
                    //string varId_SubGroup = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_ProductSubGroup WHERE PRSG_EName = '" + txtProductSubGroup.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT PRSGID FROM MR_ProductSubGroup WHERE PRSG_EName = '" + txtProductSubGroup.Text.Trim() + "') END AS PRSGID ");
                    //objDServ.CloseConnection();
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtProductSubGroup.Text.Trim(), 0, 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varSubGroupId = Convert.ToInt16(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                objDs = objdserv.udfnBrandList(0, "", varGroupId, varSubGroupId,0,"",Convert.ToInt32(cmbStatus.SelectedValue));
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
                            grdBrandList.DataSource = objDs.Tables[0];
                            grdBrandList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdBrandList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdBrandList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdBrandList.Columns["Total Groups"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdBrandList.Columns["Total Subgroups"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            grdBrandList.Columns["S.No."].Width = 50;
                            grdBrandList.Columns["Brand Name in English"].Width = 250;
                            grdBrandList.Columns["Brand Name in Tamil"].Width = 250;
                            grdBrandList.Columns["Total Products"].Width = 100;
                            grdBrandList.Columns["Total Groups"].Width = 100;
                            grdBrandList.Columns["Total Subgroups"].Width = 150;
                            grdBrandList.Columns["Status"].Width = 80;

                            grdBrandList.Columns["ID"].Visible = false;
                            grdBrandList.Columns["Status ID"].Visible = false;
                            grdBrandList.Columns["Brand Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
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
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
                // udfnSearchGridHead();
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
                picLoader.Visible = false;
                picLoader.SendToBack();
                lblProductCount.Text = Convert.ToString(grdBrandList.Rows.Count);
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["Status ID"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Brand Name in English"].Width = 250;
                DGV_SearchGrid.Columns["Brand Name in Tamil"].Width = 250;
                DGV_SearchGrid.Columns["Total Products"].Width = 100;
                DGV_SearchGrid.Columns["Total Groups"].Width = 100;
                DGV_SearchGrid.Columns["Total Subgroups"].Width = 150;
                DGV_SearchGrid.Columns["Status"].Width = 80;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 

        public void grdBrandList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit();
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
      
        private void CmbProductgroup_Enter(object sender, EventArgs e)
        {
            try
            {
                //cmbProductgroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductgroup_Leave(object sender, EventArgs e)
        {
            try
            {
                //cmbProductgroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbProductSubGroup.Focus();
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductgroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbProductgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    BeginInvoke(new Action(() => cmbProductgroup.Select(int.MaxValue, 0)));
            //    varGroupId= Convert.ToInt32(cmbProductgroup.SelectedValue);
            //    udfnCmbProductSubGroup();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void CmbProductSubGroup_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    cmbProductSubGroup.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void CmbProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                //cmbProductSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductSubGroup_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbProductSubGroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbProductSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    BeginInvoke(new Action(() => cmbProductSubGroup.Select(int.MaxValue, 0)));
            //    varSubGroupId = Convert.ToInt32(cmbProductSubGroup.SelectedValue);
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
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

        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           try
           {   
                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdBrandList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdBrandList);
                    objDser.CloseConnection();
                    grdBrandList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //DGV_SearchGrid_CellPainting(sender,e);
           }
           catch (Exception ex)
           {
                objError = new DataError(); objError.WriteFile(ex);
           }
            
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdBrandList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdBrandList.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn && grdBrandList.SortOrder == SortOrder.Ascending)
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
                grdBrandList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGrid.HorizontalScrollingOffset = grdBrandList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdBrandList.ColumnCount > 0)
                {
                    grdBrandList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdBrandList.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
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
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdBrandList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdBrandList.Columns)
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
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void GrdBrandList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                varActiveCount = 0; varInactiveCount = 0;
                for (int i = 0; i < grdBrandList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdBrandList.Rows[i].Cells["Status ID"].Value) == "1")
                    {
                        grdBrandList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdBrandList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                        varActiveCount++;
                    }
                    else
                    {
                        grdBrandList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdBrandList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                        varInactiveCount++;
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
                grdBrandList.ClearSelection();
                lblActiveCount.Text = Convert.ToString(varActiveCount);
                lblInactiveCount.Text = Convert.ToString(varInactiveCount);
            }
        }

        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Visible = false;
                lvSubGroup.Visible = false;
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBrandList_MouseDoubleClick(object sender, MouseEventArgs e)
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
            finally
            {
                grdBrandList.ClearSelection();
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

        private void BtnView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnView_Click(sender,e);
                }
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
                if ((grdBrandList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Brand List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdBrandList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Brand List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;

                  

                    foreach (DataGridViewColumn col in grdBrandList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "S.No."  )
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            else if (col.Name == "Total Groups" || col.Name == "Total Subgroups" || col.Name == "Total Products" || col.Name == "Status")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 50;
                            }

                            if(col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            else if (col.Name == "Total Products" || col.Name == "Total Groups" || col.Name == "Total Subgroups")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            int varSLno = 1;
                            foreach (DataGridViewRow rowa in grdBrandList.Rows)
                            {
                                if (cIndex == 1)
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex] = varSLno;
                                    varSLno++;
                                }
                                else
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                                }
                                if (cIndex == 3)
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
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(41);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                lvGroup.Visible = false;
                lvSubGroup.Visible = false;
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

        private void BtnExport_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnExport_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_BrandList_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtProductGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(8, 0, 0, txtProductGroup.Text,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvGroup.Columns[0].Width = 200;
                                    lvGroup.Columns[1].Width = 200;
                                    lvGroup.Items.Add(objList);
                                }
                                lvGroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvGroup.Visible = false;
                    lvGroup.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(8, 0, "", varGroupId, 0, txtProductSubGroup.Text,0,0,0,0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {

                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvSubGroup.Columns[0].Width = 200;
                                    lvSubGroup.Columns[1].Width = 200;
                                    lvSubGroup.Items.Add(objList);
                                }
                                lvSubGroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvSubGroup.Visible = false;
                    lvSubGroup.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvGroup.Items.Count == 0 || txtProductGroup.Text == "")
                    {
                        txtProductGroup.Focus();
                        lvGroup.Visible = false;
                    }
                    else
                    {
                        lvGroup.Focus();
                    }
                    if (lvGroup.Items.Count > 0)
                    {
                        lvGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSubGroup.Items.Count == 0 || txtProductSubGroup.Text == "")
                    {
                        txtProductSubGroup.Focus();
                        lvSubGroup.Visible = false;
                    }
                    else
                    {
                        lvSubGroup.Focus();
                    }
                    if (lvSubGroup.Items.Count > 0)
                    {
                        lvSubGroup.Items[0].Selected = true;
                    }
                }
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

        private void LvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvGroup();
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvSubGroup();
                    cmbStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvGroup()
        {
            try
            {
                if (txtProductGroup.Text != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    txtProductGroup.Text = selectedItem.SubItems[0].Text;
                    varGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvGroup.Visible = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvSubGroup()
        {
            try
            {
                if (txtProductSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    txtProductSubGroup.Text = selectedItem.SubItems[0].Text;
                    varSubGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvSubGroup.Visible = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvGroup();
                txtProductSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvSubGroup();
                cmbStatus.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LblProductgroup_Click(object sender, EventArgs e)
        {

        }

        private void TxtProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Visible = false;
                txtProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.White;
                if (txtProductGroup.Text.Trim() == "") { varGroupId = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Visible = false;
                txtProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.White;
                if (txtProductSubGroup.Text.Trim() == "") { varSubGroupId = 0; }
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
                DataService objDser = new DataService();
                grdBrandList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdBrandList);
                objDser.CloseConnection();
                grdBrandList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblProductCount.Text = Convert.ToString(grdBrandList.Rows.Count);
            }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdBrandList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdBrandList.Width > grdBrandList.HorizontalScrollingOffset && grdBrandList.HorizontalScrollingOffset > 0)
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

        private void GrdBrandList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdBrandList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdBrandList.Width > grdBrandList.HorizontalScrollingOffset && grdBrandList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdBrandList);
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

        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Visible = false;
                lvSubGroup.Visible = false;
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
    }
}
