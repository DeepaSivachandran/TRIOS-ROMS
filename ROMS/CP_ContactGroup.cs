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
    public partial class CP_ContactGroup : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpCustomerType = new ToolTip();
        public int pbContactGroupID = 0, PbStatus = 0, varUpdate = 0;
        public CP_ContactGroup()
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
                    varoriginator = "Customer Group Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Customer Group Updation";
                    varType = 1;
                }
                MR_Sales obj = new MR_Sales();
                obj.paraViewType = varType;
                obj.paraContactGroupId = pbContactGroupID;
                obj.paraCONGroupEName = txtCustomerGroup.Text.Trim();
                obj.paraCONGroupTName = txtCustomerGroupTName.Text.Trim();
                obj.paraStatusId = PbStatus;
                obj.paraOriginator = varoriginator; 
                varResult = objspservice.udfnContactGroup(obj);
                objspservice.CloseConnection();

                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_ContactGrouplist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        txtCustomerGroup.Text = "";
                        txtCustomerGroupTName.Text = "";
                        this.ActiveControl = txtCustomerGroup;
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
                if (txtCustomerGroup.Text.Trim() == "")
                {
                    epCustomerType.SetError(txtCustomerGroup, "Please enter customer type english name.");
                    txtCustomerGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomerType.ShowAlways = true;
                    tpCustomerType.Show("Please enter customer type english name.", txtCustomerGroup, 5000);
                }
                else if (txtCustomerGroupTName.Text.Trim() == "")
                {
                    epCustomerType.SetError(txtCustomerGroupTName, "Please enter customer type tamil name.");
                    txtCustomerGroupTName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomerType.ShowAlways = true;
                    tpCustomerType.Show("Please enter customer type tamil name.", txtCustomerGroupTName, 5000);
                }
                else
                {
                    txtCustomerGroup.BackColor = Color.White;
                    txtCustomerGroupTName.BackColor = Color.White;
                    epCustomerType.Clear();
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
                tpCustomerType.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_CustomerType_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_ContactGrouplist.picLoader.Visible = false;
                MainForm.objCP_ContactGrouplist.picLoader.SendToBack();
                if (pbContactGroupID == 0)
                {
                    this.ActiveControl = txtCustomerGroup;
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                }
                else
                {
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1)
                    {
                        this.ActiveControl = txtCustomerGroup;
                        rbActive.Checked = true;
                    }
                    else if(PbStatus == 2)
                    {
                        txtCustomerGroup.Enabled = false;
                        txtCustomerGroupTName.Enabled = false;
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
                if (pbContactGroupID != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService(); 
                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 1;
                    obj.paraContactGroupId = pbContactGroupID;
                    obj.paraStatusId = 0;
                    objDs = objspservice.udfnContactGroupList(obj);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            txtCustomerGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["CONG_EName"]);
                            txtCustomerGroupTName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["CONG_TName"]);
                            txtCustomerGroup.Focus();
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
        private void txtCustomerType_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCustomerGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCustomerGroupTName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCustomerType_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCustomerGroup.BackColor = Color.White;
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

        private void txtCustomerTypeTName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCustomerGroupTName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCustomerTypeTName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCustomerTypeTName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCustomerGroupTName.BackColor = Color.White;
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

        private void CP_CustomerType_FormClosing(object sender, FormClosingEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void CP_CustomerType_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_CustomerType_Leave(object sender, EventArgs e)
        {
            try
            {
                tpCustomerType.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
