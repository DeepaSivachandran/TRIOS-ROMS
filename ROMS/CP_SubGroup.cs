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
        public String pbFormStatus;

        public int varStatusid = 1;
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
        public int varGroupCode = 0, varmastertype=0,varSubgroupCode=0;
        public int varLocationCode = 0, varRackCode = 0;
        

        public CP_SubGroup()
        {
            InitializeComponent();
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
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=25 OR MSTID=-1", "MST_DisplayText,MSTID", cmbBatchNo, "", "MST_DisplayText", "MSTID");
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
                udfnLoadCmbBatchNo();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnEdit();
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
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtProductGroupName.Text);
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
                lblGroupCode.Text = Convert.ToString( varGroupCode);
                txtESubGroupNameEnglish.Text = varSubGroupNameinEnglish;
                txtESubGroupNameTamil.Text = varSubGroupNameinTamil;
                cmbBatchNo.SelectedValue = varBatchId;
                txtLocation.Text = varStockLocationName;
                lblLocation.Text=Convert.ToString(varLocationCode);
                txtRack.Text = varRackName;
                lblRack.Text = Convert.ToString(varRackCode);
                varStatusid = varStatus;
                if(varStatusid==1)
                {
                    rbActive.Checked=true;
                }
                else
                {
                    rbInactive.Checked = true;
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
                lvLocation.Visible = false;
                lvRack.Visible = false;
            }
        }
        public void udfnClear()
        {
            try
            {
                txtProductGroupName.Text = "";
                txtESubGroupNameEnglish.Text = "";
                txtESubGroupNameTamil.Text = "";
                cmbBatchNo.SelectedValue = -1;
                txtLocation.Text = "";
                txtRack.Text = "";
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
                string varResult = ""; string varOriginator = "Product Sub Group Creation";
                int varViewType=0; 
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
                   varViewType=1; 
                }

                int varGroupId = 0;
                if (txtProductGroupName.Text == "")
                {
                    varGroupId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_Group = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_ProductGroup WHERE PRG_EName = '" + txtProductGroupName.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT PRGID FROM MR_ProductGroup WHERE PRG_EName = '" + txtProductGroupName.Text.Trim() + "') END AS PRGID ");
                    objDServ.CloseConnection();
                    varGroupId = Convert.ToInt32(varId_Group);
                }

                int varLocationId = 0;
                if (txtLocation.Text == "")
                {
                    varLocationId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_Location = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_StockLocation WHERE SL_EName = '" + txtLocation.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT SLID FROM MR_StockLocation WHERE SL_EName = '" + txtLocation.Text.Trim() + "') END AS SLID ");
                    objDServ.CloseConnection();
                    varLocationId = Convert.ToInt32(varId_Location);
                }
                int varRackId = 0;
                if (txtRack.Text == "")
                {
                    varRackId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_Rack = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_Rack WHERE RK_Name = '" + txtRack.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT RKID FROM MR_Rack WHERE RK_Name = '" + txtRack.Text.Trim() + "') END AS RKID ");
                    objDServ.CloseConnection();
                    varRackId = Convert.ToInt32(varId_Rack);
                }
                varResult = objDser.udfnSubGroup(varViewType, varId, varGroupId, Convert.ToString(txtESubGroupNameEnglish.Text).Trim(), Convert.ToString(txtESubGroupNameTamil.Text).Trim(), varStatusid, Convert.ToInt16(cmbBatchNo.SelectedValue), varLocationId, varRackId, varOriginator);
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
                            MainForm.objCP_Items.varGroupCode = varGroupId;
                            MainForm.objCP_Items.varGroupName = txtProductGroupName.Text.Trim();
                            MainForm.objCP_Items.varBatchCode = Convert.ToInt32(cmbBatchNo.SelectedValue);
                            MainForm.objCP_Items.varPURSLID = Convert.ToInt32(lblLocation.Text);
                            MainForm.objCP_Items.varSALESLID = Convert.ToInt32(lblLocation.Text);
                            MainForm.objCP_Items.varPURRKID = Convert.ToInt32(lblRack.Text);
                            MainForm.objCP_Items.varSALERKID = Convert.ToInt32(lblRack.Text);
                            MainForm.objCP_Items.varPurchaseLocation =txtLocation.Text.Trim();
                            MainForm.objCP_Items.varSalesLocation = txtLocation.Text.Trim();
                            MainForm.objCP_Items.varPurchaseRack = txtRack.Text.Trim();
                            MainForm.objCP_Items.varSalesRack = txtRack.Text.Trim();
                            varCloseFlag = 1;
                            udfnclose();
                        }
                        else
                        {
                            MainForm.objCP_SubGroupList.udfnList();
                        }
                        udfnClear();
                        lvGroupName.Visible = false;
                        lvLocation.Visible = false;
                        lvRack.Visible = false;
                    }
                    else
                    {
                        varCloseFlag = 1;
                        udfnclose();
                    }
                    MainForm.objCP_SubGroupList.udfnList();
                }
                else if (varResult.Split('~')[0] == "4")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); MessageBox.Show("Something went wrong,Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    DataService objDserv = new DataService();
                    VarPSGName = objDserv.displaydata("SELECT COUNT(*) AS Count FROM MR_ProductGroup WHERE PRG_EName ='" + txtProductGroupName.Text.Trim() + "'");
                    if (VarPSGName == "0")
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
                if (Convert.ToString(cmbBatchNo.SelectedValue) == "0" || Convert.ToString(cmbBatchNo.SelectedValue) == "-1")
                {
                    epSubGroup.SetError(cmbBatchNo, "Please select batch No. status");
                    cmbBatchNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBatchNo.ShowAlways = true;
                    tpBatchNo.Show("Please select batch No. status", cmbBatchNo, 5000);
                    blnErrorFlag = true;
                }
                if (txtLocation.Text.Trim() != "")
                {
                    string varLocation = "0";
                    DataService objDserv = new DataService();
                    varLocation = objDserv.displaydata("SELECT COUNT(*) AS Count FROM MR_StockLocation WHERE SL_EName ='" + txtLocation.Text.Trim() + "'");
                    if (varLocation == "0")
                    {
                        lblLocation.Text = "0";
                        epSubGroup.SetError(txtLocation, "Invalid Location");
                        txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
                }
                if (txtRack.Text.Trim() != "")
                {
                    string varRack = "0";
                    DataService objDserv = new DataService();
                    varRack = objDserv.displaydata("SELECT COUNT(*) AS Count FROM MR_Rack WHERE RK_Name ='" + txtRack.Text.Trim() + "'");
                    if (varRack == "0")
                    {
                        lblRack.Text = "0";
                        epSubGroup.SetError(txtRack, "Invalid Rack");
                        txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
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
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); MessageBox.Show("Something went wrong,Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Focus();
            }
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroupName.Visible = false;
                lvLocation.Visible = false;
                lvRack.Visible = false;
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
                MainForm.objCP_SubGroupList.udfnList();
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
                lvGroupName.Visible = false;
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
                if (txtESubGroupNameEnglish.Text.Trim()== "")
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
                    cmbBatchNo.Focus();
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
                if (txtESubGroupNameTamil.Text.Trim()== "")
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
        private void TxtProductGroupName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvGroupName.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductGroupName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7,0,0, txtProductGroupName.Text);
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
                if(e.KeyCode==Keys.Enter)
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode==Keys.Enter)
                {
                    if (lvLocation.Items.Count == 0 || txtLocation.Text == "")
                    {
                        txtRack.Focus();
                        lvLocation.Visible = false;
                    }
                    else
                    {
                        lvLocation.Focus();
                    }
                    if (lvLocation.Items.Count > 0)
                    {
                        lvLocation.Items[0].Selected = true;
                    }
                }
                if(e.KeyCode==Keys.Enter)
                {
                    txtRack.Focus();
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
                lvLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtLocation.Text.Length > 0)
                {

                    objDs = objspdservice.udfnStockLocationList(12, 0, 0,0,txtLocation.Text);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvLocation.Columns[1].Width = 0;
                                    lvLocation.Items.Add(objList);
                                }
                                lvLocation.Visible = true;
                            }
                            else
                            {
                                lvLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvLocation.Visible = false;
                    }
                }
                else
                {
                    lvLocation.Visible = false;
                    lvLocation.Items.Clear();
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
                txtRack.Focus();
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
                    txtRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLocationEvent()
        {
            try
            {
                if (txtLocation.Text != "")
                {
                    ListViewItem selectedItem = lvLocation.SelectedItems[0];
                    txtLocation.Text = selectedItem.SubItems[0].Text;
                    lblLocation.Text = selectedItem.SubItems[1].Text;
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
                lvLocation.Visible = false;
            }
        }

        private void TxtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                lvLocation.Visible = false;
                txtRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode==Keys.Enter)
                {
                    if (lvRack.Items.Count == 0 || txtRack.Text == "")
                    {
                        pnlStatus.Focus();
                        lvRack.Visible = false;
                    }
                    else
                    {
                        lvRack.Focus();
                    }
                    if (lvRack.Items.Count > 0)
                    {
                        lvRack.Items[0].Selected = true;
                    }
                }
                if(e.KeyCode==Keys.Enter)
                {
                    if (pnlStatus.Enabled == false)
                    {
                        btnSave.Focus();
                    }
                    else
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
            try
            {
                txtRack.BackColor = Color.White;
                if (txtRack.Text.Trim() == "") { lblRack.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnRackEvent();
                if (pnlStatus.Enabled == false)
                {
                    btnSave.Focus();
                }
                else
                {
                    pnlStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnRackEvent();
                    if (pnlStatus.Enabled == false)
                    {
                        btnSave.Focus();
                    }
                    else
                    {
                        pnlStatus.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRackEvent()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    lblRack.Text = selectedItem.SubItems[1].Text;
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
                lvRack.Visible = false;
            }
        }

        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRack.Text.Length > 0)
                {
                    int varLocationId = 0;
                    if (txtLocation.Text == "")
                    {
                        varLocationId = 0;
                    }
                    else
                    {
                        DataService objDServ = new DataService();
                        string varId_Location = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_StockLocation WHERE SL_EName = '" + txtLocation.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT SLID FROM MR_StockLocation WHERE SL_EName = '" + txtLocation.Text.Trim() + "') END AS SLID ");
                        objDServ.CloseConnection();
                        varLocationId = Convert.ToInt32(varId_Location);
                    }

                    objDs = objspdservice.udfnRackList(7, 0,0 ,varLocationId, 0, txtRack.Text);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_Name"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvRack.Columns[1].Width = 0;
                                    lvRack.Items.Add(objList);
                                }
                                lvRack.Visible = true;
                            }
                            else
                            {
                                lvRack.Visible = false;
                            }
                        }
                        else
                        {
                            lvRack.Visible = false;
                        }
                    }
                    else
                    {
                        lvRack.Visible = false;
                    }
                }
                else
                {
                    lvRack.Visible = false;
                    lvRack.Items.Clear();
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
    }
}
