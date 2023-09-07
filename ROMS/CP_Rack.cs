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
        public int varRackcode=0;
        public int varstatus;
        public string PbRackName = "";
        public string PbShortName = "";
        public string PbDescription = "";
        public string PbConcern = "";
        public string PbStockLocation = "";
        public int PbConcernID = 0;
        public int PbStockLocationID = 0;
        public int PbStatus = 0;
        public int varUpdate = 0;
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
                objDs = objdserv.udfnCompanyList(varViewType, PbConcernID, MainForm.pbUserID, MainForm.pbIpAddress);
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
               
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {

                MainForm.objCP_RackList.picLoader.Visible = false;
                MainForm.objCP_RackList.picLoader.SendToBack();
            }
        }
        private void udfnLoad()
        {
            try
            {
                txtRackName.Text = PbRackName;
                txtShortName.Text = PbShortName;
                txtDescription.Text = PbDescription;
                cmbConcern.SelectedValue = PbConcernID;
                cmbStockLocation.SelectedValue = PbStockLocationID;
                if (PbStatus == 1) { rbActive.Checked = true; } else { rbInactive.Checked = true; }
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
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
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
                varResult = objspservice.udfnRack(varType,varRackcode, Convert.ToInt16(cmbConcern.SelectedValue), Convert.ToInt16(cmbStockLocation.SelectedValue), (txtRackName.Text).Trim(), (txtShortName.Text).Trim(), (txtDescription.Text).Trim(), varstatus, varoriginator);
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_RackList.udfnList();
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
                    }
                    udfnclear();
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
                if (Convert.ToString(cmbStockLocation.SelectedValue) == "" || Convert.ToString(cmbStockLocation.SelectedValue) == "-1")
                {
                    epRack.SetError(cmbStockLocation, "Please select stock location");
                    cmbStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please select stock location", cmbStockLocation, 5000);
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
            }
        }
        private void udfnclear()
        {
            try
            {
                txtRackName.Text = "";
                txtShortName.Text = "";
                txtDescription.Text = "";
                //cmbConcern.SelectedIndex = 0;
                cmbStockLocation.SelectedIndex = 0;
                btnSave.Text = "Save";
                cmbStockLocation.Focus();
                this.ActiveControl = cmbStockLocation;
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
                // MainForm.objCP_RackList.udfnList();
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
                    cmbStockLocation.Focus();
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
        private void CmbStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRackName.Focus();
                }
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
        private void CmbStockLocation_Leave(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToString(cmbStockLocation.SelectedValue) == "" || Convert.ToString(cmbStockLocation.SelectedValue) == "-1")
                {
                    epRack.SetError(cmbStockLocation, "Please select stock location");
                    cmbStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please select stock location", cmbStockLocation, 5000);
                }
                else
                {
                    epRack.Clear();
                    cmbStockLocation.BackColor = Color.White;
                }
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
                        rbActive.Focus();
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                DataSet objDS = new DataSet();
                SPDataService objsdserv = new SPDataService();
                int varparaViewType = 9;
                if (btnSave.Text == "Save")
                {
                    varparaViewType = 8;
                }
                objDS = objsdserv.udfnStockLocationList(varparaViewType,Convert.ToInt32(cmbConcern.SelectedValue),PbStockLocationID, 0,"" );
                objsdserv.CloseConnection();
                cmbStockLocation.DataSource = null;
                if (objDS != null)
                {
                    if (objDS.Tables.Count > 0)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            cmbStockLocation.ValueMember = "SLID";
                            cmbStockLocation.DisplayMember = "SL_EName";
                            cmbStockLocation.DataSource = objDS.Tables[0];
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
        private void CmbStockLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbStockLocation.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
