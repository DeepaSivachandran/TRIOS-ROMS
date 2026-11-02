using CrystalDecisions.CrystalReports.Engine;
using DocumentFormat.OpenXml.Bibliography;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
        public int pbTransportId = 0, PbStatus = 0, varUpdate = 0, varUpDownKeyCity = 0, varUpDownKeyArea = 0;
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
                obj.paraLandlineNo = txtLandline.Text.Trim();
                obj.paraCTAddress1 = txtAddress1.Text.Trim();
                obj.paraCTAddress2 = txtAddress2.Text.Trim();
                obj.paraCTStateId = Convert.ToInt32(cmbState.SelectedValue);
                obj.paraCTDistrictId = Convert.ToInt32(cmbDistrict.SelectedValue);
                obj.paraCTCityId = Convert.ToInt32(lblCityId.Text);
                obj.paraCTPincode = txtPincode.Text.Trim();
                obj.paraCTAreaId = Convert.ToInt32(lblAreaId.Text);
                obj.paraCTLandmark = txtLandmark.Text.Trim();
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
                        txtLandline.Text = "";
                        txtAddress1.Text = "";
                        txtAddress2.Text = "";
                        cmbState.SelectedValue = -1;
                        cmbDistrict.SelectedValue = -1;
                        txtCityName.Text = "";
                        lblCityId.Text = "0";
                        txtPincode.Text = "";
                        txtArea.Text = "";
                        lblAreaId.Text = "0";
                        txtLandmark.Text = "";
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
        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtArea)
                {
                    varUpDownKeyArea = 0;
                    DGV_FilterArea.DataSource = null;
                    DGV_FilterArea.Visible = false;
                }
                if (skipControl != txtCityName)
                {
                    varUpDownKeyCity = 0;
                    DGV_FilterCity.DataSource = null;
                    DGV_FilterCity.Visible = false;
                }
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
                if (txtMobileNo.Text.Trim() == "" || txtMobileNo.TextLength < 10)
                {
                    epTransport.SetError(txtMobileNo, "Please enter valid mobile no.");
                    txtMobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter valid mobile no.", txtMobileNo, 5000);
                    blnErrFlag = true;
                }
                if (txtLandline.Text.Trim() == "" || txtLandline.TextLength < 10)
                {
                    epTransport.SetError(txtLandline, "Please enter valid Landline no.");
                    txtLandline.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter valid Landline no.", txtLandline, 5000);
                    blnErrFlag = true;
                }
                if (txtAddress1.Text.Trim() == "" && txtAddress2.Text.Trim() == "")
                {
                    epTransport.SetError(txtAddress1, "Please enter Address 1 or Address 2.");
                    txtAddress1.BackColor = ColorTranslator.FromHtml("#fabdbd");

                    epTransport.SetError(txtAddress2, "Please enter Address 1 or Address 2.");
                    txtAddress2.BackColor = ColorTranslator.FromHtml("#fabdbd");

                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter at least one Address.", txtAddress1, 5000);

                    blnErrFlag = true;
                }
                if (Convert.ToInt32(cmbState.SelectedValue) == -1)
                {
                    epTransport.SetError(cmbState, "Please select State.");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please select State.", cmbState, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToInt32(cmbDistrict.SelectedValue) == -1)
                {
                    epTransport.SetError(cmbDistrict, "Please select District.");
                    cmbDistrict.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please select District.", cmbDistrict, 5000);
                    blnErrFlag = true;
                }
                if (txtCityName.Text.Trim() == "")
                {
                    epTransport.SetError(txtCityName, "Please enter City.");
                    txtCityName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter City.", txtCityName, 5000);
                    blnErrFlag = true;
                }
                else
                {
                    if (lblCityId.Text.Trim() == "" || lblCityId.Text.Trim() == "0")
                    {
                        epTransport.SetError(txtCityName, "Please select valid City");
                        txtCityName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpTransport.ShowAlways = true;
                        tpTransport.Show("Please select valid City.", txtCityName, 5000);
                        blnErrFlag = true;
                    }
                }
                if (txtPincode.Text.Trim() == "")
                {
                    epTransport.SetError(txtPincode, "Please enter Pincode.");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter Pincode.", txtPincode, 5000);
                    blnErrFlag = true;
                }
                else
                {
                    if (txtPincode.Text.Trim().Length < 6)
                    {
                        epTransport.SetError(txtPincode, "Please enter valid Pincode.");
                        txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpTransport.ShowAlways = true;
                        tpTransport.Show("Please enter valid Pincode.", txtPincode, 5000);
                        blnErrFlag = true;
                    }
                }
                if (txtArea.Text.Trim() == "")
                {
                    epTransport.SetError(txtArea, "Please enter Area.");
                    txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransport.ShowAlways = true;
                    tpTransport.Show("Please enter Area.", txtArea, 5000);
                    blnErrFlag = true;
                }
                else
                {
                    if (lblAreaId.Text.Trim() == "" || lblAreaId.Text.Trim() == "0")
                    {
                        epTransport.SetError(txtArea, "Please select valid Area");
                        txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpTransport.ShowAlways = true;
                        tpTransport.Show("Please select valid Area.", txtArea, 5000);
                        blnErrFlag = true;
                    }
                }

                if (blnErrFlag == false)
                {
                    txtTransportEName.BackColor = Color.White;
                    txtTransportTName.BackColor = Color.White;
                    txtShortName.BackColor = Color.White;
                    txtContactPersonName.BackColor = Color.White;
                    txtMobileNo.BackColor = Color.White;
                    txtLandline.BackColor = Color.White;
                    txtAddress1.BackColor = Color.White;
                    txtAddress2.BackColor = Color.White;
                    cmbState.BackColor = Color.White;
                    cmbDistrict.BackColor = Color.White;
                    txtCityName.BackColor = Color.White;
                    txtPincode.BackColor = Color.White;
                    txtArea.BackColor = Color.White;
                    txtLandmark.BackColor = Color.White;
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
                udfnGridNull((Control)sender);
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_State", " ST_STSID=1 AND STID !=0 Order by STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                objDataBind.BindComboBoxListSelected("DEF_District", " DIST_STSID=1 AND DISTID NOT IN (0) Order by DISTID", "DIST_Name,DISTID", cmbDistrict, "", "DIST_Name", "DISTID");
                objDataBind = null;
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
                        txtLandline.Enabled = false;
                        grbAddress.Enabled = false;    
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
                        if (objDs.Tables.Count != 0 && objDs.Tables[0].Rows.Count > 0)
                        {
                            txtTransportEName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_EName"]);
                            txtTransportTName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_TNAME"]);
                            txtShortName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_ShortName"]);
                            txtContactPersonName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_ContactPerson"]);
                            txtMobileNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_MobileNo"]);
                            txtLandline.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_LandlineNo"]);

                            txtAddress1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_Address1"]);
                            txtAddress2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_Address2"]);

                            cmbState.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["TR_STID"]);
                            cmbDistrict.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["TR_DISTID"]);

                            txtCityName.Text = objDs.Tables[0].Rows[0]["CT_CITY"].ToString();
                            txtArea.Text = objDs.Tables[0].Rows[0]["CT_AREA"].ToString();

                            lblCityId.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_CTYID"]);
                            lblAreaId.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_AID"]);

                            txtPincode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TRPincode"]);
                            txtLandmark.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TR_Landmark"]);

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
                udfnGridNull((Control)sender);
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
                udfnGridNull((Control)sender);
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
                udfnGridNull((Control)sender);
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
                udfnGridNull((Control)sender);
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
                udfnGridNull((Control)sender);
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
                udfnGridNull((Control)sender);
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
                udfnGridNull((Control)sender);
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
                    txtLandline.Focus();
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


        //landline
        private void txtLandline_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtLandline.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLandline_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddress1.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLandline_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLandline.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLandline_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAddress1_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtAddress1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddress2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddress1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAddress1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddress2_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtAddress2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbState.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddress2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAddress2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbState_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbState.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbState_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbDistrict.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbState_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled=true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbState_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbState.BackColor = Color.White;
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
                udfnGridNull((Control)sender);
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
                cmbDistrict.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCityName_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtCityName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCityName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyCity = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterCity.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterCity.Visible == false)
                {
                    txtPincode.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterCity.Focus();
                }
                if (DGV_FilterCity.CurrentCell == null && DGV_FilterCity.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterCity.Focus();
                    int RowIndex = DGV_FilterCity.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterCity.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyCity = 1;
                    }
                    else
                    {
                        varUpDownKeyCity = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtCityName.Text = DGV_FilterCity.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }
                            txtCityName.Focus();
                            txtCityName.SelectionStart = txtCityName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterCity.Rows.Count) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterCity.Rows.Count))
                            {
                                txtCityName.Text = DGV_FilterCity.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }

                            txtCityName.Focus();
                            txtCityName.SelectionStart = txtCityName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterCity.Rows.Count > 0)
                                {
                                    varUpDownKeyCity = 1;
                                    udfnCityEvent();
                                    DGV_FilterCity.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtCityName.Focus();
                    //txtCityName.SelectionStart = txtCityName.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtPincode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCityName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCityName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCityName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyCity == 0)
                {
                    //lvCity.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtCityName.Text.Length != 0)
                    {
                        objDs = objspdservice.udfnCitylist(4, txtCityName.Text, 0, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterCity.Visible = true;
                                    DGV_FilterCity.DataSource = objDs.Tables[0];
                                    DGV_FilterCity.Columns["CTYID"].Visible = false;
                                    DGV_FilterCity.Columns["STID"].Visible = false;
                                    DGV_FilterCity.Columns["ST_Name"].Visible = false;
                                    DGV_FilterCity.Columns["ST_TIN"].Visible = false;
                                    DGV_FilterCity.Columns["CTY_NAME"].HeaderText = "City";
                                    DGV_FilterCity.Columns["CTY_NAME"].Width = 180;
                                    DGV_FilterCity.Columns["CTY_NAME"].DisplayIndex = 0;
                                    DGV_FilterCity.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterCity.Visible = false;
                                    DGV_FilterCity.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterCity.Visible = false;
                                DGV_FilterCity.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterCity.Visible = false;
                            DGV_FilterCity.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterCity.Visible = false;
                        DGV_FilterCity.DataSource = null;
                    }
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
                udfnGridNull((Control)sender);
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
                    txtArea.Focus();
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

        private void txtArea_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtArea.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyArea = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterArea.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterArea.Visible == false)
                {
                    txtLandmark.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterArea.Focus();
                }
                if (DGV_FilterArea.CurrentCell == null && DGV_FilterArea.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterArea.Focus();
                    int RowIndex = DGV_FilterArea.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterArea.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyArea = 1;
                    }
                    else
                    {
                        varUpDownKeyArea = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtArea.Text = DGV_FilterArea.Rows[RowIndex].Cells["AreaName"].Value.ToString();
                            }
                            txtArea.Focus();
                            txtArea.SelectionStart = txtArea.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterArea.Rows.Count) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterArea.Rows.Count))
                            {
                                txtArea.Text = DGV_FilterArea.Rows[RowIndex].Cells["AreaName"].Value.ToString();
                            }

                            txtArea.Focus();
                            txtArea.SelectionStart = txtArea.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterArea.Rows.Count > 0)
                                {
                                    varUpDownKeyArea = 1;
                                    udfnAreaData();
                                    DGV_FilterArea.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtArea.Focus();
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtLandmark.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_Leave(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyArea == 0)
                {
                    if (txtArea.Text.Length > 0)
                    {
                        MR_Area objMR_Area = new MR_Area();
                        objMR_Area.ViewType = 2;
                        objMR_Area.paraAreaEName = txtArea.Text;
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnArealist(objMR_Area);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterArea.Visible = true;
                                    DGV_FilterArea.DataSource = objDs.Tables[0];
                                    DGV_FilterArea.Columns["AID"].Visible = false;
                                    DGV_FilterArea.Columns["AreaName"].Width = 250;
                                    DGV_FilterArea.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterArea.Visible = false;
                                    DGV_FilterArea.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterArea.Visible = false;
                                DGV_FilterArea.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterArea.Visible = false;
                            DGV_FilterArea.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterArea.Visible = false;
                        DGV_FilterArea.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLandmark_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtLandmark.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLandmark_KeyDown(object sender, KeyEventArgs e)
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

        private void txtLandmark_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLandmark.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterCity_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyCity = 1;
                udfnCityEvent();
                txtPincode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyArea = 1;
                udfnAreaData();
                txtLandmark.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterArea.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterArea.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyArea = 1;
                    }
                    else
                    {
                        varUpDownKeyArea = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];

                            txtArea.Text = DGV_FilterArea.SelectedRows[0].Cells["AreaName"].Value.ToString();

                            txtArea.Focus();
                            txtArea.SelectionStart = txtArea.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterArea.Rows.Count) DGV_FilterArea.CurrentCell = DGV_FilterArea.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterArea.Rows.Count))
                            {
                                txtArea.Text = DGV_FilterArea.Rows[RowIndex].Cells["AreaName"].Value.ToString();
                            }

                            txtArea.Focus();
                            txtArea.SelectionStart = txtArea.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterArea.Rows.Count > 0)
                                {
                                    varUpDownKeyArea = 1;
                                    udfnAreaData();
                                    DGV_FilterArea.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtLandmark.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAreaData()
        {
            try
            {
                if (txtArea.Text.Trim() != "")
                {
                    lblAreaId.Text = DGV_FilterArea.SelectedRows[0].Cells["AID"].Value.ToString();
                    txtArea.Text = DGV_FilterArea.SelectedRows[0].Cells["AreaName"].Value.ToString();
                }
                txtLandmark.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_FilterCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterCity.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterCity.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyCity = 1;
                    }
                    else
                    {
                        varUpDownKeyCity = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];

                            txtCityName.Text = DGV_FilterCity.SelectedRows[0].Cells["CTY_NAME"].Value.ToString();

                            txtCityName.Focus();
                            txtCityName.SelectionStart = txtCityName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterCity.Rows.Count) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterCity.Rows.Count))
                            {
                                txtCityName.Text = DGV_FilterCity.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }

                            txtCityName.Focus();
                            txtCityName.SelectionStart = txtCityName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterCity.Rows.Count > 0)
                                {
                                    varUpDownKeyCity = 1;
                                    udfnCityEvent();
                                    DGV_FilterCity.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtPincode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCityEvent()
        {
            try
            {
                if (txtCityName.Text.Trim() != "")
                {
                    txtCityName.Text = DGV_FilterCity.SelectedRows[0].Cells["CTY_NAME"].Value.ToString();
                    lblCityId.Text = DGV_FilterCity.SelectedRows[0].Cells["CTYID"].Value.ToString();
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
