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
{   //Created By:-Sathish
    //Created On:-17/08/2023
    public partial class CP_LocationList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public int varStockApplicable = 0;
        public string varUserID = "";
        public int SearchFlag = 0;
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();

        public CP_LocationList()
        {
            InitializeComponent();
            windowControl.Initialize(tsLocation, this);
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objCP_Location = new CP_Location();
                    MainForm.objCP_Location.FormBorderStyle = FormBorderStyle.FixedSingle;
                    //MainForm.objCP_Location.cmbStockApplicable.Enabled = false;
                    varStockApplicable = 1;
                    MainForm.objCP_Location.ShowDialog();
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
        private void CP_LocationList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 509;
                cmbConcern.Focus();
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                int varViewType = 2;
                objDs = objdserv.udfnCompanyList(varViewType, 0, MainForm.pbUserID, MainForm.pbIpAddress,0);
                objdserv.CloseConnection();
                cmbConcern.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDs.Tables[0];
                        }
                    }
                }
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                DataSet objDS = new DataSet();
                SPDataService objDServ = new SPDataService();

                MR_Location objMR_Location = new MR_Location();
                objMR_Location.paraViewType = 18;
                objDs = objdserv.udfnStockLocationList(objMR_Location);
                objdserv.CloseConnection();
                objDServ.CloseConnection();
                cmbLocationType.DataSource = null;
                if (objDS != null)
                {
                    if (objDS.Tables.Count > 0)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            cmbLocationType.ValueMember = "MSTID";
                            cmbLocationType.DisplayMember = "MST_DisplayText";
                            cmbLocationType.DataSource = objDS.Tables[0];
                        }
                    }
                }
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (1) OR STSID=0", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                cmbStatus.SelectedValue = 0;
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
                grdGodownList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();

                MR_Location objMR_Location = new MR_Location();
                objMR_Location.paraViewType = 0;
                objMR_Location.ParaCompanycode = Convert.ToInt16(cmbConcern.SelectedValue);
                objMR_Location.paraLocationType = Convert.ToInt16(cmbLocationType.SelectedValue);
                objMR_Location.paraStatusId = Convert.ToInt16(cmbStatus.SelectedValue);
                objDs = objspservice.udfnStockLocationList(objMR_Location);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                        //    grdGodownList.Columns["S.No."].Frozen = true;
                        //    grdGodownList.Columns["GSTIN"].DefaultCellStyle.BackColor = Color.AliceBlue;
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdGodownList.DataSource = objDs.Tables[0];
                            grdGodownList.Columns["ID"].Visible = false;
                            grdGodownList.Columns["ConcernID"].Visible = false;
                            grdGodownList.Columns["LocationTypeID"].Visible = false;
                            grdGodownList.Columns["StockApplicableID"].Visible = false;
                            grdGodownList.Columns["GodownTypeID"].Visible = false;
                            grdGodownList.Columns["StatusID"].Visible = false;
                            grdGodownList.Columns["DefaultID"].Visible = false;
                            grdGodownList.Columns["RKCreationID"].Visible = false;
                            grdGodownList.Columns["RKGCreationID"].Visible = false;
                            grdGodownList.Columns["S.No."].Width = 50;
                            grdGodownList.Columns["Concern"].Width = 70;
                            grdGodownList.Columns["Location Type"].Width = 90;
                            grdGodownList.Columns["Location Name in English"].Width = 200;
                            grdGodownList.Columns["Location Name in Tamil"].Width = 200;
                            grdGodownList.Columns["Rack Group Creation"].Width = 130;
                            grdGodownList.Columns["Short Name"].Width = 85;
                            grdGodownList.Columns["Stock Applicable"].Width = 105;
                            grdGodownList.Columns["Status"].Width = 80;
                            grdGodownList.Columns["Godown Type"].Width = 90;
                            grdGodownList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGodownList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGodownList.Columns["Godown Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGodownList.Columns["No.of Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGodownList.Columns["Location Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
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
                else { DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalCount.Text = Convert.ToString(grdGodownList.Rows.Count);
                picLoader.Visible = false;
                picLoader.SendToBack();
                btnView.Enabled = true;
                txtSearchbyLocationName.Text = "";
                SearchFlag = 0;
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["ConcernID"].Visible = false;
                DGV_SearchGrid.Columns["LocationTypeID"].Visible = false;
                DGV_SearchGrid.Columns["StockApplicableID"].Visible = false;
                DGV_SearchGrid.Columns["GodownTypeID"].Visible = false;
                DGV_SearchGrid.Columns["StatusID"].Visible = false;
                DGV_SearchGrid.Columns["DefaultID"].Visible = false;
                DGV_SearchGrid.Columns["RKCreationID"].Visible = false;
                DGV_SearchGrid.Columns["RKGCreationID"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Location Name in English"].Width = 200;
                DGV_SearchGrid.Columns["Location Name in Tamil"].Width = 200;
                DGV_SearchGrid.Columns["Rack Group Creation"].Width = 130;
                DGV_SearchGrid.Columns["Short Name"].Width = 100;
                DGV_SearchGrid.Columns["Stock Applicable"].Width = 110;
                DGV_SearchGrid.Columns["Status"].Width = 80;
                DGV_SearchGrid.Columns["Godown Type"].Width = 150;
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
                    udfnGridSearchHeading(grdGodownList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdGodownList.Columns)
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
                    if (Convert.ToString(grdGodownList.Rows[grdGodownList.CurrentCell.RowIndex].Cells["DefaultID"].Value) != "1" && Convert.ToString(grdGodownList.Rows[grdGodownList.CurrentCell.RowIndex].Cells["DefaultID"].Value) != "2")
                    {
                        if (grdGodownList.SelectedRows.Count > 0)
                        {
                            string varResult = "";
                            DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                SPDataService objspservice = new SPDataService();
                                varResult = objspservice.udfnStockLocation(2, Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["ID"].Value.ToString()), 0, 0, "", "", "", 0, 0, 0, "Stock Delete", varUserID, 0, 0, 0);
                                objspservice.CloseConnection();
                                if (varResult.Split('~')[0] == "3")
                                {
                                    if (varResult.Split('~')[1] == "1")
                                    {
                                        MainForm.objCP_Verify = new CP_Verify();
                                        MainForm.objCP_Verify.ShowDialog();
                                        varUserID = MainForm.objCP_Verify.varUserId;
                                        if (MainForm.objCP_Verify.flag == 1)
                                        {
                                            objspservice = new SPDataService();
                                            varResult = objspservice.udfnStockLocation(2, Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["ID"].Value.ToString()), 0, 0, "", "", "", 0, 0, 0, "Stock Delete", varUserID, 0, 0, 1);
                                            objspservice.CloseConnection();
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
                    varStockApplicable = 0;
                    if (grdGodownList.SelectedRows.Count > 0)
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        if (Convert.ToString(grdGodownList.Rows[grdGodownList.CurrentCell.RowIndex].Cells["DefaultID"].Value) == "1" || Convert.ToString(grdGodownList.Rows[grdGodownList.CurrentCell.RowIndex].Cells["DefaultID"].Value) == "2")
                        {
                            MainForm.objCP_Location = new CP_Location();
                            MainForm.objCP_Location.btnSave.Visible = false;
                            MainForm.objCP_Location.cmbConcern.Enabled = false;
                            MainForm.objCP_Location.cmbLocationType.Enabled = false;
                            MainForm.objCP_Location.txtLocationNameInEnglish.Enabled = false;
                            MainForm.objCP_Location.txtLocationNameInTamil.Enabled = false;
                            MainForm.objCP_Location.txtShortName.Enabled = false;
                            MainForm.objCP_Location.pnlGodownType.Enabled = false;
                            MainForm.objCP_Location.cmbStockApplicable.Enabled = false;
                            MainForm.objCP_Location.pnlStatus.Enabled = false;
                        }
                        else
                        {
                            MainForm.objCP_Location = new CP_Location();
                            MainForm.objCP_Location.btnSave.Visible = true;
                            MainForm.objCP_Location.cmbConcern.Enabled = false;
                            MainForm.objCP_Location.cmbLocationType.Enabled = true;
                            MainForm.objCP_Location.txtLocationNameInEnglish.Enabled = true;
                            MainForm.objCP_Location.txtLocationNameInTamil.Enabled = true;
                            MainForm.objCP_Location.txtShortName.Enabled = true;
                            MainForm.objCP_Location.pnlGodownType.Enabled = true;
                            MainForm.objCP_Location.cmbStockApplicable.Enabled = true;
                            MainForm.objCP_Location.pnlStatus.Enabled = true;
                        }
                        MainForm.objCP_Location.btnSave.Text = "Update";
                        MainForm.objCP_Location.varlocationcode = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["ID"].Value);
                        MainForm.objCP_Location.PbConcernID = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["ConcernID"].Value);
                        MainForm.objCP_Location.PbLocationTypeID = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["LocationTypeID"].Value);
                        MainForm.objCP_Location.PbStockApplicableID = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["StockApplicableID"].Value);
                        MainForm.objCP_Location.PbDefault = Convert.ToString(grdGodownList.SelectedRows[0].Cells["DefaultID"].Value);
                        MainForm.objCP_Location.PbRKCreationID = Convert.ToString(grdGodownList.SelectedRows[0].Cells["RKCreationID"].Value);
                        MainForm.objCP_Location.PbRKGCreationID = Convert.ToString(grdGodownList.SelectedRows[0].Cells["RKGCreationID"].Value);
                        MainForm.objCP_Location.PbLocationEName = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Location Name in English"].Value);
                        MainForm.objCP_Location.PbLocationTName = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Location Name in Tamil"].Value);
                        MainForm.objCP_Location.PbLocationSName = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Short Name"].Value);
                        MainForm.objCP_Location.PbConcern = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Concern"].Value);
                        MainForm.objCP_Location.PbLocationType = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Location Type"].Value);
                        MainForm.objCP_Location.PbStockApplicable = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Stock Applicable"].Value);
                        MainForm.objCP_Location.PbStatus = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["StatusID"].Value);
                        MainForm.objCP_Location.PbGodownTypeStatus = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["GodownTypeID"].Value);
                        picLoader.SendToBack();
                        picLoader.Visible = false;
                        MainForm.objCP_Location.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        }
        private void CP_LocationList_KeyDown(object sender, KeyEventArgs e)
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
        private void grdLocationList_SelectionChanged(object sender, EventArgs e)
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (Convert.ToString(grdGodownList.Rows[grdGodownList.CurrentCell.RowIndex].Cells["DefaultID"].Value) == "1" || Convert.ToString(grdGodownList.Rows[grdGodownList.CurrentCell.RowIndex].Cells["DefaultID"].Value) == "2")
                    { tsbDelete.Visible = false; }
                    else { tsbDelete.Visible = true; }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        }
        private void GrdGodownList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGodownList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdGodownList.Rows[i].Cells["StatusID"].Value) == "1")
                    {
                        grdGodownList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdGodownList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdGodownList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdGodownList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(grdGodownList.Rows[i].Cells["DefaultID"].Value) == "1" || Convert.ToString(grdGodownList.Rows[i].Cells["DefaultID"].Value) == "2")
                    {
                        grdGodownList.Rows[i].DefaultCellStyle.BackColor=Color.LightPink;
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
                grdGodownList.ClearSelection(); 
            }
        } 
        private void GrdGodownList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) {
                    udfnEdit();
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
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbLocationType.Focus();
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
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Focus();
                btnView.Enabled = false;
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
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Focus();
                btnExport.Enabled = false;
                if ((grdGodownList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Stock Location List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdGodownList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;
                    ExcelSheet.Cells[1, 1].Value = "Stock Location List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    foreach (DataGridViewColumn col in grdGodownList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";
                            ExcelSheet.Cells[2, cIndex].Interior.Color = Color.LightSlateGray;
                            Excel.Range cell = ExcelSheet.Cells[2, cIndex];
                            cell.Font.Color = Excel.XlRgbColor.rgbWhite;
                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                             else if (col.Name == "Concern" || col.Name == "Location Type" || col.Name == "Godown Type" || col.Name == "Status" || col.Name == "Rack Creation" || col.Name == "Rack Group Creation" || col.Name == "No.of Products")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 50;
                            }

                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            else if (col.Name == "Total Products" || col.Name == "Total Groups" || col.Name == "Total Subgroups")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            if (cIndex == 1 || cIndex == 8)
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 25;
                            }
                            if (cIndex == 1 || cIndex == 7 || cIndex == 9)
                            {
                                ExcelSheet.Cells[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (cIndex == 2 || cIndex == 3 || cIndex == 4 || cIndex == 5 || cIndex == 6)
                            {
                                ExcelSheet.Cells[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            int varSLno = 1;
                            foreach (DataGridViewRow rowa in grdGodownList.Rows)
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
                                if (cIndex == 5)
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex].Font.Name = "Uni Ila.Sundaram-03";
                                }
                            }
                        }
                    }
                    //   ExcelSheet.Protect(System.Configuration.ConfigurationManager.AppSettings["ExcelPassword"]);
                    ExcelObj.Visible = true;
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

        private void TxtSearchbyLocationName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SearchFlag == 1)
                {
                    (grdGodownList.DataSource as BindingSource).Filter = "([Location Name in English]) LIKE '%" + txtSearchbyLocationName.Text + "%'";
                }
                else
                {
                    (grdGodownList.DataSource as DataTable).DefaultView.RowFilter = "([Location Name in English]) LIKE '%" + txtSearchbyLocationName.Text + "%'";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalCount.Text = Convert.ToString(grdGodownList.Rows.Count);
            }
        }

        private void TxtSearchbyLocationName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchbyLocationName.BackColor = Color.LemonChiffon;
                for (int i = 1; i < DGV_SearchGrid.ColumnCount; i++)
                {
                    DGV_SearchGrid.Rows[0].Cells[i].Value = "";
                }
                udfnList();
               // DGV_SearchGrid_CurrentCellDirtyStateChanged(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchbyLocationName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchbyLocationName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGodownList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void CmbLocationType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbLocationType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbLocationType_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbLocationType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbLocationType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbLocationType.BackColor = Color.White;
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
                grdGodownList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGodownList);
                objDser.CloseConnection();
                grdGodownList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdGodownList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdGodownList.SortedColumn;
                ListSortDirection direction;
                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdGodownList.SortOrder == SortOrder.Ascending)
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
                grdGodownList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                DGV_SearchGrid.HorizontalScrollingOffset = grdGodownList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdGodownList.ColumnCount > 0)
                {
                    grdGodownList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdGodownList.HorizontalScrollingOffset;
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
                txtSearchbyLocationName.Text = "";
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdGodownList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGodownList);
                objDser.CloseConnection();
                grdGodownList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalCount.Text = Convert.ToString(grdGodownList.Rows.Count);
            }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdGodownList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdGodownList.Width > grdGodownList.HorizontalScrollingOffset && grdGodownList.HorizontalScrollingOffset > 0)
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

        private void GrdGodownList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdGodownList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdGodownList.Width > grdGodownList.HorizontalScrollingOffset && grdGodownList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdGodownList);
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
                if (lblNoRecordsFound.Visible == false)
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

        private void DGV_SearchGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
