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
{
    //Created By:-Sathish ; Created On:-11-08-2023
    public partial class CP_Route : Form
    {
        DataError objError;
        private ToolTip tpREName = new ToolTip();
        private ToolTip tpRTName = new ToolTip();
        public int varRouteId = 0;
        public int PbStatus = 0;
        public int varUpdate = 0;
        public CP_Route()
        {
            InitializeComponent();
        }
        public void udfnLoadSlNo()
        {
            try
            {
                DataSet objDS;
                if (varRouteId != 0)
                {
                    string varRID = Convert.ToString(varRouteId);
                    SPDataService objspservice = new SPDataService();
                    objDS = objspservice.udfnGetSlNo("MR_Route", "Update", "RID", varRID, "R_OrderNo");
                    objspservice.CloseConnection();
                }
                else
                {
                    SPDataService objspservice = new SPDataService();
                    objDS = objspservice.udfnGetSlNo("MR_Route ", "Create", "1=1", "", "R_OrderNo");
                    objspservice.CloseConnection();
                }
                if (objDS != null)
                {
                    cmbRSNo.DataSource = objDS.Tables[0];
                    cmbRSNo.DisplayMember = "num";
                    cmbRSNo.ValueMember = "num";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave(object sender,EventArgs e)
        {
            try
            {
                if (rbActive.Checked == true) { PbStatus = 1; }
                else { PbStatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = "";int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Route Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Route Updation";
                    varType = 1;
                }
                 
                // Create a new DataTable with only ID column
                DataTable dtArea = new DataTable();
                dtArea.Columns.Add("AID", typeof(int));

                // Filter only checked rows and get only AR_AID
                var ids = grdArea.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["clmCheckBox"].Value) == true)  // Checkbox column name
                .Select(r => Convert.ToInt32(r.Cells["AID"].Value))               // ID column
                .ToList();

                if (ids.Any())
                {
                    foreach (var id in ids)
                    {
                        dtArea.Rows.Add(id);
                    }
                }

                SPDataService objspdservice = new SPDataService();
                MR_Route objMR_Route = new MR_Route();
                objMR_Route.ViewType = varType;
                objMR_Route.paraRouteId = varRouteId;
                objMR_Route.paraRouteTName = txtRTName.Text.Trim();
                objMR_Route.paraRouteEName = txtREName.Text.Trim(); 
                objMR_Route.paraStatusId = PbStatus;
                objMR_Route.paraAreaRoute = dtArea;
                objMR_Route.paraOriginator = varoriginator;
                objMR_Route.paraOrderNo = Convert.ToInt32(cmbRSNo.SelectedValue); 
                varResult = objspdservice.udfnRoute(objMR_Route);
                objspdservice.CloseConnection();
 
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Routelist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        udfnclear();
                        MainForm.objCP_Routelist.udfnList();
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
        private void udfnclear()
        {
            try
            {
                txtREName.Text = "";
                txtRTName.Text = "";
                udfnLoadSlNo();
                udfnArea();
                txtREName.Focus();
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
                if (Convert.ToString(txtREName.Text).Trim() == "")
                {
                    epRoute.SetError(txtREName, "Please enter route english name.");
                    txtREName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpREName.ShowAlways = true;
                    tpREName.Show("Please enter route english name.", txtREName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtRTName.Text).Trim() == "")
                {
                    epRoute.SetError(txtRTName, "Please enter route tamil name.");
                    txtRTName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRTName.ShowAlways = true;
                    tpRTName.Show("Please enter route tamil name.", txtRTName, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    epRoute.Clear();
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
                    btnSave.Enabled = true;
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
                //if (varmastertype == 0)
                //{
                //    MainForm.objCP_Routelist.udfnList();
                //}
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
        private void RbInActive_Enter(object sender, EventArgs e)
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
        private void RbInActive_Leave(object sender, EventArgs e)
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

        private void CP_Route_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CP_Route_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Route_Leave(object sender, EventArgs e)
        {
            try
            {
                tpREName.Active = false;
                tpRTName.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Route_Load(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                    udfnLoadSlNo();
                    udfnArea();
                }
                else
                {
                    udfnLoadSlNo();
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1) 
                    { 
                        rbActive.Checked = true; 
                    }
                    else 
                    {
                        txtREName.Enabled = false;
                        txtRTName.Enabled = false;
                        cmbRSNo.Enabled = false;
                        rbInActive.Checked = true;
                    }
                }
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                MainForm.objCP_Routelist.picLoader.Visible = false;
                MainForm.objCP_Routelist.picLoader.SendToBack(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnArea()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                MR_Route objMR_Route = new MR_Route();
                objMR_Route.ViewType = 2; 
                objDs = objspservice.udfnRouteList(objMR_Route);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdArea.DataSource = objDs.Tables[0];
                            grdArea.Columns["AID"].Visible = false;
                            grdArea.Columns["Flag"].Visible = false;
                            grdArea.Columns["Area"].Width = 250;
                        } 
                    } 
                    objspservice.CloseConnection();
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
                if (varRouteId != 0)
                {
                    DataSet objDs = new DataSet();  
                    SPDataService objspservice = new SPDataService();
                    MR_Route objMR_Route = new MR_Route();
                    objMR_Route.ViewType = 1;
                    objMR_Route.paraRouteId = varRouteId;
                    objDs = objspservice.udfnRouteList(objMR_Route); 
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtREName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["R_EName"]);
                                txtRTName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["R_TName"]);
                                cmbRSNo.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["R_OrderNo"]);
                                txtREName.Focus();
                            }
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                // dtFlags contains ID + Flag values
                                grdArea.DataSource = objDs.Tables[1];
                                var idsToCheck = objDs.Tables[1].AsEnumerable()
                                    .Where(x => x.Field<int>("Flag") == 1)
                                    .Select(x => x.Field<int>("AID"))
                                    .ToList(); 
                                // Loop through grid rows and check only matching IDs
                                grdArea.Rows.Cast<DataGridViewRow>()
                                    .Where(r => idsToCheck.Contains(Convert.ToInt32(r.Cells["AID"].Value)))
                                    .ToList()
                                    .ForEach(r => r.Cells["clmCheckBox"].Value = true);
                                grdArea.Columns["AID"].Visible = false;
                                grdArea.Columns["Flag"].Visible = false;
                                grdArea.Columns["Area"].Width = 250;
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
        private void txtREName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtREName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtREName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    txtRTName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtREName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtREName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRTName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRTName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRTName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRSNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRTName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRTName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRSNo_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRSNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRSNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (rbActive.Enabled == true)
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

        private void cmbRSNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRSNo_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbRSNo.BackColor = Color.White;
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
    }
}
