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
    //Created By:Sathish ; Created On:-28/11/2025
    public partial class CP_Transport : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpTransport = new ToolTip();
        public int pbTransportId = 0, PbStatus = 0, varUpdate = 0;
        public CP_Transport()
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
                    varoriginator = "Transport Type Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Transport Type Updation";
                    varType = 1;
                }
                MR_Sales obj = new MR_Sales();
                obj.paraViewType = varType;
                obj.paraTransportId = pbTransportId;
                obj.paraTransportEName = txtTransportEName.Text.Trim();
                obj.paraTransportTName = txtTransportTName.Text.Trim();
                obj.paraShortName = txtShortName.Text.Trim();
                obj.paraContactPersonName = txtContactPersonName.Text.Trim();
                obj.paraMobileNo = txtMobileNo.Text.Trim();
                obj.paraStatusId = PbStatus;
                obj.paraOriginator = varoriginator;

                varResult = objspservice.udfnTransport(obj);
                objspservice.CloseConnection();

                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Transportlist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        txtTransportEName.Text = "";
                        txtTransportTName.Text = "";
                        txtShortName.Text = "";
                        txtContactPersonName.Text = "";
                        txtMobileNo.Text = "";
                        this.ActiveControl = txtTransportEName;
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
                epTransport.Clear();
                bool blnErrFlag = false;
                if (txtTransportEName.Text.Trim() == "")
                {
                    epTransport.SetError(txtTransportEName, "Please enter Transport type english name.");
                    txtTransportEName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter Transport type english name.", txtTransportEName, 5000);
                    blnErrFlag = true;
                }
                if (txtTransportTName.Text.Trim() == "")
                {
                    epTransport.SetError(txtTransportTName, "Please enter Transport type tamil name.");
                    txtTransportTName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter Transport type tamil name.", txtTransportTName, 5000);
                    blnErrFlag = true;
                }
                if (txtShortName.Text.Trim() == "")
                {
                    epTransport.SetError(txtShortName, "Please enter short name.");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter short name.", txtShortName, 5000);
                    blnErrFlag = true;
                }
                if (txtContactPersonName.Text.Trim() == "")
                {
                    epTransport.SetError(txtContactPersonName, "Please enter contact person name.");
                    txtContactPersonName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter contact person name.", txtContactPersonName, 5000);
                    blnErrFlag = true;
                }
                if (txtMobileNo.Text.Trim() == "")
                {
                    epTransport.SetError(txtMobileNo, "Please enter mobile no.");
                    txtMobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter mobile no.", txtMobileNo, 5000);
                    blnErrFlag = true;
                }
                else if (!long.TryParse(txtMobileNo.Text.Trim(), out _) || txtMobileNo.Text.Trim().Length < 10)
                {
                    epTransport.SetError(txtMobileNo, "Please enter valid mobile no.");
                    txtMobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter valid mobile no.", txtMobileNo, 5000);
                    blnErrFlag = true;
                }
                if (blnErrFlag == false)
                {
                    txtTransportEName.BackColor = Color.White;
                    txtTransportTName.BackColor = Color.White;
                    txtShortName.BackColor = Color.White;
                    txtContactPersonName.BackColor = Color.White;
                    txtMobileNo.BackColor = Color.White;
                    epTransport.Clear();
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
                tpTransport.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Transport_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Transportlist.picLoader.Visible = false;
                MainForm.objCP_Transportlist.picLoader.SendToBack();
                if (pbTransportId == 0)
                {
                    this.ActiveControl = txtTransportEName;
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                }
                else
                {
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1)
                    {
                        this.ActiveControl = txtTransportEName;
                        rbActive.Checked = true;
                    }
                    else if(PbStatus == 2)
                    {
                        txtTransportEName.Enabled = false;
                        txtTransportTName.Enabled = false;
                        txtShortName.Enabled = false;
                        txtContactPersonName.Enabled = false;
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
                if (pbTransportId != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();

                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 1;
                    obj.paraTransportId = pbTransportId;
                    obj.paraStatusId = 0;
                    objDs = objspservice.udfnTransportList(obj);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            txtTransportEName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_EName"]);
                            txtTransportTName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_TNAME"]);
                            txtShortName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_ShortName"]);
                            txtContactPersonName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_ContactPerson"]);
                            txtMobileNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_MobileNo"]);
                            txtTransportEName.Focus();
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
        private void txtTransportEName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTransportEName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTransportEName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTransportTName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTransportEName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTransportEName.BackColor = Color.White;
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

        private void txtTransportTName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTransportTName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTransportTName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTransportTName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTransportTName.BackColor = Color.White;
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

        private void CP_Transport_FormClosing(object sender, FormClosingEventArgs e)
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
                    txtContactPersonName.Focus();
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

        private void txtContactPersonName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtContactPersonName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtContactPersonName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtContactPersonName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtContactPersonName.BackColor = Color.White;
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
        private void CP_Transport_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Transport_Leave(object sender, EventArgs e)
        {
            try
            {
                tpTransport.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
