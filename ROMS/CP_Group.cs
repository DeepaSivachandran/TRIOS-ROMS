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
    public partial class CP_Group : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public int varmastertype = 0;
        private ToolTip tpGroupNameinTamil = new ToolTip();
        private ToolTip tpGroupNameinEnglish = new ToolTip();

        int varStatusid = 1;
        public String pbFormStatus;

        public int varCloseFlag = 0;
        public string varGroupNameinTamil = "";
        public string varGroupNameinEnglish = "";
        public string varDescription = "";
        public int varGroupCode =0;
        public string varProductGroupName = "";
        public int varId = 0;
        public int varStatus = 0;
        public int varFormFlag = 0;

        public CP_Group()
        {
            InitializeComponent();
        }
        private void CP_Group_Leave(object sender, EventArgs e)
        {
            try
            {
                tpGroupNameinTamil.Active = false;
                tpGroupNameinEnglish.Active = false;
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
        private void CP_Group_KeyDown(object sender, KeyEventArgs e)
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
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEGroupNameEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEGroupNameTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
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

        private void RbInactive_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Group_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
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


        private void TxtEGroupNameEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEGroupNameEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEGroupNameEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEGroupNameEnglish.Text.Trim()== "")
                {
                    epGroup.SetError(txtEGroupNameEnglish, "Please enter product group name in english");
                    txtEGroupNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinEnglish.ShowAlways = true;
                    tpGroupNameinEnglish.Show("Please enter product group name in english", txtEGroupNameEnglish, 5000);
                }
                else
                {
                    epGroup.Clear();
                    txtEGroupNameEnglish.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEGroupNameTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEGroupNameTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEGroupNameTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDescription.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEGroupNameTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEGroupNameTamil.Text.Trim() == "")
                {
                    epGroup.SetError(txtEGroupNameTamil, "Please enter product group name in tamil");
                    txtEGroupNameTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinTamil.ShowAlways = true;
                    tpGroupNameinTamil.Show("Please enter product group name in tamil", txtEGroupNameTamil, 5000);
                }
                else
                {
                    epGroup.Clear();
                    txtEGroupNameTamil.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public void udfnClear()
        {
            try
            {
                txtEGroupNameEnglish.Text = "";
                txtEGroupNameTamil.Text = "";
                txtDescription.Text = "";
                txtEGroupNameEnglish.Focus();
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
                txtEGroupNameEnglish.Text = varGroupNameinEnglish;
                txtEGroupNameTamil.Text = varGroupNameinTamil;
                txtDescription.Text = varDescription;
                varStatusid = varStatus;
                if (varStatusid == 1)
                {
                    rbActive.Checked = true;
                }
                else
                {
                    rbInActive.Checked = true;
                }
                if(varStatus==2)
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
            txtEGroupNameEnglish.Enabled = false;
            txtEGroupNameTamil.Enabled = false;
            txtDescription.Enabled = false;
            this.ActiveControl = rbInActive;
        }
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                string varResult = ""; string varOriginator = "Product Group Creation";
                int varViewType=0; 
                if (rbActive.Checked)
                {
                    varStatusid = 1;
                }
                else
                {
                    varStatusid = 2;
                }
                SPDataService objDser = new SPDataService();
                if (btnSave.Text == "Update")
                {
                    varViewType=1;
                    varOriginator = "Product Group Updation";
                }
                varResult = objDser.udfnGroup(varViewType, varId, Convert.ToString(txtEGroupNameEnglish.Text).Trim(), Convert.ToString(txtEGroupNameTamil.Text).Trim(), varStatusid, varOriginator, MainForm.pbUserID, 0, txtDescription.Text.Trim());
                objDser.CloseConnection();
                btnSave.Enabled = true;
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnSave.Text == "Save")
                    {
                        varGroupCode = Convert.ToInt16(varResult.Split('~')[2]);
                        if (varmastertype == 0 &&  varFormFlag == 0)
                        {
                            udfnClear();
                            MainForm.objCP_GroupList.udfnList();
                          //  MainForm.objCP_GroupList.udfnLoadCmbProductGroup();
                           // MainForm.objCP_GroupList.varGroupId= Convert.ToInt16(MainForm.objCP_GroupList.varGroupCode);
                            udfnClear();
                        }

                        if (varFormFlag == 1)
                        {
                            varFormFlag = 0;
                            varGroupCode = Convert.ToInt16(varResult.Split('~')[2]);
                            varProductGroupName = Convert.ToString(varResult.Split('~')[2]);
                            MainForm.objCP_SubGroup.varProductGroupName = txtEGroupNameEnglish.Text;
                            MainForm.objCP_SubGroup.varGroupCode = varGroupCode;
                            varCloseFlag = 1;
                            udfnclose();
                        }
                        if (varmastertype == 1)
                        {
                            varmastertype = 0;
                            MainForm.objCP_Items.varGroupCode = varGroupCode;
                            MainForm.objCP_Items.varGroupName = txtEGroupNameEnglish.Text.Trim();
                            varCloseFlag = 1;
                            udfnclose();
                        }
                    }
                    else
                    {
                        varCloseFlag = 1;
                        udfnclose();
                        MainForm.objCP_GroupList.udfnLoadCmbProductGroup();
                        MainForm.objCP_GroupList.udfnList();
                    }
                    
                }
                else if (varResult.Split('~')[0] == "4")
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (txtEGroupNameEnglish.Text.Trim() == "")
                {
                    epGroup.SetError(txtEGroupNameEnglish, "Please enter product group name in english");
                    txtEGroupNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinEnglish.ShowAlways = true;
                    tpGroupNameinEnglish.Show("Please enter product group name in english", txtEGroupNameEnglish, 5000);
                    blnErrorFlag = true;
                }
                if (txtEGroupNameTamil.Text.Trim() == "")
                {
                    epGroup.SetError(txtEGroupNameTamil, "Please enter product group name in tamil");
                    txtEGroupNameTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinTamil.ShowAlways = true;
                    tpGroupNameinTamil.Show("Please enter product group name in tamil", txtEGroupNameTamil, 5000);
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

        private void BtnSave_Enter(object sender, EventArgs e)
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

        private void BtnSave_Leave(object sender, EventArgs e)
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

        private void BtnClose_Click(object sender, EventArgs e)
        {

            try
            {
                udfnclose();
                if (varmastertype == 0 && varFormFlag == 0)
                {
                    MainForm.objCP_GroupList.udfnList();
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

        private void CP_Group_Load(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                      varCloseFlag = 0;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnEdit();
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

        private void RbInactive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInActive.BackColor = Color.White;
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
                rbInActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDescription.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInActive.Focus();
                        }
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

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDescription.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
