using ROMS.Model;
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
    //Created By:Sathish ; Created On:-26/11/2025
    public partial class CP_DeliveryPerson : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpDeliveryPerson = new ToolTip();
        public int pbDeliveryPersonId = 0, PbStatus = 0, varUpdate = 0;
        public CP_DeliveryPerson()
        {
            InitializeComponent();
        }
        public void udfnSave()
        {
            try
            {
                if (rbActive.Checked == true) { PbStatus = 1; }
                else { PbStatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Delivery Person Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Delivery Person Updation";
                    varType = 1;
                }
                MR_Sales obj = new MR_Sales();
                obj.paraViewType = varType;
                obj.paraDeliveryPersonId = pbDeliveryPersonId;
                obj.paraName = txtDeliveryPersonName.Text.Trim();
                obj.paraMobileNo = txtMobileNo.Text.Trim();
                obj.paraCode = txtDeliveryPersonCode.Text.Trim();
                obj.paraStatusId = PbStatus;
                obj.paraOriginator = varoriginator;

                varResult = objspservice.udfnDeliveryPerson(obj);
                objspservice.CloseConnection();

                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_DeliveryPersonlist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        txtDeliveryPersonCode.Text = "";
                        txtDeliveryPersonName.Text = "";
                        txtMobileNo.Text = "";
                        this.ActiveControl = txtDeliveryPersonCode;
                    }
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryPersonCode.Text.Trim() == "")
                {
                    epDeliveryPerson.SetError(txtDeliveryPersonCode, "Please enter delivery person code.");
                    txtDeliveryPersonCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDeliveryPerson.ShowAlways = true;
                    tpDeliveryPerson.Show("Please enter delivery person code.", txtDeliveryPersonCode, 5000);
                }
                else if (txtDeliveryPersonName.Text.Trim() == "")
                {
                    epDeliveryPerson.SetError(txtDeliveryPersonName, "Please enter delivery person name.");
                    txtDeliveryPersonName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDeliveryPerson.ShowAlways = true;
                    tpDeliveryPerson.Show("Please enter delivery person name.", txtDeliveryPersonName, 5000);
                }
                else if (txtMobileNo.Text.Trim() == "")
                {
                    epDeliveryPerson.SetError(txtMobileNo, "Please enter mobile number.");
                    txtMobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDeliveryPerson.ShowAlways = true;
                    tpDeliveryPerson.Show("Please enter mobile number.", txtMobileNo, 5000);
                }
                else
                {
                    txtDeliveryPersonCode.BackColor = Color.White;
                    txtDeliveryPersonName.BackColor = Color.White;
                    txtMobileNo.BackColor = Color.White;
                    epDeliveryPerson.Clear();
                    btnSave.Enabled = false;
                    udfnSave();
                    btnSave.Enabled = true;
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
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Brand_Leave(object sender, EventArgs e)
        {
            try
            {
                tpDeliveryPerson.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_DeliveryPerson_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_DeliveryPersonlist.picLoader.Visible = false;
                MainForm.objCP_DeliveryPersonlist.picLoader.SendToBack();
                if (pbDeliveryPersonId == 0)
                {
                    this.ActiveControl = txtDeliveryPersonCode;
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                }
                else
                {
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1)
                    {
                        this.ActiveControl = txtDeliveryPersonCode;
                        rbActive.Checked = true;
                    }
                    else if(PbStatus == 2)
                    {
                        txtDeliveryPersonCode.Enabled = false;
                        txtDeliveryPersonName.Enabled = false;
                        txtMobileNo.Enabled = false;
                        rbInActive.Checked = true;
                        rbInActive.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEdit()
        {
            try
            {
                if (pbDeliveryPersonId != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();

                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 1;
                    obj.paraDeliveryPersonId = pbDeliveryPersonId;
                    obj.paraStatusId = 0;
                    objDs = objspservice.udfnDeliveryPersonList(obj);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            txtDeliveryPersonCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Code"]);
                            txtDeliveryPersonName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Name"]);
                            txtMobileNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Mobile Number"]);
                            txtDeliveryPersonCode.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtDeliveryPersonCode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDeliveryPersonCode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDeliveryPersonCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDeliveryPersonName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDeliveryPersonCode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDeliveryPersonCode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbActive_Enter(object sender, EventArgs e)
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
        private void rbInActive_Enter(object sender, EventArgs e)
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
        private void rbActive_Leave(object sender, EventArgs e)
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
        private void rbInActive_Leave(object sender, EventArgs e)
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

        private void rbActive_KeyDown(object sender, KeyEventArgs e)
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

        private void rbInActive_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDeliveryPersonName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDeliveryPersonName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDeliveryPersonName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMobileNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDeliveryPersonName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDeliveryPersonName.BackColor = Color.White;
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

        private void CP_DeliveryPerson_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtMobileNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMobileNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInActive.Focus();
                        }
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMobileNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMobileNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CP_DeliveryPerson_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_DeliveryPerson_Leave(object sender, EventArgs e)
        {
            try
            {
                tpDeliveryPerson.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
