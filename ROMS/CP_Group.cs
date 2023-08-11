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

        private ToolTip tpGroupNameinTamil = new ToolTip();
        private ToolTip tpGroupNameinEnglish = new ToolTip();
       
      
        public string vargroupcode;
        public String pbFormStatus;

        public int varCloseFlag = 0;
        public string varGroupNameinTamil = "";
        public string varGroupNameinEnglish = "";
        public string varHsnCode = "";
        public int varId = 0;

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


        private void txtEGroupNameEnglish_Enter(object sender, EventArgs e)
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

        private void txtEGroupNameEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEGroupNameEnglish.Text == "")
                {
                    txtEGroupNameEnglish.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epGroup.SetError(txtEGroupNameEnglish, "Please Enter Group Name in English");
                }
                else
                {
                    txtEGroupNameEnglish.BackColor = Color.White;
                    epGroup.Clear();
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

        private void TxtEGroupNameEnglish_KeyDown_1(object sender, KeyEventArgs e)
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
                int varStatusid = 1;
                if (rbActive.Checked)
                {
                    varStatusid = 1;
                }
                else
                {
                    varStatusid = 2;
                }
                if (btnSave.Text == "Save")
                {
                    SPDataService objDser = new SPDataService();
                    string varResult = objDser.udfnGroup(0, 0,Convert.ToString(txtEGroupNameEnglish.Text), Convert.ToString(txtEGroupNameTamil.Text), varStatusid, "Creation");
                    objDser.CloseConnection();
                    if (varResult.Split('~')[0] == "3")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnClear();
                        MainForm.objCP_GroupList.udfnList();
                    }
                    else if (varResult.Split('~')[0] == "4")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (btnSave.Text == "Update")
                {
                    SPDataService objDser = new SPDataService();
                    string varResult = objDser.udfnGroup(1,varId , Convert.ToString(txtEGroupNameEnglish.Text), Convert.ToString(txtEGroupNameTamil.Text), varStatusid, "Updation");
                    objDser.CloseConnection();
                    if (varResult.Split('~')[0] == "3")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        varCloseFlag = 1;
                        udfnclose();
                        MainForm.objCP_GroupList.udfnList();
                    }
                    else if (varResult.Split('~')[0] == "4")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                btnSave.BackColor = Color.White;
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
                btnClose.BackColor = Color.White;
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
                    pnlStatus.Enabled = true; udfnEdit();
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
                rbInActive.BackColor = Color.LemonChiffon;
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
    }
}
