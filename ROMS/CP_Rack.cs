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
    public partial class CP_Rack : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpRackName = new ToolTip();
        private ToolTip tpShortName = new ToolTip();
        private ToolTip tpDescription = new ToolTip();

        public string vargroupcode;
        public String pbFormStatus;
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
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnEdit()
        {
            try
            {
                if (vargroupcode != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS = new DataSet();
                    // objDS = objspservice.udfnSPGroupList("EditLoad", vargroupcode, "0", MainForm.pbUserID, MainForm.pbIpAddress);
                    objspservice.CloseConnection();

                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            //cmbGroupType.SelectedValue = objDS.Tables[0].Rows[0]["GroupTypeCode"].ToString();
                            //txtTGroupName.Text = objDS.Tables[0].Rows[0]["GTName"].ToString().Replace("''", "'");
                            //txtEGroupName.Text = objDS.Tables[0].Rows[0]["GEName"].ToString().Replace("''", "'");
                            //txtTLabelName.Text = objDS.Tables[0].Rows[0]["GTLabelName"].ToString().Replace("''", "'");
                            //txtELabelName.Text = objDS.Tables[0].Rows[0]["GELabelName"].ToString().Replace("''", "'");
                            //udfnLoadSlNo();
                            //cmbSINO.SelectedValue = objDS.Tables[0].Rows[0]["SINO"].ToString();
                            //if (Convert.ToString(objDS.Tables[0].Rows[0]["RawCount"]) != "0" || Convert.ToString(objDS.Tables[0].Rows[0]["FinishedCount"]) != "0") {
                            //    cmbGroupType.Enabled = false;
                            //}
                            btnSave.Text = "Update";
                        }
                    }

                }
                else
                {// udfnLoadSlNo(); 
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
        public void udfnSave(object sender, EventArgs e)
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
                btnSave.Text = "Save";
                // cmbGroupType.SelectedValue = "-1";
                DataSet objDS = new DataSet();
                SPDataService objspservice = new SPDataService();
                // objDS = objspservice.udfnGetSlNo("CP_Rack", "Create", "", "");
                objspservice.CloseConnection();
                if (objDS != null)
                {
                    //cmbSINO.DataSource = objDS.Tables[0];
                    //cmbSINO.DisplayMember = "num";
                    //cmbSINO.ValueMember = "num";
                }
                //  txtTGroupName.Focus();
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
                btnSave.BackColor = Color.White;
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
                btnClose.BackColor = Color.White;
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
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

        
    }
   

}
