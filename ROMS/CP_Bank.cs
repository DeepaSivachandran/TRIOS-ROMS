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
    //Created By:-Sathish ; Created On:-11-08-2023
    public partial class CP_Bank : Form
    {
        DataError objError;
        private ToolTip tpCityName = new ToolTip();
        private ToolTip tpState = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int varstatus;
        public string PbCityName="";
        public int varCityCode= 0;
        public string varCityName = "";
        public string PbStateName="";
        public int PbStateId=0;
        public int PbStatus=0;
        public int varUpdate = 0;
        public int varmastertype = 0;
        public int varflag = 0;
        public CP_Bank()
        {
            InitializeComponent();
        }
        private void CP_City_Leave(object sender, EventArgs e)
        {
            try
            {
                tpCityName.Active = false;
                tpState.Active = false;
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
            finally {
            }
        }
        private void udfnLoad()
        {
            try
            {
                txtCityName.Text = PbCityName; 
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
                string varResult = "",
                varoriginator = "";int varType = 0;
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
//                varResult = objspservice.udfnCity(varType, varCityCode,  , (txtCityName.Text).Trim(), varstatus, varoriginator,MainForm.pbUserID,0);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //udfnclear();
                    //MainForm.objCP_Citylist.udfnList();
                    if (varmastertype == 1)
                    {
                        varmastertype = 0;
                        varUpdate = 1;
                        varCityCode = Convert.ToInt16(varResult.Split('~')[2]);
                        varCityName = Convert.ToString(varResult.Split('~')[2]);
                        MainForm.objCP_CP_Broker.varCityName = txtCityName.Text;
                        MainForm.objCP_CP_Broker.varCityCode = varCityCode;
                         
                        udfnclose();
                    }
                    else
                    {
                        MainForm.objCP_Citylist.udfnList();
                    }
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
                txtCityName.Text = "";
                txtCityName.Focus();
                this.ActiveControl = txtCityName;
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
                if (Convert.ToString(txtCityName.Text).Trim() == "")
                {
                    epCity.SetError(txtCityName, "Please enter city name");
                    txtCityName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCityName.ShowAlways = true;
                    tpCityName.Show("Please enter city name", txtCityName, 5000);
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
                    MainForm.objCP_Citylist.udfnList();
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
                if (Convert.ToString(txtCityName.Text).Trim() == "")
                {
                    epCity.SetError(txtCityName, "Please enter city name");
                    txtCityName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCityName.ShowAlways = true;
                    tpCityName.Show("Please enter city name", txtCityName, 5000);
                 
                }
                else
                {
                    epCity.Clear();
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
    }
}
