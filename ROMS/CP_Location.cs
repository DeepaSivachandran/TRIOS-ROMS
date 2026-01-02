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
    //Created By:-Sathish ; Created On:-17-08-2023
    public partial class CP_Location : Form
    {
        MainForm objMainForm = new MainForm();
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
        public string varUserID = "";
        public int PbConcernID = 0;
        public int PbLocationTypeID=0;
        public int PbStockApplicableID = 0;
        public string PbDefault;
        public string PbRKCreationID;
        public string PbRKGCreationID;
        public int PbStatus = 0;
        public int PbGodownTypeStatus = 0;
        public int varUpdate = 0;
        public int varFormFlag = 0;
        public int varStockApplicableId = 0;
        public int saveflag = 0;
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
                cmbStockApplicable.SelectedIndex = 2;
                cmbLocationType.Focus();
                chkRKCreation.Enabled = true;
                chkRKCreation.Checked = false;
                chkRKGCreation.Checked = false;
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
                if (varFormFlag == 0)
                {
                    MainForm.objCP_LocationList.udfnList();
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
        private void CP_Location_Load(object sender, EventArgs e)
        {
            try
            {
                chkRKGCreation.Enabled = false;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                int varViewType = 4;
                if (btnSave.Text == "Save")
                {
                    varViewType = 3;
                }
                objDs = objdserv.udfnCompanyList(varViewType, PbConcernID, MainForm.pbUserID, MainForm.pbIpAddress,0);
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
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_MASTER", " MST_TransactionID in (0,3) and MSTID !=0 Order by MSTID", "MST_DisplayText,MSTID", cmbLocationType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_MASTER", " MST_TransactionID in (0,4) and MSTID !=0 Order by MSTID", "MST_DisplayText,MSTID", cmbStockApplicable, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                if (MainForm.objCP_LocationList.varStockApplicable == 1)
                {
                    cmbStockApplicable.SelectedValue = 12;
                }
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    udfnLoad();
                    if (btnSave.Visible)
                    {
                        if (Convert.ToInt32(cmbStockApplicable.SelectedValue) == 11)
                        {
                            pnlStatus.Enabled = false;
                        }
                        else
                        {
                            pnlStatus.Enabled = true;
                        }
                        //pnlGodownType.Enabled = true;
                    }
                }
                if (varFormFlag != 0)
                {
                    //MainForm.objCP_LocationList.picLoader.Visible = false;
                    //MainForm.objCP_LocationList.picLoader.SendToBack();
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
                //if (PbGodownTypeStatus != 0)
                //{
                    if (PbGodownTypeStatus == 86)
                    { rbInside.Checked = true; }
                    else
                    { rbOutside.Checked = true; }
                //}
                pnlStatus.Enabled = true;
                if (PbStatus == 1) { rbActive.Checked = true; } else { rbInactive.Checked = true; }
                if (PbStockApplicableID==11) { varStockApplicableId = PbStockApplicableID; }
                if (PbRKCreationID == "1") { chkRKCreation.Checked = true; } else { chkRKCreation.Checked = false; }
                if (PbRKGCreationID == "1") { chkRKGCreation.Checked = true; } else { chkRKGCreation.Checked = false; }
                if (PbDefault=="1" || PbDefault=="2")
                {
                    cmbConcern.Enabled = false;
                    cmbLocationType.Enabled = false;
                    txtLocationNameInEnglish.Enabled = false;
                    txtLocationNameInTamil.Enabled = false;
                    txtShortName.Enabled = false;
                    pnlGodownType.Enabled = false;
                    cmbStockApplicable.Enabled = false;
                    pnlStatus.Enabled = false;
                    chkRKCreation.Enabled = false;
                    chkRKGCreation.Enabled = false;
                }
                if (PbStatus == 2)
                {
                    udfnDisable();
                }
                else
                {
                    if (PbStockApplicableID == 11)
                    {
                        DataSet objDS;
                        SPDataService objdserv = new SPDataService();
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 34;
                        objMR_Location.paraLocationId = varlocationcode;
                        objDS = objdserv.udfnStockLocationList(objMR_Location);
                        objdserv.CloseConnection();
                        if (objDS != null)
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToInt16(objDS.Tables[0].Rows[0]["Flag"]) == 0)
                                { cmbStockApplicable.Enabled = true; }
                                else
                                { cmbStockApplicable.Enabled = false; }
                            }
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
        public void udfnDisable()
        {
            cmbConcern.Enabled = false;
            cmbLocationType.Enabled = false;
            cmbStockApplicable.Enabled = false;
            txtLocationNameInEnglish.Enabled = false;
            txtLocationNameInTamil.Enabled = false;
            txtShortName.Enabled = false;
            pnlGodownType.Enabled = false;
            chkRKCreation.Enabled = false;
            chkRKGCreation.Enabled = false;
            this.ActiveControl = rbInactive;
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

                //if (pnlGodownType.Enabled == false)
                //{
                //    rbInside.Checked = false;
                //    rbOutside.Checked = false;
                //    varGodownType = 0;
                //}
                //else
                //{
                    if (rbInside.Checked == true)
                    {
                        varGodownType = 86; 
                    }
                    else
                    {
                        varGodownType = 87;
                    }
                //}
                int RKCheck = 0;
                if(chkRKCreation.Checked==true)
                {
                    RKCheck = 1;
                }
                else
                {
                    RKCheck = 0;
                }
                int RKGCheck = 0;
                if (chkRKGCreation.Checked == true)
                {
                    RKGCheck = 1;
                }
                else
                {
                    RKGCheck = 0;
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
                int varVerify = 0;
                if (btnSave.Text == "Update")
                {
                    if (varStockApplicableId == Convert.ToInt32(cmbStockApplicable.SelectedValue))
                    { varVerify = 1; }
                    if (Convert.ToInt32(cmbStockApplicable.SelectedValue) == 12) { varVerify = 1; }
                }
                else
                {
                    varVerify = 1;
                    saveflag = 0;
                }
                if (varVerify == 0)
                {
                    saveflag = 1;
                    MainForm.objCP_SL_Verify = new CP_SL_Verify();
                    MainForm.objCP_SL_Verify.ShowDialog();
                    varVerify = MainForm.objCP_SL_Verify.flag;
                    varUserID = MainForm.objCP_SL_Verify.varUserId;
                }
                else
                {
                    varUserID = MainForm.pbUserID;
                }
                if (saveflag == 0)
                {
                    varResult = objspservice.udfnStockLocation(varType, varlocationcode, Convert.ToInt16(cmbConcern.SelectedValue), Convert.ToInt16(cmbLocationType.SelectedValue), (txtLocationNameInEnglish.Text).Trim(), (txtLocationNameInTamil.Text).Trim(), (txtShortName.Text).Trim(), varGodownType, Convert.ToInt16(cmbStockApplicable.SelectedValue), varstatus, varoriginator, MainForm.pbUserID,RKCheck,RKGCheck,0);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*modified by deepa on 15-09-2023*/
                        if (varFormFlag == 1)
                        {
                            varFormFlag = 0;
                            MainForm.objCP_SubGroup.varStockLocationName = txtLocationNameInEnglish.Text;
                            MainForm.objCP_SubGroup.varLocationCode = Convert.ToInt16(varResult.Split('~')[2]);
                            varUpdate = 1;
                            udfnclose();
                        }
                        else
                        {
                            MainForm.objCP_LocationList.udfnList();
                        }
                        if (btnSave.Text == "Update")
                        {
                            varUpdate = 1;
                            udfnclose();
                        }
                        udfnclear();
                        objMainForm.udfnUserMappedLocations();
                    }
                    else
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = true;
                        btnSave.Focus();
                    }
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    cmbStockApplicable.Focus();
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
                    if (chkRKCreation.Enabled == true)
                    {
                        chkRKCreation.Focus();
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
        private void RbInactive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    chkRKCreation.Focus();
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
                    if (pnlStatus.Enabled==true)
                    {
                        if(rbActive.Checked==true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInactive.Focus();
                        }
                    }
                    else { chkRKCreation.Focus(); }
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
                    if (pnlGodownType.Enabled==true)
                    {
                        if(rbInside.Checked==true)
                        {
                            rbInside.Focus();
                        }
                        else
                        {
                            rbOutside.Focus();
                        }
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
                rbInside.Checked = true;
            }
        }
        private void CmbStockApplicable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    if (Convert.ToInt32(cmbStockApplicable.SelectedValue)== 11)
                    {
                        pnlStatus.Enabled = false;
                        rbActive.Checked = true;
                    }
                    else
                    {
                        pnlStatus.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkRKCreation_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRKCreation.Checked==true)
            {
                chkRKGCreation.Enabled = true;
            }
            else
            {
                chkRKGCreation.Enabled = false;
                chkRKGCreation.Checked = false;
            }
        }

        private void ChkRKCreation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(chkRKGCreation.Enabled==true)
                    {
                        chkRKGCreation.Focus();
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

        private void ChkRKGCreation_KeyDown(object sender, KeyEventArgs e)
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

        private void ChkRKCreation_Enter(object sender, EventArgs e)
        {
            try
            {
                chkRKCreation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkRKCreation_Leave(object sender, EventArgs e)
        {
            try
            {
                chkRKCreation.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkRKGCreation_Enter(object sender, EventArgs e)
        {
            try
            {
                chkRKGCreation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkRKGCreation_Leave(object sender, EventArgs e)
        {
            try
            {
                chkRKGCreation.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
