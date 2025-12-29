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
    public partial class CP_SubGroup : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpGroupName = new ToolTip();
        private ToolTip tpSubGroupNameInEnglish = new ToolTip();
        private ToolTip tpSubGroupNameInTamil = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpShopLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();

        public string varsubgroupcode;
        public string pbFormStatus;
        DataSet objRackList = new DataSet();
        DataTable dtRackList = new DataTable();

        public int varStatusid = 1, varUpDownKeyLocation = 0;
        public int varCloseFlag = 0;
        public string varSubGroupNameinTamil = "";
        public string varSubGroupNameinEnglish = "";
        public string varGroupName = "";
        public string varBatchNo = "";
        public string varProductGroupName = "";
        public int varProductGroupCode = 0;
        public int varBatchId = -1;
        public string varStockLocationName = "";
        public string varRackName = "";
        public int varId = 0;
        public int varStatus = 0;
        public int varGroupCode = 0, varmastertype = 0, varSubgroupCode = 0;
        public int varLocationCode = 0, varRackCode = 0;
        public string varRackCodes = "";
        public int varSortFlag = 0;
        public int varSubgroupType = 0;
        public string VarRackCreation = "0";
        public string GroupPrivilege = "", LocationPrivilege="",RackPrivilege="";
        public CP_SubGroup()
        {
            InitializeComponent();
        }
        public void udfnLvHide()
        {
            try
            {
                lvGroupName.Visible = false;
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_SubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                tpGroupName.Active = false;
                tpSubGroupNameInEnglish.Active = false;
                tpSubGroupNameInTamil.Active = false;
                tpBatchNo.Active = false;
                tpShopLocation.Active = false;
                tpRack.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnLoadCmbBatchNo()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=25 ", "MST_DisplayText,MSTID", cmbBatchNo, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=92 ", "MST_DisplayText,MSTID", cmbSubgroupType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_SubGroup_Load(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterLocation.ColumnHeadersDefaultCellStyle.Font = new Font("Oswald Regular", 10.75f, FontStyle.Regular);

                dtRackList = new DataTable();
                dtRackList.Columns.Add("", typeof(Boolean));
                dtRackList.Columns.Add("Rack Name", typeof(string));
                dtRackList.Columns.Add("Rack Description", typeof(string));
                dtRackList.Columns.Add("RKID", typeof(int));
                dtRackList.Columns.Add("Rack ShortName", typeof(string));
                udfnLoadCmbBatchNo();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    varSortFlag = 1;
                    udfnEdit();
                }
                if (VarRackCreation == "0")
                {
                    txtRack.Enabled = false;
                    btnNewRack.Enabled = false;
                }
                else
                {
                    txtRack.Enabled = true;
                    btnNewRack.Enabled = true;
                }
                udfnUserAccess();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { //grdRackList.ColumnHeadersVisible = false;
              //  udfnSearchGridHead();
            }
        }
        public void udfnUserAccess()
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                { 
                    //Group
                    var groupresult = UserAccessHelper.LoadUserAccess(50502);
                    GroupPrivilege = groupresult.PrivilegeCode;
                    btnAdd.Visible = GroupPrivilege.Contains("2");
                    //Brand
                    var Locationresult = UserAccessHelper.LoadUserAccess(50401);
                    LocationPrivilege = Locationresult.PrivilegeCode;
                    btnewlocation.Visible = LocationPrivilege.Contains("2");
                    //Unit
                    var Rackresult = UserAccessHelper.LoadUserAccess(50402);
                    RackPrivilege = Rackresult.PrivilegeCode;
                    btnNewRack.Visible = RackPrivilege.Contains("2");
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListView()
        {
            try
            {
                lvGroupName.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductGroupName.Text.Length > 2)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtProductGroupName.Text, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvGroupName.Columns[2].Width = 200;
                                    lvGroupName.Items.Add(objList);
                                }
                                lvGroupName.Visible = true;
                            }
                            else
                            {
                                lvGroupName.Visible = false;
                            }
                        }
                        else
                        {
                            lvGroupName.Visible = false;
                        }
                    }
                    else
                    {
                        lvGroupName.Visible = false;
                    }
                }
                else
                {
                    lvGroupName.Visible = false;
                    lvGroupName.Items.Clear();
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
        public void udfnEdit()
        {
            try
            {
                txtProductGroupName.Text = varGroupName;
                lblGroupCode.Text = Convert.ToString(varGroupCode);
                txtESubGroupNameEnglish.Text = varSubGroupNameinEnglish;
                txtESubGroupNameTamil.Text = varSubGroupNameinTamil;
                cmbBatchNo.SelectedValue = varBatchId;
                cmbSubgroupType.SelectedValue = varSubgroupType;
                txtLocation.Text = varStockLocationName;
                lblLocation.Text = Convert.ToString(varLocationCode);
                udfnLoadRackList();
                // txtRack.Text = varRackName;
                // lblRack.Text = Convert.ToString(varRackCode);
                string[] varRkIds = varRackCodes.Split(',');
                for (int i = 0; i < dtRackList.Rows.Count; i++)
                {
                    for (int j = 0; j < varRkIds.Length; j++)
                    {
                        if (varRkIds[j] == Convert.ToString(dtRackList.Rows[i]["RKID"]))
                        {
                            dtRackList.Rows[i][0] = true;
                        }
                    }
                }
                dtRackList.DefaultView.Sort = dtRackList.Columns[0].ColumnName + " DESC";
                dtRackList = dtRackList.DefaultView.ToTable();
                grdRackList.DataSource = null;
                grdRackList.DataSource = dtRackList;
                grdRackList.Columns["Column1"].HeaderText = "";
                grdRackList.Columns["Column1"].Width = 80;
                grdRackList.Columns["Rack Name"].Width = 80;
                grdRackList.Columns["Rack Name"].ReadOnly = true;
                grdRackList.Columns["Rack Description"].Width = 270;
                grdRackList.Columns["Rack Description"].ReadOnly = true;
                grdRackList.Columns["RKID"].Visible = false;
                grdRackList.Columns["Rack ShortName"].Visible = false;
                grdRackList.Columns[0].Width = 30;
                varStatusid = varStatus;
                if (varStatusid == 1)
                {
                    rbActive.Checked = true;
                }
                else
                {
                    rbInactive.Checked = true;
                }
                if (varStatus == 2)
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
                lvGroupName.Visible = false;
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
                // lvRack.Visible = false;
            }
        }
        public void udfnDisable()
        {
            txtProductGroupName.Enabled = false;
            btnAdd.Enabled = false;
            txtESubGroupNameEnglish.Enabled = false;
            txtESubGroupNameTamil.Enabled = false;
            cmbBatchNo.Enabled = false;
            txtLocation.Enabled = false;
            btnewlocation.Enabled = false;
            btnNewRack.Enabled = false;
            txtRack.Enabled = false;
            grdRackList.ReadOnly = true;
            this.ActiveControl = rbInactive;
        }
        public void udfnClear()
        {
            try
            {
                txtProductGroupName.Text = "";
                txtESubGroupNameEnglish.Text = "";
                txtESubGroupNameTamil.Text = "";
                cmbBatchNo.SelectedValue = -1;
                cmbSubgroupType.SelectedValue = 312;
                txtLocation.Text = "";
                grdRackList.DataSource = null;
                txtProductGroupName.Focus();
                tpShopLocation.Active = false;
                tpRack.Active = false;
                epSubGroup.Clear();
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
                btnSave.Enabled = false;
                txtRack.Text = "";
                string varResult = ""; string varOriginator = "Product Sub Group Creation";
                int varViewType = 0;
                if (rbActive.Checked)
                {
                    varStatusid = 1;
                }
                else
                {
                    varStatusid = 2;
                }
                SPDataService objDser = new SPDataService();
                if (btnSave.Text == "Update")
                {
                    varOriginator = "Product Sub Group Updation";
                    varViewType = 1;
                }
                string varRackId = "", varRackName = "", varRackDescription = "";
                int varcheckedcount = 0;
                for (int i = 0; i < grdRackList.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdRackList.Rows[i].Cells[0].Value) == true)
                    {
                        varcheckedcount++;
                        if (varRackId == "") { varRackId = Convert.ToString(grdRackList.Rows[i].Cells["RKID"].Value); }
                        else { varRackId = varRackId + ',' + Convert.ToString(grdRackList.Rows[i].Cells["RKID"].Value); }
                        if (varRackName == "") { varRackName = Convert.ToString(grdRackList.Rows[i].Cells["Rack ShortName"].Value); }
                        else { varRackName = varRackName + ',' + Convert.ToString(grdRackList.Rows[i].Cells["Rack ShortName"].Value); }
                        if (varRackDescription == "") { varRackDescription = Convert.ToString(grdRackList.Rows[i].Cells["Rack Description"].Value); }
                        else { varRackDescription = varRackDescription + ',' + Convert.ToString(grdRackList.Rows[i].Cells["Rack Description"].Value); }
                    }
                }
                if (grdRackList.Rows.Count > 0 && varRackId == "")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(60);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    grdRackList.Focus();
                }
                else
                {
                    varResult = objDser.udfnSubGroup(varViewType, varId, Convert.ToInt32(lblGroupCode.Text), Convert.ToString(txtESubGroupNameEnglish.Text).Trim(), Convert.ToString(txtESubGroupNameTamil.Text).Trim(), varStatusid, Convert.ToInt16(cmbBatchNo.SelectedValue), Convert.ToInt32(lblLocation.Text), 0, varOriginator, varRackId, MainForm.pbUserID, 0, Convert.ToInt32(cmbSubgroupType.SelectedValue));
                    objDser.CloseConnection();
                    btnSave.Enabled = true;
                    if (varResult.Split('~')[0] == "3")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (btnSave.Text == "Save")
                        {
                            varSubgroupCode = Convert.ToInt16(varResult.Split('~')[2]);
                            if (varmastertype == 1)
                            {
                                varmastertype = 0;
                                MainForm.objCP_Items.varSubgroupCode = varSubgroupCode;
                                MainForm.objCP_Items.varSubGroupName = txtESubGroupNameEnglish.Text;
                                MainForm.objCP_Items.varSubgroupType = cmbSubgroupType.Text;
                                MainForm.objCP_Items.varGroupCode = Convert.ToInt32(lblGroupCode.Text);
                                MainForm.objCP_Items.varGroupName = txtProductGroupName.Text.Trim();
                                MainForm.objCP_Items.varBatchCode = Convert.ToInt32(cmbBatchNo.SelectedValue);
                                MainForm.objCP_Items.varPURSLID = Convert.ToInt32(lblLocation.Text);
                                MainForm.objCP_Items.varSALESLID = Convert.ToInt32(lblLocation.Text);
                                //MainForm.objCP_Items.varPURRKID = Convert.ToInt32(lblRack.Text);
                                //MainForm.objCP_Items.varSALERKID = Convert.ToInt32(lblRack.Text);
                                MainForm.objCP_Items.varPurchaseLocation = txtLocation.Text.Trim();
                                MainForm.objCP_Items.varSalesLocation = txtLocation.Text.Trim();
                                if (varcheckedcount == 1)
                                {
                                    MainForm.objCP_Items.varPURRKID = Convert.ToInt32(varRackId);
                                    MainForm.objCP_Items.varPurchaseRack = varRackName;
                                    MainForm.objCP_Items.varRackDescription = varRackDescription;
                                }
                                else
                                {
                                    MainForm.objCP_Items.varPURRKID = 0;
                                    MainForm.objCP_Items.varPurchaseRack = "";
                                    MainForm.objCP_Items.varRackDescription = "";
                                }
                                //MainForm.objCP_Items.varPurchaseRack = txtRack.Text.Trim();
                                //MainForm.objCP_Items.varSalesRack = txtRack.Text.Trim();
                                varCloseFlag = 1;
                                udfnclose();
                            }
                            else
                            {
                                MainForm.objCP_SubGroupList.udfnList();
                            }
                            udfnClear();
                            lvGroupName.Visible = false;
                            DGV_FilterLocation.DataSource = null;
                            DGV_FilterLocation.Visible = false;
                            //   lvRack.Visible = false;
                        }
                        else
                        {
                            MainForm.objCP_SubGroupList.udfnList();
                            varCloseFlag = 1;
                            udfnclose();
                        }
                    }
                    else if (varResult.Split('~')[0] == "4")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (txtProductGroupName.Text.Trim() == "")
                {
                    epSubGroup.SetError(txtProductGroupName, "Please enter product group name");
                    txtProductGroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupName.ShowAlways = true;
                    tpGroupName.Show("Please enter product group name", txtProductGroupName, 5000);
                    blnErrorFlag = true;
                }
                if (txtProductGroupName.Text.Trim() != "")
                {
                    string VarPSGName = "0";
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtProductGroupName.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                VarPSGName = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblGroupCode.Text = Convert.ToString(VarPSGName);
                    if (VarPSGName == "0" || VarPSGName == "-1")
                    {
                        lblGroupCode.Text = "0";
                        epSubGroup.SetError(txtProductGroupName, "Invalid Group");
                        txtProductGroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
                }
                if (txtESubGroupNameEnglish.Text.Trim() == "")
                {
                    epSubGroup.SetError(txtESubGroupNameEnglish, "Please enter product sub group name in english");
                    txtESubGroupNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSubGroupNameInEnglish.ShowAlways = true;
                    tpSubGroupNameInEnglish.Show("Please enter product sub group name in english", txtESubGroupNameEnglish, 5000);
                    blnErrorFlag = true;
                }
                if (txtESubGroupNameTamil.Text.Trim() == "")
                {
                    epSubGroup.SetError(txtESubGroupNameTamil, "Please enter product sub group name in tamil");
                    txtESubGroupNameTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSubGroupNameInTamil.ShowAlways = true;
                    tpSubGroupNameInTamil.Show("Please enter product sub group name in tamil", txtESubGroupNameTamil, 5000);
                    blnErrorFlag = true;

                }
                //if (Convert.ToString(cmbBatchNo.SelectedValue) == "0" || Convert.ToString(cmbBatchNo.SelectedValue) == "-1")
                //{
                //    epSubGroup.SetError(cmbBatchNo, "Please select batch No. status");
                //    cmbBatchNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpBatchNo.ShowAlways = true;
                //    tpBatchNo.Show("Please select batch No. status", cmbBatchNo, 5000);
                //    blnErrorFlag = true;
                //}
                if (txtLocation.Text.Trim() != "")
                {
                    string varLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 14;
                    objMR_Location.paraLocationName = txtLocation.Text.Trim();
                    objDsPurLoc = objDServ3.udfnStockLocationList(objMR_Location);
                    objDServ3.CloseConnection();

                    //objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                    if (objDsPurLoc != null)
                    {
                        if (objDsPurLoc.Tables.Count > 0)
                        {
                            if (objDsPurLoc.Tables[0].Rows.Count > 0)
                            {
                                varLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblLocation.Text = Convert.ToString(varLocation);
                    if (varLocation == "0" || varLocation == "-1")
                    {
                        lblLocation.Text = "0";
                        epSubGroup.SetError(txtLocation, "Invalid Location");
                        txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
                }
                else
                {
                    lblLocation.Text = "0";
                    epSubGroup.SetError(txtLocation, "Please select stock location");
                    txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Focus();
            }
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroupName.Visible = false;
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave_Click(sender, e);
                }
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
                if (varmastertype == 0)
                {
                    MainForm.objCP_SubGroupList.udfnList();
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

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose_Click(sender, e);
                }
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
        private void CP_SubGroup_KeyDown(object sender, KeyEventArgs e)
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
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Group = new CP_Group();
                MainForm.objCP_Group.varFormFlag = 1;
                MainForm.objCP_Group.ShowDialog();
                udfnListView();
                txtProductGroupName.Text = varProductGroupName;
                lblGroupCode.Text = Convert.ToString(varGroupCode);
                lvGroupName.Visible = false;
                txtESubGroupNameEnglish.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtESubGroupNameEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnLvHide();
                txtESubGroupNameEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtESubGroupNameEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtESubGroupNameTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtESubGroupNameEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtESubGroupNameEnglish.Text.Trim() == "")
                {
                    epSubGroup.SetError(txtESubGroupNameEnglish, "Please enter product sub group name in english");
                    txtESubGroupNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSubGroupNameInEnglish.ShowAlways = true;
                    tpSubGroupNameInEnglish.Show("Please enter product sub group name in english", txtESubGroupNameEnglish, 5000);
                }
                else
                {
                    txtESubGroupNameEnglish.BackColor = Color.White;
                    epSubGroup.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtESubGroupNameTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnLvHide();
                txtESubGroupNameTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtESubGroupNameTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbBatchNo.Focus();
                    cmbSubgroupType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtESubGroupNameTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtESubGroupNameTamil.Text.Trim() == "")
                {
                    epSubGroup.SetError(txtESubGroupNameTamil, "Please enter product sub group name in tamil");
                    txtESubGroupNameTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSubGroupNameInTamil.ShowAlways = true;
                    tpSubGroupNameInTamil.Show("Please enter product sub group name in tamil", txtESubGroupNameTamil, 5000);

                }
                else
                {
                    txtESubGroupNameTamil.BackColor = Color.White;
                    epSubGroup.Clear();
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
        private void CmbBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbBatchNo.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbBatchNo_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnLvHide();
                cmbBatchNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        private void CmbBatchNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbBatchNo.SelectedValue) == "-1")
                {
                    epSubGroup.SetError(cmbBatchNo, "Please select batch No. status");
                    cmbBatchNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBatchNo.ShowAlways = true;
                    tpBatchNo.Show("Please select batch No. status", cmbBatchNo, 5000);
                }
                else
                {
                    epSubGroup.Clear();
                    cmbBatchNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLocation.Focus();
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbBatchNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CP_SubGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
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
        private void TxtProductGroupName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvGroupName.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductGroupName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtProductGroupName.Text, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvGroupName.Columns[1].Width = 0;
                                    lvGroupName.Items.Add(objList);
                                }
                                lvGroupName.Visible = true;
                            }
                            else
                            {
                                lvGroupName.Visible = false;
                            }
                        }
                        else
                        {
                            lvGroupName.Visible = false;
                        }
                    }
                    else
                    {
                        lvGroupName.Visible = false;
                    }
                }
                else
                {
                    lvGroupName.Visible = false;
                    lvGroupName.Items.Clear();
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

        private void LvGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductNameEvent();
                    txtESubGroupNameEnglish.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvGroupName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnProductNameEvent();
                txtESubGroupNameEnglish.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductNameEvent()
        {
            try
            {
                if (txtProductGroupName.Text != "")
                {
                    ListViewItem selectedItem = lvGroupName.SelectedItems[0];
                    txtProductGroupName.Text = selectedItem.SubItems[0].Text;
                    lblGroupCode.Text = selectedItem.SubItems[1].Text;
                    //    lvCity.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvGroupName.Visible = false;
            }
        }

        private void TxtProductGroupName_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
                txtProductGroupName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvGroupName.Items.Count == 0 || txtProductGroupName.Text == "")
                    {
                        txtESubGroupNameEnglish.Focus();
                        lvGroupName.Visible = false;
                    }
                    else
                    {
                        lvGroupName.Focus();
                    }
                    if (lvGroupName.Items.Count > 0)
                    {
                        lvGroupName.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtESubGroupNameEnglish.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroupName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductGroupName.Text.Trim() == "") { lblGroupCode.Text = "0"; }
                if (txtProductGroupName.Text.Trim() == "")
                {
                    epSubGroup.SetError(txtProductGroupName, "Please enter product group name");
                    txtProductGroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupName.ShowAlways = true;
                    tpGroupName.Show("Please enter product group name", txtProductGroupName, 5000);
                }
                else
                {
                    txtProductGroupName.BackColor = Color.White;
                    epSubGroup.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroupName.Visible = false;
                txtLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterLocation.Visible == false)
                {
                    if (txtRack.Enabled == true)
                    {
                        txtRack.Focus();
                    }
                    else
                    {
                        if (pnlStatus.Enabled == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            btnSave.Focus();
                        }
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterLocation.Focus();
                }
                if (DGV_FilterLocation.CurrentCell == null && DGV_FilterLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterLocation.Focus();
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnLocationEvent();
                                    DGV_FilterLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtLocation.Focus();
                    //txtLocation.SelectionStart = txtLocation.Text.Length;
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
                        if (txtRack.Enabled == true)
                        {
                            txtRack.Focus();
                        }
                        else
                        {
                            if (pnlStatus.Enabled == true)
                            {
                                rbActive.Focus();
                            }
                            else
                            {
                                btnSave.Focus();
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

        private void TxtLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLocation.BackColor = Color.White;
                if (txtLocation.Text.Trim() == "") { lblLocation.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyLocation == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtLocation.Text == "")
                    {
                        this.grdRackList.DataSource = null;
                    }
                    if (txtLocation.Text.Length > 0)
                    {
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 12;
                        objMR_Location.paraLocationName = txtLocation.Text.Trim();
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(12, 0, 0, 0, txtLocation.Text, 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    //for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    //{
                                    //    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(), objDs.Tables[0].Rows[i]["SL_RKCreation"].ToString() };
                                    //    ListViewItem objList = new ListViewItem(row);
                                    //    lvLocation.Columns[1].Width = 0;
                                    //    lvLocation.Items.Add(objList);
                                    //}
                                    //lvLocation.Visible = true;

                                    DGV_FilterLocation.Visible = true;
                                    DGV_FilterLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_RKCreation"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_EName"].HeaderText = "Location E Name";
                                    DGV_FilterLocation.Columns["SL_EName"].Width = 160;
                                    DGV_FilterLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterLocation.DataSource = null;
                                    DGV_FilterLocation.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterLocation.DataSource = null;
                                DGV_FilterLocation.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterLocation.DataSource = null;
                            DGV_FilterLocation.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterLocation.DataSource = null;
                        DGV_FilterLocation.Visible = false;
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

        private void LvLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLocationEvent();
                if (txtRack.Enabled == true)
                {
                    txtRack.Focus();
                }
                else
                {
                    if (pnlStatus.Enabled == true)
                    {
                        rbActive.Focus();
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

        private void LvLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLocationEvent();
                    if (txtRack.Enabled == true)
                    {
                        txtRack.Focus();
                    }
                    else
                    {
                        if (pnlStatus.Enabled == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            btnSave.Focus();
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
        public void udfnLoadRackList()
        {
            try
            {
                if (txtLocation.Text != "")
                {
                    SPDataService objService = new SPDataService();
                    objRackList = objService.udfnRackList(11, 0, 0, Convert.ToInt32(lblLocation.Text), 0, "", 0, 0);
                    objService.CloseConnection();
                    dtRackList.Rows.Clear();
                    if (objRackList != null)
                    {
                        if (objRackList.Tables.Count > 0)
                        {
                            if (objRackList.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < objRackList.Tables[0].Rows.Count; i++)
                                {
                                    dtRackList.Rows.Add(false, Convert.ToString(objRackList.Tables[0].Rows[i]["RK_Name"]), Convert.ToString(objRackList.Tables[0].Rows[i]["RK_Description"]), Convert.ToInt32(objRackList.Tables[0].Rows[i]["RKID"]), Convert.ToString(objRackList.Tables[0].Rows[i]["RK_ShortName"]));
                                }
                                grdRackList.DataSource = null;
                                grdRackList.DataSource = dtRackList;
                                grdRackList.Columns["RKID"].Visible = false;
                                grdRackList.Columns["Column1"].HeaderText = "";
                                //grdRackList.Columns["Rack Name"].Visible = true;
                                //grdRackList.Columns["RK_Description"].Visible = true;
                                grdRackList.Columns["Column1"].Width = 80;
                                grdRackList.Columns["Rack Name"].Width = 80;
                                grdRackList.Columns["Rack Name"].ReadOnly = true;
                                grdRackList.Columns["Rack Description"].Width = 270;
                                grdRackList.Columns["Rack Description"].ReadOnly = true;
                                grdRackList.Columns["Rack ShortName"].Visible = false;
                                grdRackList.Columns[0].Width = 30;
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
            finally
            {
                //this.grdRackList.Sort(this.grdRackList.Columns[0], ListSortDirection.Descending);
            }
        }
        public void udfnLocationEvent()
        {
            try
            {
                if (txtLocation.Text != "")
                {
                    lblLocation.Text = Convert.ToString(DGV_FilterLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                    VarRackCreation = Convert.ToString(DGV_FilterLocation.SelectedRows[0].Cells["SL_RKCreation"].Value.ToString());

                    //ListViewItem selectedItem = lvLocation.SelectedItems[0];
                    //VarRackCreation = selectedItem.SubItems[2].Text;
                    grdRackList.DataSource = null;
                    dtRackList.Rows.Clear();
                    udfnLoadRackList();
                    if (VarRackCreation == "0")
                    {
                        txtRack.Enabled = false;
                        btnNewRack.Enabled = false;
                    }
                    else
                    {
                        txtRack.Enabled = true;
                        btnNewRack.Enabled = true;
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
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
            }
        }

        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {// (grdRackList.DataSource as BindingSource).Filter = "([RK_Name]) LIKE '%" + txtRack.Text + "%'";
                dtRackList.DefaultView.RowFilter = "([Rack Name]) LIKE '%" + txtRack.Text.Trim() + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRack_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void TxtRack_KeyDown(object sender, KeyEventArgs e)
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
                            rbInactive.Focus();
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

        private void TxtRack_Leave(object sender, EventArgs e)
        {
            try { txtRack.BackColor = Color.White; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRackList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdRackList.IsCurrentCellDirty)
                {
                    grdRackList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRackList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdRackList.RowCount; i++)
                {
                    if (Convert.ToBoolean(grdRackList.SelectedRows[i].Cells[0].Value) == true)
                    {
                        for (int j = 0; j < dtRackList.Rows.Count; j++)
                        {
                            if (grdRackList.Rows[i].Cells["RKID"].Value == dtRackList.Rows[j]["RKID"])
                            {
                                { dtRackList.Rows[i][0] = true; }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < dtRackList.Rows.Count; j++)
                        {
                            if (grdRackList.Rows[i].Cells["RKID"].Value == dtRackList.Rows[j]["RKID"])
                            {
                                { dtRackList.Rows[i][0] = false; }
                            }
                        }
                    }
                }
                //grdRackList.DataSource = null;
                //grdRackList.DataSource = dtRackList;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRackList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdRackList.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubgroupType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSubgroupType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubgroupType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubgroupType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DGV_FilterLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 1;
                udfnLocationEvent();
                if (txtRack.Enabled == true)
                {
                    txtRack.Focus();
                }
                else
                {
                    if (pnlStatus.Enabled == true)
                    {
                        rbActive.Focus();
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

        private void DGV_FilterLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnLocationEvent();
                                    DGV_FilterLocation.Visible = false;
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
                        if (txtRack.Enabled == true)
                        {
                            txtRack.Focus();
                        }
                        else
                        {
                            if (pnlStatus.Enabled == true)
                            {
                                rbActive.Focus();
                            }
                            else
                            {
                                btnSave.Focus();
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

        private void CmbSubgroupType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSubgroupType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        /*added by deepa on 15-09-2023*/
        private void Btnewlocation_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Location = new CP_Location();
                MainForm.objCP_Location.varFormFlag = 1;
                MainForm.objCP_Location.ShowDialog();
                //udfnListView();
                txtLocation.Text = varStockLocationName;
                lblLocation.Text = Convert.ToString(varLocationCode);
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
                grdRackList.DataSource = null;
                dtRackList.Rows.Clear();
                udfnLoadRackList();
                grdRackList.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        /*added by deepa on 15-09-2023*/
        private void BtnNewRack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtLocation.Text.Trim()) == "")
                {
                    lblLocation.Text = "0";
                    epSubGroup.SetError(txtLocation, "Please select stock location");
                    txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                }
                else
                {
                    epSubGroup.Clear();
                    txtLocation.BackColor = Color.White;

                    MainForm.objCP_Rack = new CP_Rack();
                    MainForm.objCP_Rack.varFormFlag = 1;
                    MainForm.objCP_Rack.cmbConcern.Enabled = false;
                    MainForm.objCP_Rack.txtLocation.Text = txtLocation.Text;
                    MainForm.objCP_Rack.lblLocationCode.Text = lblLocation.Text;
                    MainForm.objCP_Rack.txtLocation.Enabled = false;
                    MainForm.objCP_Rack.ShowDialog();
                    if (MainForm.objCP_Rack.varSaveFlag == 1)
                    {
                        txtLocation.Text = varStockLocationName;
                        lblLocation.Text = Convert.ToString(varLocationCode);
                        txtRack.Text = varRackName;
                        lblRack.Text = Convert.ToString(varRackCode);
                        //  lvRack.Visible = false;
                        udfnLoadRackList();
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

        private void TxtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnLvHide();
                txtRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
