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
    public partial class CP_Unit : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpUnitName = new ToolTip();
        private ToolTip tpSymbol = new ToolTip();
        private ToolTip tpNoOfDecimals = new ToolTip();
        private ToolTip tpEInvoiceUnitName = new ToolTip();

        public string varbrandcode;
        public string pbFormStatus;
        public CP_Unit()
        {
            InitializeComponent();
        }

        private void CP_Unit_Leave(object sender, EventArgs e)
        {
            try
            {
                tpUnitName.Active = false;
                tpSymbol.Active = false;
                tpNoOfDecimals.Active = false;
                tpEInvoiceUnitName.Active = false;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Unit_Load(object sender, EventArgs e)
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

        private void udfnEdit()
        {
            try
            {
                if (varbrandcode != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS = new DataSet();
                 //   objDS = objspservice.udfnSPBrandList("EditLoad", varbrandcode, MainForm.pbUserID, MainForm.pbIpAddress);
                    objspservice.CloseConnection();

                    if (objDS != null)
                    {
                        //if (objDS.Tables[0].Rows.Count > 0)
                        //{
                        //    txtTEInvoiceUnitName.Text = objDS.Tables[0].Rows[0]["UName"].ToString().Replace("''","'");
                        //    txtDUnitName.Text = objDS.Tables[0].Rows[0]["EIName"].ToString().Replace("''", "'");
                        //    /*  txtDEIUnitName.Text = objDS.Tables[0].Rows[0]["BTLabelName"].ToString().Replace("''", "'");
                        //      txtELabelName.Text = objDS.Tables[0].Rows[0]["BELabelName"].ToString().Replace("''", "'"); */

                        //    btnSave.Text = "Update";
                        //}
                    }

                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;

                if (Convert.ToString(txtEUnitName.Text).Trim() == "")
                {
                    epUnit.SetError(txtEUnitName, "Please enter unit name");
                    txtEUnitName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUnitName.ShowAlways = true;
                    tpUnitName.Show("Please enter unit name", txtEUnitName, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(txtSymbol.Text).Trim() == "")
                {
                    epUnit.SetError(txtSymbol, "Please enter symbol");
                    txtSymbol.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSymbol.ShowAlways = true;
                    tpSymbol.Show("Please enter symbol", txtSymbol, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbNoOfDecimals.SelectedValue) == "" || Convert.ToString(cmbNoOfDecimals.SelectedValue) == "-1")
                {
                    epUnit.SetError(cmbNoOfDecimals, "Please select No.of decimals");
                    cmbNoOfDecimals.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpNoOfDecimals.ShowAlways = true;
                    tpNoOfDecimals.Show("Please select No.of decimals", cmbNoOfDecimals, 5000);
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

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose.Focus();
                }
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
              //  MainForm.objCP_BrandList.udfnList();
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


        private void CP_Brand_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void txtEUnitName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSymbol.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEInvoiceUnitName_KeyDown(object sender, KeyEventArgs e)
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

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbInActive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEInvoiceUnitName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEUnitName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEUnitName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEInvoiceUnitName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEInvoiceUnitName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEUnitName_Leave(object sender, EventArgs e)
        {
            try
            {
                 if(Convert.ToString(txtEUnitName.Text).Trim() == "")
                 {
                    epUnit.SetError(txtEUnitName, "Please enter unit name");
                    txtEUnitName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUnitName.ShowAlways = true;
                    tpUnitName.Show("Please enter unit name", txtEUnitName, 5000);
                }
                else
                {
                    epUnit.Clear();
                    txtEUnitName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSymbol_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSymbol.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSymbol_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtSymbol.Text).Trim() == "")
                {
                    epUnit.SetError(txtSymbol, "Please enter symbol");
                    txtSymbol.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSymbol.ShowAlways = true;
                    tpSymbol.Show("Please enter symbol", txtSymbol, 5000);
                }
                else
                {
                    epUnit.Clear();
                    txtSymbol.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSymbol_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbNoOfDecimals.Focus();
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

        private void TxtEInvoiceUnitName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtEInvoiceUnitName.Text).Trim() == "")
                {
                    epUnit.SetError(txtEInvoiceUnitName, "Please enter E-Invoice unit name");
                    txtEInvoiceUnitName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEInvoiceUnitName.ShowAlways = true;
                    tpEInvoiceUnitName.Show("Please enter E-Invoice unit name", txtEInvoiceUnitName, 5000);
                }
                else
                {
                    epUnit.Clear();
                    tpSymbol.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbNoOfDecimals_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbNoOfDecimals.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbNoOfDecimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbNoOfDecimals.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbNoOfDecimals_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbNoOfDecimals_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbNoOfDecimals.SelectedValue) == "" || Convert.ToString(cmbNoOfDecimals.SelectedValue) == "-1")
                {
                    epUnit.SetError(cmbNoOfDecimals, "Please select No.of decimals");
                    cmbNoOfDecimals.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpNoOfDecimals.ShowAlways = true;
                    tpNoOfDecimals.Show("Please select No.of decimals", cmbNoOfDecimals, 5000);
                }
                else
                {
                    epUnit.Clear();
                    cmbNoOfDecimals.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbNoOfDecimals_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CP_Unit_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CP_Unit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
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
    }
}
