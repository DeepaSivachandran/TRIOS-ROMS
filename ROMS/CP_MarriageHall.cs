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
    //Created By:Sathish ; Created On:-28/11/2025
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
                obj.paraMHId = pbMarriageHallId;
                obj.paraMHEName = txtMarriageHallEName.Text.Trim();
                obj.paraMHTName = txtMarriageHallTName.Text.Trim();
                obj.paraAreaId = Convert.ToInt32(lblAreaId.Text);
                obj.paraRouteId = Convert.ToInt32(lblRouteId.Text);
                obj.paraDistance = txtDistance.Text.Trim();
                obj.paraTeller = txtTeller.Text.Trim();
                obj.paraReason = txtReason.Text.Trim();
                obj.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                obj.paraOriginator = varoriginator;

                varResult = objspservice.udfnMarriageHall(obj);
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
                        txtArea.Text = "";
                        txtRoute.Text = "";
                        lblAreaId.Text = "0";
                        lblRouteId.Text = "0";
                        txtDistance.Text = "";
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
                epMarriageHall.Clear();
                bool blnErrFlag = false;
                if (txtMarriageHallEName.Text.Trim() == "")
                {
                    epMarriageHall.SetError(txtMarriageHallEName, "Please enter marriage hall english name.");
                    txtMarriageHallEName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMarriageHall.ShowAlways = true;
                    tpMarriageHall.Show("Please enter marriage hall english name.", txtMarriageHallEName, 5000);
                    blnErrFlag = true;
                }
                if (txtMarriageHallTName.Text.Trim() == "")
                {
                    epMarriageHall.SetError(txtMarriageHallTName, "Please enter marriage hall tamil name.");
                    txtMarriageHallTName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMarriageHall.ShowAlways = true;
                    tpMarriageHall.Show("Please enter marriage hall tamil name.", txtMarriageHallTName, 5000);
                    blnErrFlag = true;
                }
                if (txtArea.Text.Trim() == "")
                {
                    epMarriageHall.SetError(txtArea, "Please enter area name.");
                    txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMarriageHall.ShowAlways = true;
                    tpMarriageHall.Show("Please enter area name.", txtArea, 5000);
                    blnErrFlag = true;
                }
                else
                {
                    if (lblAreaId.Text == "0")
                    {
                        epMarriageHall.SetError(txtArea, "Please enter valid area name.");
                        txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpMarriageHall.ShowAlways = true;
                        tpMarriageHall.Show("Please enter valid area name.", txtArea, 5000);
                        blnErrFlag = true;
                    }
                }
                if (txtDistance.Text.Trim() == "")
                {
                    epMarriageHall.SetError(txtDistance, "Please enter distance.");
                    txtDistance.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMarriageHall.ShowAlways = true;
                    tpMarriageHall.Show("Please enter distance.", txtDistance, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToInt32(cmbStatus.SelectedValue) == 98)
                {
                    if (txtTeller.Text.Trim() == "")
                    {
                        epMarriageHall.SetError(txtTeller, "Please enter teller.");
                        txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpMarriageHall.ShowAlways = true;
                        tpMarriageHall.Show("Please enter teller.", txtTeller, 5000);
                        blnErrFlag = true;
                    }
                    if (txtReason.Text.Trim() == "")
                    {
                        epMarriageHall.SetError(txtReason, "Please enter reason.");
                        txtReason.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpMarriageHall.ShowAlways = true;
                        tpMarriageHall.Show("Please enter reason.", txtReason, 5000);
                        blnErrFlag = true;
                    }
                }
                if (blnErrFlag == false)
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

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STSID IN (1,2,98)", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;

                if (pbMarriageHallId == 0)
                {
                    this.ActiveControl = txtMarriageHallEName;
                    cmbStatus.SelectedValue = 1;
                    cmbStatus.Enabled = false;
                }
                else
                {
                    udfnEdit();
                    if (PbStatus == 1)
                    {
                        this.ActiveControl = txtMarriageHallEName;
                        //rbActive.Checked = true;
                    }
                    else if(PbStatus == 2)
                    {
                        //txtMarriageHallEName.Enabled = false;
                        //txtMarriageHallTName.Enabled = false;
                        //rbInActive.Checked = true;
                        //rbInActive.Focus();
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
                    obj.paraMHId = pbMarriageHallId;
                    objDs = objspservice.udfnMarriageHallList(obj);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            txtMarriageHallEName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["EName"]);
                            txtMarriageHallTName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["TName"]);
                            txtArea.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Area"]);
                            txtRoute.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Route"]);
                            txtDistance.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Distance"]);
                            txtTeller.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Teller"]);
                            txtReason.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Reason"]);
                            cmbStatus.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["STSID"]);
                            lblAreaId.Text = Convert.ToString(objDs.Tables[0].Rows[0]["AID"]);
                            lblRouteId.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RID"]);
                            lvArea.Visible = false;
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
                    txtArea.Focus();
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
                txtMarriageHallTName.BackColor = Color.White;
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

        private void txtArea_Enter(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.LemonChiffon;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvArea.Items.Count == 0 || txtArea.Text == "")
                    {
                        txtDistance.Focus();
                        lvArea.Visible = false;
                    }
                    else
                    {
                        lvArea.Focus();
                    }
                    if (lvArea.Items.Count > 0)
                    {
                        lvArea.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtDistance.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_Leave(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.White;
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
                lvArea.Items.Clear();
                if (txtArea.Text.Length > 0)
                {
                    lblAreaId.Text = "0";
                    lblRouteId.Text = "0";
                    txtRoute.Text = "";
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();

                    MR_Sales obj = new MR_Sales();
                    obj.paraViewType = 2;
                    obj.paraMHEName = txtArea.Text.Trim();
                    objDs = objspservice.udfnMarriageHallList(obj);
                    objspservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["Area"].ToString(), objDs.Tables[0].Rows[i]["Route"].ToString(), objDs.Tables[0].Rows[i]["AID"].ToString() , objDs.Tables[0].Rows[i]["RID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    lvArea.Columns[2].Width = 0;
                                    lvArea.Columns[3].Width = 0;
                                    lvArea.Items.Add(objList);
                                }
                                lvArea.Visible = true;
                            }
                            else
                            {
                                lvArea.Visible = false;
                            }
                        }
                        else
                        {
                            lvArea.Visible = false;
                        }
                    }
                    else
                    {
                        lvArea.Visible = false;
                    }
                }
                else
                {
                    lvArea.Visible = false;
                    lvArea.Items.Clear();
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
        private void txtDistance_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDistance.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDistance_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbStatus.Enabled == true)
                    {
                        cmbStatus.Focus();
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

        private void txtDistance_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDistance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReason.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReason_Enter(object sender, EventArgs e)
        {
            try
            {
                txtReason.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtReason_KeyDown(object sender, KeyEventArgs e)
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

        private void txtReason_Leave(object sender, EventArgs e)
        {
            try
            {
                txtReason.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtTeller.Enabled == true)
                    {
                        txtTeller.Focus();
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

        private void cmbStatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbStatus.SelectedValue) == 98)
                {
                    txtTeller.Enabled = true;
                    txtReason.Enabled = true;
                }
                else
                {
                    txtTeller.Enabled = false;
                    txtReason.Enabled = false;
                    txtTeller.Text = "";
                    txtReason.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnAreaEvent();
                    txtDistance.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvArea_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnAreaEvent();
                txtDistance.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAreaEvent()
        {
            try
            {
                if (txtArea.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvArea.SelectedItems[0];
                    txtArea.Text = selectedItem.SubItems[0].Text;
                    txtRoute.Text = selectedItem.SubItems[1].Text;
                    lblAreaId.Text = selectedItem.SubItems[2].Text;
                    lblRouteId.Text = selectedItem.SubItems[3].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvArea.Visible = false;
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
