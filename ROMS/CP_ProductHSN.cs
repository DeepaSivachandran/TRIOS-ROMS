using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_ProductHSN : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;


        public string varcompanycode;
        public string pbFormStatus;
        public string varstatecode = "";

        //tool tip
        private ToolTip tpContactNo = new ToolTip();
        private ToolTip tpAltContactNo = new ToolTip();
        private ToolTip tpemail = new ToolTip();
        private ToolTip tpgstin = new ToolTip();
        private ToolTip tpfssai = new ToolTip();
        private ToolTip tpplno = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpshortname = new ToolTip();
        private ToolTip tppincode = new ToolTip();
        private ToolTip tpcity = new ToolTip();
        private ToolTip tparea = new ToolTip();
        private ToolTip tpstate = new ToolTip();
        public CP_ProductHSN()
        {
            InitializeComponent();
        }

        private void CP_ProductHSN_Load(object sender, EventArgs e)
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
                btnClose.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtHSNName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtHSNName.Text.Trim() == "")
                {
                    eppHsn.SetError(txtHSNName, "Please Enter HSN Name.");
                    txtHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                }
                else
                {
                    txtHSNName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtHSNCode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtHSNCode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtHSNCode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtHSNCode.Text.Trim() == "")
                {
                    eppHsn.SetError(txtHSNCode, "Please Enter HSN Code.");
                    txtHSNCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                }
                else
                {
                    txtHSNCode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGST.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGST_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbGST_SelectedIndexChanged(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => cmbGST.Select(int.MaxValue, 0)));
        }

        private void CmbGST_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGST.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGST_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbGST.SelectedValue) != "0")
                {
                    eppHsn.SetError(cmbGST, "Please Select GST.");
                }
                else
                {
                    cmbGST.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGST_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                pnlStatus.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_ProductHSN_FormClosing(object sender, FormClosingEventArgs e)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                eppHsn.Clear();
                if (txtHSNName.Text!="" && txtHSNCode.Text!="" && Convert.ToString(cmbGST.SelectedValue) != "0" )
                {
                    MessageBox.Show("", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtHSNName.Text.Trim() == "")
                    {
                        eppHsn.SetError(txtHSNName, "Please Enter HSN Name.");
                        txtHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    }
                    if (txtHSNCode.Text.Trim() == "")
                    {
                        eppHsn.SetError(txtHSNCode, "Please Enter HSN Code.");
                        txtHSNCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    }
                    if (Convert.ToString(cmbGST.SelectedValue) != "0")
                    {
                        eppHsn.SetError(cmbGST, "Please Select GST.");
                    }
                   
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_ProductHSN_KeyDown(object sender, KeyEventArgs e)
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
    }
}


    