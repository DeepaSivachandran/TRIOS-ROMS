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
    public partial class CP_City : Form
    {
        DataError objError;
        private ToolTip tpCityName = new ToolTip();
        private ToolTip tpPincode = new ToolTip();
        private ToolTip tpState = new ToolTip();
        private ToolTip tpDistrict = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int varstatus;
        public string PbCityName="";
        public string pbPincode = "";
        public int varCityCode= 0;
        public string varCityName = "";
        public string PbStateName="";
        public string pbDistrictName="";
        public int PbStateId=0;
        public int PbStatus=0;
        public int varUpdate = 0;
        public int varmastertype = 0;
        public int varflog = 0;
        public int pbDistrictID = 0;
        public CP_City()
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
                if (varflog == 0)
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_State", " ST_STSID=1 AND STID !=0 Order by STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                    objDataBind.BindComboBoxListSelected("DEF_District", " DIST_STSID=1 AND DISTID NOT IN (0) Order by DISTID", "DIST_Name,DISTID", cmbDistrict, "", "DIST_Name", "DISTID");
                    objDataBind = null;
                    if (btnSave.Text == "Save")
                    {
                        pnlStatus.Enabled = false;
                    }
                    else
                    {
                        pnlStatus.Enabled = true;
                        udfnLoad();
                    }
                    this.FormBorderStyle = FormBorderStyle.FixedDialog;
                    MainForm.objCP_Citylist.picLoader.Visible = false;
                    MainForm.objCP_Citylist.picLoader.SendToBack();
                }
                else
                {
                    DataBind objDTBind = new DataBind();
                    objDTBind.BindComboBoxListSelected("DEF_State", " ST_STSID=1 AND STID ="+ MainForm.objCP_CP_Broker.varStateID, "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                    cmbState.Enabled = false;
                    objDTBind = null;
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
                txtPincode.Text = pbPincode;
                cmbDistrict.SelectedValue = pbDistrictID;
                cmbState.SelectedValue = PbStateId;
                if (PbStatus == 1) { rbActive.Checked = true; } else { rbInActive.Checked = true; }
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
                if (rbActive.Checked == true) { varstatus = 1; }
                else { varstatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = "";int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "City Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "City Updation";
                    varType = 1;    
                }
                varResult = objspservice.udfnCity(varType, varCityCode, Convert.ToString(cmbState.SelectedValue), (txtCityName.Text).Trim(), varstatus, varoriginator, MainForm.pbUserID, 0, Convert.ToInt32(cmbDistrict.SelectedValue), Convert.ToInt32(txtPincode.Text));
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
                        MainForm.objCP_CP_Broker.varStateID = Convert.ToInt32(cmbState.SelectedValue);
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
                if (Convert.ToString(txtPincode.Text).Trim() == "")
                {
                    epCity.SetError(txtPincode, "Please enter pincode");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPincode.ShowAlways = true;
                    tpPincode.Show("Please enter pincode", txtPincode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                {
                    epCity.SetError(cmbState, "Please select state name.");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please select state name.", cmbState, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbDistrict.SelectedValue) == "" || Convert.ToString(cmbDistrict.SelectedValue) == "-1")
                {
                    epCity.SetError(cmbDistrict, "Please select district name.");
                    cmbDistrict.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please select district name.", cmbDistrict, 5000);
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
        private void CmbState_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbState.BackColor = Color.LemonChiffon;
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
                    cmbDistrict.Focus();
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
                    //if (pnlStatus.Enabled)
                    //{
                    //    rbActive.Focus();
                    //}
                    //else { btnSave.Focus(); }
                    txtPincode.Focus();
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
        private void CmbState_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                {
                    epCity.SetError(cmbState, "Please select state name");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please select state name", cmbState, 5000);
                }
                else
                {
                    epCity.Clear();
                    cmbState.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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

        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbState.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }  
        private void cmbDistrict_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbDistrict.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCityName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbDistrict_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbDistrict_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbDistrict.SelectedValue) == "" || Convert.ToString(cmbDistrict.SelectedValue) == "-1")
                {
                    epCity.SetError(cmbDistrict, "Please select district name");
                    cmbDistrict.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDistrict.ShowAlways = true;
                    tpDistrict.Show("Please select district name", cmbDistrict, 5000);
                }
                else
                {
                    epCity.Clear();
                    cmbDistrict.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPincode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPincode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPincode_KeyDown(object sender, KeyEventArgs e)
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

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPincode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPincode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
