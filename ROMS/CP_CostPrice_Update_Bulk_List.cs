using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; 
namespace ROMS
{
    public partial class CP_CostPrice_Update_Bulk_List : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;

        public string varUserID = "";
        DataSet objDs = new DataSet();
        DataTable objDtExcel = new DataTable();

        public int varSubGroupCode = 0, varUpDownKeyLocation = 0;
        public int SearchFlag = 0;
        DataTable dtDefaultGrid = new DataTable();
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public CP_CostPrice_Update_Bulk_List()
        {
            InitializeComponent();
            windowControl.Initialize(tsSubgroupList, this);
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {

            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {

                    MainForm.objCP_CostPrice_Update_Bulk = new CP_CostPrice_Update_Bulk();
                    MainForm.objCP_CostPrice_Update_Bulk.MdiParent = this.ParentForm;
                    //objMainForm.CenterEntryForm(this, MainForm.objINV_StockJournalConversion);
                    MainForm main = (MainForm)this.MdiParent;
                    main.IsEntryFormOpen = true;
                    main.CurrentEntryForm = MainForm.objCP_CostPrice_Update_Bulk;
                    main.CurrentParentListForm = this;
                    MainForm.objCP_CostPrice_Update_Bulk.Show();
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
        private void CP_SubGroupList_Load(object sender, EventArgs e)
        {
            try
            {
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 51302;
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                MenuCode = 51302;
                udfnBindCombobox();
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
        public void udfnBindCombobox() {
            try
            {
                DataBind objDataBind = new DataBind(); 
                objDataBind.BindComboBoxListSelected("DEF_Status", "STSID=0 OR STS_ModuleID = 28", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID"); 
                objDataBind = null;
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
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdSubGroupList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();

                int varSubGroupId = 0;
                int varGroupId = 0;
                int varLocationId = 0;
                int varRackId = 0;

                 
                SPDataService objDserv = new SPDataService();


                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 1;
                objMR_Product.paraGroup = varGroupId;
                objMR_Product.paraSubgroup = varSubGroupId;
                objMR_Product.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);


                objDs = objDserv.udfnCPBulkUpdatelIST(objMR_Product);
                objDserv.CloseConnection();
                 
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdSubGroupList.DataSource = objDs.Tables[0];
                            grdSubGroupList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdSubGroupList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdSubGroupList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdSubGroupList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            grdSubGroupList.Columns["Last Updated By"].Width = 280;
                            grdSubGroupList.Columns["S.No."].Width = 50;   
                            grdSubGroupList.Columns["Total Products"].Width = 100; 
                            grdSubGroupList.Columns["Status"].Width = 140;

                            grdSubGroupList.Columns["ID"].Visible = false;
                            grdSubGroupList.Columns["Status ID"].Visible = false; 
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
                SearchFlag = 0;
                //varSubGroupCode = Convert.ToInt32(cmbProductSubGroup.SelectedValue);
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
                DGV_SearchGrid.Columns["Last Updated By"].Width = 250;  
                DGV_SearchGrid.Columns["Status"].Width = 80;
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
                    udfnGridSearchHeading(grdSubGroupList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdSubGroupList.Columns)
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
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
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
        public void udfndelete()
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdSubGroupList.SelectedRows.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            TRN_RateChange objRateChange = new TRN_RateChange();

                            objRateChange.paraOriginator = "Cp Bulk Update Deleted";
                            objRateChange.paraViewType = 2;
                            objRateChange.paraDeleteFlag = 0;
                            objRateChange.paraStatusId = Convert.ToInt16(grdSubGroupList.SelectedRows[0].Cells["Status ID"].Value.ToString());

                            objRateChange.paraProductID = Convert.ToInt16(grdSubGroupList.SelectedRows[0].Cells["ID"].Value.ToString());  
                            SPDataService objspservice = new SPDataService();

                            DataService objDser = new DataService();
                            string varResult = objspservice.udfnCPBulkUpdate(objRateChange);
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

                                        objRateChange.paraOriginator = "Cp Bulk Update Deleted";
                                        objRateChange.paraViewType = 2;
                                        objRateChange.paraDeleteFlag = 1;
                                        objRateChange.paraStatusId = Convert.ToInt16(grdSubGroupList.SelectedRows[0].Cells["Status ID"].Value.ToString());

                                        objRateChange.paraProductID = Convert.ToInt16(grdSubGroupList.SelectedRows[0].Cells["ID"].Value.ToString());
                                        string varResult1 = objspservice.udfnCPBulkUpdate(objRateChange);
                                        objDser.CloseConnection();
                                        if (varResult1.Split('~')[0] == "3")
                                        {
                                            MessageBox.Show(varResult1.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            udfnList();
                                        }
                                        else { MessageBox.Show(varResult1.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
                    if (grdSubGroupList.SelectedRows.Count != 0)
                    {

                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        MainForm.objCP_CostPrice_Update_Bulk = new CP_CostPrice_Update_Bulk();
                        MainForm.objCP_CostPrice_Update_Bulk.MdiParent = this.ParentForm;

                        MainForm.objCP_CostPrice_Update_Bulk.varId = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["ID"].Value);
                        MainForm.objCP_CostPrice_Update_Bulk.grid_flag = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["Status ID"].Value);
                        //objMainForm.CenterEntryForm(this, MainForm.objINV_StockJournalConversion);
                        MainForm main = (MainForm)this.MdiParent;
                        main.IsEntryFormOpen = true;
                        main.CurrentEntryForm = MainForm.objCP_CostPrice_Update_Bulk;
                        main.CurrentParentListForm = this;
                        MainForm.objCP_CostPrice_Update_Bulk.Show();
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);

                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                btnView.Enabled = false;
                lblProductgroup.Focus();
                lvGroup.Visible = false;
                lvSubGroup.Visible = false; 
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnView.Enabled = true;
                btnView.Focus();

            }
        }

        private void CP_SubGroupList_KeyDown(object sender, KeyEventArgs e)
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

   
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
                udfnLvHide();
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

        private void BtnExport_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnLvHide();
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


        private void CmbProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                //cmbProductSubGroup.BackColor = Color.LemonChiffon;
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

        private void CmbProductSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //BeginInvoke(new Action(() => cmbProductSubGroup.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSubGroupList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdSubGroupList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdSubGroupList.Rows[i].Cells["Status ID"].Value) == "122")
                    {
                        grdSubGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdSubGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdSubGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdSubGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                grdSubGroupList.ClearSelection();
            }
        }
        private void GrdSubGroupList_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView_Click(sender, e);
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
                if ((grdSubGroupList.Rows.Count > 0))
                {
                    lblProductgroup.Focus();
                    btnExport.Enabled = false;
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
                    ExcelSheet.Name = "Product Sub Group List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdSubGroupList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Product Sub Group List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;

                   
                    foreach (DataGridViewColumn col in grdSubGroupList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 8;
                            }
                            else if (col.Name == "Stock Location")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }
                            else if (col.Name == "Rack" || col.Name == "Product Group Name")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 19;
                            }
                            else if ( col.Name == "Total Products" || col.Name == "Status")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 16;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 40;
                            }
                            if (col.Name == "Total Products")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            int varSLno = 1;
                            foreach (DataGridViewRow rowa in grdSubGroupList.Rows)
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
                                if (cIndex == 4)
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

        private void TxtProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
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
                if(e.KeyCode==Keys.Enter)
                {
                    txtProductName.Focus();
                }
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
                if (txtProductSubGroup.Text.Trim() == "") { lblSubGroupId.Text = "0"; }
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
                if(txtProductGroup.Text=="")
                {
                    lblGroupCode.Text = "0";
                }
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupCode.Text), 0, txtProductSubGroup.Text, 0, 0, 0, 0,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvSubGroup.Columns[2].Width = 200;
                                    lvSubGroup.Columns[0].Width = 200;
                                    lvSubGroup.Items.Add(objList);
                                }
                                lvSubGroup.Visible = true;
                            }
                            else
                            {
                                lvSubGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvSubGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvSubGroup.Visible = false;
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
            finally
            {
            }
        }

        private void LvSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSubGroupevent();
                }
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
                udfnSubGroupevent();
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSubGroupevent()
        {
            try
            {
                if (txtProductSubGroup.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    lblSubGroupId.Text = selectedItem.SubItems[1].Text;
                    txtProductSubGroup.Text = selectedItem.SubItems[0].Text;
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSubGroup.Visible = false; 
            }
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
         

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbStatus.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvHide()
        {
            try
            {
                lvGroup.Visible = false;
                lvSubGroup.Visible = false; 
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
                udfnLvHide();
                cmbStatus.BackColor = Color.LemonChiffon;
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

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
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

        private void TxtProductGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtProductGroup.Text,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvGroup.Columns[0].Width = 200;
                                    lvGroup.Columns[2].Width = 200;
                                    lvGroup.Items.Add(objList);
                                }
                                lvGroup.Visible = true;
                            }
                            else
                            {
                                lvGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvGroup.Visible = false;
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

        private void LvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnBindProductGroup();
                    txtProductSubGroup.Focus();
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
                udfnBindProductGroup();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnBindProductGroup()
        {
            try
            {
                if (txtProductGroup.Text != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    lblGroupCode.Text = selectedItem.SubItems[1].Text;
                    txtProductGroup.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvGroup.Visible = false;
                txtProductSubGroup.Focus();
            }
        }
             

        private void GrdSubGroupList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                udfnEdit();
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
                grdSubGroupList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSubGroupList);
                objDser.CloseConnection();
                grdSubGroupList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            finally
            {
                SearchFlag = 1;
            }
        }

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
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
            }
            catch (Exception ex)
            { objError = new DataError();
                objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdSubGroupList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdSubGroupList.SortedColumn;
                ListSortDirection direction;
                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdSubGroupList.SortOrder == SortOrder.Ascending)
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
                grdSubGroupList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                DGV_SearchGrid.HorizontalScrollingOffset = grdSubGroupList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdSubGroupList.ColumnCount > 0)
                {
                    grdSubGroupList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdSubGroupList.HorizontalScrollingOffset;
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
                grdSubGroupList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSubGroupList);
                objDser.CloseConnection();
                grdSubGroupList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
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

 

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdSubGroupList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdSubGroupList.Width > grdSubGroupList.HorizontalScrollingOffset && grdSubGroupList.HorizontalScrollingOffset > 0)
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

        private void GrdSubGroupList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdSubGroupList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdSubGroupList.Width > grdSubGroupList.HorizontalScrollingOffset && grdSubGroupList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdSubGroupList);
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
