using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
     
namespace ROMS
{
    public partial class CP_Tally : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varbrandcode = 0;

        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpmodule = new ToolTip();

        public int varStatusid = 1; 
        public int varUpdate = 0;
        public int varFormFlag = 0;
        public int varId = 0;
        public int varModifiedFlag = 0;
        public string varBrandId = "";
        public string varGroupId = "";
        public string varSubGroupId = "";
        public int varmastertype = 0;
        public int varRefresh = 0;
        public int varmasterBrandtype = 0;
        public string varGroup = "";
        public string varGroupName = "";
        public string varSubGroupName = "";
        // Added by deepa on 01-09-2023
        public int varCheckAllFlag1 = 0;
        public int varCheckAllFlag2 = 0;
        public int varCheckAllFlag3 = 0;
        public DataTable dtSubGroup = new DataTable();
        public DataTable dtSubGroupAdd = new DataTable();
        public DataTable dtGroup = new DataTable();
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public CP_Tally()
        {
            InitializeComponent();
            dtGroup = new DataTable();
            
        }
     
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnClose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
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
        private void BtnClose_Enter(object sender, EventArgs e)
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

        private void BtnClose_Leave(object sender, EventArgs e)
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

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //udfnclose();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Tally_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 701;
                udfnDropdownLoad();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
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
                btnExport.Visible = privilege.Contains("6"); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDropdownLoad()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                int varconcerntype = 3;
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(varconcerntype, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
                }
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (0,66) AND MSTID<>0 ORDER BY MST_DisplayText desc", "MST_DisplayText,MSTID", cmbModule, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID in (0,67) AND MSTID<>0 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbTransactiontype, "", "MST_DisplayText", "MSTID");
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
                    cmbModule.Focus();
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
                if (Convert.ToInt32(cmbConcern.SelectedValue) == -1 || Convert.ToString(cmbConcern.SelectedValue) == "")
                {
                    epTally.SetError(cmbConcern, "Please select Company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    epTally.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbModule_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbModule.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbModule_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbTransactiontype.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbModule_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbModule.SelectedValue) == -1 || Convert.ToString(cmbModule.SelectedValue) == "")
                {
                    epTally.SetError(cmbModule, "Please select module");
                    cmbModule.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpmodule.ShowAlways = true;
                    tpmodule.Show("Please select module", cmbModule, 5000);
                }
                else
                {
                    epTally.Clear();
                    cmbModule.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactiontype_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTransactiontype.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactiontype_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnExport.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactiontype_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbTransactiontype.SelectedValue) == -1 || Convert.ToString(cmbTransactiontype.SelectedValue) == "")
                {
                    epTally.SetError(cmbTransactiontype, "Please select transaction type");
                    cmbTransactiontype.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpmodule.ShowAlways = true;
                    tpmodule.Show("Please select transaction type", cmbTransactiontype, 5000);
                }
                else
                {
                    epTally.Clear();
                    cmbTransactiontype.BackColor = Color.White;
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

        private void CP_Tally_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnClose();
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
