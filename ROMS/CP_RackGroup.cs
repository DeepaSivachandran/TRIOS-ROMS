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

namespace ROMS
{
    public partial class CP_RackGroup : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        Boolean BlnSearchImageYN = false;

        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpRackGroupName = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpStaffName = new ToolTip();

        public string vargroupcode = "";
        public String pbFormStatus = "";
        public String varDesignation = "";
        public String varUserID = "";
        public String varRackID = "";
        public String varUserId = "", varEmpCode = "";
        public int varStockId = 0;
        public int varStatusid = 1;
        public int varConcernId = 0;
        // public int varStockLocationId = 0;
        public DataTable dtRack = new DataTable();
        public DataTable dtEmployee = new DataTable();
        public DataTable dtSelectedRack = new DataTable();
        public int varId = 0;
        public int varCloseFlag = 0;
        public int varCmbFlag = 0;
        public int varCompanyId = 0;
        public int varCheckAllFlag = 0;
        public int varModifiedFlag = 0;

        public CP_RackGroup()
        {
            InitializeComponent();
        }
        private void CP_RackGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpStockLocation.Active = false;
                tpRackGroupName.Active = false;
                tpStaffName.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_RackGroup_Load(object sender, EventArgs e)
        {
            try
            {
                dtRack = new DataTable();
                dtEmployee = new DataTable();
                //dtSelectedRack = new DataTable();

                dtRack.Columns.Add("", typeof(Boolean));
                dtRack.Columns.Add("S.No.", typeof(string));
                dtRack.Columns.Add("Concern", typeof(string));
                dtRack.Columns.Add("Stock Location", typeof(string));
                dtRack.Columns.Add("Rack", typeof(string));
                dtRack.Columns.Add("Short Name", typeof(string));
                dtRack.Columns.Add("Description", typeof(string));
                dtRack.Columns.Add("Total Products", typeof(int));
                dtRack.Columns.Add("Status", typeof(string));
                dtRack.Columns.Add("ID", typeof(int));
                dtRack.Columns.Add("Concern ID", typeof(int));
                dtRack.Columns.Add("StockLocation ID", typeof(int));
                dtRack.Columns.Add("Status ID", typeof(int));

                dtEmployee.Columns.Add("", typeof(Boolean));
                dtEmployee.Columns.Add("S.No.", typeof(string));
                dtEmployee.Columns.Add("Employee Code", typeof(string));
                dtEmployee.Columns.Add("Employee Name", typeof(string));
                dtEmployee.Columns.Add("Employee Category", typeof(string));
                dtEmployee.Columns.Add("EMPID", typeof(int));
                dtEmployee.Columns.Add("CT_SINO", typeof(int));


                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnUserCategoryList(4, Convert.ToInt32(cmbUserCategory.SelectedValue),"",0);
                objdserv.CloseConnection();
                cmbUserCategory.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbUserCategory.ValueMember = "CTID";
                            cmbUserCategory.DisplayMember = "CT_Name";
                            cmbUserCategory.DataSource = objDs.Tables[0];
                        }
                    }
                }

                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                udfnemployeeload();
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                    udfnLoadSlNo();
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnEdit();
                    varCmbFlag = 1;
                }
                //  udfnList();
                udfnTotalProducts();
                grdStaffDetails.Columns["clmUserId"].Visible = false;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadSlNo()
        {
            try
            {
                DataSet objDS;
                if (varId != 0)
                {
                    string varRGID = Convert.ToString(varId);
                    SPDataService objspservice = new SPDataService();
                    objDS = objspservice.udfnGetSlNo("MR_RackGroup", "Update", "RKGID", varRGID, "RKG_SINO");
                    objspservice.CloseConnection();

                }
                else
                {
                    SPDataService objspservice = new SPDataService();
                    objDS = objspservice.udfnGetSlNo("MR_RackGroup ", "Create", "1=1", "", "RKG_SINO");
                    objspservice.CloseConnection();
                }
                if (objDS != null)
                {
                    cmbRGOrderNo.DataSource = objDS.Tables[0];
                    cmbRGOrderNo.DisplayMember = "num";
                    cmbRGOrderNo.ValueMember = "num";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTotalProducts()
        {
            int varCount = 0;
            try
            {
                if (grdSelectedRack.Rows.Count != 0)
                {
                    for (int i = 0; i < grdSelectedRack.RowCount; i++)
                    {
                        if (Convert.ToInt32(grdSelectedRack.Rows[i].Cells["clmTotalProducts"].Value) != 0)
                        {
                            varCount = varCount + Convert.ToInt32(grdSelectedRack.Rows[i].Cells["clmTotalProducts"].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { lblTotalProduct.Text = Convert.ToString(varCount); }
        }

        public void udfnCmbConcern()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varViewType = 9, varConcernId = 0;
                if (btnSave.Text == "Update")
                {
                    varViewType = 10;
                    varConcernId = varCompanyId;
                }
                objDT = objdserv.udfnCompanyList(varViewType, varConcernId, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
                    udfnList();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnemployeeload()
        {
            try
            {
                int varViewType = 6;
                if (btnSave.Text == "Update")
                {
                    varViewType = 7;
                }
                dtEmployee.Rows.Clear();
                Application.DoEvents();
                grdEmployee.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnEmployeeList(varViewType, "", 0, "", 1, varId, Convert.ToInt32(cmbUserCategory.SelectedValue));
                objdserv.CloseConnection();
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtEmployee.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["Employee Code"], objDs.Tables[0].Rows[i]["Employee Name"],
                           objDs.Tables[0].Rows[i]["Employee Category"], objDs.Tables[0].Rows[i]["EMPID"], objDs.Tables[0].Rows[i]["CT_SINO"]);
                    }
                }
                grdEmployee.DataSource = null;
                grdEmployee.DataSource = dtEmployee;
                grdEmployee.Columns[0].HeaderText = "";
                grdEmployee.Columns[0].Width = 30;
                grdEmployee.Columns["S.No."].Width = 40;
                grdEmployee.Columns["S.No."].Visible = false;
                grdEmployee.Columns["Employee Code"].Width = 100;
                grdEmployee.Columns["Employee Name"].Width = 180;
                grdEmployee.Columns["Employee Category"].Width = 150;
                grdEmployee.Columns["EMPID"].Visible = false;
                grdEmployee.Columns["CT_SINO"].Visible = false;
                grdEmployee.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                grdEmployee.Columns["S.No."].ReadOnly = true;
                grdEmployee.Columns["Employee Code"].ReadOnly = true;
                grdEmployee.Columns["Employee Name"].ReadOnly = true;
                grdEmployee.Columns["Employee Category"].ReadOnly = true;
                udfnEmpGridRemove();
                udfnSearchGridHead();

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
                udfnGridSearchHeading(grdRack, DGV_SearchGridLeft);
                DGV_SearchGridLeft.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdRack.Columns)
                {
                    DGV_SearchGridLeft.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_SearchGridLeft.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_SearchGridLeft.Rows.Clear();
                    DGV_SearchGridLeft.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_SearchGridLeft.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_SearchGridLeft.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_SearchGridLeft.Columns[0].ReadOnly = true;
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
        private void CmbUserCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbUserCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnViewEmployee.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserCategory_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbUserCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbUserCategory.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbUserCategory.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfncmbShopLocation()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varRackGroupID = 0;
                int varViewType = 2;
                if (btnSave.Text == "Save")
                {
                    if (varConcernId == -1)
                    {
                        varViewType = 3;
                    }
                    else { varViewType = 4; }
                }
                else
                {
                    if (varConcernId == -1)
                    {
                        varViewType = 3;
                    }
                    else { varViewType = 5; varRackGroupID = varId; }
                }
                MR_Location objMR_Location = new MR_Location();
                objMR_Location.paraViewType = varViewType;
                objMR_Location.ParaCompanycode = varConcernId;
                objMR_Location.paraLocationId = varStockId;
                objMR_Location.paraId = varRackGroupID;
                objDT = objdserv.udfnStockLocationList(objMR_Location);
                objdserv.CloseConnection();

                //objDT = objdserv.udfnStockLocationList(varViewType, varConcernId,varStockId, varRackGroupID,"",0,0,0,"","",0);
                cmbStockLocation.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbStockLocation.ValueMember = "SLID";
                            cmbStockLocation.DisplayMember = "SL_EName";
                            cmbStockLocation.DataSource = objDT.Tables[0];
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
        public void udfnList()
        {
            try
            {
                int varViewType = 1;
                if (btnSave.Text == "Update")
                {
                    varViewType = 2;
                }
                dtRack.Rows.Clear();
                Application.DoEvents();
                grdRack.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnRackList(varViewType, varId, varConcernId, varStockId, 0, "", 0, 0);
                objdserv.CloseConnection();

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtRack.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["Concern"], objDs.Tables[0].Rows[i]["Stock Location"],
                           objDs.Tables[0].Rows[i]["Rack Name"], objDs.Tables[0].Rows[i]["Short Name"], objDs.Tables[0].Rows[i]["Description"], 
                           objDs.Tables[0].Rows[i]["Total Products"], objDs.Tables[0].Rows[i]["Status"], objDs.Tables[0].Rows[i]["ID"], objDs.Tables[0].Rows[i]["ConcernID"],
                           objDs.Tables[0].Rows[i]["StockLocationID"], objDs.Tables[0].Rows[i]["StatusID"]);
                    }
                }

                grdRack.DataSource = null;
                grdRack.DataSource = dtRack;
                grdRack.Columns[0].HeaderText = "";
                grdRack.Columns[0].Width = 30;
                grdRack.Columns["S.No."].Width = 40;
                grdRack.Columns["Rack"].Width = 100;
                grdRack.Columns["Description"].Width = 200;
                grdRack.Columns["Total Products"].Width = 100;
                grdRack.Columns["Stock Location"].Width = 180;
                grdRack.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdRack.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdRack.Columns["Stock Location"].DisplayIndex = 3;
                grdRack.Columns["S.No."].Visible = false;
                grdRack.Columns["Concern"].Visible = false;
                //grdRack.Columns["Stock Location"].Visible = false;
                grdRack.Columns["Short Name"].Visible = false;
                grdRack.Columns["Status"].Visible = false;
                grdRack.Columns["ID"].Visible = false;
                grdRack.Columns["Concern ID"].Visible = false;
                grdRack.Columns["Status ID"].Visible = false;
                grdRack.Columns["StockLocation ID"].Visible = false;

                grdRack.Columns[0].ReadOnly = false;
                grdRack.Columns["S.No."].ReadOnly = true;
                grdRack.Columns["Rack"].ReadOnly = true;
                grdRack.Columns["Stock Location"].ReadOnly = true;
                grdRack.Columns["Description"].ReadOnly = true;
                grdRack.Columns["Total Products"].ReadOnly = true;

                udfnGridRemove();
                udfnsearchGridHead();
                //((DataGridViewImageCell)DGV_SearchGridRight.Rows[0].Cells[0]).Value = new System.Drawing.Bitmap(1, 1); ;
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
                if (varStatusid == 1)
                {
                    rbActive.Checked = true;
                }
                else
                {
                    rbInactive.Checked = true;
                }

                DataSet objDS = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDS = objdserv.udfnRackGroupList(1, 0, varStockId, varId,0,"",0,0);
                objdserv.CloseConnection();
                if (objDS != null)
                {

                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["RKG_COMID"].ToString().Replace("''", "'");
                        txtRackGroupName.Text = objDS.Tables[0].Rows[0]["RKG_Name"].ToString().Replace("''", "'");
                        txtPGBMins.Text = objDS.Tables[0].Rows[0]["PickupGBMins"].ToString().Replace("''", "'");
                        txtPOBMins.Text = objDS.Tables[0].Rows[0]["PickupOBMins"].ToString().Replace("''", "'");
                    }
                    cmbStockLocation.SelectedValue = varStockId;
                    udfnList();
                    udfnemployeeload();
                    udfnLoadSlNo();
                    cmbRGOrderNo.SelectedValue = objDS.Tables[0].Rows[0]["RKG_SINO"].ToString().Replace("''", "'");
                    if (objDS.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                        {
                            grdStaffDetails.Rows.Add(grdStaffDetails.Rows.Count + 1, Convert.ToString(objDS.Tables[1].Rows[i]["EMP_Code"]), Convert.ToString(objDS.Tables[1].Rows[i]["U_Name"]), Convert.ToString(objDS.Tables[1].Rows[i]["CT_Name"]), Convert.ToInt16(objDS.Tables[1].Rows[i]["RKGU_UID"]), Convert.ToString(objDS.Tables[1].Rows[i]["CT_SINO"]));
                        }
                    }

                    //for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < grdEmployee.RowCount; j++)
                    //    {
                    //        if (Convert.ToString(objDS.Tables[1].Rows[i]["RKGU_UID"]) == Convert.ToString(grdEmployee.Rows[j].Cells["EMPID"].Value))
                    //        {
                    //            grdEmployee.Rows[j].Cells[0].Value = true;
                    //        }
                    //    }
                    //}
                    if (objDS.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                        {
                            grdSelectedRack.Rows.Add(grdSelectedRack.Rows.Count + 1, Convert.ToString(objDS.Tables[2].Rows[i]["Stock Location"]), Convert.ToString(objDS.Tables[2].Rows[i]["RK_Name"]), Convert.ToString(objDS.Tables[2].Rows[i]["RK_Description"]),  Convert.ToInt16(objDS.Tables[2].Rows[i]["TotalProducts"]),  Convert.ToInt16(objDS.Tables[2].Rows[i]["RKID"]));
                        }
                    }
                    //for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < grdRack.RowCount; j++)
                    //    {
                    //        if (Convert.ToString(objDS.Tables[2].Rows[i]["RKID"]) == Convert.ToString(grdRack.Rows[j].Cells["ID"].Value))
                    //        {
                    //            grdRack.Rows[j].Cells[0].Value = true;
                    //        }
                    //    }
                    //}

                    udfnGridRemove();
                    udfnsearchGridHead();
                    udfnEmpGridRemove();
                    ((DataGridViewImageCell)DGV_SearchGridRight.Rows[0].Cells[6]).Value = new System.Drawing.Bitmap(1, 1); ;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdStaffDetails.Sort(grdStaffDetails.Columns["clmSINO"], ListSortDirection.Ascending);
                grdRack.ClearSelection();
                grdSelectedRack.ClearSelection();
                grdEmployee.ClearSelection();
                grdStaffDetails.ClearSelection();
            }
        }
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                string varResult = ""; string varOriginator = "Rack Group Creation";
                int varViewType = 0;
                if (btnSave.Text == "Update")
                {
                    varOriginator = "Rack Group Updation";
                    varViewType = 1;
                }
                if (rbActive.Checked)
                {
                    varStatusid = 1;
                }
                else
                {
                    varStatusid = 2;
                }
                varRackID = ""; varUserID = "";
                for (int i = 0; i < grdSelectedRack.RowCount; i++)
                {
                    if (varRackID == "")
                    {
                        varRackID = Convert.ToString(grdSelectedRack.Rows[i].Cells["ID"].Value);
                    }
                    else
                    {
                        varRackID = varRackID + "," + Convert.ToString(grdSelectedRack.Rows[i].Cells["ID"].Value);
                    }
                }
                for (int i = 0; i < grdStaffDetails.RowCount; i++)
                {
                    if (varUserID == "")
                    {
                        varUserID = Convert.ToString(grdStaffDetails.Rows[i].Cells["clmUserId"].Value);
                    }
                    else
                    {
                        varUserID = varUserID + "," + Convert.ToString(grdStaffDetails.Rows[i].Cells["clmUserId"].Value);
                    }
                }
                SPDataService objDser = new SPDataService();
                varResult = objDser.udfnRackGroup(varViewType, varId, Convert.ToInt16(cmbConcern.SelectedValue), Convert.ToString(txtRackGroupName.Text).Trim(), varRackID, varUserID, varStatusid, varOriginator, MainForm.pbUserID, 0, Convert.ToInt32(cmbRGOrderNo.SelectedValue), null, int.TryParse(txtPGBMins.Text, out int pgbMins) ? pgbMins : 0, int.TryParse(txtPOBMins.Text, out int pobMins) ? pobMins : 0);
                objDser.CloseConnection();
                btnSave.Enabled = true;
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varModifiedFlag = 0;
                    if (btnSave.Text == "Save")
                    {
                        udfnClear();
                    }
                    else
                    {
                        varCloseFlag = 1;
                        udfnclose();
                    }
                    MainForm.objCP_RackGroupList.udfnList();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Focus();
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
                btnSave.Focus();
            }
        }
        public void udfnClear()
        {
            try
            {
                txtRackGroupName.Text = "";
                txtPGBMins.Text = "";
                txtPOBMins.Text = "";
                //cmbConcern.SelectedValue = -1;
                //grdRack.DataSource = null;
                grdSelectedRack.Rows.Clear();
                grdStaffDetails.Rows.Clear();
                chkRack.Checked = false;
                chkEmployee.Checked = false;
                tpStaffName.Active = false;
                lblTotalProduct.Text = "0";
                txtRackGroupName.Focus();
                foreach (DataGridViewRow row in grdEmployee.Rows)
                {
                    row.Cells[0].Value = false;
                }
                udfnemployeeload();
                udfnLoadSlNo();
                //grdRack.DataSource = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(cmbConcern.SelectedItem) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epRackGroup.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtRackGroupName.Text).Trim() == "")
                {
                    epRackGroup.SetError(txtRackGroupName, "Please enter rack group name");
                    txtRackGroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRackGroupName.ShowAlways = true;
                    tpRackGroupName.Show("Please enter rack group name", txtRackGroupName, 5000);
                    blnErrorFlag = true;

                }
                if (grdSelectedRack.Rows.Count <= 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(41);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    udfnSave(sender, e);
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
                btnSave.Focus();
            }
        }


        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclose()
        {
            try
            {
                if (varModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objCP_RackGroupList.Show();
                        MainForm.objCP_RackGroupList.udfnList();
                    }else
                    { btnSave.Focus(); }
                }
                else
                {
                    if (varCloseFlag == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
                            MainForm.objCP_RackGroupList.Show();
                            MainForm.objCP_RackGroupList.udfnList();
                        }
                    }
                    else { this.Close(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void btnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                epRackGroup.Clear();
                string varAddStaff = ""; int varFlag = 0; int varStaffName = 0;
                if (Convert.ToString(txtStaffName.Text).Trim() == "")
                {
                    epRackGroup.SetError(txtStaffName, "Please enter staff name");
                    txtStaffName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStaffName.ShowAlways = true;
                    tpStaffName.Show("Please enter staff name", txtStaffName, 5000);
                }
                else
                {
                    DataSet objDsUser = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsUser = objDserv.udfnEmployeeList(3, txtStaffName.Text.Trim(), 0, varEmpCode, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDsUser != null)
                    {
                        if (objDsUser.Tables.Count > 0)
                        {
                            if (objDsUser.Tables[0].Rows.Count > 0)
                            {
                                varStaffName = Convert.ToInt32(objDsUser.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varUserID = Convert.ToString(varStaffName);
                    if (varStaffName == 0 || varStaffName == -1)
                    {
                        varUserID = "0";
                        varEmpCode = "0";
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(49);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        varFlag = 0;
                        for (int i = 0; i < grdStaffDetails.Rows.Count; i++)
                        {
                            varAddStaff = varUserID;
                            if (txtStaffName.Text.Trim().ToUpper() == Convert.ToString(grdStaffDetails.Rows[i].Cells["clmStaffName"].Value).Trim().ToUpper())
                            {
                                varFlag = 1;
                            }
                        }
                        if (varFlag == 0)
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnEmployeeList(4, txtStaffName.Text.Trim(), 0, "", 0, 0, 0);
                            objspdservice.CloseConnection();
                            txtStaffName.Text = objDs.Tables[0].Rows[0]["EMP_Name"].ToString();
                            varUserID = objDs.Tables[0].Rows[0]["EMPID"].ToString();
                            varDesignation = objDs.Tables[0].Rows[0]["CT_Name"].ToString();
                            varEmpCode = objDs.Tables[0].Rows[0]["EMP_Code"].ToString();
                            grdStaffDetails.Rows.Add(grdStaffDetails.Rows.Count + 1, varEmpCode, txtStaffName.Text.Trim(), varDesignation, varUserID);
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(43);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    txtStaffName.Focus();
                    txtStaffName.Text = "";
                    varDesignation = "";
                    varUserId = "";
                    varEmpCode = "";
                    tpStaffName.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdStaffDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {

                    switch (grdStaffDetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmremove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                dtEmployee.Rows.Add(false, 0,
                                   grdStaffDetails.SelectedRows[0].Cells["clmEmpCode"].Value, grdStaffDetails.SelectedRows[0].Cells["clmStaffName"].Value,
                                   grdStaffDetails.SelectedRows[0].Cells["clmcatrgory"].Value, grdStaffDetails.SelectedRows[0].Cells["clmUserId"].Value
                                   );

                                grdStaffDetails.Rows.RemoveAt(this.grdStaffDetails.SelectedRows[0].Index);
                                for (int i = 0; i < grdStaffDetails.RowCount; i++)
                                {
                                    grdStaffDetails.Rows[i].Cells["clmSno"].Value = i + 1;
                                }
                                dtEmployee.AcceptChanges();
                                grdEmployee.DataSource = dtEmployee;
                                BtnViewEmployee_Click(sender, e);
                                varModifiedFlag = 1;
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
            finally
            {
                this.grdEmployee.Sort(this.grdEmployee.Columns[2], ListSortDirection.Ascending);
                grdEmployee.ClearSelection();
            }
        }
        private void DGV_Racklist_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void GrdSelectedRackList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //try
            //{
            //    if (Convert.ToInt32(grdSelectedRack.SelectedRows[0].Cells["clmTotalProducts"].Value) != 0)
            //    {
            //        MainForm.objCP_ProductDetails = new CP_ProductDetails();
            //        MainForm.objCP_ProductDetails.varRackId = Convert.ToInt32(grdSelectedRack.SelectedRows[0].Cells["ID"].Value);
            //        MainForm.objCP_ProductDetails.varRackName = Convert.ToString(grdSelectedRack.SelectedRows[0].Cells["clmRack"].Value);
            //        MainForm.objCP_ProductDetails.varDescription = Convert.ToString(grdSelectedRack.SelectedRows[0].Cells["clmDescription"].Value);
            //        MainForm.objCP_ProductDetails.ShowDialog();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);

            //}
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
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epRackGroup.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epRackGroup.Clear();
                    cmbConcern.BackColor = Color.White;
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
                varConcernId = Convert.ToInt16(cmbConcern.SelectedValue);
                udfncmbShopLocation();
                grdRack.DataSource = null;
                grdSelectedRack.Rows.Clear();
                chkRack.Checked = false;
                udfnTotalProducts();
                udfnList();
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
                    txtRackGroupName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRackGroupName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRackGroupName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRackGroupName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtRackGroupName.Text).Trim() == "")
                {
                    epRackGroup.SetError(txtRackGroupName, "Please enter rack group name");
                    txtRackGroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRackGroupName.ShowAlways = true;
                    tpRackGroupName.Show("Please enter rack group name", txtRackGroupName, 5000);

                }
                else
                {
                    epRackGroup.Clear();
                    txtRackGroupName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRackGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRGOrderNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockLocation_Enter(object sender, EventArgs e)
        {

            try
            {
                cmbStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockLocation_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbStockLocation_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStockLocation.BackColor = Color.White;
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

        private void Add_Enter(object sender, EventArgs e)
        {
            try
            {
                Add.BackColor = Color.LemonChiffon;
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
        private void Add_Leave(object sender, EventArgs e)
        {

            try
            {
                Add.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStaffName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStaffName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtStaffName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStaffName.BackColor = Color.White;
                //if (txtStaffName.Text.Trim() == "") { lblUserId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSelectedRackList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DgvStaffDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbActive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_RackGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void TxtStaffName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvStaffName.Items.Count == 0 || txtStaffName.Text == "")
                    {
                        txtStaffName.Focus();
                        // lvStaffName.Visible = false;
                    }
                    else
                    {
                        lvStaffName.Focus();
                    }
                    if (lvStaffName.Items.Count > 0)
                    {
                        lvStaffName.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_RackGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                lvStaffName.Visible = false;
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                varStockId = Convert.ToInt32(cmbStockLocation.SelectedValue);
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
                for (int j = 0; j < grdRack.RowCount; j++)
                {
                    if (Convert.ToString(grdSelectedRack.Rows[j].Cells["ID"].Value) == Convert.ToString(grdRack.Rows[j].Cells["ID"].Value))
                    {
                        grdRack.Rows[j].Cells[0].Value = true;
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //Added by deepa on 01-09-2023
        public void udfnCaculateCheckedCount()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdRack.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdRack.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        varCheckedCount++;
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
                if (grdRack.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag = 1;
                    chkRack.Checked = true;
                }
                else
                {
                    varCheckAllFlag = 1;
                    chkRack.Checked = false;
                }
            }
        }
        public void udfnSelectedRack()
        {
            try
            {
                string varRemoveRack = "", varAddRack = "";
                if (grdRack.Rows.Count > 0)
                {
                    for (int i = 0; i < grdRack.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdRack.Rows[i].Cells[0].Value) == true)
                        {
                            int varFlag = 0, varcount = 1; ;

                            for (int j = 0; j < grdSelectedRack.Rows.Count; j++)
                            {
                                varAddRack = Convert.ToString(grdRack.Rows[i].Cells["ID"].Value);
                                if (varAddRack == Convert.ToString(grdSelectedRack.Rows[j].Cells["ID"].Value))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                grdSelectedRack.Rows.Add(Convert.ToInt32(grdSelectedRack.Rows.Count) + 1, grdRack.Rows[i].Cells["Stock Location"].Value, grdRack.Rows[i].Cells["Rack"].Value, grdRack.Rows[i].Cells["Description"].Value, 
                                    grdRack.Rows[i].Cells["Total Products"].Value, grdRack.Rows[i].Cells["ID"].Value);
                            }
                            varModifiedFlag = 1;
                        }

                    }
                    udfnGridRemove();
                    udfnsearchGridHead();
                    ((DataGridViewImageCell)DGV_SearchGridRight.Rows[0].Cells[6]).Value = new System.Drawing.Bitmap(1, 1); ;
                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnsearchGridHead()
        {
            try
            {
                udfnGridsearchHeading(grdSelectedRack, DGV_SearchGridRight);
                DGV_SearchGridRight.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdSelectedRack.Columns)
                {
                    DGV_SearchGridRight.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_SearchGridRight.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_SearchGridRight.Rows.Clear();
                    DGV_SearchGridRight.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_SearchGridRight.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_SearchGridRight.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_SearchGridRight.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnGridsearchHeading(DataGridView dgv1, DataGridView dgv2)
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
        public void udfnGridRemove()
        {
            try
            {
                string varRemoveGroup = "";
                for (int j = 0; j < grdSelectedRack.Rows.Count; j++)
                {
                    varRemoveGroup = Convert.ToString(grdSelectedRack.Rows[j].Cells["ID"].Value);
                    for (int i = 0; i < grdRack.Rows.Count; i++)
                    {
                        if (varRemoveGroup == Convert.ToString(grdRack.Rows[i].Cells["ID"].Value))
                        {
                            grdRack.Rows.RemoveAt(i);
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

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSelectedRack();
                if (grdRack.Rows.Count<1)
                {
                    chkRack.Checked = false;
                }
                udfnTotalProducts();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdSelectedRack.ClearSelection();
            }
        }

        private void ChkRack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (varCheckAllFlag != 1)
                {
                    for (int i = 0; i < grdRack.Rows.Count; i++)
                    {
                        grdRack.Rows[i].Cells[0].Value = chkRack.Checked;

                    }
                }
                else
                {
                    varCheckAllFlag = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSelectedRack_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {

                    switch (grdSelectedRack.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemoveRack":

                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {

                                dtRack.Rows.Add(false, 0, "", grdSelectedRack.SelectedRows[0].Cells["clmStockLocation"].Value,
                                   grdSelectedRack.SelectedRows[0].Cells["clmRack"].Value, "", grdSelectedRack.SelectedRows[0].Cells["clmDescription"].Value, 
                                   grdSelectedRack.SelectedRows[0].Cells["clmTotalProducts"].Value, "", grdSelectedRack.SelectedRows[0].Cells["ID"].Value, 0, 
                                   0,0);

                                grdSelectedRack.Rows.RemoveAt(this.grdSelectedRack.SelectedRows[0].Index);
                                for (int i = 0; i < grdSelectedRack.RowCount; i++)
                                {
                                    grdSelectedRack.Rows[i].Cells["columnSNo"].Value = i + 1;
                                }
                                udfnTotalProducts();

                                dtRack.AcceptChanges();
                                grdRack.DataSource = dtRack;
                                varModifiedFlag = 1;
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

            finally
            {
                this.grdRack.Sort(this.grdRack.Columns[4], ListSortDirection.Ascending);
                grdRack.ClearSelection();
            }
        }
        public void udfnlvStaffname()
        {
            try
            {
                if (txtStaffName.Text != "")
                {
                    ListViewItem selectedItem = lvStaffName.SelectedItems[0];
                    txtStaffName.Text = selectedItem.SubItems[0].Text;
                    varDesignation = selectedItem.SubItems[1].Text;
                    varUserID = selectedItem.SubItems[2].Text;
                    varEmpCode = selectedItem.SubItems[3].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvStaffName.Visible = false;
            }
        }

        private void TxtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvStaffName.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStaffName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnEmployeeList(5, txtStaffName.Text.Trim(), 0, "", 1, varId, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["EMP_Name"].ToString(), objDs.Tables[0].Rows[i]["CT_Name"].ToString(), objDs.Tables[0].Rows[i]["EMPID"].ToString(), objDs.Tables[0].Rows[i]["EMP_Code"].ToString(), };

                                    ListViewItem objList = new ListViewItem(row);
                                    lvStaffName.Items.Add(objList);
                                }
                                lvStaffName.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvStaffName.Visible = false;
                    lvStaffName.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStaffName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnlvStaffname();
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStaffName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                udfnlvStaffname();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRack_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    udfnCaculateCheckedCount();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Add_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Add_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void ChkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdEmployee.Rows.Count; i++)
                {
                    grdEmployee.Rows[i].Cells[0].Value = chkEmployee.Checked;

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAddemployee_Click(object sender, EventArgs e)
        {
            try
            {
                udfnemployeSelect();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdStaffDetails.ClearSelection();
            }
        }

        public void udfnemployeSelect()
        {
            try
            {
                string varAddEmployee = "";

                if (grdEmployee.Rows.Count > 0)
                {
                    for (int i = 0; i < grdEmployee.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdEmployee.Rows[i].Cells[0].Value) == true)
                        {
                            int varFlag = 0, varcount = 1; ;

                            for (int j = 0; j < grdStaffDetails.Rows.Count; j++)
                            {
                                varAddEmployee = Convert.ToString(grdEmployee.Rows[i].Cells["EMPID"].Value);
                                if (varAddEmployee == Convert.ToString(grdStaffDetails.Rows[j].Cells["clmUserId"].Value))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                grdStaffDetails.Rows.Add(Convert.ToInt32(grdStaffDetails.Rows.Count) + 1, grdEmployee.Rows[i].Cells["Employee Code"].Value, grdEmployee.Rows[i].Cells["Employee Name"].Value,
                                grdEmployee.Rows[i].Cells["Employee Category"].Value, grdEmployee.Rows[i].Cells["EMPID"].Value, Convert.ToString(grdEmployee.Rows[i].Cells["CT_SINO"].Value));
                            }
                            varModifiedFlag = 1;
                        }
                    }
                    udfnEmpGridRemove();
                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdStaffDetails.Sort(grdStaffDetails.Columns[5], ListSortDirection.Ascending);

                //For SNO Count For Right Side Grid
                for (int i = 0; i < grdStaffDetails.Rows.Count; i++)
                {
                    grdStaffDetails.Rows[i].Cells["clmSno"].Value = i + 1;
                }
            }
        }

        public void udfnEmpGridRemove()
        {
            try
            {
                string varRemoveGroup = "";
                for (int j = 0; j < grdStaffDetails.Rows.Count; j++)
                {
                    varRemoveGroup = Convert.ToString(grdStaffDetails.Rows[j].Cells["clmUserId"].Value);
                    for (int i = 0; i < grdEmployee.Rows.Count; i++)
                    {
                        if (varRemoveGroup == Convert.ToString(grdEmployee.Rows[i].Cells["EMPID"].Value))
                        {
                            grdEmployee.Rows.RemoveAt(i);
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
        private void GrdEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    udfncheckedcountemployee();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfncheckedcountemployee()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdEmployee.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdEmployee.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        varCheckedCount++;
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
                if (grdEmployee.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag = 1;
                    chkRack.Checked = true;
                }
                else
                {
                    varCheckAllFlag = 1;
                    chkRack.Checked = false;
                }
            }
        }

        private void BtnViewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                udfnemployeeload();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRack_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdRack.SelectedRows[0].Cells["Total Products"].Value) != 0 && grdRack.SelectedRows[0].Cells[e.ColumnIndex].OwningColumn.Name == "Rack")
                {
                    MainForm.objCP_ProductDetails = new CP_ProductDetails();
                    MainForm.objCP_ProductDetails.varRackId = Convert.ToInt32(grdRack.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_ProductDetails.varRackName = Convert.ToString(grdRack.SelectedRows[0].Cells["Rack"].Value);
                    MainForm.objCP_ProductDetails.varDescription = Convert.ToString(grdRack.SelectedRows[0].Cells["Description"].Value);
                    MainForm.objCP_ProductDetails.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdSelectedRack_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdSelectedRack.SelectedRows[0].Cells["clmTotalProducts"].Value) != 0 && grdSelectedRack.SelectedRows[0].Cells[e.ColumnIndex].OwningColumn.Name == "clmRack")
                {
                    MainForm.objCP_ProductDetails = new CP_ProductDetails();
                    MainForm.objCP_ProductDetails.varRackId = Convert.ToInt32(grdSelectedRack.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_ProductDetails.varRackName = Convert.ToString(grdSelectedRack.SelectedRows[0].Cells["clmRack"].Value);
                    MainForm.objCP_ProductDetails.varDescription = Convert.ToString(grdSelectedRack.SelectedRows[0].Cells["clmDescription"].Value);
                    MainForm.objCP_ProductDetails.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void DGV_SearchGridLeft_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdRack.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridLeft, grdRack);
                objDser.CloseConnection();
                grdRack.HorizontalScrollingOffset = DGV_SearchGridLeft.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridLeft_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGridLeft.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGridLeft.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
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

        private void DGV_SearchGridLeft_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdRack.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdRack.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdRack.SortOrder == SortOrder.Ascending)
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
                    grdRack.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGridLeft.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGridLeft.HorizontalScrollingOffset = grdRack.HorizontalScrollingOffset;
                    DGV_SearchGridLeft.FirstDisplayedScrollingRowIndex = 0;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridLeft_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdRack.ColumnCount > 0)
                {
                    grdRack.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGridLeft.HorizontalScrollingOffset = grdRack.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridLeft_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGridLeft.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGridLeft.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdRack.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridLeft, grdRack);
                objDser.CloseConnection();
                grdRack.HorizontalScrollingOffset = DGV_SearchGridLeft.HorizontalScrollingOffset;
                //lblTotalProducts.Text = grdRack.Rows.Count.ToString();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridLeft_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdRack.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridLeft.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdRack.Width > grdRack.HorizontalScrollingOffset && grdRack.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridLeft.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridLeft.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LblNoofproducts_Click(object sender, EventArgs e)
        {

        }

        private void DGV_SearchGridRight_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGridRight.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridRight_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = grdSelectedRack.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = grdSelectedRack.SortedColumn;
            ListSortDirection direction;
            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    grdSelectedRack.SortOrder == SortOrder.Ascending)
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
            grdSelectedRack.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;
            DataGridViewColumn DGV = DGV_SearchGridRight.Columns[e.ColumnIndex];
            DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
            DGV_SearchGridRight.HorizontalScrollingOffset = grdSelectedRack.HorizontalScrollingOffset;
            DGV_SearchGridRight.FirstDisplayedScrollingRowIndex = 0;
        }

        private void DGV_SearchGridRight_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdSelectedRack.ColumnCount > 0)
                {
                    grdSelectedRack.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGridRight.HorizontalScrollingOffset = grdSelectedRack.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridRight_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGV_SearchGridRight.IsCurrentCellDirty)
            {
                // Commit the changes immediately
                DGV_SearchGridRight.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            DataService objDser = new DataService();
            grdSelectedRack.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridRight, grdSelectedRack);
            objDser.CloseConnection();
            grdSelectedRack.HorizontalScrollingOffset = DGV_SearchGridRight.HorizontalScrollingOffset;
        }

        private void DGV_SearchGridRight_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdSelectedRack.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridRight.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdSelectedRack.Width > grdSelectedRack.HorizontalScrollingOffset && grdSelectedRack.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridRight.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridRight.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridLeft_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex >= 0 && DGV_SearchGridLeft.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            //{
            //    e.Value = null;
            //}
            if (e.RowIndex >= 0 && DGV_SearchGridLeft.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }

        private void DGV_SearchGridRight_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGridRight.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }

        private void GrdRack_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdRack.IsCurrentCellDirty)
                {
                    grdRack.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRack_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdRack.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridLeft.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdRack.Width > grdRack.HorizontalScrollingOffset && grdRack.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridLeft.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridLeft.Invalidate();
                udfnscrollVisible(DGV_SearchGridLeft, grdRack);
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
                var vScrollbar = grdRack.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGridLeft.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGridLeft.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGridLeft.Rows[rowIndex].Cells[i].Value = "";
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

        private void GrdSelectedRack_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdSelectedRack.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridRight.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdSelectedRack.Width > grdSelectedRack.HorizontalScrollingOffset && grdSelectedRack.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridRight.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridRight.Invalidate();
                udfnScrollVisible(DGV_SearchGridRight, grdSelectedRack);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnScrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdSelectedRack.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGridRight.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGridRight.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGridRight.Rows[rowIndex].Cells[i].Value = "";
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

        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdRack.Rows.Count; i++)
                {
                    grdRack.Rows[i].Cells[0].Value = false;
                    dtRack.Rows[i][0] = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                btnUnselectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                btnUnselectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdRack.Rows.Count; i++)
                {
                    grdRack.Rows[i].Cells[0].Value = true;
                    dtRack.Rows[i][0] = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRack_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdRack.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdEmployee_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdEmployee.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSelectedRack_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdSelectedRack.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStaffDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdStaffDetails.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbRGOrderNo_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRGOrderNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbRGOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPGBMins.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbRGOrderNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbRGOrderNo_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbRGOrderNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtPGBMins_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPGBMins.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPGBMins_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPOBMins.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPGBMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPGBMins_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPGBMins.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPOBMins_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPOBMins.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPOBMins_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStockLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPOBMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPOBMins_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPOBMins.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGridRight_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdSelectedRack.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridRight, grdSelectedRack);
                objDser.CloseConnection();
                grdSelectedRack.HorizontalScrollingOffset = DGV_SearchGridRight.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
    }

}
