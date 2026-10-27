using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROMS.Model;
namespace ROMS
{
    public partial class CP_Sales_UserRole : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private bool isProcessing = false;
        private ToolTip tpUserRole = new ToolTip();
        public string varupdate = "0";
        public string varstatusid = "0", varcontactcompanyid = "0", varSlNo = "0", varCMSlNo = "0", varUserRoleName = "";
        public static int varCloseFlag = 0, varflag = 0, varstatusidContact = 1;
        public int varstatus = 0, varUserRoleID = 0, varChangesFlag = 0,varCLone=0;


        DataTable objDtMainMenu = new DataTable();
        DataTable objDtSubMenu = new DataTable();

        DataTable objDtSalesUserMenuDetails = new DataTable();

        public DataTable objDtSplPermission = new DataTable();
        public DataTable objDtSplPermissionFilterTable = new DataTable();
        public DataTable objdtMR_UserRole_Menu_SPL_Access = new DataTable();
        

        public CP_Sales_UserRole()
        {
            InitializeComponent();
        }

        private void CP_Sales_UserRole_Load(object sender, EventArgs e)
        {
            try
            {

                objdtMR_UserRole_Menu_SPL_Access.TableName = "MR_UserRole_Menu_SPL_Access";
                objdtMR_UserRole_Menu_SPL_Access.Columns.Add("UAS_Menuid", typeof(int));
                objdtMR_UserRole_Menu_SPL_Access.Columns.Add("UAS_ViewAccess", typeof(int));
                objdtMR_UserRole_Menu_SPL_Access.Columns.Add("UAS_EditAccess", typeof(int));
                objdtMR_UserRole_Menu_SPL_Access.Columns.Add("UAS_Fieldid", typeof(int));

                objDtSalesUserMenuDetails.Clear();

                objDtSalesUserMenuDetails = MainForm.objDtSales_MenuDetails.DefaultView.ToTable(false,
                    "SLMU_Code", 
                    "SLMU_Name",
                    "SLMU_Link",
                    "SLMU_ParentMenuCode",
                    "SLMU_Level", 
                    "SLMU_Formname", 
                    "SLMU_CloseFlag", 
                    "Menuflag");

                DataView dv = new DataView(objDtSalesUserMenuDetails);
                dv.RowFilter = "SLMU_ParentMenuCode IS NULL AND SLMU_Code <> 9";
                objDtMainMenu = dv.ToTable();

                objDtSplPermission.Clear();
                if (MainForm.objDtSales_MenuSplPermission != null)
                {
                    objDtSplPermission = MainForm.objDtSales_MenuSplPermission.Copy();
                }

                udfnSPLPermission_Load();

                if (varUserRoleID != 0)
                {
                    udfnEdit();
                }
                LoadTreeViewFromDataTable(tvMainmenu, objDtMainMenu);
                txtSalesUserRole.Focus();
                this.ActiveControl = txtSalesUserRole;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        

        private void txtUserRole_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesUserRole.BackColor = Color.LemonChiffon;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtUserRole_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesUserRole.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tvMainmenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                tvMainmenu.Nodes.Cast<TreeNode>()
                .SelectMany(n => new[] { n }.Concat(n.Nodes.Cast<TreeNode>()))
                .ToList()
                .ForEach(n =>
                {
                    n.BackColor = Color.White;
                    n.ForeColor = Color.Black;
                });
                if (e.Action != TreeViewAction.ByMouse) return; // avoid recursion when setting programmatically

                string menuCode = e.Node.Tag.ToString();

                if (menuCode == "")
                {
                    menuCode = "0";
                } 

                objDtSubMenu.Clear();
                if (e.Node.IsSelected)
                    LoadSubMenuForParent(tvSubmenu,menuCode);
                else
                    RemoveSubMenu(tvSubmenu,Convert.ToInt32(menuCode));

                //if (btnSave.Text=="Update" || varCLone == 1 )
                //{
                //    TreeNode node = tvLevl2Submenu.Nodes[0]; // or any node you want

                //    // Create event arguments for the node
                //    TreeViewEventArgs args = new TreeViewEventArgs(node, TreeViewAction.ByMouse);

                //    tvLevl2Submenu_AfterCheck(tvLevl2Submenu, args);

                //}
                e.Node.EnsureVisible();
                tvMainmenu.SelectedNode = e.Node;
                e.Node.BackColor = Color.LightBlue;
                tvLevl2Submenu.Nodes.Clear();
                 

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtUserRole_KeyDown(object sender, KeyEventArgs e)
        {

        }
        public void udfntooltiphide()
        {
            try
            {

                tpUserRole.Active = false;
                epCompany.Clear();

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
                if (varChangesFlag == 1 && varupdate == "0")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(164);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        //MainForm.objCP_UserRoleList.udfnList();
                        MainForm.objCP_Sales_UserRoleList.udfnList();
                    }
                }
                else
                {
                    if (varupdate == "0")
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
                            //MainForm.objCP_UserRoleList.udfnList();
                            MainForm.objCP_Sales_UserRoleList.udfnList();


                        }
                    }
                    else
                    {
                        this.Close();
                        //MainForm.objCP_UserRoleList.udfnList();
                        MainForm.objCP_Sales_UserRoleList.udfnList();

                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Grpform2_Leave(object sender, EventArgs e)
        {
            try
            {
                udfntooltiphide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                // tpCompanyName.Active = false; 
            }
        }



        private void tvSubmenu_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                //if (e.Node.Level == 0)
                //{
                //    e.Cancel = true; // Initially cancel the event
                //    if (e.Node.Checked)
                //    {
                //        e.Cancel = false; // <--- PROBLEM: If it was already checked, you allowed it to be unchecked.
                //    }
                //}
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
                if (Convert.ToString(txtSalesUserRole.Text).Trim() == "")
                {
                    epCompany.SetError(txtSalesUserRole, "Please enter Sales user role");
                    txtSalesUserRole.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUserRole.ShowAlways = true;
                    tpUserRole.Show("Please enter Sales user role", txtSalesUserRole, 5000);
                    blnErrorFlag = true;
                }
                if (varChangesFlag == 0 && btnSave.Text == "Save" && varCLone == 0)
                {

                    MessageBox.Show("Please select atleast one menu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }
        }

        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                udfntooltiphide();
                if (rbActive.Checked == true) { varstatus = 1; }
                else { varstatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Sales UserRole Creation";
                    varUserRoleID = 0;
                    varType = 0;
                }
                else
                {
                    varoriginator = "Sales UserRole Updation";
                    varType = 1;
                }
                DataTable objdtUserRole_Menu_Access = new DataTable();
                objdtUserRole_Menu_Access.TableName = "MR_UserRole_Menu_Access";
                objdtUserRole_Menu_Access.Columns.Add("UA_Menuid", typeof(int));
                objdtUserRole_Menu_Access.Columns.Add("UA_ViewAccess", typeof(int));
                objdtUserRole_Menu_Access.Columns.Add("UA_CreateAccess", typeof(int));
                objdtUserRole_Menu_Access.Columns.Add("UA_EditAccess", typeof(int));
                objdtUserRole_Menu_Access.Columns.Add("UA_DeleteAccess", typeof(int));
                objdtUserRole_Menu_Access.Columns.Add("UA_PrintAccess", typeof(int));
                objdtUserRole_Menu_Access.Columns.Add("UA_ExcelAccess", typeof(int));
                objdtUserRole_Menu_Access.Columns.Add("UA_NotificationAccess", typeof(int));
                objdtUserRole_Menu_Access.Columns.Add("UA_CloneAccess", typeof(int));


                if (grdUserPermission.RowCount > 0)
                {
                    for (int i = 0; i < grdUserPermission.Rows.Count; i++)
                    { 
                        objdtUserRole_Menu_Access.Rows.Add(
                    Convert.ToInt32(grdUserPermission.Rows[i].Cells["clmMenuId"].Value ?? 0),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserPermission.Rows[i].Cells["clmViewchk"].Value?.ToString()) ? "0" : grdUserPermission.Rows[i].Cells["clmViewchk"].Value),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserPermission.Rows[i].Cells["clmCreatechk"].Value?.ToString()) ? "0" : grdUserPermission.Rows[i].Cells["clmCreatechk"].Value),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserPermission.Rows[i].Cells["clmEditchk"].Value?.ToString()) ? "0" : grdUserPermission.Rows[i].Cells["clmEditchk"].Value),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserPermission.Rows[i].Cells["clmDeletechk"].Value?.ToString()) ? "0" : grdUserPermission.Rows[i].Cells["clmDeletechk"].Value),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserPermission.Rows[i].Cells["clmPrintchk"].Value?.ToString()) ? "0" : grdUserPermission.Rows[i].Cells["clmPrintchk"].Value),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserPermission.Rows[i].Cells["clmExcelchk"].Value?.ToString()) ? "0" : grdUserPermission.Rows[i].Cells["clmExcelchk"].Value),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserPermission.Rows[i].Cells["clmNotificationchk"].Value?.ToString()) ? "0" : grdUserPermission.Rows[i].Cells["clmNotificationchk"].Value),
                    Convert.ToInt32(string.IsNullOrEmpty(grdUserPermission.Rows[i].Cells["clmClonechk"].Value?.ToString()) ? "0" : grdUserPermission.Rows[i].Cells["clmClonechk"].Value)
                        );
                    }
                }
                                

                DataTable saveobjDtSplPermission = objDtSplPermission.DefaultView.ToTable(false, "SLMUP_SLMU_Code", "ViewAccess", "EditAccess", "SLMUP_CODE" );

                varResult = objspservice.udfnSalesUserRole(varType, Convert.ToInt32(varUserRoleID), (txtSalesUserRole.Text).Trim(), varstatus, varoriginator, MainForm.pbUserID, 0, objDtSalesUserMenuDetails, objdtUserRole_Menu_Access, saveobjDtSplPermission);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varChangesFlag = 0;
                    if (btnSave.Text == "Save")
                    {
                        if (varvalue[2] != "")
                        {
                            varChangesFlag = 0;
                            varUserRoleID = Convert.ToInt32(varvalue[2]);
                            btnSave.Text = "Update";
                        }
                        else
                        {
                            btnSave.Text = "Save";
                        } 
                    }
                    else
                    {
                        if (btnSave.Text == "Update" && Convert.ToString(tbFirst.SelectedIndex) == "1")
                        {
                            varupdate = "1";
                            udfnclose();
                        }
                    }

                    tbFirst.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
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
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void LoadTreeViewFromDataTable(TreeView tv, DataTable dt)
        {
            try
            {
                tv.Nodes.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string nodeText = row["SLMU_Name"].ToString();   // Text to display
                    string nodeValue = row["SLMU_Code"].ToString(); //  id for menus

                    // Create TreeNode
                    TreeNode node = new TreeNode(nodeText)
                    {
                        Tag = nodeValue   // Store value in Tag (can retrieve later)
                    };

                    tv.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LoadSubMenuForParent(TreeView submenu, string parentMenuCode)
        {
            try
            {
                 
                submenu.Nodes.Clear(); // clear previous second tree

                // Create root node for this parent
                DataRow parentRow = objDtSalesUserMenuDetails.Select($"SLMU_Code = {parentMenuCode}").FirstOrDefault();
                if (parentRow != null)
                {
                    TreeNode rootNode = new TreeNode(parentRow["SLMU_Name"].ToString())
                    {
                        Tag = parentRow["SLMU_Code"]
                    };
                    int parenttype = 0;
                    
                    if (submenu.Name == "tvLevl2Submenu") 
                    {
                         parenttype = 1;
                    }
                    submenu.Nodes.Add(rootNode);                   

                    // Load all children recursively
                    LoadSubMenu(rootNode, parentMenuCode, parenttype);
                    
                }
                tvSubmenu.ExpandAll();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LoadSubMenu(TreeNode parentNode, string parentMenuCode,int parenttype)
        {
            try
            {
                DataView dv = new DataView(objDtSalesUserMenuDetails);
                dv.RowFilter = $"SLMU_ParentMenuCode = {parentMenuCode}";
                DataTable objDtSubMenuClone = dv.ToTable();
                int count = 0;
                if (objDtSubMenu.Rows.Count == 0)
                {
                    objDtSubMenu = dv.ToTable();
                } 

                foreach (DataRow row in objDtSubMenuClone.Rows)
                {
                    string nodeText = row["SLMU_Name"].ToString();
                    string nodeValue = row["SLMU_Code"].ToString();

                    TreeNode childNode = new TreeNode(nodeText)
                    {
                        Tag = nodeValue,
                        Checked = row["Menuflag"] != DBNull.Value && Convert.ToInt32(row["Menuflag"]) == 1
                    };
                    parentNode.Nodes.Add(childNode);

                    if (parentNode.Nodes.Count > 0)
                    {
                        // Call your existing logic to fix the hierarchy state
                        UpdateParentNodes(parentNode.Nodes[0]);
                    }

                    // You might also need a refresh if it's not updating correctly
                    parentNode.TreeView?.Refresh();


                    //// Recursive call to add children of this child
                    ///
                    if (parenttype == 1)
                    { 
                        LoadSubMenu(childNode, nodeValue, 1); 
                    } 
                }


                if (tvLevl2Submenu.Nodes.Count == 1)
                {
                    TreeNode parentNode1 = tvLevl2Submenu.Nodes[0];
                     
                    if (parentNode1.Nodes.Count == 0)
                    {
                        tvLevl2Submenu.Nodes.Clear(); // Clear entire tree
                    }
                }

                parentNode.Expand();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void RemoveSubMenu(TreeView view, int parentMenuCode)
        {
            try
            {
                if (objDtSubMenu != null)
                {
                    for (int i = objDtSubMenu.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(objDtSubMenu.Rows[i]["SLMU_ParentMenuCode"]) == parentMenuCode)
                        {
                            view.Nodes.RemoveAt(i);
                            objDtSubMenu.Rows[i].Delete();

                        }
                    }
                    objDtSubMenu.AcceptChanges();
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

        private void tbFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

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

        private void tbFirst_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                int errorflag = 0;
                if (varChangesFlag == 1 && btnSave.Text != "Save")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(164);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        errorflag = 1;

                    }
                }

                if (tbFirst.SelectedIndex == 1)
                {
                    if (e.TabPage == grpSalesUserPermission)
                    {

                        if (errorflag == 0)
                        {
                            if (btnSave.Text != "Update" && varCLone == 0)
                            {
                                e.Cancel = true; // Prevent the user from switching to tabPage2 
                            }
                            else
                            {
                                DataSet objDs = new DataSet();
                                //**** To call the function from SP ***************
                                SPDataService objspservice = new SPDataService();
                                grdUserPermission.Rows.Clear();
                                objDs = objspservice.udfnSalesUserRoleList(2, Convert.ToInt32(varUserRoleID), 0, 0,"", 0, 0);
                                objspservice.CloseConnection();
                                if (objDs != null)
                                {
                                    if (objDs.Tables.Count != 0)
                                    {
                                        if (objDs.Tables[0].Rows.Count != 0)
                                        {
                                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                            {
                                                grdUserPermission.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["SLMU_NAME"]), 1, 0, 0, 0, 0, 0, 0, Convert.ToString(objDs.Tables[0].Rows[i]["Menu Code"]), Convert.ToString(objDs.Tables[0].Rows[i]["SURM_Access_Level"]), Convert.ToString(objDs.Tables[0].Rows[i]["IsParentFlag"]), Convert.ToString(objDs.Tables[0].Rows[i]["PrivilegeCode"]), Convert.ToString(objDs.Tables[0].Rows[i]["SplFlag"]));

                                            }
                                        }

                                    }
                                }

                            }
                            grdUserPermission_DataBindingComplete(grdUserPermission, new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
                else
                {
                    if (errorflag != 0)
                    {
                        e.Cancel = true;
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
                grdUserPermission.ClearSelection();
            }
        }

        private void CP_UserRole_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
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

        private void grdUserPermission_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                int viewColumnIndex = grdUserPermission.Columns["clmViewchk"]?.Index ?? -1;
                string PrivilegeCode = Convert.ToString(grdUserPermission.Rows[e.RowIndex].Cells["clmPrivilegeCode"].Value);


                // Check if the change happened in the 'View' column (clmViewchk)
                if (e.ColumnIndex == viewColumnIndex && e.RowIndex >= 0)
                {
                    // Define the names of the columns to enable/disable
                    var permissionColumns = new[] {

            "clmViewchk",
            "clmCreatechk",
            "clmEditchk",
            "clmDeletechk",
            "clmPrintchk",
            "clmExcelchk",
            "clmNotificationchk",
                "Action"
        };

                    // --- FIX FOR SPECIFIED CAST IS NOT VALID ---
                    object cellValue = grdUserPermission.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Safely convert the cell's value to a boolean. 
                    // This handles DBNull, 0/1 integers, and boolean strings gracefully.
                    bool isViewChecked = Convert.ToBoolean(cellValue);
                    // ---------------------------------------------

                    int privilegeNo = 0;
                    // If 'View' is checked (true), other columns should be ENABLED (ReadOnly = false)
                    // If 'View' is NOT checked (false), other columns should be DISABLED (ReadOnly = true)
                    bool setReadOnly = !isViewChecked;

                    // Iterate through the other permission columns
                    if (!string.IsNullOrEmpty(PrivilegeCode))
                    {
                        foreach (var colName in permissionColumns)
                        {
                            // Find the index of the current permission column
                            int colIndex = grdUserPermission.Columns[colName]?.Index ?? -1;

                            if (colIndex != -1)
                            {
                                var cell = grdUserPermission.Rows[e.RowIndex].Cells[colIndex];
                                if (!string.IsNullOrEmpty(PrivilegeCode))
                                {
                                    var allowed = PrivilegeCode.Split(',')
                                                               .Select(s => s.Trim())
                                                               .Where(s => int.TryParse(s, out _))
                                                               .Select(int.Parse)
                                                               .ToList();
                                    privilegeNo = privilegeNo + 1;
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
                                        // OPTIONAL: Uncheck the box and gray out the cell when disabled
                                        if (colName != "Action")
                                        {
                                            if (allowed.Contains(privilegeNo))
                                            {
                                                cell.Value = false;
                                            }
                                            else
                                            {
                                                cell.ReadOnly = true;
                                            }
                                        }
                                        cell.Style.BackColor = System.Drawing.Color.LightGray;
                                    }
                                    else
                                    {
                                        if (allowed.Contains(privilegeNo))
                                        {
                                            // Reset the background color when enabled
                                            cell.Style.BackColor = grdUserPermission.DefaultCellStyle.BackColor;
                                        }
                                        else
                                        {
                                            cell.ReadOnly = true;
                                            cell.Style.BackColor = System.Drawing.Color.LightGray;
                                        }
                                    }
                                }
                                else
                                {
                                    cell.ReadOnly = true;
                                    // Reset the background color when enabled
                                    cell.Style.BackColor = System.Drawing.Color.LightGray;
                                }
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
        private const string ViewCol = "clmViewchk";
        private const string ActionCol = "Action";
        private const int ViewCode = 1;
        private const int ActionCode = 8;

        private static readonly Dictionary<string, int> PrivilegeMap = new Dictionary<string, int>
{
    { "clmViewchk", 1 },
    { "clmCreatechk", 2 },
    { "clmEditchk", 3 },
    { "clmDeletechk", 4 },
    { "clmPrintchk", 5 },
    { "clmExcelchk", 6 },
    { "clmNotificationchk", 7 },
    { "clmClonechk", 11 }
};

        private bool _isBinding;
        private Image _actionImage;
        private readonly Bitmap _blankImage = new Bitmap(1, 1);

        private static HashSet<int> ParseCodes(object value)
        {
            var set = new HashSet<int>();
            foreach (var s in Convert.ToString(value).Split(','))
                if (int.TryParse(s.Trim(), out int n)) set.Add(n);
            return set;
        }

        private static bool ToBool(object v)
        {
            if (v == null || v == DBNull.Value) return false;
            if (v is bool b) return b;
            string s = Convert.ToString(v);
            return s == "1" || s.Equals("true", StringComparison.OrdinalIgnoreCase);
        }

        private HashSet<int> GetAllowed(DataGridViewRow row)
        {
            return ParseCodes(row.Cells["clmPrivilegeCode"].Value);
        }

        // Subordinate cells are active only when View is checked (or View isn't a privilege for the row)
        private bool IsGateOpen(DataGridViewRow row, HashSet<int> allowed)
        {
            return !allowed.Contains(ViewCode) || ToBool(row.Cells[ViewCol].Value);
        }

        private void CaptureActionImage()
        {
            if (_actionImage != null) return;
            if (grdUserPermission.Columns[ActionCol] is DataGridViewImageColumn ic && ic.Image != null)
            {
                _actionImage = ic.Image;
                return;
            }
            foreach (DataGridViewRow r in grdUserPermission.Rows)
            {
                if (r.IsNewRow) continue;
                if (r.Cells[ActionCol].Value is Image img && img.Width > 1)
                {
                    _actionImage = img;
                    return;
                }
            }
        }

        // Single place that decides visibility, editability and gray-out of a row's permission cells
        private void ApplyRowState(DataGridViewRow row)
        {
            var allowed = GetAllowed(row);
            bool gateOpen = IsGateOpen(row, allowed);

            foreach (var kv in PrivilegeMap)
            {
                if (!grdUserPermission.Columns.Contains(kv.Key)) continue;
                int ci = grdUserPermission.Columns[kv.Key].Index;
                bool isView = kv.Key == ViewCol;

                if (!allowed.Contains(kv.Value))
                {
                    if (!(row.Cells[ci] is DataGridViewTextBoxCell) || row.Cells[ci].Value as string != "")
                        row.Cells[ci] = new DataGridViewTextBoxCell { Value = "" };
                    row.Cells[ci].ReadOnly = true;
                    row.Cells[ci].Style.BackColor = Color.LightGray;
                    continue;
                }

                if (!(row.Cells[ci] is DataGridViewCheckBoxCell))
                    row.Cells[ci] = (DataGridViewCell)grdUserPermission.Columns[ci].CellTemplate.Clone();

                var cell = row.Cells[ci];
                bool enabled = isView || gateOpen;

                if (enabled)
                {
                    cell.ReadOnly = false;
                    cell.Style.BackColor = Color.Empty;
                }
                else
                {
                    if (ToBool(cell.Value)) cell.Value = false;
                    cell.ReadOnly = true;
                    cell.Style.BackColor = Color.LightGray;
                }
            }

            if (grdUserPermission.Columns.Contains(ActionCol))
            {
                var actCell = row.Cells[ActionCol];
                string splFlag = row.Cells["clmsplflag"].Value?.ToString() ?? "";
                bool actionAllowed = allowed.Contains(ActionCode) && splFlag != "0";

                if (actionAllowed)
                {
                    actCell.Value = _actionImage;
                    actCell.ReadOnly = !gateOpen;
                    actCell.Style.BackColor = gateOpen ? Color.Empty : Color.LightGray;
                }
                else
                {
                    actCell.Value = _blankImage;
                    actCell.ReadOnly = true;
                    actCell.Style.BackColor = Color.LightGray;
                }
            }
        }
        // ===== 1. DataBindingComplete =====
        private void grdUserPermission_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            _isBinding = true;
            try
            {
                CaptureActionImage();

                foreach (DataGridViewRow row in grdUserPermission.Rows)
                {
                    if (row.IsNewRow) continue;

                    int parentFlag = Convert.ToInt32(row.Cells["clmParentFlag"].Value);
                    string saved = row.Cells["SURM_Access_Level"].Value?.ToString() ?? "";
                    var allowed = GetAllowed(row);

                    // Row highlight
                    if (parentFlag == 1)
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    else if (parentFlag == 10 || parentFlag == 1000)
                        row.DefaultCellStyle.BackColor = Color.AliceBlue;
                    else if (parentFlag == 100)
                        row.DefaultCellStyle.BackColor = Color.Honeydew;

                    // Make sure allowed columns hold checkbox cells, blank the rest
                    ApplyRowState(row);

                    // Apply saved selections (only where the privilege is allowed)
                    foreach (var code in ParseCodes(saved))
                    {
                        if (!allowed.Contains(code)) continue;
                        foreach (var kv in PrivilegeMap)
                        {
                            if (kv.Value != code) continue;
                            var cell = row.Cells[kv.Key];
                            if (cell is DataGridViewCheckBoxCell) cell.Value = true;
                        }
                    }

                    // Re-evaluate now that View's saved value is known
                    ApplyRowState(row);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                _isBinding = false;
            }
        }
        // ===== 4. CellPainting (same output as before, de-duplicated) =====
        private void grdUserPermission_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex != grdUserPermission.Columns["clmMenuname"].Index) return;

                string menuType = grdUserPermission.Rows[e.RowIndex].Cells["clmParentFlag"].Value?.ToString();
                bool selected = e.State.HasFlag(DataGridViewElementStates.Selected);

                if (menuType == "2" || menuType == "10")
                    DrawMenuCell(e, "├⮞", 3, 25, selected ? Color.Black : Color.Blue);
                else if (menuType == "3" || menuType == "100")
                    DrawMenuCell(e, "├⮞", 30, 50, selected ? Color.Black : Color.Blue);
                else if (menuType == "4" || menuType == "1000")
                    DrawMenuCell(e, "└⮞", 60, 80, selected ? Color.Black : Color.DarkBlue);
                else if (menuType == "5")
                    DrawMenuCell(e, "└⮞", 100, 120, selected ? Color.Black : Color.DarkBlue);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DrawMenuCell(DataGridViewCellPaintingEventArgs e, string arrow, int arrowX, int textX, Color arrowColor)
        {
            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            TextRenderer.DrawText(e.Graphics, arrow, e.CellStyle.Font,
                new Point(e.CellBounds.X + arrowX, e.CellBounds.Y + 2), arrowColor);

            TextRenderer.DrawText(e.Graphics, e.Value?.ToString(), e.CellStyle.Font,
                new Rectangle(e.CellBounds.X + textX, e.CellBounds.Y + 2,
                              e.CellBounds.Width - 10, e.CellBounds.Height),
                Color.Black, TextFormatFlags.Left);
        }

        private void grdUserPermission_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdUserPermission.IsCurrentCellDirty)
                {
                    grdUserPermission.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        // ===== 2. CellValueChanged =====
        private void grdUserPermission_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_isBinding || e.RowIndex < 0 || e.ColumnIndex < 0) return;
                if (grdUserPermission.Columns[e.ColumnIndex].Name != ViewCol) return;

                var row = grdUserPermission.Rows[e.RowIndex];
                ApplyRowState(row);

                if (!ToBool(row.Cells[ViewCol].Value) && objdtMR_UserRole_Menu_SPL_Access != null)
                {
                    int menuId = Convert.ToInt32(row.Cells["clmMenuId"].Value);

                    var rowsToDelete = objdtMR_UserRole_Menu_SPL_Access
                        .AsEnumerable()
                        .Where(r => r.RowState != DataRowState.Deleted &&
                                    Convert.ToInt32(r["UAS_Menuid"]) == menuId)
                        .ToList();

                    rowsToDelete.ForEach(r => r.Delete());
                    objdtMR_UserRole_Menu_SPL_Access.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        // ===== 3. CellContentClick =====
        private void grdUserPermission_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                if (grdUserPermission.Columns[e.ColumnIndex].Name != ActionCol) return;

                DataGridViewRow row = grdUserPermission.Rows[e.RowIndex];
                var allowed = GetAllowed(row);
                string splFlag = row.Cells["clmsplflag"].Value?.ToString() ?? "";

                if (!allowed.Contains(ActionCode) || splFlag == "0") return;
                if (!IsGateOpen(row, allowed)) return;

                try
                {
                    DataTable objDtSplPermissionClone = objDtSplPermission.Copy();
                    DataView dvspl = new DataView(objDtSplPermissionClone);
                    dvspl.RowFilter = "SLMUP_SLMU_CODE = " + Convert.ToInt32(row.Cells["clmMenuId"].Value) + " ";
                    objDtSplPermissionFilterTable = dvspl.ToTable();

                    MainForm.objCP_Sales_UserRole_SPL = new CP_Sales_UserRole_SPL();
                    MainForm.objCP_Sales_UserRole_SPL.FormBorderStyle = FormBorderStyle.FixedSingle;
                    MainForm.objCP_Sales_UserRole_SPL.varmenuid = Convert.ToInt32(row.Cells["clmMenuId"].Value);
                    MainForm.objCP_Sales_UserRole_SPL.PbMenuName = Convert.ToString(row.Cells["clmMenuname"].Value);
                    MainForm.objCP_Sales_UserRole_SPL.varUserRoleID = varUserRoleID;
                    MainForm.objCP_Sales_UserRole_SPL.ShowDialog();
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

        private void tvLevl2Submenu_AfterCheck(object sender, TreeViewEventArgs e)
        {

            try
            {
                if (e.Action != TreeViewAction.Unknown)
                {
                    varChangesFlag = 1;
                    TreeNode clickedNode = e.Node;
                    SetChildNodes(e.Node, e.Node.Checked); // Step 1 → check/uncheck children
                    UpdateParentNodes(e.Node);  // Step 2 → update parent checkbox 
                    UpdateFlag(e.Node.Tag.ToString(), e.Node.Checked, clickedNode.Nodes.Count); // Step 3 → update DataTable  

                    // The main menu node is the currently selected node in tvSubmenu
                    TreeNode mainNode = tvSubmenu.SelectedNode;
                    if (mainNode != null)
                    {
                        string mainMenuCode = mainNode.Tag?.ToString();
                        if (!string.IsNullOrEmpty(mainMenuCode))
                        {
                            DataRow[] mainRows = objDtSalesUserMenuDetails.Select($"SLMU_Code = {mainMenuCode}");
                            if (mainRows.Length > 0)
                            {
                                bool anyChecked = HasAnyCheckedNode(tvLevl2Submenu.Nodes);

                                // ✅ If at least one node checked → Menuflag = 1
                                //    If all unchecked → Menuflag = 0
                                mainRows[0]["Menuflag"] = anyChecked ? 1 : 0;
                            }
                        }
                    }

                    string nodeText = e.Node.Text;

                    // Find a matching node in tvSubmenu2 (recursive search)
                    TreeNode matchingNode = FindNodeByText(tvSubmenu.Nodes, nodeText);

                    if (matchingNode != null && matchingNode.Checked != e.Node.Checked)
                    {
                        matchingNode.Checked = e.Node.Checked; 
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
            }
        }


        private void tvSubmenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try {
                tvSubmenu.Nodes.Cast<TreeNode>()
                .SelectMany(n => new[] { n }.Concat(n.Nodes.Cast<TreeNode>()))
                .ToList()
                .ForEach(n =>
                {
                    n.BackColor = Color.White;
                    n.ForeColor = Color.Black;
                });
                if (e.Action != TreeViewAction.Unknown)
                { 
                    TreeNode clickedNode = e.Node;
                    if (e.Node.Level != 0)
                    {
                        if (e.Action != TreeViewAction.ByMouse) return; // avoid recursion when setting programmatically

                        string menuCode = e.Node.Tag.ToString();

                        if (menuCode == "")
                        {
                            menuCode = "0";
                        }

                        //objDtSubMenu.Clear(); 

                        if (e.Node.IsSelected)
                            LoadSubMenuForParent(tvLevl2Submenu, menuCode);
                        else
                            RemoveSubMenu(tvLevl2Submenu, Convert.ToInt32(menuCode));


                        e.Node.EnsureVisible();
                        tvMainmenu.SelectedNode = e.Node;
                        e.Node.BackColor = Color.LightBlue;
                    }

                    else {
                        tvLevl2Submenu.Nodes.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdUserPermission_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void tvSubmenu_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //// The bounds of the node's text/content area
            //Rectangle nodeBounds = e.Bounds;

            //// Check if the node is a Level 0 node
            //if (e.Node.Level == 0)
            //{
            //    // 1. Calculate the new text bounds (shifting left to hide the checkbox area).
            //    // The constant 19-20 pixels is a rough estimate for the checkbox and padding.
            //    int checkboxWidth = 20;

            //    // Adjust the bounds to start where the checkbox normally ends
            //    Rectangle textBounds = new Rectangle(
            //        nodeBounds.X - checkboxWidth, // Shift text area left
            //        nodeBounds.Y,
            //        nodeBounds.Width + checkboxWidth, // Make the text area wider
            //        nodeBounds.Height
            //    );

            //    // 2. Draw the node's background (optional)
            //    if (e.State.HasFlag(TreeNodeStates.Selected))
            //    {
            //        e.Graphics.FillRectangle(System.Drawing.SystemBrushes.Highlight, nodeBounds);
            //        e.Graphics.DrawString(e.Node.Text, tvSubmenu.Font, System.Drawing.SystemBrushes.HighlightText, textBounds);
            //    }
            //    else
            //    {
            //        e.Graphics.FillRectangle(System.Drawing.SystemBrushes.Window, nodeBounds);
            //        e.Graphics.DrawString(e.Node.Text, tvSubmenu.Font, System.Drawing.SystemBrushes.WindowText, textBounds);
            //    }

            //    // Crucial: Set DrawDefault to false since we drew manually
            //    e.DrawDefault = false;
            //}
            //else
            //{
            //    // 3. For all other levels (Level 1, 2, etc.), draw the node normally
            //    //    (This includes the visible checkbox)
            //    e.DrawDefault = true;
            //}
        }
        private void tvSubmenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action != TreeViewAction.Unknown)
                {
                    varChangesFlag = 1;
                    TreeNode clickedNode = e.Node;

                    if (e.Action != TreeViewAction.ByMouse) return; // avoid recursion when setting programmatically

                    // Step 1 → check/uncheck children
                    SetChildNodes(e.Node, e.Node.Checked);

                    // Step 2 → update parent checkbox
                    UpdateParentNodes(e.Node);

                    // Step 3 → update DataTable flag for the clicked node
                    UpdateFlag(e.Node.Tag.ToString(), e.Node.Checked, clickedNode.Nodes.Count);
                     
                    TreeNode mainNode = tvMainmenu.SelectedNode;
                    if (mainNode != null)
                    {
                        string mainMenuCode = mainNode.Tag?.ToString();
                        if (!string.IsNullOrEmpty(mainMenuCode))
                        {
                            DataRow[] mainRows = objDtSalesUserMenuDetails.Select($"SLMU_Code = {mainMenuCode}");
                            if (mainRows.Length > 0)
                            {
                                bool anyChecked = HasAnyCheckedNode(tvSubmenu.Nodes);
                                 
                                mainRows[0]["Menuflag"] = anyChecked ? 1 : 0;
                            }
                        }
                    }
                }

                string nodeText = e.Node.Text;

                // Step 5 → Sync with Level2 Tree
                TreeNode matchingNode = FindNodeByText(tvLevl2Submenu.Nodes, nodeText);
                if (matchingNode != null && matchingNode.Checked != e.Node.Checked)
                {
                    matchingNode.Checked = e.Node.Checked;
                    tvLevl2Submenu_AfterCheck(tvLevl2Submenu, new TreeViewEventArgs(matchingNode, e.Action));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void tvSubmenu_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }

        

        private void SetChildNodes(TreeNode node, bool isChecked)
        {
            try
            {
                // 1. Define a local function to recursively gather all descendant nodes
                IEnumerable<TreeNode> GetAllDescendants(TreeNode parent)
                {
                    // Select all child nodes and flatten them using SelectMany
                    return parent.Nodes.Cast<TreeNode>()
                        .SelectMany(child => new[] { child }.Concat(GetAllDescendants(child)));
                }

                // 2. Use the helper function to get all descendants of the starting node
                //    This now correctly includes Purchase Hsn Wise and Purchase Hsn Name Wise Product.
                GetAllDescendants(node)
                    .ToList()
                    .ForEach(n => n.Checked = isChecked);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void UpdateParentNodes(TreeNode node)
        {
            try
            {
                if (node.Parent == null) return;

                var siblings = node.Parent.Nodes.Cast<TreeNode>();
                bool allChecked = siblings.All(s => s.Checked);
                bool anyChecked = siblings.Any(s => s.Checked);

                node.Parent.Checked = allChecked;

                UpdateParentNodes(node.Parent);


                 
                TreeNode matchingNode = FindNodeByText(tvSubmenu.Nodes, node.Parent.Text); 

                if (matchingNode != null && matchingNode.Checked != allChecked)
                {
                    matchingNode.Checked = allChecked;
                     
                }



            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void UpdateFlag(string menuCode, bool isChecked, int nodeCount)
        {
            try
            {
                // 1. Update the flag for the *clicked node itself* (Leaf or Parent)
                var selfRows = objDtSalesUserMenuDetails.AsEnumerable()
                    .Where(r => r["SLMU_Code"].ToString() == menuCode);

                selfRows.ToList().ForEach(r => r["Menuflag"] = isChecked ? 1 : 0);

                // 2. If it's a parent, update all descendants (DOWNWARD propagation)
                //if (nodeCount > 0)
                //{
                    UpdateAllDescendantFlags(menuCode, isChecked);
                //}

                // 3. If it's a leaf/child or an intermediate parent, update flags UPWARDS
                // This handles your requirement: grandchild clicked -> child flag updated -> parent flag updated
                UpdateParentFlagsInDataTable(menuCode);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        /// <summary>
        ///  select all checked then all child select
        /// </summary> 
        private void UpdateAllDescendantFlags(string parentMenuCode, bool isChecked)
        {
            try
            {
                // find and update first level child
                // Find all immediate children of the current parentMenuCode
                objDtSalesUserMenuDetails.AsEnumerable()
                    .Where(r => r["SLMU_ParentMenuCode"].ToString() == parentMenuCode)
                    .ToList() // Convert to a list to use the List<T>.ForEach method
                    .ForEach(row =>
                    {
                        // 1. Update the current child's flag   
                        row["Menuflag"] = isChecked ? 1 : 0;

                        // if incase child have 2 level again calling
                        // 2. Recursively call the function to update its children
                        string childMenuCode = row["SLMU_Code"].ToString();
                        UpdateAllDescendantFlags(childMenuCode, isChecked);
                    });
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        /// <summary>
        ///  only one grand child checked , change the flag for the parent 
        ///  grand child id is 1000 checked true then child lvl 2 id 100 ,  child lvl 1 id 10, parent id  1 all flag update
        /// </summary> 
        private void UpdateParentFlagsInDataTable(string childMenuCode)
        {
            try
            {
                // 1. Find the parent code of the current child
                var childRow = objDtSalesUserMenuDetails.AsEnumerable()
                    .FirstOrDefault(r => r["SLMU_Code"].ToString() == childMenuCode);

                if (childRow == null) return;

                string parentMenuCode = childRow["SLMU_ParentMenuCode"].ToString();

                // Stop recursion if we've reached the top (e.g., parent code is "0" or empty)
                if (string.IsNullOrEmpty(parentMenuCode) || parentMenuCode == "0") return;

                // 2. Check the state of ALL siblings (all children of the parent)
                var siblingRows = objDtSalesUserMenuDetails.AsEnumerable()
                    .Where(r => r["SLMU_ParentMenuCode"].ToString() == parentMenuCode);

                // Check if ANY sibling (including the one that was just clicked) is checked (Flag = 1)
                bool anySiblingChecked = siblingRows.Any(r => r.Field<int>("Menuflag") == 1);

                // 3. Find the parent row
                var parentRow = objDtSalesUserMenuDetails.AsEnumerable()
                    .FirstOrDefault(r => r["SLMU_Code"].ToString() == parentMenuCode);

                if (parentRow != null)
                {
                    int currentParentFlag = parentRow.Field<int>("Menuflag");
                    int newParentFlag = anySiblingChecked ? 1 : 0;

                    // Only update if the state has genuinely changed to avoid unnecessary recursion
                    if (currentParentFlag != newParentFlag)
                    {
                        // Update the parent's flag
                        parentRow["Menuflag"] = newParentFlag;

                        // 4. Recurse: Call the function for the updated parent to check ITS parent
                        UpdateParentFlagsInDataTable(parentMenuCode);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEdit()
        {
            try
            {
                if (varUserRoleID != 0)
                {
                    txtSalesUserRole.Text = varUserRoleName;
                    tvMainmenu.Nodes.Clear(); // clear previous first tree
                    tvSubmenu.Nodes.Clear(); // clear previous second tree
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objspservice = new SPDataService();

                    objDs = objspservice.udfnSalesUserRoleList(1, Convert.ToInt32(varUserRoleID), 0, 0,"", 0, 0);
                    objspservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                var varGetSameData = from dt1 in objDtSalesUserMenuDetails.AsEnumerable()
                                                     join dt2 in objDs.Tables[0].AsEnumerable()
                                                     on dt1.Field<int>("SLMU_Code") equals Convert.ToInt32(dt2.Field<string>("SURM_Access_MenuCode"))
                                                     select dt1;
                                varGetSameData.ToList().ForEach(row =>
                                {
                                    row["Menuflag"] = 1;
                                });

                                if (objDs.Tables[0].Rows[0]["SUR_STSID"].ToString() == "1")
                                {
                                    rbActive.Checked = true;
                                }
                                else
                                {
                                    rbInactive.Checked = true;
                                }
                            }
                        }
                    }

                    if (varCLone == 1) 
                    {
                        grdUserPermission.Rows.Clear();
                        objDs = objspservice.udfnSalesUserRoleList(2, Convert.ToInt32(varUserRoleID), 0, 0, "", 0, 0);
                        objspservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        grdUserPermission.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["SLMU_NAME"]), 1, 0, 0, 0, 0, 0, 0, Convert.ToString(objDs.Tables[0].Rows[i]["Menu Code"]), Convert.ToString(objDs.Tables[0].Rows[i]["SURM_Access_Level"]), Convert.ToString(objDs.Tables[0].Rows[i]["IsParentFlag"]), Convert.ToString(objDs.Tables[0].Rows[i]["PrivilegeCode"]), Convert.ToString(objDs.Tables[0].Rows[i]["SplFlag"]), 0);
                                    }
                                }
                            }
                        }

                        grdUserPermission_DataBindingComplete(grdUserPermission, new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
                    }
                   
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        public void udfnSPLPermission_Load()
        {
            try
            {
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnSalesUserRoleList(3, varUserRoleID, 0, 0,"",0,0);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            var varGetSameData = from dt1 in objDtSplPermission.AsEnumerable()
                                                 join dt2 in objDs.Tables[0].AsEnumerable()
                                                 on Convert.ToInt32(dt1["SLMUP_Code"] ?? 0)
                                                 equals Convert.ToInt32(dt2["SURSF_FieldID"] ?? 0)
                                                 select new { dt1, dt2 };

                            foreach (var item in varGetSameData)
                            {
                                item.dt1["AccessLevel"] = item.dt2["SURSF_Access_Level"]?.ToString() ?? "";
                                item.dt1["ViewAccess"] = item.dt2["ViewAccess"]?.ToString() ?? "";
                                item.dt1["EditAccess"] = item.dt2["EditAccess"]?.ToString() ?? "";
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
        public  TreeNode FindNodeByText(TreeNodeCollection nodes, string text)
        {
            try
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Text.Equals(text, StringComparison.OrdinalIgnoreCase))
                        return node;

                    TreeNode child = FindNodeByText(node.Nodes, text);
                    if (child != null)
                        return child;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

            return null;
        }

        private bool HasAnyCheckedNode(TreeNodeCollection nodes)
        {
            try {
                foreach (TreeNode node in nodes)
                {
                    if (node.Checked) return true;
                    if (HasAnyCheckedNode(node.Nodes)) return true; // recursive check
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return false;
        }

    }
}
