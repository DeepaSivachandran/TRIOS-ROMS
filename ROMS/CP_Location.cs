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
    //Created By:-Sathish ; Created On:-17-08-2023
    public partial class CP_Location : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpLocationType = new ToolTip();
        private ToolTip tpLocationTypeInEnglish = new ToolTip();
        private ToolTip tpLocationTypeInTamil = new ToolTip();
        private ToolTip tpStoctApplicable = new ToolTip();
        public int varlocationcode=0;
        public int varstatus;
        public int varGodownType;
        public string PbConcern="";
        public string PbLocationType = "";
        public string PbLocationEName = "";
        public string PbLocationTName = "";
        public string PbLocationSName = "";
        public string PbStockApplicable = "";
        public int PbConcernID = 0;
        public int PbLocationTypeID=0;
        public int PbStockApplicableID = 0;
        public string PbDefault;
        public int PbStatus = 0;
        public int PbGodownTypeStatus = 0;
        public int varUpdate = 0;
        public CP_Location()
        {
            InitializeComponent();
        }
        private void CP_Location_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpLocationType.Active = false;
                tpLocationTypeInEnglish.Active = false;
                tpLocationTypeInTamil.Active = false;
                tpStoctApplicable.Active = false;
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
                txtLocationNameInEnglish.Text = "";
                txtLocationNameInTamil.Text = "";
                txtShortName.Text = "";
                cmbLocationType.SelectedIndex = 0;
                cmbStockApplicable.SelectedIndex = 0;
                cmbLocationType.Focus();
                this.ActiveControl = cmbLocationType;
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
                btnClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Location_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                int varViewType = 4;
                if (btnSave.Text == "Save")
                {
                    varViewType = 3;
                }
                objDs = objdserv.udfnCompanyList(varViewType, PbConcernID, MainForm.pbUserID, MainForm.pbIpAddress);
                objdserv.CloseConnection();
                cmbConcern.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDs.Tables[0];
                        }
                    }
                }
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", " MST_TransactionID in (0,3) and MSTID !=0 Order by MSTID", "MST_DisplayText,MSTID", cmbLocationType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", " MST_TransactionID in (0,4) and MSTID !=0 Order by MSTID", "MST_DisplayText,MSTID", cmbStockApplicable, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    if (btnSave.Visible)
                    {
                        pnlStatus.Enabled = true;
                    }
                    udfnLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {

                MainForm.objCP_LocationList.picLoader.Visible = false;
                MainForm.objCP_LocationList.picLoader.SendToBack();
            }
        }
        private void udfnLoad()
        {
            try
            {
                txtLocationNameInEnglish.Text = PbLocationEName;
                txtLocationNameInTamil.Text = PbLocationTName;
                txtShortName.Text = PbLocationSName;
                cmbConcern.SelectedValue = PbConcernID;
                cmbLocationType.SelectedValue = PbLocationTypeID;
                cmbStockApplicable.SelectedValue = PbStockApplicableID;
                if (PbGodownTypeStatus == 86) { rbInside.Checked = true; } else { rbOutside.Checked = true; }
                if (PbStatus == 1) { rbActive.Checked = true; } else { rbInactive.Checked = true; }
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

        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                if (rbActive.Checked == true) { varstatus = 1; }
                else { varstatus = 2; }

                if (pnlGodownType.Enabled == false)
                {
                    rbInside.Checked = false;
                    rbOutside.Checked = false;
                    varGodownType = 0;
                }
                else
                {
                    if (rbInside.Checked == true)
                    {
                        varGodownType = 86;
                    }
                    else
                    {
                        varGodownType = 87;
                    }
                }
                 
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                    if (btnSave.Text == "Save")
                    {
                        varoriginator = "Stock Creation";
                        varType = 0;
                    }
                    else
                    {
                        varoriginator = "Stock Updation";
                        varType = 1;
                    }
                    varResult = objspservice.udfnStockLocation(varType, varlocationcode, Convert.ToInt16(cmbConcern.SelectedValue), Convert.ToInt16(cmbLocationType.SelectedValue), (txtLocationNameInEnglish.Text).Trim(), (txtLocationNameInTamil.Text).Trim(), (txtShortName.Text).Trim(), varGodownType, Convert.ToInt16(cmbStockApplicable.SelectedValue), varstatus, varoriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm.objCP_LocationList.udfnList();
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
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                bool blnErrorFlag = false;

                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbLocationType.SelectedItem) == "" || Convert.ToString(cmbLocationType.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbLocationType, "Please select location type");
                    cmbLocationType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationType.ShowAlways = true;
                    tpLocationType.Show("Please select location type", cmbLocationType, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtLocationNameInEnglish.Text).Trim() == "")
                {
                    epLocation.SetError(txtLocationNameInEnglish, "Please enter location name in english");
                    txtLocationNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInEnglish.ShowAlways = true;
                    tpLocationTypeInEnglish.Show("Please enter location name in english", txtLocationNameInEnglish, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtLocationNameInTamil.Text).Trim() == "")
                {
                    epLocation.SetError(txtLocationNameInTamil, "Please enter location name in tamil");
                    txtLocationNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInTamil.ShowAlways = true;
                    tpLocationTypeInTamil.Show("Please enter location name in tamil", txtLocationNameInTamil, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbStockApplicable.SelectedItem) == "" || Convert.ToString(cmbStockApplicable.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbStockApplicable, "Please select stock applicable");
                    cmbStockApplicable.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStoctApplicable.ShowAlways = true;
                    tpStoctApplicable.Show("Please select stock applicable", cmbStockApplicable, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epLocation.SetError(txtShortName, "Please enter short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInTamil.ShowAlways = true;
                    tpLocationTypeInTamil.Show("Please  enter short name", txtShortName, 5000);
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
            }
        }
        private void CP_Location_KeyDown(object sender, KeyEventArgs e)
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
        private void Rboutside_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //rbActive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbActive_KeyDown(object sender, KeyEventArgs e)
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
        private void RbInactive_KeyDown(object sender, KeyEventArgs e)
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
        private void CP_Location_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varUpdate == 0)
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epLocation.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbLocationType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbLocationType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbLocationType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbLocationType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLocationNameInEnglish.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbLocationType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbLocationType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbLocationType.SelectedItem) == "" || Convert.ToString(cmbLocationType.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbLocationType, "Please select location type");
                    cmbLocationType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationType.ShowAlways = true;
                    tpLocationType.Show("Please select location type", cmbLocationType, 5000);
                }
                else
                {
                    epLocation.Clear();
                    cmbLocationType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocationNameInEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLocationNameInEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocationNameInEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLocationNameInTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocationNameInEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtLocationNameInEnglish.Text).Trim() == "")
                {
                    epLocation.SetError(txtLocationNameInEnglish, "Please enter location name in english");
                    txtLocationNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInEnglish.ShowAlways = true;
                    tpLocationTypeInEnglish.Show("Please enter location name in english", txtLocationNameInEnglish, 5000);
                }
                else
                {
                    epLocation.Clear();
                    txtLocationNameInEnglish.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocationNameInTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLocationNameInTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocationNameInTamil_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtLocationNameInTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtLocationNameInTamil.Text).Trim() == "")
                {
                    epLocation.SetError(txtLocationNameInTamil, "Please enter location name in tamil");
                    txtLocationNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInTamil.ShowAlways = true;
                    tpLocationTypeInTamil.Show("Please enter location name in tamil", txtLocationNameInTamil, 5000);
                }
                else
                {
                    epLocation.Clear();
                    txtLocationNameInTamil.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbInside_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInside.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbInside_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInside.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStockApplicable_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStockApplicable.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStockApplicable_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbStockApplicable_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbStockApplicable_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbStockApplicable.SelectedItem) == "" || Convert.ToString(cmbStockApplicable.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbStockApplicable, "Please select stock applicable");
                    cmbStockApplicable.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationType.ShowAlways = true;
                    tpLocationType.Show("Please select stock applicable", cmbStockApplicable, 5000);
                }
                else
                {
                    epLocation.Clear();
                    cmbStockApplicable.BackColor = Color.White;
                }
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
        private void RbInactive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbInactive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbInside_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStockApplicable.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Rboutside_Enter(object sender, EventArgs e)
        {
            try
            {
                rbOutside.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Rboutside_Leave(object sender, EventArgs e)
        {
            try
            {
                rbOutside.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtShortName_Leave(object sender, EventArgs e)
        { 
            try
            {
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epLocation.SetError(txtShortName, "Please enter short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInTamil.ShowAlways = true;
                    tpLocationTypeInTamil.Show("Please  enter short name", txtShortName, 5000);
                }
                else
                {
                    epLocation.Clear();
                    txtShortName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtShortName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlGodownType.Enabled)
                    {
                        rbInside.Focus();
                    }
                    else
                    {
                        cmbStockApplicable.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtShortName_Enter(object sender, EventArgs e)
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

        private void CmbLocationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbLocationType.SelectedValue) == 9)
            {
                pnlGodownType.Enabled = true;
                rbInside.Checked = true;
            }
            else
            {
                pnlGodownType.Enabled = false;
                rbInside.Checked = false;
            }
        }

        private void CmbStockApplicable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(btnSave.Text=="Save")
            {
                cmbStockApplicable.SelectedValue = 11;
            }
        }
    }
}
