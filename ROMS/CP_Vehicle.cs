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
    public partial class CP_Vehicle : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpVehicle = new ToolTip();
        public int pbVehicleId = 0, PbStatus = 0, varUpdate = 0;
        public CP_Vehicle()
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
                    varoriginator = "Vehicle Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Vehicle Updation";
                    varType = 1;
                }
                varResult = objspservice.udfnVehicle(varType, pbVehicleId, txtVehicleName.Text.Trim(), txtShortName.Text.Trim(), txtRegisterNo.Text.Trim(), txtCapacity.Text.Trim(), PbStatus, varoriginator);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Vehiclelist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        txtRegisterNo.Text = "";
                        txtVehicleName.Text = "";
                        txtShortName.Text = "";
                        txtCapacity.Text = "";
                        this.ActiveControl = txtRegisterNo;
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
                bool blnErrFlag = false;
                if (txtRegisterNo.Text.Trim() == "")
                {
                    epVehicle.SetError(txtRegisterNo, "Please enter vehicle number.");
                    txtRegisterNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVehicle.ShowAlways = true;
                    tpVehicle.Show("Please enter vehicle number.", txtRegisterNo, 5000);
                    blnErrFlag = true;
                }
                if (txtVehicleName.Text.Trim() == "")
                {
                    epVehicle.SetError(txtVehicleName, "Please enter vehicle name.");
                    txtVehicleName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVehicle.ShowAlways = true;
                    tpVehicle.Show("Please enter vehicle name.", txtVehicleName, 5000);
                    blnErrFlag = true;
                }
                if (txtShortName.Text.Trim() == "")
                {
                    epVehicle.SetError(txtShortName, "Please enter vehicle shortname name.");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVehicle.ShowAlways = true;
                    tpVehicle.Show("Please enter vehicle shortname name.", txtShortName, 5000);
                    blnErrFlag = true;
                }
                if (txtCapacity.Text.Trim() == "")
                {
                    epVehicle.SetError(txtCapacity, "Please enter capacity.");
                    txtCapacity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVehicle.ShowAlways = true;
                    tpVehicle.Show("Please enter capacity.", txtCapacity, 5000);
                    blnErrFlag = true;
                }
                if (blnErrFlag == false)
                {
                    txtRegisterNo.BackColor = Color.White;
                    txtVehicleName.BackColor = Color.White;
                    txtShortName.BackColor = Color.White;
                    txtCapacity.BackColor = Color.White;
                    epVehicle.Clear();
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
                tpVehicle.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Vehicle_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Vehiclelist.picLoader.Visible = false;
                MainForm.objCP_Vehiclelist.picLoader.SendToBack();
                if (pbVehicleId == 0)
                {
                    this.ActiveControl = txtRegisterNo;
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                }
                else
                {
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1)
                    {
                        this.ActiveControl = txtRegisterNo;
                        rbActive.Checked = true;
                    }
                    else if(PbStatus == 2)
                    {
                        txtRegisterNo.Enabled = false;
                        txtVehicleName.Enabled = false;
                        txtShortName.Enabled = false;
                        txtCapacity.Enabled = false;
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
                if (pbVehicleId != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();
                    objDs = objspservice.udfnVehiclelist(1, pbVehicleId, 0);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            txtRegisterNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Vehicle Number"]);
                            txtVehicleName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Vehicle Name"]);
                            txtShortName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["V Short Name"]);
                            txtCapacity.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Capacity"]);
                            txtRegisterNo.Focus();
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
        private void txtVehicleName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtVehicleName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtVehicleName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtVehicleName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVehicleName.BackColor = Color.White;
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

        private void txtShortName_Enter(object sender, EventArgs e)
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

        private void txtShortName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCapacity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtShortName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtShortName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRegisterNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRegisterNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRegisterNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtVehicleName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRegisterNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRegisterNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCapacity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCapacity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCapacity_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCapacity_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCapacity.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRegisterNo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                //{
                //    e.Handled = true;
                //}

                //// Allow only one decimal point
                //if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                //{
                //    e.Handled = true;
                //}
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

        private void CP_Vehicle_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CP_Vehicle_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Vehicle_Leave(object sender, EventArgs e)
        {
            try
            {
                tpVehicle.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
