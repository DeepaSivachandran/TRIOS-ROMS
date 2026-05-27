using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using ROMS.Model;

namespace ROMS
{  //Created By:-Sathish
    //Created On:-22/08/2023
    public partial class CP_MappedUserList : Form
    {
        MainForm objMainForm = new MainForm();
        DataError objError;
        public int pbvarUserRoleID = 0,pbvarUserID = 0;
        string privilege = "";

        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();

        public CP_MappedUserList()
        {
            InitializeComponent();
        }

        private void grdUserList_DoubleClick(object sender, EventArgs e)
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

        private void grdUserList_KeyDown(object sender, KeyEventArgs e)
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
        private void udfnEdit()
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdUserList.SelectedCells.Count > 0)
                    {
                        Application.DoEvents();

                        DataGridViewRow row =
                            grdUserList.SelectedCells[0].OwningRow;

                        MainForm.objCP_User = new CP_User();

                        MainForm.objCP_User.btnSave.Text = "Update";

                        MainForm.objCP_User.varUserID =
                            Convert.ToString(row.Cells["ID"].Value);

                        MainForm.objCP_User.PbUserRoleID =
                            Convert.ToInt32(row.Cells["UserRoleID"].Value);

                        MainForm.objCP_User.PbPasskeyID =
                            Convert.ToInt32(row.Cells["PassKeyID"].Value);

                        MainForm.objCP_User.PbNameoftheUser =
                            Convert.ToString(row.Cells["User Name"].Value);

                        MainForm.objCP_User.PbLoginid =
                            Convert.ToString(row.Cells["Login ID"].Value);

                        MainForm.objCP_User.PbUserRole =
                            Convert.ToString(row.Cells["User Role"].Value);

                        MainForm.objCP_User.PbPasskey =
                            Convert.ToString(row.Cells["Pass Key"].Value);

                        MainForm.objCP_User.PbStatus =
                            Convert.ToInt32(row.Cells["StatusID"].Value);

                        MainForm.objCP_User.varMappedUserFlag = 1;
                        this.Close();
                        MainForm.objCP_User.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        }
        private void CP_MappedUserList_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }
                if (pbvarUserRoleID != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();
                    objDs = objspservice.udfnUserRoleList(6, pbvarUserRoleID, 0, 0, "", 0, 0);
                    objspservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                grdUserList.DataSource = objDs.Tables[0];
                                grdUserList.Columns["S.No."].Width = 50;
                                grdUserList.Columns["User Name"].Width = 200;
                                grdUserList.Columns["ID"].Visible = false;
                                grdUserList.Columns["UserRoleID"].Visible = false;
                                grdUserList.Columns["PassKeyID"].Visible = false;
                                grdUserList.Columns["Login ID"].Visible = false;
                                grdUserList.Columns["User Role"].Visible = false;
                                grdUserList.Columns["Pass Key"].Visible = false;
                                grdUserList.Columns["StatusID"].Visible = false;
                                grdUserList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdUserList.ClearSelection();
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
        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(51402);
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
