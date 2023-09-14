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

        private ToolTip tpCatogaroryName = new ToolTip();
        public string oldpassword,varpassword;
        public string varusercode="";
        public int varUserCategoryCode = 0;
        public int PbUserCategorycode = 0;
        public string PbUserCategoryName = "";
        public string PbDefault;
        public int PbStatus = 0;
        public int varstatus = 0;
        public int varUpdate = 0;
        public int varmastertype = 0;
        public int varCategoryCode = 0;

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
                    varResult = objspservice.udfnUserCategory(varType, varUserCategoryCode, (txtCategoryName.Text).Trim(), varstatus, varoriginator);
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
                            MainForm.objCP_User.varCategoryCode = varCategoryCode;
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
                this.ActiveControl = txtCategoryName;
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

                if (Convert.ToString(txtCategoryName.Text).Trim() == "")
                {
                    epUserCategory.SetError(txtCategoryName, "Please enter catogory name");
                    txtCategoryName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCatogaroryName.ShowAlways = true;
                    tpCatogaroryName.Show("Please enter catogory name", txtCategoryName, 5000);
                    blnErrorFlag = true;
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
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
        private void TxtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled)
                    {
                        rbActive.Focus();
                    }
                    else { btnSave.Focus(); }
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
