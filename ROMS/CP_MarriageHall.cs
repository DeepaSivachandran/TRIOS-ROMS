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
    public partial class CP_MarriageHall : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpMarriageHall = new ToolTip();
        public int pbMarriageHallId = 0, PbStatus = 0, varUpdate = 0;
        public CP_MarriageHall()
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
                    varoriginator = "Marriage Hall Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Marriage Hall Updation";
                    varType = 1;
                }
                MR_Sales obj = new MR_Sales();
                obj.paraViewType = varType;
                obj.paraCusTypeId = pbMarriageHallId;
                obj.paraCusTypeEName = txtMarriageHallEName.Text.Trim();
                obj.paraCusTypeTName = txtMarriageHallTName.Text.Trim();
                obj.paraStatusId = PbStatus;
                obj.paraOriginator = varoriginator;

                //varResult = objspservice.udfnMarriageHall(obj);
                objspservice.CloseConnection();

                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_MarriageHalllist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        txtMarriageHallEName.Text = "";
                        txtMarriageHallTName.Text = "";
                        this.ActiveControl = txtMarriageHallEName;
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
                if (txtMarriageHallEName.Text.Trim() == "")
                {
                    epMarriageHall.SetError(txtMarriageHallEName, "Please enter marriage hall english name.");
                    txtMarriageHallEName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMarriageHall.ShowAlways = true;
                    tpMarriageHall.Show("Please enter marriage hall english name.", txtMarriageHallEName, 5000);
                }
                else if (txtMarriageHallTName.Text.Trim() == "")
                {
                    epMarriageHall.SetError(txtMarriageHallTName, "Please enter marriage hall tamil name.");
                    txtMarriageHallTName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMarriageHall.ShowAlways = true;
                    tpMarriageHall.Show("Please enter marriage hall tamil name.", txtMarriageHallTName, 5000);
                }
                else
                {
                    txtMarriageHallEName.BackColor = Color.White;
                    txtMarriageHallTName.BackColor = Color.White;
                    epMarriageHall.Clear();
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
                tpMarriageHall.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_MarriageHall_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_MarriageHalllist.picLoader.Visible = false;
                MainForm.objCP_MarriageHalllist.picLoader.SendToBack();
                if (pbMarriageHallId == 0)
                {
                    this.ActiveControl = txtMarriageHallEName;
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                }
                else
                {
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1)
                    {
                        this.ActiveControl = txtMarriageHallEName;
                        rbActive.Checked = true;
                    }
                    else if(PbStatus == 2)
                    {
                        txtMarriageHallEName.Enabled = false;
                        txtMarriageHallTName.Enabled = false;
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
                if (pbMarriageHallId != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();

                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 1;
                    obj.paraCusTypeId = pbMarriageHallId;
                    obj.paraStatusId = 0;
                    objDs = objspservice.udfnCustomerTypeList(obj);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            txtMarriageHallEName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["CusType_Name"]);
                            txtMarriageHallTName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["CusType_TName"]);
                            txtMarriageHallEName.Focus();
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
        private void txtMarriageHallEName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMarriageHallEName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMarriageHallEName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMarriageHallTName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMarriageHallEName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMarriageHallEName.BackColor = Color.White;
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

        private void txtMarriageHallTName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMarriageHallTName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMarriageHallTName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtMarriageHallTName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMarriageHallEName.BackColor = Color.White;
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

        private void CP_MarriageHall_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CP_MarriageHall_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_MarriageHall_Leave(object sender, EventArgs e)
        {
            try
            {
                tpMarriageHall.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
