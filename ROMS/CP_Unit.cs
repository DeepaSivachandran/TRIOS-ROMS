using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ROMS
{
    //Created by:-Sathish;Created on:-08/08/2023
    public partial class CP_Unit : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpUnitName = new ToolTip();
        private ToolTip tpSymbol = new ToolTip();
        private ToolTip tpNoOfDecimals = new ToolTip();
        private ToolTip tpEInvoiceUnitName = new ToolTip();
        public int varmastertype = 0, varUnitCodeProduct=0;
        public string varbrandcode;
        public int varUnitCode = 0;
        public string pbFormStatus;
        public int varstatus;        public string PbUnitName="";
        public string PbSymbol="";
        public string PbNoOfDecimals="";
        public int PbStatus=0;
        public int pbDecimalId = 0;
        public int varUpdate = 0;
        public CP_Unit()
        {
            InitializeComponent();
            MainForm.objCP_Unitlist.picLoader.Visible = false;
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", " MST_TransactionID in (0,2) and MSTID !=0 Order by MSTID", "MST_DisplayText,MSTID", cmbNoOfDecimals, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoad() {
            try {
                txtEUnitName.Text = PbUnitName;
                txtSymbol.Text = PbSymbol;
                cmbNoOfDecimals.SelectedValue = pbDecimalId;
                if (PbStatus == 1) { rbActive.Checked = true; } else { rbInActive.Checked = true; }
            }
            catch (Exception ex) {
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
                    varoriginator = "Unit Creation";
                    varType = 0;
                    if (varmastertype == 1)
                    {
                        varUpdate = 1;
                    }
                }
                else
                {
                    varoriginator = "Unit Updation";
                    varType = 1;
                }
                varResult = objspservice.udfnUnit(varType, varUnitCode, (txtEUnitName.Text).Trim(), txtSymbol.Text.Trim(), Convert.ToInt16(cmbNoOfDecimals.SelectedValue), varstatus, varoriginator);
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
                    }
                    else
                    {
                        varUnitCodeProduct = Convert.ToInt16(varResult.Split('~')[2]);
                    }
                    udfnclear();
                    if (varmastertype == 1)
                    {
                        MainForm.objCP_Items.varUnitCode = varUnitCodeProduct;
                        varmastertype = 0;
                        udfnclose();
                    }
                    else
                    {
                        MainForm.objCP_Unitlist.udfnList();
                    }
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

                txtEUnitName.Text = "";
                txtSymbol.Text = "";
                cmbNoOfDecimals.SelectedIndex = 0;
                txtEUnitName.Focus();
                this.ActiveControl = txtEUnitName;
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
                    btnSave.Enabled = false;
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
                    btnSave.Focus();
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
