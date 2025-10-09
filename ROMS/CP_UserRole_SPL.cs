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
    //Created By:-Sathish ; Created On:-11-08-2023
    public partial class CP_UserRole_SPL : Form
    {
        DataError objError;
        private ToolTip tpCityName = new ToolTip();
        private ToolTip tpState = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int varstatus;
        public int varCityCode= 0;
        public string varCityName = "";
        public string PbStateName="";
        public int PbStateId=0;
        public int PbStatus=0;
        public int varUpdate = 0;
        public int varmastertype = 0;
        public int varmenuid = 0, varUserRoleID= 0;
        public string PbMenuName = "";
        DataTable objDtMainMenu = new DataTable(); 
        public CP_UserRole_SPL()
        {
            InitializeComponent();
        }

        private void CP_UserRole_SPL_Load(object sender, EventArgs e)
        {
            try
            {
                 
                objDtMainMenu = MainForm.objDtMenuDetails.Copy();
                  
                DataRow[] rows = objDtMainMenu.Select("MU_Code = " + varmenuid);
                var parts = new[] {
                    rows[0]["Level1Parent"]?.ToString(),
                    rows[0]["Level2Parent"]?.ToString(),
                    rows[0]["Level3Parent"]?.ToString(),
                    PbMenuName
                }; 

                string combinedValue = string.Join(" - ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
                lblMenuLink.Text = combinedValue;
                udfnView();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnView() 
        {
            try
            {
                //DataSet objDs = new DataSet();
                ////**** To call the function from SP ***************
                //SPDataService objspservice = new SPDataService();

                btnSave.Enabled = true;
                lblNoRecordsFound.Visible = false;
                //objDs = objspservice.udfnUserRoleList(3, varUserRoleID, 0, varmenuid);
                //objspservice.CloseConnection();
                //if (objDs != null)
                //{
                //    if (objDs.Tables.Count != 0)
                //    {

                //    }
                //}
                grdUserSPLPermission.Rows.Clear();
                if (MainForm.objCP_UserRole.objDtSplPermissionFilterTable != null)
                {
                    if (MainForm.objCP_UserRole.objDtSplPermissionFilterTable.Rows.Count != 0)
                    {
                        for (int i = 0; i < MainForm.objCP_UserRole.objDtSplPermissionFilterTable.Rows.Count; i++)
                        {
                            int varViewaccess = 0, varEditaccess = 0;
                            if (Convert.ToString(MainForm.objCP_UserRole.objDtSplPermissionFilterTable.Rows[i]["ViewAccess"]) == "9")
                            {
                                varViewaccess = 1;
                            }
                            if (Convert.ToString(MainForm.objCP_UserRole.objDtSplPermissionFilterTable.Rows[i]["EditAccess"]) == "10") {
                                varEditaccess = 1;
                            }
                            grdUserSPLPermission.Rows.Add(grdUserSPLPermission.Rows.Count + 1, Convert.ToString(MainForm.objCP_UserRole.objDtSplPermissionFilterTable.Rows[i]["MUP_FieldName"]), varViewaccess, varEditaccess, Convert.ToString(MainForm.objCP_UserRole.objDtSplPermissionFilterTable.Rows[i]["MUP_MU_Code"]), Convert.ToString(MainForm.objCP_UserRole.objDtSplPermissionFilterTable.Rows[i]["MUP_Code"]), Convert.ToString(MainForm.objCP_UserRole.objDtSplPermissionFilterTable.Rows[i]["AccessLevel"]), Convert.ToString(MainForm.objCP_UserRole.objDtSplPermissionFilterTable.Rows[i]["MUP_PrivilegeCode"]));
                        }
                    }
                    else {
                        lblNoRecordsFound.Visible = true;
                        btnSave.Enabled = false;
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    btnSave.Enabled = false;
                }

                grdUserSPLPermission_DataBindingComplete(grdUserSPLPermission, new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
            }


            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdUserSPLPermission.ClearSelection();
            }
        }

        private void grdUserSPLPermission_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try {
                foreach (DataGridViewRow row in grdUserSPLPermission.Rows)
                {
                    if (row.IsNewRow) continue;
                    int privilegeNo = 8;

                    string values = row.Cells["clmURSF_Access_Level"].Value?.ToString() ?? "";
                    var chkCols = new[] { "clmViewchk", "clmEditchk" };
                    string PrivilegeCode = row.Cells["clmPrivilagecode"].Value?.ToString() ?? "";
                    var allowed = PrivilegeCode.Split(',')
                                                   .Select(s => s.Trim())
                                                   .Where(s => int.TryParse(s, out _))
                                                   .Select(int.Parse)
                                                   .ToList();
                    foreach (var colName in chkCols)
                    {
                        privilegeNo = privilegeNo + 1;
                        if (allowed.Contains(privilegeNo))
                        {
                            // keep checkbox cell (active)
                            if (!(row.Cells[colName] is DataGridViewCheckBoxCell))
                            {
                                row.Cells[colName] = new DataGridViewCheckBoxCell();
                            }
                            row.Cells[colName].ReadOnly = false; 
                        }
                        else
                        {
                            // create a new text cell (blank)
                            var blankCell = new DataGridViewTextBoxCell
                            {
                                Value = ""
                            };

                            int colIndex = grdUserSPLPermission.Columns[colName].Index;
                            // replace the checkbox cell for this row
                            row.Cells[colIndex] = blankCell;
                            row.Cells[colIndex].ReadOnly = true;
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
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

        private void grdUserSPLPermission_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            try
            {

                int viewColumnIndex = grdUserSPLPermission.Columns["clmViewchk"]?.Index ?? -1; 


                // Check if the change happened in the 'View' column (clmViewchk)
                if (e.ColumnIndex == viewColumnIndex && e.RowIndex >= 0)
                {
                    // Define the names of the columns to enable/disable
                    var permissionColumns = new[] {

            "clmViewchk", 
            "clmEditchk" 
        };

                    // --- FIX FOR SPECIFIED CAST IS NOT VALID ---
                    object cellValue = grdUserSPLPermission.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Safely convert the cell's value to a boolean. 
                    // This handles DBNull, 0/1 integers, and boolean strings gracefully.
                    bool isViewChecked = Convert.ToBoolean(cellValue);
                    // ---------------------------------------------
                     
                    // If 'View' is checked (true), other columns should be ENABLED (ReadOnly = false)
                    // If 'View' is NOT checked (false), other columns should be DISABLED (ReadOnly = true)
                    bool setReadOnly = !isViewChecked;

                    // Iterate through the other permission columns
                     
                        foreach (var colName in permissionColumns)
                        {
                            // Find the index of the current permission column
                            int colIndex = grdUserSPLPermission.Columns[colName]?.Index ?? -1;

                            if (colIndex != -1)
                            {
                                var cell = grdUserSPLPermission.Rows[e.RowIndex].Cells[colIndex];
                                  
                                // Set the ReadOnly property to enable/disable the cell

                                if (colName != "clmViewchk")
                                {
                                    cell.ReadOnly = setReadOnly;
                                }
                                else
                                {
                                    cell.ReadOnly = false;
                                }

                                if (setReadOnly && colName != "clmViewchk")
                                { 
                                    cell.Value = false;
                                    cell.Style.BackColor = System.Drawing.Color.LightGray;
                                }
                                else
                                { 
                                        cell.Style.BackColor = grdUserSPLPermission.DefaultCellStyle.BackColor;
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

        private void grdUserSPLPermission_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdUserSPLPermission.IsCurrentCellDirty)
                {
                    grdUserSPLPermission.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdUserSPLPermission_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                int viewColumnIndex = grdUserSPLPermission.Columns["clmViewchk"]?.Index ?? -1;


                // Check if the change happened in the 'View' column (clmViewchk)
                if (e.ColumnIndex == viewColumnIndex && e.RowIndex >= 0)
                {
                    // Define the names of the columns to enable/disable
                    var permissionColumns = new[] {

            "clmViewchk",
            "clmEditchk"
        };

                    // --- FIX FOR SPECIFIED CAST IS NOT VALID ---
                    object cellValue = grdUserSPLPermission.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Safely convert the cell's value to a boolean. 
                    // This handles DBNull, 0/1 integers, and boolean strings gracefully.
                    bool isViewChecked = Convert.ToBoolean(cellValue);
                    // ---------------------------------------------

                    // If 'View' is checked (true), other columns should be ENABLED (ReadOnly = false)
                    // If 'View' is NOT checked (false), other columns should be DISABLED (ReadOnly = true)
                    bool setReadOnly = !isViewChecked;

                    // Iterate through the other permission columns

                    foreach (var colName in permissionColumns)
                    {
                        // Find the index of the current permission column
                        int colIndex = grdUserSPLPermission.Columns[colName]?.Index ?? -1;

                        if (colIndex != -1)
                        {
                            var cell = grdUserSPLPermission.Rows[e.RowIndex].Cells[colIndex];

                            // Set the ReadOnly property to enable/disable the cell

                            if (colName != "clmViewchk")
                            {
                                cell.ReadOnly = setReadOnly;
                            }
                            else
                            {
                                cell.ReadOnly = false;
                            }

                            if (setReadOnly && colName != "clmViewchk")
                            {
                                cell.Value = false;
                                cell.Style.BackColor = System.Drawing.Color.LightGray;
                            }
                            else
                            {
                                cell.Style.BackColor = grdUserSPLPermission.DefaultCellStyle.BackColor;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try { this.Close(); }
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
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;

                varoriginator = "UserRole SPL Access Creation";
                varType = 3;

                MainForm.objCP_UserRole.objdtMR_UserRole_Menu_SPL_Access.Rows.Clear();

                if (grdUserSPLPermission.RowCount > 0)
                {
                    for (int i = 0; i < grdUserSPLPermission.Rows.Count; i++)
                    {
                        MainForm.objCP_UserRole.objdtMR_UserRole_Menu_SPL_Access.Rows.Add(
                    Convert.ToInt32(grdUserSPLPermission.Rows[i].Cells["clmMenuId"].Value ?? 0),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserSPLPermission.Rows[i].Cells["clmViewchk"].Value?.ToString()) ? "0" : grdUserSPLPermission.Rows[i].Cells["clmViewchk"].Value), 
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserSPLPermission.Rows[i].Cells["clmEditchk"].Value?.ToString()) ? "0" : grdUserSPLPermission.Rows[i].Cells["clmEditchk"].Value),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserSPLPermission.Rows[i].Cells["clmFieldId"].Value?.ToString()) ? "0" : grdUserSPLPermission.Rows[i].Cells["clmFieldId"].Value) 
                        );
                    }
                }
               

                var varGetSameData = from dt1 in MainForm.objCP_UserRole.objDtSplPermission.AsEnumerable()
                                     join dt2 in MainForm.objCP_UserRole.objdtMR_UserRole_Menu_SPL_Access.AsEnumerable()
                                     on Convert.ToInt32(dt1["MUP_Code"] ?? 0)
                                     equals Convert.ToInt32(dt2["UAS_Fieldid"] ?? 0)
                                     select new { dt1, dt2 }; 

                foreach (var item in varGetSameData)
                {
                    int varViewaccess = 0, varEditaccess = 0;
                    if (item.dt2["UAS_ViewAccess"]?.ToString()  == "1")
                    {
                        varViewaccess = 9;
                    }
                    if (item.dt2["UAS_EditAccess"]?.ToString() == "1")
                    {
                        varEditaccess = 10;
                    }

                    item.dt1["ViewAccess"] = varViewaccess;
                    item.dt1["EditAccess"] = varEditaccess;
                }

                this.Close(); 
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
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}
