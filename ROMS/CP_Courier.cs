using DocumentFormat.OpenXml.Bibliography;
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
    public partial class CP_Courier : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError = new DataError();
        private ToolTip tpCourierEName = new ToolTip();
        private ToolTip tpCourierTName = new ToolTip();
        private ToolTip tpShortName = new ToolTip();
        private ToolTip tpAddress = new ToolTip();
        private ToolTip tpCity = new ToolTip();
        private ToolTip tpState = new ToolTip();
        private ToolTip tpDistrict = new ToolTip();
        private ToolTip tpPincode = new ToolTip();
        private ToolTip tpArea = new ToolTip();
        public int pbCourierId = 0, PbStatus = 0, varUpDownKeyCity = 0, varUpDownKeyArea = 0, varUpdate = 0;
        public CP_Courier()
        {
            InitializeComponent();
            txtCourierNameEnglish.Enter += Common_Enter;
            txtCourierNameEnglish.Leave += Common_Leave;
            txtCourierNameTamil.Enter += Common_Enter;
            txtCourierNameTamil.Leave += Common_Leave;
            txtShortName.Enter += Common_Enter;
            txtShortName.Leave += Common_Leave;
            txtAddress1.Enter += Common_Enter;
            txtAddress1.Leave += Common_Leave;
            txtAddress2.Enter += Common_Enter;
            txtAddress2.Leave += Common_Leave;
            cmbDistrict.Enter += Common_Enter;
            cmbDistrict.Leave += Common_Leave;
            txtCity.Enter += Common_Enter;
            txtCity.Leave += Common_Leave;
            txtArea.Enter += Common_Enter;
            txtArea.Leave += Common_Leave;
            cmbState.Enter += Common_Enter;
            cmbState.Leave += Common_Leave;
            txtPincode.Enter += Common_Enter;
            txtPincode.Leave += Common_Leave;
            rbActive.Enter += Common_Enter;
            rbActive.Leave += Common_Leave;
            rbInActive.Enter += Common_Enter;
            rbInActive.Leave += Common_Leave;
            txtLandmark.Enter += Common_Enter;
            txtLandmark.Leave += Common_Leave;
        }

        private void CP_Courier_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_State", " ST_STSID=1 AND STID !=0 Order by STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                objDataBind.BindComboBoxListSelected("DEF_District", " DIST_STSID=1 AND DISTID NOT IN (0) Order by DISTID", "DIST_Name,DISTID", cmbDistrict, "", "DIST_Name", "DISTID");
                objDataBind = null;
                txtCourierNameEnglish.Focus();
                MainForm.objCP_Courierlist.picLoader.Visible = false;
                MainForm.objCP_Courierlist.picLoader.SendToBack();
                if (pbCourierId == 0)
                {
                    btnSave.Text = "Save";
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                }
                else
                {
                    btnSave.Text = "Update";
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1)
                    {
                        this.ActiveControl = txtCourierNameEnglish;
                        rbActive.Checked = true;
                    }
                    else if (PbStatus == 2)
                    {
                        txtCourierNameEnglish.Enabled = false;
                        txtCourierNameTamil.Enabled = false;
                        txtShortName.Enabled = false;
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
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                MR_Sales obj = new MR_Sales();

                obj.paraViewType = 1;
                obj.paraCourierId = pbCourierId;

                objDs = objspdservice.udfnCourierList(obj);
                objspdservice.CloseConnection();

                if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
                {
                    txtCourierNameEnglish.Text = objDs.Tables[0].Rows[0]["COURIER_ENAME"].ToString();
                    txtCourierNameTamil.Text = objDs.Tables[0].Rows[0]["COURIER_TNAME"].ToString();
                    txtShortName.Text = objDs.Tables[0].Rows[0]["SHORT_NAME"].ToString();

                    txtAddress1.Text = objDs.Tables[0].Rows[0]["CT_ADDRESS1"].ToString();
                    txtAddress2.Text = objDs.Tables[0].Rows[0]["CT_ADDRESS2"].ToString();

                    cmbState.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["CT_STATEID"]);
                    cmbDistrict.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["CT_DISTRICTID"]);

                    txtCity.Text = objDs.Tables[0].Rows[0]["CT_CITY"].ToString();
                    txtArea.Text = objDs.Tables[0].Rows[0]["CT_AREA"].ToString();

                    lblCityId.Text = objDs.Tables[0].Rows[0]["CT_CITYID"].ToString();
                    lblAreaId.Text = objDs.Tables[0].Rows[0]["CT_AREAID"].ToString();

                    txtPincode.Text = objDs.Tables[0].Rows[0]["CT_PINCODE"].ToString();
                    txtLandmark.Text = objDs.Tables[0].Rows[0]["CT_LANDMARK"].ToString();

                    PbStatus = Convert.ToInt32(objDs.Tables[0].Rows[0]["STATUS"]);

                    if (PbStatus == 1)
                    {
                        rbActive.Checked = true;
                        rbInActive.Checked = false;
                    }
                    else
                    {
                        rbActive.Checked = false;
                        rbInActive.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Common_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                ((Control)sender).BackColor = Color.LemonChiffon;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                epCourier.Clear();
                bool blnErrFlag = false;
                if (txtCourierNameEnglish.Text.Trim() == "")
                {
                    epCourier.SetError(txtCourierNameEnglish, "Please enter Courier name english.");
                    txtCourierNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCourierEName.ShowAlways = true;
                    tpCourierEName.Show("Please enter Courier name english.", txtCourierNameEnglish, 5000);
                    blnErrFlag = true;
                }
                if (txtCourierNameTamil.Text.Trim() == "")
                {
                    epCourier.SetError(txtCourierNameTamil, "Please enter Courier name tamil.");
                    txtCourierNameTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCourierTName.ShowAlways = true;
                    tpCourierTName.Show("Please enter Courier name tamil.", txtCourierNameTamil, 5000);
                    blnErrFlag = true;
                }
                if (txtShortName.Text.Trim() == "")
                {
                    epCourier.SetError(txtShortName, "Please enter Short name.");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpShortName.ShowAlways = true;
                    tpShortName.Show("Please enter Short name.", txtShortName, 5000);
                    blnErrFlag = true;
                }
                if (txtAddress1.Text.Trim() == "" && txtAddress2.Text.Trim() == "")
                {
                    epCourier.SetError(txtAddress1, "Please enter Address.");
                    txtAddress1.BackColor = ColorTranslator.FromHtml("#fabdbd");

                    tpAddress.ShowAlways = true;
                    tpAddress.Show("Please enter Address.", txtAddress1, 5000);

                    blnErrFlag = true;
                }
                else if (txtAddress1.Text.Trim() == "")
                {
                    epCourier.SetError(txtAddress1, "Please enter Address 1.");
                    txtAddress1.BackColor = ColorTranslator.FromHtml("#fabdbd");

                    tpAddress.ShowAlways = true;
                    tpAddress.Show("Please enter Address 1.", txtAddress1, 5000);

                    blnErrFlag = true;
                }
                else if (txtAddress2.Text.Trim() == "")
                {
                    epCourier.SetError(txtAddress2, "Please enter Address 2.");
                    txtAddress2.BackColor = ColorTranslator.FromHtml("#fabdbd");

                    tpAddress.ShowAlways = true;
                    tpAddress.Show("Please enter Address 2.", txtAddress2, 5000);

                    blnErrFlag = true;
                }
                if (Convert.ToInt32(cmbState.SelectedValue) == -1)
                {
                    epCourier.SetError(cmbState, "Please select State.");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please select State.", cmbState, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToInt32(cmbDistrict.SelectedValue) == -1)
                {
                    epCourier.SetError(cmbDistrict, "Please select District.");
                    cmbDistrict.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDistrict.ShowAlways = true;
                    tpDistrict.Show("Please select District.", cmbDistrict, 5000);
                    blnErrFlag = true;
                }
                if (txtCity.Text.Trim() == "")
                {
                    epCourier.SetError(txtCity, "Please enter City.");
                    txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCity.ShowAlways = true;
                    tpCity.Show("Please enter City.", txtCity, 5000);
                    blnErrFlag = true;
                }
                else
                {
                    if (lblCityId.Text.Trim() == "" || lblCityId.Text.Trim() == "0")
                    {
                        epCourier.SetError(txtCity, "Please select valid City");
                        txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCity.ShowAlways = true;
                        tpCity.Show("Please select valid City.", txtCity, 5000);
                        blnErrFlag = true;
                    }
                }
                if (txtPincode.Text.Trim() == "")
                {
                    epCourier.SetError(txtPincode, "Please enter Pincode.");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPincode.ShowAlways = true;
                    tpPincode.Show("Please enter Pincode.", txtPincode, 5000);
                    blnErrFlag = true;
                }
                else
                {
                    if (txtPincode.Text.Trim().Length < 6)
                    {
                        epCourier.SetError(txtPincode, "Please enter valid Pincode.");
                        txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPincode.ShowAlways = true;
                        tpPincode.Show("Please enter valid Pincode.", txtPincode, 5000);
                        blnErrFlag = true;
                    }
                }
                if (txtArea.Text.Trim() == "")
                {
                    epCourier.SetError(txtArea, "Please enter Area.");
                    txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpArea.ShowAlways = true;
                    tpArea.Show("Please enter Area.", txtArea, 5000);
                    blnErrFlag = true;
                }
                else
                {
                    if (lblAreaId.Text.Trim() == "" || lblAreaId.Text.Trim() == "0")
                    {
                        epCourier.SetError(txtArea, "Please select valid Area");
                        txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpArea.ShowAlways = true;
                        tpArea.Show("Please select valid Area.", txtArea, 5000);
                        blnErrFlag = true;
                    }
                }
                if (blnErrFlag == false)
                {
                    txtCourierNameEnglish.BackColor = Color.White;
                    txtCourierNameTamil.BackColor = Color.White;
                    txtShortName.BackColor = Color.White;
                    txtAddress1.BackColor = Color.White;
                    txtAddress2.BackColor = Color.White;
                    cmbState.BackColor = Color.White;
                    cmbDistrict.BackColor = Color.White;
                    txtCity.BackColor = Color.White;
                    txtPincode.BackColor = Color.White;
                    txtArea.BackColor = Color.White;
                    txtLandmark.BackColor = Color.White;
                    udfnSave();
                }
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
                if (skipControl != txtCity)
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
        public void udfnSave()
        {
            try
            {
                MR_Sales objMR_Sales = new MR_Sales();
                objMR_Sales.paraCourierId = pbCourierId;
                objMR_Sales.paraCourierEName = txtCourierNameEnglish.Text.Trim();
                objMR_Sales.paraCourierTName = txtCourierNameTamil.Text.Trim();
                objMR_Sales.paraCourierShortName = txtShortName.Text.Trim();
                objMR_Sales.paraCTAddress1 = txtAddress1.Text.Trim();
                objMR_Sales.paraCTAddress2 = txtAddress2.Text.Trim();
                objMR_Sales.paraCTStateId = Convert.ToInt32(cmbState.SelectedValue);
                objMR_Sales.paraCTDistrictId = Convert.ToInt32(cmbDistrict.SelectedValue);
                objMR_Sales.paraCTCityId = Convert.ToInt32(lblCityId.Text);
                objMR_Sales.paraCTPincode = txtPincode.Text.Trim();
                objMR_Sales.paraCTAreaId = Convert.ToInt32(lblAreaId.Text);
                objMR_Sales.paraCTLandmark = txtLandmark.Text.Trim();
                if (rbActive.Checked == true)
                {
                    objMR_Sales.paraStatusId = 1;
                }
                else
                {
                    objMR_Sales.paraStatusId = 2;
                }
                SPDataService objspdservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Courier Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Courier Updation";
                    varType = 1;
                }
                objMR_Sales.paraViewType = varType;
                varResult = objspdservice.udfnCourier(objMR_Sales);
                objspdservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Courierlist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        udfnClear();
                        this.ActiveControl = txtCourierNameEnglish;
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
        public void udfnClear()
        {
            try
            {
                pbCourierId = 0;
                txtCourierNameEnglish.Text = "";
                txtCourierNameTamil.Text = "";
                txtShortName.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                cmbState.SelectedValue = -1;
                cmbDistrict.SelectedValue = -1;
                txtCity.Text = "";
                lblCityId.Text = "0";
                txtPincode.Text = "";
                txtArea.Text = "";
                lblAreaId.Text = "0";
                txtLandmark.Text = "";
                rbActive.Checked = true;
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

        private void btnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
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

        private void txtCourierNameEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCourierNameTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCourierNameTamil_KeyDown(object sender, KeyEventArgs e)
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

        private void txtShortName_KeyDown(object sender, KeyEventArgs e)
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
        private void cmbDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCity.Focus();
                }
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
                e.Handled = true;
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

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
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
                                txtCity.Text = DGV_FilterCity.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }
                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterCity.Rows.Count) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterCity.Rows.Count))
                            {
                                txtCity.Text = DGV_FilterCity.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
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
                    txtCity.Focus();
                    //txtCity.SelectionStart = txtCity.Text.Length;
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

                            txtCity.Text = DGV_FilterCity.SelectedRows[0].Cells["CTY_NAME"].Value.ToString();

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterCity.Rows.Count) DGV_FilterCity.CurrentCell = DGV_FilterCity.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterCity.Rows.Count))
                            {
                                txtCity.Text = DGV_FilterCity.Rows[RowIndex].Cells["CTY_NAME"].Value.ToString();
                            }

                            txtCity.Focus();
                            txtCity.SelectionStart = txtCity.Text.Length;
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
                if (txtCity.Text.Trim() != "")
                {
                    txtCity.Text = DGV_FilterCity.SelectedRows[0].Cells["CTY_NAME"].Value.ToString();
                    lblCityId.Text = DGV_FilterCity.SelectedRows[0].Cells["CTYID"].Value.ToString();
                }
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

        private void CP_Courier_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Courier_FormClosing(object sender, FormClosingEventArgs e)
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
        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyCity == 0)
                {
                    //lvCity.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtCity.Text.Length != 0)
                    {
                        objDs = objspdservice.udfnCitylist(4, txtCity.Text, 0, 0);
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
            finally
            {

            }
        }

        private void Common_Leave(object sender, EventArgs e)
        {
            try
            {
                ((Control)sender).BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
