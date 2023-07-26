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
    public partial class CP_City : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public string varbrandcode;
        public string pbFormStatus;
        public CP_City()
        {
            InitializeComponent();
        }
        private void CP_City_Load(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbState.Select(int.MaxValue, 0)));
                if (btnSave.Text=="Save")
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbState.SelectedValue)!="0" && txtCityName.Text!="")
                {
                    MessageBox.Show("","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(Convert.ToString(cmbState.SelectedValue) != "0")
                    {
                        eppCity.SetError(cmbState, "Please Select State.");
                    }
                    if(txtCityName.Text.Trim()=="")
                    {
                        eppCity.SetError(txtCityName, "Please Enter City Name.");
                        txtCityName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    }
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

       
        private void btnSave_Leave(object sender, EventArgs e)
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

        private void CmbState_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbState.BackColor = Color.Yellow;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCityName.Focus();
                }
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCityName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCityName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCityName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCityName.Text == "")
                {
                    eppCity.SetError(txtCityName, "Please Enter City Name");
                    txtCityName.BackColor = ColorTranslator.FromHtml("#fabdbd");
                }
                else
                {
                    eppCity.Clear();
                    txtCityName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCityName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    pnlStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_City_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if(e.KeyCode==Keys.F5)
                {
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_Leave(object sender, EventArgs e)
        {
            try
            {
                //cmbState.BackColor = Color.White;
                if (Convert.ToString(cmbState.SelectedValue) != "0")
                {

                    eppCity.SetError(cmbState, "Please Select State.");
                }
                else
                {
                    cmbState.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void CP_City_FormClosing(object sender, FormClosingEventArgs e)
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
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => cmbState.Select(int.MaxValue, 0)));
        }

        private void CmbState_KeyPress(object sender, KeyPressEventArgs e)
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

      
    }
}
