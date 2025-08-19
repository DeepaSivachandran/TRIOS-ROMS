using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROMS.Model;


namespace ROMS
{
    //Created By:-Sathish ; Created On:-11-08-2023
    public partial class CP_Bank : Form
    {
        DataError objError;
        private ToolTip tpBankName = new ToolTip();
        private ToolTip tpBankShortName = new ToolTip(); 
        public string pbFormStatus; 
        public string pbBankName = ""; 
        public string pbBankShortName = ""; 
        public int PbStateId=0; 
        public int varUpdate = 0;
        public int varmastertype = 0;
        public int varflag = 0;
        public int varBankId = 0;
        public CP_Bank()
        {
            InitializeComponent();
        }
        private void CP_City_Leave(object sender, EventArgs e)
        {
            try
            {
                tpBankName.Active = false;
                tpBankShortName.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_City_Load(object sender, EventArgs e)
        {
            try
            {
                if (varflag == 0)
                {
                    udfnLoad();
                    this.FormBorderStyle = FormBorderStyle.FixedDialog;
                    MainForm.objCP_BankList.picLoader.Visible = false;
                    MainForm.objCP_BankList.picLoader.SendToBack();
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }
        private void udfnLoad()
        {
            try
            {
                txtShortName.Text = pbBankShortName; 
                txtBankName.Text = pbBankName; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave(object sender,EventArgs e)
        {
            try
            { 
                SPDataService objspservice = new SPDataService();
                string varResult = "",   varoriginator = "";int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Bank Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Bank Updation";
                    varType = 1;
                }
                MR_Bank objMR_Bank = new MR_Bank();
                objMR_Bank.paraViewType = varType;
                objMR_Bank.paraBankId = varBankId;
                objMR_Bank.paraBankName = txtBankName.Text.Trim();
                objMR_Bank.paraShortName = txtShortName.Text.Trim();
                objMR_Bank.paraOriginator = varoriginator;  
                varResult = objspservice.udfnBank(objMR_Bank);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    MainForm.objCP_BankList.udfnList(); 
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
                txtShortName.Text = "";
                txtBankName.Text = "";
                txtBankName.Focus();
                this.ActiveControl = txtBankName;
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
                if (Convert.ToString(txtBankName.Text).Trim() == "")
                {
                    epBank.SetError(txtBankName, "Please enter bank name");
                    txtBankName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank name", txtBankName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epBank.SetError(txtShortName, "Please enter bank short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank short name", txtShortName, 5000);
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
                if (varmastertype == 0)
                {
                    MainForm.objCP_BankList.udfnList();
                }
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
        private void TxtCityName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtShortName.BackColor = Color.LemonChiffon;
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
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epBank.SetError(txtShortName, "Please enter bank short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank short name", txtShortName, 5000);
                 
                }
                else
                {
                    epBank.Clear();
                    txtShortName.BackColor = Color.White;
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
                    btnSave.Focus();
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
        private void CP_City_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varUpdate == 0)
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

        private void TxtBankName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBankName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBankName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtBankName.Text).Trim() == "")
                {
                    epBank.SetError(txtBankName, "Please enter bank name");
                    txtBankName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank name", txtBankName, 5000); 
                }
                else
                {
                    epBank.Clear();
                    txtBankName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtShortName.Focus();
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
