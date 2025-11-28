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
    public partial class CP_Mobile : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpMobile = new ToolTip();
        public int pbMobileId = 0, PbStatus = 0, varUpdate = 0;
        public CP_Mobile()
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
                    varoriginator = "Mobile Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Mobile Updation";
                    varType = 1;
                }
                MR_Sales obj = new MR_Sales();
                obj.paraViewType = varType;
                obj.paraMobileId = pbMobileId;
                obj.paraMobileName = txtMobileName.Text.Trim();
                obj.paraVendor = Convert.ToInt32(cmbVendor.SelectedValue);
                obj.paraMobileNo = txtMobileNo.Text.Trim();
                obj.paraStatusId = PbStatus;
                obj.paraOriginator = varoriginator;

                varResult = objspservice.udfnMobile(obj);
                objspservice.CloseConnection();

                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Mobilelist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        txtMobileName.Text = "";
                        cmbVendor.SelectedValue = -1;
                        txtMobileNo.Text = "";
                        this.ActiveControl = txtMobileName;
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
                if (txtMobileName.Text.Trim() == "")
                {
                    epMobile.SetError(txtMobileName, "Please enter mobile name.");
                    txtMobileName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobile.ShowAlways = true;
                    tpMobile.Show("Please enter mobile name.", txtMobileName, 5000);
                }
                //else if (txtVendor.Text.Trim() == "")
                //{
                //    epMobile.SetError(txtVendor, "Please enter delivery person name.");
                //    txtVendor.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpMobile.ShowAlways = true;
                //    tpMobile.Show("Please enter delivery person name.", txtVendor, 5000);
                //}
                else if (Convert.ToInt32(cmbVendor.SelectedValue) == -1)
                {
                    epMobile.SetError(cmbVendor, "Please select vendor.");
                    cmbVendor.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobile.ShowAlways = true;
                    tpMobile.Show("Please select vendor.", cmbVendor, 5000);
                }
                else if (txtMobileNo.Text.Trim() == "")
                {
                    epMobile.SetError(txtMobileNo, "Please enter mobile number.");
                    txtMobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobile.ShowAlways = true;
                    tpMobile.Show("Please enter mobile number.", txtMobileNo, 5000);
                }
                else
                {
                    txtMobileName.BackColor = Color.White;
                    cmbVendor.BackColor = Color.White;
                    txtMobileNo.BackColor = Color.White;
                    epMobile.Clear();
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
                tpMobile.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Mobile_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Mobilelist.picLoader.Visible = false;
                MainForm.objCP_Mobilelist.picLoader.SendToBack();

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (0,137) AND MSTID<>0 ORDER BY MSTID ASC", "MST_DisplayText,MSTID", cmbVendor, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                if (pbMobileId == 0)
                {
                    this.ActiveControl = txtMobileName;
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                }
                else
                {
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1)
                    {
                        this.ActiveControl = txtMobileName;
                        rbActive.Checked = true;
                    }
                    else if(PbStatus == 2)
                    {
                        txtMobileName.Enabled = false;
                        cmbVendor.Enabled = false;
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
                if (pbMobileId != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();

                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 1;
                    obj.paraMobileId = pbMobileId;
                    obj.paraStatusId = 0;
                    objDs = objspservice.udfnMobileList(obj);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            txtMobileName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Mobile Name"]);
                            cmbVendor.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["Vendor"]);
                            txtMobileNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Mobile No."]);
                            txtMobileName.Focus();
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
        private void txtMobileName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMobileName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMobileName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbVendor.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMobileName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMobileName.BackColor = Color.White;
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

        private void txtVendor_Enter(object sender, EventArgs e)
        {
            try
            {
                txtVendor.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtVendor_KeyDown(object sender, KeyEventArgs e)
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

        private void txtVendor_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVendor.BackColor = Color.White;
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

        private void CP_Mobile_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cmbVendor_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbVendor.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbVendor_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbVendor_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbVendor.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbVendor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CP_Mobile_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Mobile_Leave(object sender, EventArgs e)
        {
            try
            {
                tpMobile.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
