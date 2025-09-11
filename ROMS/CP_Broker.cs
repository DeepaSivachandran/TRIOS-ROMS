using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROMS.Model;

namespace ROMS
{   //Created By:-Sathish ; Created On:-24-08-2023
    public partial class CP_Broker : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpGstinNo = new ToolTip();
        private ToolTip tpBrokerName = new ToolTip();
        private ToolTip tpMobileNo = new ToolTip();
        private ToolTip tpWhatsAppNo = new ToolTip();
        private ToolTip tpAddressLine1 = new ToolTip();
        private ToolTip tpCity = new ToolTip();
        private ToolTip tpState = new ToolTip();
        private ToolTip tpPincode = new ToolTip();
        private ToolTip tpBankName = new ToolTip();
        private ToolTip tpBankShortName = new ToolTip();
        private ToolTip tpBranchName = new ToolTip();
        private ToolTip tpAccountNo = new ToolTip();
        private ToolTip tpIfsCode = new ToolTip();
        public int varModifiedFlag = 0;
        public int varCityCode;
        public int PbConcernID = 0;
        public string varCityName="";
        public int varstatus;
        public int varStateID=0;
        public string vargroupcode;
        public string varBrokerCode = "0";
        public string varBrokerid="", varstatusid = "0", varSlNo="0";
        public int varUpdate = 0;
        public String pbFormStatus;
        public int varflog = 0;
        DataSet objDTBank = new DataSet();
        public CP_Broker()
        {
            InitializeComponent();
        }
        private void udfnEdit()
        {
            try
            {
                if (varBrokerid != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objspservice.udfnBrokerList(1, Convert.ToInt32(varBrokerid),0,0,"");
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtBrokerConcern.Text = objDS.Tables[0].Rows[0]["Broker Concern"].ToString().Replace("''", "'");
                            txtGstinNo.Text = objDS.Tables[0].Rows[0]["GSTIN No."].ToString().Replace("''", "'");
                            txtBrokerName.Text = objDS.Tables[0].Rows[0]["Broker Name"].ToString().Replace("''", "'");
                            txtMobileNo.Text = objDS.Tables[0].Rows[0]["Mobile No."].ToString().Replace("''", "'"); 
                            txtWhatsAppNo.Text = objDS.Tables[0].Rows[0]["Whatsapp"].ToString().Replace("''", "'");
                            txtAddressLine1.Text = objDS.Tables[0].Rows[0]["Address1"].ToString().Replace("''", "'");
                            txtAddressLine2.Text = objDS.Tables[0].Rows[0]["Address2"].ToString().Replace("''", "'");
                            cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["Concern"].ToString();
                            cmbState.SelectedValue = objDS.Tables[0].Rows[0]["StateId"].ToString();
                            lblcityid.Text = objDS.Tables[0].Rows[0]["CityID"].ToString();
                            txtCity.Text = objDS.Tables[0].Rows[0]["City"].ToString().Replace("''", "'");
                            txtPincode.Text = objDS.Tables[0].Rows[0]["Pincode"].ToString();
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "1") { rbActive.Checked = true; } else { rbInactive.Checked = true; }
                            btnSave.Text = "Update";
                            pnlStatus.Enabled = true;
                        }
                        if (objDS.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                            {
                                grdBankDetails.Rows.Add(Convert.ToString(objDS.Tables[1].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[1].Rows[i]["Bank Name"]), Convert.ToString(objDS.Tables[1].Rows[i]["Bank Short Name"]),
                                Convert.ToString(objDS.Tables[1].Rows[i]["Branch Name"]), Convert.ToString(objDS.Tables[1].Rows[i]["Account No."]), Convert.ToString(objDS.Tables[1].Rows[i]["IFS Code"])
                                , Convert.ToString(objDS.Tables[1].Rows[i]["STATUS"]), Convert.ToString(objDS.Tables[1].Rows[i]["BankID"]), Convert.ToString(objDS.Tables[1].Rows[i]["STS"]));
                            }
                            btnSave.Text = "Update";
                        }
                    }
                }
                if(varstatus == 2)
                {
                    udfnDisable();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdBankDetails.ClearSelection();
            }
        }
        public void udfnDisable()
        {
            txtBrokerConcern.Enabled = false;
            txtGstinNo.Enabled = false;
            txtBrokerName.Enabled = false;
            txtMobileNo.Enabled = false;
            txtWhatsAppNo.Enabled = false;
            txtAddressLine1.Enabled = false;
            txtAddressLine2.Enabled = false;
            cmbState.Enabled = false;
            txtCity.Enabled = false;
            btnAdd.Enabled = false;
            txtPincode.Enabled = false;
            groupBox2.Enabled = false;
            this.ActiveControl = rbInactive;
        }
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                string varResult = "";
                udfnTextBoxColor();
                if (Convert.ToString(txtBrokerName.Text).Trim() != "" && Convert.ToString(txtBrokerConcern.Text).Trim() != "")
                {
                    if (rbActive.Checked == true) { varstatus = 1; }
                    else { varstatus = 2; }
                    int varcityid = 0;string Brokerid = "";
                    if (lblcityid.Text == "")
                    {
                        varcityid = 0;
                    }
                    else
                    {
                        varcityid = Convert.ToInt32(lblcityid.Text);
                    }
                    if (varBrokerid== "")
                    {
                        Brokerid = "0";
                    }
                    else
                    {
                        Brokerid = Convert.ToString(varBrokerid);
                    }
                    DataTable objBankTable = new DataTable();

                    string varoriginator = ""; int varType = 0;
                    if (btnSave.Text == "Save")
                    {
                        varoriginator = "Broker Creation";
                        varType = 0;
                    }
                    else
                    {
                        varoriginator = "Broker Updation";
                        varType = 1;
                    }
                    objBankTable = udfnBankSave();
                    varResult = objspservice.udfnBroker(varType, Convert.ToInt32(Brokerid) , Convert.ToInt16(cmbConcern.SelectedValue),(txtBrokerConcern.Text).Trim(),(txtGstinNo.Text).Trim(), (txtBrokerName.Text).Trim(), (txtAddressLine1.Text).Trim(), (txtAddressLine2.Text).Trim(), Convert.ToInt32(cmbState.SelectedValue), varcityid, (txtPincode.Text).Trim(), (txtWhatsAppNo.Text).Trim(), (txtMobileNo.Text).Trim(),varstatus, varoriginator, objBankTable,MainForm.pbUserID,0);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm.objCP_CP_BrokerList.udfnList();
                        udfnClear();
                        varModifiedFlag = 0;
                        txtBrokerConcern.Focus();
                        cmbConcern.Focus();
                        cmbConcern.SelectedValue = -1;
                        pnlBStatus.Enabled = false;
                        rbBankActive.Checked = true;
                        if (btnSave.Text == "Update")
                        {
                            varUpdate = 1;
                            udfnclose();
                        }
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = true;
                        btnSave.Focus();
                    }
                    grdBankDetails.Rows.Clear();
                }
                else
                {
                    if (Convert.ToString(txtBrokerName.Text).Trim() == "")
                    {
                        epBroker.SetError(txtBrokerName, "Please enter broker name");
                        txtBrokerName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpBrokerName.ShowAlways = true;
                        tpBrokerName.Show("Please enter broker name", txtBrokerName, 5000);
                    }
                    if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                    {
                        epBroker.SetError(cmbConcern, "Please select concern");
                        cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpConcern.ShowAlways = true;
                        tpConcern.Show("Please select concern", cmbConcern, 5000);
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
        public DataTable udfnBankSave()
        {
            DataTable objBankTable = new DataTable();
            try
            {
                objBankTable.TableName = "MR_Broker_Bank";
                objBankTable.Columns.Add("BRB_Name", typeof(string));
                objBankTable.Columns.Add("BRB_ShortName", typeof(string));
                objBankTable.Columns.Add("BRB_BranchName", typeof(string));
                objBankTable.Columns.Add("BRB_AccNo", typeof(string));
                objBankTable.Columns.Add("BRB_IFSC", typeof(string));
                objBankTable.Columns.Add("BRB_STSID", typeof(string));
                objBankTable.Columns.Add("BRB_BNKID", typeof(int));
                for (int i = 0; i < grdBankDetails.Rows.Count; i++)
                {
                    DataService objDser = new DataService();
                    string varvalue = "";
                    if (rbBankActive.Checked == true)
                    {
                        varstatusid = "1";
                    }
                    else
                    {
                        varstatusid = "2";
                    }
                    varvalue = objDser.displaydata("SELECT STS_Name FROM  DEF_Status where STS_ModuleID = '" + varstatusid + "'");
                    string varStatus = "1";
                    if (Convert.ToString(grdBankDetails.Rows[i].Cells["clmStatus"].Value) == varvalue)
                    {
                        varStatus = "1";
                    }
                    else
                    {
                        varStatus = "2";
                    }
                    objBankTable.Rows.Add(Convert.ToString(grdBankDetails.Rows[i].Cells["clmbankname"].Value), Convert.ToString(grdBankDetails.Rows[i].Cells["clmBankShortName"].Value),
                    Convert.ToString(grdBankDetails.Rows[i].Cells["clmbranch"].Value), Convert.ToString(grdBankDetails.Rows[i].Cells["clmaccno"].Value),
                    Convert.ToString(grdBankDetails.Rows[i].Cells["clmifscode"].Value), varStatus, Convert.ToInt16(grdBankDetails.Rows[i].Cells["clmBNKID"].Value));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return objBankTable;
        }
        public void udfnTextBoxColor()
        {
            try
            {
                txtGstinNo.BackColor = Color.White;
                txtBrokerName.BackColor = Color.White;
                txtAddressLine1.BackColor = Color.White;
                txtAddressLine2.BackColor = Color.White;
                txtMobileNo.BackColor = Color.White;
                cmbConcern.BackColor = Color.White;
                txtCity.BackColor = Color.White;
                txtWhatsAppNo.BackColor = Color.White;
                txtPincode.BackColor = Color.White;
                txtPincode.BackColor = Color.White;
                cmbBankName.BackColor = Color.White;
                txtBankShortName.BackColor = Color.White;
                txtbranchname.BackColor = Color.White;
                txtAccno.BackColor = Color.White;
                txtIFScode.BackColor = Color.White;
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
                txtBrokerConcern.Text = "";
                txtGstinNo.Text = "";
                txtBrokerName.Text = "";
                txtAddressLine1.Text = "";
                txtAddressLine2.Text = "";
                txtMobileNo.Text = "";
                cmbConcern.Text = "";
                txtCity.Text = "";
                txtWhatsAppNo.Text = "";
                txtPincode.Text = "";
                txtPincode.Text = "";
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
        public void udfnclose()
        {
            try
            {
                this.Close();
                MainForm.objCP_CP_BrokerList.udfnList();
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
        private void RbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbBankName.Enabled == true)
                    {
                        cmbBankName.Focus();
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
                    cmbBankName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Broker_Load(object sender, EventArgs e)
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>0 ORDER BY STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                objDataBind = null;
                objDs = objdserv.udfnCompanyList(varViewType,PbConcernID, MainForm.pbUserID, MainForm.pbIpAddress,0);
                objdserv.CloseConnection();
                 cmbState.SelectedValue = 27;
                cmbConcern.DataSource = null;
                pnlBStatus.Enabled = false;
                rbBankActive.Checked = true;
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
                DataService objdservice = new DataService();
                varstatusid = objdservice.displaydata("select STS_Name as name from DEF_Status where STS_ModuleID=1 AND STSID=1");
                grdBankDetails.Rows.Clear();
                udfnBankDropDownLoad();
                udfnEdit();
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvCity.Visible = false;
                MainForm.objCP_CP_BrokerList.picLoader.Visible = false;
                MainForm.objCP_CP_BrokerList.picLoader.SendToBack();
            }
        }
        private void CP_Broker_KeyDown(object sender, KeyEventArgs e)
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
        private void CP_Broker_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                        MainForm.objCP_CP_BrokerList.Show();
                        MainForm.objCP_CP_BrokerList.udfnList();
                    }
                    else
                    {
                        e.Cancel = true;
                        btnSave.Focus();
                    }
                }
                else
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
                    epBroker.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epBroker.Clear();
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
                    txtGstinNo.Focus();
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
        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                varStateID = Convert.ToInt32(cmbState.SelectedValue);
                MainForm.objCP_City = new CP_City();
                MainForm.objCP_City.varmastertype = 1;
                MainForm.objCP_City.varflog = 1;
                MainForm.objCP_City.ShowDialog();

                udfnListView();
                txtCity.Text = varCityName;
                lblcityid.Text = Convert.ToString(varCityCode);
                lvCity.Visible = false;
                txtPincode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGstinNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGstinNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGstinNo_Leave(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToString(txtGstinNo.Text).Trim() != "" && txtGstinNo.Text.Length != 15)
                {
                    epBroker.SetError(txtGstinNo, "Please enter valid GSTINNo");
                    txtGstinNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGstinNo.ShowAlways = true;
                    tpGstinNo.Show("Please enter valid GSTINNo", txtGstinNo, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtGstinNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGstinNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBrokerName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBrokerName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBrokerName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBrokerName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtBrokerName.Text).Trim() == "")
                {
                    epBroker.SetError(txtBrokerName, "Please enter broker name");
                    txtBrokerName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrokerName.ShowAlways = true;
                    tpBrokerName.Show("Please enter broker name", txtBrokerName, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtBrokerName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBrokerName_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtMobileNo_Enter(object sender, EventArgs e)
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
        private void TxtMobileNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtMobileNo.Text).Trim() == "")
                {
                    epBroker.SetError(txtMobileNo, "Please enter mobile number");
                    txtMobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNo.ShowAlways = true;
                    tpMobileNo.Show("Please enter mobile number", txtMobileNo, 5000);
                }
                if (Convert.ToString(txtMobileNo.Text).Trim() != "" && txtMobileNo.Text.Length != 10)
                {
                    epBroker.SetError(txtMobileNo, "Please enter valid mobile number");
                    txtMobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNo.ShowAlways = true;
                    tpMobileNo.Show("Please enter valid mobile number", txtMobileNo, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtMobileNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWhatsAppNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtWhatsAppNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWhatsAppNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtWhatsAppNo_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtWhatsAppNo.Text).Trim() == "")
                //{
                //    epBroker.SetError(txtWhatsAppNo, "Please enter whatsapp number");
                //    txtWhatsAppNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpWhatsAppNo.ShowAlways = true;
                //    tpWhatsAppNo.Show("Please enter whatsapp number", txtWhatsAppNo, 5000);
                //}
                if (Convert.ToString(txtWhatsAppNo.Text).Trim() != "" && txtWhatsAppNo.Text.Length != 10)
                {
                    epBroker.SetError(txtWhatsAppNo, "Please enter valid whatsapp number");
                    txtWhatsAppNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWhatsAppNo.ShowAlways = true;
                    tpWhatsAppNo.Show("Please enter valid whatsapp number", txtWhatsAppNo, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtWhatsAppNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtWhatsAppNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddressLine1.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAddressLine1_Enter(object sender, EventArgs e)
        {

            try
            {
                txtAddressLine1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAddressLine1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddressLine2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAddressLine1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtAddressLine1.Text).Trim() == "")
                {
                    epBroker.SetError(txtAddressLine1, "Please enter address line");
                    txtAddressLine1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAddressLine1.ShowAlways = true;
                    tpAddressLine1.Show("Please enter address line", txtAddressLine1, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtAddressLine1.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAddressLine2_Enter(object sender, EventArgs e)
        {
            try
            {
                lvCity.Visible = false;
                txtAddressLine2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAddressLine2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAddressLine2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAddressLine2_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtPincode_Enter(object sender, EventArgs e)
        {
            try
            {
                lvCity.Visible = false;
                txtPincode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPincode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtPincode.Text).Trim() == "")
                {
                    epBroker.SetError(txtPincode, "Please enter pincode");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPincode.ShowAlways = true;
                    tpPincode.Show("Please enter pincode", txtPincode, 5000);
                }
                if (Convert.ToString(txtPincode.Text).Trim() != "" && txtPincode.TextLength != 6)
                {
                    epBroker.SetError(txtPincode, "Please enter valid pincode");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPincode.ShowAlways = true;
                    tpPincode.Show("Please enter valid pincode", txtPincode, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtPincode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPincode_KeyDown(object sender, KeyEventArgs e)
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
                    else { btnSave.Focus(); }
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
        private void TxtBankname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBankShortName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBankShortName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBankShortName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBankShortName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtBankShortName.Text).Trim() == "")
                {
                    epBroker.SetError(txtBankShortName, "Please enter bank short name");
                    txtBankShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank short name", txtBankShortName, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtBankShortName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBankShortName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtbranchname.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtbranchname_Enter(object sender, EventArgs e)
        {
            try
            {
                txtbranchname.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtbranchname_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtbranchname.Text).Trim() == "")
                {
                    epBroker.SetError(txtbranchname, "Please enter branch name");
                    txtbranchname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBranchName.ShowAlways = true;
                    tpBranchName.Show("Please enter branch name", txtbranchname, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtbranchname.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtbranchname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAccno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAccno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAccno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAccno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtAccno.Text).Trim() == "")
                {
                    epBroker.SetError(txtAccno, "Please enter account number");
                    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAccountNo.ShowAlways = true;
                    tpAccountNo.Show("Please enter account number", txtAccno, 5000);
                }
                //else if (txtAccno.Text.Length != 20)
                //{
                //    epBroker.SetError(txtAccno, "Please enter valid account number");
                //    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpAccountNo.ShowAlways = true;
                //    tpAccountNo.Show("Please enter valid account number", txtAccno, 5000);
                //}
                else
                {
                    epBroker.Clear();
                    txtAccno.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtAccno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtIFScode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtIFScode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIFScode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtIFScode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(pnlBStatus.Enabled==true)
                    {
                        if(rbBankActive.Checked==true)
                        {
                            rbBankActive.Focus();
                        }
                        else
                        {
                            rbBankInActive.Focus();
                        }
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtIFScode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtIFScode.Text).Trim() == "")
                {
                    epBroker.SetError(txtIFScode, "Please enter IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter IFS Code", txtIFScode, 5000);
                }
                else if (txtIFScode.Text.Length != 11)
                {
                    epBroker.SetError(txtIFScode, "Please enter valid IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter valid IFS Code", txtIFScode, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtIFScode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.White;
                //txtBankname.Focus();
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
                epBroker.Clear();
                bool blnErrorFlag = false;

                //if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                //{
                //    epBroker.SetError(cmbConcern, "Please select concern");
                //    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpConcern.ShowAlways = true;
                //    tpConcern.Show("Please select concern", cmbConcern, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(txtBrokerConcern.Text).Trim() == "")
                {
                    epBroker.SetError(txtBrokerConcern, "Please enter broker concern");
                    txtBrokerConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter broker concern", txtBrokerConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtBrokerName.Text).Trim() == "")
                {
                    epBroker.SetError(txtBrokerName, "Please enter broker name");
                    txtBrokerName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrokerName.ShowAlways = true;
                    tpBrokerName.Show("Please enter broker name", txtBrokerName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtMobileNo.Text).Trim() == "")
                {
                    epBroker.SetError(txtMobileNo, "Please enter mobile number");
                    txtMobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNo.ShowAlways = true;
                    tpMobileNo.Show("Please enter mobile number", txtMobileNo, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtGstinNo.Text) != "")
                {
                    if (Convert.ToString(txtGstinNo.Text).Length != 15)
                    {
                        epBroker.SetError(txtGstinNo, "Please enter valid GSTINNo");
                        txtGstinNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpGstinNo.ShowAlways = true;
                        tpGstinNo.Show("Please enter valid GSTINNo", txtGstinNo, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtMobileNo.Text) != "")
                {
                    if (Convert.ToString(txtMobileNo.Text).Length != 10)
                    {
                        epBroker.SetError(txtMobileNo, "Please enter valid mobile number");
                        txtMobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpMobileNo.ShowAlways = true;
                        tpMobileNo.Show("Please enter valid mobile number", txtMobileNo, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtWhatsAppNo.Text) != "")
                {
                    if (Convert.ToString(txtWhatsAppNo.Text).Length != 10)
                    {
                        epBroker.SetError(txtWhatsAppNo, "Please enter valid whatsapp number");
                        txtWhatsAppNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpWhatsAppNo.ShowAlways = true;
                        tpWhatsAppNo.Show("Please enter valid whatsapp number", txtWhatsAppNo, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtAddressLine1.Text).Trim() == "")
                {
                    epBroker.SetError(txtAddressLine1, "Please enter address");
                    txtAddressLine1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAddressLine1.ShowAlways = true;
                    tpAddressLine1.Show("Please enter address", txtAddressLine1, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                {
                    epBroker.SetError(cmbState, "Please Select State Name");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please Select State Name", cmbState, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtCity.Text).Trim() == "")
                {
                    epBroker.SetError(txtCity, "Please enter city");
                    txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCity.ShowAlways = true;
                    tpCity.Show("Please enter city", txtCity, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtCity.Text) != "")
                {
                    string VarCity = "0";
                    DataSet objDsCity = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsCity = objDserv.udfnCitylist(1, txtCity.Text.Trim(), Convert.ToInt32(cmbState.SelectedValue),0);
                    objDserv.CloseConnection();
                    if (objDsCity != null)
                    {
                        if (objDsCity.Tables.Count > 0)
                        {
                            if (objDsCity.Tables[0].Rows.Count > 0)
                            {
                                VarCity = Convert.ToString(objDsCity.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (VarCity == "0" || VarCity == "-1")
                    {
                        lblcityid.Text = "0";
                        epBroker.SetError(txtCity, "Invalid city");
                        txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCity.ShowAlways = true;
                        tpCity.Show("Invalid city", txtCity, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        lblcityid.Text= VarCity;
                    }
                }
                if (Convert.ToString(txtPincode.Text).Trim() == "")
                {
                    epBroker.SetError(txtPincode, "Please enter pincode");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPincode.ShowAlways = true;
                    tpPincode.Show("Please enter pincode", txtPincode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtCity.Text) != "")
                {
                    if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                    {
                        epBroker.SetError(cmbState, "Please Select State Name");
                        cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpState.ShowAlways = true;
                        tpState.Show("Please Select State Name", cmbState, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        epBroker.Clear();
                        cmbState.BackColor = Color.White;
                        string VarCity = "0";
                        //DataService objDserv = new DataService();
                        //VarCity = objDserv.displaydata("SELECT COUNT(*) FROM MR_CITY WHERE CTY_NAME='" + txtCity.Text + "'");
                        DataSet objDsCity = new DataSet();
                        SPDataService objDserv = new SPDataService();
                        objDsCity = objDserv.udfnCitylist(2, txtCity.Text.Trim(), 0, 0);
                        objDserv.CloseConnection();
                        if (objDsCity != null)
                        {
                            if (objDsCity.Tables.Count > 0)
                            {
                                if (objDsCity.Tables[0].Rows.Count > 0)
                                {
                                    VarCity = Convert.ToString(objDsCity.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        if (VarCity == "0" || VarCity == "-1")
                        {
                            lblcityid.Text = "0";
                            epBroker.SetError(txtCity, "Invalid city");
                            txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpCity.ShowAlways = true;
                            tpCity.Show("Invalid city", txtCity, 5000);
                            blnErrorFlag = true;
                        }
                        else
                        {
                            lblcityid.Text = VarCity;
                        }
                    }

                }
                if (blnErrorFlag == false)
                {
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
                    udfnBankclear();
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
        private void CP_Broker_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpGstinNo.Active = false;
                tpBrokerName.Active = false;
                tpMobileNo.Active = false;
                tpWhatsAppNo.Active = false;
                tpCity.Active = false;
                tpState.Active = false;
                tpAddressLine1.Active = false;
                tpPincode.Active = false;
                tpBankName.Active = false;
                tpBankShortName.Active = false;
                tpBranchName.Active = false;
                tpAccountNo.Active = false;
                tpIfsCode.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                int varflag = 0;
                if (Convert.ToString(cmbBankName.SelectedValue).Trim() == "-1" || Convert.ToString(cmbBankName.SelectedValue).Trim() == "0")
                {
                    epBroker.SetError(cmbBankName, "Please select bank name");
                    cmbBankName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankName.ShowAlways = true;
                    tpBankName.Show("Please select bank name", cmbBankName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtBankShortName.Text).Trim() == "")
                {
                    epBroker.SetError(txtBankShortName, "Please enter bank short name");
                    txtBankShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank short name", txtBankShortName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtbranchname.Text).Trim() == "")
                {
                    epBroker.SetError(txtbranchname, "Please enter branch name");
                    txtbranchname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBranchName.ShowAlways = true;
                    tpBranchName.Show("Please enter branch name", txtbranchname, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtAccno.Text).Trim() == "")
                {
                    epBroker.SetError(txtAccno, "Please enter account number");
                    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAccountNo.ShowAlways = true;
                    tpAccountNo.Show("Please enter account number", txtAccno, 5000);
                    blnErrorFlag = true;
                }
                //else if (txtAccno.Text.Length != 20)
                //{
                //    epBroker.SetError(txtAccno, "Please enter valid account number");
                //    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpAccountNo.ShowAlways = true;
                //    tpAccountNo.Show("Please enter valid account number", txtAccno, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(txtIFScode.Text).Trim() == "")
                {
                    epBroker.SetError(txtIFScode, "Please enter IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter IFS Code", txtIFScode, 5000);
                    blnErrorFlag = true;
                }
                else if (txtIFScode.Text.Length != 11)
                {
                    epBroker.SetError(txtIFScode, "Please enter valid IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter valid IFS Code", txtIFScode, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    pnlBStatus.Enabled = false;
                    //if (varSlNo != "0") { varflag = 0; }
                    //else
                    //{
                    //foreach (DataGridViewRow row in grdBankDetails.Rows)
                    //{
                    //    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    //    {
                    //        string gridValue1 = row.Cells[1].Value.ToString();
                    //        string gridValue2 = row.Cells[3].Value.ToString();

                    //        if (gridValue1.ToUpper() == (txtBankname.Text).Trim().ToUpper() && gridValue2.ToUpper() == (txtbranchname.Text).Trim().ToUpper())
                    //        {
                    //            varflag = 1;
                    //        }
                    //    }
                    //}
                    foreach (DataGridViewRow row in grdBankDetails.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                        {
                            string gridValue1 = row.Cells[1].Value.ToString();
                            string gridValue2 = row.Cells[3].Value.ToString();//varSlNo
                            string varUpdateSlNo = row.Cells["clmsno"].Value.ToString();
                            string varUpdateAccNo = row.Cells["clmaccno"].Value.ToString();
                            if (varSlNo != varUpdateSlNo && varUpdateAccNo.Trim() == txtAccno.Text.Trim() && gridValue1.ToUpper() == (cmbBankName.Text).Trim().ToUpper() && gridValue2.ToUpper() == (txtbranchname.Text).Trim().ToUpper())
                            {
                                varflag = 1;
                            }
                            if (varSlNo != varUpdateSlNo && varUpdateAccNo.Trim() == txtAccno.Text.Trim())
                            {
                                varflag = 1;
                            }
                        }
                    }
                    // }
                    if (varflag == 0)
                    {
                        if (rbBankActive.Checked == true)
                        {
                            varstatusid = "Active";
                        }
                        else
                        {
                            varstatusid = "Inactive";
                        }
                        if (varSlNo == "0")
                        {
                            grdBankDetails.Rows.Add(grdBankDetails.Rows.Count + 1, (cmbBankName.Text)  , (txtBankShortName.Text).Trim().ToUpper(), (txtbranchname.Text).Trim(), (txtAccno.Text).Trim(), (txtIFScode.Text).Trim(), varstatusid,Convert.ToString(cmbBankName.SelectedValue));
                            varModifiedFlag = 1;
                        }
                        else
                        {
                            for (int i = 0; i < grdBankDetails.RowCount; i++)
                            {
                                if (Convert.ToString(grdBankDetails.Rows[i].Cells["clmsno"].Value) == varSlNo)
                                {
                                    grdBankDetails.Rows[i].Cells["clmbankname"].Value = cmbBankName.Text;
                                    grdBankDetails.Rows[i].Cells["clmBankShortName"].Value = txtBankShortName.Text.ToUpper();
                                    grdBankDetails.Rows[i].Cells["clmbranch"].Value = txtbranchname.Text;
                                    grdBankDetails.Rows[i].Cells["clmaccno"].Value = txtAccno.Text;
                                    grdBankDetails.Rows[i].Cells["clmifscode"].Value = txtIFScode.Text;
                                    grdBankDetails.Rows[i].Cells["clmStatus"].Value = varstatusid;
                                    grdBankDetails.Rows[i].Cells["clmBNKID"].Value = cmbBankName.SelectedValue;
                                    varModifiedFlag = 1;
                                }
                            }
                        }
                        udfnBankclear();
                        rbBankActive.Checked = true;
                        this.ActiveControl = cmbBankName;
                        grdBankDetails.ClearSelection();
                        btnAdd.Image = ROMS.Properties.Resources.plus;
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(45);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { grdBankDetails.ClearSelection(); }
        }
        public void udfnBankclear()
        {
            cmbBankName.SelectedValue = -1;
            txtBankShortName.Text = "";
            txtbranchname.Text = "";
            txtAccno.Text = "";
            txtIFScode.Text = "";
        }
        private void GrdBankDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdBankDetails.Columns[e.ColumnIndex].Name)
                        {
                            case "clmremovebank":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdBankDetails.Rows.RemoveAt(this.grdBankDetails.SelectedRows[0].Index);
                                for (int i = 0; i < grdBankDetails.RowCount; i++)
                                {
                                    grdBankDetails.Rows[i].Cells["clmsno"].Value = i + 1;
                                }
                                varModifiedFlag = 1;
                            }
                            break;
                        case "clmEdit":
                            cmbBankName.SelectedValue = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmBNKID"].Value);
                            txtBankShortName.Text = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmBankShortName"].Value);
                            txtbranchname.Text = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmbranch"].Value);
                            txtAccno.Text = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmaccno"].Value);
                            txtIFScode.Text = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmifscode"].Value);
                            varSlNo = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmsno"].Value);
                            varstatusid = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmStatus"].Value);
                            pnlBStatus.Enabled = true;
                            if (varstatusid == "Active")
                            {
                                rbBankActive.Checked = true;
                            }
                            else
                            {
                                rbBankInActive.Checked = true;
                            }
                            btnAdd.Image = ROMS.Properties.Resources.save16x16;
                            cmbBankName.BackColor = Color.White;
                            tpBankName.Active = false;
                            epBroker.Clear();
                            cmbBankName.Focus();
                            break;
                    } 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdBankDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdBankDetails.CurrentCell.OwningColumn.Name == "clmStatus")
                {
                    TextBox RefCode = e.Control as TextBox;
                    if (RefCode != null)
                    {
                        RefCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        RefCode.AutoCompleteCustomSource = AutoCompleteLoad();
                        RefCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else
                {
                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.None;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvCity.Items.Count == 0 || txtCity.Text == "")
                    {
                        txtCity.Focus();
                        lvCity.Visible = false;
                    }
                    else
                    {
                        lvCity.Focus();
                    }
                    if (lvCity.Items.Count > 0)
                    {
                        lvCity.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtPincode.Focus();
                    lvCity.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtCity_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtCity.Text).Trim() == "")
                {
                    epBroker.SetError(txtCity, "Please enter city");
                    txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCity.ShowAlways = true;
                    tpCity.Show("Please enter city", txtCity, 5000);
                }
                else
                {
                    epBroker.Clear();
                    txtCity.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
              //  lvCity.Visible = false;
            }
        }
        private void LvCity_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGrdevent();
                txtPincode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGrdevent();
                    txtPincode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGrdevent()
        {
            try
            {
                if (txtCity.Text != "")
                {
                    ListViewItem selectedItem = lvCity.SelectedItems[0];
                    txtCity.Text = selectedItem.SubItems[0].Text;
                    lblcityid.Text = selectedItem.SubItems[2].Text;
                    lvCity.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvCity.Visible = false;
            }
        }
        public void udfnListView()
        {
            try
            {
                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtCity.Text.Length > 2)
                {
                    objDs = objspdservice.udfnCitylist(1, txtCity.Text,0,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvCity.Items.Add(objList);
                                }
                                lvCity.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvCity.Visible = false;
                    lvCity.Items.Clear();
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
        private void TxtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {

                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtCity.Text.Length > 0)
                {
                    objDs = objspdservice.udfnCitylist(1, txtCity.Text, Convert.ToInt32(cmbState.SelectedValue), 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvCity.Items.Add(objList);
                                }
                                lvCity.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvCity.Visible = false;
                    lvCity.Items.Clear();
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
        private void TxtAccno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // This will prevent the character from being entered in the TextBox
            }
        }
        private void TxtIFScode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // This will prevent the character from being entered in the TextBox
            }
        }
        private void TxtPincode_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtWhatsAppNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtGstinNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // This will prevent the character from being entered in the TextBox
            }
        }

        private void RbBankActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbBankActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbBankActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbBankActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbBankActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbBankInActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbBankInActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbBankInActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbBankInActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbBankInActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrokerConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBrokerConcern.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrokerConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGstinNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrokerConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBrokerConcern.BackColor = Color.White;
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
                    epBroker.SetError(cmbState, "Please Select State Name.");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please Select State Name.", cmbState, 5000);
                }
                else
                {
                    epBroker.Clear();
                    cmbState.BackColor = Color.White;
                }
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
                    txtCity.Focus();
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
        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbState.Select(int.MaxValue, 0)));
                txtCity.Text = "";
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

        private void CmbBankName_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBankName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBankName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtbranchname.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBankName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbBankName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbBankName.SelectedValue) == "" || Convert.ToString(cmbBankName.SelectedValue) == "-1")
                {
                    epBroker.SetError(cmbBankName, "Please select bank name.");
                    cmbBankName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankName.ShowAlways = true;
                    tpBankName.Show("Please select bank name.", cmbBankName, 5000);
                }
                else
                {
                    epBroker.Clear();
                    cmbBankName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBankDropDownLoad()
        {
            try
            {
                objDTBank = null;
                SPDataService objDserv = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Bank objMR_Bank = new MR_Bank();
                objMR_Bank.paraViewType = 2;
                objDs = objDserv.udfnBanklist(objMR_Bank);
                objDserv.CloseConnection();
                cmbBankName.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbBankName.ValueMember = "BNKID";
                            cmbBankName.DisplayMember = "Bank";
                            cmbBankName.DataSource = objDs.Tables[0];
                            objDTBank = objDs;
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
        private void CmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                result = objDTBank.Tables[0].AsEnumerable()
                           .Where(r => r.Field<int?>("BNKID") == Convert.ToInt16(cmbBankName.SelectedValue)) // handle nulls
                           .Select(r => r.Field<string>("ShortName"))
                           .FirstOrDefault() ?? string.Empty;

                // Assign to TextBox (result will be empty string if nothing found)
                txtBankShortName.Text = result ?? string.Empty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBankDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdBankDetails.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public AutoCompleteStringCollection AutoCompleteLoad()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();
            objds = objdservice.GetDataset("select STSID as id,STS_Name as Name from DEF_Status where STS_ModuleID=1 ");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("Name") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
    }
}
