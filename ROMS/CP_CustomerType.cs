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
    public partial class CP_CustomerType : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpCustomerType = new ToolTip();
        public int pbCusTypeId = 0, PbStatus = 0, varUpdate = 0;
        public CP_CustomerType()
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
                    varoriginator = "Customer Type Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Customer Type Updation";
                    varType = 1;
                }
                varResult = objspservice.udfnCustomerType(varType, pbCusTypeId, txtCustomerType.Text.Trim(), txtCustomerTypeTName.Text.Trim(), PbStatus, varoriginator);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_CustomerTypelist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        txtCustomerType.Text = "";
                        txtCustomerTypeTName.Text = "";
                        this.ActiveControl = txtCustomerType;
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
                if (txtCustomerType.Text.Trim() == "")
                {
                    epCustomerType.SetError(txtCustomerType, "Please enter customer type english name.");
                    txtCustomerType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomerType.ShowAlways = true;
                    tpCustomerType.Show("Please enter customer type english name.", txtCustomerType, 5000);
                }
                else if (txtCustomerTypeTName.Text.Trim() == "")
                {
                    epCustomerType.SetError(txtCustomerTypeTName, "Please enter customer type tamil name.");
                    txtCustomerTypeTName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCustomerType.ShowAlways = true;
                    tpCustomerType.Show("Please enter customer type tamil name.", txtCustomerTypeTName, 5000);
                }
                else
                {
                    txtCustomerType.BackColor = Color.White;
                    txtCustomerTypeTName.BackColor = Color.White;
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
                MainForm.objCP_CustomerTypelist.picLoader.Visible = false;
                MainForm.objCP_CustomerTypelist.picLoader.SendToBack();
                if (pbCusTypeId == 0)
                {
                    this.ActiveControl = txtCustomerType;
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                }
                else
                {
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1)
                    {
                        this.ActiveControl = txtCustomerType;
                        rbActive.Checked = true;
                    }
                    else if(PbStatus == 2)
                    {
                        txtCustomerType.Enabled = false;
                        txtCustomerTypeTName.Enabled = false;
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
                if (pbCusTypeId != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();
                    objDs = objspservice.udfnCustomerTypelist(1, pbCusTypeId, 0);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            txtCustomerType.Text = Convert.ToString(objDs.Tables[0].Rows[0]["CusType_Name"]);
                            txtCustomerTypeTName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["CusType_TName"]);
                            txtCustomerType.Focus();
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
                txtCustomerType.BackColor = Color.LemonChiffon;
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
                    txtCustomerTypeTName.Focus();
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
                txtCustomerType.BackColor = Color.White;
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
                txtCustomerTypeTName.BackColor = Color.LemonChiffon;
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
                txtCustomerType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_CustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
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
