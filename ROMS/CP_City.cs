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
        private ToolTip tpCityName = new ToolTip();
        private ToolTip tpState = new ToolTip();
        public string varbrandcode;
        public int varstatus;
        public string PbCityName;
        public int varCityCode= 0;
        public int PbStateId;
        public int PbStatus;
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
                //BeginInvoke(new Action(() => cmbState.Select(int.MaxValue, 0)));
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_State", " ST_STSID in (1) and STID !=0 Order by STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                objDataBind = null;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                if (btnSave.Text=="Save")
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
        private void udfnLoad()
        {
            try
            {
                txtCityName.Text = PbCityName;
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
                string varResult = "";
                if (btnSave.Text == "Save")
                {
                    varResult = objspservice.udfnCity(0, 0, Convert.ToString(cmbState.SelectedValue), (txtCityName.Text).Trim(), varstatus, "City Creation");
                }
                else
                {
                    varResult = objspservice.udfnCity(1,varCityCode,Convert.ToString(cmbState.SelectedValue), (txtCityName.Text).Trim(), varstatus, "City Updation");
                    this.Close();
                }
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    udfnclear();
                    MainForm.objCP_Unitlist.udfnList();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                objspservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnclear()
        {
            try
            {
                txtCityName.Text = "";
                cmbState.SelectedIndex = 0;
                btnSave.Text = "Save";
                cmbState.Focus();
                //txtCityName.Focus();
                this.ActiveControl = cmbState;
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
                if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                {
                    epCity.SetError(cmbState, "Please select state name.");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please select state name.", cmbState, 5000);
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
