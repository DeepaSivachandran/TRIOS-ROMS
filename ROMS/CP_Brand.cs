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
    public partial class CP_Brand : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public string varbrandcode;

        private ToolTip tpBrandNameInEnglish = new ToolTip();
        private ToolTip tpBrandNameInTamil = new ToolTip();

        public CP_Brand()
        {
            InitializeComponent();
        }

        private void CP_Brand_Leave(object sender, EventArgs e)
        {
            try
            {
                tpBrandNameInEnglish.Active = false;
                tpBrandNameInTamil.Active = false;
              
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
                //  MainForm.objCP_BrandList.udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Brand_FormClosing(object sender, FormClosingEventArgs e)
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

        private void TxtEBrandNameInEnglish_Enter(object sender, EventArgs e)
        {

            try
            {
                txtEBrandNameInEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEBrandNameInEnglish.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInEnglish, "Please enter brand name in english");
                    txtEBrandNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInEnglish.ShowAlways = true;
                    tpBrandNameInEnglish.Show("Please enter brand name in english", txtEBrandNameInEnglish, 5000);
                }
                else
                {
                    epBrand.Clear();
                    txtEBrandNameInEnglish.BackColor = Color.White;
                   
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEBrandNameInTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInTamil_Enter(object sender, EventArgs e)
        {

            try
            {
                txtEBrandNameInTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInTamil_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtEBrandNameInTamil.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInTamil, "Please enter brand name in tamil");
                    txtEBrandNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInTamil.ShowAlways = true;
                    tpBrandNameInTamil.Show("Please enter brand name in tamil", txtEBrandNameInTamil, 5000);
                }
                else
                {
                    epBrand.Clear();
                    txtEBrandNameInTamil.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelectedProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSelectedProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelectedProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSelectedProductSubGroup.BackColor = Color.White;
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

                if (txtEBrandNameInEnglish.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInEnglish, "Please enter brand name in english");
                    txtEBrandNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInEnglish.ShowAlways = true;
                    tpBrandNameInEnglish.Show("Please enter brand name in english", txtEBrandNameInEnglish, 5000);
                    blnErrorFlag = true;
                }

                if (txtEBrandNameInTamil.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInTamil, "Please enter brand name in tamil");
                    txtEBrandNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInTamil.ShowAlways = true;
                    tpBrandNameInTamil.Show("Please enter brand name in tamil", txtEBrandNameInTamil, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false && grdSubGroupAdd.Rows.Count <= 0)
                {
                    if (grdSubGroupAdd.Rows.Count <= 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Please select atleast one product sub group", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    udfnSave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSelectedProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelectedProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnRemove.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRemove_Enter(object sender, EventArgs e)
        {
            try
            {
                btnRemove.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRemove_Leave(object sender, EventArgs e)
        {
            try
            {
                btnRemove.BackColor = Color.White;
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


    }
}
