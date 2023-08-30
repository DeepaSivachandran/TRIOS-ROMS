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

        public int varShopLocationId = -1;
        public string varsubgroupcode;
        public String pbFormStatus;

        public int varStatusid = 1;
        public int varCloseFlag = 0;
        //public int varFormFlag = 0;
        public string varSubGroupNameinTamil = "";
        public string varSubGroupNameinEnglish = "";
        public int varProductName = -1;
        public string varBatchNo = "";
        public int varBatchId = -1;
        public int varStockLocation = -1;
        public int varRack = -1;
        public int varId = 0;
        public int varStatus = 0;
        public int varGroupCode = 0, varmastertype=0,varSubgroupCode=0;
        

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
        public void udfnLoadCmbGroupName()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_ProductGroup", "PRGID not in (0)", "PRG_EName,PRGID", cmbGroupName, "", "PRG_EName", "PRGID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         public void udfnLoadcmbShopLocation()
         {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_StockLocation", "SLID NOT IN(0)", "SLID,SL_EName", cmbStockLocation, "", "SL_EName", "SLID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
         }
        public void udfnLoadcmbRack()
        {
            try
            {
                DataBind objDataBind = new DataBind();
               
                objDataBind.BindComboBoxListSelected("MR_Rack", "RK_SLID="+varShopLocationId+"  OR RKID=-1 ", "RK_Name,RKID", cmbRack, "", "RK_Name", "RKID");
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
                udfnLoadCmbGroupName();
                udfnLoadCmbBatchNo();
                udfnLoadcmbShopLocation();
                
                BeginInvoke(new Action(() => cmbGroupName.Select(int.MaxValue, 0)));
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

        public void udfnEdit()
        {
            try
            {
                cmbGroupName.SelectedValue = varProductName;
                txtESubGroupNameEnglish.Text = varSubGroupNameinEnglish;
                txtESubGroupNameTamil.Text = varSubGroupNameinTamil;
                cmbBatchNo.SelectedValue = varBatchId;
                cmbStockLocation.SelectedValue = varStockLocation;
                cmbRack.SelectedValue = varRack;
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
        }
        public void udfnClear()
        {
            try
            {
                cmbGroupName.SelectedValue = -1;
                txtESubGroupNameEnglish.Text = "";
                txtESubGroupNameTamil.Text = "";
                cmbBatchNo.SelectedValue = -1;
                cmbStockLocation.SelectedValue = -1;
                cmbRack.SelectedValue = -1;
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
                // else
                // {
                //     varResult = objDser.udfnSubGroup(1, varId, Convert.ToInt16(cmbGroupName.SelectedValue), Convert.ToString(txtESubGroupNameEnglish.Text), Convert.ToString(txtESubGroupNameTamil.Text), varStatusid, Convert.ToInt16(cmbBatchNo.SelectedValue), Convert.ToInt16(cmbStockLocation.SelectedValue), Convert.ToInt16(cmbRack.SelectedValue), "Product Sub Group Updation");
                // }
                varResult = objDser.udfnSubGroup(varViewType, varId, Convert.ToInt16(cmbGroupName.SelectedValue), Convert.ToString(txtESubGroupNameEnglish.Text), Convert.ToString(txtESubGroupNameTamil.Text), varStatusid, Convert.ToInt16(cmbBatchNo.SelectedValue), Convert.ToInt16(cmbStockLocation.SelectedValue), Convert.ToInt16(cmbRack.SelectedValue), varOriginator);
                objDser.CloseConnection();
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
                            varCloseFlag = 1;
                            udfnclose();
                        }
                        else
                        {
                            MainForm.objCP_SubGroupList.udfnList();
                            MainForm.objCP_SubGroupList.udfnLoadCmbProductSubGroup();
                            udfnLoadCmbGroupName();
                        }
                        udfnClear();
                        udfnLoadCmbGroupName();
                    }
                    else
                    {
                        varCloseFlag = 1;
                        udfnclose();
                    }
                    MainForm.objCP_SubGroupList.udfnList();
                    MainForm.objCP_SubGroupList.udfnLoadCmbProductSubGroup();
                }
                else if (varResult.Split('~')[0] == "4")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                bool blnErrorFlag = false;
                if (Convert.ToString(cmbGroupName.SelectedValue) == "0" || Convert.ToString(cmbGroupName.SelectedValue) == "-1")
                {
                    epSubGroup.SetError(cmbGroupName, "Please select product group name");
                    cmbGroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupName.ShowAlways = true;
                    tpGroupName.Show("Please select group name", cmbGroupName, 5000);
                    blnErrorFlag = true;
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
              
                if (blnErrorFlag == false)
                {
                    udfnSave(sender, e);
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
                udfnLoadCmbGroupName();
                cmbGroupName.SelectedValue = Convert.ToInt16(varGroupCode);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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
        private void txtESubGroupNameEnglish_Enter(object sender, EventArgs e)
        {
            try
            {  
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
        private void CmbRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbRack.Select(int.MaxValue, 0)));
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbGroupName_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGroupName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbGroupName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbGroupName.SelectedValue) == "-1")
                {
                    epSubGroup.SetError(cmbGroupName, "Please select product group name");
                    cmbGroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupName.ShowAlways = true;
                    tpGroupName.Show("Please select product group name", cmbGroupName, 5000);
                }
                else
                {
                    epSubGroup.Clear();
                    cmbGroupName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbGroupName_KeyPress(object sender, KeyPressEventArgs e)
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
                    cmbStockLocation.Focus();
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
        private void CmbRack_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbRack_Leave(object sender, EventArgs e)
        {
            try
            {
               
              cmbRack.BackColor = Color.White;
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbRack_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled)
                    {
                        rbActive.Focus();
                    }
                    else
                    { btnSave.Focus(); }
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
        private void CmbGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbGroupName.Select(int.MaxValue, 0)));
              
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbStockLocation.SelectedValue) == "0" || Convert.ToString(cmbStockLocation.SelectedValue) == "-1")
                {
                    epSubGroup.SetError(cmbStockLocation, "Please select shop location");
                    cmbStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpShopLocation.ShowAlways = true;
                    tpShopLocation.Show("Please select shop location.", cmbStockLocation, 5000);
                }
                else
                {
                    cmbStockLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRack.Focus();
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStockLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbStockLocation.Select(int.MaxValue, 0)));
                varShopLocationId = Convert.ToInt32(cmbStockLocation.SelectedValue);
                udfnLoadcmbRack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStockLocation_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
