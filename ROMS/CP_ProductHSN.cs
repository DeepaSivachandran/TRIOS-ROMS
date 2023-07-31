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
        private ToolTip tpHsnName = new ToolTip();
        private ToolTip tpHsnCode = new ToolTip();
        private ToolTip tpGst = new ToolTip();
      
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
                    
                    epHsn.SetError(txtHSNName, "Please Enter HSN Name.");
                    txtHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnName.ShowAlways = true;
                    tpHsnName.Show("Please Enter HSN Name.", txtHSNName, 5000);
                }
                else
                {
                    epHsn.Clear();
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
                    epHsn.SetError(txtHSNCode, "Please Enter HSN Code.");
                    txtHSNCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnCode.ShowAlways = true;
                    tpHsnCode.Show("Please Enter HSN Code.", txtHSNCode, 5000);
                }
                else
                {
                    epHsn.Clear();
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
            try
            {
                BeginInvoke(new Action(() => cmbGST.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
            if (Convert.ToString(cmbGST.SelectedValue) != "0")
            {
                epHsn.SetError(cmbGST, "Please Select GST.");
                cmbGST.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpGst.ShowAlways = true;
                tpGst.Show("Please Select GST.", cmbGST, 5000);
            }
            else
            {
                epHsn.Clear();
                cmbGST.BackColor = Color.White;
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
        private void CmbGST_KeyDown(object sender, KeyEventArgs e)
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

        public void udfnSave(object sender, EventArgs e)
        {
            try
            {

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
                if (Convert.ToString(cmbGST.SelectedValue) != "0")
                {
                    epHsn.SetError(cmbGST, "Please Select GST.");
                    cmbGST.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGst.ShowAlways = true;
                    tpGst.Show("Please Select GST.", cmbGST, 5000);
                    blnErrorFlag = true;
                }
                if (txtHSNName.Text.Trim() == "")
                {
                    epHsn.SetError(txtHSNName, "Please Enter HSN Name.");
                    txtHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnName.ShowAlways = true;
                    tpHsnName.Show("Please Enter HSN Name.", txtHSNName, 5000);
                    blnErrorFlag = true;
                }
                if (txtHSNCode.Text.Trim() == "")
                {
                    epHsn.SetError(txtHSNCode, "Please Enter HSN Code.");
                    txtHSNCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnCode.ShowAlways = true;
                    tpHsnCode.Show("Please Enter HSN Code.", txtHSNCode, 5000);
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

        private void RbInActive_Enter(object sender, EventArgs e)
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

        private void RbInActive_Leave(object sender, EventArgs e)
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
    }
}


    