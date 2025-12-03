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
    public partial class CP_UPI : Form
    {
        DataError objError;
        private ToolTip tpREName = new ToolTip();
        private ToolTip tpRTName = new ToolTip();
        public int varRouteId = 0;
        public int PbStatus = 0;
        public int varUpdate = 0;
        public CP_UPI()
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
                    cmbConcern.DataSource = objDS.Tables[0];
                    cmbConcern.DisplayMember = "num";
                    cmbConcern.ValueMember = "num";
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
                 
               

                SPDataService objspdservice = new SPDataService();
                MR_Route objMR_Route = new MR_Route();
                objMR_Route.ViewType = varType;
                objMR_Route.paraRouteId = varRouteId; 
                objMR_Route.paraRouteEName = txtMachineName.Text.Trim(); 
                objMR_Route.paraStatusId = PbStatus; 
                objMR_Route.paraOriginator = varoriginator;
                objMR_Route.paraOrderNo = Convert.ToInt32(cmbConcern.SelectedValue); 
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
                txtMachineName.Text = ""; 
                udfnLoadSlNo();
                txtMachineName.Focus();
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
                if (Convert.ToString(txtMachineName.Text).Trim() == "")
                {
                    epRoute.SetError(txtMachineName, "Please enter route english name.");
                    txtMachineName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpREName.ShowAlways = true;
                    tpREName.Show("Please enter route english name.", txtMachineName, 5000);
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
                        txtMachineName.Enabled = false; 
                        cmbConcern.Enabled = false;
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
                                txtMachineName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["R_EName"]); 
                                cmbConcern.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["R_OrderNo"]);
                                txtMachineName.Focus();
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
                txtMachineName.BackColor = Color.LemonChiffon;
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
                    cmbProvider.Focus();
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
                txtMachineName.BackColor = Color.White;
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
                cmbConcern.BackColor = Color.LemonChiffon;
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
                    cmbBank.Focus();
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
                e.Handled = true;
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
                cmbConcern.BackColor = Color.White;
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
         
        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (rbActive.Enabled == true)
                    {
                        cmbBank.Focus();
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

        private void cmbBank_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBank.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbBank_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbBank_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBank.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProvider_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProvider.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProvider_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbConcern.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProvider_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbProvider_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProvider.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDProvider_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpLogo_Enter(object sender, EventArgs e)
        {

        }
    }
}
