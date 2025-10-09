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
{    //Created By:-Sathish ; Created On:-18-08-2023
    public partial class CP_Rack : Form
    {
        DataError objError;
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();    
        private ToolTip tpRackName = new ToolTip();
        private ToolTip tpShortName = new ToolTip();
        private ToolTip tpDescription = new ToolTip();
        public int varUpDownKeyLocation = 0;
        public int varRackcode=0;
        public int varstatus;
        public int varSaveFlag = 0;
        public string PbRackName = "";
        public string PbShortName = "";
        public string PbLocationName = "";
        public string PbDescription = "";
        public string PbConcern = "";
        public string PbStockLocation = "";
        public int PbConcernID = 0;
        public int varLocationCode = 0;
        public int PbStatus = 0;
        public int varUpdate = 0;
        public int varFormFlag = 0;
        public CP_Rack()
        {
            InitializeComponent();
        }
        private void CP_Rack_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpStockLocation.Active = false;
                tpRackName.Active = false;
                tpShortName.Active = false;
                tpDescription.Active = false;
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Rack_Load(object sender, EventArgs e)
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
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnLoad();
                    DGV_FilterLocation.DataSource = null;
                    DGV_FilterLocation.Visible = false;
                }
                if (varFormFlag != 0) {
                    //MainForm.objCP_RackList.picLoader.Visible = false;
                    //MainForm.objCP_RackList.picLoader.SendToBack();
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
                txtLocation.Text = PbLocationName;
                txtLocation.Enabled = false;
                lblLocationCode.Text = Convert.ToString(varLocationCode);
                txtRackName.Text = PbRackName;
                txtShortName.Text = PbShortName;
                txtDescription.Text = PbDescription;
                cmbConcern.SelectedValue = PbConcernID;
                cmbConcern.Enabled = false;
                this.ActiveControl = txtRackName;
                //cmbStockLocation.SelectedValue = PbStockLocationID;
                if (PbStatus == 1) { rbActive.Checked = true; } else { rbInactive.Checked = true; }
                if(PbStatus==2)
                {
                    udfnDisable();
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
            txtLocation.Enabled = false;
            txtRackName.Enabled = false;
            txtShortName.Enabled = false;
            txtDescription.Enabled = false;
            this.ActiveControl = rbInactive;
        }
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                if (rbActive.Checked == true) { varstatus = 1; }
                else { varstatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                varSaveFlag = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Rack Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Rack Updation";
                    varType = 1;
                }

                int varLocationId = 0;
                if (txtLocation.Text == "")
                {
                    varLocationId = 0;
                }
                else
                {
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtLocation.Text.Trim(),0,0,0,"","",0);
                    objDServ3.CloseConnection();
                    if (objDsPurLoc != null)
                    {
                        if (objDsPurLoc.Tables.Count > 0)
                        {
                            if (objDsPurLoc.Tables[0].Rows.Count > 0)
                            {
                                varLocationId = Convert.ToInt32(objDsPurLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varLocationId == -1 || varLocationId == 0) { 
                        epRack.SetError(txtLocation, "Invalid location");
                        txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Invalid location", txtLocation, 5000);
                    }
                    else
                    {
                        lblLocationCode.Text =Convert.ToString(varLocationId);
                        //Convert.ToInt32(lblLocation.Text) = varLocationId;
                        txtLocation.BackColor = Color.White;
                        tpStockLocation.ShowAlways = false;
                    }
                }
                if (varLocationId != -1)
                {
                    varResult = objspservice.udfnRack(varType, varRackcode, Convert.ToInt16(cmbConcern.SelectedValue), varLocationId, (txtRackName.Text).Trim(), (txtShortName.Text).Trim(), (txtDescription.Text).Trim(), varstatus, varoriginator,0);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        varSaveFlag = 1;
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*modified by deepa on 15-09-2023*/
                        if (varFormFlag == 1)
                        {
                            varFormFlag = 0;
                            MainForm.objCP_SubGroup.varStockLocationName = txtLocation.Text.Trim();
                            MainForm.objCP_SubGroup.varLocationCode = Convert.ToInt16(lblLocationCode.Text);
                            MainForm.objCP_SubGroup.varRackName = txtRackName.Text.Trim();
                            MainForm.objCP_SubGroup.varRackCode = Convert.ToInt16(varResult.Split('~')[2]);

                            varUpdate = 1;
                            udfnclose();
                        }
                        else
                        {
                            MainForm.objCP_RackList.udfnList();
                        }
                        if (btnSave.Text == "Update")
                        {
                            varUpdate = 1;
                            udfnclose();
                        }
                        udfnclear();
                        txtLocation.Focus();
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
                    epRack.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (txtLocation.Text == "" || lblLocationCode.Text == "0")
                {
                    epRack.SetError(txtLocation, "Please select stock location");
                    txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please select stock location", txtLocation, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtRackName.Text).Trim() == "")
                {
                    epRack.SetError(txtRackName, "Please enter rack name");
                    txtRackName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRackName.ShowAlways = true;
                    tpRackName.Show("Please enter rack name", txtRackName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epRack.SetError(txtShortName, "Please enter short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpShortName.ShowAlways = true;
                    tpShortName.Show("Please enter short name", txtShortName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtDescription.Text).Trim() == "")
                {
                    epRack.SetError(txtDescription, "Please enter description");
                    txtDescription.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDescription.ShowAlways = true;
                    tpDescription.Show("Please enter description", txtDescription, 5000);
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
        private void udfnclear()
        {
            try
            {
                txtLocation.Text = "";
                txtRackName.Text = "";
                txtShortName.Text = "";
                txtDescription.Text = "";
                //cmbConcern.SelectedIndex = 0;
                btnSave.Text = "Save";
                //cmbStockLocation.Focus();
                //this.ActiveControl = cmbStockLocation;
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
                if(varFormFlag==1)
                {
                    MainForm.objCP_SubGroup.varStockLocationName = txtLocation.Text.Trim();
                    MainForm.objCP_SubGroup.varLocationCode = Convert.ToInt16(lblLocationCode.Text);
                }
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
                if (varFormFlag == 0)
                {
                    MainForm.objCP_RackList.udfnList();
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
        private void CP_Rack_KeyDown(object sender, KeyEventArgs e)
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
        private void CP_Rack_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varUpdate == 0)
                {
                    if (varFormFlag == 1)
                    {
                        MainForm.objCP_SubGroup.varStockLocationName = txtLocation.Text.Trim();
                        MainForm.objCP_SubGroup.varLocationCode = Convert.ToInt16(lblLocationCode.Text);
                    }
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
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
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
                    epRack.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epRack.Clear();
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
                    txtLocation.Focus();
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
        private void TxtRackName_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
                txtRackName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRackName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtRackName.Text).Trim() == "")
                {
                    epRack.SetError(txtRackName, "Please enter rack name");
                    txtRackName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRackName.ShowAlways = true;
                    tpRackName.Show("Please enter rack name", txtRackName, 5000);
                }
                else
                {
                    epRack.Clear();
                    txtRackName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRackName_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtShortName_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
                txtShortName.BackColor = Color.LemonChiffon;
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
                    epRack.SetError(txtShortName, "Please enter short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpShortName.ShowAlways = true;
                    tpShortName.Show("Please enter short name", txtShortName, 5000);
                }
                else
                {
                    epRack.Clear();
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
                    txtDescription.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterLocation.DataSource = null;
                DGV_FilterLocation.Visible = false;
                txtDescription.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtDescription.Text).Trim() == "")
                {
                    epRack.SetError(txtDescription, "Please enter description");
                    txtDescription.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDescription.ShowAlways = true;
                    tpDescription.Show("Please enter description", txtDescription, 5000);
                }
                else
                {
                    epRack.Clear();
                    txtDescription.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled)
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
        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyLocation == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtLocation.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnStockLocationList(20, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtLocation.Text, 0, 0, 0, "", "", 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterLocation.Visible = true;
                                    DGV_FilterLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterLocation.Columns["SL_EName"].Width = 220;
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
                varUpDownKeyLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterLocation.Visible == false)
                {
                    txtRackName.Focus();
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
                        txtRackName.Focus();
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
                if (txtLocation.Text.Trim() == "") { lblLocationCode.Text = "0"; }
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
                    lblLocationCode.Text = Convert.ToString(DGV_FilterLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                }
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
                txtRackName.Focus();
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
                        txtRackName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
