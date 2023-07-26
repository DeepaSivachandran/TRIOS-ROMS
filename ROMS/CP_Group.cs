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

        private ToolTip tpgrouptype = new ToolTip();
        private ToolTip tptgroupname = new ToolTip();
        private ToolTip tpegroupname = new ToolTip();
        private ToolTip tptlabelname = new ToolTip();
        private ToolTip tpelabelname = new ToolTip();
        private ToolTip tpsno = new ToolTip();
        public string vargroupcode;
        public String pbFormStatus;
        public CP_Group()
        {
            InitializeComponent();
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
                    eppGroup.SetError(txtEGroupNameEnglish, "Please Enter Group Name In English");
                }
                else
                {
                    txtEGroupNameEnglish.BackColor = Color.White;
                    eppGroup.Clear();
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
                    rbInactive.Focus();
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
                if (txtEGroupNameEnglish.Text == "")
                {
                    eppGroup.SetError(txtEGroupNameEnglish, "Please Enter City Name");
                    txtEGroupNameEnglish.BackColor = ColorTranslator.FromHtml("#fabdbd");
                }
                else
                {
                    eppGroup.Clear();
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
                    rbActive.Focus();
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
                if (txtEGroupNameTamil.Text == "")
                {
                    txtEGroupNameTamil.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    eppGroup.SetError(txtEGroupNameTamil, "Please Enter Group Name in Tamil");
                }
                else
                {
                    txtEGroupNameTamil.BackColor = Color.White;
                    eppGroup.Clear();
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
                eppGroup.Clear();
                if (txtEGroupNameEnglish.Text.Trim()!="" && txtEGroupNameTamil.Text.Trim()!="")
                {
                    MessageBox.Show("", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {  
                    if (txtEGroupNameEnglish.Text.Trim() == "")
                    {
                        eppGroup.SetError(txtEGroupNameEnglish, "Please Enter Group Name in English.");
                        txtEGroupNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    }
                    if (txtEGroupNameTamil.Text.Trim() == "")
                    {
                        eppGroup.SetError(txtEGroupNameTamil, "Please Enter Group Name in Tamil.");
                        txtEGroupNameTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    }
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
                }
                else
                {
                    pnlStatus.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Group_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Group_FormClosing_1(object sender, FormClosingEventArgs e)
        {

            try
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
