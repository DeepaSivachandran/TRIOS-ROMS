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
namespace ROMS
{   //Created by:-Sathish;Created on:-21/08/2023
    public partial class CP_UserCategory : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public DataTable dtModules = new DataTable();
        private ToolTip tpCatogaroryName = new ToolTip();
        public string oldpassword,varpassword;
        public string varusercode="";
        public int varUserCategoryCode = 0;
        public int PbUserCategorycode = 0;
        public string PbUserCategoryName = "", varModules = "";
        public string PbDefault;
        public int PbStatus = 0;
        public int varstatus = 0;
        public int varUpdate = 0;
        public int varmastertype = 0;
        public int varCategoryCode = 0, PbOrderNo=0;

        public CP_UserCategory()
        {
            InitializeComponent();
        }
        private void rbActive_KeyDown(object sender, KeyEventArgs e)
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
        private void rbActive_Leave(object sender, EventArgs e)
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
        private void rbInactive_Enter(object sender, EventArgs e)
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
        private void rbInactive_KeyDown(object sender, KeyEventArgs e)
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
        private void rbInactive_Leave(object sender, EventArgs e)
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
        public void udfnLoadSlNo()
        {
            try
            {
                int ViewType = 0;
                if(btnSave.Text=="Save")
                {
                    ViewType = 0;
                }
                else
                {
                    ViewType = 1;
                }
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnSINO(ViewType,varUserCategoryCode);
                objdserv.CloseConnection();
                cmbCTSINO.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbCTSINO.ValueMember = "num";
                            cmbCTSINO.DisplayMember = "num";
                            cmbCTSINO.DataSource = objDT.Tables[0];
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                if (rbActive.Checked == true) { varstatus = 1; }
                else { varstatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "UserCategory Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "UserCategory Updation";
                    varType = 1;
                }
                varResult = objspservice.udfnUserCategory(varType, varUserCategoryCode, (txtCategoryName.Text).Trim(), varstatus,Convert.ToInt32(cmbCTSINO.SelectedValue),varoriginator,MainForm.pbUserID,0,varModules);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    udfnclear();
                    if (varmastertype == 1)
                    {
                        varmastertype = 0;
                        varUpdate = 1;
                        varCategoryCode = Convert.ToInt16(varResult.Split('~')[2]);
                        MainForm.objCP_Employee.varCategoryCode = varCategoryCode;
                        udfnclose();
                    }
                    else
                    {
                        MainForm.objCP_UserCategoryList.udfnList();
                    }
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
                    }
                    udfnclear();
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
        private void udfnclear()
        {
            try
            {
                txtCategoryName.Text = "";
                txtCategoryName.Focus();
                grdModules.Refresh();
                grdModules.DataSource = null;
                udfnModuleload();
                this.ActiveControl = txtCategoryName;
                pnlStatus.Enabled = false;
                udfnLoadSlNo();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnModuleload()
        {
            try
            {
                dtModules.Rows.Clear();
                Application.DoEvents();
                grdModules.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnEmployeeList(11, "", 0, "", 1, 0, 0);
                objdserv.CloseConnection();
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtModules.Rows.Add(false, objDs.Tables[0].Rows[i]["MID"], objDs.Tables[0].Rows[i]["M_Name"]);
                    }
                }
                grdModules.DataSource = null;
                grdModules.DataSource = dtModules;
                grdModules.Columns[0].HeaderText = "";
                grdModules.Columns[0].Width = 30;
                grdModules.Columns["MID"].Visible = false;
                grdModules.Columns["M_Name"].Width = 150;
                grdModules.Columns["M_Name"].ReadOnly = true;
                grdModules.Columns["M_Name"].HeaderText = "Modules";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdModules.ClearSelection();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                bool blnErrorFlag = false;
                varModules = "";
                if (Convert.ToString(txtCategoryName.Text).Trim() == "")
                {
                    epUserCategory.SetError(txtCategoryName, "Please enter catogory name");
                    txtCategoryName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCatogaroryName.ShowAlways = true;
                    tpCatogaroryName.Show("Please enter catogory name", txtCategoryName, 5000);
                    blnErrorFlag = true;
                }
                if (grdModules.Rows.Count > 0)
                {
                    grdModules.DataSource = dtModules;
                    for (int i = 0; i < grdModules.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdModules.Rows[i].Cells[0].Value) == true)
                        {
                            if (varModules == "")
                            {
                                varModules = Convert.ToString(grdModules.Rows[i].Cells["MID"].Value);
                            }
                            else
                            {
                                varModules = varModules + ',' + Convert.ToString(grdModules.Rows[i].Cells["MID"].Value);
                            }
                        }
                    }
                }
                if (blnErrorFlag == false)
                {
                    btnSave.Enabled = false;
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
                this.Close();
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
                if (varmastertype == 0)
                {
                    MainForm.objCP_UserCategoryList.udfnList();
                }
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
        private void CP_UserCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varUpdate == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
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
        }
        private void CP_UserCategory_KeyDown(object sender, KeyEventArgs e)
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
        private void CP_UserCategory_Load(object sender, EventArgs e)
        {
            try
            {
                dtModules = new DataTable();
                dtModules.Columns.Add("", typeof(Boolean));
                dtModules.Columns.Add("MID", typeof(string));
                dtModules.Columns.Add("M_Name", typeof(string));

                udfnModuleload();
                udfnLoadSlNo();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    if (btnSave.Visible)
                    {
                        pnlStatus.Enabled = true;
                    }
                    udfnLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (varmastertype == 0)
                {
                    MainForm.objCP_UserCategoryList.picLoader.Visible = false;
                    MainForm.objCP_UserCategoryList.picLoader.SendToBack();
                }
            }
        }
        private void udfnLoad()
        {
            try
            {
                txtCategoryName.Text = PbUserCategoryName;
                if (PbStatus == 1) { rbActive.Checked = true; } else { rbInactive.Checked = true; }
                cmbCTSINO.SelectedValue = PbOrderNo;

                for (int i = 0; i < grdModules.Rows.Count; i++)
                {
                    string[] Modules = varModules.Split(',');
                    for (int j = 0; j < Modules.Count(); j++)
                    {
                        if (Convert.ToString(grdModules.Rows[i].Cells["MID"].Value) == Convert.ToString(Modules[j]))
                        {
                            grdModules.Rows[i].Cells[0].Value = true;
                        }
                    }
                }
                if (Convert.ToBoolean(grdModules.Rows[2].Cells[0].Value) == true)
                {
                    grdModules.Rows[3].ReadOnly = true;
                    grdModules.Rows[3].DefaultCellStyle.BackColor = Color.LightGray;
                    grdModules.ClearSelection();
                }
                if (Convert.ToBoolean(grdModules.Rows[3].Cells[0].Value) == true)
                {
                    grdModules.Rows[2].ReadOnly = true;
                    grdModules.Rows[2].DefaultCellStyle.BackColor = Color.LightGray;
                    grdModules.ClearSelection();
                }
                if (PbStatus==2)
                {
                    udfnDisable();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDisable()
        {
            txtCategoryName.Enabled = false;
            cmbCTSINO.Enabled = false;
            this.ActiveControl = rbInactive;
        }
        private void TxtCategoryName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCategoryName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCategoryName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtCategoryName.Text).Trim() == "")
                {
                    epUserCategory.SetError(txtCategoryName, "Please enter catogory name");
                    txtCategoryName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCatogaroryName.ShowAlways = true;
                    tpCatogaroryName.Show("Please enter catogory name", txtCategoryName, 5000);
                }
                else
                {
                    epUserCategory.Clear();
                    txtCategoryName.BackColor = Color.White;
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

        private void CmbCTSINO_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbCTSINO.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbCTSINO_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(pnlStatus.Enabled==true)
                    {
                        if(rbActive.Checked==true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInactive.Focus();
                        }
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdModules_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(grdModules.Rows[3].Cells[0].Value) == true)
                {
                    grdModules.Rows[6].ReadOnly = true;
                    grdModules.Rows[6].DefaultCellStyle.BackColor = Color.LightGray;
                    grdModules.ClearSelection();
                }
                else
                {
                    grdModules.Rows[6].ReadOnly = false;
                    grdModules.Rows[6].DefaultCellStyle.BackColor = Color.White;
                }
                if (Convert.ToBoolean(grdModules.Rows[6].Cells[0].Value) == true)
                {
                    grdModules.Rows[3].ReadOnly = true;
                    grdModules.Rows[3].DefaultCellStyle.BackColor = Color.LightGray;
                    grdModules.ClearSelection();
                }
                else
                {
                    grdModules.Rows[3].ReadOnly = false;
                    grdModules.Rows[3].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbCTSINO_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbCTSINO.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbCTSINO_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCTSINO.Focus();
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
